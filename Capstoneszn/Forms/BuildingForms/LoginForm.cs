using System.ComponentModel;
using System.Windows.Forms;
using Capstoneszn.Forms.BuildingForms;

namespace Capstoneszn
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void SelectBuildingForm_Load(object sender, EventArgs e)
        {



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoginPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BuildingSelection bs = new BuildingSelection();
            bs.Show();
            this.Hide();
        }

        private void lnkForgotPassword_Click(object sender, EventArgs e)
        {
            ForgetForm ff = new ForgetForm();
            ff.Show();

            //HIDE
            this.Hide();
        }
    }

}
