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

namespace Capstoneszn.Forms.EmployeeForms
{
    /// <summary>
    /// STEP 5 — Edit an employee's Full Name and Address only.
    /// Not editable here: Date Hired (salary depends on it), Status (the
    /// checkbox), Username / password (forgotten password = Forgot Password
    /// with the caretaker's own security questions).
    /// </summary>
    /// 

    public partial class EditEmployeeForm : Form
    {
        // ADDED
        private static readonly Regex NamePattern = new Regex(@"^[\p{L}][\p{L} .'\-]*$");
        private readonly int _employeeId;
        private string _originalName = "";
        private string _originalAddress = "";


        public EditEmployeeForm()
        {
            InitializeComponent();
        }

        // ADDED: the constructor EmployeeControl uses
        public EditEmployeeForm(int employeeId) : this()
        {
            _employeeId = employeeId;

            StartPosition = FormStartPosition.CenterParent;
            txtEditFullName.MaxLength = 150;
            txtEditAddress.MaxLength = 255;
            AcceptButton = btnSave;     // Enter = Save
            CancelButton = btnCancel;   // Esc = Cancel

            // btnSave has no Click in the Designer, so it is wired here.
            // Do NOT also double-click it in the Designer.
            btnSave.Click += btnSave_Click;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            // ADDED: fill the form with the current values
            if (_employeeId <= 0) return;

            try
            {
                EmployeeInfo? emp = EmployeeHelper.GetEmployee(_employeeId);
                if (emp == null)
                {
                    MessageBox.Show("This employee was archived. Refresh the list.", "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }

                _originalName = emp.FullName;
                _originalAddress = emp.Address;
                txtEditFullName.Text = emp.FullName;
                txtEditAddress.Text = emp.Address;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the employee.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        // ADDED: validate -> save -> close
        private void btnSave_Click(object? sender, EventArgs e)
        {
            string fullName = txtEditFullName.Text.Trim();
            string address = txtEditAddress.Text.Trim();

            // Same rules as Add Employee
            if (fullName.Length == 0)
            {
                Warn("Full name is required.", txtEditFullName);
                return;
            }
            if (!NamePattern.IsMatch(fullName))
            {
                Warn("Full name may only contain letters, spaces, periods, apostrophes and hyphens.", txtEditFullName);
                return;
            }
            if (address.Length == 0)
            {
                Warn("Address is required.", txtEditAddress);
                return;
            }
            if (address.Contains('\r') || address.Contains('\n'))
            {
                Warn("Address must be on one line.", txtEditAddress);
                return;
            }
            if (fullName == _originalName && address == _originalAddress)
            {
                MessageBox.Show("No changes to save.", "No Changes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnSave.Enabled = false;
            try
            {
                EmployeeHelper.UpdateEmployee(_employeeId, fullName, address);

                MessageBox.Show("Employee details updated.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;   // EmployeeControl reloads the list
                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Cannot Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the changes.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private static void Warn(string message, Control focus)
        {
            MessageBox.Show(message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus.Focus();
        }


    }
}
