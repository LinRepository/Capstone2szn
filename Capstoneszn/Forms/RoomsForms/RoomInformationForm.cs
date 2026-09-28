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

namespace Capstoneszn.UserControls
{
    public partial class RoomInformationForm : Form
    {
        private int _roomId;
        private int _floorId; // Needed to check for duplicate room numbers during save
        private int _currentCapacity;
        private int _currentTenantCount;

        public RoomInformationForm(int roomId)
        {
            InitializeComponent();

            _roomId = roomId;

            // Set up ComboBox options
            cboRoomType.Items.Clear();
            cboRoomType.Items.Add("Single Room");
            cboRoomType.Items.Add("Shared Room");
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;

            // Restrict textboxes to numbers only
            txtSetRoom.KeyPress += NumericOnly_KeyPress;
            txtRoomPrice.KeyPress += NumericOnly_KeyPress;

            // Start in Read-Only Mode
            ToggleEditMode(false);
            LoadRoomData();
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block letters/symbols
            }
        }

        // --- UI STATE MANAGEMENT ---
        private void ToggleEditMode(bool isEdit)
        {
            // Toggle Edit Fields - The FlowLayoutPanel automatically slides them up and down!
            pnlSetRoom.Visible = isEdit;
            pnlSetCapacity.Visible = isEdit;
            pnlRoomType.Visible = isEdit;
            pnlRoomTypescbo.Visible = isEdit;
            pnlRoomPricelbl.Visible = isEdit;
            pnlRoomPrice.Visible = isEdit;

            // Toggle the entire bottom action panel instead of individual buttons
            pnlActionButtons.Visible = isEdit;

            // Toggle top action buttons
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

                    // 1. Fetch Room Details (Added FloorId for duplicate checking later)
                    string roomQuery = "SELECT RoomNumber, Status, Capacity, RoomType, RoomPrice, FloorId FROM Rooms WHERE RoomId = @rId";
                    using (SqlCommand cmd = new SqlCommand(roomQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@rId", _roomId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string rNum = reader.GetString(0);
                                string rStatus = reader.GetString(1);
                                _currentCapacity = reader.GetInt32(2);
                                string rType = reader.GetString(3);
                                decimal rPrice = reader.GetDecimal(4);
                                _floorId = reader.GetInt32(5);

                                // Populate Read-Only Labels
                                lblUnitNumberValue.Text = rNum;
                                lblRoomStatus.Text = rStatus;

                                // Pre-fill Edit Fields in case they click Edit
                                txtSetRoom.Text = rNum;
                                nudSetCapacity.Value = _currentCapacity > 0 ? _currentCapacity : 1;
                                cboRoomType.Text = rType;
                                txtRoomPrice.Text = (rPrice % 1 == 0) ? rPrice.ToString("0") : rPrice.ToString("0.00");
                            }
                        }
                    }

                    // 2. Fetch Active Tenants and map to your specific Designer columns
                    string tenantQuery = "SELECT TenantId, FirstName, LastName, ContactNumber FROM Tenants WHERE RoomId = @rId AND Status = 'Active'";
                    using (SqlCommand cmd = new SqlCommand(tenantQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@rId", _roomId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        _currentTenantCount = dt.Rows.Count; // Count exactly how many people live here

                        // Stop the grid from adding extra columns
                        dgvCurrentTenants.AutoGenerateColumns = false;

                        // Map the SQL columns exactly to the names of the columns in your Document Outline
                        if (dgvCurrentTenants.Columns["TenantID"] != null)
                            dgvCurrentTenants.Columns["TenantID"].DataPropertyName = "TenantId";

                        if (dgvCurrentTenants.Columns["TenantFName"] != null)
                            dgvCurrentTenants.Columns["TenantFName"].DataPropertyName = "FirstName";

                        if (dgvCurrentTenants.Columns["TenantLName"] != null)
                            dgvCurrentTenants.Columns["TenantLName"].DataPropertyName = "LastName";

                        if (dgvCurrentTenants.Columns["TenantContactNumber"] != null)
                            dgvCurrentTenants.Columns["TenantContactNumber"].DataPropertyName = "ContactNumber";

                        dgvCurrentTenants.DataSource = dt;

                        // Clean up DataGridView appearance
                        dgvCurrentTenants.ReadOnly = true;
                        dgvCurrentTenants.AllowUserToAddRows = false;
                        dgvCurrentTenants.RowHeadersVisible = false;
                        dgvCurrentTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }

                    // 3. Update Capacity Label & Button Logic
                    lblCapacityValue.Text = _currentCapacity > 0 ? $"{_currentTenantCount}/{_currentCapacity}" : "Not Set";

                    // Move In is only clickable if there is vacant capacity
                    btnMoveIn.Enabled = (_currentTenantCount < _currentCapacity) && (_currentCapacity > 0);

                    // Move Out is only clickable if someone actually lives there
                    btnMoveOut.Enabled = (_currentTenantCount > 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading room data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMoveIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opening Move In form...");
        }

        private void btnMoveOut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opening Move Out form...");
        }

        private void btnCloseRoomInfo_Click(object sender, EventArgs e)
        {
            // Tells RoomsControl that nothing was updated, so it shouldn't reload the database
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RoomInformationForm_Load(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newRoomNum = txtSetRoom.Text.Trim();
            string newType = cboRoomType.Text;
            int newCapacity = (int)nudSetCapacity.Value;

            // 1. Basic Validation
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

            // Prevent lowering capacity below active tenant count
            if (newCapacity < _currentTenantCount)
            {
                MessageBox.Show($"Cannot set capacity to {newCapacity} because there are already {_currentTenantCount} tenants living in this room.", "Invalid Capacity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Database Save
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Check for duplicate room number (only if they actually changed it from the original)
                    if (newRoomNum != lblUnitNumberValue.Text)
                    {
                        string checkQuery = "SELECT COUNT(*) FROM Rooms WHERE RoomNumber = @rNum AND FloorId = @fId AND RoomId != @rId";
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

                    // Update the room
                    string updateQuery = "UPDATE Rooms SET RoomNumber = @num, Capacity = @cap, RoomType = @type, RoomPrice = @price WHERE RoomId = @rId";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@num", newRoomNum);
                        cmd.Parameters.AddWithValue("@cap", newCapacity);
                        cmd.Parameters.AddWithValue("@type", newType);
                        cmd.Parameters.AddWithValue("@price", newPrice);
                        cmd.Parameters.AddWithValue("@rId", _roomId);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Success! Reload data and return to Read-Only mode
                    MessageBox.Show("Room details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRoomData();
                    ToggleEditMode(false);

                    // Signal the main form that a change occurred so it updates the Room Card behind this window
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}