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
            tabArchive = new TabControl();
            tabRooms = new TabPage();
            tabBillAccounts = new TabPage();
            tabAudits = new TabPage();
            tabTenants = new TabPage();
            tabEmployee = new TabPage();
            dgvArchivedRooms = new DataGridView();
            dgvArchivedBillAccounts = new DataGridView();
            dgvArchivedAudits = new DataGridView();
            dgvArchivedTenants = new DataGridView();
            dgvArchivedEmployees = new DataGridView();
            colRoomArchiveID = new DataGridViewTextBoxColumn();
            colRoomArchivedAt = new DataGridViewTextBoxColumn();
            colArchivedRoom = new DataGridViewTextBoxColumn();
            colRoomArchiveAction = new DataGridViewButtonColumn();
            colBillAccountArchiveID = new DataGridViewTextBoxColumn();
            colBillAccountArchivedAt = new DataGridViewTextBoxColumn();
            colArchivedBillAccountType = new DataGridViewTextBoxColumn();
            colArchivedBillAccountRoom = new DataGridViewTextBoxColumn();
            colArchivedBillAccountNumber = new DataGridViewTextBoxColumn();
            colBillAccountArchiveAction = new DataGridViewButtonColumn();
            colAuditArchiveID = new DataGridViewTextBoxColumn();
            colAuditArchivedAt = new DataGridViewTextBoxColumn();
            colArchivedAuditCategory = new DataGridViewTextBoxColumn();
            colArchivedAuditDateTime = new DataGridViewTextBoxColumn();
            colAuditArchiveAction = new DataGridViewButtonColumn();
            colTenantArchiveID = new DataGridViewTextBoxColumn();
            colTenantArchivedAt = new DataGridViewTextBoxColumn();
            colArchivedTenantName = new DataGridViewTextBoxColumn();
            colArchivedTenantContact = new DataGridViewTextBoxColumn();
            colArchivedTenantMoveIn = new DataGridViewTextBoxColumn();
            colTenantArchiveAction = new DataGridViewButtonColumn();
            colEmployeeArchiveID = new DataGridViewTextBoxColumn();
            colEmployeeArchivedAt = new DataGridViewTextBoxColumn();
            colArchivedEmployeeName = new DataGridViewTextBoxColumn();
            colArchivedEmployeeAddress = new DataGridViewTextBoxColumn();
            colArchivedEmployeeDateHired = new DataGridViewTextBoxColumn();
            colEmployeeArchiveAction = new DataGridViewButtonColumn();
            pnlArchiveHeader.SuspendLayout();
            pnlArchiveContent.SuspendLayout();
            tabArchive.SuspendLayout();
            tabRooms.SuspendLayout();
            tabBillAccounts.SuspendLayout();
            tabAudits.SuspendLayout();
            tabTenants.SuspendLayout();
            tabEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedRooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedBillAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedAudits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedTenants).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedEmployees).BeginInit();
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
            lblArchiveTitle.Dock = DockStyle.Fill;
            lblArchiveTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveTitle.ForeColor = Color.White;
            lblArchiveTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblArchiveTitle.Location = new Point(140, 0);
            lblArchiveTitle.Name = "lblArchiveTitle";
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
            // 
            // pnlArchiveContent
            // 
            pnlArchiveContent.Controls.Add(tabArchive);
            pnlArchiveContent.Dock = DockStyle.Fill;
            pnlArchiveContent.Location = new Point(0, 100);
            pnlArchiveContent.Name = "pnlArchiveContent";
            pnlArchiveContent.Padding = new Padding(10);
            pnlArchiveContent.Size = new Size(1300, 650);
            pnlArchiveContent.TabIndex = 1;
            // 
            // tabArchive
            // 
            tabArchive.Controls.Add(tabRooms);
            tabArchive.Controls.Add(tabBillAccounts);
            tabArchive.Controls.Add(tabAudits);
            tabArchive.Controls.Add(tabTenants);
            tabArchive.Controls.Add(tabEmployee);
            tabArchive.Dock = DockStyle.Fill;
            tabArchive.Location = new Point(10, 10);
            tabArchive.Name = "tabArchive";
            tabArchive.SelectedIndex = 0;
            tabArchive.Size = new Size(1280, 630);
            tabArchive.TabIndex = 0;
            // 
            // tabRooms
            // 
            tabRooms.Controls.Add(dgvArchivedRooms);
            tabRooms.Location = new Point(4, 29);
            tabRooms.Name = "tabRooms";
            tabRooms.Padding = new Padding(3);
            tabRooms.Size = new Size(1272, 597);
            tabRooms.TabIndex = 0;
            tabRooms.Text = "Rooms";
            tabRooms.UseVisualStyleBackColor = true;
            // 
            // tabBillAccounts
            // 
            tabBillAccounts.Controls.Add(dgvArchivedBillAccounts);
            tabBillAccounts.Location = new Point(4, 29);
            tabBillAccounts.Name = "tabBillAccounts";
            tabBillAccounts.Padding = new Padding(3);
            tabBillAccounts.Size = new Size(1272, 597);
            tabBillAccounts.TabIndex = 1;
            tabBillAccounts.Text = "Bill Accounts";
            tabBillAccounts.UseVisualStyleBackColor = true;
            // 
            // tabAudits
            // 
            tabAudits.Controls.Add(dgvArchivedAudits);
            tabAudits.Location = new Point(4, 29);
            tabAudits.Name = "tabAudits";
            tabAudits.Padding = new Padding(3);
            tabAudits.Size = new Size(1272, 597);
            tabAudits.TabIndex = 2;
            tabAudits.Text = "Audits";
            tabAudits.UseVisualStyleBackColor = true;
            // 
            // tabTenants
            // 
            tabTenants.Controls.Add(dgvArchivedTenants);
            tabTenants.Location = new Point(4, 29);
            tabTenants.Name = "tabTenants";
            tabTenants.Padding = new Padding(3);
            tabTenants.Size = new Size(1272, 597);
            tabTenants.TabIndex = 3;
            tabTenants.Text = "Tenants";
            tabTenants.UseVisualStyleBackColor = true;
            // 
            // tabEmployee
            // 
            tabEmployee.Controls.Add(dgvArchivedEmployees);
            tabEmployee.Location = new Point(4, 29);
            tabEmployee.Name = "tabEmployee";
            tabEmployee.Padding = new Padding(3);
            tabEmployee.Size = new Size(1272, 597);
            tabEmployee.TabIndex = 4;
            tabEmployee.Text = "Employee";
            tabEmployee.UseVisualStyleBackColor = true;
            // 
            // dgvArchivedRooms
            // 
            dgvArchivedRooms.AllowUserToAddRows = false;
            dgvArchivedRooms.AllowUserToDeleteRows = false;
            dgvArchivedRooms.AllowUserToResizeRows = false;
            dgvArchivedRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivedRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivedRooms.Columns.AddRange(new DataGridViewColumn[] { colRoomArchiveID, colRoomArchivedAt, colArchivedRoom, colRoomArchiveAction });
            dgvArchivedRooms.Dock = DockStyle.Fill;
            dgvArchivedRooms.Location = new Point(3, 3);
            dgvArchivedRooms.MultiSelect = false;
            dgvArchivedRooms.Name = "dgvArchivedRooms";
            dgvArchivedRooms.ReadOnly = true;
            dgvArchivedRooms.RowHeadersVisible = false;
            dgvArchivedRooms.RowHeadersWidth = 51;
            dgvArchivedRooms.ScrollBars = ScrollBars.Vertical;
            dgvArchivedRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedRooms.Size = new Size(1266, 591);
            dgvArchivedRooms.TabIndex = 0;
            // 
            // dgvArchivedBillAccounts
            // 
            dgvArchivedBillAccounts.AllowUserToAddRows = false;
            dgvArchivedBillAccounts.AllowUserToDeleteRows = false;
            dgvArchivedBillAccounts.AllowUserToResizeRows = false;
            dgvArchivedBillAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivedBillAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivedBillAccounts.Columns.AddRange(new DataGridViewColumn[] { colBillAccountArchiveID, colBillAccountArchivedAt, colArchivedBillAccountType, colArchivedBillAccountRoom, colArchivedBillAccountNumber, colBillAccountArchiveAction });
            dgvArchivedBillAccounts.Dock = DockStyle.Fill;
            dgvArchivedBillAccounts.Location = new Point(3, 3);
            dgvArchivedBillAccounts.MultiSelect = false;
            dgvArchivedBillAccounts.Name = "dgvArchivedBillAccounts";
            dgvArchivedBillAccounts.ReadOnly = true;
            dgvArchivedBillAccounts.RowHeadersVisible = false;
            dgvArchivedBillAccounts.RowHeadersWidth = 51;
            dgvArchivedBillAccounts.ScrollBars = ScrollBars.Vertical;
            dgvArchivedBillAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedBillAccounts.Size = new Size(1266, 591);
            dgvArchivedBillAccounts.TabIndex = 1;
            // 
            // dgvArchivedAudits
            // 
            dgvArchivedAudits.AllowUserToAddRows = false;
            dgvArchivedAudits.AllowUserToDeleteRows = false;
            dgvArchivedAudits.AllowUserToResizeRows = false;
            dgvArchivedAudits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivedAudits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivedAudits.Columns.AddRange(new DataGridViewColumn[] { colAuditArchiveID, colAuditArchivedAt, colArchivedAuditCategory, colArchivedAuditDateTime, colAuditArchiveAction });
            dgvArchivedAudits.Dock = DockStyle.Fill;
            dgvArchivedAudits.Location = new Point(3, 3);
            dgvArchivedAudits.MultiSelect = false;
            dgvArchivedAudits.Name = "dgvArchivedAudits";
            dgvArchivedAudits.ReadOnly = true;
            dgvArchivedAudits.RowHeadersVisible = false;
            dgvArchivedAudits.RowHeadersWidth = 51;
            dgvArchivedAudits.ScrollBars = ScrollBars.Vertical;
            dgvArchivedAudits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedAudits.Size = new Size(1266, 591);
            dgvArchivedAudits.TabIndex = 1;
            // 
            // dgvArchivedTenants
            // 
            dgvArchivedTenants.AllowUserToAddRows = false;
            dgvArchivedTenants.AllowUserToDeleteRows = false;
            dgvArchivedTenants.AllowUserToResizeRows = false;
            dgvArchivedTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivedTenants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivedTenants.Columns.AddRange(new DataGridViewColumn[] { colTenantArchiveID, colTenantArchivedAt, colArchivedTenantName, colArchivedTenantContact, colArchivedTenantMoveIn, colTenantArchiveAction });
            dgvArchivedTenants.Dock = DockStyle.Fill;
            dgvArchivedTenants.Location = new Point(3, 3);
            dgvArchivedTenants.MultiSelect = false;
            dgvArchivedTenants.Name = "dgvArchivedTenants";
            dgvArchivedTenants.ReadOnly = true;
            dgvArchivedTenants.RowHeadersVisible = false;
            dgvArchivedTenants.RowHeadersWidth = 51;
            dgvArchivedTenants.ScrollBars = ScrollBars.Vertical;
            dgvArchivedTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedTenants.Size = new Size(1266, 591);
            dgvArchivedTenants.TabIndex = 1;
            // 
            // dgvArchivedEmployees
            // 
            dgvArchivedEmployees.AllowUserToAddRows = false;
            dgvArchivedEmployees.AllowUserToDeleteRows = false;
            dgvArchivedEmployees.AllowUserToResizeRows = false;
            dgvArchivedEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivedEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivedEmployees.Columns.AddRange(new DataGridViewColumn[] { colEmployeeArchiveID, colEmployeeArchivedAt, colArchivedEmployeeName, colArchivedEmployeeAddress, colArchivedEmployeeDateHired, colEmployeeArchiveAction });
            dgvArchivedEmployees.Dock = DockStyle.Fill;
            dgvArchivedEmployees.Location = new Point(3, 3);
            dgvArchivedEmployees.MultiSelect = false;
            dgvArchivedEmployees.Name = "dgvArchivedEmployees";
            dgvArchivedEmployees.ReadOnly = true;
            dgvArchivedEmployees.RowHeadersVisible = false;
            dgvArchivedEmployees.RowHeadersWidth = 51;
            dgvArchivedEmployees.ScrollBars = ScrollBars.Vertical;
            dgvArchivedEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivedEmployees.Size = new Size(1266, 591);
            dgvArchivedEmployees.TabIndex = 1;
            // 
            // colRoomArchiveID
            // 
            colRoomArchiveID.HeaderText = "ID";
            colRoomArchiveID.MinimumWidth = 6;
            colRoomArchiveID.Name = "colRoomArchiveID";
            colRoomArchiveID.ReadOnly = true;
            // 
            // colRoomArchivedAt
            // 
            colRoomArchivedAt.HeaderText = "Time Archived";
            colRoomArchivedAt.MinimumWidth = 6;
            colRoomArchivedAt.Name = "colRoomArchivedAt";
            colRoomArchivedAt.ReadOnly = true;
            // 
            // colArchivedRoom
            // 
            colArchivedRoom.HeaderText = "Room";
            colArchivedRoom.MinimumWidth = 6;
            colArchivedRoom.Name = "colArchivedRoom";
            colArchivedRoom.ReadOnly = true;
            // 
            // colRoomArchiveAction
            // 
            colRoomArchiveAction.HeaderText = "Action";
            colRoomArchiveAction.MinimumWidth = 6;
            colRoomArchiveAction.Name = "colRoomArchiveAction";
            colRoomArchiveAction.ReadOnly = true;
            // 
            // colBillAccountArchiveID
            // 
            colBillAccountArchiveID.HeaderText = "ID";
            colBillAccountArchiveID.MinimumWidth = 6;
            colBillAccountArchiveID.Name = "colBillAccountArchiveID";
            colBillAccountArchiveID.ReadOnly = true;
            // 
            // colBillAccountArchivedAt
            // 
            colBillAccountArchivedAt.HeaderText = "Time Archived";
            colBillAccountArchivedAt.MinimumWidth = 6;
            colBillAccountArchivedAt.Name = "colBillAccountArchivedAt";
            colBillAccountArchivedAt.ReadOnly = true;
            // 
            // colArchivedBillAccountType
            // 
            colArchivedBillAccountType.HeaderText = "Type";
            colArchivedBillAccountType.MinimumWidth = 6;
            colArchivedBillAccountType.Name = "colArchivedBillAccountType";
            colArchivedBillAccountType.ReadOnly = true;
            // 
            // colArchivedBillAccountRoom
            // 
            colArchivedBillAccountRoom.HeaderText = "Room";
            colArchivedBillAccountRoom.MinimumWidth = 6;
            colArchivedBillAccountRoom.Name = "colArchivedBillAccountRoom";
            colArchivedBillAccountRoom.ReadOnly = true;
            // 
            // colArchivedBillAccountNumber
            // 
            colArchivedBillAccountNumber.HeaderText = "Account Number";
            colArchivedBillAccountNumber.MinimumWidth = 6;
            colArchivedBillAccountNumber.Name = "colArchivedBillAccountNumber";
            colArchivedBillAccountNumber.ReadOnly = true;
            // 
            // colBillAccountArchiveAction
            // 
            colBillAccountArchiveAction.HeaderText = "Action";
            colBillAccountArchiveAction.MinimumWidth = 6;
            colBillAccountArchiveAction.Name = "colBillAccountArchiveAction";
            colBillAccountArchiveAction.ReadOnly = true;
            // 
            // colAuditArchiveID
            // 
            colAuditArchiveID.HeaderText = "ID";
            colAuditArchiveID.MinimumWidth = 6;
            colAuditArchiveID.Name = "colAuditArchiveID";
            colAuditArchiveID.ReadOnly = true;
            // 
            // colAuditArchivedAt
            // 
            colAuditArchivedAt.HeaderText = "Time Archived";
            colAuditArchivedAt.MinimumWidth = 6;
            colAuditArchivedAt.Name = "colAuditArchivedAt";
            colAuditArchivedAt.ReadOnly = true;
            // 
            // colArchivedAuditCategory
            // 
            colArchivedAuditCategory.HeaderText = "Category";
            colArchivedAuditCategory.MinimumWidth = 6;
            colArchivedAuditCategory.Name = "colArchivedAuditCategory";
            colArchivedAuditCategory.ReadOnly = true;
            // 
            // colArchivedAuditDateTime
            // 
            colArchivedAuditDateTime.HeaderText = "Date & Time Audited";
            colArchivedAuditDateTime.MinimumWidth = 6;
            colArchivedAuditDateTime.Name = "colArchivedAuditDateTime";
            colArchivedAuditDateTime.ReadOnly = true;
            // 
            // colAuditArchiveAction
            // 
            colAuditArchiveAction.HeaderText = "Action";
            colAuditArchiveAction.MinimumWidth = 6;
            colAuditArchiveAction.Name = "colAuditArchiveAction";
            colAuditArchiveAction.ReadOnly = true;
            // 
            // colTenantArchiveID
            // 
            colTenantArchiveID.HeaderText = "ID";
            colTenantArchiveID.MinimumWidth = 6;
            colTenantArchiveID.Name = "colTenantArchiveID";
            colTenantArchiveID.ReadOnly = true;
            // 
            // colTenantArchivedAt
            // 
            colTenantArchivedAt.HeaderText = "Time Archived";
            colTenantArchivedAt.MinimumWidth = 6;
            colTenantArchivedAt.Name = "colTenantArchivedAt";
            colTenantArchivedAt.ReadOnly = true;
            // 
            // colArchivedTenantName
            // 
            colArchivedTenantName.HeaderText = "Tenant Name";
            colArchivedTenantName.MinimumWidth = 6;
            colArchivedTenantName.Name = "colArchivedTenantName";
            colArchivedTenantName.ReadOnly = true;
            // 
            // colArchivedTenantContact
            // 
            colArchivedTenantContact.HeaderText = "Contact";
            colArchivedTenantContact.MinimumWidth = 6;
            colArchivedTenantContact.Name = "colArchivedTenantContact";
            colArchivedTenantContact.ReadOnly = true;
            // 
            // colArchivedTenantMoveIn
            // 
            colArchivedTenantMoveIn.HeaderText = "Move In";
            colArchivedTenantMoveIn.MinimumWidth = 6;
            colArchivedTenantMoveIn.Name = "colArchivedTenantMoveIn";
            colArchivedTenantMoveIn.ReadOnly = true;
            // 
            // colTenantArchiveAction
            // 
            colTenantArchiveAction.HeaderText = "Action";
            colTenantArchiveAction.MinimumWidth = 6;
            colTenantArchiveAction.Name = "colTenantArchiveAction";
            colTenantArchiveAction.ReadOnly = true;
            // 
            // colEmployeeArchiveID
            // 
            colEmployeeArchiveID.HeaderText = "ID";
            colEmployeeArchiveID.MinimumWidth = 6;
            colEmployeeArchiveID.Name = "colEmployeeArchiveID";
            colEmployeeArchiveID.ReadOnly = true;
            // 
            // colEmployeeArchivedAt
            // 
            colEmployeeArchivedAt.HeaderText = "Time Archived";
            colEmployeeArchivedAt.MinimumWidth = 6;
            colEmployeeArchivedAt.Name = "colEmployeeArchivedAt";
            colEmployeeArchivedAt.ReadOnly = true;
            // 
            // colArchivedEmployeeName
            // 
            colArchivedEmployeeName.HeaderText = "Employee Name";
            colArchivedEmployeeName.MinimumWidth = 6;
            colArchivedEmployeeName.Name = "colArchivedEmployeeName";
            colArchivedEmployeeName.ReadOnly = true;
            // 
            // colArchivedEmployeeAddress
            // 
            colArchivedEmployeeAddress.HeaderText = "Address";
            colArchivedEmployeeAddress.MinimumWidth = 6;
            colArchivedEmployeeAddress.Name = "colArchivedEmployeeAddress";
            colArchivedEmployeeAddress.ReadOnly = true;
            // 
            // colArchivedEmployeeDateHired
            // 
            colArchivedEmployeeDateHired.HeaderText = "Date Hired";
            colArchivedEmployeeDateHired.MinimumWidth = 6;
            colArchivedEmployeeDateHired.Name = "colArchivedEmployeeDateHired";
            colArchivedEmployeeDateHired.ReadOnly = true;
            // 
            // colEmployeeArchiveAction
            // 
            colEmployeeArchiveAction.HeaderText = "Action";
            colEmployeeArchiveAction.MinimumWidth = 6;
            colEmployeeArchiveAction.Name = "colEmployeeArchiveAction";
            colEmployeeArchiveAction.ReadOnly = true;
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
            tabArchive.ResumeLayout(false);
            tabRooms.ResumeLayout(false);
            tabBillAccounts.ResumeLayout(false);
            tabAudits.ResumeLayout(false);
            tabTenants.ResumeLayout(false);
            tabEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArchivedRooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedBillAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedAudits).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedTenants).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvArchivedEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlArchiveHeader;
        private Panel pnlArchiveContent;
        private Label lblArchiveTitle;
        private Button btnBackArchive;
        private TabControl tabArchive;
        private TabPage tabRooms;
        private TabPage tabBillAccounts;
        private TabPage tabAudits;
        private TabPage tabTenants;
        private TabPage tabEmployee;
        private DataGridView dgvArchivedRooms;
        private DataGridView dgvArchivedBillAccounts;
        private DataGridView dgvArchivedAudits;
        private DataGridView dgvArchivedTenants;
        private DataGridView dgvArchivedEmployees;
        private DataGridViewTextBoxColumn colRoomArchiveID;
        private DataGridViewTextBoxColumn colRoomArchivedAt;
        private DataGridViewTextBoxColumn colArchivedRoom;
        private DataGridViewButtonColumn colRoomArchiveAction;
        private DataGridViewTextBoxColumn colBillAccountArchiveID;
        private DataGridViewTextBoxColumn colBillAccountArchivedAt;
        private DataGridViewTextBoxColumn colArchivedBillAccountType;
        private DataGridViewTextBoxColumn colArchivedBillAccountRoom;
        private DataGridViewTextBoxColumn colArchivedBillAccountNumber;
        private DataGridViewButtonColumn colBillAccountArchiveAction;
        private DataGridViewTextBoxColumn colAuditArchiveID;
        private DataGridViewTextBoxColumn colAuditArchivedAt;
        private DataGridViewTextBoxColumn colArchivedAuditCategory;
        private DataGridViewTextBoxColumn colArchivedAuditDateTime;
        private DataGridViewButtonColumn colAuditArchiveAction;
        private DataGridViewTextBoxColumn colTenantArchiveID;
        private DataGridViewTextBoxColumn colTenantArchivedAt;
        private DataGridViewTextBoxColumn colArchivedTenantName;
        private DataGridViewTextBoxColumn colArchivedTenantContact;
        private DataGridViewTextBoxColumn colArchivedTenantMoveIn;
        private DataGridViewButtonColumn colTenantArchiveAction;
        private DataGridViewTextBoxColumn colEmployeeArchiveID;
        private DataGridViewTextBoxColumn colEmployeeArchivedAt;
        private DataGridViewTextBoxColumn colArchivedEmployeeName;
        private DataGridViewTextBoxColumn colArchivedEmployeeAddress;
        private DataGridViewTextBoxColumn colArchivedEmployeeDateHired;
        private DataGridViewButtonColumn colEmployeeArchiveAction;
    }
}
