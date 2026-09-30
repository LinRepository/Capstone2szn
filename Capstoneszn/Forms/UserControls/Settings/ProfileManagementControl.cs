using Capstoneszn.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.SettingsForms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.UserControls.Settings
{
    public partial class ProfileManagementControl : UserControl
    {
        public int CurrentUserId { get; set; } = 1;
        public ProfileManagementControl()
        {
            InitializeComponent();
            LoadUsername();
        }

        private void btnBackProfileManagement_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            using (EditProfileForm editForm = new EditProfileForm(
            CurrentUserId,
            lblProfileNameValue.Text,
            lblProfileRoleValue.Text,
            lblProfileUsernameValue.Text))
            {
                editForm.StartPosition = FormStartPosition.CenterScreen;
                editForm.TopMost = true;
                editForm.WindowState = FormWindowState.Normal;
                editForm.StartPosition = FormStartPosition.CenterParent;

                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadUsername();
                }
            }
        }

        private void ProfileManagementControl_Load(object sender, EventArgs e)
        {

        }
        private void LoadUsername()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name, Username FROM Users WHERE User_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", CurrentUserId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblProfileNameValue.Text = reader["Name"].ToString();
                    lblProfileUsernameValue.Text = reader["Username"].ToString();
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (ChangePasswordForm changeForm = new ChangePasswordForm(CurrentUserId))
            {
                changeForm.StartPosition = FormStartPosition.CenterScreen;
                changeForm.TopMost = true;
                changeForm.ShowDialog();
            }
        }
    }
}
