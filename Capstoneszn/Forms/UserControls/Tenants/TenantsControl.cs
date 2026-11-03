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
            if (dgvTenants.CurrentRow == null || dgvTenants.CurrentRow.Index < 0)
            {
                pnlTenantDetails.Visible = false;
                _selectedTenantId = -1;
                return;
            }

            DataRowView row = dgvTenants.CurrentRow.DataBoundItem as DataRowView;
            if (row == null) return;

            _selectedTenantId = Convert.ToInt32(row["TenantId"]);
            ShowDetails(row);
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

           Each category row shows what the tenant still OWES in it -
           ₱ 0.00 means nothing owed, not "no data". Available Balance is
           the net position: credit paid ahead minus everything owed,
           across all categories. Positive = paid ahead, negative = owing.

           Every figure comes from BillingHelper - the same queries the
           payment engine allocates against - so this panel, the payment
           form and Bill Management can never disagree.
           ================================================================= */

        private void LoadTenantBillingSummary(int tenantId)
        {

            var owed = new Dictionary<string, decimal>();
            decimal net = 0m;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    foreach (string cat in Categories)
                    {
                        decimal outstanding = BillingHelper.GetTotalOutstanding(conn, tenantId, cat);
                        decimal credit = BillingHelper.GetAvailableCredit(conn, tenantId, cat);

                        owed[cat] = outstanding;
                        net += credit - outstanding;
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

            ShowOwed(lblRentBillValue, owed["Rent"]);
            ShowOwed(lblMaintenanceBillValue, owed["Maintenance"]);
            ShowOwed(lblWaterBillValue, owed["Water"]);
            ShowOwed(lblElectricityBillValue, owed["Electricity"]);

            // The Utilities row is Water + Electricity together.
            //ShowOwed(lblUtilitiesBillValue, owed["Water"] + owed["Electricity"]);

            lblAvailableBalanceValue.Text =
                (net < 0m ? "-₱ " : "₱ ") + Math.Abs(net).ToString("N2");
            lblAvailableBalanceValue.ForeColor = net < 0m ? Color.Salmon
                                               : net > 0m ? Color.PaleGreen
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

            using (var billing = new TenantBillingForm(_selectedTenantId))
                billing.ShowDialog(this.FindForm());
        }

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
    }
}