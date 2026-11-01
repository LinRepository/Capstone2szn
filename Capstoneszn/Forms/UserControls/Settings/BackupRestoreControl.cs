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

        // ============================================================================
        // PART 1 — BackupRestoreControl.cs
        // ============================================================================
        // Add at the top of the file if missing:
        //   using Capstoneszn.Forms.SettingsForms;   // RestoreConfirmForm
        //   (plus the namespace of MainForm, if it is different from this file's)
        //
        // REPLACE your empty handler:
        //     private void btnRestoreData_Click(object sender, EventArgs e) { }
        // with the method below (note: it is now "async").
        // Also add the LogOut helper method below it.
        //
        // TODO: Session.UserId -> use your real property for the logged-in user's id
        //       (the same value SettingsControl passes as CurrentUserId).

        private async void btnRestoreData_Click(object sender, EventArgs e)
        {
            // ----- 1. Pick the backup file (from this PC or a flash drive) -----
            string selectedFile;
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select a backup to restore (from this PC or a flash drive)";
                dlg.Filter = "Backup files (*.bak)|*.bak";
                string lastFolder = BackupService.GetLastFolder();
                if (lastFolder.Length > 0) dlg.InitialDirectory = lastFolder;

                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                selectedFile = dlg.FileName;
            }

            string restoreFile = selectedFile;
            BackupFileInfo info;

            try
            {
                // ----- 2. From a flash drive? Copy it to the PC first -----
                if (BackupService.IsOnRemovableDrive(selectedFile))
                {
                    string pcFolder = BackupService.GetLastFolder();
                    if (pcFolder.Length == 0)
                    {
                        using (var folderDlg = new FolderBrowserDialog())
                        {
                            folderDlg.Description = "Select a folder on this PC to copy the backup into (e.g. C:\\CapstoneBackupRestore)";
                            folderDlg.UseDescriptionForTitle = true;
                            if (folderDlg.ShowDialog(this) != DialogResult.OK) return;
                            pcFolder = folderDlg.SelectedPath;
                        }
                    }

                    SetBusy(true, "Copying the backup from the flash drive to this PC...");
                    restoreFile = await BackupService.StageToFolderAsync(selectedFile, pcFolder);
                }

                // ----- 3. Check the file is a real, complete ApartmentDB backup -----
                SetBusy(true, "Checking the backup file...");
                info = await BackupService.ReadBackupHeaderAsync(restoreFile);

                if (!string.Equals(info.DatabaseName, "ApartmentDB", StringComparison.OrdinalIgnoreCase)
                    || info.BackupType != 1)
                {
                    SetBusy(false);
                    await RefreshStatusAsync();
                    MessageBox.Show("The selected file is not a full backup of this system's database.",
                        "Invalid Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await BackupService.VerifyBackupAsync(restoreFile);
            }
            catch (SqlException ex)
            {
                SetBusy(false);
                await RefreshStatusAsync();
                MessageBox.Show("The selected file could not be read as a valid backup.\n\n" +
                                BackupService.DescribeError(ex), "Invalid Backup",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException
                                       || ex is InvalidOperationException)
            {
                SetBusy(false);
                await RefreshStatusAsync();
                MessageBox.Show(ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetBusy(false);
            await RefreshStatusAsync();

            // ----- 4. Confirm (shows the backup date) + password -----
            while (true)
            {
                string password;
                using (var confirm = new RestoreConfirmForm(Path.GetFileName(restoreFile), info.BackupDate))
                {
                    if (confirm.ShowDialog(this) != DialogResult.OK) return;   // cancelled
                    password = confirm.Password;
                }

                if (password.Length == 0)   // blank does not count as an attempt
                {
                    MessageBox.Show("Enter your password to continue.", "Restore",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                PasswordCheckResult check;
                try
                {
                    check = ProfileRepository.VerifyPassword(Session.UserId, password);   // TODO: Session.UserId
                }
                catch (SqlException)
                {
                    MessageBox.Show("Unable to verify your password. Please try again.", "Restore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (check == PasswordCheckResult.Ok) break;

                if (check == PasswordCheckResult.WrongPassword)
                {
                    MessageBox.Show("Incorrect password.", "Restore",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                // LockedNow / AlreadyLocked
                MessageBox.Show("Too many incorrect attempts. Your account is temporarily locked " +
                                "and you will be logged out.", "Account Locked",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                LogOut(afterRestore: false);
                return;
            }

            // ----- 5. Safety backup of the CURRENT data (same PC folder) -----
            string safetyFile = Path.Combine(Path.GetDirectoryName(restoreFile)!,
                                             BackupService.BuildFileName("ApartmentDB_PreRestore"));

            SetBusy(true, "Making a safety backup of the current data...");
            try
            {
                await BackupService.BackupAsync(safetyFile, "ApartmentDB PreRestore Safety Backup");
            }
            catch (SqlException ex)
            {
                SetBusy(false);
                await RefreshStatusAsync();
                MessageBox.Show("The safety backup failed, so the restore was cancelled. Your data was not changed.\n\n" +
                                BackupService.DescribeError(ex), "Restore Cancelled",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ----- 6. Restore -----
            SetBusy(true, "Restoring... please wait. Do not close the system.");
            try
            {
                await BackupService.RestoreAsync(restoreFile);
            }
            catch (Exception ex) when (ex is SqlException || ex is InvalidOperationException)
            {
                SetBusy(false);
                await RefreshStatusAsync();
                MessageBox.Show("The restore failed.\n\n" + ex.Message + "\n\n" +
                                "If the system shows errors afterwards, restore this safety backup:\n" + safetyFile,
                                "Restore Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ----- 7. Done -> automatic logout -----
            MessageBox.Show("Restore complete.\n\nThe data now matches the backup from " +
                            info.BackupDate.ToString("MMMM d, yyyy h:mm tt") + ".\n" +
                            "Safety backup of the previous data:\n" + safetyFile + "\n\n" +
                            "You will now be logged out.", "Restore Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            LogOut(afterRestore: true);
        }

        private void LogOut(bool afterRestore)
        {
            if (this.FindForm() is MainForm main)
            {
                if (afterRestore) main.LogoutAfterRestore();
                else main.ForceLogout();   // lockout
            }
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
