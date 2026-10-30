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
using Capstoneszn.Forms.RoomsForms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.UserControls.Settings
{
    /// <summary>
    /// Reactivates a moved-out tenant: the SAME person starts a NEW stay.
    ///
    /// Nothing about the old stay is touched. Their Tenants row is reused
    /// (no duplicate person), and a new Tenancies row is added. Money from
    /// the old stay was already settled at move out (write-off / forfeit),
    /// and every billing query counts only the CURRENT stay, so old debts
    /// show as "Written off" and are never charged again.
    ///
    /// The room rules are exactly Move In's:
    ///   - empty room    -> full room price up front (the normal PaymentForm)
    ///   - occupied room -> joins without paying now; billed from the room's
    ///                      next cycle
    /// </summary>
    /// 

    public partial class ReactivateTenantForm : Form
    {
        private readonly int _tenantId;
        private readonly int _buildingId;

        // The person, as recorded. Carried into the move-in unchanged; the
        // landlord can update details afterwards in Tenants > Edit (allowed
        // again once the tenant is active).
        private string _firstName = "", _middleName = "", _lastName = "",
                       _address = "", _contact = "";

        private DataTable _rooms = new DataTable();


        public ReactivateTenantForm(int tenantId, int buildingId)
        {
            InitializeComponent();

            _tenantId = tenantId;
            _buildingId = buildingId;

            dgvAvailableRooms.AutoGenerateColumns = false;
            colFloor.DataPropertyName = "FloorNumber";
            colRoomNumber.DataPropertyName = "RoomNumber";
            colRoomType.DataPropertyName = "RoomType";
            colOccupancy.DataPropertyName = "Occupancy";
            colRoomPrice.DataPropertyName = "RoomPrice";
            colOnReactivation.DataPropertyName = "OnReactivation";

            colRoomType.DefaultCellStyle.NullValue = "-";
            colRoomPrice.DefaultCellStyle.Format = "N2";
            colRoomPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.CancelButton = btnCancelReactivate;

            if (LoadTenant())
                LoadRooms();
            else
            {
                // Blocked (moved out today, already active, or not found):
                // show why instead of an empty grid.
                btnContinueReactivate.Enabled = false;
                dgvAvailableRooms.Visible = false;
                lblNoRooms.Text = "No rooms to choose from yet - see the note above.";
                lblNoRooms.Visible = true;
            }

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            dgvAvailableRooms.ClearSelection();
            UpdateSelection();
        }

        /* =================================================================
           LOAD
           ================================================================= */

        private bool LoadTenant()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT t.FirstName, t.MiddleName, t.LastName, t.Address, t.ContactNumber,
                           (SELECT COUNT(*) FROM Tenancies tn
                            WHERE tn.TenantId = t.TenantId AND tn.Status = 'Active') AS ActiveStays,
                           last.RoomNumber, last.MoveOutDate
                    FROM   Tenants t
                    OUTER APPLY (SELECT TOP 1 r.RoomNumber, tn.MoveOutDate
                                 FROM   Tenancies tn
                                 JOIN   Rooms r ON r.RoomId = tn.RoomId
                                 WHERE  tn.TenantId = t.TenantId
                                 ORDER BY tn.MoveInDate DESC, tn.TenancyId DESC) last
                    WHERE  t.TenantId = @tid;", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                        {
                            lblTenantSummary.Text = "Tenant not found.";
                            return false;
                        }

                        _firstName = r.IsDBNull(0) ? "" : r.GetString(0);
                        _middleName = r.IsDBNull(1) ? "" : r.GetString(1);
                        _lastName = r.IsDBNull(2) ? "" : r.GetString(2);
                        _address = r.IsDBNull(3) ? "" : r.GetString(3);
                        _contact = r.IsDBNull(4) ? "" : r.GetString(4);

                        if (r.GetInt32(5) > 0)
                        {
                            lblTenantSummary.Text = FullName() + " already has an active stay.";
                            return false;
                        }

                        // ORIGINAL: string lastRoom = r.IsDBNull(6) ? "-" : r.GetString(6);
                        string lastRoom = r.IsDBNull(6) ? "-" : Convert.ToString(r.GetValue(6));   // NEW: RoomNumber is INT
                        string movedOut = r.IsDBNull(7) ? "-" : r.GetDateTime(7).ToString("MMM d, yyyy");

                        lblTenantSummary.Text = FullName() + "   |   " + _contact +
                                                "   |   last in Room " + lastRoom +
                                                ", moved out " + movedOut;

                        // A new stay must begin after the last one ended. Out and
                        // back in on the same day is a correction, not a new stay -
                        // and it would make the old stay's bills look current again.
                        if (!r.IsDBNull(7) && r.GetDateTime(7).Date >= DateTime.Today)
                        {
                            lblReactivateRule.Text = FullName() + " moved out today. Moving out and back in on " +
                                                     "the same day is a correction, not a new stay, so " +
                                                     "reactivation is possible from tomorrow.";
                            lblReactivateRule.ForeColor = Color.Gold;
                            return false;
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to load the tenant: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string FullName()
        {
            return (_firstName + " " + (_middleName.Length > 0 ? _middleName + " " : "") + _lastName).Trim();
        }

        /// <summary>
        /// Rooms of this building with a free bed. Configured rooms only - an
        /// unconfigured room has no price or capacity to move into. A room
        /// under maintenance is allowed, the same as Move In.
        /// </summary>
        private void LoadRooms()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT v.RoomId,
                           f.FloorNumber,
                           v.RoomNumber,
                           r.RoomType,
                           r.Capacity,
                           r.RoomPrice,
                           ISNULL(v.ActiveTenants, 0) AS ActiveTenants
                    FROM   vwRoomStatus v
                    JOIN   Rooms  r ON r.RoomId  = v.RoomId
                    JOIN   Floors f ON f.FloorId = r.FloorId
                    WHERE  v.BuildingId = @bid
                      AND  v.IsArchived = 0
                      AND  r.Capacity  > 0
                      AND  r.RoomPrice > 0
                      AND  ISNULL(v.ActiveTenants, 0) < r.Capacity
                    ORDER BY f.FloorNumber, LEN(v.RoomNumber), v.RoomNumber;", conn))
                {
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = _buildingId;

                    _rooms = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(_rooms);
                }

                // Two display columns worked out here, so the landlord sees
                // what will happen BEFORE choosing.
                _rooms.Columns.Add("Occupancy", typeof(string));
                _rooms.Columns.Add("OnReactivation", typeof(string));

                foreach (DataRow row in _rooms.Rows)
                {
                    int active = Convert.ToInt32(row["ActiveTenants"]);
                    int capacity = Convert.ToInt32(row["Capacity"]);
                    decimal price = Convert.ToDecimal(row["RoomPrice"]);

                    row["Occupancy"] = active + "/" + capacity;
                    row["OnReactivation"] = active == 0
                        ? "Empty room - pays PHP " + price.ToString("N2") + " now"
                        : "Joins room-mates - pays from the next bill";
                }

                dgvAvailableRooms.DataSource = _rooms;

                bool any = _rooms.Rows.Count > 0;
                dgvAvailableRooms.Visible = any;
                lblNoRooms.Visible = !any;

                dgvAvailableRooms.ClearSelection();
                UpdateSelection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Unable to load rooms: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* =================================================================
           SELECTION
           ================================================================= */

        private void dgvAvailableRooms_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelection();
        }

        private DataRowView SelectedRoom()
        {
            if (dgvAvailableRooms.SelectedRows.Count == 0) return null;
            return dgvAvailableRooms.SelectedRows[0].DataBoundItem as DataRowView;
        }

        private void UpdateSelection()
        {
            DataRowView row = SelectedRoom();
            btnContinueReactivate.Enabled = row != null;

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



        private void btnContinueReactivate_Click(object sender, EventArgs e)
        {
            DataRowView row = SelectedRoom();
            if (row == null) return;

            int roomId = Convert.ToInt32(row["RoomId"]);
            string roomNumber = Convert.ToString(row["RoomNumber"]);
            int active = Convert.ToInt32(row["ActiveTenants"]);

            if (active == 0)
            {
                // Empty room: the ordinary move-in payment, reusing this
                // tenant's record instead of creating a new one.
                var data = new MoveInData
                {
                    RoomId = roomId,
                    FirstName = _firstName,
                    MiddleName = _middleName,
                    LastName = _lastName,
                    Address = _address,
                    ContactNumber = _contact,
                    DateOccupied = DateTime.Today,
                    ExistingTenantId = _tenantId
                };

                using (PaymentForm pay = new PaymentForm(data))
                {
                    if (pay.ShowDialog(this) == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                return;
            }

            // Occupied room: joins without paying now, same as Move In.
            string msg =
                "Room " + roomNumber + " is already occupied, so no payment is collected now.\n\n" +
                FullName() + " will be reactivated into Room " + roomNumber + ", and their " +
                "rent is collected with the room's next bill.\n\nContinue?";

            if (MessageBox.Show(msg, "Reactivate Tenant", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (JoinRoom(roomId))
            {
                MessageBox.Show(FullName() + " has been reactivated into Room " + roomNumber + ".",
                    "Tenant Reactivated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelReactivate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Adds the new stay for a tenant joining an occupied room. Every
        /// condition is re-checked inside the transaction - the screen may
        /// have sat open while something changed.
        /// </summary>
        private bool JoinRoom(int roomId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        int capacity, occupied;
                        using (var cmd = new SqlCommand(@"
                            SELECT ISNULL(r.Capacity, 0),
                                   (SELECT COUNT(*) FROM Tenancies tn
                                    WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active')
                            FROM   Rooms r
                            WHERE  r.RoomId = @rid AND r.IsArchived = 0;", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                            using (var rd = cmd.ExecuteReader())
                            {
                                if (!rd.Read())
                                {
                                    rd.Close();
                                    tx.Rollback();
                                    MessageBox.Show("This room is no longer available.", "Room Unavailable",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    LoadRooms();
                                    return false;
                                }
                                capacity = rd.GetInt32(0);
                                occupied = rd.GetInt32(1);
                            }
                        }

                        if (occupied >= capacity)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room filled up while the form was open.", "Room Full",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LoadRooms();
                            return false;
                        }

                        // Emptied in the meantime: a vacant room needs the full
                        // room price first, so go through the payment instead.
                        if (occupied == 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room became vacant while the form was open.\n\n" +
                                            "Click Continue again to take the first payment.",
                                "Room Is Now Vacant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadRooms();
                            return false;
                        }

                        using (var cmd = new SqlCommand(@"
                            SELECT COUNT(*) FROM Tenancies
                            WHERE TenantId = @tid
                              AND (Status = 'Active' OR MoveOutDate >= @date);", conn, tx))
                        {
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
                            if ((int)cmd.ExecuteScalar() > 0)
                            {
                                tx.Rollback();
                                MessageBox.Show(FullName() + " already has an active stay, or moved out today " +
                                                "(reactivation is possible from the day after the move out).",
                                    "Cannot Reactivate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }

                        // The new stay. No bill, share or payment: a tenant
                        // joining an occupied room is billed from the next cycle.
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                            VALUES (@tid, @rid, @date, 'Active');", conn, tx))
                        {
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { Debug.WriteLine(rollbackEx); }

                        Debug.WriteLine(ex);
                        MessageBox.Show("Could not reactivate the tenant: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        private void ReactivateTenantForm_Load(object sender, EventArgs e)
        {

        }
    }
}
