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
    public partial class AddBuildingForm : Form
    {

        public AddBuildingForm()
        {
            InitializeComponent();


        }

        private void AddBuildingForm_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string buildingName = txtBuildingName.Text.Trim();
            int floors = (int)nudFloors.Value;

            // Validate that the user actually entered data
            if (string.IsNullOrEmpty(buildingName) || floors <= 0)
            {
                MessageBox.Show("Please enter a valid building name and at least 1 floor.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Instantiate the next form and pass the variables into its constructor
            FloorConfigurationForm configForm = new FloorConfigurationForm(buildingName, floors);
            configForm.Show();

            // Hide this form so they can go 'Back' if needed
            this.Hide();
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            // Return to the Select Building Form
            var selectForm = Application.OpenForms.OfType<Login>().FirstOrDefault();

            if (selectForm != null)
            {
                selectForm.Show();
            }
            else
            {
                new Login().Show();
            }

            this.Close();
        }

    }
}
