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
    public partial class EditProfileForm : Form
    {
        private readonly int userId;
        private readonly string originalUsername;

        public string UpdatedName { get; private set; } = string.Empty;
        public string UpdatedUsername { get; private set; } = string.Empty;
        public EditProfileForm(int userId, string currentName, string currentRole, string currentUsername)
        {
            InitializeComponent();

            this.userId = userId;
            this.originalUsername = currentUsername;

            txtName.Text = currentName;
            lblEditProfileRoleValue.Text = currentRole;
            txtUsername.Text = currentUsername;
        }

        private void btnCancelEditProfile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveProfileChanges_Click(object sender, EventArgs e)
        {
            string newName = txtName.Text.Trim();
            string newUsername = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Name and Username cannot be empty.", "Edit Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Only check for duplicates if the username changed
                    if (!newUsername.Equals(originalUsername, StringComparison.OrdinalIgnoreCase))
                    {
                        using (SqlCommand check = new SqlCommand(
                            "SELECT COUNT(*) FROM Users WHERE Username = @Username AND UserId <> @UserId", conn))
                        {
                            check.Parameters.AddWithValue("@Username", newUsername);
                            check.Parameters.AddWithValue("@UserId", userId);

                            if ((int)check.ExecuteScalar() > 0)
                            {
                                MessageBox.Show("That username is already taken.", "Edit Profile",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // Update Name and Username in Users table
                    using (SqlCommand update = new SqlCommand(
                        "UPDATE Users SET Name = @Name, Username = @Username WHERE UserId = @UserId", conn))
                    {
                        update.Parameters.AddWithValue("@Name", newName);
                        update.Parameters.AddWithValue("@Username", newUsername);
                        update.Parameters.AddWithValue("@UserId", userId);
                        update.ExecuteNonQuery();
                    }
                }

                UpdatedName = newName;
                UpdatedUsername = newUsername;

                // Keep the live session in step with the database
                if (Session.UserId == userId)
                {
                    Session.Name = newName;
                    Session.Username = newUsername;
                }

                MessageBox.Show("Profile updated successfully.", "Edit Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save the profile changes.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
