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
            pnlAuditFilter = new Panel();
            btnAuditClear = new Button();
            dtpAuditTo = new DateTimePicker();
            lblAuditTo = new Label();
            dtpAuditFrom = new DateTimePicker();
            lblAuditFrom = new Label();
            cboAuditModule = new ComboBox();
            lblAuditModule = new Label();
            txtAuditSearch = new TextBox();
            lblAuditSearch = new Label();
            pnlAuditFooter = new Panel();
            lblAuditCount = new Label();
            pnlAuditContent = new Panel();
            dgvAuditLogs = new DataGridView();
            pnlAuditHeader.SuspendLayout();
            pnlAuditFilter.SuspendLayout();
            pnlAuditFooter.SuspendLayout();
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
            pnlAuditHeader.Size = new Size(1280, 75);
            pnlAuditHeader.TabIndex = 0;
            // 
            // lblAuditTitle
            // 
            lblAuditTitle.Dock = DockStyle.Fill;
            lblAuditTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuditTitle.ForeColor = Color.White;
            lblAuditTitle.Location = new Point(0, 0);
            lblAuditTitle.Name = "lblAuditTitle";
            lblAuditTitle.Size = new Size(1278, 73);
            lblAuditTitle.TabIndex = 0;
            lblAuditTitle.Text = "Audit Logs";
            lblAuditTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAuditFilter
            // 
            pnlAuditFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlAuditFilter.Controls.Add(btnAuditClear);
            pnlAuditFilter.Controls.Add(dtpAuditTo);
            pnlAuditFilter.Controls.Add(lblAuditTo);
            pnlAuditFilter.Controls.Add(dtpAuditFrom);
            pnlAuditFilter.Controls.Add(lblAuditFrom);
            pnlAuditFilter.Controls.Add(cboAuditModule);
            pnlAuditFilter.Controls.Add(lblAuditModule);
            pnlAuditFilter.Controls.Add(txtAuditSearch);
            pnlAuditFilter.Controls.Add(lblAuditSearch);
            pnlAuditFilter.Dock = DockStyle.Top;
            pnlAuditFilter.Location = new Point(10, 85);
            pnlAuditFilter.Name = "pnlAuditFilter";
            pnlAuditFilter.Size = new Size(1280, 75);
            pnlAuditFilter.TabIndex = 1;
            // 
            // btnAuditClear
            // 
            btnAuditClear.Font = new Font("Segoe UI", 10.2F);
            btnAuditClear.Location = new Point(945, 30);
            btnAuditClear.Name = "btnAuditClear";
            btnAuditClear.Size = new Size(100, 33);
            btnAuditClear.TabIndex = 8;
            btnAuditClear.Text = "Clear";
            btnAuditClear.UseVisualStyleBackColor = true;
            // 
            // dtpAuditTo
            // 
            dtpAuditTo.CustomFormat = "MMM dd, yyyy";
            dtpAuditTo.Font = new Font("Segoe UI", 10.2F);
            dtpAuditTo.Format = DateTimePickerFormat.Custom;
            dtpAuditTo.Location = new Point(755, 32);
            dtpAuditTo.Name = "dtpAuditTo";
            dtpAuditTo.Size = new Size(170, 30);
            dtpAuditTo.TabIndex = 7;
            // 
            // lblAuditTo
            // 
            lblAuditTo.AutoSize = true;
            lblAuditTo.Font = new Font("Segoe UI", 10.2F);
            lblAuditTo.ForeColor = Color.White;
            lblAuditTo.Location = new Point(755, 6);
            lblAuditTo.Name = "lblAuditTo";
            lblAuditTo.Size = new Size(68, 23);
            lblAuditTo.TabIndex = 6;
            lblAuditTo.Text = "Date To";
            // 
            // dtpAuditFrom
            // 
            dtpAuditFrom.CustomFormat = "MMM dd, yyyy";
            dtpAuditFrom.Font = new Font("Segoe UI", 10.2F);
            dtpAuditFrom.Format = DateTimePickerFormat.Custom;
            dtpAuditFrom.Location = new Point(570, 32);
            dtpAuditFrom.Name = "dtpAuditFrom";
            dtpAuditFrom.Size = new Size(170, 30);
            dtpAuditFrom.TabIndex = 5;
            // 
            // lblAuditFrom
            // 
            lblAuditFrom.AutoSize = true;
            lblAuditFrom.Font = new Font("Segoe UI", 10.2F);
            lblAuditFrom.ForeColor = Color.White;
            lblAuditFrom.Location = new Point(570, 6);
            lblAuditFrom.Name = "lblAuditFrom";
            lblAuditFrom.Size = new Size(90, 23);
            lblAuditFrom.TabIndex = 4;
            lblAuditFrom.Text = "Date From";
            // 
            // cboAuditModule
            // 
            cboAuditModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAuditModule.Font = new Font("Segoe UI", 10.2F);
            cboAuditModule.FormattingEnabled = true;
            cboAuditModule.Location = new Point(350, 31);
            cboAuditModule.Name = "cboAuditModule";
            cboAuditModule.Size = new Size(200, 31);
            cboAuditModule.TabIndex = 3;
            // 
            // lblAuditModule
            // 
            lblAuditModule.AutoSize = true;
            lblAuditModule.Font = new Font("Segoe UI", 10.2F);
            lblAuditModule.ForeColor = Color.White;
            lblAuditModule.Location = new Point(350, 6);
            lblAuditModule.Name = "lblAuditModule";
            lblAuditModule.Size = new Size(68, 23);
            lblAuditModule.TabIndex = 2;
            lblAuditModule.Text = "Module";
            // 
            // txtAuditSearch
            // 
            txtAuditSearch.Font = new Font("Segoe UI", 10.2F);
            txtAuditSearch.Location = new Point(12, 32);
            txtAuditSearch.MaxLength = 100;
            txtAuditSearch.Name = "txtAuditSearch";
            txtAuditSearch.PlaceholderText = "User, action or description";
            txtAuditSearch.Size = new Size(320, 30);
            txtAuditSearch.TabIndex = 1;
            // 
            // lblAuditSearch
            // 
            lblAuditSearch.AutoSize = true;
            lblAuditSearch.Font = new Font("Segoe UI", 10.2F);
            lblAuditSearch.ForeColor = Color.White;
            lblAuditSearch.Location = new Point(12, 6);
            lblAuditSearch.Name = "lblAuditSearch";
            lblAuditSearch.Size = new Size(61, 23);
            lblAuditSearch.TabIndex = 0;
            lblAuditSearch.Text = "Search";
            // 
            // pnlAuditFooter
            // 
            pnlAuditFooter.BorderStyle = BorderStyle.FixedSingle;
            pnlAuditFooter.Controls.Add(lblAuditCount);
            pnlAuditFooter.Dock = DockStyle.Bottom;
            pnlAuditFooter.Location = new Point(10, 700);
            pnlAuditFooter.Name = "pnlAuditFooter";
            pnlAuditFooter.Size = new Size(1280, 40);
            pnlAuditFooter.TabIndex = 3;
            // 
            // lblAuditCount
            // 
            lblAuditCount.Dock = DockStyle.Fill;
            lblAuditCount.Font = new Font("Segoe UI", 10.2F);
            lblAuditCount.ForeColor = Color.White;
            lblAuditCount.Location = new Point(0, 0);
            lblAuditCount.Name = "lblAuditCount";
            lblAuditCount.Size = new Size(1278, 38);
            lblAuditCount.TabIndex = 0;
            lblAuditCount.Text = "0 entries";
            lblAuditCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAuditContent
            // 
            pnlAuditContent.BorderStyle = BorderStyle.FixedSingle;
            pnlAuditContent.Controls.Add(dgvAuditLogs);
            pnlAuditContent.Dock = DockStyle.Fill;
            pnlAuditContent.Location = new Point(10, 160);
            pnlAuditContent.Name = "pnlAuditContent";
            pnlAuditContent.Size = new Size(1280, 540);
            pnlAuditContent.TabIndex = 2;
            // 
            // dgvAuditLogs
            // 
            dgvAuditLogs.ColumnHeadersHeight = 29;
            dgvAuditLogs.Dock = DockStyle.Fill;
            dgvAuditLogs.Location = new Point(0, 0);
            dgvAuditLogs.Name = "dgvAuditLogs";
            dgvAuditLogs.RowHeadersWidth = 51;
            dgvAuditLogs.Size = new Size(1278, 538);
            dgvAuditLogs.TabIndex = 0;
            // 
            // AuditLogsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            Controls.Add(pnlAuditContent);
            Controls.Add(pnlAuditFooter);
            Controls.Add(pnlAuditFilter);
            Controls.Add(pnlAuditHeader);
            Name = "AuditLogsControl";
            Padding = new Padding(10);
            Size = new Size(1300, 750);
            pnlAuditHeader.ResumeLayout(false);
            pnlAuditFilter.ResumeLayout(false);
            pnlAuditFilter.PerformLayout();
            pnlAuditFooter.ResumeLayout(false);
            pnlAuditContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAuditHeader;
        private Label lblAuditTitle;
        private Panel pnlAuditFilter;
        private Label lblAuditSearch;
        private TextBox txtAuditSearch;
        private Label lblAuditModule;
        private ComboBox cboAuditModule;
        private Label lblAuditFrom;
        private DateTimePicker dtpAuditFrom;
        private Label lblAuditTo;
        private DateTimePicker dtpAuditTo;
        private Button btnAuditClear;
        private Panel pnlAuditFooter;
        private Label lblAuditCount;
        private Panel pnlAuditContent;
        private DataGridView dgvAuditLogs;
    }
}
