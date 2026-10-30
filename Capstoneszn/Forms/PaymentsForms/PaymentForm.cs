using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Capstoneszn.Forms.RoomsForms;
using Capstoneszn.Forms.PaymentsForms;   // NEW (move-in redesign): PayerCardControl lives here

namespace Capstoneszn.Forms
{
    public partial class PaymentForm : Form
    {
        private MoveInData _data;
        private decimal _roomPrice;

        private readonly List<PayerCardControl> _cards = new List<PayerCardControl>();
        private decimal[] _shares = new decimal[0];   // each payer's share of the first bill
        private string _roomNumber = "";
        private bool _ready;                          // true once the room loaded without problems
        private bool _building;                       // true while cards are being (re)built - ignore their events

        public PaymentForm(MoveInData data)
        {
            InitializeComponent();

            _data = data;

            // Date is fixed - it anchors the billing cycle
            dtpPaymentDate.Value = DateTime.Today;
            dtpPaymentDate.Enabled = false;

            // Category: Rent, locked
            cboPaymentCategory.Items.Clear();
            cboPaymentCategory.Items.Add("Rent");
            cboPaymentCategory.SelectedIndex = 0;
            cboPaymentCategory.Enabled = false;

            // Payment type: always Full. The amount is locked to the room price,
            // which is exactly the first bill - paid equals owed.
            cboPaymentType.Items.Clear();
            cboPaymentType.Items.Add("Full Payment");
            cboPaymentType.SelectedIndex = 0;
            cboPaymentType.Enabled = false;

            // Amount is always visible
            lblPaymentAmount.Visible = true;
            txtAmountValue.Visible = true;

            RadioBtnCash.Checked = true;
            RadioBtnCash.CheckedChanged += PaymentMethod_Changed;
            RadioBtnGCash.CheckedChanged += PaymentMethod_Changed;
            PaymentMethod_Changed(null, EventArgs.Empty);

            // NEW (move-in redesign)
            // The old fields above belong to the hidden legacy panel; they stay so nothing breaks.
            // Reactivation (ReactivateTenantForm) fills only the single-person
            // fields, so turn them into Payers[0] - one way of saving for both.
            _data.UseSinglePersonIfNoList();

            // This form only opens for an EMPTY room (MoveInForm and
            // ReactivateTenantForm both check first). The save re-checks it,
            // in case someone moved in while this form was open.
            _data.ExpectVacant = true;
        }

        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && txtAmountValue.Text.Contains("."))
                e.Handled = true;
        }

        private void PaymentMethod_Changed(object sender, EventArgs e)
        {
            bool isGCash = RadioBtnGCash.Checked;

            lblReferenceNumber.Visible = isGCash;
            txtReferenceNumber.Visible = isGCash;

            if (!isGCash) txtReferenceNumber.Clear();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // ORIGINAL: LoadRoomPrice();

            // NEW (move-in redesign)
            _ready = LoadRoom();
            if (!_ready)
            {
                btnContinuePayment.Enabled = false;
                SetStatus("The room could not be loaded. Press Back and try again.", false);
                return;
            }

            _shares = MoveInService.ComputeShares(_roomPrice, _data.Payers.Count);
            ShowHeaderAndSummary();
            FillPaidBy();
            FillCreditTo();   // NEW (credit choice)
            BuildCards();
        }

        private void btnCancelPayment_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnContinuePayment_Click(object sender, EventArgs e)
        {
            // NEW (move-in redesign): Payer Cards -> Confirm -> one save -> Move-In Complete.

            if (!_ready) return;

            // 1. Every card must be at least what is due.
            if (!Recalculate())
            {
                Warn(lblStatus.Text);
                PayerCardControl first = _cards.FirstOrDefault(c => c.AmountPaid == null || c.AmountPaid < c.AmountDue);
                first?.FocusAmount();
                return;
            }

            // 2. GCash reference numbers, then the typo guard for big advances.
            if (!CheckReferences()) return;
            if (!ConfirmLargeAdvances()) return;

            // 3. Put what was typed into the move-in data, then confirm (C1).
            CopyCardsToData();

            using (ConfirmPaymentForm confirm = new ConfirmPaymentForm(BuildConfirmInfo()))
            {
                if (confirm.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            // 4. Save everything: people, stays, dependents, first bill, shares,
            //    receipts. One transaction - all of it or none of it.
            MoveInResult result;
            btnContinuePayment.Enabled = false;   // one click = one save

            try
            {
                result = MoveInService.SaveMoveIn(_data);
            }
            catch (InvalidOperationException ex)
            {
                // A rule said no (room changed, contact or reference taken...). Nothing was saved.
                Warn(ex.Message);
                Recalculate();
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show("Move-in failed, nothing was saved: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Recalculate();
                return;
            }

            // 5. Show the receipts (View / Print), then close back to Rooms.
            using (var done = new MoveInCompleteForm(result.RoomNumber, result.PayingCount, result.DependentCount,
                                                     result.MoveInDate, result.NextDue, result.Receipts))
            {
                done.ShowDialog(this);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReferenceNumber.Clear();
            RadioBtnCash.Checked = true;
            // Amount, Category, Payment Type and Date are fixed - don't clear them
        }

        // NOTE (move-in redesign): no longer called. LoadRoom() replaced it. Kept as is.
        private void LoadRoomPrice()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT RoomPrice FROM Rooms WHERE RoomId = @rid";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _data.RoomId);
                        object result = cmd.ExecuteScalar();
                        _roomPrice = (result == null || result == DBNull.Value)
                            ? 0m : Convert.ToDecimal(result);
                    }

                    txtAmountValue.Text = _roomPrice.ToString("N2");
                    txtAmountValue.ReadOnly = true;
                    txtAmountValue.BackColor = Color.Gainsboro;
                    txtAmountValue.ForeColor = Color.Black;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load the room price: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // NOTE (move-in redesign): no longer called. MoveInService.SaveMoveIn replaced it
        //   (this version handles one tenant only, and its PaymentAllocations insert
        //   has no Category / PaymentType, which Billing v2 requires). Kept as is.
        private void SaveMoveIn(decimal amount, string method, string refNo)
        {

            string receiptNo = "R" + DateTime.Now.ToString("yyyyMMddHHmmss");
            bool saved = false;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Re-check capacity - the form may have sat open a while.
                        //    Occupancy comes from Tenancies now; Tenants holds only
                        //    the person.
                        string capSql = @"
                    SELECT r.Capacity,
                           (SELECT COUNT(*) FROM Tenancies tn
                            WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active')
                    FROM Rooms r WHERE r.RoomId = @rid;";

                        int capacity, occupied;
                        using (var cmd = new SqlCommand(capSql, conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            using (var rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                capacity = rd.IsDBNull(0) ? 0 : rd.GetInt32(0);
                                occupied = rd.GetInt32(1);
                            }
                        }

                        if (capacity == 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room has no capacity set yet.",
                                "Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (occupied >= capacity)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room filled up while the form was open.",
                                "Room Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // 2. The PERSON. A returning tenant (reactivated from
                        //    Settings > Archive) keeps their existing record;
                        //    only a new person gets a new Tenants row.
                        int newTenantId;

                        if (_data.ExistingTenantId > 0)
                        {
                            using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) FROM Tenancies
                        WHERE TenantId = @tid AND Status = 'Active';", conn, tx))
                            {
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _data.ExistingTenantId;
                                if ((int)cmd.ExecuteScalar() > 0)
                                {
                                    tx.Rollback();
                                    MessageBox.Show("This tenant already has an active stay, so they cannot be reactivated again.",
                                        "Already Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            // A new stay must begin after the last one ended. Out and
                            // back in on the same day is a correction, not a new stay -
                            // and it would make the old stay's bills look current again.
                            using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) FROM Tenancies
                        WHERE TenantId = @tid AND MoveOutDate >= @date;", conn, tx))
                            {
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _data.ExistingTenantId;
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = _data.DateOccupied;
                                if ((int)cmd.ExecuteScalar() > 0)
                                {
                                    tx.Rollback();
                                    MessageBox.Show("This tenant moved out on or after this date. A returning tenant " +
                                                    "can be reactivated from the day after their move out.",
                                        "Too Soon to Reactivate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            newTenantId = _data.ExistingTenantId;
                        }
                        else
                        {
                            string tenantSql = @"
                    INSERT INTO Tenants
                        (FirstName, MiddleName, LastName, Address, ContactNumber)
                    OUTPUT INSERTED.TenantId
                    VALUES (@fn, @mn, @ln, @addr, @contact);";

                            using (var cmd = new SqlCommand(tenantSql, conn, tx))
                            {
                                cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = _data.FirstName;
                                cmd.Parameters.Add("@mn", SqlDbType.NVarChar, 50).Value =
                                    string.IsNullOrWhiteSpace(_data.MiddleName)
                                        ? (object)DBNull.Value : _data.MiddleName;
                                cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = _data.LastName;
                                cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 255).Value =
                                    string.IsNullOrWhiteSpace(_data.Address)
                                        ? (object)DBNull.Value : _data.Address;
                                cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = _data.ContactNumber;

                                newTenantId = (int)cmd.ExecuteScalar();
                            }
                        }

                        // 2a. Insert the STAY
                        using (var cmd = new SqlCommand(@"
                    INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                    VALUES (@tid, @rid, @date, 'Active');", conn, tx))
                        {
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = _data.DateOccupied;
                            cmd.ExecuteNonQuery();
                        }

                        // 2b. Anchor the billing cycle. If this tenant is alone in the
                        //     room, the cycle starts on their move-in day. If others
                        //     already live here, the room keeps its existing anchor.
                        DateTime start = _data.DateOccupied;

                        using (var cmd = new SqlCommand(
                            @"UPDATE Rooms SET BillingAnchorDate = @start
                          WHERE RoomId = @rid
                            AND NOT EXISTS (SELECT 1 FROM Tenancies tn
                            WHERE tn.RoomId = @rid AND tn.Status = 'Active'
                            AND tn.TenantId <> @tid);", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            cmd.Parameters.Add("@start", SqlDbType.Date).Value = start;
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.ExecuteNonQuery();
                        }

                        // 2c. The first bill. Period runs anchor to anchor, matching
                        //     what the generator will produce for every later period.
                        //
                        //     Re-let on the same day: if the previous occupants
                        //     left on the very day their bill started, a Rent bill
                        //     for this room already begins today. The room is then
                        //     let twice in that period, so the newcomer joins THAT
                        //     bill: their share is added and the bill's total rises
                        //     by the same amount. Old shares, payments, write-offs
                        //     and forfeits are not touched, and shares still add
                        //     up to the bill.
                        int billId = 0;
                        using (var cmd = new SqlCommand(@"
                    SELECT BillId FROM Bills WITH (UPDLOCK, HOLDLOCK)
                    WHERE  RoomId = @rid AND BillCategory = 'Rent'
                      AND  BillingPeriodStart = @start;", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            cmd.Parameters.Add("@start", SqlDbType.Date).Value = start;
                            object existing = cmd.ExecuteScalar();
                            if (existing != null && existing != DBNull.Value)
                                billId = Convert.ToInt32(existing);
                        }

                        if (billId > 0)
                        {
                            using (var cmd = new SqlCommand(@"
                        UPDATE Bills SET Amount = Amount + @amt WHERE BillId = @bid;", conn, tx))
                            {
                                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                                cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                                cmd.Parameters["@amt"].Precision = 18;
                                cmd.Parameters["@amt"].Scale = 2;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (var cmd = new SqlCommand(
                                @"INSERT INTO Bills
                              (RoomId, BillCategory, BillingPeriodStart,
                               BillingPeriodEnd, DueDate, Amount)
                          OUTPUT INSERTED.BillId
                          VALUES (@rid, 'Rent', @start,
                                  DATEADD(MONTH, 1, @start), @start, @amt);", conn, tx))
                            {
                                cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                                cmd.Parameters.Add("@start", SqlDbType.Date).Value = start;
                                cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                                cmd.Parameters["@amt"].Precision = 18;
                                cmd.Parameters["@amt"].Scale = 2;
                                billId = (int)cmd.ExecuteScalar();
                            }
                        }

                        // 2d. This tenant's share. They are alone in the room, so the
                        //     share is the whole bill. Frozen here, never recomputed.
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO BillTenants (BillId, TenantId, Share)
                      VALUES (@bid, @tid, @share);", conn, tx))
                        {
                            cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.Parameters.Add("@share", SqlDbType.Decimal).Value = amount;
                            cmd.Parameters["@share"].Precision = 18;
                            cmd.Parameters["@share"].Scale = 2;
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Record the money received. Payments no longer carries a
                        //    BillId - PaymentAllocations says which share it settled.
                        int paymentId;
                        string paySql = @"
                    INSERT INTO Payments
                        (TenantId, RoomId, ReceiptNo, PaymentCategory,
                         PaymentType, Amount, PaymentMethod, ReferenceNo,
                         PaymentDate, CoversRoom, RecordedBy)
                    OUTPUT INSERTED.PaymentId
                    VALUES (@tid, @rid, @rcpt, @cat,
                            @type, @amt, @method, @ref,
                            @pdate, 0, @by);";

                        using (var cmd = new SqlCommand(paySql, conn, tx))
                        {
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            cmd.Parameters.Add("@rcpt", SqlDbType.NVarChar, 50).Value = receiptNo;
                            cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = cboPaymentCategory.Text;
                            cmd.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = "Full";
                            cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                            cmd.Parameters["@amt"].Precision = 18;
                            cmd.Parameters["@amt"].Scale = 2;
                            cmd.Parameters.Add("@method", SqlDbType.NVarChar, 20).Value = method;
                            cmd.Parameters.Add("@ref", SqlDbType.NVarChar, 100).Value =
                                string.IsNullOrWhiteSpace(refNo) ? (object)DBNull.Value : refNo;
                            cmd.Parameters.Add("@pdate", SqlDbType.Date).Value = dtpPaymentDate.Value.Date;
                            cmd.Parameters.Add("@by", SqlDbType.Int).Value = Session.UserId;

                            paymentId = (int)cmd.ExecuteScalar();
                        }

                        // 3a. Allocate that money to the share it settles. Nothing
                        //     stores "amount paid" - it is summed from here, so it
                        //     cannot drift away from the payments behind it.
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO PaymentAllocations
                          (PaymentId, BillId, TenantId, Amount)
                      VALUES (@pid, @bid, @tid, @amt);", conn, tx))
                        {
                            cmd.Parameters.Add("@pid", SqlDbType.Int).Value = paymentId;
                            cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                            cmd.Parameters["@amt"].Precision = 18;
                            cmd.Parameters["@amt"].Scale = 2;
                            cmd.ExecuteNonQuery();
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Move In",
    _data.FirstName + " " + _data.LastName + " moved into Room " +
    AuditLogger.RoomNumber(conn, tx, _data.RoomId) + " on " + _data.DateOccupied.ToString("MMM dd, yyyy"));
                        AuditLogger.Log(conn, tx, AuditLogger.ModulePayments, "Record Payment",
                            "Receipt " + receiptNo + ": PHP " + amount.ToString("N2") + " Rent (move-in, " + method +
                            ") from " + _data.FirstName + " " + _data.LastName);

                        // No bill recompute and no room status update: both are
                        // derived now, from allocations and from vwRoomStatus.

                        tx.Commit();
                        saved = true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { System.Diagnostics.Debug.WriteLine(rollbackEx); }

                        System.Diagnostics.Debug.WriteLine(ex);
                        MessageBox.Show("Move-in failed, nothing was saved: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (!saved) return;

            using (PaymentSuccessForm success = new PaymentSuccessForm(
                receiptNo, dtpPaymentDate.Value.Date, cboPaymentCategory.Text))
            {
                success.ShowDialog(this);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void txtReferenceNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlReferenceNumber_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RadioBtnGCash_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>NEW: Whole Room - the landlord picks who hands over the money.</summary>
        private void cboPaidBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_building || !_ready || cboPaidBy.SelectedIndex < 0) return;

            _data.WholeRoomPayerIndex = cboPaidBy.SelectedIndex;
            SelectCreditTo(_data.WholeRoomPayerIndex);   // NEW (credit choice): default follows the payer
            BuildCards();   // the one card now shows the chosen payer
        }
        /// <summary>NEW: reads the room number and price. False = cannot continue.</summary>
        private bool LoadRoom()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (var cmd = new SqlCommand(
                    "SELECT RoomNumber, RoomPrice FROM Rooms WHERE RoomId = @rid;", conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                    conn.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            Warn("This room could not be found.");
                            return false;
                        }

                        // RoomNumber may be text or a number in the table, so read it as a value.
                        _roomNumber = Convert.ToString(rd.GetValue(0));
                        _roomPrice = rd.IsDBNull(1) ? 0m : Convert.ToDecimal(rd.GetValue(1));
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

            if (_roomPrice <= 0)
            {
                Warn("This room has no price set. Configure the room before moving tenants in.");
                return false;
            }

            if (_data.Payers.Count == 0)
            {
                Warn("There is no paying tenant to collect from. Go back and add one.");
                return false;
            }

            return true;
        }

        /// <summary>NEW: the header line, the SUMMARY box and the two notes under the cards.</summary>
        private void ShowHeaderAndSummary()
        {
            int payers = _data.Payers.Count;
            int dependents = _data.Dependents.Count;
            DateTime today = DateTime.Today;

            lblPaymentDescription.Text = "Room " + _roomNumber + " · Rent · " +
                                         today.ToString("MMM d, yyyy") + " · " +
                                         (_data.WholeRoom ? "Whole Room" : "Individual");

            lblRoomPrice.Text = Peso(_roomPrice);
            lblOccupants.Text = (payers + dependents) + " (" + payers + " paying)";
            lblShare.Text = ShareText();
            lblCycleStart.Text = today.ToString("MMM d, yyyy");

            // "Paid by" is only for Whole Room (one person hands over the money).
            pnlPaidBy.Visible = _data.WholeRoom;

            // Whole Room with 2+ payers: say whose shares the money settles.
            lblCreditedTo.Visible = _data.WholeRoom && payers > 1;
            // ORIGINAL: lblCreditedTo.Text = "Credited to: " + string.Join(", ", _data.Payers.Select(p => p.FullName)) +
            // ORIGINAL:                      Environment.NewLine +
            // ORIGINAL:                      "Each keeps their own share on the bill. Any extra is split equally as credit.";
            UpdateCreditedToText();   // NEW (credit choice): the second line follows the chosen option

            // NEW (credit choice): "Extra credit to" - only Whole Room with 2+ payers has a choice.
            pnlCreditTo.Visible = _data.WholeRoom && payers > 1;

            // Dependents live here but are never billed.
            lblDependents.Visible = dependents > 0;
            lblDependents.Text = "Dependents (no billing): " + string.Join(", ", _data.Dependents.Select(d =>
                d.FullName + (d.HeadIndex >= 0 && d.HeadIndex < payers
                    ? " (of " + _data.Payers[d.HeadIndex].FirstName + ")"
                    : "")));
        }
        /// <summary>NEW: "₱3,000.00", or "₱333.34 / ₱333.33" when rounding makes the shares differ.</summary>
        private string ShareText()
        {
            if (_shares.Length == 0) return "—";

            decimal max = _shares.Max();
            decimal min = _shares.Min();
            return max == min ? Peso(max) : Peso(max) + " / " + Peso(min);
        }

        /// <summary>NEW: fills "Paid by" (Whole Room) with the payers in this move-in.</summary>
        private void FillPaidBy()
        {
            _building = true;

            cboPaidBy.Items.Clear();
            foreach (MoveInPayer p in _data.Payers)
                cboPaidBy.Items.Add(p.FullName);

            int index = _data.WholeRoomPayerIndex;
            if (index < 0 || index >= _data.Payers.Count) index = 0;

            _data.WholeRoomPayerIndex = index;
            cboPaidBy.SelectedIndex = index;

            _building = false;
        }

        /// <summary>
        /// NEW: one card per payer (Individual) or one card for the chosen
        /// payer (Whole Room). Each card starts at the amount due.
        /// </summary>
        private void BuildCards()
        {
            _building = true;
            flpPayerCards.SuspendLayout();

            // Remove the old cards (Whole Room payer changed).
            foreach (PayerCardControl old in _cards)
            {
                old.PaymentChanged -= Card_PaymentChanged;
                flpPayerCards.Controls.Remove(old);
                old.Dispose();
            }
            _cards.Clear();

            if (_data.WholeRoom)
            {
                int i = _data.WholeRoomPayerIndex;
                AddCard(i, _data.Payers[i].FullName + " — whole room", "Room price due", _roomPrice);
            }
            else
            {
                for (int i = 0; i < _data.Payers.Count; i++)
                    AddCard(i, _data.Payers[i].FullName, "Share due", _shares[i]);
            }

            flpPayerCards.ResumeLayout();
            _building = false;

            Recalculate();
            if (_cards.Count > 0) _cards[0].FocusAmount();
        }
        private void AddCard(int payerIndex, string title, string dueCaption, decimal due)
        {
            var card = new PayerCardControl();
            card.SetPayer(payerIndex, title, dueCaption, due);

            // Full width of the list, leaving room for the scroll bar.
            card.Width = flpPayerCards.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 6;

            card.PaymentChanged += Card_PaymentChanged;
            flpPayerCards.Controls.Add(card);
            _cards.Add(card);
        }
        private void Card_PaymentChanged(object sender, EventArgs e)
        {
            if (_building) return;
            Recalculate();
        }
        /// <summary>
        /// NEW: re-checks every card and refreshes the totals.
        /// Rules (move-in = full payment before occupying):
        ///   empty / zero  -> not allowed
        ///   below due     -> not allowed (red)
        ///   exactly due   -> Full
        ///   more than due -> Advance (the extra becomes Rent credit)
        /// Returns true when every card is OK.
        /// </summary>
        private bool Recalculate()
        {
            decimal total = 0m;
            string problem = null;   // the first thing to fix, shown in the status line

            foreach (PayerCardControl card in _cards)
            {
                decimal? paid = card.AmountPaid;
                decimal due = card.AmountDue;

                if (paid == null || paid.Value <= 0)
                {
                    card.ShowResult("Enter amount", Color.Firebrick, "", "");
                    problem = problem ?? "Enter the amount paid by " + PayerName(card) + ".";
                    continue;
                }

                total += paid.Value;

                if (paid.Value < due)
                {
                    card.ShowResult("Below due", Color.Firebrick, "Short by " + Peso(due - paid.Value), "");
                    problem = problem ?? PayerName(card) + " must pay at least " + Peso(due) + ".";
                    continue;
                }

                string type = MoveInService.PaymentTypeFor(paid.Value, due);
                card.ShowResult(type,
                    type == "Full" ? Color.SeaGreen : Color.RoyalBlue,
                    CoversText(paid.Value, due),
                    CreditText(paid.Value - due));
            }

            lblTotalCollected.Text = Peso(total);
            lblReceiptsLine.Text = ReceiptsText();

            // NEW (credit choice): the choice only matters when there IS extra money.
            PayerCardControl wholeCard = _data.WholeRoom ? _cards.FirstOrDefault() : null;
            cboCreditTo.Enabled = wholeCard != null && (wholeCard.AmountPaid ?? 0m) > wholeCard.AmountDue;

            bool ok = _ready && problem == null;
            SetStatus(problem ?? "Ready to continue.", ok);
            btnContinuePayment.Enabled = ok;
            return ok;
        }
        /// <summary>
        /// NEW: how far the payment reaches.
        ///   Paid one month (Full)  -> covered until the next due date.
        ///   Each extra full month  -> one month later.
        /// "≈" for Advance: a later share can change if people move in or out,
        /// so the date is an estimate. The credit itself is exact.
        /// </summary>
        private static string CoversText(decimal paid, decimal monthly)
        {
            decimal months = Math.Floor(paid / monthly);   // whole months only
            if (months > 120) return "≈ covers 10+ years";   // a typo-sized amount; avoids a date overflow

            DateTime until = DateTime.Today.AddMonths((int)months);
            return (paid == monthly ? "Covers until " : "≈ covers until ") + until.ToString("MMM d, yyyy");
        }

        /// <summary>NEW: the extra over what is due, kept as Rent credit.</summary>
        private string CreditText(decimal extra)
        {
            if (extra <= 0) return "No credit";

            // ORIGINAL: // Whole Room: BillingHelper splits the extra equally between the payers.
            // ORIGINAL: if (_data.WholeRoom && _data.Payers.Count > 1)
            // ORIGINAL:     return "Credit " + Peso(extra) + " (split)";

            // NEW (credit choice): Whole Room - say where the extra goes.
            if (_data.WholeRoom && _data.Payers.Count > 1)
            {
                int to = ChosenCreditIndex();
                return to >= 0
                    ? "Credit " + Peso(extra) + " → " + _data.Payers[to].FirstName
                    : "Credit " + Peso(extra) + " (split)";
            }

            return "Credit " + Peso(extra);
        }

        /// <summary>NEW: Whole Room = one receipt. Individual = one receipt per payer.</summary>
        private string ReceiptsText()
        {
            int n = _data.WholeRoom ? 1 : _cards.Count;
            return n == 1 ? "1 payment · 1 receipt" : n + " payments · " + n + " receipts";
        }

        private void SetStatus(string text, bool ok)
        {
            lblStatus.Text = text;
            lblStatus.ForeColor = ok ? Color.SeaGreen : Color.Firebrick;
        }

        private string PayerName(PayerCardControl card)
        {
            return _data.Payers[card.PayerKey].FullName;
        }

        /// <summary>
        /// NEW: checks the GCash reference numbers before confirming.
        /// 13 digits, no two payers with the same one, and not used before.
        /// Returns false (and focuses the card) when something is wrong.
        /// </summary>
        private bool CheckReferences()
        {
            var references = new List<string>();

            foreach (PayerCardControl card in _cards)
            {
                if (card.Method != MoveInService.GCash) continue;

                string reference = card.ReferenceNo;

                if (!MoveInService.IsValidGCashReference(reference))
                {
                    Warn("GCash reference number for " + PayerName(card) + " must be exactly 13 digits.");
                    card.FocusReference();
                    return false;
                }

                if (references.Contains(reference))
                {
                    Warn("Two payers have the same GCash reference number. Each GCash payment has its own.");
                    card.FocusReference();
                    return false;
                }

                references.Add(reference);
            }

            // Used in an earlier payment? The database blocks this too
            // (UX_Payments_ReferenceNo); checking here gives a clearer message
            // before the confirm screen.
            foreach (PayerCardControl card in _cards.Where(c => c.Method == MoveInService.GCash))
            {
                bool used;
                try
                {
                    used = ReferenceAlreadyUsed(card.ReferenceNo);
                }
                catch (Exception ex)
                {
                    // A failed check must not block; the database still refuses a duplicate.
                    System.Diagnostics.Debug.WriteLine(ex);
                    continue;
                }

                if (used)
                {
                    Warn("GCash reference " + card.ReferenceNo + " was already recorded in an earlier payment. " +
                         "Check the number on " + PayerName(card) + "'s GCash receipt.");
                    card.FocusReference();
                    return false;
                }
            }

            return true;
        }

        private static bool ReferenceAlreadyUsed(string reference)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Payments WHERE ReferenceNo = @ref;", conn))
            {
                cmd.Parameters.Add("@ref", SqlDbType.NVarChar, 100).Value = reference;
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        /// <summary>
        /// NEW: typo guard. More than 12 months of rent in one go is usually
        /// an extra zero, so ask once. The landlord can still say Yes.
        /// </summary>
        private bool ConfirmLargeAdvances()
        {
            foreach (PayerCardControl card in _cards)
            {
                decimal paid = card.AmountPaid ?? 0m;
                decimal months = Math.Floor(paid / card.AmountDue);   // decimal: no overflow on a huge typo
                if (months <= 12) continue;

                if (MessageBox.Show(PayerName(card) + " is paying " + Peso(paid) + ", about " + months.ToString("N0") +
                                    " months of rent." + Environment.NewLine + Environment.NewLine +
                                    "Is this amount correct?",
                        "Check Amount", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    card.FocusAmount();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// NEW: copies the cards into _data.Payers - this is what MoveInService saves.
        /// Whole Room: only the chosen payer has an amount; the others pay 0.
        /// </summary>
        private void CopyCardsToData()
        {
            foreach (MoveInPayer p in _data.Payers)
            {
                p.AmountPaid = 0m;
                p.Method = MoveInService.Cash;
                p.ReferenceNo = "";
            }

            foreach (PayerCardControl card in _cards)
            {
                MoveInPayer p = _data.Payers[card.PayerKey];
                p.AmountPaid = card.AmountPaid ?? 0m;
                p.Method = card.Method;
                p.ReferenceNo = card.Method == MoveInService.GCash ? card.ReferenceNo : "";   // Cash has no reference
            }

            // NEW (credit choice): who gets the extra. null = split equally.
            int to = ChosenCreditIndex();
            _data.CreditToIndex = _data.WholeRoom && to >= 0 ? to : (int?)null;
        }

        /// <summary>NEW: what ConfirmPaymentForm (C1) shows. Read from the same cards.</summary>
        private ConfirmMoveInInfo BuildConfirmInfo()
        {
            var info = new ConfirmMoveInInfo
            {
                Date = DateTime.Today,
                RoomNumber = _roomNumber,
                PaidAs = _data.WholeRoom ? "Whole Room" : "Individual",
                Occupants = lblOccupants.Text,
                Share = lblShare.Text,
                CreditedTo = lblCreditedTo.Visible ? lblCreditedTo.Text : "",
                Dependents = lblDependents.Visible ? lblDependents.Text : "",
                ReceiptsLine = lblReceiptsLine.Text
            };

            foreach (PayerCardControl card in _cards)
            {
                decimal paid = card.AmountPaid ?? 0m;

                info.Rows.Add(new ConfirmMoveInRow
                {
                    Payer = PayerName(card) + (_data.WholeRoom ? " (whole room)" : ""),
                    Type = MoveInService.PaymentTypeFor(paid, card.AmountDue),
                    Method = card.Method,
                    Reference = card.Method == MoveInService.GCash ? card.ReferenceNo : "—",
                    // ORIGINAL: Covers = CoversText(paid, card.AmountDue),
                    // NEW: the column header already says "Covers Until", so show only the date ("≈ Nov 29, 2026")
                    Covers = CoversText(paid, card.AmountDue).Replace("≈ covers until ", "≈ ").Replace("Covers until ", ""),
                    Amount = paid
                });

                info.Total += paid;
            }

            return info;
        }

        private void Warn(string message)
        {
            MessageBox.Show(message, "Move-In Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>One item of "Extra credit to". Index -1 = split equally, else a payer index.</summary>
        private sealed class CreditChoice
        {
            public int Index;
            public string Text = "";
            public override string ToString() => Text;
        }

        /// <summary>NEW: "Split equally" plus every payer; starts on the person paying.</summary>
        private void FillCreditTo()
        {
            _building = true;

            cboCreditTo.Items.Clear();
            cboCreditTo.Items.Add(new CreditChoice { Index = -1, Text = "Split equally" });
            for (int i = 0; i < _data.Payers.Count; i++)
                cboCreditTo.Items.Add(new CreditChoice { Index = i, Text = _data.Payers[i].FullName });

            _building = false;
            SelectCreditTo(_data.WholeRoomPayerIndex);   // default: the payer (it is their money)
        }

        /// <summary>NEW: selects a payer (index) or Split equally (-1).</summary>
        private void SelectCreditTo(int index)
        {
            _building = true;
            foreach (object item in cboCreditTo.Items)
            {
                if (((CreditChoice)item).Index == index)
                {
                    cboCreditTo.SelectedItem = item;
                    break;
                }
            }
            _building = false;
            UpdateCreditedToText();
        }

        /// <summary>NEW: the chosen payer index, or -1 for split equally.</summary>
        private int ChosenCreditIndex()
        {
            return cboCreditTo.SelectedItem is CreditChoice c ? c.Index : -1;
        }

        private void cboCreditTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_building || !_ready) return;
            UpdateCreditedToText();
            Recalculate();   // the card's credit text changes
        }

        /// <summary>NEW: the "Credited to" note under the card (also shown on the Confirm screen).</summary>
        private void UpdateCreditedToText()
        {
            int to = ChosenCreditIndex();

            lblCreditedTo.Text = "Credited to: " + string.Join(", ", _data.Payers.Select(p => p.FullName)) +
                                 Environment.NewLine +
                                 (to >= 0 && to < _data.Payers.Count
                                     ? "Each keeps their own share on the bill. Any extra goes to " + _data.Payers[to].FullName + "."
                                     : "Each keeps their own share on the bill. Any extra is split equally as credit.");
        }

        private static string Peso(decimal v) => "₱" + v.ToString("N2");


    }
}