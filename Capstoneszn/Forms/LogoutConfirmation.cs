using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms
{
    public partial class LogoutConfirmation : Form
    {
        public LogoutConfirmation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectBuildingForm sbf = new SelectBuildingForm();
            sbf.Show();
            this.Hide();
        }
    }
}
