using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;   // NEW (Nov 19): CloseReason for LogAppClosed

namespace Capstoneszn
{

    /// <summary>
    /// Writes to the audit trail (AuditLogs). Two ways to call it:
    ///
    ///   AuditLogger.Log(module, action, description)
    ///       After an action has succeeded. Opens its own connection and
    ///       never throws - a logging problem must not break the user's work.
    ///
    ///   AuditLogger.Log(conn, tx, module, action, description)
    ///       Inside an existing transaction (payments, voids, maintenance).
    ///       The action and its log are saved together or not at all, so a
    ///       failure here rolls the action back - that is intended.
    ///
    /// Who and where come from Session: UserId always; BuildingId when a
    /// building is selected (NULL before that, e.g. at login).
    /// To log a new action later, add one Log(...) call where it succeeds.
    /// </summary>
    public static class AuditLogger
    {
        // Module names used in the log (and in the Audit Logs filter).
        public const string ModuleLogin = "Login";
        public const string ModuleRooms = "Rooms";
        public const string ModuleTenants = "Tenants";
        public const string ModulePayments = "Payments";
        public const string ModuleMaintenance = "Maintenance";
        public const string ModuleEmployee = "Employee";
        public const string ModuleSettings = "Settings";
        public const string ModuleBuildings = "Buildings";   // NEW (Nov 18): Add Building
        public const string ModuleUtilities = "Utilities";   // NEW (Nov 18, 2026): water bills, electricity, utility accounts

        private const string InsertSql = @"
            INSERT INTO AuditLogs (BuildingId, UserId, Module, Action, Description)
            VALUES (@bid, @uid, @module, @action, @desc);";

        /// <summary>Log after success. Never throws.</summary>
        public static void Log(string module, string action, string description)
        {
            if (Session.UserId <= 0) return;   // nobody signed in - nothing to attribute

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(InsertSql, conn))
                {
                    AddParameters(cmd, module, action, description);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Audit log failed: " + ex);
            }
        }

        /// <summary>Log inside the caller's transaction. Throws on failure.</summary>
        public static void Log(SqlConnection conn, SqlTransaction tx,
                               string module, string action, string description)
        {
            if (Session.UserId <= 0)
                throw new InvalidOperationException("No signed-in user to record in the audit log.");

            using (var cmd = new SqlCommand(InsertSql, conn, tx))
            {
                AddParameters(cmd, module, action, description);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// NEW (Nov 18, 2026): same as the transaction version above, but files the
        /// entry under the building given here instead of Session.BuildingId.
        /// Used by Add Building: on the Building Selection screen no building is
        /// selected yet (Session.BuildingId is 0), so the normal version would save
        /// the entry with no building and it would show in every building's logs.
        /// Throws on failure, so the action rolls back with it - same as above.
        /// </summary>
        public static void Log(SqlConnection conn, SqlTransaction tx, int buildingId,
                               string module, string action, string description)
        {
            if (Session.UserId <= 0)
                throw new InvalidOperationException("No signed-in user to record in the audit log.");

            using (var cmd = new SqlCommand(InsertSql, conn, tx))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value =
                    buildingId > 0 ? (object)buildingId : DBNull.Value;
                cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Session.UserId;
                cmd.Parameters.Add("@module", SqlDbType.NVarChar, 30).Value = Cut(module, 30);
                cmd.Parameters.Add("@action", SqlDbType.NVarChar, 30).Value = Cut(action, 30);
                cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 500).Value = Cut(description, 500);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ADDED (Nov 10, 2026): log an event for an account when NOBODY is signed in -
        /// a lockout at the login screen, a Forgot Password lockout, or a password reset
        /// through security questions. Log(...) above skips these because Session.UserId
        /// is 0 before login. The entry is filed under the account it happened to
        /// (userId) with no building, like login entries, so it shows in every
        /// building's Audit Logs. Never throws, same as Log(...).
        /// </summary>
        /// <summary>
        /// NEW (Nov 19, 2026): records a Logout when the app is closed WITHOUT the
        /// Logout button - taskbar X, right-click > Close window, Alt+F4, Task
        /// Manager, or Windows shutting down. Called from the FormClosed event of
        /// MainForm and BuildingSelection.
        ///
        /// Skipped when the sign-out was already handled: the Logout button, a
        /// lockout and the restore all call Session.Clear() (and set LoggingOut)
        /// before closing, so UserId is 0 here and nothing is logged twice.
        /// After logging, the session is cleared so the next window that closes
        /// on the way out (BuildingSelection after MainForm) doesn't log it again.
        /// Never throws. If the app is killed (power loss, End process) no event
        /// runs, so nothing can be logged - a known limit.
        /// </summary>
        public static void LogAppClosed(CloseReason reason)
        {
            if (Session.LoggingOut || Session.UserId <= 0) return;

            string how =
                reason == CloseReason.WindowsShutDown    ? "Windows shut down" :
                reason == CloseReason.TaskManagerClosing ? "closed from Task Manager" :
                                                           "app closed";

            Log(ModuleLogin, "Logout", "Signed out (" + how + ")");
            Session.Clear();   // logged once - the other windows closing after this skip it
        }

        public static void LogForUser(int userId, string module, string action, string description)
        {
            if (userId <= 0) return;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(InsertSql, conn))
                {
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
                    cmd.Parameters.Add("@module", SqlDbType.NVarChar, 30).Value = Cut(module, 30);
                    cmd.Parameters.Add("@action", SqlDbType.NVarChar, 30).Value = Cut(action, 30);
                    cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 500).Value = Cut(description, 500);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Audit log failed: " + ex);
            }
        }

        private static void AddParameters(SqlCommand cmd, string module, string action, string description)
        {
            cmd.Parameters.Add("@bid", SqlDbType.Int).Value =
                Session.BuildingId > 0 ? (object)Session.BuildingId : DBNull.Value;
            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Session.UserId;
            cmd.Parameters.Add("@module", SqlDbType.NVarChar, 30).Value = Cut(module, 30);
            cmd.Parameters.Add("@action", SqlDbType.NVarChar, 30).Value = Cut(action, 30);
            cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 500).Value = Cut(description, 500);
        }

        private static string Cut(string? s, int max)
        {
            s = (s ?? "").Trim();
            if (s.Length == 0) s = "-";
            return s.Length <= max ? s : s.Substring(0, max);
        }

        /* ---- Small lookups for readable descriptions ------------------- */

        public static string RoomNumber(SqlConnection conn, SqlTransaction? tx, int roomId)
        {
            using (var cmd = new SqlCommand("SELECT RoomNumber FROM Rooms WHERE RoomId = @id;", conn, tx))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = roomId;
                return cmd.ExecuteScalar()?.ToString() ?? "#" + roomId;
            }
        }

        public static string TenantName(SqlConnection conn, SqlTransaction? tx, int tenantId)
        {
            using (var cmd = new SqlCommand(
                "SELECT FirstName + ' ' + LastName FROM Tenants WHERE TenantId = @id;", conn, tx))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = tenantId;
                return cmd.ExecuteScalar()?.ToString() ?? "Tenant #" + tenantId;
            }
        }
    }

}
