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

        private void btnSetPassword_Click(object sender, EventArgs e)
        {
            // Proceed to the Success Form
            PasswordSuccessForm successForm = new PasswordSuccessForm();
            successForm.Show();

            // Close this Reset Form
            this.Close();
        }

        private void PasswordResetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
