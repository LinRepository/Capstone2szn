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

        private int _roomId;
        private int _tenantId;
        private RentControlBilling _rent;

        public BillingPaymentForm(int roomId, int tenantId)
        {
            InitializeComponent();

            _roomId = roomId;
            _tenantId = tenantId;

            // --- Category: Rent only for now. Maintenance and Utilities
            //     have no tables yet, so offering them would be a dead end.
            cboCategoryType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoryType.Items.Clear();
            cboCategoryType.Items.Add("Rent");
            cboCategoryType.SelectedIndex = 0;
            cboCategoryType.Enabled = false;

            // --- Payment type: suggested from the amount, landlord can override
            cboPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentType.Items.Clear();
            cboPaymentType.Items.AddRange(new object[]
                { "Full Payment", "Partial Payment", "Down Payment" });
            cboPaymentType.SelectedIndex = 0;

            dtpDate.Value = DateTime.Today;
            dtpDate.MaxDate = DateTime.Today;   // no post-dating

            radioButtonCash.Checked = true;
            radioButtonCash.CheckedChanged += PaymentMethod_Changed;
            radioButtonGcash.CheckedChanged += PaymentMethod_Changed;

            txtAmount.KeyPress += Decimal_KeyPress;
            txtAmount.TextChanged += Amount_Changed;

            btnConfirm.Click += btnConfirm_Click;
            btnCancel.Click += btnCancel_Click;
            btnClear.Click += btnClear_Click;

            LoadContext();
            PaymentMethod_Changed(null, EventArgs.Empty);
        }

        private void LoadContext()
        {
            flpPaymentDetails.Controls.Clear();
            flpPaymentDetails.WrapContents = false;
            flpPaymentDetails.AutoScroll = true;

            _rent = new RentControlBilling(_roomId, _tenantId);

            // Dock = Fill does not fill inside a FlowLayoutPanel, so size it
            _rent.Width = flpPaymentDetails.ClientSize.Width - 6;

            _rent.ContextChanged += (s, e) => UpdatePreview();

            flpPaymentDetails.Controls.Add(_rent);

            lblMakePaymentTitle.Text = "Make Payment - " + _rent.TenantName;

            // Start with the outstanding filled in; it is the common case
            if (_rent.Outstanding > 0)
                txtAmount.Text = _rent.Outstanding.ToString("N2");

            UpdatePreview();
        }

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
            SuggestPaymentType();
        }

        private decimal ParsedAmount()
        {
            decimal.TryParse(txtAmount.Text, out decimal amount);
            return amount;
        }

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

            if (_rent.CoversRoom)
                text += "   [this tenant's share: PHP " + credited.ToString("N2") + "]";

            lblAfterPaymentValue.Text = text;
            lblAfterPaymentValue.ForeColor = color;
        }

        /// <summary>
        /// A Down Payment is the FIRST partial payment on a bill; a Partial
        /// is any later one. Suggest, never force - the landlord can override.
        /// </summary>
        private void SuggestPaymentType()
        {
            if (_rent == null || _rent.Outstanding <= 0) return;

            decimal credited = _rent.ShareOf(ParsedAmount());

            if (credited >= _rent.Outstanding)
                cboPaymentType.SelectedItem = "Full Payment";
            else if (_rent.HasPriorPayment)
                cboPaymentType.SelectedItem = "Partial Payment";
            else
                cboPaymentType.SelectedItem = "Down Payment";
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReferenceNumber.Clear();
            radioButtonCash.Checked = true;
            txtAmount.Text = _rent != null && _rent.Outstanding > 0
                ? _rent.Outstanding.ToString("N2") : "";
            // Category and date stay fixed
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
                MessageBox.Show("This room has no bill to pay yet.", "No Bill",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal amount = ParsedAmount();

            if (amount <= 0)
            {
                MessageBox.Show("Enter an amount greater than zero.", "Invalid Amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string payType = cboPaymentType.Text;
            decimal credited = _rent.ShareOf(amount);

            // Label and money must agree
            if (payType == "Full Payment" && credited < _rent.Outstanding)
            {
                MessageBox.Show(
                    "Full Payment needs PHP " + _rent.Outstanding.ToString("N2") +
                    " for this tenant, but only PHP " + credited.ToString("N2") +
                    " would be credited.\n\nChange the amount, or pick Partial or Down Payment.",
                    "Amount doesn't match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((payType == "Partial Payment" || payType == "Down Payment")
                && credited >= _rent.Outstanding && _rent.Outstanding > 0)
            {
                MessageBox.Show(
                    "This covers the full PHP " + _rent.Outstanding.ToString("N2") +
                    " outstanding.\n\nSelect Full Payment instead.",
                    "Amount doesn't match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Confirm ---
            decimal after = _rent.Balance + credited;

            string summary =
                "Room:      " + lblMakePaymentTitle.Text.Replace("Make Payment - ", "") + "\n" +
                "Category:  " + cboCategoryType.Text + "\n" +
                "Type:      " + payType + "\n" +
                "Method:    " + method + (method == "GCash" ? "  (ref " + refNo + ")" : "") + "\n" +
                "Amount:    PHP " + amount.ToString("N2") + "\n\n" +
                (_rent.CoversRoom
                    ? "Recorded as WHOLE ROOM - split across every active tenant.\n" +
                      "This tenant is credited PHP " + credited.ToString("N2") + ".\n\n"
                    : "Recorded for this tenant only.\n\n") +
                "Balance after: " + (after >= 0 ? "+" : "-") +
                "PHP " + Math.Abs(after).ToString("N2") +
                (after > 0 ? " (advance)" : after < 0 ? " (still owing)" : "") +
                "\n\nSave this payment?";

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
                            payType,
                            amount,
                            method,
                            refNo,
                            dtpDate.Value.Date,
                            Session.UserId,
                            receiptNo);

                        tx.Commit();
                        saved = true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Payment failed, nothing was saved: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
