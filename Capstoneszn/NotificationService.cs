using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{
    /// <summary>
    /// One notification = one room that needs attention.
    /// Nothing here is stored in the database - the list is worked out
    /// from the bills every time it is shown, so a room disappears from it
    /// by itself once its tenants pay.
    /// </summary>
    public class RoomNotification
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = "";

        /// <summary>true = Overdue, false = Due Soon.</summary>
        public bool IsOverdue { get; set; }

        /// <summary>Overdue card: the overdue amount only. Due Soon card: the amount due in the next 7 days.</summary>
        public decimal AmountUnpaid { get; set; }

        /// <summary>Overdue card: the OLDEST unpaid due date. Due Soon card: the NEAREST due date.</summary>
        public DateTime KeyDueDate { get; set; }

        /// <summary>Paying tenants who still owe (dependents are never billed).</summary>
        public int TenantsOwing { get; set; }

        /// <summary>Active paying tenants of the room.</summary>
        public int TotalTenants { get; set; }

        /// <summary>Overdue: days past the oldest due date. Due Soon: days until the nearest due date (0 = today).</summary>
        public int DayCount { get; set; }

        /* ---- display text, shared by the module card and the Home list ---- */

        // ₱ = peso sign, · = middle dot (escaped so the file encoding can't break them)

        public string Title =>
            (IsOverdue ? "OVERDUE" : "DUE SOON") + " · Room " + RoomNumber;

        public string Description =>
            $"₱{AmountUnpaid:N2} unpaid · Tenants owing: {TenantsOwing} of {TotalTenants} · Due {KeyDueDate:MMM d, yyyy}";

        /// <summary>"5 days overdue" / "Due in 3 days" / "Due today".</summary>
        public string DaysText
        {
            get
            {
                if (IsOverdue)
                    return DayCount == 1 ? "1 day overdue" : $"{DayCount} days overdue";

                if (DayCount == 0) return "Due today";
                return DayCount == 1 ? "Due in 1 day" : $"Due in {DayCount} days";
            }
        }

        /// <summary>Home dashboard line: "Room 202 - Overdue (5 days)" / "Room 102 - Due Soon (in 3 days)".</summary>
        public string ShortText
        {
            get
            {
                string when;
                if (IsOverdue)
                    when = DayCount == 1 ? "1 day" : $"{DayCount} days";
                else if (DayCount == 0)
                    when = "today";
                else
                    when = DayCount == 1 ? "in 1 day" : $"in {DayCount} days";

                return $"Room {RoomNumber} - {(IsOverdue ? "Overdue" : "Due Soon")} ({when})";
            }
        }
    }


    /// <summary>
    /// Builds the notification list for one building.
    /// Used by the Notification module, the bell in the header and the
    /// Home dashboard, so all three always show the same rooms.
    /// </summary>
    public static class NotificationService
    {
        /// <summary>A bill shows as Due Soon from this many days before its due date.</summary>
        public const int DueSoonDays = 7;

        /* =================================================================
           THE RULES (approved Nov 2, 2026)

           - Every bill category counts: Rent, Water, Maintenance.
           - Overdue  = an unpaid share whose due date has passed
                        (starts the day AFTER the due date, same as billing).
           - Due Soon = an unpaid share due from today up to 7 days ahead.
           - One notification per room. Overdue outranks Due Soon.
           - Same tenant rule as the room's billing details screen
             (BillingRoomDetailsControl): a tenant's unpaid shares from their
             CURRENT stay, in any room, show under the room they live in now.
             So the screen a card opens always shows the same money.
           - "Unpaid" = share minus non-voided allocations of non-voided
             payments - the same formula the billing screens use.
           - Moved-out tenants are not counted: their debt was written off
             or forfeited at move out.
           ================================================================= */

        private const string Sql = @"
            WITH Unpaid AS (
                SELECT tn.RoomId,
                       bt.TenantId,
                       b.DueDate,
                       bt.Share
                     - ISNULL((SELECT SUM(a.Amount)
                               FROM   PaymentAllocations a
                               JOIN   Payments p ON p.PaymentId = a.PaymentId
                               WHERE  a.BillId   = bt.BillId
                                 AND  a.TenantId = bt.TenantId
                                 AND  a.IsVoided = 0
                                 AND  p.IsVoided = 0), 0) AS Amount
                FROM   Tenancies tn
                JOIN   Rooms r        ON r.RoomId    = tn.RoomId
                JOIN   BillTenants bt ON bt.TenantId = tn.TenantId
                JOIN   Bills b        ON b.BillId    = bt.BillId
                WHERE  tn.Status = 'Active'
                  AND  r.BuildingId = @bid
                  AND  r.IsArchived = 0
                  AND  b.BillingPeriodStart >= tn.MoveInDate
                  AND  b.DueDate <= @dueLimit
            )
            SELECT u.RoomId,
                   r.RoomNumber,
                   (SELECT COUNT(*)
                    FROM   Tenancies t2
                    WHERE  t2.RoomId = u.RoomId
                      AND  t2.Status = 'Active')                                AS TotalTenants,
                   SUM(CASE WHEN u.DueDate <  @today THEN u.Amount ELSE 0 END)   AS OverdueAmount,
                   MIN(CASE WHEN u.DueDate <  @today THEN u.DueDate END)         AS OldestOverdue,
                   COUNT(DISTINCT CASE WHEN u.DueDate <  @today THEN u.TenantId END) AS OverdueTenants,
                   SUM(CASE WHEN u.DueDate >= @today THEN u.Amount ELSE 0 END)   AS DueSoonAmount,
                   MIN(CASE WHEN u.DueDate >= @today THEN u.DueDate END)         AS NearestDue,
                   COUNT(DISTINCT CASE WHEN u.DueDate >= @today THEN u.TenantId END) AS DueSoonTenants
            FROM   Unpaid u
            JOIN   Rooms r ON r.RoomId = u.RoomId
            WHERE  u.Amount > 0
            GROUP BY u.RoomId, r.RoomNumber;";


        /// <summary>
        /// Every room of the building that has something overdue or due
        /// within 7 days, already sorted: Overdue first (most days overdue
        /// at the top), then Due Soon (nearest due date first).
        /// Throws on a database error - each caller decides how to show it.
        /// </summary>
        public static List<RoomNotification> GetRoomNotifications(int buildingId)
        {
            DateTime today = DateTime.Today;
            var list = new List<RoomNotification>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(Sql, conn))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = buildingId;
                cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;
                cmd.Parameters.Add("@dueLimit", SqlDbType.Date).Value = today.AddDays(DueSoonDays);
                conn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int roomId = rd.GetInt32(0);
                        string roomNumber = Convert.ToString(rd.GetValue(1)) ?? "";   // RoomNumber is INT
                        int totalTenants = rd.GetInt32(2);

                        decimal overdueAmount = rd.GetDecimal(3);
                        decimal dueSoonAmount = rd.GetDecimal(6);

                        var n = new RoomNotification
                        {
                            RoomId = roomId,
                            RoomNumber = roomNumber,
                            TotalTenants = totalTenants
                        };

                        if (overdueAmount > 0m)
                        {
                            // Overdue outranks Due Soon: show only the overdue part.
                            n.IsOverdue = true;
                            n.AmountUnpaid = overdueAmount;
                            n.KeyDueDate = rd.GetDateTime(4).Date;
                            n.TenantsOwing = rd.GetInt32(5);
                            n.DayCount = (today - n.KeyDueDate).Days;
                        }
                        else if (dueSoonAmount > 0m)
                        {
                            n.IsOverdue = false;
                            n.AmountUnpaid = dueSoonAmount;
                            n.KeyDueDate = rd.GetDateTime(7).Date;
                            n.TenantsOwing = rd.GetInt32(8);
                            n.DayCount = (n.KeyDueDate - today).Days;
                        }
                        else
                        {
                            continue;   // nothing owed (should not happen - the query filters Amount > 0)
                        }

                        list.Add(n);
                    }
                }
            }

            // Overdue first, most days overdue at the top; then Due Soon,
            // nearest due date first. Same day -> lower room number first.
            return list
                .OrderBy(n => n.IsOverdue ? 0 : 1)
                .ThenBy(n => n.IsOverdue ? -n.DayCount : n.DayCount)
                .ThenBy(n => int.TryParse(n.RoomNumber, out int num) ? num : int.MaxValue)
                .ToList();
        }
    }
}