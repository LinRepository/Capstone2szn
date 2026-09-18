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
            FloorConfigurationForm floorForm = new FloorConfigurationForm();
            floorForm.Show();

            // HIDE this form instead of closing it, so we don't lose the user's typed data
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
