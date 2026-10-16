using Capstoneszn.Forms.UtilityForms;
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
    public partial class RecordWaterExpenseForm : Form
    {
        private readonly int _waterBillId;
        private readonly decimal _ownerShare;
        private readonly DateTime _billingMonth;
        public RecordWaterExpenseForm(int waterBillId, decimal ownerShare, DateTime billingMonth)
        {
            InitializeComponent();

            _waterBillId = waterBillId;
            _ownerShare = ownerShare;
            _billingMonth = new DateTime(billingMonth.Year, billingMonth.Month, 1);

            Text = "Record Water Expense";
            label1.Text = $"Owner's share of the {_billingMonth:MMMM yyyy} water bill.\n" +
                          "This will be recorded as a Utilities expense.";

            // Date: from the bill's month up to today - no post-dating
            dtpPaymentDate.MinDate = _billingMonth;
            dtpPaymentDate.MaxDate = DateTime.Today;
            dtpPaymentDate.Value = DateTime.Today;

            txtAmount.Text = _ownerShare.ToString("0.00");
            txtAmount.KeyPress += WaterBillHelper.MoneyKeyPress;
        }

        private void btnCancelRecordWaterExpense_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirmRecordWaterExpense_Click(object sender, EventArgs e)
        {
            // ── Validation ──
            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
            {
                Warn("Enter a valid amount.");
                txtAmount.Focus();
                return;
            }

            if (amount != Math.Round(amount, 2))
            {
                Warn("Enter the amount to at most two decimal places (centavos).");
                txtAmount.Focus();
                return;
            }

            // Exact amount only - no partial, no overpayment
            if (amount != _ownerShare)
            {
                Warn($"The payment must be exactly the owner's share: {_ownerShare:₱#,##0.00}.\n\n" +
                     $"You entered {amount:₱#,##0.00}.");
                txtAmount.Text = _ownerShare.ToString("0.00");
                txtAmount.Focus();
                return;
            }

            DateTime paidDate = dtpPaymentDate.Value.Date;

            // Lock warning - "No" is the default
            if (MessageBox.Show(
                    $"Record {amount:₱#,##0.00} as the owner's water payment for {_billingMonth:MMMM yyyy}?\n\n" +
                    $"Date paid: {paidDate:MMMM d, yyyy}\n\n" +
                    "Once recorded, this bill is LOCKED:\n" +
                    "  • the payment can't be recorded again\n" +
                    "  • the bill can no longer be edited",
                    "Confirm payment", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            // ── Save: expense row + mark the bill paid, together ──
            // Returning before Commit() rolls back automatically when 'tran' is disposed.
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using SqlTransaction tran = conn.BeginTransaction();

                // Re-check in the database: still unpaid, and the share hasn't changed
                decimal dbShare;
                string dbStatus;
                using (var cmd = new SqlCommand(@"
                    SELECT AdminAmount, AdminStatus
                    FROM   dbo.WaterBills WITH (UPDLOCK, HOLDLOCK)
                    WHERE  WaterBillId = @Id AND BuildingId = @BuildingId;", conn, tran))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _waterBillId;
                    cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;

                    using SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        Warn("This water bill no longer exists. Close this window and refresh.");
                        return;
                    }
                    dbShare = dr.GetDecimal(0);
                    dbStatus = dr.GetString(1);
                }

                if (dbStatus == "Paid")
                {
                    MessageBox.Show("This bill is already paid and locked.", "Bill locked",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (amount != dbShare)
                {
                    MessageBox.Show($"The owner's share changed to {dbShare:₱#,##0.00}. Close this window and try again.",
                        "Amount changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 1. The expense
                using (var cmd = new SqlCommand(@"
                    INSERT INTO dbo.Expenses
                        (BuildingId, ExpenseCategory, Description, Amount, ExpenseDate, RecordedBy)
                    VALUES
                        (@BuildingId, 'Utilities', @Description, @Amount, @ExpenseDate, @RecordedBy);", conn, tran))
                {
                    cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255).Value =
                        $"Water bill - {_billingMonth:MMMM yyyy} (owner's share)";
                    WaterBillHelper.AddMoney(cmd, "@Amount", amount);
                    cmd.Parameters.Add("@ExpenseDate", SqlDbType.Date).Value = paidDate;
                    cmd.Parameters.Add("@RecordedBy", SqlDbType.Int).Value = Session.UserId;
                    cmd.ExecuteNonQuery();
                }

                // 2. Lock the bill's owner side
                using (var cmd = new SqlCommand(@"
                    UPDATE dbo.WaterBills
                       SET AdminStatus = 'Paid', AdminPaidDate = @PaidDate
                     WHERE WaterBillId = @Id AND AdminStatus = 'Unpaid';", conn, tran))
                {
                    cmd.Parameters.Add("@PaidDate", SqlDbType.Date).Value = paidDate;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _waterBillId;
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();

                MessageBox.Show($"Expense recorded: {amount:₱#,##0.00}", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error recording expense: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static void Warn(string msg) =>
            MessageBox.Show(msg, "Record Expense", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void RecordWaterExpenseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
