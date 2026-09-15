using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn
{
    public partial class FloorConfigurationForm : Form
    {
        public FloorConfigurationForm()
        {
            InitializeComponent();
        }

        private void lblBuildingName_Click(object sender, EventArgs e)
        {

        }

        private void flpFloors_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Return to the Add Building Form
            var addForm = Application.OpenForms.OfType<AddBuildingForm>().FirstOrDefault();

            if (addForm != null)
            {
                addForm.Show();
            }
            else
            {
                new AddBuildingForm().Show();
            }

            this.Close(); // Close the current FloorConfigurationForm
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void FloorConfigurationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
