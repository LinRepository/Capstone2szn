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
using Capstoneszn.Forms.RoomsForms;

namespace Capstoneszn.UserControls
{
    public partial class MoveInForm : Form
    {

        private int _roomId;

        public MoveInForm(int roomId)
        {
            InitializeComponent();

            _roomId = roomId;

            txtContactNumber.KeyPress += NumericOnly_KeyPress;
            txtContactNumber.MaxLength = 20;
            dtpMoveInDate.Value = DateTime.Today;
            dtpMoveInDate.Enabled = false;
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
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
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text))
            {
                MessageBox.Show("First name and last name are required.",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtContactNumber.Text.Trim().Length < 10)
            {
                MessageBox.Show("Please enter a valid contact number.",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var data = new MoveInData
            {
                RoomId = _roomId,
                FirstName = txtFName.Text.Trim(),
                MiddleName = txtMName.Text.Trim(),
                LastName = txtLName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactNumber = txtContactNumber.Text.Trim(),
                DateOccupied = dtpMoveInDate.Value.Date
            };

            using (PaymentForm pay = new PaymentForm(data))
            {
                if (pay.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;   // success relays upward
                    this.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Clear();
            txtMName.Clear();
            txtLName.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            dtpMoveInDate.Value = DateTime.Today;
        }
    }
}
