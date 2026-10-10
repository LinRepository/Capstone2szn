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
using Capstoneszn.Forms.SettingsForms;

namespace Capstoneszn.Forms.UserControls.Settings
{
    public partial class ElectricWaterAccountControl : UserControl
    {
        public ElectricWaterAccountControl()
        {
            InitializeComponent();
        }

        private void btnBackElectricWater_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }

        private void btnAddElectricityAccount_Click(object sender, EventArgs e)
        {
            AddUtilityAccountForm addutilaccountform = new AddUtilityAccountForm();
            addutilaccountform.ShowDialog();
        }

        private void btnAddWaterAccount_Click(object sender, EventArgs e)
        {
            AddUtilityAccountForm addutilaccountform = new AddUtilityAccountForm();
            addutilaccountform.ShowDialog();
        }

        private void flpElectricityAccounts_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
