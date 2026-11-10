using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.RoomsForms
{
    /* =========================================================================
       NEW (Transfer rules, Nov 6, 2026)
       -------------------------------------------------------------------------
       Who owes what share of a room's rent when people LEAVE or JOIN it.
       Step 2 (Transfer) uses this now. Step 3 (Move In joiners) will reuse Join.

       A PERIOD is every rent bill of one room that ends on the same date:
           Regular      the room's normal bill
           TransferGap  what a remaining tenant owes after someone left
           JoinerShare  what a joiner took over

       LEAVE (Falco leaves Room 306, Gabi stays)
         1. Falco's shares on the CURRENT period come off the old bills, and
            that money moves with him. A bill with no shares left becomes Closed.
         2. A next bill already issued is final (approved Nov 6, option 2):
            Falco's paid share stays on it, and nothing on it changes.
         3. Gabi owes up to her fair share of the money that left, on a
            TransferGap bill due today.
         4. Her advance credit is used first.
         5. Nobody stays -> nobody owes anything.

       JOIN (Pieck joins Room 306)
         1. Fair share = the period's total / people after joining, less any
            share the joiner already holds there (a tenant coming back before
            a next bill they already paid starts).
         2. Capped at what is still unpaid. Paid tenants keep their shares and
            no credit is created.
         3. Only unpaid shares are reduced, on a JoinerShare bill due today.
         4. A next bill already issued is final (approved Nov 7): the joiner
            is not added to it and starts on the first bill not issued yet.

       Everything here runs inside the caller's transaction.
       ========================================================================= */

    /// <summary>NEW: one tenant's share on one rent bill.</summary>
    internal sealed class RentShare
    {
        public int BillId;
        public int TenantId;
        public decimal Share;
        public decimal Paid;
        public decimal Owing => Math.Max(0m, Share - Paid);
    }

    /// <summary>NEW: every rent bill of a room that ends on the same date.</summary>
    internal sealed class RentPeriod
    {
        public DateTime End;
        public DateTime FirstStart;
        public int MainBillId;      // the oldest bill of the period
        public List<RentShare> Shares = new List<RentShare>();

        public decimal Total => Shares.Sum(s => s.Share);
        public decimal Unpaid => Shares.Sum(s => s.Owing);
        public bool HasStarted(DateTime today) => FirstStart <= today;
    }

    /// <summary>NEW: what one remaining tenant owes after someone leaves.</summary>
    internal sealed class StayerCharge
    {
        public RentPeriod Period = new RentPeriod();
        public int TenantId;
        public string Name = "";
        public decimal Amount;
    }

    /// <summary>NEW: what joiners take over in one period.</summary>
    internal sealed class JoinPart
    {
        public RentPeriod Period = new RentPeriod();
        public decimal Amount;
        public decimal[] Shares = new decimal[0];     // same order as the joiners
    }

    /// <summary>NEW: a share created for someone in their new room.</summary>
    internal sealed class NewRoomShare
    {
        public int BillId;
        public decimal Amount;
    }

    /// <summary>NEW: one payment row that moves with a tenant.</summary>
    internal sealed class CarriedRow
    {
        public int AllocationId;
        public int PaymentId;
        public int FromBillId;
        public decimal Amount;
    }

    internal static class RoomRentShares
    {
        private const string Rent = "Rent";

        /* =================================================================
           READ
           ================================================================= */

        /// <summary>
        /// The room's rent periods that have not ended, with the active
        /// tenants' shares. Older unpaid periods stay with whoever was billed.
        /// A moved-out tenant's share is left out: their money stays where it is.
        /// </summary>
        /// <param name="returning">
        /// Tenants about to join this room. A share they still hold on a next
        /// bill here (paid before they left) is read too, so it is counted.
        /// </param>
        internal static List<RentPeriod> ReadPeriods(SqlConnection conn, SqlTransaction tx, int roomId, DateTime today,
                                                     ICollection<int>? returning = null)
        {
            var periods = new List<RentPeriod>();
            var ids = (returning ?? new List<int>()).ToList();

            // @r0, @r1, ... one parameter per returning tenant
            string returningSql = ids.Count == 0 ? "" :
                " OR (b.BillingPeriodStart > @today AND bt.TenantId IN (" +
                string.Join(", ", ids.Select((id, i) => "@r" + i)) + "))";

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT b.BillId, b.BillingPeriodStart, b.BillingPeriodEnd, bt.TenantId, bt.Share,
                       ISNULL((SELECT SUM(a.Amount)
                               FROM   PaymentAllocations a
                               JOIN   Payments p ON p.PaymentId = a.PaymentId
                               WHERE  a.BillId   = bt.BillId
                                 AND  a.TenantId = bt.TenantId
                                 AND  a.IsVoided = 0
                                 AND  p.IsVoided = 0), 0) AS Paid
                FROM   Bills b
                JOIN   BillTenants bt     ON bt.BillId = b.BillId
                LEFT JOIN Tenancies tn    ON tn.TenantId = bt.TenantId
                                         AND tn.RoomId   = b.RoomId
                                         AND tn.Status   = 'Active'
                WHERE  b.RoomId = @rid
                  AND  b.BillCategory = @rent
                  AND  b.BillKind NOT IN (N'Closed', N'Superseded')   -- NEW (item 4): ORIGINAL b.BillKind <> N'Closed'
                  AND  b.BillingPeriodEnd > @today
                  AND  ((tn.TenancyId IS NOT NULL AND b.BillingPeriodStart >= tn.MoveInDate)" + returningSql + @")
                ORDER BY b.BillingPeriodEnd, b.BillingPeriodStart, b.BillId,
                         ISNULL(tn.MoveInDate, '9999-12-31'), bt.TenantId;", conn, tx))
            {
                for (int i = 0; i < ids.Count; i++)
                    cmd.Parameters.Add("@r" + i, SqlDbType.Int).Value = ids[i];

                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                cmd.Parameters.Add("@rent", SqlDbType.NVarChar, 20).Value = Rent;
                cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        int billId = r.GetInt32(0);
                        DateTime start = r.GetDateTime(1);
                        DateTime end = r.GetDateTime(2);

                        RentPeriod? period = periods.FirstOrDefault(p => p.End == end);
                        if (period == null)
                        {
                            period = new RentPeriod { End = end, FirstStart = start, MainBillId = billId };
                            periods.Add(period);
                        }

                        period.Shares.Add(new RentShare
                        {
                            BillId = billId,
                            TenantId = r.GetInt32(3),
                            Share = r.GetDecimal(4),
                            Paid = r.GetDecimal(5)
                        });
                    }
                }
            }

            return periods;
        }

        /// <summary>
        /// NEW (Step 3): true when the room's next rent bill is already issued
        /// (a Regular bill whose period has not started yet) - the room is near due.
        /// </summary>
        internal static bool NextBillIssued(SqlConnection conn, SqlTransaction? tx, int roomId, DateTime today)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT CASE WHEN EXISTS (
                           SELECT 1 FROM Bills
                           WHERE  RoomId = @rid
                             AND  BillCategory = @rent
                             AND  BillKind = N'Regular'
                             AND  MaintenanceIssueId IS NULL
                             AND  BillingPeriodStart > @today)
                       THEN 1 ELSE 0 END;", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                cmd.Parameters.Add("@rent", SqlDbType.NVarChar, 20).Value = Rent;
                cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;
                return (int)cmd.ExecuteScalar() == 1;
            }
        }

        /// <summary>The room's active paying tenants, longest-tenured first.</summary>
        internal static List<int> ActiveTenantIds(SqlConnection conn, SqlTransaction tx, int roomId)
        {
            var list = new List<int>();

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT TenantId FROM Tenancies
                WHERE  RoomId = @rid AND Status = 'Active'
                ORDER BY MoveInDate ASC, TenantId ASC;", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                using (SqlDataReader r = cmd.ExecuteReader())
                    while (r.Read()) list.Add(r.GetInt32(0));
            }

            return list;
        }

        /// <summary>The payment rows on a tenant's unfinished rent periods in this room.</summary>
        internal static List<CarriedRow> ReadCarriedRows(SqlConnection conn, SqlTransaction tx,
                                                         int tenantId, int roomId, DateTime today)
        {
            var rows = new List<CarriedRow>();

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT a.AllocationId, a.PaymentId, a.BillId, a.Amount
                FROM   PaymentAllocations a
                JOIN   Payments p   ON p.PaymentId = a.PaymentId
                JOIN   Bills b      ON b.BillId    = a.BillId
                JOIN   Tenancies tn ON tn.TenantId = a.TenantId
                                   AND tn.RoomId   = b.RoomId
                                   AND tn.Status   = 'Active'
                WHERE  a.TenantId = @tid
                  AND  b.RoomId = @rid
                  AND  b.BillCategory = @rent
                  AND  a.IsVoided = 0
                  AND  p.IsVoided = 0
                  AND  b.BillKind NOT IN (N'Closed', N'Superseded')   -- NEW (item 4): ORIGINAL b.BillKind <> N'Closed'
                  AND  b.BillingPeriodEnd > @today
                  AND  b.BillingPeriodStart <= @today      -- a next bill already issued stays (option 2)
                  AND  b.BillingPeriodStart >= tn.MoveInDate
                ORDER BY a.AllocationId ASC;", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                cmd.Parameters.Add("@rent", SqlDbType.NVarChar, 20).Value = Rent;
                cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        rows.Add(new CarriedRow
                        {
                            AllocationId = r.GetInt32(0),
                            PaymentId = r.GetInt32(1),
                            FromBillId = r.GetInt32(2),
                            Amount = r.GetDecimal(3)
                        });
                    }
                }
            }

            return rows;
        }


        /* =================================================================
           LEAVE
           ================================================================= */

        /// <summary>
        /// Works out what each remaining tenant owes. Reads nothing and saves
        /// nothing, so the Transfer screen and the save use the same figures.
        /// </summary>
        internal static List<StayerCharge> PlanLeave(List<RentPeriod> periods, ICollection<int> movers, IList<int> stayers)
        {
            var charges = new List<StayerCharge>();
            if (stayers.Count == 0) return charges;      // empty room: nobody owes

            foreach (RentPeriod period in periods)
            {
                decimal moved = period.Shares.Where(s => movers.Contains(s.TenantId)).Sum(s => s.Share);
                if (moved <= 0m) continue;

                // What each person holds in this period now.
                var held = stayers.Select(id => period.Shares.Where(s => s.TenantId == id).Sum(s => s.Share)).ToList();

                // The money people in the room must cover, split fairly among those staying.
                decimal[] fair = BillGenerator.SplitEqually(moved + held.Sum(), stayers.Count);

                var needs = new List<KeyValuePair<int, decimal>>();
                for (int i = 0; i < stayers.Count; i++)
                    needs.Add(new KeyValuePair<int, decimal>(stayers[i], Math.Max(0m, fair[i] - held[i])));

                decimal toCharge = Math.Min(moved, needs.Sum(x => x.Value));

                foreach (var part in BillingHelper.SplitWholeRoom(needs, toCharge))
                {
                    if (part.Value > 0m)
                        charges.Add(new StayerCharge { Period = period, TenantId = part.Key, Amount = part.Value });
                }
            }

            return charges;
        }

        /// <summary>Takes the movers off the old bills and charges those who stay.</summary>
        internal static void ApplyLeave(SqlConnection conn, SqlTransaction tx, int roomId, string roomNumber,
                                        List<RentPeriod> periods, ICollection<int> movers,
                                        List<StayerCharge> charges, DateTime today)
        {
            var touched = new HashSet<int>();

            // 1. The movers' shares come off their bills.
            foreach (RentPeriod period in periods)
            {
                foreach (RentShare share in period.Shares.Where(s => movers.Contains(s.TenantId)))
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM BillTenants WHERE BillId = @bid AND TenantId = @tid;", conn, tx))
                    {
                        cmd.Parameters.Add("@bid", SqlDbType.Int).Value = share.BillId;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = share.TenantId;
                        cmd.ExecuteNonQuery();
                    }
                    touched.Add(share.BillId);
                }
            }

            // 2. Those who stay.
            foreach (var group in charges.GroupBy(c => c.Period))
            {
                RentPeriod period = group.Key;

                if (period.HasStarted(today))
                {
                    // The period is running: due immediately, on its own bill.
                    int gapId = InsertBill(conn, tx, roomId, "TransferGap", today, period.End, today,
                                           group.Sum(c => c.Amount), "Transfer share - Room " + roomNumber);

                    foreach (StayerCharge charge in group)
                    {
                        AddShare(conn, tx, gapId, charge.TenantId, charge.Amount);
                        BillGenerator.ConsumeCredit(conn, tx, charge.TenantId, gapId, charge.Amount);
                    }
                }
                else
                {
                    // The next bill was issued early: a higher share keeps its due date.
                    foreach (StayerCharge charge in group)
                    {
                        AddShare(conn, tx, period.MainBillId, charge.TenantId, charge.Amount);
                        BillGenerator.ConsumeCredit(conn, tx, charge.TenantId, period.MainBillId, charge.Amount);
                    }
                    touched.Add(period.MainBillId);
                }
            }

            foreach (int billId in touched)
                RefreshBill(conn, tx, billId);
        }


        /* =================================================================
           JOIN
           ================================================================= */

        /// <summary>
        /// Works out what joiners take over, one entry per unpaid period.
        /// Reads nothing and saves nothing. A fully paid period is skipped.
        /// </summary>
        internal static List<JoinPart> PlanJoin(List<RentPeriod> periods, int payersInRoom, IList<int> joiners,
                                                DateTime today)
        {
            var parts = new List<JoinPart>();

            foreach (RentPeriod period in periods)
            {
                // NEW (Nov 7): a next bill already issued is final. The joiner
                // starts on the first bill not issued yet.
                if (!period.HasStarted(today)) continue;

                // What the people already living there still owe (the cap).
                decimal unpaid = period.Shares.Where(s => !joiners.Contains(s.TenantId)).Sum(s => s.Owing);
                if (unpaid <= 0m) continue;

                // Each joiner's fair share, less a share they already hold here.
                decimal fairEach = Math.Floor(period.Total / (payersInRoom + joiners.Count) * 100m) / 100m;

                var needs = joiners.Select(id => new KeyValuePair<int, decimal>(id,
                                Math.Max(0m, fairEach - period.Shares.Where(s => s.TenantId == id).Sum(s => s.Share))))
                                   .ToList();

                decimal amount = Math.Min(needs.Sum(x => x.Value), unpaid);     // the cap wins
                if (amount <= 0m) continue;

                parts.Add(new JoinPart
                {
                    Period = period,
                    Amount = amount,
                    Shares = BillingHelper.SplitWholeRoom(needs, amount).Select(x => x.Value).ToArray()
                });
            }

            return parts;
        }

        /// <summary>
        /// Moves one period's unpaid money from the people already there to the
        /// joiners. Returns the bill the joiners were charged on.
        /// </summary>
        internal static int ApplyJoin(SqlConnection conn, SqlTransaction tx, int roomId, string roomNumber,
                                      JoinPart part, IList<int> joiners, DateTime today)
        {
            var touched = new HashSet<int>();

            // 1. Only unpaid shares are reduced, equally, never below what was paid.
            List<RentShare> open = part.Period.Shares.Where(s => s.Owing > 0m && !joiners.Contains(s.TenantId)).ToList();

            var owing = new List<KeyValuePair<int, decimal>>();
            for (int i = 0; i < open.Count; i++)
                owing.Add(new KeyValuePair<int, decimal>(i, open[i].Owing));

            foreach (var cut in BillingHelper.SplitWholeRoom(owing, part.Amount))
            {
                if (cut.Value <= 0m) continue;
                ReduceShare(conn, tx, open[cut.Key], cut.Value);
                touched.Add(open[cut.Key].BillId);
            }

            // 2. The joiners take it over.
            int billId = part.Period.HasStarted(today)
                ? InsertBill(conn, tx, roomId, "JoinerShare", today, part.Period.End, today,
                             part.Amount, "Joiner share - Room " + roomNumber)
                : part.Period.MainBillId;

            for (int i = 0; i < joiners.Count; i++)
            {
                if (part.Shares[i] > 0m)
                    AddShare(conn, tx, billId, joiners[i], part.Shares[i]);
            }
            touched.Add(billId);

            foreach (int id in touched)
                RefreshBill(conn, tx, id);

            return billId;
        }


        /* =================================================================
           BILLS AND SHARES
           ================================================================= */

        /// <summary>The bill for a tenant moving into a vacant room.</summary>
        /// <remarks>
        /// NEW (item 4): the previous occupants' bill for a period that has not
        /// started yet is retired first (SupersedeOldCycle), and the newcomer
        /// ALWAYS gets a fresh bill - never the old tenants' bill.
        /// Its only caller is a transfer into an EMPTY room.
        /// </remarks>
        internal static int FindOrInsertRegular(SqlConnection conn, SqlTransaction tx, int roomId,
                                                DateTime start, DateTime end, decimal amount)
        {
            // NEW (item 4): retire the previous occupants' not-started bill (frees today's slot).
            SupersedeOldCycle(conn, tx, roomId, start);

            // ORIGINAL (item 4): reused the old tenants' bill when it started today, so
            // the mover's share landed on a bill with THEIR period. Kept for reference:
            //// A Regular bill can already start today if the last tenant moved out today.
            //using (SqlCommand cmd = new SqlCommand(@"
            //    SELECT BillId FROM Bills WITH (UPDLOCK, HOLDLOCK)
            //    WHERE  RoomId = @rid AND BillCategory = @rent
            //      AND  BillingPeriodStart = @start AND BillKind = N'Regular'
            //      AND  MaintenanceIssueId IS NULL;", conn, tx))
            //{
            //    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
            //    cmd.Parameters.Add("@rent", SqlDbType.NVarChar, 20).Value = Rent;
            //    cmd.Parameters.Add("@start", SqlDbType.Date).Value = start;
            //
            //    object existing = cmd.ExecuteScalar();
            //    if (existing != null && existing != DBNull.Value)
            //        return Convert.ToInt32(existing);
            //}

            return InsertBill(conn, tx, roomId, "Regular", start, end, start, amount, null);
        }

        /// <summary>
        /// NEW (item 4): a VACANT room is starting a new cycle (Move In or a
        /// transfer into an empty room).
        ///
        /// Bills are created 7 days early, so the last tenants' NEXT bill may
        /// already exist. They still owe it (an issued bill never changes - it
        /// was written off at move-out), but nobody will live in that period.
        /// That bill is marked Superseded:
        ///   - it stays as their charge: shares, payments and write-off untouched
        ///   - it is no longer a room period (screens, statement, generator,
        ///     joiner and transfer checks all skip it)
        ///   - it frees the one-Regular-bill-per-date slot for the new bill
        ///
        /// Only bills that start today or later. A bill already running is real
        /// history (they lived in it); the statement cuts it at the new start.
        ///
        /// Call ONLY when the room had no active tenant before this save.
        /// Returns how many bills were superseded (0 or 1 in practice).
        /// </summary>
        internal static int SupersedeOldCycle(SqlConnection conn, SqlTransaction tx, int roomId, DateTime today)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE Bills
                   SET BillKind = N'Superseded'
                 WHERE RoomId = @rid
                   AND BillCategory = @rent
                   AND BillKind = N'Regular'
                   AND MaintenanceIssueId IS NULL
                   AND BillingPeriodStart >= @today;", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                cmd.Parameters.Add("@rent", SqlDbType.NVarChar, 20).Value = Rent;
                cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;
                return cmd.ExecuteNonQuery();
            }
        }

        private static int InsertBill(SqlConnection conn, SqlTransaction tx, int roomId, string kind,
                                      DateTime start, DateTime end, DateTime due, decimal amount, string? remarks)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Bills (RoomId, BillCategory, BillKind, BillingPeriodStart, BillingPeriodEnd,
                                   DueDate, Amount, Remarks)
                OUTPUT INSERTED.BillId
                VALUES (@rid, @rent, @kind, @start, @end, @due, @amt, @remarks);", conn, tx))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                cmd.Parameters.Add("@rent", SqlDbType.NVarChar, 20).Value = Rent;
                cmd.Parameters.Add("@kind", SqlDbType.NVarChar, 20).Value = kind;
                cmd.Parameters.Add("@start", SqlDbType.Date).Value = start;
                cmd.Parameters.Add("@end", SqlDbType.Date).Value = end;
                cmd.Parameters.Add("@due", SqlDbType.Date).Value = due;
                AddMoney(cmd, "@amt", amount);
                cmd.Parameters.Add("@remarks", SqlDbType.NVarChar, 255).Value =
                    remarks == null ? (object)DBNull.Value : remarks;
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>Adds to a tenant's share, or creates the share.</summary>
        internal static void AddShare(SqlConnection conn, SqlTransaction tx, int billId, int tenantId, decimal amount)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE BillTenants SET Share = Share + @amt
                WHERE  BillId = @bid AND TenantId = @tid;

                IF @@ROWCOUNT = 0
                    INSERT INTO BillTenants (BillId, TenantId, Share)
                    VALUES (@bid, @tid, @amt);", conn, tx))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                AddMoney(cmd, "@amt", amount);
                cmd.ExecuteNonQuery();
            }
        }

        private static void ReduceShare(SqlConnection conn, SqlTransaction tx, RentShare share, decimal cut)
        {
            // Share must stay above 0, so a share with nothing left is removed.
            string sql = share.Share - cut > 0m
                ? "UPDATE BillTenants SET Share = Share - @cut WHERE BillId = @bid AND TenantId = @tid;"
                : "DELETE FROM BillTenants WHERE BillId = @bid AND TenantId = @tid;";

            using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = share.BillId;
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = share.TenantId;
                AddMoney(cmd, "@cut", cut);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Keeps a bill in step with its shares. Bills.Amount cannot be 0, so a
        /// bill with no shares left keeps its last amount and becomes Closed.
        /// </summary>
        internal static void RefreshBill(SqlConnection conn, SqlTransaction tx, int billId)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE Bills
                   SET Amount = (SELECT SUM(Share) FROM BillTenants WHERE BillId = @bid)
                 WHERE BillId = @bid
                   AND EXISTS (SELECT 1 FROM BillTenants WHERE BillId = @bid);

                UPDATE Bills
                   SET BillKind = N'Closed'
                 WHERE BillId = @bid
                   AND NOT EXISTS (SELECT 1 FROM BillTenants WHERE BillId = @bid);", conn, tx))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                cmd.ExecuteNonQuery();
            }
        }


        /* =================================================================
           THE MONEY THAT MOVES
           ================================================================= */

        /// <summary>
        /// Pays a mover's new shares, oldest first, in the approved order:
        ///   1. their advance credit
        ///   2. the money carried from the old room
        /// Anything carried that is not needed becomes credit.
        /// Each moved amount gets one TransferMoves row.
        /// </summary>
        internal static void MoveCarriedMoney(SqlConnection conn, SqlTransaction tx, int tenantId,
                                              int fromTenancyId, int toTenancyId,
                                              List<NewRoomShare> shares, List<CarriedRow> rows, int recordedBy)
        {
            foreach (NewRoomShare share in shares)
                BillGenerator.ConsumeCredit(conn, tx, tenantId, share.BillId, share.Amount);

            var open = new List<NewRoomShare>();
            foreach (NewRoomShare share in shares)
            {
                decimal owing = OwingOnBill(conn, tx, share.BillId, tenantId);
                if (owing > 0m) open.Add(new NewRoomShare { BillId = share.BillId, Amount = owing });
            }

            foreach (CarriedRow row in rows)
            {
                decimal left = row.Amount;

                foreach (NewRoomShare target in open.Where(x => x.Amount > 0m))
                {
                    if (left <= 0m) break;

                    decimal take = Math.Min(left, target.Amount);

                    if (take == left)
                        PointRowAtBill(conn, tx, row.AllocationId, target.BillId);
                    else
                        SplitRowToBill(conn, tx, row.AllocationId, target.BillId, take);

                    InsertMove(conn, tx, fromTenancyId, toTenancyId, row, target.BillId, take, recordedBy);

                    target.Amount -= take;
                    left -= take;
                }

                if (left > 0m)
                {
                    TurnRowIntoCredit(conn, tx, row.AllocationId);
                    InsertMove(conn, tx, fromTenancyId, toTenancyId, row, null, left, recordedBy);
                }
            }
        }

        private static decimal OwingOnBill(SqlConnection conn, SqlTransaction tx, int billId, int tenantId)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT ISNULL((SELECT Share FROM BillTenants WHERE BillId = @bid AND TenantId = @tid), 0)
                     - ISNULL((SELECT SUM(a.Amount)
                               FROM   PaymentAllocations a
                               JOIN   Payments p ON p.PaymentId = a.PaymentId
                               WHERE  a.BillId   = @bid
                                 AND  a.TenantId = @tid
                                 AND  a.IsVoided = 0
                                 AND  p.IsVoided = 0), 0);", conn, tx))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        private static void PointRowAtBill(SqlConnection conn, SqlTransaction tx, int allocationId, int billId)
        {
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE PaymentAllocations SET BillId = @bid WHERE AllocationId = @aid;", conn, tx))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                cmd.Parameters.Add("@aid", SqlDbType.Int).Value = allocationId;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Part of a row moves: a new row is added and the old one shrinks.</summary>
        private static void SplitRowToBill(SqlConnection conn, SqlTransaction tx, int allocationId, int billId, decimal amount)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO PaymentAllocations (PaymentId, BillId, TenantId, Amount, Category, PaymentType)
                SELECT PaymentId, @bid, TenantId, @amt, Category, PaymentType
                FROM   PaymentAllocations
                WHERE  AllocationId = @aid;

                UPDATE PaymentAllocations
                   SET Amount = Amount - @amt
                 WHERE AllocationId = @aid;", conn, tx))
            {
                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                cmd.Parameters.Add("@aid", SqlDbType.Int).Value = allocationId;
                AddMoney(cmd, "@amt", amount);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>A row with no bill is credit, and credit is always an Advance.</summary>
        private static void TurnRowIntoCredit(SqlConnection conn, SqlTransaction tx, int allocationId)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE PaymentAllocations
                   SET BillId = NULL, PaymentType = N'Advance'
                 WHERE AllocationId = @aid;", conn, tx))
            {
                cmd.Parameters.Add("@aid", SqlDbType.Int).Value = allocationId;
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertMove(SqlConnection conn, SqlTransaction tx, int fromTenancyId, int toTenancyId,
                                       CarriedRow row, int? toBillId, decimal amount, int recordedBy)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO TransferMoves
                    (FromTenancyId, ToTenancyId, SourcePaymentId, FromBillId, ToBillId, Amount, RecordedBy)
                VALUES (@from, @to, @pay, @fromBill, @toBill, @amt, @by);", conn, tx))
            {
                cmd.Parameters.Add("@from", SqlDbType.Int).Value = fromTenancyId;
                cmd.Parameters.Add("@to", SqlDbType.Int).Value = toTenancyId;
                cmd.Parameters.Add("@pay", SqlDbType.Int).Value = row.PaymentId;
                cmd.Parameters.Add("@fromBill", SqlDbType.Int).Value = row.FromBillId;
                cmd.Parameters.Add("@toBill", SqlDbType.Int).Value =
                    toBillId.HasValue ? (object)toBillId.Value : DBNull.Value;
                AddMoney(cmd, "@amt", amount);
                cmd.Parameters.Add("@by", SqlDbType.Int).Value = recordedBy;
                cmd.ExecuteNonQuery();
            }
        }

        private static void AddMoney(SqlCommand cmd, string name, decimal value)
        {
            SqlParameter p = cmd.Parameters.Add(name, SqlDbType.Decimal);
            p.Precision = 18;
            p.Scale = 2;
            p.Value = value;
        }
    }


}
