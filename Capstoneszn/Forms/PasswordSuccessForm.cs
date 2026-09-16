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
            var loginForm = Application.OpenForms.OfType<LoginForm>().FirstOrDefault();

            if (loginForm != null)
            {
                loginForm.Show();
            }
            else
            {
                new LoginForm().Show();
            }

            // Close the Success Form
            this.Close();
        }
    }
}
