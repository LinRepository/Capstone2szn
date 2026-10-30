using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.UserControls.BillingManagement;

namespace Capstoneszn.UserControls
{
    public partial class BillingManagementControl : UserControl
    {

        private int _buildingId;

        public BillingManagementControl(int buildingId)
        {
            InitializeComponent();
            _buildingId = buildingId;

            // ADDED (caretaker restrictions): Expenses is landlord-only.
            // Hide its card and give its row no height, so Room Account
            // fills the screen instead of leaving an empty half.
            if (!Session.IsLandlord)
            {
                pnlExpenses.Visible = false;
                tblBillingOptions.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
            }

        }

        private void lblRoomAccount_Click(object sender, EventArgs e)
        {
            // 1. Create the new Room Account control
            BillingRoomAccountControl accountControl = new BillingRoomAccountControl(_buildingId);

            // 2. Make it fill the parent container
            accountControl.Dock = DockStyle.Fill;

            // 3. Add it to the parent container (the panel on your MainForm)
            this.Parent.Controls.Add(accountControl);

            // 4. Bring it to the front so it covers everything else
            accountControl.BringToFront();

            // 5. Hide this current Billing Management Control
            this.Hide();
        }

        private void lblExpenses_Click(object sender, EventArgs e)
        {
            if (!Session.IsLandlord) return;   // ADDED (caretaker restrictions): landlord only

            // 1. Create the new Expenses control
            BillingExpensesControl expensesControl = new BillingExpensesControl();

            // 2. Make it fill the parent container
            expensesControl.Dock = DockStyle.Fill;

            // 3. Add it to the parent container
            this.Parent.Controls.Add(expensesControl);

            // 4. Bring it to the front
            expensesControl.BringToFront();

            // 5. Hide this current Billing Management Control
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
