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
        public RoomCardControl()
        {
            InitializeComponent();

            // Unify the clicks so clicking anywhere on the card triggers the same event
            this.Click += OnRoomClicked;
            lblRoomNumber.Click += OnRoomClicked;
            lblOccupancy.Click += OnRoomClicked;
        }
        // Database properties
        public int RoomId { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupants { get; set; }

        public string RoomName
        {
            get { return lblRoomNumber.Text; }
            set { lblRoomNumber.Text = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                UpdateColor();
            }
        }

        // Custom event so the main dashboard knows which room was clicked
        public event EventHandler RoomClicked;

        public void UpdateOccupancyLabel()
        {
            // Formats the label to look like "1/1" or "0/2"
            lblOccupancy.Text = $"{CurrentOccupants}/{Capacity}";
        }

        private void UpdateColor()
        {
            // Apply your Figma color legend
            if (_status == "Available")
                this.BackColor = Color.LimeGreen;
            else if (_status == "Occupied")
                this.BackColor = Color.Crimson;
            else if (_status == "Maintenance")
                this.BackColor = Color.Gray;
            else
                this.BackColor = Color.SlateGray;
        }

        private void OnRoomClicked(object sender, EventArgs e)
        {
            RoomClicked?.Invoke(this, e);
        }

        private void lblRoomNumber_Click(object sender, EventArgs e)
        {
            OnRoomClicked(this, e);
        }

        private void lblOccupancy_Click(object sender, EventArgs e)
        {
            OnRoomClicked(this, e);
        }

        private void RoomCardControl_Load(object sender, EventArgs e)
        {

        }
    }
}
