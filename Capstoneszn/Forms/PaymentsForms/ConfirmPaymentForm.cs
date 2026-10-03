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
}
