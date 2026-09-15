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

namespace Capstoneszn.Forms
{
    public partial class AddIssueForm : Form
    {
        public AddIssueForm()
        {
            InitializeComponent();
        }

        private void AddIssueForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelIssue_Click(object sender, EventArgs e)
        {
            // Return to the Select Building Form
            var selectForm = Application.OpenForms.OfType<MaintenanceControl>().FirstOrDefault();

            if (selectForm != null)
            {
                selectForm.Show();
            }
            else
            {
                new MaintenanceControl().Show();
            }

            this.Close(); // Close the current 
        }

        private void btnAddIssue_Click(object sender, EventArgs e)
        {

        }
    }
}
