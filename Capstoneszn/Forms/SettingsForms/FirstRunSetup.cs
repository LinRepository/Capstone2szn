using System;
using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.SettingsForms
{
    // NEW (Nov 21, 2026 - first-run setup of the default landlord account)
    // Checks used by MainForm_Shown when the landlord opens Home:
    //   1. FirstTimeNameForm      - shown while Users.Name is blank (mandatory)
    //   2. Credentials notice     - shown while the default username OR password is still in use
    //   3. Backup reminder        - unchanged rule (no backup today)
    // Nothing is stored to remember these steps: both are worked out from the
    // Users row itself, so no new column is needed.
    public static class FirstRunSetup
    {
        // The fresh-system seed account (DatabaseScript/Seed_DefaultLandlord.sql).
        // Keep these two in sync with the seed script and the user manual.
        public const string DefaultLandlordUsername = "admin";
        public const string DefaultLandlordPassword = "hahahaha";

        // True when the account has no name yet (fresh system: the seed leaves Name NULL).
        public static bool NeedsName(int userId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("SELECT Name FROM Users WHERE UserId = @UserId", conn))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                conn.Open();
                object? result = cmd.ExecuteScalar();
                if (result == null) return false;   // account not found - nothing to set up
                return result == DBNull.Value || string.IsNullOrWhiteSpace((string)result);
            }
        }

        // Option A: true while the default username OR the default password is still in use.
        // The password check uses the stored hash (BCrypt), so the typed password is not needed.
        public static bool IsUsingDefaultCredentials(int userId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("SELECT Username, Password FROM Users WHERE UserId = @UserId", conn))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return false;

                    string username = r.GetString(0);
                    string storedHash = r.GetString(1);

                    // Case-insensitive, because the database collation treats "Admin" and "admin" as the same login.
                    bool defaultUsername = string.Equals(username, DefaultLandlordUsername,
                                                         StringComparison.OrdinalIgnoreCase);
                    bool defaultPassword = SecurityHelper.Verify(DefaultLandlordPassword, storedHash);

                    return defaultUsername || defaultPassword;
                }
            }
        }

        // Saves the landlord's name and records it in the audit log, in one transaction
        // (if the log fails, the name is not saved either - same rule as Edit Profile).
        public static void SaveName(int userId, string name)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SqlCommand(
                            "UPDATE Users SET Name = @Name WHERE UserId = @UserId AND Role = 'Landlord'",
                            conn, tx))
                        {
                            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = name;
                            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

                            if (cmd.ExecuteNonQuery() == 0)
                                throw new InvalidOperationException("Landlord account not found.");
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleSettings, "Set Name",
                            "First-time setup: name set to " + name);

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
