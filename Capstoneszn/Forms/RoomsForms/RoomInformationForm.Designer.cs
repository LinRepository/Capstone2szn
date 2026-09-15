namespace Capstoneszn.UserControls
{
    partial class RoomInformationForm
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
            pnlRoomHeader = new Panel();
            btnCloseRoomInfo = new Button();
            lblRoomTitle = new Label();
            btnMoveOut = new Button();
            btnMoveIn = new Button();
            pnlRoomStatus = new Panel();
            lblRoomStatus = new Label();
            lblCurrentStatus = new Label();
            pnlRoomDetails = new Panel();
            tblRoomDetails = new TableLayoutPanel();
            pnlRoomInformation = new Panel();
            btnSetCapacity = new Button();
            lblCapacityValue = new Label();
            lblCapacityTitle = new Label();
            lblDateOccupiedValue = new Label();
            lblDateOccupiedTitle = new Label();
            lblUnitNumberValue = new Label();
            lblUnitNumberTitle = new Label();
            pnlCurrentTenants = new Panel();
            dgvCurrentTenants = new DataGridView();
            pnlCurrentTenantsHeader = new Panel();
            lblCurrentTenantsTitle = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            pnlRoomHeader.SuspendLayout();
            pnlRoomStatus.SuspendLayout();
            pnlRoomDetails.SuspendLayout();
            tblRoomDetails.SuspendLayout();
            pnlRoomInformation.SuspendLayout();
            pnlCurrentTenants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentTenants).BeginInit();
            pnlCurrentTenantsHeader.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomHeader
            // 
            pnlRoomHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomHeader.Controls.Add(btnCloseRoomInfo);
            pnlRoomHeader.Controls.Add(lblRoomTitle);
            pnlRoomHeader.Dock = DockStyle.Top;
            pnlRoomHeader.Location = new Point(0, 0);
            pnlRoomHeader.Name = "pnlRoomHeader";
            pnlRoomHeader.Size = new Size(882, 50);
            pnlRoomHeader.TabIndex = 0;
            // 
            // btnCloseRoomInfo
            // 
            btnCloseRoomInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseRoomInfo.FlatStyle = FlatStyle.Flat;
            btnCloseRoomInfo.ForeColor = Color.White;
            btnCloseRoomInfo.Location = new Point(838, 9);
            btnCloseRoomInfo.Name = "btnCloseRoomInfo";
            btnCloseRoomInfo.Size = new Size(30, 30);
            btnCloseRoomInfo.TabIndex = 21;
            btnCloseRoomInfo.TabStop = false;
            btnCloseRoomInfo.Text = "X";
            btnCloseRoomInfo.UseVisualStyleBackColor = true;
            btnCloseRoomInfo.Click += btnCloseRoomInfo_Click;
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.AutoSize = true;
            lblRoomTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomTitle.ForeColor = Color.White;
            lblRoomTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomTitle.Location = new Point(9, 14);
            lblRoomTitle.Margin = new Padding(0);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new Size(159, 25);
            lblRoomTitle.TabIndex = 20;
            lblRoomTitle.Text = "Room Information";
            lblRoomTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMoveOut
            // 
            btnMoveOut.Location = new Point(776, 20);
            btnMoveOut.Name = "btnMoveOut";
            btnMoveOut.Size = new Size(94, 40);
            btnMoveOut.TabIndex = 1;
            btnMoveOut.Text = "Move Out";
            btnMoveOut.UseVisualStyleBackColor = true;
            btnMoveOut.Click += btnMoveOut_Click;
            // 
            // btnMoveIn
            // 
            btnMoveIn.Location = new Point(676, 20);
            btnMoveIn.Name = "btnMoveIn";
            btnMoveIn.Size = new Size(94, 40);
            btnMoveIn.TabIndex = 0;
            btnMoveIn.Text = "Move In";
            btnMoveIn.UseVisualStyleBackColor = true;
            btnMoveIn.Click += btnMoveIn_Click;
            // 
            // pnlRoomStatus
            // 
            pnlRoomStatus.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomStatus.Controls.Add(lblRoomStatus);
            pnlRoomStatus.Controls.Add(lblCurrentStatus);
            pnlRoomStatus.Controls.Add(btnMoveIn);
            pnlRoomStatus.Controls.Add(btnMoveOut);
            pnlRoomStatus.Dock = DockStyle.Top;
            pnlRoomStatus.Location = new Point(0, 50);
            pnlRoomStatus.Name = "pnlRoomStatus";
            pnlRoomStatus.Size = new Size(882, 80);
            pnlRoomStatus.TabIndex = 1;
            // 
            // lblRoomStatus
            // 
            lblRoomStatus.AutoSize = true;
            lblRoomStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomStatus.ForeColor = Color.White;
            lblRoomStatus.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomStatus.Location = new Point(132, 26);
            lblRoomStatus.Margin = new Padding(0);
            lblRoomStatus.Name = "lblRoomStatus";
            lblRoomStatus.Size = new Size(60, 25);
            lblRoomStatus.TabIndex = 22;
            lblRoomStatus.Text = "Status";
            lblRoomStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentStatus.ForeColor = Color.White;
            lblCurrentStatus.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentStatus.Location = new Point(9, 26);
            lblCurrentStatus.Margin = new Padding(0);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(123, 25);
            lblCurrentStatus.TabIndex = 21;
            lblCurrentStatus.Text = "Current Status";
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomDetails
            // 
            pnlRoomDetails.Controls.Add(tblRoomDetails);
            pnlRoomDetails.Dock = DockStyle.Fill;
            pnlRoomDetails.Location = new Point(0, 130);
            pnlRoomDetails.Name = "pnlRoomDetails";
            pnlRoomDetails.Size = new Size(882, 423);
            pnlRoomDetails.TabIndex = 2;
            // 
            // tblRoomDetails
            // 
            tblRoomDetails.ColumnCount = 2;
            tblRoomDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblRoomDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblRoomDetails.Controls.Add(pnlRoomInformation, 0, 0);
            tblRoomDetails.Controls.Add(pnlCurrentTenants, 1, 0);
            tblRoomDetails.Dock = DockStyle.Fill;
            tblRoomDetails.Location = new Point(0, 0);
            tblRoomDetails.Name = "tblRoomDetails";
            tblRoomDetails.RowCount = 1;
            tblRoomDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRoomDetails.Size = new Size(882, 423);
            tblRoomDetails.TabIndex = 0;
            // 
            // pnlRoomInformation
            // 
            pnlRoomInformation.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomInformation.Controls.Add(panel4);
            pnlRoomInformation.Controls.Add(panel3);
            pnlRoomInformation.Controls.Add(panel2);
            pnlRoomInformation.Controls.Add(panel1);
            pnlRoomInformation.Dock = DockStyle.Fill;
            pnlRoomInformation.Location = new Point(3, 3);
            pnlRoomInformation.Name = "pnlRoomInformation";
            pnlRoomInformation.Size = new Size(346, 417);
            pnlRoomInformation.TabIndex = 0;
            // 
            // btnSetCapacity
            // 
            btnSetCapacity.Location = new Point(128, 6);
            btnSetCapacity.Name = "btnSetCapacity";
            btnSetCapacity.Size = new Size(76, 40);
            btnSetCapacity.TabIndex = 29;
            btnSetCapacity.Text = "Set";
            btnSetCapacity.UseVisualStyleBackColor = true;
            // 
            // lblCapacityValue
            // 
            lblCapacityValue.Dock = DockStyle.Left;
            lblCapacityValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacityValue.ForeColor = Color.White;
            lblCapacityValue.ImageAlign = ContentAlignment.MiddleRight;
            lblCapacityValue.Location = new Point(164, 0);
            lblCapacityValue.Margin = new Padding(0);
            lblCapacityValue.Name = "lblCapacityValue";
            lblCapacityValue.Size = new Size(135, 53);
            lblCapacityValue.TabIndex = 28;
            lblCapacityValue.Text = "#";
            lblCapacityValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCapacityTitle
            // 
            lblCapacityTitle.Dock = DockStyle.Left;
            lblCapacityTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacityTitle.ForeColor = Color.White;
            lblCapacityTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblCapacityTitle.Location = new Point(0, 0);
            lblCapacityTitle.Margin = new Padding(0);
            lblCapacityTitle.Name = "lblCapacityTitle";
            lblCapacityTitle.Size = new Size(164, 53);
            lblCapacityTitle.TabIndex = 27;
            lblCapacityTitle.Text = "Capacity";
            lblCapacityTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateOccupiedValue
            // 
            lblDateOccupiedValue.Dock = DockStyle.Left;
            lblDateOccupiedValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateOccupiedValue.ForeColor = Color.White;
            lblDateOccupiedValue.ImageAlign = ContentAlignment.MiddleRight;
            lblDateOccupiedValue.Location = new Point(164, 0);
            lblDateOccupiedValue.Margin = new Padding(0);
            lblDateOccupiedValue.Name = "lblDateOccupiedValue";
            lblDateOccupiedValue.Size = new Size(135, 53);
            lblDateOccupiedValue.TabIndex = 26;
            lblDateOccupiedValue.Text = "MMDDYY";
            lblDateOccupiedValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateOccupiedTitle
            // 
            lblDateOccupiedTitle.Dock = DockStyle.Left;
            lblDateOccupiedTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateOccupiedTitle.ForeColor = Color.White;
            lblDateOccupiedTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblDateOccupiedTitle.Location = new Point(0, 0);
            lblDateOccupiedTitle.Margin = new Padding(0);
            lblDateOccupiedTitle.Name = "lblDateOccupiedTitle";
            lblDateOccupiedTitle.Size = new Size(164, 53);
            lblDateOccupiedTitle.TabIndex = 25;
            lblDateOccupiedTitle.Text = "Date Occupied";
            lblDateOccupiedTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUnitNumberValue
            // 
            lblUnitNumberValue.Dock = DockStyle.Left;
            lblUnitNumberValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitNumberValue.ForeColor = Color.White;
            lblUnitNumberValue.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitNumberValue.Location = new Point(164, 0);
            lblUnitNumberValue.Margin = new Padding(0);
            lblUnitNumberValue.Name = "lblUnitNumberValue";
            lblUnitNumberValue.Size = new Size(135, 53);
            lblUnitNumberValue.TabIndex = 24;
            lblUnitNumberValue.Text = "###";
            lblUnitNumberValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUnitNumberTitle
            // 
            lblUnitNumberTitle.Dock = DockStyle.Left;
            lblUnitNumberTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitNumberTitle.ForeColor = Color.White;
            lblUnitNumberTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitNumberTitle.Location = new Point(0, 0);
            lblUnitNumberTitle.Margin = new Padding(0);
            lblUnitNumberTitle.Name = "lblUnitNumberTitle";
            lblUnitNumberTitle.Size = new Size(164, 53);
            lblUnitNumberTitle.TabIndex = 23;
            lblUnitNumberTitle.Text = "Unit Number";
            lblUnitNumberTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCurrentTenants
            // 
            pnlCurrentTenants.Controls.Add(dgvCurrentTenants);
            pnlCurrentTenants.Controls.Add(pnlCurrentTenantsHeader);
            pnlCurrentTenants.Dock = DockStyle.Fill;
            pnlCurrentTenants.Location = new Point(355, 3);
            pnlCurrentTenants.Name = "pnlCurrentTenants";
            pnlCurrentTenants.Size = new Size(524, 417);
            pnlCurrentTenants.TabIndex = 1;
            // 
            // dgvCurrentTenants
            // 
            dgvCurrentTenants.AllowUserToAddRows = false;
            dgvCurrentTenants.AllowUserToDeleteRows = false;
            dgvCurrentTenants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentTenants.Dock = DockStyle.Fill;
            dgvCurrentTenants.Location = new Point(0, 45);
            dgvCurrentTenants.MultiSelect = false;
            dgvCurrentTenants.Name = "dgvCurrentTenants";
            dgvCurrentTenants.ReadOnly = true;
            dgvCurrentTenants.RowHeadersVisible = false;
            dgvCurrentTenants.RowHeadersWidth = 51;
            dgvCurrentTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCurrentTenants.Size = new Size(524, 372);
            dgvCurrentTenants.TabIndex = 30;
            // 
            // pnlCurrentTenantsHeader
            // 
            pnlCurrentTenantsHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlCurrentTenantsHeader.Controls.Add(lblCurrentTenantsTitle);
            pnlCurrentTenantsHeader.Dock = DockStyle.Top;
            pnlCurrentTenantsHeader.Location = new Point(0, 0);
            pnlCurrentTenantsHeader.Name = "pnlCurrentTenantsHeader";
            pnlCurrentTenantsHeader.Size = new Size(524, 45);
            pnlCurrentTenantsHeader.TabIndex = 29;
            // 
            // lblCurrentTenantsTitle
            // 
            lblCurrentTenantsTitle.Dock = DockStyle.Fill;
            lblCurrentTenantsTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentTenantsTitle.ForeColor = Color.White;
            lblCurrentTenantsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentTenantsTitle.Location = new Point(0, 0);
            lblCurrentTenantsTitle.Margin = new Padding(0);
            lblCurrentTenantsTitle.Name = "lblCurrentTenantsTitle";
            lblCurrentTenantsTitle.Size = new Size(522, 43);
            lblCurrentTenantsTitle.TabIndex = 28;
            lblCurrentTenantsTitle.Text = "Current Tenants";
            lblCurrentTenantsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblUnitNumberValue);
            panel1.Controls.Add(lblUnitNumberTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 55);
            panel1.TabIndex = 30;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblDateOccupiedValue);
            panel2.Controls.Add(lblDateOccupiedTitle);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(344, 55);
            panel2.TabIndex = 31;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblCapacityValue);
            panel3.Controls.Add(lblCapacityTitle);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 110);
            panel3.Name = "panel3";
            panel3.Size = new Size(344, 55);
            panel3.TabIndex = 32;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(btnSetCapacity);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 165);
            panel4.Name = "panel4";
            panel4.Size = new Size(344, 55);
            panel4.TabIndex = 33;
            // 
            // RoomInformationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(882, 553);
            Controls.Add(pnlRoomDetails);
            Controls.Add(pnlRoomStatus);
            Controls.Add(pnlRoomHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RoomInformationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Room Information";
            pnlRoomHeader.ResumeLayout(false);
            pnlRoomHeader.PerformLayout();
            pnlRoomStatus.ResumeLayout(false);
            pnlRoomStatus.PerformLayout();
            pnlRoomDetails.ResumeLayout(false);
            tblRoomDetails.ResumeLayout(false);
            pnlRoomInformation.ResumeLayout(false);
            pnlCurrentTenants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCurrentTenants).EndInit();
            pnlCurrentTenantsHeader.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoomHeader;
        private Button btnMoveOut;
        private Button btnMoveIn;
        private Panel pnlRoomStatus;
        private Label lblRoomTitle;
        private Button btnCloseRoomInfo;
        private Panel pnlRoomDetails;
        private Label lblRoomStatus;
        private Label lblCurrentStatus;
        private TableLayoutPanel tblRoomDetails;
        private Panel pnlRoomInformation;
        private Label lblCapacityValue;
        private Label lblCapacityTitle;
        private Label lblDateOccupiedValue;
        private Label lblDateOccupiedTitle;
        private Label lblUnitNumberValue;
        private Label lblUnitNumberTitle;
        private Panel pnlCurrentTenants;
        private Button btnSetCapacity;
        private Label lblCurrentTenantsTitle;
        private Panel pnlCurrentTenantsHeader;
        private DataGridView dgvCurrentTenants;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
    }
}