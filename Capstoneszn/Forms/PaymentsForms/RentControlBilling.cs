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
    /// choice. The form reads BillId, Outstanding and CoversRoom off it.
    /// </summary>
    /// 
    public partial class RentControlBilling : UserControl
    {

        private int _roomId;
        private int _tenantId;

        // What the form needs back
        public int BillId { get; private set; } = -1;
        public decimal TenantShare { get; private set; }
        public decimal Outstanding { get; private set; }
        public decimal Balance { get; private set; }
        public string TenantName { get; private set; } = "";
        public bool HasPriorPayment { get; private set; }

        public bool CoversRoom => RadioBtnRoom.Checked;

        /// <summary>Raised when the Individual / Whole Room choice changes.</summary>
        public event EventHandler ContextChanged;

        private List<string> _roomTenantNames = new List<string>();
        private int _firstTenantId = -1;

        public RentControlBilling(int roomId, int tenantId)
        {
            InitializeComponent();

            _roomId = roomId;
            _tenantId = tenantId;

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
                        lblRoomValue.Text = rn == null ? "-" : rn.ToString();
                    }

                    // Tenant name
                    using (var cmd = new SqlCommand(
                        @"SELECT FirstName + ' ' + LastName FROM Tenants
                          WHERE TenantId = @tid", conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", _tenantId);
                        object n = cmd.ExecuteScalar();
                        TenantName = n == null ? "-" : n.ToString();
                        lblTenantValue.Text = TenantName;
                    }

                    // Current rent bill for this room
                    using (var cmd = new SqlCommand(@"
                        SELECT TOP 1 BillId, BillingPeriodStart, BillingPeriodEnd
                        FROM Bills
                        WHERE RoomId = @rid AND BillCategory = 'Rent'
                        ORDER BY BillingPeriodStart DESC;", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _roomId);
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

                    // Share for this period
                    if (BillId > 0)
                    {
                        using (var cmd = new SqlCommand(
                            @"SELECT Share FROM BillTenants
                              WHERE BillId = @bid AND TenantId = @tid", conn))
                        {
                            cmd.Parameters.AddWithValue("@bid", BillId);
                            cmd.Parameters.AddWithValue("@tid", _tenantId);
                            object s = cmd.ExecuteScalar();
                            TenantShare = (s == null || s == DBNull.Value)
                                ? 0m : Convert.ToDecimal(s);
                        }

                        Outstanding = BillingHelper.GetOutstanding(conn, BillId, _tenantId);
                    }

                    Balance = BillingHelper.GetBalance(conn, _tenantId, "Rent");

                    // Anything already allocated to this tenant on this bill?
                    HasPriorPayment = (TenantShare - Outstanding) > 0;

                    // Who else is in the room, for the Whole Room breakdown.
                    // Read once - the room cannot change while this dialog is open.
                    _roomTenantNames.Clear();
                    _firstTenantId = -1;
                    using (var cmd = new SqlCommand(
                        @"SELECT TenantId,
                                 ISNULL(FirstName,'') + ' ' + ISNULL(LastName,'')
                          FROM Tenants
                          WHERE RoomId = @rid AND Status = 'Active' AND IsArchived = 0
                          ORDER BY TenantId;", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _roomId);
                        using (var rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                if (_firstTenantId < 0) _firstTenantId = rd.GetInt32(0);
                                _roomTenantNames.Add(rd.GetString(1).Trim());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load rent details: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            lblShareValue.Text = TenantShare.ToString("N2");
            lblOutstandingValue.Text = Outstanding.ToString("N2");

            lblBalanceValue.Text = Balance.ToString("N2");
            lblBalanceValue.ForeColor = Balance < 0 ? Color.Salmon
                                      : Balance > 0 ? Color.PaleGreen
                                      : Color.White;

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
        /// 


        public void SetPreviewAmount(decimal amount)
        {
            if (!CoversRoom)
            {
                lblDescription1.Text = "Credited to " + TenantName + " only";
                lblDescription2.Text = "Share this period: PHP " + TenantShare.ToString("N2");
                return;
            }

            int n = _roomTenantNames.Count;
            if (n == 0)
            {
                lblDescription1.Text = "No active tenants in this room";
                lblDescription2.Text = "";
                return;
            }

            if (amount <= 0)
            {
                lblDescription1.Text = "Split equally across " + n + " tenant(s)";
            }
            else
            {
                decimal each = Math.Floor(amount / n * 100m) / 100m;
                lblDescription1.Text = "PHP " + amount.ToString("N2") + " / " + n +
                                       " = PHP " + each.ToString("N2") + " each";
            }

            lblDescription2.Text = "Credits: " + string.Join(", ", _roomTenantNames);
        }


        /// <summary>How much of a payment lands on THIS tenant.</summary>
        public decimal ShareOf(decimal amount)
        {
            if (!CoversRoom) return amount;

            int n = _roomTenantNames.Count;
            if (n == 0) return 0m;

            decimal each = Math.Floor(amount / n * 100m) / 100m;
            decimal remainder = amount - (each * n);

            // The engine orders by TenantId and gives the rounding
            // remainder to the lowest id, so mirror that here
            return _tenantId == _firstTenantId ? each + remainder : each;
        }   

        private void RadioBtnIndividualTenant_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioBtnRoom_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
