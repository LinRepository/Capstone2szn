using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Capstoneszn.Forms.UtilityForms
{
    /// <summary>The building's electricity admin (owner) account: ElectricityAccounts row with RoomId = NULL.</summary>
    public sealed class ElectricityAdminAccountInfo
    {
        public int ElectricityAccountId;
        public int BuildingId;
        public string AccountName = "";
        public string AccountNumber = "";
    }

    public enum ElectricityAccountSaveResult
    {
        Created,    // building had no admin account yet
        Updated,    // name/number changed in place
        NoChange    // same name and number as before
    }

    /// <summary>
    /// Reads and saves the building's electricity admin account.
    /// The admin account is master data edited in place (no history): owner charges are
    /// recorded as expenses and keep pointing to the same ElectricityAccountId.
    /// One admin account per building is enforced by the existing UQ_ElecAcct_Owner index
    /// (unique BuildingId WHERE RoomId IS NULL).
    /// Room accounts are NOT handled here (ElectricityHelper.CreateRoomAccount creates them with the room).
    /// Used by Settings → Utilities Accounts (EditElectricityAccount) and AddBuildingForm.
    /// </summary>
    public static class ElectricityAccountHelper
    {
        // Match ElectricityHelper.CreateRoomAccount: NVARCHAR(100) name, VARCHAR(50) number
        public const int NameMaxLength = 100;
        public const int NumberMaxLength = 50;

        // ───────────────────────── Validation ─────────────────────────

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

        /// <summary>The building's admin account, or null if it hasn't been set up.</summary>
        public static ElectricityAdminAccountInfo? GetAdmin(int buildingId)
        {
            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            return GetAdmin(conn, null, buildingId, lockRow: false);
        }

        public static ElectricityAdminAccountInfo? GetAdmin(SqlConnection conn, SqlTransaction? tran,
            int buildingId, bool lockRow)
        {
            string sql = $@"
                SELECT ElectricityAccountId, BuildingId, AccountName, AccountNumber
                FROM   dbo.ElectricityAccounts {(lockRow ? "WITH (UPDLOCK, HOLDLOCK)" : "")}
                WHERE  BuildingId = @BuildingId
                  AND  RoomId IS NULL;";

            using var cmd = new SqlCommand(sql, conn, tran);
            cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = buildingId;

            using SqlDataReader rd = cmd.ExecuteReader();
            if (!rd.Read()) return null;

            return new ElectricityAdminAccountInfo
            {
                ElectricityAccountId = rd.GetInt32(0),
                BuildingId = rd.GetInt32(1),
                AccountName = rd.IsDBNull(2) ? "" : rd.GetString(2),
                AccountNumber = rd.IsDBNull(3) ? "" : rd.GetString(3)
            };
        }

        // ───────────────────────── Save ─────────────────────────

        /// <summary>Settings → Edit: opens its own connection and transaction.</summary>
        public static ElectricityAccountSaveResult Save(int buildingId, string name, string number)
        {
            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using SqlTransaction tran = conn.BeginTransaction();
            try
            {
                ElectricityAccountSaveResult result = Save(conn, tran, buildingId, name, number);
                tran.Commit();
                return result;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        /// <summary>Building creation: runs inside the caller's transaction.</summary>
        public static ElectricityAccountSaveResult Save(SqlConnection conn, SqlTransaction tran,
            int buildingId, string name, string number)
        {
            name = name?.Trim() ?? "";
            number = number?.Trim() ?? "";

            if (!Validate(name, number, out string error))
                throw new ArgumentException(error);

            ElectricityAdminAccountInfo? current = GetAdmin(conn, tran, buildingId, lockRow: true);

            // 1) First-time setup
            if (current == null)
            {
                using var ins = new SqlCommand(@"
                    INSERT INTO dbo.ElectricityAccounts (BuildingId, RoomId, AccountName, AccountNumber)
                    VALUES (@BuildingId, NULL, @Name, @Number);", conn, tran);
                ins.Parameters.Add("@BuildingId", SqlDbType.Int).Value = buildingId;
                ins.Parameters.Add("@Name", SqlDbType.NVarChar, NameMaxLength).Value = name;
                ins.Parameters.Add("@Number", SqlDbType.VarChar, NumberMaxLength).Value = number;
                ins.ExecuteNonQuery();
                return ElectricityAccountSaveResult.Created;
            }

            // 2) Nothing changed
            if (current.AccountName == name && current.AccountNumber == number)
                return ElectricityAccountSaveResult.NoChange;

            // 3) Edit in place (owner charges keep the same ElectricityAccountId)
            using var upd = new SqlCommand(@"
                UPDATE dbo.ElectricityAccounts
                   SET AccountName   = @Name,
                       AccountNumber = @Number
                 WHERE ElectricityAccountId = @Id;", conn, tran);
            upd.Parameters.Add("@Name", SqlDbType.NVarChar, NameMaxLength).Value = name;
            upd.Parameters.Add("@Number", SqlDbType.VarChar, NumberMaxLength).Value = number;
            upd.Parameters.Add("@Id", SqlDbType.Int).Value = current.ElectricityAccountId;
            upd.ExecuteNonQuery();
            return ElectricityAccountSaveResult.Updated;
        }
    }
}
