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

                    string floorQuery = "SELECT FloorId, FloorNumber FROM Floors WHERE BuildingId = @bId ORDER BY FloorNumber ASC";
                    DataTable dtFloors = new DataTable();

                    using (SqlCommand cmdFloor = new SqlCommand(floorQuery, conn))
                    {
                        cmdFloor.Parameters.AddWithValue("@bId", _buildingId);
                        using (SqlDataAdapter daFloors = new SqlDataAdapter(cmdFloor))
                        {
                            daFloors.Fill(dtFloors);
                        }
                    }

                    if (dtFloors.Rows.Count == 0)
                    {
                        MessageBox.Show($"No floors found for Building ID: {_buildingId}.", "Empty Building");
                        return;
                    }

                    foreach (DataRow floorRow in dtFloors.Rows)
                    {
                        int floorId = Convert.ToInt32(floorRow["FloorId"]);
                        int floorNum = Convert.ToInt32(floorRow["FloorNumber"]);

                        Label lblFloorTitle = new Label();
                        lblFloorTitle.Text = "Floor " + floorNum;
                        lblFloorTitle.Font = new Font(this.Font.FontFamily, 12, FontStyle.Bold);
                        lblFloorTitle.ForeColor = Color.White;
                        lblFloorTitle.AutoSize = false;
                        lblFloorTitle.Width = flpRoomsOverview.Width - 30;
                        lblFloorTitle.Height = 30;
                        lblFloorTitle.Margin = new Padding(5, 15, 0, 0);

                        FlowLayoutPanel flpCards = new FlowLayoutPanel();
                        flpCards.Width = flpRoomsOverview.Width - 30;
                        flpCards.AutoSize = true;
                        flpCards.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        flpCards.WrapContents = true;
                        flpCards.Margin = new Padding(0, 0, 0, 20);
                        flpCards.BackColor = Color.Transparent; // Removes the white gap

                        // REAL DATABASE QUERY
                        string roomQuery = @"
                            SELECT r.RoomId, r.RoomName, 
                                   ISNULL(r.Status, 'Available') AS Status, 
                                   ISNULL(r.Capacity, 0) AS Capacity, 
                                   (SELECT COUNT(*) FROM Tenants t WHERE t.RoomId = r.RoomId) AS OccupantCount
                            FROM Rooms r 
                            WHERE r.FloorId = @fId 
                            ORDER BY r.RoomName ASC";

                        DataTable dtRooms = new DataTable();
                        using (SqlCommand cmdRoom = new SqlCommand(roomQuery, conn))
                        {
                            cmdRoom.Parameters.AddWithValue("@fId", floorId);
                            using (SqlDataAdapter daRooms = new SqlDataAdapter(cmdRoom))
                            {
                                daRooms.Fill(dtRooms);
                            }
                        }

                        foreach (DataRow roomRow in dtRooms.Rows)
                        {
                            RoomCardControl card = new RoomCardControl();
                            card.RoomId = Convert.ToInt32(roomRow["RoomId"]);
                            card.RoomName = roomRow["RoomName"].ToString();

                            // DYNAMIC UI BINDING
                            card.Capacity = Convert.ToInt32(roomRow["Capacity"]);
                            card.CurrentOccupants = Convert.ToInt32(roomRow["OccupantCount"]);
                            card.Status = roomRow["Status"].ToString();
                            card.UpdateOccupancyLabel();

                            card.Margin = new Padding(5);
                            card.Cursor = Cursors.Hand;
                            card.RoomClicked += RoomCard_Clicked;

                            flpCards.Controls.Add(card);
                        }

                        flpRoomsOverview.Controls.Add(lblFloorTitle);
                        flpRoomsOverview.Controls.Add(flpCards);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rooms: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Add this timer variable right above the method
        private DateTime _lastClosedTime = DateTime.MinValue;
        private void RoomCard_Clicked(object sender, EventArgs e)
        {
            // ANTI-BOUNCE: If the form was closed less than 500 milliseconds ago, ignore this ghost click
            if ((DateTime.Now - _lastClosedTime).TotalMilliseconds < 500) return;

            RoomCardControl clickedRoom = sender as RoomCardControl;
            if (clickedRoom != null)
            {
                

                using (RoomInformationForm infoForm = new RoomInformationForm(
                    clickedRoom.RoomId,
                    clickedRoom.RoomName,
                    clickedRoom.Status,
                    clickedRoom.Capacity,
                    clickedRoom.CurrentOccupants))
                {
                    // ShowDialog pauses the code here until the user closes the form
                    DialogResult result = infoForm.ShowDialog();

                    // 3. ONLY redraw the heavy UI if a change was actually made
                    if (result == DialogResult.OK)
                    {
                        LoadRooms();
                    }
                }

                // Lock the door: Record the exact time the form fully closed
                _lastClosedTime = DateTime.Now;
            }
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
        }

        private void RoomsControl_Load(object sender, EventArgs e)
        {
        }
    }
}