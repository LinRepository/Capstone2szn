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

namespace Capstoneszn.UserControls
{
    public partial class MaintenanceControl : UserControl
    {
        public MaintenanceControl()
        {
            InitializeComponent();
        }

        private void btnAddIssue_Click(object sender, EventArgs e)
        {
            AddIssueForm aif = new AddIssueForm();
            aif.Show();


        }
    }
}
