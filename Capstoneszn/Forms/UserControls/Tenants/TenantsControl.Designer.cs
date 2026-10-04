namespace Capstoneszn.UserControls
{
    partial class TenantsControl
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
            pnlSearch = new Panel();
            lblTenantsTitle = new Label();
            pnlSearchContent = new Panel();
            pnlSearchContainer = new Panel();
            txtSearch = new TextBox();
            pnlTenantContent = new Panel();
            tblTenantSplit = new TableLayoutPanel();
            pnlTenantList = new Panel();
            dgvTenants = new DataGridView();
            colRoom = new DataGridViewTextBoxColumn();
            colFname = new DataGridViewTextBoxColumn();
            colMname = new DataGridViewTextBoxColumn();
            colLname = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colContactNumber = new DataGridViewTextBoxColumn();
            colDateOccupied = new DataGridViewTextBoxColumn();
            pnlTenantDetails = new Panel();
            pnlBillingSummary = new Panel();
            tblBillingSummary = new TableLayoutPanel();
            lblWaterBillValue = new Label();
            lblWaterBill = new Label();
            lblElectricityBillValue = new Label();
            lblElectricityBill = new Label();
            lblUtilitiesBillValue = new Label();
            lblUtilitiesBill = new Label();
            lblMaintenanceBillValue = new Label();
            lblMaintenanceBill = new Label();
            lblRentBillValue = new Label();
            lblRentBill = new Label();
            pnlBillingSummaryHeader = new Panel();
            lblBillingSummary = new Label();
            pnlTenantInfo = new Panel();
            tblTenantInfo = new TableLayoutPanel();
            lblContactNumberValue = new Label();
            lblAddressValue = new Label();
            lblLastNameValue = new Label();
            lblMiddleNameValue = new Label();
            lblFirstNameValue = new Label();
            lblDateOccupiedValue = new Label();
            lblRoomValue = new Label();
            lblContactNumberTitle = new Label();
            lblAddressTitle = new Label();
            lblLastNameTitle = new Label();
            lblMiddleNameTitle = new Label();
            lblFirstNameTitle = new Label();
            lblDateOccupiedTitle = new Label();
            lblRoomNumberTitle = new Label();
            pnlTenantDetailsHeader = new Panel();
            lblTenantDetailsTitle = new Label();
            btnCloseTenantDetails = new Button();
            btnEditTenant = new Button();
            pnlSearch.SuspendLayout();
            pnlSearchContent.SuspendLayout();
            pnlSearchContainer.SuspendLayout();
            pnlTenantContent.SuspendLayout();
            tblTenantSplit.SuspendLayout();
            pnlTenantList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenants).BeginInit();
            pnlTenantDetails.SuspendLayout();
            pnlBillingSummary.SuspendLayout();
            tblBillingSummary.SuspendLayout();
            pnlBillingSummaryHeader.SuspendLayout();
            pnlTenantInfo.SuspendLayout();
            tblTenantInfo.SuspendLayout();
            pnlTenantDetailsHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSearch
            // 
            pnlSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch.Controls.Add(lblTenantsTitle);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(5, 5);
            pnlSearch.Margin = new Padding(0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1290, 85);
            pnlSearch.TabIndex = 0;
            // 
            // lblTenantsTitle
            // 
            lblTenantsTitle.BorderStyle = BorderStyle.FixedSingle;
            lblTenantsTitle.Dock = DockStyle.Fill;
            lblTenantsTitle.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantsTitle.ForeColor = Color.White;
            lblTenantsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTenantsTitle.Location = new Point(0, 0);
            lblTenantsTitle.Name = "lblTenantsTitle";
            lblTenantsTitle.Size = new Size(1288, 83);
            lblTenantsTitle.TabIndex = 6;
            lblTenantsTitle.Text = "Tenants";
            lblTenantsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSearchContent
            // 
            pnlSearchContent.Controls.Add(pnlSearchContainer);
            pnlSearchContent.Dock = DockStyle.Top;
            pnlSearchContent.Location = new Point(5, 90);
            pnlSearchContent.Name = "pnlSearchContent";
            pnlSearchContent.Size = new Size(1290, 60);
            pnlSearchContent.TabIndex = 1;
            // 
            // pnlSearchContainer
            // 
            pnlSearchContainer.BackColor = Color.Transparent;
            pnlSearchContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchContainer.Controls.Add(txtSearch);
            pnlSearchContainer.Dock = DockStyle.Left;
            pnlSearchContainer.Location = new Point(0, 0);
            pnlSearchContainer.Name = "pnlSearchContainer";
            pnlSearchContainer.Size = new Size(408, 60);
            pnlSearchContainer.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.Location = new Point(14, 9);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(376, 40);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Search Tenant";
            txtSearch.TextAlign = HorizontalAlignment.Center;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // pnlTenantContent
            // 
            pnlTenantContent.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantContent.Controls.Add(tblTenantSplit);
            pnlTenantContent.Dock = DockStyle.Fill;
            pnlTenantContent.Location = new Point(5, 150);
            pnlTenantContent.Margin = new Padding(0);
            pnlTenantContent.Name = "pnlTenantContent";
            pnlTenantContent.Size = new Size(1290, 595);
            pnlTenantContent.TabIndex = 2;
            // 
            // tblTenantSplit
            // 
            tblTenantSplit.ColumnCount = 2;
            tblTenantSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tblTenantSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblTenantSplit.Controls.Add(pnlTenantList, 0, 0);
            tblTenantSplit.Controls.Add(pnlTenantDetails, 1, 0);
            tblTenantSplit.Dock = DockStyle.Fill;
            tblTenantSplit.Location = new Point(0, 0);
            tblTenantSplit.Margin = new Padding(0);
            tblTenantSplit.Name = "tblTenantSplit";
            tblTenantSplit.RowCount = 1;
            tblTenantSplit.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblTenantSplit.Size = new Size(1288, 593);
            tblTenantSplit.TabIndex = 0;
            // 
            // pnlTenantList
            // 
            pnlTenantList.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantList.Controls.Add(dgvTenants);
            pnlTenantList.Dock = DockStyle.Fill;
            pnlTenantList.Location = new Point(0, 0);
            pnlTenantList.Margin = new Padding(0);
            pnlTenantList.Name = "pnlTenantList";
            pnlTenantList.Padding = new Padding(10);
            pnlTenantList.Size = new Size(901, 593);
            pnlTenantList.TabIndex = 0;
            // 
            // dgvTenants
            // 
            dgvTenants.AllowUserToAddRows = false;
            dgvTenants.AllowUserToDeleteRows = false;
            dgvTenants.AllowUserToResizeColumns = false;
            dgvTenants.AllowUserToResizeRows = false;
            dgvTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTenants.BorderStyle = BorderStyle.None;
            dgvTenants.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTenants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTenants.ColumnHeadersHeight = 35;
            dgvTenants.Columns.AddRange(new DataGridViewColumn[] { colRoom, colFname, colMname, colLname, colAddress, colContactNumber, colDateOccupied });
            dgvTenants.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTenants.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTenants.Dock = DockStyle.Fill;
            dgvTenants.Location = new Point(10, 10);
            dgvTenants.MultiSelect = false;
            dgvTenants.Name = "dgvTenants";
            dgvTenants.ReadOnly = true;
            dgvTenants.RowHeadersVisible = false;
            dgvTenants.RowHeadersWidth = 51;
            dgvTenants.RowTemplate.Height = 35;
            dgvTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenants.Size = new Size(879, 571);
            dgvTenants.TabIndex = 4;
            dgvTenants.CellContentClick += dgvTenants_CellContentClick;
            // 
            // colRoom
            // 
            colRoom.HeaderText = "Room";
            colRoom.MinimumWidth = 6;
            colRoom.Name = "colRoom";
            colRoom.ReadOnly = true;
            // 
            // colFname
            // 
            colFname.HeaderText = "First Name";
            colFname.MinimumWidth = 6;
            colFname.Name = "colFname";
            colFname.ReadOnly = true;
            // 
            // colMname
            // 
            colMname.HeaderText = "Middle Name";
            colMname.MinimumWidth = 6;
            colMname.Name = "colMname";
            colMname.ReadOnly = true;
            // 
            // colLname
            // 
            colLname.HeaderText = "Last Name";
            colLname.MinimumWidth = 6;
            colLname.Name = "colLname";
            colLname.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.HeaderText = "Address";
            colAddress.MinimumWidth = 6;
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colContactNumber
            // 
            colContactNumber.HeaderText = "Contact Number";
            colContactNumber.MinimumWidth = 6;
            colContactNumber.Name = "colContactNumber";
            colContactNumber.ReadOnly = true;
            // 
            // colDateOccupied
            // 
            colDateOccupied.HeaderText = "Date Occupied";
            colDateOccupied.MinimumWidth = 6;
            colDateOccupied.Name = "colDateOccupied";
            colDateOccupied.ReadOnly = true;
            // 
            // pnlTenantDetails
            // 
            pnlTenantDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantDetails.Controls.Add(pnlBillingSummary);
            pnlTenantDetails.Controls.Add(pnlTenantInfo);
            pnlTenantDetails.Controls.Add(pnlTenantDetailsHeader);
            pnlTenantDetails.Dock = DockStyle.Fill;
            pnlTenantDetails.Location = new Point(901, 0);
            pnlTenantDetails.Margin = new Padding(0);
            pnlTenantDetails.Name = "pnlTenantDetails";
            pnlTenantDetails.Padding = new Padding(10);
            pnlTenantDetails.Size = new Size(387, 593);
            pnlTenantDetails.TabIndex = 1;
            // 
            // pnlBillingSummary
            // 
            pnlBillingSummary.AutoScroll = true;
            pnlBillingSummary.Controls.Add(tblBillingSummary);
            pnlBillingSummary.Controls.Add(pnlBillingSummaryHeader);
            pnlBillingSummary.Dock = DockStyle.Fill;
            pnlBillingSummary.Location = new Point(10, 360);
            pnlBillingSummary.Name = "pnlBillingSummary";
            pnlBillingSummary.Size = new Size(365, 221);
            pnlBillingSummary.TabIndex = 4;
            // 
            // tblBillingSummary
            // 
            tblBillingSummary.ColumnCount = 2;
            tblBillingSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblBillingSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblBillingSummary.Controls.Add(lblWaterBillValue, 1, 4);
            tblBillingSummary.Controls.Add(lblWaterBill, 0, 4);
            tblBillingSummary.Controls.Add(lblElectricityBillValue, 1, 3);
            tblBillingSummary.Controls.Add(lblElectricityBill, 0, 3);
            tblBillingSummary.Controls.Add(lblUtilitiesBillValue, 1, 2);
            tblBillingSummary.Controls.Add(lblUtilitiesBill, 0, 2);
            tblBillingSummary.Controls.Add(lblMaintenanceBillValue, 1, 1);
            tblBillingSummary.Controls.Add(lblMaintenanceBill, 0, 1);
            tblBillingSummary.Controls.Add(lblRentBillValue, 1, 0);
            tblBillingSummary.Controls.Add(lblRentBill, 0, 0);
            tblBillingSummary.Dock = DockStyle.Fill;
            tblBillingSummary.Location = new Point(0, 40);
            tblBillingSummary.Name = "tblBillingSummary";
            tblBillingSummary.RowCount = 5;
            tblBillingSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBillingSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBillingSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBillingSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBillingSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblBillingSummary.Size = new Size(365, 181);
            tblBillingSummary.TabIndex = 12;
            // 
            // lblWaterBillValue
            // 
            lblWaterBillValue.AutoSize = true;
            lblWaterBillValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWaterBillValue.ForeColor = Color.White;
            lblWaterBillValue.ImageAlign = ContentAlignment.MiddleRight;
            lblWaterBillValue.Location = new Point(149, 144);
            lblWaterBillValue.Name = "lblWaterBillValue";
            lblWaterBillValue.Size = new Size(19, 25);
            lblWaterBillValue.TabIndex = 12;
            lblWaterBillValue.Text = "-";
            lblWaterBillValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWaterBill
            // 
            lblWaterBill.AutoSize = true;
            lblWaterBill.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWaterBill.ForeColor = Color.White;
            lblWaterBill.ImageAlign = ContentAlignment.MiddleRight;
            lblWaterBill.Location = new Point(3, 144);
            lblWaterBill.Name = "lblWaterBill";
            lblWaterBill.Size = new Size(85, 25);
            lblWaterBill.TabIndex = 11;
            lblWaterBill.Text = "Water Bill";
            lblWaterBill.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblElectricityBillValue
            // 
            lblElectricityBillValue.AutoSize = true;
            lblElectricityBillValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectricityBillValue.ForeColor = Color.White;
            lblElectricityBillValue.ImageAlign = ContentAlignment.MiddleRight;
            lblElectricityBillValue.Location = new Point(149, 108);
            lblElectricityBillValue.Name = "lblElectricityBillValue";
            lblElectricityBillValue.Size = new Size(19, 25);
            lblElectricityBillValue.TabIndex = 10;
            lblElectricityBillValue.Text = "-";
            lblElectricityBillValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblElectricityBill
            // 
            lblElectricityBill.AutoSize = true;
            lblElectricityBill.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectricityBill.ForeColor = Color.White;
            lblElectricityBill.ImageAlign = ContentAlignment.MiddleRight;
            lblElectricityBill.Location = new Point(3, 108);
            lblElectricityBill.Name = "lblElectricityBill";
            lblElectricityBill.Size = new Size(112, 25);
            lblElectricityBill.TabIndex = 9;
            lblElectricityBill.Text = "Electricity Bill";
            lblElectricityBill.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUtilitiesBillValue
            // 
            lblUtilitiesBillValue.AutoSize = true;
            lblUtilitiesBillValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilitiesBillValue.ForeColor = Color.White;
            lblUtilitiesBillValue.ImageAlign = ContentAlignment.MiddleRight;
            lblUtilitiesBillValue.Location = new Point(149, 72);
            lblUtilitiesBillValue.Name = "lblUtilitiesBillValue";
            lblUtilitiesBillValue.Size = new Size(19, 25);
            lblUtilitiesBillValue.TabIndex = 8;
            lblUtilitiesBillValue.Text = "-";
            lblUtilitiesBillValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUtilitiesBill
            // 
            lblUtilitiesBill.AutoSize = true;
            lblUtilitiesBill.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilitiesBill.ForeColor = Color.White;
            lblUtilitiesBill.ImageAlign = ContentAlignment.MiddleRight;
            lblUtilitiesBill.Location = new Point(3, 72);
            lblUtilitiesBill.Name = "lblUtilitiesBill";
            lblUtilitiesBill.Size = new Size(96, 25);
            lblUtilitiesBill.TabIndex = 7;
            lblUtilitiesBill.Text = "Utilities Bill";
            lblUtilitiesBill.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaintenanceBillValue
            // 
            lblMaintenanceBillValue.AutoSize = true;
            lblMaintenanceBillValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceBillValue.ForeColor = Color.White;
            lblMaintenanceBillValue.ImageAlign = ContentAlignment.MiddleRight;
            lblMaintenanceBillValue.Location = new Point(149, 36);
            lblMaintenanceBillValue.Name = "lblMaintenanceBillValue";
            lblMaintenanceBillValue.Size = new Size(19, 25);
            lblMaintenanceBillValue.TabIndex = 6;
            lblMaintenanceBillValue.Text = "-";
            lblMaintenanceBillValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaintenanceBill
            // 
            lblMaintenanceBill.AutoSize = true;
            lblMaintenanceBill.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceBill.ForeColor = Color.White;
            lblMaintenanceBill.ImageAlign = ContentAlignment.MiddleRight;
            lblMaintenanceBill.Location = new Point(3, 36);
            lblMaintenanceBill.Name = "lblMaintenanceBill";
            lblMaintenanceBill.Size = new Size(139, 25);
            lblMaintenanceBill.TabIndex = 5;
            lblMaintenanceBill.Text = "Maintenance Bill";
            lblMaintenanceBill.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRentBillValue
            // 
            lblRentBillValue.AutoSize = true;
            lblRentBillValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRentBillValue.ForeColor = Color.White;
            lblRentBillValue.ImageAlign = ContentAlignment.MiddleRight;
            lblRentBillValue.Location = new Point(149, 0);
            lblRentBillValue.Name = "lblRentBillValue";
            lblRentBillValue.Size = new Size(19, 25);
            lblRentBillValue.TabIndex = 3;
            lblRentBillValue.Text = "-";
            lblRentBillValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRentBill
            // 
            lblRentBill.AutoSize = true;
            lblRentBill.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRentBill.ForeColor = Color.White;
            lblRentBill.ImageAlign = ContentAlignment.MiddleRight;
            lblRentBill.Location = new Point(3, 0);
            lblRentBill.Name = "lblRentBill";
            lblRentBill.Size = new Size(74, 25);
            lblRentBill.TabIndex = 4;
            lblRentBill.Text = "Rent Bill";
            lblRentBill.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBillingSummaryHeader
            // 
            pnlBillingSummaryHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlBillingSummaryHeader.Controls.Add(lblBillingSummary);
            pnlBillingSummaryHeader.Dock = DockStyle.Top;
            pnlBillingSummaryHeader.Location = new Point(0, 0);
            pnlBillingSummaryHeader.Name = "pnlBillingSummaryHeader";
            pnlBillingSummaryHeader.Size = new Size(365, 40);
            pnlBillingSummaryHeader.TabIndex = 11;
            // 
            // lblBillingSummary
            // 
            lblBillingSummary.Dock = DockStyle.Fill;
            lblBillingSummary.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillingSummary.ForeColor = Color.White;
            lblBillingSummary.ImageAlign = ContentAlignment.MiddleRight;
            lblBillingSummary.Location = new Point(0, 0);
            lblBillingSummary.Name = "lblBillingSummary";
            lblBillingSummary.Size = new Size(363, 38);
            lblBillingSummary.TabIndex = 11;
            lblBillingSummary.Text = "Billing Summary";
            lblBillingSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTenantInfo
            // 
            pnlTenantInfo.AutoScroll = true;
            pnlTenantInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantInfo.Controls.Add(tblTenantInfo);
            pnlTenantInfo.Dock = DockStyle.Top;
            pnlTenantInfo.Location = new Point(10, 60);
            pnlTenantInfo.Margin = new Padding(0);
            pnlTenantInfo.Name = "pnlTenantInfo";
            pnlTenantInfo.Padding = new Padding(5);
            pnlTenantInfo.Size = new Size(365, 300);
            pnlTenantInfo.TabIndex = 1;
            // 
            // tblTenantInfo
            // 
            tblTenantInfo.AutoScroll = true;
            tblTenantInfo.ColumnCount = 2;
            tblTenantInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblTenantInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblTenantInfo.Controls.Add(lblContactNumberValue, 1, 6);
            tblTenantInfo.Controls.Add(lblAddressValue, 1, 5);
            tblTenantInfo.Controls.Add(lblLastNameValue, 1, 4);
            tblTenantInfo.Controls.Add(lblMiddleNameValue, 1, 3);
            tblTenantInfo.Controls.Add(lblFirstNameValue, 1, 2);
            tblTenantInfo.Controls.Add(lblDateOccupiedValue, 1, 1);
            tblTenantInfo.Controls.Add(lblRoomValue, 1, 0);
            tblTenantInfo.Controls.Add(lblContactNumberTitle, 0, 6);
            tblTenantInfo.Controls.Add(lblAddressTitle, 0, 5);
            tblTenantInfo.Controls.Add(lblLastNameTitle, 0, 4);
            tblTenantInfo.Controls.Add(lblMiddleNameTitle, 0, 3);
            tblTenantInfo.Controls.Add(lblFirstNameTitle, 0, 2);
            tblTenantInfo.Controls.Add(lblDateOccupiedTitle, 0, 1);
            tblTenantInfo.Controls.Add(lblRoomNumberTitle, 0, 0);
            tblTenantInfo.Dock = DockStyle.Fill;
            tblTenantInfo.Location = new Point(5, 5);
            tblTenantInfo.Name = "tblTenantInfo";
            tblTenantInfo.RowCount = 7;
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblTenantInfo.Size = new Size(353, 288);
            tblTenantInfo.TabIndex = 2;
            // 
            // lblContactNumberValue
            // 
            lblContactNumberValue.AutoSize = true;
            lblContactNumberValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNumberValue.ForeColor = Color.White;
            lblContactNumberValue.ImageAlign = ContentAlignment.MiddleRight;
            lblContactNumberValue.Location = new Point(144, 246);
            lblContactNumberValue.Name = "lblContactNumberValue";
            lblContactNumberValue.Size = new Size(19, 25);
            lblContactNumberValue.TabIndex = 22;
            lblContactNumberValue.Text = "-";
            lblContactNumberValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAddressValue
            // 
            lblAddressValue.AutoSize = true;
            lblAddressValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddressValue.ForeColor = Color.White;
            lblAddressValue.ImageAlign = ContentAlignment.MiddleRight;
            lblAddressValue.Location = new Point(144, 205);
            lblAddressValue.Name = "lblAddressValue";
            lblAddressValue.Size = new Size(19, 25);
            lblAddressValue.TabIndex = 21;
            lblAddressValue.Text = "-";
            lblAddressValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLastNameValue
            // 
            lblLastNameValue.AutoSize = true;
            lblLastNameValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastNameValue.ForeColor = Color.White;
            lblLastNameValue.ImageAlign = ContentAlignment.MiddleRight;
            lblLastNameValue.Location = new Point(144, 164);
            lblLastNameValue.Name = "lblLastNameValue";
            lblLastNameValue.Size = new Size(19, 25);
            lblLastNameValue.TabIndex = 20;
            lblLastNameValue.Text = "-";
            lblLastNameValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMiddleNameValue
            // 
            lblMiddleNameValue.AutoSize = true;
            lblMiddleNameValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMiddleNameValue.ForeColor = Color.White;
            lblMiddleNameValue.ImageAlign = ContentAlignment.MiddleRight;
            lblMiddleNameValue.Location = new Point(144, 123);
            lblMiddleNameValue.Name = "lblMiddleNameValue";
            lblMiddleNameValue.Size = new Size(19, 25);
            lblMiddleNameValue.TabIndex = 19;
            lblMiddleNameValue.Text = "-";
            lblMiddleNameValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFirstNameValue
            // 
            lblFirstNameValue.AutoSize = true;
            lblFirstNameValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstNameValue.ForeColor = Color.White;
            lblFirstNameValue.ImageAlign = ContentAlignment.MiddleRight;
            lblFirstNameValue.Location = new Point(144, 82);
            lblFirstNameValue.Name = "lblFirstNameValue";
            lblFirstNameValue.Size = new Size(19, 25);
            lblFirstNameValue.TabIndex = 18;
            lblFirstNameValue.Text = "-";
            lblFirstNameValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateOccupiedValue
            // 
            lblDateOccupiedValue.AutoSize = true;
            lblDateOccupiedValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateOccupiedValue.ForeColor = Color.White;
            lblDateOccupiedValue.ImageAlign = ContentAlignment.MiddleRight;
            lblDateOccupiedValue.Location = new Point(144, 41);
            lblDateOccupiedValue.Name = "lblDateOccupiedValue";
            lblDateOccupiedValue.Size = new Size(19, 25);
            lblDateOccupiedValue.TabIndex = 17;
            lblDateOccupiedValue.Text = "-";
            lblDateOccupiedValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomValue
            // 
            lblRoomValue.AutoSize = true;
            lblRoomValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomValue.ForeColor = Color.White;
            lblRoomValue.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomValue.Location = new Point(144, 0);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(19, 25);
            lblRoomValue.TabIndex = 16;
            lblRoomValue.Text = "-";
            lblRoomValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblContactNumberTitle
            // 
            lblContactNumberTitle.AutoSize = true;
            lblContactNumberTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNumberTitle.ForeColor = Color.White;
            lblContactNumberTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblContactNumberTitle.Location = new Point(3, 246);
            lblContactNumberTitle.Name = "lblContactNumberTitle";
            lblContactNumberTitle.Size = new Size(77, 42);
            lblContactNumberTitle.TabIndex = 15;
            lblContactNumberTitle.Text = "Contact Number";
            lblContactNumberTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAddressTitle
            // 
            lblAddressTitle.AutoSize = true;
            lblAddressTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddressTitle.ForeColor = Color.White;
            lblAddressTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddressTitle.Location = new Point(3, 205);
            lblAddressTitle.Name = "lblAddressTitle";
            lblAddressTitle.Size = new Size(77, 25);
            lblAddressTitle.TabIndex = 13;
            lblAddressTitle.Text = "Address";
            lblAddressTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLastNameTitle
            // 
            lblLastNameTitle.AutoSize = true;
            lblLastNameTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastNameTitle.ForeColor = Color.White;
            lblLastNameTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblLastNameTitle.Location = new Point(3, 164);
            lblLastNameTitle.Name = "lblLastNameTitle";
            lblLastNameTitle.Size = new Size(95, 25);
            lblLastNameTitle.TabIndex = 11;
            lblLastNameTitle.Text = "Last Name";
            lblLastNameTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMiddleNameTitle
            // 
            lblMiddleNameTitle.AutoSize = true;
            lblMiddleNameTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMiddleNameTitle.ForeColor = Color.White;
            lblMiddleNameTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMiddleNameTitle.Location = new Point(3, 123);
            lblMiddleNameTitle.Name = "lblMiddleNameTitle";
            lblMiddleNameTitle.Size = new Size(119, 25);
            lblMiddleNameTitle.TabIndex = 9;
            lblMiddleNameTitle.Text = "Middle Name";
            lblMiddleNameTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFirstNameTitle
            // 
            lblFirstNameTitle.AutoSize = true;
            lblFirstNameTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstNameTitle.ForeColor = Color.White;
            lblFirstNameTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblFirstNameTitle.Location = new Point(3, 82);
            lblFirstNameTitle.Name = "lblFirstNameTitle";
            lblFirstNameTitle.Size = new Size(97, 25);
            lblFirstNameTitle.TabIndex = 7;
            lblFirstNameTitle.Text = "First Name";
            lblFirstNameTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateOccupiedTitle
            // 
            lblDateOccupiedTitle.AutoSize = true;
            lblDateOccupiedTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateOccupiedTitle.ForeColor = Color.White;
            lblDateOccupiedTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblDateOccupiedTitle.Location = new Point(3, 41);
            lblDateOccupiedTitle.Name = "lblDateOccupiedTitle";
            lblDateOccupiedTitle.Size = new Size(129, 25);
            lblDateOccupiedTitle.TabIndex = 5;
            lblDateOccupiedTitle.Text = "Date Occupied";
            lblDateOccupiedTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomNumberTitle
            // 
            lblRoomNumberTitle.AutoSize = true;
            lblRoomNumberTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumberTitle.ForeColor = Color.White;
            lblRoomNumberTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomNumberTitle.Location = new Point(3, 0);
            lblRoomNumberTitle.Name = "lblRoomNumberTitle";
            lblRoomNumberTitle.Size = new Size(130, 25);
            lblRoomNumberTitle.TabIndex = 4;
            lblRoomNumberTitle.Text = "Room Number";
            lblRoomNumberTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTenantDetailsHeader
            // 
            pnlTenantDetailsHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantDetailsHeader.Controls.Add(lblTenantDetailsTitle);
            pnlTenantDetailsHeader.Controls.Add(btnCloseTenantDetails);
            pnlTenantDetailsHeader.Controls.Add(btnEditTenant);
            pnlTenantDetailsHeader.Dock = DockStyle.Top;
            pnlTenantDetailsHeader.Location = new Point(10, 10);
            pnlTenantDetailsHeader.Margin = new Padding(0);
            pnlTenantDetailsHeader.Name = "pnlTenantDetailsHeader";
            pnlTenantDetailsHeader.Padding = new Padding(5);
            pnlTenantDetailsHeader.Size = new Size(365, 50);
            pnlTenantDetailsHeader.TabIndex = 0;
            // 
            // lblTenantDetailsTitle
            // 
            lblTenantDetailsTitle.Dock = DockStyle.Fill;
            lblTenantDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantDetailsTitle.ForeColor = Color.White;
            lblTenantDetailsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTenantDetailsTitle.Location = new Point(99, 5);
            lblTenantDetailsTitle.Name = "lblTenantDetailsTitle";
            lblTenantDetailsTitle.Padding = new Padding(0, 0, 50, 0);
            lblTenantDetailsTitle.Size = new Size(221, 38);
            lblTenantDetailsTitle.TabIndex = 6;
            lblTenantDetailsTitle.Text = "Tenant Information";
            lblTenantDetailsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCloseTenantDetails
            // 
            btnCloseTenantDetails.Cursor = Cursors.Hand;
            btnCloseTenantDetails.Dock = DockStyle.Right;
            btnCloseTenantDetails.FlatStyle = FlatStyle.Flat;
            btnCloseTenantDetails.ForeColor = Color.White;
            btnCloseTenantDetails.Location = new Point(320, 5);
            btnCloseTenantDetails.Name = "btnCloseTenantDetails";
            btnCloseTenantDetails.Size = new Size(38, 38);
            btnCloseTenantDetails.TabIndex = 5;
            btnCloseTenantDetails.TabStop = false;
            btnCloseTenantDetails.Text = "X";
            btnCloseTenantDetails.UseVisualStyleBackColor = true;
            btnCloseTenantDetails.Click += btnCloseTenantDetails_Click;
            // 
            // btnEditTenant
            // 
            btnEditTenant.Cursor = Cursors.Hand;
            btnEditTenant.Dock = DockStyle.Left;
            btnEditTenant.Location = new Point(5, 5);
            btnEditTenant.Name = "btnEditTenant";
            btnEditTenant.Size = new Size(94, 38);
            btnEditTenant.TabIndex = 0;
            btnEditTenant.Text = "Edit";
            btnEditTenant.UseVisualStyleBackColor = true;
            btnEditTenant.Click += btnEditTenant_Click;
            // 
            // TenantsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlTenantContent);
            Controls.Add(pnlSearchContent);
            Controls.Add(pnlSearch);
            Name = "TenantsControl";
            Padding = new Padding(5);
            Size = new Size(1300, 750);
            Load += TenantsControl_Load;
            pnlSearch.ResumeLayout(false);
            pnlSearchContent.ResumeLayout(false);
            pnlSearchContainer.ResumeLayout(false);
            pnlSearchContainer.PerformLayout();
            pnlTenantContent.ResumeLayout(false);
            tblTenantSplit.ResumeLayout(false);
            pnlTenantList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTenants).EndInit();
            pnlTenantDetails.ResumeLayout(false);
            pnlBillingSummary.ResumeLayout(false);
            tblBillingSummary.ResumeLayout(false);
            tblBillingSummary.PerformLayout();
            pnlBillingSummaryHeader.ResumeLayout(false);
            pnlTenantInfo.ResumeLayout(false);
            tblTenantInfo.ResumeLayout(false);
            tblTenantInfo.PerformLayout();
            pnlTenantDetailsHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSearch;
        private Panel pnlSearchContent;
        private Panel pnlSearchContainer;
        private TextBox txtSearch;
        private Panel pnlTenantContent;
        private TableLayoutPanel tblTenantSplit;
        private Panel pnlTenantList;
        private DataGridView dgvTenants;
        private Panel pnlTenantDetails;
        private Panel pnlBillingSummary;
        private Panel pnlBillingSummaryHeader;
        private Label lblBillingSummary;
        private Panel pnlTenantInfo;
        private TableLayoutPanel tblTenantInfo;
        private Label lblMiddleNameTitle;
        private Label lblFirstNameTitle;
        private Label lblDateOccupiedTitle;
        private Label lblRoomNumberTitle;
        private Panel pnlTenantDetailsHeader;
        private Button btnCloseTenantDetails;
        private Button btnEditTenant;
        private Label lblTenantsTitle;
        private Label lblTenantDetailsTitle;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colFname;
        private DataGridViewTextBoxColumn colMname;
        private DataGridViewTextBoxColumn colLname;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colContactNumber;
        private DataGridViewTextBoxColumn colDateOccupied;
        private TableLayoutPanel tblBillingSummary;
        private Label lblWaterBillValue;
        private Label lblWaterBill;
        private Label lblElectricityBillValue;
        private Label lblElectricityBill;
        private Label lblUtilitiesBillValue;
        private Label lblUtilitiesBill;
        private Label lblMaintenanceBillValue;
        private Label lblMaintenanceBill;
        private Label lblRentBillValue;
        private Label lblRentBill;
        private Label lblContactNumberTitle;
        private Label lblAddressTitle;
        private Label lblLastNameTitle;
        private Label lblDateOccupiedValue;
        private Label lblRoomValue;
        private Label lblContactNumberValue;
        private Label lblAddressValue;
        private Label lblLastNameValue;
        private Label lblMiddleNameValue;
        private Label lblFirstNameValue;
    }
}
