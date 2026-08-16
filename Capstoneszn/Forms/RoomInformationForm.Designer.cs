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
            pnlRoomHeader.SuspendLayout();
            pnlRoomStatus.SuspendLayout();
            pnlRoomDetails.SuspendLayout();
            tblRoomDetails.SuspendLayout();
            pnlRoomInformation.SuspendLayout();
            pnlCurrentTenants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentTenants).BeginInit();
            pnlCurrentTenantsHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomHeader
            // 
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
            btnCloseRoomInfo.Location = new Point(840, 9);
            btnCloseRoomInfo.Name = "btnCloseRoomInfo";
            btnCloseRoomInfo.Size = new Size(30, 30);
            btnCloseRoomInfo.TabIndex = 21;
            btnCloseRoomInfo.TabStop = false;
            btnCloseRoomInfo.Text = "X";
            btnCloseRoomInfo.UseVisualStyleBackColor = true;
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
            // 
            // btnMoveIn
            // 
            btnMoveIn.Location = new Point(676, 20);
            btnMoveIn.Name = "btnMoveIn";
            btnMoveIn.Size = new Size(94, 40);
            btnMoveIn.TabIndex = 0;
            btnMoveIn.Text = "Move In";
            btnMoveIn.UseVisualStyleBackColor = true;
            // 
            // pnlRoomStatus
            // 
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
            tblRoomDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblRoomDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblRoomDetails.Controls.Add(pnlRoomInformation, 0, 0);
            tblRoomDetails.Controls.Add(pnlCurrentTenants, 1, 0);
            tblRoomDetails.Dock = DockStyle.Fill;
            tblRoomDetails.Location = new Point(0, 0);
            tblRoomDetails.Name = "tblRoomDetails";
            tblRoomDetails.RowCount = 1;
            tblRoomDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRoomDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblRoomDetails.Size = new Size(882, 423);
            tblRoomDetails.TabIndex = 0;
            // 
            // pnlRoomInformation
            // 
            pnlRoomInformation.Controls.Add(btnSetCapacity);
            pnlRoomInformation.Controls.Add(lblCapacityValue);
            pnlRoomInformation.Controls.Add(lblCapacityTitle);
            pnlRoomInformation.Controls.Add(lblDateOccupiedValue);
            pnlRoomInformation.Controls.Add(lblDateOccupiedTitle);
            pnlRoomInformation.Controls.Add(lblUnitNumberValue);
            pnlRoomInformation.Controls.Add(lblUnitNumberTitle);
            pnlRoomInformation.Dock = DockStyle.Fill;
            pnlRoomInformation.Location = new Point(3, 3);
            pnlRoomInformation.Name = "pnlRoomInformation";
            pnlRoomInformation.Size = new Size(435, 417);
            pnlRoomInformation.TabIndex = 0;
            // 
            // btnSetCapacity
            // 
            btnSetCapacity.Location = new Point(9, 124);
            btnSetCapacity.Name = "btnSetCapacity";
            btnSetCapacity.Size = new Size(76, 40);
            btnSetCapacity.TabIndex = 29;
            btnSetCapacity.Text = "Set";
            btnSetCapacity.UseVisualStyleBackColor = true;
            // 
            // lblCapacityValue
            // 
            lblCapacityValue.AutoSize = true;
            lblCapacityValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacityValue.ForeColor = Color.White;
            lblCapacityValue.ImageAlign = ContentAlignment.MiddleRight;
            lblCapacityValue.Location = new Point(144, 96);
            lblCapacityValue.Margin = new Padding(0);
            lblCapacityValue.Name = "lblCapacityValue";
            lblCapacityValue.Size = new Size(23, 25);
            lblCapacityValue.TabIndex = 28;
            lblCapacityValue.Text = "#";
            lblCapacityValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCapacityTitle
            // 
            lblCapacityTitle.AutoSize = true;
            lblCapacityTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacityTitle.ForeColor = Color.White;
            lblCapacityTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblCapacityTitle.Location = new Point(6, 96);
            lblCapacityTitle.Margin = new Padding(0);
            lblCapacityTitle.Name = "lblCapacityTitle";
            lblCapacityTitle.Size = new Size(79, 25);
            lblCapacityTitle.TabIndex = 27;
            lblCapacityTitle.Text = "Capacity";
            lblCapacityTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateOccupiedValue
            // 
            lblDateOccupiedValue.AutoSize = true;
            lblDateOccupiedValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateOccupiedValue.ForeColor = Color.White;
            lblDateOccupiedValue.ImageAlign = ContentAlignment.MiddleRight;
            lblDateOccupiedValue.Location = new Point(144, 53);
            lblDateOccupiedValue.Margin = new Padding(0);
            lblDateOccupiedValue.Name = "lblDateOccupiedValue";
            lblDateOccupiedValue.Size = new Size(90, 25);
            lblDateOccupiedValue.TabIndex = 26;
            lblDateOccupiedValue.Text = "MMDDYY";
            lblDateOccupiedValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateOccupiedTitle
            // 
            lblDateOccupiedTitle.AutoSize = true;
            lblDateOccupiedTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateOccupiedTitle.ForeColor = Color.White;
            lblDateOccupiedTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblDateOccupiedTitle.Location = new Point(6, 53);
            lblDateOccupiedTitle.Margin = new Padding(0);
            lblDateOccupiedTitle.Name = "lblDateOccupiedTitle";
            lblDateOccupiedTitle.Size = new Size(129, 25);
            lblDateOccupiedTitle.TabIndex = 25;
            lblDateOccupiedTitle.Text = "Date Occupied";
            lblDateOccupiedTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUnitNumberValue
            // 
            lblUnitNumberValue.AutoSize = true;
            lblUnitNumberValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitNumberValue.ForeColor = Color.White;
            lblUnitNumberValue.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitNumberValue.Location = new Point(144, 10);
            lblUnitNumberValue.Margin = new Padding(0);
            lblUnitNumberValue.Name = "lblUnitNumberValue";
            lblUnitNumberValue.Size = new Size(45, 25);
            lblUnitNumberValue.TabIndex = 24;
            lblUnitNumberValue.Text = "###";
            lblUnitNumberValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUnitNumberTitle
            // 
            lblUnitNumberTitle.AutoSize = true;
            lblUnitNumberTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitNumberTitle.ForeColor = Color.White;
            lblUnitNumberTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitNumberTitle.Location = new Point(6, 10);
            lblUnitNumberTitle.Margin = new Padding(0);
            lblUnitNumberTitle.Name = "lblUnitNumberTitle";
            lblUnitNumberTitle.Size = new Size(114, 25);
            lblUnitNumberTitle.TabIndex = 23;
            lblUnitNumberTitle.Text = "Unit Number";
            lblUnitNumberTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCurrentTenants
            // 
            pnlCurrentTenants.Controls.Add(dgvCurrentTenants);
            pnlCurrentTenants.Controls.Add(pnlCurrentTenantsHeader);
            pnlCurrentTenants.Dock = DockStyle.Fill;
            pnlCurrentTenants.Location = new Point(444, 3);
            pnlCurrentTenants.Name = "pnlCurrentTenants";
            pnlCurrentTenants.Size = new Size(435, 417);
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
            dgvCurrentTenants.Size = new Size(435, 372);
            dgvCurrentTenants.TabIndex = 30;
            // 
            // pnlCurrentTenantsHeader
            // 
            pnlCurrentTenantsHeader.Controls.Add(lblCurrentTenantsTitle);
            pnlCurrentTenantsHeader.Dock = DockStyle.Top;
            pnlCurrentTenantsHeader.Location = new Point(0, 0);
            pnlCurrentTenantsHeader.Name = "pnlCurrentTenantsHeader";
            pnlCurrentTenantsHeader.Size = new Size(435, 45);
            pnlCurrentTenantsHeader.TabIndex = 29;
            // 
            // lblCurrentTenantsTitle
            // 
            lblCurrentTenantsTitle.AutoSize = true;
            lblCurrentTenantsTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentTenantsTitle.ForeColor = Color.White;
            lblCurrentTenantsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentTenantsTitle.Location = new Point(141, 9);
            lblCurrentTenantsTitle.Margin = new Padding(0);
            lblCurrentTenantsTitle.Name = "lblCurrentTenantsTitle";
            lblCurrentTenantsTitle.Size = new Size(134, 25);
            lblCurrentTenantsTitle.TabIndex = 28;
            lblCurrentTenantsTitle.Text = "Current Tenants";
            lblCurrentTenantsTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            pnlRoomInformation.PerformLayout();
            pnlCurrentTenants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCurrentTenants).EndInit();
            pnlCurrentTenantsHeader.ResumeLayout(false);
            pnlCurrentTenantsHeader.PerformLayout();
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
    }
}