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
            MessageBox.Show("Receipt printing isn't available yet.",
                "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAnotherTransaction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Another Transaction isn't available yet.", "Another Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
