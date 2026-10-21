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
        private readonly int _electricityBillId;   // ElectricityCharges.ElectricityChargeId of the owner's bill
        private readonly decimal _amountDue;
        private readonly DateTime _billMonth;
        public RecordElectricityExpenseForm(int electricityBillId, decimal amountDue, DateTime billMonth)
        {
            InitializeComponent();

            _electricityBillId = electricityBillId;
            _amountDue = amountDue;
            _billMonth = billMonth;

            Text = $"Record Owner Electricity Expense - {billMonth:MMMM yyyy}";

            dtpPaymentDate.MaxDate = DateTime.Today;   // can't record a payment in the future
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
            // 1.Validate the amount(accepts "1500", "1,500.00", "₱1,500")
            if (!ElectricityHelper.TryParseAmount(txtAmount.Text, out decimal? parsed)
                || !parsed.HasValue || parsed.Value <= 0)
            {
                MessageBox.Show("Enter a valid amount greater than 0.", "Invalid amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }
            decimal amount = parsed.Value;

            // 2. Exact amount only — no partial payment or overpayment
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

            DateTime paymentDate = dtpPaymentDate.Value.Date;

            // 3. Lock warning — "No" is the default
            var confirm = MessageBox.Show(
                $"Record the owner's electricity payment for {_billMonth:MMMM yyyy}?\n\n" +
                $"Amount: {amount:₱#,##0.00}\n" +
                $"Date: {paymentDate:MMM d, yyyy}\n\n" +
                "Once recorded, this bill is LOCKED:\n" +
                "  • the amount can no longer be edited\n" +
                "  • the payment can't be recorded again\n\n" +
                "Please make sure the amount is correct before continuing.",
                "Confirm payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 4. Mark the owner's bill Paid — refused if it's already paid
                    //    or if the amount changed since this form opened
                    const string statusSql = @"
                        UPDATE dbo.ElectricityCharges
                           SET Status   = 'Paid',
                               PaidDate = @PaidDate,
                               MarkedBy = @UserId
                         WHERE ElectricityChargeId = @ChargeId
                           AND Status = 'Unpaid'
                           AND Amount = @Amount;";

                    using (var cmd = new SqlCommand(statusSql, conn, tran))
                    {
                        cmd.Parameters.Add("@PaidDate", SqlDbType.Date).Value = paymentDate;
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Session.UserId;
                        cmd.Parameters.Add("@ChargeId", SqlDbType.Int).Value = _electricityBillId;
                        var p = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                        p.Precision = 18; p.Scale = 2; p.Value = amount;

                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            tran.Rollback();
                            MessageBox.Show("This bill is already paid, or its amount was changed. Please reopen and try again.",
                                "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;   // card reloads and shows the current state
                            this.Close();
                            return;
                        }
                    }

                    // 5. Record the expense (same format as the water owner's share)
                    const string expenseSql = @"
                        INSERT INTO dbo.Expenses
                               (BuildingId, ExpenseCategory, Description, Amount, ExpenseDate, RecordedBy)
                        VALUES (@BuildingId, 'Utilities', @Description, @Amount, @ExpenseDate, @RecordedBy);";

                    using (var cmd = new SqlCommand(expenseSql, conn, tran))
                    {
                        cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255).Value =
                            $"Electricity bill - {_billMonth:MMMM yyyy} (owner's account)";
                        var p = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                        p.Precision = 18; p.Scale = 2; p.Value = amount;
                        cmd.Parameters.Add("@ExpenseDate", SqlDbType.Date).Value = paymentDate;
                        cmd.Parameters.Add("@RecordedBy", SqlDbType.Int).Value = Session.UserId;
                        cmd.ExecuteNonQuery();
                    }

                    // 6. Both steps succeeded — save for real
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }

                MessageBox.Show($"Expense recorded: {amount:₱#,##0.00}", "Recorded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error recording expense: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
