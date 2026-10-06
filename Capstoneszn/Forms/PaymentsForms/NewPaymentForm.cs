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
    public partial class New_Make_Payment : Form
    {
        public New_Make_Payment()
        {
            InitializeComponent();

            RadioBtnCash.Checked = true;
            RadioBtnCash.CheckedChanged += PaymentMethod_Changed;
            RadioBtnGCash.CheckedChanged += PaymentMethod_Changed;
            PaymentMethod_Changed(null, EventArgs.Empty);
        }

        private void New_Make_Payment_Load(object sender, EventArgs e)
        {

        }
        private void PaymentMethod_Changed(object? sender, EventArgs e)
        {
            bool isGCash = RadioBtnGCash.Checked;

            lblReferenceNumber.Visible = isGCash;
            txtReferenceNumber.Visible = isGCash;

            if (!isGCash) txtReferenceNumber.Clear();
        }
    }
}
