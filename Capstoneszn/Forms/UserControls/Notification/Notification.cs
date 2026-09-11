using Capstoneszn.Forms.UserControls.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls
{
    public partial class NotificationControl : UserControl
    {
        public NotificationControl()
        {
            InitializeComponent();
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            flowLayoutPanel1.BringToFront();
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                NotificationItem item = new NotificationItem();

                item.Width = 1200;
                item.Height = 60;
                item.Margin = new Padding(10);
                item.BackColor = Color.Navy; // Bright color to guarantee visibility

                flowLayoutPanel1.Controls.Add(item);
            }
        }
    }
}
