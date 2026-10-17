using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms
{
    public partial class PaymentSuccessForm : Form
    {
        public PaymentSuccessForm(string transactionId, DateTime date, string category)
        {
            InitializeComponent();


            lblTransactionIDValue.Text = transactionId;
            lblDateValue.Text = date.ToString("MMMM d, yyyy");
            lblCategoryValue.Text = category;
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            int? paymentId = PaymentHistoryService.GetPaymentIdByReceipt(lblTransactionIDValue.Text);
            if (paymentId == null)
            {
                MessageBox.Show("Receipt not found.", "Print Receipt",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var receipt = new Capstoneszn.Forms.PaymentReceiptForm(paymentId.Value))
                receipt.ShowDialog(this);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PaymentSuccessForm_Load(object sender, EventArgs e)
        {

        }
    }
}
