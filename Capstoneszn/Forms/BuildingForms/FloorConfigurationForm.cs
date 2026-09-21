using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.BuildingForms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{
    public partial class FloorConfigurationForm : Form
    {
        
        public FloorConfigurationForm(string buildingName, int totalFloors)
        {
            InitializeComponent();

            _buildingName = buildingName;
            _totalFloors = totalFloors;

            // Update the UI label to show the building name
            lblBuildingName.Text = _buildingName;

            // Trigger the dynamic UI generation
            GenerateFloorPanels();
        }

        private string _buildingName;
        private int _totalFloors;
        // Modify this constructor to accept the passed parameters

        private void GenerateFloorPanels()
        {
            // Clear the design-time placeholder panel
            flpFloors.Controls.Clear();

            // Loop to create a settings panel for every floor requested
            for (int i = 1; i <= _totalFloors; i++)
            {
                // Create the white container block
                Panel pnl = new Panel();
                pnl.Size = new Size(300, 60);
                pnl.BackColor = Color.White;
                pnl.Margin = new Padding(3, 3, 3, 10);

                // Create "Floor X" label
                Label lblFloor = new Label();
                lblFloor.Text = "Floor " + i;
                lblFloor.Location = new Point(10, 10);
                lblFloor.AutoSize = true;
                lblFloor.ForeColor = Color.Black;
                lblFloor.Font = new Font(this.Font.FontFamily, 10, FontStyle.Regular);

                // Create "Rooms:" label
                Label lblRoomsText = new Label();
                lblRoomsText.Text = "Rooms:";
                lblRoomsText.Location = new Point(10, 35);
                lblRoomsText.AutoSize = true;
                lblRoomsText.ForeColor = Color.Black;

                // Create the NumericUpDown input for this specific floor
                NumericUpDown nudRooms = new NumericUpDown();
                nudRooms.Name = "nudFloor" + i; // Naming it dynamically (e.g., nudFloor1, nudFloor2) so we can extract the value later
                nudRooms.Location = new Point(70, 33);
                nudRooms.Size = new Size(60, 23);
                nudRooms.Minimum = 0; // Allow 0 if a floor is just a lobby, or change to 1 if rooms are required

                // Add the controls to the white panel
                pnl.Controls.Add(lblFloor);
                pnl.Controls.Add(lblRoomsText);
                pnl.Controls.Add(nudRooms);

                // Inject the completed panel into the FlowLayoutPanel
                flpFloors.Controls.Add(pnl);
            }
        }

        private void lblBuildingName_Click(object sender, EventArgs e)
        {

        }

        private void flpFloors_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Return to the Add Building Form
            var addForm = Application.OpenForms.OfType<AddBuildingForm>().FirstOrDefault();

            if (addForm != null)
            {
                addForm.Show();
            }
            else
            {
                new AddBuildingForm().Show();
            }

            this.Close(); // Close the current FloorConfigurationForm
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // Start a transaction so all inserts succeed or fail together
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert the Building and retrieve the newly generated BuildingId
                        string insertBuilding = "INSERT INTO Buildings (BuildingName, TotalFloors) OUTPUT INSERTED.BuildingId VALUES (@BName, @Floors);";
                        int newBuildingId;

                        using (SqlCommand cmdBuilding = new SqlCommand(insertBuilding, conn, transaction))
                        {
                            cmdBuilding.Parameters.AddWithValue("@BName", _buildingName);
                            cmdBuilding.Parameters.AddWithValue("@Floors", _totalFloors);
                            newBuildingId = (int)cmdBuilding.ExecuteScalar();
                        }

                        // 2. Loop through the dynamically generated panels in the FlowLayoutPanel
                        int currentFloor = 1;
                        foreach (Control ctrl in flpFloors.Controls)
                        {
                            if (ctrl is Panel pnl)
                            {
                                // Find the specific NumericUpDown for this floor based on the name we gave it in Step 2
                                NumericUpDown nud = (NumericUpDown)pnl.Controls["nudFloor" + currentFloor];
                                int totalRooms = nud != null ? (int)nud.Value : 0;

                                // Insert the Floor and retrieve the newly generated FloorId
                                string insertFloor = "INSERT INTO Floors (BuildingId, FloorNumber, TotalRooms) OUTPUT INSERTED.FloorId VALUES (@BId, @FNum, @TRooms);";
                                int newFloorId;

                                using (SqlCommand cmdFloor = new SqlCommand(insertFloor, conn, transaction))
                                {
                                    cmdFloor.Parameters.AddWithValue("@BId", newBuildingId);
                                    cmdFloor.Parameters.AddWithValue("@FNum", currentFloor);
                                    cmdFloor.Parameters.AddWithValue("@TRooms", totalRooms);
                                    newFloorId = (int)cmdFloor.ExecuteScalar();
                                }

                                // 3. Loop to generate the specific physical Rooms for this Floor
                                if (totalRooms > 0)
                                {
                                    string insertRoom = "INSERT INTO Rooms (FloorId, RoomName) VALUES (@FId, @RName);";
                                    using (SqlCommand cmdRoom = new SqlCommand(insertRoom, conn, transaction))
                                    {
                                        for (int r = 1; r <= totalRooms; r++)
                                        {
                                            cmdRoom.Parameters.Clear();
                                            cmdRoom.Parameters.AddWithValue("@FId", newFloorId);

                                            // Formats the room name dynamically (e.g., Floor 1 Room 1 -> "101", Floor 3 Room 5 -> "305")
                                            string roomName = $"{currentFloor}{r:D2}";
                                            cmdRoom.Parameters.AddWithValue("@RName", roomName);

                                            cmdRoom.ExecuteNonQuery();
                                        }
                                    }
                                }
                                currentFloor++;
                            }
                        }

                        // Commit saves everything permanently to the database
                        transaction.Commit();
                        MessageBox.Show("Building, Floors, and Rooms successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 1. Find the existing Building Selection form, refresh it, and show it
                        BuildingSelection bsForm = Application.OpenForms.OfType<BuildingSelection>().FirstOrDefault();
                        if (bsForm != null)
                        {
                            bsForm.LoadBuildings(); // Pulls the newly created building from SQL Server
                            bsForm.Show();
                        }

                        // 2. Clean up the hidden AddBuildingForm so it doesn't cause a memory leak
                        AddBuildingForm addForm = Application.OpenForms.OfType<AddBuildingForm>().FirstOrDefault();
                        if (addForm != null)
                        {
                            addForm.Close();
                        }

                        // Return to the Building Selection Form (we will trigger a refresh on it in the next step)
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        // Rollback undoes all inserts if any error occurred
                        transaction.Rollback();
                        MessageBox.Show("Error saving building data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FloorConfigurationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
