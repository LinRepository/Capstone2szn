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


        public BillingRoomDetailsControl(int roomId)
        {
            InitializeComponent();

            _roomId = roomId;

            // Columns are defined in the designer; never let the grid add
            // its own from the query (TenantId, Overdue stay hidden that way).
            dgvTenantPayments.AutoGenerateColumns = false;

            foreach (DataGridViewColumn col in new[] { colShare, colPaid, colMaintenance, colOutstanding, colAdvance })
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
            lblPeriodValue.Text = "No bill yet";

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT TOP 1 BillId, BillingPeriodStart, BillingPeriodEnd, DueDate
                FROM   Bills
                WHERE  RoomId = @rid
                  AND  BillCategory = @cat
                ORDER BY BillingPeriodStart DESC;", conn))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                cmd.Parameters.Add("@cat", SqlDbType.VarChar, 30).Value = RentCategory;

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return;

                    _currentBillId = rd.GetInt32(0);
                    DateTime start = rd.GetDateTime(1);
                    DateTime end = rd.GetDateTime(2);
                    _currentDueDate = rd.GetDateTime(3);

                    lblPeriodValue.Text = $"{start:MMM d} - {end:MMM d, yyyy}";
                }
            }
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
                       t.FirstName + ' ' + t.LastName AS TenantName,
                       cur.Share                       AS PeriodShare,
                       cur.Paid                        AS PeriodPaid,
                       ISNULL(debt.Outstanding, 0)     AS Outstanding,
                       ISNULL(debt.Overdue, 0)         AS Overdue,
                       ISNULL(debt.MaintOwed, 0)       AS MaintenanceOwed,
                       ISNULL(cred.Held, 0)
                     - ISNULL(forf.Forfeited, 0)       AS Advance
                FROM   Tenancies tn
                JOIN   Tenants t ON t.TenantId = tn.TenantId

                OUTER APPLY (
                    SELECT bt.Share,
                           ISNULL((SELECT SUM(a.Amount)
                                   FROM   PaymentAllocations a
                                   JOIN   Payments p ON p.PaymentId = a.PaymentId
                                   WHERE  a.BillId   = bt.BillId
                                     AND  a.TenantId = bt.TenantId
                                     AND  a.IsVoided = 0
                                     AND  p.IsVoided = 0), 0) AS Paid
                    FROM   BillTenants bt
                    WHERE  bt.BillId   = @bid
                      AND  bt.TenantId = t.TenantId
                ) cur

                OUTER APPLY (
                    SELECT SUM(x.Unpaid) AS Outstanding,
                           SUM(CASE WHEN x.DueDate < CAST(GETDATE() AS DATE)
                                    THEN x.Unpaid ELSE 0 END) AS Overdue,
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
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = _currentBillId;

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) da.Fill(dt);

                _tenants = dt;
                dgvTenantPayments.DataSource = dt;
            }
        }

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

            if (_tenants != null)
            {
                foreach (DataRow r in _tenants.Rows)
                {
                    tenantCount++;

                    if (r["PeriodShare"] != DBNull.Value)
                    {
                        periodBill += ToDec(r["PeriodShare"]);
                        periodPaid += ToDec(r["PeriodPaid"]);
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
                lblTenantsCaption.Text = "Nobody lives in this room right now.";
                return;
            }

            lblTenantsCaption.Text =
                "Current tenants  -  double-click a tenant to see their full bill history";

            if (_currentBillId <= 0 || !_currentDueDate.HasValue)
            {
                lblBillStatusValue.Text = "No bill yet";
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

            string status = BillStatus(periodBill - periodPaid, periodPaid, _currentDueDate.Value);

            lblBillStatusValue.Text = $"Due {_currentDueDate.Value:MMM d, yyyy}   |   {status}";
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
            using (BillingPaymentForm pay = new BillingPaymentForm(_roomId, tenantId))
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
    }
}
