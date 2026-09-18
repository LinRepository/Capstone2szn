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



        private void lblBackupRestore_Click(object sender, EventArgs e)
        {
            BackupRestoreControl backupCtrl = new BackupRestoreControl();
            backupCtrl.Dock = DockStyle.Fill;

            pnlSettingsContent.Controls.Add(backupCtrl);
            backupCtrl.BringToFront();
        }

        private void lblUtilitiesAccount_Click(object sender, EventArgs e)
        {
            // Assuming ElectricWaterAccountControl is the main utilities view
            ElectricWaterAccountControl utilitiesCtrl = new ElectricWaterAccountControl();
            utilitiesCtrl.Dock = DockStyle.Fill;

            pnlSettingsContent.Controls.Add(utilitiesCtrl);
            utilitiesCtrl.BringToFront();
        }

        private void lblArchive_Click(object sender, EventArgs e)
        {
            ArchiveControl archiveCtrl = new ArchiveControl();
            archiveCtrl.Dock = DockStyle.Fill;

            pnlSettingsContent.Controls.Add(archiveCtrl);
            archiveCtrl.BringToFront();
        }

        private void lblSalary_Click(object sender, EventArgs e)
        {
            SalaryControl salaryCtrl = new SalaryControl();
            salaryCtrl.Dock = DockStyle.Fill;

            pnlSettingsContent.Controls.Add(salaryCtrl);
            salaryCtrl.BringToFront();
        }

        private void lblProfileManagement_Click(object sender, EventArgs e)
        {
            ProfileManagementControl profileCtrl = new ProfileManagementControl();
            profileCtrl.Dock = DockStyle.Fill;

            // Add it directly inside the settings content panel
            pnlSettingsContent.Controls.Add(profileCtrl);
            profileCtrl.BringToFront();
        }
    }
}