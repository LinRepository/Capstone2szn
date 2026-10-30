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

        public string StatementNo => "SOA-" + RoomNumber + "-" + Period.Start.ToString("yyyyMMdd");

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
        /// The room's rent periods, newest first. A period appears once its
        /// rent bill exists (generated 7 days before the due date); test bills
        /// further in the future are ignored.
        /// </summary>
        public static List<StatementPeriod> GetPeriods(int roomId)
        {
            var list = new List<StatementPeriod>();

            const string sql = @"
                SELECT BillingPeriodStart, BillingPeriodEnd, DueDate
                FROM   Bills
                WHERE  RoomId = @rid
                  AND  BillCategory = 'Rent'
                  AND  BillingPeriodStart <= DATEADD(DAY, 7, CAST(GETDATE() AS DATE))
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
                const string ledgerSql = @"
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
                    )
                    SELECT te.FirstName + ' ' + te.LastName AS TenantName,
                           ISNULL(c.PrevCharges, 0) - ISNULL(pd.PrevPaid, 0) + ISNULL(ad.PrevAdj, 0) AS PreviousBalance,
                           ISNULL(c.Rent, 0)          AS Rent,
                           ISNULL(c.Water, 0)         AS Water,
                           ISNULL(c.Maint, 0)         AS Maintenance,
                           ISNULL(pd.PaidInPeriod, 0) AS Payments,
                           ISNULL(ad.AdjInPeriod, 0)  AS Adjustments
                    FROM   ids
                    JOIN   Tenants te     ON te.TenantId = ids.TenantId
                    LEFT JOIN charges c   ON c.TenantId  = ids.TenantId
                    LEFT JOIN paid pd     ON pd.TenantId = ids.TenantId
                    LEFT JOIN adjs ad     ON ad.TenantId = ids.TenantId
                    ORDER BY te.LastName, te.FirstName;";

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

                            // A former tenant whose account was already settled
                            // before this period adds nothing to it.
                            if (!line.IsEmpty) st.Tenants.Add(line);
                        }
                    }
                }

                // ---- 3. Payments received during the period -------------------
                //  Same filters as "paid" above, grouped per receipt, so this
                //  list always adds up to the Payments total.
                const string paySql = @"
                    SELECT p.PaymentDate, p.ReceiptNo,
                           te.FirstName + ' ' + te.LastName AS PaidBy,
                           p.PaymentMethod, SUM(a.Amount) AS Amount
                    FROM   Payments p
                    JOIN   PaymentAllocations a ON a.PaymentId = p.PaymentId
                    LEFT JOIN Bills b ON b.BillId = a.BillId
                    JOIN   Tenants te ON te.TenantId = p.TenantId
                    WHERE  p.PaymentDate >= @S
                      AND  p.PaymentDate <  @Dnext
                      AND  (p.IsVoided = 0 OR p.VoidedAt >= @Dnext)
                      AND  (b.RoomId = @rid OR (a.BillId IS NULL AND p.RoomId = @rid))
                    GROUP BY p.PaymentId, p.PaymentDate, p.ReceiptNo,
                             te.FirstName, te.LastName, p.PaymentMethod
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
            }

            return st;
        }

        private static void AddPeriodParameters(SqlCommand cmd, int roomId,
            StatementPeriod period, DateTime dayAfterAsOf)
        {
            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
            cmd.Parameters.Add("@S", SqlDbType.Date).Value = period.Start;
            cmd.Parameters.Add("@E", SqlDbType.Date).Value = period.End;
            cmd.Parameters.Add("@Dnext", SqlDbType.Date).Value = dayAfterAsOf;
        }
    }

    /* ======================================================================
       PRINTING: draws the statement on one A4 page and opens the preview.
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

                doc.PrintPage += (s, e) =>
                {
                    Draw(e.Graphics, e.MarginBounds, st);
                    e.HasMorePages = false;   // one page per statement
                };

                preview.Document = doc;
                preview.Text = "Statement of Account - Room " + st.RoomNumber;
                preview.Width = 900;
                preview.Height = 1000;
                preview.StartPosition = FormStartPosition.CenterScreen;
                preview.ShowDialog(owner);
            }
        }

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