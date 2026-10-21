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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;                 // NEW: account name validation
using Capstoneszn.Forms.UserControls.Utilities;       // NEW: ElectricityHelper

namespace Capstoneszn.Forms
{
    public partial class AddRoomForm : Form
    {

        private int _buildingId;

        public AddRoomForm(int buildingId)
        {
            InitializeComponent();

            _buildingId = buildingId;
            LoadDropdowns();

            // Wire up the KeyPress event to automatically block non-integer characters
            txtRoomNumber.KeyPress += NumericOnly_KeyPress;
            txtRoomPrice.KeyPress += NumericOnly_KeyPress;

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


        private void AddRoomForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelAddRoom_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (cboFloor.SelectedValue == null) return;

            string roomNumber = txtRoomNumber.Text.Trim();
            string roomType = cboRoomType.Text;
            string priceText = txtRoomPrice.Text.Trim();

            // 1. Basic Empty Validation
            if (string.IsNullOrEmpty(roomNumber) || string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Please fill in all fields.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Strict Integer Parsing Validation
            if (!int.TryParse(roomNumber, out int parsedRoomNumber))
            {
                MessageBox.Show("Room Number must be a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(priceText, out int roomPrice) || roomPrice <= 0)
            {
                MessageBox.Show("Room Price must be a valid number greater than 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            int selectedFloorId = (int)cboFloor.SelectedValue;



                // Single rooms are complete on creation; shared rooms need a capacity first
                bool isSingle = (roomType == "Single Room");
            object capacity = isSingle ? (object)1 : DBNull.Value;

            // 3. Database Check & Insertion
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // --- DUPLICATE CHECK ---
                    // Links Rooms to Floors to ensure the room number is completely unique across this specific building
                    string checkDuplicateQuery = @"
                        SELECT COUNT(*) 
                        FROM Rooms r 
                        INNER JOIN Floors f ON r.FloorId = f.FloorId 
                        WHERE r.RoomNumber = @roomNum AND f.BuildingId = @bId";

                    using (SqlCommand checkCmd = new SqlCommand(checkDuplicateQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@roomNum", roomNumber);
                        checkCmd.Parameters.AddWithValue("@bId", _buildingId);

                        int existingCount = (int)checkCmd.ExecuteScalar();
                        if (existingCount > 0)
                        {
                            MessageBox.Show("This Room Number already exists in this building. Please enter a unique room number.", "Duplicate Room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Stop the save process
                        }
                    }

                    // NEW: --- DUPLICATE ELECTRICITY ACCOUNT CHECK ---
                    // Each meter/account belongs to one room only; checked before the room is saved
                    using (SqlCommand elecCheckCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM dbo.ElectricityAccounts WHERE AccountNumber = @accNum", conn))
                    {
                        elecCheckCmd.Parameters.Add("@accNum", SqlDbType.VarChar, 50).Value = elecAccountNumber;
                        if ((int)elecCheckCmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("This Elec. Account Number is already used by another account. Please check the number.", "Duplicate Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox2.Focus();
                            return;
                        }
                    }


                    // BuildingId is stored on the room as well as the floor. It is what makes
                    // room numbers unique per building rather than per floor, and a composite
                    // FK keeps it in step with the floor's own building.
                    string insertQuery = @"
                        INSERT INTO Rooms (FloorId, BuildingId, RoomNumber, RoomType, RoomPrice, Capacity)
                        VALUES (@floorId, @bId, @roomNum, @type, @price, @cap)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add("@floorId", SqlDbType.Int).Value = selectedFloorId;
                        cmd.Parameters.Add("@bId", SqlDbType.Int).Value = _buildingId;
                        cmd.Parameters.Add("@roomNum", SqlDbType.NVarChar, 50).Value = roomNumber;
                        cmd.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = roomType;
                        cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = roomPrice;
                        cmd.Parameters["@price"].Precision = 18;
                        cmd.Parameters["@price"].Scale = 2;
                        cmd.Parameters.Add("@cap", SqlDbType.Int).Value = capacity;
                        cmd.ExecuteNonQuery();
                    }

                    // NEW: create the room's electricity account so it shows in Utilities > Electricity.
                    // The room number is unique per building (checked above), so this finds the new room.
                    using (SqlCommand idCmd = new SqlCommand(
                        "SELECT RoomId FROM Rooms WHERE RoomNumber = @roomNum AND BuildingId = @bId", conn))
                    {
                        idCmd.Parameters.Add("@roomNum", SqlDbType.NVarChar, 50).Value = roomNumber;
                        idCmd.Parameters.Add("@bId", SqlDbType.Int).Value = _buildingId;
                        int newRoomId = Convert.ToInt32(idCmd.ExecuteScalar());

                        ElectricityHelper.CreateRoomAccount(conn, null, newRoomId, elecAccountName, elecAccountNumber);
                    }

                    AuditLogger.Log(AuditLogger.ModuleRooms, "Add Room",
    "Room " + roomNumber + " (" + roomType + ", PHP " + roomPrice.ToString("N2") + ")");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving room: " + ex.Message);
                }
            }
        }
    }
}
