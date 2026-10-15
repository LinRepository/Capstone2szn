using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            // Login stays visible behind this dialog now that the recovery flow is
            // modal, so there is nothing to re-show. Closing returns control to
            // PasswordResetForm, which closes in turn.
            this.Close();
        }

        private void PasswordSuccessForm_Load(object sender, EventArgs e)
        {

        }
    }
}
