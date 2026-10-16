using Capstoneszn.Forms.UserControls.Utilities;
using Capstoneszn.Forms.UtilityForms;
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

namespace Capstoneszn.UserControls
{
    public partial class UtilitiesControl : UserControl
    {
        private AdminWaterBillAccount? _waterAdmin;

        private int _waterTenantCount;
        private bool _waterHasBill;

        private DateTime WaterMonthStart =>
            new DateTime(dtpWaterDate.Value.Year, dtpWaterDate.Value.Month, 1);
        public UtilitiesControl()
        {
            InitializeComponent();
            SetupWaterGrid();
        }
        private void SetupWaterGrid()
        {
            dgvWaterBillData.AutoGenerateColumns = false;
            colWaterRoom.DataPropertyName = "Room";
            colWaterTenant.DataPropertyName = "Tenant";
            colWaterDueDate.DataPropertyName = "DueDate";
            colWaterAmount.DataPropertyName = "Amount";
            colWaterStatus.DataPropertyName = "Status";
        }
        public void LoadWaterBillGrid()
        {
            DateTime monthStart = WaterMonthStart;
            DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);

            var dt = new DataTable();
            dt.Columns.Add("Room");
            dt.Columns.Add("Tenant");
            dt.Columns.Add("DueDate");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Status");

            _waterTenantCount = 0;
            _waterHasBill = false;

            decimal billTotal = 0m;
            int billedCount = 0;   // tenants actually on this month's bill

            if (monthStart > DateTime.Today)   // future month: nothing to show
            {
                dgvWaterBillData.DataSource = dt;
                UpdateWaterSummary(false, 0m, 0);
                return;
            }

            const string billSql = @"
                    SELECT TotalAmount
                    FROM   dbo.WaterBills
                    WHERE  BuildingId   = @BuildingId
                      AND  BillingMonth = @MonthStart;";

                        const string tenantSql = @"
                    SELECT r.RoomNumber,
                            t.LastName + ', ' + t.FirstName AS Tenant,
                            CASE WHEN tn.MoveInDate <= @MonthStart THEN 1 ELSE 0 END AS Eligible,
                            wb.DueDate, wb.Share, wb.PaidAmount
                    FROM   dbo.Tenancies tn
                    INNER JOIN dbo.Tenants t ON t.TenantId = tn.TenantId
                    INNER JOIN dbo.Rooms   r ON r.RoomId   = tn.RoomId
                    INNER JOIN dbo.Floors  f ON f.FloorId  = r.FloorId
                    OUTER APPLY (
                        SELECT TOP 1 b.DueDate, bt.Share,
                               ISNULL((SELECT SUM(a.Amount)
                                       FROM   dbo.PaymentAllocations a
                                       JOIN   dbo.Payments p ON p.PaymentId = a.PaymentId
                                       WHERE  a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                         AND  a.IsVoided = 0 AND p.IsVoided = 0), 0) AS PaidAmount
                        FROM   dbo.Bills b
                        JOIN   dbo.BillTenants bt ON bt.BillId = b.BillId
                        WHERE  bt.TenantId = tn.TenantId
                            AND  b.BillCategory = 'Water'
                            AND  b.BillingPeriodStart = @MonthStart
                    ) wb
                    WHERE  f.BuildingId  = @BuildingId
                        AND  tn.Status     = 'Active'
                        AND  tn.MoveInDate <= @MonthEnd
                    ORDER BY r.RoomNumber, t.LastName, t.FirstName;";   

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using (var cmd = new SqlCommand(billSql, conn))
                {
                    cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                    cmd.Parameters.Add("@MonthStart", SqlDbType.Date).Value = monthStart;

                    object? result = cmd.ExecuteScalar();
                    _waterHasBill = result != null && result != DBNull.Value;
                    if (_waterHasBill) billTotal = Convert.ToDecimal(result);
                }

                using (var cmd = new SqlCommand(tenantSql, conn))
                {
                    cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                    cmd.Parameters.Add("@MonthStart", SqlDbType.Date).Value = monthStart;
                    cmd.Parameters.Add("@MonthEnd", SqlDbType.Date).Value = monthEnd;

                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        bool onBill = !rd.IsDBNull(rd.GetOrdinal("Share"));
                        if (onBill) billedCount++;
                        if (rd.GetInt32(rd.GetOrdinal("Eligible")) == 1) _waterTenantCount++;

                        string amountText = "—";
                        string statusText = "—";

                        if (onBill)
                        {
                            decimal share = rd.GetDecimal(rd.GetOrdinal("Share"));
                            decimal paid = rd.GetDecimal(rd.GetOrdinal("PaidAmount"));
                            decimal balance = Math.Max(share - paid, 0m);   // what's still owed

                            amountText = "₱" + balance.ToString("N2");
                            statusText = balance <= 0m ? "Paid" : "Unpaid";
                        }

                        dt.Rows.Add(
                            rd["RoomNumber"].ToString(),
                            rd["Tenant"].ToString(),
                            onBill ? rd.GetDateTime(rd.GetOrdinal("DueDate")).ToString("MMM d, yyyy") : "—",
                            amountText,
                            statusText);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to load water bills.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvWaterBillData.DataSource = dt;
            UpdateWaterSummary(_waterHasBill, billTotal, billedCount);
        }

        private void UpdateWaterSummary(bool hasBill, decimal total, int billedCount)
        {
            if (!hasBill)
            {
                lblCurrentTotalBillValue.Text = "—";
                lblTotalSharesValue.Text = "—";
                return;
            }

            lblCurrentTotalBillValue.Text = total.ToString("₱#,##0.00");
            lblTotalSharesValue.Text = $"{billedCount + 1}  ({billedCount} tenants + owner)";
        }
        private void btnEditWaterBill_Click(object sender, EventArgs e)
        {
            if (!_waterHasBill)
            {
                MessageBox.Show($"{WaterMonthStart:MMMM yyyy} has no water bill yet. Use Add Bill first.",
                    "Edit Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var ewf = new EditWaterBillForm(WaterMonthStart);
            if (ewf.ShowDialog(this) == DialogResult.OK)
                RefreshWaterTab();
        }

        private void btnEditElectricity_Click(object sender, EventArgs e)
        {

        }

        private void UtilitiesControl_Load(object sender, EventArgs e)
        {
            dtpWaterDate.Value = DateTime.Today;

            _waterAdmin = new AdminWaterBillAccount { Dock = DockStyle.Fill };
            _waterAdmin.SelectedDate = dtpWaterDate.Value.Date;
            pnlWaterAdminAccount.Controls.Add(_waterAdmin);
            _waterAdmin.LoadAccount();

            LoadWaterBillGrid();
        }

        private void btnAddElectricity_Click(object sender, EventArgs e)
        {
            
        }
        private void btnAddWaterBill_Click(object sender, EventArgs e)
        {
            if (WaterMonthStart > DateTime.Today)
            {
                MessageBox.Show("You can't add a bill for a future month.", "Add Bill",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_waterHasBill)
            {
                MessageBox.Show($"{WaterMonthStart:MMMM yyyy} already has a water bill. Use Edit Bill instead.",
                    "Add Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_waterTenantCount == 0)
            {
                MessageBox.Show($"There are no active tenants for {WaterMonthStart:MMMM yyyy}, so there's no one to split the bill with.",
                    "Add Bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var awf = new AddWaterBillForm(WaterMonthStart);
            if (awf.ShowDialog(this) == DialogResult.OK)
                RefreshWaterTab();
        }

        private void RefreshWaterTab()
        {
            LoadWaterBillGrid();
            if (_waterAdmin != null)
            {
                _waterAdmin.SelectedDate = dtpWaterDate.Value.Date;
                _waterAdmin.LoadAccount();
            }
        }

        private void dtpWaterDate_ValueChanged(object sender, EventArgs e)
        {
            LoadWaterBillGrid();

            if (_waterAdmin == null) return;

            _waterAdmin.SelectedDate = dtpWaterDate.Value.Date;
            _waterAdmin.LoadAccount();
        }

        private void dgvElectricityBillData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtpElectricityDate_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvWaterBillData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}