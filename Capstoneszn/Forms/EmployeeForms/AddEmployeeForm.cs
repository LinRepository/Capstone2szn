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
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.EmployeeForms
{
    /// <summary>
    /// STEP 3 — Add Employee. Collects and validates the input; saving is done
    /// by EmployeeHelper.AddEmployee (employee + login, saved as Active).
    /// </summary>
    /// 

    public partial class AddEmployeeForm : Form
    {
        private readonly int _buildingId;

        // ADDED: letters (incl. Ñ/ñ and accents), spaces, period, apostrophe, hyphen
        // e.g. "Ma. Teresa Dela Cruz-Reyes Jr."
        private static readonly Regex NamePattern = new Regex(@"^[\p{L}][\p{L} .'\-]*$");
        // ADDED: letters, digits, _ . @ only
        private static readonly Regex UsernamePattern = new Regex(@"^[A-Za-z0-9_.@]+$");

        // ADDED
        private const int MinPasswordLength = 8;

        public AddEmployeeForm(int buildingId)
        {
            InitializeComponent();
            _buildingId = buildingId;

            // ADDED: a Multiline TextBox ignores the password mask, so the password
            // was visible while typing. Single-line makes the dots work.
            txtAddPassword.Multiline = false;

            txtAddPassword.UseSystemPasswordChar = true;
            txtAddUsername.PlaceholderText = "@Employee1";
            dtpDate.MaxDate = DateTime.Today;
            dtpDate.Value = DateTime.Today;

            // ADDED: limits match the database (FullName 150, Address 255,
            // Username 50) and the login form's password limit (72).
            txtAddFullName.MaxLength = 150;
            txtAddAddress.MaxLength = 255;
            txtAddUsername.MaxLength = 50;
            txtAddPassword.MaxLength = 72;

            // ADDED: Enter = Add, Esc = Cancel
            AcceptButton = btnAdd;
            CancelButton = btnCancel;
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fullName = txtAddFullName.Text.Trim();
            string address = txtAddAddress.Text.Trim();
            string username = txtAddUsername.Text.Trim();
            string password = txtAddPassword.Text;
            // OLD: DateTime dateHired = dtpDate.Value.Date;
            DateTime dateHired = DateTime.Today;   // ADDED: always today (the picker is disabled)

            if (!ValidateInput(fullName, address, username, password)) return;

            btnAdd.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                // OLD: saved Role 'Employee' (rejected by CK_Users_Role) and a
                // plain-text password. Kept below, commented out.
                // InsertEmployee(fullName, address, dateHired, username, password);

                // ADDED: Caretaker role, BCrypt hash, Active, 3-per-building + salary checks
                EmployeeHelper.AddEmployee(_buildingId, fullName, address, dateHired, username, password);

                // OLD message:
                // MessageBox.Show($"Employee \"{fullName}\" added successfully.",
                //     "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ADDED message:
                MessageBox.Show(
                    $"Employee \"{fullName}\" added successfully.\n\n" +
                    $"They can now log in as \"{username}\". Salary counts from today.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DuplicateNameException)
            {
                MessageBox.Show("That username is already taken. Please choose another.",
                    "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddUsername.Focus();
                txtAddUsername.SelectAll();
            }
            catch (InvalidOperationException ex)   // ADDED: 3-employee limit / no salary set
            {
                MessageBox.Show(ex.Message, "Cannot Add Employee",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add the employee.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnAdd.Enabled = true;
            }
        }

        private bool ValidateInput(string fullName, string address, string username, string password)
        {
            if (fullName.Length == 0)
            {
                MessageBox.Show("Full name is required.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddFullName.Focus();
                return false;
            }
            // ADDED: letters-only names (panel revision); also rules out line breaks
            if (!NamePattern.IsMatch(fullName))
            {
                MessageBox.Show("Full name may only contain letters, spaces, periods, apostrophes and hyphens.",
                    "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddFullName.Focus();
                return false;
            }
            if (address.Length == 0)
            {
                MessageBox.Show("Address is required.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddAddress.Focus();
                return false;
            }
            // ADDED: one line only (the textbox is Multiline, so a paste can add line breaks)
            if (address.Contains('\r') || address.Contains('\n'))
            {
                MessageBox.Show("Address must be on one line.", "Invalid Address",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddAddress.Focus();
                return false;
            }
            if (username.Length < 4 || username.Contains(" "))
            {
                MessageBox.Show("Username must be at least 4 characters and contain no spaces.",
                    "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddUsername.Focus();
                return false;
            }
            // ADDED: allowed characters only (also rules out line breaks)
            if (!UsernamePattern.IsMatch(username))
            {
                MessageBox.Show("Username may only contain letters, numbers, _ . and @.",
                    "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddUsername.Focus();
                return false;
            }
            // OLD: if (password.Length < 6)
            if (password.Length < MinPasswordLength)   // ADDED: minimum 8
            {
                MessageBox.Show($"Password must be at least {MinPasswordLength} characters.", "Weak Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddPassword.Focus();
                return false;
            }
            // ADDED: login never trims passwords, so spaces at the ends would lock them out
            if (password.Contains('\r') || password.Contains('\n') || password.Trim() != password)
            {
                MessageBox.Show("Password cannot start or end with a space.",
                    "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddPassword.Focus();
                return false;
            }
            return true;
        }


    }
}
