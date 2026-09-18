using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn
{
    public partial class ForgetForm : Form
    {
        public ForgetForm()
        {
            InitializeComponent();
        }

        private void ForgetForm_Load(object sender, EventArgs e)
        {

        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            // Proceed to the Password Reset Form
            PasswordResetForm resetForm = new PasswordResetForm();
            resetForm.Show();

            // Close this verification form
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
