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
        private decimal? _amount;      // null = no amount entered this month
        private bool _isLocked;
        private DateTime BillMonth => new DateTime(SelectedDate.Year, SelectedDate.Month, 1);
        public AdminElectricityAccount()
        {
            InitializeComponent();

            txtAmount.Leave += txtAmount_Leave;
            txtAmount.KeyDown += txtAmount_KeyDown;
        }
        public void LoadAccount()
        {
            AccountId = 0;
            ElectricityBillId = 0;
            _amount = null;
            _isLocked = false;

            const string sql = @"
                SELECT ea.ElectricityAccountId, ea.AccountName, ea.AccountNumber,
                       ec.ElectricityChargeId, ec.Amount, ec.Status
                FROM   dbo.ElectricityAccounts ea
                LEFT JOIN dbo.ElectricityCharges ec
                       ON ec.ElectricityAccountId = ea.ElectricityAccountId
                      AND ec.BillingMonth = @BillMonth
                WHERE  ea.BuildingId = @BuildingId
                  AND  ea.RoomId IS NULL;";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                cmd.Parameters.Add("@BillMonth", SqlDbType.Date).Value = BillMonth;

                using SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    AccountId = Convert.ToInt32(dr["ElectricityAccountId"]);
                    lblAccountName.Text = dr["AccountName"].ToString();
                    lblAccountNumber.Text = dr["AccountNumber"].ToString();

                    if (dr["ElectricityChargeId"] != DBNull.Value)
                        ElectricityBillId = Convert.ToInt32(dr["ElectricityChargeId"]);

                    if (dr["Amount"] != DBNull.Value)
                    {
                        _amount = Convert.ToDecimal(dr["Amount"]);
                        lblStatus.Text = dr["Status"].ToString();
                        _isLocked = dr["Status"].ToString() == "Paid";
                    }
                    else
                    {
                        lblStatus.Text = "No bill";
                    }
                }
                else
                {
                    lblAccountName.Text = "No electricity account set up";
                    lblAccountNumber.Text = "—";
                    lblStatus.Text = "—";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading electricity account: " + ex.Message);
            }

            ShowAmount();
            txtAmount.ReadOnly = AccountId == 0 || _isLocked || BillMonth > DateTime.Today;
        }
        private void ShowAmount()
        {
            txtAmount.Text = _amount.HasValue ? _amount.Value.ToString("₱#,##0.00") : "";
        }
        private void txtAmount_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            SaveAmount();
        }

        private void txtAmount_Leave(object? sender, EventArgs e)
        {
            SaveAmount();
        }

        private void SaveAmount()
        {
            if (txtAmount.ReadOnly || AccountId == 0) return;

            if (!ElectricityHelper.TryParseAmount(txtAmount.Text, out decimal? value)
                || (value.HasValue && value.Value <= 0))
            {
                MessageBox.Show("Enter a valid amount greater than 0, or leave it blank.", "Invalid amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowAmount();   // put the saved value back
                return;
            }

            if (value == _amount) { ShowAmount(); return; }   // nothing changed

            try
            {
                int result = ElectricityHelper.SaveAmount(AccountId, BillMonth, value);
                if (result == -1)
                    MessageBox.Show("The owner's bill is already paid and can't be edited.", "Bill locked",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to save the owner's amount.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadAccount();
        }
        private void AdminElectricityAccount_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRecordExpenses_Click(object sender, EventArgs e)
        {
            SaveAmount();   // in case they typed an amount and clicked straight here

            if (AccountId == 0)
            {
                MessageBox.Show("No owner electricity account is set up yet.", "No account",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_isLocked)
            {
                MessageBox.Show(
                    $"The owner's electricity bill for {BillMonth:MMMM yyyy} is already paid.\n\n" +
                    "Paid bills are locked and can't be recorded again.",
                    "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ElectricityBillId == 0 || !_amount.HasValue || _amount.Value <= 0)
            {
                MessageBox.Show($"Type the owner's amount for {BillMonth:MMMM yyyy} first.", "No amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            using var refForm = new RecordElectricityExpenseForm(ElectricityBillId, _amount.Value, BillMonth);

            if (refForm.ShowDialog(this) == DialogResult.OK)
                LoadAccount();
        }
    }
}