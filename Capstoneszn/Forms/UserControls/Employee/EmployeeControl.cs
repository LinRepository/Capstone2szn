using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.EmployeeForms;
using Capstoneszn.Forms.UserControls.Employee;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// Employee module (landlord only - MainForm hides the button for caretakers).
    ///   Salary button   -> EmployeeSalaryForm (STEP 2)
    ///   Add Employee    -> AddEmployeeForm (STEP 3)
    ///   Status checkbox -> Active / Inactive = on leave (STEP 4)
    ///   Edit button     -> EditEmployeeForm (STEP 5)
    ///   Archive button  -> archive + final salary (STEP 6)
    /// </summary>
    /// 

    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl()
        {
            InitializeComponent();

            // ADDED: Username right after Name; header "DateHired" -> "Date Hired"
            dgvEmployee.Columns.Insert(colNameEmployee.Index + 1, colUsernameEmployee);
            colDateHiredEmployee.HeaderText = "Date Hired";

            // ADDED: btnSalary has no Click event in the Designer, so it is wired here.
            // Do NOT also double-click it in the Designer (the form would open twice).
            btnSalary.Click += btnSalary_Click;
        }

        // ADDED: Username column, created here so no Designer change is needed
        private readonly DataGridViewTextBoxColumn colUsernameEmployee = new DataGridViewTextBoxColumn
        {
            Name = "colUsernameEmployee",
            HeaderText = "Username",
            ReadOnly = true,
            MinimumWidth = 6
        };

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
                LoadEmployees();
        }

        // ADDED: second guard behind MainForm hiding the module from caretakers
        private static bool IsLandlord() => Session.IsLandlord;

        private static void NotAllowed() =>
            MessageBox.Show("Only the landlord can manage employees.", "Not Allowed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        /* =================================================================
           STEP 2 — Salary
           ================================================================= */

        private void btnSalary_Click(object? sender, EventArgs e)
        {
            if (!IsLandlord()) { NotAllowed(); return; }

            using (var form = new EmployeeSalaryForm())
                form.ShowDialog(this);
        }

        /* =================================================================
           STEP 3 — Add Employee
           ================================================================= */

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (!IsLandlord()) { NotAllowed(); return; }

            // ADDED: checks before the form opens (repeated inside the save)
            try
            {
                if (!SalaryHelper.HasSalaryThisMonth(Session.BuildingId))
                {
                    MessageBox.Show("Set the salary first (Salary button).", "Salary Not Set",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (EmployeeHelper.CountEmployees(Session.BuildingId) >= EmployeeHelper.MaxEmployeesPerBuilding)
                {
                    MessageBox.Show(
                        $"This building already has {EmployeeHelper.MaxEmployeesPerBuilding} employees.\n" +
                        "Archive one before adding another.",
                        "Employee Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not check the employee rules.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // OLD: building 1 was hardcoded
            // using (var form = new AddEmployeeForm(1))
            using (var form = new AddEmployeeForm(Session.BuildingId))   // ADDED: current building
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadEmployees();
            }
        }

        private void EmployeeControl_Load(object sender, EventArgs e)
        {

        }

        /* =================================================================
           Grid clicks: Status (STEP 4), Edit (STEP 5), Archive (STEP 6)
           ================================================================= */

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // ADDED
            if (e.RowIndex < 0) return;   // header row
            if (!IsLandlord()) { NotAllowed(); return; }

            DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];
            int employeeId = Convert.ToInt32(row.Cells[colEmployeeID.Index].Value);
            string name = Convert.ToString(row.Cells[colNameEmployee.Index].Value) ?? "";

            if (e.ColumnIndex == colStatusEmployee.Index)
            {
                bool isActive = Convert.ToBoolean(row.Cells[colStatusEmployee.Index].Value);
                ToggleStatus(employeeId, name, isActive);
            }
            else if (e.ColumnIndex == colActionEditEmployee.Index)
            {
                EditEmployee(employeeId);
            }
            else if (e.ColumnIndex == colActionArchiveEmployee.Index)
            {
                ArchiveEmployee(employeeId, name);
            }

        }

        // STEP 4 — the grid is ReadOnly, so the checkbox never flips by itself:
        // confirm -> save -> reload, so the grid always shows what the database says.
        private void ToggleStatus(int employeeId, string name, bool isActive)
        {
            string question = isActive
                ? $"Set {name} to INACTIVE (on leave)?\n\n" +
                  "• They will not be able to log in.\n• Their salary continues."
                : $"Set {name} to ACTIVE?\n\n" +
                  "• They will be able to log in again.";

            if (MessageBox.Show(question, "Confirm Status Change",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                EmployeeHelper.SetStatus(employeeId, !isActive);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Cannot Change Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not change the status.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadEmployees();
        }

        // STEP 5
        private void EditEmployee(int employeeId)
        {
            using (var form = new EditEmployeeForm(employeeId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadEmployees();
            }
        }

        // STEP 6
        private void ArchiveEmployee(int employeeId, string name)
        {
            try
            {
                // 6a. Warn (do not block) about pending maintenance issues
                int pending = EmployeeHelper.CountPendingIssues(employeeId);
                if (pending > 0 &&
                    MessageBox.Show(
                        $"{name} is responsible for {pending} pending maintenance issue(s).\n\nArchive anyway?",
                        "Pending Maintenance", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes)
                    return;

                // 6b. Confirm
                if (MessageBox.Show(
                        $"Archive {name}?\n\n" +
                        "• They can no longer log in.\n" +
                        "• Their salary stops today (today is not paid).\n" +
                        "• You can restore them in Settings › Archive.",
                        "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != DialogResult.Yes)
                    return;

                // 6c. Archive + final salary
                decimal finalPay = EmployeeHelper.Archive(employeeId, Session.UserId);

                MessageBox.Show(
                    $"{name} has been archived." +
                    (finalPay > 0 ? $"\n\nFinal salary recorded as an expense: ₱{finalPay:N2}" : ""),
                    "Employee Archived", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Cannot Archive",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not archive the employee.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadEmployees();
        }

        /* =================================================================
           List + counters (current building only)
           ================================================================= */

        private void LoadEmployees()
        {
            try
            {
                // OLD:
                // DataTable dt = new DataTable();
                // using (SqlConnection conn = DatabaseHelper.GetConnection())
                // using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                // {
                //     da.Fill(dt);
                // }
                DataTable dt = EmployeeHelper.GetEmployees(Session.BuildingId);   // ADDED

                dgvEmployee.AutoGenerateColumns = false;
                dgvEmployee.DataSource = null;
                dgvEmployee.Rows.Clear();

                int active = 0;

                foreach (DataRow r in dt.Rows)
                {
                    bool isActive = r["EmploymentStatus"].ToString() == "Active";
                    if (isActive) active++;

                    // OLD (positional - breaks when a column is inserted):
                    // dgvEmployee.Rows.Add(r["EmployeeID"], r["FullName"], r["Address"],
                    //     Convert.ToDateTime(r["DateHired"]).ToString("MMM dd, yyyy"),
                    //     isActive, "Edit", "Archive");

                    // ADDED: fill each cell by its column
                    int i = dgvEmployee.Rows.Add();
                    DataGridViewRow row = dgvEmployee.Rows[i];
                    row.Cells[colEmployeeID.Index].Value = r["EmployeeId"];
                    row.Cells[colNameEmployee.Index].Value = r["FullName"];
                    row.Cells[colUsernameEmployee.Index].Value = r["Username"] == DBNull.Value ? "-" : r["Username"];
                    row.Cells[colAddressEmployee.Index].Value = r["Address"];
                    row.Cells[colDateHiredEmployee.Index].Value = Convert.ToDateTime(r["DateHired"]).ToString("MMM dd, yyyy");
                    row.Cells[colStatusEmployee.Index].Value = isActive;
                    row.Cells[colActionEditEmployee.Index].Value = "Edit";
                    row.Cells[colActionArchiveEmployee.Index].Value = "Archive";
                }

                lblRegisteredEmployeeValue.Text = dt.Rows.Count.ToString();
                lblActiveEmployeeValue.Text = active.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load employees.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
