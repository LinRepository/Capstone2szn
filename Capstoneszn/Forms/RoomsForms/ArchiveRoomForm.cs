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
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.RoomsForms
{
    /// <summary>
    /// Archive Room: takes an EMPTY room out of the active room list.
    ///
    /// Settled rules:
    ///   - Only an Available or Unconfigured room can be archived. An
    ///     occupied room must be moved out first; a room under maintenance
    ///     must have its issue settled first.
    ///   - Archiving never deletes. The row stays (IsArchived = 1, with the
    ///     time in ArchivedAt), so its bills and payments keep pointing at
    ///     a real room and still show in history and reports.
    ///   - The room number is NOT freed for reuse. A returning room is
    ///     unarchived from Settings > Archive, so its history stays in one
    ///     place.
    ///
    /// The rule is enforced inside the UPDATE itself, not only by what this
    /// list shows - if someone moves in between loading the list and
    /// clicking Archive, the UPDATE changes nothing and says so.
    /// </summary>
    /// 

    public partial class ArchiveRoomForm : Form
    {

        private readonly int _buildingId;
        private DataTable _rooms = new DataTable();

        /// <summary>
        /// Statuses from vwRoomStatus that block archiving. Written as
        /// "not these" rather than "only Available/Unconfigured" so the rule
        /// does not depend on the exact word the view uses for an
        /// unconfigured room.
        /// </summary>
        private const string BlockedStatuses = "'Occupied', 'Maintenance'";
        public ArchiveRoomForm(int buildingId)
        {
            InitializeComponent();

            _buildingId = buildingId;

            // Map grid columns to the query below
            dgvArchivableRooms.AutoGenerateColumns = false;
            colFloor.DataPropertyName = "FloorNumber";
            colRoomNumber.DataPropertyName = "RoomNumber";
            colRoomType.DataPropertyName = "RoomType";
            colCapacity.DataPropertyName = "Capacity";
            colRoomPrice.DataPropertyName = "RoomPrice";
            colStatus.DataPropertyName = "Status";

            // An unconfigured room has no capacity, type or price yet
            colCapacity.DefaultCellStyle.NullValue = "-";
            colRoomType.DefaultCellStyle.NullValue = "-";
            colRoomPrice.DefaultCellStyle.NullValue = "-";
            colRoomPrice.DefaultCellStyle.Format = "N2";
            colRoomPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Esc closes. Enter deliberately does NOT archive - this is a
            // change the landlord should click on purpose.
            this.CancelButton = btnCancelArchiveRoom;

            LoadArchivableRooms();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // The grid selects its first row on its own when shown. Nothing
            // should be pre-selected for an archive, so clear it.
            dgvArchivableRooms.ClearSelection();
            UpdateSelection();
        }

        private void LoadArchivableRooms()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand($@"
                    SELECT v.RoomId,
                           f.FloorNumber,
                           v.RoomNumber,
                           r.RoomType,
                           r.Capacity,
                           r.RoomPrice,
                           v.Status
                    FROM   vwRoomStatus v
                    JOIN   Rooms  r ON r.RoomId  = v.RoomId
                    JOIN   Floors f ON f.FloorId = r.FloorId
                    WHERE  v.BuildingId = @bid
                      AND  v.IsArchived = 0
                      AND  v.Status NOT IN ({BlockedStatuses})
                      AND  NOT EXISTS (SELECT 1 FROM Tenancies tn
                                       WHERE tn.RoomId = v.RoomId
                                         AND tn.Status = 'Active')
                    ORDER BY f.FloorNumber, LEN(v.RoomNumber), v.RoomNumber;", conn))
                {
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = _buildingId;

                    _rooms = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(_rooms);
                }

                dgvArchivableRooms.DataSource = _rooms;

                bool any = _rooms.Rows.Count > 0;
                dgvArchivableRooms.Visible = any;
                lblNoRooms.Visible = !any;

                dgvArchivableRooms.ClearSelection();
                UpdateSelection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to load rooms: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvArchivableRooms_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelection();
        }

        /// <summary>The selected row, or null when nothing is selected.</summary>
        private DataRowView SelectedRoom()
        {
            if (dgvArchivableRooms.SelectedRows.Count == 0) return null;
            return dgvArchivableRooms.SelectedRows[0].DataBoundItem as DataRowView;
        }

        private void UpdateSelection()
        {
            DataRowView row = SelectedRoom();

            btnArchiveSelected.Enabled = row != null;

            if (row == null)
            {
                lblSelectedRoom.Text = "No room selected";
                lblSelectedRoom.ForeColor = Color.Silver;
            }
            else
            {
                lblSelectedRoom.Text = "Selected: Room " + row["RoomNumber"] +
                                       " (Floor " + row["FloorNumber"] + ")";
                lblSelectedRoom.ForeColor = Color.White;
            }
        }

        private void ArchiveRoomForm_Load(object sender, EventArgs e)
        {

        }

        private void btnArchiveSelected_Click(object sender, EventArgs e)
        {
            DataRowView row = SelectedRoom();
            if (row == null) return;

            int roomId = Convert.ToInt32(row["RoomId"]);
            string roomNumber = Convert.ToString(row["RoomNumber"]);
            int floorNumber = Convert.ToInt32(row["FloorNumber"]);

            // NEW (ARC-03): warn about unpaid electricity, then let the landlord decide.
            decimal unpaidElectricity;
            try
            {
                unpaidElectricity = GetUnpaidElectricity(roomId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to check the room's electricity bills: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (unpaidElectricity > 0m &&
                MessageBox.Show(
                    $"Room {roomNumber} has an unpaid electricity balance of ₱{unpaidElectricity:N2}.\n\n" +
                    "If you archive this room, the bill will be hidden from Utilities " +
                    "until the room is restored.\n\nArchive anyway?",
                    "Unpaid Electricity", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            using (var confirm = new ArchiveRoomConfirmationForm(roomNumber, floorNumber))
            {
                if (confirm.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            bool? archived = ArchiveRoom(roomId, roomNumber, unpaidElectricity);   // NEW
            if (archived == null) return;          // database error, already shown

            if (archived == true)
            {
                MessageBox.Show("Room " + roomNumber + " has been archived.", "Room Archived",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;   // RoomsControl reloads the map
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Room " + roomNumber + " can no longer be archived. A tenant may have " +
                    "moved in, a maintenance issue may have been opened, or it was already " +
                    "archived.\n\nNothing was changed.",
                    "Not Archived", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LoadArchivableRooms();   // show the list as it is now
            }
        }

        private static decimal GetUnpaidElectricity(int roomId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT ISNULL(SUM(ec.Amount), 0)
                FROM   ElectricityCharges ec
                JOIN   ElectricityAccounts ea
                       ON ea.ElectricityAccountId = ec.ElectricityAccountId
                WHERE  ea.RoomId = @rid
                  AND  ec.Status = 'Unpaid';", conn))
            {
                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Archives the room only if it is still archivable at this moment.
        /// true = archived; false = the rule no longer holds, nothing changed;
        /// null = database error (already shown to the user).
        ///
        /// NEW (ARC-01, ARC-02): the room, its electricity account and the
        /// audit entry are saved in ONE transaction: all or nothing.
        /// </summary>
        private bool? ArchiveRoom(int roomId, string roomNumber, decimal unpaidElectricity)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. The room - same rules as before.
                            int roomRows;
                            using (SqlCommand cmd = new SqlCommand($@"
                                UPDATE r
                                   SET r.IsArchived        = 1,
                                       r.ArchivedAt        = SYSDATETIME(),
                                       r.BillingAnchorDate = NULL      -- an empty room has no cycle
                                FROM   Rooms r
                                JOIN   vwRoomStatus v ON v.RoomId = r.RoomId
                                WHERE  r.RoomId     = @rid
                                  AND  r.BuildingId = @bid
                                  AND  r.IsArchived = 0
                                  AND  v.Status NOT IN ({BlockedStatuses})
                                  AND  NOT EXISTS (SELECT 1 FROM Tenancies tn
                                                   WHERE tn.RoomId = r.RoomId
                                                     AND tn.Status = 'Active');", conn, tx))
                            {
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = _buildingId;
                                roomRows = cmd.ExecuteNonQuery();
                            }

                            if (roomRows != 1)
                            {
                                tx.Rollback();
                                return false;
                            }

                            // 2. Its electricity account (ARC-01).
                            int accountRows;
                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE ElectricityAccounts
                                   SET IsArchived = 1,
                                       ArchivedAt = SYSDATETIME()
                                WHERE  RoomId = @rid
                                  AND  IsArchived = 0;", conn, tx))
                            {
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                                accountRows = cmd.ExecuteNonQuery();
                            }

                            // 3. Audit entry (ARC-02).
                            string details = "Archived Room " + roomNumber;
                            if (accountRows > 0)
                                details += " and its electricity account";
                            if (unpaidElectricity > 0m)
                                details += " (unpaid electricity PHP " + unpaidElectricity.ToString("N2") + ")";

                            AuditLogger.Log(conn, tx, AuditLogger.ModuleRooms, "Archive Room", details);

                            tx.Commit();
                            return true;
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to archive the room: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnCancelArchiveRoom_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
