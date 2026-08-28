namespace Capstoneszn.Forms
{
    partial class DeleteIssueConfirmationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlDeleteIssueHeader = new Panel();
            pnlDeleteIssueActions = new Panel();
            pnlDeleteIssueContent = new Panel();
            lblDeleteIssueTitle = new Label();
            lblDeleteIssueQuestion = new Label();
            lblDeleteIssueNotice = new Label();
            btnCancelDeleteIssue = new Button();
            btnConfirmDeleteIssue = new Button();
            pnlDeleteIssueHeader.SuspendLayout();
            pnlDeleteIssueActions.SuspendLayout();
            pnlDeleteIssueContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDeleteIssueHeader
            // 
            pnlDeleteIssueHeader.Controls.Add(lblDeleteIssueTitle);
            pnlDeleteIssueHeader.Dock = DockStyle.Top;
            pnlDeleteIssueHeader.Location = new Point(0, 0);
            pnlDeleteIssueHeader.Name = "pnlDeleteIssueHeader";
            pnlDeleteIssueHeader.Size = new Size(432, 45);
            pnlDeleteIssueHeader.TabIndex = 0;
            // 
            // pnlDeleteIssueActions
            // 
            pnlDeleteIssueActions.Controls.Add(btnConfirmDeleteIssue);
            pnlDeleteIssueActions.Controls.Add(btnCancelDeleteIssue);
            pnlDeleteIssueActions.Dock = DockStyle.Bottom;
            pnlDeleteIssueActions.Location = new Point(0, 168);
            pnlDeleteIssueActions.Name = "pnlDeleteIssueActions";
            pnlDeleteIssueActions.Size = new Size(432, 45);
            pnlDeleteIssueActions.TabIndex = 1;
            // 
            // pnlDeleteIssueContent
            // 
            pnlDeleteIssueContent.Controls.Add(lblDeleteIssueNotice);
            pnlDeleteIssueContent.Controls.Add(lblDeleteIssueQuestion);
            pnlDeleteIssueContent.Dock = DockStyle.Fill;
            pnlDeleteIssueContent.Location = new Point(0, 45);
            pnlDeleteIssueContent.Name = "pnlDeleteIssueContent";
            pnlDeleteIssueContent.Size = new Size(432, 123);
            pnlDeleteIssueContent.TabIndex = 2;
            // 
            // lblDeleteIssueTitle
            // 
            lblDeleteIssueTitle.Dock = DockStyle.Fill;
            lblDeleteIssueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDeleteIssueTitle.ForeColor = Color.White;
            lblDeleteIssueTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblDeleteIssueTitle.Location = new Point(0, 0);
            lblDeleteIssueTitle.Name = "lblDeleteIssueTitle";
            lblDeleteIssueTitle.Size = new Size(432, 45);
            lblDeleteIssueTitle.TabIndex = 41;
            lblDeleteIssueTitle.Text = "Delete Maintenance Issue";
            lblDeleteIssueTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblDeleteIssueTitle.Visible = false;
            // 
            // lblDeleteIssueQuestion
            // 
            lblDeleteIssueQuestion.Dock = DockStyle.Top;
            lblDeleteIssueQuestion.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDeleteIssueQuestion.ForeColor = Color.White;
            lblDeleteIssueQuestion.ImageAlign = ContentAlignment.MiddleRight;
            lblDeleteIssueQuestion.Location = new Point(0, 0);
            lblDeleteIssueQuestion.Name = "lblDeleteIssueQuestion";
            lblDeleteIssueQuestion.Size = new Size(432, 60);
            lblDeleteIssueQuestion.TabIndex = 41;
            lblDeleteIssueQuestion.Text = "Are you sure you want to delete the issue for Room 202?";
            lblDeleteIssueQuestion.TextAlign = ContentAlignment.MiddleCenter;
            lblDeleteIssueQuestion.Visible = false;
            // 
            // lblDeleteIssueNotice
            // 
            lblDeleteIssueNotice.Dock = DockStyle.Bottom;
            lblDeleteIssueNotice.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDeleteIssueNotice.ForeColor = Color.White;
            lblDeleteIssueNotice.ImageAlign = ContentAlignment.MiddleRight;
            lblDeleteIssueNotice.Location = new Point(0, 60);
            lblDeleteIssueNotice.Name = "lblDeleteIssueNotice";
            lblDeleteIssueNotice.Size = new Size(432, 63);
            lblDeleteIssueNotice.TabIndex = 42;
            lblDeleteIssueNotice.Text = "This issue will no longer appear in the active maintenance list ";
            lblDeleteIssueNotice.TextAlign = ContentAlignment.MiddleCenter;
            lblDeleteIssueNotice.Visible = false;
            // 
            // btnCancelDeleteIssue
            // 
            btnCancelDeleteIssue.Location = new Point(213, 8);
            btnCancelDeleteIssue.Name = "btnCancelDeleteIssue";
            btnCancelDeleteIssue.Size = new Size(94, 29);
            btnCancelDeleteIssue.TabIndex = 0;
            btnCancelDeleteIssue.Text = "Cancel";
            btnCancelDeleteIssue.UseVisualStyleBackColor = true;
            // 
            // btnConfirmDeleteIssue
            // 
            btnConfirmDeleteIssue.Location = new Point(326, 8);
            btnConfirmDeleteIssue.Name = "btnConfirmDeleteIssue";
            btnConfirmDeleteIssue.Size = new Size(94, 29);
            btnConfirmDeleteIssue.TabIndex = 1;
            btnConfirmDeleteIssue.Text = "Confirm";
            btnConfirmDeleteIssue.UseVisualStyleBackColor = true;
            // 
            // DeleteIssueConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 28, 30);
            ClientSize = new Size(432, 213);
            Controls.Add(pnlDeleteIssueContent);
            Controls.Add(pnlDeleteIssueActions);
            Controls.Add(pnlDeleteIssueHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeleteIssueConfirmationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Delete Maintenance Issue";
            pnlDeleteIssueHeader.ResumeLayout(false);
            pnlDeleteIssueActions.ResumeLayout(false);
            pnlDeleteIssueContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDeleteIssueHeader;
        private Panel pnlDeleteIssueActions;
        private Panel pnlDeleteIssueContent;
        private Label lblDeleteIssueTitle;
        private Button btnConfirmDeleteIssue;
        private Button btnCancelDeleteIssue;
        private Label lblDeleteIssueNotice;
        private Label lblDeleteIssueQuestion;
    }
}