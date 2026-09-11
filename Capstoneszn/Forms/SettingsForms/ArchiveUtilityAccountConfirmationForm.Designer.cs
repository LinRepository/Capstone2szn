namespace Capstoneszn.Forms.SettingsForms
{
    partial class ArchiveUtilityAccountConfirmationForm
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
            pnlArchiveUtilityAccountHeader = new Panel();
            pnlArchiveUtilityAccountActions = new Panel();
            pnlArchiveUtilityAccountContent = new Panel();
            btnCancelArchiveUtilityAccount = new Button();
            btnConfirmArchiveUtilityAccount = new Button();
            lblArchiveUtilityAccountTitle = new Label();
            lblArchiveUtilityAccountQuestion = new Label();
            lblArchiveUtilityAccountNotice = new Label();
            pnlArchiveUtilityAccountHeader.SuspendLayout();
            pnlArchiveUtilityAccountActions.SuspendLayout();
            pnlArchiveUtilityAccountContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlArchiveUtilityAccountHeader
            // 
            pnlArchiveUtilityAccountHeader.Controls.Add(lblArchiveUtilityAccountTitle);
            pnlArchiveUtilityAccountHeader.Dock = DockStyle.Top;
            pnlArchiveUtilityAccountHeader.Location = new Point(0, 0);
            pnlArchiveUtilityAccountHeader.Name = "pnlArchiveUtilityAccountHeader";
            pnlArchiveUtilityAccountHeader.Size = new Size(482, 55);
            pnlArchiveUtilityAccountHeader.TabIndex = 0;
            // 
            // pnlArchiveUtilityAccountActions
            // 
            pnlArchiveUtilityAccountActions.Controls.Add(btnConfirmArchiveUtilityAccount);
            pnlArchiveUtilityAccountActions.Controls.Add(btnCancelArchiveUtilityAccount);
            pnlArchiveUtilityAccountActions.Dock = DockStyle.Bottom;
            pnlArchiveUtilityAccountActions.Location = new Point(0, 198);
            pnlArchiveUtilityAccountActions.Name = "pnlArchiveUtilityAccountActions";
            pnlArchiveUtilityAccountActions.Size = new Size(482, 55);
            pnlArchiveUtilityAccountActions.TabIndex = 1;
            // 
            // pnlArchiveUtilityAccountContent
            // 
            pnlArchiveUtilityAccountContent.Controls.Add(lblArchiveUtilityAccountNotice);
            pnlArchiveUtilityAccountContent.Controls.Add(lblArchiveUtilityAccountQuestion);
            pnlArchiveUtilityAccountContent.Dock = DockStyle.Fill;
            pnlArchiveUtilityAccountContent.Location = new Point(0, 55);
            pnlArchiveUtilityAccountContent.Name = "pnlArchiveUtilityAccountContent";
            pnlArchiveUtilityAccountContent.Size = new Size(482, 143);
            pnlArchiveUtilityAccountContent.TabIndex = 2;
            // 
            // btnCancelArchiveUtilityAccount
            // 
            btnCancelArchiveUtilityAccount.Cursor = Cursors.Hand;
            btnCancelArchiveUtilityAccount.Location = new Point(255, 14);
            btnCancelArchiveUtilityAccount.Name = "btnCancelArchiveUtilityAccount";
            btnCancelArchiveUtilityAccount.Size = new Size(94, 29);
            btnCancelArchiveUtilityAccount.TabIndex = 0;
            btnCancelArchiveUtilityAccount.Text = "Cancel";
            btnCancelArchiveUtilityAccount.UseVisualStyleBackColor = true;
            // 
            // btnConfirmArchiveUtilityAccount
            // 
            btnConfirmArchiveUtilityAccount.Cursor = Cursors.Hand;
            btnConfirmArchiveUtilityAccount.Location = new Point(367, 14);
            btnConfirmArchiveUtilityAccount.Name = "btnConfirmArchiveUtilityAccount";
            btnConfirmArchiveUtilityAccount.Size = new Size(94, 29);
            btnConfirmArchiveUtilityAccount.TabIndex = 1;
            btnConfirmArchiveUtilityAccount.Text = "Archive";
            btnConfirmArchiveUtilityAccount.UseVisualStyleBackColor = true;
            // 
            // lblArchiveUtilityAccountTitle
            // 
            lblArchiveUtilityAccountTitle.Dock = DockStyle.Fill;
            lblArchiveUtilityAccountTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveUtilityAccountTitle.ForeColor = Color.White;
            lblArchiveUtilityAccountTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblArchiveUtilityAccountTitle.Location = new Point(0, 0);
            lblArchiveUtilityAccountTitle.Name = "lblArchiveUtilityAccountTitle";
            lblArchiveUtilityAccountTitle.Size = new Size(482, 55);
            lblArchiveUtilityAccountTitle.TabIndex = 10;
            lblArchiveUtilityAccountTitle.Text = "Archive Utility Account";
            lblArchiveUtilityAccountTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchiveUtilityAccountQuestion
            // 
            lblArchiveUtilityAccountQuestion.Dock = DockStyle.Top;
            lblArchiveUtilityAccountQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveUtilityAccountQuestion.ForeColor = Color.White;
            lblArchiveUtilityAccountQuestion.ImageAlign = ContentAlignment.MiddleRight;
            lblArchiveUtilityAccountQuestion.Location = new Point(0, 0);
            lblArchiveUtilityAccountQuestion.Name = "lblArchiveUtilityAccountQuestion";
            lblArchiveUtilityAccountQuestion.Size = new Size(482, 70);
            lblArchiveUtilityAccountQuestion.TabIndex = 11;
            lblArchiveUtilityAccountQuestion.Text = "Are you sure you want to archive the\r\nWater Bill Account for Room 101?";
            lblArchiveUtilityAccountQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchiveUtilityAccountNotice
            // 
            lblArchiveUtilityAccountNotice.Dock = DockStyle.Fill;
            lblArchiveUtilityAccountNotice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveUtilityAccountNotice.ForeColor = Color.White;
            lblArchiveUtilityAccountNotice.ImageAlign = ContentAlignment.MiddleRight;
            lblArchiveUtilityAccountNotice.Location = new Point(0, 70);
            lblArchiveUtilityAccountNotice.Name = "lblArchiveUtilityAccountNotice";
            lblArchiveUtilityAccountNotice.Size = new Size(482, 73);
            lblArchiveUtilityAccountNotice.TabIndex = 12;
            lblArchiveUtilityAccountNotice.Text = "This account will no longer appear in the active utility account list.";
            lblArchiveUtilityAccountNotice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ArchiveUtilityAccountConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 20, 38);
            ClientSize = new Size(482, 253);
            Controls.Add(pnlArchiveUtilityAccountContent);
            Controls.Add(pnlArchiveUtilityAccountActions);
            Controls.Add(pnlArchiveUtilityAccountHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ArchiveUtilityAccountConfirmationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Archive Utility Account";
            pnlArchiveUtilityAccountHeader.ResumeLayout(false);
            pnlArchiveUtilityAccountActions.ResumeLayout(false);
            pnlArchiveUtilityAccountContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlArchiveUtilityAccountHeader;
        private Panel pnlArchiveUtilityAccountActions;
        private Panel pnlArchiveUtilityAccountContent;
        private Button btnConfirmArchiveUtilityAccount;
        private Button btnCancelArchiveUtilityAccount;
        private Label lblArchiveUtilityAccountTitle;
        private Label lblArchiveUtilityAccountNotice;
        private Label lblArchiveUtilityAccountQuestion;
    }
}