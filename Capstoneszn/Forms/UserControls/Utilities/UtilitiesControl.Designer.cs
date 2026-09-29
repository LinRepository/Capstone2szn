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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlUtilitiesContent = new Panel();
            tabUtilities = new TabControl();
            tabWater = new TabPage();
            pnlWaterContent = new Panel();
            dgvWaterBillData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
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
            dgvElectricityData = new DataGridView();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewComboBoxColumn();
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
            dgvOtherData = new DataGridView();
            Column10 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewButtonColumn();
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
            ((System.ComponentModel.ISupportInitialize)dgvElectricityData).BeginInit();
            pnlElectricityHeader.SuspendLayout();
            pnlElectricityButtons.SuspendLayout();
            pnlDate.SuspendLayout();
            pnlHeaderElectricityTitle.SuspendLayout();
            tabOther.SuspendLayout();
            pnlOtherContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOtherData).BeginInit();
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
            dgvWaterBillData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvWaterBillData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvWaterBillData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWaterBillData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgvWaterBillData.Dock = DockStyle.Fill;
            dgvWaterBillData.Location = new Point(0, 0);
            dgvWaterBillData.Name = "dgvWaterBillData";
            dgvWaterBillData.RowHeadersWidth = 51;
            dgvWaterBillData.Size = new Size(1244, 508);
            dgvWaterBillData.TabIndex = 12;
            // 
            // Column1
            // 
            Column1.FillWeight = 50F;
            Column1.HeaderText = "Room";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.FillWeight = 150F;
            Column2.HeaderText = "Tenant";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Due Date";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Amount";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Status";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
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
            lblTotalSharesValue.Text = "****";
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
            lblCurrentTotalBillValue.Text = "****";
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
            pnlElectricityContent.Controls.Add(dgvElectricityData);
            pnlElectricityContent.Dock = DockStyle.Fill;
            pnlElectricityContent.Location = new Point(3, 138);
            pnlElectricityContent.Name = "pnlElectricityContent";
            pnlElectricityContent.Size = new Size(1246, 525);
            pnlElectricityContent.TabIndex = 19;
            // 
            // dgvElectricityData
            // 
            dgvElectricityData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvElectricityData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvElectricityData.Columns.AddRange(new DataGridViewColumn[] { Column6, Column7, Column8, Column9 });
            dgvElectricityData.Dock = DockStyle.Fill;
            dgvElectricityData.Location = new Point(0, 0);
            dgvElectricityData.Name = "dgvElectricityData";
            dgvElectricityData.RowHeadersWidth = 51;
            dgvElectricityData.Size = new Size(1246, 525);
            dgvElectricityData.TabIndex = 20;
            // 
            // Column6
            // 
            Column6.FillWeight = 50F;
            Column6.HeaderText = "Room";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "Name";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.FillWeight = 70F;
            Column8.HeaderText = "Amount";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.FillWeight = 70F;
            Column9.HeaderText = "Status";
            Column9.Items.AddRange(new object[] { "Pending", "Paid", "Overdue" });
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
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
            pnlOtherContent.Controls.Add(dgvOtherData);
            pnlOtherContent.Dock = DockStyle.Fill;
            pnlOtherContent.Location = new Point(3, 138);
            pnlOtherContent.Name = "pnlOtherContent";
            pnlOtherContent.Size = new Size(1246, 525);
            pnlOtherContent.TabIndex = 3;
            // 
            // dgvOtherData
            // 
            dgvOtherData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOtherData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOtherData.Columns.AddRange(new DataGridViewColumn[] { Column10, Column11, Column12, Column14, Column15 });
            dgvOtherData.Dock = DockStyle.Fill;
            dgvOtherData.Location = new Point(0, 0);
            dgvOtherData.Name = "dgvOtherData";
            dgvOtherData.RowHeadersWidth = 51;
            dgvOtherData.Size = new Size(1246, 525);
            dgvOtherData.TabIndex = 3;
            // 
            // Column10
            // 
            Column10.HeaderText = "Date";
            Column10.MinimumWidth = 6;
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // Column11
            // 
            Column11.HeaderText = "Utility Name";
            Column11.MinimumWidth = 6;
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            // 
            // Column12
            // 
            Column12.HeaderText = "Name";
            Column12.MinimumWidth = 6;
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            // 
            // Column14
            // 
            Column14.HeaderText = "Amount";
            Column14.MinimumWidth = 6;
            Column14.Name = "Column14";
            Column14.ReadOnly = true;
            // 
            // Column15
            // 
            Column15.HeaderText = "Edit";
            Column15.MinimumWidth = 6;
            Column15.Name = "Column15";
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
            ((System.ComponentModel.ISupportInitialize)dgvElectricityData).EndInit();
            pnlElectricityHeader.ResumeLayout(false);
            pnlElectricityButtons.ResumeLayout(false);
            pnlDate.ResumeLayout(false);
            pnlHeaderElectricityTitle.ResumeLayout(false);
            tabOther.ResumeLayout(false);
            pnlOtherContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOtherData).EndInit();
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
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
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
        private DataGridView dgvElectricityData;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewComboBoxColumn Column9;
        private Panel pnlOtherContent;
        private DataGridView dgvOtherData;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewButtonColumn Column15;
        private Panel pnlOtherHeader;
        private Label lblOtherTitles;
        private Button btnOtherAdd;
        private Panel pnlOtherDate;
        private DateTimePicker dtpOtherDate;
        private Label lblOtherDate;
    }
}
