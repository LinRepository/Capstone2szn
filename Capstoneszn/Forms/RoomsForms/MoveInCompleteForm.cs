using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.RoomsForms
{
    

    /// <summary>
    /// Shown once after a move-in is saved. Replaces PaymentSuccessForm for
    /// the move-in flow only (Bill Management still uses PaymentSuccessForm).
    /// Lists every receipt the move-in created, each with View / Print, so
    /// several receipts (Individual payers) never open one after another.
    /// </summary>
    public partial class MoveInCompleteForm : Form
    {
        private static readonly Color ViewedColor = Color.FromArgb(134, 239, 172);

        /// <param name="roomNumber">The room moved into.</param>
        /// <param name="payingCount">Paying tenants who moved in.</param>
        /// <param name="dependentCount">Dependents who moved in.</param>
        /// <param name="moveInDate">The move-in (payment) date - today.</param>
        /// <param name="nextDue">The room's next rent due date.</param>
        /// <param name="receipts">One line per payment saved (none for a joiner).</param>
        public MoveInCompleteForm(string roomNumber, int payingCount, int dependentCount,
                                  DateTime moveInDate, DateTime nextDue,
                                  IList<MoveInReceiptLine> receipts)
        {
            InitializeComponent();

            receipts ??= new List<MoveInReceiptLine>();
            int occupants = payingCount + dependentCount;

            string who = occupants + (occupants == 1 ? " occupant" : " occupants") + " moved in";
            if (dependentCount > 0)
                who += " (" + payingCount + " paying, " + dependentCount +
                       (dependentCount == 1 ? " dependent)" : " dependents)");

            string paid = receipts.Count == 0
                ? "no payment due today"
                : receipts.Count + (receipts.Count == 1 ? " payment recorded" : " payments recorded");

            lblCompleteSubtitle.Text = "Room " + roomNumber + " · " + who + " · " + paid;
            lblTotalValue.Text = Peso(receipts.Sum(r => r.Amount));
            lblDateValue.Text = moveInDate.ToString("MMM d, yyyy", CultureInfo.InvariantCulture);
            lblNextDueValue.Text = nextDue.ToString("MMM d, yyyy", CultureInfo.InvariantCulture);

            foreach (MoveInReceiptLine r in receipts)
                dgvReceipts.Rows.Add(r.ReceiptNo, r.PayerName, r.Method, Peso(r.Amount));

            if (receipts.Count == 0)
            {
                lblReceiptsTitle.Text = "Receipts (none - joined an occupied room)";
                lblHint.Text = "Their rent is collected with the room's next bill.";
            }
        }

        private void dgvReceipts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colView.Index) return;

            DataGridViewRow row = dgvReceipts.Rows[e.RowIndex];
            string receiptNo = Convert.ToString(row.Cells[colReceiptNo.Index].Value) ?? "";

            int? paymentId;
            try
            {
                paymentId = PaymentHistoryService.GetPaymentIdByReceipt(receiptNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the receipt: " + ex.Message, "Receipt",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (paymentId == null)
            {
                MessageBox.Show("Receipt " + receiptNo + " was not found.", "Receipt",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var receipt = new PaymentReceiptForm(paymentId.Value))
                receipt.ShowDialog(this);

            // Mark it so the landlord can see which receipts were already opened.
            row.DefaultCellStyle.ForeColor = ViewedColor;
            row.DefaultCellStyle.SelectionForeColor = ViewedColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private static string Peso(decimal v) => "₱" + v.ToString("N2", CultureInfo.InvariantCulture);
    }
    /// <summary>One receipt saved by a move-in.</summary>
    public class MoveInReceiptLine
    {
        public string ReceiptNo { get; set; } = "";
        public string PayerName { get; set; } = "";
        public string Method { get; set; } = "";
        public decimal Amount { get; set; }
    }
}
