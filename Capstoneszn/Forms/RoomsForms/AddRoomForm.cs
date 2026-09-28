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

            int selectedFloorId = (int)cboFloor.SelectedValue;

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

                    // --- SAVE NEW ROOM ---
                    string insertQuery = "INSERT INTO Rooms (FloorId, RoomNumber, RoomType, RoomPrice) VALUES (@floorId, @roomNum, @type, @price)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@floorId", selectedFloorId);
                        cmd.Parameters.AddWithValue("@roomNum", roomNumber);
                        cmd.Parameters.AddWithValue("@type", roomType);
                        cmd.Parameters.AddWithValue("@price", roomPrice);
                        cmd.ExecuteNonQuery();
                    }

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
