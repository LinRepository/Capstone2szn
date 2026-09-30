using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public ChangePasswordForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void btnSaveNewPassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmNewPassword.Text;

            // 1. Basic validation
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
                return;
            }

            if (newPassword.Length < 2)
            {
                MessageBox.Show("New password must be at least 2 characters.", "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword == currentPassword)
            {
                MessageBox.Show("New password must be different from the current one.", "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 2. Verify the current password
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE user_id = @UserID AND Password = @CurrentPassword";
                    string updateQuery = "UPDATE Users SET Password = @NewPassword WHERE user_id = @UserID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = _userId;
                        checkCmd.Parameters.Add("@CurrentPassword", SqlDbType.NVarChar).Value = currentPassword;

                        int match = (int)checkCmd.ExecuteScalar();
                        if (match == 0)
                        {
                            MessageBox.Show("Current password is incorrect.", "Change Password",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 3. Update to the new password
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.Add("@NewPassword", SqlDbType.NVarChar).Value = newPassword;
                        updateCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = _userId;
                        updateCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Password changed successfully.", "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing password: " + ex.Message, "Change Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
