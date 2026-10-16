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

            if (monthStart > DateTime.Today)
            {
                dgvWaterBillData.DataSource = dt;
                return;
            }

            const string billSql = @"
        SELECT CASE WHEN EXISTS (
                   SELECT 1
                   FROM   dbo.Bills b
                   INNER JOIN dbo.Rooms  r ON r.RoomId  = b.RoomId
                   INNER JOIN dbo.Floors f ON f.FloorId = r.FloorId
                   WHERE  f.BuildingId        = @BuildingId
                     AND  b.BillCategory      = 'Utilities'
                     AND  b.BillingPeriodStart = @MonthStart)
               THEN 1 ELSE 0 END;";

            const string tenantSql = @"
        SELECT r.RoomNumber,
               t.LastName + ', ' + t.FirstName AS Tenant,
               CASE WHEN tn.MoveInDate <= @MonthStart THEN 1 ELSE 0 END AS Eligible,
               wb.DueDate, wb.Share, wb.BillStatus
        FROM   dbo.Tenancies tn
        INNER JOIN dbo.Tenants t ON t.TenantId = tn.TenantId
        INNER JOIN dbo.Rooms   r ON r.RoomId   = tn.RoomId
        INNER JOIN dbo.Floors  f ON f.FloorId  = r.FloorId
        OUTER APPLY (
            SELECT TOP 1 b.DueDate, bt.Share,
                   CASE WHEN bt.Share - ISNULL((
                            SELECT SUM(a.Amount)
                            FROM   dbo.PaymentAllocations a
                            JOIN   dbo.Payments p ON p.PaymentId = a.PaymentId
                            WHERE  a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                              AND  a.IsVoided = 0 AND p.IsVoided = 0), 0) <= 0
                        THEN 'Paid' ELSE 'Unpaid' END AS BillStatus
            FROM   dbo.Bills b
            JOIN   dbo.BillTenants bt ON bt.BillId = b.BillId
            WHERE  bt.TenantId = tn.TenantId
              AND  b.BillCategory = 'Utilities'
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
                    _waterHasBill = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
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
                        if (rd.GetInt32(rd.GetOrdinal("Eligible")) == 1) _waterTenantCount++;

                        dt.Rows.Add(
                            rd["RoomNumber"].ToString(),
                            rd["Tenant"].ToString(),
                            onBill ? rd.GetDateTime(rd.GetOrdinal("DueDate")).ToString("MMM d, yyyy") : "—",
                            onBill ? "₱" + rd.GetDecimal(rd.GetOrdinal("Share")).ToString("N2") : "—",
                            onBill ? rd.GetString(rd.GetOrdinal("BillStatus")) : "Unpaid");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to load water bills.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvWaterBillData.DataSource = dt;
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
        private void btnEditWaterBill_Click(object sender, EventArgs e)
        {
            if (!_waterHasBill)
            {
                MessageBox.Show($"There's no water bill for {WaterMonthStart:MMMM yyyy} yet. Use Add Bill first.",
                    "Edit Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var ewb = new EditWaterBillForm();
            if (ewb.ShowDialog(this) == DialogResult.OK)
                RefreshWaterTab();
        }

        private void btnEditElectricity_Click(object sender, EventArgs e)
        {
            using var frm = new EditElectricityForm();

            if (frm.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void UtilitiesControl_Load(object sender, EventArgs e)
        {
            dtpWaterDate.Value = DateTime.Today;

            _waterAdmin = new AdminWaterBillAccount { Dock = DockStyle.Fill };
            _waterAdmin.SelectedDate = dtpWaterDate.Value.Date;
            pnlWaterAdminAccount.Controls.Add(_waterAdmin);
            _waterAdmin.LoadAccount();

            LoadWaterBillGrid();

            /*
            _elecAdmin = new AdminElectricityAccount { Dock = DockStyle.Fill };
            _elecAdmin.SelectedDate = dtpElectricityDate.Value.Date;
            pnlElecAdminAccount.Controls.Add(_elecAdmin);
            _elecAdmin.LoadAccount();
            */
        }

        private void btnAddElectricity_Click(object sender, EventArgs e)
        {
            using var aef = new AddElectricityForm();

            if (aef.ShowDialog(this) == DialogResult.OK)
            {

            }
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
                MessageBox.Show($"No tenants were active on {WaterMonthStart:MMMM d, yyyy}, so there's no one to split the bill with.",
                    "Add Bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var awf = new AddWaterBillForm();
            if (awf.ShowDialog(this) == DialogResult.OK)
                RefreshWaterTab();
        }

        private void dtpWaterDate_ValueChanged(object sender, EventArgs e)
        {
            LoadWaterBillGrid();

            if (_waterAdmin != null)
            {
                _waterAdmin.SelectedDate = dtpWaterDate.Value.Date;
                _waterAdmin.LoadAccount();
            }
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