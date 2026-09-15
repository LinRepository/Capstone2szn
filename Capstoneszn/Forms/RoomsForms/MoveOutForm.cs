using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.UserControls
{
    public partial class MoveOutForm : Form
    {
        public MoveOutForm()
        {
            InitializeComponent();
        }

        private void btnCancelMoveOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
