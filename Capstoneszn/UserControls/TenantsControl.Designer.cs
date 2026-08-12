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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlSearch = new Panel();
            pnlSearchContainer = new Panel();
            txtSearch = new TextBox();
            picSearch = new PictureBox();
            pnlTenantContent = new Panel();
            tblTenantSplit = new TableLayoutPanel();
            pnlTenantList = new Panel();
            dgvTenants = new DataGridView();
            colRoom = new DataGridViewTextBoxColumn();
            colTenantName = new DataGridViewTextBoxColumn();
            colDateOccupied = new DataGridViewTextBoxColumn();
            colContact = new DataGridViewTextBoxColumn();
            pnlTenantDetails = new Panel();
            pnlTenantInfo = new Panel();
            tblTenantInfo = new TableLayoutPanel();
            lblContactNumberValue = new Label();
            lblContactNumberTitle = new Label();
            lblTenantNameValue = new Label();
            lblTenantNameTitle = new Label();
            lblDateOccupiedValue = new Label();
            lblDateOccupiedTitle = new Label();
            lblRoomNumberValue = new Label();
            lblRoomNumberTitle = new Label();
            pnlTenantDetailsHeader = new Panel();
            btnCloseTenantDetails = new Button();
            lblTenantDetailsTitle = new Label();
            pnlTenantActions = new Panel();
            pnlBillingSummary = new Panel();
            lblBillingSummary = new Label();
            btnEditTenant = new Button();
            btnCancelTenant = new Button();
            btnSaveTenant = new Button();
            pnlSearch.SuspendLayout();
            pnlSearchContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            pnlTenantContent.SuspendLayout();
            tblTenantSplit.SuspendLayout();
            pnlTenantList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenants).BeginInit();
            pnlTenantDetails.SuspendLayout();
            pnlTenantInfo.SuspendLayout();
            tblTenantInfo.SuspendLayout();
            pnlTenantDetailsHeader.SuspendLayout();
            pnlTenantActions.SuspendLayout();
            pnlBillingSummary.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(pnlSearchContainer);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(20, 20);
            pnlSearch.Margin = new Padding(0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1260, 90);
            pnlSearch.TabIndex = 0;
            // 
            // pnlSearchContainer
            // 
            pnlSearchContainer.BackColor = Color.White;
            pnlSearchContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchContainer.Controls.Add(txtSearch);
            pnlSearchContainer.Controls.Add(picSearch);
            pnlSearchContainer.Location = new Point(28, 14);
            pnlSearchContainer.Name = "pnlSearchContainer";
            pnlSearchContainer.Size = new Size(450, 61);
            pnlSearchContainer.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(14, 10);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(376, 40);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Search Tenant";
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // picSearch
            // 
            picSearch.Location = new Point(396, 10);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(40, 40);
            picSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picSearch.TabIndex = 1;
            picSearch.TabStop = false;
            // 
            // pnlTenantContent
            // 
            pnlTenantContent.Controls.Add(tblTenantSplit);
            pnlTenantContent.Dock = DockStyle.Fill;
            pnlTenantContent.Location = new Point(20, 110);
            pnlTenantContent.Margin = new Padding(0);
            pnlTenantContent.Name = "pnlTenantContent";
            pnlTenantContent.Size = new Size(1260, 620);
            pnlTenantContent.TabIndex = 1;
            // 
            // tblTenantSplit
            // 
            tblTenantSplit.ColumnCount = 2;
            tblTenantSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblTenantSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblTenantSplit.Controls.Add(pnlTenantList, 0, 0);
            tblTenantSplit.Controls.Add(pnlTenantDetails, 1, 0);
            tblTenantSplit.Dock = DockStyle.Fill;
            tblTenantSplit.Location = new Point(0, 0);
            tblTenantSplit.Margin = new Padding(0);
            tblTenantSplit.Name = "tblTenantSplit";
            tblTenantSplit.RowCount = 1;
            tblTenantSplit.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblTenantSplit.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblTenantSplit.Size = new Size(1260, 620);
            tblTenantSplit.TabIndex = 0;
            // 
            // pnlTenantList
            // 
            pnlTenantList.Controls.Add(dgvTenants);
            pnlTenantList.Dock = DockStyle.Fill;
            pnlTenantList.Location = new Point(0, 0);
            pnlTenantList.Margin = new Padding(0);
            pnlTenantList.Name = "pnlTenantList";
            pnlTenantList.Padding = new Padding(10);
            pnlTenantList.Size = new Size(756, 620);
            pnlTenantList.TabIndex = 0;
            // 
            // dgvTenants
            // 
            dgvTenants.AllowUserToAddRows = false;
            dgvTenants.AllowUserToDeleteRows = false;
            dgvTenants.AllowUserToResizeColumns = false;
            dgvTenants.AllowUserToResizeRows = false;
            dgvTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTenants.BackgroundColor = Color.FromArgb(11, 20, 38);
            dgvTenants.BorderStyle = BorderStyle.None;
            dgvTenants.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTenants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTenants.ColumnHeadersHeight = 35;
            dgvTenants.Columns.AddRange(new DataGridViewColumn[] { colRoom, colTenantName, colDateOccupied, colContact });
            dgvTenants.Cursor = Cursors.Hand;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTenants.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTenants.Dock = DockStyle.Fill;
            dgvTenants.Location = new Point(10, 10);
            dgvTenants.MultiSelect = false;
            dgvTenants.Name = "dgvTenants";
            dgvTenants.ReadOnly = true;
            dgvTenants.RowHeadersVisible = false;
            dgvTenants.RowHeadersWidth = 51;
            dgvTenants.RowTemplate.Height = 35;
            dgvTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenants.Size = new Size(736, 600);
            dgvTenants.TabIndex = 4;
            // 
            // colRoom
            // 
            colRoom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoom.FillWeight = 15F;
            colRoom.HeaderText = "Room";
            colRoom.MinimumWidth = 6;
            colRoom.Name = "colRoom";
            colRoom.ReadOnly = true;
            // 
            // colTenantName
            // 
            colTenantName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTenantName.FillWeight = 35F;
            colTenantName.HeaderText = "Tenant Name";
            colTenantName.MinimumWidth = 6;
            colTenantName.Name = "colTenantName";
            colTenantName.ReadOnly = true;
            // 
            // colDateOccupied
            // 
            colDateOccupied.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDateOccupied.FillWeight = 25F;
            colDateOccupied.HeaderText = "Date Occupied";
            colDateOccupied.MinimumWidth = 6;
            colDateOccupied.Name = "colDateOccupied";
            colDateOccupied.ReadOnly = true;
            // 
            // colContact
            // 
            colContact.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colContact.FillWeight = 25F;
            colContact.HeaderText = "Contacts";
            colContact.MinimumWidth = 6;
            colContact.Name = "colContact";
            colContact.ReadOnly = true;
            // 
            // pnlTenantDetails
            // 
            pnlTenantDetails.Controls.Add(pnlBillingSummary);
            pnlTenantDetails.Controls.Add(pnlTenantActions);
            pnlTenantDetails.Controls.Add(pnlTenantInfo);
            pnlTenantDetails.Controls.Add(pnlTenantDetailsHeader);
            pnlTenantDetails.Dock = DockStyle.Fill;
            pnlTenantDetails.Location = new Point(756, 0);
            pnlTenantDetails.Margin = new Padding(0);
            pnlTenantDetails.Name = "pnlTenantDetails";
            pnlTenantDetails.Padding = new Padding(10);
            pnlTenantDetails.Size = new Size(504, 620);
            pnlTenantDetails.TabIndex = 1;
            // 
            // pnlTenantInfo
            // 
            pnlTenantInfo.Controls.Add(tblTenantInfo);
            pnlTenantInfo.Dock = DockStyle.Top;
            pnlTenantInfo.Location = new Point(10, 60);
            pnlTenantInfo.Margin = new Padding(0);
            pnlTenantInfo.Name = "pnlTenantInfo";
            pnlTenantInfo.Padding = new Padding(5);
            pnlTenantInfo.Size = new Size(484, 250);
            pnlTenantInfo.TabIndex = 1;
            // 
            // tblTenantInfo
            // 
            tblTenantInfo.ColumnCount = 2;
            tblTenantInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblTenantInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblTenantInfo.Controls.Add(lblContactNumberValue, 1, 3);
            tblTenantInfo.Controls.Add(lblContactNumberTitle, 0, 3);
            tblTenantInfo.Controls.Add(lblTenantNameValue, 1, 2);
            tblTenantInfo.Controls.Add(lblTenantNameTitle, 0, 2);
            tblTenantInfo.Controls.Add(lblDateOccupiedValue, 1, 1);
            tblTenantInfo.Controls.Add(lblDateOccupiedTitle, 0, 1);
            tblTenantInfo.Controls.Add(lblRoomNumberValue, 1, 0);
            tblTenantInfo.Controls.Add(lblRoomNumberTitle, 0, 0);
            tblTenantInfo.Dock = DockStyle.Fill;
            tblTenantInfo.Location = new Point(5, 5);
            tblTenantInfo.Name = "tblTenantInfo";
            tblTenantInfo.RowCount = 4;
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 38.0281677F));
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 61.9718323F));
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            tblTenantInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tblTenantInfo.Size = new Size(474, 240);
            tblTenantInfo.TabIndex = 2;
            // 
            // lblContactNumberValue
            // 
            lblContactNumberValue.AutoSize = true;
            lblContactNumberValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNumberValue.ForeColor = Color.White;
            lblContactNumberValue.ImageAlign = ContentAlignment.MiddleRight;
            lblContactNumberValue.Location = new Point(192, 193);
            lblContactNumberValue.Name = "lblContactNumberValue";
            lblContactNumberValue.Size = new Size(19, 25);
            lblContactNumberValue.TabIndex = 10;
            lblContactNumberValue.Text = "-";
            lblContactNumberValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblContactNumberTitle
            // 
            lblContactNumberTitle.AutoSize = true;
            lblContactNumberTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNumberTitle.ForeColor = Color.White;
            lblContactNumberTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblContactNumberTitle.Location = new Point(3, 193);
            lblContactNumberTitle.Name = "lblContactNumberTitle";
            lblContactNumberTitle.Size = new Size(143, 25);
            lblContactNumberTitle.TabIndex = 9;
            lblContactNumberTitle.Text = "Contact Number";
            lblContactNumberTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenantNameValue
            // 
            lblTenantNameValue.AutoSize = true;
            lblTenantNameValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantNameValue.ForeColor = Color.White;
            lblTenantNameValue.ImageAlign = ContentAlignment.MiddleRight;
            lblTenantNameValue.Location = new Point(192, 116);
            lblTenantNameValue.Name = "lblTenantNameValue";
            lblTenantNameValue.Size = new Size(19, 25);
            lblTenantNameValue.TabIndex = 8;
            lblTenantNameValue.Text = "-";
            lblTenantNameValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenantNameTitle
            // 
            lblTenantNameTitle.AutoSize = true;
            lblTenantNameTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantNameTitle.ForeColor = Color.White;
            lblTenantNameTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTenantNameTitle.Location = new Point(3, 116);
            lblTenantNameTitle.Name = "lblTenantNameTitle";
            lblTenantNameTitle.Size = new Size(59, 25);
            lblTenantNameTitle.TabIndex = 7;
            lblTenantNameTitle.Text = "Name";
            lblTenantNameTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateOccupiedValue
            // 
            lblDateOccupiedValue.AutoSize = true;
            lblDateOccupiedValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateOccupiedValue.ForeColor = Color.White;
            lblDateOccupiedValue.ImageAlign = ContentAlignment.MiddleRight;
            lblDateOccupiedValue.Location = new Point(192, 44);
            lblDateOccupiedValue.Name = "lblDateOccupiedValue";
            lblDateOccupiedValue.Size = new Size(19, 25);
            lblDateOccupiedValue.TabIndex = 6;
            lblDateOccupiedValue.Text = "-";
            lblDateOccupiedValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateOccupiedTitle
            // 
            lblDateOccupiedTitle.AutoSize = true;
            lblDateOccupiedTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateOccupiedTitle.ForeColor = Color.White;
            lblDateOccupiedTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblDateOccupiedTitle.Location = new Point(3, 44);
            lblDateOccupiedTitle.Name = "lblDateOccupiedTitle";
            lblDateOccupiedTitle.Size = new Size(129, 25);
            lblDateOccupiedTitle.TabIndex = 5;
            lblDateOccupiedTitle.Text = "Date Occupied";
            lblDateOccupiedTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomNumberValue
            // 
            lblRoomNumberValue.AutoSize = true;
            lblRoomNumberValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumberValue.ForeColor = Color.White;
            lblRoomNumberValue.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomNumberValue.Location = new Point(192, 0);
            lblRoomNumberValue.Name = "lblRoomNumberValue";
            lblRoomNumberValue.Size = new Size(19, 25);
            lblRoomNumberValue.TabIndex = 3;
            lblRoomNumberValue.Text = "-";
            lblRoomNumberValue.TextAlign = ContentAlignment.MiddleCenter;
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
            pnlTenantDetailsHeader.Controls.Add(btnCloseTenantDetails);
            pnlTenantDetailsHeader.Controls.Add(lblTenantDetailsTitle);
            pnlTenantDetailsHeader.Controls.Add(btnEditTenant);
            pnlTenantDetailsHeader.Dock = DockStyle.Top;
            pnlTenantDetailsHeader.Location = new Point(10, 10);
            pnlTenantDetailsHeader.Margin = new Padding(0);
            pnlTenantDetailsHeader.Name = "pnlTenantDetailsHeader";
            pnlTenantDetailsHeader.Size = new Size(484, 50);
            pnlTenantDetailsHeader.TabIndex = 0;
            // 
            // btnCloseTenantDetails
            // 
            btnCloseTenantDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseTenantDetails.FlatStyle = FlatStyle.Flat;
            btnCloseTenantDetails.ForeColor = Color.White;
            btnCloseTenantDetails.Location = new Point(446, 10);
            btnCloseTenantDetails.Name = "btnCloseTenantDetails";
            btnCloseTenantDetails.Size = new Size(30, 30);
            btnCloseTenantDetails.TabIndex = 5;
            btnCloseTenantDetails.TabStop = false;
            btnCloseTenantDetails.Text = "X";
            btnCloseTenantDetails.UseVisualStyleBackColor = true;
            // 
            // lblTenantDetailsTitle
            // 
            lblTenantDetailsTitle.AutoSize = true;
            lblTenantDetailsTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantDetailsTitle.ForeColor = Color.White;
            lblTenantDetailsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTenantDetailsTitle.Location = new Point(156, 15);
            lblTenantDetailsTitle.Name = "lblTenantDetailsTitle";
            lblTenantDetailsTitle.Size = new Size(162, 25);
            lblTenantDetailsTitle.TabIndex = 3;
            lblTenantDetailsTitle.Text = "Tenant Information";
            lblTenantDetailsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTenantActions
            // 
            pnlTenantActions.Controls.Add(btnSaveTenant);
            pnlTenantActions.Controls.Add(btnCancelTenant);
            pnlTenantActions.Dock = DockStyle.Top;
            pnlTenantActions.Location = new Point(10, 310);
            pnlTenantActions.Margin = new Padding(0);
            pnlTenantActions.Name = "pnlTenantActions";
            pnlTenantActions.Size = new Size(484, 50);
            pnlTenantActions.TabIndex = 3;
            // 
            // pnlBillingSummary
            // 
            pnlBillingSummary.AutoScroll = true;
            pnlBillingSummary.Controls.Add(lblBillingSummary);
            pnlBillingSummary.Dock = DockStyle.Fill;
            pnlBillingSummary.Location = new Point(10, 360);
            pnlBillingSummary.Name = "pnlBillingSummary";
            pnlBillingSummary.Size = new Size(484, 250);
            pnlBillingSummary.TabIndex = 4;
            // 
            // lblBillingSummary
            // 
            lblBillingSummary.AutoSize = true;
            lblBillingSummary.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillingSummary.ForeColor = Color.White;
            lblBillingSummary.ImageAlign = ContentAlignment.MiddleRight;
            lblBillingSummary.Location = new Point(167, 12);
            lblBillingSummary.Name = "lblBillingSummary";
            lblBillingSummary.Size = new Size(140, 25);
            lblBillingSummary.TabIndex = 10;
            lblBillingSummary.Text = "Billing Summary";
            lblBillingSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEditTenant
            // 
            btnEditTenant.Location = new Point(8, 11);
            btnEditTenant.Name = "btnEditTenant";
            btnEditTenant.Size = new Size(94, 29);
            btnEditTenant.TabIndex = 0;
            btnEditTenant.Text = "edit";
            btnEditTenant.UseVisualStyleBackColor = true;
            // 
            // btnCancelTenant
            // 
            btnCancelTenant.Location = new Point(282, 10);
            btnCancelTenant.Name = "btnCancelTenant";
            btnCancelTenant.Size = new Size(94, 29);
            btnCancelTenant.TabIndex = 1;
            btnCancelTenant.Text = "cancel";
            btnCancelTenant.UseVisualStyleBackColor = true;
            btnCancelTenant.Visible = false;
            // 
            // btnSaveTenant
            // 
            btnSaveTenant.Location = new Point(382, 10);
            btnSaveTenant.Name = "btnSaveTenant";
            btnSaveTenant.Size = new Size(94, 29);
            btnSaveTenant.TabIndex = 2;
            btnSaveTenant.Text = "save";
            btnSaveTenant.UseVisualStyleBackColor = true;
            btnSaveTenant.Visible = false;
            // 
            // TenantsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlTenantContent);
            Controls.Add(pnlSearch);
            Name = "TenantsControl";
            Padding = new Padding(20);
            Size = new Size(1300, 750);
            pnlSearch.ResumeLayout(false);
            pnlSearchContainer.ResumeLayout(false);
            pnlSearchContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            pnlTenantContent.ResumeLayout(false);
            tblTenantSplit.ResumeLayout(false);
            pnlTenantList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTenants).EndInit();
            pnlTenantDetails.ResumeLayout(false);
            pnlTenantInfo.ResumeLayout(false);
            tblTenantInfo.ResumeLayout(false);
            tblTenantInfo.PerformLayout();
            pnlTenantDetailsHeader.ResumeLayout(false);
            pnlTenantDetailsHeader.PerformLayout();
            pnlTenantActions.ResumeLayout(false);
            pnlBillingSummary.ResumeLayout(false);
            pnlBillingSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSearch;
        private TextBox txtSearch;
        private PictureBox picSearch;
        private Panel pnlSearchContainer;
        private Panel pnlTenantContent;
        private TableLayoutPanel tblTenantSplit;
        private Panel pnlTenantList;
        private DataGridView dgvTenants;
        private Panel pnlTenantDetails;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colTenantName;
        private DataGridViewTextBoxColumn colDateOccupied;
        private DataGridViewTextBoxColumn colContact;
        private Panel pnlTenantDetailsHeader;
        private Label lblTenantDetailsTitle;
        private Button btnCloseTenantDetails;
        private Panel pnlTenantInfo;
        private TableLayoutPanel tblTenantInfo;
        private Label lblContactNumberValue;
        private Label lblContactNumberTitle;
        private Label lblTenantNameValue;
        private Label lblTenantNameTitle;
        private Label lblDateOccupiedValue;
        private Label lblDateOccupiedTitle;
        private Label lblRoomNumberValue;
        private Label lblRoomNumberTitle;
        private Panel pnlBillingSummary;
        private Label lblBillingSummary;
        private Panel pnlTenantActions;
        private Button btnEditTenant;
        private Button btnSaveTenant;
        private Button btnCancelTenant;
    }
}
