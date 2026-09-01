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
    public partial class ReportsControl : UserControl
    {
        public ReportsControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.BackColor = Color.LightGray;
            button1.ForeColor = Color.DarkGray;

            button2.Enabled = true;
            button2.BackColor = Color.SteelBlue;
            button2.ForeColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.BackColor = Color.LightGray;
            button2.ForeColor = Color.DarkGray;

            button1.Enabled = true;
            button1.BackColor = Color.SteelBlue;
            button1.ForeColor = Color.White;
        }
    }
}
