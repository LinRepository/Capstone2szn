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
    public partial class LogoutConfirmationForm : Form
    {
        public LogoutConfirmationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectBuildingForm sbf = new SelectBuildingForm();
            sbf.Show();
            this.Hide();
        }

        private void LogoutConfirmationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
