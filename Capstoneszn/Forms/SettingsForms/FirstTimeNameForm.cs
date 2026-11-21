using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.SettingsForms
{
    // NEW (Nov 21, 2026 - first-run setup): opened by MainForm_Shown when the
    // landlord's Users.Name is blank (fresh system). Entering the name is mandatory:
    // the form cannot be skipped, and closing it without saving returns to Login.
    // Caretakers never see it - their name is set when the landlord adds the employee.
    public partial class FirstTimeNameForm : Form
    {
        private readonly int _userId;
        private bool _savedSuccessfully;

        // Same name rule as EditProfileForm (letters incl. ñ/accents, space, . ' -)
        private static readonly Regex NameRule = new Regex(@"^\p{L}[\p{L} .'\-]*$");
        private const int MaxNameLength = 150;   // Users.Name is nvarchar(150)

        // Read by MainForm after DialogResult.OK
        public string SavedName { get; private set; } = string.Empty;

        public FirstTimeNameForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            txtName.MaxLength = MaxNameLength;
        }

        private void FirstTimeNameForm_Load(object sender, EventArgs e)
        {
            txtName.Select();
        }

        private void btnSaveName_Click(object sender, EventArgs e)
        {
            // Collapse double spaces, same cleanup as Edit Profile
            string name = Regex.Replace(txtName.Text.Trim(), @"\s+", " ");

            if (name.Length == 0)
            {
                ShowWarning("Please enter your name.");
                return;
            }
            if (!NameRule.IsMatch(name))
            {
                ShowWarning("Name may contain letters, spaces, and . ' - only.");
                return;
            }

            try
            {
                FirstRunSetup.SaveName(_userId, name);
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to save your name. Please make sure SQL Server is running and try again.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Something went wrong while saving your name.",
                    "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SavedName = name;
            _savedSuccessfully = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Mandatory: closing with X / Alt+F4 asks first. Yes = back to Login
        // (MainForm sees DialogResult.Cancel and signs out). No = stay on the form.
        private void FirstTimeNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_savedSuccessfully) return;

            // Windows shutting down / app being closed by the system - don't block it.
            if (e.CloseReason == CloseReason.WindowsShutDown ||
                e.CloseReason == CloseReason.TaskManagerClosing)
                return;

            DialogResult answer = MessageBox.Show(
                "Entering your name is required before you can use the system.\n\n" +
                "Return to the login screen?",
                "Name required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
            {
                e.Cancel = true;
                this.DialogResult = DialogResult.None;
                txtName.Focus();
                return;
            }

            this.DialogResult = DialogResult.Cancel;
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Enter Your Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
        }
    }
}
