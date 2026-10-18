using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{

    /// <summary>One payment as shown in Payment History.</summary>
    public class PaymentHistoryRow
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }   // the date entered on the payment form
        public DateTime RecordedAt { get; set; }    // when it was saved (gives the Time column)
        public string ReceiptNo { get; set; } = "";
        public string TenantName { get; set; } = "";
        public string RoomNumber { get; set; } = "";
        public string Category { get; set; } = "";  // Rent / Maintenance / Water / Electricity / Other
        public string PaymentType { get; set; } = ""; // Full / Partial / Advance
        public string Method { get; set; } = "";
        public string ReferenceNo { get; set; } = "";
        public decimal Amount { get; set; }
        public bool CoversRoom { get; set; }
        public string Tag { get; set; } = "";       // On-time / Overdue / Advance
        public string Issues { get; set; } = "";    // maintenance issue title(s)

        public bool IsVoided { get; set; }
        public string VoidReason { get; set; } = "";
        public DateTime? VoidedAt { get; set; }
        public string VoidedBy { get; set; } = "";

        public bool IsUtility =>
            Category == "Water" || Category == "Electricity" || Category == "Other";
    }

    /// <summary>One line of what a payment settled (receipt / void preview).</summary>
    public class PaymentAllocationLine
    {
        public string TenantName { get; set; } = "";
        public string AppliedTo { get; set; } = "";   // "Rent Oct 15 - Nov 15, 2026", "Maintenance: Leaking faucet", "Advance credit"
        public decimal Amount { get; set; }
        public bool IsCredit { get; set; }
    }

    /// <summary>Everything the receipt and the void form show about one payment.</summary>
    public class PaymentReceipt
    {
        public PaymentHistoryRow Payment { get; set; } = new PaymentHistoryRow();
        public string BuildingName { get; set; } = "";
        public string RecordedBy { get; set; } = "";
        public List<PaymentAllocationLine> Lines { get; } = new List<PaymentAllocationLine>();
    }

    /// <summary>
    /// Payment History: reading payments, building receipts, and voiding.
    ///
    /// Rules this class follows:
    ///   - Payments are never deleted. A void sets Payments.IsVoided and
    ///     every PaymentAllocations row of that payment to voided, in one
    ///     transaction. Every balance query already skips voided rows, so
    ///     balances correct themselves.
    ///   - Voiding is landlord-only; checked here against the Users table,
    ///     not only by hiding the button.
    ///   - The Tag is derived, never stored:
    ///       Advance  - some money became credit, or paid a period that had
    ///                  not started on the payment date
    ///       Overdue  - paid after the due date of the oldest bill it settled
    ///       On-time  - otherwise
    ///     It is read from all of the payment's allocations, voided or not,
    ///     so a voided row still shows what it originally was.
    /// </summary>
    public static class PaymentHistoryService
    {
        public const string TagOnTime = "On-time";
        public const string TagOverdue = "Overdue";
        public const string TagAdvance = "Advance";

        /* =================================================================
           LIST
           ================================================================= */

        /// <summary>
        /// One building's payments, newest first. fromDate inclusive,
        /// toDate exclusive; null = no limit.
        /// </summary>
        public static List<PaymentHistoryRow> GetPayments(int buildingId, DateTime? fromDate, DateTime? toDate)
        {
            var list = new List<PaymentHistoryRow>();

            string sql = @"
                SELECT p.PaymentId, p.PaymentDate, p.RecordedAt, p.ReceiptNo,
                       t.FirstName + ' ' + t.LastName AS TenantName,
                       r.RoomNumber, p.PaymentCategory, p.PaymentType,
                       p.PaymentMethod, p.ReferenceNo, p.Amount, p.CoversRoom,
                       p.IsVoided, p.VoidReason, p.VoidedAt, vu.Name AS VoidedByName,
                       tag.HasCredit, tag.LatestStart, tag.OldestDue,
                       iss.Issues
                FROM   Payments p
                JOIN   Tenants t  ON t.TenantId = p.TenantId
                JOIN   Rooms   r  ON r.RoomId   = p.RoomId
                LEFT JOIN Users vu ON vu.UserId = p.VoidedBy
                OUTER APPLY (
                    SELECT MAX(CASE WHEN a.BillId IS NULL THEN 1 ELSE 0 END) AS HasCredit,
                           MAX(b.BillingPeriodStart) AS LatestStart,
                           MIN(b.DueDate) AS OldestDue
                    FROM   PaymentAllocations a
                    LEFT JOIN Bills b ON b.BillId = a.BillId
                    WHERE  a.PaymentId = p.PaymentId
                ) tag
                OUTER APPLY (
                    SELECT STRING_AGG(x.IssueTitle, ', ') AS Issues
                    FROM (
                        SELECT DISTINCT mi.IssueTitle
                        FROM   PaymentAllocations a
                        JOIN   Bills b              ON b.BillId  = a.BillId
                        JOIN   MaintenanceIssues mi ON mi.IssueId = b.MaintenanceIssueId
                        WHERE  a.PaymentId = p.PaymentId
                    ) x
                ) iss
                WHERE  r.BuildingId = @bid
                  AND  (@from IS NULL OR p.PaymentDate >= @from)
                  AND  (@to   IS NULL OR p.PaymentDate <  @to)
                ORDER BY p.PaymentDate DESC, p.PaymentId DESC;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = buildingId;
                cmd.Parameters.Add("@from", SqlDbType.Date).Value =
                    fromDate.HasValue ? (object)fromDate.Value.Date : DBNull.Value;
                cmd.Parameters.Add("@to", SqlDbType.Date).Value =
                    toDate.HasValue ? (object)toDate.Value.Date : DBNull.Value;

                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(ReadRow(rd));
                }
            }

            return list;
        }

        private static PaymentHistoryRow ReadRow(SqlDataReader rd)
        {
            var row = new PaymentHistoryRow
            {
                PaymentId = rd.GetInt32(0),
                PaymentDate = rd.GetDateTime(1),
                RecordedAt = rd.GetDateTime(2),
                ReceiptNo = rd.GetString(3),
                TenantName = rd.GetString(4),
                RoomNumber = rd.GetString(5),
                Category = rd.GetString(6),
                PaymentType = rd.GetString(7),
                Method = rd.GetString(8),
                ReferenceNo = rd.IsDBNull(9) ? "" : rd.GetString(9),
                Amount = rd.GetDecimal(10),
                CoversRoom = rd.GetBoolean(11),
                IsVoided = rd.GetBoolean(12),
                VoidReason = rd.IsDBNull(13) ? "" : rd.GetString(13),
                VoidedAt = rd.IsDBNull(14) ? (DateTime?)null : rd.GetDateTime(14),
                VoidedBy = rd.IsDBNull(15) ? "" : rd.GetString(15),
                Issues = rd.IsDBNull(19) ? "" : rd.GetString(19)
            };

            // Worked out here, not in SQL: SQL Server does not allow an
            // aggregate that mixes the outer p.PaymentDate with inner columns.
            bool hasCredit = !rd.IsDBNull(16) && rd.GetInt32(16) == 1;
            DateTime? latestStart = rd.IsDBNull(17) ? (DateTime?)null : rd.GetDateTime(17);
            DateTime? oldestDue = rd.IsDBNull(18) ? (DateTime?)null : rd.GetDateTime(18);

            bool hasAdvance = hasCredit ||
                              (latestStart.HasValue && latestStart.Value.Date > row.PaymentDate.Date);

            if (hasAdvance)
                row.Tag = TagAdvance;
            else if (oldestDue.HasValue && row.PaymentDate.Date > oldestDue.Value.Date)
                row.Tag = TagOverdue;      // overdue starts the day after the due date
            else
                row.Tag = TagOnTime;

            return row;
        }

        /* =================================================================
           RECEIPT / VOID PREVIEW
           ================================================================= */

        /// <summary>
        /// The payment plus what each peso of it settled. Returns null if the
        /// payment does not exist.
        /// </summary>
        public static PaymentReceipt? GetReceipt(int paymentId)
        {
            var receipt = new PaymentReceipt();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // ---- Header: same row shape as the list -------------------
                string headSql = @"
                    SELECT p.PaymentId, p.PaymentDate, p.RecordedAt, p.ReceiptNo,
                           t.FirstName + ' ' + t.LastName AS TenantName,
                           r.RoomNumber, p.PaymentCategory, p.PaymentType,
                           p.PaymentMethod, p.ReferenceNo, p.Amount, p.CoversRoom,
                           p.IsVoided, p.VoidReason, p.VoidedAt, vu.Name AS VoidedByName,
                           tag.HasCredit, tag.LatestStart, tag.OldestDue,
                           CAST(NULL AS NVARCHAR(MAX)) AS Issues,
                           bl.BuildingName, ru.Name AS RecordedByName
                    FROM   Payments p
                    JOIN   Tenants t   ON t.TenantId   = p.TenantId
                    JOIN   Rooms   r   ON r.RoomId     = p.RoomId
                    JOIN   Buildings bl ON bl.BuildingId = r.BuildingId
                    LEFT JOIN Users vu ON vu.UserId = p.VoidedBy
                    LEFT JOIN Users ru ON ru.UserId = p.RecordedBy
                    OUTER APPLY (
                        SELECT MAX(CASE WHEN a.BillId IS NULL THEN 1 ELSE 0 END) AS HasCredit,
                               MAX(b.BillingPeriodStart) AS LatestStart,
                               MIN(b.DueDate) AS OldestDue
                        FROM   PaymentAllocations a
                        LEFT JOIN Bills b ON b.BillId = a.BillId
                        WHERE  a.PaymentId = p.PaymentId
                    ) tag
                    WHERE  p.PaymentId = @pid;";

                using (var cmd = new SqlCommand(headSql, conn))
                {
                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = paymentId;
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read()) return null;
                        receipt.Payment = ReadRow(rd);
                        receipt.BuildingName = rd.GetString(20);
                        receipt.RecordedBy = rd.IsDBNull(21) ? "" : rd.GetString(21);
                    }
                }

                // ---- Lines: every allocation of the payment ----------------
                string lineSql = @"
                    SELECT t.FirstName + ' ' + t.LastName AS TenantName,
                           b.BillCategory, b.BillingPeriodStart, b.BillingPeriodEnd,
                           mi.IssueTitle, a.Amount,
                           CASE WHEN a.BillId IS NULL THEN 1 ELSE 0 END AS IsCredit
                    FROM   PaymentAllocations a
                    JOIN   Tenants t ON t.TenantId = a.TenantId
                    LEFT JOIN Bills b ON b.BillId = a.BillId
                    LEFT JOIN MaintenanceIssues mi ON mi.IssueId = b.MaintenanceIssueId
                    WHERE  a.PaymentId = @pid
                    ORDER BY t.LastName, t.FirstName, b.BillingPeriodStart, a.AllocationId;";

                using (var cmd = new SqlCommand(lineSql, conn))
                {
                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = paymentId;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            bool isCredit = rd.GetInt32(6) == 1;
                            string appliedTo;

                            if (isCredit)
                                appliedTo = "Advance credit (for future bills)";
                            else if (!rd.IsDBNull(4))
                                appliedTo = "Maintenance: " + rd.GetString(4);
                            else
                                appliedTo = rd.GetString(1) + "  " +
                                            rd.GetDateTime(2).ToString("MMM dd") + " - " +
                                            rd.GetDateTime(3).ToString("MMM dd, yyyy");

                            receipt.Lines.Add(new PaymentAllocationLine
                            {
                                TenantName = rd.GetString(0),
                                AppliedTo = appliedTo,
                                Amount = rd.GetDecimal(5),
                                IsCredit = isCredit
                            });
                        }
                    }
                }
            }

            return receipt;
        }

        /// <summary>The PaymentId for a receipt number, or null if none.</summary>
        public static int? GetPaymentIdByReceipt(string receiptNo)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT PaymentId FROM Payments WHERE ReceiptNo = @r;", conn))
            {
                cmd.Parameters.Add("@r", SqlDbType.NVarChar, 50).Value = receiptNo ?? "";
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result == null ? (int?)null : (int)result;
            }
        }

        /* =================================================================
           VOID
           ================================================================= */

        /// <summary>
        /// Voids a payment: the payment and all of its allocations are
        /// flagged in one transaction. Cannot be undone.
        /// Throws InvalidOperationException if the user is not the landlord,
        /// the reason is empty, or the payment is already voided / missing.
        /// </summary>
        public static void VoidPayment(int paymentId, string reason, int userId)
        {
            reason = (reason ?? "").Trim();
            if (reason.Length == 0)
                throw new InvalidOperationException("A reason is required to void a payment.");
            if (reason.Length > 255)
                reason = reason.Substring(0, 255);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Landlord-only, checked in the database, not just the UI.
                        using (var cmd = new SqlCommand(
                            "SELECT COUNT(*) FROM Users WHERE UserId = @uid AND Role = 'Landlord';", conn, tx))
                        {
                            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
                            if ((int)cmd.ExecuteScalar() == 0)
                                throw new InvalidOperationException("Only the landlord can void a payment.");
                        }

                        // The IsVoided = 0 test makes a double void impossible,
                        // even from two screens at once.
                        using (var cmd = new SqlCommand(@"
                            UPDATE Payments
                            SET    IsVoided = 1, VoidedAt = SYSDATETIME(),
                                   VoidedBy = @uid, VoidReason = @reason
                            WHERE  PaymentId = @pid AND IsVoided = 0;", conn, tx))
                        {
                            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
                            cmd.Parameters.Add("@reason", SqlDbType.NVarChar, 255).Value = reason;
                            cmd.Parameters.Add("@pid", SqlDbType.Int).Value = paymentId;

                            if (cmd.ExecuteNonQuery() != 1)
                                throw new InvalidOperationException("This payment is already voided or no longer exists.");
                        }

                        // Every allocation of the payment - including credit that
                        // BillGenerator later moved onto a newer bill (it keeps
                        // the same PaymentId), so no peso of it counts anywhere.
                        using (var cmd = new SqlCommand(
                            "UPDATE PaymentAllocations SET IsVoided = 1 WHERE PaymentId = @pid;", conn, tx))
                        {
                            cmd.Parameters.Add("@pid", SqlDbType.Int).Value = paymentId;
                            cmd.ExecuteNonQuery();
                        }

                        // Audit trail, inside the same transaction.
                        string what = "Payment #" + paymentId;
                        using (var cmd = new SqlCommand(@"
                            SELECT 'Receipt ' + p.ReceiptNo + ': PHP ' + FORMAT(p.Amount, 'N2') + ' ' +
                                   p.PaymentCategory + ' from ' + t.FirstName + ' ' + t.LastName +
                                   ', Room ' + r.RoomNumber
                            FROM   Payments p
                            JOIN   Tenants t ON t.TenantId = p.TenantId
                            JOIN   Rooms   r ON r.RoomId   = p.RoomId
                            WHERE  p.PaymentId = @pid;", conn, tx))
                        {
                            cmd.Parameters.Add("@pid", SqlDbType.Int).Value = paymentId;
                            what = cmd.ExecuteScalar()?.ToString() ?? what;
                        }
                        AuditLogger.Log(conn, tx, AuditLogger.ModulePayments, "Void Payment",
                                        what + ". Reason: " + reason);

                        tx.Commit();
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { /* keep the original error */ }
                        throw;
                    }
                }
            }
        }
    }

}
