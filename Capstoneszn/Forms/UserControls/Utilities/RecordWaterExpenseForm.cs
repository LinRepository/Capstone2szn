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
    public partial class RecordWaterExpenseForm : Form
    {
        private readonly int _waterBillId;
        private readonly decimal _remaining;
        public RecordWaterExpenseForm(int waterBillId, decimal remaining)
        {
            InitializeComponent();

            _waterBillId = waterBillId;
            _remaining = remaining;

            dtpPaymentDate.Value = DateTime.Today;
            txtAmount.Text = remaining > 0 ? remaining.ToString("0.00") : "";
        }

        private void btnCancelRecordWaterExpense_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirmRecordWaterExpense_Click(object sender, EventArgs e)
        {
            // 4a. Validate the amount
            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Enter a valid amount.", "Invalid amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            // 4b. Must be the exact owner's share — no partial, no overpayment
            if (amount != _remaining)
            {
                MessageBox.Show(
                    $"The payment must be exactly the owner's share: {_remaining:₱#,##0.00}.\n\n" +
                    $"You entered {amount:₱#,##0.00}.",
                    "Amount must match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Text = _remaining.ToString("0.00");
                txtAmount.Focus();
                return;
            }

            // 4c. Lock warning — "No" is the default
            if (MessageBox.Show(
                    $"Record {amount:₱#,##0.00} as the owner's water payment?\n\n" +
                    "Once recorded, this bill is LOCKED:\n" +
                    "  • the payment can't be recorded again\n" +
                    "  • the bill can no longer be edited\n\n" +
                    "Please make sure the amount is correct before continuing.",
                    "Confirm payment", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                != DialogResult.Yes) return;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 4d. Re-check in the database: not yet paid, and still the same share
                        string checkSql = @"SELECT wb.TotalAmount
                                                 - ISNULL((SELECT SUM(c.Amount) FROM dbo.TenantWaterCharges c
                                                           WHERE c.WaterBillID = wb.WaterBillID), 0) AS OwnerShare,
                                                   (SELECT COUNT(*) FROM dbo.Expenses e
                                                     WHERE e.RefTable = 'WaterBills'
                                                       AND e.RefID    = wb.WaterBillID) AS Payments
                                            FROM dbo.WaterBills wb WITH (UPDLOCK, HOLDLOCK)
                                            WHERE wb.WaterBillID = @BillId;";

                        decimal dbShare = 0;
                        int payments = 0;

                        using (SqlCommand cmd = new SqlCommand(checkSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@BillId", _waterBillId);

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    dbShare = Convert.ToDecimal(dr["OwnerShare"]);
                                    payments = Convert.ToInt32(dr["Payments"]);
                                }
                            }
                        }

                        if (payments > 0)
                        {
                            tran.Rollback();
                            MessageBox.Show("This bill is already paid and locked.",
                                "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (amount != dbShare)
                        {
                            tran.Rollback();
                            MessageBox.Show($"The owner's share changed to {dbShare:₱#,##0.00}. Please reopen and try again.",
                                "Amount changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // 4e. Record the expense
                        string sql = @"INSERT INTO dbo.Expenses
                                          (BuildingID, Category, RefTable, RefID,
                                           Description, Amount, PaymentDate, RecordedBy)
                                       VALUES
                                          (@BuildingId, 'Water', 'WaterBills', @RefId,
                                           @Description, @Amount, @PaymentDate, @RecordedBy);";

                        using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);
                            cmd.Parameters.AddWithValue("@RefId", _waterBillId);
                            cmd.Parameters.AddWithValue("@Description", "Owner's share of water bill");
                            cmd.Parameters.AddWithValue("@Amount", amount);
                            cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value.Date);
                            cmd.Parameters.AddWithValue("@RecordedBy", Session.UserId);
                            cmd.ExecuteNonQuery();
                        }

                        // 4f. Save
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

        private void RecordWaterExpenseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
