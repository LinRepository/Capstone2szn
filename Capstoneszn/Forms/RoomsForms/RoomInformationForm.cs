using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;                          // REVISION: culture-safe price parsing
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;                // REVISION: elec. account name rule
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms;
using Capstoneszn.Forms.RoomsForms;
using Capstoneszn.Forms.UserControls.Utilities;      // REVISION: ElectricityHelper (fallback create)
using Microsoft.Data.SqlClient;

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// Room Information (Rooms module revision, Oct 2026 - layout Option A).
    ///
    /// Left: room details. Read-only by default; Edit (landlord only) swaps
    ///       them for edit fields in place. Floor is never editable.
    /// Right: current occupants - paying tenants with their dependents
    ///       listed under them. Balance is rent only.
    ///
    /// Settled edit rules:
    ///   - Room number 1-9999, no leading zero, unique in the building
    ///     (archived rooms included). Editable any time.
    ///   - Room type editable even while occupied; capacity must stay at or
    ///     above the occupants (payers + dependents). Shared -> Single only
    ///     with 0-1 occupants. Shared capacity 2-10.
    ///   - Price: occupied room = new price waits for the next cycle
    ///     (Rooms.PendingRoomPrice / PendingPriceFrom); empty room = applies now.
    ///   - Electricity account name/number edited here (the only edit place).
    ///   - Converting/repricing an occupied room asks for confirmation.
    ///   - One transaction: room + electricity account + audit (old -> new).
    /// </summary>
    public partial class RoomInformationForm : Form
    {
        private int _roomId;
        private int _floorId; // Needed to check for duplicate room numbers during save
        private int _currentCapacity;
        private int _currentTenantCount;      // paying tenants (active stays)

        // REVISION: everything the edit rules and the display need
        private const string SingleRoom = "Single Room";
        private const string SharedRoom = "Shared Room";
        private const int MaxSharedCapacity = 10;
        private const decimal MaxRoomPrice = 999999.99m;

        private int _roomNumber;
        private int _floorNumber;
        private string _roomType = "";
        private decimal _roomPrice;
        private decimal? _pendingPrice;
        private DateTime? _pendingFrom;
        private DateTime? _anchorDate;
        private int _occupants;               // payers + dependents
        private int _dependents;
        private string _elecName = "";
        private string _elecNumber = "";
        private bool _hasElecAccount;

        /// <summary>
        /// True once anything was saved here (an edit, a move in/out, a
        /// transfer). The form now STAYS OPEN after a change so the landlord
        /// sees the result; RoomsControl is told to refresh when it closes.
        /// </summary>
        private bool _changed;

        public RoomInformationForm(int roomId)
        {
            InitializeComponent();

            _roomId = roomId;

            // Set up ComboBox options
            cboRoomType.Items.Clear();
            cboRoomType.Items.Add(SingleRoom);
            cboRoomType.Items.Add(SharedRoom);
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;

            // Restrict textboxes
            txtSetRoom.KeyPress += NumericOnly_KeyPress;
            // txtRoomPrice.KeyPress += NumericOnly_KeyPress;    // OLD: blocked the decimal point
            txtRoomPrice.KeyPress += Decimal_KeyPress;           // REVISION: price is a decimal
            txtSetElecNumber.KeyPress += NumericOnly_KeyPress;   // REVISION: account number digits only

            // REVISION: occupants grid uses the designer columns only
            dgvCurrentTenants.AutoGenerateColumns = false;
            dgvCurrentTenants.CellFormatting += dgvCurrentTenants_CellFormatting;

            // REVISION: report changes to RoomsControl when the form closes
            this.FormClosing += RoomInformationForm_FormClosing;

            // Start in Read-Only Mode
            LoadRoomData();
            ToggleEditMode(false);
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block letters/symbols
            }
        }

        /// <summary>REVISION: digits and one decimal point, max 2 decimals.</summary>
        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            TextBox box = (TextBox)sender;

            if (e.KeyChar == '.')
            {
                if (box.Text.Contains('.')) e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar)) { e.Handled = true; return; }

            int dot = box.Text.IndexOf('.');
            if (dot >= 0 && box.SelectionLength == 0 && box.SelectionStart > dot
                && box.Text.Length - dot - 1 >= 2)
            {
                e.Handled = true;
            }
        }

        private void RoomInformationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changed) this.DialogResult = DialogResult.OK;
        }

        /* =================================================================
           UI STATE
           ================================================================= */

        private bool IsOccupied => _currentTenantCount > 0;

        private void ToggleEditMode(bool isEdit)
        {
            // Read-only details
            pnlUnitData.Visible = !isEdit;
            pnlRoomTypeData.Visible = !isEdit;
            pnlCapacityData.Visible = !isEdit;
            pnlRoomPriceData.Visible = !isEdit;
            pnlNextDueData.Visible = !isEdit;
            pnlElecData.Visible = !isEdit;
            pnlFloorData.Visible = true;            // floor is final - shown in both modes

            // Edit fields
            pnlSetRoom.Visible = isEdit;
            pnlRoomType.Visible = isEdit;           // REVISION: type editable even while occupied
            pnlRoomTypescbo.Visible = isEdit;
            pnlSetCapacity.Visible = isEdit && cboRoomType.Text == SharedRoom;
            pnlRoomPricelbl.Visible = isEdit;
            pnlRoomPrice.Visible = isEdit;
            pnlPriceNotice.Visible = isEdit && IsOccupied;
            pnlSetElecName.Visible = isEdit;
            pnlSetElecNumber.Visible = isEdit;
            pnlActionButtons.Visible = isEdit;

            // Top bar
            btnEdit.Visible = !isEdit && Session.IsLandlord;   // REVISION: landlord only
            btnMoveIn.Visible = !isEdit;
            btnMoveOut.Visible = !isEdit;
            btnTransfer.Visible = !isEdit;                     // REVISION: was left visible while editing
            lblEditingNotice.Visible = isEdit;

            if (isEdit) flpRoomDetails.ScrollControlIntoView(pnlFloorData);
        }

        /* =================================================================
           LOADING
           ================================================================= */

        private void LoadRoomData()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Room details (vwRoomStatus) + floor number + electricity account
                    string roomQuery = @"
                        SELECT v.RoomNumber, v.Status, v.Capacity, v.RoomType, v.RoomPrice,
                               v.FloorId, f.FloorNumber, v.BillingAnchorDate,
                               v.ActiveTenants, v.ActiveDependents, v.Occupants,
                               v.PendingRoomPrice, v.PendingPriceFrom,
                               ea.AccountName, ea.AccountNumber
                        FROM   vwRoomStatus v
                        JOIN   Floors f ON f.FloorId = v.FloorId
                        LEFT JOIN ElectricityAccounts ea ON ea.RoomId = v.RoomId
                        WHERE  v.RoomId = @rId";

                    string status = "";
                    using (SqlCommand cmd = new SqlCommand(roomQuery, conn))
                    {
                        cmd.Parameters.Add("@rId", SqlDbType.Int).Value = _roomId;
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                MessageBox.Show("This room no longer exists.", "Room Not Found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            _roomNumber = r.GetInt32(0);
                            status = r.GetString(1);
                            _currentCapacity = r.GetInt32(2);
                            _roomType = r.GetString(3);
                            _roomPrice = r.GetDecimal(4);
                            _floorId = r.GetInt32(5);
                            _floorNumber = r.GetInt32(6);
                            _anchorDate = r.IsDBNull(7) ? (DateTime?)null : r.GetDateTime(7);
                            _currentTenantCount = r.GetInt32(8);
                            _dependents = r.GetInt32(9);
                            _occupants = r.GetInt32(10);
                            _pendingPrice = r.IsDBNull(11) ? (decimal?)null : r.GetDecimal(11);
                            _pendingFrom = r.IsDBNull(12) ? (DateTime?)null : r.GetDateTime(12);
                            _hasElecAccount = !r.IsDBNull(14);
                            _elecName = r.IsDBNull(13) ? "" : r.GetString(13);
                            _elecNumber = r.IsDBNull(14) ? "" : r.GetString(14);
                        }
                    }

                    // 2. Read-only labels
                    lblRoomHeaderInfo.Text = $"Room {_roomNumber} · Floor {_floorNumber}";
                    lblUnitNumberValue.Text = _roomNumber.ToString();
                    lblFloorValue.Text = _floorNumber.ToString();
                    lblRoomTypeValue.Text = _roomType;

                    lblCapacityValue.Text = _dependents > 0
                        ? $"{_occupants} / {_currentCapacity}  ({_dependents} dependent{(_dependents == 1 ? "" : "s")})"
                        : $"{_occupants} / {_currentCapacity}";

                    lblRoomPriceValue.Text = "₱" + _roomPrice.ToString("N2");
                    lblPendingPriceValue.Visible = _pendingPrice.HasValue;
                    if (_pendingPrice.HasValue && _pendingFrom.HasValue)
                        lblPendingPriceValue.Text = $"₱{_pendingPrice.Value:N2} from {_pendingFrom.Value:MMM d, yyyy}";

                    DateTime? nextDue = IsOccupied ? NextDueDate(_anchorDate) : null;
                    lblNextDueValue.Text = nextDue.HasValue ? nextDue.Value.ToString("MMM d, yyyy") : "—";

                    lblElecNameValue.Text = _hasElecAccount ? _elecName : "No account";
                    lblElecNumberValue.Text = _hasElecAccount ? "Acct No. " + _elecNumber : "";

                    lblRoomStatus.Text = status;
                    lblRoomStatus.ForeColor = StatusColor(status);

                    // 3. Pre-fill the edit fields
                    txtSetRoom.Text = _roomNumber.ToString();
                    cboRoomType.Text = _roomType;
                    ApplyCapacityLimits();
                    nudSetCapacity.Value = Math.Max(nudSetCapacity.Minimum,
                                           Math.Min(nudSetCapacity.Maximum, _currentCapacity));

                    // The price box shows the LATEST price set: the scheduled one if any.
                    decimal shownPrice = _pendingPrice ?? _roomPrice;
                    txtRoomPrice.Text = shownPrice.ToString("0.00", CultureInfo.InvariantCulture);

                    txtSetElecName.Text = _elecName;
                    txtSetElecNumber.Text = _elecNumber;

                    lblPriceNotice.Text = nextDue.HasValue
                        ? $"Room is occupied — a new price starts on {nextDue.Value:MMM d, yyyy}. " +
                          $"This period stays at ₱{_roomPrice:N2}."
                        : "Room is occupied — a new price starts on the next due date.";

                    // 4. Occupants grid
                    LoadOccupants(conn);

                    // 5. Buttons (settled rules)
                    btnMoveIn.Enabled = _occupants < _currentCapacity;   // free slot
                    btnMoveOut.Enabled = _currentTenantCount > 0;         // someone lives here
                    btnTransfer.Enabled = _currentTenantCount > 0;        // REVISION: had no rule
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                    MessageBox.Show("Error loading room data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Paying tenants first, each followed by their dependents.
        /// Balance = rent only (BillingHelper.GetBalance): negative owing,
        /// positive paid ahead. Dependents have no billing records.
        /// </summary>
        private void LoadOccupants(SqlConnection conn)
        {
            var payers = new List<(int TenancyId, int TenantId, string Name, string First,
                                   string Contact, DateTime MoveIn)>();

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT tn.TenancyId, t.TenantId, t.FirstName, t.MiddleName, t.LastName,
                       t.ContactNumber, tn.MoveInDate
                FROM   Tenancies tn
                JOIN   Tenants   t ON t.TenantId = tn.TenantId
                WHERE  tn.RoomId = @rId AND tn.Status = 'Active'
                ORDER BY tn.MoveInDate, t.LastName, t.FirstName;", conn))
            {
                cmd.Parameters.Add("@rId", SqlDbType.Int).Value = _roomId;
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        payers.Add((r.GetInt32(0), r.GetInt32(1),
                                    FullName(r.GetString(2), r.IsDBNull(3) ? null : r.GetString(3), r.GetString(4)),
                                    r.GetString(2), r.GetString(5), r.GetDateTime(6)));
                    }
                }
            }

            var dependents = new List<(int DependentId, int TenancyId, string Name,
                                       string Contact, DateTime MoveIn)>();

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT d.DependentId, d.TenancyId, d.FirstName, d.MiddleName, d.LastName,
                       d.ContactNumber, d.MoveInDate
                FROM   Dependents d
                JOIN   Tenancies tn ON tn.TenancyId = d.TenancyId
                WHERE  tn.RoomId = @rId AND tn.Status = 'Active' AND d.Status = 'Active'
                ORDER BY d.MoveInDate, d.LastName, d.FirstName;", conn))
            {
                cmd.Parameters.Add("@rId", SqlDbType.Int).Value = _roomId;
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        dependents.Add((r.GetInt32(0), r.GetInt32(1),
                                        FullName(r.GetString(2), r.IsDBNull(3) ? null : r.GetString(3), r.GetString(4)),
                                        r.IsDBNull(5) ? "—" : r.GetString(5), r.GetDateTime(6)));
                    }
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("OccupantId", typeof(string));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("OccupantType", typeof(string));
            dt.Columns.Add("ContactNumber", typeof(string));
            dt.Columns.Add("MoveInDate", typeof(DateTime));
            dt.Columns.Add("BalanceText", typeof(string));

            foreach (var p in payers)
            {
                // Readers above are closed, so the helper can use the connection.
                decimal balance = BillingHelper.GetBalance(conn, p.TenantId, "Rent");

                dt.Rows.Add("T-" + p.TenantId, p.Name, "Payer", p.Contact, p.MoveIn, BalanceText(balance));

                foreach (var d in dependents.Where(x => x.TenancyId == p.TenancyId))
                {
                    dt.Rows.Add("D-" + d.DependentId, "   ↳ " + d.Name, "Dependent of " + p.First,
                                d.Contact, d.MoveIn, "—");
                }
            }

            dgvCurrentTenants.DataSource = dt;
            dgvCurrentTenants.ClearSelection();

            lblCurrentTenantsTitle.Text = payers.Count == 0
                ? "Current Occupants — none"
                : $"Current Occupants — {payers.Count} paying, {dependents.Count} dependent{(dependents.Count == 1 ? "" : "s")}";
        }

        private static string FullName(string first, string middle, string last)
        {
            return string.IsNullOrWhiteSpace(middle)
                ? $"{first} {last}"
                : $"{first} {middle} {last}";
        }

        private static string BalanceText(decimal balance)
        {
            if (balance < 0m) return "−₱" + (-balance).ToString("N2");
            if (balance > 0m) return "+₱" + balance.ToString("N2");
            return "₱0.00";
        }

        /// <summary>Owing in red, paid ahead in green, dependents grey.</summary>
        private void dgvCurrentTenants_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string type = Convert.ToString(dgvCurrentTenants.Rows[e.RowIndex].Cells[colOccType.Index].Value) ?? "";
            if (type.StartsWith("Dependent"))
                e.CellStyle.ForeColor = Color.DimGray;

            if (e.ColumnIndex == colOccBalance.Index)
            {
                string text = Convert.ToString(e.Value) ?? "";
                if (text.StartsWith("−")) e.CellStyle.ForeColor = Color.Firebrick;
                else if (text.StartsWith("+")) e.CellStyle.ForeColor = Color.ForestGreen;
            }
        }

        private static Color StatusColor(string status)
        {
            switch (status)
            {
                case "Available": return Color.Chartreuse;
                case "Occupied": return Color.FromArgb(255, 107, 107);
                case "Maintenance": return Color.LightSlateGray;
                default: return Color.White;
            }
        }

        /// <summary>
        /// The next period start after today, from the room's fixed anchor -
        /// the same calculation as BillGenerator and TransferForm.
        /// </summary>
        private static DateTime? NextDueDate(DateTime? anchor)
        {
            if (!anchor.HasValue) return null;

            int n = 0;
            while (anchor.Value.AddMonths(n) <= DateTime.Today) n++;

            return anchor.Value.AddMonths(n);
        }

        /* =================================================================
           BUTTONS
           ================================================================= */

        private void btnMoveIn_Click(object sender, EventArgs e)
        {
            using (MoveInForm moveIn = new MoveInForm(_roomId))
            {
                if (moveIn.ShowDialog() == DialogResult.OK)
                {
                    _changed = true;          // REVISION: stay open, show the new occupant
                    LoadRoomData();
                    ToggleEditMode(false);
                }
            }
        }

        private void btnMoveOut_Click(object sender, EventArgs e)
        {
            using (MoveOutForm moveOut = new MoveOutForm(_roomId))
            {
                if (moveOut.ShowDialog() == DialogResult.OK)
                {
                    _changed = true;
                    LoadRoomData();
                    ToggleEditMode(false);
                }
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            using (TransferForm transfer = new TransferForm(_roomId))
            {
                if (transfer.ShowDialog() == DialogResult.OK)
                {
                    _changed = true;
                    LoadRoomData();
                    ToggleEditMode(false);
                }
            }
        }

        private void btnCloseRoomInfo_Click(object sender, EventArgs e)
        {
            // Tells RoomsControl that nothing was updated, so it shouldn't reload the database
            this.DialogResult = _changed ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        private void RoomInformationForm_Load(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!Session.IsLandlord) return;      // REVISION: landlord only

            LoadRoomData();                       // edit the latest values
            ToggleEditMode(true); // Switches UI to Edit Mode
        }

        private void dgvCurrentTenants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Revert changes visually by reloading the original data, then hide edit fields
            LoadRoomData();
            ToggleEditMode(false);
        }

        /* =================================================================
           ROOM TYPE -> CAPACITY (edit mode)
           ================================================================= */

        private void cboRoomType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ApplyCapacityLimits();

            if (pnlActionButtons.Visible)      // only while editing
                pnlSetCapacity.Visible = cboRoomType.Text == SharedRoom;
        }

        /// <summary>Single = 1. Shared = 2..10 (the database CHECK).</summary>
        private void ApplyCapacityLimits()
        {
            if (cboRoomType.Text == SharedRoom)
            {
                nudSetCapacity.Maximum = MaxSharedCapacity;
                nudSetCapacity.Minimum = 2;         // raises a lower value to 2 by itself
            }
            else
            {
                nudSetCapacity.Minimum = 1;
                nudSetCapacity.Value = 1;
            }
        }

        /* =================================================================
           SAVE
           ================================================================= */

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Session.IsLandlord) return;

            // ---------- 1. Read and validate ----------
            string numText = txtSetRoom.Text.Trim();
            if (numText.Length == 0 || !numText.All(char.IsDigit) || numText.StartsWith("0")
                || !int.TryParse(numText, out int newNumber) || newNumber < 1 || newNumber > 9999)
            {
                MessageBox.Show("Room Number must be a whole number from 1 to 9999, without a leading zero.",
                    "Invalid Room Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSetRoom.Focus();
                return;
            }

            string newType = cboRoomType.Text;
            if (newType != SingleRoom && newType != SharedRoom)
            {
                MessageBox.Show("Please select a room type.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newCapacity = newType == SingleRoom ? 1 : (int)nudSetCapacity.Value;

            if (newType == SingleRoom && _occupants > 1)
            {
                MessageBox.Show($"Room {_roomNumber} has {_occupants} occupants. Move out or transfer " +
                                $"{_occupants - 1} of them before making it a Single Room.",
                    "Cannot Make Single", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newCapacity < _occupants)
            {
                MessageBox.Show($"Capacity cannot be {newCapacity}: {_occupants} people live in this room " +
                                "(paying tenants and dependents).",
                    "Invalid Capacity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtRoomPrice.Text.Trim(), NumberStyles.AllowDecimalPoint,
                                  CultureInfo.InvariantCulture, out decimal enteredPrice)
                || enteredPrice <= 0m || enteredPrice > MaxRoomPrice
                || decimal.Round(enteredPrice, 2) != enteredPrice)
            {
                MessageBox.Show("Room Price must be greater than 0 and at most 999,999.99, with up to 2 decimal places.",
                    "Invalid Room Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomPrice.Focus();
                return;
            }

            string newElecName = txtSetElecName.Text.Trim();
            string newElecNumber = txtSetElecNumber.Text.Trim();

            if (newElecName.Length == 0 || newElecNumber.Length == 0)
            {
                MessageBox.Show("Please enter the room's electricity account name and account number.",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                (newElecName.Length == 0 ? txtSetElecName : txtSetElecNumber).Focus();
                return;
            }

            if (!Regex.IsMatch(newElecName, @"^[\p{L}\p{N} .,'\-]+$"))
            {
                MessageBox.Show("Elec. Account Name can only contain letters, numbers, spaces, and . , ' -",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSetElecName.Focus();
                return;
            }

            if (!newElecNumber.All(char.IsDigit) || newElecNumber.Length < 5)
            {
                MessageBox.Show("Elec. Account Number must be digits only, at least 5 digits long.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSetElecNumber.Focus();
                return;
            }

            // ---------- 2. Work out the price outcome ----------
            //   Empty room    : the new price applies now, nothing pending.
            //   Occupied room : current price stays this period; a different
            //                   price is scheduled for the next due date.
            //                   Typing the current price again cancels a
            //                   scheduled change.
            DateTime? nextDue = NextDueDate(_anchorDate);
            decimal newRoomPrice;
            decimal? newPending;
            DateTime? newPendingFrom;

            if (!IsOccupied || !nextDue.HasValue)
            {
                newRoomPrice = enteredPrice;
                newPending = null;
                newPendingFrom = null;
            }
            else if (enteredPrice == _roomPrice)
            {
                newRoomPrice = _roomPrice;
                newPending = null;
                newPendingFrom = null;
            }
            else
            {
                newRoomPrice = _roomPrice;
                newPending = enteredPrice;
                newPendingFrom = nextDue.Value;
            }

            // ---------- 3. Anything to save? ----------
            var changes = new List<string>();
            if (newNumber != _roomNumber)
                changes.Add($"Room number {_roomNumber} → {newNumber}");
            if (newType != _roomType || newCapacity != _currentCapacity)
                changes.Add($"{ShortType(_roomType)}/{_currentCapacity} → {ShortType(newType)}/{newCapacity}");
            if (newRoomPrice != _roomPrice)
                changes.Add($"Price ₱{_roomPrice:N2} → ₱{newRoomPrice:N2}");
            if (newPending != _pendingPrice || newPendingFrom != _pendingFrom)
                changes.Add(newPending.HasValue
                    ? $"Scheduled price ₱{newPending.Value:N2} from {newPendingFrom.Value:MMM d, yyyy}"
                    : $"Scheduled price change cancelled");
            if (newElecName != _elecName)
                changes.Add($"Elec. name \"{_elecName}\" → \"{newElecName}\"");
            if (newElecNumber != _elecNumber)
                changes.Add($"Elec. acct {_elecNumber} → {newElecNumber}");

            if (changes.Count == 0)
            {
                MessageBox.Show("No changes to save.", "Edit Room",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ---------- 4. Confirm when tenants are affected ----------
            bool typeOrCapacityChanged = newType != _roomType || newCapacity != _currentCapacity;
            bool priceScheduled = newPending.HasValue && newPending != _pendingPrice;

            if (IsOccupied && (typeOrCapacityChanged || priceScheduled))
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Room {_roomNumber} has {_occupants} occupant(s). Save these changes?");
                sb.AppendLine();
                if (typeOrCapacityChanged)
                    sb.AppendLine($"•  It becomes a {newType} (capacity {newCapacity}).");
                if (priceScheduled)
                    sb.AppendLine($"•  New price ₱{newPending.Value:N2} starts {newPendingFrom.Value:MMM d, yyyy}. " +
                                  $"This period stays at ₱{_roomPrice:N2}.");
                sb.AppendLine();
                sb.Append(nextDue.HasValue
                    ? $"Rent shares are recalculated from the next bill ({nextDue.Value:MMM d, yyyy})."
                    : "Rent shares are recalculated from the next bill.");

                if (MessageBox.Show(sb.ToString(), "Confirm Room Change",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            // ---------- 5. Save: room + electricity account + audit, all or nothing ----------
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 5a. Lock the room and re-count occupants - someone may
                        //     have moved in while this form was open.
                        int occupantsNow;
                        using (SqlCommand cmd = new SqlCommand(@"
                            SELECT r.RoomId FROM Rooms r WITH (UPDLOCK, HOLDLOCK) WHERE r.RoomId = @rId;
                            SELECT v.Occupants FROM vwRoomStatus v WHERE v.RoomId = @rId;", conn, tx))
                        {
                            cmd.Parameters.Add("@rId", SqlDbType.Int).Value = _roomId;
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                r.NextResult();
                                r.Read();
                                occupantsNow = r.GetInt32(0);
                            }
                        }

                        if (newCapacity < occupantsNow || (newType == SingleRoom && occupantsNow > 1))
                        {
                            SafeRollback(tx);
                            MessageBox.Show($"Someone moved in while this form was open - the room now has {occupantsNow} occupant(s). Nothing was saved.",
                                "Room Changed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LoadRoomData();
                            return;
                        }

                        // 5b. Room number free in this building? (archived rooms count)
                        if (newNumber != _roomNumber)
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                SELECT TOP 1 IsArchived FROM Rooms
                                WHERE  BuildingId = (SELECT BuildingId FROM Rooms WHERE RoomId = @rId)
                                  AND  RoomNumber = @num
                                  AND  RoomId <> @rId;", conn, tx))
                            {
                                cmd.Parameters.Add("@rId", SqlDbType.Int).Value = _roomId;
                                cmd.Parameters.Add("@num", SqlDbType.Int).Value = newNumber;
                                object found = cmd.ExecuteScalar();
                                if (found != null && found != DBNull.Value)
                                {
                                    SafeRollback(tx);
                                    bool archived = Convert.ToBoolean(found);
                                    MessageBox.Show(archived
                                            ? $"Room {newNumber} is an archived room in this building. Its number cannot be reused."
                                            : $"Room {newNumber} already exists in this building.",
                                        "Duplicate Room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtSetRoom.Focus();
                                    return;
                                }
                            }
                        }

                        // 5c. Electricity account number free? (any other account)
                        if (newElecNumber != _elecNumber)
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                SELECT COUNT(*) FROM ElectricityAccounts
                                WHERE  AccountNumber = @n
                                  AND  (RoomId IS NULL OR RoomId <> @rId);", conn, tx))
                            {
                                cmd.Parameters.Add("@n", SqlDbType.VarChar, 50).Value = newElecNumber;
                                cmd.Parameters.Add("@rId", SqlDbType.Int).Value = _roomId;
                                if ((int)cmd.ExecuteScalar() > 0)
                                {
                                    SafeRollback(tx);
                                    MessageBox.Show("This Elec. Account Number is already used by another account. Please check the number.",
                                        "Duplicate Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtSetElecNumber.Focus();
                                    return;
                                }
                            }
                        }

                        // 5d. The room
                        using (SqlCommand cmd = new SqlCommand(@"
                            UPDATE Rooms
                               SET RoomNumber       = @num,
                                   RoomType         = @type,
                                   Capacity         = @cap,
                                   RoomPrice        = @price,
                                   PendingRoomPrice = @pending,
                                   PendingPriceFrom = @pendingFrom
                             WHERE RoomId = @rId;", conn, tx))
                        {
                            cmd.Parameters.Add("@num", SqlDbType.Int).Value = newNumber;
                            cmd.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = newType;
                            cmd.Parameters.Add("@cap", SqlDbType.Int).Value = newCapacity;

                            SqlParameter price = cmd.Parameters.Add("@price", SqlDbType.Decimal);
                            price.Precision = 18; price.Scale = 2; price.Value = newRoomPrice;

                            SqlParameter pending = cmd.Parameters.Add("@pending", SqlDbType.Decimal);
                            pending.Precision = 18; pending.Scale = 2;
                            pending.Value = newPending.HasValue ? (object)newPending.Value : DBNull.Value;

                            cmd.Parameters.Add("@pendingFrom", SqlDbType.Date).Value =
                                newPendingFrom.HasValue ? (object)newPendingFrom.Value : DBNull.Value;

                            cmd.Parameters.Add("@rId", SqlDbType.Int).Value = _roomId;
                            cmd.ExecuteNonQuery();
                        }

                        // 5e. The room's electricity account (created if it is somehow missing)
                        int elecRows;
                        using (SqlCommand cmd = new SqlCommand(@"
                            UPDATE ElectricityAccounts
                               SET AccountName = @name, AccountNumber = @n
                             WHERE RoomId = @rId;", conn, tx))
                        {
                            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = newElecName;
                            cmd.Parameters.Add("@n", SqlDbType.VarChar, 50).Value = newElecNumber;
                            cmd.Parameters.Add("@rId", SqlDbType.Int).Value = _roomId;
                            elecRows = cmd.ExecuteNonQuery();
                        }
                        if (elecRows == 0)
                            ElectricityHelper.CreateRoomAccount(conn, tx, _roomId, newElecName, newElecNumber);

                        // 5f. Audit: old -> new
                        AuditLogger.Log(conn, tx, AuditLogger.ModuleRooms, "Edit Room",
                            $"Room {_roomNumber}: " + string.Join("; ", changes));

                        tx.Commit();
                    }
                    catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                    {
                        SafeRollback(tx);
                        MessageBox.Show("That room number or electricity account number was just used. Nothing was saved.",
                            "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    catch (Exception ex)
                    {
                        SafeRollback(tx);
                        System.Diagnostics.Debug.WriteLine(ex);
                        MessageBox.Show("Changes were not saved: " + ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // ---------- 6. Done: stay on the form, show the result ----------
            _changed = true;
            MessageBox.Show("Room details updated.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadRoomData();
            ToggleEditMode(false);
        }

        private static string ShortType(string type) => type == SingleRoom ? "Single" : "Shared";

        private static void SafeRollback(SqlTransaction tx)
        {
            try { tx.Rollback(); }
            catch (Exception rollbackEx) { System.Diagnostics.Debug.WriteLine(rollbackEx); }
        }

        /* =================================================================
           OLD CODE (before the Oct 27, 2026 revision), kept as a comment per
           the team rule. Replaced because RoomNumber is now INT, Unconfigured
           rooms no longer exist, the form gained new fields, the type could
           not change while occupied, prices were saved immediately, and the
           save/audit were not one transaction.
           =================================================================

        private void ToggleEditMode(bool isEdit)
        {
            pnlSetRoom.Visible = isEdit;
            pnlRoomPricelbl.Visible = isEdit;
            pnlRoomPrice.Visible = isEdit;

            // Type can only change while nobody lives here
            bool canChangeType = isEdit && _currentTenantCount == 0;
            pnlRoomType.Visible = canChangeType;
            pnlRoomTypescbo.Visible = canChangeType;

            // Capacity is a shared-room concept
            pnlSetCapacity.Visible = isEdit && cboRoomType.Text == "Shared Room";

            pnlActionButtons.Visible = isEdit;

            btnEdit.Visible = !isEdit;
            btnMoveIn.Visible = !isEdit;
            btnMoveOut.Visible = !isEdit;
        }

        private void LoadRoomData()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string roomQuery = @"
                        SELECT v.RoomNumber, v.Status, v.Capacity, v.RoomType, v.RoomPrice, v.FloorId
                        FROM   vwRoomStatus v
                        WHERE  v.RoomId = @rId";
                    using (SqlCommand cmd = new SqlCommand(roomQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@rId", _roomId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string rNum = reader.GetString(0);
                                string rStatus = reader.GetString(1);
                                _currentCapacity = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                string rType = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                decimal rPrice = reader.IsDBNull(4) ? 0m : reader.GetDecimal(4);
                                _floorId = reader.GetInt32(5);

                                lblUnitNumberValue.Text = rNum;
                                lblRoomStatus.Text = rStatus;

                                txtSetRoom.Text = rNum;
                                nudSetCapacity.Value = _currentCapacity > 0 ? _currentCapacity : 1;
                                cboRoomType.Text = rType;
                                txtRoomPrice.Text = (rPrice % 1 == 0) ? rPrice.ToString("0") : rPrice.ToString("0.00");
                            }
                        }
                    }

                    string tenantQuery = @"
                            SELECT t.TenantId, t.FirstName, t.LastName, t.ContactNumber
                            FROM   Tenancies tn
                            JOIN   Tenants   t ON t.TenantId = tn.TenantId
                            WHERE  tn.RoomId = @rId AND tn.Status = 'Active'
                            ORDER BY t.LastName, t.FirstName";
                    using (SqlCommand cmd = new SqlCommand(tenantQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@rId", _roomId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        _currentTenantCount = dt.Rows.Count;

                        dgvCurrentTenants.AutoGenerateColumns = false;
                        if (dgvCurrentTenants.Columns["TenantID"] != null)
                            dgvCurrentTenants.Columns["TenantID"].DataPropertyName = "TenantId";
                        if (dgvCurrentTenants.Columns["TenantFName"] != null)
                            dgvCurrentTenants.Columns["TenantFName"].DataPropertyName = "FirstName";
                        if (dgvCurrentTenants.Columns["TenantLName"] != null)
                            dgvCurrentTenants.Columns["TenantLName"].DataPropertyName = "LastName";
                        if (dgvCurrentTenants.Columns["TenantContactNumber"] != null)
                            dgvCurrentTenants.Columns["TenantContactNumber"].DataPropertyName = "ContactNumber";

                        dgvCurrentTenants.DataSource = dt;
                        dgvCurrentTenants.ReadOnly = true;
                        dgvCurrentTenants.AllowUserToAddRows = false;
                        dgvCurrentTenants.RowHeadersVisible = false;
                        dgvCurrentTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }

                    lblCapacityValue.Text = _currentCapacity > 0 ? $"{_currentTenantCount}/{_currentCapacity}" : "Not Set";
                    btnMoveIn.Enabled = (_currentTenantCount < _currentCapacity) && (_currentCapacity > 0);
                    btnMoveOut.Enabled = (_currentTenantCount > 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading room data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newRoomNum = txtSetRoom.Text.Trim();
            string newType = cboRoomType.Text;
            int newCapacity = (newType == "Single Room") ? 1 : (int)nudSetCapacity.Value;

            if (newType == "Shared Room" && newCapacity < 1)
            {
                MessageBox.Show("Please set a capacity for this shared room.",
                    "Capacity Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(newRoomNum) || string.IsNullOrEmpty(txtRoomPrice.Text))
            {
                MessageBox.Show("Room Number and Price cannot be empty.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtRoomPrice.Text, out decimal newPrice) || newPrice <= 0)
            {
                MessageBox.Show("Please enter a valid price greater than 0.", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newCapacity < _currentTenantCount)
            {
                MessageBox.Show($"Cannot set capacity to {newCapacity} because there are already {_currentTenantCount} tenants living in this room.", "Invalid Capacity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    if (newRoomNum != lblUnitNumberValue.Text)
                    {
                        string checkQuery = @"
                            SELECT COUNT(*)
                            FROM   Rooms r
                            WHERE  r.RoomNumber = @rNum
                              AND  r.BuildingId = (SELECT BuildingId FROM Rooms WHERE RoomId = @rId)
                              AND  r.RoomId != @rId";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@rNum", newRoomNum);
                            checkCmd.Parameters.AddWithValue("@fId", _floorId);
                            checkCmd.Parameters.AddWithValue("@rId", _roomId);

                            int count = (int)checkCmd.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show("This Room Number already exists on this floor.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    string updateQuery = @"
                        UPDATE Rooms
                           SET RoomNumber = @num,
                               Capacity   = @cap,
                               RoomType   = @type,
                               RoomPrice  = @price
                         WHERE RoomId = @rId";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@num", newRoomNum);
                        cmd.Parameters.AddWithValue("@cap", newCapacity);
                        cmd.Parameters.AddWithValue("@type", newType);
                        cmd.Parameters.AddWithValue("@price", newPrice);
                        cmd.Parameters.AddWithValue("@rId", _roomId);
                        cmd.ExecuteNonQuery();
                    }

                    AuditLogger.Log(AuditLogger.ModuleRooms, "Edit Room",
    "Room " + newRoomNum + " set to " + newType + ", capacity " + newCapacity + ", PHP " + newPrice.ToString("N2"));

                    MessageBox.Show("Room details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRoomData();
                    ToggleEditMode(false);

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboRoomType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            bool isShared = cboRoomType.Text == "Shared Room";

            if (pnlActionButtons.Visible)      // only while editing
                pnlSetCapacity.Visible = isShared;

            if (!isShared)
                nudSetCapacity.Value = 1;
        }

        Old button handlers set this.DialogResult = DialogResult.OK after a
        move in / move out / transfer, which closed this form at once.
        ================================================================= */
    }
}