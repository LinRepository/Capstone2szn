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

namespace Capstoneszn.Forms.UserControls.Utilities
{
    public partial class AdminWaterBillAccount : UserControl
    {
        public int AccountId { get; private set; }
        public int WaterBillId { get; private set; }
        public DateTime SelectedDate { get; set; } = DateTime.Today;

        private decimal _ownerShare;
        private decimal _paidSoFar;
        public AdminWaterBillAccount()
        {
            InitializeComponent();
        }
        public void LoadAccount()
        {
            
        }
        

        private void btnRecordWaterExpense_Click(object sender, EventArgs e)
        {
            if (AccountId == 0)
            {
                MessageBox.Show("No owner water account is set up yet.", "No account",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (WaterBillId == 0)
            {
                MessageBox.Show($"There's no water bill for {SelectedDate:MMMM yyyy} yet. Add one first.",
                    "No bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_paidSoFar > 0)
            {
                MessageBox.Show(
                    $"The owner's water share for {SelectedDate:MMMM yyyy} is already fully paid.\n\n" +
                    "Paid bills are locked and can't be recorded again.",
                    "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var rwef = new RecordWaterExpenseForm(WaterBillId, _ownerShare);

            if (rwef.ShowDialog(this) == DialogResult.OK)
                LoadAccount();
        }
    }
}
