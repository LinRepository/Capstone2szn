using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.PaymentsForms
{
    /// <summary>
    /// The Maintenance context panel inside BillingPaymentForm.
    ///
    /// Settled rules for maintenance payments:
    ///   - Full only: no partial, no advance.
    ///   - Never Whole Room: each affected tenant pays their own share.
    ///   - One payment clears EVERYTHING the tenant owes for maintenance,
    ///     even across several issues.
    /// BillingHelper.RecordPayment enforces the same rules when saving;
    /// this panel only shows them.
    ///
    /// Figures come from BillingHelper (same queries as the allocation
    /// engine), so what this panel shows is what the payment will do.
    /// </summary>
    /// 

    public partial class MaintenanceControlBilling : UserControl, ICategoryBilling
    {
        private const string MaintenanceCategory = BillingHelper.MaintenanceCategory;

        private readonly int _roomId;
        private readonly int _tenantId;

        /// <summary>One unpaid maintenance share of this tenant.</summary>
        private class UnpaidShare
        {
            public int BillId;
            public string IssueTitle;
            public DateTime DateReported;
            public decimal MaterialsTotal;   // the whole bill
            public decimal Share;            // this tenant's part
            public decimal Owing;            // share minus anything paid
            public DateTime DueDate;
        }

        private readonly List<UnpaidShare> _unpaid = new List<UnpaidShare>();

        /* ---- ICategoryBilling -------------------------------------------- */

        /// <summary>The oldest unpaid maintenance bill, or -1 if none.</summary>
        public int BillId { get; private set; } = -1;

        /// <summary>Everything this tenant owes for maintenance (current stay).</summary>
        public decimal Outstanding { get; private set; }

        /// <summary>Always zero or negative: maintenance has no advance credit.</summary>
        public decimal Balance { get; private set; }

        public string TenantName { get; private set; } = "";

        public bool CoversRoom => false;                 // never Whole Room
        public decimal RoomOutstanding => Outstanding;
        public decimal OwedForMode => Outstanding;
        public int RoomTenantCount => 1;

        // No Individual / Whole Room switch on this panel, so it never fires.
        public event EventHandler ContextChanged { add { } remove { } }

        public void SetPreviewAmount(decimal amount) { }

        public List<KeyValuePair<int, decimal>> WholeRoomSplit(decimal amount) =>
            new List<KeyValuePair<int, decimal>> { new KeyValuePair<int, decimal>(_tenantId, amount) };

        public string NameOf(int tenantId) => TenantName;

        public decimal ShareOf(decimal amount) => amount;

        /* ---- Construction ------------------------------------------------ */

        // Required by the designer only.
        public MaintenanceControlBilling()
        {
            InitializeComponent();
        }

        public MaintenanceControlBilling(int roomId, int tenantId)
        {
            InitializeComponent();
            _roomId = roomId;
            _tenantId = tenantId;
            LoadData();
        }

        private void LoadData()
        {
            string roomNumber = "-";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(
                        "SELECT RoomNumber FROM Rooms WHERE RoomId = @rid;", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _roomId);
                        roomNumber = cmd.ExecuteScalar()?.ToString() ?? "-";
                    }

                    using (var cmd = new SqlCommand(
                        "SELECT FirstName + ' ' + LastName FROM Tenants WHERE TenantId = @tid;", conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", _tenantId);
                        TenantName = cmd.ExecuteScalar()?.ToString() ?? "-";
                    }

                    // Unpaid maintenance shares, oldest first - the same
                    // filters BillingHelper uses (current stay, voids ignored).
                    string sql = @"
                        SELECT x.BillId, x.IssueTitle, x.DateReported, x.Amount,
                               x.Share, x.Share - x.Paid AS Owing, x.DueDate
                        FROM (
                            SELECT b.BillId, mi.IssueTitle, mi.DateReported, b.Amount,
                                   b.DueDate, b.BillingPeriodStart, bt.Share,
                                   ISNULL((SELECT SUM(a.Amount)
                                           FROM   PaymentAllocations a
                                           JOIN   Payments p ON p.PaymentId = a.PaymentId
                                           WHERE  a.BillId   = bt.BillId
                                             AND  a.TenantId = bt.TenantId
                                             AND  a.IsVoided = 0
                                             AND  p.IsVoided = 0), 0) AS Paid
                            FROM   BillTenants bt
                            JOIN   Bills b              ON b.BillId = bt.BillId
                            JOIN   MaintenanceIssues mi ON mi.IssueId = b.MaintenanceIssueId
                            JOIN   Tenancies tn         ON tn.TenantId = bt.TenantId
                                                       AND tn.Status   = 'Active'
                            WHERE  bt.TenantId = @tid
                              AND  b.BillCategory = @cat
                              AND  b.BillingPeriodStart >= tn.MoveInDate
                        ) x
                        WHERE x.Share - x.Paid > 0
                        ORDER BY x.BillingPeriodStart ASC, x.BillId ASC;";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", _tenantId);
                        cmd.Parameters.AddWithValue("@cat", MaintenanceCategory);
                        using (var rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                _unpaid.Add(new UnpaidShare
                                {
                                    BillId = rd.GetInt32(0),
                                    IssueTitle = rd.GetString(1),
                                    DateReported = rd.GetDateTime(2),
                                    MaterialsTotal = rd.GetDecimal(3),
                                    Share = rd.GetDecimal(4),
                                    Owing = rd.GetDecimal(5),
                                    DueDate = rd.GetDateTime(6)
                                });
                            }
                        }
                    }

                    Outstanding = BillingHelper.GetTotalOutstanding(conn, _tenantId, MaintenanceCategory);
                    Balance = -Outstanding;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load maintenance details: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            BillId = _unpaid.Count > 0 ? _unpaid[0].BillId : -1;
            DisplayData(roomNumber);
        }

        private void DisplayData(string roomNumber)
        {
            lblRoomValue.Text = roomNumber;
            lblTenantValue.Text = TenantName;
            lblOutstandingValue.Text = "PHP " + Outstanding.ToString("N2");
            lblOutstandingValue.ForeColor = Outstanding > 0m ? Color.Salmon : Color.White;

            if (_unpaid.Count == 0)
            {
                lblIssueValue.Text = "-";
                lblDateValue.Text = "-";
                lblMaterialCostValue.Text = "-";
                lblShareValue.Text = "-";
                lblStatusValue.Text = "Paid";
                lblStatusValue.ForeColor = Color.PaleGreen;
                lblDescription1.Text = "No unpaid maintenance for this tenant.";
                lblDescription2.Text = "";
                return;
            }

            bool overdue = _unpaid.Any(u => u.DueDate < DateTime.Today);
            lblStatusValue.Text = overdue ? "Overdue" : "Unpaid";
            lblStatusValue.ForeColor = overdue ? Color.Salmon : Color.White;

            if (_unpaid.Count == 1)
            {
                UnpaidShare u = _unpaid[0];
                lblIssueValue.Text = u.IssueTitle;
                lblDateValue.Text = u.DateReported.ToString("MMM dd, yyyy");
                lblMaterialCostValue.Text = "PHP " + u.MaterialsTotal.ToString("N2");
                lblShareValue.Text = "PHP " + u.Share.ToString("N2");
                lblDescription1.Text = "Due " + u.DueDate.ToString("MMM dd, yyyy") + ".";
            }
            else
            {
                // Several issues: one payment clears them all, so show totals.
                lblIssueValue.Text = _unpaid.Count + " issues";
                lblDateValue.Text = _unpaid.First().DateReported.ToString("MMM dd") + " - " +
                                    _unpaid.Last().DateReported.ToString("MMM dd, yyyy");
                lblMaterialCostValue.Text = "PHP " + _unpaid.Sum(u => u.MaterialsTotal).ToString("N2");
                lblShareValue.Text = "PHP " + _unpaid.Sum(u => u.Share).ToString("N2");
                lblDescription1.Text = Shorten(string.Join(", ", _unpaid.Select(u => u.IssueTitle)), 70);
            }

            lblDescription2.Text = "Full payment only - this pays all maintenance this tenant owes.";
        }

        private static string Shorten(string text, int max) =>
            text.Length <= max ? text : text.Substring(0, max - 3) + "...";
    }
}
