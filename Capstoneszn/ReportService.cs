using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{

    /// <summary>A room in the Reports room filter.</summary>
    public class ReportRoom
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = "";
        public override string ToString() => "Room " + RoomNumber;
    }

    /// <summary>One payment received, as listed in Reports.</summary>
    public class ReportReceivedRow
    {
        public DateTime PaymentDate { get; set; }
        public string ReceiptNo { get; set; } = "";
        public string TenantName { get; set; } = "";
        public string RoomNumber { get; set; } = "";
        public string Category { get; set; } = "";
        public string Method { get; set; } = "";
        public decimal Amount { get; set; }
    }

    /// <summary>
    /// Read-only data for the Reports module.
    ///
    /// Settled income rule: only RENT is the landlord's income. Water and
    /// maintenance collections reimburse money the landlord pays out for the
    /// tenants (the water facility, the materials), so they are reported
    /// but kept out of profit:
    ///     Net Income = Rent collected - Expenses
    ///
    /// Voided payments are never counted. Expenses come from ExpenseService
    /// (the same source as Bill Management > Expenses).
    /// </summary>
    public static class ReportService
    {
        public static string GetBuildingName(int buildingId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT BuildingName FROM Buildings WHERE BuildingId = @bid;", conn))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = buildingId;
                conn.Open();
                return cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }

        /// <summary>
        /// Every room of the building, archived ones included - an archived
        /// room can still have payments inside the chosen period.
        /// </summary>
        public static List<ReportRoom> GetRooms(int buildingId)
        {
            var list = new List<ReportRoom>();

            string sql = @"
                SELECT RoomId, RoomNumber
                FROM   Rooms
                WHERE  BuildingId = @bid
                ORDER BY RoomNumber;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = buildingId;
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(new ReportRoom { RoomId = rd.GetInt32(0), RoomNumber = rd.GetString(1) });
                }
            }

            return list;
        }

        /// <summary>
        /// Valid (not voided) payments of the building, oldest first.
        /// fromDate inclusive, toDateExclusive exclusive. roomId null = all rooms.
        /// </summary>
        public static List<ReportReceivedRow> GetReceived(
            int buildingId, DateTime fromDate, DateTime toDateExclusive, int? roomId)
        {
            var list = new List<ReportReceivedRow>();

            string sql = @"
                SELECT p.PaymentDate, p.ReceiptNo,
                       t.FirstName + ' ' + t.LastName AS TenantName,
                       r.RoomNumber, p.PaymentCategory, p.PaymentMethod, p.Amount
                FROM   Payments p
                JOIN   Tenants t ON t.TenantId = p.TenantId
                JOIN   Rooms   r ON r.RoomId   = p.RoomId
                WHERE  r.BuildingId = @bid
                  AND  p.IsVoided = 0
                  AND  p.PaymentDate >= @from
                  AND  p.PaymentDate <  @to
                  AND  (@rid IS NULL OR p.RoomId = @rid)
                ORDER BY p.PaymentDate ASC, p.PaymentId ASC;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = buildingId;
                cmd.Parameters.Add("@from", SqlDbType.Date).Value = fromDate.Date;
                cmd.Parameters.Add("@to", SqlDbType.Date).Value = toDateExclusive.Date;
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value =
                    roomId.HasValue ? (object)roomId.Value : DBNull.Value;

                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new ReportReceivedRow
                        {
                            PaymentDate = rd.GetDateTime(0),
                            ReceiptNo = rd.GetString(1),
                            TenantName = rd.GetString(2),
                            RoomNumber = rd.GetString(3),
                            Category = rd.GetString(4),
                            Method = rd.GetString(5),
                            Amount = rd.GetDecimal(6)
                        });
                    }
                }
            }

            return list;
        }
    }

}
