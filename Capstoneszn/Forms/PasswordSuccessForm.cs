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
    public partial class PasswordSuccessForm : Form
    {
        public PasswordSuccessForm()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Find the original hidden Login Form
            var login = Application.OpenForms.OfType<Login>().FirstOrDefault();

            if (login != null)
            {
                login.Show();
            }
            else
            {
                // Fallback just in case it doesn't exist
                new Login().Show();
            }

            // Close the current Forget Form
            this.Close();
        }
    }
}
