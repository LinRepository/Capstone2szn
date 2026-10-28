using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Employee
{
    /// <summary>
    /// STEP 2 — Salary button. The ONLY place the salary is shown.
    /// Uses the controls already in the Designer:
    ///   lblSalaryPerPeriod  current salary (+ the waiting change, if any)
    ///   txtNewSalary        new monthly salary
    ///   btnSave / btnCancel
    /// Click events are wired in the constructor - do NOT also double-click
    /// the buttons in the Designer, or each click runs twice.
    ///
    /// Rules: first salary applies this month; a change applies next month;
    /// typing the current salary cancels a waiting change.
    /// 

    public partial class EmployeeSalaryForm : Form
    {
        // ADDED
        private static readonly CultureInfo PH = new CultureInfo("en-PH");
        private const decimal MaxSalary = 1_000_000m;

        public EmployeeSalaryForm()
        {
            InitializeComponent();

            // ADDED
            StartPosition = FormStartPosition.CenterParent;
            // OLD: txtNewSalary.MaxLength = 13;                       // "1,000,000.00" + spare
            txtNewSalary.MaxLength = 7;                                // ADDED: whole pesos only, max 1000000
            txtNewSalary.KeyPress += txtNewSalary_KeyPress;            // ADDED: digits only
            txtNewSalary.TextAlign = HorizontalAlignment.Right;        // keeps digits clear of the ₱ label
            lblCurrentSalary.Text = "Monthly Salary:";
            lblEntertheSalaryofEmployees.Text = "Enter the monthly salary";
            AcceptButton = btnSave;
            CancelButton = btnCancel;

            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => Close();

        }

        // ADDED
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode) LoadSalary();
        }

        // ADDED: current salary, plus the change waiting for next month (if any)
        private void LoadSalary()
        {
            try
            {
                decimal? current = SalaryHelper.GetSalaryForMonth(Session.BuildingId, DateTime.Today);
                var pending = SalaryHelper.GetPendingSalary(Session.BuildingId);

                string text = current.HasValue ? current.Value.ToString("C2", PH) : "Not set yet";
                if (pending.HasValue)
                    text += Environment.NewLine + $"(From {pending.Value.EffectiveMonth:MMMM yyyy}: " +
                            pending.Value.Salary.ToString("C2", PH) + ")";

                lblSalaryPerPeriod.Text = text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the salary.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ADDED: only digits can be typed (Backspace / Ctrl+C / Ctrl+V still work)
        private void txtNewSalary_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsAsciiDigit(e.KeyChar))
                e.Handled = true;
        }

        // ADDED: validate -> confirm -> save
        private void btnSave_Click(object? sender, EventArgs e)
        {
            string input = txtNewSalary.Text.Trim();

            if (input.Length == 0 || !input.All(char.IsAsciiDigit)
                || !int.TryParse(input, NumberStyles.None, CultureInfo.InvariantCulture, out int whole)
                || whole <= 0)
            {
                MessageBox.Show("Enter a whole number greater than zero (e.g. 10000).",
                    "Invalid Salary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewSalary.Focus();
                txtNewSalary.SelectAll();
                return;
            }
            if (whole > MaxSalary)
            {
                MessageBox.Show($"Salary must be at most {MaxSalary.ToString("C0", PH)}.",
                    "Invalid Salary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewSalary.Focus();
                txtNewSalary.SelectAll();
                return;
            }
            decimal salary = whole;

            // 2. Work out what Save will do, so the confirmation says it plainly
            decimal? current;
            (decimal Salary, DateTime EffectiveMonth)? pending;
            try
            {
                current = SalaryHelper.GetSalaryForMonth(Session.BuildingId, DateTime.Today);
                pending = SalaryHelper.GetPendingSalary(Session.BuildingId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not read the current salary.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime thisMonth = SalaryHelper.FirstOfMonth(DateTime.Today);
            string question;

            if (current == null)
            {
                question = $"Set the monthly salary to {salary.ToString("C2", PH)} for ALL employees of this building?\n\n" +
                           $"It applies from {thisMonth:MMMM yyyy}.";
            }
            else if (current.Value == salary)
            {
                if (pending == null)
                {
                    MessageBox.Show("This is already the current salary. Nothing to save.",
                        "No Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                question = $"Cancel the change to {pending.Value.Salary.ToString("C2", PH)} " +
                           $"from {pending.Value.EffectiveMonth:MMMM yyyy}?\n\n" +
                           $"The salary stays {salary.ToString("C2", PH)}.";
            }
            else
            {
                question = $"Change the monthly salary to {salary.ToString("C2", PH)} for ALL employees?\n\n" +
                           $"It applies from {thisMonth.AddMonths(1):MMMM yyyy}.\n" +
                           $"{thisMonth:MMMM yyyy} keeps the current salary ({current.Value.ToString("C2", PH)}).";
            }

            if (MessageBox.Show(question, "Confirm Salary",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // 3. Save
            try
            {
                SalarySaveResult result = SalaryHelper.SetSalary(Session.BuildingId, salary,
                                                                 Session.UserId, out DateTime from);
                txtNewSalary.Clear();
                LoadSalary();

                string done = result switch
                {
                    SalarySaveResult.SetThisMonth => $"Salary saved. It applies from {from:MMMM yyyy}.",
                    SalarySaveResult.Scheduled => $"Salary change saved. It applies from {from:MMMM yyyy}.",
                    SalarySaveResult.CancelledPending => "The waiting salary change was cancelled.",
                    _ => "Nothing was changed."
                };
                MessageBox.Show(done, "Salary", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the salary.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
