using Capstoneszn.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn
{
    public partial class PasswordResetForm : Form
    {
        private string _username;
        public PasswordResetForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void btnReturnLogin_Click(object sender, EventArgs e)
        {
            // Find the original hidden Login Form
            var login = Application.OpenForms.OfType<Login>().FirstOrDefault();

            if (login != null)
            {
                login.Show();
            }
            else
            {
                // Fallback just in case it doesn't exist
                new Login().Show();
            }

            // Close the current Forget Form
            this.Close();
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            string newPass = txtResetPassword.Text.Trim();
            string confirmPass = txtConfirmResetPassword.Text.Trim();

            // 1. Empty checks
            if (newPass == "")
            {
                MessageBox.Show("Please enter a new password.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResetPassword.Focus();
                return;
            }
            if (confirmPass == "")
            {
                MessageBox.Show("Please confirm your new password.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmResetPassword.Focus();
                return;
            }

            // 2. Both must match
            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmResetPassword.Clear();
                txtConfirmResetPassword.Focus();
                return;
            }

            // 3. Save to database
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET Password = @Password WHERE Username = @Username", conn))
                {
                    cmd.Parameters.AddWithValue("@Password", newPass);
                    cmd.Parameters.AddWithValue("@Username", _username);
                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        new PasswordSuccessForm().Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("User not found. Password was not changed.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasswordResetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
