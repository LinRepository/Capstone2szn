using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.TenantForms
{
    /// <summary>
    /// The drill-down behind a tenant's Billing Summary: what they were
    /// charged, what they paid, and which periods are still open.
    ///
    /// Read-only by design. Money is recorded in Bill Management and
    /// corrected by voiding a payment - never by editing history here.
    /// </summary>
    /// 

    public partial class TenantBillingForm : Form
    {

        private readonly int _tenantId;

        private const string AllCategories = "All Categories";
        private const string WrittenOffStatus = "Written off";

        /// <summary>
        /// Listed here rather than read from the data, so a category with no
        /// bills still gets a row showing 0.00. "Nothing owed" and "nothing
        /// recorded" must not look like the same thing.
        /// </summary>

        private static readonly string[] Categories =
            { "Rent", "Maintenance", "Water", "Electricity", "Other" };

        /// <summary>Kept so the category filter can re-apply without re-querying.</summary>
        private DataTable _bills;

        public TenantBillingForm(int tenantId)
        {
            InitializeComponent();
            _tenantId = tenantId;
        }

        /* =================================================================
           HEADER
           ================================================================= */

        private void LoadTenantHeader()
        {

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT t.FirstName, t.MiddleName, t.LastName, t.ContactNumber,
                           (SELECT TOP 1 r.RoomNumber
                            FROM   Tenancies tn
                            JOIN   Rooms r ON r.RoomId = tn.RoomId
                            WHERE  tn.TenantId = t.TenantId
                              AND  tn.Status = 'Active') AS CurrentRoom
                    FROM   Tenants t
                    WHERE  t.TenantId = @tid;", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                        {
                            lblTenantInfo.Text = "Tenant not found.";
                            return;
                        }

                        string first = r.GetString(0);
                        string middle = r.IsDBNull(1) ? "" : r.GetString(1);
                        string last = r.GetString(2);
                        string contact = r.GetString(3);

                        // No active tenancy means they have moved out. Their
                        // bill history stays readable either way.
                        // ORIGINAL: string room = r.IsDBNull(4) ? null : r.GetString(4);
                        string room = r.IsDBNull(4) ? null : Convert.ToString(r.GetValue(4));   // NEW: RoomNumber is INT

                        string name = string.IsNullOrWhiteSpace(middle)
                            ? $"{first} {last}"
                            : $"{first} {middle} {last}";

                        lblTenantInfo.Text = room == null
                            ? $"{name}   |   {contact}   |   Not currently renting"
                            : $"{name}   |   {contact}   |   Room {room}";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                lblTenantInfo.Text = "Could not load tenant details.";
            }

        }


        /* =================================================================
           SUMMARY - totals per category
           ================================================================= */

        /// <summary>
        /// Running totals for one category. Nothing here is stored in the
        /// database; every figure is summed from the ledger each time the
        /// form opens, so it cannot drift from the rows behind it.
        /// </summary>
        /// 
        private sealed class CategoryTotals
        {
            public decimal Charged;
            public decimal Paid;
            public decimal WrittenOff;
            public decimal Forfeited;
            public decimal CreditHeld;

            // What they still owe, after a write-off has closed any part of it.
            public decimal Outstanding => Charged - Paid - WrittenOff;

            // Money paid ahead that no bill has claimed yet, less anything
            // forfeited at move-out.
            public decimal Advance => CreditHeld - Forfeited;
        }

        private void LoadSummary()
        {
            var totals = new Dictionary<string, CategoryTotals>();
            foreach (string c in Categories) totals[c] = new CategoryTotals();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Charged and paid, per category.
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT b.BillCategory,
                               SUM(bt.Share) AS Charged,
                               SUM(ISNULL((SELECT SUM(a.Amount)
                                           FROM   PaymentAllocations a
                                           JOIN   Payments p ON p.PaymentId = a.PaymentId
                                           WHERE  a.BillId   = bt.BillId
                                             AND  a.TenantId = bt.TenantId
                                             AND  a.IsVoided = 0
                                             AND  p.IsVoided = 0), 0)) AS Paid
                        FROM   BillTenants bt
                        JOIN   Bills b ON b.BillId = bt.BillId
                        WHERE  bt.TenantId = @tid
                        GROUP BY b.BillCategory;", conn))
                    {
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                // OLD: string cat = r.GetString(0);
                                // NEW: BillCategory can be NULL on old rows - skip them instead of crashing
                                if (r.IsDBNull(0)) continue;
                                string cat = r.GetString(0);
                                if (!totals.ContainsKey(cat)) totals[cat] = new CategoryTotals();

                                totals[cat].Charged = r.IsDBNull(1) ? 0m : r.GetDecimal(1);
                                totals[cat].Paid = r.IsDBNull(2) ? 0m : r.GetDecimal(2);
                            }
                        }
                    }

                    // 2. Write-offs and forfeits. Neither is a payment - they
                    //    are decisions made at move-out - so they are counted
                    //    separately and never mixed into Paid.
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT BillCategory, AdjustmentType, SUM(Amount) AS Total
                        FROM   TenantAdjustments
                        WHERE  TenantId = @tid
                        GROUP BY BillCategory, AdjustmentType;", conn))
                    {
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string cat = r.GetString(0);
                                // OLD: string type = r.GetString(1);
                                // NEW: null-safe
                                string type = r.IsDBNull(1) ? "" : r.GetString(1);
                                decimal amt = r.IsDBNull(2) ? 0m : r.GetDecimal(2);

                                if (!totals.ContainsKey(cat)) totals[cat] = new CategoryTotals();

                                if (type == "WriteOff") totals[cat].WrittenOff = amt;
                                else totals[cat].Forfeited = amt;
                            }
                        }
                    }

                    // 3. Credit held - allocations that no bill has claimed.
                    //    Categorised by the payment they came from, since a
                    //    credit row has no bill to take a category from.
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT p.PaymentCategory, SUM(a.Amount) AS Credit
                        FROM   PaymentAllocations a
                        JOIN   Payments p ON p.PaymentId = a.PaymentId
                        WHERE  a.TenantId = @tid
                          AND  a.BillId IS NULL
                          AND  a.IsVoided = 0
                          AND  p.IsVoided = 0
                        GROUP BY p.PaymentCategory;", conn))
                    {
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string cat = r.GetString(0);
                                if (!totals.ContainsKey(cat)) totals[cat] = new CategoryTotals();

                                totals[cat].CreditHeld = r.IsDBNull(1) ? 0m : r.GetDecimal(1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                // OLD:
                // MessageBox.Show("Could not load the billing totals.",
                //     "Billing Summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // NEW: show the reason while testing, same as TenantsControl does
                MessageBox.Show("Could not load the billing totals: " + ex.Message,
                    "Billing Summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //BindSummary(totals);
        }

        /*
        private void BindSummary(Dictionary<string, CategoryTotals> totals)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Charged", typeof(decimal));
            dt.Columns.Add("Paid", typeof(decimal));
            dt.Columns.Add("Written Off", typeof(decimal));
            dt.Columns.Add("Outstanding", typeof(decimal));
            dt.Columns.Add("Advance", typeof(decimal));

            decimal advanceTotal = 0m;

            foreach (string cat in Categories)
            {
                CategoryTotals t = totals[cat];
                advanceTotal += t.Advance;

                dt.Rows.Add(cat, t.Charged, t.Paid, t.WrittenOff, t.Outstanding, t.Advance);
            }

            dgvSummary.AutoGenerateColumns = true;
            dgvSummary.DataSource = dt;

            FormatMoneyColumns(dgvSummary,
                "Charged", "Paid", "Written Off", "Outstanding", "Advance");

            lblCreditNote.Text = advanceTotal > 0m
                ? $"Paid ahead: {advanceTotal:N2}"
                : "No advance payment held";
        }
        */


        /* =================================================================
           BILL HISTORY
           ================================================================= */

        private void LoadBills()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Period", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Due Date", typeof(DateTime));
            dt.Columns.Add("Share", typeof(decimal));
            dt.Columns.Add("Paid", typeof(decimal));
            dt.Columns.Add("Outstanding", typeof(decimal));
            dt.Columns.Add("Status", typeof(string));

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // When the current stay began. Anything still unpaid from
                    // BEFORE it was cancelled at an earlier move out - move
                    // out writes off everything owed, and a transfer is only
                    // allowed once everything is paid. With no active stay at
                    // all (moved out), every unpaid share was written off.
                    DateTime? currentStayStart = null;
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT TOP 1 MoveInDate FROM Tenancies
                        WHERE  TenantId = @tid AND Status = 'Active';", conn))
                    {
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                        object v = cmd.ExecuteScalar();
                        if (v != null && v != DBNull.Value) currentStayStart = Convert.ToDateTime(v);
                    }

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT b.BillingPeriodStart,
                               b.BillingPeriodEnd,
                               b.DueDate,
                               b.BillCategory,
                               bt.Share,
                               ISNULL((SELECT SUM(a.Amount)
                                       FROM   PaymentAllocations a
                                       JOIN   Payments p ON p.PaymentId = a.PaymentId
                                       WHERE  a.BillId   = bt.BillId
                                         AND  a.TenantId = bt.TenantId
                                         AND  a.IsVoided = 0
                                         AND  p.IsVoided = 0), 0) AS Paid
                        FROM   BillTenants bt
                        JOIN   Bills b ON b.BillId = bt.BillId
                        WHERE  bt.TenantId = @tid
                        ORDER BY b.BillingPeriodStart DESC, b.BillCategory ASC;", conn))
                    {
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                DateTime start = r.GetDateTime(0);
                                DateTime end = r.GetDateTime(1);
                                DateTime due = r.GetDateTime(2);
                                string category = r.GetString(3);
                                decimal share = r.GetDecimal(4);
                                decimal paid = r.GetDecimal(5);

                                decimal outstanding = share - paid;
                                string status = BillStatus(outstanding, paid, due);

                                // Without this, a written-off share shows as
                                // "Overdue" in red forever - for a tenant who
                                // has long since left.
                                bool writtenOff = outstanding > 0m &&
                                    (!currentStayStart.HasValue || start < currentStayStart.Value);

                                if (writtenOff)
                                {
                                    outstanding = 0m;
                                    status = WrittenOffStatus;
                                }

                                dt.Rows.Add(
                                    $"{start:MMM d, yyyy} - {end:MMM d, yyyy}",
                                    category,
                                    due,
                                    share,
                                    paid,
                                    outstanding,
                                    status);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load the bill history.",
                    "Billing Summary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _bills = dt;

            dgvBills.AutoGenerateColumns = true;
            dgvBills.DataSource = _bills;

            FormatMoneyColumns(dgvBills, "Share", "Paid", "Outstanding");

            if (dgvBills.Columns["Due Date"] != null)
                dgvBills.Columns["Due Date"].DefaultCellStyle.Format = "MMM d, yyyy";

            ApplyFilter();

        }

        /// <summary>
        /// Derived, never stored. A stored status would go stale the moment a
        /// payment landed or a due date passed.
        /// </summary>
        private static string BillStatus(decimal outstanding, decimal paid, DateTime dueDate)
        {
            if (outstanding <= 0m) return "Paid";
            if (dueDate < DateTime.Today) return "Overdue";
            if (paid > 0m) return "Partial";
            return "Unpaid";
        }


        /* =================================================================
           FILTER AND FORMATTING
           ================================================================= */

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            // Fires once from Load before the table exists.
            if (_bills == null) return;

            string choice = cboCategory.SelectedItem as string;

            _bills.DefaultView.RowFilter =
                (string.IsNullOrEmpty(choice) || choice == AllCategories)
                    ? string.Empty
                    : "Category = '" + choice.Replace("'", "''") + "'";
        }

        private static void FormatMoneyColumns(DataGridView grid, params string[] columns)
        {
            foreach (string name in columns)
            {
                DataGridViewColumn col = grid.Columns[name];
                if (col == null) continue;

                col.DefaultCellStyle.Format = "N2";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        /// <summary>
        /// Colours the Status cell so an overdue period is visible without
        /// reading every row.
        /// </summary>
        private void dgvBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvBills.Columns[e.ColumnIndex].Name != "Status") return;

            string status = e.Value as string;

            switch (status)
            {
                case "Paid": e.CellStyle.ForeColor = Color.ForestGreen; break;
                case "Overdue": e.CellStyle.ForeColor = Color.Crimson; break;
                case "Partial": e.CellStyle.ForeColor = Color.DarkOrange; break;
                case WrittenOffStatus: e.CellStyle.ForeColor = Color.Gray; break;
                default: e.CellStyle.ForeColor = Color.Black; break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TenantBillingForm_Load(object sender, EventArgs e)
        {
            cboCategory.Items.Add(AllCategories);
            cboCategory.Items.AddRange(Categories);
            cboCategory.SelectedIndex = 0;     // fires the filter; it guards on a null table

            LoadTenantHeader();
            // OLD:
            // LoadSummary();
            // NEW: its totals are no longer displayed (BindSummary and the summary grid were
            //      removed), so calling it only produced the "Could not load" popup.
            //      The Billing Summary panel in TenantsControl already shows these totals.
            LoadBills();
        }
    }
}