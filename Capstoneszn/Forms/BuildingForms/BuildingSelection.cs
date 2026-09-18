using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.BuildingForms
{
    public partial class BuildingSelection : Form
    {
        public BuildingSelection()
        {
            InitializeComponent();
        }

        private void BuildingSelection_Load(object sender, EventArgs e)
        {

        }

        private void flpBuildings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPlusSampleBuilding_Click(object sender, EventArgs e)
        {
            // Create and show the Main Forma
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Hide the Login Form
            this.Close();
        }

        private void lblPlusBuilding_Click(object sender, EventArgs e)
        {
            AddBuildingForm addForm = new AddBuildingForm();
            addForm.Show();

            // Hide
            this.Hide();
        }
    }
}
