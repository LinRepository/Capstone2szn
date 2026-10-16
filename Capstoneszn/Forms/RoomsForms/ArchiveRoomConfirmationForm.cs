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
    /// <summary>
    /// "Are you sure?" for archiving one room. It only asks - it does not
    /// touch the database. ArchiveRoomForm does the save, in one place, and
    /// only when this returns OK.
    /// </summary>
    /// 

    public partial class ArchiveRoomConfirmationForm : Form
    {
        public ArchiveRoomConfirmationForm(string roomNumber, int floorNumber)
        {
            InitializeComponent();

            lblArchiveQuestion.Text = $"Archive Room {roomNumber} (Floor {floorNumber})?";

            // Esc cancels. Enter is NOT mapped to Archive on purpose:
            // a confirmation should not be passed by a stray key press.
            this.CancelButton = btnCancelArchive;
            this.ActiveControl = btnCancelArchive;
        }

        private void ArchiveRoomConfirmationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmArchive_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelArchive_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
