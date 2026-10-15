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
    public partial class RecordElectricityExpenseForm : Form
    {
        private readonly int _electricityBillId;
        private readonly decimal _amountDue;
        private readonly DateTime _billMonth;   
        public RecordElectricityExpenseForm(int electricityBillId, decimal amountDue, DateTime billMonth)
        {
            InitializeComponent();

            _electricityBillId = electricityBillId;
            _amountDue = amountDue;
            _billMonth = billMonth;

            dtpPaymentDate.Value = DateTime.Today;
            txtAmount.Text = amountDue > 0 ? amountDue.ToString("0.00") : "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RecordElectricityExpenseForm_Load(object sender, EventArgs e)
        {

        }
        private void btnConfirmRecordElectricityExpense_Click(object sender, EventArgs e)
        {
            // 4a. Validate the amount
            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Enter a valid amount.");
                txtAmount.Focus();
                return;
            }

            // 4b. Warn if the amount doesn't match the bill
            if (amount != _amountDue)
            {
                MessageBox.Show(
                    $"The payment must be exactly the billed amount: {_amountDue:₱#,##0.00}.\n\n" +
                    $"You entered {amount:₱#,##0.00}.",
                    "Amount must match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Text = _amountDue.ToString("0.00");
                txtAmount.Focus();
                return;
            }

            // 4c. Lock warning — "No" is the default
            var confirm = MessageBox.Show(
                $"Record the owner's electricity payment for {_billMonth:MMMM yyyy}?\n\n" +
                $"Amount: {amount:₱#,##0.00}\n" +
                $"Date: {dtpPaymentDate.Value:MMM d, yyyy}\n\n" +
                "Once recorded, this bill is LOCKED:\n" +
                "  • the amount can no longer be edited\n" +
                "  • the payment can't be recorded again\n\n" +
                "Please make sure the amount is correct before continuing.",
                "Confirm payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 4d. Mark this month's bill Paid — refused if already paid
                        string statusSql = @"UPDATE dbo.ElectricityCharges
                                                SET Status = 'Paid',
                                                    SettledDate = @Today,
                                                    MarkedBy    = @UserId
                                              WHERE ChargeID = @ChargeId
                                                AND Status   = 'Unpaid';";

                        using (SqlCommand cmd = new SqlCommand(statusSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Today", DateTime.Today);
                            cmd.Parameters.AddWithValue("@UserId", Session.UserId);
                            cmd.Parameters.AddWithValue("@ChargeId", _electricityBillId);

                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                tran.Rollback();
                                MessageBox.Show("This bill is already paid and locked.",
                                    "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        // 4e. Record the expense, linked to this month's bill
                        string expenseSql = @"INSERT INTO dbo.Expenses
                                                 (BuildingID, Category, RefTable, RefID,
                                                  Description, Amount, PaymentDate, RecordedBy)
                                              VALUES
                                                 (@BuildingId, 'Electricity', 'ElectricityCharges', @RefId,
                                                  @Description, @Amount, @PaymentDate, @RecordedBy);";

                        using (SqlCommand cmd = new SqlCommand(expenseSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);
                            cmd.Parameters.AddWithValue("@RefId", _electricityBillId);
                            cmd.Parameters.AddWithValue("@Description",
                                $"Owner's electricity bill - {_billMonth:MMMM yyyy}");
                            cmd.Parameters.AddWithValue("@Amount", amount);
                            cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value.Date);
                            cmd.Parameters.AddWithValue("@RecordedBy", Session.UserId);
                            cmd.ExecuteNonQuery();
                        }

                        // 4f. Both steps succeeded — save for real
                        tran.Commit();

                        MessageBox.Show($"Expense recorded: {amount:₱#,##0.00}");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error recording expense: " + ex.Message);
                    }
                }
            }
        }
    }
}
