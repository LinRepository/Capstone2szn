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
        public int AccountId { get; private set; }
        public int WaterBillId { get; private set; }
        public DateTime SelectedDate { get; set; } = DateTime.Today;

        private decimal _ownerShare;
        private decimal _paidSoFar;
        public AdminWaterBillAccount()
        {
            InitializeComponent();
        }
        public void LoadAccount()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT AccountID, AccountName
                           FROM dbo.UtilityAccounts
                           WHERE BuildingID  = @BuildingId
                             AND UtilityType = 'Water'
                             AND IsActive    = 1;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                AccountId = Convert.ToInt32(dr["AccountID"]);
                                lblAccountName.Text = dr["AccountName"].ToString();
                            }
                            else
                            {
                                AccountId = 0;
                                lblAccountName.Text = "No water account set up";
                            }
                        }
                    }

                    LoadBillForMonth(conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading water account: " + ex.Message);
                }
            }
        }
        private void LoadBillForMonth(SqlConnection conn)
        {
            string sql = @"SELECT TOP 1
                       wb.WaterBillID,
                       wb.TotalAmount - ISNULL((SELECT SUM(c.Amount)
                                                FROM dbo.TenantWaterCharges c
                                                WHERE c.WaterBillID = wb.WaterBillID), 0) AS OwnerShare,
                       ISNULL((SELECT SUM(e.Amount)
                               FROM dbo.Expenses e
                               WHERE e.RefTable = 'WaterBills'
                                 AND e.RefID    = wb.WaterBillID), 0) AS PaidSoFar
                   FROM dbo.WaterBills wb
                   WHERE wb.BuildingID = @BuildingId
                     AND YEAR(wb.BillingPeriodEnd)  = YEAR(@PickedDate)
                     AND MONTH(wb.BillingPeriodEnd) = MONTH(@PickedDate)
                   ORDER BY wb.BillingPeriodEnd DESC;";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);
                cmd.Parameters.AddWithValue("@PickedDate", SelectedDate.Date);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        WaterBillId = Convert.ToInt32(dr["WaterBillID"]);
                        _ownerShare = Convert.ToDecimal(dr["OwnerShare"]);
                        _paidSoFar = Convert.ToDecimal(dr["PaidSoFar"]);

                        lblAmount.Text = _ownerShare.ToString("₱#,##0.00");
                        lblStatus.Text = _paidSoFar > 0 ? "Paid" : "Unpaid";
                    }
                    else
                    {
                        WaterBillId = 0;
                        _ownerShare = 0;
                        _paidSoFar = 0;
                        lblAmount.Text = "—";
                        lblStatus.Text = "No bill";
                    }
                }
            }
        }

        private void btnRecordWaterExpense_Click(object sender, EventArgs e)
        {
            if (AccountId == 0)
            {
                MessageBox.Show("No owner water account is set up yet.", "No account",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (WaterBillId == 0)
            {
                MessageBox.Show($"There's no water bill for {SelectedDate:MMMM yyyy} yet. Add one first.",
                    "No bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_paidSoFar > 0)
            {
                MessageBox.Show(
                    $"The owner's water share for {SelectedDate:MMMM yyyy} is already fully paid.\n\n" +
                    "Paid bills are locked and can't be recorded again.",
                    "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var rwef = new RecordWaterExpenseForm(WaterBillId, _ownerShare);

            if (rwef.ShowDialog(this) == DialogResult.OK)
                LoadAccount();
        }
    }
}
