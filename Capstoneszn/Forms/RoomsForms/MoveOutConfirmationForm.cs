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

    

    public partial class MoveOutConfirmationForm : Form
    {
        /// <summary>
        /// The last stop before a move out is written.
        ///
        /// This dialog carries no logic of its own on purpose - it only
        /// displays what the caller has already worked out and returns OK or
        /// Cancel. Keeping it dumb means the figures shown here are the same
        /// ones that get written, because they are the same values.
        /// </summary>
        /// 


        /// <param name="summaryText">
        /// The consequence, already composed by the caller: who is moving
        /// out, from where, on what date, and every peso that will be
        /// written off or forfeited.
        /// </param>
        /// <param name="destroysMoney">
        /// True when money will actually be cancelled. Drives the
        /// irreversibility warning, so a clean move out is not dressed up
        /// as a destructive one.
        /// </param>
        public MoveOutConfirmationForm(string summaryText, bool destroysMoney)
        {
            InitializeComponent();

            lblConfirmation.Text = summaryText;

            if (destroysMoney)
            {
                lblIrreversible.Text =
                    "This cannot be undone. The amounts above will be recorded as cancelled.";
                lblIrreversible.ForeColor = Color.Gold;
            }
            else
            {
                lblIrreversible.Text =
                    "This cannot be undone, but no money is affected.";
                lblIrreversible.ForeColor = Color.Gainsboro;
            }
        }

        private void btnCancelConfirmation_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirmMoveOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
