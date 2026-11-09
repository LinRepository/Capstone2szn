using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{
    /* ======================================================================
       ROOM STATEMENT OF ACCOUNT (SOA)

       A statement answers one question for one billing period:
       "As of the statement date, how much does this room owe, and why?"

       It follows the standard statement formula:

           Previous balance
         + Current charges (Rent, Water, Maintenance due within the period)
         - Payments received during the period
         +/- Adjustments (write-off = less owed, forfeit = credit given up)
         = Amount due   (negative = credit / paid ahead)

       AS-OF RULE (Decision A): a statement is computed, never stored. It
       only counts what existed on its Statement Date:
         - bills generated on or before that date,
         - payments dated on or before that date,
         - a payment voided AFTER that date still counts (it was valid then).
       So reprinting an old statement always shows the same figures the
       tenant originally received.

       Statement Date = the period's last day for a past period, or today
       for the current / upcoming period.

       Statement No. = SOA-<room>-<period start>, e.g. SOA-202-20261015.
       It is derived, not stored, so the same period always gets the same
       number.

       Electricity is excluded: tenants pay AKELCO directly.
       ====================================================================== */

    /// <summary>One rent billing period of a room.</summary>
    public sealed class StatementPeriod
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }       // stored end = next period's start (exclusive)
        public DateTime DueDate { get; set; }
        public DateTime LastDay => End.AddDays(-1);

        // NEW (All periods): a statement covering every listed period at once.
        public bool IsAll { get; set; }
        public List<StatementPeriod> Parts { get; set; } = new List<StatementPeriod>();   // oldest first
    }

    /// <summary>NEW (All periods): one row of the PERIOD BREAKDOWN table.</summary>
    public sealed class StatementPeriodRow
    {
        public DateTime Start { get; set; }
        public DateTime LastDay { get; set; }
        public decimal Rent { get; set; }
        public decimal Water { get; set; }
        public decimal Maintenance { get; set; }
        public decimal Paid { get; set; }
        public decimal Adjustments { get; set; }
        public decimal Balance { get; set; }      // running balance at the end of this period
    }

    /// <summary>One tenant's line in the per-tenant breakdown.</summary>
    public sealed class StatementTenantLine
    {
        public string TenantName { get; set; } = "";
        public decimal PreviousBalance { get; set; }
        public decimal Rent { get; set; }
        public decimal Water { get; set; }
        public decimal Maintenance { get; set; }
        public decimal Payments { get; set; }
        public decimal Adjustments { get; set; }

        /// <summary>
        /// NEW (Step 5, decision B): filled when the tenant no longer lived in
        /// the room on the statement date, e.g. "Transferred out on November 5, 2026".
        /// Empty for someone still living here.
        /// </summary>
        public string LeftNote { get; set; } = "";

        public decimal AmountDue =>
            PreviousBalance + Rent + Water + Maintenance - Payments + Adjustments;

        public bool IsEmpty =>
            PreviousBalance == 0m && Rent == 0m && Water == 0m && Maintenance == 0m &&
            Payments == 0m && Adjustments == 0m;
    }

    /// <summary>One payment received during the period (one receipt).</summary>
    public sealed class StatementPayment
    {
        public DateTime PaymentDate { get; set; }
        public string ReceiptNo { get; set; } = "";
        public string PaidBy { get; set; } = "";
        public string Method { get; set; } = "";
        public decimal Amount { get; set; }
    }

    /// <summary>Everything printed on one statement.</summary>
    public sealed class RoomStatement
    {
        public string BuildingName { get; set; } = "";
        public string RoomNumber { get; set; } = "";
        public string RoomType { get; set; } = "";
        public StatementPeriod Period { get; set; } = new StatementPeriod();
        public DateTime AsOf { get; set; }
        public bool IsCurrent { get; set; }     // today is inside (or before) this period

        public List<StatementTenantLine> Tenants { get; } = new List<StatementTenantLine>();
        public List<StatementPayment> Payments { get; } = new List<StatementPayment>();

        // NEW (statement shows the people living here): tenants left out
        // because they no longer lived in the room on the statement date.
        // NEW (Step 5, decision B): now only tenants who did not live here at
        // all during the statement, but still had activity on it (rare).
        public List<string> ExcludedNames { get; } = new List<string>();

        // NEW (All periods)
        public List<StatementPeriodRow> PeriodRows { get; } = new List<StatementPeriodRow>();
        public bool IsAll => Period.IsAll;

        // ORIGINAL: public string StatementNo => "SOA-" + RoomNumber + "-" + Period.Start.ToString("yyyyMMdd");
        public string StatementNo => IsAll
            ? "SOA-" + RoomNumber + "-ALL-" + AsOf.ToString("yyyyMMdd")                       // NEW
            : "SOA-" + RoomNumber + "-" + Period.Start.ToString("yyyyMMdd");

        // Room totals = the sum of the tenant lines, so the summary and the
        // breakdown can never disagree.
        public decimal TotalPrevious => Tenants.Sum(t => t.PreviousBalance);
        public decimal TotalRent => Tenants.Sum(t => t.Rent);
        public decimal TotalWater => Tenants.Sum(t => t.Water);
        public decimal TotalMaintenance => Tenants.Sum(t => t.Maintenance);
        public decimal TotalPayments => Tenants.Sum(t => t.Payments);
        public decimal TotalAdjustments => Tenants.Sum(t => t.Adjustments);
        public decimal TotalDue => Tenants.Sum(t => t.AmountDue);
    }

    /* ======================================================================
       DATA: reads the statement from the database
       ====================================================================== */

    public static class RoomStatementService
    {
        /// <summary>
        /// NEW (statement shows the people living here): a tenant counts when
        /// they had a stay in THIS room on the statement date (@Dnext = the day
        /// after it). Someone who moved out or transferred out before or on
        /// that date is left out; an October statement still shows whoever
        /// lived there in October.
        /// </summary>
        private static string Occupant(string tenantColumn) =>
            "EXISTS (SELECT 1 FROM Tenancies o WHERE o.TenantId = " + tenantColumn +
            " AND o.RoomId = @rid AND o.MoveInDate < @Dnext" +
            " AND (o.MoveOutDate IS NULL OR o.MoveOutDate >= @Dnext))";

        /// <summary>
        /// NEW (Step 5, decision B): a tenant counts when they had a stay in
        /// THIS room at any time from the statement's first day (@L) to the
        /// statement date (@Dnext = the day after it).
        ///
        ///   Nov 1 - Nov 30 statement, Levi transferred out Nov 5  -> listed
        ///   Nov 1 - Nov 30 statement, Eren moved out Oct 20       -> not listed
        ///
        /// Occupant() above is still used to tell who has LEFT, for the note.
        /// </summary>
        private static string Lived(string tenantColumn) =>
            "EXISTS (SELECT 1 FROM Tenancies lv WHERE lv.TenantId = " + tenantColumn +
            " AND lv.RoomId = @rid AND lv.MoveInDate < @Dnext" +
            " AND (lv.MoveOutDate IS NULL OR lv.MoveOutDate >= @L))";

        /// <summary>
        /// The room's rent periods, newest first. A period appears once its
        /// rent bill exists (generated 7 days before the due date); test bills
        /// further in the future are ignored.
        /// </summary>
        public static List<StatementPeriod> GetPeriods(int roomId)
        {
            // NEW (Step 5): the room's periods come from its Regular AND Closed
            // rent bills. A Regular bill turns Closed when every share on it
            // moved away (a transfer), but its period still happened, so it
            // keeps its statement. See GetPeriodsWithClosed below.
            return GetPeriodsWithClosed(roomId);
        }

        /// <summary>ORIGINAL GetPeriods body, kept as is (no longer called).</summary>
        private static List<StatementPeriod> GetPeriodsRegularOnly(int roomId)
        {
            var list = new List<StatementPeriod>();

            const string sql = @"
                SELECT BillingPeriodStart, BillingPeriodEnd, DueDate
                FROM   Bills
                WHERE  RoomId = @rid
                  AND  BillCategory = 'Rent'
                  AND  BillingPeriodStart <= DATEADD(DAY, 7, CAST(GETDATE() AS DATE))
                  -- NEW: a transfer's price-difference bill is a charge, not a billing period
                  -- ORIGINAL: AND  (Remarks IS NULL OR Remarks NOT LIKE N'Price difference%')
                  AND  BillKind = N'Regular'   -- NEW (BillKind)
                ORDER BY BillingPeriodStart DESC;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                conn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new StatementPeriod
                        {
                            Start = rd.GetDateTime(0),
                            End = rd.GetDateTime(1),
                            DueDate = rd.GetDateTime(2)
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// NEW (Step 5): the room's rent periods, newest first, from its
        /// Regular and Closed rent bills.
        ///
        /// Three rules keep the list clean:
        ///   1. A TransferGap / JoinerShare bill is never a period. If one
        ///      turned Closed, it is skipped: it ends on the same day as its
        ///      period's main bill but starts later (the NOT EXISTS below).
        ///   2. One period per start date (a Regular bill wins over a Closed one).
        ///   3. When a new cycle starts inside an older period (the room was
        ///      emptied, then someone moved in on a new date), the older period
        ///      is cut short so the two never overlap:
        ///         Nov 1 - Nov 30 (Closed) + new cycle Nov 8 - Dec 7
        ///         -> Nov 1 - Nov 7  and  Nov 8 - Dec 7
        /// </summary>
        private static List<StatementPeriod> GetPeriodsWithClosed(int roomId)
        {
            var list = new List<StatementPeriod>();

            const string sql = @"
                SELECT b.BillingPeriodStart, b.BillingPeriodEnd, b.DueDate
                FROM   Bills b
                WHERE  b.RoomId = @rid
                  AND  b.BillCategory = 'Rent'
                  AND  b.BillingPeriodStart <= DATEADD(DAY, 7, CAST(GETDATE() AS DATE))
                  AND  b.BillKind IN (N'Regular', N'Closed')
                  -- rule 1: a closed transfer/joiner bill is not a period
                  AND  NOT EXISTS (SELECT 1 FROM Bills m
                                   WHERE  m.RoomId = b.RoomId
                                     AND  m.BillCategory = 'Rent'
                                     AND  m.BillKind IN (N'Regular', N'Closed')
                                     AND  m.BillingPeriodEnd = b.BillingPeriodEnd
                                     AND  m.BillingPeriodStart < b.BillingPeriodStart)
                ORDER BY b.BillingPeriodStart DESC,
                         CASE WHEN b.BillKind = N'Regular' THEN 0 ELSE 1 END;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                conn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        DateTime start = rd.GetDateTime(0);
                        DateTime end = rd.GetDateTime(1);

                        // rule 2: same start as the one just added -> skip
                        if (list.Count > 0 && list[list.Count - 1].Start == start) continue;

                        // rule 3: the newer period (added just before) starts
                        // before this one ends -> this one ends there
                        if (list.Count > 0 && list[list.Count - 1].Start < end)
                            end = list[list.Count - 1].Start;

                        list.Add(new StatementPeriod
                        {
                            Start = start,
                            End = end,
                            DueDate = rd.GetDateTime(2)
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>Builds the statement for one room and one period.</summary>
        public static RoomStatement Load(int roomId, StatementPeriod period)
        {
            DateTime today = DateTime.Today;

            var st = new RoomStatement
            {
                Period = period,
                // Past period -> its last day; current/upcoming -> today.
                AsOf = period.LastDay < today ? period.LastDay : today,
                IsCurrent = today < period.End
            };

            DateTime dayAfterAsOf = st.AsOf.AddDays(1);   // "on or before AsOf" = "< the next day"

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // ---- 1. Header ------------------------------------------------
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT r.RoomNumber, r.RoomType, b.BuildingName
                    FROM   Rooms r
                    JOIN   Buildings b ON b.BuildingId = r.BuildingId
                    WHERE  r.RoomId = @rid;", conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            st.RoomNumber = Convert.ToString(rd.GetValue(0)) ?? "";   // text or INT
                            st.RoomType = rd.IsDBNull(1) ? "" : rd.GetString(1);
                            st.BuildingName = rd.GetString(2);
                        }
                    }
                }

                // ---- 2. Per-tenant ledger -------------------------------------
                //  charges : shares of this room's bills, split into
                //            "due before the period" (previous) and
                //            "due within the period" (current, per category).
                //            Bills due after the period belong to the next
                //            statement and are left out.
                //  paid    : this room's payment lines (incl. advance credit),
                //            split into "before the period" and "during it".
                //            Money paid ahead for a later bill still counts
                //            as received - that is what makes a credit.
                //  adjs    : move-out write-offs (less owed) and forfeits
                //            (credit given up) for stays in this room.
                // ORIGINAL: const string ledgerSql = @"   (NEW: + the IsOccupant column at the end)
                string ledgerSql = @"
                    WITH charges AS (
                        SELECT bt.TenantId,
                               SUM(CASE WHEN b.DueDate < @S THEN bt.Share ELSE 0 END) AS PrevCharges,
                               SUM(CASE WHEN b.DueDate >= @S AND b.BillCategory = 'Rent'
                                        THEN bt.Share ELSE 0 END) AS Rent,
                               SUM(CASE WHEN b.DueDate >= @S AND b.BillCategory = 'Water'
                                        THEN bt.Share ELSE 0 END) AS Water,
                               SUM(CASE WHEN b.DueDate >= @S AND b.BillCategory = 'Maintenance'
                                        THEN bt.Share ELSE 0 END) AS Maint
                        FROM   BillTenants bt
                        JOIN   Bills b ON b.BillId = bt.BillId
                        WHERE  b.RoomId = @rid
                          AND  b.BillCategory IN ('Rent', 'Water', 'Maintenance')
                          AND  b.DueDate < @E
                          AND  ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext
                        GROUP BY bt.TenantId
                    ),
                    paid AS (
                        SELECT a.TenantId,
                               SUM(CASE WHEN p.PaymentDate <  @S THEN a.Amount ELSE 0 END) AS PrevPaid,
                               SUM(CASE WHEN p.PaymentDate >= @S THEN a.Amount ELSE 0 END) AS PaidInPeriod
                        FROM   PaymentAllocations a
                        JOIN   Payments p ON p.PaymentId = a.PaymentId
                        LEFT JOIN Bills b ON b.BillId = a.BillId
                        WHERE  p.PaymentDate < @Dnext
                          AND  (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)
                          AND  (b.RoomId = @rid OR (a.BillId IS NULL AND p.RoomId = @rid))
                        GROUP BY a.TenantId
                    ),
                    adjs AS (
                        SELECT ta.TenantId,
                               SUM(CASE WHEN ta.AdjustmentDate <  @S THEN x.Signed ELSE 0 END) AS PrevAdj,
                               SUM(CASE WHEN ta.AdjustmentDate >= @S THEN x.Signed ELSE 0 END) AS AdjInPeriod
                        FROM   TenantAdjustments ta
                        JOIN   Tenancies tn ON tn.TenancyId = ta.TenancyId
                        CROSS APPLY (SELECT CASE WHEN ta.AdjustmentType = 'WriteOff'
                                                 THEN -ta.Amount ELSE ta.Amount END AS Signed) x
                        WHERE  tn.RoomId = @rid
                          AND  ta.AdjustmentDate < @Dnext
                        GROUP BY ta.TenantId
                    ),
                    ids AS (
                        SELECT TenantId FROM charges
                        UNION SELECT TenantId FROM paid
                        UNION SELECT TenantId FROM adjs
                        -- NEW (Step 5, decision B): everyone who lived here during the
                        -- statement, even with nothing on it (a share that moved away on
                        -- a transfer, or a joiner not billed yet)
                        UNION SELECT lv.TenantId FROM Tenancies lv
                              WHERE  lv.RoomId = @rid AND lv.MoveInDate < @Dnext
                                AND  (lv.MoveOutDate IS NULL OR lv.MoveOutDate >= @L)
                    )
                    SELECT te.FirstName
                         + ISNULL(' ' + LEFT(NULLIF(LTRIM(te.MiddleName), N''), 1) + '.', '')
                         + ' ' + te.LastName AS TenantName,
                           ISNULL(c.PrevCharges, 0) - ISNULL(pd.PrevPaid, 0) + ISNULL(ad.PrevAdj, 0) AS PreviousBalance,
                           ISNULL(c.Rent, 0)          AS Rent,
                           ISNULL(c.Water, 0)         AS Water,
                           ISNULL(c.Maint, 0)         AS Maintenance,
                           ISNULL(pd.PaidInPeriod, 0) AS Payments,
                           ISNULL(ad.AdjInPeriod, 0)  AS Adjustments,
                           CASE WHEN " + Occupant("ids.TenantId") + @" THEN 1 ELSE 0 END AS IsOccupant,
                           -- NEW (Step 5, decision B): lived here during the statement,
                           -- and for someone who left, their last move-out from this room
                           CASE WHEN " + Lived("ids.TenantId") + @" THEN 1 ELSE 0 END AS IsLived,
                           lo.MoveOutDate,
                           lo.MoveOutReason
                    FROM   ids
                    JOIN   Tenants te     ON te.TenantId = ids.TenantId
                    LEFT JOIN charges c   ON c.TenantId  = ids.TenantId
                    LEFT JOIN paid pd     ON pd.TenantId = ids.TenantId
                    LEFT JOIN adjs ad     ON ad.TenantId = ids.TenantId
                    OUTER APPLY (SELECT TOP 1 o.MoveOutDate, o.MoveOutReason
                                 FROM   Tenancies o
                                 WHERE  o.TenantId = ids.TenantId
                                   AND  o.RoomId = @rid
                                   AND  o.MoveOutDate IS NOT NULL
                                   AND  o.MoveOutDate < @Dnext
                                 ORDER BY o.MoveOutDate DESC, o.TenancyId DESC) lo   -- NEW (Step 5)
                    -- ORIGINAL: ORDER BY te.LastName, te.FirstName;
                    -- NEW (Step 5): people living here first, then those who left
                    ORDER BY IsOccupant DESC, te.LastName, te.FirstName;";

                using (SqlCommand cmd = new SqlCommand(ledgerSql, conn))
                {
                    AddPeriodParameters(cmd, roomId, period, dayAfterAsOf);
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var line = new StatementTenantLine
                            {
                                TenantName = rd.GetString(0),
                                PreviousBalance = rd.GetDecimal(1),
                                Rent = rd.GetDecimal(2),
                                Water = rd.GetDecimal(3),
                                Maintenance = rd.GetDecimal(4),
                                Payments = rd.GetDecimal(5),
                                Adjustments = rd.GetDecimal(6)
                            };

                            // ORIGINAL: // A former tenant whose account was already settled
                            // ORIGINAL: // before this period adds nothing to it.
                            // ORIGINAL: if (!line.IsEmpty) st.Tenants.Add(line);

                            // NEW: only the people living here on the statement date;
                            // anyone else with activity is named in the notes instead.
                            // ORIGINAL (NEW earlier): if (rd.GetInt32(7) == 1) st.Tenants.Add(line);
                            // ORIGINAL (NEW earlier): else if (!line.IsEmpty) st.ExcludedNames.Add(line.TenantName);

                            // NEW (Step 5, decision B): everyone who lived here during
                            // the statement is listed. Someone who has left gets a note
                            // under their line saying when and how they left.
                            bool isOccupant = rd.GetInt32(7) == 1;
                            bool isLived = rd.GetInt32(8) == 1;

                            if (isLived)
                            {
                                if (!isOccupant && !rd.IsDBNull(9))
                                {
                                    string how = !rd.IsDBNull(10) && rd.GetString(10) == "Transferred"
                                        ? "Transferred out"
                                        : "Moved out";
                                    line.LeftNote = how + " on " + rd.GetDateTime(9).ToString("MMMM d, yyyy");
                                }
                                st.Tenants.Add(line);
                            }
                            else if (!line.IsEmpty)
                            {
                                st.ExcludedNames.Add(line.TenantName);
                            }
                        }
                    }
                }

                // ---- 3. Payments received during the period -------------------
                //  Same filters as "paid" above, grouped per receipt, so this
                //  list always adds up to the Payments total.
                // ORIGINAL: const string paySql = @"   (NEW: only payments for the people living here)
                string paySql = @"
                    SELECT p.PaymentDate, p.ReceiptNo,
                           te.FirstName
                         + ISNULL(' ' + LEFT(NULLIF(LTRIM(te.MiddleName), N''), 1) + '.', '')
                         + ' ' + te.LastName AS PaidBy,
                           p.PaymentMethod, SUM(a.Amount) AS Amount
                    FROM   Payments p
                    JOIN   PaymentAllocations a ON a.PaymentId = p.PaymentId
                    LEFT JOIN Bills b ON b.BillId = a.BillId
                    JOIN   Tenants te ON te.TenantId = p.TenantId
                    WHERE  p.PaymentDate >= @S
                      AND  p.PaymentDate <  @Dnext
                      AND  (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)
                      AND  (b.RoomId = @rid OR (a.BillId IS NULL AND p.RoomId = @rid))
                      AND  " + Lived("a.TenantId") + @"   -- NEW (Step 5, decision B); ORIGINAL used Occupant(""a.TenantId"")
                    GROUP BY p.PaymentId, p.PaymentDate, p.ReceiptNo,
                             te.FirstName, te.MiddleName, te.LastName, p.PaymentMethod
                    ORDER BY p.PaymentDate, p.PaymentId;";

                using (SqlCommand cmd = new SqlCommand(paySql, conn))
                {
                    AddPeriodParameters(cmd, roomId, period, dayAfterAsOf);
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            st.Payments.Add(new StatementPayment
                            {
                                PaymentDate = rd.GetDateTime(0),
                                ReceiptNo = rd.GetString(1),
                                PaidBy = rd.GetString(2),
                                Method = rd.GetString(3),
                                Amount = rd.GetDecimal(4)
                            });
                        }
                    }
                }

                // ---- 4. NEW (All periods): one row per period -----------------
                if (period.IsAll)
                    LoadPeriodRows(conn, roomId, st, dayAfterAsOf);
            }

            return st;
        }

        /// <summary>
        /// NEW (All periods): totals per period for the people living here.
        /// NEW (Step 5, decision B): "living here" = lived in the room at any
        /// time during the whole statement (Lived, @L = the first period's
        /// start), the same people as the PER-TENANT BREAKDOWN.
        /// The windows run back to back (each ends where the next starts), so
        /// the rows always add up to the summary, and the last row's running
        /// balance equals the TOTAL AMOUNT DUE.
        /// </summary>
        private static void LoadPeriodRows(SqlConnection conn, int roomId, RoomStatement st, DateTime dayAfterAsOf)
        {
            string sql = @"
                SELECT
                  ISNULL((SELECT SUM(bt.Share) FROM BillTenants bt JOIN Bills b ON b.BillId = bt.BillId
                          WHERE b.RoomId = @rid AND b.BillCategory = 'Rent'
                            AND b.DueDate >= @S AND b.DueDate < @E
                            AND ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext
                            AND " + Lived("bt.TenantId") + @"), 0),   -- NEW (Step 5): was Occupant
                  ISNULL((SELECT SUM(bt.Share) FROM BillTenants bt JOIN Bills b ON b.BillId = bt.BillId
                          WHERE b.RoomId = @rid AND b.BillCategory = 'Water'
                            AND b.DueDate >= @S AND b.DueDate < @E
                            AND ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext
                            AND " + Lived("bt.TenantId") + @"), 0),   -- NEW (Step 5): was Occupant
                  ISNULL((SELECT SUM(bt.Share) FROM BillTenants bt JOIN Bills b ON b.BillId = bt.BillId
                          WHERE b.RoomId = @rid AND b.BillCategory = 'Maintenance'
                            AND b.DueDate >= @S AND b.DueDate < @E
                            AND ISNULL(b.GeneratedDate, b.BillingPeriodStart) < @Dnext
                            AND " + Lived("bt.TenantId") + @"), 0),   -- NEW (Step 5): was Occupant
                  ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                          JOIN Payments p ON p.PaymentId = a.PaymentId
                          LEFT JOIN Bills b ON b.BillId = a.BillId
                          WHERE p.PaymentDate >= @S AND p.PaymentDate < @E AND p.PaymentDate < @Dnext
                            AND (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)
                            AND (b.RoomId = @rid OR (a.BillId IS NULL AND p.RoomId = @rid))
                            AND " + Lived("a.TenantId") + @"), 0),   -- NEW (Step 5): was Occupant
                  ISNULL((SELECT SUM(CASE WHEN ta.AdjustmentType = 'WriteOff' THEN -ta.Amount ELSE ta.Amount END)
                          FROM TenantAdjustments ta JOIN Tenancies tn ON tn.TenancyId = ta.TenancyId
                          WHERE tn.RoomId = @rid
                            AND ta.AdjustmentDate >= @S AND ta.AdjustmentDate < @E AND ta.AdjustmentDate < @Dnext
                            AND " + Lived("ta.TenantId") + @"), 0);   -- NEW (Step 5): was Occupant";

            List<StatementPeriod> parts = st.Period.Parts;
            decimal running = st.TotalPrevious;

            for (int i = 0; i < parts.Count; i++)
            {
                DateTime s = i == 0 ? st.Period.Start : parts[i].Start;
                DateTime e = i + 1 < parts.Count ? parts[i + 1].Start : st.Period.End;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                    cmd.Parameters.Add("@S", SqlDbType.Date).Value = s;
                    cmd.Parameters.Add("@E", SqlDbType.Date).Value = e;
                    cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dayAfterAsOf;
                    cmd.Parameters.Add("@L", SqlDbType.Date).Value = st.Period.Start;   // NEW (Step 5)

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        var row = new StatementPeriodRow
                        {
                            Start = parts[i].Start,
                            LastDay = parts[i].LastDay,
                            Rent = rd.GetDecimal(0),
                            Water = rd.GetDecimal(1),
                            Maintenance = rd.GetDecimal(2),
                            Paid = rd.GetDecimal(3),
                            Adjustments = rd.GetDecimal(4)
                        };
                        running += row.Rent + row.Water + row.Maintenance - row.Paid + row.Adjustments;
                        row.Balance = running;
                        st.PeriodRows.Add(row);
                    }
                }
            }
        }

        /// <summary>
        /// NEW (All periods): one statement period spanning every listed one
        /// up to the current period (upcoming bills not due yet are left out,
        /// so the total equals the current statement's total).
        /// </summary>
        public static StatementPeriod AllPeriods(List<StatementPeriod> periods)
        {
            DateTime today = DateTime.Today;
            List<StatementPeriod> parts = periods.Where(p => p.Start <= today).OrderBy(p => p.Start).ToList();
            if (parts.Count == 0) parts = periods.OrderBy(p => p.Start).ToList();

            StatementPeriod current = parts.LastOrDefault(p => p.Start <= today && today < p.End) ?? parts.Last();

            return new StatementPeriod
            {
                IsAll = true,
                Start = parts.First().Start,
                End = parts.Last().End,
                DueDate = current.DueDate,
                Parts = parts
            };
        }

        private static void AddPeriodParameters(SqlCommand cmd, int roomId,
            StatementPeriod period, DateTime dayAfterAsOf)
        {
            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
            cmd.Parameters.Add("@S", SqlDbType.Date).Value = period.Start;
            cmd.Parameters.Add("@E", SqlDbType.Date).Value = period.End;
            cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dayAfterAsOf;
            cmd.Parameters.Add("@L", SqlDbType.Date).Value = period.Start;   // NEW (Step 5): first day for Lived()
        }
    }

    /* ======================================================================
       PRINTING: draws the statement on A4 and opens the preview.
       (Originally one page; NEW: a long statement continues on more pages.)
       The preview window has its own Print button; choosing
       "Microsoft Print to PDF" there saves the statement as a PDF.
       ====================================================================== */

    public static class RoomStatementPrinter
    {
        public static void ShowPreview(IWin32Window owner, RoomStatement st)
        {
            using (var doc = new PrintDocument())
            using (var preview = new PrintPreviewDialog())
            {
                doc.DocumentName = st.StatementNo;
                // A4 in hundredths of an inch (8.27 x 11.69 in), half-inch margins.
                doc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                doc.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

                // ORIGINAL:
                // doc.PrintPage += (s, e) =>
                // {
                //     Draw(e.Graphics, e.MarginBounds, st);
                //     e.HasMorePages = false;   // one page per statement
                // };

                // NEW (All periods): the statement is a list of blocks (lines,
                // rows) printed top to bottom; when the page is full the rest
                // continues on the next page, so nothing is cut off. A table
                // that continues repeats its header row.
                using var fonts = new StatementFonts();
                List<Block> blocks = BuildBlocks(st, fonts);
                int page = 0, next = 0;

                doc.BeginPrint += (s, e) => { page = 0; next = 0; };   // printing again starts over
                doc.PrintPage += (s, e) =>
                {
                    page++;
                    Graphics g = e.Graphics;
                    Rectangle area = e.MarginBounds;
                    float x = area.Left, w = area.Width, y = area.Top;
                    float bottom = area.Bottom - fonts.Small.GetHeight(g) - 6;   // room for "Page n"

                    if (page > 1)
                    {
                        y = Line(g, st.StatementNo + "  (continued)", fonts.Small, x, y);
                        y = Rule(g, x, w, y);
                    }

                    int placed = 0;
                    while (next < blocks.Count)
                    {
                        Block b = blocks[next];
                        bool repeat = placed == 0 && page > 1 && b.RepeatHeader != null;
                        float h = b.Height(g) + (repeat ? b.RepeatHeader.Height(g) : 0f);

                        if (y + h > bottom && placed > 0) break;   // full: continue on the next page

                        if (repeat)
                        {
                            b.RepeatHeader.Paint(g, x, w, y);
                            y += b.RepeatHeader.Height(g);
                        }
                        b.Paint(g, x, w, y);
                        y += b.Height(g);
                        placed++;
                        next++;
                    }

                    using (var right = new StringFormat { Alignment = StringAlignment.Far })
                        g.DrawString("Page " + page, fonts.Small, Brushes.Black,
                            new RectangleF(x, area.Bottom - fonts.Small.GetHeight(g), w, fonts.Small.GetHeight(g) + 2), right);

                    e.HasMorePages = next < blocks.Count;
                };

                preview.Document = doc;
                preview.Text = "Statement of Account - Room " + st.RoomNumber;
                preview.Width = 900;
                preview.Height = 1000;
                preview.StartPosition = FormStartPosition.CenterScreen;
                preview.ShowDialog(owner);
            }
        }

        /* =================================================================
           NEW (All periods): page-splitting printer
           ================================================================= */

        /// <summary>The statement's fonts, made once per preview.</summary>
        private sealed class StatementFonts : IDisposable
        {
            public readonly Font Title = new Font("Segoe UI", 16f, FontStyle.Bold);
            public readonly Font Head = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            public readonly Font Body = new Font("Segoe UI", 9.5f);
            public readonly Font Bold = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            public readonly Font Small = new Font("Segoe UI", 8f);

            public void Dispose()
            {
                Title.Dispose(); Head.Dispose(); Body.Dispose(); Bold.Dispose(); Small.Dispose();
            }
        }

        /// <summary>One printable piece: its height, and how to draw it at (x, y).</summary>
        private sealed class Block
        {
            public Func<Graphics, float> Height = g => 0f;
            public Action<Graphics, float, float, float> Paint = (g, x, w, y) => { };
            public Block RepeatHeader;   // a table's header row, repeated at the top of a new page
        }

        private static Block TextLine(string text, Font f) => new Block
        {
            Height = g => f.GetHeight(g) + 3,
            Paint = (g, x, w, y) => Line(g, text, f, x, y)
        };

        private static Block Gap(float h) => new Block { Height = g => h };

        private static Block RuleBlock() => new Block
        {
            Height = g => 8,
            Paint = (g, x, w, y) => Rule(g, x, w, y)
        };

        private static Block AmountLine(string label, decimal value, Font f) => new Block
        {
            Height = g => f.GetHeight(g) + 3,
            Paint = (g, x, w, y) => Amount(g, label, value, f, x, w, y)
        };

        /// <summary>A table row. widths are shares of the page width (they add up to 1).</summary>
        private static Block TableRow(float[] shares, string[] cells, Font f, bool shaded, int firstRightCol = 1) => new Block
        {
            Height = g => f.GetHeight(g) + 6,
            Paint = (g, x, w, y) => Row(g, f, x, y, shares.Select(sh => sh * w).ToArray(), cells, shaded, firstRightCol)
        };

        private static float[] Shares(float first, int others)
        {
            var r = new float[others + 1];
            r[0] = first;
            for (int i = 1; i <= others; i++) r[i] = (1f - first) / others;
            return r;
        }

        /// <summary>
        /// NEW: the whole statement as blocks, in print order. Same content as
        /// the original one-page Draw(), plus the PERIOD BREAKDOWN for All
        /// periods and the note naming tenants who moved out.
        /// </summary>
        private static List<Block> BuildBlocks(RoomStatement st, StatementFonts f)
        {
            var b = new List<Block>();

            // ---- 1. Title ----
            b.Add(new Block
            {
                Height = g => f.Title.GetHeight(g) + 2,
                Paint = (g, x, w, y) => Centered(g, st.BuildingName, f.Title, x, w, y)
            });
            string title = st.IsAll ? "STATEMENT OF ACCOUNT - ALL PERIODS" : "STATEMENT OF ACCOUNT";
            b.Add(new Block
            {
                Height = g => f.Head.GetHeight(g) + 4,
                Paint = (g, x, w, y) => Centered(g, title, f.Head, x, w, y + 2)
            });
            b.Add(Gap(6));
            b.Add(RuleBlock());

            // ---- 2. Statement details (left) and period (right) ----
            string periodText = (st.IsAll ? "All: " : "") +
                                st.Period.Start.ToString("MMM d, yyyy") + " - " + st.Period.LastDay.ToString("MMM d, yyyy");
            b.Add(new Block
            {
                Height = g => 3 * (f.Body.GetHeight(g) + 3) + 4,
                Paint = (g, x, w, y) =>
                {
                    float half = w / 2f, yl = y, yr = y;
                    yl = Pair(g, "Statement No.:", st.StatementNo, f.Body, f.Bold, x, yl);
                    yl = Pair(g, "Statement Date:", st.AsOf.ToString("MMMM d, yyyy"), f.Body, f.Bold, x, yl);
                    Pair(g, "Room:", st.RoomNumber + (st.RoomType.Length > 0 ? "  (" + st.RoomType + ")" : ""),
                         f.Body, f.Bold, x, yl);
                    yr = Pair(g, "Billing Period:", periodText, f.Body, f.Bold, x + half, yr);
                    Pair(g, "Due Date:", st.Period.DueDate.ToString("MMMM d, yyyy"), f.Body, f.Bold, x + half, yr);
                }
            });
            b.Add(RuleBlock());

            // ---- 3. Account summary (whole room) ----
            b.Add(TextLine(st.IsAll ? "ACCOUNT SUMMARY (WHOLE ROOM, ALL PERIODS)" : "ACCOUNT SUMMARY (WHOLE ROOM)", f.Head));
            if (!st.IsAll || st.TotalPrevious != 0m)
                b.Add(AmountLine("Previous balance", st.TotalPrevious, f.Body));
            b.Add(AmountLine("Add:  Rent", st.TotalRent, f.Body));
            b.Add(AmountLine("Add:  Water", st.TotalWater, f.Body));
            b.Add(AmountLine("Add:  Maintenance", st.TotalMaintenance, f.Body));
            b.Add(AmountLine("Less: Payments received", -st.TotalPayments, f.Body));
            if (st.TotalAdjustments != 0m)
                b.Add(AmountLine("Adjustments (write-off / forfeit)", st.TotalAdjustments, f.Body));
            decimal due = st.TotalDue;
            b.Add(new Block
            {
                Height = g => f.Head.GetHeight(g) + 5,
                Paint = (g, x, w, y) =>
                {
                    g.DrawLine(Pens.Black, x + w - 200, y, x + w, y);
                    Amount(g, due >= 0m ? "TOTAL AMOUNT DUE" : "CREDIT BALANCE (paid ahead)", Math.Abs(due), f.Head, x, w, y + 2);
                }
            });
            b.Add(Gap(12));

            // ---- 4. NEW: period breakdown (All periods only) ----
            if (st.IsAll && st.PeriodRows.Count > 0)
            {
                float[] ps = Shares(0.28f, 6);
                b.Add(TextLine("PERIOD BREAKDOWN", f.Head));
                Block head = TableRow(ps, new[] { "Period", "Rent", "Water", "Maint.", "Paid", "Adjust.", "Balance" }, f.Bold, true);
                b.Add(head);
                foreach (StatementPeriodRow r in st.PeriodRows)
                {
                    Block row = TableRow(ps, new[] { r.Start.ToString("MMM d") + " - " + r.LastDay.ToString("MMM d, yyyy"),
                        Money(r.Rent), Money(r.Water), Money(r.Maintenance), Money(r.Paid), Money(r.Adjustments),
                        Money(r.Balance) }, f.Body, false);
                    row.RepeatHeader = head;
                    b.Add(row);
                }
                b.Add(Gap(12));
            }

            // ---- 5. Per-tenant breakdown ----
            b.Add(TextLine("PER-TENANT BREAKDOWN", f.Head));
            // ORIGINAL (NEW earlier): float[] ts = Shares(0.20f, 7);
            // NEW: "Amount Due" was cut off ("Amount..."), so the last column is wider.
            float[] ts = { 0.18f, 0.115f, 0.115f, 0.115f, 0.115f, 0.115f, 0.115f, 0.13f };   // adds up to 1
            Block tHead = TableRow(ts, new[] { "Tenant", "Prev. Bal.", "Rent", "Water", "Maint.",
                                               "Payments", "Adjust.", "Amount Due" }, f.Bold, true);
            b.Add(tHead);
            if (st.Tenants.Count == 0)
                // ORIGINAL (NEW earlier): b.Add(TextLine("No tenants living in this room on the statement date.", f.Body));
                // ORIGINAL (NEW earlier): b.Add(TextLine("No current tenants.", f.Body));
                b.Add(TextLine("No tenants during this period.", f.Body));   // NEW (Step 5, decision B)
            foreach (StatementTenantLine t in st.Tenants)
            {
                Block row = TableRow(ts, new[] { t.TenantName, Money(t.PreviousBalance), Money(t.Rent),
                        Money(t.Water), Money(t.Maintenance), Money(t.Payments),
                        Money(t.Adjustments), Money(t.AmountDue) }, f.Body, false);
                row.RepeatHeader = tHead;
                b.Add(row);

                // NEW (Step 5, decision B): a small line under someone who has
                // left, e.g. "Transferred out on November 5, 2026".
                if (t.LeftNote.Length > 0)
                    b.Add(TextLine("      " + t.LeftNote, f.Small));
            }
            b.Add(TableRow(ts, new[] { "Room total", Money(st.TotalPrevious), Money(st.TotalRent),
                    Money(st.TotalWater), Money(st.TotalMaintenance), Money(st.TotalPayments),
                    Money(st.TotalAdjustments), Money(st.TotalDue) }, f.Bold, true));
            b.Add(Gap(12));

            // ---- 6. Payments received (every one - no "+ n more" cut-off now) ----
            b.Add(TextLine(st.IsAll ? "PAYMENTS RECEIVED" : "PAYMENTS RECEIVED THIS PERIOD", f.Head));
            if (st.Payments.Count == 0)
            {
                b.Add(TextLine(st.IsAll ? "No payments received." : "No payments received during this period.", f.Body));
            }
            else
            {
                float[] pw = { 0.14f, 0.22f, 0.34f, 0.12f, 0.18f };
                Block pHead = TableRow(pw, new[] { "Date", "Receipt No.", "Paid by", "Method", "Amount" }, f.Bold, true, 4);
                b.Add(pHead);
                foreach (StatementPayment p in st.Payments)
                {
                    Block row = TableRow(pw, new[] { p.PaymentDate.ToString("MMM d, yyyy"), p.ReceiptNo,
                            p.PaidBy, p.Method, Money(p.Amount) }, f.Body, false, 4);
                    row.RepeatHeader = pHead;
                    b.Add(row);
                }
            }

            // ---- 7. Notes ----
            // NEW (printable footer): the statement goes to tenants, so the footer
            // only says what a customer needs - when and how to pay, what the
            // statement covers. Internal notes (who is not shown and where to
            // look) are left out; staff see that on the Tenants screen.
            // ORIGINAL: b.Add(Gap(8));
            // ORIGINAL: b.Add(RuleBlock());
            // ORIGINAL: b.Add(TextLine("Please pay the total amount due on or before " +
            // ORIGINAL: st.Period.DueDate.ToString("MMMM d, yyyy") + ". Payment: Cash at the office or GCash.", f.Small));
            // ORIGINAL: if (st.IsCurrent)
            // ORIGINAL: b.Add(TextLine("This statement includes transactions up to " + st.AsOf.ToString("MMMM d, yyyy") +
            // ORIGINAL: ". Payments made after this date are not shown.", f.Small));
            // ORIGINAL: if (st.IsCurrent && !st.IsAll && st.TotalWater == 0m)
            // ORIGINAL: b.Add(TextLine("Water for this period: to follow (not yet billed).", f.Small));
            // ORIGINAL: if (st.ExcludedNames.Count > 0)
            // ORIGINAL: b.Add(TextLine("Tenants who moved out are not shown (" + string.Join(", ", st.ExcludedNames) +
            // ORIGINAL: "). Their account is in Tenants / Payment History.", f.Small));
            // ORIGINAL: b.Add(TextLine("Electricity is paid directly to AKELCO and is not included.  " +
            // ORIGINAL: "Amounts in ( ) are credits.", f.Small));
            // ORIGINAL: b.Add(TextLine("Computer-generated statement. Printed " + DateTime.Now.ToString("MMM d, yyyy h:mm tt") + ".", f.Small));

            b.Add(Gap(8));
            b.Add(RuleBlock());

            // 1. What to do: pay, nothing due, or credit carried forward.
            if (due > 0m)
                b.Add(TextLine("Please pay the total amount due of " + Peso(due) + " on or before " +
                               st.Period.DueDate.ToString("MMMM d, yyyy") + ".", f.Small));
            else if (due < 0m)
                b.Add(TextLine("You have an advance credit of " + Peso(-due) +
                               ". It will be applied to your next bill.", f.Small));
            else if (st.Payments.Count > 0)
                b.Add(TextLine("No amount is due. Thank you for your payment.", f.Small));
            else
                b.Add(TextLine("No amount is due.", f.Small));

            // 2. How to pay.
            b.Add(TextLine("Payments are accepted in cash at the office or through GCash. " +
                           "Please keep your official receipt.", f.Small));

            // 3. What the statement covers.
            if (st.IsCurrent)
                b.Add(TextLine("This statement reflects transactions up to " + st.AsOf.ToString("MMMM d, yyyy") + ".", f.Small));
            if (st.IsCurrent && !st.IsAll && st.TotalWater == 0m)
                b.Add(TextLine("Water charges for this period will be billed separately.", f.Small));
            b.Add(TextLine("Electricity is billed directly by AKELCO and is not included in this statement. " +
                           "Amounts in ( ) are credits.", f.Small));

            // 4. Validity.
            b.Add(TextLine("This is a computer-generated statement and does not require a signature. " +
                           "Printed " + DateTime.Now.ToString("MMM d, yyyy h:mm tt") + ".", f.Small));

            return b;
        }

        // NOTE (All periods): no longer called - the one-page version, kept as is.
        // BuildBlocks above prints the same content and continues on more pages.
        private static void Draw(Graphics g, Rectangle area, RoomStatement st)
        {
            using var titleFont = new Font("Segoe UI", 16f, FontStyle.Bold);
            using var headFont = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            using var bodyFont = new Font("Segoe UI", 9.5f);
            using var boldFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            using var smallFont = new Font("Segoe UI", 8f);

            float x = area.Left, w = area.Width, y = area.Top;

            // ---- 1. Title ------------------------------------------------------
            y = Centered(g, st.BuildingName, titleFont, x, w, y);
            y = Centered(g, "STATEMENT OF ACCOUNT", headFont, x, w, y + 2);
            y = Rule(g, x, w, y + 6);

            // ---- 2. Statement details (left) and period (right) ----------------
            float half = w / 2f;
            float yl = y, yr = y;
            yl = Pair(g, "Statement No.:", st.StatementNo, bodyFont, boldFont, x, yl);
            yl = Pair(g, "Statement Date:", st.AsOf.ToString("MMMM d, yyyy"), bodyFont, boldFont, x, yl);
            yl = Pair(g, "Room:", st.RoomNumber + (st.RoomType.Length > 0 ? "  (" + st.RoomType + ")" : ""),
                      bodyFont, boldFont, x, yl);
            yr = Pair(g, "Billing Period:", st.Period.Start.ToString("MMM d, yyyy") + " - " +
                      st.Period.LastDay.ToString("MMM d, yyyy"), bodyFont, boldFont, x + half, yr);
            yr = Pair(g, "Due Date:", st.Period.DueDate.ToString("MMMM d, yyyy"), bodyFont, boldFont, x + half, yr);
            y = Rule(g, x, w, Math.Max(yl, yr) + 4);

            // ---- 3. Account summary (whole room) -------------------------------
            y = Line(g, "ACCOUNT SUMMARY (WHOLE ROOM)", headFont, x, y);
            y = Amount(g, "Previous balance", st.TotalPrevious, bodyFont, x, w, y);
            y = Amount(g, "Add:  Rent", st.TotalRent, bodyFont, x, w, y);
            y = Amount(g, "Add:  Water", st.TotalWater, bodyFont, x, w, y);
            y = Amount(g, "Add:  Maintenance", st.TotalMaintenance, bodyFont, x, w, y);
            y = Amount(g, "Less: Payments received", -st.TotalPayments, bodyFont, x, w, y);
            if (st.TotalAdjustments != 0m)
                y = Amount(g, "Adjustments (write-off / forfeit)", st.TotalAdjustments, bodyFont, x, w, y);
            g.DrawLine(Pens.Black, x + w - 200, y, x + w, y);
            decimal due = st.TotalDue;
            y = Amount(g, due >= 0m ? "TOTAL AMOUNT DUE" : "CREDIT BALANCE (paid ahead)",
                       Math.Abs(due), headFont, x, w, y + 2);
            y += 12;

            // ---- 4. Per-tenant breakdown ---------------------------------------
            y = Line(g, "PER-TENANT BREAKDOWN", headFont, x, y);
            float[] tw = Widths(w, 0.20f, 7);
            y = Row(g, boldFont, x, y, tw, new[] { "Tenant", "Prev. Bal.", "Rent", "Water", "Maint.",
                                                   "Payments", "Adjust.", "Amount Due" }, true);
            foreach (StatementTenantLine t in st.Tenants)
            {
                y = Row(g, bodyFont, x, y, tw, new[] { t.TenantName, Money(t.PreviousBalance), Money(t.Rent),
                        Money(t.Water), Money(t.Maintenance), Money(t.Payments),
                        Money(t.Adjustments), Money(t.AmountDue) }, false);
            }
            y = Row(g, boldFont, x, y, tw, new[] { "Room total", Money(st.TotalPrevious), Money(st.TotalRent),
                    Money(st.TotalWater), Money(st.TotalMaintenance), Money(st.TotalPayments),
                    Money(st.TotalAdjustments), Money(st.TotalDue) }, true);
            y += 12;

            // ---- 5. Payments received this period ------------------------------
            y = Line(g, "PAYMENTS RECEIVED THIS PERIOD", headFont, x, y);
            float[] pw = { w * 0.14f, w * 0.22f, w * 0.34f, w * 0.12f, w * 0.18f };
            float notesTop = area.Bottom - 95;   // space kept free for the notes

            if (st.Payments.Count == 0)
            {
                y = Line(g, "No payments received during this period.", bodyFont, x, y);
            }
            else
            {
                y = Row(g, boldFont, x, y, pw, new[] { "Date", "Receipt No.", "Paid by", "Method", "Amount" }, true, 4);
                for (int i = 0; i < st.Payments.Count; i++)
                {
                    if (y + 22 > notesTop)
                    {
                        // One page only: the full list is in Payment History.
                        y = Line(g, "+ " + (st.Payments.Count - i) +
                                 " more payment(s). See Payment History for the full list.", smallFont, x, y);
                        break;
                    }
                    StatementPayment p = st.Payments[i];
                    y = Row(g, bodyFont, x, y, pw, new[] { p.PaymentDate.ToString("MMM d, yyyy"), p.ReceiptNo,
                            p.PaidBy, p.Method, Money(p.Amount) }, false, 4);
                }
            }

            // ---- 6. Notes --------------------------------------------------------
            y = Rule(g, x, w, Math.Max(y + 8, notesTop));
            y = Line(g, "Please pay the total amount due on or before " +
                     st.Period.DueDate.ToString("MMMM d, yyyy") + ". Payment: Cash at the office or GCash.",
                     smallFont, x, y);
            if (st.IsCurrent)
                y = Line(g, "This statement includes transactions up to " + st.AsOf.ToString("MMMM d, yyyy") +
                         ". Payments made after this date are not shown.", smallFont, x, y);
            if (st.IsCurrent && st.TotalWater == 0m)
                y = Line(g, "Water for this period: to follow (not yet billed).", smallFont, x, y);
            y = Line(g, "Electricity is paid directly to AKELCO and is not included.  " +
                     "Amounts in ( ) are credits.", smallFont, x, y);
            Line(g, "Computer-generated statement. Printed " + DateTime.Now.ToString("MMM d, yyyy h:mm tt") + ".",
                 smallFont, x, y);
        }

        /* ---- drawing helpers ---------------------------------------------------- */

        /// <summary>Negative amounts (credits) are shown in parentheses.</summary>
        // NEW (printable footer): "₱1,234.00"
        private static string Peso(decimal v) => "\u20B1" + v.ToString("N2");

        private static string Money(decimal v) => v < 0m ? "(" + (-v).ToString("N2") + ")" : v.ToString("N2");

        private static float Centered(Graphics g, string text, Font f, float x, float w, float y)
        {
            using var sf = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString(text, f, Brushes.Black, new RectangleF(x, y, w, f.GetHeight(g) + 2), sf);
            return y + f.GetHeight(g) + 2;
        }

        private static float Line(Graphics g, string text, Font f, float x, float y)
        {
            g.DrawString(text, f, Brushes.Black, x, y);
            return y + f.GetHeight(g) + 3;
        }

        private static float Rule(Graphics g, float x, float w, float y)
        {
            g.DrawLine(Pens.Black, x, y, x + w, y);
            return y + 8;
        }

        private static float Pair(Graphics g, string label, string value, Font lf, Font vf, float x, float y)
        {
            g.DrawString(label, lf, Brushes.Black, x, y);
            g.DrawString(value, vf, Brushes.Black, x + 110, y);
            return y + lf.GetHeight(g) + 3;
        }

        /// <summary>Label on the left, amount right-aligned.</summary>
        private static float Amount(Graphics g, string label, decimal value, Font f, float x, float w, float y)
        {
            using var right = new StringFormat { Alignment = StringAlignment.Far };
            g.DrawString(label, f, Brushes.Black, x + 10, y);
            g.DrawString("₱" + Money(value), f, Brushes.Black, new RectangleF(x + w - 200, y, 200, f.GetHeight(g) + 2), right);
            return y + f.GetHeight(g) + 3;
        }

        /// <summary>First column gets firstShare of the width; the rest share it equally.</summary>
        private static float[] Widths(float w, float firstShare, int others)
        {
            var result = new float[others + 1];
            result[0] = w * firstShare;
            for (int i = 1; i <= others; i++) result[i] = w * (1f - firstShare) / others;
            return result;
        }

        /// <summary>
        /// One table row. Columns from firstRightCol onwards are right-aligned (money).
        /// </summary>
        private static float Row(Graphics g, Font f, float x, float y, float[] widths, string[] cells,
                                 bool shaded, int firstRightCol = 1)
        {
            float h = f.GetHeight(g) + 6;
            float total = widths.Sum();

            if (shaded) g.FillRectangle(Brushes.Gainsboro, x, y, total, h);

            float cx = x;
            for (int i = 0; i < cells.Length; i++)
            {
                using var sf = new StringFormat
                {
                    Alignment = i >= firstRightCol ? StringAlignment.Far : StringAlignment.Near,
                    Trimming = StringTrimming.EllipsisCharacter,
                    FormatFlags = StringFormatFlags.NoWrap
                };
                g.DrawString(cells[i], f, Brushes.Black, new RectangleF(cx + 3, y + 3, widths[i] - 6, h - 3), sf);
                cx += widths[i];
            }

            g.DrawLine(Pens.Gray, x, y + h, x + total, y + h);
            return y + h;
        }
    }


}