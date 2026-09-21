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
    public partial class PaymentForm : Form
    {

        // Tenant data passed from MoveInForm
        private int _roomId;
        private string _tenantName;
        private string _contactNumber;
        private DateTime _moveInDate;
        public PaymentForm(int roomId, string tenantName, string contactNumber, DateTime moveInDate)
        {
            InitializeComponent();

            _roomId = roomId;
            _tenantName = tenantName;
            _contactNumber = contactNumber;
            _moveInDate = moveInDate;

            // 1. Populate Dropdowns
            cboPaymentCategory.Items.AddRange(new string[] { "Rent", "Utilities", "Maintenance" });
            cboPaymentType.Items.AddRange(new string[] { "Full Payment", "Partial Payment", "Down Payment" });

            // 2. Set Default Values
            cboPaymentCategory.SelectedItem = "Rent";
            cboPaymentType.SelectedItem = "Full Payment";
            RadioBtnCash.Checked = true; // Cash is default

            // 3. Hide GCash Reference fields by default
            lblReferenceNumber.Visible = false;
            txtReferenceNumber.Visible = false;

            // 4. Wire up the Radio Button click events dynamically
            RadioBtnCash.CheckedChanged += PaymentMethod_CheckedChanged;
            RadioBtnGCash.CheckedChanged += PaymentMethod_CheckedChanged;
        }

        // This event fires anytime either radio button is clicked
        private void PaymentMethod_CheckedChanged(object sender, EventArgs e)
        {
            // If GCash is checked, it returns true (Visible). If not, false (Hidden).
            bool isGcash = RadioBtnGCash.Checked;

            lblReferenceNumber.Visible = isGcash;
            txtReferenceNumber.Visible = isGcash;

            // Optional: Clear out the textbox if they switch back to Cash
            if (!isGcash)
            {
                txtReferenceNumber.Clear();
            }
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelPayment_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnContinuePayment_Click(object sender, EventArgs e)
        {
            // 1. Validate the Amount (Temporary 1000 minimum rule)
            if (!decimal.TryParse(txtPaymentAmount.Text, out decimal amount) || amount < 1000)
            {
                MessageBox.Show("Insufficient amount. The minimum payment required before move-in is ₱1000.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validate GCash Reference Number if GCash is selected
            if (RadioBtnGCash.Checked && string.IsNullOrWhiteSpace(txtReferenceNumber.Text))
            {
                MessageBox.Show("Please enter the GCash Reference Number.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Gather Payment Details
            DateTime paymentDate = dtpPaymentDate.Value;
            string category = cboPaymentCategory.Text;
            string paymentType = cboPaymentType.Text;
            string method = RadioBtnGCash.Checked ? "GCash" : "Cash";
            string refNumber = txtReferenceNumber.Text.Trim();
            string remarks = txtPaymentRemarks.Text.Trim();

            // 4. Pass ALL data to the ConfirmPaymentForm
            using (ConfirmPaymentForm confirmForm = new ConfirmPaymentForm(
                _roomId, _tenantName, _contactNumber, _moveInDate,
                paymentDate, category, paymentType, method, amount, refNumber, remarks))
            {
                if (confirmForm.ShowDialog() == DialogResult.OK)
                {
                    // Success! Cascade the close command back down the chain
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
