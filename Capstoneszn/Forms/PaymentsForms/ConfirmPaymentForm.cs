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

        public ConfirmPaymentForm()
        {
            InitializeComponent();

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
            
        }
    }
}
