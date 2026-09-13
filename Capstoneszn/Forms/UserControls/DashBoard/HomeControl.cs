using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
