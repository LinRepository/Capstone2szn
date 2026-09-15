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
    public partial class RoomInformationForm : Form
    {
        public RoomInformationForm()
        {
            InitializeComponent();
        }

        private void btnMoveIn_Click(object sender, EventArgs e)
        {
            MoveInForm moveInForm = new MoveInForm();
            moveInForm.ShowDialog();
        }

        private void btnMoveOut_Click(object sender, EventArgs e)
        {
            MoveOutForm moveOutForm = new MoveOutForm();
            moveOutForm.ShowDialog();
        }

        private void btnCloseRoomInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
