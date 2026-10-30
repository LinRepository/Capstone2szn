using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.RoomsForms
{
    public partial class TransferForm : Form
    {

        private readonly int _sourceRoomId;

        private string _sourceRoomNumber = "";
        private decimal _sourceRoomPrice;
        private int _sourceActiveCount;

        /// <summary>
        /// The source room's billing anchor. The transferring tenants have
        /// already been billed (and have paid) the source room's current
        /// period, so their cycle continues from it.
        /// </summary>
        private DateTime? _sourceAnchor;

        /// <summary>
        /// Tenants with a Pending maintenance issue charged to them in the
        /// source room. The charge follows the tenant, so this is a warning,
        /// not a block.
        /// </summary>
        private readonly HashSet<int> _tenantsWithPendingIssues = new HashSet<int>();

        public TransferForm(int sourceRoomId)
        {
            InitializeComponent();
            _sourceRoomId = sourceRoomId;
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {
            LoadSourceRoom();
            LoadPendingIssueTenants();
            LoadTenants();
            LoadDestinations();
            RefreshWarnings();
        }


        /* =================================================================
           LIST ITEMS
           ================================================================= */

        private sealed class TenantItem
        {
            public int TenantId;
            public string Name = "";
            public decimal Outstanding;

            public override string ToString()
            {
                return Outstanding > 0m
                    ? $"{Name}   -   owes {Outstanding:N2}"
                    : $"{Name}   -   settled";
            }
        }

        private sealed class RoomItem
        {
            public int RoomId;
            public string RoomNumber = "";
            public int Capacity;
            public int ActiveTenants;
            public decimal RoomPrice;
            public DateTime? AnchorDate;

            public int FreeSlots => Capacity - ActiveTenants;

            public override string ToString()
            {
                return $"Room {RoomNumber}   -   {ActiveTenants}/{Capacity} occupied,   {RoomPrice:N2}";
            }
        }


        /* =================================================================
           LOADING
           ================================================================= */

        private void LoadSourceRoom()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT v.RoomNumber, ISNULL(v.RoomPrice, 0), ISNULL(v.ActiveTenants, 0),
                           v.BillingAnchorDate
                    FROM   vwRoomStatus v
                    WHERE  v.RoomId = @rid;", conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return;

                        // ORIGINAL: _sourceRoomNumber = r.GetString(0);
                        _sourceRoomNumber = Convert.ToString(r.GetValue(0)) ?? "";   // NEW: RoomNumber is INT
                        _sourceRoomPrice = r.GetDecimal(1);
                        _sourceActiveCount = r.GetInt32(2);
                        _sourceAnchor = r.IsDBNull(3) ? (DateTime?)null : r.GetDateTime(3);
                    }
                }

                lblSourceRoom.Text =
                    $"From Room {_sourceRoomNumber}   |   {_sourceActiveCount} tenant(s)   |   {_sourceRoomPrice:N2} per period";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                lblSourceRoom.Text = "Could not load the room.";
            }
        }

        private void LoadPendingIssueTenants()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT DISTINCT mat.TenantId
                    FROM   MaintenanceAffectedTenants mat
                    JOIN   MaintenanceIssues mi ON mi.IssueId = mat.IssueId
                    WHERE  mi.RoomId = @rid
                      AND  mi.Status = 'Pending'
                      AND  mi.IsDeleted = 0;", conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) _tenantsWithPendingIssues.Add(r.GetInt32(0));
                }
            }
            catch (Exception ex)
            {
                // A missing warning must not stop a legitimate transfer.
                Debug.WriteLine(ex);
            }
        }

        private void LoadTenants()
        {
            clbTenants.Items.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT t.TenantId,
                           t.FirstName + ' ' + t.LastName AS FullName,
                           ISNULL((SELECT SUM(bt.Share) FROM BillTenants bt
                                   WHERE bt.TenantId = t.TenantId), 0)
                         - ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                                   WHERE a.TenantId = t.TenantId
                                     AND a.BillId IS NOT NULL
                                     AND a.IsVoided = 0), 0)
                         - ISNULL((SELECT SUM(adj.Amount) FROM TenantAdjustments adj
                                   WHERE adj.TenantId = t.TenantId
                                     AND adj.AdjustmentType = 'WriteOff'), 0)
                           AS Outstanding
                    FROM   Tenancies tn
                    JOIN   Tenants t ON t.TenantId = tn.TenantId
                    WHERE  tn.RoomId = @rid
                      AND  tn.Status = 'Active'
                    ORDER BY tn.MoveInDate ASC, t.LastName ASC;", conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            clbTenants.Items.Add(new TenantItem
                            {
                                TenantId = r.GetInt32(0),
                                Name = r.GetString(1),
                                Outstanding = r.GetDecimal(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load this room's tenants.",
                    "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Rooms that could take them: configured, priced, not archived, not
        /// this room, and with at least one free slot. Occupied rooms are
        /// included - joining an occupied room is allowed, and the tenants
        /// simply adopt its cycle.
        /// </summary>
        private void LoadDestinations()
        {
            cboDestination.Items.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@" SELECT v.RoomId, v.RoomNumber, v.Capacity, ISNULL(v.ActiveTenants, 0),
                           v.RoomPrice, v.BillingAnchorDate
                    FROM   vwRoomStatus v
                    WHERE  v.BuildingId = @bid
                      AND  v.IsArchived = 0
                      AND  v.RoomId <> @src
                      AND  v.Capacity  IS NOT NULL
                      AND  v.RoomPrice IS NOT NULL
                      AND  ISNULL(v.ActiveTenants, 0) < v.Capacity
                    ORDER BY LEN(v.RoomNumber) ASC, v.RoomNumber ASC;", conn))
                {
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = Session.BuildingId;
                    cmd.Parameters.Add("@src", SqlDbType.Int).Value = _sourceRoomId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            cboDestination.Items.Add(new RoomItem
                            {
                                RoomId = r.GetInt32(0),
                                // ORIGINAL: RoomNumber = r.GetString(1),
                                RoomNumber = Convert.ToString(r.GetValue(1)) ?? "",   // NEW: RoomNumber is INT
                                Capacity = r.GetInt32(2),
                                ActiveTenants = r.GetInt32(3),
                                RoomPrice = r.GetDecimal(4),
                                AnchorDate = r.IsDBNull(5) ? (DateTime?)null : r.GetDateTime(5)
                            });
                        }
                    }
                }

                if (cboDestination.Items.Count == 0)
                {
                    lblDestinationInfo.Text = "No other room in this building has a free slot.";
                    btnTransfer.Enabled = false;
                }
                else
                {
                    cboDestination.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load the available rooms.",
                    "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /* =================================================================
           WARNINGS
           ================================================================= */

        private void clbTenants_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // ItemCheck fires BEFORE the item's state changes, so the warnings
            // have to be rebuilt after the control has caught up.
            BeginInvoke(new Action(RefreshWarnings));
        }

        private void cboDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoomItem dest = cboDestination.SelectedItem as RoomItem;

            if (dest == null)
            {
                lblDestinationInfo.Text = "-";
            }
            else
            {
                DateTime? nextDue = NextDueDate(dest.AnchorDate);
                DateTime? ownNextDue = NextDueDate(_sourceAnchor);

                lblDestinationInfo.Text = dest.ActiveTenants == 0
                    ? $"{dest.FreeSlots} free slot(s). The room is empty, so it keeps the tenants' current cycle: " +
                      $"first bill at this room's price on {ownNextDue:MMM d, yyyy}."
                    : $"{dest.FreeSlots} free slot(s). Next bill due {nextDue:MMM d, yyyy}.";
            }

            RefreshWarnings();
        }

        private List<TenantItem> CheckedTenants()
        {
            var list = new List<TenantItem>();
            foreach (object o in clbTenants.CheckedItems)
                if (o is TenantItem t) list.Add(t);
            return list;
        }

        private void RefreshWarnings()
        {
            var selected = CheckedTenants();
            RoomItem dest = cboDestination.SelectedItem as RoomItem;

            var lines = new List<string>();

            // Remaining tenants absorb a larger share once this room's next
            // bill is generated - the room price does not shrink with them.
            int remaining = _sourceActiveCount - selected.Count;
            if (selected.Count > 0 && remaining > 0 && _sourceRoomPrice > 0m)
            {
                decimal newShare = Math.Floor(_sourceRoomPrice / remaining * 100m) / 100m;

                lines.Add(
                    $"Room {_sourceRoomNumber} will be left with {remaining} tenant(s). " +
                    $"Their share rises to about {newShare:N2} each from the next bill.");
            }

            // A maintenance charge belongs to the tenant, not the room, so it
            // follows them. The landlord should know before confirming.
            var withIssues = selected.Where(t => _tenantsWithPendingIssues.Contains(t.TenantId))
                                     .Select(t => t.Name)
                                     .ToList();
            if (withIssues.Count > 0)
            {
                lines.Add(
                    $"Pending maintenance in Room {_sourceRoomNumber} is charged to " +
                    $"{string.Join(", ", withIssues)}. Any cost will follow them to the new room.");
            }

            // Capacity, shown live rather than only on confirm.
            if (dest != null && selected.Count > dest.FreeSlots)
            {
                lines.Add(
                    $"Room {dest.RoomNumber} has only {dest.FreeSlots} free slot(s), " +
                    $"but {selected.Count} tenant(s) are selected.");
            }

            // Arrears block the transfer entirely.
            var owing = selected.Where(t => t.Outstanding > 0m).Select(t => t.Name).ToList();
            if (owing.Count > 0)
            {
                lines.Add($"Settle the balance first for: {string.Join(", ", owing)}.");
            }

            lblWarnings.Text = lines.Count == 0
                ? "No payment is taken and no refund is given. The tenants keep paying on the destination room's cycle."
                : string.Join(Environment.NewLine + Environment.NewLine, lines);

            lblWarnings.ForeColor = lines.Count == 0 ? Color.Gainsboro : Color.Gold;
        }

        /// <summary>
        /// The next period start on or after today, computed from the fixed
        /// anchor the same way BillGenerator does it.
        /// </summary>
        private static DateTime? NextDueDate(DateTime? anchor)
        {
            if (!anchor.HasValue) return null;

            int n = 0;
            while (anchor.Value.AddMonths(n) <= DateTime.Today) n++;

            return anchor.Value.AddMonths(n);
        }


        /* =================================================================
           TRANSFER
           ================================================================= */

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            var selected = CheckedTenants();
            RoomItem dest = cboDestination.SelectedItem as RoomItem;

            if (selected.Count == 0)
            {
                MessageBox.Show("Select at least one tenant to transfer.",
                    "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dest == null)
            {
                MessageBox.Show("Select a destination room.",
                    "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // A tenant cannot carry a debt into a new room and leave the old
            // bill behind. Settle it in Bill Management first.
            var owing = selected.Where(t => t.Outstanding > 0m).ToList();
            if (owing.Count > 0)
            {
                string names = string.Join(Environment.NewLine,
                    owing.Select(t => $"   {t.Name}  -  {t.Outstanding:N2}"));

                MessageBox.Show(
                    "These tenants still owe money and cannot be transferred yet:" +
                    Environment.NewLine + Environment.NewLine + names +
                    Environment.NewLine + Environment.NewLine +
                    "Record their payment in Bill Management first.",
                    "Balance Outstanding", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selected.Count > dest.FreeSlots)
            {
                MessageBox.Show(
                    $"Room {dest.RoomNumber} has only {dest.FreeSlots} free slot(s).",
                    "Not Enough Space", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string confirm =
                $"Transfer {selected.Count} tenant(s) from Room {_sourceRoomNumber} " +
                $"to Room {dest.RoomNumber}?" + Environment.NewLine + Environment.NewLine +
                string.Join(Environment.NewLine, selected.Select(t => "   " + t.Name)) +
                Environment.NewLine + Environment.NewLine +
                "No payment is collected and no refund is given." + Environment.NewLine +
                lblWarnings.Text;

            if (MessageBox.Show(confirm, "Confirm Transfer",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (ExecuteTransfer(selected, dest))
            {
                MessageBox.Show(
                    $"{selected.Count} tenant(s) moved to Room {dest.RoomNumber}.",
                    "Transfer Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ExecuteTransfer(List<TenantItem> selected, RoomItem dest)
        {

            DateTime today = DateTime.Today;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Re-check capacity inside the transaction - the form
                        // may have sat open while someone else moved in.
                        int destCapacity, destOccupied;

                        using (SqlCommand cmd = new SqlCommand(@"
                            SELECT ISNULL(r.Capacity, 0),
                                   (SELECT COUNT(*) FROM Tenancies tn
                                    WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active')
                            FROM   Rooms r WHERE r.RoomId = @rid;", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = dest.RoomId;

                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                r.Read();
                                destCapacity = r.GetInt32(0);
                                destOccupied = r.GetInt32(1);
                            }
                        }

                        if (destOccupied + selected.Count > destCapacity)
                        {
                            tx.Rollback();
                            MessageBox.Show(
                                $"Room {dest.RoomNumber} filled up while this form was open.",
                                "Room Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        foreach (TenantItem t in selected)
                        {
                            // Close the old stay FIRST. A filtered unique index
                            // allows one active tenancy per tenant, so inserting
                            // before closing would be rejected.
                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE Tenancies
                                   SET Status        = 'Inactive',
                                       MoveOutDate   = @date,
                                       MoveOutReason = 'Transferred'
                                 WHERE TenantId = @tid
                                   AND RoomId   = @rid
                                   AND Status   = 'Active';", conn, tx))
                            {
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = t.TenantId;
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;

                                if (cmd.ExecuteNonQuery() != 1)
                                {
                                    tx.Rollback();
                                    MessageBox.Show(
                                        $"{t.Name} is no longer an active tenant of this room. Nothing was changed.",
                                        "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }

                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                                VALUES (@tid, @rid, @date, 'Active');", conn, tx))
                            {
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = t.TenantId;
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = dest.RoomId;
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // An empty destination gets a billing cycle here.
                        //
                        // It must NOT start today: BillGenerator bills every
                        // period from the anchor up to today, so an anchor of
                        // today would charge the destination price at once -
                        // while the tenants have already paid the source room's
                        // current period (settled rule: no payment at transfer,
                        // destination price from the NEXT cycle).
                        //
                        // So the anchor is the tenants' next due date on their
                        // current cycle. The first destination bill falls exactly
                        // where their next source bill would have.
                        if (destOccupied == 0)
                        {
                            DateTime? sourceAnchor;
                            using (SqlCommand cmd = new SqlCommand(
                                "SELECT BillingAnchorDate FROM Rooms WHERE RoomId = @rid;", conn, tx))
                            {
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;
                                object o = cmd.ExecuteScalar();
                                sourceAnchor = (o == null || o == DBNull.Value) ? (DateTime?)null : (DateTime)o;
                            }

                            DateTime newAnchor = NextDueDate(sourceAnchor) ?? today;

                            using (SqlCommand cmd = new SqlCommand(
                                "UPDATE Rooms SET BillingAnchorDate = @date WHERE RoomId = @rid;",
                                conn, tx))
                            {
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = newAnchor;
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = dest.RoomId;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // The same rule in reverse: if the source room is now
                        // empty, it has no cycle until someone moves in.
                        using (SqlCommand cmd = new SqlCommand(@"
                            UPDATE Rooms
                               SET BillingAnchorDate = NULL
                             WHERE RoomId = @rid
                               AND NOT EXISTS (SELECT 1 FROM Tenancies tn
                                               WHERE tn.RoomId = @rid AND tn.Status = 'Active');",
                            conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;
                            cmd.ExecuteNonQuery();
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Transfer",
                            string.Join(", ", selected.Select(t => t.Name)) +
                            " transferred from Room " + _sourceRoomNumber + " to Room " + dest.RoomNumber +
                            " on " + today.ToString("MMM dd, yyyy"));

                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { Debug.WriteLine(rollbackEx); }

                        Debug.WriteLine(ex);
                        MessageBox.Show("The transfer failed and nothing was changed.",
                            "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
