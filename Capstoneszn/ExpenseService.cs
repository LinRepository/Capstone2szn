using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{

    /// <summary>One row of the Expenses screen.</summary>
    public class ExpenseRow
    {
        public int ExpenseId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

    /// <summary>
    /// Read-only data access for the Expenses screen.
    ///
    /// Expenses are written by the modules that cause them (Maintenance at
    /// Complete, the Utilities water code); this class only reads. The
    /// category list comes from ExpenseCategories, so a new category shows
    /// up as a new tab without any code change.
    /// </summary>
    public static class ExpenseService
    {
        /// <summary>Active categories in display order.</summary>
        public static List<string> GetActiveCategories()
        {
            var list = new List<string>();

            string sql = @"
                SELECT CategoryName
                FROM   ExpenseCategories
                WHERE  IsActive = 1
                ORDER BY SortOrder, CategoryName;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read()) list.Add(rd.GetString(0));
                }
            }

            return list;
        }

        /// <summary>
        /// One building's expenses, newest first.
        /// fromDate is inclusive, toDate is exclusive; null means no limit.
        /// </summary>
        public static List<ExpenseRow> GetExpenses(int buildingId, DateTime? fromDate, DateTime? toDate)
        {
            var list = new List<ExpenseRow>();

            string sql = @"
                SELECT ExpenseId, ExpenseDate, ExpenseCategory, Description, Amount
                FROM   Expenses
                WHERE  BuildingId = @bid
                  AND  (@from IS NULL OR ExpenseDate >= @from)
                  AND  (@to   IS NULL OR ExpenseDate <  @to)
                ORDER BY ExpenseDate DESC, ExpenseId DESC;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bid", buildingId);
                cmd.Parameters.Add("@from", System.Data.SqlDbType.Date).Value =
                    fromDate.HasValue ? fromDate.Value.Date : DBNull.Value;
                cmd.Parameters.Add("@to", System.Data.SqlDbType.Date).Value =
                    toDate.HasValue ? toDate.Value.Date : DBNull.Value;

                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new ExpenseRow
                        {
                            ExpenseId = rd.GetInt32(0),
                            ExpenseDate = rd.GetDateTime(1),
                            Category = rd.GetString(2),
                            Description = rd.GetString(3),
                            Amount = rd.GetDecimal(4)
                        });
                    }
                }
            }

            return list;
        }
    }

}
