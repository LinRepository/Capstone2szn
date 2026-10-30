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

            // ADDED (caretaker restrictions): Backup & Restore (row 1) and
            // Archive (row 3) are landlord-only. Hide the cards and give their
            // rows no height, so the remaining cards close the gaps.
            if (!Session.IsLandlord)
            {
                pnlBackupRestore.Visible = false;
                pnlArchive.Visible = false;
                tblSettingsOptions.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
                tblSettingsOptions.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
            }
        }



        private void lblBackupRestore_Click(object sender, EventArgs e)
        {
            if (!Session.IsLandlord) return;   // ADDED (caretaker restrictions): landlord only

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
            if (!Session.IsLandlord) return;   // ADDED (caretaker restrictions): landlord only

            ArchiveControl archiveCtrl = new ArchiveControl();
            archiveCtrl.Dock = DockStyle.Fill;

            pnlSettingsContent.Controls.Add(archiveCtrl);
            archiveCtrl.BringToFront();
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