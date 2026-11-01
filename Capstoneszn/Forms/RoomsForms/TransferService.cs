using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.RoomsForms
{

    /* =========================================================================
       NEW (transfer price difference - decision C)
       -------------------------------------------------------------------------
       The rule (approved):
         A payer who transfers to a room where their share is HIGHER pays the
         difference for each rent period they ALREADY PAID that has not ended
         yet, up to their first bill in the new room - BEFORE the transfer is
         saved. Whole periods only (no proration), even with 1 day left.
         Same or lower share: nothing charged, nothing refunded.
         Advance credit is used first; only the rest is collected.

       Example: Usopp paid Oct 31 - Nov 30 at 6,000 in Room 311 (alone).
                Nov 5 -> empty Room 312 (12,000): new share 12,000.
                Difference 6,000, due now. New price from the Nov 30 bill.

       How it is recorded (so every screen already understands it):
         ONE Rent bill in the destination room, period today -> their first
         bill there, due today, Remarks "Price difference - transfer from
         Room 311", one share per payer = their difference. Credit is moved
         onto it, then each payment is a normal receipt (BillingHelper).

       Everything happens in ONE transaction with the transfer itself.
       A broken rule throws InvalidOperationException with a landlord-
       readable message; nothing is saved.
       ========================================================================= */

    /// <summary>NEW: one paying tenant who moves (with their dependents).</summary>
    public sealed class TransferMover
    {
        public int TenantId;
        public int TenancyId;
        public string Name = "";
        public List<string> Dependents = new List<string>();

        // Filled by TransferService.BuildPlan
        public List<TransferDiffLine> Lines = new List<TransferDiffLine>();
        public decimal Difference;          // sum of the lines
        public decimal CreditUsed;          // advance credit applied first
        public decimal Due;                 // Difference - CreditUsed, collected now

        // Filled by TransferPaymentForm (only when Due > 0)
        public decimal AmountPaid;
        public string Method = MoveInService.Cash;
        public string ReferenceNo = "";
    }

    /// <summary>NEW: one already-paid rent period and its difference.</summary>
    public sealed class TransferDiffLine
    {
        public DateTime PeriodStart;
        public DateTime PeriodEnd;
        public decimal OldShare;            // what they paid in the old room
        public decimal NewShare;            // their share in the new room
        public decimal Difference => Math.Max(0m, NewShare - OldShare);
    }

    /// <summary>NEW: everything the Transfer screens show and the save uses.</summary>
    public sealed class TransferPlan
    {
        public int SourceRoomId;
        public string SourceRoomNumber = "";
        public int DestRoomId;
        public string DestRoomNumber = "";
        public bool DestEmpty;              // no paying tenant there before the move
        public DateTime? FirstBill;         // their first bill in the new room
        public List<TransferMover> Movers = new List<TransferMover>();

        public decimal TotalDifference => Movers.Sum(m => m.Difference);
        public decimal TotalCredit => Movers.Sum(m => m.CreditUsed);
        public decimal TotalDue => Movers.Sum(m => m.Due);
        public int DependentCount => Movers.Sum(m => m.Dependents.Count);
    }

    /// <summary>NEW: what the save returns, for the Transfer Complete screen.</summary>
    public sealed class TransferResult
    {
        public List<MoveInReceiptLine> Receipts = new List<MoveInReceiptLine>();
        public int PayingCount;
        public int DependentCount;
        public DateTime? FirstBill;
    }

    public static class TransferService
    {
        private const string Rent = "Rent";
        private static readonly string[] Categories = { "Rent", "Water", "Maintenance", "Electricity", "Other" };

        /* =================================================================
           PLAN (read only) - the difference per payer
           ================================================================= */

        /// <summary>Works out the difference, credit and amount due for each mover.</summary>
        public static TransferPlan BuildPlan(int sourceRoomId, int destRoomId, IList<TransferMover> movers)
        {
            var plan = new TransferPlan { SourceRoomId = sourceRoomId, DestRoomId = destRoomId };
            plan.Movers.AddRange(movers);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                ComputeInto(conn, null, plan, DateTime.Today);
            }
            return plan;
        }

        /// <summary>
        /// Fills the plan. Used for the screen (tx null) and again inside the
        /// save, so what is charged is always worked out from fresh data.
        /// </summary>
        private static void ComputeInto(SqlConnection conn, SqlTransaction tx, TransferPlan plan, DateTime today)
        {
            // ---- The two rooms ----
            DateTime? srcAnchor = null, destAnchor = null, destPendingFrom = null;
            decimal destPrice = 0m;
            decimal? destPending = null;
            int destPayers = 0;

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT v.RoomId, v.RoomNumber, v.BillingAnchorDate, ISNULL(v.RoomPrice, 0),
                       v.PendingRoomPrice, v.PendingPriceFrom, ISNULL(v.ActiveTenants, 0)
                FROM   vwRoomStatus v
                WHERE  v.RoomId IN (@src, @dest);", conn, tx))
            {
                cmd.Parameters.Add("@src", SqlDbType.Int).Value = plan.SourceRoomId;
                cmd.Parameters.Add("@dest", SqlDbType.Int).Value = plan.DestRoomId;
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        int id = r.GetInt32(0);
                        string number = Convert.ToString(r.GetValue(1)) ?? "";
                        DateTime? anchor = r.IsDBNull(2) ? (DateTime?)null : r.GetDateTime(2);

                        if (id == plan.SourceRoomId)
                        {
                            plan.SourceRoomNumber = number;
                            srcAnchor = anchor;
                        }
                        else
                        {
                            plan.DestRoomNumber = number;
                            destAnchor = anchor;
                            destPrice = r.GetDecimal(3);
                            destPending = r.IsDBNull(4) ? (decimal?)null : r.GetDecimal(4);
                            destPendingFrom = r.IsDBNull(5) ? (DateTime?)null : r.GetDateTime(5);
                            destPayers = r.GetInt32(6);
                        }
                    }
                }
            }

            plan.DestEmpty = destPayers == 0;

            // ---- Their first bill in the new room ----
            //   Empty room    -> keeps their cycle: the source room's first bill not created yet
            //   Occupied room -> joins its cycle: the destination's first bill not created yet
            if (plan.DestEmpty)
                plan.FirstBill = srcAnchor.HasValue
                    ? BillGenerator.NextUnbilledPeriod(conn, tx, plan.SourceRoomId, srcAnchor.Value, today)
                    : (DateTime?)null;
            else
                plan.FirstBill = destAnchor.HasValue
                    ? BillGenerator.NextUnbilledPeriod(conn, tx, plan.DestRoomId, destAnchor.Value, today)
                    : (DateTime?)null;

            int payersAfter = destPayers + plan.Movers.Count;

            // ---- Per mover ----
            foreach (TransferMover m in plan.Movers)
            {
                m.Lines.Clear();

                // Rent periods already billed (and, since they must be settled,
                // paid) in the old room that have not ended yet, and that start
                // before their first bill in the new room.
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT b.BillingPeriodStart, b.BillingPeriodEnd, bt.Share
                    FROM   BillTenants bt
                    JOIN   Bills b      ON b.BillId = bt.BillId
                    JOIN   Tenancies tn ON tn.TenancyId = @tn
                    WHERE  bt.TenantId = @tid
                      AND  b.RoomId = @src
                      AND  b.BillCategory = @rent
                      AND  b.BillingPeriodStart >= tn.MoveInDate
                      AND  b.BillingPeriodEnd > @today
                      AND  (@first IS NULL OR b.BillingPeriodStart < @first)
                    ORDER BY b.BillingPeriodStart;", conn, tx))
                {
                    cmd.Parameters.Add("@tn", SqlDbType.Int).Value = m.TenancyId;
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = m.TenantId;
                    cmd.Parameters.Add("@src", SqlDbType.Int).Value = plan.SourceRoomId;
                    cmd.Parameters.Add("@rent", SqlDbType.NVarChar, 20).Value = Rent;
                    cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;
                    cmd.Parameters.Add("@first", SqlDbType.Date).Value =
                        plan.FirstBill.HasValue ? (object)plan.FirstBill.Value : DBNull.Value;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            DateTime start = r.GetDateTime(0);

                            // The new room's price for that period (a scheduled price if it starts by then).
                            decimal price = destPending.HasValue && destPendingFrom.HasValue && start >= destPendingFrom.Value
                                ? destPending.Value
                                : destPrice;

                            m.Lines.Add(new TransferDiffLine
                            {
                                PeriodStart = start,
                                PeriodEnd = r.GetDateTime(1),
                                OldShare = r.GetDecimal(2),
                                NewShare = Math.Floor(price / payersAfter * 100m) / 100m   // same rounding as the bills
                            });
                        }
                    }
                }

                m.Difference = m.Lines.Sum(l => l.Difference);

                decimal credit = m.Difference > 0m
                    ? BillingHelper.GetAvailableCredit(conn, m.TenantId, Rent, tx)
                    : 0m;
                m.CreditUsed = Math.Min(credit, m.Difference);
                m.Due = m.Difference - m.CreditUsed;
            }
        }

        /// <summary>"Oct 31 – Nov 30: 12,000.00 − 6,000.00" lines for screens.</summary>
        public static string Breakdown(TransferMover m)
        {
            return string.Join("\n", m.Lines.Where(l => l.Difference > 0m).Select(l =>
                $"{l.PeriodStart:MMM d} – {l.PeriodEnd:MMM d}: {l.NewShare:N2} − {l.OldShare:N2}"));
        }


        /* =================================================================
           SAVE - transfer + difference bill + credit + receipts, one transaction
           ================================================================= */

        public static TransferResult Save(TransferPlan plan)
        {
            if (plan == null) throw new ArgumentNullException(nameof(plan));
            if (plan.Movers.Count == 0) throw new InvalidOperationException("Tick at least one tenant to transfer.");

            ValidatePayments(plan);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        TransferResult result = SaveInsideTransaction(conn, tx, plan, DateTime.Today);
                        tx.Commit();
                        return result;
                    }
                    catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
                    {
                        TryRollback(tx);
                        throw new InvalidOperationException(
                            "A GCash reference number or receipt number is already used. Check the reference.");
                    }
                    catch
                    {
                        TryRollback(tx);
                        throw;
                    }
                }
            }
        }

        /// <summary>Amount at least what is due, 2 decimals, Cash/GCash, valid unique references.</summary>
        private static void ValidatePayments(TransferPlan plan)
        {
            var references = new List<string>();

            foreach (TransferMover m in plan.Movers.Where(x => x.Due > 0m))
            {
                if (m.AmountPaid < m.Due)
                    throw new InvalidOperationException($"{m.Name} must pay at least the difference due: PHP {m.Due:N2}.");
                if (m.AmountPaid != Math.Round(m.AmountPaid, 2))
                    throw new InvalidOperationException($"Amounts can have at most 2 decimal places ({m.Name}).");
                if (m.Method != MoveInService.Cash && m.Method != MoveInService.GCash)
                    throw new InvalidOperationException($"Choose Cash or GCash ({m.Name}).");

                if (m.Method == MoveInService.GCash)
                {
                    string reference = (m.ReferenceNo ?? "").Trim();
                    if (!MoveInService.IsValidGCashReference(reference))
                        throw new InvalidOperationException($"GCash reference number must be exactly 13 digits ({m.Name}).");
                    references.Add(reference);
                }
            }

            if (references.Distinct().Count() != references.Count)
                throw new InvalidOperationException("Two payers have the same GCash reference number.");
        }

        private static TransferResult SaveInsideTransaction(SqlConnection conn, SqlTransaction tx,
                                                            TransferPlan plan, DateTime today)
        {
            // ---- 1. Lock both rooms (lower RoomId first: two transfers can't deadlock) ----
            foreach (int roomId in new[] { plan.SourceRoomId, plan.DestRoomId }.OrderBy(x => x))
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT RoomId FROM Rooms WITH (UPDLOCK, HOLDLOCK) WHERE RoomId = @rid;", conn, tx))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                    cmd.ExecuteScalar();
                }
            }

            // ---- 2. Re-check everything from fresh data ----
            var shownDue = plan.Movers.ToDictionary(m => m.TenantId, m => m.Due);
            decimal shownDifference = plan.TotalDifference;

            ComputeInto(conn, tx, plan, today);

            if (plan.TotalDifference != shownDifference ||
                plan.Movers.Any(m => m.Due != shownDue[m.TenantId]))
                throw new InvalidOperationException(
                    "The price difference changed while this screen was open (a bill, price or payment changed). Start the transfer again.");

            foreach (TransferMover m in plan.Movers)
            {
                foreach (string cat in Categories)
                {
                    decimal owed = BillingHelper.GetTotalOutstanding(conn, m.TenantId, cat, tx);
                    if (owed >= 0.005m)
                        throw new InvalidOperationException($"{m.Name} now owes {cat} {owed:N2}. Settle it first.");
                }
            }

            int destCapacity, destOccupants;
            using (SqlCommand cmd = new SqlCommand(
                "SELECT ISNULL(Capacity, 0), ISNULL(Occupants, 0) FROM vwRoomStatus WHERE RoomId = @rid;", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = plan.DestRoomId;
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    r.Read();
                    destCapacity = r.GetInt32(0);
                    destOccupants = r.GetInt32(1);
                }
            }

            int moving = 0;
            foreach (TransferMover m in plan.Movers)
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Dependents WHERE TenancyId = @tn AND Status = 'Active';", conn, tx))
                {
                    cmd.Parameters.Add("@tn", SqlDbType.Int).Value = m.TenancyId;
                    moving += 1 + (int)cmd.ExecuteScalar();
                }
            }

            if (destOccupants + moving > destCapacity)
                throw new InvalidOperationException($"Room {plan.DestRoomNumber} no longer has space for {moving} people.");

            // ---- 3. The transfer itself (same steps as TransferForm) ----
            var log = new List<string>();
            int dependentsMoved = 0;

            foreach (TransferMover m in plan.Movers)
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE Tenancies
                       SET Status = 'Inactive', MoveOutDate = @date, MoveOutReason = 'Transferred'
                     WHERE TenancyId = @tn AND Status = 'Active';", conn, tx))
                {
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                    cmd.Parameters.Add("@tn", SqlDbType.Int).Value = m.TenancyId;
                    if (cmd.ExecuteNonQuery() != 1)
                        throw new InvalidOperationException(m.Name + " is no longer an active tenant of Room " + plan.SourceRoomNumber + ".");
                }

                int newTenancyId;
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                    OUTPUT INSERTED.TenancyId
                    VALUES (@tid, @rid, @date, 'Active');", conn, tx))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = m.TenantId;
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = plan.DestRoomId;
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                    newTenancyId = (int)cmd.ExecuteScalar();
                }

                // Dependents: re-add under the new stay, then close the old rows.
                int deps;
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Dependents (TenancyId, FirstName, MiddleName, LastName, ContactNumber, MoveInDate, Status)
                    SELECT @newTn, FirstName, MiddleName, LastName, ContactNumber, @date, 'Active'
                    FROM   Dependents
                    WHERE  TenancyId = @oldTn AND Status = 'Active';

                    UPDATE Dependents
                       SET Status = 'Inactive', MoveOutDate = @date, MoveOutReason = 'Transferred'
                     WHERE TenancyId = @oldTn AND Status = 'Active';", conn, tx))
                {
                    cmd.Parameters.Add("@newTn", SqlDbType.Int).Value = newTenancyId;
                    cmd.Parameters.Add("@oldTn", SqlDbType.Int).Value = m.TenancyId;
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                    deps = cmd.ExecuteNonQuery() / 2;   // each dependent = 1 insert + 1 update
                }

                dependentsMoved += deps;
                log.Add(m.Name + (deps > 0 ? $" + {deps} dependent(s)" : ""));
            }

            // Empty destination: keep their cycle (first bill not created yet in the
            // source room) and apply a scheduled price now.
            if (plan.DestEmpty)
            {
                using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE Rooms
                       SET BillingAnchorDate = @date,
                           RoomPrice         = ISNULL(PendingRoomPrice, RoomPrice),
                           PendingRoomPrice  = NULL,
                           PendingPriceFrom  = NULL
                     WHERE RoomId = @rid;", conn, tx))
                {
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = plan.FirstBill ?? today;
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = plan.DestRoomId;
                    cmd.ExecuteNonQuery();
                }
            }

            // Source left empty: no cycle, and a scheduled price becomes the price.
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE Rooms
                   SET BillingAnchorDate = NULL,
                       RoomPrice         = ISNULL(PendingRoomPrice, RoomPrice),
                       PendingRoomPrice  = NULL,
                       PendingPriceFrom  = NULL
                 WHERE RoomId = @rid
                   AND NOT EXISTS (SELECT 1 FROM Tenancies tn WHERE tn.RoomId = @rid AND tn.Status = 'Active');", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = plan.SourceRoomId;
                cmd.ExecuteNonQuery();
            }

            // ---- 4. The price difference: bill, credit, receipts ----
            var result = new TransferResult
            {
                PayingCount = plan.Movers.Count,
                DependentCount = dependentsMoved,
                FirstBill = plan.FirstBill
            };

            if (plan.TotalDifference > 0m)
            {
                int billId = CreateDifferenceBill(conn, tx, plan, today);

                foreach (TransferMover m in plan.Movers.Where(x => x.Difference > 0m))
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO BillTenants (BillId, TenantId, Share) VALUES (@bid, @tid, @share);", conn, tx))
                    {
                        cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = m.TenantId;
                        AddMoney(cmd, "@share", m.Difference);
                        cmd.ExecuteNonQuery();
                    }

                    // Advance credit first (the same routine new bills use).
                    if (m.CreditUsed > 0m)
                        BillGenerator.ConsumeCredit(conn, tx, m.TenantId, billId, m.Difference);
                }

                // The rest is paid now: one normal receipt per payer.
                var payers = plan.Movers.Where(x => x.Due > 0m).ToList();
                string baseNo = "R" + DateTime.Now.ToString("yyyyMMddHHmmss");

                for (int i = 0; i < payers.Count; i++)
                {
                    TransferMover m = payers[i];
                    string receiptNo = payers.Count == 1 ? baseNo : baseNo + "-" + (i + 1);
                    string type = m.AmountPaid == m.Due ? "Full" : "Advance";   // more than due becomes Rent credit

                    BillingHelper.RecordReceipt(conn, tx, plan.DestRoomId, m.TenantId, false,
                        new List<PaymentLine> { new PaymentLine(Rent, m.AmountPaid, type) },
                        m.Method,
                        m.Method == MoveInService.GCash ? m.ReferenceNo.Trim() : null,
                        today, Session.UserId, receiptNo);

                    result.Receipts.Add(new MoveInReceiptLine
                    {
                        ReceiptNo = receiptNo,
                        PayerName = m.Name + " (difference)",
                        Method = m.Method,
                        Amount = m.AmountPaid
                    });
                }
            }

            // ---- 5. Audit, same transaction ----
            string money = plan.TotalDifference > 0m
                ? $"; price difference {plan.TotalDifference:N2} (credit {plan.TotalCredit:N2}, paid {plan.Movers.Sum(m => m.Due > 0m ? m.AmountPaid : 0m):N2})"
                : "";

            AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Transfer",
                string.Join("; ", log) + " transferred from Room " + plan.SourceRoomNumber +
                " to Room " + plan.DestRoomNumber + " on " + today.ToString("MMM dd, yyyy") + money);

            return result;
        }

        /// <summary>
        /// The one "price difference" Rent bill in the destination room:
        /// today -> their first bill there, due today.
        /// If the room already has a Rent bill starting today, the difference
        /// joins it (one bill per room per period start is a database rule).
        /// </summary>
        private static int CreateDifferenceBill(SqlConnection conn, SqlTransaction tx, TransferPlan plan, DateTime today)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT BillId FROM Bills WITH (UPDLOCK, HOLDLOCK)
                WHERE  RoomId = @rid AND BillCategory = @rent AND BillingPeriodStart = @today;", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = plan.DestRoomId;
                cmd.Parameters.Add("@rent", SqlDbType.NVarChar, 20).Value = Rent;
                cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;
                object existing = cmd.ExecuteScalar();

                if (existing != null && existing != DBNull.Value)
                {
                    int id = Convert.ToInt32(existing);
                    using (SqlCommand up = new SqlCommand("UPDATE Bills SET Amount = Amount + @amt WHERE BillId = @bid;", conn, tx))
                    {
                        up.Parameters.Add("@bid", SqlDbType.Int).Value = id;
                        AddMoney(up, "@amt", plan.TotalDifference);
                        up.ExecuteNonQuery();
                    }
                    return id;
                }
            }

            // Today is one of the destination's own billing dates but its bill was
            // not generated yet: our bill would take that slot and the room's real
            // bill could never be created. Ask for the bills to be generated first.
            if (!plan.DestEmpty && IsAnchorPeriod(conn, tx, plan.DestRoomId, today))
                throw new InvalidOperationException(
                    $"Room {plan.DestRoomNumber}'s rent bill for today has not been created yet. " +
                    "Log out and back in (or use Generate Bills), then try the transfer again.");

            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Bills (RoomId, BillCategory, BillingPeriodStart, BillingPeriodEnd, DueDate, Amount, Remarks)
                OUTPUT INSERTED.BillId
                VALUES (@rid, @rent, @start, @end, @start, @amt, @remarks);", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = plan.DestRoomId;
                cmd.Parameters.Add("@rent", SqlDbType.NVarChar, 20).Value = Rent;
                cmd.Parameters.Add("@start", SqlDbType.Date).Value = today;
                cmd.Parameters.Add("@end", SqlDbType.Date).Value = plan.FirstBill ?? today.AddMonths(1);
                AddMoney(cmd, "@amt", plan.TotalDifference);
                cmd.Parameters.Add("@remarks", SqlDbType.NVarChar, 255).Value =
                    "Price difference - transfer from Room " + plan.SourceRoomNumber;
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>True when today is one of the room's anchor period starts.</summary>
        private static bool IsAnchorPeriod(SqlConnection conn, SqlTransaction tx, int roomId, DateTime today)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT BillingAnchorDate FROM Rooms WHERE RoomId = @rid;", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                object o = cmd.ExecuteScalar();
                if (o == null || o == DBNull.Value) return false;

                DateTime anchor = (DateTime)o;
                for (int n = 0; anchor.AddMonths(n) <= today; n++)
                    if (anchor.AddMonths(n) == today) return true;
                return false;
            }
        }

        private static void AddMoney(SqlCommand cmd, string name, decimal value)
        {
            SqlParameter p = cmd.Parameters.Add(name, SqlDbType.Decimal);
            p.Precision = 18;
            p.Scale = 2;
            p.Value = value;
        }

        private static void TryRollback(SqlTransaction tx)
        {
            try { tx.Rollback(); }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }
        }
    }

}
