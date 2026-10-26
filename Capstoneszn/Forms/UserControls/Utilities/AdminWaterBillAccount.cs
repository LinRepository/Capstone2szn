using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Utilities
{
    public partial class AdminWaterBillAccount : UserControl
    {
        //private const string AccountName = "Owner (Landlord)";   // static, not stored
        private const string NotSetText = "Not set yet";           // NEW

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
            //lblAccountName.Text = AccountName;
            lblAmount.Text = "—";
            lblStatus.Text = "No bill yet";
            WaterBillId = 0;
            _ownerShare = 0m;
            _isPaid = false;
            _paidDate = null;

            /*
            const string sql = @"
                SELECT WaterBillId, AdminAmount, AdminStatus, AdminPaidDate
                FROM dbo.WaterBills
                WHERE  BuildingId = @BuildingId
                  AND  BillingMonth = @MonthStart; ";
            */

            // NEW: same columns as before, plus the account the bill was recorded under
            const string sql = @"
                SELECT wb.WaterBillId, wb.AdminAmount, wb.AdminStatus, wb.AdminPaidDate,
                       wa.AccountName, wa.AccountNumber
                FROM   dbo.WaterBills wb
                LEFT JOIN dbo.WaterAccounts wa ON wa.WaterAccountId = wb.WaterAccountId
                WHERE  wb.BuildingId   = @BuildingId
                  AND  wb.BillingMonth = @MonthStart;";

            try
            {
                // NEW: default to the building's current account
                WaterAccountInfo? account = WaterAccountHelper.GetActive(Session.BuildingId);
                if (account != null)
                {
                    lblAccountName.Text = account.AccountName;
                    lblAccountNumber.Text = account.AccountNumber;
                }

                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                cmd.Parameters.Add("@MonthStart", SqlDbType.Date).Value = MonthStart;

                using SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.Read()) return;   // no bill this month → stays "No bill yet"

                WaterBillId = dr.GetInt32(0);
                _ownerShare = dr.GetDecimal(1);
                _isPaid = dr.GetString(2) == "Paid";
                _paidDate = dr.IsDBNull(3) ? null : dr.GetDateTime(3);

                // NEW: a linked bill shows the account it was billed under (history)
                if (!dr.IsDBNull(4))
                {
                    lblAccountName.Text = dr.GetString(4);
                    lblAccountNumber.Text = dr.GetString(5);
                }

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
            LoadAccount();   // read the latest state before deciding

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

            using var rwef = new RecordWaterExpenseForm(WaterBillId, _ownerShare, MonthStart);
            if (rwef.ShowDialog(this) == DialogResult.OK)
                LoadAccount();
        }
    }
}