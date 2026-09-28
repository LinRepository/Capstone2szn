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
    public partial class BuildingCard : UserControl
    {
        
        public int BuildingId { get; set; }

        public string BuildingName
        {
            get { return lblBuildingNameCard.Text; }
            set { lblBuildingNameCard.Text = value; }
        }

        // Custom event to notify the Selection Form when this card is clicked
        public event EventHandler CardClicked;

        public BuildingCard()
        {
            InitializeComponent();

            // Ensure clicking the background of the card also triggers the event
            this.Click += OnCardClicked;
        }

        private void BuildingCard_Load(object sender, EventArgs e)
        {

        }

        private void lblBuildingNameCard_Click(object sender, EventArgs e)
        {
            OnCardClicked(this, e);
        }

        private void lblBuildingContent_Click(object sender, EventArgs e)
        {
            OnCardClicked(this, e);
        }

        // The unified method that tells BuildingSelection this specific card was clicked
        private void OnCardClicked(object sender, EventArgs e)
        {
            CardClicked?.Invoke(this, e);
        }
    }
}
