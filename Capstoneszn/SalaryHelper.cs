//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;

//namespace Capstoneszn
//{
//    /// <summary>What happened when the landlord pressed Save on the salary.</summary>
//    public enum SalarySaveResult
//    {
//        NoChange,          // typed the current salary and nothing was waiting
//        SetThisMonth,      // first salary of the building - applies this month
//        Scheduled,         // a change - applies from next month
//        CancelledPending   // typed the current salary - the waiting change was removed
//    }

//    /// <summary>
//    /// The employee salary is only an EXPENSE of the building - not a payroll.
//    ///
//    /// RULES (settled Oct 28, 2026)
//    ///   - one fixed MONTHLY salary per building, the same for every employee
//    ///   - an employee is paid from the day they are ADDED until the day they
//    ///     are ARCHIVED (the archive day itself is not paid)
//    ///   - leave (Status unchecked) does NOT change the salary
//    ///   - a salary change applies from next month
//    ///
//    /// HOW "AUTOMATIC AT MONTH END" WORKS
//    ///   SQL Server Express has no scheduler and the app is not always open on
//    ///   the 31st. So right after every login, RecordMonthEndSalaries() records
//    ///   every FINISHED month that is not recorded yet, dated the last day of
//    ///   that month. Login on Nov 3 -> October is recorded, dated Oct 31.
//    ///   Running it again records nothing (one salary expense per employee per date).
//    /// </summary>
//    public static class SalaryHelper
//    {
//        public const string SalaryCategory = "Salary";

//        public static DateTime FirstOfMonth(DateTime d) => new DateTime(d.Year, d.Month, 1);

//        // =====================================================================
//        // PART 1 — Read the salary
//        // =====================================================================

//        /// <summary>Salary that applies to the given month, or null if none is set.</summary>
//        public static decimal? GetSalaryForMonth(int buildingId, DateTime month)
//        {
//            using (SqlConnection conn = DatabaseHelper.GetConnection())
//            {
//                conn.Open();
//                return GetSalaryForMonth(conn, null, buildingId, month);
//            }
//        }

//        private static decimal? GetSalaryForMonth(SqlConnection conn, SqlTransaction? tx,
//                                                  int buildingId, DateTime month)
//        {
//            const string sql = @"
//                SELECT TOP 1 MonthlySalary
//                FROM   SalaryRates
//                WHERE  BuildingId = @b AND EffectiveMonth <= @m
//                ORDER BY EffectiveMonth DESC;";

//            using (var cmd = new SqlCommand(sql, conn, tx))
//            {
//                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
//                cmd.Parameters.Add("@m", SqlDbType.Date).Value = FirstOfMonth(month);
//                object? v = cmd.ExecuteScalar();
//                return v == null || v == DBNull.Value ? null : Convert.ToDecimal(v);
//            }
//        }

//        /// <summary>True if a salary applies to the current month (Add Employee needs this).</summary>
//        public static bool HasSalaryThisMonth(int buildingId)
//            => GetSalaryForMonth(buildingId, DateTime.Today).HasValue;

//        /// <summary>A change that is waiting to start (next month), or null.</summary>
//        public static (decimal Salary, DateTime EffectiveMonth)? GetPendingSalary(int buildingId)
//        {
//            const string sql = @"
//                SELECT TOP 1 MonthlySalary, EffectiveMonth
//                FROM   SalaryRates
//                WHERE  BuildingId = @b AND EffectiveMonth > @m
//                ORDER BY EffectiveMonth;";

//            using (SqlConnection conn = DatabaseHelper.GetConnection())
//            using (var cmd = new SqlCommand(sql, conn))
//            {
//                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
//                cmd.Parameters.Add("@m", SqlDbType.Date).Value = FirstOfMonth(DateTime.Today);
//                conn.Open();
//                using (var r = cmd.ExecuteReader())
//                {
//                    if (!r.Read()) return null;
//                    return (r.GetDecimal(0), r.GetDateTime(1));
//                }
//            }
//        }

//        // =====================================================================
//        // PART 2 — Save the salary
//        //   no salary yet            -> applies THIS month
//        //   same as current salary   -> cancels a waiting change (or nothing to do)
//        //   different amount         -> applies from NEXT month
//        //                               (replaces any change already waiting)
//        // =====================================================================
//        public static SalarySaveResult SetSalary(int buildingId, decimal monthlySalary,
//                                                 int userId, out DateTime effectiveMonth)
//        {
//            DateTime thisMonth = FirstOfMonth(DateTime.Today);
//            DateTime nextMonth = thisMonth.AddMonths(1);
//            effectiveMonth = thisMonth;
//            SalarySaveResult result;

//            using (SqlConnection conn = DatabaseHelper.GetConnection())
//            {
//                conn.Open();
//                using (SqlTransaction tx = conn.BeginTransaction())
//                {
//                    try
//                    {
//                        decimal? current = GetSalaryForMonth(conn, tx, buildingId, thisMonth);

//                        if (current == null)
//                        {
//                            // 2a. First salary of the building -> this month.
//                            DeleteFutureRates(conn, tx, buildingId, thisMonth);
//                            UpsertRate(conn, tx, buildingId, monthlySalary, thisMonth, userId);
//                            effectiveMonth = thisMonth;
//                            result = SalarySaveResult.SetThisMonth;

//                            AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Set Salary",
//                                $"Monthly salary set to {monthlySalary:N2}, from {thisMonth:MMMM yyyy}");
//                        }
//                        else if (current.Value == monthlySalary)
//                        {
//                            // 2b. Same as the current salary -> remove a waiting change, if any.
//                            int removed = DeleteFutureRates(conn, tx, buildingId, thisMonth);
//                            result = removed > 0 ? SalarySaveResult.CancelledPending
//                                                 : SalarySaveResult.NoChange;

//                            if (removed > 0)
//                                AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Cancel Salary",
//                                    $"Pending salary change cancelled; stays {monthlySalary:N2}");
//                        }
//                        else
//                        {
//                            // 2c. A real change -> next month (only one waiting change at a time).
//                            DeleteFutureRates(conn, tx, buildingId, thisMonth);
//                            UpsertRate(conn, tx, buildingId, monthlySalary, nextMonth, userId);
//                            effectiveMonth = nextMonth;
//                            result = SalarySaveResult.Scheduled;

//                            AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Set Salary",
//                                $"Monthly salary changed {current.Value:N2} -> {monthlySalary:N2}, from {nextMonth:MMMM yyyy}");
//                        }

//                        tx.Commit();
//                    }
//                    catch
//                    {
//                        tx.Rollback();
//                        throw;
//                    }
//                }
//            }
//            return result;
//        }

//        /// Removes every rate that starts after this month (the waiting change).
//        private static int DeleteFutureRates(SqlConnection conn, SqlTransaction tx,
//                                             int buildingId, DateTime thisMonth)
//        {
//            using (var cmd = new SqlCommand(
//                "DELETE FROM SalaryRates WHERE BuildingId = @b AND EffectiveMonth > @m;", conn, tx))
//            {
//                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
//                cmd.Parameters.Add("@m", SqlDbType.Date).Value = thisMonth;
//                return cmd.ExecuteNonQuery();
//            }
//        }

//        /// Insert the rate for that month, or replace it if that month already has one.
//        private static void UpsertRate(SqlConnection conn, SqlTransaction tx, int buildingId,
//                                       decimal salary, DateTime month, int userId)
//        {
//            const string sql = @"
//                UPDATE SalaryRates
//                SET    MonthlySalary = @s, SetBy = @u, SetAt = SYSDATETIME()
//                WHERE  BuildingId = @b AND EffectiveMonth = @m;

//                IF @@ROWCOUNT = 0
//                    INSERT INTO SalaryRates (BuildingId, MonthlySalary, EffectiveMonth, SetBy)
//                    VALUES (@b, @s, @m, @u);";

//            using (var cmd = new SqlCommand(sql, conn, tx))
//            {
//                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
//                var p = cmd.Parameters.Add("@s", SqlDbType.Decimal);
//                p.Precision = 18; p.Scale = 2; p.Value = salary;
//                cmd.Parameters.Add("@m", SqlDbType.Date).Value = month;
//                cmd.Parameters.Add("@u", SqlDbType.Int).Value = userId;
//                cmd.ExecuteNonQuery();
//            }
//        }

//        // =====================================================================
//        // PART 3 — Prorate: monthly salary x days paid / days in that month
//        //   P10,000 x 4 / 31 = P1,290.32  (added Oct 28)
//        // =====================================================================
//        public static decimal Prorate(decimal monthlySalary, int daysPaid, int daysInMonth)
//        {
//            if (daysPaid >= daysInMonth) return monthlySalary;   // full month = exact salary
//            return Math.Round(monthlySalary * daysPaid / daysInMonth, 2,
//                              MidpointRounding.AwayFromZero);
//        }

//        private static string Describe(string fullName, DateTime month, int daysPaid, int daysInMonth)
//        {
//            string days = daysPaid >= daysInMonth ? "full month" : $"{daysPaid} of {daysInMonth} days";
//            string text = $"Salary - {fullName} - {month:MMMM yyyy} ({days})";
//            return text.Length <= 255 ? text : text.Substring(0, 255);
//        }

//        // =====================================================================
//        // PART 4 — Month-end recording (call right after a successful login)
//        //
//        // For every employee, every FINISHED month from the month they were
//        // added, not recorded yet:
//        //   - full month        -> the full salary, dated the last day of the month
//        //   - month added       -> prorated from the date added
//        // The month an employee is ARCHIVED is not done here - Archive records
//        // that last part itself (PART 5), so it is skipped below.
//        // =====================================================================
//        public static (int Count, decimal Total) RecordMonthEndSalaries(int recordedByUserId)
//        {
//            int count = 0;
//            decimal total = 0m;
//            DateTime lastFinishedMonth = FirstOfMonth(DateTime.Today).AddMonths(-1);

//            using (SqlConnection conn = DatabaseHelper.GetConnection())
//            {
//                conn.Open();

//                var employees = LoadEmployees(conn);        // DateHired / ArchivedAt
//                var recorded = LoadRecordedSalaries(conn);  // (EmployeeId, ExpenseDate) already saved
//                var rates = LoadRates(conn);                // salary history

//                foreach (var emp in employees)
//                {
//                    // Last month to do: the last finished month, but never the archive
//                    // month or later (Archive already recorded those days).
//                    DateTime lastMonth = lastFinishedMonth;
//                    if (emp.ArchivedAt.HasValue)
//                    {
//                        DateTime beforeArchiveMonth = FirstOfMonth(emp.ArchivedAt.Value).AddMonths(-1);
//                        if (beforeArchiveMonth < lastMonth) lastMonth = beforeArchiveMonth;
//                    }

//                    for (DateTime month = FirstOfMonth(emp.DateHired); month <= lastMonth; month = month.AddMonths(1))
//                    {
//                        DateTime monthEnd = month.AddMonths(1).AddDays(-1);
//                        if (recorded.Contains((emp.EmployeeId, monthEnd))) continue;   // already done

//                        // Paid days = from the later of (1st of month, date added) to month end.
//                        DateTime from = emp.DateHired > month ? emp.DateHired : month;
//                        int daysPaid = (month.AddMonths(1) - from).Days;
//                        int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
//                        if (daysPaid <= 0) continue;

//                        decimal? salary = RateFor(rates, emp.BuildingId, month);
//                        if (salary == null) continue;   // no salary set for that month

//                        decimal amount = Prorate(salary.Value, daysPaid, daysInMonth);
//                        if (amount <= 0) continue;

//                        if (InsertSalaryExpense(conn, null, emp.BuildingId, emp.EmployeeId, monthEnd, amount,
//                                Describe(emp.FullName, month, daysPaid, daysInMonth), recordedByUserId))
//                        {
//                            count++;
//                            total += amount;
//                        }
//                    }
//                }
//            }

//            if (count > 0)
//                AuditLogger.Log(AuditLogger.ModuleEmployee, "Record Salaries",
//                    $"Recorded {count} month-end salary expense(s), total {total:N2}");

//            return (count, total);
//        }

//        // =====================================================================
//        // PART 5 — Final salary when an employee is ARCHIVED
//        // Called inside the Archive transaction (EmployeeHelper.Archive).
//        // Pays from the later of (1st of the month, date added) up to the day
//        // BEFORE the archive date, dated that last paid day.
//        //   Archived Oct 10 -> Oct 1-9 = 9 of 31 days, dated Oct 9
//        // =====================================================================
//        public static decimal RecordFinalSalary(SqlConnection conn, SqlTransaction tx,
//                                                int employeeId, int buildingId, string fullName,
//                                                DateTime dateHired, DateTime archiveDate, int userId)
//        {
//            DateTime month = FirstOfMonth(archiveDate);
//            DateTime from = dateHired.Date > month ? dateHired.Date : month;
//            int daysPaid = (archiveDate.Date - from).Days;
//            if (daysPaid <= 0) return 0m;   // archived on the 1st, or on the day added

//            decimal? salary = GetSalaryForMonth(conn, tx, buildingId, month);
//            if (salary == null) return 0m;

//            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
//            decimal amount = Prorate(salary.Value, daysPaid, daysInMonth);
//            if (amount <= 0) return 0m;

//            DateTime lastPaidDay = archiveDate.Date.AddDays(-1);
//            InsertSalaryExpense(conn, tx, buildingId, employeeId, lastPaidDay, amount,
//                Describe(fullName, month, daysPaid, daysInMonth), userId);
//            return amount;
//        }

//        // ---------------------------------------------------------------------
//        // Helpers
//        // ---------------------------------------------------------------------
//        private class EmployeeRow
//        {
//            public int EmployeeId;
//            public int BuildingId;
//            public string FullName = "";
//            public DateTime DateHired;
//            public DateTime? ArchivedAt;
//        }

//        private static List<EmployeeRow> LoadEmployees(SqlConnection conn)
//        {
//            // Archived employees are included: months before their archive month
//            // may still be unrecorded if nobody logged in for a while.
//            var list = new List<EmployeeRow>();
//            using (var cmd = new SqlCommand(
//                "SELECT EmployeeId, BuildingId, FullName, DateHired, ArchivedAt FROM Employees;", conn))
//            using (var r = cmd.ExecuteReader())
//            {
//                while (r.Read())
//                {
//                    list.Add(new EmployeeRow
//                    {
//                        EmployeeId = r.GetInt32(0),
//                        BuildingId = r.GetInt32(1),
//                        FullName = r.GetString(2),
//                        DateHired = r.GetDateTime(3).Date,
//                        ArchivedAt = r.IsDBNull(4) ? null : r.GetDateTime(4).Date
//                    });
//                }
//            }
//            return list;
//        }

//        private static HashSet<(int, DateTime)> LoadRecordedSalaries(SqlConnection conn)
//        {
//            var set = new HashSet<(int, DateTime)>();
//            using (var cmd = new SqlCommand(
//                "SELECT EmployeeId, ExpenseDate FROM Expenses WHERE EmployeeId IS NOT NULL;", conn))
//            using (var r = cmd.ExecuteReader())
//            {
//                while (r.Read())
//                    set.Add((r.GetInt32(0), r.GetDateTime(1).Date));
//            }
//            return set;
//        }

//        private static List<(int BuildingId, decimal Salary, DateTime EffectiveMonth)> LoadRates(SqlConnection conn)
//        {
//            var list = new List<(int, decimal, DateTime)>();
//            using (var cmd = new SqlCommand(
//                "SELECT BuildingId, MonthlySalary, EffectiveMonth FROM SalaryRates;", conn))
//            using (var r = cmd.ExecuteReader())
//            {
//                while (r.Read())
//                    list.Add((r.GetInt32(0), r.GetDecimal(1), r.GetDateTime(2)));
//            }
//            return list;
//        }

//        private static decimal? RateFor(List<(int BuildingId, decimal Salary, DateTime EffectiveMonth)> rates,
//                                        int buildingId, DateTime month)
//        {
//            return rates.Where(x => x.BuildingId == buildingId && x.EffectiveMonth <= month)
//                        .OrderByDescending(x => x.EffectiveMonth)
//                        .Select(x => (decimal?)x.Salary)
//                        .FirstOrDefault();
//        }

//        /// Returns false if that employee already has a salary expense on that date.
//        private static bool InsertSalaryExpense(SqlConnection conn, SqlTransaction? tx, int buildingId,
//                                                int employeeId, DateTime expenseDate, decimal amount,
//                                                string description, int recordedByUserId)
//        {
//            const string sql = @"
//                IF NOT EXISTS (SELECT 1 FROM Expenses WHERE EmployeeId = @emp AND ExpenseDate = @date)
//                    INSERT INTO Expenses
//                        (BuildingId, ExpenseCategory, Description, Amount, ExpenseDate,
//                         MaintenanceIssueId, EmployeeId, RecordedBy)
//                    VALUES
//                        (@b, @cat, @desc, @amt, @date, NULL, @emp, @by);";

//            using (var cmd = new SqlCommand(sql, conn, tx))
//            {
//                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
//                cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = SalaryCategory;
//                cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 255).Value = description;
//                var a = cmd.Parameters.Add("@amt", SqlDbType.Decimal);
//                a.Precision = 18; a.Scale = 2; a.Value = amount;
//                cmd.Parameters.Add("@date", SqlDbType.Date).Value = expenseDate.Date;
//                cmd.Parameters.Add("@emp", SqlDbType.Int).Value = employeeId;
//                cmd.Parameters.Add("@by", SqlDbType.Int).Value = recordedByUserId;
//                return cmd.ExecuteNonQuery() == 1;
//            }
//        }
//    }
//}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Capstoneszn
{
    /// <summary>What happened when the landlord pressed Save on the salary.</summary>
    public enum SalarySaveResult
    {
        NoChange,          // typed the current salary and nothing was waiting
        SetThisMonth,      // first salary of the building - applies this month
        Scheduled,         // a change - applies from next month
        CancelledPending   // typed the current salary - the waiting change was removed
    }

    /// <summary>
    /// The employee salary is only an EXPENSE of the building - not a payroll.
    ///
    /// RULES (revised Nov 5, 2026) - these replace the Oct 28 rules below
    ///   - one fixed DAILY salary per building, the same for every employee
    ///   - an employee is paid only for WORKING DAYS: days their Status is
    ///     checked (stored in EmployeeActivePeriods)
    ///   - a salary change still applies from next month
    ///   - two cutoffs a month: the 1st-15th, and the 16th-last day
    ///     (30th, 31st, or 28th/29th in February)
    ///
    /// HOW THE CUTOFF RECORDING WORKS
    ///   Each time MainForm opens (after the clock check), RecordCutoffSalaries()
    ///   records every cutoff that has ENDED and is not recorded yet:
    ///     amount = days worked in that cutoff x daily salary
    ///     dated the cutoff day (the 15th, or the last day of the month)
    ///   A cutoff is recorded from the NEXT day on (e.g. Nov 1-15 on Nov 16),
    ///   because the cutoff day itself can still be changed to a day off.
    ///   Running it again records nothing (one salary expense per employee per date).
    ///
    /// OLD RULES (settled Oct 28, 2026), kept for reference:
    ///   - one fixed MONTHLY salary per building, the same for every employee
    ///   - an employee is paid from the day they are ADDED until the day they
    ///     are ARCHIVED (the archive day itself is not paid)
    ///   - leave (Status unchecked) does NOT change the salary
    ///   - a salary change applies from next month
    ///
    /// HOW "AUTOMATIC AT MONTH END" WORKS
    ///   SQL Server Express has no scheduler and the app is not always open on
    ///   the 31st. So right after every login, RecordMonthEndSalaries() records
    ///   every FINISHED month that is not recorded yet, dated the last day of
    ///   that month. Login on Nov 3 -> October is recorded, dated Oct 31.
    ///   Running it again records nothing (one salary expense per employee per date).
    /// </summary>
    public static class SalaryHelper
    {
        public const string SalaryCategory = "Salary";

        public static DateTime FirstOfMonth(DateTime d) => new DateTime(d.Year, d.Month, 1);

        // =====================================================================
        // PART 1 — Read the salary
        // =====================================================================

        /// <summary>Salary that applies to the given month, or null if none is set.</summary>
        public static decimal? GetSalaryForMonth(int buildingId, DateTime month)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return GetSalaryForMonth(conn, null, buildingId, month);
            }
        }

        private static decimal? GetSalaryForMonth(SqlConnection conn, SqlTransaction? tx,
                                                  int buildingId, DateTime month)
        {
            // OLD: SELECT TOP 1 MonthlySalary ...   (column renamed Nov 5, 2026)
            const string sql = @"
                SELECT TOP 1 DailySalary
                FROM   SalaryRates
                WHERE  BuildingId = @b AND EffectiveMonth <= @m
                ORDER BY EffectiveMonth DESC;";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                cmd.Parameters.Add("@m", SqlDbType.Date).Value = FirstOfMonth(month);
                object? v = cmd.ExecuteScalar();
                return v == null || v == DBNull.Value ? null : Convert.ToDecimal(v);
            }
        }

        /// <summary>True if a salary applies to the current month (Add Employee needs this).</summary>
        public static bool HasSalaryThisMonth(int buildingId)
            => GetSalaryForMonth(buildingId, DateTime.Today).HasValue;

        /// <summary>A change that is waiting to start (next month), or null.</summary>
        public static (decimal Salary, DateTime EffectiveMonth)? GetPendingSalary(int buildingId)
        {
            // OLD: SELECT TOP 1 MonthlySalary, EffectiveMonth ...   (column renamed Nov 5, 2026)
            const string sql = @"
                SELECT TOP 1 DailySalary, EffectiveMonth
                FROM   SalaryRates
                WHERE  BuildingId = @b AND EffectiveMonth > @m
                ORDER BY EffectiveMonth;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                cmd.Parameters.Add("@m", SqlDbType.Date).Value = FirstOfMonth(DateTime.Today);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    return (r.GetDecimal(0), r.GetDateTime(1));
                }
            }
        }

        // =====================================================================
        // PART 2 — Save the salary
        //   no salary yet            -> applies THIS month
        //   same as current salary   -> cancels a waiting change (or nothing to do)
        //   different amount         -> applies from NEXT month
        //                               (replaces any change already waiting)
        // =====================================================================
        public static SalarySaveResult SetSalary(int buildingId, decimal monthlySalary,
                                                 int userId, out DateTime effectiveMonth)
        {
            DateTime thisMonth = FirstOfMonth(DateTime.Today);
            DateTime nextMonth = thisMonth.AddMonths(1);
            effectiveMonth = thisMonth;
            SalarySaveResult result;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        decimal? current = GetSalaryForMonth(conn, tx, buildingId, thisMonth);

                        if (current == null)
                        {
                            // 2a. First salary of the building -> this month.
                            DeleteFutureRates(conn, tx, buildingId, thisMonth);
                            UpsertRate(conn, tx, buildingId, monthlySalary, thisMonth, userId);
                            effectiveMonth = thisMonth;
                            result = SalarySaveResult.SetThisMonth;

                            // OLD: $"Monthly salary set to {monthlySalary:N2}, from {thisMonth:MMMM yyyy}"
                            AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Set Salary",
                                $"Daily salary set to {monthlySalary:N2}, from {thisMonth:MMMM yyyy}");
                        }
                        else if (current.Value == monthlySalary)
                        {
                            // 2b. Same as the current salary -> remove a waiting change, if any.
                            int removed = DeleteFutureRates(conn, tx, buildingId, thisMonth);
                            result = removed > 0 ? SalarySaveResult.CancelledPending
                                                 : SalarySaveResult.NoChange;

                            if (removed > 0)
                                AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Cancel Salary",
                                    $"Pending salary change cancelled; stays {monthlySalary:N2}");
                        }
                        else
                        {
                            // 2c. A real change -> next month (only one waiting change at a time).
                            DeleteFutureRates(conn, tx, buildingId, thisMonth);
                            UpsertRate(conn, tx, buildingId, monthlySalary, nextMonth, userId);
                            effectiveMonth = nextMonth;
                            result = SalarySaveResult.Scheduled;

                            // OLD: $"Monthly salary changed {current.Value:N2} -> {monthlySalary:N2}, from {nextMonth:MMMM yyyy}"
                            AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Set Salary",
                                $"Daily salary changed {current.Value:N2} -> {monthlySalary:N2}, from {nextMonth:MMMM yyyy}");
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            return result;
        }

        /// Removes every rate that starts after this month (the waiting change).
        private static int DeleteFutureRates(SqlConnection conn, SqlTransaction tx,
                                             int buildingId, DateTime thisMonth)
        {
            using (var cmd = new SqlCommand(
                "DELETE FROM SalaryRates WHERE BuildingId = @b AND EffectiveMonth > @m;", conn, tx))
            {
                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                cmd.Parameters.Add("@m", SqlDbType.Date).Value = thisMonth;
                return cmd.ExecuteNonQuery();
            }
        }

        /// Insert the rate for that month, or replace it if that month already has one.
        private static void UpsertRate(SqlConnection conn, SqlTransaction tx, int buildingId,
                                       decimal salary, DateTime month, int userId)
        {
            /* OLD (column renamed to DailySalary, Nov 5, 2026):
            const string sql = @"
                UPDATE SalaryRates
                SET    MonthlySalary = @s, SetBy = @u, SetAt = SYSDATETIME()
                WHERE  BuildingId = @b AND EffectiveMonth = @m;

                IF @@ROWCOUNT = 0
                    INSERT INTO SalaryRates (BuildingId, MonthlySalary, EffectiveMonth, SetBy)
                    VALUES (@b, @s, @m, @u);";
            */
            const string sql = @"
                UPDATE SalaryRates
                SET    DailySalary = @s, SetBy = @u, SetAt = SYSDATETIME()
                WHERE  BuildingId = @b AND EffectiveMonth = @m;

                IF @@ROWCOUNT = 0
                    INSERT INTO SalaryRates (BuildingId, DailySalary, EffectiveMonth, SetBy)
                    VALUES (@b, @s, @m, @u);";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                var p = cmd.Parameters.Add("@s", SqlDbType.Decimal);
                p.Precision = 18; p.Scale = 2; p.Value = salary;
                cmd.Parameters.Add("@m", SqlDbType.Date).Value = month;
                cmd.Parameters.Add("@u", SqlDbType.Int).Value = userId;
                cmd.ExecuteNonQuery();
            }
        }

        // =====================================================================
        // NOT USED since Nov 5, 2026 (daily salary) - kept for reference.
        // PART 3 — Prorate: monthly salary x days paid / days in that month
        //   P10,000 x 4 / 31 = P1,290.32  (added Oct 28)
        // =====================================================================
        public static decimal Prorate(decimal monthlySalary, int daysPaid, int daysInMonth)
        {
            if (daysPaid >= daysInMonth) return monthlySalary;   // full month = exact salary
            return Math.Round(monthlySalary * daysPaid / daysInMonth, 2,
                              MidpointRounding.AwayFromZero);
        }

        private static string Describe(string fullName, DateTime month, int daysPaid, int daysInMonth)
        {
            string days = daysPaid >= daysInMonth ? "full month" : $"{daysPaid} of {daysInMonth} days";
            string text = $"Salary - {fullName} - {month:MMMM yyyy} ({days})";
            return text.Length <= 255 ? text : text.Substring(0, 255);
        }

        // =====================================================================
        // PART 4 — Month-end recording (call right after a successful login)
        //
        // For every employee, every FINISHED month from the month they were
        // added, not recorded yet:
        //   - full month        -> the full salary, dated the last day of the month
        //   - month added       -> prorated from the date added
        // The month an employee is ARCHIVED is not done here - Archive records
        // that last part itself (PART 5), so it is skipped below.
        // =====================================================================
        // ADDED (Nov 5, 2026): MainForm still calls this name, so it now
        // simply runs the new 15th / month-end cutoff recording (PART 6).
        public static (int Count, decimal Total) RecordMonthEndSalaries(int recordedByUserId)
            => RecordCutoffSalaries(recordedByUserId);

        /* OLD (monthly salary, Oct 28, 2026) - replaced by RecordCutoffSalaries:
        public static (int Count, decimal Total) RecordMonthEndSalaries(int recordedByUserId)
        {
            int count = 0;
            decimal total = 0m;
            DateTime lastFinishedMonth = FirstOfMonth(DateTime.Today).AddMonths(-1);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                var employees = LoadEmployees(conn);        // DateHired / ArchivedAt
                var recorded = LoadRecordedSalaries(conn);  // (EmployeeId, ExpenseDate) already saved
                var rates = LoadRates(conn);                // salary history

                foreach (var emp in employees)
                {
                    // Last month to do: the last finished month, but never the archive
                    // month or later (Archive already recorded those days).
                    DateTime lastMonth = lastFinishedMonth;
                    if (emp.ArchivedAt.HasValue)
                    {
                        DateTime beforeArchiveMonth = FirstOfMonth(emp.ArchivedAt.Value).AddMonths(-1);
                        if (beforeArchiveMonth < lastMonth) lastMonth = beforeArchiveMonth;
                    }

                    for (DateTime month = FirstOfMonth(emp.DateHired); month <= lastMonth; month = month.AddMonths(1))
                    {
                        DateTime monthEnd = month.AddMonths(1).AddDays(-1);
                        if (recorded.Contains((emp.EmployeeId, monthEnd))) continue;   // already done

                        // Paid days = from the later of (1st of month, date added) to month end.
                        DateTime from = emp.DateHired > month ? emp.DateHired : month;
                        int daysPaid = (month.AddMonths(1) - from).Days;
                        int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
                        if (daysPaid <= 0) continue;

                        decimal? salary = RateFor(rates, emp.BuildingId, month);
                        if (salary == null) continue;   // no salary set for that month

                        decimal amount = Prorate(salary.Value, daysPaid, daysInMonth);
                        if (amount <= 0) continue;

                        if (InsertSalaryExpense(conn, null, emp.BuildingId, emp.EmployeeId, monthEnd, amount,
                                Describe(emp.FullName, month, daysPaid, daysInMonth), recordedByUserId))
                        {
                            count++;
                            total += amount;
                        }
                    }
                }
            }

            if (count > 0)
                AuditLogger.Log(AuditLogger.ModuleEmployee, "Record Salaries",
                    $"Recorded {count} month-end salary expense(s), total {total:N2}");

            return (count, total);
        }
        */

        // =====================================================================
        // NOT USED since Nov 5, 2026 - Archive no longer records a final salary;
        // the archive day simply ends the employee's paid days, and the next
        // cutoff records them. Kept for reference.
        // PART 5 — Final salary when an employee is ARCHIVED
        // Called inside the Archive transaction (EmployeeHelper.Archive).
        // Pays from the later of (1st of the month, date added) up to the day
        // BEFORE the archive date, dated that last paid day.
        //   Archived Oct 10 -> Oct 1-9 = 9 of 31 days, dated Oct 9
        // =====================================================================
        public static decimal RecordFinalSalary(SqlConnection conn, SqlTransaction tx,
                                                int employeeId, int buildingId, string fullName,
                                                DateTime dateHired, DateTime archiveDate, int userId)
        {
            DateTime month = FirstOfMonth(archiveDate);
            DateTime from = dateHired.Date > month ? dateHired.Date : month;
            int daysPaid = (archiveDate.Date - from).Days;
            if (daysPaid <= 0) return 0m;   // archived on the 1st, or on the day added

            decimal? salary = GetSalaryForMonth(conn, tx, buildingId, month);
            if (salary == null) return 0m;

            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
            decimal amount = Prorate(salary.Value, daysPaid, daysInMonth);
            if (amount <= 0) return 0m;

            DateTime lastPaidDay = archiveDate.Date.AddDays(-1);
            InsertSalaryExpense(conn, tx, buildingId, employeeId, lastPaidDay, amount,
                Describe(fullName, month, daysPaid, daysInMonth), userId);
            return amount;
        }

        // =====================================================================
        // PART 6 — Cutoff recording (ADDED Nov 5, 2026)
        //
        // Cutoffs: 1st-15th (dated the 15th) and 16th-last day (dated the last
        // day: 30th, 31st, or 28th/29th in February).
        // For every employee, every cutoff that has ENDED (cutoff day < today)
        // and is not recorded yet:
        //   days   = working days inside the cutoff (from EmployeeActivePeriods)
        //   amount = days x the daily salary of that month
        //   e.g. Nov 1-15, 12 working days x P500 = P6,000.00, dated Nov 15
        // A cutoff with 0 working days records nothing.
        // =====================================================================
        public static (int Count, decimal Total) RecordCutoffSalaries(int recordedByUserId)
        {
            int count = 0;
            decimal total = 0m;
            DateTime today = DateTime.Today;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                var employees = LoadEmployees(conn);         // id, building, name
                var periods = LoadWorkPeriods(conn);         // paid days per employee
                var recorded = LoadRecordedSalaries(conn);   // (EmployeeId, ExpenseDate) already saved
                var rates = LoadRates(conn);                 // daily salary history

                foreach (var emp in employees)
                {
                    if (!periods.TryGetValue(emp.EmployeeId, out var empPeriods)) continue;   // never worked

                    DateTime firstMonth = FirstOfMonth(empPeriods.Min(p => p.Start));

                    for (DateTime month = firstMonth; month <= FirstOfMonth(today); month = month.AddMonths(1))
                    {
                        DateTime lastDay = month.AddMonths(1).AddDays(-1);

                        // the two cutoffs of this month: (first day, cutoff day)
                        var cutoffs = new[]
                        {
                            (From: month,            To: month.AddDays(14)),   // 1st - 15th
                            (From: month.AddDays(15), To: lastDay)              // 16th - last day
                        };

                        foreach (var c in cutoffs)
                        {
                            if (c.To >= today) continue;                                  // not ended yet
                            if (recorded.Contains((emp.EmployeeId, c.To))) continue;     // already recorded

                            int days = CountPaidDays(empPeriods, c.From, c.To);
                            if (days <= 0) continue;                                      // no working days

                            decimal? daily = RateFor(rates, emp.BuildingId, month);
                            if (daily == null) continue;                                  // no salary set

                            decimal amount = daily.Value * days;
                            string description =
                                $"Salary - {emp.FullName} - {c.From:MMM d}-{c.To:d, yyyy} " +
                                $"({days} day(s) x {daily.Value:N2})";
                            if (description.Length > 255) description = description.Substring(0, 255);

                            if (InsertSalaryExpense(conn, null, emp.BuildingId, emp.EmployeeId,
                                                    c.To, amount, description, recordedByUserId))
                            {
                                count++;
                                total += amount;
                            }
                        }
                    }
                }
            }

            if (count > 0)
                AuditLogger.Log(AuditLogger.ModuleEmployee, "Record Salaries",
                    $"Recorded {count} cutoff salary expense(s), total {total:N2}");

            return (count, total);
        }

        /// Working days between from and to (both included), using the
        /// employee's paid stretches [Start, End) - End is the first unpaid day.
        public static int CountPaidDays(List<(DateTime Start, DateTime? End)> periods,
                                        DateTime from, DateTime to)
        {
            DateTime toExclusive = to.Date.AddDays(1);
            int days = 0;
            foreach (var p in periods)
            {
                DateTime s = p.Start > from ? p.Start : from;
                DateTime e = p.End ?? toExclusive;
                if (e > toExclusive) e = toExclusive;
                if (e > s) days += (e - s).Days;
            }
            return days;
        }

        private static Dictionary<int, List<(DateTime Start, DateTime? End)>> LoadWorkPeriods(SqlConnection conn)
        {
            var map = new Dictionary<int, List<(DateTime Start, DateTime? End)>>();
            using (var cmd = new SqlCommand(
                "SELECT EmployeeId, StartDate, EndDate FROM EmployeeActivePeriods;", conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    int id = r.GetInt32(0);
                    if (!map.TryGetValue(id, out var list))
                        map[id] = list = new List<(DateTime Start, DateTime? End)>();
                    list.Add((r.GetDateTime(1).Date, r.IsDBNull(2) ? (DateTime?)null : r.GetDateTime(2).Date));
                }
            }
            return map;
        }

        // ---------------------------------------------------------------------
        // Helpers
        // ---------------------------------------------------------------------
        private class EmployeeRow
        {
            public int EmployeeId;
            public int BuildingId;
            public string FullName = "";
            public DateTime DateHired;
            public DateTime? ArchivedAt;
        }

        private static List<EmployeeRow> LoadEmployees(SqlConnection conn)
        {
            // Archived employees are included: months before their archive month
            // may still be unrecorded if nobody logged in for a while.
            var list = new List<EmployeeRow>();
            using (var cmd = new SqlCommand(
                "SELECT EmployeeId, BuildingId, FullName, DateHired, ArchivedAt FROM Employees;", conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    list.Add(new EmployeeRow
                    {
                        EmployeeId = r.GetInt32(0),
                        BuildingId = r.GetInt32(1),
                        FullName = r.GetString(2),
                        DateHired = r.GetDateTime(3).Date,
                        ArchivedAt = r.IsDBNull(4) ? null : r.GetDateTime(4).Date
                    });
                }
            }
            return list;
        }

        private static HashSet<(int, DateTime)> LoadRecordedSalaries(SqlConnection conn)
        {
            var set = new HashSet<(int, DateTime)>();
            using (var cmd = new SqlCommand(
                "SELECT EmployeeId, ExpenseDate FROM Expenses WHERE EmployeeId IS NOT NULL;", conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                    set.Add((r.GetInt32(0), r.GetDateTime(1).Date));
            }
            return set;
        }

        private static List<(int BuildingId, decimal Salary, DateTime EffectiveMonth)> LoadRates(SqlConnection conn)
        {
            var list = new List<(int, decimal, DateTime)>();
            using (var cmd = new SqlCommand(
                // OLD: "SELECT BuildingId, MonthlySalary, EffectiveMonth FROM SalaryRates;"
                "SELECT BuildingId, DailySalary, EffectiveMonth FROM SalaryRates;", conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                    list.Add((r.GetInt32(0), r.GetDecimal(1), r.GetDateTime(2)));
            }
            return list;
        }

        private static decimal? RateFor(List<(int BuildingId, decimal Salary, DateTime EffectiveMonth)> rates,
                                        int buildingId, DateTime month)
        {
            return rates.Where(x => x.BuildingId == buildingId && x.EffectiveMonth <= month)
                        .OrderByDescending(x => x.EffectiveMonth)
                        .Select(x => (decimal?)x.Salary)
                        .FirstOrDefault();
        }

        /// Returns false if that employee already has a salary expense on that date.
        private static bool InsertSalaryExpense(SqlConnection conn, SqlTransaction? tx, int buildingId,
                                                int employeeId, DateTime expenseDate, decimal amount,
                                                string description, int recordedByUserId)
        {
            const string sql = @"
                IF NOT EXISTS (SELECT 1 FROM Expenses WHERE EmployeeId = @emp AND ExpenseDate = @date)
                    INSERT INTO Expenses
                        (BuildingId, ExpenseCategory, Description, Amount, ExpenseDate,
                         MaintenanceIssueId, EmployeeId, RecordedBy)
                    VALUES
                        (@b, @cat, @desc, @amt, @date, NULL, @emp, @by);";

            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = SalaryCategory;
                cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 255).Value = description;
                var a = cmd.Parameters.Add("@amt", SqlDbType.Decimal);
                a.Precision = 18; a.Scale = 2; a.Value = amount;
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = expenseDate.Date;
                cmd.Parameters.Add("@emp", SqlDbType.Int).Value = employeeId;
                cmd.Parameters.Add("@by", SqlDbType.Int).Value = recordedByUserId;
                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}