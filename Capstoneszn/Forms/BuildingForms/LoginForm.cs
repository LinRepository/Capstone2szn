using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Capstoneszn.Forms.BuildingForms;
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

            if (string.IsNullOrEmpty(inputUsername) || string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                    // The password itself is never sent to SQL Server - we fetch the
                    // stored hash by username, then verify here in C#.
                    if (!SecurityHelper.Verify(inputPassword, storedHash))
                    {
                        ShowInvalidCredentials();
                        return;
                    }

                    // Caretaker logins are frozen when the employee is inactive or archived
                    if (userRole == "Caretaker" && (isArchived || empStatus != "Active"))
                    {
                        MessageBox.Show("This account is no longer active. Contact the landlord.",
                            "Account Disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Session.UserId = userId;
                    Session.Username = inputUsername;
                    Session.Role = userRole;
                    Session.Name = displayName;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connect to the database.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            ForgetForm ff = new ForgetForm(username);
            ff.FormClosed += (s2, e2) => { txtLoginPassword.Clear(); this.Show(); };
            ff.Show();
            this.Hide();
        }

        private void ShowInvalidCredentials()
        {
            MessageBox.Show("Invalid username or password.", "Login Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
