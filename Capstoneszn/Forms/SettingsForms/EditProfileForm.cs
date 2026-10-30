using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.SettingsForms
{
    public partial class EditProfileForm : Form
    {
        private readonly int userId;
        private readonly string originalUsername;

        // Read by SettingsControl after DialogResult.OK
        public string UpdatedName { get; private set; } = string.Empty;
        public string UpdatedUsername { get; private set; } = string.Empty;

        private UserProfile _profile;

        // Letters (incl. ñ/accents), space, . ' -   (same rule as tenant names)
        private static readonly Regex NameRule = new Regex(@"^\p{L}[\p{L} .'\-]*$");
        // 4-30 letters/digits, no spaces
        private static readonly Regex UsernameRule = new Regex(@"^[A-Za-z0-9]{4,30}$");

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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSaveProfileChanges_Click(object sender, EventArgs e)
        {
            if (_profile == null) return;   // profile failed to load

            // 1. Clean input (collapse double spaces in the name)
            string newName = Regex.Replace(txtName.Text.Trim(), @"\s+", " ");
            string newUsername = txtUsername.Text.Trim();

            bool nameChanged = newName != _profile.Name;
            bool usernameChanged = newUsername != _profile.Username;

            // 2. Nothing changed -> just close, no password, no DB write
            if (!nameChanged && !usernameChanged)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            // 3. Validate
            if (newName.Length == 0 || !NameRule.IsMatch(newName))
            {
                ShowWarning("Name may contain letters, spaces, and . ' - only.", txtName);
                return;
            }
            if (!UsernameRule.IsMatch(newUsername))
            {
                ShowWarning("Username must be 4–30 letters or numbers, with no spaces.", txtUsername);
                return;
            }
            if (txtEnterPassword.Text.Length == 0)   // blank does NOT count as an attempt
            {
                ShowWarning("Enter your password to save the changes.", txtEnterPassword);
                return;
            }

            try
            {
                // 4. Username taken by someone else? (checked before the password so no attempt is used)
                if (usernameChanged && ProfileRepository.IsUsernameTaken(newUsername, userId))
                {
                    ShowWarning("That username is already taken.", txtUsername);
                    return;
                }

                // 5. Verify password (counts toward the login lockout)
                switch (ProfileRepository.VerifyPassword(userId, txtEnterPassword.Text))
                {
                    case PasswordCheckResult.WrongPassword:
                        txtEnterPassword.Clear();
                        ShowWarning("Incorrect password.", txtEnterPassword);
                        return;

                    case PasswordCheckResult.LockedNow:
                    case PasswordCheckResult.AlreadyLocked:
                        MessageBox.Show("Too many incorrect attempts. Your account is temporarily locked " +
                                        "and you will be logged out.", "Account Locked",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.Abort;   // SettingsControl logs the user out
                        this.Close();
                        return;
                }

                // 6. Save (also updates Employees.FullName for a caretaker)
                if (!ProfileRepository.UpdateProfile(_profile, newName, newUsername))
                {
                    ShowWarning("That username is already taken.", txtUsername);
                    return;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Unable to save your profile. Please try again.", "Edit Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 7. Hand the new values back to SettingsControl
            UpdatedName = newName;
            UpdatedUsername = newUsername;

            MessageBox.Show("Profile updated.", "Edit Profile",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EditProfileForm_Load(object sender, EventArgs e)
        {
            txtEnterPassword.UseSystemPasswordChar = true;
            txtUsername.MaxLength = 30;
            txtEnterPassword.Clear();

            try
            {
                // Re-read from the database so the form shows the saved values
                _profile = ProfileRepository.GetProfile(userId);
            }
            catch (SqlException)
            {
                MessageBox.Show("Unable to load your profile. Please try again.", "Edit Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                BeginInvoke(new Action(Close));
                return;
            }

            if (_profile == null)
            {
                MessageBox.Show("Your account could not be found.", "Edit Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                BeginInvoke(new Action(Close));
                return;
            }

            txtName.Text = _profile.Name;
            txtUsername.Text = _profile.Username;
            lblEditProfileRoleValue.Text = _profile.Role;
        }

        private void ShowWarning(string message, Control focusTarget)
        {
            MessageBox.Show(message, "Edit Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focusTarget.Focus();
        }


    }
}
