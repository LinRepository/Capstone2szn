using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms;
using Microsoft.Data.SqlClient;
using Capstoneszn.Forms.RoomsForms;

namespace Capstoneszn.UserControls
{
    public partial class MoveInForm : Form
    {

        private int _roomId;

        /* =================================================================
           NEW (move-in redesign): group move-in with dependents.
           The list is kept here until Confirm; nothing touches the database
           before MoveInService.SaveMoveIn (one transaction).
           ================================================================= */

        /// <summary>One row of the "Moving In" list: a payer OR a dependent.</summary>
        private sealed class MoveInEntry
        {
            public MoveInPayer Payer;            // set for a paying tenant
            public MoveInDependent Dependent;    // set for a dependent
            public MoveInPayer HeadPayer;        // dependent's head, if the head is in this list
            public int HeadTenantId;             // dependent's head, if the head already lives here
            public string HeadName = "";

            public bool IsPayer => Payer != null;
            public string Name => IsPayer ? Payer.FullName : Dependent.FullName;
        }

        /// <summary>An item of the "Dependent of" and "Paid by" combo boxes.</summary>
        private sealed class HeadChoice
        {
            public MoveInPayer Payer;   // a payer in the list
            public int TenantId;        // or a tenant already living in the room
            public string Name = "";    // the plain name (for "Dependent of ...")
            public string Text = "";    // what the combo box shows
            public override string ToString() => Text;
        }

        private readonly List<MoveInEntry> _entries = new List<MoveInEntry>();
        private bool _loaded;   // the designer fires CheckedChanged before the room is read

        // The room, read when the form opens
        private string _roomNumber = "";
        private string _roomType = "";
        private int _capacity;
        private decimal _roomPrice;
        private int _activeTenantsNow;          // paying tenants already living here
        private int _occupantsNow;              // paying tenants + dependents already living here
        private DateTime? _anchor;
        private DateTime? _firstUnbilled;       // NEW (option 1): the first rent bill not created yet (a joiner's first bill)
        private bool _vacant;
        private readonly List<HeadChoice> _currentTenants = new List<HeadChoice>();

        private static string Peso(decimal v) => "₱" + v.ToString("N2");

        private List<MoveInEntry> PayerEntries => _entries.Where(x => x.IsPayer).ToList();

        private int FreeSlots => _capacity - _occupantsNow - _entries.Count;

        /// <summary>Reads the room and who already lives there.</summary>
        private bool LoadRoom()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(@"
                        SELECT r.RoomNumber, r.RoomType, r.Capacity, r.RoomPrice,
                               r.BillingAnchorDate, v.ActiveTenants, v.Occupants
                        FROM   Rooms r
                        JOIN   vwRoomStatus v ON v.RoomId = r.RoomId
                        WHERE  r.RoomId = @rid;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read())
                            {
                                MessageBox.Show("This room no longer exists.", "Move In",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            _roomNumber = Convert.ToString(rd.GetValue(0)) ?? "";   // works for text or INT
                            _roomType = Convert.ToString(rd.GetValue(1)) ?? "";
                            _capacity = rd.GetInt32(2);
                            _roomPrice = rd.GetDecimal(3);
                            _anchor = rd.IsDBNull(4) ? (DateTime?)null : rd.GetDateTime(4);
                            _activeTenantsNow = rd.GetInt32(5);
                            _occupantsNow = rd.GetInt32(6);
                        }
                    }

                    // NEW (option 1): bills are created 7 days early, so the next
                    // due date's bill may already exist. A joiner starts on the
                    // first bill NOT created yet.
                    _firstUnbilled = _anchor.HasValue
                        ? BillGenerator.NextUnbilledPeriod(conn, null, _roomId, _anchor.Value, DateTime.Today)
                        : (DateTime?)null;

                    _currentTenants.Clear();
                    using (var cmd = new SqlCommand(@"
                        SELECT t.TenantId, t.FirstName + ' ' + t.LastName
                        FROM   Tenancies tn
                        JOIN   Tenants t ON t.TenantId = tn.TenantId
                        WHERE  tn.RoomId = @rid AND tn.Status = 'Active'
                        ORDER BY tn.MoveInDate, t.TenantId;", conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                        using (var rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                                _currentTenants.Add(new HeadChoice
                                {
                                    TenantId = rd.GetInt32(0),
                                    Name = rd.GetString(1),
                                    Text = rd.GetString(1) + " (already living here)"
                                });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show("Could not load the room: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _vacant = _activeTenantsNow == 0;

            lblRoomInfo.Text = "Room " + _roomNumber + " · " + _roomType + " · " + Peso(_roomPrice) +
                               " / month · Capacity " + _capacity + " · " +
                               (_vacant ? "Vacant" : "Occupied (" + _occupantsNow + " living here)");

            btnConfirmMoveIn.Text = _vacant ? "Continue to Payment" : "Confirm Move In";
            return true;
        }

        /// <summary>Redraws everything that depends on the list.</summary>
        private void RefreshAll()
        {
            var payers = PayerEntries;

            // ---- The list ----
            dgvMoveInList.Rows.Clear();
            for (int i = 0; i < _entries.Count; i++)
            {
                MoveInEntry e = _entries[i];
                string type = e.IsPayer ? "Tenant (pays)" : "Dependent of " + e.HeadName;
                string contact = e.IsPayer ? e.Payer.ContactNumber
                               : string.IsNullOrWhiteSpace(e.Dependent.ContactNumber) ? "—" : e.Dependent.ContactNumber;
                dgvMoveInList.Rows.Add(i + 1, e.Name, type, contact);
            }

            int occupantsAfter = _occupantsNow + _entries.Count;
            int payingAfter = _activeTenantsNow + payers.Count;
            lblOccupantCount.Text = occupantsAfter + " occupant(s) · " + payingAfter + " paying";

            int free = FreeSlots;
            lblSlotsLeft.Text = free <= 0 ? "Room full" : free + " slot(s) left";
            lblSlotsLeft.ForeColor = free <= 0 ? Color.FromArgb(252, 165, 165) : Color.FromArgb(147, 197, 253);
            btnAddToList.Enabled = free > 0;

            // ---- "Dependent of" choices: payers in the list + people already living here ----
            object keep = cboDependentOf.SelectedItem;
            cboDependentOf.Items.Clear();
            foreach (MoveInEntry p in payers)
                cboDependentOf.Items.Add(new HeadChoice { Payer = p.Payer, Name = p.Payer.FullName, Text = p.Payer.FullName });
            foreach (HeadChoice h in _currentTenants)
                cboDependentOf.Items.Add(h);
            ReselectHead(keep);

            // ---- Who pays (vacant room with 2+ payers only) ----
            bool choose = _vacant && payers.Count > 1;
            rdoWholeRoom.Visible = choose;
            rdoIndividual.Visible = choose;
            lblPaidBy.Visible = choose && rdoWholeRoom.Checked;
            cboPaidBy.Visible = choose && rdoWholeRoom.Checked;
            lblPayNote.Visible = !choose;

            int paidByIndex = cboPaidBy.SelectedIndex;
            cboPaidBy.Items.Clear();
            foreach (MoveInEntry p in payers) cboPaidBy.Items.Add(p.Payer.FullName);
            if (cboPaidBy.Items.Count > 0)
                cboPaidBy.SelectedIndex = paidByIndex >= 0 && paidByIndex < cboPaidBy.Items.Count ? paidByIndex : 0;

            if (!_vacant)
                lblPayNote.Text = "Joining an occupied room: nothing is paid at move-in.";
            else if (payers.Count == 0)
                lblPayNote.Text = "Add at least one paying tenant. Dependents have no share.";
            else
                lblPayNote.Text = "Paid by " + payers[0].Payer.FullName + ", the only paying tenant. Dependents have no share.";

            // ---- Summary ----
            if (_vacant)
            {
                lblTotalDueCaption.Text = "Total due today";
                lblShareCaption.Text = "Share per paying tenant";
                lblCoversCaption.Text = "Covers";
                lblNextDueCaption.Text = "Next due";

                lblTotalDue.Text = Peso(_roomPrice);
                lblShare.Text = payers.Count == 0 ? "—" : ShareText(_roomPrice, payers.Count);
                lblCovers.Text = DateTime.Today.ToString("MMM d") + " – " + DateTime.Today.AddMonths(1).ToString("MMM d, yyyy");
                lblNextDue.Text = DateTime.Today.AddMonths(1).ToString("MMM d, yyyy");

                bool whole = payers.Count > 1 && rdoWholeRoom.Checked;
                int receipts = payers.Count == 0 ? 0 : whole ? 1 : payers.Count;
                lblSummaryNote.Text = payers.Count == 0
                    ? "Add at least one paying tenant."
                    : receipts + (receipts == 1 ? " payment · 1 receipt" : " payments · " + receipts + " receipts");
            }
            else
            {
                DateTime next = NextDueDate();
                lblTotalDueCaption.Text = "Due today";
                lblShareCaption.Text = "Share from next bill";
                lblCoversCaption.Text = "Room cycle";
                lblNextDueCaption.Text = "Next bill";

                lblTotalDue.Text = Peso(0m);
                lblShare.Text = ShareText(_roomPrice, Math.Max(payingAfter, 1));
                // ORIGINAL: lblCovers.Text = "Joins the room's cycle";
                lblCovers.Text = "Room's cycle";   // NEW: shorter, fits the label
                lblNextDue.Text = next.ToString("MMM d, yyyy");

                lblSummaryNote.Text = payers.Count == 0
                    ? "Dependents only: no change to billing."
                    // ORIGINAL: : "From the " + next.ToString("MMM d") + " bill, rent is split among " + payingAfter + " paying tenants.";
                    : "From " + next.ToString("MMM d") + ": split among " + payingAfter + " payers.";   // NEW: shorter, fits the label
            }

            btnConfirmMoveIn.Enabled = _entries.Count > 0 && (!_vacant || payers.Count > 0);
        }

        /// <summary>₱3,000.00 when even; ₱333.34 / ₱333.33 when the centavos don't divide evenly.</summary>
        private static string ShareText(decimal price, int count)
        {
            decimal[] shares = MoveInService.ComputeShares(price, count);
            return shares[0] == shares[shares.Length - 1]
                ? Peso(shares[0])
                : Peso(shares[0]) + " / " + Peso(shares[shares.Length - 1]);
        }

        /// <summary>The room's next period start after today (same rule as BillGenerator).</summary>
        private DateTime NextDueDate()
        {
            // NEW (option 1): the first bill not created yet (read in LoadRoom).
            if (_firstUnbilled.HasValue) return _firstUnbilled.Value;
            
            if (!_anchor.HasValue) return DateTime.Today;
            int n = 0;
            while (_anchor.Value.AddMonths(n) <= DateTime.Today) n++;
            return _anchor.Value.AddMonths(n);
        }

        private void ReselectHead(object previous)
        {
            if (previous is HeadChoice old)
            {
                foreach (HeadChoice h in cboDependentOf.Items)
                {
                    if ((old.Payer != null && h.Payer == old.Payer) ||
                        (old.Payer == null && old.TenantId > 0 && h.TenantId == old.TenantId))
                    {
                        cboDependentOf.SelectedItem = h;
                        return;
                    }
                }
            }
            if (cboDependentOf.Items.Count > 0) cboDependentOf.SelectedIndex = 0;
        }

        private void ClearEntryFields()
        {
            txtFName.Clear();
            txtMName.Clear();
            txtLName.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            txtFName.Focus();
        }
        /// <summary>Tenant mode shows Address; Dependent mode shows "Dependent of" and makes contact optional.</summary>
        private void ApplyOccupantType()
        {
            bool dependent = rdoDependent.Checked;
            pnlAddress.Visible = !dependent;
            pnlDependentOf.Visible = dependent;
            lblContactNumber.Text = dependent ? "Contact (optional)" : "Contact Number";
        }

        /// <summary>Clears only the entry fields, never the list.</summary>
        private bool EntryFieldsHaveText()
        {
            return txtFName.Text.Trim().Length > 0 || txtLName.Text.Trim().Length > 0 ||
                   txtContactNumber.Text.Trim().Length > 0;
        }

        private void Warn(string message, Control focus = null)
        {
            MessageBox.Show(message, "Move In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus?.Focus();
        }
        /// <summary>
        /// Who already uses this contact number, or null. Contact numbers are
        /// unique per tenant (settled rule), so a match BLOCKS the entry.
        /// </summary>
        private string ContactOwner(string contact)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 t.FirstName + ' ' + t.LastName
                FROM   Tenants t WHERE t.ContactNumber = @c;", conn))
            {
                cmd.Parameters.Add("@c", SqlDbType.NVarChar, 20).Value = contact;
                conn.Open();
                return cmd.ExecuteScalar() as string;
            }
        }

        /// <summary>
        /// A dependent with the same full name as someone living in the
        /// building gets a WARNING only (settled rule) - it may be a namesake.
        /// </summary>
        private bool NameAlreadyLivingHere(string first, string last)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT COUNT(*) FROM (
                    SELECT t.FirstName, t.LastName
                    FROM   Tenants t
                    JOIN   Tenancies tn ON tn.TenantId = t.TenantId AND tn.Status = 'Active'
                    UNION ALL
                    SELECT d.FirstName, d.LastName
                    FROM   Dependents d
                    WHERE  d.Status = 'Active'
                ) x
                WHERE x.FirstName = @fn AND x.LastName = @ln;", conn))
            {
                cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = first;
                cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = last;
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        /// <summary>Turns the list into what MoveInService and PaymentForm need.</summary>
        private MoveInData BuildMoveInData()
        {
            var data = new MoveInData
            {
                RoomId = _roomId,
                DateOccupied = DateTime.Today,
                ExpectVacant = _vacant
            };

            foreach (MoveInEntry e in _entries.Where(x => x.IsPayer))
                data.Payers.Add(e.Payer);

            foreach (MoveInEntry e in _entries.Where(x => !x.IsPayer))
            {
                e.Dependent.HeadIndex = e.HeadPayer != null ? data.Payers.IndexOf(e.HeadPayer) : -1;
                e.Dependent.HeadTenantId = e.HeadPayer != null ? 0 : e.HeadTenantId;
                data.Dependents.Add(e.Dependent);
            }

            data.WholeRoom = _vacant && data.Payers.Count > 1 && rdoWholeRoom.Checked;
            data.WholeRoomPayerIndex = data.WholeRoom ? Math.Max(cboPaidBy.SelectedIndex, 0) : 0;
            return data;
        }

        public MoveInForm(int roomId)
        {
            InitializeComponent();

            _roomId = roomId;

            txtContactNumber.KeyPress += NumericOnly_KeyPress;
            txtContactNumber.MaxLength = 20;
            txtFName.MaxLength = 50;    // nvarchar(50)
            txtMName.MaxLength = 50;
            txtLName.MaxLength = 50;
            txtAddress.MaxLength = 255;   // nvarchar(255)
            dtpMoveInDate.Value = DateTime.Today;
            dtpMoveInDate.Enabled = false;
        }

        private void NumericOnly_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnCancelMoveIn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MoveInForm_Load(object sender, EventArgs e)
        {
            // NEW (move-in redesign): read the room, then draw the empty list.
            if (!LoadRoom())
            {
                BeginInvoke(new Action(Close));
                return;
            }

            _loaded = true;
            rdoTenant.Checked = true;
            ApplyOccupantType();
            RefreshAll();
        }

        private void btnConfirmMoveIn_Click(object sender, EventArgs e)
        {
            /*
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
        string.IsNullOrWhiteSpace(txtLName.Text))
            {
                MessageBox.Show("First name and last name are required.",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string contact = txtContactNumber.Text.Trim();
            if (contact.Length < 11 || !contact.All(char.IsDigit))
            {
                MessageBox.Show("Contact number must be 11 digits or more.",
                    "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNumber.Focus();
                return;
            }

            if (!ConfirmIfDuplicateContact(contact)) return;

            var data = new MoveInData
            {
                RoomId = _roomId,
                FirstName = txtFName.Text.Trim(),
                MiddleName = txtMName.Text.Trim(),
                LastName = txtLName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactNumber = contact,
                DateOccupied = dtpMoveInDate.Value.Date
            };

            int activeTenants = GetActiveTenantCount();
            if (activeTenants < 0) return;   // query failed, message already shown

            if (activeTenants == 0)
            {
                // Vacant room: landlord policy requires the full room price up front
                using (PaymentForm pay = new PaymentForm(data))
                {
                    if (pay.ShowDialog(this) == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                // Room is already occupied: no payment at move-in.
                // This tenant's share is collected through Bill Management.
                string msg =
                    $"This room is already occupied, so no payment is collected now.\n\n" +
                    $"{data.FirstName} {data.LastName} will be added to the room, and " +
                    $"their rent is collected with the room's next bill.\n\nContinue?";

                if (MessageBox.Show(msg, "Add Tenant", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (AddTenantWithoutPayment(data))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        // Returns -1 if the query failed
        private int GetActiveTenantCount()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Occupancy lives in Tenancies now. Tenants holds only the
                    // person, so a room's headcount comes from its active stays.
                    string sql = @"
                SELECT COUNT(*) FROM Tenancies
                WHERE RoomId = @rid AND Status = 'Active';";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                    MessageBox.Show("Could not check the room: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        private bool AddTenantWithoutPayment(MoveInData data)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Re-check capacity inside the transaction
                        string capSql = @"
                    SELECT r.Capacity,
                           (SELECT COUNT(*) FROM Tenancies tn
                            WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active')
                    FROM Rooms r WHERE r.RoomId = @rid;";

                        int capacity, occupied;
                        using (var cmd = new SqlCommand(capSql, conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = data.RoomId;
                            using (var rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                // An unconfigured room has no capacity yet, so nobody
                                // can move in until the landlord sets one.
                                capacity = rd.IsDBNull(0) ? 0 : rd.GetInt32(0);
                                occupied = rd.GetInt32(1);
                            }
                        }

                        if (capacity == 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room has no capacity set yet.",
                                "Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (occupied >= capacity)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room filled up while the form was open.",
                                "Room Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        // The room emptied while this form was open. A tenant moving into a
                        // vacant room must pay the full room price first, so send them back
                        // through the payment path instead of adding them for free.
                        // Checked BEFORE any insert, so nothing is written and undone.
                        if (occupied == 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room became vacant while the form was open.\n\n" +
                                            "Click Confirm again to take the first payment.",
                                "Room Is Now Vacant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }

                        // 2. Insert the PERSON
                        int tenantId;
                        string tenantSql = @"
                    INSERT INTO Tenants
                        (FirstName, MiddleName, LastName, Address, ContactNumber)
                    OUTPUT INSERTED.TenantId
                    VALUES (@fn, @mn, @ln, @addr, @contact);";

                        using (var cmd = new SqlCommand(tenantSql, conn, tx))
                        {
                            cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = data.FirstName;
                            cmd.Parameters.Add("@mn", SqlDbType.NVarChar, 50).Value =
                                string.IsNullOrWhiteSpace(data.MiddleName)
                                    ? (object)DBNull.Value : data.MiddleName;
                            cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = data.LastName;
                            cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 255).Value =
                                string.IsNullOrWhiteSpace(data.Address)
                                    ? (object)DBNull.Value : data.Address;
                            cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = data.ContactNumber;

                            tenantId = (int)cmd.ExecuteScalar();
                        }

                        // 3. Insert the STAY. Separating these two is what lets a
                        //    tenant move rooms or return later without losing the
                        //    earlier tenancy.
                        string tenancySql = @"
                    INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                    VALUES (@tid, @rid, @date, 'Active');";

                        using (var cmd = new SqlCommand(tenancySql, conn, tx))
                        {
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = data.RoomId;
                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = data.DateOccupied;
                            cmd.ExecuteNonQuery();
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Move In",
    data.FirstName + " " + data.LastName + " joined Room " +
    AuditLogger.RoomNumber(conn, tx, data.RoomId) + " on " + data.DateOccupied.ToString("MMM dd, yyyy") + " (no payment)");

                        // No bill, share or payment here: a tenant joining an
                        // occupied room is billed from the room's next cycle.
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { System.Diagnostics.Debug.WriteLine(rollbackEx); }

                        System.Diagnostics.Debug.WriteLine(ex);
                        MessageBox.Show("Could not add the tenant: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            */

            // NEW (move-in redesign): the whole list moves in together.

            if (_entries.Count == 0)
            {
                Warn("Add at least one person to the list.", txtFName);
                return;
            }

            if (EntryFieldsHaveText() &&
                MessageBox.Show("Some details are typed but were not added to the list.\n\nContinue without them?",
                    "Not Added", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            MoveInData data = BuildMoveInData();

            // ---- Vacant room: payment first (PaymentForm saves everything) ----
            if (_vacant)
            {
                if (data.Payers.Count == 0)
                {
                    Warn("An empty room needs at least one paying tenant. Dependents cannot move in alone.");
                    return;
                }

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

            // ---- Occupied room (joiner): nothing is paid now ----
            string names = string.Join(Environment.NewLine, _entries.Select(x =>
                "   " + x.Name + (x.IsPayer ? "  (pays)" : "  (dependent of " + x.HeadName + ")")));

            string msg =
                "Add these people to Room " + _roomNumber + "?" + Environment.NewLine + Environment.NewLine +
                names + Environment.NewLine + Environment.NewLine +
                "No payment is collected now." + Environment.NewLine +
                (data.Payers.Count > 0
                    ? "Paying tenants are included from the " + NextDueDate().ToString("MMM d, yyyy") + " bill."
                    : "Dependents have no billing.");

            if (MessageBox.Show(msg, "Confirm Move In", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            MoveInResult result;
            btnConfirmMoveIn.Enabled = false;   // one click = one save

            try
            {
                result = MoveInService.SaveMoveIn(data);
            }
            catch (InvalidOperationException ex)
            {
                // A rule said no (room changed, contact taken, room full...). Nothing was saved.
                Warn(ex.Message);
                if (LoadRoom()) RefreshAll();   // show the room as it is now
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show("Move-in failed, nothing was saved: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshAll();
                return;
            }

            using (var done = new MoveInCompleteForm(result.RoomNumber, result.PayingCount, result.DependentCount,
                                                     result.MoveInDate, result.NextDue, result.Receipts))
            {
                done.ShowDialog(this);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // NOTE (move-in redesign): no longer called - MoveInForm_Load reads the room. Kept per team rule.
        // Returns -1 if the query failed
        private int GetActiveTenantCount()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Occupancy lives in Tenancies now. Tenants holds only the
                    // person, so a room's headcount comes from its active stays.
                    string sql = @"
                SELECT COUNT(*) FROM Tenancies
                WHERE RoomId = @rid AND Status = 'Active';";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                    MessageBox.Show("Could not check the room: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Clear();
            txtMName.Clear();
            txtLName.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            dtpMoveInDate.Value = DateTime.Today;
        }

        // NOTE (move-in redesign): no longer called - MoveInService.SaveMoveIn saves joiners. Kept per team rule.
        private bool AddTenantWithoutPayment(MoveInData data)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Re-check capacity inside the transaction
                        string capSql = @"
                    SELECT r.Capacity,
                           (SELECT COUNT(*) FROM Tenancies tn
                            WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active')
                    FROM Rooms r WHERE r.RoomId = @rid;";

                        int capacity, occupied;
                        using (var cmd = new SqlCommand(capSql, conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = data.RoomId;
                            using (var rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                // An unconfigured room has no capacity yet, so nobody
                                // can move in until the landlord sets one.
                                capacity = rd.IsDBNull(0) ? 0 : rd.GetInt32(0);
                                occupied = rd.GetInt32(1);
                            }
                        }

                        if (capacity == 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room has no capacity set yet.",
                                "Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (occupied >= capacity)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room filled up while the form was open.",
                                "Room Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        // The room emptied while this form was open. A tenant moving into a
                        // vacant room must pay the full room price first, so send them back
                        // through the payment path instead of adding them for free.
                        // Checked BEFORE any insert, so nothing is written and undone.
                        if (occupied == 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room became vacant while the form was open.\n\n" +
                                            "Click Confirm again to take the first payment.",
                                "Room Is Now Vacant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }

                        // 2. Insert the PERSON
                        int tenantId;
                        string tenantSql = @"
                    INSERT INTO Tenants
                        (FirstName, MiddleName, LastName, Address, ContactNumber)
                    OUTPUT INSERTED.TenantId
                    VALUES (@fn, @mn, @ln, @addr, @contact);";

                        using (var cmd = new SqlCommand(tenantSql, conn, tx))
                        {
                            cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = data.FirstName;
                            cmd.Parameters.Add("@mn", SqlDbType.NVarChar, 50).Value =
                                string.IsNullOrWhiteSpace(data.MiddleName)
                                    ? (object)DBNull.Value : data.MiddleName;
                            cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = data.LastName;
                            cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 255).Value =
                                string.IsNullOrWhiteSpace(data.Address)
                                    ? (object)DBNull.Value : data.Address;
                            cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = data.ContactNumber;

                            tenantId = (int)cmd.ExecuteScalar();
                        }

                        // 3. Insert the STAY. Separating these two is what lets a
                        //    tenant move rooms or return later without losing the
                        //    earlier tenancy.
                        string tenancySql = @"
                    INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                    VALUES (@tid, @rid, @date, 'Active');";

                        using (var cmd = new SqlCommand(tenancySql, conn, tx))
                        {
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = data.RoomId;
                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = data.DateOccupied;
                            cmd.ExecuteNonQuery();
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Move In",
    data.FirstName + " " + data.LastName + " joined Room " +
    AuditLogger.RoomNumber(conn, tx, data.RoomId) + " on " + data.DateOccupied.ToString("MMM dd, yyyy") + " (no payment)");

                        // No bill, share or payment here: a tenant joining an
                        // occupied room is billed from the room's next cycle.
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { System.Diagnostics.Debug.WriteLine(rollbackEx); }

                        System.Diagnostics.Debug.WriteLine(ex);
                        MessageBox.Show("Could not add the tenant: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }


        /// <summary>
        /// Warns if the contact number already belongs to someone. Deliberately
        /// a warning, not a block: family members share numbers. It catches the
        /// accidental double entry without forbidding the legitimate one.
        /// Returns false if the landlord decides not to continue.
        /// </summary>
        private bool ConfirmIfDuplicateContact(string contactNumber)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT TOP 1 t.FirstName + ' ' + t.LastName AS FullName,
                   ISNULL(r.RoomNumber, '-') AS RoomNumber,
                   CASE WHEN tn.TenancyId IS NULL THEN 'Inactive' ELSE 'Active' END AS Standing
            FROM   Tenants t
            LEFT JOIN Tenancies tn ON tn.TenantId = t.TenantId AND tn.Status = 'Active'
            LEFT JOIN Rooms r      ON r.RoomId = tn.RoomId
            WHERE  t.ContactNumber = @contact
            ORDER BY tn.TenancyId DESC;", conn))
                {
                    cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = contactNumber;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return true;   // no match, carry on

                        string msg =
                            $"A tenant with this contact number already exists:\n\n" +
                            $"{r.GetString(0)} - Room {r.GetString(1)} ({r.GetString(2)})\n\n" +
                            $"Continue anyway?";

                        return MessageBox.Show(msg, "Possible Duplicate",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                    }
                }
            }
            catch (Exception ex)
            {
                // A failed check must not block a legitimate move-in.
                System.Diagnostics.Debug.WriteLine(ex);
                return true;
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (FreeSlots <= 0)
            {
                Warn("Room " + _roomNumber + " is full. Payers and dependents both take a slot.");
                return;
            }

            string first = txtFName.Text.Trim();
            string middle = txtMName.Text.Trim();
            string last = txtLName.Text.Trim();
            string contact = txtContactNumber.Text.Trim();

            if (!MoveInService.IsValidName(first)) { Warn("Enter a valid first name (letters, spaces, . ' - only).", txtFName); return; }
            if (middle.Length > 0 && !MoveInService.IsValidName(middle)) { Warn("Middle name may contain letters, spaces, . ' - only.", txtMName); return; }
            if (!MoveInService.IsValidName(last)) { Warn("Enter a valid last name (letters, spaces, . ' - only).", txtLName); return; }

            if (rdoTenant.Checked)
            {
                // ---- Paying tenant ----
                string address = txtAddress.Text.Trim();
                if (address.Length == 0) { Warn("Address is required.", txtAddress); return; }

                if (!MoveInService.IsValidContact(contact))
                {
                    Warn("Contact number must be 11 to 20 digits.", txtContactNumber);
                    return;
                }

                if (_entries.Any(x => x.IsPayer && x.Payer.ContactNumber == contact))
                {
                    Warn("This contact number is already in the list.", txtContactNumber);
                    return;
                }

                string owner;
                try
                {
                    owner = ContactOwner(contact);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                    Warn("Could not check the contact number: " + ex.Message);
                    return;
                }

                if (owner != null)
                {
                    Warn("Contact number " + contact + " already belongs to " + owner +
                         ". Each paying tenant needs their own number.", txtContactNumber);
                    return;
                }

                _entries.Add(new MoveInEntry
                {
                    Payer = new MoveInPayer
                    {
                        FirstName = first,
                        MiddleName = middle,
                        LastName = last,
                        Address = address,
                        ContactNumber = contact
                    }
                });
            }
            else
            {
                // ---- Dependent ----
                if (contact.Length > 0 && !MoveInService.IsValidContact(contact))
                {
                    Warn("A dependent's contact number is optional, but if given it must be 11 to 20 digits.", txtContactNumber);
                    return;
                }

                if (!(cboDependentOf.SelectedItem is HeadChoice head))
                {
                    Warn("Add the paying tenant first, then choose who this dependent belongs to.", cboDependentOf);
                    return;
                }

                // Same name as someone listed or living in the building: warning only.
                string fullName = first + " " + last;
                bool sameName = _entries.Any(x => string.Equals(x.Name, fullName, StringComparison.OrdinalIgnoreCase));
                if (!sameName)
                {
                    try { sameName = NameAlreadyLivingHere(first, last); }
                    catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }   // a failed check must not block
                }

                if (sameName &&
                    MessageBox.Show(fullName + " has the same name as someone already listed or living in the building." +
                                    Environment.NewLine + Environment.NewLine + "Add anyway?",
                        "Same Name", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                _entries.Add(new MoveInEntry
                {
                    Dependent = new MoveInDependent
                    {
                        FirstName = first,
                        MiddleName = middle,
                        LastName = last,
                        ContactNumber = contact
                    },
                    HeadPayer = head.Payer,
                    HeadTenantId = head.Payer == null ? head.TenantId : 0,
                    HeadName = head.Name
                });
            }

            ClearEntryFields();
            RefreshAll();
        }
        /// <summary>NEW: Tenant / Dependent switch.</summary>
        private void rdoOccupantType_CheckedChanged(object sender, EventArgs e)
        {
            if (!_loaded) return;
            ApplyOccupantType();
        }

        /// <summary>NEW: Whole Room / Individual switch.</summary>
        private void rdoPaymentMode_CheckedChanged(object sender, EventArgs e)
        {
            if (!_loaded) return;
            RefreshAll();
        }
        /// <summary>NEW: the X button. Removing a payer also removes their dependents.</summary>
        private void dgvMoveInList_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.RowIndex < 0 || e.RowIndex >= _entries.Count || e.ColumnIndex != colRemove.Index) return;

            MoveInEntry entry = _entries[e.RowIndex];
            var toRemove = new List<MoveInEntry> { entry };

            if (entry.IsPayer)
            {
                var dependents = _entries.Where(x => !x.IsPayer && x.HeadPayer == entry.Payer).ToList();
                if (dependents.Count > 0)
                {
                    string list = string.Join(Environment.NewLine, dependents.Select(d => "   " + d.Name));
                    if (MessageBox.Show("Removing " + entry.Name + " also removes their dependent(s):" +
                                        Environment.NewLine + Environment.NewLine + list +
                                        Environment.NewLine + Environment.NewLine + "Continue?",
                            "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    toRemove.AddRange(dependents);
                }
            }

            foreach (MoveInEntry x in toRemove) _entries.Remove(x);
            RefreshAll();
        }
    }
}
