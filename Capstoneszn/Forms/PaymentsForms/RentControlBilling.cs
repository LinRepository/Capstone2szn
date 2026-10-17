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
    /// The Rent context panel inside BillingPaymentForm.
    /// Shows what this tenant owes, and carries the Individual / Whole Room
    /// choice. The form reads BillId, Outstanding, Balance and CoversRoom
    /// off it.
    ///
    /// Every money figure here comes from BillingHelper - the same queries
    /// the allocation engine uses. That is the point: what this panel says
    /// a payment will do and what BillingHelper.RecordPayment actually does
    /// can then never disagree.
    /// </summary>
    /// 
    public partial class RentControlBilling : UserControl, ICategoryBilling
    {
        private const string RentCategory = "Rent";

        private int _roomId;
        private int _tenantId;

        // What the form needs back

        /// <summary>The room's current rent bill. Display only - payments are
        /// allocated oldest-first, not to this bill specifically.</summary>
        public int BillId { get; private set; } = -1;

        /// <summary>This tenant's share of the current bill (display only).</summary>
        public decimal TenantShare { get; private set; }

        /// <summary>
        /// Everything this tenant owes across every period of their current
        /// stay. NOT just the current bill: the engine pays the oldest share
        /// first, so a figure for the current bill alone would tell the
        /// landlord a payment settles everything when it only clears an
        /// older month.
        /// </summary>
        public decimal Outstanding { get; private set; }

        /// <summary>Credit available minus Outstanding. Positive = paid ahead.</summary>
        public decimal Balance { get; private set; }

        public string TenantName { get; private set; } = "";

        /// <summary>
        /// Whether the share this payment will land on first - the oldest
        /// unpaid one - already has money against it. Drives the Down
        /// Payment / Partial Payment suggestion.
        /// </summary>
        public bool HasPriorPayment { get; private set; }

        public bool CoversRoom => RadioBtnRoom.Checked;

        /// <summary>What every active tenant of the room owes together.</summary>
        public decimal RoomOutstanding { get; private set; }

        /// <summary>
        /// What this payment is measured against: the room's total for a
        /// Whole Room payment, this tenant's own total otherwise.
        /// </summary>
        public decimal OwedForMode => CoversRoom ? RoomOutstanding : Outstanding;

        public int RoomTenantCount => _roomOwing.Count;

        /// <summary>Raised when the Individual / Whole Room choice changes.</summary>
        public event EventHandler ContextChanged;

        // Each active tenant and what they owe, longest-tenured first - the
        // exact input BillingHelper.SplitWholeRoom gets when saving.
        private List<KeyValuePair<int, decimal>> _roomOwing = new List<KeyValuePair<int, decimal>>();
        private readonly Dictionary<int, string> _roomTenantNames = new Dictionary<int, string>();
        private bool _billedThisPeriod;

        public RentControlBilling(int roomId, int tenantId)
        {
            InitializeComponent();

            _roomId = roomId;
            _tenantId = tenantId;

            // Make the selected option obvious - these are button-style
            // radios, so the only cue is the background.
            Color selected = Color.FromArgb(38, 66, 112);
            RadioBtnIndividualTenant.FlatAppearance.CheckedBackColor = selected;
            RadioBtnRoom.FlatAppearance.CheckedBackColor = selected;

            RadioBtnIndividualTenant.Checked = true;
            RadioBtnIndividualTenant.CheckedChanged += Mode_Changed;
            RadioBtnRoom.CheckedChanged += Mode_Changed;

            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Room number
                    using (var cmd = new SqlCommand(
                        "SELECT RoomNumber FROM Rooms WHERE RoomId = @rid", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _roomId);
                        object rn = cmd.ExecuteScalar();
                        lblRoomValue.Text = (rn == null || rn == DBNull.Value) ? "-" : rn.ToString();
                    }

                    // Tenant name
                    using (var cmd = new SqlCommand(
                        @"SELECT FirstName + ' ' + LastName FROM Tenants
                          WHERE TenantId = @tid", conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", _tenantId);
                        object n = cmd.ExecuteScalar();
                        TenantName = (n == null || n == DBNull.Value) ? "-" : n.ToString();
                        lblTenantValue.Text = TenantName;
                    }

                    // Current rent bill for this room - shown for context
                    using (var cmd = new SqlCommand(@"
                        SELECT TOP 1 BillId, BillingPeriodStart, BillingPeriodEnd
                        FROM Bills
                        WHERE RoomId = @rid AND BillCategory = @cat
                        ORDER BY BillingPeriodStart DESC;", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _roomId);
                        cmd.Parameters.AddWithValue("@cat", RentCategory);
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                BillId = rd.GetInt32(0);
                                DateTime s = rd.GetDateTime(1);
                                DateTime e = rd.GetDateTime(2);
                                lblPeriodValue.Text =
                                    s.ToString("MMM d") + " - " + e.ToString("MMM d, yyyy");
                            }
                            else
                            {
                                lblPeriodValue.Text = "No bill yet";
                            }
                        }
                    }

                    // This tenant's share of the current bill. No row means
                    // they joined after it was generated.
                    _billedThisPeriod = false;
                    TenantShare = 0m;
                    if (BillId > 0)
                    {
                        using (var cmd = new SqlCommand(
                            @"SELECT Share FROM BillTenants
                              WHERE BillId = @bid AND TenantId = @tid", conn))
                        {
                            cmd.Parameters.AddWithValue("@bid", BillId);
                            cmd.Parameters.AddWithValue("@tid", _tenantId);
                            object s = cmd.ExecuteScalar();
                            _billedThisPeriod = s != null && s != DBNull.Value;
                            TenantShare = _billedThisPeriod ? Convert.ToDecimal(s) : 0m;
                        }
                    }

                    // The figures that drive the form - all from the engine's
                    // own queries.
                    Outstanding = BillingHelper.GetTotalOutstanding(conn, _tenantId, RentCategory);
                    Balance = BillingHelper.GetBalance(conn, _tenantId, RentCategory);
                    HasPriorPayment = BillingHelper.OldestUnpaidShareHasPayment(conn, _tenantId, RentCategory);

                    // The whole room: who lives there and what each owes.
                    // Same method the save uses, so the preview and the
                    // saved allocations cannot disagree.
                    _roomOwing = BillingHelper.GetRoomOwing(conn, _roomId, RentCategory);
                    RoomOutstanding = _roomOwing.Sum(x => x.Value);

                    _roomTenantNames.Clear();
                    using (var cmd = new SqlCommand(
                        @"SELECT t.TenantId,
                                 ISNULL(t.FirstName,'') + ' ' + ISNULL(t.LastName,'')
                          FROM   Tenancies tn
                          JOIN   Tenants t ON t.TenantId = tn.TenantId
                          WHERE  tn.RoomId = @rid
                            AND  tn.Status = 'Active';", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _roomId);
                        using (var rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                                _roomTenantNames[rd.GetInt32(0)] = rd.GetString(1).Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load rent details: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            lblShareValue.Text = (BillId > 0 && !_billedThisPeriod)
                ? "Not billed"
                : TenantShare.ToString("N2");

            lblOutstandingValue.Text = Outstanding.ToString("N2");
            lblOutstandingValue.ForeColor = Outstanding > 0 ? Color.Salmon : Color.White;

            lblBalanceValue.Text = Balance.ToString("N2");
            lblBalanceValue.ForeColor = Balance < 0 ? Color.Salmon
                                      : Balance > 0 ? Color.PaleGreen
                                      : Color.White;

            // Whole Room pays the ROOM's rent, so it is available whenever
            // anyone in the room owes - even when opened from a tenant who is
            // already paid up (they may be the one handing over the money).
            // With nothing owed in the room, an advance is taken per tenant.
            if (RoomOutstanding <= 0)
            {
                RadioBtnRoom.Enabled = false;
                RadioBtnIndividualTenant.Checked = true;
            }

            SetPreviewAmount(0m);
        }

        private void Mode_Changed(object sender, EventArgs e)
        {
            // Both radios fire, so only act on the one turning on
            if (sender is RadioButton rb && !rb.Checked) return;

            ContextChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// The form calls this as the amount is typed, so the Whole Room
        /// split shows real numbers rather than a placeholder.
        /// </summary>


        public void SetPreviewAmount(decimal amount)
        {
            if (!CoversRoom)
            {
                lblDescription1.Text = "Credited to " + TenantName + " only";
                lblDescription2.Text = Outstanding > 0
                    ? "Applied to the oldest unpaid period first"
                    : "Nothing owed - held as advance for the next bill";
                return;
            }

            if (_roomOwing.Count == 0)
            {
                lblDescription1.Text = "No active tenants in this room";
                lblDescription2.Text = "";
                return;
            }

            if (amount <= 0)
            {
                lblDescription1.Text = "Room owes PHP " + RoomOutstanding.ToString("N2") +
                                       " across " + _roomOwing.Count + " tenant(s)";
            }
            else
            {
                lblDescription1.Text = "Pays: " + string.Join(", ",
                    WholeRoomSplit(amount)
                        .Where(p => p.Value > 0m)
                        .Select(p => NameOf(p.Key) + " " + p.Value.ToString("N2")));
            }

            lblDescription2.Text = "Each tenant's debt first; any extra is advance, split equally";
        }

        /// <summary>
        /// How a Whole Room payment of this amount divides - the same
        /// method, same input and same order the save uses.
        /// </summary>
        public List<KeyValuePair<int, decimal>> WholeRoomSplit(decimal amount)
        {
            return BillingHelper.SplitWholeRoom(_roomOwing, amount);
        }

        public string NameOf(int tenantId)
        {
            return _roomTenantNames.TryGetValue(tenantId, out string name) ? name : "Tenant " + tenantId;
        }


        /// <summary>How much of a payment lands on THIS tenant.</summary>
        public decimal ShareOf(decimal amount)
        {
            if (!CoversRoom) return amount;

            foreach (var part in WholeRoomSplit(amount))
                if (part.Key == _tenantId) return part.Value;

            return 0m;
        }

        private void RadioBtnIndividualTenant_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioBtnRoom_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RentControlBilling_Load(object sender, EventArgs e)
        {

        }

        private void pnlButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
