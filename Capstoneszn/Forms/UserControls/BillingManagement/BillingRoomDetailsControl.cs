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
using Capstoneszn.Forms.PaymentsForms;
using Capstoneszn.Forms.TenantForms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.UserControls.BillingManagement
{
    /// <summary>
    /// One room's billing: what this period's bill is, what the current
    /// tenants still owe across every period, and where to take a payment.
    ///
    /// Everything on this screen is about the people living here now. A
    /// tenant who moved out had their balance written off or forfeited at
    /// move out, so including them would show money nobody can collect.
    /// The same rule drives the room card, so the card and this screen
    /// always agree.
    /// </summary>
    /// 

    public partial class BillingRoomDetailsControl : UserControl
    {

        /// <summary>
        /// The "This Period" figures follow the room's rent bill. Every
        /// other category (water, maintenance) still counts in Total
        /// Outstanding, which is category-blind; maintenance also gets its
        /// own column because it is paid separately (Full only).
        /// </summary>
        private const string RentCategory = "Rent";
        private readonly int _roomId;

        private int _currentBillId = -1;

        private DateTime? _currentDueDate;
        private DataTable _tenants;

        // NEW (Step 5): the dates of "this period". Every rent bill of the room
        // inside these dates counts in This Period (the main bill, plus a
        // transfer share or joiner share added during the period).
        private DateTime? _currentPeriodStart;
        private DateTime? _currentPeriodEnd;      // stored end = the next period's start

        // NEW (fix 2): when the room has no rent bill yet, the date and price
        // of its first one, so the screen says "First bill: Dec 1, 2026 · ₱3,000.00"
        // instead of just "No bill yet". Null = no billing cycle (empty room).
        private DateTime? _firstBillDate;
        private decimal _firstBillPrice;

        // NEW (Billing v2): the drop-down list of periods for Generate statement
        private readonly ContextMenuStrip _periodMenu = new ContextMenuStrip();
        public BillingRoomDetailsControl(int roomId)
        {
            InitializeComponent();

            _roomId = roomId;

            // Columns are defined in the designer; never let the grid add
            // its own from the query (TenantId, Overdue stay hidden that way).
            dgvTenantPayments.AutoGenerateColumns = false;

            // ORIGINAL: foreach (DataGridViewColumn col in new[] { colShare, colPaid, colMaintenance, colOutstanding, colAdvance })

            // NEW (Billing v2): each category column shows that category's unpaid balance
            colRent.DataPropertyName = "RentOwed";
            colWater.DataPropertyName = "WaterOwed";
            colMaintenance.DataPropertyName = "MaintenanceOwed";

            foreach (DataGridViewColumn col in new[] { colRent, colWater, colMaintenance, colOutstanding, colCredits })
            {
                col.DefaultCellStyle.Format = "N2";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Every event on this control is wired in the designer. Do not
            // add any of them here as well, or each fires twice.

        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadBilling();
        }

        /* =================================================================
   LOADING
   ================================================================= */

        /// <summary>Public so a successful payment can refresh the screen.</summary>
        /// 

        public void LoadBilling()
        {

            _tenants = null;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    LoadRoomHeader(conn);
                    LoadCurrentBill(conn);
                    LoadTenantGrid(conn);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load this room's billing.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateSummary();

        }


        private void LoadRoomHeader(SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT RoomNumber FROM Rooms WHERE RoomId = @rid;", conn))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;

                object rn = cmd.ExecuteScalar();
                lblRoomNumber.Text = "Room " +
                    ((rn == null || rn == DBNull.Value) ? "-" : rn.ToString());
            }
        }


        /// <summary>
        /// The room's most recent rent bill is "this period". Older periods
        /// are not lost - anything still unpaid on them is in each tenant's
        /// Outstanding column, and the full history is a double-click away.
        /// </summary>

        private void LoadCurrentBill(SqlConnection conn)
        {
            _currentBillId = -1;
            _currentDueDate = null;
            _currentPeriodStart = null;   // NEW (Step 5)
            _currentPeriodEnd = null;     // NEW (Step 5)
            _firstBillDate = null;   // NEW (fix 2)
            _firstBillPrice = 0m;    // NEW (fix 2)
            lblPeriodValue.Text = "No bill yet";

            // ORIGINAL query (picked up the transfer "Price difference" bills too,
            // which are short partial periods, e.g. "Nov 2 - Nov 30"):
            //     SELECT TOP 1 BillId, BillingPeriodStart, BillingPeriodEnd, DueDate
            //     FROM   Bills
            //     WHERE  RoomId = @rid
            //       AND  BillCategory = @cat
            //     ORDER BY BillingPeriodStart DESC;

            // NEW (fix 2): the room's latest REGULAR rent bill. Difference bills
            // are extra charges for one tenant, not the room's period.
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT TOP 1 b.BillId, b.BillingPeriodStart, b.BillingPeriodEnd, b.DueDate
                FROM   Bills b
                WHERE  b.RoomId = @rid
                  AND  b.BillCategory = @cat
                  AND  b.BillKind IN (N'Regular', N'Closed')
                  AND  NOT EXISTS (SELECT 1 FROM Bills m
                                   WHERE  m.RoomId = b.RoomId
                                     AND  m.BillCategory = b.BillCategory
                                     AND  m.BillKind IN (N'Regular', N'Closed')
                                     AND  m.BillingPeriodEnd = b.BillingPeriodEnd
                                     AND  m.BillingPeriodStart < b.BillingPeriodStart)
                ORDER BY b.BillingPeriodStart DESC,
                         CASE WHEN b.BillKind = N'Regular' THEN 0 ELSE 1 END;", conn))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                cmd.Parameters.Add("@cat", SqlDbType.VarChar, 30).Value = RentCategory;

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        _currentBillId = rd.GetInt32(0);
                        DateTime start = rd.GetDateTime(1);
                        DateTime end = rd.GetDateTime(2);
                        _currentDueDate = rd.GetDateTime(3);
                        _currentPeriodStart = start;   // NEW (Step 5)
                        _currentPeriodEnd = end;       // NEW (Step 5)

                        // ORIGINAL: lblPeriodValue.Text = $"{start:MMM d} - {end:MMM d, yyyy}";
                        // NEW (fix 3): BillingPeriodEnd is the day the NEXT period starts
                        // (Nov 1 -> Dec 1), so the last day of this one is the day before:
                        // "Nov 1 - Nov 30, 2026", the same as the statement.
                        lblPeriodValue.Text = $"{start:MMM d} - {end.AddDays(-1):MMM d, yyyy}";
                        return;
                    }
                }
            }

            // NEW (fix 2): no rent bill yet -> work out the first one.
            LoadFirstBill(conn);
        }

        /// <summary>
        /// NEW (fix 2): the date and amount of the room's first rent bill.
        ///
        /// Same rule as Move-In and Transfer: the first period after today
        /// that has no bill yet (BillGenerator.NextUnbilledPeriod), at the
        /// price that period will be billed at - the scheduled (pending)
        /// price if it starts by then, otherwise the current price.
        ///
        ///   anchor Nov 1, today Nov 2, no bills   -> First bill: Dec 1, 2026 · ₱3,000.00
        ///
        /// A room with no billing cycle (nobody has moved in) keeps "No bill yet".
        /// </summary>
        private void LoadFirstBill(SqlConnection conn)
        {
            DateTime? anchor = null, pendingFrom = null;
            decimal price = 0m;
            decimal? pending = null;

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT BillingAnchorDate, RoomPrice, PendingRoomPrice, PendingPriceFrom
                FROM   Rooms
                WHERE  RoomId = @rid;", conn))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return;

                    anchor = rd.IsDBNull(0) ? (DateTime?)null : rd.GetDateTime(0);
                    price = rd.IsDBNull(1) ? 0m : rd.GetDecimal(1);
                    pending = rd.IsDBNull(2) ? (decimal?)null : rd.GetDecimal(2);
                    pendingFrom = rd.IsDBNull(3) ? (DateTime?)null : rd.GetDateTime(3);
                }
            }

            if (!anchor.HasValue) return;   // no cycle yet: stays "No bill yet"

            DateTime first = BillGenerator.NextUnbilledPeriod(conn, null, _roomId, anchor.Value, DateTime.Today);

            _firstBillDate = first;
            _firstBillPrice = (pending.HasValue && pendingFrom.HasValue && pendingFrom.Value <= first)
                ? pending.Value
                : price;

            lblPeriodValue.Text = $"First bill: {first:MMM d, yyyy}";
        }

        /// <summary>
        /// One row per current tenant.
        ///
        ///   PeriodShare / PeriodPaid - this period's rent bill only. NULL
        ///       means they joined after the bill was generated and have no
        ///       share in it; they are billed from the next period.
        ///   Outstanding / Overdue - every unpaid share from their CURRENT
        ///       stay, any category, any room. Same rule as BillingHelper's
        ///       allocation engine, so this screen shows exactly what the
        ///       payment form can collect. No room filter on purpose: a
        ///       maintenance bill for the room they transferred out of
        ///       follows the tenant. Bills from before a reactivation are
        ///       excluded: those were settled by write-off or forfeit at
        ///       that earlier move out.
        ///   MaintenanceOwed - the Maintenance part of Outstanding.
        ///   Advance - credit paid ahead that no bill has claimed yet, less
        ///       anything forfeited.
        ///
        /// Voided payments are excluded on both the allocation and the
        /// payment, so a reversed payment can never read as paid.
        /// </summary>


        private void LoadTenantGrid(SqlConnection conn)
        {
            const string sql = @"
                SELECT t.TenantId,
                       t.FirstName
                     + ISNULL(' ' + LEFT(NULLIF(LTRIM(t.MiddleName), N''), 1) + '.', '')
                     + ' ' + t.LastName AS TenantName,
                       cur.Share                       AS PeriodShare,
                       cur.Paid                        AS PeriodPaid,
                        ISNULL(cur.LateUnpaid, 0)       AS PeriodOverdue,   -- NEW (Step 5 fix)
                        cur.NextDue                     AS PeriodNextDue,   -- NEW (Step 5 fix)
                       ISNULL(debt.Outstanding, 0)     AS Outstanding,
                       ISNULL(debt.Overdue, 0)         AS Overdue,
                       ISNULL(debt.MaintOwed, 0)       AS MaintenanceOwed,
                       ISNULL(debt.RentOwed, 0)        AS RentOwed,      -- NEW (Billing v2)
                       ISNULL(debt.WaterOwed, 0)       AS WaterOwed,     -- NEW (Billing v2)
                       ISNULL(cred.Held, 0)
                     - ISNULL(forf.Forfeited, 0)       AS Advance
                FROM   Tenancies tn
                JOIN   Tenants t ON t.TenantId = tn.TenantId

                -- NEW (Step 5): every rent bill of this room inside this period
                                OUTER APPLY (
                    SELECT SUM(s.Share) AS Share,
                           SUM(s.Paid)  AS Paid,
                           -- NEW (Step 5 fix): unpaid on bills already past their due date,
                           -- and the earliest due date still unpaid
                           SUM(CASE WHEN s.DueDate < CAST(GETDATE() AS DATE)
                                    THEN s.Share - s.Paid ELSE 0 END) AS LateUnpaid,
                           MIN(CASE WHEN s.Share > s.Paid THEN s.DueDate END) AS NextDue
                    FROM (
                        SELECT bt.Share, b.DueDate,
                               ISNULL((SELECT SUM(a.Amount)
                                       FROM   PaymentAllocations a
                                       JOIN   Payments p ON p.PaymentId = a.PaymentId
                                       WHERE  a.BillId   = bt.BillId
                                         AND  a.TenantId = bt.TenantId
                                         AND  a.IsVoided = 0
                                         AND  p.IsVoided = 0), 0) AS Paid
                        FROM   BillTenants bt
                        JOIN   Bills b ON b.BillId = bt.BillId
                        WHERE  bt.TenantId = t.TenantId
                          AND  b.RoomId = @rid
                          AND  b.BillCategory = 'Rent'
                          AND  b.BillingPeriodStart >= @ps
                          AND  b.BillingPeriodStart <  @pe
                          AND  b.BillingPeriodStart >= tn.MoveInDate
                    ) s
                ) cur

                OUTER APPLY (
                    SELECT SUM(x.Unpaid) AS Outstanding,
                           SUM(CASE WHEN x.DueDate < CAST(GETDATE() AS DATE)
                                    THEN x.Unpaid ELSE 0 END) AS Overdue,
                           SUM(CASE WHEN x.BillCategory = 'Rent'
                                    THEN x.Unpaid ELSE 0 END) AS RentOwed,    -- NEW (Billing v2)
                           SUM(CASE WHEN x.BillCategory = 'Water'
                                    THEN x.Unpaid ELSE 0 END) AS WaterOwed,   -- NEW (Billing v2)
                           SUM(CASE WHEN x.BillCategory = 'Maintenance'
                                    THEN x.Unpaid ELSE 0 END) AS MaintOwed
                    FROM (
                        SELECT b.DueDate, b.BillCategory,
                               bt.Share
                             - ISNULL((SELECT SUM(a.Amount)
                                       FROM   PaymentAllocations a
                                       JOIN   Payments p ON p.PaymentId = a.PaymentId
                                       WHERE  a.BillId   = bt.BillId
                                         AND  a.TenantId = bt.TenantId
                                         AND  a.IsVoided = 0
                                         AND  p.IsVoided = 0), 0) AS Unpaid
                        FROM   BillTenants bt
                        JOIN   Bills b ON b.BillId = bt.BillId
                        WHERE  bt.TenantId = t.TenantId
                          AND  b.BillingPeriodStart >= tn.MoveInDate
                    ) x
                    WHERE x.Unpaid > 0
                ) debt

                OUTER APPLY (
                    SELECT SUM(a.Amount) AS Held
                    FROM   PaymentAllocations a
                    JOIN   Payments p ON p.PaymentId = a.PaymentId
                    WHERE  a.TenantId = t.TenantId
                      AND  a.BillId IS NULL
                      AND  a.IsVoided = 0
                      AND  p.IsVoided = 0
                ) cred

                OUTER APPLY (
                    SELECT SUM(adj.Amount) AS Forfeited
                    FROM   TenantAdjustments adj
                    WHERE  adj.TenantId = t.TenantId
                      AND  adj.AdjustmentType = 'Forfeit'
                ) forf

                WHERE  tn.RoomId = @rid
                  AND  tn.Status = 'Active'
                ORDER BY tn.MoveInDate ASC, t.LastName ASC, t.FirstName ASC;";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                cmd.Parameters.Add("@ps", SqlDbType.Date).Value =
                    _currentPeriodStart.HasValue ? (object)_currentPeriodStart.Value : DBNull.Value;
                cmd.Parameters.Add("@pe", SqlDbType.Date).Value =
                    _currentPeriodEnd.HasValue ? (object)_currentPeriodEnd.Value : DBNull.Value;

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) da.Fill(dt);

                _tenants = dt;
                dgvTenantPayments.DataSource = dt;
            }
        }
        // NEW (Billing v2): colours per category, derived Status, button caption
        private void dgvTenantPayments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRowView row = dgvTenantPayments.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            decimal owed = ToDec(row["Outstanding"]);
            decimal overdue = ToDec(row["Overdue"]);
            decimal credit = ToDec(row["Advance"]);

            if (e.ColumnIndex == colRent.Index)
            {
                e.CellStyle.ForeColor = ToDec(row["RentOwed"]) > 0m ? Color.DarkOrange : Color.Black;
            }
            else if (e.ColumnIndex == colWater.Index)
            {
                e.CellStyle.ForeColor = ToDec(row["WaterOwed"]) > 0m ? Color.DarkOrange : Color.Black;
            }
            else if (e.ColumnIndex == colMaintenance.Index)
            {
                e.CellStyle.ForeColor = ToDec(row["MaintenanceOwed"]) > 0m ? Color.DarkOrange : Color.Black;
            }
            else if (e.ColumnIndex == colOutstanding.Index)
            {
                e.CellStyle.ForeColor = overdue > 0m ? Color.Crimson
                                      : owed > 0m ? Color.DarkOrange
                                      : Color.Black;
            }
            else if (e.ColumnIndex == colCredits.Index)
            {
                e.CellStyle.ForeColor = credit > 0m ? Color.SeaGreen : Color.Black;
            }
            else if (e.ColumnIndex == colStatus.Index)
            {
                // Not stored anywhere - worked out from the balances every time.
                string status = TenantStatus(owed, overdue, credit);
                e.Value = status;
                e.CellStyle.ForeColor = status == "Overdue" ? Color.Crimson
                                      : status == "Unpaid" ? Color.DarkOrange
                                      : status == "Advance" ? Color.SeaGreen
                                      : Color.Black;
                e.FormattingApplied = true;
            }
            else if (e.ColumnIndex == colPayment.Index)
            {
                e.Value = owed > 0m ? "Make Payment" : "Pay Advance";
            }
        }

        /// <summary>
        /// NEW (Billing v2). Checked in this order:
        /// owes past the due date -> Overdue; owes -> Unpaid;
        /// owes nothing but has credit -> Advance; otherwise Paid.
        /// </summary>
        private static string TenantStatus(decimal owed, decimal overdue, decimal credit)
        {
            if (overdue > 0m) return "Overdue";
            if (owed > 0m) return "Unpaid";
            if (credit > 0m) return "Advance";
            return "Paid";
        }

        /* ORIG
        // Per-row button caption and balance color
        private void dgvTenantPayments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRowView row = dgvTenantPayments.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            if (e.ColumnIndex == colShare.Index || e.ColumnIndex == colPaid.Index)
            {
                if (row["PeriodShare"] == DBNull.Value)
                {
                    e.Value = e.ColumnIndex == colShare.Index ? "Not billed" : "-";
                    e.CellStyle.ForeColor = Color.Gray;
                    e.FormattingApplied = true;
                }
            }
            else if (e.ColumnIndex == colOutstanding.Index)
            {
                decimal owed = ToDec(row["Outstanding"]);
                decimal late = ToDec(row["Overdue"]);

                e.CellStyle.ForeColor = late > 0m ? Color.Crimson
                                      : owed > 0m ? Color.DarkOrange
                                      : Color.Black;
            }
            else if (e.ColumnIndex == colMaintenance.Index)
            {
                e.CellStyle.ForeColor = ToDec(row["MaintenanceOwed"]) > 0m ? Color.DarkOrange : Color.Black;
            }
            else if (e.ColumnIndex == colAdvance.Index)
            {
                e.CellStyle.ForeColor = ToDec(row["Advance"]) > 0m ? Color.SeaGreen : Color.Black;
            }
            else if (e.ColumnIndex == colPayment.Index)
            {
                // Keyed on everything owed, not just this period, so an
                // unpaid older period can still be collected from here.
                e.Value = ToDec(row["Outstanding"]) > 0m ? "Make Payment" : "Pay Advance";
            }
        }

        /* =================================================================
           SUMMARY TILES AND HEADER STATUS

           Computed from the grid's own rows, so the tiles are always the
           column totals - they cannot disagree with the table under them.
           ================================================================= */

        private void UpdateSummary()
        {
            decimal periodBill = 0m, periodPaid = 0m, outstanding = 0m, overdue = 0m;
            int tenantCount = 0;

            // NEW (Step 5 fix): this period's late amount and earliest unpaid due date
            decimal periodLate = 0m;
            DateTime? periodNextDue = null;

            if (_tenants != null)
            {
                foreach (DataRow r in _tenants.Rows)
                {
                    tenantCount++;

                    if (r["PeriodShare"] != DBNull.Value)
                    {
                        periodBill += ToDec(r["PeriodShare"]);
                        periodPaid += ToDec(r["PeriodPaid"]);

                        // NEW (Step 5 fix)
                        periodLate += ToDec(r["PeriodOverdue"]);
                        if (r["PeriodNextDue"] != DBNull.Value)
                        {
                            DateTime d = Convert.ToDateTime(r["PeriodNextDue"]);
                            if (!periodNextDue.HasValue || d < periodNextDue.Value) periodNextDue = d;
                        }
                    }

                    outstanding += ToDec(r["Outstanding"]);
                    overdue += ToDec(r["Overdue"]);
                }
            }

            lblPeriodBillValue.Text = periodBill.ToString("N2");
            lblPeriodPaidValue.Text = periodPaid.ToString("N2");
            lblOutstandingValue.Text = outstanding.ToString("N2");
            lblOverdueValue.Text = overdue.ToString("N2");

            lblOutstandingValue.ForeColor = outstanding > 0m ? Color.Gold : Color.White;
            lblOverdueValue.ForeColor = overdue > 0m ? Color.Tomato : Color.White;

            if (tenantCount == 0)
            {
                lblBillStatusValue.Text = "No current tenants";
                lblBillStatusValue.ForeColor = Color.Gainsboro;
                //ORIG lblTenantsCaption.Text = "Nobody lives in this room right now.";
                return;
            }

            //ORIG lblTenantsCaption.Text =
            //ORIG    "Current tenants  -  double-click a tenant to see their full bill history";

            if (_currentBillId <= 0 || !_currentDueDate.HasValue)
            {
                // ORIGINAL: lblBillStatusValue.Text = "No bill yet";
                // NEW (fix 2): say when the first bill comes and how much it is.
                lblBillStatusValue.Text = _firstBillDate.HasValue
                    ? $"First bill: {_firstBillDate.Value:MMM d, yyyy}   |   ₱{_firstBillPrice:N2}"
                    : "No bill yet";
                lblBillStatusValue.ForeColor = Color.Gainsboro;
                return;
            }

            if (periodBill == 0m)
            {
                // Everyone here joined after the latest bill was generated.
                lblBillStatusValue.Text = "Not billed this period";
                lblBillStatusValue.ForeColor = Color.Gainsboro;
                return;
            }

            string status = periodBill - periodPaid <= 0m ? "Paid"
                          : periodLate > 0m ? "Overdue"
                          : periodPaid > 0m ? "Partial"
                          : "Unpaid";
            DateTime dueShown = periodNextDue ?? _currentDueDate.Value;

            lblBillStatusValue.Text = $"Due {dueShown:MMM d, yyyy}   |   {status}";
            lblBillStatusValue.ForeColor = StatusColor(status);
        }


        /// <summary>
        /// Derived, never stored - Bills.Status no longer exists. Same rule
        /// as the tenant's Billing Summary so the two screens use one
        /// vocabulary.
        /// </summary>
        private static string BillStatus(decimal outstanding, decimal paid, DateTime dueDate)
        {
            if (outstanding <= 0m) return "Paid";
            if (dueDate.Date < DateTime.Today) return "Overdue";
            if (paid > 0m) return "Partial";
            return "Unpaid";
        }

        private static Color StatusColor(string status)
        {
            switch (status)
            {
                case "Paid": return Color.Chartreuse;
                case "Overdue": return Color.Tomato;
                case "Partial": return Color.Gold;
                default: return Color.White;
            }
        }



        private void dgvTenantPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colPayment.Index) return;

            DataRowView row = dgvTenantPayments.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            int tenantId = Convert.ToInt32(row["TenantId"]);

            // The payment form takes room and tenant, not a bill: it applies
            // the money to the tenant's oldest unpaid share first and holds
            // any excess as credit for the next bill.

            // ORIGINAL: using (BillingPaymentForm pay = new BillingPaymentForm(_roomId, tenantId))
            using (RevisedBillingPaymentForm pay = new RevisedBillingPaymentForm(_roomId, tenantId))   // NEW (Billing v2)
            {
                if (pay.ShowDialog(this.FindForm()) == DialogResult.OK)
                    LoadBilling();
            }
        }

        private void dgvTenantPayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // The button column has its own action; a double-click there must
            // not also open the history.
            if (e.RowIndex < 0 || e.ColumnIndex == colPayment.Index) return;

            DataRowView row = dgvTenantPayments.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            using (TenantBillingForm history = new TenantBillingForm(Convert.ToInt32(row["TenantId"])))
                history.ShowDialog(this.FindForm());
        }

        /* =================================================================
          NAVIGATION
          ================================================================= */

        /// <summary>
        /// The room grid was hidden, not disposed, when this opened - so it
        /// is still here to show. It is reloaded on the way back because a
        /// payment taken here may have turned its card from red to green.
        /// </summary>

        private void btnBackRoomBilling_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            if (parent == null) return;

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is BillingRoomAccountControl account)
                {
                    account.Show();
                    account.BringToFront();
                    account.LoadRooms();
                    break;
                }
            }

            parent.Controls.Remove(this);
            this.Dispose();
        }

        /* ================================================================= */

        private static decimal ToDec(object value)
        {
            return (value == null || value == DBNull.Value) ? 0m : Convert.ToDecimal(value);
        }

        /// <summary>
        /// NEW (Billing v2): lists the room's billing periods (newest first);
        /// picking one opens that period's Statement of Account.
        /// </summary>
        private void btnGenerateStatment_Click(object sender, EventArgs e)
        {
            List<StatementPeriod> periods;
            try
            {
                periods = RoomStatementService.GetPeriods(_roomId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load this room's billing periods.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (periods.Count == 0)
            {
                // ORIGINAL: MessageBox.Show("This room has no billing periods yet.", "Statement",
                //               MessageBoxButtons.OK, MessageBoxIcon.Information);
                // NEW (fix 2): also say when the first bill comes.
                string msg = "This room has no billing periods yet.";
                if (_firstBillDate.HasValue)
                    msg += $"\n\nFirst bill: {_firstBillDate.Value:MMM d, yyyy} (₱{_firstBillPrice:N2}).";
                MessageBox.Show(msg, "Statement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _periodMenu.Items.Clear();
            DateTime today = DateTime.Today;

            // NEW (fix 5): "All periods" first - every period up to now on one
            // statement (several pages if needed). Picking a month still works
            // exactly as before.
            StatementPeriod all = RoomStatementService.AllPeriods(periods);
            if (all != null)
            {
                ToolStripItem allItem = _periodMenu.Items.Add(
                    $"All periods  ({all.Start:MMM d, yyyy} - {all.LastDay:MMM d, yyyy})");
                allItem.Font = new Font(allItem.Font, FontStyle.Bold);
                allItem.Click += (s, a) => ShowStatement(all);
                _periodMenu.Items.Add(new ToolStripSeparator());
            }

            foreach (StatementPeriod p in periods)
            {
                string label = $"{p.Start:MMM d, yyyy} - {p.LastDay:MMM d, yyyy}";
                if (p.Start > today) label += "  (upcoming)";
                else if (today < p.End) label += "  (current)";

                ToolStripItem item = _periodMenu.Items.Add(label);
                item.Click += (s, a) => ShowStatement(p);
            }

            // Opens just below the button.
            _periodMenu.Show(btnGenerateStatment, new Point(0, btnGenerateStatment.Height));
        }
        /// <summary>NEW (Billing v2): builds the statement and opens the print preview.</summary>
        private void ShowStatement(StatementPeriod period)
        {
            try
            {
                RoomStatement st = RoomStatementService.Load(_roomId, period);
                RoomStatementPrinter.ShowPreview(this.FindForm(), st);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not generate the statement.\n\n" + ex.Message, "Statement",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}