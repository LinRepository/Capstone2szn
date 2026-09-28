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
using Microsoft.Data.SqlClient;

namespace Capstoneszn.UserControls
{
    public partial class MoveInForm : Form
    {

        
        public MoveInForm()
        {
            InitializeComponent();

        }

        private void btnCancelMoveIn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MoveInForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmMoveIn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
