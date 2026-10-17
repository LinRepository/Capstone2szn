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
    /// Confirms and performs the soft delete of a Pending issue.
    /// Closes with DialogResult.OK only when the delete succeeded, so
    /// MaintenanceControl reloads the list.
    /// </summary>
    /// 
    public partial class DeleteIssueConfirmationForm : Form
    {
        private readonly int _issueId;

        public DeleteIssueConfirmationForm(int issueId)
        {
            _issueId = issueId;

            InitializeComponent();

            // These were hidden in the designer by mistake (decision L).
            lblDeleteIssueTitle.Visible = true;
            lblDeleteIssueQuestion.Visible = true;
            lblDeleteIssueNotice.Visible = true;

            // Esc cancels. No AcceptButton on purpose: Enter should not delete.
            CancelButton = btnCancelDeleteIssue;
        }

        private void btnConfirmDeleteIssue_Click(object sender, EventArgs e)
        {
            btnConfirmDeleteIssue.Enabled = false;   // no double delete on a double-click
            try
            {
                MaintenanceService.DeleteIssue(_issueId);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Issue Not Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.OK;   // list is stale - let the control reload it
                Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The issue was not deleted.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConfirmDeleteIssue.Enabled = true;
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelDeleteIssue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DeleteIssueConfirmationForm_Load(object sender, EventArgs e)
        {
            MaintenanceIssueHeader issue;
            try
            {
                issue = MaintenanceService.GetIssueHeader(_issueId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the issue.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (issue == null)
            {
                MessageBox.Show("This issue no longer exists.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            if (!issue.IsPending)
            {
                MessageBox.Show("This issue is already complete and can no longer be deleted.",
                    "Issue Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            lblDeleteIssueQuestion.Text =
                "Are you sure you want to delete \"" + issue.IssueTitle + "\" for Room " + issue.RoomNumber + "?";
            lblDeleteIssueNotice.Text =
                "This issue will no longer appear in the maintenance list.";

            // Default focus on Cancel, the safe choice.
            ActiveControl = btnCancelDeleteIssue;
        }
    }
}
