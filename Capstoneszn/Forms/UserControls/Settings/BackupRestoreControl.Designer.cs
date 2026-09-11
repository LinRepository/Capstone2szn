namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class BackupRestoreControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlBackupRestoreHeader = new Panel();
            pnlBackupRestoreContent = new Panel();
            pnlBackupRestoreCenter = new Panel();
            pnlBackupRestoreActions = new Panel();
            btnRestoreData = new Button();
            btnBackupData = new Button();
            pnlBackupRestoreCenterHeader = new Panel();
            lblBackUpUpdate = new Label();
            btnBackBackupRestore = new Button();
            lblBackupRestoreTitle = new Label();
            pnlBackupRestoreHeader.SuspendLayout();
            pnlBackupRestoreContent.SuspendLayout();
            pnlBackupRestoreCenter.SuspendLayout();
            pnlBackupRestoreActions.SuspendLayout();
            pnlBackupRestoreCenterHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBackupRestoreHeader
            // 
            pnlBackupRestoreHeader.Controls.Add(lblBackupRestoreTitle);
            pnlBackupRestoreHeader.Controls.Add(btnBackBackupRestore);
            pnlBackupRestoreHeader.Dock = DockStyle.Top;
            pnlBackupRestoreHeader.Location = new Point(0, 0);
            pnlBackupRestoreHeader.Name = "pnlBackupRestoreHeader";
            pnlBackupRestoreHeader.Size = new Size(1300, 100);
            pnlBackupRestoreHeader.TabIndex = 0;
            // 
            // pnlBackupRestoreContent
            // 
            pnlBackupRestoreContent.Controls.Add(pnlBackupRestoreCenter);
            pnlBackupRestoreContent.Dock = DockStyle.Fill;
            pnlBackupRestoreContent.Location = new Point(0, 100);
            pnlBackupRestoreContent.Name = "pnlBackupRestoreContent";
            pnlBackupRestoreContent.Size = new Size(1300, 650);
            pnlBackupRestoreContent.TabIndex = 1;
            // 
            // pnlBackupRestoreCenter
            // 
            pnlBackupRestoreCenter.Anchor = AnchorStyles.None;
            pnlBackupRestoreCenter.BorderStyle = BorderStyle.FixedSingle;
            pnlBackupRestoreCenter.Controls.Add(pnlBackupRestoreActions);
            pnlBackupRestoreCenter.Controls.Add(pnlBackupRestoreCenterHeader);
            pnlBackupRestoreCenter.Location = new Point(349, 166);
            pnlBackupRestoreCenter.Name = "pnlBackupRestoreCenter";
            pnlBackupRestoreCenter.Size = new Size(600, 275);
            pnlBackupRestoreCenter.TabIndex = 16;
            // 
            // pnlBackupRestoreActions
            // 
            pnlBackupRestoreActions.Controls.Add(btnRestoreData);
            pnlBackupRestoreActions.Controls.Add(btnBackupData);
            pnlBackupRestoreActions.Dock = DockStyle.Fill;
            pnlBackupRestoreActions.Location = new Point(0, 82);
            pnlBackupRestoreActions.Name = "pnlBackupRestoreActions";
            pnlBackupRestoreActions.Size = new Size(598, 191);
            pnlBackupRestoreActions.TabIndex = 17;
            // 
            // btnRestoreData
            // 
            btnRestoreData.Anchor = AnchorStyles.None;
            btnRestoreData.Cursor = Cursors.Hand;
            btnRestoreData.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRestoreData.Location = new Point(152, 37);
            btnRestoreData.Name = "btnRestoreData";
            btnRestoreData.Size = new Size(300, 40);
            btnRestoreData.TabIndex = 14;
            btnRestoreData.Text = "Restore Data";
            btnRestoreData.UseVisualStyleBackColor = true;
            // 
            // btnBackupData
            // 
            btnBackupData.Anchor = AnchorStyles.None;
            btnBackupData.Cursor = Cursors.Hand;
            btnBackupData.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackupData.Location = new Point(152, 99);
            btnBackupData.Name = "btnBackupData";
            btnBackupData.Size = new Size(300, 40);
            btnBackupData.TabIndex = 15;
            btnBackupData.Text = "Backup Data";
            btnBackupData.UseVisualStyleBackColor = true;
            // 
            // pnlBackupRestoreCenterHeader
            // 
            pnlBackupRestoreCenterHeader.Controls.Add(lblBackUpUpdate);
            pnlBackupRestoreCenterHeader.Dock = DockStyle.Top;
            pnlBackupRestoreCenterHeader.Location = new Point(0, 0);
            pnlBackupRestoreCenterHeader.Name = "pnlBackupRestoreCenterHeader";
            pnlBackupRestoreCenterHeader.Size = new Size(598, 82);
            pnlBackupRestoreCenterHeader.TabIndex = 16;
            // 
            // lblBackUpUpdate
            // 
            lblBackUpUpdate.Dock = DockStyle.Fill;
            lblBackUpUpdate.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBackUpUpdate.ForeColor = Color.White;
            lblBackUpUpdate.ImageAlign = ContentAlignment.MiddleRight;
            lblBackUpUpdate.Location = new Point(0, 0);
            lblBackUpUpdate.Name = "lblBackUpUpdate";
            lblBackUpUpdate.Size = new Size(598, 82);
            lblBackUpUpdate.TabIndex = 13;
            lblBackUpUpdate.Text = "Last Status of Backup and Restore:";
            lblBackUpUpdate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackBackupRestore
            // 
            btnBackBackupRestore.Cursor = Cursors.Hand;
            btnBackBackupRestore.Dock = DockStyle.Left;
            btnBackBackupRestore.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackBackupRestore.Location = new Point(0, 0);
            btnBackBackupRestore.Margin = new Padding(0);
            btnBackBackupRestore.Name = "btnBackBackupRestore";
            btnBackBackupRestore.Size = new Size(140, 100);
            btnBackBackupRestore.TabIndex = 7;
            btnBackBackupRestore.Text = "←";
            btnBackBackupRestore.TextAlign = ContentAlignment.TopCenter;
            btnBackBackupRestore.UseVisualStyleBackColor = true;
            // 
            // lblBackupRestoreTitle
            // 
            lblBackupRestoreTitle.Dock = DockStyle.Fill;
            lblBackupRestoreTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBackupRestoreTitle.ForeColor = Color.White;
            lblBackupRestoreTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblBackupRestoreTitle.Location = new Point(140, 0);
            lblBackupRestoreTitle.Name = "lblBackupRestoreTitle";
            lblBackupRestoreTitle.Size = new Size(1160, 100);
            lblBackupRestoreTitle.TabIndex = 8;
            lblBackupRestoreTitle.Text = "Backup and Restore";
            lblBackupRestoreTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackupRestoreControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlBackupRestoreContent);
            Controls.Add(pnlBackupRestoreHeader);
            Name = "BackupRestoreControl";
            Size = new Size(1300, 750);
            pnlBackupRestoreHeader.ResumeLayout(false);
            pnlBackupRestoreContent.ResumeLayout(false);
            pnlBackupRestoreCenter.ResumeLayout(false);
            pnlBackupRestoreActions.ResumeLayout(false);
            pnlBackupRestoreCenterHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBackupRestoreHeader;
        private Panel pnlBackupRestoreContent;
        private Button btnBackupData;
        private Button btnRestoreData;
        private Label lblBackUpUpdate;
        private Panel pnlBackupRestoreCenter;
        private Panel pnlBackupRestoreActions;
        private Panel pnlBackupRestoreCenterHeader;
        private Label lblBackupRestoreTitle;
        private Button btnBackBackupRestore;
    }
}
