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
    /// A Whole Room payment splits the amount across the room's active
    /// tenants first, then runs the same two rules for each of them.
    ///
    /// Everything happens inside the caller's transaction, so a payment
    /// either lands completely or not at all.
    /// </summary>
    public static class BillingHelper
    {
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
            string category,        // "Rent" / "Maintenance" / "Utilities"
            string paymentType,     // "Full Payment" / "Partial Payment" / "Down Payment"
            decimal amount,
            string method,          // "Cash" / "GCash"
            string referenceNo,     // null for cash
            DateTime paymentDate,
            int recordedBy,
            string receiptNo)
        {
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
                List<int> tenants = GetActiveTenants(conn, tx, roomId);

                if (tenants.Count == 0)
                    throw new InvalidOperationException(
                        "Whole Room payment on a room with no active tenants.");

                // Split evenly. Rounding leftovers go to the first tenant so
                // the parts always add back up to the amount exactly.
                decimal each = Math.Floor(amount / tenants.Count * 100m) / 100m;
                decimal remainder = amount - (each * tenants.Count);

                for (int i = 0; i < tenants.Count; i++)
                {
                    decimal share = (i == 0) ? each + remainder : each;
                    if (share > 0)
                        credits.Add(new KeyValuePair<int, decimal>(tenants[i], share));
                }
            }

            // ---- 3. Allocate each credit -----------------------------------
            var touchedBills = new HashSet<int>();

            foreach (var credit in credits)
                AllocateToTenant(conn, tx, paymentId, credit.Key, credit.Value,
                                 category, touchedBills);

            // ---- 4. Recompute every bill this payment touched --------------
            foreach (int billId in touchedBills)
                RecomputeBill(conn, tx, billId);

            return paymentId;
        }

        /// <summary>
        /// Walks this tenant's unpaid shares oldest first, settling what it
        /// can. Anything left over becomes a credit row with no BillId.
        /// </summary>
        private static void AllocateToTenant(
            SqlConnection conn, SqlTransaction tx,
            int paymentId, int tenantId, decimal amount,
            string category, HashSet<int> touchedBills)
        {
            decimal remaining = amount;

            // Oldest unpaid shares first
            string owingSql = @"
                SELECT BillId, Owing FROM (
                    SELECT bt.BillId, b.BillingPeriodStart,
                           bt.Share - ISNULL((SELECT SUM(a.Amount)
                                              FROM PaymentAllocations a
                                              WHERE a.BillId = bt.BillId
                                                AND a.TenantId = bt.TenantId), 0) AS Owing
                    FROM BillTenants bt
                    JOIN Bills b ON b.BillId = bt.BillId
                    WHERE bt.TenantId = @tid AND b.BillCategory = @cat
                ) x
                WHERE Owing > 0
                ORDER BY BillingPeriodStart ASC;";

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

                touchedBills.Add(bill.Key);
                remaining -= take;
            }

            // Nothing left to settle - hold it as credit for a future bill
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
        /// AmountPaid and Status are always summed from the allocations, never
        /// incremented - two numbers that can drift will eventually disagree.
        /// </summary>
        public static void RecomputeBill(SqlConnection conn, SqlTransaction tx, int billId)
        {
            string sql = @"
                UPDATE Bills
                SET AmountPaid = ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                                         WHERE a.BillId = Bills.BillId), 0),
                    Status = CASE
                        WHEN ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                                     WHERE a.BillId = Bills.BillId), 0) >= Amount
                             THEN 'Paid'
                        WHEN ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                                     WHERE a.BillId = Bills.BillId), 0) > 0
                             THEN 'Partially Paid'
                        ELSE 'Unpaid' END
                WHERE BillId = @bid;";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@bid", billId);
                cmd.ExecuteNonQuery();
            }
        }

        private static List<int> GetActiveTenants(
            SqlConnection conn, SqlTransaction tx, int roomId)
        {
            var list = new List<int>();

            string sql = @"
                SELECT TenantId FROM Tenants
                WHERE RoomId = @rid AND Status = 'Active' AND IsArchived = 0
                ORDER BY TenantId;";

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

        /// <summary>
        /// Available Balance, one category only.
        /// Credit held, minus everything still unpaid.
        /// Positive = paid ahead. Negative = owing.
        /// </summary>
        public static decimal GetBalance(
            SqlConnection conn, int tenantId, string category)
        {
            string sql = @"
                SELECT
                  ISNULL((SELECT SUM(c.Amount) FROM PaymentAllocations c
                          WHERE c.TenantId = @tid AND c.BillId IS NULL), 0)
                  - (
                      ISNULL((SELECT SUM(bt.Share) FROM BillTenants bt
                              JOIN Bills b ON b.BillId = bt.BillId
                              WHERE bt.TenantId = @tid AND b.BillCategory = @cat), 0)
                    - ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                              JOIN Bills b2 ON b2.BillId = a.BillId
                              WHERE a.TenantId = @tid AND b2.BillCategory = @cat), 0)
                    );";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tid", tenantId);
                cmd.Parameters.AddWithValue("@cat", category);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// What this tenant still owes on one specific bill.
        /// </summary>
        public static decimal GetOutstanding(
            SqlConnection conn, int billId, int tenantId)
        {
            string sql = @"
                SELECT ISNULL(bt.Share, 0)
                     - ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                               WHERE a.BillId = @bid AND a.TenantId = @tid), 0)
                FROM BillTenants bt
                WHERE bt.BillId = @bid AND bt.TenantId = @tid;";

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
