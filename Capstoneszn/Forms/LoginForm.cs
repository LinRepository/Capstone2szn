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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void lblSystemName_Click(object sender, EventArgs e)
        {

        }

        private void InputUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void InputPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblShowPassword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {

        }


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            // Create and show the Main Form
            MainForm mainForm = new MainForm();
            mainForm.Show();

            // Hide the Login Form
            this.Close();
        }

        private void btnSwitchBuilding_Click(object sender, EventArgs e)
        {
            SelectBuildingForm SBF = new SelectBuildingForm();
            SBF.Show();

            //
            this.Close();
        }

        private void lnkForgotPassword_Click(object sender, EventArgs e)
        {
            // Create and show the Forget Form
            ForgetForm forgetForm = new ForgetForm();
            forgetForm.Show();

            // Hide the Login Form
            this.Hide();
        }
    }
}
