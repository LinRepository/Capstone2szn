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
        private string _roomName;
        private string _status;
        private int _capacity;
        private int _currentOccupants;

        public RoomInformationForm(int roomId, string roomName, string status, int capacity, int occupants)
        {
            InitializeComponent();

            _roomId = roomId;
            _roomName = roomName;
            _status = status;
            _capacity = capacity;
            _currentOccupants = occupants;

            PopulateRoomDetails();
        }

        private void PopulateRoomDetails()
        {
            // Set the basic labels on the left panel
            lblUnitNumberValue.Text = _roomName;
            lblCurrentStatus.Text = _status;

            if (_capacity == 0)
                lblCapacityValue.Text = "Not Set";
            else
                lblCapacityValue.Text = $"{_currentOccupants} / {_capacity}";

            EnforceButtonRules();

            // NEW: Fetch and load the tenants into the DataGridView
            LoadCurrentTenants();
        }

        // NEW METHOD: Grabs tenants for this room and populates the grid
        private void LoadCurrentTenants()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Query the tenants belonging to this specific room
                    string query = @"
                        SELECT TenantName AS [Name], 
                               ContactNumber AS [Contact], 
                               CAST(DateOccupied AS DATE) AS [Date Occupied] 
                        FROM Tenants 
                        WHERE RoomId = @roomId
                        ORDER BY DateOccupied ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@roomId", _roomId);

                        DataTable dtTenants = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtTenants);
                        }

                        // Bind the data to your DataGridView
                        dgvCurrentTenants.DataSource = dtTenants;

                        // Clean up the visual look of the grid to make it look professional
                        dgvCurrentTenants.AllowUserToAddRows = false;
                        dgvCurrentTenants.ReadOnly = true;
                        dgvCurrentTenants.RowHeadersVisible = false;
                        dgvCurrentTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvCurrentTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        // Update the Date Occupied label based on the earliest tenant in the grid
                        if (dtTenants.Rows.Count > 0)
                        {
                            DateTime earliestDate = Convert.ToDateTime(dtTenants.Rows[0]["Date Occupied"]);
                            lblDateOccupiedValue.Text = earliestDate.ToString("MMM dd, yyyy");
                        }
                        else
                        {
                            lblDateOccupiedValue.Text = "-";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading tenants: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EnforceButtonRules()
        {
            // 1. If capacity is 0, they can ONLY set the capacity
            if (_capacity == 0)
            {
                btnMoveIn.Enabled = false;
                btnMoveOut.Enabled = false;
                btnSetCapacity.Enabled = true;
                return;
            }

            // 2. Set Capacity is ONLY enabled when the room is fully Available
            btnSetCapacity.Enabled = (_status == "Available");

            // 3. Move Out is ONLY enabled if someone actually lives there
            btnMoveOut.Enabled = (_currentOccupants > 0);

            // 4. Move In is ONLY enabled if it's not under maintenance AND there is space left
            if (_status == "Maintenance")
            {
                btnMoveIn.Enabled = false;
                btnMoveOut.Enabled = false;
            }
            else
            {
                btnMoveIn.Enabled = (_currentOccupants < _capacity);
            }
        }

        private void btnMoveIn_Click(object sender, EventArgs e)
        {
            // Open the MoveInForm and pass the Room ID so we know where to put the tenant
            using (MoveInForm moveIn = new MoveInForm(_roomId))
            {
                // If the user successfully added a tenant...
                if (moveIn.ShowDialog() == DialogResult.OK)
                {
                    // Close the room info form and tell RoomsControl to reload the cards
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
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

        private void btnSetCapacity_Click(object sender, EventArgs e)
        {
            // Open the Set Capacity form and pass the Room ID
            using (SetCapacityForm setCapForm = new SetCapacityForm(_roomId, _capacity))
            {
                // If the user clicked Save in the child form...
                if (setCapForm.ShowDialog() == DialogResult.OK)
                {
                    // Close this info form immediately and trigger the main dashboard reload
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}