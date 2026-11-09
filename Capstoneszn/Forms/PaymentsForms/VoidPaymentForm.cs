using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.PaymentsForms
{

    /// <summary>
    /// Voids one payment (settled rule: landlord only, reason required,
    /// cannot be undone; the payment stays visible, struck through, and the
    /// correct payment is recorded again as a new receipt).
    ///
    /// Shows what the void will undo before asking, so the landlord sees
    /// which tenants will owe again. Closes with DialogResult.OK only when
    /// the void was saved.
    /// </summary>
    /// 

    public partial class VoidPaymentForm : Form
    {

        private readonly int _paymentId;
        private PaymentReceipt? _receipt;


        public VoidPaymentForm(int paymentId)
        {
            InitializeComponent();

            _paymentId = paymentId;

            // Esc cancels; no AcceptButton on purpose - Enter must not void.
            CancelButton = btnCancelVoid;
        }

        private void VoidPaymentForm_Load(object sender, EventArgs e)
        {

            try
            {
                _receipt = PaymentHistoryService.GetReceipt(_paymentId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the payment.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (_receipt == null || _receipt.Payment.IsVoided)
            {
                MessageBox.Show("This payment no longer exists or is already voided.",
                    "Cannot Void", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            // NEW (Step 6, rule B): landlord = any receipt; caretaker = own receipt, recorded today
            string? notAllowed;
            try
            {
                notAllowed = PaymentHistoryService.VoidNotAllowedReason(_paymentId, Session.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to check the payment.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            if (notAllowed != null)
            {
                MessageBox.Show(notAllowed, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            PaymentHistoryRow p = _receipt.Payment;

            lblVoidDetails.Text =
                "Receipt No.:  " + p.ReceiptNo + "\n" +
                "Date:  " + p.PaymentDate.ToString("MMM dd, yyyy") + "\n" +
                "Paid by:  " + p.TenantName + "  (Room " + p.RoomNumber + ")" +
                (p.CoversRoom ? "  - Whole Room" : "") + "\n" +
                "Category:  " + p.Category + "   Type: " + p.PaymentType + "\n" +
                "Amount:  ₱" + p.Amount.ToString("N2") + "  (" + p.Method +
                (p.ReferenceNo.Length > 0 ? " ref " + p.ReferenceNo : "") + ")";

            lblVoidImpact.Text = BuildImpactText();
            ActiveControl = txtVoidReason;
        }

        /// <summary>
        /// Per tenant: how much goes back to owing, and how much advance
        /// credit disappears.
        /// </summary>
        private string BuildImpactText()
        {
            if (_receipt == null) return "";

            var sb = new StringBuilder("Voiding this payment will:\n");

            foreach (var group in _receipt.Lines.GroupBy(l => new { l.TenantName, l.RoomNumber }))
            {
                decimal owesAgain = group.Where(l => !l.IsCredit).Sum(l => l.Amount);
                decimal creditLost = group.Where(l => l.IsCredit).Sum(l => l.Amount);
                string categories = string.Join(", ",
                    group.Where(l => !l.IsCredit).Select(l => l.Category.ToLower()).Distinct());

                if (owesAgain > 0)
                {
                    sb.Append("  • ").Append(group.Key.TenantName).Append(" will owe ₱")
                      .Append(owesAgain.ToString("N2")).Append(" ")
                      .Append(categories).Append(" again");

                    // a bill in another room = the money moved there with a transfer
                    if (group.Key.RoomNumber.Length > 0 && group.Key.RoomNumber != _receipt.Payment.RoomNumber)
                        sb.Append(" in Room ").Append(group.Key.RoomNumber);

                    sb.Append("\n");
                }
                if (creditLost > 0)
                    sb.Append("  • ").Append(group.Key.TenantName).Append(" loses ₱")
                      .Append(creditLost.ToString("N2")).Append(" advance credit\n");
            }

            sb.Append("\nThis cannot be undone. Record the correct payment again afterwards.");
            return sb.ToString();
        }

        private void btnConfirmVoid_Click(object sender, EventArgs e)
        {
            string reason = txtVoidReason.Text.Trim();
            if (reason.Length == 0)
            {
                MessageBox.Show("Enter the reason for voiding this payment.", "Reason Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVoidReason.Focus();
                return;
            }

            if (MessageBox.Show("Void receipt " + _receipt?.Payment.ReceiptNo + "? This cannot be undone.",
                    "Confirm Void", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            btnConfirmVoid.Enabled = false;   // no double void on a double-click
            try
            {
                PaymentHistoryService.VoidPayment(_paymentId, reason, Session.UserId);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Payment Not Voided",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.OK;   // list may be stale - let it reload
                Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The payment was not voided.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConfirmVoid.Enabled = true;
                return;
            }

            MessageBox.Show("Payment voided.", "Voided",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelVoid_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
