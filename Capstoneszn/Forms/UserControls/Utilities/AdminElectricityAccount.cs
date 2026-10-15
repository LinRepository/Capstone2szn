using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.UserControls.Utilities;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.UserControls.Utilities
{
    public partial class AdminElectricityAccount : UserControl
    {
        public int AccountId { get; private set; }
        public int ElectricityBillId { get; private set; }
        public DateTime SelectedDate { get; set; } = DateTime.Today;
        private decimal _amount;
        private bool _isLocked;
        public AdminElectricityAccount()
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

                    DateTime billMonth = new DateTime(SelectedDate.Year, SelectedDate.Month, 1);

                    string sql = @"SELECT ua.AccountID, ua.AccountName, ua.AccountNumber,
                                          c.ChargeID, c.Amount, c.Status
                                FROM dbo.UtilityAccounts ua
                                LEFT JOIN dbo.ElectricityCharges c
                                       ON c.AccountID = ua.AccountID
                                      AND c.BillMonth = @BillMonth
                                WHERE ua.BuildingID  = @BuildingId
                                AND ua.UtilityType = 'Electricity'
                                AND ua.RoomID IS NULL
                                AND ua.IsActive    = 1;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);
                        cmd.Parameters.AddWithValue("@BillMonth", billMonth);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                AccountId = Convert.ToInt32(dr["AccountID"]);
                                lblAccountName.Text = dr["AccountName"].ToString();
                                lblAccountNumber.Text = dr["AccountNumber"].ToString();

                                if (dr["ChargeID"] != DBNull.Value)
                                {
                                    ElectricityBillId = Convert.ToInt32(dr["ChargeID"]);
                                    _amount = Convert.ToDecimal(dr["Amount"]);
                                    lblAmount.Text = _amount.ToString("₱#,##0.00");
                                    lblStatus.Text = dr["Status"].ToString();
                                    _isLocked = dr["Status"].ToString() == "Paid";
                                }
                                else
                                {
                                    ElectricityBillId = 0;
                                    _amount = 0;
                                    lblAmount.Text = "—";
                                    lblStatus.Text = "No bill";
                                    _isLocked = false;
                                }
                            }
                            else
                            {
                                AccountId = 0;
                                ElectricityBillId = 0;
                                lblAccountName.Text = "No electricity account set up";
                                lblAccountNumber.Text = "—";
                                lblAmount.Text = "—";
                                lblStatus.Text = "—";
                                _amount = 0;
                                _isLocked = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading electricity account: " + ex.Message);
                }
            }
        }
        private void AdminElectricityAccount_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRecordExpenses_Click(object sender, EventArgs e)
        {
            if (AccountId == 0)
            {
                MessageBox.Show("No owner electricity account is set up yet.", "No account",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime billMonth = new DateTime(SelectedDate.Year, SelectedDate.Month, 1);

            if (ElectricityBillId == 0)
            {
                MessageBox.Show($"There's no owner bill for {billMonth:MMMM yyyy} yet.\n\n" +
                                "Set the owner's amount in Edit Bill first.",
                    "No bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isLocked)
            {
                MessageBox.Show(
                    $"The owner's electricity bill for {billMonth:MMMM yyyy} is already paid.\n\n" +
                    "Paid bills are locked and can't be recorded again.",
                    "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_amount <= 0)
            {
                MessageBox.Show("Set the owner's amount in Edit Bill first.", "No amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var refForm = new RecordElectricityExpenseForm(ElectricityBillId, _amount, billMonth);

            if (refForm.ShowDialog(this) == DialogResult.OK)
                LoadAccount();
        }
    }
}