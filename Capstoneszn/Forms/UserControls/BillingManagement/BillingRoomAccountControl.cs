using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.UserControls.Rooms;
using Capstoneszn.UserControls;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.UserControls.BillingManagement
{

    /// <summary>
    /// The room picker for Billing Management.
    ///
    /// The same rooms as the Rooms module, but answering a different
    /// question. Rooms asks "can somebody live here?" - this asks "does
    /// anybody here owe money?" So it uses its own card,
    /// BillingRoomItemControl, coloured by payment state rather than by
    /// occupancy. RoomCardControl is not used here and is not affected.
    /// </summary>
    /// 
    public partial class BillingRoomAccountControl : UserControl
    {

        private int _buildingId;

        public BillingRoomAccountControl(int buildingId)
        {
            InitializeComponent();

            _buildingId = buildingId;

        }

        /// <summary>
        /// Rooms are loaded here rather than in the constructor. The flow
        /// panel's width is used to decide where the cards wrap, and in the
        /// constructor that width is still the designer's value - the
        /// control has not been docked into its parent yet.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadRooms();
        }

        /* =================================================================
           LOADING
           ================================================================= */

        /// <summary>
        /// Public so the details view can refresh this grid after a payment
        /// is recorded - a room that was red should turn green on the way
        /// back without the landlord reopening the module.
        /// </summary>
        public void LoadRooms()
        {
            // Also clears the designer's two placeholder floor sections.
            flpFloors.Controls.Clear();

            DataTable dtFloors = new DataTable();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT FloorId, FloorNumber
                    FROM   Floors
                    WHERE  BuildingId = @bId
                    ORDER BY FloorNumber ASC;", conn))
                {
                    cmd.Parameters.Add("@bId", SqlDbType.Int).Value = _buildingId;
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dtFloors);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load the floors for this building.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtFloors.Rows.Count == 0)
            {
                flpFloors.Controls.Add(new Label
                {
                    Text = "This building has no floors yet.",
                    Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                    ForeColor = Color.Gainsboro,
                    AutoSize = true,
                    Margin = new Padding(15, 20, 10, 5)
                });
                return;
            }

            // One try per floor. Wrapping the whole loop means the first bad
            // room query takes every later floor down with it - which is
            // exactly why the Rooms module used to show only Floor 1.
            foreach (DataRow floorRow in dtFloors.Rows)
            {
                int floorId = Convert.ToInt32(floorRow["FloorId"]);
                int floorNumber = Convert.ToInt32(floorRow["FloorNumber"]);

                try
                {
                    BuildFloorSection(floorId, floorNumber);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);

                    flpFloors.Controls.Add(new Label
                    {
                        Text = $"FLOOR {floorNumber} - could not be loaded.",
                        Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                        ForeColor = Color.Crimson,
                        AutoSize = true,
                        Margin = new Padding(10, 20, 10, 5)
                    });
                }
            }
        }


        private void BuildFloorSection(int floorId, int floorNumber)
        {
            Label lblFloor = new Label
            {
                Text = "FLOOR " + floorNumber,
                Font = new Font("Segoe UI", 13.8F, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = true,
                Margin = new Padding(10, 20, 10, 5)
            };
            flpFloors.Controls.Add(lblFloor);

            // ClientSize excludes the vertical scrollbar, so the cards do not
            // wrap one column too wide once the list gets long enough to
            // scroll. The floor stops it going negative before layout.
            int wrapWidth = Math.Max(240, flpFloors.ClientSize.Width - 40);

            FlowLayoutPanel flpFloorRooms = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(10, 0, 10, 20),
                MaximumSize = new Size(wrapWidth, 0)
            };

            int cardCount = 0;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(RoomQuery, conn))
            {
                cmd.Parameters.Add("@fId", SqlDbType.Int).Value = floorId;
                cmd.Parameters.Add("@bId", SqlDbType.Int).Value = _buildingId;
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int roomId = reader.GetInt32(0);
                        // ORIGINAL: string roomNumber = reader.GetString(1);
                        string roomNumber = Convert.ToString(reader.GetValue(1)) ?? "";   // NEW: RoomNumber is INT
                        int? capacity = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2);
                        int tenantCount = reader.GetInt32(3);
                        decimal outstanding = reader.GetDecimal(4);
                        decimal overdue = reader.GetDecimal(5);

                        // A shared room with no capacity set yet has nothing
                        // to show as a denominator.
                        string occupancy = capacity.HasValue
                            ? $"{tenantCount}/{capacity.Value} tenants"
                            : $"{tenantCount} tenant(s)";

                        BillingRoomItemControl card = new BillingRoomItemControl();
                        card.Bind(roomId, roomNumber, occupancy,
                                  BillingState(tenantCount, outstanding, overdue),
                                  outstanding, overdue);

                        card.CardClicked += RoomCard_Clicked;

                        flpFloorRooms.Controls.Add(card);
                        cardCount++;
                    }
                }
            }

            if (cardCount == 0)
            {
                flpFloorRooms.Controls.Add(new Label
                {
                    Text = "No rooms on this floor yet.",
                    Font = new Font("Segoe UI", 10.8F, FontStyle.Regular),
                    ForeColor = Color.Gainsboro,
                    AutoSize = true,
                    Margin = new Padding(5, 10, 5, 10)
                });
            }

            flpFloors.Controls.Add(flpFloorRooms);
        }


        /* =================================================================
           THE QUERY

           Occupancy comes from Tenancies now - Tenants.RoomId and
           Tenants.Status no longer exist.

           Outstanding counts only bills belonging to this room whose share
           is held by somebody still living here. That is deliberate: a
           tenant who moved out had their debt written off at move out, and a
           tenant who transferred had to settle first, so anybody with a live
           unpaid share is a current occupant. It also avoids trying to
           attribute a TenantAdjustments row to a room, which it has no
           column for.

           If a standalone write-off action is ever added outside move out,
           this query has to start subtracting WriteOff adjustments.
           ================================================================= */

        private const string RoomQuery = @"
            SELECT r.RoomId,
                   r.RoomNumber,
                   r.Capacity,
                   ISNULL(occ.ActiveTenants, 0) AS TenantCount,
                   ISNULL(money.Outstanding, 0) AS Outstanding,
                   ISNULL(money.Overdue, 0)     AS Overdue
            FROM   Rooms r

            OUTER APPLY (
                SELECT COUNT(*) AS ActiveTenants
                FROM   Tenancies tn
                WHERE  tn.RoomId = r.RoomId
                  AND  tn.Status = 'Active'
            ) occ

            OUTER APPLY (
                SELECT SUM(unpaid.Amount) AS Outstanding,
                       SUM(CASE WHEN unpaid.DueDate < CAST(GETDATE() AS DATE)
                                THEN unpaid.Amount ELSE 0 END) AS Overdue
                FROM (
                    SELECT b.DueDate,
                           bt.Share
                         - ISNULL((SELECT SUM(a.Amount)
                                   FROM   PaymentAllocations a
                                   JOIN   Payments p ON p.PaymentId = a.PaymentId
                                   WHERE  a.BillId   = bt.BillId
                                     AND  a.TenantId = bt.TenantId
                                     AND  a.IsVoided = 0
                                     AND  p.IsVoided = 0), 0) AS Amount
                    FROM   BillTenants bt
                    JOIN   Bills b ON b.BillId = bt.BillId
                    WHERE  b.RoomId = r.RoomId
                      AND  EXISTS (SELECT 1
                                   FROM   Tenancies tn2
                                   WHERE  tn2.TenantId = bt.TenantId
                                     AND  tn2.RoomId   = r.RoomId
                                     AND  tn2.Status   = 'Active'
                                     AND  b.BillingPeriodStart >= tn2.MoveInDate)
                ) unpaid
                WHERE unpaid.Amount > 0
            ) money

            WHERE  r.FloorId    = @fId
              AND  r.BuildingId = @bId
              AND  r.IsArchived = 0
            ORDER BY LEN(r.RoomNumber) ASC, r.RoomNumber ASC;";


        /* =================================================================
           PAYMENT STATE

           The rule lives here, next to the query that feeds it. The card
           only displays whatever state it is given.

           Order matters: overdue outranks unpaid, so a room with one share
           past due shows red even if its other shares are not yet due.
           ================================================================= */

        private static BillingRoomState BillingState(int tenantCount,
                                                     decimal outstanding,
                                                     decimal overdue)
        {
            if (tenantCount == 0) return BillingRoomState.Vacant;
            if (overdue > 0m) return BillingRoomState.Overdue;
            if (outstanding > 0m) return BillingRoomState.Unpaid;
            return BillingRoomState.Settled;
        }


        /* =================================================================
           NAVIGATION
           ================================================================= */

        private void RoomCard_Clicked(object sender, EventArgs e)
        {
            BillingRoomItemControl card = sender as BillingRoomItemControl;
            if (card == null) return;

            BillingRoomDetailsControl details =
                new BillingRoomDetailsControl(card.RoomId) { Dock = DockStyle.Fill };

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
