using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

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
