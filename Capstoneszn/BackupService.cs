using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{

    public class BackupStatus
    {
        public DateTime? LastBackup { get; set; }
        public string? LastBackupFile { get; set; }
        public DateTime? LastRestore { get; set; }
    }

    public static class BackupService
    {
        private const string DatabaseName = "ApartmentDB";

        // Use the SAME connection string as ProfileRepository.cs
        // Ayano18 laptop = @"Server=LAPTOP-TRR0U4GS\SQLEXPRESS;Database=ApartmentDB;Integrated Security=True;TrustServerCertificate=True;"
        private static string ConnStr =>
            @"Server=LAPTOP-TRR0U4GS\SQLEXPRESS;Database=ApartmentDB;Integrated Security=True;TrustServerCertificate=True;";

        // Backup/restore commands run from the "master" database, not ApartmentDB.
        private static string MasterConnStr =>
            new SqlConnectionStringBuilder(ConnStr) { InitialCatalog = "master" }.ConnectionString;

        // Remembers the last folder used (one small text file per Windows user on this PC).
        private static readonly string LastFolderFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Capstoneszn", "last_backup_folder.txt");

        // ---------------------------------------------------------------
        // File name / last folder
        // ---------------------------------------------------------------

        public static string BuildFileName(string prefix = "ApartmentDB")
        {
            return $"{prefix}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
        }

        public static string GetLastFolder()
        {
            try
            {
                if (File.Exists(LastFolderFile))
                {
                    string folder = File.ReadAllText(LastFolderFile).Trim();
                    if (Directory.Exists(folder)) return folder;
                }
            }
            catch { /* not critical — fall back to the dialog's default */ }

            return string.Empty;
        }

        public static void SaveLastFolder(string folder)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LastFolderFile)!);
                File.WriteAllText(LastFolderFile, folder);
            }
            catch { /* not critical */ }
        }

        // ---------------------------------------------------------------
        // Backup
        // ---------------------------------------------------------------

        // Full backup of the whole database. CHECKSUM lets SQL Server detect corruption.
        // Note: SQL Server's service account writes this file, not the Windows user.
        public static async Task BackupAsync(string filePath, string backupName)
        {
            const string sql = @"BACKUP DATABASE [ApartmentDB]
                                 TO DISK = @Path
                                 WITH INIT, CHECKSUM, NAME = @Name;";

            using (var conn = new SqlConnection(MasterConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandTimeout = 0;   // no timeout — a backup can take a while
                cmd.Parameters.AddWithValue("@Path", filePath);
                cmd.Parameters.AddWithValue("@Name", backupName);
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        // Copies a finished backup file to another folder (e.g. a flash drive).
        // The APP copies it (Windows user), so the SQL service permission issue doesn't apply.
        public static async Task<string> CopyBackupAsync(string sourceFile, string destinationFolder)
        {
            string destFile = Path.Combine(destinationFolder, Path.GetFileName(sourceFile));

            await Task.Run(() => File.Copy(sourceFile, destFile, overwrite: false));

            // Verify the copy is complete
            long sourceSize = new FileInfo(sourceFile).Length;
            long destSize = new FileInfo(destFile).Length;
            if (sourceSize != destSize)
                throw new IOException("The copied file is incomplete. Please try again.");

            return destFile;
        }

        // ---------------------------------------------------------------
        // Status (read from msdb, so a restore can't erase this history)
        // ---------------------------------------------------------------

        public static async Task<BackupStatus> GetStatusAsync()
        {
            const string sql = @"
                SELECT TOP 1 b.backup_finish_date, m.physical_device_name
                FROM msdb.dbo.backupset b
                JOIN msdb.dbo.backupmediafamily m ON b.media_set_id = m.media_set_id
                WHERE b.database_name = @Db AND b.type = 'D'
                ORDER BY b.backup_finish_date DESC;

                SELECT TOP 1 restore_date
                FROM msdb.dbo.restorehistory
                WHERE destination_database_name = @Db
                ORDER BY restore_date DESC;";

            var status = new BackupStatus();

            using (var conn = new SqlConnection(MasterConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Db", DatabaseName);
                await conn.OpenAsync();
                using (var r = await cmd.ExecuteReaderAsync())
                {
                    if (await r.ReadAsync())
                    {
                        status.LastBackup = r.GetDateTime(0);
                        status.LastBackupFile = r.GetString(1);
                    }

                    if (await r.NextResultAsync() && await r.ReadAsync())
                    {
                        status.LastRestore = r.GetDateTime(0);
                    }
                }
            }

            return status;
        }

        // For the daily reminder (step 4): true if a backup was made today.
        public static async Task<bool> HasBackupTodayAsync()
        {
            BackupStatus s = await GetStatusAsync();
            return s.LastBackup.HasValue && s.LastBackup.Value.Date == DateTime.Today;
        }

        // ---------------------------------------------------------------
        // Friendly error messages
        // ---------------------------------------------------------------

        public static string DescribeError(SqlException ex)
        {
            foreach (SqlError err in ex.Errors)
            {
                if (err.Message.Contains("Operating system error 5"))
                {
                    return "SQL Server is not allowed to save in that folder (access denied).\n\n" +
                           "Please choose another folder, for example C:\\KSU_Backups, " +
                           "or a flash drive.";
                }
                if (err.Message.Contains("Operating system error 3"))
                {
                    return "The selected folder could not be found. Please choose another folder.";
                }
                if (err.Message.Contains("Operating system error 112"))
                {
                    return "There is not enough free space in the selected location.";
                }
            }

            return "The operation failed.\n\nDetails: " + ex.Message;
        }
    }

}
