using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms;

namespace Capstoneszn
{
    public partial class PasswordResetForm : Form
    {
        public PasswordResetForm()
        {
            InitializeComponent();
        }

        private void btnReturnLogin_Click(object sender, EventArgs e)
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

            // Close the current Reset Form
            this.Close();
        }

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            // Proceed to the Success Form
            PasswordSuccessForm successForm = new PasswordSuccessForm();
            successForm.Show();

            // Close this Reset Form
            this.Close();
        }
    }
}
