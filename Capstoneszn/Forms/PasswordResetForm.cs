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
        private const int MinPasswordLength = 8;

        private readonly string _username;
        public PasswordResetForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void btnReturnLogin_Click(object sender, EventArgs e)
        {
            // Close the current Forget Form
            this.Close();
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            // Not trimmed - a password is taken exactly as typed, the same way
            // the login form reads it. Trimming here would let someone set a
            // password they then cannot type.
            string newPass = txtResetPassword.Text;
            string confirmPass = txtConfirmResetPassword.Text;

            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Please enter a new password.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResetPassword.Focus();
                return;
            }

            if (newPass.Length < MinPasswordLength)
            {
                MessageBox.Show($"Password must be at least {MinPasswordLength} characters.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResetPassword.SelectAll();
                txtResetPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Please confirm your new password.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmResetPassword.Focus();
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmResetPassword.Clear();
                txtConfirmResetPassword.Focus();
                return;
            }

            try
            {
                // Hash BEFORE it reaches the database. Storing the raw password
                // here would break login, since Verify cannot read a non-hash.
                string hashed = SecurityHelper.Hash(newPass);

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET Password = @Password WHERE Username = @Username", conn))
                {
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 255).Value = hashed;
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = _username;
                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        MessageBox.Show("User not found. Password was not changed.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                txtResetPassword.Clear();
                txtConfirmResetPassword.Clear();

                using (var success = new PasswordSuccessForm())
                    success.ShowDialog(this);

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save the new password.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasswordResetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
