namespace Capstoneszn.UserControls
{
    partial class PaymentHistoryControl
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
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            pnlPaymentHistoryHeader = new Panel();
            lblPaymentHistoryTitle = new Label();
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            pnlPaymentHistoryContent = new Panel();
            tabPaymentHistory = new TabControl();
            tabRent = new TabPage();
            dgvRent = new DataGridView();
            colRentDate = new DataGridViewTextBoxColumn();
            colRentTime = new DataGridViewTextBoxColumn();
            colRentRoom = new DataGridViewTextBoxColumn();
            colRentType = new DataGridViewTextBoxColumn();
            colRentTag = new DataGridViewTextBoxColumn();
            colRentMethod = new DataGridViewTextBoxColumn();
            colRentAmount = new DataGridViewTextBoxColumn();
            colRentReceipt = new DataGridViewButtonColumn();
            tabMaintenance = new TabPage();
            dgvMaintenance = new DataGridView();
            colMaintenanceDate = new DataGridViewTextBoxColumn();
            colMaintenanceTime = new DataGridViewTextBoxColumn();
            colMaintenanceRoom = new DataGridViewTextBoxColumn();
            colMaintenanceResponsible = new DataGridViewTextBoxColumn();
            colMaintenanceIssue = new DataGridViewTextBoxColumn();
            colMaintenanceAmount = new DataGridViewTextBoxColumn();
            colMaintenanceReceipt = new DataGridViewButtonColumn();
            tabUtilities = new TabPage();
            dgvUtilities = new DataGridView();
            colUtilitiesDate = new DataGridViewTextBoxColumn();
            colUtilitiesTime = new DataGridViewTextBoxColumn();
            colUtilitiesUtility = new DataGridViewTextBoxColumn();
            colUtilitiesAmount = new DataGridViewTextBoxColumn();
            colUtilitiesReceipt = new DataGridViewButtonColumn();
            pnlPaymentHistoryHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlPaymentHistoryContent.SuspendLayout();
            tabPaymentHistory.SuspendLayout();
            tabRent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRent).BeginInit();
            tabMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).BeginInit();
            tabUtilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUtilities).BeginInit();
            SuspendLayout();
            // 
            // pnlPaymentHistoryHeader
            // 
            pnlPaymentHistoryHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentHistoryHeader.Controls.Add(lblPaymentHistoryTitle);
            pnlPaymentHistoryHeader.Dock = DockStyle.Top;
            pnlPaymentHistoryHeader.Location = new Point(0, 0);
            pnlPaymentHistoryHeader.Name = "pnlPaymentHistoryHeader";
            pnlPaymentHistoryHeader.Size = new Size(1300, 80);
            pnlPaymentHistoryHeader.TabIndex = 0;
            // 
            // lblPaymentHistoryTitle
            // 
            lblPaymentHistoryTitle.BorderStyle = BorderStyle.FixedSingle;
            lblPaymentHistoryTitle.Dock = DockStyle.Fill;
            lblPaymentHistoryTitle.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentHistoryTitle.ForeColor = Color.White;
            lblPaymentHistoryTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentHistoryTitle.Location = new Point(0, 0);
            lblPaymentHistoryTitle.Name = "lblPaymentHistoryTitle";
            lblPaymentHistoryTitle.Size = new Size(1298, 78);
            lblPaymentHistoryTitle.TabIndex = 7;
            lblPaymentHistoryTitle.Text = "Payment History";
            lblPaymentHistoryTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSearch
            // 
            pnlSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 80);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1300, 60);
            pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Cursor = Cursors.IBeam;
            txtSearch.Location = new Point(5, 9);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(376, 40);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Search History";
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // pnlPaymentHistoryContent
            // 
            pnlPaymentHistoryContent.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentHistoryContent.Controls.Add(tabPaymentHistory);
            pnlPaymentHistoryContent.Dock = DockStyle.Fill;
            pnlPaymentHistoryContent.Location = new Point(0, 140);
            pnlPaymentHistoryContent.Name = "pnlPaymentHistoryContent";
            pnlPaymentHistoryContent.Size = new Size(1300, 610);
            pnlPaymentHistoryContent.TabIndex = 2;
            // 
            // tabPaymentHistory
            // 
            tabPaymentHistory.Controls.Add(tabRent);
            tabPaymentHistory.Controls.Add(tabMaintenance);
            tabPaymentHistory.Controls.Add(tabUtilities);
            tabPaymentHistory.Dock = DockStyle.Fill;
            tabPaymentHistory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPaymentHistory.Location = new Point(0, 0);
            tabPaymentHistory.Name = "tabPaymentHistory";
            tabPaymentHistory.SelectedIndex = 0;
            tabPaymentHistory.Size = new Size(1298, 608);
            tabPaymentHistory.TabIndex = 0;
            // 
            // tabRent
            // 
            tabRent.BackColor = Color.FromArgb(11, 20, 38);
            tabRent.Controls.Add(dgvRent);
            tabRent.Location = new Point(4, 37);
            tabRent.Name = "tabRent";
            tabRent.Padding = new Padding(3);
            tabRent.Size = new Size(1290, 567);
            tabRent.TabIndex = 0;
            tabRent.Text = "Rent";
            // 
            // dgvRent
            // 
            dgvRent.AllowUserToAddRows = false;
            dgvRent.AllowUserToDeleteRows = false;
            dgvRent.AllowUserToResizeColumns = false;
            dgvRent.AllowUserToResizeRows = false;
            dgvRent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRent.BorderStyle = BorderStyle.None;
            dgvRent.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = SystemColors.Control;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dgvRent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dgvRent.ColumnHeadersHeight = 35;
            dgvRent.Columns.AddRange(new DataGridViewColumn[] { colRentDate, colRentTime, colRentRoom, colRentType, colRentTag, colRentMethod, colRentAmount, colRentReceipt });
            dgvRent.Cursor = Cursors.Hand;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = SystemColors.Window;
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle16.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            dgvRent.DefaultCellStyle = dataGridViewCellStyle16;
            dgvRent.Dock = DockStyle.Fill;
            dgvRent.Location = new Point(3, 3);
            dgvRent.MultiSelect = false;
            dgvRent.Name = "dgvRent";
            dgvRent.ReadOnly = true;
            dgvRent.RowHeadersVisible = false;
            dgvRent.RowHeadersWidth = 51;
            dgvRent.RowTemplate.Height = 35;
            dgvRent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRent.Size = new Size(1284, 561);
            dgvRent.TabIndex = 5;
            // 
            // colRentDate
            // 
            colRentDate.HeaderText = "Date";
            colRentDate.MinimumWidth = 6;
            colRentDate.Name = "colRentDate";
            colRentDate.ReadOnly = true;
            // 
            // colRentTime
            // 
            colRentTime.HeaderText = "Time";
            colRentTime.MinimumWidth = 6;
            colRentTime.Name = "colRentTime";
            colRentTime.ReadOnly = true;
            // 
            // colRentRoom
            // 
            colRentRoom.HeaderText = "Room";
            colRentRoom.MinimumWidth = 6;
            colRentRoom.Name = "colRentRoom";
            colRentRoom.ReadOnly = true;
            // 
            // colRentType
            // 
            colRentType.HeaderText = "Type";
            colRentType.MinimumWidth = 6;
            colRentType.Name = "colRentType";
            colRentType.ReadOnly = true;
            // 
            // colRentTag
            // 
            colRentTag.HeaderText = "Tag";
            colRentTag.MinimumWidth = 6;
            colRentTag.Name = "colRentTag";
            colRentTag.ReadOnly = true;
            // 
            // colRentMethod
            // 
            colRentMethod.HeaderText = "Method";
            colRentMethod.MinimumWidth = 6;
            colRentMethod.Name = "colRentMethod";
            colRentMethod.ReadOnly = true;
            // 
            // colRentAmount
            // 
            colRentAmount.HeaderText = "Amount";
            colRentAmount.MinimumWidth = 6;
            colRentAmount.Name = "colRentAmount";
            colRentAmount.ReadOnly = true;
            // 
            // colRentReceipt
            // 
            colRentReceipt.HeaderText = "Receipt";
            colRentReceipt.MinimumWidth = 6;
            colRentReceipt.Name = "colRentReceipt";
            colRentReceipt.ReadOnly = true;
            // 
            // tabMaintenance
            // 
            tabMaintenance.BackColor = Color.FromArgb(11, 20, 38);
            tabMaintenance.Controls.Add(dgvMaintenance);
            tabMaintenance.Location = new Point(4, 37);
            tabMaintenance.Name = "tabMaintenance";
            tabMaintenance.Padding = new Padding(3);
            tabMaintenance.Size = new Size(1290, 567);
            tabMaintenance.TabIndex = 1;
            tabMaintenance.Text = "Maintenance";
            // 
            // dgvMaintenance
            // 
            dgvMaintenance.AllowUserToAddRows = false;
            dgvMaintenance.AllowUserToDeleteRows = false;
            dgvMaintenance.AllowUserToResizeColumns = false;
            dgvMaintenance.AllowUserToResizeRows = false;
            dgvMaintenance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaintenance.BorderStyle = BorderStyle.None;
            dgvMaintenance.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = SystemColors.Control;
            dataGridViewCellStyle17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle17.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgvMaintenance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgvMaintenance.ColumnHeadersHeight = 35;
            dgvMaintenance.Columns.AddRange(new DataGridViewColumn[] { colMaintenanceDate, colMaintenanceTime, colMaintenanceRoom, colMaintenanceResponsible, colMaintenanceIssue, colMaintenanceAmount, colMaintenanceReceipt });
            dgvMaintenance.Cursor = Cursors.Hand;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = SystemColors.Window;
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle18.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dgvMaintenance.DefaultCellStyle = dataGridViewCellStyle18;
            dgvMaintenance.Dock = DockStyle.Fill;
            dgvMaintenance.Location = new Point(3, 3);
            dgvMaintenance.MultiSelect = false;
            dgvMaintenance.Name = "dgvMaintenance";
            dgvMaintenance.ReadOnly = true;
            dgvMaintenance.RowHeadersVisible = false;
            dgvMaintenance.RowHeadersWidth = 51;
            dgvMaintenance.RowTemplate.Height = 35;
            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaintenance.Size = new Size(1284, 561);
            dgvMaintenance.TabIndex = 6;
            // 
            // colMaintenanceDate
            // 
            colMaintenanceDate.HeaderText = "Date";
            colMaintenanceDate.MinimumWidth = 6;
            colMaintenanceDate.Name = "colMaintenanceDate";
            colMaintenanceDate.ReadOnly = true;
            // 
            // colMaintenanceTime
            // 
            colMaintenanceTime.HeaderText = "Time";
            colMaintenanceTime.MinimumWidth = 6;
            colMaintenanceTime.Name = "colMaintenanceTime";
            colMaintenanceTime.ReadOnly = true;
            // 
            // colMaintenanceRoom
            // 
            colMaintenanceRoom.HeaderText = "Room";
            colMaintenanceRoom.MinimumWidth = 6;
            colMaintenanceRoom.Name = "colMaintenanceRoom";
            colMaintenanceRoom.ReadOnly = true;
            // 
            // colMaintenanceResponsible
            // 
            colMaintenanceResponsible.HeaderText = "Responsible";
            colMaintenanceResponsible.MinimumWidth = 6;
            colMaintenanceResponsible.Name = "colMaintenanceResponsible";
            colMaintenanceResponsible.ReadOnly = true;
            // 
            // colMaintenanceIssue
            // 
            colMaintenanceIssue.HeaderText = "Issue";
            colMaintenanceIssue.MinimumWidth = 6;
            colMaintenanceIssue.Name = "colMaintenanceIssue";
            colMaintenanceIssue.ReadOnly = true;
            // 
            // colMaintenanceAmount
            // 
            colMaintenanceAmount.HeaderText = "Amount";
            colMaintenanceAmount.MinimumWidth = 6;
            colMaintenanceAmount.Name = "colMaintenanceAmount";
            colMaintenanceAmount.ReadOnly = true;
            // 
            // colMaintenanceReceipt
            // 
            colMaintenanceReceipt.HeaderText = "Receipt";
            colMaintenanceReceipt.MinimumWidth = 6;
            colMaintenanceReceipt.Name = "colMaintenanceReceipt";
            colMaintenanceReceipt.ReadOnly = true;
            // 
            // tabUtilities
            // 
            tabUtilities.BackColor = Color.FromArgb(11, 20, 38);
            tabUtilities.Controls.Add(dgvUtilities);
            tabUtilities.Location = new Point(4, 37);
            tabUtilities.Name = "tabUtilities";
            tabUtilities.Padding = new Padding(3);
            tabUtilities.Size = new Size(1290, 567);
            tabUtilities.TabIndex = 2;
            tabUtilities.Text = "Utilities";
            // 
            // dgvUtilities
            // 
            dgvUtilities.AllowUserToAddRows = false;
            dgvUtilities.AllowUserToDeleteRows = false;
            dgvUtilities.AllowUserToResizeColumns = false;
            dgvUtilities.AllowUserToResizeRows = false;
            dgvUtilities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUtilities.BorderStyle = BorderStyle.None;
            dgvUtilities.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = SystemColors.Control;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dgvUtilities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dgvUtilities.ColumnHeadersHeight = 35;
            dgvUtilities.Columns.AddRange(new DataGridViewColumn[] { colUtilitiesDate, colUtilitiesTime, colUtilitiesUtility, colUtilitiesAmount, colUtilitiesReceipt });
            dgvUtilities.Cursor = Cursors.Hand;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = SystemColors.Window;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle14.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            dgvUtilities.DefaultCellStyle = dataGridViewCellStyle14;
            dgvUtilities.Dock = DockStyle.Fill;
            dgvUtilities.Location = new Point(3, 3);
            dgvUtilities.MultiSelect = false;
            dgvUtilities.Name = "dgvUtilities";
            dgvUtilities.ReadOnly = true;
            dgvUtilities.RowHeadersVisible = false;
            dgvUtilities.RowHeadersWidth = 51;
            dgvUtilities.RowTemplate.Height = 35;
            dgvUtilities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUtilities.Size = new Size(1284, 561);
            dgvUtilities.TabIndex = 7;
            // 
            // colUtilitiesDate
            // 
            colUtilitiesDate.HeaderText = "Date";
            colUtilitiesDate.MinimumWidth = 6;
            colUtilitiesDate.Name = "colUtilitiesDate";
            colUtilitiesDate.ReadOnly = true;
            // 
            // colUtilitiesTime
            // 
            colUtilitiesTime.HeaderText = "Time";
            colUtilitiesTime.MinimumWidth = 6;
            colUtilitiesTime.Name = "colUtilitiesTime";
            colUtilitiesTime.ReadOnly = true;
            // 
            // colUtilitiesUtility
            // 
            colUtilitiesUtility.HeaderText = "Utility";
            colUtilitiesUtility.MinimumWidth = 6;
            colUtilitiesUtility.Name = "colUtilitiesUtility";
            colUtilitiesUtility.ReadOnly = true;
            // 
            // colUtilitiesAmount
            // 
            colUtilitiesAmount.HeaderText = "Amount";
            colUtilitiesAmount.MinimumWidth = 6;
            colUtilitiesAmount.Name = "colUtilitiesAmount";
            colUtilitiesAmount.ReadOnly = true;
            // 
            // colUtilitiesReceipt
            // 
            colUtilitiesReceipt.HeaderText = "Receipt";
            colUtilitiesReceipt.MinimumWidth = 6;
            colUtilitiesReceipt.Name = "colUtilitiesReceipt";
            colUtilitiesReceipt.ReadOnly = true;
            // 
            // PaymentHistoryControl
            // 
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlPaymentHistoryContent);
            Controls.Add(pnlSearch);
            Controls.Add(pnlPaymentHistoryHeader);
            Name = "PaymentHistoryControl";
            Size = new Size(1300, 750);
            Load += PaymentHistoryControl_Load_1;
            pnlPaymentHistoryHeader.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlPaymentHistoryContent.ResumeLayout(false);
            tabPaymentHistory.ResumeLayout(false);
            tabRent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRent).EndInit();
            tabMaintenance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).EndInit();
            tabUtilities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUtilities).EndInit();
            ResumeLayout(false);

        }

        #endregion


        private Panel pnlPaymentHistoryHeader;
        private Label lblPaymentHistoryTitle;
        private Panel pnlSearch;
        private Panel pnlPaymentHistoryContent;
        private TextBox txtSearch;
        private TabControl tabPaymentHistory;
        private TabPage tabRent;
        private TabPage tabMaintenance;
        private DataGridView dgvRent;
        private DataGridView dgvMaintenance;
        private DataGridViewTextBoxColumn colRentDate;
        private DataGridViewTextBoxColumn colRentTime;
        private DataGridViewTextBoxColumn colRentRoom;
        private DataGridViewTextBoxColumn colRentType;
        private DataGridViewTextBoxColumn colRentTag;
        private DataGridViewTextBoxColumn colRentMethod;
        private DataGridViewTextBoxColumn colRentAmount;
        private DataGridViewButtonColumn colRentReceipt;
        private DataGridViewTextBoxColumn colMaintenanceDate;
        private DataGridViewTextBoxColumn colMaintenanceTime;
        private DataGridViewTextBoxColumn colMaintenanceRoom;
        private DataGridViewTextBoxColumn colMaintenanceResponsible;
        private DataGridViewTextBoxColumn colMaintenanceIssue;
        private DataGridViewTextBoxColumn colMaintenanceAmount;
        private DataGridViewButtonColumn colMaintenanceReceipt;
        private TabPage tabUtilities;
        private DataGridView dgvUtilities;
        private DataGridViewTextBoxColumn colUtilitiesDate;
        private DataGridViewTextBoxColumn colUtilitiesTime;
        private DataGridViewTextBoxColumn colUtilitiesUtility;
        private DataGridViewTextBoxColumn colUtilitiesAmount;
        private DataGridViewButtonColumn colUtilitiesReceipt;
    }
}