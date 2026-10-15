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
using Microsoft.Data.SqlClient;

namespace Capstoneszn.UserControls
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        private void HomeControl_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        /// <summary>
        /// Public so MainForm can refresh the dashboard after another module
        /// changes something - a move-in, a new room, a completed issue.
        /// </summary>
        public void LoadDashboard()
        {
            LoadCounts();
            LoadRoomOverview();
            LoadMaintenance();
        }

        /* =================================================================
           TOP CARDS
           ================================================================= */

        /// <summary>
        /// Every count comes from vwRoomStatus, so the dashboard and the
        /// Rooms module can never disagree: they read the same derived
        /// status rather than each working it out separately.
        /// </summary>
        private void LoadCounts()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*) AS TotalUnits,
                           SUM(CASE WHEN v.Status = 'Available' THEN 1 ELSE 0 END) AS AvailableUnits,
                           SUM(CASE WHEN v.Status = 'Occupied'  THEN 1 ELSE 0 END) AS OccupiedUnits
                    FROM   vwRoomStatus v
                    WHERE  v.BuildingId = @bid
                      AND  v.IsArchived = 0;", conn))
                {
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = Session.BuildingId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return;

                        int total = r.GetInt32(0);
                        // SUM over zero rows is NULL, while COUNT is 0.
                        int available = r.IsDBNull(1) ? 0 : r.GetInt32(1);
                        int occupied = r.IsDBNull(2) ? 0 : r.GetInt32(2);

                        lblTotalCount.Text = total.ToString();
                        lblAvailableCount.Text = available.ToString();
                        lblOccupancyRate.Text = occupied.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // The dashboard is a summary, not a workflow. A failure here
                // leaves the zeros in place rather than blocking the screen.
                Debug.WriteLine(ex);
            }
        }

        /* =================================================================
           ROOM OVERVIEW - read-only colour map, matching the Rooms legend
           ================================================================= */

        private void LoadRoomOverview()
        {
            // Dispose rather than just Clear, or every refresh leaks the
            // previous set of labels.
            foreach (Control c in flpRoomOverview.Controls) c.Dispose();
            flpRoomOverview.Controls.Clear();

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT v.RoomNumber,
                           v.Status,
                           v.ActiveTenants,
                           ISNULL(v.Capacity, 0) AS Capacity
                    FROM   vwRoomStatus v
                    WHERE  v.BuildingId = @bid
                      AND  v.IsArchived = 0
                    ORDER BY LEN(v.RoomNumber) ASC, v.RoomNumber ASC;", conn))
                {
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = Session.BuildingId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string number = r.GetString(0);
                            string status = r.GetString(1);
                            int tenants = r.GetInt32(2);
                            int capacity = r.GetInt32(3);

                            flpRoomOverview.Controls.Add(
                                BuildRoomTile(number, status, tenants, capacity));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        /// <summary>
        /// One small read-only tile. Deliberately not clickable - the Home
        /// module is a summary; room actions live in the Rooms module.
        /// </summary>
        private static Label BuildRoomTile(string number, string status, int tenants, int capacity)
        {
            Label tile = new Label
            {
                Text = capacity > 0 ? $"{number}\n{tenants}/{capacity}" : number,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(100, 60),
                Margin = new Padding(6),
                BackColor = StatusColor(status)
            };

            return tile;
        }


        /// <summary>
        /// Must match RoomCardControl.SetStatusColor and the legend swatches,
        /// or the same room would appear in two different colours.
        /// </summary>
        private static Color StatusColor(string status)
        {
            switch (status)
            {
                case "Available": return Color.Chartreuse;
                case "Occupied": return Color.Crimson;
                case "Maintenance": return Color.LightSlateGray;
                default: return Color.White;   // Unconfigured
            }
        }



        /* =================================================================
           MAINTENANCE SUMMARY
           ================================================================= */

        private void LoadMaintenance()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT r.RoomNumber, mi.IssueTitle, mi.Status
                    FROM   MaintenanceIssues mi
                    JOIN   Rooms r ON r.RoomId = mi.RoomId
                    WHERE  r.BuildingId = @bid
                      AND  mi.IsDeleted = 0
                    ORDER BY CASE WHEN mi.Status = 'Pending' THEN 0 ELSE 1 END,
                             mi.DateReported DESC;", conn))
                {
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = Session.BuildingId;

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) da.Fill(dt);

                    // The three columns are defined in the designer, so the
                    // grid must not invent its own from the DataTable.
                    dgvMaintenance.AutoGenerateColumns = false;

                    if (dgvMaintenance.Columns["Room"] != null)
                        dgvMaintenance.Columns["Room"].DataPropertyName = "RoomNumber";

                    if (dgvMaintenance.Columns["Issue"] != null)
                        dgvMaintenance.Columns["Issue"].DataPropertyName = "IssueTitle";

                    if (dgvMaintenance.Columns["Status"] != null)
                        dgvMaintenance.Columns["Status"].DataPropertyName = "Status";

                    dgvMaintenance.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }



        private void btnViewAllActivities_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.OpenAuditLogsModule();
            }
        }

        private void btnViewAllMaintenance_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.OpenMaintenanceModule();
            }
        }

        private void btnViewAllNotifications_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm mainForm)
            {
                mainForm.OpenNotificationModule();
            }
        }
    }
}
