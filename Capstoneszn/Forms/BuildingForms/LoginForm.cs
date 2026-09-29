using System.ComponentModel;
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

        private void SelectBuildingForm_Load(object sender, EventArgs e)
        {



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
            if (chkShowPassword.Checked)
            {
                // Show the actual typed letters
                txtLoginPassword.PasswordChar = '\0';
            }
            else
            {
                // Hide the text behind asterisks
                txtLoginPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string inputUsername = txtLoginUsername.Text.Trim();
            string inputPassword = txtLoginPassword.Text; // Passwords shouldn't be trimmed just in case of intentional spaces

            // 1. Prevent empty submissions
            if (string.IsNullOrEmpty(inputUsername) || string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Connect to SQL Server and verify credentials
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Parameterized query to prevent SQL Injection
                    string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", inputUsername);
                        cmd.Parameters.AddWithValue("@Password", inputPassword);

                        // ExecuteScalar grabs the first column of the matching row (the Role)
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string userRole = result.ToString() ?? "";
                            //MessageBox.Show($"Login successful! Welcome, {userRole}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // --> WIPE THE CREDENTIALS CLEAN HERE <--
                            txtLoginUsername.Clear();
                            txtLoginPassword.Clear();
                            chkShowPassword.Checked = false; // Reset the checkbox as well

                            // To ensure the asterisks come back for the next user
                            txtLoginPassword.PasswordChar = '*';

                            // 3. Open the Building Selection Form and hide Login
                            BuildingSelection bs = new BuildingSelection();
                            bs.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
            ff.Show();

            //HIDE
            this.Hide();
        }
    }

}
