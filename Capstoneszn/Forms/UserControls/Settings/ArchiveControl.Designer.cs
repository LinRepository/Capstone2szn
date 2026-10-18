namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class ArchiveControl
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
            pnlArchiveHeader = new Panel();
            lblArchiveTitle = new Label();
            btnBackArchive = new Button();
            pnlArchiveContent = new Panel();
            tabEmployee = new TabPage();
            lblNoArchivedEmployees = new Label();
            dgvArchivedEmployees = new DataGridView();
            colEmployeeArchiveAction = new DataGridViewButtonColumn();
            colArchivedEmployeeDateHired = new DataGridViewTextBoxColumn();
            colArchivedEmployeeAddress = new DataGridViewTextBoxColumn();
            colArchivedEmployeeName = new DataGridViewTextBoxColumn();
            colEmployeeArchivedAt = new DataGridViewTextBoxColumn();
            colEmployeeArchiveID = new DataGridViewTextBoxColumn();
            tabBillAccounts = new TabPage();
            lblNoArchivedBillAccounts = new Label();
            dgvArchivedBillAccounts = new DataGridView();
            colBillAccountArchiveAction = new DataGridViewButtonColumn();
            colArchivedBillAccountNumber = new DataGridViewTextBoxColumn();
            colArchivedBillAccountRoom = new DataGridViewTextBoxColumn();
            colArchivedBillAccountType = new DataGridViewTextBoxColumn();
            colBillAccountArchivedAt = new DataGridViewTextBoxColumn();
            colBillAccountArchiveID = new DataGridViewTextBoxColumn();
            tabTenants = new TabPage();
            lblTenantsNote = new Label();
            pnlTenantsToolbar = new Panel();
            lblSearchTenants = new Label();
            txtSearchTenants = new TextBox();
            lblTenantsCount = new Label();
            lblNoArchivedTenants = new Label();
            dgvArchivedTenants = new DataGridView();
            colTenantArchiveAction = new DataGridViewButtonColumn();
            colArchivedTenantReason = new DataGridViewTextBoxColumn();
            colTenantArchivedAt = new DataGridViewTextBoxColumn();
            colArchivedTenantMoveIn = new DataGridViewTextBoxColumn();
            colArchivedTenantLastRoom = new DataGridViewTextBoxColumn();
            colArchivedTenantContact = new DataGridViewTextBoxColumn();
            colArchivedTenantName = new DataGridViewTextBoxColumn();
            tabRooms = new TabPage();
            lblRoomsNote = new Label();
            pnlRoomsToolbar = new Panel();
            lblSearchRooms = new Label();
            txtSearchRooms = new TextBox();
            lblRoomsCount = new Label();
            lblNoArchivedRooms = new Label();
            dgvArchivedRooms = new DataGridView();
            colRoomArchiveAction = new DataGridViewButtonColumn();
            colRoomArchivedAt = new DataGridViewTextBoxColumn();
            colArchivedRoomPrice = new DataGridViewTextBoxColumn();
            colArchivedRoomCapacity = new DataGridViewTextBoxColumn();
            colArchivedRoomType = new DataGridViewTextBoxColumn();
            colArchivedRoom = new DataGridViewTextBoxColumn();
            colArchivedRoomFloor = new DataGridViewTextBoxColumn();
            tabArchive = new TabControl();
            pnlArchiveHeader.SuspendLayout();
            pnlArchiveContent.SuspendLayout();
            tabEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedEmployees).BeginInit();
            tabBillAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedBillAccounts).BeginInit();
            tabTenants.SuspendLayout();
            pnlTenantsToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedTenants).BeginInit();
            tabRooms.SuspendLayout();
            pnlRoomsToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedRooms).BeginInit();
            tabArchive.SuspendLayout();
            SuspendLayout();
            // 
            // pnlArchiveHeader
            // 
            pnlArchiveHeader.Controls.Add(lblArchiveTitle);
            pnlArchiveHeader.Controls.Add(btnBackArchive);
            pnlArchiveHeader.Dock = DockStyle.Top;
            pnlArchiveHeader.Location = new Point(0, 0);
            pnlArchiveHeader.Name = "pnlArchiveHeader";
            pnlArchiveHeader.Size = new Size(1300, 100);
            pnlArchiveHeader.TabIndex = 0;
            // 
            // lblArchiveTitle
            // 
            lblArchiveTitle.BorderStyle = BorderStyle.FixedSingle;
            lblArchiveTitle.Dock = DockStyle.Fill;
            lblArchiveTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveTitle.ForeColor = Color.White;
            lblArchiveTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblArchiveTitle.Location = new Point(140, 0);
            lblArchiveTitle.Name = "lblArchiveTitle";
            lblArchiveTitle.Padding = new Padding(0, 0, 125, 0);
            lblArchiveTitle.Size = new Size(1160, 100);
            lblArchiveTitle.TabIndex = 10;
            lblArchiveTitle.Text = "Archive";
            lblArchiveTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackArchive
            // 
            btnBackArchive.Cursor = Cursors.Hand;
            btnBackArchive.Dock = DockStyle.Left;
            btnBackArchive.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackArchive.Location = new Point(0, 0);
            btnBackArchive.Margin = new Padding(0);
            btnBackArchive.Name = "btnBackArchive";
            btnBackArchive.Size = new Size(140, 100);
            btnBackArchive.TabIndex = 9;
            btnBackArchive.Text = "←";
            btnBackArchive.TextAlign = ContentAlignment.TopCenter;
            btnBackArchive.UseVisualStyleBackColor = true;
            btnBackArchive.Click += btnBackArchive_Click;
            // 
            // pnlArchiveContent
            // 
            pnlArchiveContent.BorderStyle = BorderStyle.FixedSingle;
            pnlArchiveContent.Controls.Add(tabArchive);
            pnlArchiveContent.Dock = DockStyle.Fill;
            pnlArchiveContent.Location = new Point(0, 100);
            pnlArchiveContent.Name = "pnlArchiveContent";
            pnlArchiveContent.Padding = new Padding(10);
            pnlArchiveContent.Size = new Size(1300, 650);
            pnlArchiveContent.TabIndex = 1;
            // 
            // tabEmployee
            // 
            tabEmployee.BackColor = Color.FromArgb(11, 20, 38);
            tabEmployee.Controls.Add(dgvArchivedEmployees);
            tabEmployee.Controls.Add(lblNoArchivedEmployees);
            tabEmployee.Location = new Point(4, 34);
            tabEmployee.Name = "tabEmployee";
            tabEmployee.Padding = new Padding(10);
            tabEmployee.Size = new Size(1270, 590);
            tabEmployee.TabIndex = 4;
            tabEmployee.Text = "Employee";
            // 
            // lblNoArchivedEmployees
            // 
            lblNoArchivedEmployees.Dock = DockStyle.Fill;
            lblNoArchivedEmployees.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoArchivedEmployees.ForeColor = Color.Silver;
            lblNoArchivedEmployees.Location = new Point(10, 10);
            lblNoArchivedEmployees.Name = "lblNoArchivedEmployees";
            lblNoArchivedEmployees.Size = new Size(1250, 570);
            lblNoArchivedEmployees.TabIndex = 2;
            lblNoArchivedEmployees.Text = "No archived records yet.";
            lblNoArchivedEmployees.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvArchivedEmployees
            // 
            dgvArchivedEmployees.AllowUserToAddRows = false;
            dgvArchivedEmployees.AllowUserToDeleteRows = false;
            dgvArchivedEmployees.AllowUserToResizeRows = false;
            dgvArchivedEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivedEmployees.BackgroundColor = Color.DarkGray;
            dgvArchivedEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivedEmployees.Columns.AddRange(new DataGridViewColumn[] { colEmployeeArchiveID, colEmployeeArchivedAt, colArchivedEmployeeName, colArchivedEmployeeAddress, colArchivedEmployeeDateHired, colEmployeeArchiveAction });
            dgvArchivedEmployees.Dock = DockStyle.Fill;
            dgvArchivedEmployees.Location = new Point(10, 10);
            dgvArchivedEmployees.MultiSelect = false;
            dgvArchivedEmployees.Name = "dgvArchivedEmployees";
            dgvArchivedEmployees.ReadOnly = true;
            dgvArchivedEmployees.RowHeadersVisible = false;
            dgvArchivedEmployees.RowHeadersWidth = 51;
            dgvArchivedEmployees.ScrollBars = ScrollBars.Vertical;
            dgvArchivedEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedEmployees.Size = new Size(1250, 570);
            dgvArchivedEmployees.TabIndex = 1;
            dgvArchivedEmployees.Visible = false;
            // 
            // colEmployeeArchiveAction
            // 
            colEmployeeArchiveAction.HeaderText = "Action";
            colEmployeeArchiveAction.MinimumWidth = 6;
            colEmployeeArchiveAction.Name = "colEmployeeArchiveAction";
            colEmployeeArchiveAction.ReadOnly = true;
            colEmployeeArchiveAction.Text = "Reactivate";
            colEmployeeArchiveAction.UseColumnTextForButtonValue = true;
            // 
            // colArchivedEmployeeDateHired
            // 
            colArchivedEmployeeDateHired.HeaderText = "Date Hired";
            colArchivedEmployeeDateHired.MinimumWidth = 6;
            colArchivedEmployeeDateHired.Name = "colArchivedEmployeeDateHired";
            colArchivedEmployeeDateHired.ReadOnly = true;
            // 
            // colArchivedEmployeeAddress
            // 
            colArchivedEmployeeAddress.HeaderText = "Address";
            colArchivedEmployeeAddress.MinimumWidth = 6;
            colArchivedEmployeeAddress.Name = "colArchivedEmployeeAddress";
            colArchivedEmployeeAddress.ReadOnly = true;
            // 
            // colArchivedEmployeeName
            // 
            colArchivedEmployeeName.HeaderText = "Employee Name";
            colArchivedEmployeeName.MinimumWidth = 6;
            colArchivedEmployeeName.Name = "colArchivedEmployeeName";
            colArchivedEmployeeName.ReadOnly = true;
            // 
            // colEmployeeArchivedAt
            // 
            colEmployeeArchivedAt.HeaderText = "Archived On";
            colEmployeeArchivedAt.MinimumWidth = 6;
            colEmployeeArchivedAt.Name = "colEmployeeArchivedAt";
            colEmployeeArchivedAt.ReadOnly = true;
            // 
            // colEmployeeArchiveID
            // 
            colEmployeeArchiveID.HeaderText = "ID";
            colEmployeeArchiveID.MinimumWidth = 6;
            colEmployeeArchiveID.Name = "colEmployeeArchiveID";
            colEmployeeArchiveID.ReadOnly = true;
            // 
            // tabBillAccounts
            // 
            tabBillAccounts.BackColor = Color.FromArgb(11, 20, 38);
            tabBillAccounts.Controls.Add(dgvArchivedBillAccounts);
            tabBillAccounts.Controls.Add(lblNoArchivedBillAccounts);
            tabBillAccounts.Location = new Point(4, 34);
            tabBillAccounts.Name = "tabBillAccounts";
            tabBillAccounts.Padding = new Padding(10);
            tabBillAccounts.Size = new Size(1270, 590);
            tabBillAccounts.TabIndex = 2;
            tabBillAccounts.Text = "Bill Accounts";
            // 
            // lblNoArchivedBillAccounts
            // 
            lblNoArchivedBillAccounts.Dock = DockStyle.Fill;
            lblNoArchivedBillAccounts.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoArchivedBillAccounts.ForeColor = Color.Silver;
            lblNoArchivedBillAccounts.Location = new Point(10, 10);
            lblNoArchivedBillAccounts.Name = "lblNoArchivedBillAccounts";
            lblNoArchivedBillAccounts.Size = new Size(1250, 570);
            lblNoArchivedBillAccounts.TabIndex = 2;
            lblNoArchivedBillAccounts.Text = "No archived records yet.";
            lblNoArchivedBillAccounts.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvArchivedBillAccounts
            // 
            dgvArchivedBillAccounts.AllowUserToAddRows = false;
            dgvArchivedBillAccounts.AllowUserToDeleteRows = false;
            dgvArchivedBillAccounts.AllowUserToResizeRows = false;
            dgvArchivedBillAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivedBillAccounts.BackgroundColor = Color.DarkGray;
            dgvArchivedBillAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivedBillAccounts.Columns.AddRange(new DataGridViewColumn[] { colBillAccountArchiveID, colBillAccountArchivedAt, colArchivedBillAccountType, colArchivedBillAccountRoom, colArchivedBillAccountNumber, colBillAccountArchiveAction });
            dgvArchivedBillAccounts.Dock = DockStyle.Fill;
            dgvArchivedBillAccounts.Location = new Point(10, 10);
            dgvArchivedBillAccounts.MultiSelect = false;
            dgvArchivedBillAccounts.Name = "dgvArchivedBillAccounts";
            dgvArchivedBillAccounts.ReadOnly = true;
            dgvArchivedBillAccounts.RowHeadersVisible = false;
            dgvArchivedBillAccounts.RowHeadersWidth = 51;
            dgvArchivedBillAccounts.ScrollBars = ScrollBars.Vertical;
            dgvArchivedBillAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedBillAccounts.Size = new Size(1250, 570);
            dgvArchivedBillAccounts.TabIndex = 1;
            dgvArchivedBillAccounts.Visible = false;
            // 
            // colBillAccountArchiveAction
            // 
            colBillAccountArchiveAction.HeaderText = "Action";
            colBillAccountArchiveAction.MinimumWidth = 6;
            colBillAccountArchiveAction.Name = "colBillAccountArchiveAction";
            colBillAccountArchiveAction.ReadOnly = true;
            colBillAccountArchiveAction.Text = "Restore";
            colBillAccountArchiveAction.UseColumnTextForButtonValue = true;
            // 
            // colArchivedBillAccountNumber
            // 
            colArchivedBillAccountNumber.HeaderText = "Account Number";
            colArchivedBillAccountNumber.MinimumWidth = 6;
            colArchivedBillAccountNumber.Name = "colArchivedBillAccountNumber";
            colArchivedBillAccountNumber.ReadOnly = true;
            // 
            // colArchivedBillAccountRoom
            // 
            colArchivedBillAccountRoom.HeaderText = "Room";
            colArchivedBillAccountRoom.MinimumWidth = 6;
            colArchivedBillAccountRoom.Name = "colArchivedBillAccountRoom";
            colArchivedBillAccountRoom.ReadOnly = true;
            // 
            // colArchivedBillAccountType
            // 
            colArchivedBillAccountType.HeaderText = "Type";
            colArchivedBillAccountType.MinimumWidth = 6;
            colArchivedBillAccountType.Name = "colArchivedBillAccountType";
            colArchivedBillAccountType.ReadOnly = true;
            // 
            // colBillAccountArchivedAt
            // 
            colBillAccountArchivedAt.HeaderText = "Archived On";
            colBillAccountArchivedAt.MinimumWidth = 6;
            colBillAccountArchivedAt.Name = "colBillAccountArchivedAt";
            colBillAccountArchivedAt.ReadOnly = true;
            // 
            // colBillAccountArchiveID
            // 
            colBillAccountArchiveID.HeaderText = "ID";
            colBillAccountArchiveID.MinimumWidth = 6;
            colBillAccountArchiveID.Name = "colBillAccountArchiveID";
            colBillAccountArchiveID.ReadOnly = true;
            // 
            // tabTenants
            // 
            tabTenants.BackColor = Color.FromArgb(11, 20, 38);
            tabTenants.Controls.Add(dgvArchivedTenants);
            tabTenants.Controls.Add(lblNoArchivedTenants);
            tabTenants.Controls.Add(pnlTenantsToolbar);
            tabTenants.Controls.Add(lblTenantsNote);
            tabTenants.Location = new Point(4, 34);
            tabTenants.Name = "tabTenants";
            tabTenants.Padding = new Padding(10);
            tabTenants.Size = new Size(1270, 590);
            tabTenants.TabIndex = 1;
            tabTenants.Text = "Tenants";
            // 
            // lblTenantsNote
            // 
            lblTenantsNote.Dock = DockStyle.Bottom;
            lblTenantsNote.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantsNote.ForeColor = Color.Silver;
            lblTenantsNote.Location = new Point(10, 540);
            lblTenantsNote.Name = "lblTenantsNote";
            lblTenantsNote.Size = new Size(1250, 40);
            lblTenantsNote.TabIndex = 2;
            lblTenantsNote.Text = "Reactivate moves a returning tenant into a room under the same record, so their full history stays together. Balances from the earlier stay remain settled.";
            lblTenantsNote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTenantsToolbar
            // 
            pnlTenantsToolbar.Controls.Add(lblTenantsCount);
            pnlTenantsToolbar.Controls.Add(txtSearchTenants);
            pnlTenantsToolbar.Controls.Add(lblSearchTenants);
            pnlTenantsToolbar.Dock = DockStyle.Top;
            pnlTenantsToolbar.Location = new Point(10, 10);
            pnlTenantsToolbar.Name = "pnlTenantsToolbar";
            pnlTenantsToolbar.Size = new Size(1250, 50);
            pnlTenantsToolbar.TabIndex = 1;
            // 
            // lblSearchTenants
            // 
            lblSearchTenants.AutoSize = true;
            lblSearchTenants.ForeColor = Color.White;
            lblSearchTenants.Location = new Point(0, 12);
            lblSearchTenants.Name = "lblSearchTenants";
            lblSearchTenants.Size = new Size(64, 25);
            lblSearchTenants.TabIndex = 0;
            lblSearchTenants.Text = "Search";
            // 
            // txtSearchTenants
            // 
            txtSearchTenants.Location = new Point(80, 9);
            txtSearchTenants.Name = "txtSearchTenants";
            txtSearchTenants.Size = new Size(320, 31);
            txtSearchTenants.TabIndex = 1;
            txtSearchTenants.TextChanged += txtSearchTenants_TextChanged;
            // 
            // lblTenantsCount
            // 
            lblTenantsCount.Dock = DockStyle.Right;
            lblTenantsCount.ForeColor = Color.Silver;
            lblTenantsCount.Location = new Point(900, 0);
            lblTenantsCount.Name = "lblTenantsCount";
            lblTenantsCount.Size = new Size(350, 50);
            lblTenantsCount.TabIndex = 2;
            lblTenantsCount.Text = "0 moved-out tenant(s)";
            lblTenantsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNoArchivedTenants
            // 
            lblNoArchivedTenants.Dock = DockStyle.Fill;
            lblNoArchivedTenants.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoArchivedTenants.ForeColor = Color.Silver;
            lblNoArchivedTenants.Location = new Point(10, 60);
            lblNoArchivedTenants.Name = "lblNoArchivedTenants";
            lblNoArchivedTenants.Size = new Size(1250, 480);
            lblNoArchivedTenants.TabIndex = 3;
            lblNoArchivedTenants.Text = "No moved-out tenants.";
            lblNoArchivedTenants.TextAlign = ContentAlignment.MiddleCenter;
            lblNoArchivedTenants.Visible = false;
            // 
            // dgvArchivedTenants
            // 
            dgvArchivedTenants.AllowUserToAddRows = false;
            dgvArchivedTenants.AllowUserToDeleteRows = false;
            dgvArchivedTenants.AllowUserToResizeRows = false;
            dgvArchivedTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivedTenants.BackgroundColor = Color.DarkGray;
            dgvArchivedTenants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivedTenants.Columns.AddRange(new DataGridViewColumn[] { colArchivedTenantName, colArchivedTenantContact, colArchivedTenantLastRoom, colArchivedTenantMoveIn, colTenantArchivedAt, colArchivedTenantReason, colTenantArchiveAction });
            dgvArchivedTenants.Dock = DockStyle.Fill;
            dgvArchivedTenants.Location = new Point(10, 60);
            dgvArchivedTenants.MultiSelect = false;
            dgvArchivedTenants.Name = "dgvArchivedTenants";
            dgvArchivedTenants.ReadOnly = true;
            dgvArchivedTenants.RowHeadersVisible = false;
            dgvArchivedTenants.RowHeadersWidth = 51;
            dgvArchivedTenants.ScrollBars = ScrollBars.Vertical;
            dgvArchivedTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedTenants.Size = new Size(1250, 480);
            dgvArchivedTenants.TabIndex = 0;
            dgvArchivedTenants.CellContentClick += dgvArchivedTenants_CellContentClick;
            // 
            // colTenantArchiveAction
            // 
            colTenantArchiveAction.FillWeight = 90F;
            colTenantArchiveAction.HeaderText = "Action";
            colTenantArchiveAction.MinimumWidth = 6;
            colTenantArchiveAction.Name = "colTenantArchiveAction";
            colTenantArchiveAction.ReadOnly = true;
            colTenantArchiveAction.Text = "Reactivate";
            colTenantArchiveAction.UseColumnTextForButtonValue = true;
            // 
            // colArchivedTenantReason
            // 
            colArchivedTenantReason.HeaderText = "Reason";
            colArchivedTenantReason.MinimumWidth = 6;
            colArchivedTenantReason.Name = "colArchivedTenantReason";
            colArchivedTenantReason.ReadOnly = true;
            // 
            // colTenantArchivedAt
            // 
            colTenantArchivedAt.HeaderText = "Moved Out";
            colTenantArchivedAt.MinimumWidth = 6;
            colTenantArchivedAt.Name = "colTenantArchivedAt";
            colTenantArchivedAt.ReadOnly = true;
            // 
            // colArchivedTenantMoveIn
            // 
            colArchivedTenantMoveIn.HeaderText = "Moved In";
            colArchivedTenantMoveIn.MinimumWidth = 6;
            colArchivedTenantMoveIn.Name = "colArchivedTenantMoveIn";
            colArchivedTenantMoveIn.ReadOnly = true;
            // 
            // colArchivedTenantLastRoom
            // 
            colArchivedTenantLastRoom.FillWeight = 70F;
            colArchivedTenantLastRoom.HeaderText = "Last Room";
            colArchivedTenantLastRoom.MinimumWidth = 6;
            colArchivedTenantLastRoom.Name = "colArchivedTenantLastRoom";
            colArchivedTenantLastRoom.ReadOnly = true;
            // 
            // colArchivedTenantContact
            // 
            colArchivedTenantContact.HeaderText = "Contact";
            colArchivedTenantContact.MinimumWidth = 6;
            colArchivedTenantContact.Name = "colArchivedTenantContact";
            colArchivedTenantContact.ReadOnly = true;
            // 
            // colArchivedTenantName
            // 
            colArchivedTenantName.FillWeight = 140F;
            colArchivedTenantName.HeaderText = "Tenant Name";
            colArchivedTenantName.MinimumWidth = 6;
            colArchivedTenantName.Name = "colArchivedTenantName";
            colArchivedTenantName.ReadOnly = true;
            // 
            // tabRooms
            // 
            tabRooms.BackColor = Color.FromArgb(11, 20, 38);
            tabRooms.Controls.Add(dgvArchivedRooms);
            tabRooms.Controls.Add(lblNoArchivedRooms);
            tabRooms.Controls.Add(pnlRoomsToolbar);
            tabRooms.Controls.Add(lblRoomsNote);
            tabRooms.Location = new Point(4, 34);
            tabRooms.Name = "tabRooms";
            tabRooms.Padding = new Padding(10);
            tabRooms.Size = new Size(1270, 590);
            tabRooms.TabIndex = 0;
            tabRooms.Text = "Rooms";
            // 
            // lblRoomsNote
            // 
            lblRoomsNote.Dock = DockStyle.Bottom;
            lblRoomsNote.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomsNote.ForeColor = Color.Silver;
            lblRoomsNote.Location = new Point(10, 540);
            lblRoomsNote.Name = "lblRoomsNote";
            lblRoomsNote.Size = new Size(1250, 40);
            lblRoomsNote.TabIndex = 2;
            lblRoomsNote.Text = "Restore returns the room to the Rooms map as Available (or Unconfigured). A room with an open maintenance issue cannot be restored.";
            lblRoomsNote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlRoomsToolbar
            // 
            pnlRoomsToolbar.Controls.Add(lblRoomsCount);
            pnlRoomsToolbar.Controls.Add(txtSearchRooms);
            pnlRoomsToolbar.Controls.Add(lblSearchRooms);
            pnlRoomsToolbar.Dock = DockStyle.Top;
            pnlRoomsToolbar.Location = new Point(10, 10);
            pnlRoomsToolbar.Name = "pnlRoomsToolbar";
            pnlRoomsToolbar.Size = new Size(1250, 50);
            pnlRoomsToolbar.TabIndex = 1;
            // 
            // lblSearchRooms
            // 
            lblSearchRooms.AutoSize = true;
            lblSearchRooms.ForeColor = Color.White;
            lblSearchRooms.Location = new Point(0, 12);
            lblSearchRooms.Name = "lblSearchRooms";
            lblSearchRooms.Size = new Size(64, 25);
            lblSearchRooms.TabIndex = 0;
            lblSearchRooms.Text = "Search";
            // 
            // txtSearchRooms
            // 
            txtSearchRooms.Location = new Point(80, 9);
            txtSearchRooms.Name = "txtSearchRooms";
            txtSearchRooms.Size = new Size(320, 31);
            txtSearchRooms.TabIndex = 1;
            txtSearchRooms.TextChanged += txtSearchRooms_TextChanged;
            // 
            // lblRoomsCount
            // 
            lblRoomsCount.Dock = DockStyle.Right;
            lblRoomsCount.ForeColor = Color.Silver;
            lblRoomsCount.Location = new Point(900, 0);
            lblRoomsCount.Name = "lblRoomsCount";
            lblRoomsCount.Size = new Size(350, 50);
            lblRoomsCount.TabIndex = 2;
            lblRoomsCount.Text = "0 archived room(s)";
            lblRoomsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNoArchivedRooms
            // 
            lblNoArchivedRooms.Dock = DockStyle.Fill;
            lblNoArchivedRooms.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoArchivedRooms.ForeColor = Color.Silver;
            lblNoArchivedRooms.Location = new Point(10, 60);
            lblNoArchivedRooms.Name = "lblNoArchivedRooms";
            lblNoArchivedRooms.Size = new Size(1250, 480);
            lblNoArchivedRooms.TabIndex = 3;
            lblNoArchivedRooms.Text = "No archived rooms.";
            lblNoArchivedRooms.TextAlign = ContentAlignment.MiddleCenter;
            lblNoArchivedRooms.Visible = false;
            // 
            // dgvArchivedRooms
            // 
            dgvArchivedRooms.AllowUserToAddRows = false;
            dgvArchivedRooms.AllowUserToDeleteRows = false;
            dgvArchivedRooms.AllowUserToResizeRows = false;
            dgvArchivedRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivedRooms.BackgroundColor = Color.DarkGray;
            dgvArchivedRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivedRooms.Columns.AddRange(new DataGridViewColumn[] { colArchivedRoomFloor, colArchivedRoom, colArchivedRoomType, colArchivedRoomCapacity, colArchivedRoomPrice, colRoomArchivedAt, colRoomArchiveAction });
            dgvArchivedRooms.Dock = DockStyle.Fill;
            dgvArchivedRooms.Location = new Point(10, 60);
            dgvArchivedRooms.MultiSelect = false;
            dgvArchivedRooms.Name = "dgvArchivedRooms";
            dgvArchivedRooms.ReadOnly = true;
            dgvArchivedRooms.RowHeadersVisible = false;
            dgvArchivedRooms.RowHeadersWidth = 51;
            dgvArchivedRooms.ScrollBars = ScrollBars.Vertical;
            dgvArchivedRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedRooms.Size = new Size(1250, 480);
            dgvArchivedRooms.TabIndex = 0;
            dgvArchivedRooms.CellContentClick += dgvArchivedRooms_CellContentClick;
            // 
            // colRoomArchiveAction
            // 
            colRoomArchiveAction.FillWeight = 80F;
            colRoomArchiveAction.HeaderText = "Action";
            colRoomArchiveAction.MinimumWidth = 6;
            colRoomArchiveAction.Name = "colRoomArchiveAction";
            colRoomArchiveAction.ReadOnly = true;
            colRoomArchiveAction.Text = "Restore";
            colRoomArchiveAction.UseColumnTextForButtonValue = true;
            // 
            // colRoomArchivedAt
            // 
            colRoomArchivedAt.FillWeight = 130F;
            colRoomArchivedAt.HeaderText = "Archived On";
            colRoomArchivedAt.MinimumWidth = 6;
            colRoomArchivedAt.Name = "colRoomArchivedAt";
            colRoomArchivedAt.ReadOnly = true;
            // 
            // colArchivedRoomPrice
            // 
            colArchivedRoomPrice.HeaderText = "Room Price";
            colArchivedRoomPrice.MinimumWidth = 6;
            colArchivedRoomPrice.Name = "colArchivedRoomPrice";
            colArchivedRoomPrice.ReadOnly = true;
            // 
            // colArchivedRoomCapacity
            // 
            colArchivedRoomCapacity.FillWeight = 70F;
            colArchivedRoomCapacity.HeaderText = "Capacity";
            colArchivedRoomCapacity.MinimumWidth = 6;
            colArchivedRoomCapacity.Name = "colArchivedRoomCapacity";
            colArchivedRoomCapacity.ReadOnly = true;
            // 
            // colArchivedRoomType
            // 
            colArchivedRoomType.HeaderText = "Type";
            colArchivedRoomType.MinimumWidth = 6;
            colArchivedRoomType.Name = "colArchivedRoomType";
            colArchivedRoomType.ReadOnly = true;
            // 
            // colArchivedRoom
            // 
            colArchivedRoom.FillWeight = 70F;
            colArchivedRoom.HeaderText = "Room";
            colArchivedRoom.MinimumWidth = 6;
            colArchivedRoom.Name = "colArchivedRoom";
            colArchivedRoom.ReadOnly = true;
            // 
            // colArchivedRoomFloor
            // 
            colArchivedRoomFloor.FillWeight = 60F;
            colArchivedRoomFloor.HeaderText = "Floor";
            colArchivedRoomFloor.MinimumWidth = 6;
            colArchivedRoomFloor.Name = "colArchivedRoomFloor";
            colArchivedRoomFloor.ReadOnly = true;
            // 
            // tabArchive
            // 
            tabArchive.Controls.Add(tabRooms);
            tabArchive.Controls.Add(tabTenants);
            tabArchive.Controls.Add(tabBillAccounts);
            tabArchive.Controls.Add(tabEmployee);
            tabArchive.Dock = DockStyle.Fill;
            tabArchive.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabArchive.Location = new Point(10, 10);
            tabArchive.Name = "tabArchive";
            tabArchive.SelectedIndex = 0;
            tabArchive.Size = new Size(1278, 628);
            tabArchive.TabIndex = 0;
            // 
            // ArchiveControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlArchiveContent);
            Controls.Add(pnlArchiveHeader);
            Name = "ArchiveControl";
            Size = new Size(1300, 750);
            pnlArchiveHeader.ResumeLayout(false);
            pnlArchiveContent.ResumeLayout(false);
            tabEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArchivedEmployees).EndInit();
            tabBillAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArchivedBillAccounts).EndInit();
            tabTenants.ResumeLayout(false);
            pnlTenantsToolbar.ResumeLayout(false);
            pnlTenantsToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedTenants).EndInit();
            tabRooms.ResumeLayout(false);
            pnlRoomsToolbar.ResumeLayout(false);
            pnlRoomsToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedRooms).EndInit();
            tabArchive.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlArchiveHeader;
        private Panel pnlArchiveContent;
        private Label lblArchiveTitle;
        private Button btnBackArchive;
        private TabControl tabArchive;
        private TabPage tabRooms;
        private DataGridView dgvArchivedRooms;
        private DataGridViewTextBoxColumn colArchivedRoomFloor;
        private DataGridViewTextBoxColumn colArchivedRoom;
        private DataGridViewTextBoxColumn colArchivedRoomType;
        private DataGridViewTextBoxColumn colArchivedRoomCapacity;
        private DataGridViewTextBoxColumn colArchivedRoomPrice;
        private DataGridViewTextBoxColumn colRoomArchivedAt;
        private DataGridViewButtonColumn colRoomArchiveAction;
        private Label lblNoArchivedRooms;
        private Panel pnlRoomsToolbar;
        private Label lblRoomsCount;
        private TextBox txtSearchRooms;
        private Label lblSearchRooms;
        private Label lblRoomsNote;
        private TabPage tabTenants;
        private DataGridView dgvArchivedTenants;
        private DataGridViewTextBoxColumn colArchivedTenantName;
        private DataGridViewTextBoxColumn colArchivedTenantContact;
        private DataGridViewTextBoxColumn colArchivedTenantLastRoom;
        private DataGridViewTextBoxColumn colArchivedTenantMoveIn;
        private DataGridViewTextBoxColumn colTenantArchivedAt;
        private DataGridViewTextBoxColumn colArchivedTenantReason;
        private DataGridViewButtonColumn colTenantArchiveAction;
        private Label lblNoArchivedTenants;
        private Panel pnlTenantsToolbar;
        private Label lblTenantsCount;
        private TextBox txtSearchTenants;
        private Label lblSearchTenants;
        private Label lblTenantsNote;
        private TabPage tabBillAccounts;
        private DataGridView dgvArchivedBillAccounts;
        private DataGridViewTextBoxColumn colBillAccountArchiveID;
        private DataGridViewTextBoxColumn colBillAccountArchivedAt;
        private DataGridViewTextBoxColumn colArchivedBillAccountType;
        private DataGridViewTextBoxColumn colArchivedBillAccountRoom;
        private DataGridViewTextBoxColumn colArchivedBillAccountNumber;
        private DataGridViewButtonColumn colBillAccountArchiveAction;
        private Label lblNoArchivedBillAccounts;
        private TabPage tabEmployee;
        private DataGridView dgvArchivedEmployees;
        private DataGridViewTextBoxColumn colEmployeeArchiveID;
        private DataGridViewTextBoxColumn colEmployeeArchivedAt;
        private DataGridViewTextBoxColumn colArchivedEmployeeName;
        private DataGridViewTextBoxColumn colArchivedEmployeeAddress;
        private DataGridViewTextBoxColumn colArchivedEmployeeDateHired;
        private DataGridViewButtonColumn colEmployeeArchiveAction;
        private Label lblNoArchivedEmployees;
    }
}
