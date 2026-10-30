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
using Capstoneszn.Forms.BuildingForms; // for SystemClockForm

namespace Capstoneszn
{
    public partial class MainForm : Form
    {
        private bool isSidebarExpanded = true;
        private const int SidebarExpandedWidth = 220;
        private const int SidebarCollapsedWidth = 44;

        //ROOMS
        private int checkbuildingId;



        private string currentBuildingName = "";


        // 1. The NEW Constructor used for db
        public MainForm(int buildingId, string buildingName)
        {
            InitializeComponent();
            pnlSideBar.Width = SidebarExpandedWidth;

            checkbuildingId = buildingId; //ROOMS MODULE
            currentBuildingName = buildingName;
        }

        //MAIN FORM 
        private void MainForm_Load(object sender, EventArgs e)
        {
            // SYSTEM CLOCK CHECK – must pass before the system load
            using (var clockForm = new SystemClockForm())
            {
                if (clockForm.ShowDialog() != DialogResult.OK)
                {
                    // User went back or closed the window: treat it like a logout
                    Session.Clear();
                    Session.LoggingOut = true;
                    BeginInvoke(new Action(Close)); // close MainForm safely after Load finishes
                    return;
                }
            }

            // ADDED (Employee module STEP 7): record the salary expense of every
            // finished month not recorded yet. It runs HERE, after the clock check
            // passed, so a wrong PC date can't record months early. Safe to run
            // every time MainForm opens - a month is never recorded twice.
            try
            {
                var salaries = SalaryHelper.RecordMonthEndSalaries(Session.UserId);
                if (salaries.Count > 0)
                    System.Diagnostics.Debug.WriteLine(
                        $"Salary: {salaries.Count} expense(s) recorded, total {salaries.Total:N2}.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            LoadControl(new HomeControl());

            SaveButtonTexts();

            //time
            UpdateDateTime();

            lblSystemName.Text = string.IsNullOrWhiteSpace(currentBuildingName) ? "Building Name" : currentBuildingName;


            //for user
            lblCurrentUser.Text = Session.Name;
            lblUserRole.Text = Session.Role;

            // ADDED (Employee module): caretakers must not see the Employee module
            btnEmployee.Visible = Session.IsLandlord;

            // ADDED (caretaker restrictions): Reports is landlord-only too.
            // Hidden buttons leave no gap - the FlowLayoutPanel moves the rest up.
            btnReports.Visible = Session.IsLandlord;

        }


        // Single helper method to keep code clean and maintainable
        private void UpdateDateTime()
        {
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy"); // e.g., September 29, 2026
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
            for (int i = pnlContent.Controls.Count - 1; i >= 0; i--)
                pnlContent.Controls[i].Dispose();

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

        public void ForceLogout()
        {
            AuditLogger.Log(AuditLogger.ModuleLogin, "Logout", "Signed out (account locked)");
            Session.Clear();
            Session.LoggingOut = true;
            this.Close();
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
            if (!Session.IsLandlord) return;   // ADDED: landlord only (button is also hidden)
            LoadControl(new ReportsControl());
        }

        private void btnPaymentHistory_Click_1(object sender, EventArgs e)
        {
            LoadControl(new PaymentHistoryControl());
        }

        private void btnEmployee_Click_1(object sender, EventArgs e)
        {
            if (!Session.IsLandlord) return;   // ADDED: landlord only (button is also hidden)
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
            AuditLogger.Log(AuditLogger.ModuleLogin, "Logout", "Signed out");
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