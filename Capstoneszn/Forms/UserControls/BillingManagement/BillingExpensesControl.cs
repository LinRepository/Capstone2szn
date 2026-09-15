using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.UserControls;

namespace Capstoneszn.Forms.UserControls.BillingManagement
{
    public partial class BillingExpensesControl : UserControl
    {
        public BillingExpensesControl()
        {
            InitializeComponent();
        }

        private void btnBackExpenses_Click(object sender, EventArgs e)
        {
            // Loop through the controls in the parent panel to find the Billing Management Control
            foreach (Control ctrl in this.Parent.Controls)
            {
                if (ctrl is BillingManagementControl)
                {
                    // Show it and bring it to the front
                    ctrl.Show();
                    ctrl.BringToFront();
                    break;
                }
            }

            // Remove THIS Expenses control from the parent panel and dispose of it
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
