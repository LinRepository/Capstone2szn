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

        private void btnGenerateStatement_Click(object sender, EventArgs e)
        {
            if (_selectedTenantId <= 0)
            {
                MessageBox.Show("Please select a tenant first.", "No Tenant Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // NEW: validation - the preview needs at least one printer driver
            // (e.g. Microsoft Print to PDF); without one it fails while drawing.
            if (PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("No printer is installed. Enable \"Microsoft Print to PDF\" in Windows Features.",
                    "Billing Statement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tenantId = _selectedTenantId;
            DateTime today = DateTime.Today;

            string building = "", tenantName = "", roomNo = "", preparedBy = "-";
            DateTime moveIn = today, periodStart = today, periodEnd = today, dueDate = today;
            bool isEstimate = false;
            decimal rentCredit = 0m;

            // NEW: advance payment (credit) held per category, and this period's rent share
            decimal waterCredit = 0m;
            decimal rentShareThisPeriod = 0m;

            // Desc, Due, Share, Paid, IsEstimate
            var current = new List<(string Desc, DateTime Due, decimal Share, decimal Paid, bool Est)>();
            var unpaid = new List<(string Desc, DateTime Due, decimal Share, decimal Paid, bool Est)>();
            var notes = new List<string>();

            // What this tenant has paid on one bill (voided allocations / payments don't count)
            const string PaidSql = @"ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                                             JOIN Payments p ON p.PaymentId = a.PaymentId
                                             WHERE a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                               AND a.IsVoided = 0 AND p.IsVoided = 0), 0)";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                // ---- 1. Active stay, room, building ----
                int roomId, buildingId;
                decimal roomPrice;
                DateTime? anchor;

                using (var cmd = new SqlCommand(@"
                    SELECT tn.RoomId, tn.MoveInDate, t.FirstName, t.MiddleName, t.LastName,
                           r.RoomNumber, r.RoomPrice, r.BillingAnchorDate, r.BuildingId, b.BuildingName
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
                    buildingId = Convert.ToInt32(rd["BuildingId"]);
                    moveIn = Convert.ToDateTime(rd["MoveInDate"]).Date;
                    roomNo = Str(rd["RoomNumber"]);
                    building = Str(rd["BuildingName"]);
                    roomPrice = rd["RoomPrice"] == DBNull.Value ? 0m : Convert.ToDecimal(rd["RoomPrice"]);
                    anchor = rd["BillingAnchorDate"] == DBNull.Value
                        ? (DateTime?)null : Convert.ToDateTime(rd["BillingAnchorDate"]).Date;

                    string mid = Str(rd["MiddleName"]);
                    tenantName = Str(rd["LastName"]) + ", " + Str(rd["FirstName"]) +
                                 (mid.Length > 0 ? " " + mid[0] + "." : "");
                }

                if (anchor == null)
                {
                    MessageBox.Show("This room has no billing cycle yet.", "Billing Statement",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // ---- 2. The period: next rent due date (room anchor + k months) ----
                int k = 0;
                while (anchor.Value.AddMonths(k) < today) k++;
                periodStart = anchor.Value.AddMonths(k);
                periodEnd = anchor.Value.AddMonths(k + 1);
                dueDate = periodStart;

                // ---- 3. Rent: the real bill if already generated ----
                int rentBillId = 0;
                using (var cmd = new SqlCommand(@"
                    SELECT TOP 1 b.BillId, b.BillingPeriodStart, b.DueDate, bt.Share, " + PaidSql + @" AS Paid
                    FROM   Bills b
                    LEFT JOIN BillTenants bt ON bt.BillId = b.BillId AND bt.TenantId = @tid
                    WHERE  b.RoomId = @rid AND b.BillCategory = 'Rent' AND b.BillingPeriodStart >= @today
                    ORDER BY b.BillingPeriodStart;", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                    cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        rentBillId = Convert.ToInt32(rd["BillId"]);
                        periodStart = Convert.ToDateTime(rd["BillingPeriodStart"]).Date;
                        dueDate = Convert.ToDateTime(rd["DueDate"]).Date;

                        if (rd["Share"] == DBNull.Value)
                            notes.Add("No rent share this period (joined after the bill was generated).");
                        // OLD:
                        // else
                        //     current.Add(($"Rent {periodStart:MMM d} – {periodEnd:MMM d, yyyy}", dueDate,
                        //         Convert.ToDecimal(rd["Share"]), Convert.ToDecimal(rd["Paid"]), false));
                        // NEW: same line, and also remember the share (used to show how many
                        //      periods the remaining advance credit covers)
                        else
                        {
                            rentShareThisPeriod = Convert.ToDecimal(rd["Share"]);
                            current.Add(($"Rent {periodStart:MMM d} – {periodEnd:MMM d, yyyy}", dueDate,
                                rentShareThisPeriod, Convert.ToDecimal(rd["Paid"]), false));
                        }
                    }
                }

                // ---- 4. Rent: estimate if not generated yet ----
                if (rentBillId == 0)
                {
                    // NEW: validation - no room price means no estimate can be made
                    if (roomPrice <= 0m)
                    {
                        MessageBox.Show($"Room {roomNo} has no room price set, so the rent can't be estimated.",
                            "Billing Statement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    isEstimate = true;
                    var heads = new List<int>();   // longest-tenured first
                    using (var cmd = new SqlCommand(@"
                        SELECT TenantId FROM Tenancies
                        WHERE RoomId = @rid AND Status = 'Active'
                        ORDER BY MoveInDate, TenantId;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                        using SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read()) heads.Add(rd.GetInt32(0));
                    }

                    int n = Math.Max(heads.Count, 1);
                    decimal each = Math.Floor(roomPrice / n * 100m) / 100m;
                    decimal share = (heads.Count > 0 && heads[0] == tenantId) ? roomPrice - each * (n - 1) : each;

                    current.Add(($"Rent {periodStart:MMM d} – {periodEnd:MMM d, yyyy} (estimate)",
                        dueDate, share, 0m, true));

                    // NEW: remember the share (used for the credit coverage line)
                    rentShareThisPeriod = share;

                    // OLD: credit was only read for estimates, so a tenant whose bill was
                    //      already generated never saw their remaining advance payment.
                    // rentCredit = BillingHelper.GetAvailableCredit(conn, tenantId, "Rent");
                }

                // NEW: advance payment (credit) is read for EVERY statement.
                //      GetAvailableCredit = unclaimed credit, minus anything forfeited,
                //      never below zero (same figure the Billing Summary uses).
                rentCredit = BillingHelper.GetAvailableCredit(conn, tenantId, "Rent");
                waterCredit = BillingHelper.GetAvailableCredit(conn, tenantId, "Water");

                // ---- 5. Water for the period's month ----
                DateTime waterMonth = new DateTime(periodStart.Year, periodStart.Month, 1);
                int waterBillId = 0;
                using (var cmd = new SqlCommand(@"
                    SELECT TOP 1 b.BillId, b.DueDate, bt.Share, " + PaidSql + @" AS Paid
                    FROM   Bills b
                    JOIN   BillTenants bt ON bt.BillId = b.BillId AND bt.TenantId = @tid
                    WHERE  b.BillCategory = 'Water' AND b.BillingPeriodStart = @m;", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    cmd.Parameters.Add("@m", SqlDbType.Date).Value = waterMonth;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        waterBillId = Convert.ToInt32(rd["BillId"]);
                        current.Add(($"Water – {waterMonth:MMMM yyyy}", Convert.ToDateTime(rd["DueDate"]).Date,
                            Convert.ToDecimal(rd["Share"]), Convert.ToDecimal(rd["Paid"]), false));
                    }
                }
                if (waterBillId == 0 && moveIn <= waterMonth)
                    notes.Add($"Water – {waterMonth:MMMM yyyy}: to follow (not yet recorded).");

                // ---- 6. Other unpaid bills (current stay only) ----
                using (var cmd = new SqlCommand(@"
                    SELECT b.BillId, b.BillCategory, b.BillingPeriodStart, b.DueDate,
                           bt.Share, " + PaidSql + @" AS Paid, mi.IssueTitle
                    FROM   BillTenants bt
                    JOIN   Bills b      ON b.BillId = bt.BillId
                    JOIN   Tenancies tn ON tn.TenantId = bt.TenantId AND tn.Status = 'Active'
                    LEFT JOIN MaintenanceIssues mi ON mi.IssueId = b.MaintenanceIssueId
                    WHERE  bt.TenantId = @tid
                      AND  b.BillCategory IN ('Rent', 'Maintenance', 'Water')
                      AND  b.BillingPeriodStart >= tn.MoveInDate
                      AND  bt.Share - " + PaidSql + @" > 0
                    ORDER BY b.DueDate;", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                    using SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        int id = Convert.ToInt32(rd["BillId"]);
                        if (id == rentBillId || id == waterBillId) continue;   // already in current charges

                        string cat = Str(rd["BillCategory"]);
                        DateTime start = Convert.ToDateTime(rd["BillingPeriodStart"]);
                        string desc = cat == "Water" ? $"Water – {start:MMMM yyyy}"
                                    : cat == "Maintenance" ? "Maintenance – " + Str(rd["IssueTitle"])
                                    : $"Rent from {start:MMM d, yyyy}";

                        unpaid.Add((desc, Convert.ToDateTime(rd["DueDate"]).Date,
                            Convert.ToDecimal(rd["Share"]), Convert.ToDecimal(rd["Paid"]), false));
                    }
                }

                // ---- 7. Pending maintenance (label only, no amount) ----
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

                // ---- 8. Prepared by ----
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

            // ---- Totals ----
            decimal Bal(decimal share, decimal paid) => Math.Max(0m, share - paid);

            decimal unpaidTotal = unpaid.Sum(l => Bal(l.Share, l.Paid));
            decimal currentTotal = current.Sum(l => l.Share);
            decimal paidCurrent = current.Sum(l => Math.Min(l.Paid, l.Share));
            decimal creditApplied = isEstimate ? Math.Min(rentCredit, current.Where(l => l.Est).Sum(l => l.Share)) : 0m;
            decimal amountDue = Math.Max(0m, unpaidTotal + currentTotal - paidCurrent - creditApplied);

            // NEW: advance payment left AFTER this statement.
            //  - Estimate: part of the rent credit is shown as applied to this period
            //    (the system applies it when the bill is generated).
            //  - Real bill: the system already applied credit to it (it is inside "Paid"),
            //    so what GetAvailableCredit returns is already the remainder.
            decimal rentCreditLeft = Math.Max(0m, rentCredit - creditApplied);
            decimal waterCreditLeft = waterCredit;
            int periodsCovered = rentShareThisPeriod > 0m
                ? (int)Math.Floor(rentCreditLeft / rentShareThisPeriod)
                : 0;

            string statementNo = $"{(isEstimate ? "EST" : "SOA")}-{tenantId:D5}-{periodStart:yyyyMMdd}";

            string Status(decimal share, decimal paid, DateTime due, bool est) =>
                est ? "Estimate"
                : Bal(share, paid) <= 0m ? "Paid"
                : today > due ? "Overdue"
                : paid > 0m ? "Partially Paid" : "Unpaid";

            // ---- Print document ----
            using var doc = new PrintDocument { DocumentName = "Billing Statement - " + tenantName };
            try
            {
                foreach (PaperSize ps in doc.PrinterSettings.PaperSizes)
                    if (ps.Kind == PaperKind.A4) { doc.DefaultPageSettings.PaperSize = ps; break; }
                doc.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
            }
            catch (InvalidPrinterException) { }

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
                // Description | Due Date | Status | Share | Paid | Balance
                void TableRow(string[] c, Font f)
                {
                    g.DrawString(c[0], f, Brushes.Black, new RectangleF(x, y, w * 0.40f, lh));
                    g.DrawString(c[1], f, Brushes.Black, x + w * 0.40f, y);
                    g.DrawString(c[2], f, Brushes.Black, x + w * 0.53f, y);
                    g.DrawString(c[3], f, Brushes.Black, new RectangleF(x, y, w * 0.77f, lh), right);
                    g.DrawString(c[4], f, Brushes.Black, new RectangleF(x, y, w * 0.88f, lh), right);
                    g.DrawString(c[5], f, Brushes.Black, new RectangleF(x, y, w, lh), right);
                    y += lh;
                }
                void Table(List<(string Desc, DateTime Due, decimal Share, decimal Paid, bool Est)> lines, string empty)
                {
                    if (lines.Count == 0) { g.DrawString(empty, fText, Brushes.DimGray, x, y); y += lh; return; }
                    TableRow(new[] { "Description", "Due Date", "Status", "Your Share", "Paid", "Balance" }, fBold);
                    foreach (var l in lines)
                        TableRow(new[] { l.Desc, l.Due.ToString("MMM d, yyyy"), Status(l.Share, l.Paid, l.Due, l.Est),
                                         "₱" + l.Share.ToString("N2"), l.Est ? "—" : "₱" + l.Paid.ToString("N2"),
                                         "₱" + Bal(l.Share, l.Paid).ToString("N2") }, fText);
                }

                // NEW: a grey explanation line under an amount
                void Hint(string text)
                {
                    g.DrawString(text, fText, Brushes.DimGray, x + 12, y);
                    y += lh;
                }

                /*
                // Estimate watermark
                if (isEstimate)
                {
                    var state = g.Save();
                    using var fMark = new Font("Segoe UI", 72F, FontStyle.Bold);
                    using var mark = new SolidBrush(Color.FromArgb(28, 0, 0, 0));
                    g.TranslateTransform(ev.PageBounds.Width / 2f, ev.PageBounds.Height / 2f);
                    g.RotateTransform(-35f);
                    SizeF sz = g.MeasureString("ESTIMATE", fMark);
                    g.DrawString("ESTIMATE", fMark, mark, -sz.Width / 2f, -sz.Height / 2f);
                    g.Restore(state);
                }
                */

                // Header
                g.DrawString(building, fTitle, Brushes.Black, x, y); y += fTitle.GetHeight(g) + 2;
                g.DrawString(isEstimate ? "BILLING STATEMENT (ESTIMATE)" : "BILLING STATEMENT", fHead, Brushes.Black, x, y);
                y += fHead.GetHeight(g) + 10;

                Info("Statement No.", statementNo);
                Info("Statement Date", today.ToString("MMM d, yyyy"));
                Info("Billing Period", $"{periodStart:MMM d, yyyy} – {periodEnd:MMM d, yyyy}");
                Info("Payment Due Date", dueDate.ToString("MMM d, yyyy"));
                y += 4;
                Info("Tenant", tenantName);
                Info("Room", roomNo);
                Info("Occupied Since", moveIn.ToString("MMM d, yyyy"));

                // Summary
                Section("SUMMARY");
                Amount("Unpaid previous bills", "₱" + unpaidTotal.ToString("N2"), fText);
                Amount("Current charges", "₱" + currentTotal.ToString("N2"), fText);
                if (paidCurrent > 0m) Amount("Less: already paid", "-₱" + paidCurrent.ToString("N2"), fText);
                if (creditApplied > 0m) Amount("Less: advance credit", "-₱" + creditApplied.ToString("N2"), fText);
                g.FillRectangle(Brushes.Gainsboro, x, y, w, fTotal.GetHeight(g) + 6);
                y += 3;
                Amount("TOTAL AMOUNT DUE", "₱" + amountDue.ToString("N2"), fTotal);

                // OLD:
                // g.DrawString(amountDue > 0m ? $"Please pay on or before {dueDate:MMM d, yyyy}." : "No amount due.",
                //     fText, Brushes.Black, x, y);
                // NEW: say WHY nothing is due when an advance payment covers it
                string dueText = amountDue > 0m ? $"Please pay on or before {dueDate:MMM d, yyyy}."
                               : (rentCredit > 0m || waterCredit > 0m || paidCurrent > 0m)
                                   ? "No amount due. This period is covered by your payment in advance."
                                   : "No amount due.";
                g.DrawString(dueText, fText, Brushes.Black, x, y);
                y += lh;

                // NEW: remaining credit shown right under the total (summary level)
                if (rentCreditLeft > 0m || waterCreditLeft > 0m)
                    Amount("Advance credit remaining", "₱" + (rentCreditLeft + waterCreditLeft).ToString("N2"), fBold);

                // Lines
                Section($"CURRENT CHARGES ({periodStart:MMM d} – {periodEnd:MMM d, yyyy})");
                Table(current, "No current charges.");
                Section("UNPAID PREVIOUS BILLS");
                Table(unpaid, "No unpaid bills.");

                // NEW: Advance payment (credit) section
                Section("ADVANCE PAYMENT (CREDIT)");
                if (rentCredit <= 0m && waterCredit <= 0m)
                {
                    g.DrawString("No advance payment on record.", fText, Brushes.DimGray, x, y);
                    y += lh;
                }
                else
                {
                    if (rentCredit > 0m)
                    {
                        Amount("Rent credit available", "₱" + rentCredit.ToString("N2"), fText);
                        if (creditApplied > 0m)
                            Amount("Less: to be applied to this period's rent", "-₱" + creditApplied.ToString("N2"), fText);
                        Amount("Rent credit remaining", "₱" + rentCreditLeft.ToString("N2"), fBold);
                        if (periodsCovered > 0)
                            Hint($"Covers about {periodsCovered} more rent period(s) at ₱{rentShareThisPeriod:N2} each.");
                        else if (rentCreditLeft > 0m)
                            Hint("Will be applied to your next rent bill.");
                    }
                    if (waterCredit > 0m)
                    {
                        Amount("Water credit remaining", "₱" + waterCreditLeft.ToString("N2"), fBold);
                        Hint("Will be applied to your next water bill.");
                    }
                }

                // Notes
                Section("NOTES");
                var allNotes = new List<string>(notes)
                {
                    "Payment methods: Cash or GCash. Please keep your official receipt.",
                    "A bill becomes overdue the day after its due date.",
                    "Electricity is paid directly to AKELCO and is not included."
                };
                if (isEstimate)
                    allNotes.Add("ESTIMATE: rent for this period is not billed yet. It is based on the room price and " +
                                 "active tenants today and may change. This is not a demand for payment.");

                // NEW: advance payment terms (credit is used automatically; unused credit is forfeited on move-out)
                if (rentCredit > 0m || waterCredit > 0m)
                    allNotes.Add("Advance payments are applied automatically to your next bills of the same category. " +
                                 "Unused advance payment is not refunded upon move-out.");

                foreach (string n in allNotes)
                {
                    SizeF sz = g.MeasureString("• " + n, fText, (int)w);
                    g.DrawString("• " + n, fText, Brushes.DimGray, new RectangleF(x, y, w, sz.Height));
                    y += sz.Height + 2;
                }

                // Signatures
                y += 20;
                g.DrawString("Prepared by: " + preparedBy, fText, Brushes.Black, x, y);

                // Footer
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