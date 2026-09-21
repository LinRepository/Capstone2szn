using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.UserControls
{
    public partial class MoveInForm : Form
    {

        private int _roomId;
        public MoveInForm(int roomId)
        {
            InitializeComponent();

            _roomId = roomId;
        }

        private void btnCancelMoveIn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MoveInForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmMoveIn_Click(object sender, EventArgs e)
        {
            string tenantName = txtTenantName.Text.Trim();
            string contactNumber = txtContactNumber.Text.Trim();
            DateTime moveInDate = dtpMoveInDate.Value;

            if (string.IsNullOrEmpty(tenantName))
            {
                MessageBox.Show("Please enter the tenant's name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Instead of saving to the database, pass the data to the Payment Form
            using (PaymentForm paymentForm = new PaymentForm(_roomId, tenantName, contactNumber, moveInDate))
            {
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    // If the payment cascade finishes successfully, close this form too
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
