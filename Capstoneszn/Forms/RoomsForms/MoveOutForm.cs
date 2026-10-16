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
            dtpMoveOutDate.MaxDate = DateTime.Today;
            dtpMoveOutDate.Value = DateTime.Today;

            LoadRoomHeader();
            LoadTenants();
            ClearSettlement();
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

                        _roomNumber = r.GetString(0);
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
            // SelectedRows, not CurrentRow: after ClearSelection() the grid
            // still has a CurrentRow (the first one), so reading CurrentRow
            // would quietly pick a tenant nobody clicked.
            if (dgvTenantsToMoveOut.SelectedRows.Count == 0)
            {
                _selected = null;
                ClearSettlement();
                return;
            }

            DataGridViewRow row = dgvTenantsToMoveOut.SelectedRows[0];

            // Guards against the blank new-row and against a half-bound grid.
            if (row.Cells["TenantId"].Value == null ||
                row.Cells["TenantId"].Value == DBNull.Value)
            {
                _selected = null;
                ClearSettlement();
                return;
            }

            _selected = new TenantRow
            {
                TenantId = Convert.ToInt32(row.Cells["TenantId"].Value),
                Name = Convert.ToString(row.Cells["Tenant"].Value),
                Contact = Convert.ToString(row.Cells["Contact"].Value),
                MoveInDate = Convert.ToDateTime(row.Cells["Moved In"].Value),
                Owed = Convert.ToDecimal(row.Cells["Owes"].Value),
                Credit = Convert.ToDecimal(row.Cells["Paid Ahead"].Value)
            };

            ApplyDateBounds(_selected.MoveInDate);
            LoadSettlement(_selected.TenantId);
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
            if (_selected == null)
            {
                MessageBox.Show("Select the tenant you want to move out.",
                    "Move Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime moveOutDate = dtpMoveOutDate.Value.Date;

            if (moveOutDate < _selected.MoveInDate.Date)
            {
                MessageBox.Show(
                    $"{_selected.Name} moved in on {_selected.MoveInDate:MMM d, yyyy}. " +
                    "The move-out date cannot be earlier than that.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (moveOutDate > DateTime.Today)
            {
                MessageBox.Show("The move-out date cannot be in the future.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalWriteOff = _settlement.Sum(l => l.Outstanding);
            decimal totalForfeit = _settlement.Sum(l => l.Credit);

            string reason = txtWriteOffReason.Text.Trim();

            if (totalWriteOff > 0m && reason.Length < 3)
            {
                MessageBox.Show(
                    $"{totalWriteOff:N2} will be written off and cannot be collected afterwards. " +
                    "Record why before continuing.",
                    "Reason Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtWriteOffReason.Focus();
                return;
            }

            string summary = BuildConfirmationText(moveOutDate, totalWriteOff, totalForfeit);
            bool destroysMoney = totalWriteOff > 0m || totalForfeit > 0m;

            using (MoveOutConfirmationForm confirm =
                       new MoveOutConfirmationForm(summary, destroysMoney))
            {
                if (confirm.ShowDialog(this) != DialogResult.OK) return;
            }

            if (ExecuteMoveOut(_selected, moveOutDate, reason))
            {
                MessageBox.Show(
                    $"{_selected.Name} has been moved out of Room {_roomNumber}.",
                    "Move Out Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
