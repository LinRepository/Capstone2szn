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
using Capstoneszn.Forms.SettingsForms;

namespace Capstoneszn.Forms.UserControls.Settings
{
    public partial class ProfileManagementControl : UserControl
    {
        public int CurrentUserId { get; set; } = 1;
        //private SettingsControl sc;
        public ProfileManagementControl()
        {
            InitializeComponent();
        }

        private void btnBackProfileManagement_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            using (EditProfileForm editForm = new EditProfileForm(
            CurrentUserId,
            lblProfileNameValue.Text,
            lblProfileRoleValue.Text,
            lblProfileUsernameValue.Text))
            {
                editForm.StartPosition = FormStartPosition.CenterScreen;
                editForm.TopMost = true;
                editForm.WindowState = FormWindowState.Normal;
                editForm.ShowDialog();
                editForm.StartPosition = FormStartPosition.CenterParent;

                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    lblProfileNameValue.Text = editForm.UpdatedName;         // from txtName
                    lblProfileUsernameValue.Text = editForm.UpdatedUsername; // from txtUsername (already saved to DB)
                }
            }
            MessageBox.Show("Edit Profile clicked");
        }
    }
}
