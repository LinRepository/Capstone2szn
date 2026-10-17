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
    public partial class UtilitiesControlBilling : UserControl, ICategoryBilling
    {
        private const string WaterCategory = "Water";

        private readonly int _roomId;
        private readonly int _tenantId;

        public int BillId { get; private set; } = -1;
        public decimal Outstanding { get; private set; }
        public decimal Balance { get; private set; }
        public string TenantName { get; private set; } = "";

        // Water is split per tenant, so it's always individual
        public bool CoversRoom => false;
        public decimal RoomOutstanding => Outstanding;
        public decimal OwedForMode => Outstanding;
        public int RoomTenantCount => 1;
        public event EventHandler ContextChanged { add { } remove { } }
        public UtilitiesControlBilling()
        {
            InitializeComponent();
        }
        public UtilitiesControlBilling(int roomId, int tenantId)
        {
            InitializeComponent();
            _roomId = roomId;
            _tenantId = tenantId;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using (var cmd = new SqlCommand(
                    "SELECT RoomNumber FROM Rooms WHERE RoomId = @rid", conn))
                {
                    cmd.Parameters.AddWithValue("@rid", _roomId);
                    lblRoomValue.Text = cmd.ExecuteScalar()?.ToString() ?? "-";
                }

                using (var cmd = new SqlCommand(
                    "SELECT FirstName + ' ' + LastName FROM Tenants WHERE TenantId = @tid", conn))
                {
                    cmd.Parameters.AddWithValue("@tid", _tenantId);
                    TenantName = cmd.ExecuteScalar()?.ToString() ?? "-";
                    lblTenantValue.Text = TenantName;
                }

                using (var cmd = new SqlCommand(@"
                    SELECT TOP 1 b.BillId, b.BillingPeriodStart
                    FROM   Bills b
                    JOIN   BillTenants bt ON bt.BillId = b.BillId
                    WHERE  b.RoomId = @rid AND bt.TenantId = @tid AND b.BillCategory = @cat
                    ORDER BY b.BillingPeriodStart DESC;", conn))
                {
                    cmd.Parameters.AddWithValue("@rid", _roomId);
                    cmd.Parameters.AddWithValue("@tid", _tenantId);
                    cmd.Parameters.AddWithValue("@cat", WaterCategory);
                    using var rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        BillId = rd.GetInt32(0);
                        lblPeriodValue.Text = rd.GetDateTime(1).ToString("MMMM yyyy");
                    }
                    else
                    {
                        lblPeriodValue.Text = "No water bill yet";
                    }
                }

                Outstanding = BillingHelper.GetTotalOutstanding(conn, _tenantId, WaterCategory);
                Balance = BillingHelper.GetBalance(conn, _tenantId, WaterCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load water details: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblOutstandingValue.Text = Outstanding.ToString("N2");
            lblOutstandingValue.ForeColor = Outstanding > 0 ? Color.Salmon : Color.White;
        }
        public void SetPreviewAmount(decimal amount) { }

        public List<KeyValuePair<int, decimal>> WholeRoomSplit(decimal amount) =>
            new List<KeyValuePair<int, decimal>> { new KeyValuePair<int, decimal>(_tenantId, amount) };

        public string NameOf(int tenantId) => TenantName;

        public decimal ShareOf(decimal amount) => amount;

        private void UtilitiesControlBilling_Load(object sender, EventArgs e)
        {

        }
    }
}
