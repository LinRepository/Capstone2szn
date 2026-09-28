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
    public partial class RoomCardControl : UserControl
    {

        public int RoomId { get; set; }
        public string Status { get; set; }

        public string RoomNumber
        {
            get { return lblRoomNumber.Text; }
            set { lblRoomNumber.Text = value; }
        }

        public string Occupancy
        {
            get { return lblOccupancy.Text; }
            set { lblOccupancy.Text = value; }
        }

        // Event for when the card is clicked (We will use this later for Room Information)
        public event EventHandler CardClicked;


        public RoomCardControl()
        {
            InitializeComponent();

            this.Click += OnCardClicked;
            lblRoomNumber.Click += OnCardClicked;
            lblOccupancy.Click += OnCardClicked;
        }

        public void SetStatusColor(string status)
        {
            Status = status;
            // Matches your dashboard legend colors
            if (status == "Available") this.BackColor = Color.LimeGreen;
            else if (status == "Occupied") this.BackColor = Color.Crimson;
            else if (status == "Maintenance") this.BackColor = Color.Gray;
        }

        private void OnCardClicked(object sender, EventArgs e)
        {
            CardClicked?.Invoke(this, e);
        }

        private void lblRoomNumber_Click(object sender, EventArgs e)
        {
            
        }

        private void lblOccupancy_Click(object sender, EventArgs e)
        {
            
        }

        private void RoomCardControl_Load(object sender, EventArgs e)
        {

        }
    }
}
