using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.SettingsForms
{
    public partial class ChangePasswordForm : Form
    {
        private readonly int _userId;
        private const int MinPasswordLength = 8;

        public ChangePasswordForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void btnSaveNewPassword_Click(object sender, EventArgs e)
        {
            // Passwords are never trimmed - taken exactly as typed, the same way
            // the login form reads them.
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmNewPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirmation do not match.", "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmNewPassword.Clear();
                txtConfirmNewPassword.Focus();
                return;
            }

            if (newPassword.Length < MinPasswordLength)
            {
                MessageBox.Show($"New password must be at least {MinPasswordLength} characters.",
                    "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.SelectAll();
                txtNewPassword.Focus();
                return;
            }

            if (newPassword == currentPassword)
            {
                MessageBox.Show("New password must be different from the current one.",
                    "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Fetch the stored hash. The typed password is never sent to SQL Server.
                    string storedHash;

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT Password FROM Users WHERE UserId = @UserId", conn))
                    {
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = _userId;
                        object? result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("User not found.", "Change Password",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        storedHash = (string)result;
                    }

                    // 2. Verify the current password in C#
                    if (!SecurityHelper.Verify(currentPassword, storedHash))
                    {
                        MessageBox.Show("Current password is incorrect.", "Change Password",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCurrentPassword.Clear();
                        txtCurrentPassword.Focus();
                        return;
                    }

                    // 3. Hash the new password before it reaches the database
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Users SET Password = @Password WHERE UserId = @UserId", conn))
                    {
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 255).Value =
                            SecurityHelper.Hash(newPassword);
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = _userId;

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show("User not found. Password was not changed.", "Change Password",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmNewPassword.Clear();

                MessageBox.Show("Password changed successfully.", "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(
                    "A database error occurred. Your password was not changed. " +
                    "Please make sure SQL Server is running and try again.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Something went wrong. Your password was not changed.",
                    "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            txtCurrentPassword.Select();
        }
    }
}
