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

namespace Capstoneszn.Forms.PaymentsForms
{
    public partial class BillingPaymentForm : Form
    {
        /* =================================================================
           PAYMENT TYPE

           Decided by the amount, never picked by hand:

               amount == what is owed   ->  Full Payment
               amount <  what is owed   ->  Partial Payment
               amount >  what is owed   ->  Advance Payment
                                            (including any payment made
                                             when nothing is owed)

           "What is owed" is this tenant's total for an Individual payment,
           and the WHOLE ROOM's total for a Whole Room payment.

           Because the type follows the money, a payment can never be
           saved with a label that contradicts its amount.

           The screen shows the full label; the database stores the short
           code (CK_Payments_Type allows Full, Partial, Advance).
           ================================================================= */

        private const string FullPayment = "Full Payment";
        private const string PartialPayment = "Partial Payment";
        private const string AdvancePayment = "Advance Payment";

        private const string RentCategory = "Rent";
        private const string WaterCategory = "Water";
        private const string MaintenanceCategory = BillingHelper.MaintenanceCategory;

        /// <summary>Maintenance is Full only, so the amount is fixed.</summary>
        private bool IsMaintenance => cboCategoryType.Text == MaintenanceCategory;

        private int _roomId;
        private int _tenantId;
        //ORIGINAL: private RentControlBilling _rent;
        private ICategoryBilling _rent; //New

        public BillingPaymentForm(int roomId, int tenantId)
        {
            InitializeComponent();

            // These two lines must stay first: LoadContext() below reads them.
            _roomId = roomId;
            _tenantId = tenantId;

            // --- Category: Rent, Water, Maintenance. Each has its own
            //     context panel (see LoadContext).
            cboCategoryType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoryType.Items.Clear();
            cboCategoryType.Items.Add(RentCategory);
            cboCategoryType.Items.Add(WaterCategory);
            cboCategoryType.Items.Add(MaintenanceCategory);
            cboCategoryType.SelectedIndex = 0;
            cboCategoryType.Enabled = true; //Was false
            cboCategoryType.SelectedIndexChanged += (s, e) => LoadContext();   //New

            // --- Payment type: display only. It follows the amount.
            cboPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentType.Items.Clear();
            cboPaymentType.Items.AddRange(new object[]
                { FullPayment, PartialPayment, AdvancePayment });
            cboPaymentType.Enabled = false;

            dtpDate.Value = DateTime.Today;
            dtpDate.MaxDate = DateTime.Today;   // no post-dating

            radioButtonCash.Checked = true;
            radioButtonCash.CheckedChanged += PaymentMethod_Changed;
            radioButtonGcash.CheckedChanged += PaymentMethod_Changed;

            txtAmount.KeyPress += Decimal_KeyPress;
            txtAmount.TextChanged += Amount_Changed;

            // btnConfirm, btnCancel and btnClear are wired in the designer.
            // Do NOT wire them here as well: a second btnConfirm handler runs
            // the whole confirm-and-save sequence again after the first one
            // finishes, and saying Yes twice records the payment twice.

            LoadContext();
            PaymentMethod_Changed(null, EventArgs.Empty);
        }

        private void LoadContext()
        {
            // Dispose the previous category's panel, then remove it.
            // (Controls.Clear alone does not dispose, so switching categories
            // back and forth would pile up panels in memory.)
            foreach (Control old in flpPaymentDetails.Controls.Cast<Control>().ToList())
                old.Dispose();
            flpPaymentDetails.Controls.Clear();
            flpPaymentDetails.WrapContents = false;
            flpPaymentDetails.AutoScroll = true;

            // Pick the panel by category.
            switch (cboCategoryType.Text)
            {
                case WaterCategory:
                    _rent = new UtilitiesControlBilling(_roomId, _tenantId);
                    break;
                case MaintenanceCategory:
                    _rent = new MaintenanceControlBilling(_roomId, _tenantId);
                    break;
                default:
                    _rent = new RentControlBilling(_roomId, _tenantId);
                    break;
            }


            // Dock = Fill does not fill inside a FlowLayoutPanel, so size it
            //ORIGINAL: _rent.Width = flpPaymentDetails.ClientSize.Width - 6;
            ((Control)_rent).Width = flpPaymentDetails.ClientSize.Width - 6;

            // Switching Individual / Whole Room changes what the payment is
            // measured against (this tenant's debt or the room's), so refill
            // the amount with that figure. Setting the text re-runs the
            // preview and the payment type through Amount_Changed.
            _rent.ContextChanged += (s, e) =>
            {
                txtAmount.Text = _rent.OwedForMode > 0m ? _rent.OwedForMode.ToString("N2") : "";
                UpdatePreview();
                UpdatePaymentType();
            };

            //ORIGINAL: flpPaymentDetails.Controls.Add(_rent);
            flpPaymentDetails.Controls.Add((Control)_rent);

            bool owesNothing = _rent.Outstanding <= 0;

            if (IsMaintenance)
                lblMakePaymentTitle.Text = (owesNothing ? "No Maintenance Owed - " : "Pay Maintenance - ")
                                         + _rent.TenantName;
            else
                lblMakePaymentTitle.Text =
                    (owesNothing ? "Pay in Advance - " : "Make Payment - ") + _rent.TenantName;

            // Maintenance is Full only: the amount is exactly what is owed
            // and cannot be typed over.
            txtAmount.ReadOnly = IsMaintenance;

            // Start with the outstanding filled in; it is the common case.
            // Cleared otherwise, so an amount from another category never
            // carries over when the category is switched.
            txtAmount.Text = owesNothing ? "" : _rent.Outstanding.ToString("N2");

            UpdatePreview();
            UpdatePaymentType();
        }

        /// <summary>
        /// With something owed, the landlord picks Full, Partial or Down.
        /// With nothing owed, the only honest label is Advance, so it is
        /// fixed and the combo is locked.
        /// </summary>
        /// 

        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.' && e.KeyChar != ',')
                e.Handled = true;

            if (e.KeyChar == '.' && txtAmount.Text.Contains("."))
                e.Handled = true;
        }

        private void PaymentMethod_Changed(object sender, EventArgs e)
        {
            bool isGCash = radioButtonGcash.Checked;

            lblReferenceNumber.Visible = isGCash;
            txtReferenceNumber.Visible = isGCash;

            if (!isGCash) txtReferenceNumber.Clear();
        }

        private void Amount_Changed(object sender, EventArgs e)
        {
            UpdatePreview();
            UpdatePaymentType();
        }

        private decimal ParsedAmount()
        {
            decimal.TryParse(txtAmount.Text, out decimal amount);
            return amount;
        }

        /* =================================================================
           TYPE FROM AMOUNT
           ================================================================= */

        /// <summary>
        /// The one rule for the payment type. Compares the amount with what
        /// it is paying for: this tenant's debt (Individual) or the whole
        /// room's debt (Whole Room).
        /// </summary>
        private string DerivePaymentType(decimal amount)
        {
            decimal owed = _rent.OwedForMode;

            if (owed <= 0m) return AdvancePayment;
            if (amount == owed) return FullPayment;
            if (amount < owed) return PartialPayment;
            return AdvancePayment;
        }

        /// <summary>
        /// One line per tenant a Whole Room payment reaches, for the
        /// confirmation message.
        /// </summary>
        /// 
        private string WholeRoomLines(decimal amount)
        {
            var sb = new StringBuilder();
            foreach (var part in _rent.WholeRoomSplit(amount))
            {
                if (part.Value <= 0m) continue;
                sb.Append("    ").Append(_rent.NameOf(part.Key))
                  .Append("   PHP ").Append(part.Value.ToString("N2")).Append('\n');
            }
            return sb.ToString();
        }
        /// <summary>The room's position after a Whole Room payment.</summary>
        private string RoomAfterText(decimal amount)
        {
            decimal after = _rent.RoomOutstanding - amount;

            if (after > 0m) return "Room still owes PHP " + after.ToString("N2");
            if (after == 0m) return "Room fully settled";
            return "Room settled, PHP " + Math.Abs(after).ToString("N2") +
                   " advance split across " + _rent.RoomTenantCount + " tenant(s)";
        }


        private void UpdatePaymentType()
        {
            if (_rent == null) return;

            decimal amount = ParsedAmount();

            if (amount <= 0m)
            {
                cboPaymentType.SelectedIndex = -1;   // nothing typed yet
                return;
            }

            cboPaymentType.SelectedItem = DerivePaymentType(amount);
        }

        /// <summary>
        /// Screen label -> database code. CK_Payments_Type allows exactly
        /// these three codes; move-in payments already store 'Full'.
        /// </summary>
        private static string PaymentTypeCode(string label)
        {
            switch (label)
            {
                case FullPayment: return "Full";
                case PartialPayment: return "Partial";
                case AdvancePayment: return "Advance";
                default: throw new InvalidOperationException("Unknown payment type: " + label);
            }
        }

        /* =================================================================
           PREVIEW
           ================================================================= */

        /// <summary>
        /// Shows what the tenant's balance becomes if this payment is saved.
        /// Any amount a tenant is credited moves their balance by exactly that
        /// much - what it settles versus what becomes credit nets out.
        /// </summary>


        private void UpdatePreview()
        {
            if (_rent == null) return;

            decimal amount = ParsedAmount();
            _rent.SetPreviewAmount(amount);

            if (amount <= 0)
            {
                lblAfterPaymentValue.Text = "Enter an amount";
                lblAfterPaymentValue.ForeColor = Color.Silver;
                return;
            }

            // Whole Room: what matters is the room, not one tenant.
            if (_rent.CoversRoom)
            {
                decimal roomAfter = _rent.RoomOutstanding - amount;
                lblAfterPaymentValue.Text = "After this payment: " + RoomAfterText(amount);
                lblAfterPaymentValue.ForeColor = roomAfter > 0m ? Color.Salmon
                                               : roomAfter < 0m ? Color.PaleGreen
                                               : Color.White;
                return;
            }

            decimal credited = _rent.ShareOf(amount);
            decimal after = _rent.Balance + credited;

            string text;
            Color color;

            if (after > 0)
            {
                text = "After this payment: +PHP " + after.ToString("N2") + " (advance)";
                color = Color.PaleGreen;
            }
            else if (after < 0)
            {
                text = "After this payment: -PHP " + Math.Abs(after).ToString("N2") + " (still owing)";
                color = Color.Salmon;
            }
            else
            {
                text = "After this payment: PHP 0.00 - fully settled";
                color = Color.White;
            }

            lblAfterPaymentValue.Text = text;
            lblAfterPaymentValue.ForeColor = color;
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReferenceNumber.Clear();
            radioButtonCash.Checked = true;
            txtAmount.Text = _rent != null && _rent.Outstanding > 0
                ? _rent.Outstanding.ToString("N2") : "";
            // Category and date stay fixed; the type follows the amount
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_rent == null) return;

            if (_rent.BillId <= 0)
            {
                MessageBox.Show(IsMaintenance
                        ? "This tenant has no unpaid maintenance."
                        : "This room has no bill to pay yet.",
                    "No Bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal amount = ParsedAmount();

            // Maintenance: Full only. The box is read-only, but the rule is
            // checked again here (and once more in BillingHelper).
            if (IsMaintenance && amount != _rent.Outstanding)
            {
                MessageBox.Show("Maintenance must be paid in full: PHP " +
                    _rent.Outstanding.ToString("N2") + ".", "Full Payment Only",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Text = _rent.Outstanding.ToString("N2");
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Enter an amount greater than zero.", "Invalid Amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // The database stores money to the centavo. A third decimal
            // would be rounded on the way in, and the allocations would no
            // longer add up to the payment they came from.
            if (amount != Math.Round(amount, 2))
            {
                MessageBox.Show("Enter the amount to at most two decimal places (centavos).",
                    "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string method = radioButtonGcash.Checked ? "GCash" : "Cash";
            string refNo = txtReferenceNumber.Text.Trim();

            if (method == "GCash" && string.IsNullOrWhiteSpace(refNo))
            {
                MessageBox.Show("Enter the GCash reference number.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recomputed here rather than read from the combo, so what is
            // saved can never differ from the rule.
            string payType = DerivePaymentType(amount);

            // --- Confirm ---
            string header =
                (_rent.CoversRoom ? "Paid by:   " : "Tenant:    ") + _rent.TenantName + "\n" +
                "Category:  " + cboCategoryType.Text + "\n" +
                "Type:      " + payType + "\n" +
                "Method:    " + method + (method == "GCash" ? "  (ref " + refNo + ")" : "") + "\n" +
                "Amount:    PHP " + amount.ToString("N2") + "\n\n";

            string body;
            if (_rent.CoversRoom)
            {
                body = "Recorded as WHOLE ROOM:\n" +
                       WholeRoomLines(amount) + "\n" +
                       RoomAfterText(amount) + ".";
            }
            else
            {
                decimal after = _rent.Balance + amount;
                body = "Recorded for this tenant only.\n\n" +
                       "Balance after: " + (after >= 0 ? "+" : "-") +
                       "PHP " + Math.Abs(after).ToString("N2") +
                       (after > 0 ? " (advance)" : after < 0 ? " (still owing)" : "");
            }

            string summary = header + body + "\n\nSave this payment?";

            if (MessageBox.Show(summary, "Confirm Payment",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            SavePayment(amount, payType, method, refNo);
        }

        private void SavePayment(decimal amount, string payType, string method, string refNo)
        {
            string receiptNo = "R" + DateTime.Now.ToString("yyyyMMddHHmmss");
            bool saved = false;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        BillingHelper.RecordPayment(
                            conn, tx,
                            _roomId,
                            _tenantId,
                            _rent.CoversRoom,
                            cboCategoryType.Text,
                            PaymentTypeCode(payType),     // stored as Full / Partial / Advance
                            amount,
                            method,
                            refNo,
                            dtpDate.Value.Date,
                            Session.UserId,
                            receiptNo);

                        tx.Commit();
                        saved = true;
                    }
                    catch (InvalidOperationException ex)
                    {
                        // A business rule refused the payment (e.g. maintenance
                        // not paid in full). Show the rule, not "failed".
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { System.Diagnostics.Debug.WriteLine(rollbackEx); }

                        MessageBox.Show(ex.Message + "\n\nNothing was saved.", "Payment Not Saved",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        // A failed rollback must not hide the real error.
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { System.Diagnostics.Debug.WriteLine(rollbackEx); }

                        // The filtered unique index on ReferenceNo is the
                        // database refusing a GCash reference it has already
                        // recorded. Say that in words, not as a SQL message.
                        bool duplicateReference =
                            ex is SqlException sqlEx &&
                            (sqlEx.Number == 2601 || sqlEx.Number == 2627) &&
                            sqlEx.Message.Contains("ReferenceNo");

                        if (duplicateReference)
                        {
                            MessageBox.Show(
                                "GCash reference " + refNo + " has already been recorded " +
                                "for another payment.\n\nCheck the reference number. Nothing was saved.",
                                "Duplicate Reference", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Payment failed, nothing was saved: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            if (!saved) return;

            using (PaymentSuccessForm success = new PaymentSuccessForm(
                receiptNo, dtpDate.Value.Date, cboCategoryType.Text))
            {
                success.ShowDialog(this);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
