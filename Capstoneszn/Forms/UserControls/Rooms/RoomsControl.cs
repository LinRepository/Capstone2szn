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
    public partial class RoomsControl : UserControl
    {
        private int _buildingId;

        public RoomsControl(int buildingId)
        {
            InitializeComponent();

            _buildingId = buildingId;

            

            LoadRooms();


        }

        public void LoadRooms()
        {
            flpRoomsOverview.Controls.Clear();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    // 1. Get all floors for this building
                    string floorQuery = "SELECT FloorId, FloorNumber FROM Floors WHERE BuildingId = @bId ORDER BY FloorNumber ASC";
                    DataTable dtFloors = new DataTable();
                    using (SqlCommand cmdFloor = new SqlCommand(floorQuery, conn))
                    {
                        cmdFloor.Parameters.AddWithValue("@bId", _buildingId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmdFloor)) da.Fill(dtFloors);
                    }

                    // 2. Loop through each floor to draw labels and horizontal room rows
                    foreach (DataRow floorRow in dtFloors.Rows)
                    {
                        int floorId = Convert.ToInt32(floorRow["FloorId"]);
                        int floorNumber = Convert.ToInt32(floorRow["FloorNumber"]);

                        // A. Draw the Vertical Floor Label ("Floor 1")
                        Label lblFloor = new Label();
                        lblFloor.Text = "Floor " + floorNumber;
                        lblFloor.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                        lblFloor.ForeColor = Color.White;
                        lblFloor.AutoSize = true;
                        lblFloor.Margin = new Padding(10, 20, 10, 5);

                        flpRoomsOverview.Controls.Add(lblFloor);

                        // B. Create a nested Horizontal Panel specifically for this floor's rooms
                        FlowLayoutPanel flpFloorRooms = new FlowLayoutPanel();
                        flpFloorRooms.FlowDirection = FlowDirection.LeftToRight;
                        flpFloorRooms.WrapContents = true;
                        flpFloorRooms.AutoSize = true;
                        flpFloorRooms.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        flpFloorRooms.Margin = new Padding(10, 0, 10, 20);

                        // Restrict max width so cards wrap down instead of scrolling sideways
                        int maxWidth = flpRoomsOverview.Width - 30; // 30px buffer for scrollbars
                        flpFloorRooms.MaximumSize = new Size(maxWidth, 0);

                        // 3. Get all active rooms for THIS specific floor (Includes the Length Sort fix!)
                        string roomQuery = "SELECT RoomId, RoomNumber, Status, Capacity FROM Rooms WHERE FloorId = @fId AND Status != 'Archived' ORDER BY LEN(RoomNumber) ASC, RoomNumber ASC";
                        using (SqlCommand cmdRoom = new SqlCommand(roomQuery, conn))
                        {
                            cmdRoom.Parameters.AddWithValue("@fId", floorId);
                            using (SqlDataReader reader = cmdRoom.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    RoomCardControl card = new RoomCardControl();
                                    card.RoomId = reader.GetInt32(0);
                                    card.RoomNumber = reader.GetString(1);
                                    card.SetStatusColor(reader.GetString(2));

                                    int capacity = reader.GetInt32(3);
                                    card.Occupancy = "0/" + capacity;

                                    card.CardClicked += RoomCard_Clicked;

                                    // Add the card to the HORIZONTAL floor panel
                                    flpFloorRooms.Controls.Add(card);
                                }
                            }
                        }

                        // C. Add the fully populated horizontal row to the main vertical panel
                        flpRoomsOverview.Controls.Add(flpFloorRooms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rooms: " + ex.Message);
                }
            }
        }

        private void RoomCard_Clicked(object sender, EventArgs e)
        {
            RoomCardControl clickedCard = sender as RoomCardControl;
            if (clickedCard != null)
            {
                // Open the Room Information Form and pass the specific RoomId
                using (RoomInformationForm infoForm = new RoomInformationForm(clickedCard.RoomId))
                {
                    // If something changes (like moving someone in, or editing the price), refresh the UI when the form closes
                    if (infoForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadRooms();
                    }
                }
            }
        }


        private void RoomsControl_Load(object sender, EventArgs e)
        {
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            using (AddRoomForm addForm = new AddRoomForm(_buildingId))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms(); // Refresh UI to show new room
                }
            }
        }

        private void flpRoomsOverview_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}