using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.UserControls;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.UserControls.BillingManagement
{
    public partial class BillingRoomAccountControl : UserControl
    {

        private int _buildingId;

        public BillingRoomAccountControl(int buildingId)
        {
            InitializeComponent();

            _buildingId = buildingId;

            LoadRooms();
        }

        public void LoadRooms()
        {
            // Clears the designer's placeholder floor sections too
            flpFloors.Controls.Clear();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string floorQuery = @"
                        SELECT FloorId, FloorNumber FROM Floors
                        WHERE BuildingId = @bId ORDER BY FloorNumber ASC;";

                    DataTable dtFloors = new DataTable();
                    using (var cmdFloor = new SqlCommand(floorQuery, conn))
                    {
                        cmdFloor.Parameters.AddWithValue("@bId", _buildingId);
                        using (var da = new SqlDataAdapter(cmdFloor)) da.Fill(dtFloors);
                    }

                    foreach (DataRow floorRow in dtFloors.Rows)
                    {
                        int floorId = Convert.ToInt32(floorRow["FloorId"]);
                        int floorNumber = Convert.ToInt32(floorRow["FloorNumber"]);

                        Label lblFloor = new Label
                        {
                            Text = "FLOOR " + floorNumber,
                            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular),
                            ForeColor = Color.White,
                            AutoSize = true,
                            Margin = new Padding(10, 20, 10, 5)
                        };
                        flpFloors.Controls.Add(lblFloor);

                        FlowLayoutPanel flpFloorRooms = new FlowLayoutPanel
                        {
                            FlowDirection = FlowDirection.LeftToRight,
                            WrapContents = true,
                            AutoSize = true,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            Margin = new Padding(10, 0, 10, 20),
                            MaximumSize = new Size(flpFloors.Width - 40, 0)
                        };

                        string roomQuery = @"
                            SELECT r.RoomId, r.RoomNumber, r.Capacity,
                                   (SELECT COUNT(*) FROM Tenants t
                                    WHERE t.RoomId = r.RoomId
                                      AND t.Status = 'Active' AND t.IsArchived = 0) AS TenantCount
                            FROM Rooms r
                            WHERE r.FloorId = @fId AND r.IsArchived = 0
                            ORDER BY LEN(r.RoomNumber) ASC, r.RoomNumber ASC;";

                        using (var cmdRoom = new SqlCommand(roomQuery, conn))
                        {
                            cmdRoom.Parameters.AddWithValue("@fId", floorId);
                            using (var reader = cmdRoom.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    RoomCardControl card = new RoomCardControl();
                                    card.RoomId = reader.GetInt32(0);
                                    card.RoomNumber = reader.GetString(1);
                                    card.Occupancy = reader.GetInt32(3) + "/" + reader.GetInt32(2);

                                    // No billing colors yet
                                    card.CardClicked += RoomCard_Clicked;

                                    flpFloorRooms.Controls.Add(card);
                                }
                            }
                        }

                        flpFloors.Controls.Add(flpFloorRooms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rooms: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void RoomCard_Clicked(object sender, EventArgs e)
        {
            RoomCardControl card = sender as RoomCardControl;
            if (card == null) return;

            MessageBox.Show("Room details for RoomId " + card.RoomId + " - pending.",
                "Room Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

             var details = new BillingRoomDetailsControl(card.RoomId) { Dock = DockStyle.Fill };
             this.Parent.Controls.Add(details);
             details.BringToFront();
             this.Hide();
        }

        private void btnBackRoomAccount_Click(object sender, EventArgs e)
        {
            // Loop through the controls in the parent panel to find the Billing Management Control
            foreach (Control ctrl in this.Parent.Controls)
            {
                if (ctrl is BillingManagementControl)
                {
                    // Show it and bring it to the front
                    ctrl.Show();
                    ctrl.BringToFront();
                    break;
                }
            }

            // Remove THIS Room Account control from the parent panel and dispose of it
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
