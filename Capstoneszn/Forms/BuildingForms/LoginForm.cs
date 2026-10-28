using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Capstoneszn.Forms.BuildingForms;
using Capstoneszn.Forms.SettingsForms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoginPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtLoginPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string inputUsername = txtLoginUsername.Text.Trim();
            string inputPassword = txtLoginPassword.Text;   // never trim a password

            // Blank or spaces-only entries never reach the database, so they don't
            // count as failed attempts (login attempt limit rule).
            // was: if (string.IsNullOrEmpty(inputUsername) || string.IsNullOrEmpty(inputPassword))
            if (string.IsNullOrEmpty(inputUsername) || string.IsNullOrWhiteSpace(inputPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set inside the connection block, then acted on after it closes.
            int loggedInUserId;
            bool questionsConfigured;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT u.UserId, u.Password, u.Role, u.Name,
                                            e.EmploymentStatus, e.ArchivedAt
                                     FROM Users u
                                     LEFT JOIN Employees e ON e.EmployeeID = u.EmployeeID
                                     WHERE u.Username = @Username";

                    int userId;
                    string storedHash, userRole, displayName;
                    string? empStatus;
                    bool isArchived;

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = inputUsername;

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            // Username not found - same message as a wrong password,
                            // so an attacker can't discover which usernames are valid.
                            if (!r.Read())
                            {
                                ShowInvalidCredentials();
                                return;
                            }

                            userId = r.GetInt32(0);
                            storedHash = r.GetString(1);
                            userRole = r.GetString(2);
                            displayName = r.IsDBNull(3) ? inputUsername : r.GetString(3);
                            empStatus = r.IsDBNull(4) ? null : r.GetString(4);
                            isArchived = !r.IsDBNull(5);
                        }
                    }

                    // LOGIN ATTEMPT LIMIT - the lock is checked BEFORE the password,
                    // so even the correct password is refused while the account is locked.
                    int lockedSeconds = LoginLockout.GetSecondsRemaining(conn, userId);
                    if (lockedSeconds > 0)
                    {
                        ShowLockedOut(lockedSeconds);
                        return;
                    }

                    // The password itself is never sent to SQL Server - we fetch the
                    // stored hash by username, then verify here in C#.
                    if (!SecurityHelper.Verify(inputPassword, storedHash))
                    {
                        // Count the failure; the 3rd one in a row starts a lock.
                        int lockMinutes = LoginLockout.RecordFailure(conn, userId);
                        if (lockMinutes > 0)
                        {
                            ShowLockedOut(lockMinutes * 60);
                            return;
                        }

                        ShowInvalidCredentials();
                        return;
                    }

                    // Correct password - clear the failed-attempt counters.
                    LoginLockout.Reset(conn, userId);

                    // OLD - one message for both cases:
                    // // Caretaker logins are frozen when the employee is inactive or archived
                    // if (userRole == "Caretaker" && (isArchived || empStatus != "Active"))
                    // {
                    //     MessageBox.Show("This account is no longer active. Contact the landlord.",
                    //         "Account Disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //     return;
                    // }

                    // ADDED (Employee module STEP 7): two messages
                    // Archived = no longer employed.
                    if (userRole == "Caretaker" && isArchived)
                    {
                        MessageBox.Show("This account is no longer active. Contact the landlord.",
                            "Account Disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Inactive = on leave (still employed, can come back).
                    if (userRole == "Caretaker" && empStatus != "Active")
                    {
                        MessageBox.Show("This account is currently inactive. Contact the landlord.",
                            "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Session.UserId = userId;
                    Session.Username = inputUsername;
                    Session.Role = userRole;
                    Session.Name = displayName;

                    loggedInUserId = userId;

                    // Exactly three, not "three or more". A user sitting at one or two
                    // rows is a broken state, and treating that as "not configured"
                    // means the setup form reopens and repairs it.
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM SecurityQuestions WHERE UserId = @UserId", conn))
                    {
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                        questionsConfigured = (int)cmd.ExecuteScalar() == 3;
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(
                    "A database error occurred. Please make sure SQL Server is running and try again.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Something went wrong while signing you in.",
                    "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // An account with no security questions cannot recover a forgotten
            // password, and nothing would ever prompt the user to fix that. So the
            // setup form opens here, before the dashboard, and cannot be skipped.
            if (!questionsConfigured)
            {
                using (var setup = new SecurityQuestionsForm(loggedInUserId, true))
                {
                    if (setup.ShowDialog(this) != DialogResult.OK)
                    {
                        // They backed out - the login does not complete.
                        Session.Clear();
                        txtLoginPassword.Clear();
                        txtLoginPassword.Focus();
                        return;
                    }
                }
            }
            AuditLogger.Log(AuditLogger.ModuleLogin, "Login", "Signed in (" + Session.Role + ")");
            try
            {
                int generated = BillGenerator.RunForAllBuildings();
                if (generated > 0)
                    Debug.WriteLine($"BillGenerator: {generated} bill(s) created at login.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            // NOTE (Employee module STEP 7): month-end salary recording is NOT done here.
            // It runs in MainForm_Load, right after the System Clock check passes,
            // so a wrong PC date can never record salary months early.

            ClearLoginFields();

            BuildingSelection bs = new BuildingSelection();
            bs.FormClosed += (s2, e2) =>
            {
                if (Session.LoggingOut)
                {
                    Session.LoggingOut = false;
                    ClearLoginFields();
                    this.Show();
                }
                else
                {
                    this.Close();   // user closed the picker - quit
                }
            };
            bs.Show();
            this.Hide();
        }

        private void lnkForgotPassword_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your username first.", "Username required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoginUsername.Focus();
                return;
            }

            // Modal, with the login form left visible underneath. The old Show()/Hide()
            // pair raced against ForgetForm closing itself during Load: Hide() ran after
            // the FormClosed handler had already re-shown this form, leaving no window
            // on screen at all. ShowDialog has no such ordering hazard.
            using (ForgetForm ff = new ForgetForm(username))
            {
                ff.ShowDialog(this);
            }

            txtLoginPassword.Clear();
            txtLoginPassword.Focus();
        }

        private void ShowInvalidCredentials()
        {
            MessageBox.Show("Invalid username or password.", "Login Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtLoginPassword.Clear();
            txtLoginPassword.Focus();
        }

        // Login attempt limit: shown when the account is locked, instead of
        // "Invalid username or password". No "attempts remaining" counter is shown.
        private void ShowLockedOut(int secondsRemaining)
        {
            MessageBox.Show(LoginLockout.LockedMessage(secondsRemaining), "Account Locked",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtLoginPassword.Clear();
            txtLoginPassword.Focus();
        }

        private void ClearLoginFields()
        {
            txtLoginUsername.Clear();
            txtLoginPassword.Clear();
            chkShowPassword.Checked = false;
            txtLoginPassword.PasswordChar = '*';
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }

}
