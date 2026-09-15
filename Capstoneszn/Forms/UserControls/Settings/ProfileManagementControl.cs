using Capstoneszn.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Settings
{
    public partial class ProfileManagementControl : UserControl
    {
        private SettingsControl sc;
        public ProfileManagementControl(SettingsControl parent)
        {
            InitializeComponent();
            sc = parent;
        }

        private void btnBackProfileManagement_Click(object sender, EventArgs e)
        {
            sc.ShowMenuOptions();
            sc.Controls.Remove(this);
        }

    }
}
