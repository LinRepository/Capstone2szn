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
    /// Creates the rent bills that fall due as time passes.
    ///
    /// A desktop app has no scheduler, so this runs when a human opens the
    /// system: once on successful login (covering every building), and on
    /// demand from the Generate Bills button in Bill Management.
    ///
    /// The billing cycle belongs to the ROOM (Rooms.BillingAnchorDate), set
    /// when the room is first occupied and never changed afterwards. Every
    /// period is computed from that fixed anchor rather than by advancing it,
    /// so a short month cannot drag the billing date backwards forever:
    ///
    ///     anchor Jan 31  ->  Feb 28, Mar 31, Apr 30, May 31   (correct)
    ///     advancing      ->  Feb 28, Mar 28, Apr 28, May 28   (drifted)
    ///
    /// Only Rent is generated. Maintenance charges come from the maintenance
    /// flow when the material cost is recorded; Water and Electricity come
    /// from the Utilities module.
    /// </summary>
    public static class BillGenerator
    {
        private const string RentCategory = "Rent";

        /// <summary>
        /// A room that is occupied and has a billing anchor, with everything
        /// needed to decide whether it owes a new bill.
        /// </summary>
        private sealed class RoomToBill
        {
            public int RoomId;
            public string RoomNumber = "";
            public DateTime AnchorDate;
            public decimal RoomPrice;
            // Every period already billed for this room, so the generator can fill
            // a gap rather than assuming bills were always created in order.
            public HashSet<DateTime> BilledPeriods = new HashSet<DateTime>();
        }

        /// <summary>
        /// The tenants sharing a room right now, longest-tenured first.
        /// Order matters: the first tenant absorbs the rounding remainder.
        /// </summary>
        private sealed class ActiveTenant
        {
            public int TenantId;
            public DateTime MoveInDate;
        }


        /* =================================================================
           ENTRY POINTS
           ================================================================= */

        /// <summary>
        /// Runs for every building. Call this once after a successful login,
        /// before the user reaches any screen that shows money.
        /// Returns the number of bills created.
        /// </summary>
        public static int RunForAllBuildings()
        {
            return Run(null);
        }

        /// <summary>
        /// Runs for one building. Use this for the manual Generate Bills
        /// button so the landlord sees it act on the building he is in.
        /// Returns the number of bills created.
        /// </summary>
        public static int RunForBuilding(int buildingId)
        {
            return Run(buildingId);
        }


        /* =================================================================
           CORE
           ================================================================= */

        private static int Run(int? buildingId)
        {
            int created = 0;
            DateTime today = DateTime.Today;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                List<RoomToBill> rooms = LoadBillableRooms(conn, buildingId);
                LoadBilledPeriods(conn, rooms);

                foreach (RoomToBill room in rooms)
                {
                    // Walk forward from the anchor one period at a time.
                    // Period n starts at anchor + n months; the first period
                    // (n = 0) is the one the move-in payment covered.
                    for (int n = 0; ; n++)
                    {
                        DateTime periodStart = room.AnchorDate.AddMonths(n);

                        // Not due yet - and no later period can be either.
                        if (periodStart > today) break;

                        // Already billed. The unique constraint on
                        // (RoomId, BillCategory, BillingPeriodStart) would
                        // reject a duplicate anyway; this just avoids the
                        // round trip and the exception.
                        if (room.BilledPeriods.Contains(periodStart))
                            continue;

                        DateTime periodEnd = room.AnchorDate.AddMonths(n + 1);

                        if (GenerateOneBill(conn, room, periodStart, periodEnd))
                            created++;
                    }
                }
            }

            return created;
        }

        /// <summary>
        /// Fills each room's set of already-billed periods in one query.
        /// </summary>
        private static void LoadBilledPeriods(SqlConnection conn, List<RoomToBill> rooms)
        {
            if (rooms.Count == 0) return;

            var byId = new Dictionary<int, RoomToBill>();
            foreach (RoomToBill room in rooms) byId[room.RoomId] = room;

            using (SqlCommand cmd = new SqlCommand(@"
        SELECT b.RoomId, b.BillingPeriodStart
        FROM   Bills b
        WHERE  b.BillCategory = @cat;", conn))
            {
                cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = RentCategory;

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        int roomId = r.GetInt32(0);
                        if (byId.TryGetValue(roomId, out RoomToBill room))
                            room.BilledPeriods.Add(r.GetDateTime(1));
                    }
                }
            }
        }


        /// <summary>
        /// Occupied, priced rooms with an anchor set. Which periods they
        /// already have is loaded separately by LoadBilledPeriods.
        /// </summary>
        private static List<RoomToBill> LoadBillableRooms(SqlConnection conn, int? buildingId)
        {
            var list = new List<RoomToBill>();

            string sql = @"
                SELECT r.RoomId, r.RoomNumber, r.BillingAnchorDate, r.RoomPrice
                FROM   Rooms r
                WHERE  r.IsArchived = 0
                  AND  r.BillingAnchorDate IS NOT NULL
                  AND  r.RoomPrice IS NOT NULL
                  AND  r.RoomPrice > 0
                  AND  EXISTS (SELECT 1 FROM Tenancies tn
                               WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active')";

            if (buildingId.HasValue)
                sql += " AND r.BuildingId = @bid";

            sql += " ORDER BY r.RoomNumber;";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (buildingId.HasValue)
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = buildingId.Value;

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new RoomToBill
                        {
                            RoomId = r.GetInt32(0),
                            RoomNumber = r.GetString(1),
                            AnchorDate = r.GetDateTime(2),
                            RoomPrice = r.GetDecimal(3)
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Creates one bill, its frozen per-tenant shares, and consumes any
        /// credit those tenants are holding - all in one transaction. A bill
        /// with shares for only some of its tenants is worse than no bill.
        /// Returns true if a bill was written.
        /// </summary>
        private static bool GenerateOneBill(
            SqlConnection conn, RoomToBill room, DateTime periodStart, DateTime periodEnd)
        {
            // Who was in the room when this period STARTED, and is still
            // here. A tenant who joins later in the period pays nothing for
            // it and joins the next split.
            //
            // This matters during catch-up. If the app was not opened for
            // three months, those three bills are generated today - and
            // without the start-date check, someone who moved in last week
            // would be charged for all three months they did not live here.
            List<ActiveTenant> tenants = LoadActiveTenants(conn, room.RoomId, periodStart);

            if (tenants.Count == 0)
            {
                // Nobody here now was here when this period began - for
                // example a stale anchor left by a previous occupant. Billing
                // the current tenants for it would charge them for time
                // before they arrived, so the period is skipped.
                Debug.WriteLine($"BillGenerator: room {room.RoomNumber} {periodStart:d} has no tenant present at period start, skipped.");
                return false;
            }

            // The room price is read NOW, so a price change the landlord made
            // during the previous period takes effect here and not before.
            decimal amount = room.RoomPrice;
            decimal[] shares = SplitEqually(amount, tenants.Count);

            using (SqlTransaction tx = conn.BeginTransaction())
            {
                try
                {
                    int billId;

                    using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO Bills
                            (RoomId, BillCategory, BillingPeriodStart,
                             BillingPeriodEnd, DueDate, Amount)
                        OUTPUT INSERTED.BillId
                        VALUES (@rid, @cat, @start, @end, @due, @amt);", conn, tx))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = room.RoomId;
                        cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = RentCategory;
                        cmd.Parameters.Add("@start", SqlDbType.Date).Value = periodStart;
                        cmd.Parameters.Add("@end", SqlDbType.Date).Value = periodEnd;
                        cmd.Parameters.Add("@due", SqlDbType.Date).Value = periodStart;
                        cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                        cmd.Parameters["@amt"].Precision = 18;
                        cmd.Parameters["@amt"].Scale = 2;

                        billId = (int)cmd.ExecuteScalar();
                    }

                    for (int i = 0; i < tenants.Count; i++)
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO BillTenants (BillId, TenantId, Share)
                            VALUES (@bid, @tid, @share);", conn, tx))
                        {
                            cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenants[i].TenantId;
                            cmd.Parameters.Add("@share", SqlDbType.Decimal).Value = shares[i];
                            cmd.Parameters["@share"].Precision = 18;
                            cmd.Parameters["@share"].Scale = 2;

                            cmd.ExecuteNonQuery();
                        }

                        // A tenant paying ahead should not be listed as owing
                        // the moment the bill appears. Pull their held credit
                        // onto this bill straight away.
                        ConsumeCredit(conn, tx, tenants[i].TenantId, billId, shares[i]);
                    }

                    tx.Commit();
                    return true;
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                {
                    // Another session generated this same bill between our
                    // check and our insert. Not an error - the bill exists.
                    try { tx.Rollback(); }
                    catch (Exception rollbackEx) { Debug.WriteLine(rollbackEx); }

                    Debug.WriteLine($"BillGenerator: bill already exists for room {room.RoomNumber} {periodStart:d}.");
                    return false;
                }
                catch
                {
                    try { tx.Rollback(); }
                    catch (Exception rollbackEx) { Debug.WriteLine(rollbackEx); }

                    throw;
                }
            }
        }

        private static List<ActiveTenant> LoadActiveTenants(
            SqlConnection conn, int roomId, DateTime periodStart)
        {
            var list = new List<ActiveTenant>();

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT tn.TenantId, tn.MoveInDate
                FROM   Tenancies tn
                WHERE  tn.RoomId = @rid
                  AND  tn.Status = 'Active'
                  AND  tn.MoveInDate <= @start
                ORDER BY tn.MoveInDate ASC, tn.TenantId ASC;", conn))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                cmd.Parameters.Add("@start", SqlDbType.Date).Value = periodStart;

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new ActiveTenant
                        {
                            TenantId = r.GetInt32(0),
                            MoveInDate = r.GetDateTime(1)
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Splits an amount into equal shares that add back to exactly the
        /// amount.
        ///
        /// 5000 / 3 = 1666.666...  Rounding every share to 1666.67 overshoots
        /// by a centavo; rounding down to 1666.66 leaves the bill a centavo
        /// short forever and it can never reach paid. So every share is the
        /// floor, and the leftover centavos go to the first tenant - the
        /// longest-tenured, which is stable and defensible.
        ///
        ///     5000 / 3  ->  1666.68, 1666.66, 1666.66   (sums to 5000.00)
        /// </summary>
        private static decimal[] SplitEqually(decimal amount, int count)
        {
            decimal baseShare = Math.Floor(amount / count * 100m) / 100m;
            decimal remainder = amount - (baseShare * count);

            var shares = new decimal[count];
            for (int i = 0; i < count; i++) shares[i] = baseShare;

            shares[0] += remainder;
            return shares;
        }

        /// <summary>
        /// Moves a tenant's held credit onto a newly created bill.
        ///
        /// Credit lives as PaymentAllocations rows with BillId NULL. Each row
        /// still points at the payment it came from, so consuming it must
        /// preserve that link rather than delete and re-create:
        ///
        ///   credit row fits inside the share  -> repoint the row at the bill
        ///   credit row is larger              -> split it, leaving the rest
        ///
        /// Oldest credit is used first.
        ///
        /// FORFEITED CREDIT IS NOT SPENT. A forfeit at move out is recorded
        /// as a TenantAdjustments row; the credit rows it cancelled are left
        /// in place as history. Without the skip below, a tenant who forfeits
        /// credit, leaves, and is later reactivated would have that forfeited
        /// money quietly applied to their new bill. Credit held at the time
        /// of a move out is the oldest credit, so the oldest pesos - up to
        /// the forfeited total - are treated as gone and passed over.
        /// </summary>
        private static void ConsumeCredit(
            SqlConnection conn, SqlTransaction tx, int tenantId, int billId, decimal share)
        {
            decimal remaining = share;

            decimal toSkip;
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT ISNULL(SUM(adj.Amount), 0)
                FROM   TenantAdjustments adj
                WHERE  adj.TenantId = @tid
                  AND  adj.AdjustmentType = 'Forfeit'
                  AND  adj.BillCategory = @cat;", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = RentCategory;
                toSkip = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            // Snapshot the credit rows first; we modify them as we go.
            var credits = new List<Tuple<int, int, decimal>>();   // AllocationId, PaymentId, Amount

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT a.AllocationId, a.PaymentId, a.Amount
                FROM   PaymentAllocations a
                JOIN   Payments p ON p.PaymentId = a.PaymentId
                WHERE  a.TenantId = @tid
                  AND  a.BillId IS NULL
                  AND  a.IsVoided = 0
                  AND  p.IsVoided = 0
                  AND  p.PaymentCategory = @cat
                ORDER BY a.AllocationId ASC;", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = RentCategory;

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        credits.Add(Tuple.Create(r.GetInt32(0), r.GetInt32(1), r.GetDecimal(2)));
                }
            }

            foreach (var credit in credits)
            {
                if (remaining <= 0m) break;

                int allocationId = credit.Item1;
                int paymentId = credit.Item2;
                decimal creditAmount = credit.Item3;

                // Pass over the forfeited part of this row, if any.
                decimal usable = creditAmount;
                if (toSkip > 0m)
                {
                    decimal skip = Math.Min(toSkip, usable);
                    usable -= skip;
                    toSkip -= skip;
                }
                if (usable <= 0m) continue;

                if (usable == creditAmount && creditAmount <= remaining)
                {
                    // Whole credit row goes to this bill.
                    using (SqlCommand cmd = new SqlCommand(@"
                        UPDATE PaymentAllocations
                           SET BillId = @bid
                         WHERE AllocationId = @aid;", conn, tx))
                    {
                        cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                        cmd.Parameters.Add("@aid", SqlDbType.Int).Value = allocationId;
                        cmd.ExecuteNonQuery();
                    }

                    remaining -= creditAmount;
                }
                else
                {
                    // Only part of it can be used - either the share needs
                    // less than the row holds, or part of the row is
                    // forfeited. Shrink the credit row and add a settled row
                    // for the piece that goes to this bill. Whatever stays
                    // behind keeps BillId NULL.
                    decimal used = Math.Min(usable, remaining);

                    using (SqlCommand cmd = new SqlCommand(@"
                        UPDATE PaymentAllocations
                           SET Amount = Amount - @used
                         WHERE AllocationId = @aid;", conn, tx))
                    {
                        cmd.Parameters.Add("@used", SqlDbType.Decimal).Value = used;
                        cmd.Parameters["@used"].Precision = 18;
                        cmd.Parameters["@used"].Scale = 2;
                        cmd.Parameters.Add("@aid", SqlDbType.Int).Value = allocationId;
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO PaymentAllocations (PaymentId, BillId, TenantId, Amount)
                        VALUES (@pid, @bid, @tid, @amt);", conn, tx))
                    {
                        cmd.Parameters.Add("@pid", SqlDbType.Int).Value = paymentId;
                        cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                        cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = used;
                        cmd.Parameters["@amt"].Precision = 18;
                        cmd.Parameters["@amt"].Scale = 2;
                        cmd.ExecuteNonQuery();
                    }

                    remaining -= used;
                }
            }
        }
    }

}
