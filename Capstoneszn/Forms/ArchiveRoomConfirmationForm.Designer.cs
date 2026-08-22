namespace Capstoneszn.Forms
{
    partial class ArchiveRoomConfirmationForm
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
            pnlArchiveActions = new Panel();
            btnConfirmArchive = new Button();
            btnCancelArchive = new Button();
            pnlArchiveHeader = new Panel();
            lblArchiveTitle = new Label();
            pnlArchiveContent = new Panel();
            lblArchiveNotice = new Label();
            lblArchiveQuestion = new Label();
            pnlArchiveActions.SuspendLayout();
            pnlArchiveHeader.SuspendLayout();
            pnlArchiveContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlArchiveActions
            // 
            pnlArchiveActions.Controls.Add(btnConfirmArchive);
            pnlArchiveActions.Controls.Add(btnCancelArchive);
            pnlArchiveActions.Dock = DockStyle.Bottom;
            pnlArchiveActions.Location = new Point(0, 208);
            pnlArchiveActions.Name = "pnlArchiveActions";
            pnlArchiveActions.Size = new Size(332, 45);
            pnlArchiveActions.TabIndex = 1;
            // 
            // btnConfirmArchive
            // 
            btnConfirmArchive.Location = new Point(190, 8);
            btnConfirmArchive.Name = "btnConfirmArchive";
            btnConfirmArchive.Size = new Size(130, 29);
            btnConfirmArchive.TabIndex = 1;
            btnConfirmArchive.Text = "Archive Room";
            btnConfirmArchive.UseVisualStyleBackColor = true;
            // 
            // btnCancelArchive
            // 
            btnCancelArchive.Location = new Point(72, 8);
            btnCancelArchive.Name = "btnCancelArchive";
            btnCancelArchive.Size = new Size(94, 29);
            btnCancelArchive.TabIndex = 0;
            btnCancelArchive.Text = "Cancel";
            btnCancelArchive.UseVisualStyleBackColor = true;
            // 
            // pnlArchiveHeader
            // 
            pnlArchiveHeader.Controls.Add(lblArchiveTitle);
            pnlArchiveHeader.Dock = DockStyle.Top;
            pnlArchiveHeader.Location = new Point(0, 0);
            pnlArchiveHeader.Name = "pnlArchiveHeader";
            pnlArchiveHeader.Size = new Size(332, 45);
            pnlArchiveHeader.TabIndex = 2;
            // 
            // lblArchiveTitle
            // 
            lblArchiveTitle.AutoSize = true;
            lblArchiveTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveTitle.ForeColor = Color.White;
            lblArchiveTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblArchiveTitle.Location = new Point(57, 8);
            lblArchiveTitle.Name = "lblArchiveTitle";
            lblArchiveTitle.Size = new Size(220, 28);
            lblArchiveTitle.TabIndex = 31;
            lblArchiveTitle.Text = "Confirmation of Archive";
            lblArchiveTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblArchiveTitle.Visible = false;
            // 
            // pnlArchiveContent
            // 
            pnlArchiveContent.Controls.Add(lblArchiveQuestion);
            pnlArchiveContent.Controls.Add(lblArchiveNotice);
            pnlArchiveContent.Dock = DockStyle.Fill;
            pnlArchiveContent.Location = new Point(0, 45);
            pnlArchiveContent.Name = "pnlArchiveContent";
            pnlArchiveContent.Size = new Size(332, 163);
            pnlArchiveContent.TabIndex = 3;
            // 
            // lblArchiveNotice
            // 
            lblArchiveNotice.Dock = DockStyle.Bottom;
            lblArchiveNotice.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveNotice.ForeColor = Color.White;
            lblArchiveNotice.ImageAlign = ContentAlignment.MiddleRight;
            lblArchiveNotice.Location = new Point(0, 93);
            lblArchiveNotice.Name = "lblArchiveNotice";
            lblArchiveNotice.Size = new Size(332, 70);
            lblArchiveNotice.TabIndex = 33;
            lblArchiveNotice.Text = "This room will no longer appear in the active room list.";
            lblArchiveNotice.TextAlign = ContentAlignment.MiddleCenter;
            lblArchiveNotice.Visible = false;
            // 
            // lblArchiveQuestion
            // 
            lblArchiveQuestion.Dock = DockStyle.Fill;
            lblArchiveQuestion.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveQuestion.ForeColor = Color.White;
            lblArchiveQuestion.ImageAlign = ContentAlignment.MiddleRight;
            lblArchiveQuestion.Location = new Point(0, 0);
            lblArchiveQuestion.Name = "lblArchiveQuestion";
            lblArchiveQuestion.Size = new Size(332, 93);
            lblArchiveQuestion.TabIndex = 34;
            lblArchiveQuestion.Text = "Are you sure you want to archive this room?";
            lblArchiveQuestion.TextAlign = ContentAlignment.MiddleCenter;
            lblArchiveQuestion.Visible = false;
            // 
            // ArchiveRoomConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(332, 253);
            Controls.Add(pnlArchiveContent);
            Controls.Add(pnlArchiveHeader);
            Controls.Add(pnlArchiveActions);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ArchiveRoomConfirmationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Archive Room";
            pnlArchiveActions.ResumeLayout(false);
            pnlArchiveHeader.ResumeLayout(false);
            pnlArchiveHeader.PerformLayout();
            pnlArchiveContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlArchiveActions;
        private Button btnConfirmArchive;
        private Button btnCancelArchive;
        private Panel pnlArchiveHeader;
        private Label lblArchiveTitle;
        private Panel pnlArchiveContent;
        private Label lblArchiveNotice;
        private Label lblArchiveQuestion;
    }
}