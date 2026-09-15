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
            // Set the result to Yes and close this confirmation box
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void LogoutConfirmationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogoutCancel_Click(object sender, EventArgs e)
        {
            // Set the result to Cancel (No) and close this confirmation box
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
