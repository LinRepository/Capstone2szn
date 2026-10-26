using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Utilities
{
    /// <summary>The building's water provider account (one active row per building).</summary>
    public sealed class WaterAccountInfo
    {
        public int WaterAccountId;
        public int BuildingId;
        public string AccountName = "";
        public string AccountNumber = "";
    }
    public enum WaterAccountSaveResult
    {
        Created,          // building had no account yet
        Updated,          // corrected in place (no bills used the old details)
        Replaced,         // old account deactivated, new one inserted (bills keep the old one)
        NoChange,         // same name and number as before
        DuplicateNumber   // number is already active on another building
    }
    internal class WaterAccountHelper
    {
        public const int NameMaxLength = 100;    // matches WaterAccounts.AccountName
        public const int NumberMaxLength = 50;   // matches WaterAccounts.AccountNumber

        // ───────────────────────── Validation ─────────────────────────

        /// <summary>Same rules as the CHECK constraints on dbo.WaterAccounts.</summary>
        public static bool Validate(string? name, string? number, out string error)
        {
            name = name?.Trim() ?? "";
            number = number?.Trim() ?? "";

            if (name.Length == 0) { error = "Enter the account name."; return false; }
            if (name.Length > NameMaxLength) { error = $"Account name can't be longer than {NameMaxLength} characters."; return false; }
            if (number.Length == 0) { error = "Enter the account number."; return false; }
            if (number.Length > NumberMaxLength) { error = $"Account number can't be longer than {NumberMaxLength} characters."; return false; }

            foreach (char c in number)
            {
                // plain 0-9 only (char.IsDigit would also accept non-Latin digits the database rejects)
                if (!(c >= '0' && c <= '9') && c != '-')
                {
                    error = "Account number can only contain digits and dashes.";
                    return false;
                }
            }

            error = "";
            return true;
        }

        // ───────────────────────── Read ─────────────────────────

        /// <summary>The building's active water account, or null if it hasn't been set up.</summary>
        public static WaterAccountInfo? GetActive(int buildingId)
        {
            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            return GetActive(conn, null, buildingId, lockRow: false);
        }

        public static WaterAccountInfo? GetActive(SqlConnection conn, SqlTransaction? tran,
            int buildingId, bool lockRow)
        {
            // UPDLOCK/HOLDLOCK keeps two saves for the same building from racing each other
            string sql = $@"
                SELECT WaterAccountId, BuildingId, AccountName, AccountNumber
                FROM   dbo.WaterAccounts {(lockRow ? "WITH (UPDLOCK, HOLDLOCK)" : "")}
                WHERE  BuildingId = @BuildingId
                  AND  IsActive   = 1;";

            using var cmd = new SqlCommand(sql, conn, tran);
            cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = buildingId;

            using SqlDataReader rd = cmd.ExecuteReader();
            if (!rd.Read()) return null;

            return new WaterAccountInfo
            {
                WaterAccountId = rd.GetInt32(0),
                BuildingId = rd.GetInt32(1),
                AccountName = rd.GetString(2),
                AccountNumber = rd.GetString(3)
            };
        }

        /// <summary>
        /// True if the active account already has water bills (linked, or recorded before
        /// linking existed). The edit dialog uses this to warn that past bills keep the old details.
        /// </summary>
        public static bool ActiveAccountHasBills(int buildingId)
        {
            const string sql = @"
                SELECT CASE WHEN EXISTS (
                    SELECT 1
                    FROM   dbo.WaterBills wb
                    INNER JOIN dbo.WaterAccounts wa
                           ON wa.BuildingId = wb.BuildingId AND wa.IsActive = 1
                    WHERE  wb.BuildingId = @BuildingId
                      AND (wb.WaterAccountId = wa.WaterAccountId OR wb.WaterAccountId IS NULL))
                THEN 1 ELSE 0 END;";

            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = buildingId;
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

        // ───────────────────────── Save ─────────────────────────

        /// <summary>Settings → Edit: opens its own connection and transaction.</summary>
        public static WaterAccountSaveResult Save(int buildingId, string name, string number)
        {
            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using SqlTransaction tran = conn.BeginTransaction();
            try
            {
                WaterAccountSaveResult result = Save(conn, tran, buildingId, name, number);
                tran.Commit();
                return result;
            }
            catch (SqlException ex) when (IsDuplicateNumber(ex))
            {
                tran.Rollback();
                return WaterAccountSaveResult.DuplicateNumber;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Building creation: runs inside the caller's transaction so the building and its
        /// water account are saved together. A duplicate number throws SqlException here;
        /// use IsDuplicateNumber(ex) to show a friendly message.
        /// </summary>
        public static WaterAccountSaveResult Save(SqlConnection conn, SqlTransaction tran,
            int buildingId, string name, string number)
        {
            name = name?.Trim() ?? "";
            number = number?.Trim() ?? "";

            if (!Validate(name, number, out string error))
                throw new ArgumentException(error);

            WaterAccountInfo? current = GetActive(conn, tran, buildingId, lockRow: true);

            // 1) First-time setup
            if (current == null)
            {
                int newId = Insert(conn, tran, buildingId, name, number);
                LinkUnlinkedBills(conn, tran, buildingId, newId);   // older bills belong to this account
                return WaterAccountSaveResult.Created;
            }

            // 2) Nothing changed
            if (current.AccountName == name && current.AccountNumber == number)
                return WaterAccountSaveResult.NoChange;

            // Any bill recorded without an account was billed under the current one
            LinkUnlinkedBills(conn, tran, buildingId, current.WaterAccountId);

            // 3) No bills use it yet → it's a correction, update in place
            if (!HasLinkedBills(conn, tran, current.WaterAccountId))
            {
                using var cmd = new SqlCommand(@"
                    UPDATE dbo.WaterAccounts
                       SET AccountName   = @Name,
                           AccountNumber = @Number
                     WHERE WaterAccountId = @Id;", conn, tran);
                AddText(cmd, "@Name", NameMaxLength, name);
                AddText(cmd, "@Number", NumberMaxLength, number);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = current.WaterAccountId;
                cmd.ExecuteNonQuery();
                return WaterAccountSaveResult.Updated;
            }

            // 4) Bills use it → keep history: deactivate first (frees the unique indexes), then insert
            using (var cmd = new SqlCommand(
                "UPDATE dbo.WaterAccounts SET IsActive = 0 WHERE WaterAccountId = @Id;", conn, tran))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = current.WaterAccountId;
                cmd.ExecuteNonQuery();
            }

            Insert(conn, tran, buildingId, name, number);
            return WaterAccountSaveResult.Replaced;
        }

        /// <summary>True when the error is the "account number already active elsewhere" index.</summary>
        public static bool IsDuplicateNumber(SqlException ex) =>
            (ex.Number == 2601 || ex.Number == 2627)
            && ex.Message.Contains("UX_WaterAccounts_ActiveNumber");


        //New
        /// <summary>True if this number is already the active water account of any building.</summary>
        public static bool IsActiveNumberInUse(string number)
        {
            const string sql = @"
                SELECT CASE WHEN EXISTS (
                    SELECT 1 FROM dbo.WaterAccounts
                    WHERE  AccountNumber = @Number AND IsActive = 1)
                THEN 1 ELSE 0 END;";

            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            AddText(cmd, "@Number", NumberMaxLength, number.Trim());
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

        /// <summary>Digits, dashes and editing keys only (shared by every account-number box).</summary>
        public static void AccountNumberKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '-')
                return;
            e.Handled = true;
        }
        //Hanggang dito



        // ───────────────────────── Private ─────────────────────────

        private static int Insert(SqlConnection conn, SqlTransaction tran,
            int buildingId, string name, string number)
        {
            using var cmd = new SqlCommand(@"
                INSERT INTO dbo.WaterAccounts (BuildingId, AccountName, AccountNumber, IsActive)
                OUTPUT INSERTED.WaterAccountId
                VALUES (@BuildingId, @Name, @Number, 1);", conn, tran);
            cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = buildingId;
            AddText(cmd, "@Name", NameMaxLength, name);
            AddText(cmd, "@Number", NumberMaxLength, number);
            return (int)cmd.ExecuteScalar();
        }

        private static void LinkUnlinkedBills(SqlConnection conn, SqlTransaction tran,
            int buildingId, int waterAccountId)
        {
            using var cmd = new SqlCommand(@"
                UPDATE dbo.WaterBills
                   SET WaterAccountId = @AccountId
                 WHERE BuildingId = @BuildingId
                   AND WaterAccountId IS NULL;", conn, tran);
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = waterAccountId;
            cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = buildingId;
            cmd.ExecuteNonQuery();
        }

        private static bool HasLinkedBills(SqlConnection conn, SqlTransaction tran, int waterAccountId)
        {
            using var cmd = new SqlCommand(@"
                SELECT CASE WHEN EXISTS (
                    SELECT 1 FROM dbo.WaterBills WHERE WaterAccountId = @Id)
                THEN 1 ELSE 0 END;", conn, tran);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = waterAccountId;
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

        private static void AddText(SqlCommand cmd, string name, int size, string value) =>
            cmd.Parameters.Add(name, SqlDbType.NVarChar, size).Value = value;
    }
}
