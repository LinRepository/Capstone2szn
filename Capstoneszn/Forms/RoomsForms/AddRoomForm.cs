using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;                           // REVISION: culture-safe price parsing
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;                 // NEW: account name validation
using Capstoneszn.Forms.UserControls.Utilities;       // NEW: ElectricityHelper

namespace Capstoneszn.Forms
{

    /// <summary>
    /// Add Room (Rooms module revision, Oct 2026).
    ///
    /// Settled rules:
    ///   - Fields: floor, room number, room type, room price, capacity,
    ///     electricity account name and number. Every room is complete on
    ///     creation - there is no "Unconfigured" room any more.
    ///   - Room number: whole number 1-9999, no leading zero, unique in the
    ///     building INCLUDING archived rooms. An archived room's number comes
    ///     back only by restoring that room (Settings > Archive).
    ///   - Single room = capacity 1 (fixed). Shared room = capacity 2-10.
    ///   - Price: greater than 0, at most 999,999.99, up to 2 decimals.
    ///   - The room, its electricity account and the audit entry are saved
    ///     in ONE transaction: all or nothing.
    ///
    /// The database enforces the same rules (CK_Rooms_*, UQ_Rooms_Bldg_Number,
    /// UQ_ElecAcct_Number); the checks here exist to give a clear message.
    /// </summary>
    /// 

    public partial class AddRoomForm : Form
    {

        private int _buildingId;

        // REVISION: limits shared with the database CHECK constraints
        private const int MinRoomNumber = 1;
        private const int MaxRoomNumber = 9999;
        private const int MinSharedCapacity = 2;
        private const int MaxSharedCapacity = 10;
        private const decimal MaxRoomPrice = 999999.99m;

        private const string SingleRoom = "Single Room";
        private const string SharedRoom = "Shared Room";

        public AddRoomForm(int buildingId)
        {
            InitializeComponent();

            _buildingId = buildingId;
            LoadDropdowns();

            // Wire up the KeyPress event to automatically block non-integer characters
            txtRoomNumber.KeyPress += NumericOnly_KeyPress;
            // txtRoomPrice.KeyPress += NumericOnly_KeyPress;   // OLD: blocked the decimal point
            txtRoomPrice.KeyPress += Decimal_KeyPress;          // REVISION: price is a decimal

            // REVISION: input lengths match the rules
            txtRoomNumber.MaxLength = 4;        // 1-9999
            txtRoomPrice.MaxLength = 9;         // 999999.99
            txtSetCapacity.MaxLength = 2;       // 2-10
            txtSetCapacity.KeyPress += NumericOnly_KeyPress;

            // REVISION: capacity follows the room type (Single = 1, Shared = 2-10)
            cboRoomType.SelectedIndexChanged += cboRoomType_SelectedIndexChanged;
            ApplyRoomTypeRules();

            // NEW: electricity account fields (textBox1 = Account Name, textBox2 = Account Number)
            textBox1.MaxLength = 100;                 // matches ElectricityAccounts.AccountName
            textBox2.MaxLength = 20;
            textBox2.KeyPress += NumericOnly_KeyPress; // account number: digits only
        }

        // Real-time restriction: Prevents letters and symbols from being typed
        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input
            }
        }
        /// <summary>
        /// REVISION: digits and ONE decimal point, at most 2 digits after it.
        /// The final check still happens on save, because a pasted value
        /// skips KeyPress.
        /// </summary>
        /// 

        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            // Fully qualified: the "using static VisualStyleElement" above also
            // brings in a nested type named TextBox.
            System.Windows.Forms.TextBox box = (System.Windows.Forms.TextBox)sender;

            if (e.KeyChar == '.')
            {
                if (box.Text.Contains('.')) e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Block a third decimal digit (unless the user is typing over a selection)
            int dot = box.Text.IndexOf('.');
            if (dot >= 0 && box.SelectionLength == 0 && box.SelectionStart > dot
                && box.Text.Length - dot - 1 >= 2)
            {
                e.Handled = true;
            }
        }

        private void LoadDropdowns()
        {
            // 1. Setup Room Type ComboBox
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.Items.Add("Single Room");
            cboRoomType.Items.Add("Shared Room");
            if (cboRoomType.Items.Count > 0) cboRoomType.SelectedIndex = 0;

            // 2. Fetch Floors for the ComboBox
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT FloorId, 'Floor ' + CAST(FloorNumber AS VARCHAR) AS FloorDisplay FROM Floors WHERE BuildingId = @bId ORDER BY FloorNumber ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bId", _buildingId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboFloor.DataSource = dt;
                        cboFloor.DisplayMember = "FloorDisplay";
                        cboFloor.ValueMember = "FloorId";
                        cboFloor.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading floors: " + ex.Message);
                }
            }
        }

        /* =================================================================
           REVISION: ROOM TYPE -> CAPACITY
           ================================================================= */

        private void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyRoomTypeRules();
        }

        /// <summary>
        /// Single: capacity is fixed at 1 and shown read-only.
        /// Shared: the landlord types 2-10.
        /// </summary>
        private void ApplyRoomTypeRules()
        {
            bool isSingle = cboRoomType.Text == SingleRoom;

            txtSetCapacity.ReadOnly = isSingle;
            txtSetCapacity.TabStop = !isSingle;
            txtSetCapacity.BackColor = isSingle ? Color.Gainsboro : SystemColors.Window;
            txtSetCapacity.PlaceholderText = isSingle ? "" : "2 - 10";

            if (isSingle)
                txtSetCapacity.Text = "1";
            else if (txtSetCapacity.Text == "1")
                txtSetCapacity.Text = "";       // force a real choice for a shared room
        }

        private void AddRoomForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelAddRoom_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /* =================================================================
           REVISION: SAVE
           ================================================================= */

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            // ---------- 1. Floor ----------
            if (cboFloor.SelectedValue == null)
            {
                MessageBox.Show("Please select a floor.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboFloor.Focus();
                return;
            }
            int selectedFloorId = Convert.ToInt32(cboFloor.SelectedValue);

            // ---------- 2. Room number: 1-9999, no leading zero ----------
            string roomNumberText = txtRoomNumber.Text.Trim();

            if (roomNumberText.Length == 0)
            {
                MessageBox.Show("Please enter the room number.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomNumber.Focus();
                return;
            }

            if (!roomNumberText.All(char.IsDigit) || roomNumberText.StartsWith("0")
                || !int.TryParse(roomNumberText, out int roomNumber)
                || roomNumber < MinRoomNumber || roomNumber > MaxRoomNumber)
            {
                MessageBox.Show("Room Number must be a whole number from 1 to 9999, without a leading zero.",
                    "Invalid Room Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomNumber.Focus();
                return;
            }

            // ---------- 3. Room type and capacity ----------
            string roomType = cboRoomType.Text;

            if (roomType != SingleRoom && roomType != SharedRoom)
            {
                MessageBox.Show("Please select a room type.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRoomType.Focus();
                return;
            }

            int capacity;
            if (roomType == SingleRoom)
            {
                capacity = 1;
            }
            else if (!int.TryParse(txtSetCapacity.Text.Trim(), out capacity)
                     || capacity < MinSharedCapacity || capacity > MaxSharedCapacity)
            {
                MessageBox.Show("A shared room needs a capacity from 2 to 10.", "Invalid Capacity",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSetCapacity.Focus();
                return;
            }

            // ---------- 4. Price: > 0, <= 999,999.99, max 2 decimals ----------
            string priceText = txtRoomPrice.Text.Trim();

            if (priceText.Length == 0)
            {
                MessageBox.Show("Please enter the room price.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomPrice.Focus();
                return;
            }

            if (!decimal.TryParse(priceText, NumberStyles.AllowDecimalPoint,
                                  CultureInfo.InvariantCulture, out decimal roomPrice)
                || roomPrice <= 0m || roomPrice > MaxRoomPrice
                || decimal.Round(roomPrice, 2) != roomPrice)
            {
                MessageBox.Show("Room Price must be greater than 0 and at most 999,999.99, with up to 2 decimal places.",
                    "Invalid Room Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomPrice.Focus();
                return;
            }

            // NEW: 2b. Electricity account validation
            string elecAccountName = textBox1.Text.Trim();
            string elecAccountNumber = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(elecAccountName) || string.IsNullOrEmpty(elecAccountNumber))
            {
                MessageBox.Show("Please enter the room's electricity account name and account number.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                (string.IsNullOrEmpty(elecAccountName) ? textBox1 : textBox2).Focus();
                return;
            }

            if (!Regex.IsMatch(elecAccountName, @"^[\p{L}\p{N} .,'\-]+$"))
            {
                MessageBox.Show("Elec. Account Name can only contain letters, numbers, spaces, and . , ' -", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (!elecAccountNumber.All(char.IsDigit) || elecAccountNumber.Length < 5)
            {
                MessageBox.Show("Elec. Account Number must be digits only, at least 5 digits long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
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
                        // 5a. Room number already used in this building? Archived rooms
                        //     count too - their number is never handed to a new room.
                        using (SqlCommand cmd = new SqlCommand(@"
                            SELECT TOP 1 IsArchived
                            FROM   Rooms
                            WHERE  BuildingId = @bId
                              AND  RoomNumber = @num;", conn, tx))
                        {
                            cmd.Parameters.Add("@bId", SqlDbType.Int).Value = _buildingId;
                            cmd.Parameters.Add("@num", SqlDbType.Int).Value = roomNumber;

                            object found = cmd.ExecuteScalar();
                            if (found != null && found != DBNull.Value)
                            {
                                tx.Rollback();

                                bool archived = Convert.ToBoolean(found);
                                MessageBox.Show(archived
                                        ? $"Room {roomNumber} is archived. Restore it from Settings > Archive instead of adding it again."
                                        : $"Room {roomNumber} already exists in this building. Please enter a different room number.",
                                    archived ? "Archived Room" : "Duplicate Room",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtRoomNumber.Focus();
                                return;
                            }
                        }

                        // NEW: --- DUPLICATE ELECTRICITY ACCOUNT CHECK ---
                        // Each meter/account belongs to one room only; checked before the room is saved
                        using (SqlCommand elecCheckCmd = new SqlCommand(
                            "SELECT COUNT(*) FROM dbo.ElectricityAccounts WHERE AccountNumber = @accNum", conn, tx))
                        {
                            elecCheckCmd.Parameters.Add("@accNum", SqlDbType.VarChar, 50).Value = elecAccountNumber;
                            if ((int)elecCheckCmd.ExecuteScalar() > 0)
                            {
                                tx.Rollback();
                                MessageBox.Show("This Elec. Account Number is already used by another account. Please check the number.", "Duplicate Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBox2.Focus();
                                return;
                            }
                        }

                        // 5b. Insert the room and get its new ID directly
                        //     (no second lookup by room number).
                        int newRoomId;
                        using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO Rooms (FloorId, BuildingId, RoomNumber, RoomType, Capacity, RoomPrice)
                            OUTPUT INSERTED.RoomId
                            VALUES (@floorId, @bId, @num, @type, @cap, @price);", conn, tx))
                        {
                            cmd.Parameters.Add("@floorId", SqlDbType.Int).Value = selectedFloorId;
                            cmd.Parameters.Add("@bId", SqlDbType.Int).Value = _buildingId;
                            cmd.Parameters.Add("@num", SqlDbType.Int).Value = roomNumber;
                            cmd.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = roomType;
                            cmd.Parameters.Add("@cap", SqlDbType.Int).Value = capacity;

                            SqlParameter p = cmd.Parameters.Add("@price", SqlDbType.Decimal);
                            p.Precision = 18;
                            p.Scale = 2;
                            p.Value = roomPrice;

                            newRoomId = (int)cmd.ExecuteScalar();
                        }

                        // 5c. The room's electricity account, in the SAME transaction.
                        // ElectricityHelper.CreateRoomAccount(conn, null, newRoomId, elecAccountName, elecAccountNumber);   // OLD: outside any transaction
                        ElectricityHelper.CreateRoomAccount(conn, tx, newRoomId, elecAccountName, elecAccountNumber);

                        // 5d. Audit entry, in the SAME transaction.
                        AuditLogger.Log(conn, tx, AuditLogger.ModuleRooms, "Add Room",
                            $"Room {roomNumber} ({roomType}, capacity {capacity}, PHP {roomPrice:N2}), " +
                            $"elec. account {elecAccountNumber}");

                        tx.Commit();
                    }
                    catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                    {
                        // A unique rule caught a duplicate that slipped in between the
                        // check and the insert (another PC saving at the same moment).
                        SafeRollback(tx);
                        MessageBox.Show("This room number or electricity account number was just used. Nothing was saved - please check and try again.",
                            "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    catch (Exception ex)
                    {
                        SafeRollback(tx);
                        System.Diagnostics.Debug.WriteLine(ex);
                        MessageBox.Show("The room was not saved: " + ex.Message, "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private static void SafeRollback(SqlTransaction tx)
        {
            try { tx.Rollback(); }
            catch (Exception rollbackEx) { System.Diagnostics.Debug.WriteLine(rollbackEx); }
        }

    }
}
