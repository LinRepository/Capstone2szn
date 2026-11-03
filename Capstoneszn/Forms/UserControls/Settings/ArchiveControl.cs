using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.EmployeeForms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.UserControls.Settings
{

    /// <summary>
    /// Settings > Archive. Every record taken out of active use, with the
    /// action that brings it back.
    ///
    ///   Rooms    - archived rooms of the selected building. Restore.
    ///              (UPDATED Nov 3, 2026: restoring a room also restores its
    ///              electricity account; the account is shown as a column here.)
    ///   Tenants  - moved-out tenants (no active stay). Reactivate = a new
    ///              stay under the same tenant record.
    ///   Employee - archived employees. Restore = re-hire (ADDED Oct 28, 2026).
    ///   (OLD: "Bill Accounts / Audits - their modules are not built
    ///              yet; the tabs say so instead of showing an empty grid.")
    ///   Bill Accounts - HIDDEN (Nov 3, 2026): a room's electricity account is
    ///              archived/restored only through its room, and water/owner
    ///              accounts are edited in place, so the tab had no action.
    ///   (OLD: "Bill Accounts / Audits / Employee - their modules are not built yet")
    ///
    /// Nothing here deletes anything. Archiving keeps the row; restoring or
    /// reactivating only brings it back into use.
    /// </summary>
    /// 

    public partial class ArchiveControl : UserControl
    {

        private DataTable _rooms = new DataTable();
        private DataTable _tenants = new DataTable();

        // (Nov 3, 2026) The Electricity Account column is now in the Designer
        // (colArchivedRoomElectricity), so it is no longer created here.
        // OLD: private DataGridViewTextBoxColumn colArchivedRoomElectricity = null!;

        public ArchiveControl()
        {
            InitializeComponent();

            // (Nov 3, 2026) Bill Accounts tab removed from the Designer, so nothing to hide here.
            // OLD: tabArchive.TabPages.Remove(tabBillAccounts);

            // ---- Rooms grid ----
            dgvArchivedRooms.AutoGenerateColumns = false;
            colArchivedRoomFloor.DataPropertyName = "FloorNumber";
            colArchivedRoom.DataPropertyName = "RoomNumber";
            colArchivedRoomType.DataPropertyName = "RoomType";
            colArchivedRoomCapacity.DataPropertyName = "Capacity";
            colArchivedRoomPrice.DataPropertyName = "RoomPrice";
            colRoomArchivedAt.DataPropertyName = "ArchivedAt";

            colArchivedRoomType.DefaultCellStyle.NullValue = "-";
            colArchivedRoomCapacity.DefaultCellStyle.NullValue = "-";
            colArchivedRoomPrice.DefaultCellStyle.NullValue = "-";
            colArchivedRoomPrice.DefaultCellStyle.Format = "N2";
            colArchivedRoomPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colRoomArchivedAt.DefaultCellStyle.Format = "MMM d, yyyy  h:mm tt";
            colRoomArchivedAt.DefaultCellStyle.NullValue = "-";

            // ADDED Nov 3, 2026: Electricity Account column (now defined in the Designer)
            colArchivedRoomElectricity.DataPropertyName = "ElectricityAccount";
            colArchivedRoomElectricity.DefaultCellStyle.NullValue = "-";

            // OLD (column was created in code before it moved to the Designer):
            // colArchivedRoomElectricity = new DataGridViewTextBoxColumn { ... };
            // dgvArchivedRooms.Columns.Insert(colRoomArchivedAt.Index, colArchivedRoomElectricity);

            // (Nov 3, 2026) The note text is now set in the Designer ("Unconfigured" removed).
            // OLD: lblRoomsNote.Text = "Restore returns the room (and its electricity account) ...";

            // ---- Tenants grid ----
            dgvArchivedTenants.AutoGenerateColumns = false;
            colArchivedTenantName.DataPropertyName = "FullName";
            colArchivedTenantContact.DataPropertyName = "ContactNumber";
            colArchivedTenantLastRoom.DataPropertyName = "LastRoom";
            colArchivedTenantMoveIn.DataPropertyName = "MoveInDate";
            colTenantArchivedAt.DataPropertyName = "MoveOutDate";
            colArchivedTenantReason.DataPropertyName = "MoveOutReason";

            colArchivedTenantMoveIn.DefaultCellStyle.Format = "MMM d, yyyy";
            colTenantArchivedAt.DefaultCellStyle.Format = "MMM d, yyyy";
            colArchivedTenantContact.DefaultCellStyle.NullValue = "-";
            colArchivedTenantReason.DefaultCellStyle.NullValue = "-";
            colTenantArchivedAt.DefaultCellStyle.NullValue = "-";

            // ---- Employees grid (ADDED - STEP 9) ----
            dgvArchivedEmployees.AutoGenerateColumns = false;
            colEmployeeArchiveID.DataPropertyName = "EmployeeId";
            colEmployeeArchivedAt.DataPropertyName = "ArchivedAt";
            colArchivedEmployeeName.DataPropertyName = "FullName";
            colArchivedEmployeeAddress.DataPropertyName = "Address";
            colArchivedEmployeeDateHired.DataPropertyName = "DateHired";

            colEmployeeArchivedAt.DefaultCellStyle.Format = "MMM d, yyyy  h:mm tt";
            colArchivedEmployeeDateHired.DefaultCellStyle.Format = "MMM d, yyyy";
            colArchivedEmployeeAddress.DefaultCellStyle.NullValue = "-";
            colEmployeeArchiveAction.Text = "Restore";   // restore = re-hire

            // The Designer has no click event for this grid, so it is wired here.
            dgvArchivedEmployees.CellContentClick += dgvArchivedEmployees_CellContentClick;

            LoadArchivedRooms();
            LoadArchivedTenants();
            LoadArchivedEmployees();   // ADDED
        }

        private void btnBackArchive_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        /* =================================================================
           ROOMS
           ================================================================= */

        private void LoadArchivedRooms()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                // ORIGINAL query (kept for reference):
                //   SELECT r.RoomId, f.FloorNumber, r.RoomNumber, r.RoomType,
                //          r.Capacity, r.RoomPrice, r.ArchivedAt
                //   FROM   Rooms r
                //   JOIN   Floors f ON f.FloorId = r.FloorId
                //   WHERE  r.BuildingId = @bid
                //     AND  r.IsArchived = 1
                //   ORDER BY r.ArchivedAt DESC;
                // NEW (Nov 3, 2026): also returns the room's electricity account
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT r.RoomId, f.FloorNumber, r.RoomNumber, r.RoomType,
                           r.Capacity, r.RoomPrice, r.ArchivedAt,
                           e.ElectricityAccount
                    FROM   Rooms r
                    JOIN   Floors f ON f.FloorId = r.FloorId
                    OUTER APPLY (SELECT TOP 1
                                        ISNULL(ea.AccountName + ' - ', '') + ea.AccountNumber AS ElectricityAccount
                                 FROM   ElectricityAccounts ea
                                 WHERE  ea.RoomId = r.RoomId
                                 ORDER BY ea.IsArchived DESC, ea.ArchivedAt DESC) e
                    WHERE  r.BuildingId = @bid
                      AND  r.IsArchived = 1
                    ORDER BY r.ArchivedAt DESC;", conn))
                {
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = Session.BuildingId;

                    _rooms = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(_rooms);
                }

                dgvArchivedRooms.DataSource = _rooms;
                ApplyRoomsFilter();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to load archived rooms: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchRooms_TextChanged(object sender, EventArgs e)
        {
            ApplyRoomsFilter();
        }

        private void ApplyRoomsFilter()
        {
            string term = EscapeFilter(txtSearchRooms.Text.Trim());

            _rooms.DefaultView.RowFilter = term.Length == 0
                ? ""
                // ORIGINAL: : $"RoomNumber LIKE '%{term}%' OR RoomType LIKE '%{term}%'";
                // NEW: RoomNumber is INT - LIKE only works on text, so convert it first
                : $"Convert(RoomNumber, 'System.String') LIKE '%{term}%' OR RoomType LIKE '%{term}%'";

            int shown = _rooms.DefaultView.Count;
            lblRoomsCount.Text = shown + " archived room(s)";

            dgvArchivedRooms.Visible = shown > 0;
            lblNoArchivedRooms.Visible = shown == 0;
            lblNoArchivedRooms.Text = _rooms.Rows.Count == 0
                ? "No archived rooms."
                : "No archived room matches the search.";

            dgvArchivedRooms.ClearSelection();
        }

        private void dgvArchivedRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colRoomArchiveAction.Index) return;

            // ADDED Nov 3, 2026: landlord only (same check as the Employees tab)
            if (!Session.IsLandlord)
            {
                MessageBox.Show("Only the landlord can restore rooms.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRowView row = dgvArchivedRooms.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            int roomId = Convert.ToInt32(row["RoomId"]);
            string roomNumber = Convert.ToString(row["RoomNumber"]);
            int floorNumber = Convert.ToInt32(row["FloorNumber"]);

            // ADDED Nov 3, 2026
            string account = row["ElectricityAccount"] == DBNull.Value
                ? ""
                : Convert.ToString(row["ElectricityAccount"]) ?? "";

            // ORIGINAL message:
            //   $"Restore Room {roomNumber} (Floor {floorNumber})?\n\n" +
            //   "It returns to the Rooms map as Available (or Unconfigured if it was " +
            //   "never set up), ready for a move in.",
            string message = $"Restore Room {roomNumber} (Floor {floorNumber})?\n\n" +
                             "It returns to the Rooms map as Available, ready for a move in.";
            if (account.Length > 0)
                message += "\n\nIts electricity account (" + account + ") will be restored too.";

            if (MessageBox.Show(message, "Restore Room", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            if (RestoreRoom(roomId, roomNumber))
            {
                // ADDED Nov 3, 2026: audit log (decided Oct 25: room archive/restore are logged)
                // If AuditLogger has no ModuleRooms constant, use the module name your Rooms code uses.
                try
                {
                    AuditLogger.Log(AuditLogger.ModuleRooms, "Restore Room",
                        "Restored Room " + roomNumber + (account.Length > 0 ? " and its electricity account" : ""));
                }
                catch (Exception ex) { Debug.WriteLine(ex); }   // a log failure must not undo the restore

                MessageBox.Show("Room " + roomNumber + " has been restored.", "Room Restored",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadArchivedRooms();
            }
        }

        /// <summary>
        /// Settled rule: an archived room comes back only with no tenant and
        /// no open maintenance issue. The room number must also still be
        /// free among this building's active rooms.
        ///
        /// The reason is checked first so the message can say exactly what
        /// blocks it; the UPDATE then enforces the same rules itself.
        ///
        /// UPDATED Nov 3, 2026: the room's electricity account is restored in the
        /// same transaction, so the room and its account always come back together.
        /// </summary>
        private bool RestoreRoom(int roomId, string roomNumber)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Why not? (for the message only)
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT v.Status,
                               (SELECT COUNT(*) FROM Tenancies tn
                                WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active') AS ActiveStays,
                               (SELECT COUNT(*) FROM Rooms r2
                                WHERE r2.BuildingId = r.BuildingId
                                  AND r2.RoomNumber = r.RoomNumber
                                  AND r2.IsArchived = 0
                                  AND r2.RoomId <> r.RoomId) AS SameNumber
                        FROM   Rooms r
                        JOIN   vwRoomStatus v ON v.RoomId = r.RoomId
                        WHERE  r.RoomId = @rid AND r.IsArchived = 1;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read())
                            {
                                MessageBox.Show("Room " + roomNumber + " is no longer archived.",
                                    "Not Restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadArchivedRooms();
                                return false;
                            }

                            string status = rd.IsDBNull(0) ? "" : rd.GetString(0);
                            int activeStays = rd.GetInt32(1);
                            int sameNumber = rd.GetInt32(2);

                            string blocked = null;
                            if (status == "Maintenance")
                                blocked = "it has an open maintenance issue. Settle the issue first.";
                            else if (activeStays > 0 || status == "Occupied")
                                blocked = "it still has an active tenant.";
                            else if (sameNumber > 0)
                                blocked = "another active room in this building already uses number " + roomNumber + ".";

                            if (blocked != null)
                            {
                                MessageBox.Show("Room " + roomNumber + " cannot be restored: " + blocked,
                                    "Not Restored", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }

                    // ADDED Nov 3, 2026: room + electricity account in one transaction
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // 2. Restore the room - the same rules, enforced in the statement itself.
                            int roomRows;
                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE r
                                   SET r.IsArchived = 0,
                                       r.ArchivedAt = NULL
                                FROM   Rooms r
                                JOIN   vwRoomStatus v ON v.RoomId = r.RoomId
                                WHERE  r.RoomId     = @rid
                                  AND  r.BuildingId = @bid
                                  AND  r.IsArchived = 1
                                  AND  v.Status NOT IN ('Occupied', 'Maintenance')
                                  AND  NOT EXISTS (SELECT 1 FROM Tenancies tn
                                                   WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active')
                                  AND  NOT EXISTS (SELECT 1 FROM Rooms r2
                                                   WHERE r2.BuildingId = r.BuildingId
                                                     AND r2.RoomNumber = r.RoomNumber
                                                     AND r2.IsArchived = 0
                                                     AND r2.RoomId <> r.RoomId);", conn, tx))
                            {
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = Session.BuildingId;
                                roomRows = cmd.ExecuteNonQuery();
                            }

                            if (roomRows != 1)
                            {
                                tx.Rollback();
                                MessageBox.Show("Room " + roomNumber + " could not be restored. Nothing was changed.",
                                    "Not Restored", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                LoadArchivedRooms();
                                return false;
                            }

                            // 3. ADDED: restore its electricity account (archived together with the room)
                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE ElectricityAccounts
                                   SET IsArchived = 0,
                                       ArchivedAt = NULL
                                WHERE  RoomId = @rid
                                  AND  IsArchived = 1;", conn, tx))
                            {
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                                cmd.ExecuteNonQuery();   // 0 rows is fine (room had no archived account)
                            }

                            tx.Commit();
                            return true;
                        }
                        catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                        {
                            tx.Rollback();
                            MessageBox.Show("Room " + roomNumber + " cannot be restored: its electricity account " +
                                            "number is now used by another account. Nothing was changed.",
                                "Not Restored", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }

                    // ORIGINAL step 2 (replaced by the transaction above):
                    // using (SqlCommand cmd = new SqlCommand(@"UPDATE r SET r.IsArchived = 0, ... ", conn))
                    // {
                    //     ...
                    //     if (cmd.ExecuteNonQuery() == 1) return true;
                    // }
                    // MessageBox.Show("Room " + roomNumber + " could not be restored. Nothing was changed.", ...);
                    // LoadArchivedRooms();
                    // return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to restore the room: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /* =================================================================
           TENANTS
           A tenant is "archived" when they have no active stay - the same
           rule the Tenants module uses to leave them out of its list. Each
           is shown with their LATEST stay, and listed under the building
           that stay was in.
           ================================================================= */

        private void LoadArchivedTenants()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT t.TenantId,
                           t.FirstName + ISNULL(' ' + NULLIF(t.MiddleName, ''), '') + ' ' + t.LastName AS FullName,
                           t.ContactNumber,
                           last.RoomNumber AS LastRoom,
                           last.MoveInDate,
                           last.MoveOutDate,
                           last.MoveOutReason
                    FROM   Tenants t
                    CROSS APPLY (SELECT TOP 1 r.RoomNumber, r.BuildingId,
                                        tn.MoveInDate, tn.MoveOutDate, tn.MoveOutReason
                                 FROM   Tenancies tn
                                 JOIN   Rooms r ON r.RoomId = tn.RoomId
                                 WHERE  tn.TenantId = t.TenantId
                                 ORDER BY tn.MoveInDate DESC, tn.TenancyId DESC) last
                    WHERE  last.BuildingId = @bid
                      AND  NOT EXISTS (SELECT 1 FROM Tenancies tn2
                                       WHERE tn2.TenantId = t.TenantId
                                         AND tn2.Status   = 'Active')
                    ORDER BY last.MoveOutDate DESC, t.LastName, t.FirstName;", conn))
                {
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = Session.BuildingId;

                    _tenants = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(_tenants);
                }

                dgvArchivedTenants.DataSource = _tenants;
                ApplyTenantsFilter();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to load moved-out tenants: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchTenants_TextChanged(object sender, EventArgs e)
        {
            ApplyTenantsFilter();
        }

        private void ApplyTenantsFilter()
        {
            string term = EscapeFilter(txtSearchTenants.Text.Trim());

            _tenants.DefaultView.RowFilter = term.Length == 0
                ? ""
                // ORIGINAL: : $"FullName LIKE '%{term}%' OR ContactNumber LIKE '%{term}%' OR LastRoom LIKE '%{term}%'";
                : $"FullName LIKE '%{term}%' OR ContactNumber LIKE '%{term}%' OR Convert(LastRoom, 'System.String') LIKE '%{term}%'";   // NEW: INT

            int shown = _tenants.DefaultView.Count;
            lblTenantsCount.Text = shown + " moved-out tenant(s)";

            dgvArchivedTenants.Visible = shown > 0;
            lblNoArchivedTenants.Visible = shown == 0;
            lblNoArchivedTenants.Text = _tenants.Rows.Count == 0
                ? "No moved-out tenants."
                : "No moved-out tenant matches the search.";

            dgvArchivedTenants.ClearSelection();
        }

        private void dgvArchivedTenants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colTenantArchiveAction.Index) return;

            DataRowView row = dgvArchivedTenants.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            int tenantId = Convert.ToInt32(row["TenantId"]);

            using (var reactivate = new ReactivateTenantForm(tenantId, Session.BuildingId))
            {
                if (reactivate.ShowDialog(this.FindForm()) == DialogResult.OK)
                    LoadArchivedTenants();   // they now have an active stay - off this list
            }
        }


        /* =================================================================
           EMPLOYEES (ADDED - STEP 9)
           Restore = re-hire: the employee comes back Active with Date Hired
           = today, so the salary counts from today. Landlord only. Blocked
           when the building already has 3 employees.
           ================================================================= */

        private DataTable _employees = new DataTable();

        private void LoadArchivedEmployees()
        {
            try
            {
                _employees = EmployeeHelper.GetArchivedEmployees(Session.BuildingId);
                dgvArchivedEmployees.DataSource = _employees;

                int shown = _employees.Rows.Count;
                dgvArchivedEmployees.Visible = shown > 0;
                lblNoArchivedEmployees.Visible = shown == 0;
                lblNoArchivedEmployees.Text = "No archived employees.";
                dgvArchivedEmployees.ClearSelection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to load archived employees: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvArchivedEmployees_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colEmployeeArchiveAction.Index) return;

            if (!Session.IsLandlord)
            {
                MessageBox.Show("Only the landlord can restore employees.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRowView? row = dgvArchivedEmployees.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            int employeeId = Convert.ToInt32(row["EmployeeId"]);
            string name = Convert.ToString(row["FullName"]) ?? "";

            if (MessageBox.Show(
                    $"Restore {name}?\n\n" +
                    "• They come back as Active and can log in again.\n" +
                    $"• This counts as a re-hire: Date Hired becomes today ({DateTime.Today:MMM dd, yyyy}) " +
                    "and the salary counts from today.\n" +
                    "• Their username and password stay the same.",
                    "Restore Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            try
            {
                EmployeeHelper.Restore(employeeId);
                MessageBox.Show(name + " has been restored.", "Employee Restored",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)   // 3-employee limit, no salary, clock
            {
                MessageBox.Show(ex.Message, "Not Restored",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to restore the employee: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadArchivedEmployees();
        }



        /* =================================================================
            HELPERS
            ================================================================= */

        // RowFilter treats [ ] * % as pattern characters. Without escaping,
        // typing a single "[" throws a SyntaxErrorException.
        private static string EscapeFilter(string s)
        {
            return (s ?? string.Empty)
                .Replace("[", "[[]")   // must come first
                .Replace("%", "[%]")
                .Replace("*", "[*]")
                .Replace("'", "''");
        }

    }
}
