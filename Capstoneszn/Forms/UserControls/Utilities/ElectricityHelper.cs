using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Capstoneszn.Forms.UserControls.Utilities
{
    /// <summary>
    /// Shared electricity logic used by the Utilities tab grid, the owner card,
    /// and the Add Room form (to create a room's account automatically).
    /// </summary>
    internal class ElectricityHelper
    {
        /// <summary>
        /// Creates the electricity account for a newly added room.
        /// Call this right after the room INSERT, on the same connection/transaction.
        /// The building is looked up from the room's floor, so only the RoomId is needed.
        /// Does nothing if the room already has an account.
        /// </summary>
        public static void CreateRoomAccount(SqlConnection conn, SqlTransaction? tran,
                                             int roomId, string accountName, string accountNumber)
        {
            const string sql = @"
                IF NOT EXISTS (SELECT 1 FROM dbo.ElectricityAccounts WHERE RoomId = @RoomId)
                    INSERT INTO dbo.ElectricityAccounts (BuildingId, RoomId, AccountName, AccountNumber)
                    SELECT f.BuildingId, r.RoomId, @AccountName, @AccountNumber
                    FROM   dbo.Rooms  r
                    JOIN   dbo.Floors f ON f.FloorId = r.FloorId
                    WHERE  r.RoomId = @RoomId;";

            using var cmd = new SqlCommand(sql, conn, tran);
            cmd.Parameters.Add("@RoomId", SqlDbType.Int).Value = roomId;
            cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = (accountName ?? "").Trim();
            cmd.Parameters.Add("@AccountNumber", SqlDbType.VarChar, 50).Value = (accountNumber ?? "").Trim();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Saves (inserts or updates) one account's amount for a month.
        /// amount = null clears the amount (back to "No bill").
        /// Returns the ElectricityChargeId (> 0), 0 if nothing needed saving,
        /// or -1 if that month is already Paid (locked).
        /// </summary>
        public static int SaveAmount(int accountId, DateTime billingMonth, decimal? amount)
        {
            const string sql = @"
                DECLARE @Id INT, @Status VARCHAR(10);

                SELECT @Id = ElectricityChargeId, @Status = Status
                FROM   dbo.ElectricityCharges
                WHERE  ElectricityAccountId = @AccountId
                  AND  BillingMonth         = @Month;

                IF @Status = 'Paid'
                    SELECT -1;
                ELSE IF @Id IS NOT NULL
                BEGIN
                    UPDATE dbo.ElectricityCharges
                       SET Amount = @Amount
                     WHERE ElectricityChargeId = @Id
                       AND Status = 'Unpaid';
                    SELECT @Id;
                END
                ELSE IF @Amount IS NOT NULL
                BEGIN
                    INSERT INTO dbo.ElectricityCharges (ElectricityAccountId, BillingMonth, Amount)
                    VALUES (@AccountId, @Month, @Amount);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);
                END
                ELSE
                    SELECT 0;";

            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
            cmd.Parameters.Add("@Month", SqlDbType.Date).Value = new DateTime(billingMonth.Year, billingMonth.Month, 1);
            var p = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            p.Precision = 18; p.Scale = 2;
            p.Value = amount.HasValue ? amount.Value : DBNull.Value;

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        /// <summary>Parses "₱1,234.50", "1234.5" etc. Blank = null. Returns false if not a valid number.</summary>
        public static bool TryParseAmount(string? text, out decimal? amount)
        {
            amount = null;
            string clean = (text ?? "").Replace("₱", "").Replace(",", "").Trim();
            if (clean.Length == 0) return true;
            if (!decimal.TryParse(clean, out decimal value)) return false;
            amount = value;
            return true;
        }
    }

}
