namespace Capstoneszn.UserControls
{
    partial class UtilitiesControl
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlUtilitiesContent = new Panel();
            tabUtilities = new TabControl();
            tabWater = new TabPage();
            pnlWaterContent = new Panel();
            dgvWaterBillData = new DataGridView();
            colWaterRoom = new DataGridViewTextBoxColumn();
            colWaterTenant = new DataGridViewTextBoxColumn();
            colWaterDueDate = new DataGridViewTextBoxColumn();
            colWaterAmount = new DataGridViewTextBoxColumn();
            colWaterStatus = new DataGridViewTextBoxColumn();
            pnlWaterHeader = new Panel();
            tblWaterActions = new TableLayoutPanel();
            pnlButtons = new Panel();
            btnEditWaterBill = new Button();
            pnlSpacer = new Panel();
            btnAddWaterBill = new Button();
            pnlTotalShares = new Panel();
            lblTotalSharesValue = new Label();
            lblTotalSharesTitle = new Label();
            pnlCurrentTotal = new Panel();
            lblCurrentTotalBillValue = new Label();
            pnlCurrentTotalBillTitle = new Label();
            pnlWaterDate = new Panel();
            dtpWaterDate = new DateTimePicker();
            lblWaterDateTitle = new Label();
            pnlHeaderWaterTitle = new Panel();
            lblWaterTitle = new Label();
            tabElectricity = new TabPage();
            pnlElectricityContent = new Panel();
            dgvElectricityBillData = new DataGridView();
            colElectricityRoom = new DataGridViewTextBoxColumn();
            colElectricityAccountName = new DataGridViewTextBoxColumn();
            colElectricityAmount = new DataGridViewTextBoxColumn();
            colElectricityStatus = new DataGridViewButtonColumn();
            pnlElectricityHeader = new Panel();
            pnlElectricityButtons = new Panel();
            btnEditElectricity = new Button();
            pnlSpacers = new Panel();
            btnAddElectricity = new Button();
            pnlDate = new Panel();
            dtpElectricityDate = new DateTimePicker();
            lblElectricityDate = new Label();
            pnlHeaderElectricityTitle = new Panel();
            pnlElectricityTitle = new Label();
            tabOther = new TabPage();
            pnlOtherContent = new Panel();
            dgvOtherBillData = new DataGridView();
            colOtherDate = new DataGridViewTextBoxColumn();
            colOtherUtilityName = new DataGridViewTextBoxColumn();
            colOtherName = new DataGridViewTextBoxColumn();
            colOtherAmount = new DataGridViewTextBoxColumn();
            colOtherEdit = new DataGridViewButtonColumn();
            pnlOtherHeader = new Panel();
            pnlOtherDate = new Panel();
            dtpOtherDate = new DateTimePicker();
            lblOtherDate = new Label();
            btnOtherAdd = new Button();
            lblOtherTitles = new Label();
            lblOtherTitle = new Label();
            btnAddOther = new Button();
            pnlUtilitiesContent.SuspendLayout();
            tabUtilities.SuspendLayout();
            tabWater.SuspendLayout();
            pnlWaterContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaterBillData).BeginInit();
            pnlWaterHeader.SuspendLayout();
            tblWaterActions.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlTotalShares.SuspendLayout();
            pnlCurrentTotal.SuspendLayout();
            pnlWaterDate.SuspendLayout();
            pnlHeaderWaterTitle.SuspendLayout();
            tabElectricity.SuspendLayout();
            pnlElectricityContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvElectricityBillData).BeginInit();
            pnlElectricityHeader.SuspendLayout();
            pnlElectricityButtons.SuspendLayout();
            pnlDate.SuspendLayout();
            pnlHeaderElectricityTitle.SuspendLayout();
            tabOther.SuspendLayout();
            pnlOtherContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOtherBillData).BeginInit();
            pnlOtherHeader.SuspendLayout();
            pnlOtherDate.SuspendLayout();
            SuspendLayout();
            // 
            // pnlUtilitiesContent
            // 
            pnlUtilitiesContent.BackColor = Color.FromArgb(11, 20, 50);
            pnlUtilitiesContent.Controls.Add(tabUtilities);
            pnlUtilitiesContent.Dock = DockStyle.Fill;
            pnlUtilitiesContent.Location = new Point(20, 20);
            pnlUtilitiesContent.Name = "pnlUtilitiesContent";
            pnlUtilitiesContent.Size = new Size(1260, 710);
            pnlUtilitiesContent.TabIndex = 0;
            // 
            // tabUtilities
            // 
            tabUtilities.Controls.Add(tabWater);
            tabUtilities.Controls.Add(tabElectricity);
            tabUtilities.Controls.Add(tabOther);
            tabUtilities.Dock = DockStyle.Fill;
            tabUtilities.Font = new Font("Segoe UI", 14F);
            tabUtilities.Location = new Point(0, 0);
            tabUtilities.Name = "tabUtilities";
            tabUtilities.Padding = new Point(10, 3);
            tabUtilities.SelectedIndex = 0;
            tabUtilities.Size = new Size(1260, 710);
            tabUtilities.TabIndex = 1;
            // 
            // tabWater
            // 
            tabWater.Controls.Add(pnlWaterContent);
            tabWater.Controls.Add(pnlWaterHeader);
            tabWater.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabWater.Location = new Point(4, 40);
            tabWater.Name = "tabWater";
            tabWater.Padding = new Padding(3);
            tabWater.Size = new Size(1252, 666);
            tabWater.TabIndex = 0;
            tabWater.Text = "Water Utility";
            tabWater.UseVisualStyleBackColor = true;
            // 
            // pnlWaterContent
            // 
            pnlWaterContent.BorderStyle = BorderStyle.FixedSingle;
            pnlWaterContent.Controls.Add(dgvWaterBillData);
            pnlWaterContent.Dock = DockStyle.Fill;
            pnlWaterContent.Location = new Point(3, 153);
            pnlWaterContent.Name = "pnlWaterContent";
            pnlWaterContent.Size = new Size(1246, 510);
            pnlWaterContent.TabIndex = 16;
            // 
            // dgvWaterBillData
            // 
            dgvWaterBillData.AllowUserToAddRows = false;
            dgvWaterBillData.AllowUserToDeleteRows = false;
            dgvWaterBillData.AllowUserToResizeRows = false;
            dgvWaterBillData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWaterBillData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvWaterBillData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvWaterBillData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWaterBillData.Columns.AddRange(new DataGridViewColumn[] { colWaterRoom, colWaterTenant, colWaterDueDate, colWaterAmount, colWaterStatus });
            dgvWaterBillData.Dock = DockStyle.Fill;
            dgvWaterBillData.Location = new Point(0, 0);
            dgvWaterBillData.Name = "dgvWaterBillData";
            dgvWaterBillData.ReadOnly = true;
            dgvWaterBillData.RowHeadersVisible = false;
            dgvWaterBillData.RowHeadersWidth = 51;
            dgvWaterBillData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWaterBillData.Size = new Size(1244, 508);
            dgvWaterBillData.TabIndex = 12;
            // 
            // colWaterRoom
            // 
            colWaterRoom.FillWeight = 50F;
            colWaterRoom.HeaderText = "Room";
            colWaterRoom.MinimumWidth = 6;
            colWaterRoom.Name = "colWaterRoom";
            colWaterRoom.ReadOnly = true;
            // 
            // colWaterTenant
            // 
            colWaterTenant.FillWeight = 150F;
            colWaterTenant.HeaderText = "Tenant";
            colWaterTenant.MinimumWidth = 6;
            colWaterTenant.Name = "colWaterTenant";
            colWaterTenant.ReadOnly = true;
            // 
            // colWaterDueDate
            // 
            colWaterDueDate.HeaderText = "Due Date";
            colWaterDueDate.MinimumWidth = 6;
            colWaterDueDate.Name = "colWaterDueDate";
            colWaterDueDate.ReadOnly = true;
            // 
            // colWaterAmount
            // 
            colWaterAmount.HeaderText = "Amount";
            colWaterAmount.MinimumWidth = 6;
            colWaterAmount.Name = "colWaterAmount";
            colWaterAmount.ReadOnly = true;
            // 
            // colWaterStatus
            // 
            colWaterStatus.HeaderText = "Status";
            colWaterStatus.MinimumWidth = 6;
            colWaterStatus.Name = "colWaterStatus";
            colWaterStatus.ReadOnly = true;
            // 
            // pnlWaterHeader
            // 
            pnlWaterHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlWaterHeader.Controls.Add(tblWaterActions);
            pnlWaterHeader.Controls.Add(pnlHeaderWaterTitle);
            pnlWaterHeader.Dock = DockStyle.Top;
            pnlWaterHeader.Location = new Point(3, 3);
            pnlWaterHeader.Name = "pnlWaterHeader";
            pnlWaterHeader.Size = new Size(1246, 150);
            pnlWaterHeader.TabIndex = 15;
            // 
            // tblWaterActions
            // 
            tblWaterActions.ColumnCount = 4;
            tblWaterActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblWaterActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblWaterActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblWaterActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblWaterActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblWaterActions.Controls.Add(pnlButtons, 3, 0);
            tblWaterActions.Controls.Add(pnlTotalShares, 2, 0);
            tblWaterActions.Controls.Add(pnlCurrentTotal, 1, 0);
            tblWaterActions.Controls.Add(pnlWaterDate, 0, 0);
            tblWaterActions.Dock = DockStyle.Fill;
            tblWaterActions.Location = new Point(0, 60);
            tblWaterActions.Name = "tblWaterActions";
            tblWaterActions.RowCount = 1;
            tblWaterActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblWaterActions.Size = new Size(1244, 88);
            tblWaterActions.TabIndex = 1;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnEditWaterBill);
            pnlButtons.Controls.Add(pnlSpacer);
            pnlButtons.Controls.Add(btnAddWaterBill);
            pnlButtons.Dock = DockStyle.Fill;
            pnlButtons.Location = new Point(747, 3);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(494, 82);
            pnlButtons.TabIndex = 3;
            // 
            // btnEditWaterBill
            // 
            btnEditWaterBill.Dock = DockStyle.Right;
            btnEditWaterBill.FlatStyle = FlatStyle.Flat;
            btnEditWaterBill.Location = new Point(166, 0);
            btnEditWaterBill.Name = "btnEditWaterBill";
            btnEditWaterBill.Size = new Size(144, 82);
            btnEditWaterBill.TabIndex = 8;
            btnEditWaterBill.Text = "Edit Bill";
            btnEditWaterBill.UseVisualStyleBackColor = true;
            btnEditWaterBill.Click += btnEditWaterBill_Click;
            // 
            // pnlSpacer
            // 
            pnlSpacer.Dock = DockStyle.Right;
            pnlSpacer.Location = new Point(310, 0);
            pnlSpacer.Name = "pnlSpacer";
            pnlSpacer.Size = new Size(40, 82);
            pnlSpacer.TabIndex = 7;
            // 
            // btnAddWaterBill
            // 
            btnAddWaterBill.Dock = DockStyle.Right;
            btnAddWaterBill.FlatStyle = FlatStyle.Flat;
            btnAddWaterBill.Location = new Point(350, 0);
            btnAddWaterBill.Name = "btnAddWaterBill";
            btnAddWaterBill.Size = new Size(144, 82);
            btnAddWaterBill.TabIndex = 6;
            btnAddWaterBill.Text = "Add Bill";
            btnAddWaterBill.UseVisualStyleBackColor = true;
            // 
            // pnlTotalShares
            // 
            pnlTotalShares.Controls.Add(lblTotalSharesValue);
            pnlTotalShares.Controls.Add(lblTotalSharesTitle);
            pnlTotalShares.Dock = DockStyle.Fill;
            pnlTotalShares.Location = new Point(499, 3);
            pnlTotalShares.Name = "pnlTotalShares";
            pnlTotalShares.Size = new Size(242, 82);
            pnlTotalShares.TabIndex = 2;
            // 
            // lblTotalSharesValue
            // 
            lblTotalSharesValue.Dock = DockStyle.Top;
            lblTotalSharesValue.Location = new Point(0, 40);
            lblTotalSharesValue.Name = "lblTotalSharesValue";
            lblTotalSharesValue.Size = new Size(242, 40);
            lblTotalSharesValue.TabIndex = 28;
            lblTotalSharesValue.Text = "₱***";
            lblTotalSharesValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalSharesTitle
            // 
            lblTotalSharesTitle.Dock = DockStyle.Top;
            lblTotalSharesTitle.Location = new Point(0, 0);
            lblTotalSharesTitle.Name = "lblTotalSharesTitle";
            lblTotalSharesTitle.Size = new Size(242, 40);
            lblTotalSharesTitle.TabIndex = 26;
            lblTotalSharesTitle.Text = "Total Shares (+ owner)";
            lblTotalSharesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCurrentTotal
            // 
            pnlCurrentTotal.Controls.Add(lblCurrentTotalBillValue);
            pnlCurrentTotal.Controls.Add(pnlCurrentTotalBillTitle);
            pnlCurrentTotal.Dock = DockStyle.Fill;
            pnlCurrentTotal.Location = new Point(251, 3);
            pnlCurrentTotal.Name = "pnlCurrentTotal";
            pnlCurrentTotal.Size = new Size(242, 82);
            pnlCurrentTotal.TabIndex = 1;
            // 
            // lblCurrentTotalBillValue
            // 
            lblCurrentTotalBillValue.Dock = DockStyle.Top;
            lblCurrentTotalBillValue.Location = new Point(0, 40);
            lblCurrentTotalBillValue.Name = "lblCurrentTotalBillValue";
            lblCurrentTotalBillValue.Size = new Size(242, 40);
            lblCurrentTotalBillValue.TabIndex = 27;
            lblCurrentTotalBillValue.Text = "₱***";
            lblCurrentTotalBillValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCurrentTotalBillTitle
            // 
            pnlCurrentTotalBillTitle.Dock = DockStyle.Top;
            pnlCurrentTotalBillTitle.Location = new Point(0, 0);
            pnlCurrentTotalBillTitle.Name = "pnlCurrentTotalBillTitle";
            pnlCurrentTotalBillTitle.Size = new Size(242, 40);
            pnlCurrentTotalBillTitle.TabIndex = 26;
            pnlCurrentTotalBillTitle.Text = "Current Total Bill";
            pnlCurrentTotalBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlWaterDate
            // 
            pnlWaterDate.Controls.Add(dtpWaterDate);
            pnlWaterDate.Controls.Add(lblWaterDateTitle);
            pnlWaterDate.Dock = DockStyle.Fill;
            pnlWaterDate.Location = new Point(3, 3);
            pnlWaterDate.Name = "pnlWaterDate";
            pnlWaterDate.Size = new Size(242, 82);
            pnlWaterDate.TabIndex = 0;
            // 
            // dtpWaterDate
            // 
            dtpWaterDate.Dock = DockStyle.Fill;
            dtpWaterDate.Font = new Font("Segoe UI", 10F);
            dtpWaterDate.Format = DateTimePickerFormat.Short;
            dtpWaterDate.Location = new Point(0, 40);
            dtpWaterDate.Name = "dtpWaterDate";
            dtpWaterDate.Size = new Size(242, 30);
            dtpWaterDate.TabIndex = 26;
            dtpWaterDate.Value = new DateTime(2026, 8, 23, 0, 0, 0, 0);
            // 
            // lblWaterDateTitle
            // 
            lblWaterDateTitle.Dock = DockStyle.Top;
            lblWaterDateTitle.Location = new Point(0, 0);
            lblWaterDateTitle.Name = "lblWaterDateTitle";
            lblWaterDateTitle.Size = new Size(242, 40);
            lblWaterDateTitle.TabIndex = 25;
            lblWaterDateTitle.Text = "Date";
            lblWaterDateTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeaderWaterTitle
            // 
            pnlHeaderWaterTitle.BorderStyle = BorderStyle.FixedSingle;
            pnlHeaderWaterTitle.Controls.Add(lblWaterTitle);
            pnlHeaderWaterTitle.Dock = DockStyle.Top;
            pnlHeaderWaterTitle.Location = new Point(0, 0);
            pnlHeaderWaterTitle.Name = "pnlHeaderWaterTitle";
            pnlHeaderWaterTitle.Size = new Size(1244, 60);
            pnlHeaderWaterTitle.TabIndex = 0;
            // 
            // lblWaterTitle
            // 
            lblWaterTitle.Dock = DockStyle.Fill;
            lblWaterTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaterTitle.Location = new Point(0, 0);
            lblWaterTitle.Name = "lblWaterTitle";
            lblWaterTitle.Size = new Size(1242, 58);
            lblWaterTitle.TabIndex = 1;
            lblWaterTitle.Text = "Water Bill Monitor";
            lblWaterTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabElectricity
            // 
            tabElectricity.Controls.Add(pnlElectricityContent);
            tabElectricity.Controls.Add(pnlElectricityHeader);
            tabElectricity.Location = new Point(4, 40);
            tabElectricity.Name = "tabElectricity";
            tabElectricity.Padding = new Padding(3);
            tabElectricity.Size = new Size(1252, 666);
            tabElectricity.TabIndex = 1;
            tabElectricity.Text = "Electricity Utility";
            tabElectricity.UseVisualStyleBackColor = true;
            // 
            // pnlElectricityContent
            // 
            pnlElectricityContent.Controls.Add(dgvElectricityBillData);
            pnlElectricityContent.Dock = DockStyle.Fill;
            pnlElectricityContent.Location = new Point(3, 138);
            pnlElectricityContent.Name = "pnlElectricityContent";
            pnlElectricityContent.Size = new Size(1246, 525);
            pnlElectricityContent.TabIndex = 19;
            // 
            // dgvElectricityBillData
            // 
            dgvElectricityBillData.AllowUserToAddRows = false;
            dgvElectricityBillData.AllowUserToDeleteRows = false;
            dgvElectricityBillData.AllowUserToResizeRows = false;
            dgvElectricityBillData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvElectricityBillData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvElectricityBillData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvElectricityBillData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvElectricityBillData.Columns.AddRange(new DataGridViewColumn[] { colElectricityRoom, colElectricityAccountName, colElectricityAmount, colElectricityStatus });
            dgvElectricityBillData.Dock = DockStyle.Fill;
            dgvElectricityBillData.Location = new Point(0, 0);
            dgvElectricityBillData.Name = "dgvElectricityBillData";
            dgvElectricityBillData.ReadOnly = true;
            dgvElectricityBillData.RowHeadersVisible = false;
            dgvElectricityBillData.RowHeadersWidth = 51;
            dgvElectricityBillData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvElectricityBillData.Size = new Size(1246, 525);
            dgvElectricityBillData.TabIndex = 13;
            // 
            // colElectricityRoom
            // 
            colElectricityRoom.FillWeight = 50F;
            colElectricityRoom.HeaderText = "Room";
            colElectricityRoom.MinimumWidth = 6;
            colElectricityRoom.Name = "colElectricityRoom";
            colElectricityRoom.ReadOnly = true;
            // 
            // colElectricityAccountName
            // 
            colElectricityAccountName.HeaderText = "Account Name";
            colElectricityAccountName.MinimumWidth = 6;
            colElectricityAccountName.Name = "colElectricityAccountName";
            colElectricityAccountName.ReadOnly = true;
            // 
            // colElectricityAmount
            // 
            colElectricityAmount.HeaderText = "Amount";
            colElectricityAmount.MinimumWidth = 6;
            colElectricityAmount.Name = "colElectricityAmount";
            colElectricityAmount.ReadOnly = true;
            // 
            // colElectricityStatus
            // 
            colElectricityStatus.HeaderText = "Status";
            colElectricityStatus.MinimumWidth = 6;
            colElectricityStatus.Name = "colElectricityStatus";
            colElectricityStatus.ReadOnly = true;
            // 
            // pnlElectricityHeader
            // 
            pnlElectricityHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlElectricityHeader.Controls.Add(pnlElectricityButtons);
            pnlElectricityHeader.Controls.Add(pnlDate);
            pnlElectricityHeader.Controls.Add(pnlHeaderElectricityTitle);
            pnlElectricityHeader.Dock = DockStyle.Top;
            pnlElectricityHeader.Location = new Point(3, 3);
            pnlElectricityHeader.Name = "pnlElectricityHeader";
            pnlElectricityHeader.Size = new Size(1246, 135);
            pnlElectricityHeader.TabIndex = 18;
            // 
            // pnlElectricityButtons
            // 
            pnlElectricityButtons.Controls.Add(btnEditElectricity);
            pnlElectricityButtons.Controls.Add(pnlSpacers);
            pnlElectricityButtons.Controls.Add(btnAddElectricity);
            pnlElectricityButtons.Dock = DockStyle.Right;
            pnlElectricityButtons.Location = new Point(875, 60);
            pnlElectricityButtons.Name = "pnlElectricityButtons";
            pnlElectricityButtons.Size = new Size(369, 73);
            pnlElectricityButtons.TabIndex = 2;
            // 
            // btnEditElectricity
            // 
            btnEditElectricity.Dock = DockStyle.Right;
            btnEditElectricity.FlatStyle = FlatStyle.Flat;
            btnEditElectricity.Location = new Point(41, 0);
            btnEditElectricity.Name = "btnEditElectricity";
            btnEditElectricity.Size = new Size(144, 73);
            btnEditElectricity.TabIndex = 9;
            btnEditElectricity.Text = "Edit Bill";
            btnEditElectricity.UseVisualStyleBackColor = true;
            // 
            // pnlSpacers
            // 
            pnlSpacers.Dock = DockStyle.Right;
            pnlSpacers.Location = new Point(185, 0);
            pnlSpacers.Name = "pnlSpacers";
            pnlSpacers.Size = new Size(40, 73);
            pnlSpacers.TabIndex = 8;
            // 
            // btnAddElectricity
            // 
            btnAddElectricity.Dock = DockStyle.Right;
            btnAddElectricity.FlatStyle = FlatStyle.Flat;
            btnAddElectricity.Location = new Point(225, 0);
            btnAddElectricity.Name = "btnAddElectricity";
            btnAddElectricity.Size = new Size(144, 73);
            btnAddElectricity.TabIndex = 7;
            btnAddElectricity.Text = "Add Bill";
            btnAddElectricity.UseVisualStyleBackColor = true;
            // 
            // pnlDate
            // 
            pnlDate.BorderStyle = BorderStyle.FixedSingle;
            pnlDate.Controls.Add(dtpElectricityDate);
            pnlDate.Controls.Add(lblElectricityDate);
            pnlDate.Dock = DockStyle.Left;
            pnlDate.Location = new Point(0, 60);
            pnlDate.Name = "pnlDate";
            pnlDate.Size = new Size(296, 73);
            pnlDate.TabIndex = 1;
            // 
            // dtpElectricityDate
            // 
            dtpElectricityDate.Dock = DockStyle.Fill;
            dtpElectricityDate.Font = new Font("Segoe UI", 10F);
            dtpElectricityDate.Location = new Point(0, 40);
            dtpElectricityDate.Name = "dtpElectricityDate";
            dtpElectricityDate.Size = new Size(294, 30);
            dtpElectricityDate.TabIndex = 28;
            dtpElectricityDate.Value = new DateTime(2026, 8, 23, 0, 0, 0, 0);
            // 
            // lblElectricityDate
            // 
            lblElectricityDate.Dock = DockStyle.Top;
            lblElectricityDate.Location = new Point(0, 0);
            lblElectricityDate.Name = "lblElectricityDate";
            lblElectricityDate.Size = new Size(294, 40);
            lblElectricityDate.TabIndex = 27;
            lblElectricityDate.Text = "Date";
            lblElectricityDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeaderElectricityTitle
            // 
            pnlHeaderElectricityTitle.BorderStyle = BorderStyle.FixedSingle;
            pnlHeaderElectricityTitle.Controls.Add(pnlElectricityTitle);
            pnlHeaderElectricityTitle.Dock = DockStyle.Top;
            pnlHeaderElectricityTitle.Location = new Point(0, 0);
            pnlHeaderElectricityTitle.Name = "pnlHeaderElectricityTitle";
            pnlHeaderElectricityTitle.Size = new Size(1244, 60);
            pnlHeaderElectricityTitle.TabIndex = 0;
            // 
            // pnlElectricityTitle
            // 
            pnlElectricityTitle.Dock = DockStyle.Top;
            pnlElectricityTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlElectricityTitle.Location = new Point(0, 0);
            pnlElectricityTitle.Name = "pnlElectricityTitle";
            pnlElectricityTitle.Size = new Size(1242, 58);
            pnlElectricityTitle.TabIndex = 1;
            pnlElectricityTitle.Text = "Electricity Bill Monitor";
            pnlElectricityTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabOther
            // 
            tabOther.Controls.Add(pnlOtherContent);
            tabOther.Controls.Add(pnlOtherHeader);
            tabOther.Location = new Point(4, 40);
            tabOther.Name = "tabOther";
            tabOther.Padding = new Padding(3);
            tabOther.Size = new Size(1252, 666);
            tabOther.TabIndex = 2;
            tabOther.Text = "Other";
            tabOther.UseVisualStyleBackColor = true;
            // 
            // pnlOtherContent
            // 
            pnlOtherContent.Controls.Add(dgvOtherBillData);
            pnlOtherContent.Dock = DockStyle.Fill;
            pnlOtherContent.Location = new Point(3, 138);
            pnlOtherContent.Name = "pnlOtherContent";
            pnlOtherContent.Size = new Size(1246, 525);
            pnlOtherContent.TabIndex = 3;
            // 
            // dgvOtherBillData
            // 
            dgvOtherBillData.AllowUserToAddRows = false;
            dgvOtherBillData.AllowUserToDeleteRows = false;
            dgvOtherBillData.AllowUserToResizeRows = false;
            dgvOtherBillData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOtherBillData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvOtherBillData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvOtherBillData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOtherBillData.Columns.AddRange(new DataGridViewColumn[] { colOtherDate, colOtherUtilityName, colOtherName, colOtherAmount, colOtherEdit });
            dgvOtherBillData.Dock = DockStyle.Fill;
            dgvOtherBillData.Location = new Point(0, 0);
            dgvOtherBillData.Name = "dgvOtherBillData";
            dgvOtherBillData.ReadOnly = true;
            dgvOtherBillData.RowHeadersVisible = false;
            dgvOtherBillData.RowHeadersWidth = 51;
            dgvOtherBillData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOtherBillData.Size = new Size(1246, 525);
            dgvOtherBillData.TabIndex = 14;
            // 
            // colOtherDate
            // 
            colOtherDate.FillWeight = 50F;
            colOtherDate.HeaderText = "Date";
            colOtherDate.MinimumWidth = 6;
            colOtherDate.Name = "colOtherDate";
            colOtherDate.ReadOnly = true;
            // 
            // colOtherUtilityName
            // 
            colOtherUtilityName.HeaderText = "Utility Name";
            colOtherUtilityName.MinimumWidth = 6;
            colOtherUtilityName.Name = "colOtherUtilityName";
            colOtherUtilityName.ReadOnly = true;
            // 
            // colOtherName
            // 
            colOtherName.HeaderText = "Name";
            colOtherName.MinimumWidth = 6;
            colOtherName.Name = "colOtherName";
            colOtherName.ReadOnly = true;
            // 
            // colOtherAmount
            // 
            colOtherAmount.HeaderText = "Amount";
            colOtherAmount.MinimumWidth = 6;
            colOtherAmount.Name = "colOtherAmount";
            colOtherAmount.ReadOnly = true;
            // 
            // colOtherEdit
            // 
            colOtherEdit.HeaderText = "Edit";
            colOtherEdit.MinimumWidth = 6;
            colOtherEdit.Name = "colOtherEdit";
            colOtherEdit.ReadOnly = true;
            // 
            // pnlOtherHeader
            // 
            pnlOtherHeader.Controls.Add(pnlOtherDate);
            pnlOtherHeader.Controls.Add(btnOtherAdd);
            pnlOtherHeader.Controls.Add(lblOtherTitles);
            pnlOtherHeader.Dock = DockStyle.Top;
            pnlOtherHeader.Location = new Point(3, 3);
            pnlOtherHeader.Name = "pnlOtherHeader";
            pnlOtherHeader.Size = new Size(1246, 135);
            pnlOtherHeader.TabIndex = 0;
            // 
            // pnlOtherDate
            // 
            pnlOtherDate.BorderStyle = BorderStyle.FixedSingle;
            pnlOtherDate.Controls.Add(dtpOtherDate);
            pnlOtherDate.Controls.Add(lblOtherDate);
            pnlOtherDate.Dock = DockStyle.Left;
            pnlOtherDate.Location = new Point(0, 58);
            pnlOtherDate.Name = "pnlOtherDate";
            pnlOtherDate.Size = new Size(296, 77);
            pnlOtherDate.TabIndex = 11;
            // 
            // dtpOtherDate
            // 
            dtpOtherDate.Dock = DockStyle.Fill;
            dtpOtherDate.Font = new Font("Segoe UI", 10F);
            dtpOtherDate.Location = new Point(0, 40);
            dtpOtherDate.Name = "dtpOtherDate";
            dtpOtherDate.Size = new Size(294, 30);
            dtpOtherDate.TabIndex = 28;
            dtpOtherDate.Value = new DateTime(2026, 8, 23, 0, 0, 0, 0);
            // 
            // lblOtherDate
            // 
            lblOtherDate.Dock = DockStyle.Top;
            lblOtherDate.Location = new Point(0, 0);
            lblOtherDate.Name = "lblOtherDate";
            lblOtherDate.Size = new Size(294, 40);
            lblOtherDate.TabIndex = 27;
            lblOtherDate.Text = "Date";
            lblOtherDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOtherAdd
            // 
            btnOtherAdd.Dock = DockStyle.Right;
            btnOtherAdd.FlatStyle = FlatStyle.Flat;
            btnOtherAdd.Location = new Point(1102, 58);
            btnOtherAdd.Name = "btnOtherAdd";
            btnOtherAdd.Size = new Size(144, 77);
            btnOtherAdd.TabIndex = 10;
            btnOtherAdd.Text = "Add";
            btnOtherAdd.UseVisualStyleBackColor = true;
            // 
            // lblOtherTitles
            // 
            lblOtherTitles.Dock = DockStyle.Top;
            lblOtherTitles.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOtherTitles.Location = new Point(0, 0);
            lblOtherTitles.Name = "lblOtherTitles";
            lblOtherTitles.Size = new Size(1246, 58);
            lblOtherTitles.TabIndex = 2;
            lblOtherTitles.Text = "Other";
            lblOtherTitles.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOtherTitle
            // 
            lblOtherTitle.Location = new Point(0, 0);
            lblOtherTitle.Name = "lblOtherTitle";
            lblOtherTitle.Size = new Size(100, 23);
            lblOtherTitle.TabIndex = 0;
            // 
            // btnAddOther
            // 
            btnAddOther.Location = new Point(0, 0);
            btnAddOther.Name = "btnAddOther";
            btnAddOther.Size = new Size(75, 23);
            btnAddOther.TabIndex = 0;
            // 
            // UtilitiesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlUtilitiesContent);
            Name = "UtilitiesControl";
            Padding = new Padding(20);
            Size = new Size(1300, 750);
            pnlUtilitiesContent.ResumeLayout(false);
            tabUtilities.ResumeLayout(false);
            tabWater.ResumeLayout(false);
            pnlWaterContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWaterBillData).EndInit();
            pnlWaterHeader.ResumeLayout(false);
            tblWaterActions.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            pnlTotalShares.ResumeLayout(false);
            pnlCurrentTotal.ResumeLayout(false);
            pnlWaterDate.ResumeLayout(false);
            pnlHeaderWaterTitle.ResumeLayout(false);
            tabElectricity.ResumeLayout(false);
            pnlElectricityContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvElectricityBillData).EndInit();
            pnlElectricityHeader.ResumeLayout(false);
            pnlElectricityButtons.ResumeLayout(false);
            pnlDate.ResumeLayout(false);
            pnlHeaderElectricityTitle.ResumeLayout(false);
            tabOther.ResumeLayout(false);
            pnlOtherContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOtherBillData).EndInit();
            pnlOtherHeader.ResumeLayout(false);
            pnlOtherDate.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlUtilitiesContent;
        private TabControl tabUtilities;
        private TabPage tabWater;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabElectricity;
        private TabPage tabOther;
        private Panel pnlWaterHeader;
        private Panel pnlWaterContent;
        private DataGridView dgvWaterBillData;
        private Panel pnlHeaderWaterTitle;
        private TableLayoutPanel tblWaterActions;
        private Panel pnlTotalShares;
        private Panel pnlCurrentTotal;
        private Panel pnlWaterDate;
        private DateTimePicker dtpWaterDate;
        private Label lblWaterDateTitle;
        private Label lblTotalSharesTitle;
        private Label pnlCurrentTotalBillTitle;
        private Label lblCurrentTotalBillValue;
        private Panel pnlButtons;
        private Button btnEditWaterBill;
        private Panel pnlSpacer;
        private Button btnAddWaterBill;
        private Label lblTotalSharesValue;
        private Label lblWaterTitle;
        private Panel pnlElectricityHeader;
        private Panel pnlDate;
        private Panel pnlHeaderElectricityTitle;
        private DateTimePicker dtpElectricityDate;
        private Label lblElectricityDate;
        private Panel pnlElectricityButtons;
        private Button btnAddElectricity;
        private Button btnEditElectricity;
        private Panel pnlSpacers;
        private Label pnlElectricityTitle;
        private Panel panel13;
        private Label lblOtherTitle;
        private Button btnAddOther;
        private Panel pnlElectricityContent;
        private Panel pnlOtherContent;
        private Panel pnlOtherHeader;
        private Label lblOtherTitles;
        private Button btnOtherAdd;
        private Panel pnlOtherDate;
        private DateTimePicker dtpOtherDate;
        private Label lblOtherDate;
        private DataGridViewTextBoxColumn colWaterRoom;
        private DataGridViewTextBoxColumn colWaterTenant;
        private DataGridViewTextBoxColumn colWaterDueDate;
        private DataGridViewTextBoxColumn colWaterAmount;
        private DataGridViewTextBoxColumn colWaterStatus;
        private DataGridView dgvElectricityBillData;
        private DataGridView dgvOtherBillData;
        private DataGridViewTextBoxColumn colOtherDate;
        private DataGridViewTextBoxColumn colOtherUtilityName;
        private DataGridViewTextBoxColumn colOtherName;
        private DataGridViewTextBoxColumn colOtherAmount;
        private DataGridViewButtonColumn colOtherEdit;
        private DataGridViewTextBoxColumn colElectricityRoom;
        private DataGridViewTextBoxColumn colElectricityAccountName;
        private DataGridViewTextBoxColumn colElectricityAmount;
        private DataGridViewButtonColumn colElectricityStatus;
    }
}
