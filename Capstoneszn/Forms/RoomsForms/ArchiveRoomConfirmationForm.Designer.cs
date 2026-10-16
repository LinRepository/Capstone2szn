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
            lblArchiveQuestion = new Label();
            lblArchiveNotice = new Label();
            pnlArchiveActions.SuspendLayout();
            pnlArchiveHeader.SuspendLayout();
            pnlArchiveContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlArchiveActions
            // 
            pnlArchiveActions.BorderStyle = BorderStyle.FixedSingle;
            pnlArchiveActions.Controls.Add(btnConfirmArchive);
            pnlArchiveActions.Controls.Add(btnCancelArchive);
            pnlArchiveActions.Dock = DockStyle.Bottom;
            pnlArchiveActions.Location = new Point(0, 225);
            pnlArchiveActions.Name = "pnlArchiveActions";
            pnlArchiveActions.Size = new Size(420, 55);
            pnlArchiveActions.TabIndex = 1;
            // 
            // btnConfirmArchive
            // 
            btnConfirmArchive.Cursor = Cursors.Hand;
            btnConfirmArchive.Location = new Point(220, 11);
            btnConfirmArchive.Name = "btnConfirmArchive";
            btnConfirmArchive.Size = new Size(140, 32);
            btnConfirmArchive.TabIndex = 1;
            btnConfirmArchive.Text = "Archive Room";
            btnConfirmArchive.UseVisualStyleBackColor = true;
            btnConfirmArchive.Click += btnConfirmArchive_Click;
            // 
            // btnCancelArchive
            // 
            btnCancelArchive.Cursor = Cursors.Hand;
            btnCancelArchive.Location = new Point(60, 11);
            btnCancelArchive.Name = "btnCancelArchive";
            btnCancelArchive.Size = new Size(140, 32);
            btnCancelArchive.TabIndex = 0;
            btnCancelArchive.Text = "Cancel";
            btnCancelArchive.UseVisualStyleBackColor = true;
            btnCancelArchive.Click += btnCancelArchive_Click;
            // 
            // pnlArchiveHeader
            // 
            pnlArchiveHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlArchiveHeader.Controls.Add(lblArchiveTitle);
            pnlArchiveHeader.Dock = DockStyle.Top;
            pnlArchiveHeader.Location = new Point(0, 0);
            pnlArchiveHeader.Name = "pnlArchiveHeader";
            pnlArchiveHeader.Size = new Size(420, 50);
            pnlArchiveHeader.TabIndex = 2;
            // 
            // lblArchiveTitle
            // 
            lblArchiveTitle.Dock = DockStyle.Fill;
            lblArchiveTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveTitle.ForeColor = Color.White;
            lblArchiveTitle.Location = new Point(0, 0);
            lblArchiveTitle.Name = "lblArchiveTitle";
            lblArchiveTitle.Size = new Size(418, 48);
            lblArchiveTitle.TabIndex = 31;
            lblArchiveTitle.Text = "Confirmation of Archive";
            lblArchiveTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlArchiveContent
            // 
            pnlArchiveContent.Controls.Add(lblArchiveQuestion);
            pnlArchiveContent.Controls.Add(lblArchiveNotice);
            pnlArchiveContent.Dock = DockStyle.Fill;
            pnlArchiveContent.Location = new Point(0, 50);
            pnlArchiveContent.Name = "pnlArchiveContent";
            pnlArchiveContent.Padding = new Padding(15, 5, 15, 5);
            pnlArchiveContent.Size = new Size(420, 175);
            pnlArchiveContent.TabIndex = 3;
            // 
            // lblArchiveQuestion
            // 
            lblArchiveQuestion.Dock = DockStyle.Fill;
            lblArchiveQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblArchiveQuestion.ForeColor = Color.White;
            lblArchiveQuestion.Location = new Point(15, 5);
            lblArchiveQuestion.Name = "lblArchiveQuestion";
            lblArchiveQuestion.Size = new Size(390, 60);
            lblArchiveQuestion.TabIndex = 34;
            lblArchiveQuestion.Text = "Archive this room?";
            lblArchiveQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchiveNotice
            // 
            lblArchiveNotice.Dock = DockStyle.Bottom;
            lblArchiveNotice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveNotice.ForeColor = Color.Silver;
            lblArchiveNotice.Location = new Point(15, 65);
            lblArchiveNotice.Name = "lblArchiveNotice";
            lblArchiveNotice.Size = new Size(390, 105);
            lblArchiveNotice.TabIndex = 33;
            lblArchiveNotice.Text = "It will no longer appear in the Rooms and Bill Management screens. Its bills and payment history are kept, and it can be restored later from Settings > Archive.";
            lblArchiveNotice.TextAlign = ContentAlignment.TopCenter;
            // 
            // ArchiveRoomConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(420, 280);
            Controls.Add(pnlArchiveContent);
            Controls.Add(pnlArchiveHeader);
            Controls.Add(pnlArchiveActions);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ArchiveRoomConfirmationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Archive Room";
            Load += ArchiveRoomConfirmationForm_Load;
            pnlArchiveActions.ResumeLayout(false);
            pnlArchiveHeader.ResumeLayout(false);
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