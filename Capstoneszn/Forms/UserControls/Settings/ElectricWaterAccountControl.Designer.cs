namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class ElectricWaterAccountControl
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
            pnlElectricWaterAccountHeader = new Panel();
            lblUtilitiesAccountTitle = new Label();
            btnBackElectricWater = new Button();
            pnlElectricWaterAccountContent = new Panel();
            tblUtilityAccounts = new TableLayoutPanel();
            pnlWaterAccounts = new Panel();
            flpWaterAccounts = new FlowLayoutPanel();
            pnlWaterHeader = new Panel();
            lblWaterTitle = new Label();
            btnAddWaterAccount = new Button();
            pnlElectricityAccounts = new Panel();
            flpElectricityAccounts = new FlowLayoutPanel();
            pnlElectricityHeader = new Panel();
            lblElectricityTitle = new Label();
            btnAddElectricityAccount = new Button();
            pnlElectricWaterAccountHeader.SuspendLayout();
            pnlElectricWaterAccountContent.SuspendLayout();
            tblUtilityAccounts.SuspendLayout();
            pnlWaterAccounts.SuspendLayout();
            pnlWaterHeader.SuspendLayout();
            pnlElectricityAccounts.SuspendLayout();
            pnlElectricityHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlElectricWaterAccountHeader
            // 
            pnlElectricWaterAccountHeader.Controls.Add(lblUtilitiesAccountTitle);
            pnlElectricWaterAccountHeader.Controls.Add(btnBackElectricWater);
            pnlElectricWaterAccountHeader.Dock = DockStyle.Top;
            pnlElectricWaterAccountHeader.Location = new Point(0, 0);
            pnlElectricWaterAccountHeader.Name = "pnlElectricWaterAccountHeader";
            pnlElectricWaterAccountHeader.Size = new Size(1300, 100);
            pnlElectricWaterAccountHeader.TabIndex = 0;
            // 
            // lblUtilitiesAccountTitle
            // 
            lblUtilitiesAccountTitle.BorderStyle = BorderStyle.FixedSingle;
            lblUtilitiesAccountTitle.Dock = DockStyle.Fill;
            lblUtilitiesAccountTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilitiesAccountTitle.ForeColor = Color.White;
            lblUtilitiesAccountTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblUtilitiesAccountTitle.Location = new Point(140, 0);
            lblUtilitiesAccountTitle.Name = "lblUtilitiesAccountTitle";
            lblUtilitiesAccountTitle.Padding = new Padding(0, 0, 150, 0);
            lblUtilitiesAccountTitle.Size = new Size(1160, 100);
            lblUtilitiesAccountTitle.TabIndex = 11;
            lblUtilitiesAccountTitle.Text = "Utilities Account";
            lblUtilitiesAccountTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackElectricWater
            // 
            btnBackElectricWater.Cursor = Cursors.Hand;
            btnBackElectricWater.Dock = DockStyle.Left;
            btnBackElectricWater.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackElectricWater.Location = new Point(0, 0);
            btnBackElectricWater.Margin = new Padding(0);
            btnBackElectricWater.Name = "btnBackElectricWater";
            btnBackElectricWater.Size = new Size(140, 100);
            btnBackElectricWater.TabIndex = 10;
            btnBackElectricWater.Text = "←";
            btnBackElectricWater.TextAlign = ContentAlignment.TopCenter;
            btnBackElectricWater.UseVisualStyleBackColor = true;
            btnBackElectricWater.Click += btnBackElectricWater_Click;
            // 
            // pnlElectricWaterAccountContent
            // 
            pnlElectricWaterAccountContent.Controls.Add(tblUtilityAccounts);
            pnlElectricWaterAccountContent.Dock = DockStyle.Fill;
            pnlElectricWaterAccountContent.Location = new Point(0, 100);
            pnlElectricWaterAccountContent.Name = "pnlElectricWaterAccountContent";
            pnlElectricWaterAccountContent.Size = new Size(1300, 650);
            pnlElectricWaterAccountContent.TabIndex = 1;
            // 
            // tblUtilityAccounts
            // 
            tblUtilityAccounts.ColumnCount = 2;
            tblUtilityAccounts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblUtilityAccounts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblUtilityAccounts.Controls.Add(pnlWaterAccounts, 1, 0);
            tblUtilityAccounts.Controls.Add(pnlElectricityAccounts, 0, 0);
            tblUtilityAccounts.Dock = DockStyle.Fill;
            tblUtilityAccounts.Location = new Point(0, 0);
            tblUtilityAccounts.Name = "tblUtilityAccounts";
            tblUtilityAccounts.RowCount = 1;
            tblUtilityAccounts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblUtilityAccounts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblUtilityAccounts.Size = new Size(1300, 650);
            tblUtilityAccounts.TabIndex = 0;
            // 
            // pnlWaterAccounts
            // 
            pnlWaterAccounts.Controls.Add(flpWaterAccounts);
            pnlWaterAccounts.Controls.Add(pnlWaterHeader);
            pnlWaterAccounts.Dock = DockStyle.Left;
            pnlWaterAccounts.Location = new Point(653, 3);
            pnlWaterAccounts.Name = "pnlWaterAccounts";
            pnlWaterAccounts.Padding = new Padding(10);
            pnlWaterAccounts.Size = new Size(644, 644);
            pnlWaterAccounts.TabIndex = 5;
            // 
            // flpWaterAccounts
            // 
            flpWaterAccounts.AutoScroll = true;
            flpWaterAccounts.BorderStyle = BorderStyle.FixedSingle;
            flpWaterAccounts.Dock = DockStyle.Fill;
            flpWaterAccounts.FlowDirection = FlowDirection.TopDown;
            flpWaterAccounts.Location = new Point(10, 100);
            flpWaterAccounts.Name = "flpWaterAccounts";
            flpWaterAccounts.Padding = new Padding(5);
            flpWaterAccounts.Size = new Size(624, 534);
            flpWaterAccounts.TabIndex = 1;
            flpWaterAccounts.WrapContents = false;
            // 
            // pnlWaterHeader
            // 
            pnlWaterHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlWaterHeader.Controls.Add(lblWaterTitle);
            pnlWaterHeader.Controls.Add(btnAddWaterAccount);
            pnlWaterHeader.Dock = DockStyle.Top;
            pnlWaterHeader.Location = new Point(10, 10);
            pnlWaterHeader.Name = "pnlWaterHeader";
            pnlWaterHeader.Size = new Size(624, 90);
            pnlWaterHeader.TabIndex = 0;
            // 
            // lblWaterTitle
            // 
            lblWaterTitle.Dock = DockStyle.Left;
            lblWaterTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWaterTitle.ForeColor = Color.White;
            lblWaterTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblWaterTitle.Location = new Point(0, 0);
            lblWaterTitle.Name = "lblWaterTitle";
            lblWaterTitle.Size = new Size(415, 88);
            lblWaterTitle.TabIndex = 12;
            lblWaterTitle.Text = "Water Bill Account";
            lblWaterTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddWaterAccount
            // 
            btnAddWaterAccount.Location = new Point(435, 28);
            btnAddWaterAccount.Name = "btnAddWaterAccount";
            btnAddWaterAccount.Size = new Size(180, 29);
            btnAddWaterAccount.TabIndex = 0;
            btnAddWaterAccount.Text = "Add Water Account";
            btnAddWaterAccount.UseVisualStyleBackColor = true;
            // 
            // pnlElectricityAccounts
            // 
            pnlElectricityAccounts.Controls.Add(flpElectricityAccounts);
            pnlElectricityAccounts.Controls.Add(pnlElectricityHeader);
            pnlElectricityAccounts.Dock = DockStyle.Right;
            pnlElectricityAccounts.Location = new Point(3, 3);
            pnlElectricityAccounts.Name = "pnlElectricityAccounts";
            pnlElectricityAccounts.Padding = new Padding(10);
            pnlElectricityAccounts.Size = new Size(644, 644);
            pnlElectricityAccounts.TabIndex = 4;
            // 
            // flpElectricityAccounts
            // 
            flpElectricityAccounts.AutoScroll = true;
            flpElectricityAccounts.BorderStyle = BorderStyle.FixedSingle;
            flpElectricityAccounts.Dock = DockStyle.Fill;
            flpElectricityAccounts.FlowDirection = FlowDirection.TopDown;
            flpElectricityAccounts.Location = new Point(10, 100);
            flpElectricityAccounts.Name = "flpElectricityAccounts";
            flpElectricityAccounts.Padding = new Padding(5);
            flpElectricityAccounts.Size = new Size(624, 534);
            flpElectricityAccounts.TabIndex = 1;
            flpElectricityAccounts.WrapContents = false;
            // 
            // pnlElectricityHeader
            // 
            pnlElectricityHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlElectricityHeader.Controls.Add(lblElectricityTitle);
            pnlElectricityHeader.Controls.Add(btnAddElectricityAccount);
            pnlElectricityHeader.Dock = DockStyle.Top;
            pnlElectricityHeader.Location = new Point(10, 10);
            pnlElectricityHeader.Name = "pnlElectricityHeader";
            pnlElectricityHeader.Size = new Size(624, 90);
            pnlElectricityHeader.TabIndex = 0;
            // 
            // lblElectricityTitle
            // 
            lblElectricityTitle.Dock = DockStyle.Left;
            lblElectricityTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectricityTitle.ForeColor = Color.White;
            lblElectricityTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblElectricityTitle.Location = new Point(0, 0);
            lblElectricityTitle.Name = "lblElectricityTitle";
            lblElectricityTitle.Size = new Size(415, 88);
            lblElectricityTitle.TabIndex = 13;
            lblElectricityTitle.Text = "Electricity Bill Account";
            lblElectricityTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddElectricityAccount
            // 
            btnAddElectricityAccount.Location = new Point(410, 28);
            btnAddElectricityAccount.Name = "btnAddElectricityAccount";
            btnAddElectricityAccount.Size = new Size(200, 29);
            btnAddElectricityAccount.TabIndex = 0;
            btnAddElectricityAccount.Text = "Add Electricity Account";
            btnAddElectricityAccount.UseVisualStyleBackColor = true;
            // 
            // ElectricWaterAccountControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlElectricWaterAccountContent);
            Controls.Add(pnlElectricWaterAccountHeader);
            Name = "ElectricWaterAccountControl";
            Size = new Size(1300, 750);
            pnlElectricWaterAccountHeader.ResumeLayout(false);
            pnlElectricWaterAccountContent.ResumeLayout(false);
            tblUtilityAccounts.ResumeLayout(false);
            pnlWaterAccounts.ResumeLayout(false);
            pnlWaterHeader.ResumeLayout(false);
            pnlElectricityAccounts.ResumeLayout(false);
            pnlElectricityHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlElectricWaterAccountHeader;
        private Panel pnlElectricWaterAccountContent;
        private Label lblUtilitiesAccountTitle;
        private Button btnBackElectricWater;
        private TableLayoutPanel tblUtilityAccounts;
        private Panel pnlWaterAccounts;
        private FlowLayoutPanel flpWaterAccounts;
        private Panel pnlWaterHeader;
        private Label lblWaterTitle;
        private Button btnAddWaterAccount;
        private Panel pnlElectricityAccounts;
        private FlowLayoutPanel flpElectricityAccounts;
        private Panel pnlElectricityHeader;
        private Label lblElectricityTitle;
        private Button btnAddElectricityAccount;
    }
}
