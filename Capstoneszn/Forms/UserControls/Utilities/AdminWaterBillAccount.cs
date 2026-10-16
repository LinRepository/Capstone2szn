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

namespace Capstoneszn.Forms.UserControls.Utilities
{
    public partial class AdminWaterBillAccount : UserControl
    {
        private const string AccountName = "Owner (Landlord)";   // static, not stored

        public int WaterBillId { get; private set; }
        public DateTime SelectedDate { get; set; } = DateTime.Today;

        private decimal _ownerShare;
        private bool _isPaid;
        private DateTime? _paidDate;

        private DateTime MonthStart => new DateTime(SelectedDate.Year, SelectedDate.Month, 1);
        public AdminWaterBillAccount()
        {
            InitializeComponent();
        }
        public void LoadAccount()
        {
            // Reset first, so a failed or empty load never shows last month's numbers
            lblAccountName.Text = AccountName;
            lblAmount.Text = "—";
            lblStatus.Text = "No bill yet";
            WaterBillId = 0;
            _ownerShare = 0m;
            _isPaid = false;
            _paidDate = null;

            const string sql = @"
                SELECT WaterBillId, AdminAmount, AdminStatus, AdminPaidDate
                FROM   dbo.WaterBills
                WHERE  BillingMonth = @MonthStart;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@MonthStart", SqlDbType.Date).Value = MonthStart;

                using SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read()) return;   // no bill this month → stays "No bill yet"

                WaterBillId = dr.GetInt32(0);
                _ownerShare = dr.GetDecimal(1);
                _isPaid = dr.GetString(2) == "Paid";
                _paidDate = dr.IsDBNull(3) ? null : dr.GetDateTime(3);

                lblAmount.Text = _ownerShare.ToString("₱#,##0.00");
                lblStatus.Text = _isPaid ? $"Paid ({_paidDate:MMM d, yyyy})"
                               : _ownerShare <= 0 ? "No share"
                                                  : "Unpaid";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading water account: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRecordWaterExpense_Click(object sender, EventArgs e)
        {
            if (WaterBillId == 0)
            {
                MessageBox.Show($"There's no water bill for {MonthStart:MMMM yyyy} yet. Add one first.",
                    "No bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isPaid)
            {
                MessageBox.Show(
                    $"The owner's water share for {MonthStart:MMMM yyyy} is already paid.\n\n" +
                    "Paid bills are locked and can't be changed.",
                    "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_ownerShare <= 0)
            {
                MessageBox.Show("The owner's share for this month is ₱0.00, so there's nothing to record.",
                    "Nothing to pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Record the owner's water payment for {MonthStart:MMMM yyyy}?\n\n" +
                $"Amount: ₱{_ownerShare:#,##0.00}  (exact amount only)\n\n" +
                "Once recorded, this bill is LOCKED:\n" +
                "  • the bill can no longer be edited\n" +
                "  • the status can't be changed back to Unpaid",
                "Confirm payment",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes) return;

            const string sql = @"
                UPDATE dbo.WaterBills
                   SET AdminStatus = 'Paid', AdminPaidDate = @Today
                 WHERE WaterBillId = @Id
                   AND AdminStatus = 'Unpaid';";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = WaterBillId;
                cmd.Parameters.Add("@Today", SqlDbType.Date).Value = DateTime.Today;

                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("This bill was already marked paid.", "Already paid",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error recording payment: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadAccount();
        }
    }
}
