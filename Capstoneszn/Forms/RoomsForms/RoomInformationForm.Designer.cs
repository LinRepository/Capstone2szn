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
            panel8 = new Panel();
            btnEdit = new Button();
            pnlRoomDetails = new Panel();
            tblRoomDetails = new TableLayoutPanel();
            pnlRoomInformation = new Panel();
            flpRoomDetails = new FlowLayoutPanel();
            pnlUnitData = new Panel();
            lblUnitNumberValue = new Label();
            lblUnitNumberTitle = new Label();
            pnlSetRoom = new Panel();
            txtSetRoom = new TextBox();
            lblSetRoom = new Label();
            pnlCapacityData = new Panel();
            lblCapacityValue = new Label();
            lblCapacityTitle = new Label();
            pnlSetCapacity = new Panel();
            nudSetCapacity = new NumericUpDown();
            lblSetCapacity = new Label();
            pnlRoomType = new Panel();
            lblRoomType = new Label();
            pnlRoomTypescbo = new Panel();
            cboRoomType = new ComboBox();
            pnlRoomPricelbl = new Panel();
            lblRoomPrice = new Label();
            pnlRoomPrice = new Panel();
            txtRoomPrice = new TextBox();
            pnlActionButtons = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            pnlCurrentTenants = new Panel();
            dgvCurrentTenants = new DataGridView();
            TenantID = new DataGridViewTextBoxColumn();
            TenantFname = new DataGridViewTextBoxColumn();
            TenantLname = new DataGridViewTextBoxColumn();
            TenantContactNumber = new DataGridViewTextBoxColumn();
            pnlCurrentTenantsHeader = new Panel();
            lblCurrentTenantsTitle = new Label();
            pnlRoomHeader.SuspendLayout();
            pnlRoomStatus.SuspendLayout();
            panel8.SuspendLayout();
            pnlRoomDetails.SuspendLayout();
            tblRoomDetails.SuspendLayout();
            pnlRoomInformation.SuspendLayout();
            flpRoomDetails.SuspendLayout();
            pnlUnitData.SuspendLayout();
            pnlSetRoom.SuspendLayout();
            pnlCapacityData.SuspendLayout();
            pnlSetCapacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSetCapacity).BeginInit();
            pnlRoomType.SuspendLayout();
            pnlRoomTypescbo.SuspendLayout();
            pnlRoomPricelbl.SuspendLayout();
            pnlRoomPrice.SuspendLayout();
            pnlActionButtons.SuspendLayout();
            pnlCurrentTenants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentTenants).BeginInit();
            pnlCurrentTenantsHeader.SuspendLayout();
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
            btnMoveOut.Cursor = Cursors.Hand;
            btnMoveOut.Location = new Point(776, 20);
            btnMoveOut.Name = "btnMoveOut";
            btnMoveOut.Size = new Size(94, 40);
            btnMoveOut.TabIndex = 1;
            btnMoveOut.Text = "Move Out";
            btnMoveOut.UseVisualStyleBackColor = true;
            btnMoveOut.Visible = false;
            btnMoveOut.Click += btnMoveOut_Click;
            // 
            // btnMoveIn
            // 
            btnMoveIn.Cursor = Cursors.Hand;
            btnMoveIn.Location = new Point(676, 20);
            btnMoveIn.Name = "btnMoveIn";
            btnMoveIn.Size = new Size(94, 40);
            btnMoveIn.TabIndex = 0;
            btnMoveIn.Text = "Move In";
            btnMoveIn.UseVisualStyleBackColor = true;
            btnMoveIn.Visible = false;
            btnMoveIn.Click += btnMoveIn_Click;
            // 
            // pnlRoomStatus
            // 
            pnlRoomStatus.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomStatus.Controls.Add(lblRoomStatus);
            pnlRoomStatus.Controls.Add(lblCurrentStatus);
            pnlRoomStatus.Controls.Add(panel8);
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
            lblRoomStatus.Dock = DockStyle.Left;
            lblRoomStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomStatus.ForeColor = Color.White;
            lblRoomStatus.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomStatus.Location = new Point(270, 0);
            lblRoomStatus.Margin = new Padding(0);
            lblRoomStatus.Name = "lblRoomStatus";
            lblRoomStatus.Size = new Size(85, 78);
            lblRoomStatus.TabIndex = 33;
            lblRoomStatus.Text = "Status";
            lblRoomStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.Dock = DockStyle.Left;
            lblCurrentStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentStatus.ForeColor = Color.White;
            lblCurrentStatus.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentStatus.Location = new Point(130, 0);
            lblCurrentStatus.Margin = new Padding(0);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(140, 78);
            lblCurrentStatus.TabIndex = 32;
            lblCurrentStatus.Text = "Current Status";
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnEdit);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(130, 78);
            panel8.TabIndex = 31;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Location = new Point(28, 20);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(76, 40);
            btnEdit.TabIndex = 30;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // pnlRoomDetails
            // 
            pnlRoomDetails.Controls.Add(tblRoomDetails);
            pnlRoomDetails.Dock = DockStyle.Fill;
            pnlRoomDetails.Location = new Point(0, 130);
            pnlRoomDetails.Name = "pnlRoomDetails";
            pnlRoomDetails.Size = new Size(882, 558);
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
            tblRoomDetails.Size = new Size(882, 558);
            tblRoomDetails.TabIndex = 0;
            // 
            // pnlRoomInformation
            // 
            pnlRoomInformation.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomInformation.Controls.Add(flpRoomDetails);
            pnlRoomInformation.Controls.Add(pnlActionButtons);
            pnlRoomInformation.Dock = DockStyle.Fill;
            pnlRoomInformation.Location = new Point(3, 3);
            pnlRoomInformation.Name = "pnlRoomInformation";
            pnlRoomInformation.Size = new Size(346, 552);
            pnlRoomInformation.TabIndex = 0;
            // 
            // flpRoomDetails
            // 
            flpRoomDetails.AutoScroll = true;
            flpRoomDetails.Controls.Add(pnlUnitData);
            flpRoomDetails.Controls.Add(pnlSetRoom);
            flpRoomDetails.Controls.Add(pnlCapacityData);
            flpRoomDetails.Controls.Add(pnlSetCapacity);
            flpRoomDetails.Controls.Add(pnlRoomType);
            flpRoomDetails.Controls.Add(pnlRoomTypescbo);
            flpRoomDetails.Controls.Add(pnlRoomPricelbl);
            flpRoomDetails.Controls.Add(pnlRoomPrice);
            flpRoomDetails.Dock = DockStyle.Fill;
            flpRoomDetails.FlowDirection = FlowDirection.TopDown;
            flpRoomDetails.Location = new Point(0, 0);
            flpRoomDetails.Margin = new Padding(0);
            flpRoomDetails.Name = "flpRoomDetails";
            flpRoomDetails.Size = new Size(344, 505);
            flpRoomDetails.TabIndex = 4;
            flpRoomDetails.WrapContents = false;
            // 
            // pnlUnitData
            // 
            pnlUnitData.BorderStyle = BorderStyle.FixedSingle;
            pnlUnitData.Controls.Add(lblUnitNumberValue);
            pnlUnitData.Controls.Add(lblUnitNumberTitle);
            pnlUnitData.Location = new Point(3, 3);
            pnlUnitData.Name = "pnlUnitData";
            pnlUnitData.Size = new Size(338, 55);
            pnlUnitData.TabIndex = 32;
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
            // pnlSetRoom
            // 
            pnlSetRoom.BorderStyle = BorderStyle.FixedSingle;
            pnlSetRoom.Controls.Add(txtSetRoom);
            pnlSetRoom.Controls.Add(lblSetRoom);
            pnlSetRoom.Location = new Point(3, 64);
            pnlSetRoom.Name = "pnlSetRoom";
            pnlSetRoom.Size = new Size(338, 55);
            pnlSetRoom.TabIndex = 41;
            pnlSetRoom.Visible = false;
            // 
            // txtSetRoom
            // 
            txtSetRoom.Cursor = Cursors.IBeam;
            txtSetRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSetRoom.Location = new Point(180, 3);
            txtSetRoom.Multiline = true;
            txtSetRoom.Name = "txtSetRoom";
            txtSetRoom.Size = new Size(150, 47);
            txtSetRoom.TabIndex = 30;
            txtSetRoom.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSetRoom
            // 
            lblSetRoom.Dock = DockStyle.Left;
            lblSetRoom.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSetRoom.ForeColor = Color.White;
            lblSetRoom.ImageAlign = ContentAlignment.MiddleRight;
            lblSetRoom.Location = new Point(0, 0);
            lblSetRoom.Margin = new Padding(0);
            lblSetRoom.Name = "lblSetRoom";
            lblSetRoom.Size = new Size(164, 53);
            lblSetRoom.TabIndex = 29;
            lblSetRoom.Text = "Set Room Number";
            lblSetRoom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCapacityData
            // 
            pnlCapacityData.BorderStyle = BorderStyle.FixedSingle;
            pnlCapacityData.Controls.Add(lblCapacityValue);
            pnlCapacityData.Controls.Add(lblCapacityTitle);
            pnlCapacityData.Location = new Point(3, 125);
            pnlCapacityData.Name = "pnlCapacityData";
            pnlCapacityData.Size = new Size(338, 55);
            pnlCapacityData.TabIndex = 42;
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
            lblCapacityValue.TabIndex = 29;
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
            lblCapacityTitle.TabIndex = 28;
            lblCapacityTitle.Text = "Capacity";
            lblCapacityTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSetCapacity
            // 
            pnlSetCapacity.BorderStyle = BorderStyle.FixedSingle;
            pnlSetCapacity.Controls.Add(nudSetCapacity);
            pnlSetCapacity.Controls.Add(lblSetCapacity);
            pnlSetCapacity.Location = new Point(3, 186);
            pnlSetCapacity.Name = "pnlSetCapacity";
            pnlSetCapacity.Size = new Size(338, 55);
            pnlSetCapacity.TabIndex = 53;
            pnlSetCapacity.Visible = false;
            // 
            // nudSetCapacity
            // 
            nudSetCapacity.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudSetCapacity.Location = new Point(180, 9);
            nudSetCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSetCapacity.Name = "nudSetCapacity";
            nudSetCapacity.Size = new Size(150, 37);
            nudSetCapacity.TabIndex = 39;
            nudSetCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSetCapacity
            // 
            lblSetCapacity.Dock = DockStyle.Left;
            lblSetCapacity.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSetCapacity.ForeColor = Color.White;
            lblSetCapacity.ImageAlign = ContentAlignment.MiddleRight;
            lblSetCapacity.Location = new Point(0, 0);
            lblSetCapacity.Margin = new Padding(0);
            lblSetCapacity.Name = "lblSetCapacity";
            lblSetCapacity.Size = new Size(164, 53);
            lblSetCapacity.TabIndex = 29;
            lblSetCapacity.Text = "Set Capacity";
            lblSetCapacity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomType
            // 
            pnlRoomType.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomType.Controls.Add(lblRoomType);
            pnlRoomType.Location = new Point(3, 247);
            pnlRoomType.Name = "pnlRoomType";
            pnlRoomType.Padding = new Padding(5);
            pnlRoomType.Size = new Size(338, 55);
            pnlRoomType.TabIndex = 54;
            pnlRoomType.Visible = false;
            // 
            // lblRoomType
            // 
            lblRoomType.Dock = DockStyle.Fill;
            lblRoomType.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomType.ForeColor = Color.White;
            lblRoomType.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomType.Location = new Point(5, 5);
            lblRoomType.Margin = new Padding(0);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(326, 43);
            lblRoomType.TabIndex = 29;
            lblRoomType.Text = "Select a Room Type";
            lblRoomType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomTypescbo
            // 
            pnlRoomTypescbo.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomTypescbo.Controls.Add(cboRoomType);
            pnlRoomTypescbo.Location = new Point(3, 308);
            pnlRoomTypescbo.Name = "pnlRoomTypescbo";
            pnlRoomTypescbo.Size = new Size(338, 55);
            pnlRoomTypescbo.TabIndex = 55;
            pnlRoomTypescbo.Visible = false;
            // 
            // cboRoomType
            // 
            cboRoomType.Cursor = Cursors.Hand;
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(45, 8);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(250, 38);
            cboRoomType.TabIndex = 34;
            // 
            // pnlRoomPricelbl
            // 
            pnlRoomPricelbl.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomPricelbl.Controls.Add(lblRoomPrice);
            pnlRoomPricelbl.Location = new Point(3, 369);
            pnlRoomPricelbl.Name = "pnlRoomPricelbl";
            pnlRoomPricelbl.Padding = new Padding(5);
            pnlRoomPricelbl.Size = new Size(338, 55);
            pnlRoomPricelbl.TabIndex = 56;
            pnlRoomPricelbl.Visible = false;
            // 
            // lblRoomPrice
            // 
            lblRoomPrice.Dock = DockStyle.Fill;
            lblRoomPrice.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomPrice.ForeColor = Color.White;
            lblRoomPrice.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomPrice.Location = new Point(5, 5);
            lblRoomPrice.Margin = new Padding(0);
            lblRoomPrice.Name = "lblRoomPrice";
            lblRoomPrice.Size = new Size(326, 43);
            lblRoomPrice.TabIndex = 30;
            lblRoomPrice.Text = "Enter Room Price";
            lblRoomPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomPrice
            // 
            pnlRoomPrice.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomPrice.Controls.Add(txtRoomPrice);
            pnlRoomPrice.Location = new Point(3, 430);
            pnlRoomPrice.Name = "pnlRoomPrice";
            pnlRoomPrice.Size = new Size(338, 55);
            pnlRoomPrice.TabIndex = 57;
            pnlRoomPrice.Visible = false;
            // 
            // txtRoomPrice
            // 
            txtRoomPrice.Cursor = Cursors.IBeam;
            txtRoomPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomPrice.Location = new Point(45, 3);
            txtRoomPrice.Multiline = true;
            txtRoomPrice.Name = "txtRoomPrice";
            txtRoomPrice.Size = new Size(250, 47);
            txtRoomPrice.TabIndex = 0;
            txtRoomPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // pnlActionButtons
            // 
            pnlActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlActionButtons.Controls.Add(btnSave);
            pnlActionButtons.Controls.Add(btnCancel);
            pnlActionButtons.Dock = DockStyle.Bottom;
            pnlActionButtons.Location = new Point(0, 505);
            pnlActionButtons.Name = "pnlActionButtons";
            pnlActionButtons.Size = new Size(344, 45);
            pnlActionButtons.TabIndex = 3;
            pnlActionButtons.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Cursor = Cursors.Hand;
            btnSave.Location = new Point(204, 9);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 51;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Location = new Point(48, 9);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 50;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlCurrentTenants
            // 
            pnlCurrentTenants.Controls.Add(dgvCurrentTenants);
            pnlCurrentTenants.Controls.Add(pnlCurrentTenantsHeader);
            pnlCurrentTenants.Dock = DockStyle.Fill;
            pnlCurrentTenants.Location = new Point(355, 3);
            pnlCurrentTenants.Name = "pnlCurrentTenants";
            pnlCurrentTenants.Size = new Size(524, 552);
            pnlCurrentTenants.TabIndex = 1;
            // 
            // dgvCurrentTenants
            // 
            dgvCurrentTenants.AllowUserToAddRows = false;
            dgvCurrentTenants.AllowUserToDeleteRows = false;
            dgvCurrentTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCurrentTenants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentTenants.Columns.AddRange(new DataGridViewColumn[] { TenantID, TenantFname, TenantLname, TenantContactNumber });
            dgvCurrentTenants.Dock = DockStyle.Fill;
            dgvCurrentTenants.Location = new Point(0, 45);
            dgvCurrentTenants.MultiSelect = false;
            dgvCurrentTenants.Name = "dgvCurrentTenants";
            dgvCurrentTenants.ReadOnly = true;
            dgvCurrentTenants.RowHeadersVisible = false;
            dgvCurrentTenants.RowHeadersWidth = 51;
            dgvCurrentTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCurrentTenants.Size = new Size(524, 507);
            dgvCurrentTenants.TabIndex = 30;
            dgvCurrentTenants.CellContentClick += dgvCurrentTenants_CellContentClick;
            // 
            // TenantID
            // 
            TenantID.HeaderText = "ID";
            TenantID.MinimumWidth = 6;
            TenantID.Name = "TenantID";
            TenantID.ReadOnly = true;
            // 
            // TenantFname
            // 
            TenantFname.HeaderText = "First Name";
            TenantFname.MinimumWidth = 6;
            TenantFname.Name = "TenantFname";
            TenantFname.ReadOnly = true;
            // 
            // TenantLname
            // 
            TenantLname.HeaderText = "Last Name";
            TenantLname.MinimumWidth = 6;
            TenantLname.Name = "TenantLname";
            TenantLname.ReadOnly = true;
            // 
            // TenantContactNumber
            // 
            TenantContactNumber.HeaderText = "ContactNumber";
            TenantContactNumber.MinimumWidth = 6;
            TenantContactNumber.Name = "TenantContactNumber";
            TenantContactNumber.ReadOnly = true;
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
            // RoomInformationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(882, 688);
            Controls.Add(pnlRoomDetails);
            Controls.Add(pnlRoomStatus);
            Controls.Add(pnlRoomHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RoomInformationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Room Information";
            Load += RoomInformationForm_Load;
            pnlRoomHeader.ResumeLayout(false);
            pnlRoomHeader.PerformLayout();
            pnlRoomStatus.ResumeLayout(false);
            panel8.ResumeLayout(false);
            pnlRoomDetails.ResumeLayout(false);
            tblRoomDetails.ResumeLayout(false);
            pnlRoomInformation.ResumeLayout(false);
            flpRoomDetails.ResumeLayout(false);
            pnlUnitData.ResumeLayout(false);
            pnlSetRoom.ResumeLayout(false);
            pnlSetRoom.PerformLayout();
            pnlCapacityData.ResumeLayout(false);
            pnlSetCapacity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudSetCapacity).EndInit();
            pnlRoomType.ResumeLayout(false);
            pnlRoomTypescbo.ResumeLayout(false);
            pnlRoomPricelbl.ResumeLayout(false);
            pnlRoomPrice.ResumeLayout(false);
            pnlRoomPrice.PerformLayout();
            pnlActionButtons.ResumeLayout(false);
            pnlCurrentTenants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCurrentTenants).EndInit();
            pnlCurrentTenantsHeader.ResumeLayout(false);
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
        private TableLayoutPanel tblRoomDetails;
        private Panel pnlRoomInformation;
        private Panel pnlCurrentTenants;
        private Label lblCurrentTenantsTitle;
        private Panel pnlCurrentTenantsHeader;
        private DataGridView dgvCurrentTenants;
        private Button btnEdit;
        private Panel panel8;
        private Label lblRoomStatus;
        private Label lblCurrentStatus;
        private DataGridViewTextBoxColumn TenantID;
        private DataGridViewTextBoxColumn TenantFname;
        private DataGridViewTextBoxColumn TenantLname;
        private DataGridViewTextBoxColumn TenantContactNumber;
        private Panel pnlActionButtons;
        private Button btnSave;
        private Button btnCancel;
        private FlowLayoutPanel flpRoomDetails;
        private Panel pnlUnitData;
        private Label lblUnitNumberValue;
        private Label lblUnitNumberTitle;
        private Panel pnlSetRoom;
        private TextBox txtSetRoom;
        private Label lblSetRoom;
        private Panel pnlCapacityData;
        private Label lblCapacityValue;
        private Label lblCapacityTitle;
        private Panel pnlSetCapacity;
        private NumericUpDown nudSetCapacity;
        private Label lblSetCapacity;
        private Panel pnlRoomType;
        private Label lblRoomType;
        private Panel pnlRoomTypescbo;
        private ComboBox cboRoomType;
        private Panel pnlRoomPricelbl;
        private Label lblRoomPrice;
        private Panel pnlRoomPrice;
        private TextBox txtRoomPrice;
    }
}