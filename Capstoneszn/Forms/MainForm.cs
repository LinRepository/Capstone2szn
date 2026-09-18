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

namespace Capstoneszn
{
    public partial class MainForm : Form
    {
        private bool isSidebarExpanded = true;

        private const int SidebarExpandedWidth = 220;
        private const int SidebarCollapsedWidth = 44;

        public MainForm()
        {
            InitializeComponent();

            pnlSideBar.Width = SidebarExpandedWidth;
        }

        //MAIN FORM 
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadControl(new HomeControl());

            SaveButtonTexts();

            // Initialize time immediately
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt"); // Shows live time with AM/PM
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt"); // Shows live time with AM/PM
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy"); // Keeps the date current
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
            LoadControl(new RoomsControl());
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
            LoadControl(new BillingManagementControl());
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
            LogoutConfirmationForm confirmForm = new LogoutConfirmationForm();

            // ShowDialog will pause execution here until the user clicks Yes or Cancel
            if (confirmForm.ShowDialog() == DialogResult.Yes)
            {
                // If they clicked Yes, check if SelectBuildingForm is already open and hidden
                var selectForm = Application.OpenForms.OfType<Login>().FirstOrDefault();

                if (selectForm != null)
                {
                    // Show the existing one
                    selectForm.Show();
                }
                else
                {
                    // If it doesn't exist for some reason, create a new one
                    new Login().Show();
                }

                // Close the MainForm
                this.Close();
            }

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