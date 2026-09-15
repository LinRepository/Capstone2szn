using System.ComponentModel;
using System.Windows.Forms;

namespace Capstoneszn
{
    public partial class SelectBuildingForm : Form
    {

        public SelectBuildingForm()
        {
            InitializeComponent();
        }

        private void SelectBuildingForm_Load(object sender, EventArgs e)
        {



        }

        private void flpBuildings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPlus_Click(object sender, EventArgs e)
        {
            // Create and show the Login Form
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            // Hide the current Select Building Form
            this.Hide();


        }

        private void lblAddBuilding_Click(object sender, EventArgs e)
        {

        }

        private void PanelAddBuilding_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSamplePlusBuilding_Click(object sender, EventArgs e)
        {
            AddBuildingForm addForm = new AddBuildingForm();
            addForm.Show();

            // Hide the SelectBuildingForm
            this.Hide();
        }
    }

    public class Building
    {
        public string Name { get; set; }
        public int Floors { get; set; }
        public int Rooms { get; set; }

        public Building(string name, int floors, int rooms)
        {
            Name = name;
            Floors = floors;
            Rooms = rooms;
        }
    }

}
