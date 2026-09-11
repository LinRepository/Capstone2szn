namespace Capstoneszn.Forms.SettingsForms
{
    partial class RestoreArchiveConfirmationForm
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
            pnlRestoreArchiveHeader = new Panel();
            pnlRestoreArchiveActions = new Panel();
            pnlRestoreArchiveContent = new Panel();
            lblRestoreArchiveTitle = new Label();
            btnCancelRestoreArchive = new Button();
            btnConfirmRestoreArchive = new Button();
            lblRestoreArchiveQuestion = new Label();
            lblRestoreArchiveNotice = new Label();
            pnlRestoreArchiveHeader.SuspendLayout();
            pnlRestoreArchiveActions.SuspendLayout();
            pnlRestoreArchiveContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRestoreArchiveHeader
            // 
            pnlRestoreArchiveHeader.Controls.Add(lblRestoreArchiveTitle);
            pnlRestoreArchiveHeader.Dock = DockStyle.Top;
            pnlRestoreArchiveHeader.Location = new Point(0, 0);
            pnlRestoreArchiveHeader.Name = "pnlRestoreArchiveHeader";
            pnlRestoreArchiveHeader.Size = new Size(482, 55);
            pnlRestoreArchiveHeader.TabIndex = 0;
            // 
            // pnlRestoreArchiveActions
            // 
            pnlRestoreArchiveActions.Controls.Add(btnConfirmRestoreArchive);
            pnlRestoreArchiveActions.Controls.Add(btnCancelRestoreArchive);
            pnlRestoreArchiveActions.Dock = DockStyle.Bottom;
            pnlRestoreArchiveActions.Location = new Point(0, 198);
            pnlRestoreArchiveActions.Name = "pnlRestoreArchiveActions";
            pnlRestoreArchiveActions.Size = new Size(482, 55);
            pnlRestoreArchiveActions.TabIndex = 1;
            // 
            // pnlRestoreArchiveContent
            // 
            pnlRestoreArchiveContent.Controls.Add(lblRestoreArchiveNotice);
            pnlRestoreArchiveContent.Controls.Add(lblRestoreArchiveQuestion);
            pnlRestoreArchiveContent.Dock = DockStyle.Fill;
            pnlRestoreArchiveContent.Location = new Point(0, 55);
            pnlRestoreArchiveContent.Name = "pnlRestoreArchiveContent";
            pnlRestoreArchiveContent.Size = new Size(482, 143);
            pnlRestoreArchiveContent.TabIndex = 2;
            // 
            // lblRestoreArchiveTitle
            // 
            lblRestoreArchiveTitle.Dock = DockStyle.Fill;
            lblRestoreArchiveTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRestoreArchiveTitle.ForeColor = Color.White;
            lblRestoreArchiveTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRestoreArchiveTitle.Location = new Point(0, 0);
            lblRestoreArchiveTitle.Name = "lblRestoreArchiveTitle";
            lblRestoreArchiveTitle.Size = new Size(482, 55);
            lblRestoreArchiveTitle.TabIndex = 11;
            lblRestoreArchiveTitle.Text = "Archive Utility Account";
            lblRestoreArchiveTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancelRestoreArchive
            // 
            btnCancelRestoreArchive.Cursor = Cursors.Hand;
            btnCancelRestoreArchive.Location = new Point(253, 14);
            btnCancelRestoreArchive.Name = "btnCancelRestoreArchive";
            btnCancelRestoreArchive.Size = new Size(94, 29);
            btnCancelRestoreArchive.TabIndex = 0;
            btnCancelRestoreArchive.Text = "Cancel";
            btnCancelRestoreArchive.UseVisualStyleBackColor = true;
            // 
            // btnConfirmRestoreArchive
            // 
            btnConfirmRestoreArchive.Cursor = Cursors.Hand;
            btnConfirmRestoreArchive.Location = new Point(367, 14);
            btnConfirmRestoreArchive.Name = "btnConfirmRestoreArchive";
            btnConfirmRestoreArchive.Size = new Size(94, 29);
            btnConfirmRestoreArchive.TabIndex = 1;
            btnConfirmRestoreArchive.Text = "Restore";
            btnConfirmRestoreArchive.UseVisualStyleBackColor = true;
            // 
            // lblRestoreArchiveQuestion
            // 
            lblRestoreArchiveQuestion.Dock = DockStyle.Top;
            lblRestoreArchiveQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRestoreArchiveQuestion.ForeColor = Color.White;
            lblRestoreArchiveQuestion.ImageAlign = ContentAlignment.MiddleRight;
            lblRestoreArchiveQuestion.Location = new Point(0, 0);
            lblRestoreArchiveQuestion.Name = "lblRestoreArchiveQuestion";
            lblRestoreArchiveQuestion.Size = new Size(482, 70);
            lblRestoreArchiveQuestion.TabIndex = 12;
            lblRestoreArchiveQuestion.Text = "Are you sure you want to restore Room 202?";
            lblRestoreArchiveQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRestoreArchiveNotice
            // 
            lblRestoreArchiveNotice.Dock = DockStyle.Fill;
            lblRestoreArchiveNotice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRestoreArchiveNotice.ForeColor = Color.White;
            lblRestoreArchiveNotice.ImageAlign = ContentAlignment.MiddleRight;
            lblRestoreArchiveNotice.Location = new Point(0, 70);
            lblRestoreArchiveNotice.Name = "lblRestoreArchiveNotice";
            lblRestoreArchiveNotice.Size = new Size(482, 73);
            lblRestoreArchiveNotice.TabIndex = 13;
            lblRestoreArchiveNotice.Text = "This record will be returned to the active list.";
            lblRestoreArchiveNotice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RestoreArchiveConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 20, 38);
            ClientSize = new Size(482, 253);
            Controls.Add(pnlRestoreArchiveContent);
            Controls.Add(pnlRestoreArchiveActions);
            Controls.Add(pnlRestoreArchiveHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RestoreArchiveConfirmationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Restore Archived Record";
            pnlRestoreArchiveHeader.ResumeLayout(false);
            pnlRestoreArchiveActions.ResumeLayout(false);
            pnlRestoreArchiveContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRestoreArchiveHeader;
        private Panel pnlRestoreArchiveActions;
        private Panel pnlRestoreArchiveContent;
        private Label lblRestoreArchiveTitle;
        private Button btnConfirmRestoreArchive;
        private Button btnCancelRestoreArchive;
        private Label lblRestoreArchiveNotice;
        private Label lblRestoreArchiveQuestion;
    }
}