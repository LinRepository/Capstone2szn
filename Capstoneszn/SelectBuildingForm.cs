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

        }

        private void lblAddBuilding_Click(object sender, EventArgs e)
        {

        }

        private void PanelAddBuilding_Paint(object sender, PaintEventArgs e)
        {

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
