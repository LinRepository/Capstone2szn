using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{


    /// <summary>
    /// The allocation engine.
    ///
    /// Money received and what it pays for are separate things. This class
    /// records the money, then decides what it settles:
    ///
    ///   1. Allocate to the tenant's oldest unpaid share first.
    ///   2. Whatever is left over becomes a credit row (BillId NULL) -
    ///      that IS the advance payment.
    ///
    /// A Whole Room payment is one tenant paying the ROOM's rent for
    /// everyone. It goes to each tenant's debt first - never more than a
    /// tenant owes while a room-mate still owes - and only money left over
    /// after the whole room is settled becomes advance, split equally.
    /// (SplitWholeRoom below; the payment screen uses the same method for
    /// its preview, so what is shown is what is saved.)
    ///
    /// Everything happens inside the caller's transaction, so a payment
    /// either lands completely or not at all.
    ///
    /// Nothing about a bill's payment state is stored. Bills.AmountPaid and
    /// Bills.Status no longer exist - "paid" is always summed from the
    /// allocations when it is read, so there is nothing to keep in step.
    ///
    /// Three rules every query in this class follows:
    ///   - A voided allocation, or any allocation under a voided payment,
    ///     does not count. Both flags are checked.
    ///   - Only shares from the tenant's CURRENT stay are owing. A tenant
    ///     who left and was later reactivated had their old shares settled
    ///     by write-off or forfeit at that move out; new money must never be
    ///     applied to debt that was already cancelled.
    ///   - Forfeited credit is not available credit.
    /// </summary>
    /// 
    public static class BillingHelper
    {
        private const string AdjustmentForfeit = "Forfeit";
        public const string MaintenanceCategory = "Maintenance";

        /// <summary>
        /// A maintenance payment must be for this tenant only (no Whole Room),
        /// typed Full, and exactly equal to everything the tenant owes for
        /// maintenance - so it can never leave a partial balance or create
        /// maintenance credit. Throws InvalidOperationException otherwise.
        /// </summary>
        private static void EnsureValidMaintenancePayment(
            SqlConnection conn, SqlTransaction tx,
            int tenantId, bool coversRoom, string paymentType, decimal amount)
        {
            if (coversRoom)
                throw new InvalidOperationException(
                    "Maintenance cannot be paid as Whole Room. Each affected tenant pays their own share.");

            decimal owed = GetTotalOutstanding(conn, tenantId, MaintenanceCategory, tx);

            if (owed <= 0m)
                throw new InvalidOperationException(
                    "This tenant has no unpaid maintenance.");

            if (paymentType != "Full" || amount != owed)
                throw new InvalidOperationException(
                    "Maintenance must be paid in full: PHP " + owed.ToString("N2") +
                    ". Partial and advance payments are not accepted.");
        }

        /// <summary>
        /// Records a payment and allocates it. Returns the new PaymentId.
        /// Call inside an open transaction.
        /// </summary>
        public static int RecordPayment(
            SqlConnection conn,
            SqlTransaction tx,
            int roomId,
            int payingTenantId,
            bool coversRoom,
            string category,        // "Rent" / "Water" / "Maintenance"
            string paymentType,     // database code: "Full" / "Partial" / "Advance"
            decimal amount,
            string method,          // "Cash" / "GCash"
            string referenceNo,     // null for cash
            DateTime paymentDate,
            int recordedBy,
            string receiptNo)
        {
            // ---- 0. Maintenance rules (decided: Full only, never Whole Room,
            //         and one payment clears everything the tenant owes) ----
            //         Checked here, inside the transaction, so no screen can
            //         save a maintenance payment that breaks them.
            if (category == MaintenanceCategory)
                EnsureValidMaintenancePayment(conn, tx, payingTenantId, coversRoom, paymentType, amount);

            // ---- 1. The money received -------------------------------------
            int paymentId;

            string paySql = @"
                INSERT INTO Payments
                    (TenantId, RoomId, ReceiptNo, PaymentCategory, PaymentType,
                     Amount, PaymentMethod, ReferenceNo, PaymentDate,
                     CoversRoom, RecordedBy)
                VALUES (@tid, @rid, @rcpt, @cat, @type,
                        @amt, @method, @ref, @pdate,
                        @covers, @by);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var cmd = new SqlCommand(paySql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@tid", payingTenantId);
                cmd.Parameters.AddWithValue("@rid", roomId);
                cmd.Parameters.AddWithValue("@rcpt", receiptNo);
                cmd.Parameters.AddWithValue("@cat", category);
                cmd.Parameters.AddWithValue("@type", paymentType);
                cmd.Parameters.AddWithValue("@amt", amount);
                cmd.Parameters.AddWithValue("@method", method);
                cmd.Parameters.AddWithValue("@ref",
                    string.IsNullOrWhiteSpace(referenceNo)
                        ? (object)DBNull.Value : referenceNo);
                cmd.Parameters.AddWithValue("@pdate", paymentDate);
                cmd.Parameters.AddWithValue("@covers", coversRoom ? 1 : 0);
                cmd.Parameters.AddWithValue("@by", recordedBy);
                paymentId = (int)cmd.ExecuteScalar();
            }

            // ---- 2. Who gets credited, and how much ------------------------
            var credits = new List<KeyValuePair<int, decimal>>();

            if (!coversRoom)
            {
                credits.Add(new KeyValuePair<int, decimal>(payingTenantId, amount));
            }
            else
            {
                // Read inside the same transaction, so the split is based on
                // exactly what is owed at the moment of saving.
                List<KeyValuePair<int, decimal>> owing =
                    GetRoomOwing(conn, roomId, category, tx);

                if (owing.Count == 0)
                    throw new InvalidOperationException(
                        "Whole Room payment on a room with no active tenants.");

                foreach (var part in SplitWholeRoom(owing, amount))
                    if (part.Value > 0m)
                        credits.Add(part);
            }

            // ---- 3. Allocate each credit -----------------------------------
            foreach (var credit in credits)
                AllocateToTenant(conn, tx, paymentId, credit.Key, credit.Value, category);

            // ---- 4. Audit trail - same transaction, so the log and the
            //         payment are saved together or not at all. ------------
            AuditLogger.Log(conn, tx, AuditLogger.ModulePayments, "Record Payment",
                "Receipt " + receiptNo + ": PHP " + amount.ToString("N2") + " " + category +
                " (" + paymentType + ", " + method + ") from " +
                AuditLogger.TenantName(conn, tx, payingTenantId) +
                ", Room " + AuditLogger.RoomNumber(conn, tx, roomId) +
                (coversRoom ? " - Whole Room" : ""));

            return paymentId;
        }

        /// <summary>
        /// Walks this tenant's unpaid shares oldest first, settling what it
        /// can. Anything left over becomes a credit row with no BillId.
        /// </summary>
        private static void AllocateToTenant(
            SqlConnection conn, SqlTransaction tx,
            int paymentId, int tenantId, decimal amount, string category)
        {
            decimal remaining = amount;

            // Oldest unpaid shares first, current stay only.
            string owingSql = @"
                SELECT x.BillId, x.Owing
                FROM (
                    SELECT bt.BillId, b.BillingPeriodStart,
                           bt.Share - ISNULL((SELECT SUM(a.Amount)
                                              FROM   PaymentAllocations a
                                              JOIN   Payments p ON p.PaymentId = a.PaymentId
                                              WHERE  a.BillId   = bt.BillId
                                                AND  a.TenantId = bt.TenantId
                                                AND  a.IsVoided = 0
                                                AND  p.IsVoided = 0), 0) AS Owing
                    FROM   BillTenants bt
                    JOIN   Bills b      ON b.BillId = bt.BillId
                    JOIN   Tenancies tn ON tn.TenantId = bt.TenantId
                                       AND tn.Status   = 'Active'
                    WHERE  bt.TenantId = @tid
                      AND  b.BillCategory = @cat
                      AND  b.BillingPeriodStart >= tn.MoveInDate
                ) x
                WHERE x.Owing > 0
                ORDER BY x.BillingPeriodStart ASC, x.BillId ASC;";

            var owing = new List<KeyValuePair<int, decimal>>();

            using (var cmd = new SqlCommand(owingSql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@tid", tenantId);
                cmd.Parameters.AddWithValue("@cat", category);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        owing.Add(new KeyValuePair<int, decimal>(
                            rd.GetInt32(0), rd.GetDecimal(1)));
                }
            }

            foreach (var bill in owing)
            {
                if (remaining <= 0) break;

                decimal take = Math.Min(remaining, bill.Value);
                InsertAllocation(conn, tx, paymentId, bill.Key, tenantId, take);

                remaining -= take;
            }

            // Nothing left to settle - hold it as credit for a future bill.
            // BillGenerator moves it onto the next bill when that is created.
            if (remaining > 0)
                InsertAllocation(conn, tx, paymentId, null, tenantId, remaining);
        }

        private static void InsertAllocation(
            SqlConnection conn, SqlTransaction tx,
            int paymentId, int? billId, int tenantId, decimal amount)
        {
            string sql = @"
                INSERT INTO PaymentAllocations (PaymentId, BillId, TenantId, Amount)
                VALUES (@pid, @bid, @tid, @amt);";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@pid", paymentId);
                cmd.Parameters.AddWithValue("@bid",
                    billId.HasValue ? (object)billId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@tid", tenantId);
                cmd.Parameters.AddWithValue("@amt", amount);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// How a Whole Room payment is divided. Pure arithmetic, no database,
        /// so the payment screen's preview and the save use the very same rule.
        ///
        ///   1. Debts first. The money is split equally among the tenants who
        ///      still owe, but nobody receives more than they owe; whatever a
        ///      settled tenant did not need is split again among the rest.
        ///      (Everyone owing the same -> a plain equal split.)
        ///   2. Only when the whole room is settled does any money remain.
        ///      That excess is advance, split equally across every tenant,
        ///      leftover centavo to the longest-tenured (same as BillGenerator).
        ///
        /// Input: each active tenant and what they owe, longest-tenured first.
        /// Output: the same tenants, in the same order, with their part.
        /// The parts always add up to the amount exactly.
        /// </summary>
        /// 
        public static List<KeyValuePair<int, decimal>> SplitWholeRoom(
            IList<KeyValuePair<int, decimal>> owing, decimal amount)
        {
            int n = owing.Count;
            var give = new decimal[n];
            decimal remaining = amount;

            // ---- 1. Debts first ---------------------------------------------
            // Each pass either uses up the money or fully settles at least one
            // tenant, so this ends quickly; the guard is only a safety net.
            for (int guard = 0; remaining > 0m && guard < 1000; guard++)
            {
                var open = new List<int>();
                for (int i = 0; i < n; i++)
                    if (owing[i].Value - give[i] > 0m) open.Add(i);

                if (open.Count == 0) break;   // whole room settled

                decimal each = Math.Floor(remaining / open.Count * 100m) / 100m;

                if (each == 0m)
                {
                    // Fewer centavos left than tenants still owing:
                    // one centavo each, in order.
                    foreach (int i in open)
                    {
                        decimal take = Math.Min(0.01m, Math.Min(remaining, owing[i].Value - give[i]));
                        give[i] += take;
                        remaining -= take;
                        if (remaining <= 0m) break;
                    }
                    continue;
                }

                foreach (int i in open)
                {
                    decimal take = Math.Min(each, owing[i].Value - give[i]);
                    give[i] += take;
                    remaining -= take;
                }
            }

            // ---- 2. Room settled, money left: advance, split equally ---------
            if (remaining > 0m && n > 0)
            {
                decimal each = Math.Floor(remaining / n * 100m) / 100m;
                decimal leftover = remaining - (each * n);

                for (int i = 0; i < n; i++)
                    give[i] += (i == 0) ? each + leftover : each;
            }

            var result = new List<KeyValuePair<int, decimal>>(n);
            for (int i = 0; i < n; i++)
                result.Add(new KeyValuePair<int, decimal>(owing[i].Key, give[i]));
            return result;
        }

        /// <summary>
        /// Every active tenant of the room with what they owe in one category,
        /// longest-tenured first. The input SplitWholeRoom expects.
        /// </summary>
        public static List<KeyValuePair<int, decimal>> GetRoomOwing(
            SqlConnection conn, int roomId, string category, SqlTransaction tx = null)
        {
            var result = new List<KeyValuePair<int, decimal>>();

            foreach (int tenantId in GetActiveTenants(conn, tx, roomId))
                result.Add(new KeyValuePair<int, decimal>(
                    tenantId, GetTotalOutstanding(conn, tenantId, category, tx)));

            return result;
        }

        /// <summary>
        /// The room's active tenants, longest-tenured first - the same order
        /// BillGenerator uses, so the same tenant absorbs rounding in both.
        /// </summary>
        private static List<int> GetActiveTenants(
            SqlConnection conn, SqlTransaction tx, int roomId)
        {
            var list = new List<int>();

            string sql = @"
                SELECT tn.TenantId
                FROM   Tenancies tn
                WHERE  tn.RoomId = @rid
                  AND  tn.Status = 'Active'
                ORDER BY tn.MoveInDate ASC, tn.TenantId ASC;";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@rid", roomId);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read()) list.Add(rd.GetInt32(0));
                }
            }

            return list;
        }


        /* =================================================================
           READ-ONLY BALANCE QUERIES

           The optional transaction lets the same figures be read inside a
           payment's transaction or outside it on a plain connection.
           ================================================================= */

        /// <summary>
        /// Everything this tenant still owes in one category, across every
        /// period of their current stay.
        /// </summary>
        public static decimal GetTotalOutstanding(
            SqlConnection conn, int tenantId, string category, SqlTransaction tx = null)
        {
            string sql = @"
                SELECT ISNULL(SUM(x.Owing), 0)
                FROM (
                    SELECT bt.Share - ISNULL((SELECT SUM(a.Amount)
                                              FROM   PaymentAllocations a
                                              JOIN   Payments p ON p.PaymentId = a.PaymentId
                                              WHERE  a.BillId   = bt.BillId
                                                AND  a.TenantId = bt.TenantId
                                                AND  a.IsVoided = 0
                                                AND  p.IsVoided = 0), 0) AS Owing
                    FROM   BillTenants bt
                    JOIN   Bills b      ON b.BillId = bt.BillId
                    JOIN   Tenancies tn ON tn.TenantId = bt.TenantId
                                       AND tn.Status   = 'Active'
                    WHERE  bt.TenantId = @tid
                      AND  b.BillCategory = @cat
                      AND  b.BillingPeriodStart >= tn.MoveInDate
                ) x
                WHERE x.Owing > 0;";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@tid", tenantId);
                cmd.Parameters.AddWithValue("@cat", category);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Credit paid ahead in one category that no bill has claimed yet,
        /// less anything forfeited at a move out.
        /// </summary>
        public static decimal GetAvailableCredit(
            SqlConnection conn, int tenantId, string category, SqlTransaction tx = null)
        {
            string sql = @"
                SELECT ISNULL((SELECT SUM(a.Amount)
                               FROM   PaymentAllocations a
                               JOIN   Payments p ON p.PaymentId = a.PaymentId
                               WHERE  a.TenantId = @tid
                                 AND  a.BillId IS NULL
                                 AND  a.IsVoided = 0
                                 AND  p.IsVoided = 0
                                 AND  p.PaymentCategory = @cat), 0)
                     - ISNULL((SELECT SUM(adj.Amount)
                               FROM   TenantAdjustments adj
                               WHERE  adj.TenantId = @tid
                                 AND  adj.AdjustmentType = @forfeit
                                 AND  adj.BillCategory = @cat), 0);";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@tid", tenantId);
                cmd.Parameters.AddWithValue("@cat", category);
                cmd.Parameters.AddWithValue("@forfeit", AdjustmentForfeit);

                decimal credit = Convert.ToDecimal(cmd.ExecuteScalar());
                return credit > 0m ? credit : 0m;
            }
        }

        /// <summary>
        /// Whether the tenant's oldest unpaid share - the one a new payment
        /// lands on first - already has some money against it. That is what
        /// separates a Down Payment (first money on that bill) from a
        /// Partial Payment (later money on it).
        /// </summary>
        public static bool OldestUnpaidShareHasPayment(
            SqlConnection conn, int tenantId, string category, SqlTransaction tx = null)
        {
            string sql = @"
                SELECT TOP 1 x.Paid
                FROM (
                    SELECT b.BillingPeriodStart, bt.BillId, bt.Share,
                           ISNULL((SELECT SUM(a.Amount)
                                   FROM   PaymentAllocations a
                                   JOIN   Payments p ON p.PaymentId = a.PaymentId
                                   WHERE  a.BillId   = bt.BillId
                                     AND  a.TenantId = bt.TenantId
                                     AND  a.IsVoided = 0
                                     AND  p.IsVoided = 0), 0) AS Paid
                    FROM   BillTenants bt
                    JOIN   Bills b      ON b.BillId = bt.BillId
                    JOIN   Tenancies tn ON tn.TenantId = bt.TenantId
                                       AND tn.Status   = 'Active'
                    WHERE  bt.TenantId = @tid
                      AND  b.BillCategory = @cat
                      AND  b.BillingPeriodStart >= tn.MoveInDate
                ) x
                WHERE x.Share - x.Paid > 0
                ORDER BY x.BillingPeriodStart ASC, x.BillId ASC;";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@tid", tenantId);
                cmd.Parameters.AddWithValue("@cat", category);

                object paid = cmd.ExecuteScalar();
                return paid != null && paid != DBNull.Value && Convert.ToDecimal(paid) > 0m;
            }
        }

        /// <summary>
        /// Available Balance, one category only.
        /// Credit available, minus everything still unpaid.
        /// Positive = paid ahead. Negative = owing.
        /// </summary>
        public static decimal GetBalance(
            SqlConnection conn, int tenantId, string category)
        {
            return GetAvailableCredit(conn, tenantId, category)
                 - GetTotalOutstanding(conn, tenantId, category);
        }

        /// <summary>
        /// What this tenant still owes on one specific bill.
        /// </summary>
        public static decimal GetOutstanding(
            SqlConnection conn, int billId, int tenantId)
        {
            string sql = @"
                SELECT ISNULL(bt.Share, 0)
                     - ISNULL((SELECT SUM(a.Amount)
                               FROM   PaymentAllocations a
                               JOIN   Payments p ON p.PaymentId = a.PaymentId
                               WHERE  a.BillId   = @bid
                                 AND  a.TenantId = @tid
                                 AND  a.IsVoided = 0
                                 AND  p.IsVoided = 0), 0)
                FROM   BillTenants bt
                WHERE  bt.BillId = @bid AND bt.TenantId = @tid;";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bid", billId);
                cmd.Parameters.AddWithValue("@tid", tenantId);
                object result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value)
                    ? 0m : Convert.ToDecimal(result);
            }
        }
    }


}
