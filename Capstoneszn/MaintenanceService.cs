using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{

    /// <summary>
    /// One row of the Maintenance list - what a card displays.
    /// </summary>
    public class MaintenanceIssueSummary
    {
        public int IssueId { get; set; }
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string IssueTitle { get; set; }
        public string Description { get; set; }
        public DateTime DateReported { get; set; }
        public string Status { get; set; }
        public string Responsible { get; set; }

        public bool IsPending => Status == MaintenanceService.StatusPending;
    }

    /// <summary>
    /// A simple id + display text pair for combo boxes and checked lists.
    /// ToString() is what the control displays.
    /// </summary>
    public class LookupItem
    {
        public int Id { get; }
        public string Text { get; }

        public LookupItem(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public override string ToString() => Text;
    }

    /// <summary>
    /// One person who can be Responsible: the owner (no Employees row)
    /// or a caretaker. Matches CK_MaintResp_Who.
    /// </summary>
    public class ResponsibleOption
    {
        public bool IsOwner { get; }
        public int? EmployeeId { get; }
        public string Name { get; }

        public ResponsibleOption(bool isOwner, int? employeeId, string name)
        {
            IsOwner = isOwner;
            EmployeeId = employeeId;
            Name = name;
        }

        public override string ToString() => IsOwner ? "Owner" : Name;
    }

    /// <summary>
    /// The few facts a form needs about one issue: where it is, what it is,
    /// and whether it can still be changed.
    /// </summary>
    public class MaintenanceIssueHeader
    {
        public int IssueId { get; set; }
        public string RoomNumber { get; set; }
        public string IssueTitle { get; set; }
        public string Status { get; set; }

        public bool IsPending => Status == MaintenanceService.StatusPending;
    }

    /// <summary>
    /// Everything the Details form shows about one issue.
    /// AffectedTenants is empty when nobody is charged (building expense).
    /// </summary>
    public class MaintenanceIssueDetails
    {
        public int IssueId { get; set; }
        public string RoomNumber { get; set; }
        public string IssueTitle { get; set; }
        public string Description { get; set; }
        public DateTime DateReported { get; set; }
        public string Status { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string AffectedTenants { get; set; }
        public string Responsible { get; set; }

        public bool IsPending => Status == MaintenanceService.StatusPending;
    }

    /// <summary>
    /// The editable fields of one issue, loaded into EditIssueForm.
    /// </summary>
    public class MaintenanceIssueEdit
    {
        public int IssueId { get; set; }
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string IssueTitle { get; set; }
        public string Description { get; set; }
        public DateTime DateReported { get; set; }
        public string Status { get; set; }

        public bool IsPending => Status == MaintenanceService.StatusPending;
    }

    /// <summary>
    /// A tenant shown in EditIssueForm's checklist. A tenant who is already
    /// on the issue but has since moved out is still listed (IsCurrent =
    /// false) so the landlord can see them and remove them.
    /// </summary>
    public class TenantChoice
    {
        public int TenantId { get; set; }
        public string Name { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsAffected { get; set; }

        public override string ToString() => IsCurrent ? Name : Name + " (moved out)";
    }

    /// <summary>
    /// A responsible person shown in EditIssueForm's checklist. A caretaker
    /// already on the issue who is now inactive or archived stays listed
    /// (IsActive = false) so history is not silently lost.
    /// </summary>
    public class ResponsibleChoice
    {
        public bool IsOwner { get; set; }
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }

        public override string ToString() =>
            IsOwner ? "Owner" : (IsActive ? Name : Name + " (inactive)");
    }

    /// <summary>
    /// What happened when an issue was saved. When Completed is true, exactly
    /// one of these is the outcome: a bill for the tenants, a building
    /// expense, or nothing (no materials).
    /// </summary>
    public class IssueSaveResult
    {
        public bool Completed { get; set; }
        public decimal MaterialsTotal { get; set; }
        public int TenantsCharged { get; set; }
        public bool ExpenseRecorded { get; set; }
        public DateTime? DueDate { get; set; }
    }

    /// <summary>
    /// One material row. TotalCost is computed (Quantity x UnitPrice),
    /// never stored, so it can never disagree with its parts.
    /// </summary>
    public class MaintenanceMaterial
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TotalCost => Quantity * UnitPrice;
    }

    /// <summary>
    /// Database access for the Maintenance module. The forms call these
    /// methods; no SQL lives in the forms themselves.
    ///
    /// Rules this class follows:
    ///   - Soft delete: IsDeleted = 1 rows never appear anywhere.
    ///   - Building scope: an issue belongs to the building of its room.
    ///   - Status values match CK_MaintIssues_Status exactly:
    ///     'Pending' and 'Complete' (not "Completed").
    /// </summary>
    public static class MaintenanceService
    {
        public const string StatusPending = "Pending";
        public const string StatusComplete = "Complete";

        /// <summary>
        /// Issues for one building. statusFilter = "Pending", "Complete",
        /// or null for all. Pending first, then newest first.
        /// </summary>
        public static List<MaintenanceIssueSummary> GetIssues(int buildingId, string statusFilter)
        {
            var list = new List<MaintenanceIssueSummary>();

            // Responsible is built from MaintenanceResponsible:
            // the owner row (IsOwner = 1) shows as "Owner", employee rows show
            // the employee's name. No rows at all = "None".
            string sql = @"
                SELECT mi.IssueId, mi.RoomId, r.RoomNumber, mi.IssueTitle,
                       mi.Description, mi.DateReported, mi.Status,
                       ISNULL((SELECT STRING_AGG(CASE WHEN mr.IsOwner = 1
                                                      THEN N'Owner'
                                                      ELSE e.FullName END, N', ')
                                      WITHIN GROUP (ORDER BY mr.IsOwner DESC, e.FullName)
                               FROM   MaintenanceResponsible mr
                               LEFT JOIN Employees e ON e.EmployeeId = mr.EmployeeId
                               WHERE  mr.IssueId = mi.IssueId), N'None') AS Responsible
                FROM   MaintenanceIssues mi
                JOIN   Rooms r ON r.RoomId = mi.RoomId
                WHERE  r.BuildingId = @bid
                  AND  mi.IsDeleted = 0
                  AND  (@status IS NULL OR mi.Status = @status)
                ORDER BY CASE mi.Status WHEN 'Pending' THEN 0 ELSE 1 END,
                         mi.DateReported DESC, mi.IssueId DESC;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bid", buildingId);
                cmd.Parameters.AddWithValue("@status",
                    string.IsNullOrEmpty(statusFilter) ? (object)DBNull.Value : statusFilter);

                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new MaintenanceIssueSummary
                        {
                            IssueId = rd.GetInt32(0),
                            RoomId = rd.GetInt32(1),
                            RoomNumber = rd.GetString(2),
                            IssueTitle = rd.GetString(3),
                            Description = rd.IsDBNull(4) ? "" : rd.GetString(4),
                            DateReported = rd.GetDateTime(5),
                            Status = rd.GetString(6),
                            Responsible = rd.GetString(7)
                        });
                    }
                }
            }

            return list;
        }

        /* =================================================================
           ADD ISSUE
           ================================================================= */

        /// <summary>
        /// Every non-archived room in the building, including vacant and
        /// Unconfigured ones, ordered by floor then room number.
        /// </summary>
        public static List<LookupItem> GetRoomsForIssue(int buildingId)
        {
            var list = new List<LookupItem>();

            string sql = @"
                SELECT r.RoomId, r.RoomNumber
                FROM   Rooms r
                JOIN   Floors f ON f.FloorId = r.FloorId
                WHERE  r.BuildingId = @bid
                  AND  r.IsArchived = 0
                ORDER BY f.FloorNumber, TRY_CAST(r.RoomNumber AS INT), r.RoomNumber;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bid", buildingId);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(new LookupItem(rd.GetInt32(0), "Room " + rd.GetString(1)));
                }
            }

            return list;
        }

        /// <summary>
        /// The room's current tenants (active tenancies), longest-tenured first.
        /// These are the only people who can be charged for the issue.
        /// </summary>
        public static List<LookupItem> GetActiveTenantsInRoom(int roomId)
        {
            var list = new List<LookupItem>();

            string sql = @"
                SELECT t.TenantId, t.FirstName + N' ' + t.LastName
                FROM   Tenancies tn
                JOIN   Tenants t ON t.TenantId = tn.TenantId
                WHERE  tn.RoomId = @rid
                  AND  tn.Status = 'Active'
                ORDER BY tn.MoveInDate, t.TenantId;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@rid", roomId);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(new LookupItem(rd.GetInt32(0), rd.GetString(1)));
                }
            }

            return list;
        }

        /// <summary>
        /// The owner first, then the building's Active, non-archived caretakers.
        /// "All" in the Responsible group means exactly this list.
        /// </summary>
        public static List<ResponsibleOption> GetResponsibleOptions(int buildingId)
        {
            var list = new List<ResponsibleOption>
            {
                new ResponsibleOption(true, null, "Owner")
            };

            string sql = @"
                SELECT EmployeeId, FullName
                FROM   Employees
                WHERE  BuildingId = @bid
                  AND  EmploymentStatus = 'Active'
                  AND  ArchivedAt IS NULL
                ORDER BY FullName;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@bid", buildingId);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(new ResponsibleOption(false, rd.GetInt32(0), rd.GetString(1)));
                }
            }

            return list;
        }

        /// <summary>
        /// Saves a new issue with its affected tenants and responsible people
        /// in ONE transaction - all of it lands, or none of it does.
        /// Status starts as Pending, which turns the room grey (vwRoomStatus).
        /// Returns the new IssueId.
        /// </summary>
        public static int AddIssue(
            int roomId,
            string issueTitle,
            string description,
            DateTime dateReported,
            IList<int> affectedTenantIds,
            bool ownerResponsible,
            IList<int> responsibleEmployeeIds,
            int createdBy)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // ---- 1. The issue ----------------------------------
                        int issueId;
                        string issueSql = @"
                            INSERT INTO MaintenanceIssues
                                (RoomId, IssueTitle, Description, DateReported, Status, CreatedBy)
                            OUTPUT INSERTED.IssueId
                            VALUES (@rid, @title, @desc, @date, @status, @by);";

                        using (var cmd = new SqlCommand(issueSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", roomId);
                            cmd.Parameters.AddWithValue("@title", issueTitle);
                            cmd.Parameters.AddWithValue("@desc",
                                string.IsNullOrWhiteSpace(description)
                                    ? (object)DBNull.Value : description);
                            cmd.Parameters.AddWithValue("@date", dateReported.Date);
                            cmd.Parameters.AddWithValue("@status", StatusPending);
                            cmd.Parameters.AddWithValue("@by", createdBy);
                            issueId = (int)cmd.ExecuteScalar();
                        }

                        // ---- 2. Affected tenants ---------------------------
                        // Inserted only if the tenant is STILL active in this
                        // room at the moment of saving. If someone moved out
                        // while the form was open, nothing is saved.
                        string tenantSql = @"
                            INSERT INTO MaintenanceAffectedTenants (IssueId, TenantId)
                            SELECT @iid, tn.TenantId
                            FROM   Tenancies tn
                            WHERE  tn.TenantId = @tid
                              AND  tn.RoomId   = @rid
                              AND  tn.Status   = 'Active';";

                        foreach (int tenantId in affectedTenantIds)
                        {
                            using (var cmd = new SqlCommand(tenantSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@iid", issueId);
                                cmd.Parameters.AddWithValue("@tid", tenantId);
                                cmd.Parameters.AddWithValue("@rid", roomId);

                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new InvalidOperationException(
                                        "A selected tenant is no longer in this room. " +
                                        "Reopen the form and choose again.");
                            }
                        }

                        // ---- 3. Responsible --------------------------------
                        string respSql = @"
                            INSERT INTO MaintenanceResponsible (IssueId, EmployeeId, IsOwner)
                            VALUES (@iid, @eid, @owner);";

                        if (ownerResponsible)
                        {
                            using (var cmd = new SqlCommand(respSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@iid", issueId);
                                cmd.Parameters.AddWithValue("@eid", DBNull.Value);
                                cmd.Parameters.AddWithValue("@owner", 1);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        foreach (int employeeId in responsibleEmployeeIds)
                        {
                            using (var cmd = new SqlCommand(respSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@iid", issueId);
                                cmd.Parameters.AddWithValue("@eid", employeeId);
                                cmd.Parameters.AddWithValue("@owner", 0);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleMaintenance, "Add Issue",
                            "Room " + GetRoomNumber(conn, tx, roomId) + " - " + issueTitle +
                            " (" + affectedTenantIds.Count + " affected tenant(s))");

                        tx.Commit();
                        return issueId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        /* =================================================================
           ISSUE HEADER (shared by the materials, details and edit forms)
           ================================================================= */

        /// <summary>
        /// Room, title and status of one issue. Returns null if the issue
        /// does not exist or was deleted.
        /// </summary>
        public static MaintenanceIssueHeader GetIssueHeader(int issueId)
        {
            string sql = @"
                SELECT mi.IssueId, r.RoomNumber, mi.IssueTitle, mi.Status
                FROM   MaintenanceIssues mi
                JOIN   Rooms r ON r.RoomId = mi.RoomId
                WHERE  mi.IssueId = @iid
                  AND  mi.IsDeleted = 0;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@iid", issueId);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;

                    return new MaintenanceIssueHeader
                    {
                        IssueId = rd.GetInt32(0),
                        RoomNumber = rd.GetString(1),
                        IssueTitle = rd.GetString(2),
                        Status = rd.GetString(3)
                    };
                }
            }
        }

        /// <summary>
        /// Full read-only view of one issue for the Details form.
        /// Returns null if the issue does not exist or was deleted.
        /// </summary>
        public static MaintenanceIssueDetails GetIssueDetails(int issueId)
        {
            string sql = @"
                SELECT mi.IssueId, r.RoomNumber, mi.IssueTitle, mi.Description,
                       mi.DateReported, mi.Status, mi.CompletedAt,
                       ISNULL((SELECT STRING_AGG(t.FirstName + N' ' + t.LastName, N', ')
                                      WITHIN GROUP (ORDER BY t.LastName, t.FirstName)
                               FROM   MaintenanceAffectedTenants mat
                               JOIN   Tenants t ON t.TenantId = mat.TenantId
                               WHERE  mat.IssueId = mi.IssueId), N'') AS AffectedTenants,
                       ISNULL((SELECT STRING_AGG(CASE WHEN mr.IsOwner = 1
                                                      THEN N'Owner'
                                                      ELSE e.FullName END, N', ')
                                      WITHIN GROUP (ORDER BY mr.IsOwner DESC, e.FullName)
                               FROM   MaintenanceResponsible mr
                               LEFT JOIN Employees e ON e.EmployeeId = mr.EmployeeId
                               WHERE  mr.IssueId = mi.IssueId), N'None') AS Responsible
                FROM   MaintenanceIssues mi
                JOIN   Rooms r ON r.RoomId = mi.RoomId
                WHERE  mi.IssueId = @iid
                  AND  mi.IsDeleted = 0;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@iid", issueId);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;

                    return new MaintenanceIssueDetails
                    {
                        IssueId = rd.GetInt32(0),
                        RoomNumber = rd.GetString(1),
                        IssueTitle = rd.GetString(2),
                        Description = rd.IsDBNull(3) ? "" : rd.GetString(3),
                        DateReported = rd.GetDateTime(4),
                        Status = rd.GetString(5),
                        CompletedAt = rd.IsDBNull(6) ? (DateTime?)null : rd.GetDateTime(6),
                        AffectedTenants = rd.GetString(7),
                        Responsible = rd.GetString(8)
                    };
                }
            }
        }

        /* =================================================================
           MATERIALS
           Materials can only be added or removed while the issue is
           Pending. At Complete their total becomes a bill or an expense,
           so after that they are frozen. The rule is checked inside the
           SQL itself, not only by the buttons, so a stale form can never
           change a completed issue.
           ================================================================= */

        public static List<MaintenanceMaterial> GetMaterials(int issueId)
        {
            var list = new List<MaintenanceMaterial>();

            string sql = @"
                SELECT MaterialId, MaterialName, Quantity, UnitPrice
                FROM   MaintenanceMaterials
                WHERE  IssueId = @iid
                ORDER BY MaterialId;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@iid", issueId);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new MaintenanceMaterial
                        {
                            MaterialId = rd.GetInt32(0),
                            MaterialName = rd.GetString(1),
                            Quantity = rd.GetInt32(2),
                            UnitPrice = rd.GetDecimal(3)
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Adds a material to a Pending issue. Throws InvalidOperationException
        /// if the issue is no longer Pending (or was deleted).
        /// </summary>
        public static void AddMaterial(int issueId, string materialName, int quantity, decimal unitPrice)
        {
            string sql = @"
                INSERT INTO MaintenanceMaterials (IssueId, MaterialName, Quantity, UnitPrice)
                SELECT @iid, @name, @qty, @price
                WHERE EXISTS (SELECT 1 FROM MaintenanceIssues
                              WHERE IssueId = @iid
                                AND Status = 'Pending'
                                AND IsDeleted = 0);";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@iid", issueId);
                cmd.Parameters.AddWithValue("@name", materialName);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@price", unitPrice);
                conn.Open();

                if (cmd.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException(
                        "This issue is no longer pending, so its materials can't be changed.");
            }
        }

        /// <summary>
        /// Removes a mistyped material from a Pending issue.
        /// This is a real DELETE, not a soft delete: while the issue is
        /// Pending no bill or expense exists yet, so the row has no history
        /// worth keeping - it is a correction, not a record.
        /// </summary>
        public static void RemoveMaterial(int materialId)
        {
            string sql = @"
                DELETE mm
                FROM   MaintenanceMaterials mm
                JOIN   MaintenanceIssues mi ON mi.IssueId = mm.IssueId
                WHERE  mm.MaterialId = @mid
                  AND  mi.Status = 'Pending'
                  AND  mi.IsDeleted = 0;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@mid", materialId);
                conn.Open();

                if (cmd.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException(
                        "This material can't be removed. The issue may no longer be pending.");
            }
        }

        /* =================================================================
           DELETE (soft)
           ================================================================= */

        /// <summary>
        /// Soft-deletes a Pending issue (IsDeleted = 1). Nothing is removed
        /// from the database: its materials, tenants and responsible rows
        /// stay for the record. Once deleted it no longer shows in the list
        /// and no longer turns the room grey in vwRoomStatus.
        ///
        /// The Pending check is in the WHERE clause, so a Complete issue
        /// (which may already have a bill or expense) can never be deleted,
        /// even if the list on screen is out of date.
        /// </summary>
        public static void DeleteIssue(int issueId)
        {
            string sql = @"
                UPDATE MaintenanceIssues
                SET    IsDeleted = 1
                WHERE  IssueId = @iid
                  AND  Status = 'Pending'
                  AND  IsDeleted = 0;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SqlCommand(sql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@iid", issueId);
                            if (cmd.ExecuteNonQuery() != 1)
                                throw new InvalidOperationException(
                                    "This issue can't be deleted. It may already be complete or deleted.");
                        }

                        // What was deleted, for the audit trail.
                        string what = "Issue #" + issueId;
                        using (var cmd = new SqlCommand(@"
                            SELECT 'Room ' + r.RoomNumber + ' - ' + mi.IssueTitle
                            FROM   MaintenanceIssues mi JOIN Rooms r ON r.RoomId = mi.RoomId
                            WHERE  mi.IssueId = @iid;", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@iid", issueId);
                            what = cmd.ExecuteScalar()?.ToString() ?? what;
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleMaintenance, "Delete Issue", what);
                        tx.Commit();
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { /* keep the original error */ }
                        throw;
                    }
                }
            }
        }

        /* =================================================================
           EDIT + COMPLETE
           ================================================================= */

        /// <summary>A maintenance bill is due this many days after Complete.</summary>
        public const int MaintenanceDueDays = 7;

        public static MaintenanceIssueEdit GetIssueForEdit(int issueId)
        {
            string sql = @"
                SELECT mi.IssueId, mi.RoomId, r.RoomNumber, mi.IssueTitle,
                       mi.Description, mi.DateReported, mi.Status
                FROM   MaintenanceIssues mi
                JOIN   Rooms r ON r.RoomId = mi.RoomId
                WHERE  mi.IssueId = @iid
                  AND  mi.IsDeleted = 0;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@iid", issueId);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;

                    return new MaintenanceIssueEdit
                    {
                        IssueId = rd.GetInt32(0),
                        RoomId = rd.GetInt32(1),
                        RoomNumber = rd.GetString(2),
                        IssueTitle = rd.GetString(3),
                        Description = rd.IsDBNull(4) ? "" : rd.GetString(4),
                        DateReported = rd.GetDateTime(5),
                        Status = rd.GetString(6)
                    };
                }
            }
        }

        /// <summary>
        /// The room's current tenants, plus anyone already on the issue who
        /// has since moved out (so they can be seen and removed).
        /// Current tenants first.
        /// </summary>
        public static List<TenantChoice> GetTenantChoicesForIssue(int issueId, int roomId)
        {
            var list = new List<TenantChoice>();

            string sql = @"
                SELECT t.TenantId, t.FirstName + N' ' + t.LastName,
                       CAST(CASE WHEN EXISTS (SELECT 1 FROM Tenancies tn
                                              WHERE tn.TenantId = t.TenantId
                                                AND tn.RoomId   = @rid
                                                AND tn.Status   = 'Active')
                                 THEN 1 ELSE 0 END AS bit) AS IsCurrent,
                       CAST(CASE WHEN EXISTS (SELECT 1 FROM MaintenanceAffectedTenants mat
                                              WHERE mat.TenantId = t.TenantId
                                                AND mat.IssueId  = @iid)
                                 THEN 1 ELSE 0 END AS bit) AS IsAffected
                FROM   Tenants t
                WHERE  t.TenantId IN (SELECT TenantId FROM Tenancies
                                      WHERE RoomId = @rid AND Status = 'Active')
                   OR  t.TenantId IN (SELECT TenantId FROM MaintenanceAffectedTenants
                                      WHERE IssueId = @iid)
                ORDER BY IsCurrent DESC, t.LastName, t.FirstName;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@iid", issueId);
                cmd.Parameters.AddWithValue("@rid", roomId);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new TenantChoice
                        {
                            TenantId = rd.GetInt32(0),
                            Name = rd.GetString(1),
                            IsCurrent = rd.GetBoolean(2),
                            IsAffected = rd.GetBoolean(3)
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Owner first, then the building's active caretakers, plus any
        /// caretaker already on the issue who is now inactive or archived.
        /// </summary>
        public static List<ResponsibleChoice> GetResponsibleChoicesForIssue(int issueId, int buildingId)
        {
            var list = new List<ResponsibleChoice>();

            string sql = @"
                SELECT CAST(CASE WHEN EXISTS (SELECT 1 FROM MaintenanceResponsible
                                              WHERE IssueId = @iid AND IsOwner = 1)
                                 THEN 1 ELSE 0 END AS bit);

                SELECT e.EmployeeId, e.FullName,
                       CAST(CASE WHEN e.EmploymentStatus = 'Active' AND e.ArchivedAt IS NULL
                                 THEN 1 ELSE 0 END AS bit) AS IsActive,
                       CAST(CASE WHEN EXISTS (SELECT 1 FROM MaintenanceResponsible mr
                                              WHERE mr.IssueId = @iid
                                                AND mr.EmployeeId = e.EmployeeId)
                                 THEN 1 ELSE 0 END AS bit) AS IsSelected
                FROM   Employees e
                WHERE  (e.BuildingId = @bid AND e.EmploymentStatus = 'Active' AND e.ArchivedAt IS NULL)
                   OR  e.EmployeeId IN (SELECT EmployeeId FROM MaintenanceResponsible
                                        WHERE IssueId = @iid AND EmployeeId IS NOT NULL)
                ORDER BY e.FullName;";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@iid", issueId);
                cmd.Parameters.AddWithValue("@bid", buildingId);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    list.Add(new ResponsibleChoice
                    {
                        IsOwner = true,
                        EmployeeId = null,
                        Name = "Owner",
                        IsActive = true,
                        IsSelected = rd.GetBoolean(0)
                    });

                    rd.NextResult();
                    while (rd.Read())
                    {
                        list.Add(new ResponsibleChoice
                        {
                            IsOwner = false,
                            EmployeeId = rd.GetInt32(0),
                            Name = rd.GetString(1),
                            IsActive = rd.GetBoolean(2),
                            IsSelected = rd.GetBoolean(3)
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Saves the edited issue in ONE transaction. When markComplete is
        /// true it also:
        ///   - sets Status = 'Complete' and CompletedAt (CK_MaintIssues_Done),
        ///   - totals the materials (Quantity x UnitPrice),
        ///   - total &gt; 0 and tenants charged -> one 'Maintenance' bill,
        ///     split equally (leftover centavo to the longest-tenured, the
        ///     same rule as rent), due today + MaintenanceDueDays,
        ///   - total &gt; 0 and nobody charged   -> one building expense,
        ///   - total = 0                        -> nothing else.
        /// The issue is only changed if it is still Pending, so a completed
        /// issue can never be edited or completed twice.
        /// </summary>
        public static IssueSaveResult SaveIssueEdit(
            int issueId,
            string issueTitle,
            string description,
            DateTime dateReported,
            IList<int> affectedTenantIds,
            bool ownerResponsible,
            IList<int> responsibleEmployeeIds,
            bool markComplete,
            int userId)
        {
            var result = new IssueSaveResult();
            DateTime today = DateTime.Today;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // ---- 1. Lock the row; it must still be Pending -----
                        int roomId;
                        using (var cmd = new SqlCommand(@"
                            SELECT RoomId FROM MaintenanceIssues WITH (UPDLOCK, ROWLOCK)
                            WHERE  IssueId = @iid AND Status = 'Pending' AND IsDeleted = 0;",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@iid", issueId);
                            object o = cmd.ExecuteScalar();
                            if (o == null)
                                throw new InvalidOperationException(
                                    "This issue is no longer pending, so it can't be edited.");
                            roomId = (int)o;
                        }

                        // ---- 2. The issue's own fields ---------------------
                        using (var cmd = new SqlCommand(@"
                            UPDATE MaintenanceIssues
                            SET    IssueTitle = @title, Description = @desc, DateReported = @date
                            WHERE  IssueId = @iid;", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@iid", issueId);
                            cmd.Parameters.AddWithValue("@title", issueTitle);
                            cmd.Parameters.AddWithValue("@desc",
                                string.IsNullOrWhiteSpace(description)
                                    ? (object)DBNull.Value : description);
                            cmd.Parameters.AddWithValue("@date", dateReported.Date);
                            cmd.ExecuteNonQuery();
                        }

                        // ---- 3. Affected tenants: replace the set ----------
                        // Same rule as Add: only a CURRENT tenant of the room
                        // can be charged. A moved-out tenant left on the list
                        // stops the whole save (decision 4).
                        Exec(conn, tx, "DELETE FROM MaintenanceAffectedTenants WHERE IssueId = @iid;",
                             "@iid", issueId);

                        foreach (int tenantId in affectedTenantIds)
                        {
                            using (var cmd = new SqlCommand(@"
                                INSERT INTO MaintenanceAffectedTenants (IssueId, TenantId)
                                SELECT @iid, tn.TenantId
                                FROM   Tenancies tn
                                WHERE  tn.TenantId = @tid AND tn.RoomId = @rid AND tn.Status = 'Active';",
                                conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@iid", issueId);
                                cmd.Parameters.AddWithValue("@tid", tenantId);
                                cmd.Parameters.AddWithValue("@rid", roomId);
                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new InvalidOperationException(
                                        "An affected tenant is no longer in this room. " +
                                        "Remove them from Affected Tenants first.");
                            }
                        }

                        // ---- 4. Responsible: replace the set ---------------
                        Exec(conn, tx, "DELETE FROM MaintenanceResponsible WHERE IssueId = @iid;",
                             "@iid", issueId);

                        string respSql = @"
                            INSERT INTO MaintenanceResponsible (IssueId, EmployeeId, IsOwner)
                            VALUES (@iid, @eid, @owner);";

                        if (ownerResponsible)
                        {
                            using (var cmd = new SqlCommand(respSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@iid", issueId);
                                cmd.Parameters.AddWithValue("@eid", DBNull.Value);
                                cmd.Parameters.AddWithValue("@owner", 1);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        foreach (int employeeId in responsibleEmployeeIds)
                        {
                            using (var cmd = new SqlCommand(respSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@iid", issueId);
                                cmd.Parameters.AddWithValue("@eid", employeeId);
                                cmd.Parameters.AddWithValue("@owner", 0);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // ---- 5. Complete -----------------------------------
                        if (markComplete)
                        {
                            decimal total;
                            using (var cmd = new SqlCommand(@"
                                SELECT ISNULL(SUM(CAST(Quantity AS decimal(18,2)) * UnitPrice), 0)
                                FROM   MaintenanceMaterials WHERE IssueId = @iid;", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@iid", issueId);
                                total = Convert.ToDecimal(cmd.ExecuteScalar());
                            }

                            Exec(conn, tx, @"
                                UPDATE MaintenanceIssues
                                SET    Status = 'Complete', CompletedAt = SYSDATETIME()
                                WHERE  IssueId = @iid;", "@iid", issueId);

                            result.Completed = true;
                            result.MaterialsTotal = total;

                            if (total > 0m && affectedTenantIds.Count > 0)
                            {
                                CreateMaintenanceBill(conn, tx, issueId, roomId, issueTitle, total, today, result);
                            }
                            else if (total > 0m)
                            {
                                CreateMaintenanceExpense(conn, tx, issueId, roomId, issueTitle, total, today, userId);
                                result.ExpenseRecorded = true;
                            }

                            string outcome =
                                total <= 0m ? "no materials, nothing charged"
                                : result.TenantsCharged > 0 ? "PHP " + total.ToString("N2") + " charged to " + result.TenantsCharged + " tenant(s)"
                                : "PHP " + total.ToString("N2") + " recorded as building expense";

                            AuditLogger.Log(conn, tx, AuditLogger.ModuleMaintenance, "Complete Issue",
                                "Room " + GetRoomNumber(conn, tx, roomId) + " - " + issueTitle + ": " + outcome);
                        }

                        tx.Commit();
                        return result;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// One 'Maintenance' bill linked to the issue, with a frozen share per
        /// affected tenant. Equal split in centavos; the leftover centavo goes
        /// to the longest-tenured tenant, as with rent.
        /// </summary>
        private static void CreateMaintenanceBill(
            SqlConnection conn, SqlTransaction tx,
            int issueId, int roomId, string issueTitle, decimal total,
            DateTime today, IssueSaveResult result)
        {
            DateTime due = today.AddDays(MaintenanceDueDays);

            int billId;
            using (var cmd = new SqlCommand(@"
                INSERT INTO Bills (RoomId, BillCategory, BillingPeriodStart, BillingPeriodEnd,
                                   DueDate, Amount, Remarks, MaintenanceIssueId)
                OUTPUT INSERTED.BillId
                VALUES (@rid, 'Maintenance', @today, @today, @due, @amt, @remarks, @iid);",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@rid", roomId);
                cmd.Parameters.AddWithValue("@today", today);
                cmd.Parameters.AddWithValue("@due", due);
                cmd.Parameters.AddWithValue("@amt", total);
                cmd.Parameters.AddWithValue("@remarks", Trim255("Maintenance: " + issueTitle));
                cmd.Parameters.AddWithValue("@iid", issueId);
                billId = (int)cmd.ExecuteScalar();
            }

            // Charged tenants, longest-tenured first.
            var tenants = new List<int>();
            using (var cmd = new SqlCommand(@"
                SELECT mat.TenantId
                FROM   MaintenanceAffectedTenants mat
                JOIN   Tenancies tn ON tn.TenantId = mat.TenantId
                                   AND tn.RoomId   = @rid
                                   AND tn.Status   = 'Active'
                WHERE  mat.IssueId = @iid
                ORDER BY tn.MoveInDate, tn.TenantId;", conn, tx))
            {
                cmd.Parameters.AddWithValue("@iid", issueId);
                cmd.Parameters.AddWithValue("@rid", roomId);
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read()) tenants.Add(rd.GetInt32(0));
            }

            long cents = (long)Math.Round(total * 100m);
            long each = cents / tenants.Count;
            long leftover = cents - each * tenants.Count;

            for (int i = 0; i < tenants.Count; i++)
            {
                long shareCents = (i == 0) ? each + leftover : each;
                if (shareCents <= 0) continue;   // CK_BillTenants_Share: Share > 0

                using (var cmd = new SqlCommand(@"
                    INSERT INTO BillTenants (BillId, TenantId, Share)
                    VALUES (@bid, @tid, @share);", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@bid", billId);
                    cmd.Parameters.AddWithValue("@tid", tenants[i]);
                    cmd.Parameters.AddWithValue("@share", shareCents / 100m);
                    cmd.ExecuteNonQuery();
                }
                result.TenantsCharged++;
            }

            result.DueDate = due;
        }

        /// <summary>
        /// Nobody is charged, so the landlord bears the cost: one building
        /// expense linked to the issue (UX_Expenses_MaintIssue allows one).
        /// </summary>
        private static void CreateMaintenanceExpense(
            SqlConnection conn, SqlTransaction tx,
            int issueId, int roomId, string issueTitle, decimal total,
            DateTime today, int userId)
        {
            using (var cmd = new SqlCommand(@"
                INSERT INTO Expenses (BuildingId, ExpenseCategory, Description, Amount,
                                      ExpenseDate, MaintenanceIssueId, RecordedBy)
                SELECT r.BuildingId, 'Maintenance', @desc, @amt, @today, @iid, @by
                FROM   Rooms r
                WHERE  r.RoomId = @rid;", conn, tx))
            {
                cmd.Parameters.AddWithValue("@desc", Trim255("Room " + GetRoomNumber(conn, tx, roomId) + " - " + issueTitle));
                cmd.Parameters.AddWithValue("@amt", total);
                cmd.Parameters.AddWithValue("@today", today);
                cmd.Parameters.AddWithValue("@iid", issueId);
                cmd.Parameters.AddWithValue("@by", userId);
                cmd.Parameters.AddWithValue("@rid", roomId);
                cmd.ExecuteNonQuery();
            }
        }

        private static string GetRoomNumber(SqlConnection conn, SqlTransaction tx, int roomId)
        {
            using (var cmd = new SqlCommand("SELECT RoomNumber FROM Rooms WHERE RoomId = @rid;", conn, tx))
            {
                cmd.Parameters.AddWithValue("@rid", roomId);
                return Convert.ToString(cmd.ExecuteScalar());
            }
        }

        private static void Exec(SqlConnection conn, SqlTransaction tx, string sql, string param, object value)
        {
            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue(param, value);
                cmd.ExecuteNonQuery();
            }
        }

        private static string Trim255(string s) => s.Length <= 255 ? s : s.Substring(0, 255);
    }

}
