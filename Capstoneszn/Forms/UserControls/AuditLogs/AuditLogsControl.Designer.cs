namespace Capstoneszn.UserControls
{
    partial class AuditLogsControl
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
            pnlAuditHeader = new Panel();
            lblAuditTitle = new Label();
            pnlAuditFooter = new Panel();
            lblAuditArchiveNotice = new Label();
            pnlAuditContentHeader = new Panel();
            pnlAuditDate = new Panel();
            dtpAudit = new DateTimePicker();
            lblAuditDate = new Label();
            pnlAuditModule = new Panel();
            cboAuditModule = new ComboBox();
            lblAuditModule = new Label();
            pnlAuditSearch = new Panel();
            txtAuditSearch = new TextBox();
            lblAuditSearch = new Label();
            pnlAuditContent = new Panel();
            dgvAuditLogs = new DataGridView();
            colAuditDateTime = new DataGridViewTextBoxColumn();
            colAuditUser = new DataGridViewTextBoxColumn();
            colAuditRole = new DataGridViewTextBoxColumn();
            colAuditModule = new DataGridViewTextBoxColumn();
            colAuditAction = new DataGridViewTextBoxColumn();
            colAuditDescription = new DataGridViewTextBoxColumn();
            pnlAuditHeader.SuspendLayout();
            pnlAuditFooter.SuspendLayout();
            pnlAuditContentHeader.SuspendLayout();
            pnlAuditDate.SuspendLayout();
            pnlAuditModule.SuspendLayout();
            pnlAuditSearch.SuspendLayout();
            pnlAuditContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).BeginInit();
            SuspendLayout();
            // 
            // pnlAuditHeader
            // 
            pnlAuditHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlAuditHeader.Controls.Add(lblAuditTitle);
            pnlAuditHeader.Dock = DockStyle.Top;
            pnlAuditHeader.Location = new Point(10, 10);
            pnlAuditHeader.Name = "pnlAuditHeader";
            pnlAuditHeader.Size = new Size(1280, 85);
            pnlAuditHeader.TabIndex = 0;
            // 
            // lblAuditTitle
            // 
            lblAuditTitle.Dock = DockStyle.Fill;
            lblAuditTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuditTitle.ForeColor = Color.White;
            lblAuditTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAuditTitle.Location = new Point(0, 0);
            lblAuditTitle.Name = "lblAuditTitle";
            lblAuditTitle.Size = new Size(1278, 83);
            lblAuditTitle.TabIndex = 5;
            lblAuditTitle.Text = "Audit Logs";
            lblAuditTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAuditFooter
            // 
            pnlAuditFooter.BorderStyle = BorderStyle.FixedSingle;
            pnlAuditFooter.Controls.Add(lblAuditArchiveNotice);
            pnlAuditFooter.Dock = DockStyle.Bottom;
            pnlAuditFooter.Location = new Point(10, 690);
            pnlAuditFooter.Name = "pnlAuditFooter";
            pnlAuditFooter.Size = new Size(1280, 50);
            pnlAuditFooter.TabIndex = 2;
            // 
            // lblAuditArchiveNotice
            // 
            lblAuditArchiveNotice.Dock = DockStyle.Fill;
            lblAuditArchiveNotice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuditArchiveNotice.ForeColor = Color.White;
            lblAuditArchiveNotice.ImageAlign = ContentAlignment.MiddleRight;
            lblAuditArchiveNotice.Location = new Point(0, 0);
            lblAuditArchiveNotice.Name = "lblAuditArchiveNotice";
            lblAuditArchiveNotice.Size = new Size(1278, 48);
            lblAuditArchiveNotice.TabIndex = 37;
            lblAuditArchiveNotice.Text = "Logs older than 30 days are automatically archived.";
            lblAuditArchiveNotice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAuditContentHeader
            // 
            pnlAuditContentHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlAuditContentHeader.Controls.Add(pnlAuditDate);
            pnlAuditContentHeader.Controls.Add(pnlAuditModule);
            pnlAuditContentHeader.Controls.Add(pnlAuditSearch);
            pnlAuditContentHeader.Dock = DockStyle.Top;
            pnlAuditContentHeader.Location = new Point(10, 95);
            pnlAuditContentHeader.Name = "pnlAuditContentHeader";
            pnlAuditContentHeader.Size = new Size(1280, 75);
            pnlAuditContentHeader.TabIndex = 3;
            // 
            // pnlAuditDate
            // 
            pnlAuditDate.Controls.Add(dtpAudit);
            pnlAuditDate.Controls.Add(lblAuditDate);
            pnlAuditDate.Dock = DockStyle.Fill;
            pnlAuditDate.Location = new Point(900, 0);
            pnlAuditDate.Name = "pnlAuditDate";
            pnlAuditDate.Padding = new Padding(5, 0, 5, 0);
            pnlAuditDate.Size = new Size(378, 73);
            pnlAuditDate.TabIndex = 4;
            // 
            // dtpAudit
            // 
            dtpAudit.Cursor = Cursors.Hand;
            dtpAudit.Dock = DockStyle.Fill;
            dtpAudit.Location = new Point(5, 40);
            dtpAudit.Name = "dtpAudit";
            dtpAudit.Size = new Size(368, 27);
            dtpAudit.TabIndex = 40;
            // 
            // lblAuditDate
            // 
            lblAuditDate.Dock = DockStyle.Top;
            lblAuditDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuditDate.ForeColor = Color.White;
            lblAuditDate.ImageAlign = ContentAlignment.MiddleRight;
            lblAuditDate.Location = new Point(5, 0);
            lblAuditDate.Name = "lblAuditDate";
            lblAuditDate.Size = new Size(368, 40);
            lblAuditDate.TabIndex = 39;
            lblAuditDate.Text = "Date";
            lblAuditDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAuditModule
            // 
            pnlAuditModule.Controls.Add(cboAuditModule);
            pnlAuditModule.Controls.Add(lblAuditModule);
            pnlAuditModule.Dock = DockStyle.Left;
            pnlAuditModule.Location = new Point(450, 0);
            pnlAuditModule.Name = "pnlAuditModule";
            pnlAuditModule.Padding = new Padding(5, 0, 5, 0);
            pnlAuditModule.Size = new Size(450, 73);
            pnlAuditModule.TabIndex = 3;
            // 
            // cboAuditModule
            // 
            cboAuditModule.Cursor = Cursors.Hand;
            cboAuditModule.Dock = DockStyle.Fill;
            cboAuditModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAuditModule.FormattingEnabled = true;
            cboAuditModule.Location = new Point(5, 39);
            cboAuditModule.Name = "cboAuditModule";
            cboAuditModule.Size = new Size(440, 28);
            cboAuditModule.TabIndex = 41;
            // 
            // lblAuditModule
            // 
            lblAuditModule.Dock = DockStyle.Top;
            lblAuditModule.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuditModule.ForeColor = Color.White;
            lblAuditModule.ImageAlign = ContentAlignment.MiddleRight;
            lblAuditModule.Location = new Point(5, 0);
            lblAuditModule.Name = "lblAuditModule";
            lblAuditModule.Size = new Size(440, 39);
            lblAuditModule.TabIndex = 40;
            lblAuditModule.Text = "Module";
            lblAuditModule.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAuditSearch
            // 
            pnlAuditSearch.Controls.Add(txtAuditSearch);
            pnlAuditSearch.Controls.Add(lblAuditSearch);
            pnlAuditSearch.Dock = DockStyle.Left;
            pnlAuditSearch.Location = new Point(0, 0);
            pnlAuditSearch.Name = "pnlAuditSearch";
            pnlAuditSearch.Padding = new Padding(5, 0, 5, 0);
            pnlAuditSearch.Size = new Size(450, 73);
            pnlAuditSearch.TabIndex = 2;
            // 
            // txtAuditSearch
            // 
            txtAuditSearch.Cursor = Cursors.IBeam;
            txtAuditSearch.Dock = DockStyle.Fill;
            txtAuditSearch.Location = new Point(5, 40);
            txtAuditSearch.Name = "txtAuditSearch";
            txtAuditSearch.Size = new Size(440, 27);
            txtAuditSearch.TabIndex = 41;
            txtAuditSearch.Text = "Search Audit Logs";
            txtAuditSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // lblAuditSearch
            // 
            lblAuditSearch.Dock = DockStyle.Top;
            lblAuditSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuditSearch.ForeColor = Color.White;
            lblAuditSearch.ImageAlign = ContentAlignment.MiddleRight;
            lblAuditSearch.Location = new Point(5, 0);
            lblAuditSearch.Name = "lblAuditSearch";
            lblAuditSearch.Size = new Size(440, 40);
            lblAuditSearch.TabIndex = 40;
            lblAuditSearch.Text = "Search";
            lblAuditSearch.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAuditContent
            // 
            pnlAuditContent.BorderStyle = BorderStyle.FixedSingle;
            pnlAuditContent.Controls.Add(dgvAuditLogs);
            pnlAuditContent.Dock = DockStyle.Fill;
            pnlAuditContent.Location = new Point(10, 170);
            pnlAuditContent.Name = "pnlAuditContent";
            pnlAuditContent.Size = new Size(1280, 520);
            pnlAuditContent.TabIndex = 4;
            // 
            // dgvAuditLogs
            // 
            dgvAuditLogs.AllowUserToAddRows = false;
            dgvAuditLogs.AllowUserToDeleteRows = false;
            dgvAuditLogs.AllowUserToResizeRows = false;
            dgvAuditLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditLogs.Columns.AddRange(new DataGridViewColumn[] { colAuditDateTime, colAuditUser, colAuditRole, colAuditModule, colAuditAction, colAuditDescription });
            dgvAuditLogs.Dock = DockStyle.Fill;
            dgvAuditLogs.Location = new Point(0, 0);
            dgvAuditLogs.MultiSelect = false;
            dgvAuditLogs.Name = "dgvAuditLogs";
            dgvAuditLogs.ReadOnly = true;
            dgvAuditLogs.RowHeadersVisible = false;
            dgvAuditLogs.RowHeadersWidth = 51;
            dgvAuditLogs.ScrollBars = ScrollBars.Vertical;
            dgvAuditLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditLogs.Size = new Size(1278, 518);
            dgvAuditLogs.TabIndex = 0;
            // 
            // colAuditDateTime
            // 
            colAuditDateTime.HeaderText = "Date & Time";
            colAuditDateTime.MinimumWidth = 6;
            colAuditDateTime.Name = "colAuditDateTime";
            colAuditDateTime.ReadOnly = true;
            // 
            // colAuditUser
            // 
            colAuditUser.HeaderText = "User";
            colAuditUser.MinimumWidth = 6;
            colAuditUser.Name = "colAuditUser";
            colAuditUser.ReadOnly = true;
            // 
            // colAuditRole
            // 
            colAuditRole.HeaderText = "Role";
            colAuditRole.MinimumWidth = 6;
            colAuditRole.Name = "colAuditRole";
            colAuditRole.ReadOnly = true;
            // 
            // colAuditModule
            // 
            colAuditModule.HeaderText = "Module";
            colAuditModule.MinimumWidth = 6;
            colAuditModule.Name = "colAuditModule";
            colAuditModule.ReadOnly = true;
            // 
            // colAuditAction
            // 
            colAuditAction.HeaderText = "Action";
            colAuditAction.MinimumWidth = 6;
            colAuditAction.Name = "colAuditAction";
            colAuditAction.ReadOnly = true;
            // 
            // colAuditDescription
            // 
            colAuditDescription.HeaderText = "Description";
            colAuditDescription.MinimumWidth = 6;
            colAuditDescription.Name = "colAuditDescription";
            colAuditDescription.ReadOnly = true;
            // 
            // AuditLogsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlAuditContent);
            Controls.Add(pnlAuditContentHeader);
            Controls.Add(pnlAuditFooter);
            Controls.Add(pnlAuditHeader);
            Name = "AuditLogsControl";
            Padding = new Padding(10);
            Size = new Size(1300, 750);
            pnlAuditHeader.ResumeLayout(false);
            pnlAuditFooter.ResumeLayout(false);
            pnlAuditContentHeader.ResumeLayout(false);
            pnlAuditDate.ResumeLayout(false);
            pnlAuditModule.ResumeLayout(false);
            pnlAuditSearch.ResumeLayout(false);
            pnlAuditSearch.PerformLayout();
            pnlAuditContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAuditHeader;
        private Panel pnlAuditFooter;
        private Label lblAuditArchiveNotice;
        private Panel pnlAuditContentHeader;
        private Panel pnlAuditContent;
        private DataGridView dgvAuditLogs;
        private DataGridViewTextBoxColumn colAuditDateTime;
        private DataGridViewTextBoxColumn colAuditUser;
        private DataGridViewTextBoxColumn colAuditRole;
        private DataGridViewTextBoxColumn colAuditModule;
        private DataGridViewTextBoxColumn colAuditAction;
        private DataGridViewTextBoxColumn colAuditDescription;
        private Panel pnlAuditDate;
        private DateTimePicker dtpAudit;
        private Label lblAuditDate;
        private Panel pnlAuditModule;
        private ComboBox cboAuditModule;
        private Label lblAuditModule;
        private Panel pnlAuditSearch;
        private TextBox txtAuditSearch;
        private Label lblAuditSearch;
        private Label lblAuditTitle;
    }
}
