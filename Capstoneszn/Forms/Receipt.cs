using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Utilities
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }

        private void Receipt_Load(object sender, EventArgs e)
        {

        }
        //Getting Data
        public Receipt(string date, string receivedFrom, string amount)
        {
            InitializeComponent();

            lblDate.Text = date;
            lblRoom.Text = receivedFrom;
            lblAmount.Text = amount;
        }
    }
}
