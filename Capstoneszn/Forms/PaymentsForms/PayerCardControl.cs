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

namespace Capstoneszn.Forms.PaymentsForms
{
    /// <summary>
    /// One payer's card on the move-in PaymentForm (Payer Cards design).
    /// UI only: it collects the amount, method and reference number and shows
    /// whatever result the form calculates. The billing math (Full / Advance,
    /// months covered, credit) stays in PaymentForm / BillingHelper so the
    /// rules live in one place.
    /// </summary>
    /// 

    public partial class PayerCardControl : UserControl
    {
        /// <summary>Raised when the amount or payment method changes.</summary>
        public event EventHandler PaymentChanged;

        public PayerCardControl()
        {
            InitializeComponent();
        }

        /// <summary>The paying tenant this card belongs to (index in the move-in list until saved).</summary>
        public int PayerKey { get; private set; }

        /// <summary>The minimum this payer must pay: their share, or the room price for Whole Room.</summary>
        public decimal AmountDue { get; private set; }

        public string Method => rdoGCash.Checked ? "GCash" : "Cash";

        public string ReferenceNo => txtReferenceNo.Text.Trim();

        /// <summary>The typed amount, or null when the box is empty or not a number.</summary>
        public decimal? AmountPaid
        {
            get
            {
                string s = txtAmountPaid.Text.Replace("₱", "").Replace(",", "").Trim();
                return decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal v)
                    ? Math.Round(v, 2)
                    : (decimal?)null;
            }
        }

        /// <summary>
        /// Fills the card. dueCaption is "Share due" (Individual) or
        /// "Room price due" (Whole Room). The amount starts at the amount due.
        /// </summary>
        public void SetPayer(int payerKey, string title, string dueCaption, decimal amountDue)
        {
            PayerKey = payerKey;
            AmountDue = amountDue;
            lblPayerName.Text = title;
            lblDueCaption.Text = dueCaption;
            lblDueValue.Text = Peso(amountDue);
            txtAmountPaid.Text = amountDue.ToString("0.00", CultureInfo.InvariantCulture);
        }

        /// <summary>Shows the result the form calculated for this card.</summary>
        public void ShowResult(string typeText, Color typeColor, string coversText, string creditText)
        {
            lblPaymentType.Text = typeText;
            lblPaymentType.ForeColor = typeColor;
            lblCovers.Text = coversText;
            lblCredit.Text = creditText;
        }

        public void FocusAmount()
        {
            txtAmountPaid.Focus();
            txtAmountPaid.SelectAll();
        }

        public void FocusReference() => txtReferenceNo.Focus();

        private void rdoMethod_CheckedChanged(object sender, EventArgs e)
        {
            // Both radios fire; react once, on the one that became checked.
            if (sender is RadioButton rb && !rb.Checked) return;

            bool gcash = rdoGCash.Checked;
            txtReferenceNo.Enabled = gcash;
            txtReferenceNo.PlaceholderText = gcash ? "Enter GCash reference no." : "Not needed for Cash";
            if (!gcash) txtReferenceNo.Clear();

            PaymentChanged?.Invoke(this, EventArgs.Empty);
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            PaymentChanged?.Invoke(this, EventArgs.Empty);
        }

        // Digits and a single decimal point only.
        private void txtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && !txtAmountPaid.Text.Contains('.')) return;
            e.Handled = true;
        }

        private static string Peso(decimal v) => "₱" + v.ToString("N2", CultureInfo.InvariantCulture);

    }
}
