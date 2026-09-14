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
            LoginForm lf = new LoginForm();
            lf.Show();

            Form? mf = Application.OpenForms["MainForm"];
            mf?.Close();
            this.Close();
        }

        private void LogoutConfirmationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogoutCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
