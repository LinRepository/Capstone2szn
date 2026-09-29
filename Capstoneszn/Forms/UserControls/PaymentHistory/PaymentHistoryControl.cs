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
using Capstoneszn.Forms.UserControls.Utilities;

namespace Capstoneszn.UserControls
{
    public partial class PaymentHistoryControl : UserControl
    {
        public PaymentHistoryControl()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].HeaderText == "Reciept")
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                string date = row.Cells[0].Value?.ToString() ?? " ";          // "08/19/2026"
                string receivedFrom = row.Cells[3].Value?.ToString() ?? " ";  // "RM 304"
                string amount = row.Cells[5].Value?.ToString() ?? " ";        // "₱6,000.00"

                // Pass variables to Receipt form
                Receipt receiptForm = new Receipt(date, receivedFrom, amount);
                receiptForm.ShowDialog(this);
            }
        }

        private void PaymentHistoryControl_Load(object sender, EventArgs e)
        {
            // 1. Add sample data
            dataGridView2.Rows.Add("08/19/2026", "02:30 PM", "Linwel Abayon", "304", "Rent", "₱67,000.00", "View");
        }
    }
}
