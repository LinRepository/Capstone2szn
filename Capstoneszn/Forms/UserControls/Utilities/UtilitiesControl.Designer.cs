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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            panel6 = new Panel();
            label4 = new Label();
            pnlWaterAdminAccount = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            pnlWaterHeader = new Panel();
            tblWaterActions = new TableLayoutPanel();
            pnlButtons = new Panel();
            btnGenerateBill = new Button();
            panel3 = new Panel();
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
            dgvElectricity = new DataGridView();
            colSelect = new DataGridViewCheckBoxColumn();
            colElectricityRoom = new DataGridViewTextBoxColumn();
            colElectricityAccountName = new DataGridViewTextBoxColumn();
            colElectricityAccountNumber = new DataGridViewTextBoxColumn();
            colElectricityAmount = new DataGridViewTextBoxColumn();
            colElectricityStatus = new DataGridViewButtonColumn();
            panel5 = new Panel();
            label2 = new Label();
            btnSelectAllUnpaid = new Button();
            panel7 = new Panel();
            btnMarkPaid = new Button();
            panel1 = new Panel();
            pnlElecAdminAccount = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            pnlElectricityHeader = new Panel();
            pnlDate = new Panel();
            dtpElectricityDate = new DateTimePicker();
            lblElectricityDate = new Label();
            pnlHeaderElectricityTitle = new Panel();
            pnlElectricityTitle = new Label();
            lblOtherTitle = new Label();
            btnAddOther = new Button();
            pnlUtilitiesContent.SuspendLayout();
            tabUtilities.SuspendLayout();
            tabWater.SuspendLayout();
            pnlWaterContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaterBillData).BeginInit();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            pnlWaterHeader.SuspendLayout();
            tblWaterActions.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlTotalShares.SuspendLayout();
            pnlCurrentTotal.SuspendLayout();
            pnlWaterDate.SuspendLayout();
            pnlHeaderWaterTitle.SuspendLayout();
            tabElectricity.SuspendLayout();
            pnlElectricityContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvElectricity).BeginInit();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlElectricityHeader.SuspendLayout();
            pnlDate.SuspendLayout();
            pnlHeaderElectricityTitle.SuspendLayout();
            SuspendLayout();
            // 
            // pnlUtilitiesContent
            // 
            pnlUtilitiesContent.BackColor = Color.FromArgb(11, 20, 50);
            pnlUtilitiesContent.Controls.Add(tabUtilities);
            pnlUtilitiesContent.Dock = DockStyle.Fill;
            pnlUtilitiesContent.Location = new Point(0, 0);
            pnlUtilitiesContent.Name = "pnlUtilitiesContent";
            pnlUtilitiesContent.Size = new Size(1300, 750);
            pnlUtilitiesContent.TabIndex = 0;
            // 
            // tabUtilities
            // 
            tabUtilities.Controls.Add(tabWater);
            tabUtilities.Controls.Add(tabElectricity);
            tabUtilities.Dock = DockStyle.Fill;
            tabUtilities.Font = new Font("Segoe UI", 14F);
            tabUtilities.Location = new Point(0, 0);
            tabUtilities.Name = "tabUtilities";
            tabUtilities.Padding = new Point(10, 3);
            tabUtilities.SelectedIndex = 0;
            tabUtilities.Size = new Size(1300, 750);
            tabUtilities.TabIndex = 1;
            // 
            // tabWater
            // 
            tabWater.Controls.Add(pnlWaterContent);
            tabWater.Controls.Add(panel6);
            tabWater.Controls.Add(pnlWaterAdminAccount);
            tabWater.Controls.Add(panel4);
            tabWater.Controls.Add(pnlWaterHeader);
            tabWater.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabWater.Location = new Point(4, 40);
            tabWater.Name = "tabWater";
            tabWater.Padding = new Padding(3);
            tabWater.Size = new Size(1292, 706);
            tabWater.TabIndex = 0;
            tabWater.Text = "Water Utility";
            tabWater.UseVisualStyleBackColor = true;
            // 
            // pnlWaterContent
            // 
            pnlWaterContent.BorderStyle = BorderStyle.FixedSingle;
            pnlWaterContent.Controls.Add(dgvWaterBillData);
            pnlWaterContent.Dock = DockStyle.Fill;
            pnlWaterContent.Location = new Point(3, 271);
            pnlWaterContent.Name = "pnlWaterContent";
            pnlWaterContent.Size = new Size(1286, 432);
            pnlWaterContent.TabIndex = 16;
            // 
            // dgvWaterBillData
            // 
            dgvWaterBillData.AllowUserToAddRows = false;
            dgvWaterBillData.AllowUserToDeleteRows = false;
            dgvWaterBillData.AllowUserToResizeRows = false;
            dgvWaterBillData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWaterBillData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvWaterBillData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvWaterBillData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWaterBillData.Columns.AddRange(new DataGridViewColumn[] { colWaterRoom, colWaterTenant, colWaterDueDate, colWaterAmount, colWaterStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvWaterBillData.DefaultCellStyle = dataGridViewCellStyle2;
            dgvWaterBillData.Dock = DockStyle.Fill;
            dgvWaterBillData.Location = new Point(0, 0);
            dgvWaterBillData.Name = "dgvWaterBillData";
            dgvWaterBillData.ReadOnly = true;
            dgvWaterBillData.RowHeadersVisible = false;
            dgvWaterBillData.RowHeadersWidth = 51;
            dgvWaterBillData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWaterBillData.Size = new Size(1284, 430);
            dgvWaterBillData.TabIndex = 12;
            dgvWaterBillData.CellContentClick += dgvWaterBillData_CellContentClick;
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
            // panel6
            // 
            panel6.BackColor = Color.Gainsboro;
            panel6.Controls.Add(label4);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(3, 244);
            panel6.Name = "panel6";
            panel6.Size = new Size(1286, 27);
            panel6.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(4, 4);
            label4.Name = "label4";
            label4.Size = new Size(136, 23);
            label4.TabIndex = 0;
            label4.Text = "Tenant Accounts";
            // 
            // pnlWaterAdminAccount
            // 
            pnlWaterAdminAccount.Dock = DockStyle.Top;
            pnlWaterAdminAccount.Location = new Point(3, 154);
            pnlWaterAdminAccount.Name = "pnlWaterAdminAccount";
            pnlWaterAdminAccount.Size = new Size(1286, 90);
            pnlWaterAdminAccount.TabIndex = 18;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gainsboro;
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 127);
            panel4.Name = "panel4";
            panel4.Size = new Size(1286, 27);
            panel4.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(4, 3);
            label3.Name = "label3";
            label3.Size = new Size(128, 23);
            label3.TabIndex = 0;
            label3.Text = "Admin Account";
            // 
            // pnlWaterHeader
            // 
            pnlWaterHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlWaterHeader.Controls.Add(tblWaterActions);
            pnlWaterHeader.Controls.Add(pnlHeaderWaterTitle);
            pnlWaterHeader.Dock = DockStyle.Top;
            pnlWaterHeader.Location = new Point(3, 3);
            pnlWaterHeader.Name = "pnlWaterHeader";
            pnlWaterHeader.Size = new Size(1286, 124);
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
            tblWaterActions.Location = new Point(0, 41);
            tblWaterActions.Name = "tblWaterActions";
            tblWaterActions.RowCount = 1;
            tblWaterActions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblWaterActions.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblWaterActions.Size = new Size(1284, 81);
            tblWaterActions.TabIndex = 1;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnGenerateBill);
            pnlButtons.Controls.Add(panel3);
            pnlButtons.Controls.Add(btnEditWaterBill);
            pnlButtons.Controls.Add(pnlSpacer);
            pnlButtons.Controls.Add(btnAddWaterBill);
            pnlButtons.Dock = DockStyle.Right;
            pnlButtons.Location = new Point(821, 3);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(10);
            pnlButtons.Size = new Size(460, 75);
            pnlButtons.TabIndex = 3;
            // 
            // btnGenerateBill
            // 
            btnGenerateBill.Dock = DockStyle.Right;
            btnGenerateBill.FlatStyle = FlatStyle.Flat;
            btnGenerateBill.Location = new Point(26, 10);
            btnGenerateBill.Name = "btnGenerateBill";
            btnGenerateBill.Size = new Size(134, 55);
            btnGenerateBill.TabIndex = 9;
            btnGenerateBill.Text = "Generate bill";
            btnGenerateBill.UseVisualStyleBackColor = true;
            btnGenerateBill.Click += btnGenerateBill_Click;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(160, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(34, 55);
            panel3.TabIndex = 10;
            // 
            // btnEditWaterBill
            // 
            btnEditWaterBill.Dock = DockStyle.Right;
            btnEditWaterBill.FlatStyle = FlatStyle.Flat;
            btnEditWaterBill.Location = new Point(194, 10);
            btnEditWaterBill.Name = "btnEditWaterBill";
            btnEditWaterBill.Size = new Size(107, 55);
            btnEditWaterBill.TabIndex = 8;
            btnEditWaterBill.Text = "Edit Bill";
            btnEditWaterBill.UseVisualStyleBackColor = true;
            btnEditWaterBill.Click += btnEditWaterBill_Click;
            // 
            // pnlSpacer
            // 
            pnlSpacer.Dock = DockStyle.Right;
            pnlSpacer.Location = new Point(301, 10);
            pnlSpacer.Name = "pnlSpacer";
            pnlSpacer.Size = new Size(34, 55);
            pnlSpacer.TabIndex = 7;
            // 
            // btnAddWaterBill
            // 
            btnAddWaterBill.BackColor = Color.LightSkyBlue;
            btnAddWaterBill.Dock = DockStyle.Right;
            btnAddWaterBill.FlatStyle = FlatStyle.Flat;
            btnAddWaterBill.Location = new Point(335, 10);
            btnAddWaterBill.Name = "btnAddWaterBill";
            btnAddWaterBill.Size = new Size(115, 55);
            btnAddWaterBill.TabIndex = 6;
            btnAddWaterBill.Text = "Add Bill";
            btnAddWaterBill.UseVisualStyleBackColor = false;
            btnAddWaterBill.Click += btnAddWaterBill_Click;
            // 
            // pnlTotalShares
            // 
            pnlTotalShares.Controls.Add(lblTotalSharesValue);
            pnlTotalShares.Controls.Add(lblTotalSharesTitle);
            pnlTotalShares.Dock = DockStyle.Left;
            pnlTotalShares.Location = new Point(515, 3);
            pnlTotalShares.Name = "pnlTotalShares";
            pnlTotalShares.Size = new Size(250, 75);
            pnlTotalShares.TabIndex = 2;
            // 
            // lblTotalSharesValue
            // 
            lblTotalSharesValue.Dock = DockStyle.Top;
            lblTotalSharesValue.Location = new Point(0, 37);
            lblTotalSharesValue.Name = "lblTotalSharesValue";
            lblTotalSharesValue.Size = new Size(250, 30);
            lblTotalSharesValue.TabIndex = 28;
            lblTotalSharesValue.Text = "₱***";
            lblTotalSharesValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalSharesTitle
            // 
            lblTotalSharesTitle.Dock = DockStyle.Top;
            lblTotalSharesTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalSharesTitle.Location = new Point(0, 0);
            lblTotalSharesTitle.Name = "lblTotalSharesTitle";
            lblTotalSharesTitle.Size = new Size(250, 37);
            lblTotalSharesTitle.TabIndex = 26;
            lblTotalSharesTitle.Text = "TotalShares(Tenants + owner)";
            lblTotalSharesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCurrentTotal
            // 
            pnlCurrentTotal.Controls.Add(lblCurrentTotalBillValue);
            pnlCurrentTotal.Controls.Add(pnlCurrentTotalBillTitle);
            pnlCurrentTotal.Dock = DockStyle.Left;
            pnlCurrentTotal.Location = new Point(259, 3);
            pnlCurrentTotal.Name = "pnlCurrentTotal";
            pnlCurrentTotal.Size = new Size(250, 75);
            pnlCurrentTotal.TabIndex = 1;
            // 
            // lblCurrentTotalBillValue
            // 
            lblCurrentTotalBillValue.Dock = DockStyle.Top;
            lblCurrentTotalBillValue.Location = new Point(0, 37);
            lblCurrentTotalBillValue.Name = "lblCurrentTotalBillValue";
            lblCurrentTotalBillValue.Size = new Size(250, 38);
            lblCurrentTotalBillValue.TabIndex = 27;
            lblCurrentTotalBillValue.Text = "₱***";
            lblCurrentTotalBillValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCurrentTotalBillTitle
            // 
            pnlCurrentTotalBillTitle.Dock = DockStyle.Top;
            pnlCurrentTotalBillTitle.Location = new Point(0, 0);
            pnlCurrentTotalBillTitle.Name = "pnlCurrentTotalBillTitle";
            pnlCurrentTotalBillTitle.Size = new Size(250, 37);
            pnlCurrentTotalBillTitle.TabIndex = 26;
            pnlCurrentTotalBillTitle.Text = "Current Total Bill";
            pnlCurrentTotalBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlWaterDate
            // 
            pnlWaterDate.Controls.Add(dtpWaterDate);
            pnlWaterDate.Controls.Add(lblWaterDateTitle);
            pnlWaterDate.Dock = DockStyle.Left;
            pnlWaterDate.Location = new Point(3, 3);
            pnlWaterDate.Name = "pnlWaterDate";
            pnlWaterDate.Padding = new Padding(10, 0, 10, 10);
            pnlWaterDate.Size = new Size(250, 75);
            pnlWaterDate.TabIndex = 0;
            // 
            // dtpWaterDate
            // 
            dtpWaterDate.CustomFormat = "MMMM yyyy";
            dtpWaterDate.Dock = DockStyle.Fill;
            dtpWaterDate.Font = new Font("Segoe UI", 10F);
            dtpWaterDate.Format = DateTimePickerFormat.Custom;
            dtpWaterDate.Location = new Point(10, 32);
            dtpWaterDate.Name = "dtpWaterDate";
            dtpWaterDate.Size = new Size(230, 30);
            dtpWaterDate.TabIndex = 26;
            dtpWaterDate.Value = new DateTime(2026, 10, 14, 0, 0, 0, 0);
            dtpWaterDate.ValueChanged += dtpWaterDate_ValueChanged;
            // 
            // lblWaterDateTitle
            // 
            lblWaterDateTitle.Dock = DockStyle.Top;
            lblWaterDateTitle.Location = new Point(10, 0);
            lblWaterDateTitle.Name = "lblWaterDateTitle";
            lblWaterDateTitle.Size = new Size(230, 32);
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
            pnlHeaderWaterTitle.Size = new Size(1284, 41);
            pnlHeaderWaterTitle.TabIndex = 0;
            // 
            // lblWaterTitle
            // 
            lblWaterTitle.Dock = DockStyle.Fill;
            lblWaterTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaterTitle.Location = new Point(0, 0);
            lblWaterTitle.Name = "lblWaterTitle";
            lblWaterTitle.Size = new Size(1282, 39);
            lblWaterTitle.TabIndex = 1;
            lblWaterTitle.Text = "Water Bill Monitor";
            lblWaterTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabElectricity
            // 
            tabElectricity.Controls.Add(pnlElectricityContent);
            tabElectricity.Controls.Add(panel5);
            tabElectricity.Controls.Add(panel1);
            tabElectricity.Controls.Add(pnlElectricityHeader);
            tabElectricity.Location = new Point(4, 40);
            tabElectricity.Name = "tabElectricity";
            tabElectricity.Padding = new Padding(3);
            tabElectricity.Size = new Size(1292, 706);
            tabElectricity.TabIndex = 1;
            tabElectricity.Text = "Electricity Utility";
            tabElectricity.UseVisualStyleBackColor = true;
            // 
            // pnlElectricityContent
            // 
            pnlElectricityContent.Controls.Add(dgvElectricity);
            pnlElectricityContent.Dock = DockStyle.Fill;
            pnlElectricityContent.Location = new Point(3, 321);
            pnlElectricityContent.Name = "pnlElectricityContent";
            pnlElectricityContent.Size = new Size(1286, 382);
            pnlElectricityContent.TabIndex = 19;
            // 
            // dgvElectricity
            // 
            dgvElectricity.AllowUserToAddRows = false;
            dgvElectricity.AllowUserToDeleteRows = false;
            dgvElectricity.AllowUserToResizeRows = false;
            dgvElectricity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvElectricity.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvElectricity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvElectricity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvElectricity.Columns.AddRange(new DataGridViewColumn[] { colSelect, colElectricityRoom, colElectricityAccountName, colElectricityAccountNumber, colElectricityAmount, colElectricityStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvElectricity.DefaultCellStyle = dataGridViewCellStyle4;
            dgvElectricity.Dock = DockStyle.Fill;
            dgvElectricity.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvElectricity.Location = new Point(0, 0);
            dgvElectricity.Name = "dgvElectricity";
            dgvElectricity.RowHeadersVisible = false;
            dgvElectricity.RowHeadersWidth = 51;
            dgvElectricity.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvElectricity.Size = new Size(1286, 382);
            dgvElectricity.TabIndex = 13;
            dgvElectricity.CellContentClick += dgvElectricityBillData_CellContentClick;
            // 
            // colSelect
            // 
            colSelect.FillWeight = 15F;
            colSelect.HeaderText = "*";
            colSelect.MinimumWidth = 6;
            colSelect.Name = "colSelect";
            // 
            // colElectricityRoom
            // 
            colElectricityRoom.FillWeight = 50F;
            colElectricityRoom.HeaderText = "Room";
            colElectricityRoom.MinimumWidth = 6;
            colElectricityRoom.Name = "colElectricityRoom";
            // 
            // colElectricityAccountName
            // 
            colElectricityAccountName.HeaderText = "Account Name";
            colElectricityAccountName.MinimumWidth = 6;
            colElectricityAccountName.Name = "colElectricityAccountName";
            // 
            // colElectricityAccountNumber
            // 
            colElectricityAccountNumber.HeaderText = "Account Number";
            colElectricityAccountNumber.MinimumWidth = 6;
            colElectricityAccountNumber.Name = "colElectricityAccountNumber";
            // 
            // colElectricityAmount
            // 
            colElectricityAmount.HeaderText = "Amount";
            colElectricityAmount.MinimumWidth = 6;
            colElectricityAmount.Name = "colElectricityAmount";
            // 
            // colElectricityStatus
            // 
            colElectricityStatus.HeaderText = "Status";
            colElectricityStatus.MinimumWidth = 6;
            colElectricityStatus.Name = "colElectricityStatus";
            // 
            // panel5
            // 
            panel5.Controls.Add(label2);
            panel5.Controls.Add(btnSelectAllUnpaid);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(btnMarkPaid);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(3, 273);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5);
            panel5.Size = new Size(1286, 48);
            panel5.TabIndex = 21;
            panel5.Paint += panel5_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(7, 14);
            label2.Name = "label2";
            label2.Size = new Size(137, 23);
            label2.TabIndex = 0;
            label2.Text = "Rooms Accounts";
            // 
            // btnSelectAllUnpaid
            // 
            btnSelectAllUnpaid.Dock = DockStyle.Right;
            btnSelectAllUnpaid.FlatAppearance.BorderColor = Color.Black;
            btnSelectAllUnpaid.FlatStyle = FlatStyle.Flat;
            btnSelectAllUnpaid.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectAllUnpaid.Location = new Point(966, 5);
            btnSelectAllUnpaid.Margin = new Padding(5);
            btnSelectAllUnpaid.Name = "btnSelectAllUnpaid";
            btnSelectAllUnpaid.Size = new Size(163, 38);
            btnSelectAllUnpaid.TabIndex = 1;
            btnSelectAllUnpaid.Text = "Select all unpaid";
            btnSelectAllUnpaid.UseVisualStyleBackColor = true;
            btnSelectAllUnpaid.Click += btnSelectAllUnpaid_Click_1;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(1129, 5);
            panel7.Name = "panel7";
            panel7.Size = new Size(30, 38);
            panel7.TabIndex = 2;
            // 
            // btnMarkPaid
            // 
            btnMarkPaid.Dock = DockStyle.Right;
            btnMarkPaid.FlatAppearance.BorderColor = Color.Black;
            btnMarkPaid.FlatStyle = FlatStyle.Flat;
            btnMarkPaid.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMarkPaid.Location = new Point(1159, 5);
            btnMarkPaid.Margin = new Padding(5);
            btnMarkPaid.Name = "btnMarkPaid";
            btnMarkPaid.Size = new Size(122, 38);
            btnMarkPaid.TabIndex = 0;
            btnMarkPaid.Text = "Mark Paid";
            btnMarkPaid.UseVisualStyleBackColor = true;
            btnMarkPaid.Click += btnMarkPaid_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pnlElecAdminAccount);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 153);
            panel1.Name = "panel1";
            panel1.Size = new Size(1286, 120);
            panel1.TabIndex = 20;
            // 
            // pnlElecAdminAccount
            // 
            pnlElecAdminAccount.Dock = DockStyle.Top;
            pnlElecAdminAccount.Location = new Point(0, 27);
            pnlElecAdminAccount.Name = "pnlElecAdminAccount";
            pnlElecAdminAccount.Size = new Size(1286, 90);
            pnlElecAdminAccount.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1286, 27);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(22, 3);
            label1.Name = "label1";
            label1.Size = new Size(128, 23);
            label1.TabIndex = 0;
            label1.Text = "Admin Account";
            // 
            // pnlElectricityHeader
            // 
            pnlElectricityHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlElectricityHeader.Controls.Add(pnlDate);
            pnlElectricityHeader.Controls.Add(pnlHeaderElectricityTitle);
            pnlElectricityHeader.Dock = DockStyle.Top;
            pnlElectricityHeader.Location = new Point(3, 3);
            pnlElectricityHeader.Name = "pnlElectricityHeader";
            pnlElectricityHeader.Size = new Size(1286, 150);
            pnlElectricityHeader.TabIndex = 18;
            // 
            // pnlDate
            // 
            pnlDate.BorderStyle = BorderStyle.FixedSingle;
            pnlDate.Controls.Add(dtpElectricityDate);
            pnlDate.Controls.Add(lblElectricityDate);
            pnlDate.Dock = DockStyle.Left;
            pnlDate.Location = new Point(0, 60);
            pnlDate.Name = "pnlDate";
            pnlDate.Padding = new Padding(5);
            pnlDate.Size = new Size(250, 88);
            pnlDate.TabIndex = 1;
            // 
            // dtpElectricityDate
            // 
            dtpElectricityDate.CustomFormat = "MMMM yyyy";
            dtpElectricityDate.Dock = DockStyle.Fill;
            dtpElectricityDate.Font = new Font("Segoe UI", 10F);
            dtpElectricityDate.Format = DateTimePickerFormat.Custom;
            dtpElectricityDate.Location = new Point(5, 42);
            dtpElectricityDate.Name = "dtpElectricityDate";
            dtpElectricityDate.Size = new Size(238, 30);
            dtpElectricityDate.TabIndex = 28;
            dtpElectricityDate.Value = new DateTime(2026, 10, 12, 0, 0, 0, 0);
            dtpElectricityDate.ValueChanged += dtpElectricityDate_ValueChanged;
            // 
            // lblElectricityDate
            // 
            lblElectricityDate.Dock = DockStyle.Top;
            lblElectricityDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectricityDate.Location = new Point(5, 5);
            lblElectricityDate.Name = "lblElectricityDate";
            lblElectricityDate.Size = new Size(238, 37);
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
            pnlHeaderElectricityTitle.Size = new Size(1284, 60);
            pnlHeaderElectricityTitle.TabIndex = 0;
            // 
            // pnlElectricityTitle
            // 
            pnlElectricityTitle.Dock = DockStyle.Top;
            pnlElectricityTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlElectricityTitle.Location = new Point(0, 0);
            pnlElectricityTitle.Name = "pnlElectricityTitle";
            pnlElectricityTitle.Size = new Size(1282, 58);
            pnlElectricityTitle.TabIndex = 1;
            pnlElectricityTitle.Text = "Electricity Bill Monitor";
            pnlElectricityTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            BackColor = Color.FromArgb(25, 25, 70);
            Controls.Add(pnlUtilitiesContent);
            Name = "UtilitiesControl";
            Size = new Size(1300, 750);
            Load += UtilitiesControl_Load;
            pnlUtilitiesContent.ResumeLayout(false);
            tabUtilities.ResumeLayout(false);
            tabWater.ResumeLayout(false);
            pnlWaterContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWaterBillData).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            pnlWaterHeader.ResumeLayout(false);
            tblWaterActions.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            pnlTotalShares.ResumeLayout(false);
            pnlCurrentTotal.ResumeLayout(false);
            pnlWaterDate.ResumeLayout(false);
            pnlHeaderWaterTitle.ResumeLayout(false);
            tabElectricity.ResumeLayout(false);
            pnlElectricityContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvElectricity).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlElectricityHeader.ResumeLayout(false);
            pnlDate.ResumeLayout(false);
            pnlHeaderElectricityTitle.ResumeLayout(false);
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
        private Label pnlElectricityTitle;
        private Panel panel13;
        private Label lblOtherTitle;
        private Button btnAddOther;
        private Panel pnlElectricityContent;
        private DataGridViewTextBoxColumn colWaterRoom;
        private DataGridViewTextBoxColumn colWaterTenant;
        private DataGridViewTextBoxColumn colWaterDueDate;
        private DataGridViewTextBoxColumn colWaterAmount;
        private DataGridViewTextBoxColumn colWaterStatus;
        private DataGridView dgvElectricity;
        private Panel panel1;
        private Panel pnlElecAdminAccount;
        private Label label2;
        private Panel panel2;
        private Label label1;
        private Panel pnlWaterAdminAccount;
        private Panel panel4;
        private Panel panel6;
        private Label label3;
        private Label label4;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn colElectricityRoom;
        private DataGridViewTextBoxColumn colElectricityAccountName;
        private DataGridViewTextBoxColumn colElectricityAccountNumber;
        private DataGridViewTextBoxColumn colElectricityAmount;
        private DataGridViewButtonColumn colElectricityStatus;
        private Panel panel5;
        private Button btnMarkPaid;
        private Button btnSelectAllUnpaid;
        private Panel panel7;
        private Button btnGenerateBill;
        private Panel panel3;
    }
}
