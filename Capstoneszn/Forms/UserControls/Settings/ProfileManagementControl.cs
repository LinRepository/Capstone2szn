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

            // CurrentUserId defaulted to 1 and was never set, so every account edited
            // UserId 1 (the landlord). Use the signed-in user instead.
            if (Session.UserId > 0) CurrentUserId = Session.UserId;

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

                // if (editForm.ShowDialog(this) == DialogResult.OK)
                // {
                //     LoadUsername();
                // }

                DialogResult result = editForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    LoadUsername();
                }
                else if (result == DialogResult.Abort)
                {
                    // account locked -> log out through the main form
                    if (this.FindForm() is MainForm main)   // <-- your main form's class name
                    {
                        main.ForceLogout();
                    }
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
                SqlCommand cmd = new SqlCommand("SELECT Name, Username FROM Users WHERE UserId = @id", conn);
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
                // was: changeForm.ShowDialog();
                if (changeForm.ShowDialog() == DialogResult.Abort)
                {
                    SignOutAfterLockout();
                    return;
                }
            }
        }

        private void btnManageSecurityQuestions_Click(object sender, EventArgs e)
        {
            using (SecurityQuestionsForm questionsForm = new SecurityQuestionsForm(CurrentUserId))
            {
                questionsForm.StartPosition = FormStartPosition.CenterScreen;
                questionsForm.TopMost = true;
                // was: questionsForm.ShowDialog();
                if (questionsForm.ShowDialog() == DialogResult.Abort)
                {
                    SignOutAfterLockout();
                    return;
                }
            }
        }

        // Login attempt limit: Change Password or Security Questions closed with Abort,
        // meaning the account is now locked. Same steps as MainForm's Logout button:
        // closing MainForm with LoggingOut = true brings back the login screen.
        private void SignOutAfterLockout()
        {
            AuditLogger.Log(AuditLogger.ModuleLogin, "Lockout",
                "Account locked after repeated wrong current passwords; signed out");

            Form? mainForm = this.FindForm();
            Session.Clear();
            Session.LoggingOut = true;
            mainForm?.Close();
        }

    }
}
