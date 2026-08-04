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

namespace Capstoneszn
{
    public partial class MainForm : Form
    {
        private bool isSidebarExpanded = true;

        private const int SidebarExpandedWidth = 240;
        private const int SidebarCollapsedWidth = 70;

        public MainForm()
        {
            InitializeComponent();

            pnlSideBar.Width = SidebarExpandedWidth;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadControl(new HomeControl());

            SaveButtonTexts();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadControl(new HomeControl());
        }

        private void btnTenants_Click(object sender, EventArgs e)
        {
            LoadControl(new TenantsControl());
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            LoadControl(new RoomsControl());
        }

        private void btnUtilities_Click(object sender, EventArgs e)
        {
            LoadControl(new UtilitiesControl());
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            LoadControl(new MaintenanceControl());
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            LoadControl(new BillingManagementControl());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadControl(new ReportsControl());
        }

        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            LoadControl(new PaymentHistoryControl());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            LoadControl(new EmployeeControl());
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            LoadControl(new AuditLogsControl());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            LoadControl(new SettingsControl());
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

        
    }
}
