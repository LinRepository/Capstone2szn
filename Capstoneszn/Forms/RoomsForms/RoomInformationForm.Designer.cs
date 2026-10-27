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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlRoomHeader = new Panel();
            lblRoomHeaderInfo = new Label();
            lblRoomTitle = new Label();
            btnMoveOut = new Button();
            btnMoveIn = new Button();
            pnlRoomStatus = new Panel();
            lblEditingNotice = new Label();
            btnTransfer = new Button();
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
            pnlFloorData = new Panel();
            lblFloorValue = new Label();
            lblFloorTitle = new Label();
            pnlRoomTypeData = new Panel();
            lblRoomTypeValue = new Label();
            lblRoomTypeTitle = new Label();
            pnlCapacityData = new Panel();
            lblCapacityValue = new Label();
            lblCapacityTitle = new Label();
            pnlRoomPriceData = new Panel();
            lblPendingPriceValue = new Label();
            lblRoomPriceValue = new Label();
            lblRoomPriceTitle = new Label();
            pnlNextDueData = new Panel();
            lblNextDueValue = new Label();
            lblNextDueTitle = new Label();
            pnlElecData = new Panel();
            lblElecNumberValue = new Label();
            lblElecNameValue = new Label();
            lblElecTitle = new Label();
            pnlSetRoom = new Panel();
            txtSetRoom = new TextBox();
            lblSetRoom = new Label();
            pnlRoomType = new Panel();
            lblRoomType = new Label();
            pnlRoomTypescbo = new Panel();
            cboRoomType = new ComboBox();
            pnlSetCapacity = new Panel();
            nudSetCapacity = new NumericUpDown();
            lblSetCapacity = new Label();
            pnlRoomPricelbl = new Panel();
            lblRoomPrice = new Label();
            pnlRoomPrice = new Panel();
            txtRoomPrice = new TextBox();
            pnlPriceNotice = new Panel();
            lblPriceNotice = new Label();
            pnlSetElecName = new Panel();
            txtSetElecName = new TextBox();
            lblSetElecName = new Label();
            pnlSetElecNumber = new Panel();
            txtSetElecNumber = new TextBox();
            lblSetElecNumber = new Label();
            pnlActionButtons = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            pnlCurrentTenants = new Panel();
            dgvCurrentTenants = new DataGridView();
            colOccId = new DataGridViewTextBoxColumn();
            colOccName = new DataGridViewTextBoxColumn();
            colOccType = new DataGridViewTextBoxColumn();
            colOccContact = new DataGridViewTextBoxColumn();
            colOccMovedIn = new DataGridViewTextBoxColumn();
            colOccBalance = new DataGridViewTextBoxColumn();
            lblBalanceNote = new Label();
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
            pnlFloorData.SuspendLayout();
            pnlRoomTypeData.SuspendLayout();
            pnlCapacityData.SuspendLayout();
            pnlRoomPriceData.SuspendLayout();
            pnlNextDueData.SuspendLayout();
            pnlElecData.SuspendLayout();
            pnlSetRoom.SuspendLayout();
            pnlRoomType.SuspendLayout();
            pnlRoomTypescbo.SuspendLayout();
            pnlSetCapacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSetCapacity).BeginInit();
            pnlRoomPricelbl.SuspendLayout();
            pnlRoomPrice.SuspendLayout();
            pnlPriceNotice.SuspendLayout();
            pnlSetElecName.SuspendLayout();
            pnlSetElecNumber.SuspendLayout();
            pnlActionButtons.SuspendLayout();
            pnlCurrentTenants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentTenants).BeginInit();
            pnlCurrentTenantsHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomHeader
            // 
            pnlRoomHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomHeader.Controls.Add(lblRoomHeaderInfo);
            pnlRoomHeader.Controls.Add(lblRoomTitle);
            pnlRoomHeader.Dock = DockStyle.Top;
            pnlRoomHeader.Location = new Point(0, 0);
            pnlRoomHeader.Name = "pnlRoomHeader";
            pnlRoomHeader.Size = new Size(1282, 50);
            pnlRoomHeader.TabIndex = 0;
            // 
            // lblRoomHeaderInfo
            // 
            lblRoomHeaderInfo.Dock = DockStyle.Right;
            lblRoomHeaderInfo.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomHeaderInfo.ForeColor = Color.Silver;
            lblRoomHeaderInfo.Location = new Point(980, 0);
            lblRoomHeaderInfo.Margin = new Padding(0);
            lblRoomHeaderInfo.Name = "lblRoomHeaderInfo";
            lblRoomHeaderInfo.Padding = new Padding(0, 0, 15, 0);
            lblRoomHeaderInfo.Size = new Size(300, 48);
            lblRoomHeaderInfo.TabIndex = 21;
            lblRoomHeaderInfo.Text = "Room ### · Floor #";
            lblRoomHeaderInfo.TextAlign = ContentAlignment.MiddleRight;
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
            btnMoveOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMoveOut.Cursor = Cursors.Hand;
            btnMoveOut.Location = new Point(1172, 20);
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
            btnMoveIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMoveIn.Cursor = Cursors.Hand;
            btnMoveIn.Location = new Point(1064, 20);
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
            pnlRoomStatus.Controls.Add(lblEditingNotice);
            pnlRoomStatus.Controls.Add(btnTransfer);
            pnlRoomStatus.Controls.Add(lblRoomStatus);
            pnlRoomStatus.Controls.Add(lblCurrentStatus);
            pnlRoomStatus.Controls.Add(panel8);
            pnlRoomStatus.Controls.Add(btnMoveIn);
            pnlRoomStatus.Controls.Add(btnMoveOut);
            pnlRoomStatus.Dock = DockStyle.Top;
            pnlRoomStatus.Location = new Point(0, 50);
            pnlRoomStatus.Name = "pnlRoomStatus";
            pnlRoomStatus.Size = new Size(1282, 80);
            pnlRoomStatus.TabIndex = 1;
            // 
            // lblEditingNotice
            // 
            lblEditingNotice.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditingNotice.ForeColor = Color.Gold;
            lblEditingNotice.Location = new Point(420, 20);
            lblEditingNotice.Name = "lblEditingNotice";
            lblEditingNotice.Size = new Size(510, 40);
            lblEditingNotice.TabIndex = 35;
            lblEditingNotice.Text = "Editing room — Transfer, Move In and Move Out are hidden.";
            lblEditingNotice.TextAlign = ContentAlignment.MiddleLeft;
            lblEditingNotice.Visible = false;
            // 
            // btnTransfer
            // 
            btnTransfer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTransfer.Cursor = Cursors.Hand;
            btnTransfer.Location = new Point(956, 20);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(94, 40);
            btnTransfer.TabIndex = 34;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // lblRoomStatus
            // 
            lblRoomStatus.Dock = DockStyle.Left;
            lblRoomStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomStatus.ForeColor = Color.White;
            lblRoomStatus.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomStatus.Location = new Point(270, 0);
            lblRoomStatus.Margin = new Padding(0);
            lblRoomStatus.Name = "lblRoomStatus";
            lblRoomStatus.Size = new Size(140, 78);
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
            pnlRoomDetails.Size = new Size(1282, 623);
            pnlRoomDetails.TabIndex = 2;
            // 
            // tblRoomDetails
            // 
            tblRoomDetails.ColumnCount = 2;
            tblRoomDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 440F));
            tblRoomDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRoomDetails.Controls.Add(pnlRoomInformation, 0, 0);
            tblRoomDetails.Controls.Add(pnlCurrentTenants, 1, 0);
            tblRoomDetails.Dock = DockStyle.Fill;
            tblRoomDetails.Location = new Point(0, 0);
            tblRoomDetails.Name = "tblRoomDetails";
            tblRoomDetails.RowCount = 1;
            tblRoomDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRoomDetails.Size = new Size(1282, 623);
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
            pnlRoomInformation.Size = new Size(434, 617);
            pnlRoomInformation.TabIndex = 0;
            // 
            // flpRoomDetails
            // 
            flpRoomDetails.AutoScroll = true;
            flpRoomDetails.Controls.Add(pnlUnitData);
            flpRoomDetails.Controls.Add(pnlFloorData);
            flpRoomDetails.Controls.Add(pnlRoomTypeData);
            flpRoomDetails.Controls.Add(pnlCapacityData);
            flpRoomDetails.Controls.Add(pnlRoomPriceData);
            flpRoomDetails.Controls.Add(pnlNextDueData);
            flpRoomDetails.Controls.Add(pnlElecData);
            flpRoomDetails.Controls.Add(pnlSetRoom);
            flpRoomDetails.Controls.Add(pnlRoomType);
            flpRoomDetails.Controls.Add(pnlRoomTypescbo);
            flpRoomDetails.Controls.Add(pnlSetCapacity);
            flpRoomDetails.Controls.Add(pnlRoomPricelbl);
            flpRoomDetails.Controls.Add(pnlRoomPrice);
            flpRoomDetails.Controls.Add(pnlPriceNotice);
            flpRoomDetails.Controls.Add(pnlSetElecName);
            flpRoomDetails.Controls.Add(pnlSetElecNumber);
            flpRoomDetails.Dock = DockStyle.Fill;
            flpRoomDetails.FlowDirection = FlowDirection.TopDown;
            flpRoomDetails.Location = new Point(0, 0);
            flpRoomDetails.Margin = new Padding(0);
            flpRoomDetails.Name = "flpRoomDetails";
            flpRoomDetails.Size = new Size(432, 570);
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
            pnlUnitData.Size = new Size(400, 55);
            pnlUnitData.TabIndex = 32;
            // 
            // lblUnitNumberValue
            // 
            lblUnitNumberValue.Dock = DockStyle.Left;
            lblUnitNumberValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnitNumberValue.ForeColor = Color.White;
            lblUnitNumberValue.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitNumberValue.Location = new Point(180, 0);
            lblUnitNumberValue.Margin = new Padding(0);
            lblUnitNumberValue.Name = "lblUnitNumberValue";
            lblUnitNumberValue.Size = new Size(215, 53);
            lblUnitNumberValue.TabIndex = 24;
            lblUnitNumberValue.Text = "###";
            lblUnitNumberValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUnitNumberTitle
            // 
            lblUnitNumberTitle.Dock = DockStyle.Left;
            lblUnitNumberTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitNumberTitle.ForeColor = Color.Silver;
            lblUnitNumberTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitNumberTitle.Location = new Point(0, 0);
            lblUnitNumberTitle.Margin = new Padding(0);
            lblUnitNumberTitle.Name = "lblUnitNumberTitle";
            lblUnitNumberTitle.Size = new Size(180, 53);
            lblUnitNumberTitle.TabIndex = 23;
            lblUnitNumberTitle.Text = "Unit Number";
            lblUnitNumberTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFloorData
            // 
            pnlFloorData.BorderStyle = BorderStyle.FixedSingle;
            pnlFloorData.Controls.Add(lblFloorValue);
            pnlFloorData.Controls.Add(lblFloorTitle);
            pnlFloorData.Location = new Point(3, 64);
            pnlFloorData.Name = "pnlFloorData";
            pnlFloorData.Size = new Size(400, 55);
            pnlFloorData.TabIndex = 33;
            // 
            // lblFloorValue
            // 
            lblFloorValue.Dock = DockStyle.Left;
            lblFloorValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFloorValue.ForeColor = Color.White;
            lblFloorValue.Location = new Point(180, 0);
            lblFloorValue.Margin = new Padding(0);
            lblFloorValue.Name = "lblFloorValue";
            lblFloorValue.Size = new Size(215, 53);
            lblFloorValue.TabIndex = 1;
            lblFloorValue.Text = "#";
            lblFloorValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFloorTitle
            // 
            lblFloorTitle.Dock = DockStyle.Left;
            lblFloorTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloorTitle.ForeColor = Color.Silver;
            lblFloorTitle.Location = new Point(0, 0);
            lblFloorTitle.Margin = new Padding(0);
            lblFloorTitle.Name = "lblFloorTitle";
            lblFloorTitle.Size = new Size(180, 53);
            lblFloorTitle.TabIndex = 0;
            lblFloorTitle.Text = "Floor";
            lblFloorTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomTypeData
            // 
            pnlRoomTypeData.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomTypeData.Controls.Add(lblRoomTypeValue);
            pnlRoomTypeData.Controls.Add(lblRoomTypeTitle);
            pnlRoomTypeData.Location = new Point(3, 125);
            pnlRoomTypeData.Name = "pnlRoomTypeData";
            pnlRoomTypeData.Size = new Size(400, 55);
            pnlRoomTypeData.TabIndex = 34;
            // 
            // lblRoomTypeValue
            // 
            lblRoomTypeValue.Dock = DockStyle.Left;
            lblRoomTypeValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomTypeValue.ForeColor = Color.White;
            lblRoomTypeValue.Location = new Point(180, 0);
            lblRoomTypeValue.Margin = new Padding(0);
            lblRoomTypeValue.Name = "lblRoomTypeValue";
            lblRoomTypeValue.Size = new Size(215, 53);
            lblRoomTypeValue.TabIndex = 1;
            lblRoomTypeValue.Text = "-";
            lblRoomTypeValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomTypeTitle
            // 
            lblRoomTypeTitle.Dock = DockStyle.Left;
            lblRoomTypeTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomTypeTitle.ForeColor = Color.Silver;
            lblRoomTypeTitle.Location = new Point(0, 0);
            lblRoomTypeTitle.Margin = new Padding(0);
            lblRoomTypeTitle.Name = "lblRoomTypeTitle";
            lblRoomTypeTitle.Size = new Size(180, 53);
            lblRoomTypeTitle.TabIndex = 0;
            lblRoomTypeTitle.Text = "Room Type";
            lblRoomTypeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCapacityData
            // 
            pnlCapacityData.BorderStyle = BorderStyle.FixedSingle;
            pnlCapacityData.Controls.Add(lblCapacityValue);
            pnlCapacityData.Controls.Add(lblCapacityTitle);
            pnlCapacityData.Location = new Point(3, 186);
            pnlCapacityData.Name = "pnlCapacityData";
            pnlCapacityData.Size = new Size(400, 55);
            pnlCapacityData.TabIndex = 42;
            // 
            // lblCapacityValue
            // 
            lblCapacityValue.Dock = DockStyle.Left;
            lblCapacityValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCapacityValue.ForeColor = Color.White;
            lblCapacityValue.ImageAlign = ContentAlignment.MiddleRight;
            lblCapacityValue.Location = new Point(180, 0);
            lblCapacityValue.Margin = new Padding(0);
            lblCapacityValue.Name = "lblCapacityValue";
            lblCapacityValue.Size = new Size(215, 53);
            lblCapacityValue.TabIndex = 29;
            lblCapacityValue.Text = "# / #";
            lblCapacityValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCapacityTitle
            // 
            lblCapacityTitle.Dock = DockStyle.Left;
            lblCapacityTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacityTitle.ForeColor = Color.Silver;
            lblCapacityTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblCapacityTitle.Location = new Point(0, 0);
            lblCapacityTitle.Margin = new Padding(0);
            lblCapacityTitle.Name = "lblCapacityTitle";
            lblCapacityTitle.Size = new Size(180, 53);
            lblCapacityTitle.TabIndex = 28;
            lblCapacityTitle.Text = "Occupants / Capacity";
            lblCapacityTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomPriceData
            // 
            pnlRoomPriceData.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomPriceData.Controls.Add(lblPendingPriceValue);
            pnlRoomPriceData.Controls.Add(lblRoomPriceValue);
            pnlRoomPriceData.Controls.Add(lblRoomPriceTitle);
            pnlRoomPriceData.Location = new Point(3, 247);
            pnlRoomPriceData.Name = "pnlRoomPriceData";
            pnlRoomPriceData.Size = new Size(400, 70);
            pnlRoomPriceData.TabIndex = 35;
            // 
            // lblPendingPriceValue
            // 
            lblPendingPriceValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPendingPriceValue.ForeColor = Color.Gold;
            lblPendingPriceValue.Location = new Point(180, 36);
            lblPendingPriceValue.Margin = new Padding(0);
            lblPendingPriceValue.Name = "lblPendingPriceValue";
            lblPendingPriceValue.Size = new Size(215, 24);
            lblPendingPriceValue.TabIndex = 2;
            lblPendingPriceValue.Text = "₱0.00 from MMM d, yyyy";
            lblPendingPriceValue.TextAlign = ContentAlignment.TopCenter;
            lblPendingPriceValue.Visible = false;
            // 
            // lblRoomPriceValue
            // 
            lblRoomPriceValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomPriceValue.ForeColor = Color.White;
            lblRoomPriceValue.Location = new Point(180, 8);
            lblRoomPriceValue.Margin = new Padding(0);
            lblRoomPriceValue.Name = "lblRoomPriceValue";
            lblRoomPriceValue.Size = new Size(215, 28);
            lblRoomPriceValue.TabIndex = 1;
            lblRoomPriceValue.Text = "₱0.00";
            lblRoomPriceValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomPriceTitle
            // 
            lblRoomPriceTitle.Dock = DockStyle.Left;
            lblRoomPriceTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomPriceTitle.ForeColor = Color.Silver;
            lblRoomPriceTitle.Location = new Point(0, 0);
            lblRoomPriceTitle.Margin = new Padding(0);
            lblRoomPriceTitle.Name = "lblRoomPriceTitle";
            lblRoomPriceTitle.Size = new Size(180, 68);
            lblRoomPriceTitle.TabIndex = 0;
            lblRoomPriceTitle.Text = "Room Price";
            lblRoomPriceTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNextDueData
            // 
            pnlNextDueData.BorderStyle = BorderStyle.FixedSingle;
            pnlNextDueData.Controls.Add(lblNextDueValue);
            pnlNextDueData.Controls.Add(lblNextDueTitle);
            pnlNextDueData.Location = new Point(3, 323);
            pnlNextDueData.Name = "pnlNextDueData";
            pnlNextDueData.Size = new Size(400, 55);
            pnlNextDueData.TabIndex = 36;
            // 
            // lblNextDueValue
            // 
            lblNextDueValue.Dock = DockStyle.Left;
            lblNextDueValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNextDueValue.ForeColor = Color.White;
            lblNextDueValue.Location = new Point(180, 0);
            lblNextDueValue.Margin = new Padding(0);
            lblNextDueValue.Name = "lblNextDueValue";
            lblNextDueValue.Size = new Size(215, 53);
            lblNextDueValue.TabIndex = 1;
            lblNextDueValue.Text = "—";
            lblNextDueValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNextDueTitle
            // 
            lblNextDueTitle.Dock = DockStyle.Left;
            lblNextDueTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNextDueTitle.ForeColor = Color.Silver;
            lblNextDueTitle.Location = new Point(0, 0);
            lblNextDueTitle.Margin = new Padding(0);
            lblNextDueTitle.Name = "lblNextDueTitle";
            lblNextDueTitle.Size = new Size(180, 53);
            lblNextDueTitle.TabIndex = 0;
            lblNextDueTitle.Text = "Next Due Date";
            lblNextDueTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlElecData
            // 
            pnlElecData.BorderStyle = BorderStyle.FixedSingle;
            pnlElecData.Controls.Add(lblElecNumberValue);
            pnlElecData.Controls.Add(lblElecNameValue);
            pnlElecData.Controls.Add(lblElecTitle);
            pnlElecData.Location = new Point(3, 384);
            pnlElecData.Name = "pnlElecData";
            pnlElecData.Size = new Size(400, 70);
            pnlElecData.TabIndex = 37;
            // 
            // lblElecNumberValue
            // 
            lblElecNumberValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElecNumberValue.ForeColor = Color.Silver;
            lblElecNumberValue.Location = new Point(180, 36);
            lblElecNumberValue.Margin = new Padding(0);
            lblElecNumberValue.Name = "lblElecNumberValue";
            lblElecNumberValue.Size = new Size(215, 24);
            lblElecNumberValue.TabIndex = 2;
            lblElecNumberValue.Text = "Acct No. —";
            lblElecNumberValue.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblElecNameValue
            // 
            lblElecNameValue.AutoEllipsis = true;
            lblElecNameValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblElecNameValue.ForeColor = Color.White;
            lblElecNameValue.Location = new Point(180, 8);
            lblElecNameValue.Margin = new Padding(0);
            lblElecNameValue.Name = "lblElecNameValue";
            lblElecNameValue.Size = new Size(215, 28);
            lblElecNameValue.TabIndex = 1;
            lblElecNameValue.Text = "—";
            lblElecNameValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblElecTitle
            // 
            lblElecTitle.Dock = DockStyle.Left;
            lblElecTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElecTitle.ForeColor = Color.Silver;
            lblElecTitle.Location = new Point(0, 0);
            lblElecTitle.Margin = new Padding(0);
            lblElecTitle.Name = "lblElecTitle";
            lblElecTitle.Size = new Size(180, 68);
            lblElecTitle.TabIndex = 0;
            lblElecTitle.Text = "Electricity Account";
            lblElecTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSetRoom
            // 
            pnlSetRoom.BorderStyle = BorderStyle.FixedSingle;
            pnlSetRoom.Controls.Add(txtSetRoom);
            pnlSetRoom.Controls.Add(lblSetRoom);
            pnlSetRoom.Location = new Point(3, 460);
            pnlSetRoom.Name = "pnlSetRoom";
            pnlSetRoom.Size = new Size(400, 55);
            pnlSetRoom.TabIndex = 41;
            pnlSetRoom.Visible = false;
            // 
            // txtSetRoom
            // 
            txtSetRoom.Cursor = Cursors.IBeam;
            txtSetRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSetRoom.Location = new Point(205, 9);
            txtSetRoom.MaxLength = 4;
            txtSetRoom.Name = "txtSetRoom";
            txtSetRoom.PlaceholderText = "1 - 9999";
            txtSetRoom.Size = new Size(180, 34);
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
            lblSetRoom.Size = new Size(190, 53);
            lblSetRoom.TabIndex = 29;
            lblSetRoom.Text = "Room Number";
            lblSetRoom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomType
            // 
            pnlRoomType.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomType.Controls.Add(lblRoomType);
            pnlRoomType.Location = new Point(3, 521);
            pnlRoomType.Name = "pnlRoomType";
            pnlRoomType.Padding = new Padding(5);
            pnlRoomType.Size = new Size(400, 40);
            pnlRoomType.TabIndex = 54;
            pnlRoomType.Visible = false;
            // 
            // lblRoomType
            // 
            lblRoomType.Dock = DockStyle.Left;
            lblRoomType.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomType.ForeColor = Color.White;
            lblRoomType.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomType.Location = new Point(5, 5);
            lblRoomType.Margin = new Padding(0);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(195, 28);
            lblRoomType.TabIndex = 29;
            lblRoomType.Text = "Room Type";
            lblRoomType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlRoomTypescbo
            // 
            pnlRoomTypescbo.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomTypescbo.Controls.Add(cboRoomType);
            pnlRoomTypescbo.Location = new Point(3, 567);
            pnlRoomTypescbo.Name = "pnlRoomTypescbo";
            pnlRoomTypescbo.Size = new Size(400, 55);
            pnlRoomTypescbo.TabIndex = 55;
            pnlRoomTypescbo.Visible = false;
            // 
            // cboRoomType
            // 
            cboRoomType.Cursor = Cursors.Hand;
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(75, 9);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(250, 36);
            cboRoomType.TabIndex = 34;
            cboRoomType.SelectedIndexChanged += cboRoomType_SelectedIndexChanged_1;
            // 
            // pnlSetCapacity
            // 
            pnlSetCapacity.BorderStyle = BorderStyle.FixedSingle;
            pnlSetCapacity.Controls.Add(nudSetCapacity);
            pnlSetCapacity.Controls.Add(lblSetCapacity);
            pnlSetCapacity.Location = new Point(3, 628);
            pnlSetCapacity.Name = "pnlSetCapacity";
            pnlSetCapacity.Size = new Size(400, 55);
            pnlSetCapacity.TabIndex = 53;
            pnlSetCapacity.Visible = false;
            // 
            // nudSetCapacity
            // 
            nudSetCapacity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudSetCapacity.Location = new Point(205, 9);
            nudSetCapacity.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudSetCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSetCapacity.Name = "nudSetCapacity";
            nudSetCapacity.Size = new Size(180, 34);
            nudSetCapacity.TabIndex = 39;
            nudSetCapacity.TextAlign = HorizontalAlignment.Center;
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
            lblSetCapacity.Size = new Size(190, 53);
            lblSetCapacity.TabIndex = 29;
            lblSetCapacity.Text = "Capacity (2 - 10)";
            lblSetCapacity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomPricelbl
            // 
            pnlRoomPricelbl.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomPricelbl.Controls.Add(lblRoomPrice);
            pnlRoomPricelbl.Location = new Point(3, 689);
            pnlRoomPricelbl.Name = "pnlRoomPricelbl";
            pnlRoomPricelbl.Padding = new Padding(5);
            pnlRoomPricelbl.Size = new Size(400, 40);
            pnlRoomPricelbl.TabIndex = 56;
            pnlRoomPricelbl.Visible = false;
            // 
            // lblRoomPrice
            // 
            lblRoomPrice.Dock = DockStyle.Left;
            lblRoomPrice.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomPrice.ForeColor = Color.White;
            lblRoomPrice.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomPrice.Location = new Point(5, 5);
            lblRoomPrice.Margin = new Padding(0);
            lblRoomPrice.Name = "lblRoomPrice";
            lblRoomPrice.Size = new Size(300, 28);
            lblRoomPrice.TabIndex = 30;
            lblRoomPrice.Text = "Room Price (₱, up to 999,999.99)";
            lblRoomPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlRoomPrice
            // 
            pnlRoomPrice.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomPrice.Controls.Add(txtRoomPrice);
            pnlRoomPrice.Location = new Point(3, 735);
            pnlRoomPrice.Name = "pnlRoomPrice";
            pnlRoomPrice.Size = new Size(400, 55);
            pnlRoomPrice.TabIndex = 57;
            pnlRoomPrice.Visible = false;
            // 
            // txtRoomPrice
            // 
            txtRoomPrice.Cursor = Cursors.IBeam;
            txtRoomPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomPrice.Location = new Point(75, 9);
            txtRoomPrice.MaxLength = 9;
            txtRoomPrice.Name = "txtRoomPrice";
            txtRoomPrice.PlaceholderText = "0.00";
            txtRoomPrice.Size = new Size(250, 34);
            txtRoomPrice.TabIndex = 0;
            txtRoomPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // pnlPriceNotice
            // 
            pnlPriceNotice.Controls.Add(lblPriceNotice);
            pnlPriceNotice.Location = new Point(3, 796);
            pnlPriceNotice.Name = "pnlPriceNotice";
            pnlPriceNotice.Padding = new Padding(8, 4, 8, 4);
            pnlPriceNotice.Size = new Size(400, 50);
            pnlPriceNotice.TabIndex = 58;
            pnlPriceNotice.Visible = false;
            // 
            // lblPriceNotice
            // 
            lblPriceNotice.BackColor = Color.FromArgb(46, 46, 102);
            lblPriceNotice.Dock = DockStyle.Fill;
            lblPriceNotice.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPriceNotice.ForeColor = Color.Gold;
            lblPriceNotice.Location = new Point(8, 4);
            lblPriceNotice.Name = "lblPriceNotice";
            lblPriceNotice.Padding = new Padding(6, 0, 6, 0);
            lblPriceNotice.Size = new Size(384, 42);
            lblPriceNotice.TabIndex = 0;
            lblPriceNotice.Text = "Room is occupied — a new price starts on the next due date.";
            lblPriceNotice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlSetElecName
            // 
            pnlSetElecName.BorderStyle = BorderStyle.FixedSingle;
            pnlSetElecName.Controls.Add(txtSetElecName);
            pnlSetElecName.Controls.Add(lblSetElecName);
            pnlSetElecName.Location = new Point(3, 852);
            pnlSetElecName.Name = "pnlSetElecName";
            pnlSetElecName.Size = new Size(400, 55);
            pnlSetElecName.TabIndex = 59;
            pnlSetElecName.Visible = false;
            // 
            // txtSetElecName
            // 
            txtSetElecName.Cursor = Cursors.IBeam;
            txtSetElecName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSetElecName.Location = new Point(205, 9);
            txtSetElecName.MaxLength = 100;
            txtSetElecName.Name = "txtSetElecName";
            txtSetElecName.Size = new Size(180, 34);
            txtSetElecName.TabIndex = 1;
            // 
            // lblSetElecName
            // 
            lblSetElecName.Dock = DockStyle.Left;
            lblSetElecName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSetElecName.ForeColor = Color.White;
            lblSetElecName.Location = new Point(0, 0);
            lblSetElecName.Margin = new Padding(0);
            lblSetElecName.Name = "lblSetElecName";
            lblSetElecName.Size = new Size(190, 53);
            lblSetElecName.TabIndex = 0;
            lblSetElecName.Text = "Elec. Account Name";
            lblSetElecName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSetElecNumber
            // 
            pnlSetElecNumber.BorderStyle = BorderStyle.FixedSingle;
            pnlSetElecNumber.Controls.Add(txtSetElecNumber);
            pnlSetElecNumber.Controls.Add(lblSetElecNumber);
            pnlSetElecNumber.Location = new Point(3, 913);
            pnlSetElecNumber.Name = "pnlSetElecNumber";
            pnlSetElecNumber.Size = new Size(400, 55);
            pnlSetElecNumber.TabIndex = 60;
            pnlSetElecNumber.Visible = false;
            // 
            // txtSetElecNumber
            // 
            txtSetElecNumber.Cursor = Cursors.IBeam;
            txtSetElecNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSetElecNumber.Location = new Point(205, 9);
            txtSetElecNumber.MaxLength = 20;
            txtSetElecNumber.Name = "txtSetElecNumber";
            txtSetElecNumber.Size = new Size(180, 34);
            txtSetElecNumber.TabIndex = 1;
            // 
            // lblSetElecNumber
            // 
            lblSetElecNumber.Dock = DockStyle.Left;
            lblSetElecNumber.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSetElecNumber.ForeColor = Color.White;
            lblSetElecNumber.Location = new Point(0, 0);
            lblSetElecNumber.Margin = new Padding(0);
            lblSetElecNumber.Name = "lblSetElecNumber";
            lblSetElecNumber.Size = new Size(190, 53);
            lblSetElecNumber.TabIndex = 0;
            lblSetElecNumber.Text = "Elec. Account Number";
            lblSetElecNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlActionButtons
            // 
            pnlActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlActionButtons.Controls.Add(btnSave);
            pnlActionButtons.Controls.Add(btnCancel);
            pnlActionButtons.Dock = DockStyle.Bottom;
            pnlActionButtons.Location = new Point(0, 570);
            pnlActionButtons.Name = "pnlActionButtons";
            pnlActionButtons.Size = new Size(432, 45);
            pnlActionButtons.TabIndex = 3;
            pnlActionButtons.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Cursor = Cursors.Hand;
            btnSave.Location = new Point(320, 8);
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
            btnCancel.Location = new Point(212, 8);
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
            pnlCurrentTenants.Controls.Add(lblBalanceNote);
            pnlCurrentTenants.Controls.Add(pnlCurrentTenantsHeader);
            pnlCurrentTenants.Dock = DockStyle.Fill;
            pnlCurrentTenants.Location = new Point(443, 3);
            pnlCurrentTenants.Name = "pnlCurrentTenants";
            pnlCurrentTenants.Size = new Size(836, 617);
            pnlCurrentTenants.TabIndex = 1;
            // 
            // dgvCurrentTenants
            // 
            dgvCurrentTenants.AllowUserToAddRows = false;
            dgvCurrentTenants.AllowUserToDeleteRows = false;
            dgvCurrentTenants.AllowUserToResizeRows = false;
            dgvCurrentTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCurrentTenants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentTenants.Columns.AddRange(new DataGridViewColumn[] { colOccId, colOccName, colOccType, colOccContact, colOccMovedIn, colOccBalance });
            dgvCurrentTenants.Dock = DockStyle.Fill;
            dgvCurrentTenants.Location = new Point(0, 45);
            dgvCurrentTenants.MultiSelect = false;
            dgvCurrentTenants.Name = "dgvCurrentTenants";
            dgvCurrentTenants.ReadOnly = true;
            dgvCurrentTenants.RowHeadersVisible = false;
            dgvCurrentTenants.RowHeadersWidth = 51;
            dgvCurrentTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCurrentTenants.Size = new Size(836, 542);
            dgvCurrentTenants.TabIndex = 30;
            dgvCurrentTenants.CellContentClick += dgvCurrentTenants_CellContentClick;
            // 
            // colOccId
            // 
            colOccId.DataPropertyName = "OccupantId";
            colOccId.FillWeight = 50F;
            colOccId.HeaderText = "ID";
            colOccId.MinimumWidth = 6;
            colOccId.Name = "colOccId";
            colOccId.ReadOnly = true;
            // 
            // colOccName
            // 
            colOccName.DataPropertyName = "FullName";
            colOccName.FillWeight = 160F;
            colOccName.HeaderText = "Name";
            colOccName.MinimumWidth = 6;
            colOccName.Name = "colOccName";
            colOccName.ReadOnly = true;
            // 
            // colOccType
            // 
            colOccType.DataPropertyName = "OccupantType";
            colOccType.FillWeight = 110F;
            colOccType.HeaderText = "Type";
            colOccType.MinimumWidth = 6;
            colOccType.Name = "colOccType";
            colOccType.ReadOnly = true;
            // 
            // colOccContact
            // 
            colOccContact.DataPropertyName = "ContactNumber";
            colOccContact.FillWeight = 110F;
            colOccContact.HeaderText = "Contact";
            colOccContact.MinimumWidth = 6;
            colOccContact.Name = "colOccContact";
            colOccContact.ReadOnly = true;
            // 
            // colOccMovedIn
            // 
            colOccMovedIn.DataPropertyName = "MoveInDate";
            dataGridViewCellStyle1.Format = "MMM d, yyyy";
            colOccMovedIn.DefaultCellStyle = dataGridViewCellStyle1;
            colOccMovedIn.HeaderText = "Moved In";
            colOccMovedIn.MinimumWidth = 6;
            colOccMovedIn.Name = "colOccMovedIn";
            colOccMovedIn.ReadOnly = true;
            // 
            // colOccBalance
            // 
            colOccBalance.DataPropertyName = "BalanceText";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            colOccBalance.DefaultCellStyle = dataGridViewCellStyle2;
            colOccBalance.FillWeight = 95F;
            colOccBalance.HeaderText = "Balance";
            colOccBalance.MinimumWidth = 6;
            colOccBalance.Name = "colOccBalance";
            colOccBalance.ReadOnly = true;
            // 
            // lblBalanceNote
            // 
            lblBalanceNote.Dock = DockStyle.Bottom;
            lblBalanceNote.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalanceNote.ForeColor = Color.Silver;
            lblBalanceNote.Location = new Point(0, 587);
            lblBalanceNote.Name = "lblBalanceNote";
            lblBalanceNote.Padding = new Padding(8, 0, 0, 0);
            lblBalanceNote.Size = new Size(836, 30);
            lblBalanceNote.TabIndex = 31;
            lblBalanceNote.Text = "Balance is rent only · negative = owing, positive = advance · dependents have no balance";
            lblBalanceNote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCurrentTenantsHeader
            // 
            pnlCurrentTenantsHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlCurrentTenantsHeader.Controls.Add(lblCurrentTenantsTitle);
            pnlCurrentTenantsHeader.Dock = DockStyle.Top;
            pnlCurrentTenantsHeader.Location = new Point(0, 0);
            pnlCurrentTenantsHeader.Name = "pnlCurrentTenantsHeader";
            pnlCurrentTenantsHeader.Size = new Size(836, 45);
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
            lblCurrentTenantsTitle.Size = new Size(834, 43);
            lblCurrentTenantsTitle.TabIndex = 28;
            lblCurrentTenantsTitle.Text = "Current Occupants";
            lblCurrentTenantsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RoomInformationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(1282, 753);
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
            pnlFloorData.ResumeLayout(false);
            pnlRoomTypeData.ResumeLayout(false);
            pnlCapacityData.ResumeLayout(false);
            pnlRoomPriceData.ResumeLayout(false);
            pnlNextDueData.ResumeLayout(false);
            pnlElecData.ResumeLayout(false);
            pnlSetRoom.ResumeLayout(false);
            pnlSetRoom.PerformLayout();
            pnlRoomType.ResumeLayout(false);
            pnlRoomTypescbo.ResumeLayout(false);
            pnlSetCapacity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudSetCapacity).EndInit();
            pnlRoomPricelbl.ResumeLayout(false);
            pnlRoomPrice.ResumeLayout(false);
            pnlRoomPrice.PerformLayout();
            pnlPriceNotice.ResumeLayout(false);
            pnlSetElecName.ResumeLayout(false);
            pnlSetElecName.PerformLayout();
            pnlSetElecNumber.ResumeLayout(false);
            pnlSetElecNumber.PerformLayout();
            pnlActionButtons.ResumeLayout(false);
            pnlCurrentTenants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCurrentTenants).EndInit();
            pnlCurrentTenantsHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoomHeader;
        private Label lblRoomHeaderInfo;
        private Button btnMoveOut;
        private Button btnMoveIn;
        private Panel pnlRoomStatus;
        private Label lblEditingNotice;
        private Label lblRoomTitle;
        private Panel pnlRoomDetails;
        private TableLayoutPanel tblRoomDetails;
        private Panel pnlRoomInformation;
        private Panel pnlCurrentTenants;
        private Label lblCurrentTenantsTitle;
        private Panel pnlCurrentTenantsHeader;
        private DataGridView dgvCurrentTenants;
        private DataGridViewTextBoxColumn colOccId;
        private DataGridViewTextBoxColumn colOccName;
        private DataGridViewTextBoxColumn colOccType;
        private DataGridViewTextBoxColumn colOccContact;
        private DataGridViewTextBoxColumn colOccMovedIn;
        private DataGridViewTextBoxColumn colOccBalance;
        private Label lblBalanceNote;
        private Button btnEdit;
        private Panel panel8;
        private Label lblRoomStatus;
        private Label lblCurrentStatus;
        private Panel pnlActionButtons;
        private Button btnSave;
        private Button btnCancel;
        private FlowLayoutPanel flpRoomDetails;

        // read-only panels
        private Panel pnlUnitData;
        private Label lblUnitNumberValue;
        private Label lblUnitNumberTitle;
        private Panel pnlFloorData;
        private Label lblFloorValue;
        private Label lblFloorTitle;
        private Panel pnlRoomTypeData;
        private Label lblRoomTypeValue;
        private Label lblRoomTypeTitle;
        private Panel pnlCapacityData;
        private Label lblCapacityValue;
        private Label lblCapacityTitle;
        private Panel pnlRoomPriceData;
        private Label lblPendingPriceValue;
        private Label lblRoomPriceValue;
        private Label lblRoomPriceTitle;
        private Panel pnlNextDueData;
        private Label lblNextDueValue;
        private Label lblNextDueTitle;
        private Panel pnlElecData;
        private Label lblElecNumberValue;
        private Label lblElecNameValue;
        private Label lblElecTitle;

        // edit panels
        private Panel pnlSetRoom;
        private TextBox txtSetRoom;
        private Label lblSetRoom;
        private Panel pnlRoomType;
        private Label lblRoomType;
        private Panel pnlRoomTypescbo;
        private ComboBox cboRoomType;
        private Panel pnlSetCapacity;
        private NumericUpDown nudSetCapacity;
        private Label lblSetCapacity;
        private Panel pnlRoomPricelbl;
        private Label lblRoomPrice;
        private Panel pnlRoomPrice;
        private TextBox txtRoomPrice;
        private Panel pnlPriceNotice;
        private Label lblPriceNotice;
        private Panel pnlSetElecName;
        private TextBox txtSetElecName;
        private Label lblSetElecName;
        private Panel pnlSetElecNumber;
        private TextBox txtSetElecNumber;
        private Label lblSetElecNumber;
        private Button btnTransfer;
    }
}