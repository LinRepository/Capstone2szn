namespace Capstoneszn.Forms.TenantForms
{
    partial class TenantAccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTenantSub = new Label();
            lblTenantName = new Label();
            lblBadge = new Label();
            tlpCards = new TableLayoutPanel();
            pnlCardRent = new Panel();
            lblCardRentNote = new Label();
            lblCardRentValue = new Label();
            lblCardRentTitle = new Label();
            pnlCardWater = new Panel();
            lblCardWaterNote = new Label();
            lblCardWaterValue = new Label();
            lblCardWaterTitle = new Label();
            pnlCardMaint = new Panel();
            lblCardMaintNote = new Label();
            lblCardMaintValue = new Label();
            lblCardMaintTitle = new Label();
            pnlCardElec = new Panel();
            lblCardElecNote = new Label();
            lblCardElecValue = new Label();
            lblCardElecTitle = new Label();
            pnlCardCredit = new Panel();
            lblCardCreditNote = new Label();
            lblCardCreditValue = new Label();
            lblCardCreditTitle = new Label();
            pnlTabs = new Panel();
            btnTabPayments = new Button();
            btnTabBills = new Button();
            pnlBody = new Panel();
            pnlBills = new Panel();
            dgvBills = new DataGridView();
            pnlBillsTotal = new Panel();
            lblBillsTotal = new Label();
            pnlBillsFilter = new Panel();
            lblBillsCount = new Label();
            cboBillStatus = new ComboBox();
            lblBillStatus = new Label();
            cboBillCategory = new ComboBox();
            lblBillCategory = new Label();
            pnlPayments = new Panel();
            dgvPayments = new DataGridView();
            colPayDate = new DataGridViewTextBoxColumn();
            colPayReceipt = new DataGridViewTextBoxColumn();
            colPayCategory = new DataGridViewTextBoxColumn();
            colPayMethod = new DataGridViewTextBoxColumn();
            colPayPaidBy = new DataGridViewTextBoxColumn();
            colPayAmount = new DataGridViewTextBoxColumn();
            colPayStatus = new DataGridViewTextBoxColumn();
            pnlPayTotal = new Panel();
            lblPayTotal = new Label();
            pnlPayFilter = new Panel();
            lblPayCount = new Label();
            cboPayCategory = new ComboBox();
            lblPayCategory = new Label();
            pnlFooter = new Panel();
            lblFooterNote = new Label();
            btnClose = new Button();
            colBillPeriod = new DataGridViewTextBoxColumn();
            colBillRoom = new DataGridViewTextBoxColumn();
            colBillDesc = new DataGridViewTextBoxColumn();
            colBillDue = new DataGridViewTextBoxColumn();
            colBillShare = new DataGridViewTextBoxColumn();
            colBillPaid = new DataGridViewTextBoxColumn();
            colBillBalance = new DataGridViewTextBoxColumn();
            colBillStatus = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            tlpCards.SuspendLayout();
            pnlCardRent.SuspendLayout();
            pnlCardWater.SuspendLayout();
            pnlCardMaint.SuspendLayout();
            pnlCardElec.SuspendLayout();
            pnlCardCredit.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlBills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
            pnlBillsTotal.SuspendLayout();
            pnlBillsFilter.SuspendLayout();
            pnlPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            pnlPayTotal.SuspendLayout();
            pnlPayFilter.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTenantSub);
            pnlHeader.Controls.Add(lblTenantName);
            pnlHeader.Controls.Add(lblBadge);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(22, 12, 22, 8);
            pnlHeader.Size = new Size(1332, 84);
            pnlHeader.TabIndex = 0;
            // 
            // lblTenantSub
            // 
            lblTenantSub.Dock = DockStyle.Top;
            lblTenantSub.Font = new Font("Segoe UI", 10.5F);
            lblTenantSub.ForeColor = Color.FromArgb(201, 203, 232);
            lblTenantSub.Location = new Point(22, 50);
            lblTenantSub.Name = "lblTenantSub";
            lblTenantSub.Size = new Size(1178, 26);
            lblTenantSub.TabIndex = 1;
            lblTenantSub.Text = "-";
            // 
            // lblTenantName
            // 
            lblTenantName.Dock = DockStyle.Top;
            lblTenantName.Font = new Font("Segoe UI Semibold", 16F);
            lblTenantName.ForeColor = Color.White;
            lblTenantName.Location = new Point(22, 12);
            lblTenantName.Name = "lblTenantName";
            lblTenantName.Size = new Size(1178, 38);
            lblTenantName.TabIndex = 0;
            lblTenantName.Text = "-";
            // 
            // lblBadge
            // 
            lblBadge.BackColor = Color.FromArgb(46, 125, 50);
            lblBadge.Dock = DockStyle.Right;
            lblBadge.Font = new Font("Segoe UI Semibold", 10F);
            lblBadge.ForeColor = Color.White;
            lblBadge.Location = new Point(1200, 12);
            lblBadge.Name = "lblBadge";
            lblBadge.Size = new Size(110, 64);
            lblBadge.TabIndex = 2;
            lblBadge.Text = "Active";
            lblBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpCards
            // 
            tlpCards.ColumnCount = 5;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpCards.Controls.Add(pnlCardRent, 0, 0);
            tlpCards.Controls.Add(pnlCardWater, 1, 0);
            tlpCards.Controls.Add(pnlCardMaint, 2, 0);
            tlpCards.Controls.Add(pnlCardElec, 3, 0);
            tlpCards.Controls.Add(pnlCardCredit, 4, 0);
            tlpCards.Dock = DockStyle.Top;
            tlpCards.Location = new Point(0, 84);
            tlpCards.Name = "tlpCards";
            tlpCards.Padding = new Padding(17, 6, 17, 6);
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCards.Size = new Size(1332, 100);
            tlpCards.TabIndex = 1;
            // 
            // pnlCardRent
            // 
            pnlCardRent.BackColor = Color.FromArgb(35, 35, 90);
            pnlCardRent.Controls.Add(lblCardRentNote);
            pnlCardRent.Controls.Add(lblCardRentValue);
            pnlCardRent.Controls.Add(lblCardRentTitle);
            pnlCardRent.Dock = DockStyle.Fill;
            pnlCardRent.Location = new Point(22, 11);
            pnlCardRent.Margin = new Padding(5);
            pnlCardRent.Name = "pnlCardRent";
            pnlCardRent.Padding = new Padding(10, 6, 10, 6);
            pnlCardRent.Size = new Size(249, 78);
            pnlCardRent.TabIndex = 0;
            // 
            // lblCardRentNote
            // 
            lblCardRentNote.Dock = DockStyle.Top;
            lblCardRentNote.Font = new Font("Segoe UI", 8.5F);
            lblCardRentNote.ForeColor = Color.FromArgb(160, 160, 210);
            lblCardRentNote.Location = new Point(10, 58);
            lblCardRentNote.Name = "lblCardRentNote";
            lblCardRentNote.Size = new Size(229, 20);
            lblCardRentNote.TabIndex = 2;
            lblCardRentNote.Text = "rent only · + advance / − owing";
            // 
            // lblCardRentValue
            // 
            lblCardRentValue.Dock = DockStyle.Top;
            lblCardRentValue.Font = new Font("Segoe UI Semibold", 14F);
            lblCardRentValue.ForeColor = Color.White;
            lblCardRentValue.Location = new Point(10, 26);
            lblCardRentValue.Name = "lblCardRentValue";
            lblCardRentValue.Size = new Size(229, 32);
            lblCardRentValue.TabIndex = 1;
            lblCardRentValue.Text = "-";
            // 
            // lblCardRentTitle
            // 
            lblCardRentTitle.Dock = DockStyle.Top;
            lblCardRentTitle.Font = new Font("Segoe UI", 9F);
            lblCardRentTitle.ForeColor = Color.FromArgb(201, 203, 232);
            lblCardRentTitle.Location = new Point(10, 6);
            lblCardRentTitle.Name = "lblCardRentTitle";
            lblCardRentTitle.Size = new Size(229, 20);
            lblCardRentTitle.TabIndex = 0;
            lblCardRentTitle.Text = "Rent Available Balance";
            // 
            // pnlCardWater
            // 
            pnlCardWater.BackColor = Color.FromArgb(35, 35, 90);
            pnlCardWater.Controls.Add(lblCardWaterNote);
            pnlCardWater.Controls.Add(lblCardWaterValue);
            pnlCardWater.Controls.Add(lblCardWaterTitle);
            pnlCardWater.Dock = DockStyle.Fill;
            pnlCardWater.Location = new Point(281, 11);
            pnlCardWater.Margin = new Padding(5);
            pnlCardWater.Name = "pnlCardWater";
            pnlCardWater.Padding = new Padding(10, 6, 10, 6);
            pnlCardWater.Size = new Size(249, 78);
            pnlCardWater.TabIndex = 1;
            // 
            // lblCardWaterNote
            // 
            lblCardWaterNote.Dock = DockStyle.Top;
            lblCardWaterNote.Font = new Font("Segoe UI", 8.5F);
            lblCardWaterNote.ForeColor = Color.FromArgb(160, 160, 210);
            lblCardWaterNote.Location = new Point(10, 58);
            lblCardWaterNote.Name = "lblCardWaterNote";
            lblCardWaterNote.Size = new Size(229, 20);
            lblCardWaterNote.TabIndex = 2;
            lblCardWaterNote.Text = "-";
            // 
            // lblCardWaterValue
            // 
            lblCardWaterValue.Dock = DockStyle.Top;
            lblCardWaterValue.Font = new Font("Segoe UI Semibold", 14F);
            lblCardWaterValue.ForeColor = Color.White;
            lblCardWaterValue.Location = new Point(10, 26);
            lblCardWaterValue.Name = "lblCardWaterValue";
            lblCardWaterValue.Size = new Size(229, 32);
            lblCardWaterValue.TabIndex = 1;
            lblCardWaterValue.Text = "-";
            // 
            // lblCardWaterTitle
            // 
            lblCardWaterTitle.Dock = DockStyle.Top;
            lblCardWaterTitle.Font = new Font("Segoe UI", 9F);
            lblCardWaterTitle.ForeColor = Color.FromArgb(201, 203, 232);
            lblCardWaterTitle.Location = new Point(10, 6);
            lblCardWaterTitle.Name = "lblCardWaterTitle";
            lblCardWaterTitle.Size = new Size(229, 20);
            lblCardWaterTitle.TabIndex = 0;
            lblCardWaterTitle.Text = "Water owed";
            // 
            // pnlCardMaint
            // 
            pnlCardMaint.BackColor = Color.FromArgb(35, 35, 90);
            pnlCardMaint.Controls.Add(lblCardMaintNote);
            pnlCardMaint.Controls.Add(lblCardMaintValue);
            pnlCardMaint.Controls.Add(lblCardMaintTitle);
            pnlCardMaint.Dock = DockStyle.Fill;
            pnlCardMaint.Location = new Point(540, 11);
            pnlCardMaint.Margin = new Padding(5);
            pnlCardMaint.Name = "pnlCardMaint";
            pnlCardMaint.Padding = new Padding(10, 6, 10, 6);
            pnlCardMaint.Size = new Size(249, 78);
            pnlCardMaint.TabIndex = 2;
            // 
            // lblCardMaintNote
            // 
            lblCardMaintNote.Dock = DockStyle.Top;
            lblCardMaintNote.Font = new Font("Segoe UI", 8.5F);
            lblCardMaintNote.ForeColor = Color.FromArgb(160, 160, 210);
            lblCardMaintNote.Location = new Point(10, 58);
            lblCardMaintNote.Name = "lblCardMaintNote";
            lblCardMaintNote.Size = new Size(229, 20);
            lblCardMaintNote.TabIndex = 2;
            lblCardMaintNote.Text = "-";
            // 
            // lblCardMaintValue
            // 
            lblCardMaintValue.Dock = DockStyle.Top;
            lblCardMaintValue.Font = new Font("Segoe UI Semibold", 14F);
            lblCardMaintValue.ForeColor = Color.White;
            lblCardMaintValue.Location = new Point(10, 26);
            lblCardMaintValue.Name = "lblCardMaintValue";
            lblCardMaintValue.Size = new Size(229, 32);
            lblCardMaintValue.TabIndex = 1;
            lblCardMaintValue.Text = "-";
            // 
            // lblCardMaintTitle
            // 
            lblCardMaintTitle.Dock = DockStyle.Top;
            lblCardMaintTitle.Font = new Font("Segoe UI", 9F);
            lblCardMaintTitle.ForeColor = Color.FromArgb(201, 203, 232);
            lblCardMaintTitle.Location = new Point(10, 6);
            lblCardMaintTitle.Name = "lblCardMaintTitle";
            lblCardMaintTitle.Size = new Size(229, 20);
            lblCardMaintTitle.TabIndex = 0;
            lblCardMaintTitle.Text = "Maintenance owed";
            // 
            // pnlCardElec
            // 
            pnlCardElec.BackColor = Color.FromArgb(35, 35, 90);
            pnlCardElec.Controls.Add(lblCardElecNote);
            pnlCardElec.Controls.Add(lblCardElecValue);
            pnlCardElec.Controls.Add(lblCardElecTitle);
            pnlCardElec.Dock = DockStyle.Fill;
            pnlCardElec.Location = new Point(799, 11);
            pnlCardElec.Margin = new Padding(5);
            pnlCardElec.Name = "pnlCardElec";
            pnlCardElec.Padding = new Padding(10, 6, 10, 6);
            pnlCardElec.Size = new Size(249, 78);
            pnlCardElec.TabIndex = 3;
            // 
            // lblCardElecNote
            // 
            lblCardElecNote.Dock = DockStyle.Top;
            lblCardElecNote.Font = new Font("Segoe UI", 8.5F);
            lblCardElecNote.ForeColor = Color.FromArgb(160, 160, 210);
            lblCardElecNote.Location = new Point(10, 58);
            lblCardElecNote.Name = "lblCardElecNote";
            lblCardElecNote.Size = new Size(229, 20);
            lblCardElecNote.TabIndex = 2;
            lblCardElecNote.Text = "-";
            // 
            // lblCardElecValue
            // 
            lblCardElecValue.Dock = DockStyle.Top;
            lblCardElecValue.Font = new Font("Segoe UI Semibold", 14F);
            lblCardElecValue.ForeColor = Color.White;
            lblCardElecValue.Location = new Point(10, 26);
            lblCardElecValue.Name = "lblCardElecValue";
            lblCardElecValue.Size = new Size(229, 32);
            lblCardElecValue.TabIndex = 1;
            lblCardElecValue.Text = "-";
            // 
            // lblCardElecTitle
            // 
            lblCardElecTitle.Dock = DockStyle.Top;
            lblCardElecTitle.Font = new Font("Segoe UI", 9F);
            lblCardElecTitle.ForeColor = Color.FromArgb(201, 203, 232);
            lblCardElecTitle.Location = new Point(10, 6);
            lblCardElecTitle.Name = "lblCardElecTitle";
            lblCardElecTitle.Size = new Size(229, 20);
            lblCardElecTitle.TabIndex = 0;
            lblCardElecTitle.Text = "Electricity (room)";
            // 
            // pnlCardCredit
            // 
            pnlCardCredit.BackColor = Color.FromArgb(35, 35, 90);
            pnlCardCredit.Controls.Add(lblCardCreditNote);
            pnlCardCredit.Controls.Add(lblCardCreditValue);
            pnlCardCredit.Controls.Add(lblCardCreditTitle);
            pnlCardCredit.Dock = DockStyle.Fill;
            pnlCardCredit.Location = new Point(1058, 11);
            pnlCardCredit.Margin = new Padding(5);
            pnlCardCredit.Name = "pnlCardCredit";
            pnlCardCredit.Padding = new Padding(10, 6, 10, 6);
            pnlCardCredit.Size = new Size(252, 78);
            pnlCardCredit.TabIndex = 4;
            // 
            // lblCardCreditNote
            // 
            lblCardCreditNote.Dock = DockStyle.Top;
            lblCardCreditNote.Font = new Font("Segoe UI", 8.5F);
            lblCardCreditNote.ForeColor = Color.FromArgb(160, 160, 210);
            lblCardCreditNote.Location = new Point(10, 58);
            lblCardCreditNote.Name = "lblCardCreditNote";
            lblCardCreditNote.Size = new Size(232, 20);
            lblCardCreditNote.TabIndex = 2;
            lblCardCreditNote.Text = "rent + water credit";
            // 
            // lblCardCreditValue
            // 
            lblCardCreditValue.Dock = DockStyle.Top;
            lblCardCreditValue.Font = new Font("Segoe UI Semibold", 14F);
            lblCardCreditValue.ForeColor = Color.White;
            lblCardCreditValue.Location = new Point(10, 26);
            lblCardCreditValue.Name = "lblCardCreditValue";
            lblCardCreditValue.Size = new Size(232, 32);
            lblCardCreditValue.TabIndex = 1;
            lblCardCreditValue.Text = "-";
            // 
            // lblCardCreditTitle
            // 
            lblCardCreditTitle.Dock = DockStyle.Top;
            lblCardCreditTitle.Font = new Font("Segoe UI", 9F);
            lblCardCreditTitle.ForeColor = Color.FromArgb(201, 203, 232);
            lblCardCreditTitle.Location = new Point(10, 6);
            lblCardCreditTitle.Name = "lblCardCreditTitle";
            lblCardCreditTitle.Size = new Size(232, 20);
            lblCardCreditTitle.TabIndex = 0;
            lblCardCreditTitle.Text = "Advance credit";
            // 
            // pnlTabs
            // 
            pnlTabs.Controls.Add(btnTabPayments);
            pnlTabs.Controls.Add(btnTabBills);
            pnlTabs.Dock = DockStyle.Top;
            pnlTabs.Location = new Point(0, 184);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Padding = new Padding(22, 6, 22, 0);
            pnlTabs.Size = new Size(1332, 44);
            pnlTabs.TabIndex = 2;
            // 
            // btnTabPayments
            // 
            btnTabPayments.Dock = DockStyle.Left;
            btnTabPayments.Font = new Font("Segoe UI", 10.5F);
            btnTabPayments.Location = new Point(142, 6);
            btnTabPayments.Name = "btnTabPayments";
            btnTabPayments.Size = new Size(130, 38);
            btnTabPayments.TabIndex = 1;
            btnTabPayments.Text = "Payments";
            btnTabPayments.UseVisualStyleBackColor = true;
            btnTabPayments.Click += btnTabPayments_Click;
            // 
            // btnTabBills
            // 
            btnTabBills.Dock = DockStyle.Left;
            btnTabBills.Font = new Font("Segoe UI", 10.5F);
            btnTabBills.Location = new Point(22, 6);
            btnTabBills.Name = "btnTabBills";
            btnTabBills.Size = new Size(120, 38);
            btnTabBills.TabIndex = 0;
            btnTabBills.Text = "Bills";
            btnTabBills.UseVisualStyleBackColor = true;
            btnTabBills.Click += btnTabBills_Click;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(pnlBills);
            pnlBody.Controls.Add(pnlPayments);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 228);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(22, 0, 22, 0);
            pnlBody.Size = new Size(1332, 396);
            pnlBody.TabIndex = 3;
            // 
            // pnlBills
            // 
            pnlBills.BackColor = Color.FromArgb(35, 35, 90);
            pnlBills.Controls.Add(dgvBills);
            pnlBills.Controls.Add(pnlBillsTotal);
            pnlBills.Controls.Add(pnlBillsFilter);
            pnlBills.Dock = DockStyle.Fill;
            pnlBills.Location = new Point(22, 0);
            pnlBills.Name = "pnlBills";
            pnlBills.Padding = new Padding(10, 0, 10, 0);
            pnlBills.Size = new Size(1288, 396);
            pnlBills.TabIndex = 0;
            // 
            // dgvBills
            // 
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.AllowUserToResizeRows = false;
            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBills.ColumnHeadersHeight = 29;
            dgvBills.Columns.AddRange(new DataGridViewColumn[] { colBillPeriod, colBillRoom, colBillDesc, colBillDue, colBillShare, colBillPaid, colBillBalance, colBillStatus });
            dgvBills.Dock = DockStyle.Fill;
            dgvBills.Location = new Point(10, 44);
            dgvBills.MultiSelect = false;
            dgvBills.Name = "dgvBills";
            dgvBills.ReadOnly = true;
            dgvBills.RowHeadersVisible = false;
            dgvBills.RowHeadersWidth = 51;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.Size = new Size(1268, 318);
            dgvBills.TabIndex = 1;
            dgvBills.CellFormatting += dgvBills_CellFormatting;
            // 
            // pnlBillsTotal
            // 
            pnlBillsTotal.Controls.Add(lblBillsTotal);
            pnlBillsTotal.Dock = DockStyle.Bottom;
            pnlBillsTotal.Location = new Point(10, 362);
            pnlBillsTotal.Name = "pnlBillsTotal";
            pnlBillsTotal.Size = new Size(1268, 34);
            pnlBillsTotal.TabIndex = 2;
            // 
            // lblBillsTotal
            // 
            lblBillsTotal.Dock = DockStyle.Fill;
            lblBillsTotal.Font = new Font("Segoe UI Semibold", 10F);
            lblBillsTotal.ForeColor = Color.White;
            lblBillsTotal.Location = new Point(0, 0);
            lblBillsTotal.Name = "lblBillsTotal";
            lblBillsTotal.Size = new Size(1268, 34);
            lblBillsTotal.TabIndex = 0;
            lblBillsTotal.Text = "-";
            lblBillsTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlBillsFilter
            // 
            pnlBillsFilter.Controls.Add(lblBillsCount);
            pnlBillsFilter.Controls.Add(cboBillStatus);
            pnlBillsFilter.Controls.Add(lblBillStatus);
            pnlBillsFilter.Controls.Add(cboBillCategory);
            pnlBillsFilter.Controls.Add(lblBillCategory);
            pnlBillsFilter.Dock = DockStyle.Top;
            pnlBillsFilter.Location = new Point(10, 0);
            pnlBillsFilter.Name = "pnlBillsFilter";
            pnlBillsFilter.Size = new Size(1268, 44);
            pnlBillsFilter.TabIndex = 0;
            // 
            // lblBillsCount
            // 
            lblBillsCount.Dock = DockStyle.Right;
            lblBillsCount.Font = new Font("Segoe UI", 9.5F);
            lblBillsCount.ForeColor = Color.FromArgb(201, 203, 232);
            lblBillsCount.Location = new Point(968, 0);
            lblBillsCount.Name = "lblBillsCount";
            lblBillsCount.Size = new Size(300, 44);
            lblBillsCount.TabIndex = 4;
            lblBillsCount.Text = "-";
            lblBillsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboBillStatus
            // 
            cboBillStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBillStatus.Font = new Font("Segoe UI", 10F);
            cboBillStatus.Location = new Point(322, 8);
            cboBillStatus.Name = "cboBillStatus";
            cboBillStatus.Size = new Size(170, 31);
            cboBillStatus.TabIndex = 3;
            cboBillStatus.SelectedIndexChanged += BillFilter_Changed;
            // 
            // lblBillStatus
            // 
            lblBillStatus.AutoSize = true;
            lblBillStatus.Font = new Font("Segoe UI", 10F);
            lblBillStatus.ForeColor = Color.White;
            lblBillStatus.Location = new Point(262, 12);
            lblBillStatus.Name = "lblBillStatus";
            lblBillStatus.Size = new Size(56, 23);
            lblBillStatus.TabIndex = 2;
            lblBillStatus.Text = "Status";
            // 
            // cboBillCategory
            // 
            cboBillCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBillCategory.Font = new Font("Segoe UI", 10F);
            cboBillCategory.Location = new Point(82, 8);
            cboBillCategory.Name = "cboBillCategory";
            cboBillCategory.Size = new Size(160, 31);
            cboBillCategory.TabIndex = 1;
            cboBillCategory.SelectedIndexChanged += BillFilter_Changed;
            // 
            // lblBillCategory
            // 
            lblBillCategory.AutoSize = true;
            lblBillCategory.Font = new Font("Segoe UI", 10F);
            lblBillCategory.ForeColor = Color.White;
            lblBillCategory.Location = new Point(0, 12);
            lblBillCategory.Name = "lblBillCategory";
            lblBillCategory.Size = new Size(79, 23);
            lblBillCategory.TabIndex = 0;
            lblBillCategory.Text = "Category";
            // 
            // pnlPayments
            // 
            pnlPayments.BackColor = Color.FromArgb(35, 35, 90);
            pnlPayments.Controls.Add(dgvPayments);
            pnlPayments.Controls.Add(pnlPayTotal);
            pnlPayments.Controls.Add(pnlPayFilter);
            pnlPayments.Dock = DockStyle.Fill;
            pnlPayments.Location = new Point(22, 0);
            pnlPayments.Name = "pnlPayments";
            pnlPayments.Padding = new Padding(10, 0, 10, 0);
            pnlPayments.Size = new Size(1288, 396);
            pnlPayments.TabIndex = 1;
            pnlPayments.Visible = false;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.AllowUserToResizeRows = false;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.ColumnHeadersHeight = 29;
            dgvPayments.Columns.AddRange(new DataGridViewColumn[] { colPayDate, colPayReceipt, colPayCategory, colPayMethod, colPayPaidBy, colPayAmount, colPayStatus });
            dgvPayments.Dock = DockStyle.Fill;
            dgvPayments.Location = new Point(10, 44);
            dgvPayments.MultiSelect = false;
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.RowHeadersWidth = 51;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new Size(1268, 318);
            dgvPayments.TabIndex = 1;
            dgvPayments.CellFormatting += dgvPayments_CellFormatting;
            // 
            // colPayDate
            // 
            colPayDate.DataPropertyName = "PaymentDate";
            colPayDate.FillWeight = 80F;
            colPayDate.HeaderText = "Date";
            colPayDate.MinimumWidth = 6;
            colPayDate.Name = "colPayDate";
            colPayDate.ReadOnly = true;
            // 
            // colPayReceipt
            // 
            colPayReceipt.DataPropertyName = "ReceiptNo";
            colPayReceipt.FillWeight = 110F;
            colPayReceipt.HeaderText = "Receipt No.";
            colPayReceipt.MinimumWidth = 6;
            colPayReceipt.Name = "colPayReceipt";
            colPayReceipt.ReadOnly = true;
            // 
            // colPayCategory
            // 
            colPayCategory.DataPropertyName = "Categories";
            colPayCategory.HeaderText = "Category";
            colPayCategory.MinimumWidth = 6;
            colPayCategory.Name = "colPayCategory";
            colPayCategory.ReadOnly = true;
            // 
            // colPayMethod
            // 
            colPayMethod.DataPropertyName = "Method";
            colPayMethod.FillWeight = 60F;
            colPayMethod.HeaderText = "Method";
            colPayMethod.MinimumWidth = 6;
            colPayMethod.Name = "colPayMethod";
            colPayMethod.ReadOnly = true;
            // 
            // colPayPaidBy
            // 
            colPayPaidBy.DataPropertyName = "PaidBy";
            colPayPaidBy.FillWeight = 130F;
            colPayPaidBy.HeaderText = "Paid By";
            colPayPaidBy.MinimumWidth = 6;
            colPayPaidBy.Name = "colPayPaidBy";
            colPayPaidBy.ReadOnly = true;
            // 
            // colPayAmount
            // 
            colPayAmount.DataPropertyName = "Amount";
            colPayAmount.FillWeight = 90F;
            colPayAmount.HeaderText = "Amount (your part)";
            colPayAmount.MinimumWidth = 6;
            colPayAmount.Name = "colPayAmount";
            colPayAmount.ReadOnly = true;
            // 
            // colPayStatus
            // 
            colPayStatus.DataPropertyName = "Status";
            colPayStatus.FillWeight = 60F;
            colPayStatus.HeaderText = "Status";
            colPayStatus.MinimumWidth = 6;
            colPayStatus.Name = "colPayStatus";
            colPayStatus.ReadOnly = true;
            // 
            // pnlPayTotal
            // 
            pnlPayTotal.Controls.Add(lblPayTotal);
            pnlPayTotal.Dock = DockStyle.Bottom;
            pnlPayTotal.Location = new Point(10, 362);
            pnlPayTotal.Name = "pnlPayTotal";
            pnlPayTotal.Size = new Size(1268, 34);
            pnlPayTotal.TabIndex = 2;
            // 
            // lblPayTotal
            // 
            lblPayTotal.Dock = DockStyle.Fill;
            lblPayTotal.Font = new Font("Segoe UI Semibold", 10F);
            lblPayTotal.ForeColor = Color.White;
            lblPayTotal.Location = new Point(0, 0);
            lblPayTotal.Name = "lblPayTotal";
            lblPayTotal.Size = new Size(1268, 34);
            lblPayTotal.TabIndex = 0;
            lblPayTotal.Text = "-";
            lblPayTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlPayFilter
            // 
            pnlPayFilter.Controls.Add(lblPayCount);
            pnlPayFilter.Controls.Add(cboPayCategory);
            pnlPayFilter.Controls.Add(lblPayCategory);
            pnlPayFilter.Dock = DockStyle.Top;
            pnlPayFilter.Location = new Point(10, 0);
            pnlPayFilter.Name = "pnlPayFilter";
            pnlPayFilter.Size = new Size(1268, 44);
            pnlPayFilter.TabIndex = 0;
            // 
            // lblPayCount
            // 
            lblPayCount.Dock = DockStyle.Right;
            lblPayCount.Font = new Font("Segoe UI", 9.5F);
            lblPayCount.ForeColor = Color.FromArgb(201, 203, 232);
            lblPayCount.Location = new Point(868, 0);
            lblPayCount.Name = "lblPayCount";
            lblPayCount.Size = new Size(400, 44);
            lblPayCount.TabIndex = 2;
            lblPayCount.Text = "-";
            lblPayCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboPayCategory
            // 
            cboPayCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPayCategory.Font = new Font("Segoe UI", 10F);
            cboPayCategory.Location = new Point(82, 8);
            cboPayCategory.Name = "cboPayCategory";
            cboPayCategory.Size = new Size(160, 31);
            cboPayCategory.TabIndex = 1;
            cboPayCategory.SelectedIndexChanged += PayFilter_Changed;
            // 
            // lblPayCategory
            // 
            lblPayCategory.AutoSize = true;
            lblPayCategory.Font = new Font("Segoe UI", 10F);
            lblPayCategory.ForeColor = Color.White;
            lblPayCategory.Location = new Point(0, 12);
            lblPayCategory.Name = "lblPayCategory";
            lblPayCategory.Size = new Size(79, 23);
            lblPayCategory.TabIndex = 0;
            lblPayCategory.Text = "Category";
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(lblFooterNote);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 624);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(22, 10, 22, 10);
            pnlFooter.Size = new Size(1332, 60);
            pnlFooter.TabIndex = 4;
            // 
            // lblFooterNote
            // 
            lblFooterNote.Dock = DockStyle.Fill;
            lblFooterNote.Font = new Font("Segoe UI", 9F);
            lblFooterNote.ForeColor = Color.FromArgb(201, 203, 232);
            lblFooterNote.Location = new Point(22, 10);
            lblFooterNote.Name = "lblFooterNote";
            lblFooterNote.Size = new Size(1158, 40);
            lblFooterNote.TabIndex = 0;
            lblFooterNote.Text = "Read-only · payments are recorded in Bill Management";
            lblFooterNote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.Font = new Font("Segoe UI", 10.5F);
            btnClose.Location = new Point(1180, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 40);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // colBillPeriod
            // 
            colBillPeriod.DataPropertyName = "Period";
            colBillPeriod.FillWeight = 120F;
            colBillPeriod.HeaderText = "Period";
            colBillPeriod.MinimumWidth = 6;
            colBillPeriod.Name = "colBillPeriod";
            colBillPeriod.ReadOnly = true;
            // 
            // colBillRoom
            // 
            colBillRoom.DataPropertyName = "Room";
            colBillRoom.FillWeight = 70F;
            colBillRoom.HeaderText = "Room";
            colBillRoom.MinimumWidth = 6;
            colBillRoom.Name = "colBillRoom";
            colBillRoom.ReadOnly = true;
            // 
            // colBillDesc
            // 
            colBillDesc.DataPropertyName = "Description";
            colBillDesc.FillWeight = 160F;
            colBillDesc.HeaderText = "Description";
            colBillDesc.MinimumWidth = 6;
            colBillDesc.Name = "colBillDesc";
            colBillDesc.ReadOnly = true;
            // 
            // colBillDue
            // 
            colBillDue.DataPropertyName = "DueDate";
            colBillDue.FillWeight = 80F;
            colBillDue.HeaderText = "Due Date";
            colBillDue.MinimumWidth = 6;
            colBillDue.Name = "colBillDue";
            colBillDue.ReadOnly = true;
            // 
            // colBillShare
            // 
            colBillShare.DataPropertyName = "Share";
            colBillShare.FillWeight = 75F;
            colBillShare.HeaderText = "Your Share";
            colBillShare.MinimumWidth = 6;
            colBillShare.Name = "colBillShare";
            colBillShare.ReadOnly = true;
            // 
            // colBillPaid
            // 
            colBillPaid.DataPropertyName = "Paid";
            colBillPaid.FillWeight = 75F;
            colBillPaid.HeaderText = "Paid";
            colBillPaid.MinimumWidth = 6;
            colBillPaid.Name = "colBillPaid";
            colBillPaid.ReadOnly = true;
            // 
            // colBillBalance
            // 
            colBillBalance.DataPropertyName = "Balance";
            colBillBalance.FillWeight = 75F;
            colBillBalance.HeaderText = "Balance";
            colBillBalance.MinimumWidth = 6;
            colBillBalance.Name = "colBillBalance";
            colBillBalance.ReadOnly = true;
            // 
            // colBillStatus
            // 
            colBillStatus.DataPropertyName = "Status";
            colBillStatus.FillWeight = 80F;
            colBillStatus.HeaderText = "Status";
            colBillStatus.MinimumWidth = 6;
            colBillStatus.Name = "colBillStatus";
            colBillStatus.ReadOnly = true;
            // 
            // TenantAccountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            CancelButton = btnClose;
            ClientSize = new Size(1332, 684);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlTabs);
            Controls.Add(tlpCards);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TenantAccountForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tenant Account";
            Load += TenantAccountForm_Load;
            pnlHeader.ResumeLayout(false);
            tlpCards.ResumeLayout(false);
            pnlCardRent.ResumeLayout(false);
            pnlCardWater.ResumeLayout(false);
            pnlCardMaint.ResumeLayout(false);
            pnlCardElec.ResumeLayout(false);
            pnlCardCredit.ResumeLayout(false);
            pnlTabs.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlBills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            pnlBillsTotal.ResumeLayout(false);
            pnlBillsFilter.ResumeLayout(false);
            pnlBillsFilter.PerformLayout();
            pnlPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            pnlPayTotal.ResumeLayout(false);
            pnlPayFilter.ResumeLayout(false);
            pnlPayFilter.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTenantSub;
        private Label lblTenantName;
        private Label lblBadge;
        private TableLayoutPanel tlpCards;
        private Panel pnlCardRent;
        private Label lblCardRentNote;
        private Label lblCardRentValue;
        private Label lblCardRentTitle;
        private Panel pnlCardWater;
        private Label lblCardWaterNote;
        private Label lblCardWaterValue;
        private Label lblCardWaterTitle;
        private Panel pnlCardMaint;
        private Label lblCardMaintNote;
        private Label lblCardMaintValue;
        private Label lblCardMaintTitle;
        private Panel pnlCardElec;
        private Label lblCardElecNote;
        private Label lblCardElecValue;
        private Label lblCardElecTitle;
        private Panel pnlCardCredit;
        private Label lblCardCreditNote;
        private Label lblCardCreditValue;
        private Label lblCardCreditTitle;
        private Panel pnlTabs;
        private Button btnTabPayments;
        private Button btnTabBills;
        private Panel pnlBody;
        private Panel pnlBills;
        private DataGridView dgvBills;
        private Panel pnlBillsTotal;
        private Label lblBillsTotal;
        private Panel pnlBillsFilter;
        private Label lblBillsCount;
        private ComboBox cboBillStatus;
        private Label lblBillStatus;
        private ComboBox cboBillCategory;
        private Label lblBillCategory;
        private Panel pnlPayments;
        private DataGridView dgvPayments;
        private DataGridViewTextBoxColumn colPayDate;
        private DataGridViewTextBoxColumn colPayReceipt;
        private DataGridViewTextBoxColumn colPayCategory;
        private DataGridViewTextBoxColumn colPayMethod;
        private DataGridViewTextBoxColumn colPayPaidBy;
        private DataGridViewTextBoxColumn colPayAmount;
        private DataGridViewTextBoxColumn colPayStatus;
        private Panel pnlPayTotal;
        private Label lblPayTotal;
        private Panel pnlPayFilter;
        private Label lblPayCount;
        private ComboBox cboPayCategory;
        private Label lblPayCategory;
        private Panel pnlFooter;
        private Label lblFooterNote;
        private Button btnClose;
        private DataGridViewTextBoxColumn colBillPeriod;
        private DataGridViewTextBoxColumn colBillRoom;
        private DataGridViewTextBoxColumn colBillDesc;
        private DataGridViewTextBoxColumn colBillDue;
        private DataGridViewTextBoxColumn colBillShare;
        private DataGridViewTextBoxColumn colBillPaid;
        private DataGridViewTextBoxColumn colBillBalance;
        private DataGridViewTextBoxColumn colBillStatus;
    }
}