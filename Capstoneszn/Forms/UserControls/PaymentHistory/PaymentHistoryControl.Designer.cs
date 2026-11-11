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
            pnlPaymentHistoryHeader = new Panel();
            lblPaymentHistoryTitle = new Label();
            pnlSearch = new Panel();
            lblPaymentTotalAmount = new Label();
            lblPaymentTotalCaption = new Label();
            btnPaymentClear = new Button();
            lblPaymentTo = new Label();
            lblPaymentFrom = new Label();
            lblPaymentSearch = new Label();
            dtpPaymentTo = new DateTimePicker();
            dtpPaymentFrom = new DateTimePicker();
            lblPaymentCount = new Label();
            txtSearch = new TextBox();
            pnlPaymentHistoryContent = new Panel();
            tabPaymentHistory = new TabControl();
            tabAll = new TabPage();
            dgvAll = new DataGridView();
            tabRent = new TabPage();
            dgvRent = new DataGridView();
            tabMaintenance = new TabPage();
            dgvMaintenance = new DataGridView();
            tabUtilities = new TabPage();
            dgvUtilities = new DataGridView();
            pnlPaymentHistoryHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlPaymentHistoryContent.SuspendLayout();
            tabPaymentHistory.SuspendLayout();
            tabAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAll).BeginInit();
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
            pnlSearch.Controls.Add(lblPaymentTotalAmount);
            pnlSearch.Controls.Add(lblPaymentTotalCaption);
            pnlSearch.Controls.Add(btnPaymentClear);
            pnlSearch.Controls.Add(lblPaymentTo);
            pnlSearch.Controls.Add(lblPaymentFrom);
            pnlSearch.Controls.Add(lblPaymentSearch);
            pnlSearch.Controls.Add(dtpPaymentTo);
            pnlSearch.Controls.Add(dtpPaymentFrom);
            pnlSearch.Controls.Add(lblPaymentCount);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 80);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(5);
            pnlSearch.Size = new Size(1300, 70);
            pnlSearch.TabIndex = 1;
            // 
            // lblPaymentTotalAmount
            // 
            lblPaymentTotalAmount.AutoSize = true;
            lblPaymentTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPaymentTotalAmount.ForeColor = Color.White;
            lblPaymentTotalAmount.Location = new Point(1072, 7);
            lblPaymentTotalAmount.Name = "lblPaymentTotalAmount";
            lblPaymentTotalAmount.Size = new Size(83, 28);
            lblPaymentTotalAmount.TabIndex = 6;
            lblPaymentTotalAmount.Text = "lblTotal";
            // 
            // lblPaymentTotalCaption
            // 
            lblPaymentTotalCaption.AutoSize = true;
            lblPaymentTotalCaption.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentTotalCaption.ForeColor = Color.White;
            lblPaymentTotalCaption.Location = new Point(989, 10);
            lblPaymentTotalCaption.Name = "lblPaymentTotalCaption";
            lblPaymentTotalCaption.Size = new Size(77, 25);
            lblPaymentTotalCaption.TabIndex = 6;
            lblPaymentTotalCaption.Text = "All total:";
            // 
            // btnPaymentClear
            // 
            btnPaymentClear.BackColor = Color.White;
            btnPaymentClear.FlatStyle = FlatStyle.Flat;
            btnPaymentClear.Location = new Point(831, 25);
            btnPaymentClear.Name = "btnPaymentClear";
            btnPaymentClear.Size = new Size(94, 29);
            btnPaymentClear.TabIndex = 5;
            btnPaymentClear.Text = "Clear";
            btnPaymentClear.UseVisualStyleBackColor = false;
            // 
            // lblPaymentTo
            // 
            lblPaymentTo.AutoSize = true;
            lblPaymentTo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentTo.ForeColor = Color.White;
            lblPaymentTo.Location = new Point(634, 2);
            lblPaymentTo.Name = "lblPaymentTo";
            lblPaymentTo.Size = new Size(68, 23);
            lblPaymentTo.TabIndex = 4;
            lblPaymentTo.Text = "Date To";
            // 
            // lblPaymentFrom
            // 
            lblPaymentFrom.AutoSize = true;
            lblPaymentFrom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentFrom.ForeColor = Color.White;
            lblPaymentFrom.Location = new Point(421, 2);
            lblPaymentFrom.Name = "lblPaymentFrom";
            lblPaymentFrom.Size = new Size(90, 23);
            lblPaymentFrom.TabIndex = 4;
            lblPaymentFrom.Text = "Date From";
            // 
            // lblPaymentSearch
            // 
            lblPaymentSearch.AutoSize = true;
            lblPaymentSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentSearch.ForeColor = Color.White;
            lblPaymentSearch.Location = new Point(7, 2);
            lblPaymentSearch.Name = "lblPaymentSearch";
            lblPaymentSearch.Size = new Size(61, 23);
            lblPaymentSearch.TabIndex = 4;
            lblPaymentSearch.Text = "Search";
            // 
            // dtpPaymentTo
            // 
            dtpPaymentTo.CalendarFont = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpPaymentTo.CustomFormat = "MMMM dd, yyyy";
            dtpPaymentTo.Format = DateTimePickerFormat.Custom;
            dtpPaymentTo.Location = new Point(634, 27);
            dtpPaymentTo.Name = "dtpPaymentTo";
            dtpPaymentTo.Size = new Size(182, 27);
            dtpPaymentTo.TabIndex = 3;
            // 
            // dtpPaymentFrom
            // 
            dtpPaymentFrom.CalendarFont = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpPaymentFrom.CustomFormat = "MMMM dd, yyyy";
            dtpPaymentFrom.Format = DateTimePickerFormat.Custom;
            dtpPaymentFrom.Location = new Point(421, 27);
            dtpPaymentFrom.Name = "dtpPaymentFrom";
            dtpPaymentFrom.Size = new Size(182, 27);
            dtpPaymentFrom.TabIndex = 3;
            // 
            // lblPaymentCount
            // 
            lblPaymentCount.AutoSize = true;
            lblPaymentCount.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentCount.ForeColor = Color.White;
            lblPaymentCount.Location = new Point(989, 38);
            lblPaymentCount.Name = "lblPaymentCount";
            lblPaymentCount.Size = new Size(49, 25);
            lblPaymentCount.TabIndex = 2;
            lblPaymentCount.Text = "Total";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(7, 25);
            txtSearch.MaxLength = 100;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔎 Search tenant, room or receipt no.";
            txtSearch.Size = new Size(380, 31);
            txtSearch.TabIndex = 0;
            // 
            // pnlPaymentHistoryContent
            // 
            pnlPaymentHistoryContent.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentHistoryContent.Controls.Add(tabPaymentHistory);
            pnlPaymentHistoryContent.Dock = DockStyle.Fill;
            pnlPaymentHistoryContent.Location = new Point(0, 150);
            pnlPaymentHistoryContent.Name = "pnlPaymentHistoryContent";
            pnlPaymentHistoryContent.Size = new Size(1300, 600);
            pnlPaymentHistoryContent.TabIndex = 2;
            // 
            // tabPaymentHistory
            // 
            tabPaymentHistory.Controls.Add(tabAll);
            tabPaymentHistory.Controls.Add(tabRent);
            tabPaymentHistory.Controls.Add(tabMaintenance);
            tabPaymentHistory.Controls.Add(tabUtilities);
            tabPaymentHistory.Dock = DockStyle.Fill;
            tabPaymentHistory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPaymentHistory.Location = new Point(0, 0);
            tabPaymentHistory.Name = "tabPaymentHistory";
            tabPaymentHistory.SelectedIndex = 0;
            tabPaymentHistory.Size = new Size(1298, 598);
            tabPaymentHistory.TabIndex = 0;
            // 
            // tabAll
            // 
            tabAll.BackColor = Color.FromArgb(11, 20, 38);
            tabAll.Controls.Add(dgvAll);
            tabAll.Location = new Point(4, 37);
            tabAll.Name = "tabAll";
            tabAll.Padding = new Padding(3);
            tabAll.Size = new Size(1290, 557);
            tabAll.TabIndex = 0;
            tabAll.Text = "All";
            // 
            // dgvAll
            // 
            dgvAll.ColumnHeadersHeight = 29;
            dgvAll.Dock = DockStyle.Fill;
            dgvAll.Location = new Point(3, 3);
            dgvAll.Name = "dgvAll";
            dgvAll.RowHeadersWidth = 51;
            dgvAll.Size = new Size(1284, 551);
            dgvAll.TabIndex = 0;
            // 
            // tabRent
            // 
            tabRent.BackColor = Color.FromArgb(11, 20, 38);
            tabRent.Controls.Add(dgvRent);
            tabRent.Location = new Point(4, 37);
            tabRent.Name = "tabRent";
            tabRent.Padding = new Padding(3);
            tabRent.Size = new Size(1290, 557);
            tabRent.TabIndex = 1;
            tabRent.Text = "Rent";
            // 
            // dgvRent
            // 
            dgvRent.ColumnHeadersHeight = 29;
            dgvRent.Dock = DockStyle.Fill;
            dgvRent.Location = new Point(3, 3);
            dgvRent.Name = "dgvRent";
            dgvRent.RowHeadersWidth = 51;
            dgvRent.Size = new Size(1284, 551);
            dgvRent.TabIndex = 0;
            // 
            // tabMaintenance
            // 
            tabMaintenance.BackColor = Color.FromArgb(11, 20, 38);
            tabMaintenance.Controls.Add(dgvMaintenance);
            tabMaintenance.Location = new Point(4, 37);
            tabMaintenance.Name = "tabMaintenance";
            tabMaintenance.Padding = new Padding(3);
            tabMaintenance.Size = new Size(1290, 557);
            tabMaintenance.TabIndex = 2;
            tabMaintenance.Text = "Maintenance";
            // 
            // dgvMaintenance
            // 
            dgvMaintenance.ColumnHeadersHeight = 29;
            dgvMaintenance.Dock = DockStyle.Fill;
            dgvMaintenance.Location = new Point(3, 3);
            dgvMaintenance.Name = "dgvMaintenance";
            dgvMaintenance.RowHeadersWidth = 51;
            dgvMaintenance.Size = new Size(1284, 551);
            dgvMaintenance.TabIndex = 0;
            // 
            // tabUtilities
            // 
            tabUtilities.BackColor = Color.FromArgb(11, 20, 38);
            tabUtilities.Controls.Add(dgvUtilities);
            tabUtilities.Location = new Point(4, 37);
            tabUtilities.Name = "tabUtilities";
            tabUtilities.Padding = new Padding(3);
            tabUtilities.Size = new Size(1290, 557);
            tabUtilities.TabIndex = 3;
            tabUtilities.Text = "Water";
            // 
            // dgvUtilities
            // 
            dgvUtilities.ColumnHeadersHeight = 29;
            dgvUtilities.Dock = DockStyle.Fill;
            dgvUtilities.Location = new Point(3, 3);
            dgvUtilities.Name = "dgvUtilities";
            dgvUtilities.RowHeadersWidth = 51;
            dgvUtilities.Size = new Size(1284, 551);
            dgvUtilities.TabIndex = 0;
            // 
            // PaymentHistoryControl
            // 
            BackColor = Color.FromArgb(25, 25, 70);
            Controls.Add(pnlPaymentHistoryContent);
            Controls.Add(pnlSearch);
            Controls.Add(pnlPaymentHistoryHeader);
            Name = "PaymentHistoryControl";
            Size = new Size(1300, 750);
            pnlPaymentHistoryHeader.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlPaymentHistoryContent.ResumeLayout(false);
            tabPaymentHistory.ResumeLayout(false);
            tabAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAll).EndInit();
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
        private TextBox txtSearch;
        private Label lblPaymentCount;
        private Panel pnlPaymentHistoryContent;
        private TabControl tabPaymentHistory;
        private TabPage tabAll;
        private DataGridView dgvAll;
        private TabPage tabRent;
        private DataGridView dgvRent;
        private TabPage tabMaintenance;
        private DataGridView dgvMaintenance;
        private TabPage tabUtilities;
        private DataGridView dgvUtilities;
        private DateTimePicker dtpPaymentFrom;
        private Label lblPaymentTotalCaption;
        private Button btnPaymentClear;
        private Label lblPaymentTo;
        private Label lblPaymentFrom;
        private Label lblPaymentSearch;
        private DateTimePicker dtpPaymentTo;
        private Label lblPaymentTotalAmount;
    }
}