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
            pnlAuditContent = new Panel();
            pnlAuditDate = new Panel();
            pnlAuditModule = new Panel();
            pnlAuditSearch = new Panel();
            pnlAuditFooter = new Panel();
            lblAuditArchiveNotice = new Label();
            label3 = new Label();
            lblAuditModule = new Label();
            label1 = new Label();
            txtSearchAudit = new TextBox();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            dgvAuditLogs = new DataGridView();
            colAuditDateTime = new DataGridViewTextBoxColumn();
            colAuditUser = new DataGridViewTextBoxColumn();
            colAuditRole = new DataGridViewTextBoxColumn();
            colAuditModule = new DataGridViewTextBoxColumn();
            colAuditAction = new DataGridViewTextBoxColumn();
            colAuditDescription = new DataGridViewTextBoxColumn();
            pnlAuditHeader.SuspendLayout();
            pnlAuditContent.SuspendLayout();
            pnlAuditDate.SuspendLayout();
            pnlAuditModule.SuspendLayout();
            pnlAuditSearch.SuspendLayout();
            pnlAuditFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).BeginInit();
            SuspendLayout();
            // 
            // pnlAuditHeader
            // 
            pnlAuditHeader.Controls.Add(pnlAuditDate);
            pnlAuditHeader.Controls.Add(pnlAuditModule);
            pnlAuditHeader.Controls.Add(pnlAuditSearch);
            pnlAuditHeader.Dock = DockStyle.Top;
            pnlAuditHeader.Location = new Point(0, 0);
            pnlAuditHeader.Name = "pnlAuditHeader";
            pnlAuditHeader.Size = new Size(1300, 90);
            pnlAuditHeader.TabIndex = 0;
            // 
            // pnlAuditContent
            // 
            pnlAuditContent.Controls.Add(dgvAuditLogs);
            pnlAuditContent.Dock = DockStyle.Fill;
            pnlAuditContent.Location = new Point(0, 90);
            pnlAuditContent.Name = "pnlAuditContent";
            pnlAuditContent.Size = new Size(1300, 660);
            pnlAuditContent.TabIndex = 1;
            // 
            // pnlAuditDate
            // 
            pnlAuditDate.Controls.Add(dateTimePicker1);
            pnlAuditDate.Controls.Add(label1);
            pnlAuditDate.Dock = DockStyle.Fill;
            pnlAuditDate.Location = new Point(900, 0);
            pnlAuditDate.Name = "pnlAuditDate";
            pnlAuditDate.Size = new Size(400, 90);
            pnlAuditDate.TabIndex = 2;
            // 
            // pnlAuditModule
            // 
            pnlAuditModule.Controls.Add(comboBox1);
            pnlAuditModule.Controls.Add(lblAuditModule);
            pnlAuditModule.Dock = DockStyle.Left;
            pnlAuditModule.Location = new Point(450, 0);
            pnlAuditModule.Name = "pnlAuditModule";
            pnlAuditModule.Size = new Size(450, 90);
            pnlAuditModule.TabIndex = 0;
            // 
            // pnlAuditSearch
            // 
            pnlAuditSearch.Controls.Add(txtSearchAudit);
            pnlAuditSearch.Controls.Add(label3);
            pnlAuditSearch.Dock = DockStyle.Left;
            pnlAuditSearch.Location = new Point(0, 0);
            pnlAuditSearch.Name = "pnlAuditSearch";
            pnlAuditSearch.Size = new Size(450, 90);
            pnlAuditSearch.TabIndex = 1;
            // 
            // pnlAuditFooter
            // 
            pnlAuditFooter.Controls.Add(lblAuditArchiveNotice);
            pnlAuditFooter.Dock = DockStyle.Bottom;
            pnlAuditFooter.Location = new Point(0, 690);
            pnlAuditFooter.Name = "pnlAuditFooter";
            pnlAuditFooter.Size = new Size(1300, 60);
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
            lblAuditArchiveNotice.Size = new Size(1300, 60);
            lblAuditArchiveNotice.TabIndex = 37;
            lblAuditArchiveNotice.Text = "Logs older than 30 days are automatically archived.";
            lblAuditArchiveNotice.TextAlign = ContentAlignment.MiddleCenter;
            lblAuditArchiveNotice.Visible = false;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.ImageAlign = ContentAlignment.MiddleRight;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(450, 40);
            label3.TabIndex = 40;
            label3.Text = "Search";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Visible = false;
            // 
            // lblAuditModule
            // 
            lblAuditModule.Dock = DockStyle.Top;
            lblAuditModule.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuditModule.ForeColor = Color.White;
            lblAuditModule.ImageAlign = ContentAlignment.MiddleRight;
            lblAuditModule.Location = new Point(0, 0);
            lblAuditModule.Name = "lblAuditModule";
            lblAuditModule.Size = new Size(450, 40);
            lblAuditModule.TabIndex = 40;
            lblAuditModule.Text = "Module";
            lblAuditModule.TextAlign = ContentAlignment.MiddleCenter;
            lblAuditModule.Visible = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(400, 40);
            label1.TabIndex = 39;
            label1.Text = "Date";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Visible = false;
            // 
            // txtSearchAudit
            // 
            txtSearchAudit.Dock = DockStyle.Fill;
            txtSearchAudit.Location = new Point(0, 40);
            txtSearchAudit.Name = "txtSearchAudit";
            txtSearchAudit.Size = new Size(450, 27);
            txtSearchAudit.TabIndex = 41;
            txtSearchAudit.Text = "Search Audit Logs";
            txtSearchAudit.TextAlign = HorizontalAlignment.Center;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(0, 40);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(450, 28);
            comboBox1.TabIndex = 41;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Location = new Point(0, 40);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(400, 27);
            dateTimePicker1.TabIndex = 40;
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
            dgvAuditLogs.Size = new Size(1300, 660);
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
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlAuditFooter);
            Controls.Add(pnlAuditContent);
            Controls.Add(pnlAuditHeader);
            Name = "AuditLogsControl";
            Size = new Size(1300, 750);
            pnlAuditHeader.ResumeLayout(false);
            pnlAuditContent.ResumeLayout(false);
            pnlAuditDate.ResumeLayout(false);
            pnlAuditModule.ResumeLayout(false);
            pnlAuditSearch.ResumeLayout(false);
            pnlAuditSearch.PerformLayout();
            pnlAuditFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAuditHeader;
        private Panel pnlAuditDate;
        private Panel pnlAuditSearch;
        private Panel pnlAuditModule;
        private Panel pnlAuditContent;
        private Panel pnlAuditFooter;
        private Label lblAuditArchiveNotice;
        private Label label1;
        private Label lblAuditModule;
        private Label label3;
        private TextBox txtSearchAudit;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private DataGridView dgvAuditLogs;
        private DataGridViewTextBoxColumn colAuditDateTime;
        private DataGridViewTextBoxColumn colAuditUser;
        private DataGridViewTextBoxColumn colAuditRole;
        private DataGridViewTextBoxColumn colAuditModule;
        private DataGridViewTextBoxColumn colAuditAction;
        private DataGridViewTextBoxColumn colAuditDescription;
    }
}
