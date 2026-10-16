using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UtilityForms
{
    public sealed class PreviewRow
    {
        public int RoomID;
        public string RoomNumber = "";
        public int TenantID;
        public string TenantName = "";
        public decimal Amount;
    }

    public static class WaterBillHelper
    {
        public const string Category = "Water";

        // Default: admin is one more head (n + 1). Custom: tenants split what's left (n).
        // Either way the leftover centavos land on the admin.
        public static (decimal perTenant, decimal adminAmount) Calculate(
            decimal total, int tenantCount, bool isDefaultShare, decimal customAdmin)
        {
            if (total <= 0 || tenantCount <= 0) return (0m, Math.Max(total, 0m));

            decimal pool = isDefaultShare ? total : total - customAdmin;
            int divisor = isDefaultShare ? tenantCount + 1 : tenantCount;
            if (pool <= 0) return (0m, total);

            decimal perTenant = Math.Floor(pool / divisor * 100m) / 100m;
            return (perTenant, total - perTenant * tenantCount);
        }

        // Who gets billed: active, this building, moved in by the end of the month
        public static List<PreviewRow> LoadActiveTenants(SqlConnection conn, SqlTransaction? tran, DateTime monthStart)
        {
            const string sql = @"
                SELECT tn.TenantId, tn.RoomId, r.RoomNumber,
                       t.LastName + ', ' + t.FirstName AS TenantName
                FROM   dbo.Tenancies tn
                INNER JOIN dbo.Tenants t ON t.TenantId = tn.TenantId
                INNER JOIN dbo.Rooms   r ON r.RoomId   = tn.RoomId
                INNER JOIN dbo.Floors  f ON f.FloorId  = r.FloorId
                WHERE  f.BuildingId  = @BuildingId
                  AND  tn.Status     = 'Active'
                  AND  tn.MoveInDate <= @MonthStart          -- billing cutoff (same as the grid)
                ORDER BY r.RoomNumber, t.LastName, t.FirstName;";

            var rows = new List<PreviewRow>();
            using var cmd = new SqlCommand(sql, conn, tran);
            AddScope(cmd, monthStart);
            cmd.Parameters.Add("@MonthEnd", SqlDbType.Date).Value = monthStart.AddMonths(1).AddDays(-1);

            using SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                rows.Add(new PreviewRow
                {
                    TenantID = rd.GetInt32(0),
                    RoomID = rd.GetInt32(1),
                    RoomNumber = rd.GetString(2),
                    TenantName = rd.GetString(3)
                });
            }
            return rows;
        }

        // Lock: any payment against this month's water bills (voided ones too,
        // since they still point at the bill and would block Edit's delete)
        public static bool HasTenantPayments(SqlConnection conn, SqlTransaction? tran, DateTime monthStart)
        {
            const string sql = @"
                SELECT CASE WHEN EXISTS (
                    SELECT 1
                    FROM   dbo.PaymentAllocations a
                    INNER JOIN dbo.Bills  b ON b.BillId  = a.BillId
                    INNER JOIN dbo.Rooms  r ON r.RoomId  = b.RoomId
                    INNER JOIN dbo.Floors f ON f.FloorId = r.FloorId
                    WHERE  f.BuildingId         = @BuildingId
                      AND  b.BillCategory       = @Category
                      AND  b.BillingPeriodStart = @MonthStart)
                THEN 1 ELSE 0 END;";

            using var cmd = new SqlCommand(sql, conn, tran);
            AddScope(cmd, monthStart);
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

        // Tenant side: one Bills row per room, one BillTenants row per head
        public static void InsertTenantBills(SqlConnection conn, SqlTransaction tran,
            DateTime monthStart, DateTime dueDate, List<PreviewRow> rows)
        {
            DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);

            foreach (var room in rows.GroupBy(r => r.RoomID))
            {
                int billId;
                using (var cmd = new SqlCommand(@"
                    INSERT INTO dbo.Bills (RoomId, BillCategory, BillingPeriodStart, BillingPeriodEnd, DueDate, Amount)
                    OUTPUT INSERTED.BillId
                    VALUES (@RoomId, @Category, @Start, @End, @Due, @Amount);", conn, tran))
                {
                    cmd.Parameters.Add("@RoomId", SqlDbType.Int).Value = room.Key;
                    cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 30).Value = Category;
                    cmd.Parameters.Add("@Start", SqlDbType.Date).Value = monthStart;
                    cmd.Parameters.Add("@End", SqlDbType.Date).Value = monthEnd;
                    cmd.Parameters.Add("@Due", SqlDbType.Date).Value = dueDate;
                    AddMoney(cmd, "@Amount", room.Sum(r => r.Amount));
                    billId = (int)cmd.ExecuteScalar();
                }

                foreach (var t in room)
                {
                    using var cmd = new SqlCommand(
                        "INSERT INTO dbo.BillTenants (BillId, TenantId, Share) VALUES (@BillId, @TenantId, @Share);",
                        conn, tran);
                    cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = billId;
                    cmd.Parameters.Add("@TenantId", SqlDbType.Int).Value = t.TenantID;
                    AddMoney(cmd, "@Share", t.Amount);
                    cmd.ExecuteNonQuery();

                    ConsumeCredit(conn, tran, t.TenantID, billId, t.Amount);   // ← NEW
                }
            }
        }
        /// <summary>
        /// Moves a tenant's held Water credit onto a newly created water bill.
        /// Same rules as BillGenerator.ConsumeCredit (rent):
        ///   credit row fits inside the share -> repoint the row at the bill
        ///   credit row is larger             -> shrink it, add a settled row for the used part
        /// Oldest credit first; forfeited credit is skipped.
        /// </summary>
        public static void ConsumeCredit(SqlConnection conn, SqlTransaction tran,
            int tenantId, int billId, decimal share)
        {
            decimal remaining = share;

            decimal toSkip;
            using (var cmd = new SqlCommand(@"
                SELECT ISNULL(SUM(adj.Amount), 0)
                FROM   TenantAdjustments adj
                WHERE  adj.TenantId = @tid
                  AND  adj.AdjustmentType = 'Forfeit'
                  AND  adj.BillCategory = @cat;", conn, tran))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = Category;
                toSkip = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            var credits = new List<(int AllocationId, int PaymentId, decimal Amount)>();

            using (var cmd = new SqlCommand(@"
                SELECT a.AllocationId, a.PaymentId, a.Amount
                FROM   PaymentAllocations a
                JOIN   Payments p ON p.PaymentId = a.PaymentId
                WHERE  a.TenantId = @tid
                  AND  a.BillId IS NULL
                  AND  a.IsVoided = 0
                  AND  p.IsVoided = 0
                  AND  p.PaymentCategory = @cat
                ORDER BY a.AllocationId ASC;", conn, tran))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = Category;
                using SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                    credits.Add((rd.GetInt32(0), rd.GetInt32(1), rd.GetDecimal(2)));
            }

            foreach (var credit in credits)
            {
                if (remaining <= 0m) break;

                decimal usable = credit.Amount;
                if (toSkip > 0m)
                {
                    decimal skip = Math.Min(toSkip, usable);
                    usable -= skip;
                    toSkip -= skip;
                }
                if (usable <= 0m) continue;

                if (usable == credit.Amount && credit.Amount <= remaining)
                {
                    // Whole credit row goes to this bill
                    using var cmd = new SqlCommand(
                        "UPDATE PaymentAllocations SET BillId = @bid WHERE AllocationId = @aid;",
                        conn, tran);
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                    cmd.Parameters.Add("@aid", SqlDbType.Int).Value = credit.AllocationId;
                    cmd.ExecuteNonQuery();

                    remaining -= credit.Amount;
                }
                else
                {
                    // Use part of it: shrink the credit row, add a settled row for the used piece
                    decimal used = Math.Min(usable, remaining);

                    using (var cmd = new SqlCommand(
                        "UPDATE PaymentAllocations SET Amount = Amount - @used WHERE AllocationId = @aid;",
                        conn, tran))
                    {
                        AddMoney(cmd, "@used", used);
                        cmd.Parameters.Add("@aid", SqlDbType.Int).Value = credit.AllocationId;
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new SqlCommand(@"
                        INSERT INTO PaymentAllocations (PaymentId, BillId, TenantId, Amount)
                        VALUES (@pid, @bid, @tid, @amt);", conn, tran))
                    {
                        cmd.Parameters.Add("@pid", SqlDbType.Int).Value = credit.PaymentId;
                        cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                        AddMoney(cmd, "@amt", used);
                        cmd.ExecuteNonQuery();
                    }

                    remaining -= used;
                }
            }
        }

        public static void DeleteTenantBills(SqlConnection conn, SqlTransaction tran, DateTime monthStart)
        {
            const string sql = @"
                DELETE bt
                FROM   dbo.BillTenants bt
                INNER JOIN dbo.Bills  b ON b.BillId  = bt.BillId
                INNER JOIN dbo.Rooms  r ON r.RoomId  = b.RoomId
                INNER JOIN dbo.Floors f ON f.FloorId = r.FloorId
                WHERE  f.BuildingId = @BuildingId AND b.BillCategory = @Category
                  AND  b.BillingPeriodStart = @MonthStart;

                DELETE b
                FROM   dbo.Bills b
                INNER JOIN dbo.Rooms  r ON r.RoomId  = b.RoomId
                INNER JOIN dbo.Floors f ON f.FloorId = r.FloorId
                WHERE  f.BuildingId = @BuildingId AND b.BillCategory = @Category
                  AND  b.BillingPeriodStart = @MonthStart;";

            using var cmd = new SqlCommand(sql, conn, tran);
            AddScope(cmd, monthStart);
            cmd.ExecuteNonQuery();
        }

        // UI bits both forms share
        public static void FillPreviewGrid(DataGridView dgv, List<PreviewRow> rows, decimal adminAmount)
        {
            dgv.Rows.Clear();
            foreach (var r in rows)
                dgv.Rows.Add(r.RoomNumber, r.TenantName, r.Amount.ToString("₱#,##0.00"));

            if (rows.Count > 0)
                dgv.Rows.Add("—", "Owner (Landlord)", adminAmount.ToString("₱#,##0.00"));
        }

        public static void MoneyKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && sender is TextBox tb && !tb.Text.Contains('.')) return;
            e.Handled = true;   // block letters, symbols, a second dot
        }

        public static void AddMoney(SqlCommand cmd, string name, decimal value)
        {
            var p = cmd.Parameters.Add(name, SqlDbType.Decimal);
            p.Precision = 18;
            p.Scale = 2;
            p.Value = value;
        }

        private static void AddScope(SqlCommand cmd, DateTime monthStart)
        {
            cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
            cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 30).Value = Category;
            cmd.Parameters.Add("@MonthStart", SqlDbType.Date).Value = monthStart;
        }
    }
}