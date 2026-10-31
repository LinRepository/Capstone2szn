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
            /* ORIGINAL:
            LoadSourceRoom();
            LoadPendingIssueTenants();
            LoadTenants();
            LoadDestinations();
            RefreshWarnings();
            */
            // NEW (transfer revision)
            LoadSourceRoomNew();
            LoadPendingIssueTenants();
            LoadHouseholds();
            LoadDestinationsNew();
            RefreshWarningsNew();
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
            public int Occupants;                 // NEW (transfer revision): payers + dependents
            public DateTime? FirstUnbilled;       // NEW (transfer revision): first bill not created yet (filled when needed)

            // ORIGINAL: public int FreeSlots => Capacity - ActiveTenants;
            public int FreeSlots => Capacity - Occupants;   // NEW: dependents take a slot too

            public override string ToString()
            {
                // ORIGINAL: return $"Room {RoomNumber}   -   {ActiveTenants}/{Capacity} occupied,   {RoomPrice:N2}";
                return $"Room {RoomNumber}   -   {Occupants}/{Capacity} occupied,   {RoomPrice:N2}";   // NEW
            }
        }


        /* =================================================================
           LOADING
           ================================================================= */

        //OLD CODE NO LONGER USED (transfer revision): Old method (still in the file, unused) LoadSourceRoom() Replaced by LoadSourceRoomNew()
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

        //OLD CODE NO LONGER USED (transfer revision): Old method (still in the file, unused) LoadTenants() Replaced by LoadHouseholds()
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
        //OLD CODE NO LONGER USED (transfer revision): Old method (still in the file, unused) LoadDestinations() Replaced by LoadDestinationsNew()
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
            BeginInvoke(new Action(RefreshWarningsNew));   // NEW (transfer revision)
        }

        private void cboDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            // NEW (transfer revision): the movers' real first bill in the destination.
            RoomItem dest = cboDestination.SelectedItem as RoomItem;

            if (dest == null)
            {
                lblDestinationInfo.Text = "-";
            }
            else
            {
                DateTime? firstBill = FirstBillAt(dest);
                string when = firstBill.HasValue ? firstBill.Value.ToString("MMM d, yyyy") : "-";

                lblDestinationInfo.Text = dest.ActiveTenants == 0
                    ? $"{dest.FreeSlots} free slot(s). The room is empty, so it keeps the tenants' cycle: " +
                      $"first bill at this room's price on {when}."
                    : $"{dest.FreeSlots} free slot(s). They join this room's cycle: first bill on {when}.";
            }

            RefreshWarningsNew();
        }

        private List<TenantItem> CheckedTenants()
        {
            var list = new List<TenantItem>();
            foreach (object o in clbTenants.CheckedItems)
                if (o is TenantItem t) list.Add(t);
            return list;
        }

        //OLD CODE NO LONGER USED (transfer revision): Old method (still in the file, unused) RefreshWarnings() Replaced by RefreshWarningsNew()
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
            TransferSelected();   // NEW (transfer revision): households, dependents, per-category balances
        }

        //OLD CODE NO LONGER USED (transfer revision): Old method (still in the file, unused) ExecuteTransfer(...) Replaced by ExecuteTransferNew(...)
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

        /* =====================================================================
           NEW (transfer revision)
           ---------------------------------------------------------------------
           What changed, in order of the gaps found:
             1. Dependents move WITH their head: their old rows close
                (Inactive, 'Transferred') and are re-added under the head's
                new stay (close and re-add - history stays readable).
             2. Capacity counts the whole household (payers + dependents).
             3. An EMPTY destination starts on the source room's first bill
                NOT created yet - no month is billed twice.
             4. An OCCUPIED destination shows its first bill not created yet
                (Option 1: an issued bill never changes).
             5. Source room left empty -> no cycle, and a scheduled price
                becomes the room price. If people stay, the scheduled price
                applies on their next bill (BillGenerator does that).
             6. "Settled?" uses BillingHelper - the same figures as every
                other screen - shown per category.
             7. A failed save shows the real reason.
             +  The "share rises to" warning uses the NEXT bill's price.
           ===================================================================== */

        /// <summary>NEW: one payer and the dependents who move with them.</summary>
        /// 

        private sealed class HouseholdItem
        {
            public int TenantId;
            public int TenancyId;
            public string Name = "";
            public List<string> Dependents = new List<string>();
            public Dictionary<string, decimal> Owed = new Dictionary<string, decimal>();
            public DateTime? IssuedAheadFrom;   // an unpaid bill already created early

            public int Size => 1 + Dependents.Count;
            public decimal TotalOwed => Owed.Values.Sum();

            public string OwedText =>
                string.Join(", ", Owed.Select(x => x.Key + " " + x.Value.ToString("N2"))) +
                (IssuedAheadFrom.HasValue ? $" (includes the {IssuedAheadFrom.Value:MMM d} bill already issued)" : "");

            public override string ToString()
            {
                string deps = Dependents.Count == 0 ? ""
                    : $"  (+{Dependents.Count} dependent{(Dependents.Count == 1 ? "" : "s")}: {string.Join(", ", Dependents)})";
                return Name + deps + (TotalOwed > 0m ? "   -   owes " + OwedText : "   -   settled");
            }
        }

        // Every category a tenant can owe - the same list Move Out settles.
        private static readonly string[] Categories = { "Rent", "Water", "Maintenance", "Electricity", "Other" };

        private int _sourceDependents;
        private decimal? _sourcePendingPrice;
        private DateTime? _sourcePendingFrom;
        private DateTime? _sourceFirstUnbilled;   // the source room's first bill not created yet

        /// <summary>NEW: source room header, its scheduled price and its first bill not created yet.</summary>
        private void LoadSourceRoomNew()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT v.RoomNumber, ISNULL(v.RoomPrice, 0), ISNULL(v.ActiveTenants, 0),
                               v.BillingAnchorDate, ISNULL(v.ActiveDependents, 0),
                               v.PendingRoomPrice, v.PendingPriceFrom
                        FROM   vwRoomStatus v
                        WHERE  v.RoomId = @rid;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read()) return;

                            _sourceRoomNumber = Convert.ToString(r.GetValue(0)) ?? "";
                            _sourceRoomPrice = r.GetDecimal(1);
                            _sourceActiveCount = r.GetInt32(2);
                            _sourceAnchor = r.IsDBNull(3) ? (DateTime?)null : r.GetDateTime(3);
                            _sourceDependents = r.GetInt32(4);
                            _sourcePendingPrice = r.IsDBNull(5) ? (decimal?)null : r.GetDecimal(5);
                            _sourcePendingFrom = r.IsDBNull(6) ? (DateTime?)null : r.GetDateTime(6);
                        }
                    }

                    _sourceFirstUnbilled = _sourceAnchor.HasValue
                        ? BillGenerator.NextUnbilledPeriod(conn, null, _sourceRoomId, _sourceAnchor.Value, DateTime.Today)
                        : (DateTime?)null;
                }

                lblSourceRoom.Text =
                    $"From Room {_sourceRoomNumber}   |   {_sourceActiveCount} paying, {_sourceDependents} dependent(s)   |   {_sourceRoomPrice:N2} per period";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                lblSourceRoom.Text = "Could not load the room.";
            }
        }

        /// <summary>NEW: one item per payer, with their dependents and what they owe.</summary>
        private void LoadHouseholds()
        {
            clbTenants.Items.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    var list = new List<HouseholdItem>();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT tn.TenancyId, t.TenantId, t.FirstName + ' ' + t.LastName
                        FROM   Tenancies tn
                        JOIN   Tenants t ON t.TenantId = tn.TenantId
                        WHERE  tn.RoomId = @rid AND tn.Status = 'Active'
                        ORDER BY tn.MoveInDate ASC, t.LastName ASC;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;
                        using (SqlDataReader r = cmd.ExecuteReader())
                            while (r.Read())
                                list.Add(new HouseholdItem { TenancyId = r.GetInt32(0), TenantId = r.GetInt32(1), Name = r.GetString(2) });
                    }

                    foreach (HouseholdItem h in list)
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            SELECT FirstName + ' ' + LastName FROM Dependents
                            WHERE  TenancyId = @tn AND Status = 'Active'
                            ORDER BY MoveInDate, DependentId;", conn))
                        {
                            cmd.Parameters.Add("@tn", SqlDbType.Int).Value = h.TenancyId;
                            using (SqlDataReader r = cmd.ExecuteReader())
                                while (r.Read()) h.Dependents.Add(r.GetString(0));
                        }

                        ReadBalances(conn, null, h);
                        clbTenants.Items.Add(h);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load this room's tenants: " + ex.Message,
                    "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// NEW: what the payer still owes per category (BillingHelper - the
        /// same numbers Bill Management shows), plus whether an unpaid bill
        /// was already created early (Option A: it must be paid before moving).
        /// </summary>
        private static void ReadBalances(SqlConnection conn, SqlTransaction tx, HouseholdItem h)
        {
            h.Owed.Clear();
            h.IssuedAheadFrom = null;

            foreach (string cat in Categories)
            {
                decimal owed = BillingHelper.GetTotalOutstanding(conn, h.TenantId, cat, tx);
                if (owed >= 0.005m) h.Owed[cat] = owed;
            }

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT MIN(b.BillingPeriodStart)
                FROM   BillTenants bt
                JOIN   Bills b      ON b.BillId = bt.BillId
                JOIN   Tenancies tn ON tn.TenantId = bt.TenantId AND tn.Status = 'Active'
                WHERE  bt.TenantId = @tid
                  AND  b.BillingPeriodStart > @today
                  AND  b.BillingPeriodStart >= tn.MoveInDate
                  AND  bt.Share > ISNULL((SELECT SUM(a.Amount)
                                          FROM   PaymentAllocations a
                                          JOIN   Payments p ON p.PaymentId = a.PaymentId
                                          WHERE  a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                            AND  a.IsVoided = 0 AND p.IsVoided = 0), 0);", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = h.TenantId;
                cmd.Parameters.Add("@today", SqlDbType.Date).Value = DateTime.Today;
                object o = cmd.ExecuteScalar();
                if (o != null && o != DBNull.Value) h.IssuedAheadFrom = (DateTime)o;
            }
        }

        /// <summary>NEW: rooms with at least one free slot, counting dependents too.</summary>
        private void LoadDestinationsNew()
        {
            cboDestination.Items.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT v.RoomId, v.RoomNumber, v.Capacity, ISNULL(v.ActiveTenants, 0),
                           v.RoomPrice, v.BillingAnchorDate, ISNULL(v.Occupants, 0)
                    FROM   vwRoomStatus v
                    WHERE  v.BuildingId = @bid
                      AND  v.IsArchived = 0
                      AND  v.RoomId <> @src
                      AND  v.Capacity  IS NOT NULL
                      AND  v.RoomPrice IS NOT NULL
                      AND  ISNULL(v.Occupants, 0) < v.Capacity
                    ORDER BY v.RoomNumber ASC;", conn))
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
                                RoomNumber = Convert.ToString(r.GetValue(1)) ?? "",
                                Capacity = r.GetInt32(2),
                                ActiveTenants = r.GetInt32(3),
                                RoomPrice = r.GetDecimal(4),
                                AnchorDate = r.IsDBNull(5) ? (DateTime?)null : r.GetDateTime(5),
                                Occupants = r.GetInt32(6)
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
                MessageBox.Show("Could not load the available rooms: " + ex.Message,
                    "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// NEW: the destination's first bill for the movers.
        ///   Empty room    -> keeps the movers' cycle: the SOURCE room's first
        ///                    bill not created yet (the ones already created
        ///                    there are paid before moving).
        ///   Occupied room -> joins its cycle: the DESTINATION's first bill
        ///                    not created yet (Option 1).
        /// </summary>
        private DateTime? FirstBillAt(RoomItem dest)
        {
            if (dest.ActiveTenants == 0) return _sourceFirstUnbilled;
            if (!dest.AnchorDate.HasValue) return null;

            if (!dest.FirstUnbilled.HasValue)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        dest.FirstUnbilled = BillGenerator.NextUnbilledPeriod(conn, null, dest.RoomId, dest.AnchorDate.Value, DateTime.Today);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return NextDueDate(dest.AnchorDate);   // fallback: the plain next due date
                }
            }
            return dest.FirstUnbilled;
        }

        private List<HouseholdItem> CheckedHouseholds()
        {
            var list = new List<HouseholdItem>();
            foreach (object o in clbTenants.CheckedItems)
                if (o is HouseholdItem h) list.Add(h);
            return list;
        }

        /// <summary>NEW: live warnings under the lists.</summary>
        private void RefreshWarningsNew()
        {
            var selected = CheckedHouseholds();
            RoomItem dest = cboDestination.SelectedItem as RoomItem;
            var lines = new List<string>();

            // Those who stay: their next bill, at the price that bill will use
            // (a scheduled price if that bill starts on/after its date).
            int remaining = _sourceActiveCount - selected.Count;
            if (selected.Count > 0 && remaining > 0 && _sourceFirstUnbilled.HasValue)
            {
                decimal price = _sourcePendingPrice.HasValue && _sourcePendingFrom.HasValue &&
                                _sourceFirstUnbilled.Value >= _sourcePendingFrom.Value
                    ? _sourcePendingPrice.Value
                    : _sourceRoomPrice;
                decimal share = Math.Floor(price / remaining * 100m) / 100m;

                lines.Add($"Room {_sourceRoomNumber} will be left with {remaining} paying tenant(s). " +
                          $"Their share becomes about {share:N2} each from the {_sourceFirstUnbilled.Value:MMM d} bill.");
            }

            var withIssues = selected.Where(h => _tenantsWithPendingIssues.Contains(h.TenantId)).Select(h => h.Name).ToList();
            if (withIssues.Count > 0)
                lines.Add($"Pending maintenance in Room {_sourceRoomNumber} is charged to " +
                          $"{string.Join(", ", withIssues)}. Any cost will follow them to the new room.");

            int moving = selected.Sum(h => h.Size);
            if (dest != null && moving > dest.FreeSlots)
                lines.Add($"Room {dest.RoomNumber} has only {dest.FreeSlots} free slot(s), " +
                          $"but {moving} people are moving (dependents included).");

            var owing = selected.Where(h => h.TotalOwed > 0m).ToList();
            if (owing.Count > 0)
                lines.Add("Settle first: " + string.Join("; ", owing.Select(h => h.Name + " owes " + h.OwedText)) + ".");

            lblWarnings.Text = lines.Count == 0
                ? "No payment is taken and no refund is given. Dependents move with their head."
                : string.Join(Environment.NewLine + Environment.NewLine, lines);
            lblWarnings.ForeColor = lines.Count == 0 ? Color.Gainsboro : Color.Gold;
        }

        /// <summary>NEW: the Transfer button - validate, confirm, save.</summary>
        private void TransferSelected()
        {
            var selected = CheckedHouseholds();
            RoomItem dest = cboDestination.SelectedItem as RoomItem;

            if (selected.Count == 0)
            {
                MessageBox.Show("Tick at least one tenant to transfer.", "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dest == null)
            {
                MessageBox.Show("Choose a destination room.", "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fully settled first - every category, and any bill already created early.
            var owing = selected.Where(h => h.TotalOwed > 0m).ToList();
            if (owing.Count > 0)
            {
                MessageBox.Show(
                    "These tenants still owe money and cannot be transferred yet:\n\n" +
                    string.Join("\n", owing.Select(h => "   " + h.Name + "  -  " + h.OwedText)) +
                    "\n\nRecord their payment in Bill Management first.",
                    "Balance Outstanding", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int moving = selected.Sum(h => h.Size);
            if (moving > dest.FreeSlots)
            {
                MessageBox.Show($"Room {dest.RoomNumber} has only {dest.FreeSlots} free slot(s), but {moving} people are moving (dependents included).",
                    "Not Enough Space", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime? firstBill = FirstBillAt(dest);
            string confirm =
                $"Transfer to Room {dest.RoomNumber} today?\n\n" +
                string.Join("\n", selected.Select(h => "   " + h.Name +
                    (h.Dependents.Count > 0 ? "  + " + string.Join(", ", h.Dependents) : ""))) +
                $"\n\n{moving} people in total. No payment is collected and no refund is given.\n" +
                (firstBill.HasValue ? $"Their first bill in Room {dest.RoomNumber}: {firstBill.Value:MMM d, yyyy}.\n" : "") +
                "\n" + lblWarnings.Text;

            if (MessageBox.Show(confirm, "Confirm Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            btnTransfer.Enabled = false;   // one click = one save

            try
            {
                ExecuteTransferNew(selected, dest);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message + "\n\nNothing was changed. The lists have been refreshed.",
                    "Transfer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ReloadAll();
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("The transfer failed and nothing was changed.\n\n" + ex.Message,
                    "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnTransfer.Enabled = true;
                return;
            }

            MessageBox.Show($"{moving} people moved to Room {dest.RoomNumber}.",
                "Transfer Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ReloadAll()
        {
            LoadSourceRoomNew();
            LoadHouseholds();
            LoadDestinationsNew();
            RefreshWarningsNew();
            btnTransfer.Enabled = cboDestination.Items.Count > 0;
        }

        /// <summary>
        /// NEW: the save - one transaction, all of it or none of it.
        ///   1. Lock both rooms; re-check space and balances.
        ///   2. Per payer: close the old stay, open the new one, close and
        ///      re-add their dependents under the new stay.
        ///   3. Empty destination: its cycle starts at the source room's
        ///      first bill not created yet; a scheduled price applies now.
        ///   4. Source left empty: no cycle; a scheduled price applies now.
        ///   5. One audit entry.
        /// Throws InvalidOperationException (landlord-readable) when a rule fails.
        /// </summary>
        private void ExecuteTransferNew(List<HouseholdItem> selected, RoomItem dest)
        {
            DateTime today = DateTime.Today;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Lock both rooms (lower RoomId first, so two transfers can't deadlock).
                        foreach (int roomId in new[] { _sourceRoomId, dest.RoomId }.OrderBy(x => x))
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "SELECT RoomId FROM Rooms WITH (UPDLOCK, HOLDLOCK) WHERE RoomId = @rid;", conn, tx))
                            {
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = roomId;
                                cmd.ExecuteScalar();
                            }
                        }

                        int destCapacity, destPayers, destOccupants;
                        using (SqlCommand cmd = new SqlCommand(@"
                            SELECT ISNULL(v.Capacity, 0), ISNULL(v.ActiveTenants, 0), ISNULL(v.Occupants, 0)
                            FROM   vwRoomStatus v WHERE v.RoomId = @rid;", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = dest.RoomId;
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                r.Read();
                                destCapacity = r.GetInt32(0);
                                destPayers = r.GetInt32(1);
                                destOccupants = r.GetInt32(2);
                            }
                        }

                        int moving = 0;
                        foreach (HouseholdItem h in selected)
                        {
                            // Re-read inside the transaction: a payment or bill may have landed.
                            ReadBalances(conn, tx, h);
                            if (h.TotalOwed > 0m)
                                throw new InvalidOperationException(h.Name + " now owes " + h.OwedText + ". Settle it first.");

                            using (SqlCommand cmd = new SqlCommand(
                                "SELECT COUNT(*) FROM Dependents WHERE TenancyId = @tn AND Status = 'Active';", conn, tx))
                            {
                                cmd.Parameters.Add("@tn", SqlDbType.Int).Value = h.TenancyId;
                                moving += 1 + (int)cmd.ExecuteScalar();
                            }
                        }

                        if (destOccupants + moving > destCapacity)
                            throw new InvalidOperationException($"Room {dest.RoomNumber} no longer has space for {moving} people.");

                        var log = new List<string>();

                        // 2. Each household
                        foreach (HouseholdItem h in selected)
                        {
                            // Close the old stay FIRST (one active stay per tenant is enforced).
                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE Tenancies
                                   SET Status = 'Inactive', MoveOutDate = @date, MoveOutReason = 'Transferred'
                                 WHERE TenancyId = @tn AND Status = 'Active';", conn, tx))
                            {
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                                cmd.Parameters.Add("@tn", SqlDbType.Int).Value = h.TenancyId;
                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new InvalidOperationException(h.Name + " is no longer an active tenant of this room.");
                            }

                            int newTenancyId;
                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                                OUTPUT INSERTED.TenancyId
                                VALUES (@tid, @rid, @date, 'Active');", conn, tx))
                            {
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = h.TenantId;
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = dest.RoomId;
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                                newTenancyId = (int)cmd.ExecuteScalar();
                            }

                            // Dependents: re-add under the new stay, then close the old rows.
                            int deps;
                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO Dependents (TenancyId, FirstName, MiddleName, LastName, ContactNumber, MoveInDate, Status)
                                SELECT @newTn, FirstName, MiddleName, LastName, ContactNumber, @date, 'Active'
                                FROM   Dependents
                                WHERE  TenancyId = @oldTn AND Status = 'Active';

                                UPDATE Dependents
                                   SET Status = 'Inactive', MoveOutDate = @date, MoveOutReason = 'Transferred'
                                 WHERE TenancyId = @oldTn AND Status = 'Active';", conn, tx))
                            {
                                cmd.Parameters.Add("@newTn", SqlDbType.Int).Value = newTenancyId;
                                cmd.Parameters.Add("@oldTn", SqlDbType.Int).Value = h.TenancyId;
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                                deps = cmd.ExecuteNonQuery() / 2;   // each dependent = 1 insert + 1 update
                            }

                            log.Add(h.Name + (deps > 0 ? $" + {deps} dependent(s)" : ""));
                        }

                        // 3. Empty destination: keep the movers' cycle, starting at the
                        //    source room's first bill NOT created yet (no double month).
                        if (destPayers == 0)
                        {
                            DateTime? sourceAnchor;
                            using (SqlCommand cmd = new SqlCommand(
                                "SELECT BillingAnchorDate FROM Rooms WHERE RoomId = @rid;", conn, tx))
                            {
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;
                                object o = cmd.ExecuteScalar();
                                sourceAnchor = (o == null || o == DBNull.Value) ? (DateTime?)null : (DateTime)o;
                            }

                            // ORIGINAL: DateTime newAnchor = NextDueDate(sourceAnchor) ?? today;
                            DateTime newAnchor = sourceAnchor.HasValue
                                ? BillGenerator.NextUnbilledPeriod(conn, tx, _sourceRoomId, sourceAnchor.Value, today)
                                : today;

                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE Rooms
                                   SET BillingAnchorDate = @date,
                                       RoomPrice         = ISNULL(PendingRoomPrice, RoomPrice),   -- empty room: a scheduled price applies now
                                       PendingRoomPrice  = NULL,
                                       PendingPriceFrom  = NULL
                                 WHERE RoomId = @rid;", conn, tx))
                            {
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = newAnchor;
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = dest.RoomId;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 4. Source left empty: no cycle, and a scheduled price becomes the price.
                        //    (People staying: the scheduled price applies on their next bill - BillGenerator.)
                        using (SqlCommand cmd = new SqlCommand(@"
                            UPDATE Rooms
                               SET BillingAnchorDate = NULL,
                                   RoomPrice         = ISNULL(PendingRoomPrice, RoomPrice),
                                   PendingRoomPrice  = NULL,
                                   PendingPriceFrom  = NULL
                             WHERE RoomId = @rid
                               AND NOT EXISTS (SELECT 1 FROM Tenancies tn
                                               WHERE tn.RoomId = @rid AND tn.Status = 'Active');", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _sourceRoomId;
                            cmd.ExecuteNonQuery();
                        }

                        // 5. Audit, same transaction.
                        AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Transfer",
                            string.Join("; ", log) + " transferred from Room " + _sourceRoomNumber +
                            " to Room " + dest.RoomNumber + " on " + today.ToString("MMM dd, yyyy"));

                        tx.Commit();
                    }
                    catch
                    {
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { Debug.WriteLine(rollbackEx); }
                        throw;
                    }
                }
            }
        }


    }
}
