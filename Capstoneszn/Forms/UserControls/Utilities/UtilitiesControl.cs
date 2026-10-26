using Capstoneszn.Forms.UserControls.Utilities;
using Capstoneszn.Forms.UtilityForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.UserControls
{
    public partial class UtilitiesControl : UserControl
    {
        private AdminWaterBillAccount? _waterAdmin;
        private AdminElectricityAccount? _elecAdmin;

        private int _waterTenantCount;
        private bool _waterHasBill;

        private object? _amountBeforeEdit;   // electricity: value before the user started typing

        private DateTime WaterMonthStart =>
            new DateTime(dtpWaterDate.Value.Year, dtpWaterDate.Value.Month, 1);

        private DateTime ElectricityMonthStart =>
            new DateTime(dtpElectricityDate.Value.Year, dtpElectricityDate.Value.Month, 1);
        public UtilitiesControl()
        {
            InitializeComponent();
            SetupWaterGrid();
            SetupElectricityGrid();
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

            // Electricity: owner card + room grid
            _elecAdmin = new AdminElectricityAccount { Dock = DockStyle.Fill };
            pnlElecAdminAccount.Controls.Add(_elecAdmin);
            dtpElectricityDate.Value = DateTime.Today;
            RefreshElectricityTab();
        }

        private void btnAddElectricity_Click(object sender, EventArgs e)
        {

        }
        private void btnAddWaterBill_Click(object sender, EventArgs e)
        {
            // NEW: a water bill needs the building's water account
            WaterAccountInfo? waterAccount;
            try
            {
                waterAccount = WaterAccountHelper.GetActive(Session.BuildingId);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to check the water account.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (waterAccount == null)
            {
                MessageBox.Show("This building has no water account yet.\n\n" +
                    "Set it up in Settings → Utilities Accounts first.", "Add Bill",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (e.RowIndex < 0 || e.ColumnIndex != colElectricityStatus.Index) return;

            dgvElectricity.EndEdit();   // save an amount that's still being typed
            DataRow data = ElecRow(e.RowIndex);
            string status = data["Status"].ToString() ?? "";
            string room = data["Room"].ToString() ?? "";

            if (status == "Paid")
            {
                MessageBox.Show($"Room {room}'s bill for {ElectricityMonthStart:MMMM yyyy} is already paid and locked.",
                    "Already paid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (data["ChargeId"] == DBNull.Value || data["Amount"] == DBNull.Value)
            {
                MessageBox.Show($"Enter Room {room}'s amount first.", "No bill",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal amount = Convert.ToDecimal(data["Amount"]);
            MarkChargesPaid(new List<int> { Convert.ToInt32(data["ChargeId"]) }, amount,
                $"Mark Room {room} as paid for {ElectricityMonthStart:MMMM yyyy} ({amount:₱#,##0.00})?");
        }

        private void dtpElectricityDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshElectricityTab();
        }

        private void dgvWaterBillData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void SetupElectricityGrid()
        {
            dgvElectricity.AutoGenerateColumns = false;
            dgvElectricity.ReadOnly = false;                         // Designer had it True
            dgvElectricity.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvElectricity.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvElectricity.MultiSelect = false;

            colSelect.DataPropertyName = "Selected";
            colElectricityRoom.DataPropertyName = "Room";
            colElectricityAccountName.DataPropertyName = "AccountName";
            colElectricityAccountNumber.DataPropertyName = "AccountNumber";
            colElectricityAmount.DataPropertyName = "Amount";
            colElectricityStatus.DataPropertyName = "Status";

            // only the checkbox and Amount can be changed
            colSelect.ReadOnly = false;
            colElectricityAmount.ReadOnly = false;
            colElectricityRoom.ReadOnly = true;
            colElectricityAccountName.ReadOnly = true;
            colElectricityAccountNumber.ReadOnly = true;
            colElectricityStatus.ReadOnly = true;

            colElectricityAmount.DefaultCellStyle.Format = "₱#,##0.00";

            dgvElectricity.CellBeginEdit += dgvElectricity_CellBeginEdit;
            dgvElectricity.CellValidating += dgvElectricity_CellValidating;
            dgvElectricity.CellParsing += dgvElectricity_CellParsing;
            dgvElectricity.CellEndEdit += dgvElectricity_CellEndEdit;
            dgvElectricity.CurrentCellDirtyStateChanged += dgvElectricity_CurrentCellDirtyStateChanged;
            dgvElectricity.DataBindingComplete += dgvElectricity_DataBindingComplete;
            dgvElectricity.DataError += dgvElectricity_DataError;

            // reload when the user comes back to the Electricity tab (e.g. after adding a room)
            tabUtilities.SelectedIndexChanged += (s, e) =>
            {
                if (tabUtilities.SelectedTab == tabElectricity) RefreshElectricityTab();
            };
        }
        private DataRow ElecRow(int rowIndex) =>
            ((DataRowView)dgvElectricity.Rows[rowIndex].DataBoundItem).Row;

        public void LoadElectricityGrid()
        {
            var dt = new DataTable();
            dt.Columns.Add("AccountId", typeof(int));
            dt.Columns.Add("ChargeId", typeof(int));      // DBNull = no bill row yet this month
            dt.Columns.Add("Selected", typeof(bool));
            dt.Columns.Add("Room", typeof(string));
            dt.Columns.Add("AccountName", typeof(string));
            dt.Columns.Add("AccountNumber", typeof(string));
            dt.Columns.Add("Amount", typeof(decimal));    // DBNull = no amount entered
            dt.Columns.Add("Status", typeof(string));

            const string sql = @"
                SELECT ea.ElectricityAccountId,
                       r.RoomNumber,
                       ea.AccountName,
                       ea.AccountNumber,
                       ec.ElectricityChargeId,
                       ec.Amount,
                       ec.Status
                FROM   dbo.ElectricityAccounts ea
                JOIN   dbo.Rooms r ON r.RoomId = ea.RoomId
                LEFT JOIN dbo.ElectricityCharges ec
                       ON ec.ElectricityAccountId = ea.ElectricityAccountId
                      AND ec.BillingMonth = @MonthStart
                WHERE  ea.BuildingId = @BuildingId
                  AND  ea.RoomId IS NOT NULL
                ORDER BY r.RoomNumber;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                cmd.Parameters.Add("@MonthStart", SqlDbType.Date).Value = ElectricityMonthStart;

                using SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    bool hasAmount = rd["Amount"] != DBNull.Value;
                    string name = rd["AccountName"].ToString() ?? "";
                    string number = rd["AccountNumber"].ToString() ?? "";

                    dt.Rows.Add(
                        rd["ElectricityAccountId"],
                        rd["ElectricityChargeId"],                    // may be DBNull
                        false,
                        rd["RoomNumber"].ToString(),
                        name.Length == 0 ? "—" : name,
                        number.Length == 0 ? "—" : number,
                        rd["Amount"],                                 // may be DBNull
                        hasAmount ? rd["Status"].ToString() : "No bill");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to load electricity accounts.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvElectricity.DataSource = dt;
        }
        private void RefreshElectricityTab()
        {
            LoadElectricityGrid();
            if (_elecAdmin != null)
            {
                _elecAdmin.SelectedDate = dtpElectricityDate.Value.Date;
                _elecAdmin.LoadAccount();
            }
        }
        private void dgvElectricity_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvElectricity.Rows)
            {
                bool paid = ElecRow(row.Index)["Status"].ToString() == "Paid";
                row.ReadOnly = paid;
                row.DefaultCellStyle.BackColor = paid ? Color.Gainsboro : SystemColors.Window;
            }
        }
        private void dgvElectricity_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRow data = ElecRow(e.RowIndex);

            if (data["Status"].ToString() == "Paid") { e.Cancel = true; return; }

            if (e.ColumnIndex == colElectricityAmount.Index)
            {
                if (ElectricityMonthStart > DateTime.Today)
                {
                    e.Cancel = true;
                    MessageBox.Show("You can't enter amounts for a future month.", "Electricity",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _amountBeforeEdit = data["Amount"];
            }
            else if (e.ColumnIndex == colSelect.Index)
            {
                // can't tick a row that has no amount yet
                if (data["Amount"] == DBNull.Value) e.Cancel = true;
            }
        }
        private void dgvElectricity_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != colElectricityAmount.Index || dgvElectricity.IsCurrentCellInEditMode == false) return;

            if (!ElectricityHelper.TryParseAmount(e.FormattedValue?.ToString(), out decimal? amount)
                || (amount.HasValue && amount.Value <= 0))
            {
                MessageBox.Show("Enter a valid amount greater than 0, or leave it blank.", "Invalid amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        // turn the typed text ("₱1,200", "1200") into a decimal / DBNull for the DataTable
        private void dgvElectricity_CellParsing(object? sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex != colElectricityAmount.Index) return;

            if (ElectricityHelper.TryParseAmount(e.Value?.ToString(), out decimal? amount))
            {
                e.Value = amount.HasValue ? amount.Value : DBNull.Value;
                e.ParsingApplied = true;
            }
        }
        // save the amount as soon as the user leaves the cell
        private void dgvElectricity_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colElectricityAmount.Index) return;

            DataRow data = ElecRow(e.RowIndex);
            object newValue = dgvElectricity.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? DBNull.Value;

            if (Equals(newValue, _amountBeforeEdit)) return;   // nothing changed

            decimal? amount = newValue == DBNull.Value ? null : Convert.ToDecimal(newValue);
            int accountId = Convert.ToInt32(data["AccountId"]);

            int result;
            try
            {
                result = ElectricityHelper.SaveAmount(accountId, ElectricityMonthStart, amount);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to save the amount.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                BeginInvoke(new Action(LoadElectricityGrid));
                return;
            }

            if (result == -1)
            {
                MessageBox.Show("This bill is already paid and can't be edited.", "Bill locked",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                BeginInvoke(new Action(LoadElectricityGrid));
                return;
            }

            // update the row after the grid has finished its edit
            BeginInvoke(new Action(() =>
            {
                if (result > 0) data["ChargeId"] = result;
                data["Status"] = amount.HasValue ? "Unpaid" : "No bill";
                if (!amount.HasValue) data["Selected"] = false;
            }));
        }
        // commit checkbox ticks immediately
        private void dgvElectricity_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvElectricity.CurrentCell is DataGridViewCheckBoxCell)
                dgvElectricity.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgvElectricity_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            MessageBox.Show("Enter a valid amount greater than 0, or leave it blank.", "Invalid amount",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnMarkPaid_Click(object sender, EventArgs e)
        {
            dgvElectricity.EndEdit();   // saves anything still being typed
            if (dgvElectricity.DataSource is not DataTable dt) return;

            var ids = new List<int>();
            decimal total = 0m;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Selected"] is not true) continue;
                if (row["Status"].ToString() != "Unpaid") continue;
                if (row["ChargeId"] == DBNull.Value || row["Amount"] == DBNull.Value) continue;

                ids.Add(Convert.ToInt32(row["ChargeId"]));
                total += Convert.ToDecimal(row["Amount"]);
            }

            if (ids.Count == 0)
            {
                MessageBox.Show("Tick at least one unpaid row that has an amount.", "Mark Paid",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MarkChargesPaid(ids, total,
                $"Mark {ids.Count} account(s) as paid for {ElectricityMonthStart:MMMM yyyy}, total {total:₱#,##0.00}?");
        }

        private void btnSelectAllUnpaid_Click_1(object sender, EventArgs e)
        {
            dgvElectricity.EndEdit();
            if (dgvElectricity.DataSource is not DataTable dt) return;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Status"].ToString() == "Unpaid" && row["Amount"] != DBNull.Value)
                    row["Selected"] = true;
            }
        }
        private void MarkChargesPaid(List<int> ids, decimal total, string question)
        {
            var confirm = MessageBox.Show(
                question + "\n\nPaid bills are locked and can't be edited afterwards.",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes) return;

            const string sql = @"
                UPDATE dbo.ElectricityCharges
                   SET Status   = 'Paid',
                       PaidDate = @Today,
                       MarkedBy = @UserId
                 WHERE ElectricityChargeId = @Id
                   AND Status = 'Unpaid'
                   AND Amount IS NOT NULL;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    foreach (int id in ids)
                    {
                        using var cmd = new SqlCommand(sql, conn, tran);
                        cmd.Parameters.Add("@Today", SqlDbType.Date).Value = DateTime.Today;
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Session.UserId;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to mark the bills as paid.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadElectricityGrid();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private sealed class UnpaidWaterRow
        {
            public string Room = "";
            public string Tenant = "";
            public DateTime DueDate;
            public decimal Share;
            public decimal Paid;
            public decimal Balance => Share - Paid;
        }

        private sealed class WaterReport
        {
            public string Building = "";
            public DateTime Month;
            public decimal Total;
            public decimal Admin;
            public string AdminStatus = "";
            public DateTime? AdminPaidDate;
            public int Billed;
            public List<UnpaidWaterRow> Unpaid = new List<UnpaidWaterRow>();
            public decimal Outstanding => Unpaid.Sum(r => r.Balance);
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            if (WaterMonthStart > DateTime.Today || !_waterHasBill)
            {
                MessageBox.Show($"{WaterMonthStart:MMMM yyyy} has no water bill yet, so there's nothing to report.",
                    "Generate Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            WaterReport rpt;
            try
            {
                rpt = LoadWaterReport(WaterMonthStart);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to load the water report.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rpt.Unpaid.Count == 0)
            {
                MessageBox.Show($"All tenants have paid their {WaterMonthStart:MMMM yyyy} water bill.",
                    "Generate Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int nextRow = 0;
            using var doc = new PrintDocument();
            doc.DocumentName = $"Water Bill Report - {rpt.Month:MMMM yyyy}";
            doc.BeginPrint += (s, ev) => nextRow = 0;               // restart when printing after preview
            doc.PrintPage += (s, ev) => nextRow = DrawWaterReportPage(ev, nextRow, rpt);

            using var preview = new PrintPreviewDialog
            {
                Document = doc,
                Width = 900,
                Height = 1000,
                StartPosition = FormStartPosition.CenterParent
            };
            preview.ShowDialog(this);
        }
        private WaterReport LoadWaterReport(DateTime monthStart)
        {
            var rpt = new WaterReport { Month = monthStart, Building = "Building" };

            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();

            // Building name (first column whose name contains "Name")
            using (var cmd = new SqlCommand("SELECT * FROM dbo.Buildings WHERE BuildingId = @BuildingId;", conn))
            {
                cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                using SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    for (int i = 0; i < rd.FieldCount; i++)
                    {
                        if (rd.GetName(i).IndexOf("Name", StringComparison.OrdinalIgnoreCase) >= 0
                            && !rd.IsDBNull(i))
                        {
                            rpt.Building = rd.GetValue(i).ToString() ?? rpt.Building;
                            break;
                        }
                    }
                }
            }

            // The month's header (total + owner side)
            using (var cmd = new SqlCommand(@"
                SELECT TotalAmount, AdminAmount, AdminStatus, AdminPaidDate
                FROM   dbo.WaterBills
                WHERE  BuildingId = @BuildingId AND BillingMonth = @MonthStart;", conn))
            {
                cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                cmd.Parameters.Add("@MonthStart", SqlDbType.Date).Value = monthStart;
                using SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    rpt.Total = rd.GetDecimal(0);
                    rpt.Admin = rd.GetDecimal(1);
                    rpt.AdminStatus = rd.GetString(2);
                    rpt.AdminPaidDate = rd.IsDBNull(3) ? null : rd.GetDateTime(3);
                }
            }

            // Every tenant share this month, with what's been paid on it
            using (var cmd = new SqlCommand(@"
                SELECT r.RoomNumber,
                       t.LastName + ', ' + t.FirstName AS Tenant,
                       b.DueDate,
                       bt.Share,
                       ISNULL((SELECT SUM(a.Amount)
                               FROM   dbo.PaymentAllocations a
                               JOIN   dbo.Payments p ON p.PaymentId = a.PaymentId
                               WHERE  a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                 AND  a.IsVoided = 0 AND p.IsVoided = 0), 0) AS Paid
                FROM   dbo.Bills b
                JOIN   dbo.BillTenants bt ON bt.BillId  = b.BillId
                JOIN   dbo.Tenants t      ON t.TenantId = bt.TenantId
                JOIN   dbo.Rooms r        ON r.RoomId   = b.RoomId
                JOIN   dbo.Floors f       ON f.FloorId  = r.FloorId
                WHERE  f.BuildingId         = @BuildingId
                  AND  b.BillCategory       = 'Water'
                  AND  b.BillingPeriodStart = @MonthStart
                ORDER BY r.RoomNumber, t.LastName, t.FirstName;", conn))
            {
                cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                cmd.Parameters.Add("@MonthStart", SqlDbType.Date).Value = monthStart;
                using SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    rpt.Billed++;
                    var row = new UnpaidWaterRow
                    {
                        Room = rd["RoomNumber"].ToString() ?? "",
                        Tenant = rd["Tenant"].ToString() ?? "",
                        DueDate = rd.GetDateTime(2),
                        Share = rd.GetDecimal(3),
                        Paid = rd.GetDecimal(4)
                    };
                    if (row.Balance > 0m) rpt.Unpaid.Add(row);
                }
            }

            return rpt;
        }
        /// <summary>Draws one page; returns the index of the next row to print.</summary>
        private int DrawWaterReportPage(PrintPageEventArgs e, int startIndex, WaterReport rpt)
        {
            Graphics g = e.Graphics!;
            Rectangle m = e.MarginBounds;
            float x = m.Left, w = m.Width, y = m.Top;

            using var fTitle = new Font("Segoe UI", 14F, FontStyle.Bold);
            using var fBold = new Font("Segoe UI", 9F, FontStyle.Bold);
            using var fText = new Font("Segoe UI", 9F);
            using var right = new StringFormat { Alignment = StringAlignment.Far };
            float lh = fText.GetHeight(g) + 5;

            void Amount(string text, Font f, float rightEdge) =>
                g.DrawString(text, f, Brushes.Black, new RectangleF(x, y, rightEdge - x, lh), right);

            void SummaryLine(string label, string value, Font f)
            {
                g.DrawString(label, f, Brushes.Black, x, y);
                Amount(value, f, x + w);
                y += lh;
            }

            // ── Header + summary (first page only) ──
            if (startIndex == 0)
            {
                g.DrawString(rpt.Building, fTitle, Brushes.Black, x, y);
                y += fTitle.GetHeight(g) + 2;
                g.DrawString("Water Bill Report - Unpaid Tenants", fBold, Brushes.Black, x, y);
                y += lh;
                g.DrawString($"Billing Month: {rpt.Month:MMMM yyyy}", fText, Brushes.Black, x, y);
                y += lh;
                g.DrawLine(Pens.Black, x, y, x + w, y);
                y += 10;

                string owner = rpt.AdminStatus == "Paid"
                    ? $"Paid {rpt.AdminPaidDate:MMM d, yyyy}"
                    : "Unpaid";

                g.DrawString("SUMMARY", fBold, Brushes.Black, x, y);
                y += lh;
                SummaryLine("Total Water Bill", rpt.Total.ToString("₱#,##0.00"), fText);
                SummaryLine("Owner's Share", $"{rpt.Admin:₱#,##0.00}  ({owner})", fText);
                SummaryLine("Tenants Billed", rpt.Billed.ToString(), fText);
                SummaryLine("Tenants Unpaid", rpt.Unpaid.Count.ToString(), fText);
                SummaryLine("TOTAL OUTSTANDING (Tenants)", rpt.Outstanding.ToString("₱#,##0.00"), fBold);
                g.DrawLine(Pens.Black, x, y, x + w, y);
                y += 14;

                g.DrawString($"UNPAID TENANTS ({rpt.Unpaid.Count})", fBold, Brushes.Black, x, y);
                y += lh;
            }

            // ── Table header (every page) ──
            float cRoom = x, cTenant = x + w * 0.10f, cDue = x + w * 0.45f;
            float eShare = x + w * 0.70f, ePaid = x + w * 0.85f, eBal = x + w;

            g.DrawString("Room", fBold, Brushes.Black, cRoom, y);
            g.DrawString("Tenant", fBold, Brushes.Black, cTenant, y);
            g.DrawString("Due Date", fBold, Brushes.Black, cDue, y);
            Amount("Share", fBold, eShare);
            Amount("Paid", fBold, ePaid);
            Amount("Balance", fBold, eBal);
            y += lh;
            g.DrawLine(Pens.Black, x, y - 2, x + w, y - 2);
            y += 2;

            // ── Rows ──
            int i = startIndex;
            while (i < rpt.Unpaid.Count)
            {
                if (y + lh * 3 > m.Bottom)          // keep room for the total line
                {
                    e.HasMorePages = true;
                    return i;
                }

                var r = rpt.Unpaid[i];
                g.DrawString(r.Room, fText, Brushes.Black, cRoom, y);
                g.DrawString(r.Tenant, fText, Brushes.Black, cTenant, y);
                g.DrawString(r.DueDate.ToString("MMM d, yyyy"), fText, Brushes.Black, cDue, y);
                Amount(r.Share.ToString("₱#,##0.00"), fText, eShare);
                Amount(r.Paid.ToString("₱#,##0.00"), fText, ePaid);
                Amount(r.Balance.ToString("₱#,##0.00"), fText, eBal);
                y += lh;
                i++;
            }

            // ── Total + footer (last page) ──
            g.DrawLine(Pens.Black, x, y, x + w, y);
            y += 4;
            g.DrawString("Total Outstanding", fBold, Brushes.Black, x, y);
            Amount(rpt.Outstanding.ToString("₱#,##0.00"), fBold, eBal);
            y += lh * 2;
            g.DrawString($"Generated {DateTime.Now:MMM dd, yyyy hh:mm tt}", fText, Brushes.Gray, x, y);

            e.HasMorePages = false;
            return i;
        }
    }
}