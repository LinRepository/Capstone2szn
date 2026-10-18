using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{

    /// <summary>One row of the Audit Logs screen.</summary>
    public class AuditLogRow
    {
        public DateTime LoggedAt { get; set; }
        public string UserName { get; set; } = "";
        public string Role { get; set; } = "";
        public string Module { get; set; } = "";
        public string Action { get; set; } = "";
        public string Description { get; set; } = "";
    }

    /// <summary>Read-only access to the audit trail.</summary>
    public static class AuditLogService
    {
        /// <summary>
        /// This building's entries plus building-independent ones (login),
        /// newest first. fromDate inclusive, toDateExclusive exclusive.
        /// </summary>
        public static List<AuditLogRow> GetLogs(int buildingId, DateTime fromDate, DateTime toDateExclusive)
        {
            var list = new List<AuditLogRow>();

            string sql = @"
                SELECT a.LoggedAt,
                       ISNULL(NULLIF(u.Name, ''), u.Username) AS UserName,
                       u.Role, a.Module, a.Action, a.Description
                FROM   AuditLogs a
                JOIN   Users u ON u.UserId = a.UserId
                WHERE  (a.BuildingId = @bid OR a.BuildingId IS NULL)
                  AND  a.LoggedAt >= @from
                  AND  a.LoggedAt <  @to
                ORDER BY a.LoggedAt DESC, a.AuditId DESC;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = buildingId;
                cmd.Parameters.Add("@from", SqlDbType.DateTime2).Value = fromDate.Date;
                cmd.Parameters.Add("@to", SqlDbType.DateTime2).Value = toDateExclusive.Date;

                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new AuditLogRow
                        {
                            LoggedAt = rd.GetDateTime(0),
                            UserName = rd.GetString(1),
                            Role = rd.GetString(2),
                            Module = rd.GetString(3),
                            Action = rd.GetString(4),
                            Description = rd.GetString(5)
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// The latest entries for the Home dashboard (this building plus
        /// building-independent ones such as login), newest first.
        /// </summary>
        public static List<AuditLogRow> GetRecent(int buildingId, int count)
        {
            var list = new List<AuditLogRow>();

            string sql = @"
                SELECT TOP (@n) a.LoggedAt,
                       ISNULL(NULLIF(u.Name, ''), u.Username) AS UserName,
                       u.Role, a.Module, a.Action, a.Description
                FROM   AuditLogs a
                JOIN   Users u ON u.UserId = a.UserId
                WHERE  a.BuildingId = @bid OR a.BuildingId IS NULL
                ORDER BY a.LoggedAt DESC, a.AuditId DESC;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@n", SqlDbType.Int).Value = count;
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = buildingId;

                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new AuditLogRow
                        {
                            LoggedAt = rd.GetDateTime(0),
                            UserName = rd.GetString(1),
                            Role = rd.GetString(2),
                            Module = rd.GetString(3),
                            Action = rd.GetString(4),
                            Description = rd.GetString(5)
                        });
                    }
                }
            }

            return list;
        }
    }

}
