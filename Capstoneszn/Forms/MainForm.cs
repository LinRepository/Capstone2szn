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
using Capstoneszn.UserControls;
using Microsoft.Data.SqlClient;

namespace Capstoneszn
{
    public partial class MainForm : Form
    {
        private bool isSidebarExpanded = true;
        private const int SidebarExpandedWidth = 220;
        private const int SidebarCollapsedWidth = 44;

        //ROOMS
        private int checkbuildingId;


        private int checkcurrentBuildingId;
        private string currentBuildingName = ""; //Added ni Lin


        // 1. The NEW Constructor used for db
        public MainForm(int buildingId, string buildingName)
        {
            InitializeComponent();
            pnlSideBar.Width = SidebarExpandedWidth;

            checkcurrentBuildingId = buildingId; //BUILDING CREATION
            checkbuildingId = buildingId; //ROOMS MODULE
            currentBuildingName = buildingName; //Lin
        }

        //MAIN FORM 
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadControl(new HomeControl());

            SaveButtonTexts();

            //time
            UpdateDateTime();

            //Para to sa building name to
            try
            {
                lblSystemName.Text = GetBuildingName();
            }
            catch (Exception ex)
            {
                lblSystemName.Text = "Building Name";
                MessageBox.Show("Could not load building name: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //Para sa user
            lblCurrentUser.Text = Session.Name;
            lblUserRole.Text = Session.Role;

        }


        // Single helper method to keep code clean and maintainable
        private void UpdateDateTime()
        {
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy"); // e.g., September 29, 2026
        }

        //Load building name
        private string GetBuildingName()
        {
            string buildingName = "Building Name";   // fallback

            string query = "SELECT BuildingName FROM Buildings WHERE BuildingId = @id";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", checkcurrentBuildingId);
                conn.Open();

                string? value = cmd.ExecuteScalar()?.ToString();

                if (!string.IsNullOrWhiteSpace(value))
                    buildingName = value;
            }

            return buildingName;
        }
        

        private void SaveButtonTexts()
        {
            foreach (Control control in flpNavigation.Controls)
            {
                if (control is Button button)
                {
                    button.Tag = button.Text;
                }
            }

            btnLogout.Tag = btnLogout.Text;
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadControl(UserControl userControl)
        {
            foreach (Control c in pnlContent.Controls)
                c.Dispose();

            pnlContent.Controls.Clear();

            userControl.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(userControl);
        }

        private void CollapseSidebar()
        {
            pnlSideBar.Width = SidebarCollapsedWidth;

            foreach (Control control in flpNavigation.Controls)
            {
                if (control is Button button)
                {
                    button.Text = "";
                }
            }

            btnLogout.Text = "";

            isSidebarExpanded = false;
        }

        private void ExpandSidebar()
        {
            pnlSideBar.Width = SidebarExpandedWidth;

            foreach (Control control in flpNavigation.Controls)
            {
                if (control is Button button)
                {
                    button.Text = button.Tag?.ToString();
                }
            }

            btnLogout.Text = btnLogout.Tag?.ToString();

            isSidebarExpanded = true;
        }

        private void btnHamburger_Click(object sender, EventArgs e)
        {
            if (isSidebarExpanded)
            {
                CollapseSidebar();
            }
            else
            {
                ExpandSidebar();
            }

        }


        //SIDE PANEL BUTTONS
        /* SIDE PANEL BUTTONS */
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            LoadControl(new HomeControl());
        }

        private void btnTenants_Click_1(object sender, EventArgs e)
        {
            LoadControl(new TenantsControl());
        }

        private void btnRooms_Click_1(object sender, EventArgs e)
        {
            LoadControl(new RoomsControl(checkbuildingId));
        }

        private void btnUtilities_Click_1(object sender, EventArgs e)
        {
            LoadControl(new UtilitiesControl());
        }

        private void btnMaintenance_Click_1(object sender, EventArgs e)
        {
            LoadControl(new MaintenanceControl());
        }

        private void btnBillingManagement_Click(object sender, EventArgs e)
        {
            LoadControl(new BillingManagementControl(checkbuildingId));
        }

        private void btnReports_Click_1(object sender, EventArgs e)
        {
            LoadControl(new ReportsControl());
        }

        private void btnPaymentHistory_Click_1(object sender, EventArgs e)
        {
            LoadControl(new PaymentHistoryControl());
        }

        private void btnEmployee_Click_1(object sender, EventArgs e)
        {
            LoadControl(new EmployeeControl());
        }

        private void btnAuditLogs_Click_1(object sender, EventArgs e)
        {
            LoadControl(new AuditLogsControl());
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            using (var confirmForm = new LogoutConfirmationForm())
            {
                if (confirmForm.ShowDialog(this) != DialogResult.Yes) return;
            }

            Session.Clear();
            Session.LoggingOut = true;
            this.Close();

        }
        //SIDE PANEL BUTTONS
        /* SIDE PANEL BUTTONS */

        //NOTIFICATION BUTTON
        private void btnNotification_Click(object sender, EventArgs e)
        {
            LoadControl(new Capstoneszn.Forms.UserControls.NotificationControl());
        }
        //NOTIFICATION BUTTON



        #region Public Module Navigation Helpers (Called from Child UserControls)

        public void OpenAuditLogsModule()
        {
            LoadControl(new AuditLogsControl());
        }

        public void OpenMaintenanceModule()
        {
            LoadControl(new MaintenanceControl());
        }

        public void OpenNotificationModule()
        {
            LoadControl(new Capstoneszn.Forms.UserControls.NotificationControl());
        }

        #endregion

    }
}