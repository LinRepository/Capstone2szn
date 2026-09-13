namespace Capstoneszn.UserControls
{
    partial class SettingsControl
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
            pnlSettingsContent = new Panel();
            tblSettingsOptions = new TableLayoutPanel();
            pnlProfileManagement = new Panel();
            lblProfileManagement = new Label();
            pnlBackupRestore = new Panel();
            lblBackupRestore = new Label();
            pnlElectricWaterAccount = new Panel();
            lblUtilitiesAccount = new Label();
            pnlArchive = new Panel();
            lblArchive = new Label();
            pnlSalary = new Panel();
            lblSalary = new Label();
            pnlSettingsHeader = new Panel();
            lblSettingsTitle = new Label();
            pnlSettingsContent.SuspendLayout();
            tblSettingsOptions.SuspendLayout();
            pnlProfileManagement.SuspendLayout();
            pnlBackupRestore.SuspendLayout();
            pnlElectricWaterAccount.SuspendLayout();
            pnlArchive.SuspendLayout();
            pnlSalary.SuspendLayout();
            pnlSettingsHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSettingsContent
            // 
            pnlSettingsContent.Controls.Add(tblSettingsOptions);
            pnlSettingsContent.Dock = DockStyle.Fill;
            pnlSettingsContent.Location = new Point(10, 95);
            pnlSettingsContent.Name = "pnlSettingsContent";
            pnlSettingsContent.Padding = new Padding(10);
            pnlSettingsContent.Size = new Size(1280, 645);
            pnlSettingsContent.TabIndex = 1;
            // 
            // tblSettingsOptions
            // 
            tblSettingsOptions.AutoScroll = true;
            tblSettingsOptions.ColumnCount = 1;
            tblSettingsOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSettingsOptions.Controls.Add(pnlProfileManagement, 0, 0);
            tblSettingsOptions.Controls.Add(pnlBackupRestore, 0, 1);
            tblSettingsOptions.Controls.Add(pnlElectricWaterAccount, 0, 2);
            tblSettingsOptions.Controls.Add(pnlArchive, 0, 3);
            tblSettingsOptions.Controls.Add(pnlSalary, 0, 4);
            tblSettingsOptions.Dock = DockStyle.Fill;
            tblSettingsOptions.Location = new Point(10, 10);
            tblSettingsOptions.Name = "tblSettingsOptions";
            tblSettingsOptions.RowCount = 5;
            tblSettingsOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblSettingsOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblSettingsOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblSettingsOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblSettingsOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblSettingsOptions.Size = new Size(1260, 625);
            tblSettingsOptions.TabIndex = 0;
            // 
            // pnlProfileManagement
            // 
            pnlProfileManagement.Controls.Add(lblProfileManagement);
            pnlProfileManagement.Cursor = Cursors.Hand;
            pnlProfileManagement.Dock = DockStyle.Fill;
            pnlProfileManagement.Location = new Point(10, 10);
            pnlProfileManagement.Margin = new Padding(10);
            pnlProfileManagement.Name = "pnlProfileManagement";
            pnlProfileManagement.Size = new Size(1240, 105);
            pnlProfileManagement.TabIndex = 0;
            // 
            // lblProfileManagement
            // 
            lblProfileManagement.BorderStyle = BorderStyle.FixedSingle;
            lblProfileManagement.Dock = DockStyle.Fill;
            lblProfileManagement.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileManagement.ForeColor = Color.White;
            lblProfileManagement.ImageAlign = ContentAlignment.MiddleRight;
            lblProfileManagement.Location = new Point(0, 0);
            lblProfileManagement.Name = "lblProfileManagement";
            lblProfileManagement.Size = new Size(1240, 105);
            lblProfileManagement.TabIndex = 6;
            lblProfileManagement.Text = "Profile Management";
            lblProfileManagement.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBackupRestore
            // 
            pnlBackupRestore.Controls.Add(lblBackupRestore);
            pnlBackupRestore.Cursor = Cursors.Hand;
            pnlBackupRestore.Dock = DockStyle.Fill;
            pnlBackupRestore.Location = new Point(10, 135);
            pnlBackupRestore.Margin = new Padding(10);
            pnlBackupRestore.Name = "pnlBackupRestore";
            pnlBackupRestore.Size = new Size(1240, 105);
            pnlBackupRestore.TabIndex = 1;
            // 
            // lblBackupRestore
            // 
            lblBackupRestore.BorderStyle = BorderStyle.FixedSingle;
            lblBackupRestore.Dock = DockStyle.Fill;
            lblBackupRestore.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBackupRestore.ForeColor = Color.White;
            lblBackupRestore.ImageAlign = ContentAlignment.MiddleRight;
            lblBackupRestore.Location = new Point(0, 0);
            lblBackupRestore.Name = "lblBackupRestore";
            lblBackupRestore.Size = new Size(1240, 105);
            lblBackupRestore.TabIndex = 6;
            lblBackupRestore.Text = "Backup and Restore";
            lblBackupRestore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlElectricWaterAccount
            // 
            pnlElectricWaterAccount.Controls.Add(lblUtilitiesAccount);
            pnlElectricWaterAccount.Cursor = Cursors.Hand;
            pnlElectricWaterAccount.Dock = DockStyle.Fill;
            pnlElectricWaterAccount.Location = new Point(10, 260);
            pnlElectricWaterAccount.Margin = new Padding(10);
            pnlElectricWaterAccount.Name = "pnlElectricWaterAccount";
            pnlElectricWaterAccount.Size = new Size(1240, 105);
            pnlElectricWaterAccount.TabIndex = 2;
            // 
            // lblUtilitiesAccount
            // 
            lblUtilitiesAccount.BorderStyle = BorderStyle.FixedSingle;
            lblUtilitiesAccount.Dock = DockStyle.Fill;
            lblUtilitiesAccount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilitiesAccount.ForeColor = Color.White;
            lblUtilitiesAccount.ImageAlign = ContentAlignment.MiddleRight;
            lblUtilitiesAccount.Location = new Point(0, 0);
            lblUtilitiesAccount.Name = "lblUtilitiesAccount";
            lblUtilitiesAccount.Size = new Size(1240, 105);
            lblUtilitiesAccount.TabIndex = 6;
            lblUtilitiesAccount.Text = "Utilities Account";
            lblUtilitiesAccount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlArchive
            // 
            pnlArchive.Controls.Add(lblArchive);
            pnlArchive.Cursor = Cursors.Hand;
            pnlArchive.Dock = DockStyle.Fill;
            pnlArchive.Location = new Point(10, 385);
            pnlArchive.Margin = new Padding(10);
            pnlArchive.Name = "pnlArchive";
            pnlArchive.Size = new Size(1240, 105);
            pnlArchive.TabIndex = 3;
            // 
            // lblArchive
            // 
            lblArchive.BorderStyle = BorderStyle.FixedSingle;
            lblArchive.Dock = DockStyle.Fill;
            lblArchive.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchive.ForeColor = Color.White;
            lblArchive.ImageAlign = ContentAlignment.MiddleRight;
            lblArchive.Location = new Point(0, 0);
            lblArchive.Name = "lblArchive";
            lblArchive.Size = new Size(1240, 105);
            lblArchive.TabIndex = 6;
            lblArchive.Text = "Archive";
            lblArchive.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSalary
            // 
            pnlSalary.Controls.Add(lblSalary);
            pnlSalary.Cursor = Cursors.Hand;
            pnlSalary.Dock = DockStyle.Fill;
            pnlSalary.Location = new Point(10, 510);
            pnlSalary.Margin = new Padding(10);
            pnlSalary.Name = "pnlSalary";
            pnlSalary.Size = new Size(1240, 105);
            pnlSalary.TabIndex = 4;
            // 
            // lblSalary
            // 
            lblSalary.BorderStyle = BorderStyle.FixedSingle;
            lblSalary.Dock = DockStyle.Fill;
            lblSalary.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSalary.ForeColor = Color.White;
            lblSalary.ImageAlign = ContentAlignment.MiddleRight;
            lblSalary.Location = new Point(0, 0);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(1240, 105);
            lblSalary.TabIndex = 6;
            lblSalary.Text = "Salary";
            lblSalary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSettingsHeader
            // 
            pnlSettingsHeader.Controls.Add(lblSettingsTitle);
            pnlSettingsHeader.Dock = DockStyle.Top;
            pnlSettingsHeader.Location = new Point(10, 10);
            pnlSettingsHeader.Name = "pnlSettingsHeader";
            pnlSettingsHeader.Size = new Size(1280, 85);
            pnlSettingsHeader.TabIndex = 0;
            // 
            // lblSettingsTitle
            // 
            lblSettingsTitle.BorderStyle = BorderStyle.FixedSingle;
            lblSettingsTitle.Dock = DockStyle.Fill;
            lblSettingsTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSettingsTitle.ForeColor = Color.White;
            lblSettingsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblSettingsTitle.Location = new Point(0, 0);
            lblSettingsTitle.Name = "lblSettingsTitle";
            lblSettingsTitle.Size = new Size(1280, 85);
            lblSettingsTitle.TabIndex = 5;
            lblSettingsTitle.Text = "Settings";
            lblSettingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SettingsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlSettingsContent);
            Controls.Add(pnlSettingsHeader);
            Name = "SettingsControl";
            Padding = new Padding(10);
            Size = new Size(1300, 750);
            pnlSettingsContent.ResumeLayout(false);
            tblSettingsOptions.ResumeLayout(false);
            pnlProfileManagement.ResumeLayout(false);
            pnlBackupRestore.ResumeLayout(false);
            pnlElectricWaterAccount.ResumeLayout(false);
            pnlArchive.ResumeLayout(false);
            pnlSalary.ResumeLayout(false);
            pnlSettingsHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlSettingsContent;
        private TableLayoutPanel tblSettingsOptions;
        private Panel pnlProfileManagement;
        private Panel pnlBackupRestore;
        private Panel pnlElectricWaterAccount;
        private Panel pnlArchive;
        private Panel pnlSalary;
        private Label lblProfileManagement;
        private Label lblBackupRestore;
        private Label lblUtilitiesAccount;
        private Label lblArchive;
        private Label lblSalary;
        private Panel pnlSettingsHeader;
        private Label lblSettingsTitle;
    }
}
