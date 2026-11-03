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
        public string LastBackupFile { get; set; }
        public DateTime? LastRestore { get; set; }
    }

    public class BackupFileInfo
    {
        public string DatabaseName { get; set; } = "";
        public DateTime BackupDate { get; set; }
        public int BackupType { get; set; }
    }

    public static class BackupService
    {
        private const string DatabaseName = "ApartmentDB";

        // Use the SAME connection string as ProfileRepository.cs
        // Ayano18 laptop = @"Server=LAPTOP-TRR0U4GS\SQLEXPRESS;Database=ApartmentDB;Integrated Security=True;TrustServerCertificate=True;"
        private static string ConnStr =>
           @"Server=LAPTOP-1LRDH7J7\SQLEXPRESS;Database=ApartmentDB;Integrated Security=True;TrustServerCertificate=True;";

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
                Directory.CreateDirectory(Path.GetDirectoryName(LastFolderFile));
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

        // ===============================================================
        // RESTORE (added in step 3)
        // ===============================================================

        // True if the file is on a flash drive / removable drive.
        public static bool IsOnRemovableDrive(string path)
        {
            try
            {
                var drive = new DriveInfo(Path.GetPathRoot(path)!);
                return drive.DriveType == DriveType.Removable;
            }
            catch
            {
                return false;
            }
        }

        // Copies a backup from the flash drive into a PC folder, so the restore never
        // reads directly from the flash drive (unplugging it mid-restore can't break the DB).
        public static async Task<string> StageToFolderAsync(string sourceFile, string pcFolder)
        {
            string destFile = Path.Combine(pcFolder, Path.GetFileName(sourceFile));

            if (File.Exists(destFile))
            {
                // Same backup already on the PC (same name and size) -> just use it
                if (new FileInfo(destFile).Length == new FileInfo(sourceFile).Length)
                    return destFile;

                destFile = Path.Combine(pcFolder,
                    Path.GetFileNameWithoutExtension(sourceFile) +
                    $"_fromFlash_{DateTime.Now:yyyyMMdd_HHmmss}.bak");
            }

            await Task.Run(() => File.Copy(sourceFile, destFile, overwrite: false));

            if (new FileInfo(destFile).Length != new FileInfo(sourceFile).Length)
                throw new IOException("The file copied from the flash drive is incomplete. Please try again.");

            return destFile;
        }

        // Reads the backup's header: which database it is, when it was made, and its type.
        public static async Task<BackupFileInfo> ReadBackupHeaderAsync(string filePath)
        {
            using (var conn = new SqlConnection(MasterConnStr))
            using (var cmd = new SqlCommand("RESTORE HEADERONLY FROM DISK = @Path;", conn))
            {
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@Path", filePath);
                await conn.OpenAsync();
                using (var r = await cmd.ExecuteReaderAsync())
                {
                    if (!await r.ReadAsync())
                        throw new InvalidOperationException("The selected file contains no backup.");

                    return new BackupFileInfo
                    {
                        DatabaseName = Convert.ToString(r["DatabaseName"]) ?? "",
                        BackupDate = Convert.ToDateTime(r["BackupFinishDate"]),
                        BackupType = Convert.ToInt32(r["BackupType"])   // 1 = full database backup
                    };
                }
            }
        }

        // Checks that the backup file is complete and readable (without restoring it).
        public static async Task VerifyBackupAsync(string filePath)
        {
            using (var conn = new SqlConnection(MasterConnStr))
            using (var cmd = new SqlCommand("RESTORE VERIFYONLY FROM DISK = @Path;", conn))
            {
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@Path", filePath);
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        // Replaces ApartmentDB with the backup.
        // The data/log files are restored to the SAME location the current database uses,
        // so a backup made on another PC (different SQL folders) still restores here.
        public static async Task RestoreAsync(string filePath)
        {
            SqlConnection.ClearAllPools();   // release the app's own open connections

            using (var conn = new SqlConnection(MasterConnStr))
            {
                await conn.OpenAsync();

                // 1. Logical file names inside the backup
                string? dataLogical = null, logLogical = null;
                int dataCount = 0, logCount = 0;

                using (var cmd = new SqlCommand("RESTORE FILELISTONLY FROM DISK = @Path;", conn))
                {
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Path", filePath);
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            string type = Convert.ToString(r["Type"]) ?? "";
                            if (type == "D") { dataLogical = Convert.ToString(r["LogicalName"]); dataCount++; }
                            else if (type == "L") { logLogical = Convert.ToString(r["LogicalName"]); logCount++; }
                        }
                    }
                }

                if (dataCount != 1 || logCount != 1 || dataLogical == null || logLogical == null)
                    throw new InvalidOperationException("This backup has an unexpected file layout and cannot be restored by the system.");

                // 2. Where the current database files are (fallback: SQL Server's default folders)
                string? dataPath = null, logPath = null;

                using (var cmd = new SqlCommand(@"
                    SELECT type_desc, physical_name FROM sys.master_files
                    WHERE database_id = DB_ID(@Db);", conn))
                {
                    cmd.Parameters.AddWithValue("@Db", DatabaseName);
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            string typeDesc = r.GetString(0);
                            if (typeDesc == "ROWS" && dataPath == null) dataPath = r.GetString(1);
                            else if (typeDesc == "LOG" && logPath == null) logPath = r.GetString(1);
                        }
                    }
                }

                if (dataPath == null || logPath == null)
                {
                    using (var cmd = new SqlCommand(@"
                        SELECT CAST(SERVERPROPERTY('InstanceDefaultDataPath') AS nvarchar(260)),
                               CAST(SERVERPROPERTY('InstanceDefaultLogPath')  AS nvarchar(260));", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        await r.ReadAsync();
                        dataPath ??= Path.Combine(r.GetString(0), "ApartmentDB.mdf");
                        logPath ??= Path.Combine(r.GetString(1), "ApartmentDB_log.ldf");
                    }
                }

                // 3. Exclusive access -> restore -> back to normal
                const string restoreSql = @"
                    IF DB_ID(@Db) IS NOT NULL
                        ALTER DATABASE [ApartmentDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

                    RESTORE DATABASE [ApartmentDB]
                    FROM DISK = @Path
                    WITH REPLACE,
                         MOVE @DataLogical TO @DataPath,
                         MOVE @LogLogical  TO @LogPath;

                    ALTER DATABASE [ApartmentDB] SET MULTI_USER;";

                try
                {
                    using (var cmd = new SqlCommand(restoreSql, conn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@Db", DatabaseName);
                        cmd.Parameters.AddWithValue("@Path", filePath);
                        cmd.Parameters.AddWithValue("@DataLogical", dataLogical);
                        cmd.Parameters.AddWithValue("@DataPath", dataPath);
                        cmd.Parameters.AddWithValue("@LogLogical", logLogical);
                        cmd.Parameters.AddWithValue("@LogPath", logPath);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                catch (SqlException)
                {
                    // Never leave the database stuck in single-user mode
                    try
                    {
                        using (var fix = new SqlCommand(
                            "IF DB_ID('ApartmentDB') IS NOT NULL ALTER DATABASE [ApartmentDB] SET MULTI_USER;", conn))
                        {
                            await fix.ExecuteNonQueryAsync();
                        }
                    }
                    catch { /* reported by the original error below */ }

                    throw;
                }
                finally
                {
                    SqlConnection.ClearAllPools();
                }
            }
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
