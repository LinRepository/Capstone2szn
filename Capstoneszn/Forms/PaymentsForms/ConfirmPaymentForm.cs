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

namespace Capstoneszn.Forms
{
    public partial class ConfirmPaymentForm : Form
    {

        public ConfirmPaymentForm(DateTime date, string category, string paymentType, string method, string referenceNo, decimal amount)
        {
            InitializeComponent();

            lblConfirmDateValue.Text = date.ToString("MMMM d, yyyy");
            lblConfirmCategoryValue.Text = category;
            lblConfirmPaymentTypeValue.Text = paymentType;
            lblConfirmPaymentMethodValue.Text = method;
            lblConfirmReferenceValue.Text =
                string.IsNullOrWhiteSpace(referenceNo) ? "N/A" : referenceNo;
            lblConfirmAmountValue.Text = "₱" + amount.ToString("N2");
        }

        // NOTE (move-in redesign): the constructor above is the old single-payment
        // version. It is kept so nothing else breaks; the move-in now uses the
        // one below. Its labels sit in the hidden pnlLegacyConfirm.

        /// <summary>
        /// NEW (move-in redesign, C1): the move-in summary table.
        /// Display only - every value was already checked by PaymentForm and
        /// is checked again by MoveInService when it saves.
        /// OK = Confirm, Cancel = go back and change something.
        /// </summary>
        public ConfirmPaymentForm(ConfirmMoveInInfo info)
        {
            InitializeComponent();

            if (info == null) throw new ArgumentNullException(nameof(info));

            // ---- Top details ----
            lblConfirmDateValue.Text = info.Date.ToString("MMMM d, yyyy");
            lblConfirmRoomValue.Text = info.RoomNumber;
            lblConfirmCategoryValue.Text = "Rent";            // move-in collects rent only; utilities come with later bills
            lblConfirmPaidAsValue.Text = info.PaidAs;
            lblConfirmOccupantsValue.Text = info.Occupants;
            lblConfirmShareValue.Text = info.Share;

            // ---- One row per payment (Whole Room = one row) ----
            dgvConfirmPayments.Rows.Clear();
            foreach (ConfirmMoveInRow r in info.Rows)
            {
                int i = dgvConfirmPayments.Rows.Add();
                DataGridViewRow row = dgvConfirmPayments.Rows[i];
                row.Cells[colPayer.Index].Value = r.Payer;
                row.Cells[colType.Index].Value = r.Type;
                row.Cells[colMethod.Index].Value = r.Method;
                row.Cells[colReference.Index].Value = r.Reference;
                row.Cells[colCovers.Index].Value = r.Covers;
                row.Cells[colAmount.Index].Value = "₱" + r.Amount.ToString("N2");

                // Advance stands out, so the landlord notices the extra money.
                if (r.Type == "Advance")
                    row.Cells[colType.Index].Style.ForeColor = Color.RoyalBlue;
            }
            dgvConfirmPayments.ClearSelection();

            // ---- Total and notes ----
            lblConfirmAmountValue.Text = "₱" + info.Total.ToString("N2");
            lblReceiptsLine.Text = info.ReceiptsLine;

            lblCreditedTo.Text = info.CreditedTo;
            lblCreditedTo.Visible = !string.IsNullOrWhiteSpace(info.CreditedTo);

            lblDependents.Text = info.Dependents;
            lblDependents.Visible = !string.IsNullOrWhiteSpace(info.Dependents);
        }
        private void ConfirmPaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelPayment_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
        /// <summary>NEW (move-in redesign): everything the C1 confirm screen shows.</summary>
        public class ConfirmMoveInInfo
        {
            public DateTime Date { get; set; }
            public string RoomNumber { get; set; } = "";
            public string PaidAs { get; set; } = "";          // "Whole Room" / "Individual"
            public string Occupants { get; set; } = "";       // e.g. "5 (2 paying)"
            public string Share { get; set; } = "";           // e.g. "₱3,000.00"
            public List<ConfirmMoveInRow> Rows { get; set; } = new List<ConfirmMoveInRow>();
            public decimal Total { get; set; }
            public string CreditedTo { get; set; } = "";      // Whole Room with 2+ payers, else empty
            public string Dependents { get; set; } = "";      // empty when there are none
            public string ReceiptsLine { get; set; } = "";    // e.g. "2 payments · 2 receipts"
        }
        /// <summary>NEW (move-in redesign): one row of the C1 table.</summary>
        public class ConfirmMoveInRow
        {
            public string Payer { get; set; } = "";
            public string Type { get; set; } = "";            // "Full" / "Advance"
            public string Method { get; set; } = "";          // "Cash" / "GCash"
            public string Reference { get; set; } = "";       // GCash reference, or "—"
            public string Covers { get; set; } = "";
            public decimal Amount { get; set; }
        }
    }