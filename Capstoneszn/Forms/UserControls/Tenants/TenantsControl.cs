using Capstoneszn.Forms.TenantForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;   // NEW: name / contact validation

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// The current tenants of the selected building, with each one's
    /// details and billing position.
    ///
    /// "Current" means an Active tenancy. A tenant who moved out has no
    /// active tenancy, so they leave this list on their own - that IS the
    /// archive. No flag on Tenants is needed for it, and none is read here.
    /// </summary>
    /// 

    public partial class TenantsControl : UserControl
    {
        /// <summary>
        /// Every category the ledger knows. All are summed into Available
        /// Balance even where the panel has no row of its own, so money
        /// recorded under any of them is never left out of the total.
        /// </summary>
        /// 

        private static readonly string[] Categories =
            { "Rent", "Maintenance", "Water", "Electricity", "Other" };

        private DataTable _tenants = new DataTable();
        private int _selectedTenantId = -1;

        // NEW (Nov 13): hover text for the Electricity row
        private readonly ToolTip _summaryTip = new ToolTip();

        // Null-safe text from a reader/scalar value (DBNull or null -> "")
        static string Str(object? o) => Convert.ToString(o)?.Trim() ?? "";

        public TenantsControl()
        {
            InitializeComponent();

            ApplyTenantsTheme();   // NEW (UI improvement)

            // Map grid columns to the SQL result
            dgvTenants.AutoGenerateColumns = false;
            colRoom.DataPropertyName = "RoomNumber";
            colFname.DataPropertyName = "FirstName";
            colMname.DataPropertyName = "MiddleName";
            colLname.DataPropertyName = "LastName";
            colAddress.DataPropertyName = "Address";
            colContactNumber.DataPropertyName = "ContactNumber";
            colDateOccupied.DataPropertyName = "MoveInDate";
            colDateOccupied.DefaultCellStyle.Format = "MMM d, yyyy";

            dgvTenants.ReadOnly = true;
            dgvTenants.AllowUserToAddRows = false;
            dgvTenants.RowHeadersVisible = false;
            dgvTenants.MultiSelect = false;
            dgvTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Wire events
            dgvTenants.SelectionChanged += dgvTenants_SelectionChanged;

            // NEW (Nov 13): nothing selected when the list is shown or refreshed
            dgvTenants.DataBindingComplete += dgvTenants_DataBindingComplete;

            pnlTenantDetails.Visible = false;   // nothing selected yet
            LoadTenants();
        }

        public void LoadTenants()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // No t.IsArchived check: an Active tenancy already means
                    // "currently renting", and whether Tenants still has that
                    // column at all is unsettled. Relying on the tenancy keeps
                    // this list correct either way.
                    string sql = @"
                        SELECT t.TenantId, r.RoomNumber, t.FirstName, t.MiddleName,
                               t.LastName, t.Address, t.ContactNumber, tn.MoveInDate
                        FROM   Tenants t
                        INNER JOIN Tenancies tn ON tn.TenantId = t.TenantId
                        INNER JOIN Rooms r      ON r.RoomId    = tn.RoomId
                        WHERE  r.BuildingId = @BuildingId
                          AND  tn.Status    = 'Active'
                        ORDER BY t.LastName, t.FirstName;";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;

                        _tenants = new DataTable();
                        using (var da = new SqlDataAdapter(cmd))
                            da.Fill(_tenants);
                    }

                    dgvTenants.DataSource = _tenants;
                    dgvTenants.ClearSelection();
                }
                catch (Exception ex)
                {
                    // Keep the reason visible while the system is being
                    // tested - "Unable to load" alone gives nothing to fix.
                    Debug.WriteLine(ex);
                    MessageBox.Show("Unable to load tenants: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void TenantsControl_Load(object sender, EventArgs e)
        {

        }

        private void btnEditTenant_Click(object sender, EventArgs e)
        {
            if (_selectedTenantId <= 0)
            {
                MessageBox.Show("Please select a tenant first.", "No Tenant Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (EditTenant edit = new EditTenant(_selectedTenantId))
            {
                if (edit.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    int keepId = _selectedTenantId;
                    LoadTenants();
                    Reselect(keepId);
                }
            }
        }

        private void btnCloseTenantDetails_Click(object sender, EventArgs e)
        {
            pnlTenantDetails.Visible = false;
            _selectedTenantId = -1;
            dgvTenants.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_tenants == null) return;

            string term = EscapeFilter(txtSearch.Text.Trim());

            _tenants.DefaultView.RowFilter = term.Length == 0
                ? ""
                : $"FirstName LIKE '%{term}%' OR LastName LIKE '%{term}%' " +
                  // ORIGINAL: $"OR MiddleName LIKE '%{term}%' OR RoomNumber LIKE '%{term}%' " +
                  // NEW: RoomNumber is INT - LIKE only works on text, so convert it first
                  $"OR MiddleName LIKE '%{term}%' OR Convert(RoomNumber, 'System.String') LIKE '%{term}%' " +
                  $"OR ContactNumber LIKE '%{term}%'";

            pnlTenantDetails.Visible = false;   // old selection no longer valid
            _selectedTenantId = -1;
        }

        // RowFilter treats [ ] * % as pattern characters. Without escaping,
        // typing a single "[" throws a SyntaxErrorException.
        private static string EscapeFilter(string s)
        {
            return (s ?? string.Empty)
                .Replace("[", "[[]")   // must come first
                .Replace("%", "[%]")
                .Replace("*", "[*]")
                .Replace("'", "''");
        }

        private void dgvTenants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTenants_SelectionChanged(object sender, EventArgs e)
        {
            // OLD:
            // if (dgvTenants.CurrentRow == null || dgvTenants.CurrentRow.Index < 0)
            // {
            //     pnlTenantDetails.Visible = false;
            //     _selectedTenantId = -1;
            //     return;
            // }
            //
            // DataRowView row = dgvTenants.CurrentRow.DataBoundItem as DataRowView;
            // if (row == null) return;

            // NEW (Nov 13): CurrentRow stays set even after ClearSelection(), which
            //      reopened the panel when X was clicked. Use the SELECTED row instead.
            if (dgvTenants.SelectedRows.Count == 0)
            {
                pnlTenantDetails.Visible = false;
                _selectedTenantId = -1;
                return;
            }

            DataRowView row = dgvTenants.SelectedRows[0].DataBoundItem as DataRowView;
            if (row == null) return;

            _selectedTenantId = Convert.ToInt32(row["TenantId"]);
            ShowDetails(row);
        }

        // NEW (Nov 13): the grid selects row 1 by itself after binding (first display,
        //      search filter). Clear it so no tenant opens until the user clicks one.
        private void dgvTenants_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTenants.ClearSelection();
        }

        private void ShowDetails(DataRowView row)
        {
            lblRoomValue.Text = Val(row["RoomNumber"]);
            lblFirstNameValue.Text = Val(row["FirstName"]);
            lblMiddleNameValue.Text = Val(row["MiddleName"]);
            lblLastNameValue.Text = Val(row["LastName"]);
            lblAddressValue.Text = Val(row["Address"]);
            lblContactNumberValue.Text = Val(row["ContactNumber"]);

            lblDateOccupiedValue.Text = row["MoveInDate"] == DBNull.Value
                ? "-"
                : Convert.ToDateTime(row["MoveInDate"]).ToString("MMMM d, yyyy");

            LoadTenantBillingSummary(_selectedTenantId);

            pnlTenantDetails.Visible = true;
        }

        private static string Val(object o)
        {
            if (o == null || o == DBNull.Value) return "-";
            string s = o.ToString().Trim();
            return s.Length == 0 ? "-" : s;
        }

        private void Reselect(int tenantId)
        {
            foreach (DataGridViewRow gridRow in dgvTenants.Rows)
            {
                DataRowView row = gridRow.DataBoundItem as DataRowView;
                if (row != null && Convert.ToInt32(row["TenantId"]) == tenantId)
                {
                    gridRow.Selected = true;
                    dgvTenants.CurrentCell = gridRow.Cells[0];
                    return;
                }
            }
        }

        /* =================================================================
           BILLING SUMMARY

           OLD: Available Balance was the net of ALL categories.
           NEW (Nov 12, 2026):
             - Available Balance = RENT ONLY (settled rule):
                 rent credit - rent owed.  + = paid ahead, - = behind on rent.
             - Rent / Maintenance / Water rows = what is still owed (BillingHelper).
             - Electricity row = the tenant's CURRENT ROOM's unpaid electricity,
               read from Utilities (ElectricityCharges). It is a room bill paid
               directly to AKELCO, so it is never added to Available Balance.
           ================================================================= */

        private void LoadTenantBillingSummary(int tenantId)
        {

            // NEW
            decimal rentOwed, maintOwed, waterOwed, rentCredit, electricity;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    rentOwed = BillingHelper.GetTotalOutstanding(conn, tenantId, "Rent");
                    maintOwed = BillingHelper.GetTotalOutstanding(conn, tenantId, "Maintenance");
                    waterOwed = BillingHelper.GetTotalOutstanding(conn, tenantId, "Water");
                    rentCredit = BillingHelper.GetAvailableCredit(conn, tenantId, "Rent");

                    // Unpaid electricity of the room the tenant lives in now.
                    // Only charges with an amount entered count; Paid ones drop to 0.
                    using (var cmd = new SqlCommand(@"
                        SELECT ISNULL(SUM(ec.Amount), 0)
                        FROM   Tenancies tn
                        JOIN   ElectricityAccounts ea ON ea.RoomId = tn.RoomId
                                                     AND ea.IsArchived = 0
                        JOIN   ElectricityCharges ec  ON ec.ElectricityAccountId = ea.ElectricityAccountId
                        WHERE  tn.TenantId = @tid
                          AND  tn.Status   = 'Active'
                          AND  ec.Status   = 'Unpaid'
                          AND  ec.Amount IS NOT NULL;", conn))
                    {
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                        electricity = Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                // Never show 0.00 when the real figure is unknown - that
                // would read as "owes nothing".
                Debug.WriteLine(ex);
                foreach (Label l in new[] { lblRentBillValue, lblMaintenanceBillValue,
                                            lblWaterBillValue, lblElectricityBillValue,
                                             lblAvailableBalanceValue })
                {
                    l.Text = "-";
                    l.ForeColor = Color.White;
                }
                return;
            }

            // OLD:
            // ShowOwed(lblRentBillValue, owed["Rent"]);
            // ShowOwed(lblMaintenanceBillValue, owed["Maintenance"]);
            // ShowOwed(lblWaterBillValue, owed["Water"]);
            // ShowOwed(lblElectricityBillValue, owed["Electricity"]);

            // NEW
            ShowOwed(lblRentBillValue, rentOwed);
            ShowOwed(lblMaintenanceBillValue, maintOwed);
            ShowOwed(lblWaterBillValue, waterOwed);

            // Electricity: room bill, paid to AKELCO - labelled so it is not read
            // as something the tenant owes the landlord.
            // OLD:
            // lblElectricityBillValue.Text = electricity > 0m
            //     ? "₱ " + electricity.ToString("N2") + " (room · pay AKELCO)"
            //     : "₱ 0.00";
            // lblElectricityBillValue.ForeColor = electricity > 0m ? Color.Salmon : Color.White;

            // NEW (Nov 13): shorter text so it fits the panel; full explanation on hover
            lblElectricityBillValue.Text = electricity > 0m
                ? "₱ " + electricity.ToString("N2") + " · AKELCO"
                : "₱ 0.00";
            lblElectricityBillValue.ForeColor = electricity > 0m ? Color.Salmon : Color.White;
            _summaryTip.SetToolTip(lblElectricityBillValue, electricity > 0m
                ? "Unpaid electricity of the whole room (from Utilities).\nPaid directly to AKELCO"
                : "No unpaid electricity bill for this room.");

            // The Utilities row is Water + Electricity together.
            //ShowOwed(lblUtilitiesBillValue, owed["Water"] + owed["Electricity"]);

            // OLD: net of all categories
            // lblAvailableBalanceValue.Text =
            //     (net < 0m ? "-₱ " : "₱ ") + Math.Abs(net).ToString("N2");
            // lblAvailableBalanceValue.ForeColor = net < 0m ? Color.Salmon
            //                                    : net > 0m ? Color.PaleGreen
            //                                    : Color.White;

            // NEW: rent only (+ = paid ahead, - = behind on rent)
            decimal rentBalance = rentCredit - rentOwed;
            lblAvailableBalanceValue.Text =
                (rentBalance < 0m ? "-₱ " : "₱ ") + Math.Abs(rentBalance).ToString("N2");
            lblAvailableBalanceValue.ForeColor = rentBalance < 0m ? Color.Salmon
                                               : rentBalance > 0m ? Color.PaleGreen
                                               : Color.White;

        }

        private static void ShowOwed(Label label, decimal amount)
        {
            label.Text = "₱ " + amount.ToString("N2");
            label.ForeColor = amount > 0m ? Color.Salmon : Color.White;
        }


        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (_selectedTenantId <= 0) return;

            // NEW (Nov 12, 2026): redesigned View Details - summary cards + Bills / Payments tabs
            using (var account = new TenantAccountForm(_selectedTenantId))
                account.ShowDialog(this.FindForm());
        }

#if false // OLD (Nov 3, 2026): one-period statement, newest period only, no Current/All picker.
        //     Kept for reference, not compiled. NEW version is below (#endif).
        /* =================================================================
           GENERATE STATEMENT  (NEW - aligned with Billing Management v2)

           One tenant's Statement of Account for ONE billing period, using the
           SAME formula and period list as the room statement in Bill
           Management (RoomStatementService), so both always agree:

               Previous balance
             + Current charges (Rent, Water, Maintenance DUE within the period)
             - Payments received during the period
             +/- Adjustments (write-off = less owed, forfeit = credit given up)
             = Amount due   (negative = advance credit)

           Period  = the room's newest rent period (the first one Bill
                     Management lists; bills exist 7 days before the due date).
           As-of   = the period's last day if it is already over, else today.
                     Only bills generated / payments dated on or before it
                     count; a payment voided AFTER it still counts.
           Scope   = this tenant's whole account (every room, every stay), so
                     a transfer or a return never hides a debt or a credit.

           Read-only. Electricity is excluded (paid directly to AKELCO).
           ================================================================= */
        private void btnGenerateStatement_Click(object sender, EventArgs e)
        {
            if (_selectedTenantId <= 0)
            {
                MessageBox.Show("Please select a tenant first.", "No Tenant Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("No printer is installed. Enable \"Microsoft Print to PDF\" in Windows Features.",
                    "Billing Statement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tenantId = _selectedTenantId;
            DateTime today = DateTime.Today;

            string building = "", tenantName = "", roomNo = "", preparedBy = "-";
            DateTime moveIn = today;
            StatementPeriod period;
            DateTime asOf;

            decimal prevBalance = 0m, rent = 0m, water = 0m, maint = 0m, payments = 0m, adjustments = 0m;

            // Desc, Due, Share, Paid (as of the statement date)
            var lines = new List<(string Desc, DateTime Due, decimal Share, decimal Paid)>();
            var receipts = new List<(DateTime Date, string Receipt, string Method, string PaidBy, decimal Amount)>();
            var notes = new List<string>();

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                // ---- 1. Active stay, room, building -------------------------------
                int roomId;
                using (var cmd = new SqlCommand(@"
                    SELECT tn.RoomId, tn.MoveInDate, t.FirstName, t.MiddleName, t.LastName,
                           r.RoomNumber, b.BuildingName
                    FROM   Tenancies tn
                    JOIN   Tenants t   ON t.TenantId   = tn.TenantId
                    JOIN   Rooms r     ON r.RoomId     = tn.RoomId
                    JOIN   Buildings b ON b.BuildingId = r.BuildingId
                    WHERE  tn.TenantId = @tid AND tn.Status = 'Active';", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    if (!rd.Read())
                    {
                        MessageBox.Show("This tenant has already moved out. The list will be refreshed.",
                            "Billing Statement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pnlTenantDetails.Visible = false;
                        _selectedTenantId = -1;
                        LoadTenants();
                        return;
                    }

                    roomId = Convert.ToInt32(rd["RoomId"]);
                    moveIn = Convert.ToDateTime(rd["MoveInDate"]).Date;
                    roomNo = Str(rd["RoomNumber"]);
                    building = Str(rd["BuildingName"]);

                    string mid = Str(rd["MiddleName"]);
                    tenantName = Str(rd["LastName"]) + ", " + Str(rd["FirstName"]) +
                                 (mid.Length > 0 ? " " + mid[0] + "." : "");
                }

                // ---- 2. The period: same list Bill Management uses -----------------
                List<StatementPeriod> periods = RoomStatementService.GetPeriods(roomId);
                if (periods.Count == 0)
                {
                    MessageBox.Show($"Room {roomNo} has no rent bill yet, so there is no billing period to show.",
                        "Billing Statement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                period = periods[0];                                   // newest first
                asOf = period.LastDay < today ? period.LastDay : today;
                DateTime dNext = asOf.AddDays(1);                      // "on or before asOf" = "< dNext"

                void AddParams(SqlCommand c)
                {
                    c.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    c.Parameters.Add("@S", SqlDbType.Date).Value = period.Start;
                    c.Parameters.Add("@E", SqlDbType.Date).Value = period.End;
                    c.Parameters.Add("@Dnext", SqlDbType.Date).Value = dNext;
                }

                // ---- 3. Summary totals (RoomStatementService formula, one tenant) --
                using (var cmd = new SqlCommand(@"
                    SELECT
                      ISNULL((SELECT SUM(bt.Share) FROM BillTenants bt JOIN Bills b ON b.BillId = bt.BillId
                              WHERE bt.TenantId = @tid AND b.BillCategory IN ('Rent','Water','Maintenance')
                                AND b.DueDate < @S
                                AND ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext), 0)
                    - ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a JOIN Payments p ON p.PaymentId = a.PaymentId
                              WHERE a.TenantId = @tid AND p.PaymentDate < @S
                                AND (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)), 0)
                    + ISNULL((SELECT SUM(CASE WHEN ta.AdjustmentType = 'WriteOff' THEN -ta.Amount ELSE ta.Amount END)
                              FROM TenantAdjustments ta
                              WHERE ta.TenantId = @tid AND ta.AdjustmentDate < @S), 0)                AS PrevBalance,

                      ISNULL((SELECT SUM(bt.Share) FROM BillTenants bt JOIN Bills b ON b.BillId = bt.BillId
                              WHERE bt.TenantId = @tid AND b.BillCategory = 'Rent'
                                AND b.DueDate >= @S AND b.DueDate < @E
                                AND ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext), 0) AS Rent,
                      ISNULL((SELECT SUM(bt.Share) FROM BillTenants bt JOIN Bills b ON b.BillId = bt.BillId
                              WHERE bt.TenantId = @tid AND b.BillCategory = 'Water'
                                AND b.DueDate >= @S AND b.DueDate < @E
                                AND ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext), 0) AS Water,
                      ISNULL((SELECT SUM(bt.Share) FROM BillTenants bt JOIN Bills b ON b.BillId = bt.BillId
                              WHERE bt.TenantId = @tid AND b.BillCategory = 'Maintenance'
                                AND b.DueDate >= @S AND b.DueDate < @E
                                AND ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext), 0) AS Maint,

                      ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a JOIN Payments p ON p.PaymentId = a.PaymentId
                              WHERE a.TenantId = @tid AND p.PaymentDate >= @S AND p.PaymentDate < @Dnext
                                AND (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)), 0)                AS Payments,

                      ISNULL((SELECT SUM(CASE WHEN ta.AdjustmentType = 'WriteOff' THEN -ta.Amount ELSE ta.Amount END)
                              FROM TenantAdjustments ta
                              WHERE ta.TenantId = @tid AND ta.AdjustmentDate >= @S
                                AND ta.AdjustmentDate < @Dnext), 0)                                AS Adjustments;", conn))
                {
                    AddParams(cmd);
                    using SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    prevBalance = rd.GetDecimal(0);
                    rent = rd.GetDecimal(1);
                    water = rd.GetDecimal(2);
                    maint = rd.GetDecimal(3);
                    payments = rd.GetDecimal(4);
                    adjustments = rd.GetDecimal(5);
                }

                // ---- 4. Current charges, itemized (bills due within the period) ----
                using (var cmd = new SqlCommand(@"
                    SELECT b.BillCategory, b.BillingPeriodStart, b.BillingPeriodEnd, b.DueDate, bt.Share,
                           ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                                   JOIN Payments p ON p.PaymentId = a.PaymentId
                                   WHERE a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                     AND p.PaymentDate < @Dnext
                                     AND (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)), 0) AS Paid,
                           mi.IssueTitle, b.Remarks
                    FROM   BillTenants bt
                    JOIN   Bills b ON b.BillId = bt.BillId
                    LEFT JOIN MaintenanceIssues mi ON mi.IssueId = b.MaintenanceIssueId
                    WHERE  bt.TenantId = @tid
                      AND  b.BillCategory IN ('Rent','Water','Maintenance')
                      AND  b.DueDate >= @S AND b.DueDate < @E
                      AND  ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext
                    ORDER BY b.DueDate, b.BillCategory;", conn))
                {
                    AddParams(cmd);
                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        string cat = Str(rd["BillCategory"]);
                        DateTime start = Convert.ToDateTime(rd["BillingPeriodStart"]).Date;
                        DateTime end = rd["BillingPeriodEnd"] == DBNull.Value
                            ? start : Convert.ToDateTime(rd["BillingPeriodEnd"]).Date;
                        string remarks = Str(rd["Remarks"]);

                        string desc =
                            cat == "Water" ? $"Water – {start:MMMM yyyy}"
                          : cat == "Maintenance" ? "Maintenance – " + (Str(rd["IssueTitle"]) is { Length: > 0 } t ? t : "repair")
                          : remarks.StartsWith("Price difference", StringComparison.OrdinalIgnoreCase) ? "Rent – " + remarks
                          : end > start ? $"Rent {start:MMM d} – {end.AddDays(-1):MMM d, yyyy}"   // stored end = next period start
                          : $"Rent {start:MMM d, yyyy}";

                        lines.Add((desc, Convert.ToDateTime(rd["DueDate"]).Date,
                            Convert.ToDecimal(rd["Share"]), Convert.ToDecimal(rd["Paid"])));
                    }
                }

                // ---- 5. Payments received during the period (this tenant's part) ----
                using (var cmd = new SqlCommand(@"
                    SELECT p.PaymentDate, p.ReceiptNo, p.PaymentMethod,
                           payer.FirstName + ' ' + payer.LastName AS PaidBy, SUM(a.Amount) AS Amount
                    FROM   PaymentAllocations a
                    JOIN   Payments p     ON p.PaymentId    = a.PaymentId
                    JOIN   Tenants  payer ON payer.TenantId = p.TenantId
                    WHERE  a.TenantId = @tid
                      AND  p.PaymentDate >= @S AND p.PaymentDate < @Dnext
                      AND  (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)
                    GROUP BY p.PaymentId, p.PaymentDate, p.ReceiptNo, p.PaymentMethod,
                             payer.FirstName, payer.LastName
                    ORDER BY p.PaymentDate, p.PaymentId;", conn))
                {
                    AddParams(cmd);
                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                        receipts.Add((Convert.ToDateTime(rd["PaymentDate"]), Str(rd["ReceiptNo"]),
                            Str(rd["PaymentMethod"]), Str(rd["PaidBy"]), Convert.ToDecimal(rd["Amount"])));
                }

                // ---- 6. Notes: water not yet recorded, pending maintenance ----------
                if (!lines.Any(l => l.Desc.StartsWith("Water")) && period.End > today)
                    notes.Add("Water for this period has not been recorded yet – to follow.");

                using (var cmd = new SqlCommand(@"
                    SELECT mi.IssueTitle
                    FROM   MaintenanceIssues mi
                    JOIN   MaintenanceAffectedTenants mat ON mat.IssueId = mi.IssueId
                    WHERE  mat.TenantId = @tid AND mi.Status = 'Pending' AND mi.IsDeleted = 0;", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                        notes.Add($"Possible additional charge: Maintenance – {Str(rd["IssueTitle"])} (pending, amount to be determined).");
                }

                // ---- 7. Next bill (estimate) - only while the next bill is not issued yet ----
                //      Same price rule and split as BillGenerator; NOT added to the total.
                if (period.End > today)
                {
                    DateTime nextStart = period.End;
                    decimal price = 0m;
                    using (var cmd = new SqlCommand(@"
                        SELECT RoomPrice, PendingRoomPrice, PendingPriceFrom FROM Rooms WHERE RoomId = @rid;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                        using SqlDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            price = rd.IsDBNull(0) ? 0m : rd.GetDecimal(0);
                            if (!rd.IsDBNull(1) && !rd.IsDBNull(2) && nextStart >= rd.GetDateTime(2))
                                price = rd.GetDecimal(1);
                        }
                    }

                    var heads = new List<int>();   // longest-tenured first, as BillGenerator
                    using (var cmd = new SqlCommand(@"
                        SELECT TenantId FROM Tenancies
                        WHERE  RoomId = @rid AND Status = 'Active' AND MoveInDate <= @start
                        ORDER BY MoveInDate, TenantId;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                        cmd.Parameters.Add("@start", SqlDbType.Date).Value = nextStart;
                        using SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read()) heads.Add(rd.GetInt32(0));
                    }

                    int idx = heads.IndexOf(tenantId);
                    if (price > 0m && idx >= 0)
                    {
                        decimal share = BillGenerator.SplitEqually(price, heads.Count)[idx];
                        notes.Add($"Next bill (estimate): Rent {nextStart:MMM d} – {nextStart.AddMonths(1).AddDays(-1):MMM d, yyyy}, " +
                                  $"₱{share:N2}, due {nextStart:MMM d, yyyy}. It will be issued on " +
                                  $"{nextStart.AddDays(-7):MMM d, yyyy} and may change if tenants move in or out.");
                    }
                }

                // ---- 8. Prepared by ------------------------------------------------
                using (var cmd = new SqlCommand(
                    "SELECT ISNULL(NULLIF(Name, ''), Username) FROM Users WHERE UserId = @uid;", conn))
                {
                    cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Session.UserId;
                    string name = Str(cmd.ExecuteScalar());
                    if (name.Length > 0) preparedBy = name;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to generate the statement: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ---- Totals (same formula as the room statement) -------------------
            decimal currentCharges = rent + water + maint;
            decimal amountDue = prevBalance + currentCharges - payments + adjustments;   // negative = credit

            decimal Bal(decimal share, decimal paid) => Math.Max(0m, share - paid);
            string Status(decimal share, decimal paid, DateTime due) =>
                Bal(share, paid) <= 0m ? "Paid"
              : asOf > due ? "Overdue"                       // overdue starts the day after the due date
              : paid > 0m ? "Partially Paid" : "Unpaid";

            bool hasOverdue = prevBalance > 0m || lines.Any(l => Bal(l.Share, l.Paid) > 0m && asOf > l.Due);
            DateTime payBy = period.DueDate;

            string statementNo = $"SOA-{roomNo}-{tenantId:D5}-{period.Start:yyyyMMdd}";
            string P(decimal v) => (v < 0m ? "-₱" : "₱") + Math.Abs(v).ToString("N2");

            // ---- Print document -------------------------------------------------
            using var doc = new PrintDocument { DocumentName = statementNo };
            doc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);   // same as RoomStatementPrinter
            doc.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

            doc.PrintPage += (s, ev) =>
            {
                Graphics g = ev.Graphics!;
                Rectangle m = ev.MarginBounds;
                float x = m.Left, w = m.Width, y = m.Top;

                using var fTitle = new Font("Segoe UI", 15F, FontStyle.Bold);
                using var fHead = new Font("Segoe UI", 12F, FontStyle.Bold);
                using var fBold = new Font("Segoe UI", 9F, FontStyle.Bold);
                using var fText = new Font("Segoe UI", 9F);
                using var fTotal = new Font("Segoe UI", 11F, FontStyle.Bold);
                using var right = new StringFormat { Alignment = StringAlignment.Far };
                float lh = fText.GetHeight(g) + 5;

                void Info(string label, string value)
                {
                    g.DrawString(label, fText, Brushes.DimGray, x, y);
                    g.DrawString(value, fBold, Brushes.Black, x + w * 0.25f, y);
                    y += lh;
                }
                void Amount(string label, string value, Font f)
                {
                    g.DrawString(label, f, Brushes.Black, x, y);
                    g.DrawString(value, f, Brushes.Black, new RectangleF(x, y, w, lh + 4), right);
                    y += f.GetHeight(g) + 5;
                }
                void Section(string title)
                {
                    y += 8;
                    g.DrawString(title, fBold, Brushes.Black, x, y);
                    y += lh;
                    g.DrawLine(Pens.Black, x, y - 3, x + w, y - 3);
                }
                void Note(string text, Brush brush)
                {
                    SizeF sz = g.MeasureString(text, fText, (int)w);
                    g.DrawString(text, fText, brush, new RectangleF(x, y, w, sz.Height));
                    y += sz.Height + 2;
                }

                // Header
                g.DrawString(building, fTitle, Brushes.Black, x, y); y += fTitle.GetHeight(g) + 2;
                g.DrawString("STATEMENT OF ACCOUNT", fHead, Brushes.Black, x, y);
                y += fHead.GetHeight(g) + 10;

                Info("Statement No.", statementNo);
                Info("Statement Date", asOf.ToString("MMM d, yyyy"));
                Info("Billing Period", $"{period.Start:MMM d, yyyy} – {period.LastDay:MMM d, yyyy}");
                Info("Rent Due Date", period.DueDate.ToString("MMM d, yyyy"));
                y += 4;
                Info("Tenant", tenantName);
                Info("Room", roomNo);
                Info("Occupied Since", moveIn.ToString("MMM d, yyyy"));

                // Summary
                Section("SUMMARY");
                Amount("Previous balance", P(prevBalance), fText);
                Amount("Add: Rent", P(rent), fText);
                Amount("Add: Water", P(water), fText);
                Amount("Add: Maintenance", P(maint), fText);
                Amount("Less: Payments received", "-" + P(payments), fText);
                if (adjustments != 0m) Amount("Adjustments", P(adjustments), fText);
                g.FillRectangle(Brushes.Gainsboro, x, y, w, fTotal.GetHeight(g) + 6);
                y += 3;
                Amount(amountDue < 0m ? "ADVANCE CREDIT" : "TOTAL AMOUNT DUE",
                       amountDue < 0m ? P(-amountDue) : P(amountDue), fTotal);

                string dueText =
                    amountDue > 0m && hasOverdue ? "Includes overdue amounts. Please pay immediately."
                  : amountDue > 0m ? $"Please pay on or before {payBy:MMM d, yyyy}."
                  : amountDue < 0m ? "Paid in advance. The credit is applied automatically to your next bills."
                  : "No amount due.";
                g.DrawString(dueText, fText, Brushes.Black, x, y);
                y += lh;

                // Current charges
                Section($"CURRENT CHARGES ({period.Start:MMM d} – {period.LastDay:MMM d, yyyy})");
                if (lines.Count == 0) Note("No charges due in this period.", Brushes.DimGray);
                else
                {
                    void Row(string[] c, Font f)
                    {
                        g.DrawString(c[0], f, Brushes.Black, new RectangleF(x, y, w * 0.40f, lh));
                        g.DrawString(c[1], f, Brushes.Black, x + w * 0.40f, y);
                        g.DrawString(c[2], f, Brushes.Black, x + w * 0.53f, y);
                        g.DrawString(c[3], f, Brushes.Black, new RectangleF(x, y, w * 0.77f, lh), right);
                        g.DrawString(c[4], f, Brushes.Black, new RectangleF(x, y, w * 0.88f, lh), right);
                        g.DrawString(c[5], f, Brushes.Black, new RectangleF(x, y, w, lh), right);
                        y += lh;
                    }
                    Row(new[] { "Description", "Due Date", "Status", "Your Share", "Paid", "Balance" }, fBold);
                    foreach (var l in lines)
                        Row(new[] { l.Desc, l.Due.ToString("MMM d, yyyy"), Status(l.Share, l.Paid, l.Due),
                                    P(l.Share), P(l.Paid), P(Bal(l.Share, l.Paid)) }, fText);
                }

                // Payments received
                Section($"PAYMENTS RECEIVED ({period.Start:MMM d} – {asOf:MMM d, yyyy})");
                if (receipts.Count == 0) Note("No payments received in this period.", Brushes.DimGray);
                else
                {
                    void PRow(string[] c, Font f)
                    {
                        g.DrawString(c[0], f, Brushes.Black, x, y);
                        g.DrawString(c[1], f, Brushes.Black, x + w * 0.17f, y);
                        g.DrawString(c[2], f, Brushes.Black, x + w * 0.42f, y);
                        g.DrawString(c[3], f, Brushes.Black, x + w * 0.55f, y);
                        g.DrawString(c[4], f, Brushes.Black, new RectangleF(x, y, w, lh), right);
                        y += lh;
                    }
                    PRow(new[] { "Date", "Receipt No.", "Method", "Paid By", "Amount" }, fBold);
                    foreach (var r in receipts)
                        PRow(new[] { r.Date.ToString("MMM d, yyyy"), r.Receipt, r.Method, r.PaidBy, P(r.Amount) }, fText);
                }

                // Notes
                Section("NOTES");
                var allNotes = new List<string>(notes)
                {
                    "Payment methods: Cash or GCash. Please keep your official receipt.",
                    "A bill becomes overdue the day after its due date.",
                    "Electricity is paid directly to AKELCO and is not included."
                };
                if (amountDue < 0m)
                    allNotes.Add("Unused advance payment is not refunded upon move-out.");
                foreach (string n in allNotes) Note("• " + n, Brushes.DimGray);

                y += 20;
                g.DrawString("Prepared by: " + preparedBy, fText, Brushes.Black, x, y);

                g.DrawString($"{statementNo} • Generated {DateTime.Now:MMM d, yyyy h:mm tt} • System-generated statement",
                    fText, Brushes.Gray, x, m.Bottom - lh);

                ev.HasMorePages = false;
            };

            using var preview = new PrintPreviewDialog
            {
                Document = doc,
                Width = 900,
                Height = 1000,
                StartPosition = FormStartPosition.CenterParent
            };
            preview.ShowDialog(FindForm());
        }
#endif // OLD

        // NEW (Nov 12, 2026): Current period / All periods picker, BillKind labels,
        // Superseded charge date, multi-page printing.
        /* =================================================================
           GENERATE STATEMENT  (v3 - Nov 12, 2026)

           Button opens a small menu (same pattern as the room statement):
             - Current period : this month's Statement of Account
             - All periods    : the whole stay, one row per period, several
                                pages if needed

           Same ledger as the room statement (RoomStatementService), for ONE
           tenant across every room and stay:

               Previous balance
             + Rent + Water + Maintenance charged in the window
             - Payments received in the window
             +/- Adjustments (write-off = less owed, forfeit = credit given up)
             = Amount due   (negative = advance credit)

           Charge date = the bill's due date, except a Superseded bill, which
           counts on the day the tenant moved out of that room (the same day
           as its write-off) - the room statement's rule.
           As-of = the last day shown, or today. A payment voided after that
           still counts. Read-only. Electricity is excluded (paid to AKELCO).
           ================================================================= */

        private ContextMenuStrip? _statementMenu;

        private void btnGenerateStatement_Click(object sender, EventArgs e)
        {
            if (_selectedTenantId <= 0)
            {
                MessageBox.Show("Please select a tenant first.", "No Tenant Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("No printer is installed. Enable \"Microsoft Print to PDF\" in Windows Features.",
                    "Billing Statement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tenantId = _selectedTenantId;
            int roomId;
            DateTime moveIn;
            List<StatementPeriod> roomPeriods;

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using (var cmd = new SqlCommand(@"
                    SELECT RoomId, MoveInDate FROM Tenancies
                    WHERE  TenantId = @tid AND Status = 'Active';", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    if (!rd.Read())
                    {
                        MessageBox.Show("This tenant has already moved out. The list will be refreshed.",
                            "Billing Statement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pnlTenantDetails.Visible = false;
                        _selectedTenantId = -1;
                        LoadTenants();
                        return;
                    }
                    roomId = rd.GetInt32(0);
                    moveIn = rd.GetDateTime(1).Date;
                }

                roomPeriods = RoomStatementService.GetPeriods(roomId);   // newest first
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to load the billing periods: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Only the periods of this tenant's stay in this room (a joiner's
            // first period counts - it is the one they joined).
            List<StatementPeriod> mine = roomPeriods.Where(p => p.End > moveIn).ToList();
            if (mine.Count == 0)
            {
                MessageBox.Show("There is no rent bill yet for this tenant's stay, so there is no period to show.",
                    "Billing Statement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime today = DateTime.Today;
            StatementPeriod current =
                mine.FirstOrDefault(p => p.Start <= today && today < p.End)
                ?? mine.Where(p => p.Start <= today).OrderByDescending(p => p.Start).FirstOrDefault()
                ?? mine.OrderBy(p => p.Start).First();
            StatementPeriod all = RoomStatementService.AllPeriods(mine);

            _statementMenu ??= new ContextMenuStrip();
            _statementMenu.Items.Clear();

            ToolStripItem cur = _statementMenu.Items.Add(
                $"Current period  ({current.Start:MMM d, yyyy} - {current.LastDay:MMM d, yyyy})");
            cur.Font = new Font(cur.Font, FontStyle.Bold);
            cur.Click += (s, a) => ShowTenantStatement(tenantId, roomId, current, false, roomPeriods);

            _statementMenu.Items.Add(new ToolStripSeparator());

            ToolStripItem allItem = _statementMenu.Items.Add(
                $"All periods  ({all.Start:MMM d, yyyy} - {all.LastDay:MMM d, yyyy})");
            allItem.Click += (s, a) => ShowTenantStatement(tenantId, roomId, all, true, roomPeriods);

            _statementMenu.Show(btnGenerateStatement, new Point(0, btnGenerateStatement.Height));
        }

#if false // OLD (Nov 13): one combined balance - rent credit paid maintenance / water
        //     Kept for reference, not compiled. NEW per-category version is below (#endif).
        /// <summary>Builds the statement for one choice and opens the print preview.</summary>
        private void ShowTenantStatement(int tenantId, int roomId, StatementPeriod period,
                                         bool isAll, List<StatementPeriod> roomPeriods)
        {
            DateTime today = DateTime.Today;
            DateTime asOf = period.LastDay < today ? period.LastDay : today;
            DateTime dNext = asOf.AddDays(1);                 // "on or before asOf" = "< dNext"
            DateTime beginning = new DateTime(1900, 1, 1);    // start of the previous-balance window

            string building = "", tenantName = "", roomNo = "", preparedBy = "-";
            DateTime moveIn = today;

            decimal prevBalance;
            decimal rent = 0m, water = 0m, maint = 0m, payments = 0m, adjustments = 0m;

            var lines = new List<(string Desc, DateTime Due, decimal Share, decimal Paid, bool WrittenOff)>();
            var receipts = new List<(DateTime Date, string Receipt, string Categories, string PaidBy, decimal Amount)>();
            var periodRows = new List<(string Period, decimal Rent, decimal Water, decimal Maint,
                                       decimal Paid, decimal Adj, decimal Balance)>();
            var notes = new List<string>();

            // A tenant's charges, dated by ChargeDate (Superseded -> their move-out day).
            const string ChargeJoins = @"
                FROM   BillTenants bt
                JOIN   Bills b ON b.BillId = bt.BillId
                OUTER APPLY (SELECT TOP 1 xo.MoveOutDate FROM Tenancies xo
                             WHERE  xo.TenantId = bt.TenantId AND xo.RoomId = b.RoomId
                               AND  xo.MoveOutDate IS NOT NULL AND xo.MoveOutDate <= b.BillingPeriodStart
                             ORDER BY xo.MoveOutDate DESC) lo
                CROSS APPLY (SELECT CASE WHEN b.BillKind = N'Superseded'
                                         THEN ISNULL(lo.MoveOutDate, b.DueDate)
                                         ELSE b.DueDate END AS ChargeDate) cd";
            const string ChargeWhere = @"
                WHERE  bt.TenantId = @tid
                  AND  ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext
                  AND  cd.ChargeDate >= @S AND cd.ChargeDate < @E";

            const string WindowSql = @"
                SELECT
                  ISNULL((SELECT SUM(bt.Share) " + ChargeJoins + ChargeWhere + @" AND b.BillCategory = 'Rent'), 0),
                  ISNULL((SELECT SUM(bt.Share) " + ChargeJoins + ChargeWhere + @" AND b.BillCategory = 'Water'), 0),
                  ISNULL((SELECT SUM(bt.Share) " + ChargeJoins + ChargeWhere + @" AND b.BillCategory = 'Maintenance'), 0),
                  ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                          JOIN Payments p ON p.PaymentId = a.PaymentId
                          WHERE a.TenantId = @tid
                            AND p.PaymentDate >= @S AND p.PaymentDate < @E AND p.PaymentDate < @Dnext
                            AND (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)), 0),
                  ISNULL((SELECT SUM(CASE WHEN ta.AdjustmentType = 'WriteOff' THEN -ta.Amount ELSE ta.Amount END)
                          FROM TenantAdjustments ta
                          WHERE ta.TenantId = @tid
                            AND ta.AdjustmentDate >= @S AND ta.AdjustmentDate < @E
                            AND ta.AdjustmentDate < @Dnext), 0);";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                (decimal Rent, decimal Water, decimal Maint, decimal Paid, decimal Adj) Window(DateTime s, DateTime e)
                {
                    using var cmd = new SqlCommand(WindowSql, conn);
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@S", SqlDbType.Date).Value = s;
                    cmd.Parameters.Add("@E", SqlDbType.Date).Value = e;
                    cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dNext;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    return (rd.GetDecimal(0), rd.GetDecimal(1), rd.GetDecimal(2), rd.GetDecimal(3), rd.GetDecimal(4));
                }

                // ---- 1. Header --------------------------------------------------
                using (var cmd = new SqlCommand(@"
                    SELECT t.FirstName, t.MiddleName, t.LastName, tn.MoveInDate, r.RoomNumber, bd.BuildingName
                    FROM   Tenancies tn
                    JOIN   Tenants t    ON t.TenantId    = tn.TenantId
                    JOIN   Rooms r      ON r.RoomId      = tn.RoomId
                    JOIN   Buildings bd ON bd.BuildingId = r.BuildingId
                    WHERE  tn.TenantId = @tid AND tn.Status = 'Active';", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        string mid = Str(rd["MiddleName"]);
                        tenantName = Str(rd["LastName"]) + ", " + Str(rd["FirstName"]) +
                                     (mid.Length > 0 ? " " + mid[0] + "." : "");
                        moveIn = Convert.ToDateTime(rd["MoveInDate"]).Date;
                        roomNo = Str(rd["RoomNumber"]);
                        building = Str(rd["BuildingName"]);
                    }
                }

                // ---- 2. Previous balance: everything before the first day shown ----
                var prev = Window(beginning, period.Start);
                prevBalance = prev.Rent + prev.Water + prev.Maint - prev.Paid + prev.Adj;

                // ---- 3. The window(s) ----------------------------------------------
                if (!isAll)
                {
                    var w = Window(period.Start, period.End);
                    (rent, water, maint, payments, adjustments) = w;
                }
                else
                {
                    // Back-to-back windows, so the rows add up to the summary and
                    // the last running balance equals the amount due.
                    decimal running = prevBalance;
                    List<StatementPeriod> parts = period.Parts;
                    for (int i = 0; i < parts.Count; i++)
                    {
                        DateTime s = i == 0 ? period.Start : parts[i].Start;
                        DateTime e = i + 1 < parts.Count ? parts[i + 1].Start : period.End;
                        var w = Window(s, e);

                        running += w.Rent + w.Water + w.Maint - w.Paid + w.Adj;
                        periodRows.Add(($"{parts[i].Start:MMM d} – {parts[i].LastDay:MMM d, yyyy}",
                                        w.Rent, w.Water, w.Maint, w.Paid, w.Adj, running));

                        rent += w.Rent; water += w.Water; maint += w.Maint;
                        payments += w.Paid; adjustments += w.Adj;
                    }
                }

                // ---- 4. Current period only: itemized charges ------------------------
                if (!isAll)
                {
                    using var cmd = new SqlCommand(@"
                        SELECT b.BillCategory, b.BillKind, b.BillingPeriodStart, b.BillingPeriodEnd,
                               b.DueDate, b.Amount, bt.Share, mi.IssueTitle,
                               (SELECT COUNT(*) FROM BillTenants c WHERE c.BillId = b.BillId) AS Heads,
                               ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                                       JOIN Payments p ON p.PaymentId = a.PaymentId
                                       WHERE a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                         AND p.PaymentDate < @Dnext
                                         AND (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)), 0) AS Paid
                        " + ChargeJoins + @"
                        LEFT JOIN MaintenanceIssues mi ON mi.IssueId = b.MaintenanceIssueId
                        " + ChargeWhere + @"
                          AND  b.BillCategory IN ('Rent', 'Water', 'Maintenance')
                        ORDER BY cd.ChargeDate, b.BillCategory;", conn);
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@S", SqlDbType.Date).Value = period.Start;
                    cmd.Parameters.Add("@E", SqlDbType.Date).Value = period.End;
                    cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dNext;

                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        string cat = Str(rd["BillCategory"]);
                        string kind = Str(rd["BillKind"]);
                        DateTime start = Convert.ToDateTime(rd["BillingPeriodStart"]).Date;
                        DateTime end = Convert.ToDateTime(rd["BillingPeriodEnd"]).Date;

                        string desc = TenantAccountForm.Describe(cat, kind, start,
                            Convert.ToDecimal(rd["Amount"]), Convert.ToInt32(rd["Heads"]), Str(rd["IssueTitle"]));
                        if (cat == "Rent" && end > start)
                            desc += $"  {start:MMM d} – {end.AddDays(-1):MMM d}";

                        lines.Add((desc, Convert.ToDateTime(rd["DueDate"]).Date,
                                   Convert.ToDecimal(rd["Share"]), Convert.ToDecimal(rd["Paid"]),
                                   kind == "Superseded"));
                    }
                }

                // ---- 5. Payments received in the window (this tenant's part) ------
                using (var cmd = new SqlCommand(@"
                    SELECT p.PaymentDate, p.ReceiptNo, p.CoversRoom,
                           payer.FirstName + ' ' + payer.LastName AS PaidBy,
                           SUM(a.Amount) AS Amount,
                           (SELECT STRING_AGG(c.Category, ', ')
                            FROM (SELECT DISTINCT a2.Category FROM PaymentAllocations a2
                                  WHERE a2.PaymentId = p.PaymentId AND a2.TenantId = @tid) c) AS Categories
                    FROM   PaymentAllocations a
                    JOIN   Payments p     ON p.PaymentId    = a.PaymentId
                    JOIN   Tenants  payer ON payer.TenantId = p.TenantId
                    WHERE  a.TenantId = @tid
                      AND  p.PaymentDate >= @S AND p.PaymentDate < @E AND p.PaymentDate < @Dnext
                      AND  (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)
                    GROUP BY p.PaymentId, p.PaymentDate, p.ReceiptNo, p.CoversRoom,
                             payer.FirstName, payer.LastName
                    ORDER BY p.PaymentDate, p.PaymentId;", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@S", SqlDbType.Date).Value = period.Start;
                    cmd.Parameters.Add("@E", SqlDbType.Date).Value = period.End;
                    cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dNext;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        string payer = Str(rd["PaidBy"]);
                        receipts.Add((Convert.ToDateTime(rd["PaymentDate"]), Str(rd["ReceiptNo"]),
                            Str(rd["Categories"]),
                            Convert.ToBoolean(rd["CoversRoom"]) ? payer + " (Whole Room)" : payer,
                            Convert.ToDecimal(rd["Amount"])));
                    }
                }

                // ---- 6. Notes (current period only) --------------------------------
                if (!isAll)
                {
                    if (!lines.Any(l => l.Desc.StartsWith("Water")) && period.End > today)
                        notes.Add("Water for this period has not been recorded yet – to follow.");

                    using (var cmd = new SqlCommand(@"
                        SELECT mi.IssueTitle
                        FROM   MaintenanceIssues mi
                        JOIN   MaintenanceAffectedTenants mat ON mat.IssueId = mi.IssueId
                        WHERE  mat.TenantId = @tid AND mi.Status = 'Pending' AND mi.IsDeleted = 0;", conn))
                    {
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                        using SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                            notes.Add($"Possible additional charge: Maintenance – {Str(rd["IssueTitle"])} (pending, amount to be determined).");
                    }

                    // Next bill: the real one if already issued (7 days early), else an estimate.
                    StatementPeriod? upcoming = roomPeriods.Where(p => p.Start > today)
                                                           .OrderBy(p => p.Start).FirstOrDefault();
                    if (upcoming != null)
                    {
                        using var cmd = new SqlCommand(@"
                            SELECT SUM(bt.Share)
                            FROM   Bills b JOIN BillTenants bt ON bt.BillId = b.BillId
                            WHERE  b.RoomId = @rid AND b.BillCategory = 'Rent' AND b.BillKind = N'Regular'
                              AND  b.BillingPeriodStart = @start AND bt.TenantId = @tid;", conn);
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                        cmd.Parameters.Add("@start", SqlDbType.Date).Value = upcoming.Start;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                        object? v = cmd.ExecuteScalar();
                        if (v != null && v != DBNull.Value)
                            notes.Add($"Next bill (already issued): Rent {upcoming.Start:MMM d} – {upcoming.LastDay:MMM d, yyyy}, " +
                                      $"₱{Convert.ToDecimal(v):N2}, due {upcoming.DueDate:MMM d, yyyy}.");
                    }
                    else if (period.End > today)
                    {
                        DateTime nextStart = period.End;
                        decimal price = 0m;
                        using (var cmd = new SqlCommand(
                            "SELECT RoomPrice, PendingRoomPrice, PendingPriceFrom FROM Rooms WHERE RoomId = @rid;", conn))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                            using SqlDataReader rd = cmd.ExecuteReader();
                            if (rd.Read())
                            {
                                price = rd.IsDBNull(0) ? 0m : rd.GetDecimal(0);
                                if (!rd.IsDBNull(1) && !rd.IsDBNull(2) && nextStart >= rd.GetDateTime(2))
                                    price = rd.GetDecimal(1);
                            }
                        }

                        var heads = new List<int>();   // longest-tenured first, as BillGenerator
                        using (var cmd = new SqlCommand(@"
                            SELECT TenantId FROM Tenancies
                            WHERE  RoomId = @rid AND Status = 'Active' AND MoveInDate <= @start
                            ORDER BY MoveInDate, TenantId;", conn))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                            cmd.Parameters.Add("@start", SqlDbType.Date).Value = nextStart;
                            using SqlDataReader rd = cmd.ExecuteReader();
                            while (rd.Read()) heads.Add(rd.GetInt32(0));
                        }

                        int idx = heads.IndexOf(tenantId);
                        if (price > 0m && idx >= 0)
                        {
                            decimal share = BillGenerator.SplitEqually(price, heads.Count)[idx];
                            notes.Add($"Next bill (estimate): Rent {nextStart:MMM d} – {nextStart.AddMonths(1).AddDays(-1):MMM d, yyyy}, " +
                                      $"₱{share:N2}, due {nextStart:MMM d, yyyy}. It will be issued on " +
                                      $"{nextStart.AddDays(-7):MMM d, yyyy} and may change if tenants move in or out.");
                        }
                    }
                }

                // ---- 7. Prepared by ------------------------------------------------
                using (var cmd = new SqlCommand(
                    "SELECT ISNULL(NULLIF(Name, ''), Username) FROM Users WHERE UserId = @uid;", conn))
                {
                    cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Session.UserId;
                    string name = Str(cmd.ExecuteScalar());
                    if (name.Length > 0) preparedBy = name;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to generate the statement: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ---- Totals ----------------------------------------------------------
            decimal charges = rent + water + maint;
            decimal amountDue = prevBalance + charges - payments + adjustments;   // negative = credit

            decimal Bal(decimal share, decimal paid) => Math.Max(0m, share - paid);
            string Status(decimal share, decimal paid, DateTime due, bool writtenOff) =>
                Bal(share, paid) <= 0m ? "Paid"
              : writtenOff ? "Written off"
              : asOf > due ? "Overdue"
              : paid > 0m ? "Partially Paid" : "Unpaid";

            bool hasOverdue = prevBalance > 0m ||
                              lines.Any(l => !l.WrittenOff && Bal(l.Share, l.Paid) > 0m && asOf > l.Due);

            string statementNo = isAll
                ? $"SOA-{roomNo}-{tenantId:D5}-ALL-{asOf:yyyyMMdd}"
                : $"SOA-{roomNo}-{tenantId:D5}-{period.Start:yyyyMMdd}";
            string P(decimal v) => (v < 0m ? "-₱" : "₱") + Math.Abs(v).ToString("N2");

            // ---- Layout as rows (kind + cells), printed with page breaks ----------
            var rows = new List<(string Kind, string[] Cells)>();
            void Add(string kind, params string[] cells) => rows.Add((kind, cells));

            Add("title", building);
            Add("heading", isAll ? "STATEMENT OF ACCOUNT – ALL PERIODS" : "STATEMENT OF ACCOUNT");
            Add("space");
            Add("info", "Statement No.", statementNo);
            Add("info", "Statement Date", asOf.ToString("MMM d, yyyy"));
            Add("info", isAll ? "Covering" : "Billing Period", $"{period.Start:MMM d, yyyy} – {period.LastDay:MMM d, yyyy}");
            Add("info", "Rent Due Date", period.DueDate.ToString("MMM d, yyyy") + (isAll ? " (current period)" : ""));
            Add("info", "Tenant", tenantName);
            Add("info", "Room", roomNo);
            Add("info", "Occupied Since", moveIn.ToString("MMM d, yyyy"));

            Add("section", isAll ? "ACCOUNT SUMMARY (ALL PERIODS)" : "SUMMARY");
            Add("amount", isAll ? "Balance before " + period.Start.ToString("MMM d, yyyy") : "Previous balance", P(prevBalance));
            Add("amount", "Add: Rent", P(rent));
            Add("amount", "Add: Water", P(water));
            Add("amount", "Add: Maintenance", P(maint));
            Add("amount", "Less: Payments received", "-" + P(payments));
            if (adjustments != 0m) Add("amount", "Adjustments (write-off / forfeit)", P(adjustments));
            Add("total", amountDue < 0m ? "ADVANCE CREDIT" : "TOTAL AMOUNT DUE", P(Math.Abs(amountDue)));
            Add("text",
                amountDue > 0m && hasOverdue ? "Includes overdue amounts. Please pay immediately."
              : amountDue > 0m ? $"Please pay on or before {period.DueDate:MMM d, yyyy}."
              : amountDue < 0m ? "Paid in advance. The credit is applied automatically to your next bills."
              : "No amount due.");

            if (isAll)
            {
                Add("section", "PERIOD BREAKDOWN");
                Add("bh", "Period", "Rent", "Water", "Maint.", "Paid", "Adj.", "Balance");
                foreach (var r in periodRows)
                    Add("br", r.Period, P(r.Rent), P(r.Water), P(r.Maint), P(r.Paid), P(r.Adj), P(r.Balance));
            }
            else
            {
                Add("section", $"CURRENT CHARGES ({period.Start:MMM d} – {period.LastDay:MMM d, yyyy})");
                if (lines.Count == 0) Add("muted", "No charges due in this period.");
                else
                {
                    Add("ch", "Description", "Due Date", "Status", "Your Share", "Paid", "Balance");
                    foreach (var l in lines)
                        Add("cr", l.Desc, l.Due.ToString("MMM d, yyyy"), Status(l.Share, l.Paid, l.Due, l.WrittenOff),
                            P(l.Share), P(l.Paid), P(l.WrittenOff ? 0m : Bal(l.Share, l.Paid)));
                }
            }

            Add("section", isAll ? "PAYMENTS RECEIVED" : $"PAYMENTS RECEIVED ({period.Start:MMM d} – {asOf:MMM d, yyyy})");
            if (receipts.Count == 0) Add("muted", isAll ? "No payments received." : "No payments received in this period.");
            else
            {
                Add("ph", "Date", "Receipt No.", "Category", "Paid By", "Amount");
                foreach (var r in receipts)
                    Add("pr", r.Date.ToString("MMM d, yyyy"), r.Receipt, r.Categories, r.PaidBy, P(r.Amount));
            }

            Add("section", "NOTES");
            foreach (string n in notes) Add("note", "• " + n);
            Add("note", "• Payment methods: Cash or GCash. Please keep your official receipt.");
            Add("note", "• A bill becomes overdue the day after its due date.");
            Add("note", "• Electricity is paid directly to AKELCO and is not included.");
            if (amountDue < 0m) Add("note", "• Unused advance payment is not refunded upon move-out.");
            Add("space");
            Add("sign", "Prepared by: " + preparedBy);

            // Column layouts (start, end as a fraction of the width; true = right-aligned)
            var chargeCols = new (float S, float E, bool R)[]
                { (0f, .40f, false), (.40f, .53f, false), (.53f, .66f, false), (.66f, .78f, true), (.78f, .89f, true), (.89f, 1f, true) };
            var payCols = new (float S, float E, bool R)[]
                { (0f, .15f, false), (.15f, .37f, false), (.37f, .55f, false), (.55f, .84f, false), (.84f, 1f, true) };
            var breakCols = new (float S, float E, bool R)[]
                { (0f, .25f, false), (.25f, .37f, true), (.37f, .48f, true), (.48f, .59f, true), (.59f, .71f, true), (.71f, .83f, true), (.83f, 1f, true) };

            int next = 0, page = 0;

            using var doc = new PrintDocument { DocumentName = statementNo };
            doc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);   // same as RoomStatementPrinter
            doc.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
            doc.BeginPrint += (s, ev) => { next = 0; page = 0; };   // restart for print after preview

            doc.PrintPage += (s, ev) =>
            {
                Graphics g = ev.Graphics!;
                Rectangle m = ev.MarginBounds;
                float x = m.Left, w = m.Width, y = m.Top;

                using var fTitle = new Font("Segoe UI", 15F, FontStyle.Bold);
                using var fHead = new Font("Segoe UI", 12F, FontStyle.Bold);
                using var fBold = new Font("Segoe UI", 9F, FontStyle.Bold);
                using var fText = new Font("Segoe UI", 9F);
                using var fTotal = new Font("Segoe UI", 11F, FontStyle.Bold);
                using var fSmall = new Font("Segoe UI", 7.5F);
                using var left = new StringFormat(StringFormatFlags.NoWrap) { Trimming = StringTrimming.EllipsisCharacter };
                using var right = new StringFormat(StringFormatFlags.NoWrap)
                { Alignment = StringAlignment.Far, Trimming = StringTrimming.EllipsisCharacter };

                float lh = fText.GetHeight(g) + 5;
                float bottom = m.Bottom - fSmall.GetHeight(g) - 8;
                page++;

                float Height((string Kind, string[] Cells) r) => r.Kind switch
                {
                    "title" => fTitle.GetHeight(g) + 2,
                    "heading" => fHead.GetHeight(g) + 6,
                    "section" => lh + 10,
                    "total" => fTotal.GetHeight(g) + 10,
                    "text" or "note" or "muted" => g.MeasureString(r.Cells[0], fText, (int)w).Height + 3,
                    "space" => 12,
                    "sign" => lh + 20,
                    _ => lh
                };

                void Row(string[] cells, (float S, float E, bool R)[] cols, Font f)
                {
                    for (int i = 0; i < cols.Length && i < cells.Length; i++)
                        g.DrawString(cells[i], f, Brushes.Black,
                            new RectangleF(x + w * cols[i].S + 2, y, w * (cols[i].E - cols[i].S) - 4, lh),
                            cols[i].R ? right : left);
                }

                while (next < rows.Count)
                {
                    var r = rows[next];
                    float h = Height(r);
                    // keep a section title together with at least one line under it
                    float need = r.Kind == "section" ? h + 2 * lh : h;
                    if (y + need > bottom && y > m.Top) break;   // continue on the next page

                    switch (r.Kind)
                    {
                        case "title": g.DrawString(r.Cells[0], fTitle, Brushes.Black, x, y); break;
                        case "heading": g.DrawString(r.Cells[0], fHead, Brushes.Black, x, y); break;
                        case "info":
                            g.DrawString(r.Cells[0], fText, Brushes.DimGray, x, y);
                            g.DrawString(r.Cells[1], fBold, Brushes.Black, new RectangleF(x + w * .25f, y, w * .75f, lh), left);
                            break;
                        case "section":
                            g.DrawString(r.Cells[0], fBold, Brushes.Black, x, y + 8);
                            g.DrawLine(Pens.Black, x, y + lh + 6, x + w, y + lh + 6);
                            break;
                        case "amount":
                            g.DrawString(r.Cells[0], fText, Brushes.Black, x, y);
                            g.DrawString(r.Cells[1], fText, Brushes.Black, new RectangleF(x, y, w, lh), right);
                            break;
                        case "total":
                            g.FillRectangle(Brushes.Gainsboro, x, y + 2, w, h - 4);
                            g.DrawString(r.Cells[0], fTotal, Brushes.Black, x + 4, y + 4);
                            g.DrawString(r.Cells[1], fTotal, Brushes.Black, new RectangleF(x, y + 4, w - 4, h), right);
                            break;
                        case "text":
                        case "note":
                        case "muted":
                            g.DrawString(r.Cells[0], fText, r.Kind == "text" ? Brushes.Black : Brushes.DimGray,
                                new RectangleF(x, y, w, h));
                            break;
                        case "ch": Row(r.Cells, chargeCols, fBold); g.DrawLine(Pens.Gray, x, y + lh - 2, x + w, y + lh - 2); break;
                        case "cr": Row(r.Cells, chargeCols, fText); break;
                        case "ph": Row(r.Cells, payCols, fBold); g.DrawLine(Pens.Gray, x, y + lh - 2, x + w, y + lh - 2); break;
                        case "pr": Row(r.Cells, payCols, fText); break;
                        case "bh": Row(r.Cells, breakCols, fBold); g.DrawLine(Pens.Gray, x, y + lh - 2, x + w, y + lh - 2); break;
                        case "br": Row(r.Cells, breakCols, fText); break;
                        case "sign": g.DrawString(r.Cells[0], fText, Brushes.Black, x, y + 16); break;
                    }

                    y += h;
                    next++;
                }

                // Footer on every page
                var footer = new RectangleF(x, m.Bottom - fSmall.GetHeight(g), w, fSmall.GetHeight(g) + 2);
                g.DrawString($"{statementNo} • Generated {DateTime.Now:MMM d, yyyy h:mm tt} • System-generated statement",
                    fSmall, Brushes.Gray, footer, left);
                g.DrawString($"Page {page}", fSmall, Brushes.Gray, footer, right);

                ev.HasMorePages = next < rows.Count;
            };

            using var preview = new PrintPreviewDialog
            {
                Document = doc,
                Width = 900,
                Height = 1000,
                StartPosition = FormStartPosition.CenterParent
            };
            preview.ShowDialog(FindForm());
        }
#endif // OLD

        /* =================================================================
           NEW (Nov 13, 2026): ShowTenantStatement - PER-CATEGORY balances

           OLD version kept everything in ONE balance, so a rent advance
           silently paid other categories (Connie: ₱2,000 rent credit -
           ₱10 maintenance = ₱1,990 credit, nothing due). That broke the
           settled rule: an advance credit belongs to its own category
           (rent credit pays rent only), exactly as BillingHelper and the
           Billing Summary treat it.

           Now each category (Rent, Water, Maintenance) has its own ledger:
               balance[c] = previous[c] + charges[c] - payments[c] +/- adjustments[c]
           TOTAL AMOUNT DUE = sum of the positive balances (what is owed)
           ADVANCE CREDIT   = shown per category, never deducted elsewhere

           Unchanged: charge date (Superseded = move-out day), as-of rule,
           void rule, Current / All periods, notes, paging, footer.
           ================================================================= */
        private void ShowTenantStatement(int tenantId, int roomId, StatementPeriod period,
                                         bool isAll, List<StatementPeriod> roomPeriods)
        {
            DateTime today = DateTime.Today;
            DateTime asOf = period.LastDay < today ? period.LastDay : today;
            DateTime dNext = asOf.AddDays(1);                 // "on or before asOf" = "< dNext"
            DateTime beginning = new DateTime(1900, 1, 1);    // start of the previous-balance window

            string[] cats = { "Rent", "Water", "Maintenance" };   // index 0, 1, 2 everywhere below

            string building = "", tenantName = "", roomNo = "", preparedBy = "-";
            DateTime moveIn = today;

            // Per category: previous balance, charges, payments, adjustments
            decimal[] prev = new decimal[3], chg = new decimal[3], paid = new decimal[3], adj = new decimal[3];

            var lines = new List<(string Desc, DateTime Due, decimal Share, decimal Paid, bool WrittenOff)>();
            var receipts = new List<(DateTime Date, string Receipt, string Categories, string PaidBy, decimal Amount)>();
            var periodRows = new List<(string Period, decimal Rent, decimal Water, decimal Maint,
                                       decimal Paid, decimal Adj, decimal Due, decimal Credit)>();
            var notes = new List<string>();
            DateTime? oldestUnpaidDue = null;   // oldest due date among unpaid bills (pay-by line)

            // A tenant's charges, dated by ChargeDate (Superseded -> their move-out day).
            const string ChargeJoins = @"
                FROM   BillTenants bt
                JOIN   Bills b ON b.BillId = bt.BillId
                OUTER APPLY (SELECT TOP 1 xo.MoveOutDate FROM Tenancies xo
                             WHERE  xo.TenantId = bt.TenantId AND xo.RoomId = b.RoomId
                               AND  xo.MoveOutDate IS NOT NULL AND xo.MoveOutDate <= b.BillingPeriodStart
                             ORDER BY xo.MoveOutDate DESC) lo
                CROSS APPLY (SELECT CASE WHEN b.BillKind = N'Superseded'
                                         THEN ISNULL(lo.MoveOutDate, b.DueDate)
                                         ELSE b.DueDate END AS ChargeDate) cd";
            const string ChargeWhere = @"
                WHERE  bt.TenantId = @tid
                  AND  ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext
                  AND  cd.ChargeDate >= @S AND cd.ChargeDate < @E";

            // One query per window, one row per (kind, category):
            //   C = charges, P = payments (by allocation category), A = adjustments
            const string WindowSql = @"
                SELECT 'C' AS Kind, b.BillCategory AS Cat, SUM(bt.Share) AS Amt
                " + ChargeJoins + ChargeWhere + @"
                  AND  b.BillCategory IN ('Rent', 'Water', 'Maintenance')
                GROUP BY b.BillCategory
                UNION ALL
                SELECT 'P', a.Category, SUM(a.Amount)
                FROM   PaymentAllocations a
                JOIN   Payments p ON p.PaymentId = a.PaymentId
                WHERE  a.TenantId = @tid
                  AND  a.Category IN ('Rent', 'Water', 'Maintenance')
                  AND  p.PaymentDate >= @S AND p.PaymentDate < @E AND p.PaymentDate < @Dnext
                  AND  (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)
                GROUP BY a.Category
                UNION ALL
                SELECT 'A', ta.BillCategory,
                       SUM(CASE WHEN ta.AdjustmentType = 'WriteOff' THEN -ta.Amount ELSE ta.Amount END)
                FROM   TenantAdjustments ta
                WHERE  ta.TenantId = @tid
                  AND  ta.BillCategory IN ('Rent', 'Water', 'Maintenance')
                  AND  ta.AdjustmentDate >= @S AND ta.AdjustmentDate < @E
                  AND  ta.AdjustmentDate < @Dnext
                GROUP BY ta.BillCategory;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                (decimal[] Chg, decimal[] Paid, decimal[] Adj) Window(DateTime s, DateTime e)
                {
                    var w = (Chg: new decimal[3], Paid: new decimal[3], Adj: new decimal[3]);
                    using var cmd = new SqlCommand(WindowSql, conn);
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@S", SqlDbType.Date).Value = s;
                    cmd.Parameters.Add("@E", SqlDbType.Date).Value = e;
                    cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dNext;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        int i = Array.IndexOf(cats, Str(rd["Cat"]));
                        if (i < 0 || rd.IsDBNull(2)) continue;
                        decimal amt = rd.GetDecimal(2);
                        switch (Str(rd["Kind"]))
                        {
                            case "C": w.Chg[i] += amt; break;
                            case "P": w.Paid[i] += amt; break;
                            default: w.Adj[i] += amt; break;
                        }
                    }
                    return w;
                }

                // ---- 1. Header --------------------------------------------------
                using (var cmd = new SqlCommand(@"
                    SELECT t.FirstName, t.MiddleName, t.LastName, tn.MoveInDate, r.RoomNumber, bd.BuildingName
                    FROM   Tenancies tn
                    JOIN   Tenants t    ON t.TenantId    = tn.TenantId
                    JOIN   Rooms r      ON r.RoomId      = tn.RoomId
                    JOIN   Buildings bd ON bd.BuildingId = r.BuildingId
                    WHERE  tn.TenantId = @tid AND tn.Status = 'Active';", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        string mid = Str(rd["MiddleName"]);
                        tenantName = Str(rd["LastName"]) + ", " + Str(rd["FirstName"]) +
                                     (mid.Length > 0 ? " " + mid[0] + "." : "");
                        moveIn = Convert.ToDateTime(rd["MoveInDate"]).Date;
                        roomNo = Str(rd["RoomNumber"]);
                        building = Str(rd["BuildingName"]);
                    }
                }

                // ---- 2. Previous balance per category (everything before the first day shown)
                var p0 = Window(beginning, period.Start);
                for (int i = 0; i < 3; i++)
                    prev[i] = p0.Chg[i] - p0.Paid[i] + p0.Adj[i];

                // ---- 3. The window(s) ----------------------------------------------
                if (!isAll)
                {
                    var w = Window(period.Start, period.End);
                    chg = w.Chg; paid = w.Paid; adj = w.Adj;
                }
                else
                {
                    // Back-to-back windows with a running balance PER CATEGORY.
                    // Due / Credit of each row come from those separate balances,
                    // so the last row equals the summary totals.
                    decimal[] run = (decimal[])prev.Clone();
                    List<StatementPeriod> parts = period.Parts;
                    for (int k = 0; k < parts.Count; k++)
                    {
                        DateTime s = k == 0 ? period.Start : parts[k].Start;
                        DateTime e = k + 1 < parts.Count ? parts[k + 1].Start : period.End;
                        var w = Window(s, e);

                        for (int i = 0; i < 3; i++)
                        {
                            run[i] += w.Chg[i] - w.Paid[i] + w.Adj[i];
                            chg[i] += w.Chg[i]; paid[i] += w.Paid[i]; adj[i] += w.Adj[i];
                        }

                        periodRows.Add(($"{parts[k].Start:MMM d} – {parts[k].LastDay:MMM d, yyyy}",
                                        w.Chg[0], w.Chg[1], w.Chg[2], w.Paid.Sum(), w.Adj.Sum(),
                                        run.Sum(v => Math.Max(0m, v)),      // owed
                                        run.Sum(v => Math.Max(0m, -v))));   // credit
                    }
                }

                // ---- 4. Current period only: itemized charges ------------------------
                if (!isAll)
                {
                    using var cmd = new SqlCommand(@"
                        SELECT b.BillCategory, b.BillKind, b.BillingPeriodStart, b.BillingPeriodEnd,
                               b.DueDate, b.Amount, bt.Share, mi.IssueTitle,
                               (SELECT COUNT(*) FROM BillTenants c WHERE c.BillId = b.BillId) AS Heads,
                               ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                                       JOIN Payments p ON p.PaymentId = a.PaymentId
                                       WHERE a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                         AND p.PaymentDate < @Dnext
                                         AND (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)), 0) AS Paid
                        " + ChargeJoins + @"
                        LEFT JOIN MaintenanceIssues mi ON mi.IssueId = b.MaintenanceIssueId
                        " + ChargeWhere + @"
                          AND  b.BillCategory IN ('Rent', 'Water', 'Maintenance')
                        ORDER BY cd.ChargeDate, b.BillCategory;", conn);
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@S", SqlDbType.Date).Value = period.Start;
                    cmd.Parameters.Add("@E", SqlDbType.Date).Value = period.End;
                    cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dNext;

                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        string cat = Str(rd["BillCategory"]);
                        string kind = Str(rd["BillKind"]);
                        DateTime start = Convert.ToDateTime(rd["BillingPeriodStart"]).Date;
                        DateTime end = Convert.ToDateTime(rd["BillingPeriodEnd"]).Date;

                        string desc = TenantAccountForm.Describe(cat, kind, start,
                            Convert.ToDecimal(rd["Amount"]), Convert.ToInt32(rd["Heads"]), Str(rd["IssueTitle"]));
                        if (cat == "Rent" && end > start)
                            desc += $"  {start:MMM d} – {end.AddDays(-1):MMM d}";

                        lines.Add((desc, Convert.ToDateTime(rd["DueDate"]).Date,
                                   Convert.ToDecimal(rd["Share"]), Convert.ToDecimal(rd["Paid"]),
                                   kind == "Superseded"));
                    }
                }

                // ---- 5. Payments received in the window (this tenant's part) ------
                using (var cmd = new SqlCommand(@"
                    SELECT p.PaymentDate, p.ReceiptNo, p.CoversRoom,
                           payer.FirstName + ' ' + payer.LastName AS PaidBy,
                           SUM(a.Amount) AS Amount,
                           (SELECT STRING_AGG(c.Category, ', ')
                            FROM (SELECT DISTINCT a2.Category FROM PaymentAllocations a2
                                  WHERE a2.PaymentId = p.PaymentId AND a2.TenantId = @tid
                                    AND a2.Category IN ('Rent', 'Water', 'Maintenance')) c) AS Categories
                    FROM   PaymentAllocations a
                    JOIN   Payments p     ON p.PaymentId    = a.PaymentId
                    JOIN   Tenants  payer ON payer.TenantId = p.TenantId
                    WHERE  a.TenantId = @tid
                      AND  a.Category IN ('Rent', 'Water', 'Maintenance')
                      AND  p.PaymentDate >= @S AND p.PaymentDate < @E AND p.PaymentDate < @Dnext
                      AND  (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)
                    GROUP BY p.PaymentId, p.PaymentDate, p.ReceiptNo, p.CoversRoom,
                             payer.FirstName, payer.LastName
                    ORDER BY p.PaymentDate, p.PaymentId;", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@S", SqlDbType.Date).Value = period.Start;
                    cmd.Parameters.Add("@E", SqlDbType.Date).Value = period.End;
                    cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dNext;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        string payer = Str(rd["PaidBy"]);
                        receipts.Add((Convert.ToDateTime(rd["PaymentDate"]), Str(rd["ReceiptNo"]),
                            Str(rd["Categories"]),
                            Convert.ToBoolean(rd["CoversRoom"]) ? payer + " (Whole Room)" : payer,
                            Convert.ToDecimal(rd["Amount"])));
                    }
                }

                // ---- 6. Notes (current period only) --------------------------------
                if (!isAll)
                {
                    if (!lines.Any(l => l.Desc.StartsWith("Water")) && period.End > today)
                        notes.Add("Water for this period has not been recorded yet – to follow.");

                    using (var cmd = new SqlCommand(@"
                        SELECT mi.IssueTitle
                        FROM   MaintenanceIssues mi
                        JOIN   MaintenanceAffectedTenants mat ON mat.IssueId = mi.IssueId
                        WHERE  mat.TenantId = @tid AND mi.Status = 'Pending' AND mi.IsDeleted = 0;", conn))
                    {
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                        using SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                            notes.Add($"Possible additional charge: Maintenance – {Str(rd["IssueTitle"])} (pending, amount to be determined).");
                    }

                    // Next bill: the real one if already issued (7 days early), else an estimate.
                    StatementPeriod? upcoming = roomPeriods.Where(p => p.Start > today)
                                                           .OrderBy(p => p.Start).FirstOrDefault();
                    if (upcoming != null)
                    {
                        using var cmd = new SqlCommand(@"
                            SELECT SUM(bt.Share)
                            FROM   Bills b JOIN BillTenants bt ON bt.BillId = b.BillId
                            WHERE  b.RoomId = @rid AND b.BillCategory = 'Rent' AND b.BillKind = N'Regular'
                              AND  b.BillingPeriodStart = @start AND bt.TenantId = @tid;", conn);
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                        cmd.Parameters.Add("@start", SqlDbType.Date).Value = upcoming.Start;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                        object? v = cmd.ExecuteScalar();
                        if (v != null && v != DBNull.Value)
                            notes.Add($"Next bill (already issued): Rent {upcoming.Start:MMM d} – {upcoming.LastDay:MMM d, yyyy}, " +
                                      $"₱{Convert.ToDecimal(v):N2}, due {upcoming.DueDate:MMM d, yyyy}.");
                    }
                    else if (period.End > today)
                    {
                        DateTime nextStart = period.End;
                        decimal price = 0m;
                        using (var cmd = new SqlCommand(
                            "SELECT RoomPrice, PendingRoomPrice, PendingPriceFrom FROM Rooms WHERE RoomId = @rid;", conn))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                            using SqlDataReader rd = cmd.ExecuteReader();
                            if (rd.Read())
                            {
                                price = rd.IsDBNull(0) ? 0m : rd.GetDecimal(0);
                                if (!rd.IsDBNull(1) && !rd.IsDBNull(2) && nextStart >= rd.GetDateTime(2))
                                    price = rd.GetDecimal(1);
                            }
                        }

                        var heads = new List<int>();   // longest-tenured first, as BillGenerator
                        using (var cmd = new SqlCommand(@"
                            SELECT TenantId FROM Tenancies
                            WHERE  RoomId = @rid AND Status = 'Active' AND MoveInDate <= @start
                            ORDER BY MoveInDate, TenantId;", conn))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                            cmd.Parameters.Add("@start", SqlDbType.Date).Value = nextStart;
                            using SqlDataReader rd = cmd.ExecuteReader();
                            while (rd.Read()) heads.Add(rd.GetInt32(0));
                        }

                        int idx = heads.IndexOf(tenantId);
                        if (price > 0m && idx >= 0)
                        {
                            decimal share = BillGenerator.SplitEqually(price, heads.Count)[idx];
                            notes.Add($"Next bill (estimate): Rent {nextStart:MMM d} – {nextStart.AddMonths(1).AddDays(-1):MMM d, yyyy}, " +
                                      $"₱{share:N2}, due {nextStart:MMM d, yyyy}. It will be issued on " +
                                      $"{nextStart.AddDays(-7):MMM d, yyyy} and may change if tenants move in or out.");
                        }
                    }
                }

                // ---- 7. Oldest unpaid due date (decides the pay-by / overdue line) ----
                //      Current stay only, written-off bills excluded (same rule as BillingHelper);
                //      paid = as of the statement date, voided after it still counts.
                using (var cmd = new SqlCommand(@"
                    SELECT MIN(b.DueDate)
                    FROM   BillTenants bt
                    JOIN   Bills b      ON b.BillId    = bt.BillId
                    JOIN   Tenancies tn ON tn.TenantId = bt.TenantId AND tn.Status = 'Active'
                    WHERE  bt.TenantId = @tid
                      AND  b.BillCategory IN ('Rent', 'Water', 'Maintenance')
                      AND  b.BillKind <> N'Superseded'
                      AND  b.BillingPeriodStart >= tn.MoveInDate
                      AND  ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext
                      AND  bt.Share > ISNULL((SELECT SUM(a.Amount)
                                              FROM   PaymentAllocations a
                                              JOIN   Payments p ON p.PaymentId = a.PaymentId
                                              WHERE  a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                                AND  p.PaymentDate < @Dnext
                                                AND  (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)), 0);", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dNext;
                    object? v = cmd.ExecuteScalar();
                    if (v != null && v != DBNull.Value) oldestUnpaidDue = Convert.ToDateTime(v).Date;
                }

                // ---- 8. Prepared by ------------------------------------------------
                using (var cmd = new SqlCommand(
                    "SELECT ISNULL(NULLIF(Name, ''), Username) FROM Users WHERE UserId = @uid;", conn))
                {
                    cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Session.UserId;
                    string name = Str(cmd.ExecuteScalar());
                    if (name.Length > 0) preparedBy = name;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to generate the statement: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ---- Totals, PER CATEGORY -----------------------------------------
            decimal[] bal = new decimal[3];
            for (int i = 0; i < 3; i++)
                bal[i] = prev[i] + chg[i] - paid[i] + adj[i];     // negative = credit of that category

            decimal amountDue = bal.Sum(v => Math.Max(0m, v));    // only what is owed
            decimal totalCredit = bal.Sum(v => Math.Max(0m, -v)); // shown, never deducted

            decimal Bal(decimal share, decimal paidAmt) => Math.Max(0m, share - paidAmt);
            string Status(decimal share, decimal paidAmt, DateTime due, bool writtenOff) =>
                Bal(share, paidAmt) <= 0m ? "Paid"
              : writtenOff ? "Written off"
              : asOf > due ? "Overdue"
              : paidAmt > 0m ? "Partially Paid" : "Unpaid";

            bool hasOverdue = oldestUnpaidDue.HasValue && asOf > oldestUnpaidDue.Value;
            DateTime payBy = oldestUnpaidDue ?? period.DueDate;

            string statementNo = isAll
                ? $"SOA-{roomNo}-{tenantId:D5}-ALL-{asOf:yyyyMMdd}"
                : $"SOA-{roomNo}-{tenantId:D5}-{period.Start:yyyyMMdd}";
            string P(decimal v) => (v < 0m ? "-₱" : "₱") + Math.Abs(v).ToString("N2");
            string Cr(decimal v) => v < 0m ? "(" + P(-v) + ")" : P(v);

            // ---- Layout as rows (kind + cells), printed with page breaks ----------
            var rows = new List<(string Kind, string[] Cells)>();
            void Add(string kind, params string[] cells) => rows.Add((kind, cells));

            Add("title", building);
            Add("heading", isAll ? "STATEMENT OF ACCOUNT – ALL PERIODS" : "STATEMENT OF ACCOUNT");
            Add("space");
            Add("info", "Statement No.", statementNo);
            Add("info", "Statement Date", asOf.ToString("MMM d, yyyy"));
            Add("info", isAll ? "Covering" : "Billing Period", $"{period.Start:MMM d, yyyy} – {period.LastDay:MMM d, yyyy}");
            Add("info", "Rent Due Date", period.DueDate.ToString("MMM d, yyyy") + (isAll ? " (current period)" : ""));
            Add("info", "Tenant", tenantName);
            Add("info", "Room", roomNo);
            Add("info", "Occupied Since", moveIn.ToString("MMM d, yyyy"));

            // Summary: one column per category, so no category pays another
            Add("section", isAll ? "ACCOUNT SUMMARY (ALL PERIODS)" : "SUMMARY");
            Add("sh", "", "Rent", "Water", "Maintenance");
            Add("sr", isAll ? "Balance before " + period.Start.ToString("MMM d, yyyy") : "Previous balance",
                P(prev[0]), P(prev[1]), P(prev[2]));
            Add("sr", "Charges", P(chg[0]), P(chg[1]), P(chg[2]));
            Add("sr", "Payments received", P(paid[0]), P(paid[1]), P(paid[2]));
            if (adj.Any(v => v != 0m))
                Add("sr", "Adjustments (write-off / forfeit)", P(adj[0]), P(adj[1]), P(adj[2]));
            Add("sb", "Balance", Cr(bal[0]), Cr(bal[1]), Cr(bal[2]));

            Add("total", "TOTAL AMOUNT DUE", P(amountDue));
            for (int i = 0; i < 3; i++)
                if (bal[i] < 0m) Add("credit", $"Advance credit – {cats[i]}", P(-bal[i]));

            Add("text",
                amountDue > 0m && hasOverdue ? "Includes overdue amounts. Please pay immediately."
              : amountDue > 0m ? $"Please pay on or before {payBy:MMM d, yyyy}."
              : "No amount due.");
            if (totalCredit > 0m)
                Add("text", "An advance credit is applied automatically to your next bills of the SAME category " +
                            "(rent credit pays rent only); it does not reduce other charges.");

            if (isAll)
            {
                Add("section", "PERIOD BREAKDOWN");
                Add("bh", "Period", "Rent", "Water", "Maint.", "Paid", "Adj.", "Due", "Credit");
                foreach (var r in periodRows)
                    Add("br", r.Period, P(r.Rent), P(r.Water), P(r.Maint), P(r.Paid), P(r.Adj), P(r.Due), P(r.Credit));
            }
            else
            {
                Add("section", $"CURRENT CHARGES ({period.Start:MMM d} – {period.LastDay:MMM d, yyyy})");
                if (lines.Count == 0) Add("muted", "No charges due in this period.");
                else
                {
                    Add("ch", "Description", "Due Date", "Status", "Your Share", "Paid", "Balance");
                    foreach (var l in lines)
                        Add("cr", l.Desc, l.Due.ToString("MMM d, yyyy"), Status(l.Share, l.Paid, l.Due, l.WrittenOff),
                            P(l.Share), P(l.Paid), P(l.WrittenOff ? 0m : Bal(l.Share, l.Paid)));
                }
            }

            Add("section", isAll ? "PAYMENTS RECEIVED" : $"PAYMENTS RECEIVED ({period.Start:MMM d} – {asOf:MMM d, yyyy})");
            if (receipts.Count == 0) Add("muted", isAll ? "No payments received." : "No payments received in this period.");
            else
            {
                Add("ph", "Date", "Receipt No.", "Category", "Paid By", "Amount");
                foreach (var r in receipts)
                    Add("pr", r.Date.ToString("MMM d, yyyy"), r.Receipt, r.Categories, r.PaidBy, P(r.Amount));
            }

            Add("section", "NOTES");
            foreach (string n in notes) Add("note", "• " + n);
            Add("note", "• Payment methods: Cash or GCash. Please keep your official receipt.");
            Add("note", "• A bill becomes overdue the day after its due date.");
            Add("note", "• Electricity is paid directly to AKELCO and is not included.");
            Add("note", "• Amounts in ( ) are advance credits.");   // NEW (Nov 14)
            if (totalCredit > 0m) Add("note", "• Unused advance payment is not refunded upon move-out.");
            Add("space");
            Add("sign", "Prepared by: " + preparedBy);

            // Column layouts (start, end as a fraction of the width; true = right-aligned)
            var summaryCols = new (float S, float E, bool R)[]
                { (0f, .46f, false), (.46f, .64f, true), (.64f, .82f, true), (.82f, 1f, true) };
            var chargeCols = new (float S, float E, bool R)[]
                { (0f, .40f, false), (.40f, .53f, false), (.53f, .66f, false), (.66f, .78f, true), (.78f, .89f, true), (.89f, 1f, true) };
            var payCols = new (float S, float E, bool R)[]
                { (0f, .15f, false), (.15f, .37f, false), (.37f, .55f, false), (.55f, .84f, false), (.84f, 1f, true) };
            var breakCols = new (float S, float E, bool R)[]
                { (0f, .22f, false), (.22f, .33f, true), (.33f, .42f, true), (.42f, .51f, true),
                  (.51f, .63f, true), (.63f, .72f, true), (.72f, .86f, true), (.86f, 1f, true) };

            int next = 0, page = 0;

            using var doc = new PrintDocument { DocumentName = statementNo };
            doc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);   // same as RoomStatementPrinter
            doc.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
            doc.BeginPrint += (s, ev) => { next = 0; page = 0; };   // restart for print after preview

            doc.PrintPage += (s, ev) =>
            {
                Graphics g = ev.Graphics!;
                Rectangle m = ev.MarginBounds;
                float x = m.Left, w = m.Width, y = m.Top;

                using var fTitle = new Font("Segoe UI", 15F, FontStyle.Bold);
                using var fHead = new Font("Segoe UI", 12F, FontStyle.Bold);
                using var fBold = new Font("Segoe UI", 9F, FontStyle.Bold);
                using var fText = new Font("Segoe UI", 9F);
                using var fTotal = new Font("Segoe UI", 11F, FontStyle.Bold);
                using var fSmall = new Font("Segoe UI", 7.5F);
                using var left = new StringFormat(StringFormatFlags.NoWrap) { Trimming = StringTrimming.EllipsisCharacter };
                using var right = new StringFormat(StringFormatFlags.NoWrap)
                { Alignment = StringAlignment.Far, Trimming = StringTrimming.EllipsisCharacter };

                float lh = fText.GetHeight(g) + 5;
                float bottom = m.Bottom - fSmall.GetHeight(g) - 8;
                page++;

                float Height((string Kind, string[] Cells) r) => r.Kind switch
                {
                    "title" => fTitle.GetHeight(g) + 2,
                    "heading" => fHead.GetHeight(g) + 6,
                    "section" => lh + 10,
                    "total" => fTotal.GetHeight(g) + 10,
                    "text" or "note" or "muted" => g.MeasureString(r.Cells[0], fText, (int)w).Height + 3,
                    "space" => 12,
                    "sign" => lh + 20,
                    _ => lh
                };

                void Row(string[] cells, (float S, float E, bool R)[] cols, Font f)
                {
                    for (int i = 0; i < cols.Length && i < cells.Length; i++)
                        g.DrawString(cells[i], f, Brushes.Black,
                            new RectangleF(x + w * cols[i].S + 2, y, w * (cols[i].E - cols[i].S) - 4, lh),
                            cols[i].R ? right : left);
                }

                while (next < rows.Count)
                {
                    var r = rows[next];
                    float h = Height(r);
                    // keep a section title together with at least one line under it
                    float need = r.Kind == "section" ? h + 2 * lh : h;
                    if (y + need > bottom && y > m.Top) break;   // continue on the next page

                    switch (r.Kind)
                    {
                        case "title": g.DrawString(r.Cells[0], fTitle, Brushes.Black, x, y); break;
                        case "heading": g.DrawString(r.Cells[0], fHead, Brushes.Black, x, y); break;
                        case "info":
                            g.DrawString(r.Cells[0], fText, Brushes.DimGray, x, y);
                            g.DrawString(r.Cells[1], fBold, Brushes.Black, new RectangleF(x + w * .25f, y, w * .75f, lh), left);
                            break;
                        case "section":
                            g.DrawString(r.Cells[0], fBold, Brushes.Black, x, y + 8);
                            g.DrawLine(Pens.Black, x, y + lh + 6, x + w, y + lh + 6);
                            break;
                        case "sh": Row(r.Cells, summaryCols, fBold); break;
                        case "sr": Row(r.Cells, summaryCols, fText); break;
                        case "sb":
                            g.DrawLine(Pens.Gray, x + w * .46f, y, x + w, y);
                            Row(r.Cells, summaryCols, fBold);
                            break;
                        case "total":
                            g.FillRectangle(Brushes.Gainsboro, x, y + 2, w, h - 4);
                            g.DrawString(r.Cells[0], fTotal, Brushes.Black, x + 4, y + 4);
                            g.DrawString(r.Cells[1], fTotal, Brushes.Black, new RectangleF(x, y + 4, w - 4, h), right);
                            break;
                        case "credit":
                            g.DrawString(r.Cells[0], fBold, Brushes.Black, x + 4, y);
                            g.DrawString(r.Cells[1], fBold, Brushes.Black, new RectangleF(x, y, w - 4, lh), right);
                            break;
                        case "text":
                        case "note":
                        case "muted":
                            g.DrawString(r.Cells[0], fText, r.Kind == "text" ? Brushes.Black : Brushes.DimGray,
                                new RectangleF(x, y, w, h));
                            break;
                        case "ch": Row(r.Cells, chargeCols, fBold); g.DrawLine(Pens.Gray, x, y + lh - 2, x + w, y + lh - 2); break;
                        case "cr": Row(r.Cells, chargeCols, fText); break;
                        case "ph": Row(r.Cells, payCols, fBold); g.DrawLine(Pens.Gray, x, y + lh - 2, x + w, y + lh - 2); break;
                        case "pr": Row(r.Cells, payCols, fText); break;
                        case "bh": Row(r.Cells, breakCols, fBold); g.DrawLine(Pens.Gray, x, y + lh - 2, x + w, y + lh - 2); break;
                        case "br": Row(r.Cells, breakCols, fText); break;
                        case "sign": g.DrawString(r.Cells[0], fText, Brushes.Black, x, y + 16); break;
                    }

                    y += h;
                    next++;
                }

                // Footer on every page
                var footer = new RectangleF(x, m.Bottom - fSmall.GetHeight(g), w, fSmall.GetHeight(g) + 2);
                g.DrawString($"{statementNo} • Generated {DateTime.Now:MMM d, yyyy h:mm tt} • System-generated statement",
                    fSmall, Brushes.Gray, footer, left);
                g.DrawString($"Page {page}", fSmall, Brushes.Gray, footer, right);

                ev.HasMorePages = next < rows.Count;
            };

            using var preview = new PrintPreviewDialog
            {
                Document = doc,
                Width = 900,
                Height = 1000,
                StartPosition = FormStartPosition.CenterParent
            };
            preview.ShowDialog(FindForm());
        }
    }
}