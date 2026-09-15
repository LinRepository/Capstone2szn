using Capstoneszn.Forms.UserControls.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.UserControls
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void lblProfileManagement_Click(object sender, EventArgs e)
        {
            // 1. Hide the options menu layout
            tblSettingsOptions.Visible = false;

            // 2. Instantiate and show the profile control instance
            ProfileManagementControl profileControl = new ProfileManagementControl(this);
            profileControl.Dock = DockStyle.Fill;

            // 3. Add to SettingsControl and bring it to front
            this.Controls.Add(profileControl);
            profileControl.BringToFront();
        }
        public void ShowMenuOptions()
        {
            tblSettingsOptions.Visible = true;
        }
    }
}