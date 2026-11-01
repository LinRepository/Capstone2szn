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

namespace Capstoneszn.Forms.UserControls.Settings
{
    public partial class BackupRestoreControl : UserControl
    {

        private bool isBusy = false;

        public BackupRestoreControl()
        {
            InitializeComponent();
        }

        public async Task RefreshStatusAsync()
        {
            try
            {
                BackupStatus s = await BackupService.GetStatusAsync();

                string lastBackup = s.LastBackup.HasValue
                    ? s.LastBackup.Value.ToString("MMM d, yyyy h:mm tt")
                    : "None yet";

                string lastRestore = s.LastRestore.HasValue
                    ? s.LastRestore.Value.ToString("MMM d, yyyy h:mm tt")
                    : "None";

                lblBackUpUpdate.Text = "Last backup: " + lastBackup + Environment.NewLine +
                                       "Last restore: " + lastRestore;
            }
            catch (SqlException)
            {
                lblBackUpUpdate.Text = "Last status of Backup and Restore: unavailable";
            }
        }

        private void btnBackBackupRestore_Click(object sender, EventArgs e)
        {
            if (isBusy) return;   // don't leave the screen in the middle of a backup

            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void btnRestoreData_Click(object sender, EventArgs e)
        {

        }

        private async void btnBackupData_Click(object sender, EventArgs e)
        {
            // 1. Choose where to save (starts in the last folder used)
            string filePath;
            using (var dlg = new SaveFileDialog())
            {
                dlg.Title = "Save Backup";
                dlg.Filter = "Backup files (*.bak)|*.bak";
                dlg.DefaultExt = "bak";
                dlg.AddExtension = true;
                dlg.OverwritePrompt = true;
                dlg.FileName = BackupService.BuildFileName();

                string lastFolder = BackupService.GetLastFolder();
                if (lastFolder.Length > 0) dlg.InitialDirectory = lastFolder;

                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                filePath = dlg.FileName;
            }

            // 2. Run the backup
            SetBusy(true, "Backing up... please wait.");
            try
            {
                await BackupService.BackupAsync(filePath, "ApartmentDB Full Backup");
            }
            catch (SqlException ex)
            {
                SetBusy(false);
                await RefreshStatusAsync();
                MessageBox.Show(BackupService.DescribeError(ex), "Backup Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BackupService.SaveLastFolder(Path.GetDirectoryName(filePath));

            // TODO (audit): add a backup entry to Audit Logs, using the same pattern as your
            // other modules, e.g.:
            // AuditLogger.Log(AuditLogger.ModuleSettings, "Backup", "Database backed up to " + filePath);

            SetBusy(false);
            await RefreshStatusAsync();

            // 3. Success message
            string sizeText = "";
            try
            {
                double mb = new FileInfo(filePath).Length / 1024.0 / 1024.0;
                sizeText = $"\nSize: {mb:0.00} MB";
            }
            catch { /* size is only informational */ }

            MessageBox.Show("Backup completed successfully.\n\nSaved to:\n" + filePath + sizeText,
                "Backup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 4. Optional second copy on a flash drive
            DialogResult copy = MessageBox.Show(
                "Do you also want to copy this backup to a flash drive as a second copy?",
                "Copy to Flash Drive", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (copy == DialogResult.Yes)
            {
                await CopyToFlashDriveAsync(filePath);
            }
        }

        // ===============================================================
        // FLOW A — Status label
        // ===============================================================

        private async void BackupRestoreControl_Load(object sender, EventArgs e)
        {
            await RefreshStatusAsync();
        }

        

        private async Task CopyToFlashDriveAsync(string backupFile)
        {
            string folder;
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select the flash drive (or a folder on it)";
                dlg.UseDescriptionForTitle = true;
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                folder = dlg.SelectedPath;
            }

            // Warn if the chosen location is not a removable drive
            try
            {
                var drive = new DriveInfo(Path.GetPathRoot(folder));
                if (drive.DriveType != DriveType.Removable)
                {
                    DialogResult go = MessageBox.Show(
                        "The selected location does not look like a flash drive.\n" +
                        "A second copy on the same PC will not protect your data if the PC is damaged.\n\n" +
                        "Copy anyway?", "Not a Flash Drive",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (go != DialogResult.Yes) return;
                }
            }
            catch { /* if the drive type can't be read, just continue */ }

            SetBusy(true, "Copying to flash drive... do not remove the flash drive.");
            try
            {
                string dest = await BackupService.CopyBackupAsync(backupFile, folder);
                MessageBox.Show("Backup copied to:\n" + dest, "Copy Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("The copy to the flash drive failed. The backup on the PC is still safe.\n\n" +
                                "Details: " + ex.Message, "Copy Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false);
                await RefreshStatusAsync();
            }
        }

        // ===============================================================
        // Helpers
        // ===============================================================

        private void SetBusy(bool busy, string message = null)
        {
            isBusy = busy;
            btnBackupData.Enabled = !busy;
            btnRestoreData.Enabled = !busy;
            btnBackBackupRestore.Enabled = !busy;
            this.UseWaitCursor = busy;

            if (busy && message != null)
            {
                lblBackUpUpdate.Text = message;
            }
        }

    }
}
