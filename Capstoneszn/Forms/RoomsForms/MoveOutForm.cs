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

namespace Capstoneszn.UserControls
{
    public partial class MoveOutForm : Form
    {

        private const string MoveOutReasonValue = "Moved Out";

        /// <summary>Allowed values of TenantAdjustments.AdjustmentType.</summary>
        private const string AdjustmentWriteOff = "WriteOff";
        private const string AdjustmentForfeit = "Forfeit";
        private const string ForfeitReasonValue = "Credit forfeited at move out (no refund)";

        // No archive flag is written for the tenant. A tenant is archived
        // exactly when they have no active stay in Tenancies - that is
        // derived wherever it is needed, never stored a second time.


        private readonly int _roomId;

        private string _roomNumber = "";
        private int _activeCount;

        private TenantRow _selected;
        private List<SettlementLine> _settlement = new List<SettlementLine>();

        public MoveOutForm(int roomId)
        {
            InitializeComponent();
            _roomId = roomId;

            // NEW (move-out redesign): tick boxes in the occupant grid (wired here, not in the designer)
            dgvTenantsToMoveOut.CurrentCellDirtyStateChanged += dgvTenantsToMoveOut_CurrentCellDirtyStateChanged;
            dgvTenantsToMoveOut.CellValueChanged += dgvTenantsToMoveOut_CellValueChanged;
        }

        private sealed class TenantRow
        {
            public int TenantId;
            public string Name = "";
            public string Contact = "";
            public DateTime MoveInDate;

            /// <summary>Unpaid shares, less anything already written off.</summary>
            public decimal Owed;

            /// <summary>Credit paid ahead that no bill has claimed, less past forfeits.</summary>
            public decimal Credit;
        }


        private sealed class SettlementLine
        {
            public string Category = "";
            public decimal Outstanding;
            public decimal Credit;

            public string Action
            {
                get
                {
                    if (Outstanding > 0m && Credit > 0m)
                        return $"Write off {Outstanding:N2}, forfeit {Credit:N2}";
                    if (Outstanding > 0m) return $"Write off {Outstanding:N2}";
                    if (Credit > 0m) return $"Forfeit {Credit:N2}";
                    return "Nothing to settle";
                }
            }
        }


        private void btnCancelMoveOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MoveOutForm_Load(object sender, EventArgs e)
        {
            // NEW (move-out redesign)
            // Move-out date is today only (decided) - shown, never edited.
            dtpMoveOutDate.MaxDate = DateTime.Today;
            dtpMoveOutDate.Value = DateTime.Today;
            dtpMoveOutDate.Enabled = false;

            // The write-off reason is now typed per payer in the grid above.
            txtWriteOffReason.Visible = false;
            lblReasonCaption.AutoSize = true;
            lblReasonCaption.MaximumSize = new Size(680, 0);
            lblReasonCaption.ForeColor = Color.Gainsboro;
            lblReasonCaption.Text = "Write-off reasons are typed in the table above - one per payer who owes money.";

            lblMoveOutTitle.Text = "Move Out";
            lblSettlementCaption.Text = "What will be settled (per payer)";

            LoadRoomHeaderNew();
            LoadOccupants();
        }

        private void LoadRoomHeader()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT v.RoomNumber,
                           ISNULL(v.Capacity, 0),
                           ISNULL(v.ActiveTenants, 0)
                    FROM   vwRoomStatus v
                    WHERE  v.RoomId = @rid;", conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                        {
                            lblRoomInfo.Text = "Room not found.";
                            return;
                        }

                        // ORIGINAL: _roomNumber = r.GetString(0);
                        _roomNumber = Convert.ToString(r.GetValue(0)) ?? "";   // NEW: RoomNumber is INT
                        int capacity = r.GetInt32(1);
                        _activeCount = r.GetInt32(2);

                        lblRoomInfo.Text =
                            $"Room {_roomNumber}   |   {_activeCount} of {capacity} occupied";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                lblRoomInfo.Text = "Could not load the room.";
            }
        }

        private void LoadTenants()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenantId", typeof(int));
            dt.Columns.Add("Tenant", typeof(string));
            dt.Columns.Add("Contact", typeof(string));
            dt.Columns.Add("Moved In", typeof(DateTime));
            dt.Columns.Add("Owes", typeof(decimal));
            dt.Columns.Add("Paid Ahead", typeof(decimal));

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT t.TenantId,
                           t.FirstName + ' ' + t.LastName AS FullName,
                           t.ContactNumber,
                           tn.MoveInDate,

                           ISNULL((SELECT SUM(bt.Share)
                                   FROM   BillTenants bt
                                   WHERE  bt.TenantId = t.TenantId), 0)
                         - ISNULL((SELECT SUM(a.Amount)
                                   FROM   PaymentAllocations a
                                   JOIN   Payments p ON p.PaymentId = a.PaymentId
                                   WHERE  a.TenantId = t.TenantId
                                     AND  a.BillId IS NOT NULL
                                     AND  a.IsVoided = 0
                                     AND  p.IsVoided = 0), 0)
                         - ISNULL((SELECT SUM(adj.Amount)
                                   FROM   TenantAdjustments adj
                                   WHERE  adj.TenantId = t.TenantId
                                     AND  adj.AdjustmentType = @writeOff), 0) AS Owed,

                           ISNULL((SELECT SUM(a.Amount)
                                   FROM   PaymentAllocations a
                                   JOIN   Payments p ON p.PaymentId = a.PaymentId
                                   WHERE  a.TenantId = t.TenantId
                                     AND  a.BillId IS NULL
                                     AND  a.IsVoided = 0
                                     AND  p.IsVoided = 0), 0)
                         - ISNULL((SELECT SUM(adj.Amount)
                                   FROM   TenantAdjustments adj
                                   WHERE  adj.TenantId = t.TenantId
                                     AND  adj.AdjustmentType = @forfeit), 0) AS Credit

                    FROM   Tenancies tn
                    JOIN   Tenants t ON t.TenantId = tn.TenantId
                    WHERE  tn.RoomId = @rid
                      AND  tn.Status = 'Active'
                    ORDER BY tn.MoveInDate ASC, t.LastName ASC;", conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                    cmd.Parameters.Add("@writeOff", SqlDbType.VarChar, 20).Value = AdjustmentWriteOff;
                    cmd.Parameters.Add("@forfeit", SqlDbType.VarChar, 20).Value = AdjustmentForfeit;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            dt.Rows.Add(
                                r.GetInt32(0),
                                r.GetString(1),
                                r.GetString(2),
                                r.GetDateTime(3),
                                Math.Max(0m, r.GetDecimal(4)),
                                Math.Max(0m, r.GetDecimal(5)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load this room's tenants: " + ex.Message,
                    "Move Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvTenantsToMoveOut.AutoGenerateColumns = true;
            dgvTenantsToMoveOut.DataSource = dt;

            if (dgvTenantsToMoveOut.Columns["TenantId"] != null)
                dgvTenantsToMoveOut.Columns["TenantId"].Visible = false;

            if (dgvTenantsToMoveOut.Columns["Moved In"] != null)
                dgvTenantsToMoveOut.Columns["Moved In"].DefaultCellStyle.Format = "MMM d, yyyy";

            FormatMoneyColumns(dgvTenantsToMoveOut, "Owes", "Paid Ahead");

            dgvTenantsToMoveOut.ClearSelection();

            if (dt.Rows.Count == 0)
            {
                lblMoveOutDescription.Text = "This room has no active tenants.";
                btnMoveOut.Enabled = false;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // The grid selects its first row by itself when it appears.
            // Nobody should be pre-selected for a move out - the landlord
            // must click the tenant on purpose.
            dgvTenantsToMoveOut.ClearSelection();
        }


        private void dgvTenantsToMoveOut_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// A move out cannot predate the move in, and cannot be in the
        /// future. Backdating changes no money - there is no proration -
        /// but the recorded date should still be the truth.
        /// </summary>

        private void ApplyDateBounds(DateTime moveInDate)
        {
            DateTime floor = moveInDate.Date;
            if (floor > DateTime.Today) floor = DateTime.Today;

            // Order matters: widen the window before narrowing it, or the
            // picker throws when the new floor sits above the old ceiling.
            dtpMoveOutDate.MinDate = DateTimePicker.MinimumDateTime;
            dtpMoveOutDate.MaxDate = DateTime.Today;
            dtpMoveOutDate.MinDate = floor;

            if (dtpMoveOutDate.Value.Date < floor)
                dtpMoveOutDate.Value = DateTime.Today;
        }

        private void ClearSettlement()
        {
            _settlement = new List<SettlementLine>();

            dgvSettlement.DataSource = null;
            lblSettlementTotal.Text = "-";
            lblSettlementTotal.ForeColor = Color.Gainsboro;

            txtWriteOffReason.Enabled = false;
            txtWriteOffReason.Text = "";
            lblReasonCaption.Text = "Write-off reason";
            lblReasonCaption.ForeColor = Color.Gray;
        }

        /// <summary>
        /// Every category the ledger knows - the same list TenantsControl
        /// uses, so money in any category is settled, not left behind.
        /// </summary>
        private static readonly string[] Categories =
            { "Rent", "Maintenance", "Water", "Electricity", "Other" };

        /// <summary>
        /// What is left to settle, per category. Uses BillingHelper - the
        /// same queries the payment form and the Tenants module read - so
        /// the amount written off here is exactly the amount those screens
        /// show as owed, and the forfeit is exactly the credit they show.
        ///
        ///   Outstanding = unpaid shares of the CURRENT stay only. Shares
        ///                 from an earlier stay were already settled at that
        ///                 move out, so they are never written off twice.
        ///   Credit      = unclaimed advance, less anything already forfeited.
        /// </summary>
        /// 

        // NOTE (move-out redesign): no longer called - kept as is.

        private void LoadSettlement(int tenantId)
        {
            var outstanding = new Dictionary<string, decimal>();
            var credit = new Dictionary<string, decimal>();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    foreach (string cat in Categories)
                    {
                        outstanding[cat] = BillingHelper.GetTotalOutstanding(conn, tenantId, cat);
                        credit[cat] = BillingHelper.GetAvailableCredit(conn, tenantId, cat);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not work out what is left to settle: " + ex.Message +
                    "\n\nNothing has been changed.",
                    "Move Out", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClearSettlement();
                return;
            }

            BuildSettlement(outstanding, credit);
        }

        private void BuildSettlement(Dictionary<string, decimal> outstanding,
                                     Dictionary<string, decimal> credit)
        {
            var categories = new SortedSet<string>(outstanding.Keys);
            foreach (string c in credit.Keys) categories.Add(c);

            _settlement = new List<SettlementLine>();

            foreach (string cat in categories)
            {
                decimal owed = outstanding.ContainsKey(cat) ? outstanding[cat] : 0m;
                decimal held = credit.ContainsKey(cat) ? credit[cat] : 0m;

                // Rounding and past adjustments can leave a hair below
                // zero. Only a real leftover is worth settling.
                if (owed < 0.005m) owed = 0m;
                if (held < 0.005m) held = 0m;

                if (owed == 0m && held == 0m) continue;

                _settlement.Add(new SettlementLine
                {
                    Category = cat,
                    Outstanding = owed,
                    Credit = held
                });
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Outstanding", typeof(decimal));
            dt.Columns.Add("Credit Held", typeof(decimal));
            dt.Columns.Add("What Happens", typeof(string));

            foreach (SettlementLine line in _settlement)
                dt.Rows.Add(line.Category, line.Outstanding, line.Credit, line.Action);

            dgvSettlement.AutoGenerateColumns = true;
            dgvSettlement.DataSource = dt;

            FormatMoneyColumns(dgvSettlement, "Outstanding", "Credit Held");

            decimal totalWriteOff = _settlement.Sum(l => l.Outstanding);
            decimal totalForfeit = _settlement.Sum(l => l.Credit);

            if (totalWriteOff == 0m && totalForfeit == 0m)
            {
                lblSettlementTotal.Text = "Nothing outstanding - a clean move out";
                lblSettlementTotal.ForeColor = Color.Chartreuse;
            }
            else
            {
                var parts = new List<string>();
                if (totalWriteOff > 0m) parts.Add($"write off {totalWriteOff:N2}");
                if (totalForfeit > 0m) parts.Add($"forfeit {totalForfeit:N2}");

                lblSettlementTotal.Text = "Will " + string.Join(" and ", parts);
                lblSettlementTotal.ForeColor = Color.Gold;
            }

            // The write-off is the landlord's discretionary loss, so it
            // needs an explanation on the record. The forfeit is not - it
            // follows automatically from the no-refund rule.
            bool needsReason = totalWriteOff > 0m;

            txtWriteOffReason.Enabled = needsReason;
            lblReasonCaption.Text = needsReason ? "Write-off reason *" : "Write-off reason";
            lblReasonCaption.ForeColor = needsReason ? Color.White : Color.Gray;

            if (!needsReason) txtWriteOffReason.Text = "";
        }


        /* =================================================================
           CONFIRM AND EXECUTE
           ================================================================= */

        private void btnMoveOut_Click(object sender, EventArgs e)
        {
            MoveOutSelected();  // NEW (move-out redesign): several occupants, dependents too
        }

        private string BuildConfirmationText(DateTime moveOutDate,
                                             decimal totalWriteOff,
                                             decimal totalForfeit)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{_selected.Name} will be moved out of Room {_roomNumber} " +
                          $"on {moveOutDate:MMM d, yyyy}.");
            sb.AppendLine();

            if (totalWriteOff == 0m && totalForfeit == 0m)
            {
                sb.AppendLine("Nothing is outstanding, so no money is affected.");
            }
            else
            {
                foreach (SettlementLine line in _settlement)
                {
                    if (line.Outstanding > 0m)
                        sb.AppendLine($"{line.Outstanding:N2} of unpaid {line.Category} " +
                                      "will be WRITTEN OFF. It cannot be collected afterwards.");

                    if (line.Credit > 0m)
                        sb.AppendLine($"{line.Credit:N2} of {line.Category} credit " +
                                      "will be FORFEITED. It will not be refunded.");
                }
            }

            if (_activeCount <= 1)
            {
                sb.AppendLine();
                sb.AppendLine($"Room {_roomNumber} will be left empty and will stop " +
                              "generating bills until someone moves in.");
            }

            return sb.ToString().TrimEnd();
        }

        // NOTE (move-out redesign): no longer called - kept as is.
        private bool ExecuteMoveOut(TenantRow tenant, DateTime moveOutDate, string reason)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Close the stay. Scoped to the active row so a
                        //    stale form cannot reopen a closed tenancy.
                        using (SqlCommand cmd = new SqlCommand(@"
                            UPDATE Tenancies
                               SET Status        = 'Inactive',
                                   MoveOutDate   = @date,
                                   MoveOutReason = @reason
                             WHERE TenantId = @tid
                               AND RoomId   = @rid
                               AND Status   = 'Active';", conn, tx))
                        {
                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = moveOutDate;
                            cmd.Parameters.Add("@reason", SqlDbType.VarChar, 50).Value = MoveOutReasonValue;
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenant.TenantId;
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;

                            if (cmd.ExecuteNonQuery() != 1)
                            {
                                tx.Rollback();
                                MessageBox.Show(
                                    $"{tenant.Name} is no longer an active tenant of this room. " +
                                    "Nothing was changed.",
                                    "Move Out Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }

                        // 2. Settle the leftover, one row per direction per
                        //    category, so Reports can separate a loss the
                        //    landlord absorbed from credit the landlord kept.
                        foreach (SettlementLine line in _settlement)
                        {
                            if (line.Outstanding > 0m)
                                InsertAdjustment(conn, tx, tenant.TenantId, line.Category,
                        AdjustmentWriteOff, line.Outstanding, reason, moveOutDate);

                            if (line.Credit > 0m)
                                InsertAdjustment(conn, tx, tenant.TenantId, line.Category,
                        AdjustmentForfeit, line.Credit, ForfeitReasonValue, moveOutDate);
                        }

                        // 3. An empty room has no billing cycle. Without
                        //    this the generator back-bills the next tenant
                        //    from the previous occupant's anchor.
                        using (SqlCommand cmd = new SqlCommand(@"
                            UPDATE Rooms
                               SET BillingAnchorDate = NULL
                             WHERE RoomId = @rid
                               AND NOT EXISTS (SELECT 1 FROM Tenancies tn
                                               WHERE tn.RoomId = @rid
                                                 AND tn.Status = 'Active');", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                            cmd.ExecuteNonQuery();
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Move Out",
                        tenant.Name + " moved out of Room " + _roomNumber + " on " +
                        moveOutDate.ToString("MMM dd, yyyy") + " (" + reason + ")");

                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { Debug.WriteLine(rollbackEx); }

                        Debug.WriteLine(ex);
                        // Keep the real reason visible while the system is being
                        // tested - "it failed" alone gives nothing to fix.
                        MessageBox.Show("The move out failed and nothing was changed.\n\n" + ex.Message,
                            "Move Out Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Records one cancelled amount. The original bill, share and
        /// payment are untouched - this row offsets them, so history stays
        /// readable and the balance still reconciles.
        ///
        /// If TenantAdjustments has further NOT NULL columns without
        /// defaults (a recorded-by or a timestamp), add them here.
        /// </summary>
        /// 

        private static void InsertAdjustment(SqlConnection conn, SqlTransaction tx,
                                     int tenantId, string category,
                                     string adjustmentType, decimal amount,
                                     string reason, DateTime adjustmentDate)
        {
            using (SqlCommand cmd = new SqlCommand(@"
            INSERT INTO TenantAdjustments
            (TenantId, BillCategory, AdjustmentType, Amount, Reason,
             AdjustmentDate, RecordedBy)
            VALUES
            (@tid, @cat, @type, @amt, @reason, @date, @by);", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 30).Value = category;
                cmd.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = adjustmentType;
                cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                cmd.Parameters["@amt"].Precision = 18;
                cmd.Parameters["@amt"].Scale = 2;
                cmd.Parameters.Add("@reason", SqlDbType.NVarChar, 255).Value =
                    string.IsNullOrWhiteSpace(reason) ? (object)DBNull.Value : reason;
                cmd.Parameters.Add("@date", SqlDbType.DateTime2).Value = adjustmentDate;
                cmd.Parameters.Add("@by", SqlDbType.Int).Value = Session.UserId;

                cmd.ExecuteNonQuery();
            }
        }

        /* =====================================================================
           NEW (move-out redesign): several occupants at once, dependents too
           ---------------------------------------------------------------------
           Rules (approved):
             - Tick who is leaving. A payer can leave with others in one go.
             - A dependent can leave alone. A head (payer) always takes their
               dependents along - ticking the head ticks and locks them.
             - Each payer is checked on their own:
                 owes money   -> WRITE OFF, with a reason for THAT payer
                 paid ahead   -> FORFEIT (no refund)
                 clean        -> nothing recorded
             - An issued bill never changes (Option A): a share on a bill
               that was already created early still counts as owed.
             - A payer on a Pending maintenance issue: warning, then they are
               removed from that issue's affected tenants.
             - Everyone leaves -> the room is empty: no billing cycle, and a
               scheduled price becomes the room price.
             - Move-out date is today only.
             - One transaction: everyone moves out, or nobody does.
           ===================================================================== */

        /// <summary>NEW: one row of the "who is leaving" grid - a payer or a dependent.</summary>
        /// 

        /// <summary>NEW: one row of the "who is leaving" grid - a payer or a dependent.</summary>
        private sealed class Occupant
        {
            public bool IsPayer;

            // Payer
            public int TenantId;
            public int TenancyId;              // a dependent: the head's TenancyId
            public decimal Owed;               // all categories, current stay
            public decimal Credit;             // all categories, after past forfeits

            // Dependent
            public int DependentId;
            public Occupant Head;              // the payer they belong to

            public string Name = "";
            public string Contact = "";
            public DateTime MoveInDate;
        }

        /// <summary>NEW: what one leaving payer settles, per category.</summary>
        private sealed class PayerSettlement
        {
            public Occupant Payer;
            public Dictionary<string, decimal> Outstanding = new Dictionary<string, decimal>();
            public Dictionary<string, decimal> Credit = new Dictionary<string, decimal>();
            public DateTime? IssuedAheadFrom;  // earliest unpaid bill that starts after today (Option A)
            public List<string> PendingIssues = new List<string>();

            public decimal TotalOwed => Outstanding.Values.Sum();
            public decimal TotalCredit => Credit.Values.Sum();
        }

        private readonly List<Occupant> _occupants = new List<Occupant>();
        private readonly List<PayerSettlement> _settlements = new List<PayerSettlement>();
        private readonly Dictionary<int, string> _reasons = new Dictionary<int, string>();   // TenantId -> write-off reason
        private int _capacity;
        private bool _filling;   // true while the grids are being filled - ignore their events

        // Grid column names (built in code, so no designer change is needed).
        private const string ColPick = "colPick";
        private const string ColReason = "colReason";

        /// <summary>NEW: header line - occupants, payers, dependents.</summary>
        private void LoadRoomHeaderNew()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT v.RoomNumber, ISNULL(v.Capacity, 0),
                           ISNULL(v.ActiveTenants, 0), ISNULL(v.ActiveDependents, 0)
                    FROM   vwRoomStatus v
                    WHERE  v.RoomId = @rid;", conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                        {
                            lblRoomInfo.Text = "Room not found.";
                            return;
                        }

                        _roomNumber = Convert.ToString(r.GetValue(0)) ?? "";
                        _capacity = r.GetInt32(1);
                        _activeCount = r.GetInt32(2);
                        int dependents = r.GetInt32(3);

                        lblRoomInfo.Text = $"Room {_roomNumber}   |   {_activeCount + dependents} of {_capacity} occupied" +
                                           $"   ({_activeCount} paying, {dependents} dependent{(dependents == 1 ? "" : "s")})";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                lblRoomInfo.Text = "Could not load the room.";
            }
        }

        /// <summary>NEW: payers, each followed by their dependents, with balances.</summary>
        private void LoadOccupants()
        {
            _occupants.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // ---- Payers (active stays) ----
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT tn.TenancyId, t.TenantId,
                               t.FirstName + ' ' + t.LastName, t.ContactNumber, tn.MoveInDate
                        FROM   Tenancies tn
                        JOIN   Tenants t ON t.TenantId = tn.TenantId
                        WHERE  tn.RoomId = @rid AND tn.Status = 'Active'
                        ORDER BY tn.MoveInDate ASC, t.LastName ASC;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                _occupants.Add(new Occupant
                                {
                                    IsPayer = true,
                                    TenancyId = r.GetInt32(0),
                                    TenantId = r.GetInt32(1),
                                    Name = r.GetString(2),
                                    Contact = r.IsDBNull(3) ? "" : r.GetString(3),
                                    MoveInDate = r.GetDateTime(4)
                                });
                            }
                        }
                    }

                    // Balances: the same BillingHelper figures every other screen shows.
                    foreach (Occupant p in _occupants)
                    {
                        foreach (string cat in Categories)
                        {
                            p.Owed += Math.Max(0m, BillingHelper.GetTotalOutstanding(conn, p.TenantId, cat));
                            p.Credit += Math.Max(0m, BillingHelper.GetAvailableCredit(conn, p.TenantId, cat));
                        }
                    }

                    // ---- Dependents of those stays ----
                    var dependents = new List<Occupant>();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT d.DependentId, d.TenancyId,
                               d.FirstName + ' ' + d.LastName, d.ContactNumber, d.MoveInDate
                        FROM   Dependents d
                        JOIN   Tenancies tn ON tn.TenancyId = d.TenancyId
                        WHERE  tn.RoomId = @rid AND tn.Status = 'Active' AND d.Status = 'Active'
                        ORDER BY d.MoveInDate ASC, d.DependentId ASC;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                int tenancyId = r.GetInt32(1);
                                dependents.Add(new Occupant
                                {
                                    IsPayer = false,
                                    DependentId = r.GetInt32(0),
                                    TenancyId = tenancyId,
                                    Head = _occupants.FirstOrDefault(p => p.TenancyId == tenancyId),
                                    Name = r.GetString(2),
                                    Contact = r.IsDBNull(3) ? "" : r.GetString(3),
                                    MoveInDate = r.GetDateTime(4)
                                });
                            }
                        }
                    }

                    // Put each dependent right under their head.
                    foreach (Occupant d in dependents.Where(x => x.Head != null))
                    {
                        int at = _occupants.IndexOf(d.Head) + 1;
                        while (at < _occupants.Count && !_occupants[at].IsPayer) at++;
                        _occupants.Insert(at, d);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load this room's occupants: " + ex.Message,
                    "Move Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FillOccupantGrid();
        }

        /// <summary>NEW: the "who is leaving" grid with a tick box per row.</summary>
        private void FillOccupantGrid()
        {
            _filling = true;

            DataGridView g = dgvTenantsToMoveOut;
            g.DataSource = null;
            g.Columns.Clear();
            g.AutoGenerateColumns = false;
            g.ReadOnly = false;                       // the tick column must be editable
            g.SelectionMode = DataGridViewSelectionMode.CellSelect;

            g.Columns.Add(new DataGridViewCheckBoxColumn { Name = ColPick, HeaderText = "Move out", FillWeight = 45 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "Name", ReadOnly = true, FillWeight = 120 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Type", ReadOnly = true, FillWeight = 110 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMovedIn", HeaderText = "Moved In", ReadOnly = true, FillWeight = 70 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOwes", HeaderText = "Owes", ReadOnly = true, FillWeight = 65 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAhead", HeaderText = "Paid Ahead", ReadOnly = true, FillWeight = 70 });
            g.Columns["colOwes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            g.Columns["colAhead"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (Occupant o in _occupants)
            {
                int i = g.Rows.Add(false,
                    o.IsPayer ? o.Name : "   ↳ " + o.Name,
                    o.IsPayer ? "Payer" : "Dependent of " + (o.Head?.Name ?? "-"),
                    o.MoveInDate.ToString("MMM d, yyyy"),
                    o.IsPayer ? o.Owed.ToString("N2") : "—",
                    o.IsPayer ? o.Credit.ToString("N2") : "—");
                g.Rows[i].Tag = o;
            }

            g.ClearSelection();
            _filling = false;

            if (_occupants.Count == 0)
            {
                lblMoveOutDescription.Text = "This room has no occupants.";
                btnMoveOut.Enabled = false;
            }
            else
            {
                lblMoveOutDescription.Text = "Tick everyone who is moving out. Dependents leave with their head.";
            }

            RefreshSettlement();
        }

        // A tick box only "changes" after the edit is committed - commit at once.
        private void dgvTenantsToMoveOut_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTenantsToMoveOut.IsCurrentCellDirty)
                dgvTenantsToMoveOut.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvTenantsToMoveOut_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_filling || e.RowIndex < 0) return;
            if (dgvTenantsToMoveOut.Columns[e.ColumnIndex].Name != ColPick) return;

            Occupant o = dgvTenantsToMoveOut.Rows[e.RowIndex].Tag as Occupant;
            if (o == null) return;

            if (o.IsPayer)
            {
                // A head takes their dependents: tick and lock them (or unlock when unticked).
                bool headLeaving = IsTicked(o);
                _filling = true;
                foreach (DataGridViewRow row in dgvTenantsToMoveOut.Rows)
                {
                    if (row.Tag is Occupant d && !d.IsPayer && d.Head == o)
                    {
                        row.Cells[ColPick].Value = headLeaving;
                        row.Cells[ColPick].ReadOnly = headLeaving;
                        row.DefaultCellStyle.ForeColor = headLeaving ? Color.Gray : dgvTenantsToMoveOut.DefaultCellStyle.ForeColor;
                    }
                }
                _filling = false;
            }

            RefreshSettlement();
        }

        private bool IsTicked(Occupant o)
        {
            foreach (DataGridViewRow row in dgvTenantsToMoveOut.Rows)
                if (row.Tag == o) return row.Cells[ColPick].Value is bool b && b;
            return false;
        }

        private List<Occupant> TickedOccupants()
        {
            return dgvTenantsToMoveOut.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Tag is Occupant && r.Cells[ColPick].Value is bool b && b)
                .Select(r => (Occupant)r.Tag)
                .ToList();
        }

        /// <summary>
        /// NEW: works out, for every ticked payer, what is written off and
        /// forfeited - and fills the bottom grid (one row per payer, with a
        /// Reason cell only for a payer who owes money).
        /// </summary>
        private void RefreshSettlement()
        {
            SaveTypedReasons();   // keep reasons already typed when the list changes
            _settlements.Clear();

            List<Occupant> payers = TickedOccupants().Where(o => o.IsPayer).ToList();

            if (payers.Count > 0)
            {
                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        foreach (Occupant p in payers)
                            _settlements.Add(ReadSettlement(conn, null, p));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    MessageBox.Show("Could not work out what is left to settle: " + ex.Message +
                        "\n\nNothing has been changed.", "Move Out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _settlements.Clear();
                }
            }

            FillSettlementGrid();
        }

        /// <summary>
        /// NEW: one payer's leftovers per category, read with BillingHelper
        /// (the same figures the payment form and Tenants module show).
        /// tx is used again inside the save, to re-check nothing changed.
        /// </summary>
        private PayerSettlement ReadSettlement(SqlConnection conn, SqlTransaction tx, Occupant p)
        {
            var s = new PayerSettlement { Payer = p };

            foreach (string cat in Categories)
            {
                decimal owed = BillingHelper.GetTotalOutstanding(conn, p.TenantId, cat, tx);
                decimal held = BillingHelper.GetAvailableCredit(conn, p.TenantId, cat, tx);

                // Rounding can leave a hair below a centavo - only a real leftover counts.
                if (owed >= 0.005m) s.Outstanding[cat] = owed;
                if (held >= 0.005m) s.Credit[cat] = held;
            }

            // Option A: an unpaid share on a bill already created early (its
            // period starts after today) still counts - say so on screen.
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
                                          JOIN   Payments pay ON pay.PaymentId = a.PaymentId
                                          WHERE  a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                            AND  a.IsVoided = 0 AND pay.IsVoided = 0), 0);", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = p.TenantId;
                cmd.Parameters.Add("@today", SqlDbType.Date).Value = DateTime.Today;
                object o = cmd.ExecuteScalar();
                if (o != null && o != DBNull.Value) s.IssuedAheadFrom = (DateTime)o;
            }

            // Pending maintenance issues this payer is charged on (not repaired yet, no bill yet).
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT mi.IssueTitle
                FROM   MaintenanceAffectedTenants mat
                JOIN   MaintenanceIssues mi ON mi.IssueId = mat.IssueId
                WHERE  mat.TenantId = @tid
                  AND  mi.Status = 'Pending'
                  AND  mi.IsDeleted = 0;", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = p.TenantId;
                using (SqlDataReader r = cmd.ExecuteReader())
                    while (r.Read()) s.PendingIssues.Add(r.GetString(0));
            }

            return s;
        }

        /// <summary>NEW: "Write off Rent 4,000.00; forfeit Rent 500.00" for one payer.</summary>
        private static string WhatHappens(PayerSettlement s)
        {
            var parts = new List<string>();

            if (s.TotalOwed > 0m)
                parts.Add("Write off " + string.Join(", ", s.Outstanding.Select(x => x.Key + " " + x.Value.ToString("N2"))));
            if (s.TotalCredit > 0m)
                parts.Add("Forfeit " + string.Join(", ", s.Credit.Select(x => x.Key + " " + x.Value.ToString("N2"))));

            string text = parts.Count == 0 ? "Clean - nothing to settle" : string.Join("; ", parts);

            if (s.IssuedAheadFrom.HasValue)
                text += $"  (includes the {s.IssuedAheadFrom.Value:MMM d} bill already issued)";
            if (s.PendingIssues.Count > 0)
                text += "  ⚠ removed from pending repair: " + string.Join(", ", s.PendingIssues);

            return text;
        }

        private void FillSettlementGrid()
        {
            _filling = true;

            DataGridView g = dgvSettlement;
            g.DataSource = null;
            g.Columns.Clear();
            g.AutoGenerateColumns = false;
            g.ReadOnly = false;                       // the Reason cell must be editable
            g.SelectionMode = DataGridViewSelectionMode.CellSelect;

            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPayer", HeaderText = "Payer", ReadOnly = true, FillWeight = 80 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "colWhat", HeaderText = "What happens", ReadOnly = true, FillWeight = 190 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = ColReason, HeaderText = "Write-off reason", FillWeight = 120, MaxInputLength = 255 });
            g.Columns["colWhat"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            g.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            foreach (PayerSettlement s in _settlements)
            {
                bool needsReason = s.TotalOwed > 0m;
                _reasons.TryGetValue(s.Payer.TenantId, out string typed);

                int i = g.Rows.Add(s.Payer.Name, WhatHappens(s), needsReason ? (typed ?? "") : "— not needed");
                g.Rows[i].Tag = s;

                DataGridViewCell reason = g.Rows[i].Cells[ColReason];
                reason.ReadOnly = !needsReason;                 // a clean payer has no reason to give
                reason.Style.BackColor = needsReason ? Color.LightYellow : Color.Gainsboro;
                reason.Style.ForeColor = needsReason ? Color.Black : Color.Gray;
            }

            g.ClearSelection();
            _filling = false;

            // Totals line.
            decimal writeOff = _settlements.Sum(s => s.TotalOwed);
            decimal forfeit = _settlements.Sum(s => s.TotalCredit);
            int leaving = TickedOccupants().Count;

            if (leaving == 0)
            {
                lblSettlementTotal.Text = "-";
                lblSettlementTotal.ForeColor = Color.Gainsboro;
            }
            else if (writeOff == 0m && forfeit == 0m)
            {
                lblSettlementTotal.Text = leaving + " leaving - nothing outstanding";
                lblSettlementTotal.ForeColor = Color.Chartreuse;
            }
            else
            {
                var parts = new List<string>();
                if (writeOff > 0m) parts.Add($"write off {writeOff:N2}");
                if (forfeit > 0m) parts.Add($"forfeit {forfeit:N2}");
                lblSettlementTotal.Text = leaving + " leaving - will " + string.Join(" and ", parts);
                lblSettlementTotal.ForeColor = Color.Gold;
            }

            btnMoveOut.Enabled = leaving > 0;
        }

        /// <summary>NEW: remembers the reasons typed in the grid (by payer).</summary>
        private void SaveTypedReasons()
        {
            foreach (DataGridViewRow row in dgvSettlement.Rows)
            {
                if (row.Tag is PayerSettlement s && !row.Cells[ColReason].ReadOnly)
                    _reasons[s.Payer.TenantId] = Convert.ToString(row.Cells[ColReason].Value)?.Trim() ?? "";
            }
        }

        /// <summary>NEW: Move Out button - validate, confirm, save everyone together.</summary>
        private void MoveOutSelected()
        {
            List<Occupant> leaving = TickedOccupants();
            if (leaving.Count == 0)
            {
                MessageBox.Show("Tick at least one occupant to move out.",
                    "Move Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvSettlement.EndEdit();
            SaveTypedReasons();

            // Each payer who owes needs their own reason (the write-off is the landlord's loss).
            foreach (PayerSettlement s in _settlements.Where(x => x.TotalOwed > 0m))
            {
                _reasons.TryGetValue(s.Payer.TenantId, out string reason);
                if (string.IsNullOrWhiteSpace(reason) || reason.Trim().Length < 3)
                {
                    MessageBox.Show(
                        $"{s.Payer.Name} owes {s.TotalOwed:N2}, which will be written off and cannot be collected afterwards.\n\n" +
                        "Type the reason in the Write-off reason column (at least 3 characters).",
                        "Reason Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FocusReason(s);
                    return;
                }
            }

            decimal writeOff = _settlements.Sum(s => s.TotalOwed);
            decimal forfeit = _settlements.Sum(s => s.TotalCredit);

            using (MoveOutConfirmationForm confirm =
                       new MoveOutConfirmationForm(BuildGroupConfirmation(leaving), writeOff > 0m || forfeit > 0m))
            {
                if (confirm.ShowDialog(this) != DialogResult.OK) return;
            }

            btnMoveOut.Enabled = false;   // one click = one save

            try
            {
                ExecuteGroupMoveOut(leaving);
            }
            catch (InvalidOperationException ex)
            {
                // A rule said no (someone already left, a balance changed...). Nothing was saved.
                MessageBox.Show(ex.Message + "\n\nNothing was changed. The list has been refreshed.",
                    "Move Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadRoomHeaderNew();
                LoadOccupants();
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("The move out failed and nothing was changed.\n\n" + ex.Message,
                    "Move Out Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnMoveOut.Enabled = true;
                return;
            }

            MessageBox.Show("Moved out of Room " + _roomNumber + ":\n\n" +
                            string.Join("\n", leaving.Select(o => "   " + o.Name)),
                "Move Out Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FocusReason(PayerSettlement s)
        {
            foreach (DataGridViewRow row in dgvSettlement.Rows)
            {
                if (row.Tag == s)
                {
                    dgvSettlement.CurrentCell = row.Cells[ColReason];
                    dgvSettlement.BeginEdit(true);
                    return;
                }
            }
        }

        private string BuildGroupConfirmation(List<Occupant> leaving)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Moving out of Room {_roomNumber} today ({DateTime.Today:MMM d, yyyy}):");
            sb.AppendLine();

            foreach (Occupant o in leaving)
            {
                if (!o.IsPayer)
                {
                    sb.AppendLine($"   {o.Name}  (dependent of {o.Head?.Name ?? "-"})");
                    continue;
                }

                PayerSettlement s = _settlements.First(x => x.Payer == o);
                sb.AppendLine($"   {o.Name}  (payer)");
                foreach (var x in s.Outstanding)
                    sb.AppendLine($"      {x.Value:N2} unpaid {x.Key} will be WRITTEN OFF");
                foreach (var x in s.Credit)
                    sb.AppendLine($"      {x.Value:N2} {x.Key} credit will be FORFEITED (no refund)");
                if (s.IssuedAheadFrom.HasValue)
                    sb.AppendLine($"      (includes the {s.IssuedAheadFrom.Value:MMM d} bill already issued)");
                foreach (string issue in s.PendingIssues)
                    sb.AppendLine($"      removed from pending repair: {issue}");
            }

            int payersLeaving = leaving.Count(o => o.IsPayer);
            sb.AppendLine();
            if (payersLeaving >= _activeCount && _activeCount > 0)
                sb.AppendLine($"Room {_roomNumber} will be EMPTY and stops billing until someone moves in.");
            else if (payersLeaving > 0)
                sb.AppendLine("Those who stay share the rent from the next bill not yet created.");

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// NEW: the save. One transaction - all of it or none of it.
        ///   1. Lock the room.
        ///   2. Per payer: re-check balances, close the stay, close ALL their
        ///      dependents, write-off / forfeit, leave pending repairs.
        ///   3. Dependents leaving alone: close them.
        ///   4. Room empty -> clear the cycle, apply a scheduled price.
        ///   5. One audit entry.
        /// Throws InvalidOperationException (landlord-readable) when a rule fails.
        /// </summary>
        private void ExecuteGroupMoveOut(List<Occupant> leaving)
        {
            DateTime today = DateTime.Today;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Lock: a payment or move-in for this room waits until we finish.
                        using (SqlCommand cmd = new SqlCommand(
                            "SELECT RoomId FROM Rooms WITH (UPDLOCK, HOLDLOCK) WHERE RoomId = @rid;", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                            cmd.ExecuteScalar();
                        }

                        var log = new List<string>();

                        // 2. Payers
                        foreach (Occupant p in leaving.Where(o => o.IsPayer))
                        {
                            PayerSettlement shown = _settlements.First(s => s.Payer == p);
                            PayerSettlement now = ReadSettlement(conn, tx, p);

                            // A payment or bill landed after the screen was filled: the
                            // amounts the landlord confirmed are no longer the truth.
                            if (now.TotalOwed != shown.TotalOwed || now.TotalCredit != shown.TotalCredit)
                                throw new InvalidOperationException(
                                    p.Name + "'s balance changed while this screen was open.");

                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE Tenancies
                                   SET Status = 'Inactive', MoveOutDate = @date, MoveOutReason = @reason
                                 WHERE TenancyId = @tn AND Status = 'Active';", conn, tx))
                            {
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                                cmd.Parameters.Add("@reason", SqlDbType.NVarChar, 20).Value = MoveOutReasonValue;
                                cmd.Parameters.Add("@tn", SqlDbType.Int).Value = p.TenancyId;
                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new InvalidOperationException(p.Name + " is no longer an active tenant of this room.");
                            }

                            // Dependents always leave with their head (all of them, ticked or not).
                            int depsClosed;
                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE Dependents
                                   SET Status = 'Inactive', MoveOutDate = @date, MoveOutReason = @reason
                                 WHERE TenancyId = @tn AND Status = 'Active';", conn, tx))
                            {
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                                cmd.Parameters.Add("@reason", SqlDbType.NVarChar, 20).Value = MoveOutReasonValue;
                                cmd.Parameters.Add("@tn", SqlDbType.Int).Value = p.TenancyId;
                                depsClosed = cmd.ExecuteNonQuery();
                            }

                            _reasons.TryGetValue(p.TenantId, out string reason);
                            foreach (var x in now.Outstanding)
                                InsertAdjustmentForStay(conn, tx, p, x.Key, AdjustmentWriteOff, x.Value, reason?.Trim(), today);
                            foreach (var x in now.Credit)
                                InsertAdjustmentForStay(conn, tx, p, x.Key, AdjustmentForfeit, x.Value, ForfeitReasonValue, today);

                            // Leaves any repair not done yet (no bill exists for it yet).
                            using (SqlCommand cmd = new SqlCommand(@"
                                DELETE mat
                                FROM   MaintenanceAffectedTenants mat
                                JOIN   MaintenanceIssues mi ON mi.IssueId = mat.IssueId
                                WHERE  mat.TenantId = @tid AND mi.Status = 'Pending' AND mi.IsDeleted = 0;", conn, tx))
                            {
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = p.TenantId;
                                cmd.ExecuteNonQuery();
                            }

                            string money = (now.TotalOwed > 0m ? $", wrote off {now.TotalOwed:N2} ({reason?.Trim()})" : "") +
                                           (now.TotalCredit > 0m ? $", forfeited {now.TotalCredit:N2}" : "");
                            log.Add(p.Name + (depsClosed > 0 ? $" + {depsClosed} dependent(s)" : "") + money);
                        }

                        // 3. Dependents leaving on their own (their head stays).
                        foreach (Occupant d in leaving.Where(o => !o.IsPayer && (o.Head == null || !leaving.Contains(o.Head))))
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE Dependents
                                   SET Status = 'Inactive', MoveOutDate = @date, MoveOutReason = @reason
                                 WHERE DependentId = @id AND Status = 'Active';", conn, tx))
                            {
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = today;
                                cmd.Parameters.Add("@reason", SqlDbType.NVarChar, 20).Value = MoveOutReasonValue;
                                cmd.Parameters.Add("@id", SqlDbType.Int).Value = d.DependentId;
                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new InvalidOperationException(d.Name + " has already moved out.");
                            }
                            log.Add(d.Name + " (dependent of " + (d.Head?.Name ?? "-") + ")");
                        }

                        // 4. Room empty: no billing cycle, and a scheduled price becomes the price
                        //    (approved: a pending price is applied as soon as the room is empty).
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
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                            cmd.ExecuteNonQuery();
                        }

                        // 5. Audit, same transaction.
                        AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Move Out",
                            "Room " + _roomNumber + " on " + today.ToString("MMM dd, yyyy") + ": " + string.Join("; ", log));

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

        /// <summary>NEW: like InsertAdjustment, but also records which stay (TenancyId) it settles.</summary>
        private static void InsertAdjustmentForStay(SqlConnection conn, SqlTransaction tx, Occupant payer,
                                                    string category, string adjustmentType, decimal amount,
                                                    string reason, DateTime adjustmentDate)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO TenantAdjustments
                    (TenantId, TenancyId, BillCategory, AdjustmentType, Amount, Reason, AdjustmentDate, RecordedBy)
                VALUES
                    (@tid, @tn, @cat, @type, @amt, @reason, @date, @by);", conn, tx))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = payer.TenantId;
                cmd.Parameters.Add("@tn", SqlDbType.Int).Value = payer.TenancyId;
                cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = category;
                cmd.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = adjustmentType;
                cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                cmd.Parameters["@amt"].Precision = 18;
                cmd.Parameters["@amt"].Scale = 2;
                cmd.Parameters.Add("@reason", SqlDbType.NVarChar, 255).Value =
                    string.IsNullOrWhiteSpace(reason) ? (object)DBNull.Value : reason;
                cmd.Parameters.Add("@date", SqlDbType.DateTime2).Value = adjustmentDate;
                cmd.Parameters.Add("@by", SqlDbType.Int).Value = Session.UserId;
                cmd.ExecuteNonQuery();
            }
        }



        /* =================================================================
           HELPERS
           ================================================================= */

        private static void FormatMoneyColumns(DataGridView grid, params string[] columns)
        {
            foreach (string name in columns)
            {
                DataGridViewColumn col = grid.Columns[name];
                if (col == null) continue;

                col.DefaultCellStyle.Format = "N2";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

    }
}