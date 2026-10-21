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
            lblPaymentTotal = new Label();
            cboPaymentPeriod = new ComboBox();
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
            pnlSearch.Controls.Add(lblPaymentTotal);
            pnlSearch.Controls.Add(cboPaymentPeriod);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 80);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1300, 60);
            pnlSearch.TabIndex = 1;
            // 
            // lblPaymentTotal
            // 
            lblPaymentTotal.AutoSize = true;
            lblPaymentTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentTotal.ForeColor = Color.White;
            lblPaymentTotal.Location = new Point(625, 15);
            lblPaymentTotal.Name = "lblPaymentTotal";
            lblPaymentTotal.Size = new Size(54, 28);
            lblPaymentTotal.TabIndex = 2;
            lblPaymentTotal.Text = "Total";
            // 
            // cboPaymentPeriod
            // 
            cboPaymentPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentPeriod.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboPaymentPeriod.FormattingEnabled = true;
            cboPaymentPeriod.Location = new Point(405, 12);
            cboPaymentPeriod.Name = "cboPaymentPeriod";
            cboPaymentPeriod.Size = new Size(200, 36);
            cboPaymentPeriod.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(10, 12);
            txtSearch.MaxLength = 100;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search tenant, room or receipt no.";
            txtSearch.Size = new Size(380, 34);
            txtSearch.TabIndex = 0;
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
            tabPaymentHistory.Controls.Add(tabAll);
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
            // tabAll
            // 
            tabAll.BackColor = Color.FromArgb(11, 20, 38);
            tabAll.Controls.Add(dgvAll);
            tabAll.Location = new Point(4, 37);
            tabAll.Name = "tabAll";
            tabAll.Padding = new Padding(3);
            tabAll.Size = new Size(1290, 567);
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
            dgvAll.Size = new Size(1284, 561);
            dgvAll.TabIndex = 0;
            // 
            // tabRent
            // 
            tabRent.BackColor = Color.FromArgb(11, 20, 38);
            tabRent.Controls.Add(dgvRent);
            tabRent.Location = new Point(4, 37);
            tabRent.Name = "tabRent";
            tabRent.Padding = new Padding(3);
            tabRent.Size = new Size(1290, 567);
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
            dgvRent.Size = new Size(1284, 561);
            dgvRent.TabIndex = 0;
            // 
            // tabMaintenance
            // 
            tabMaintenance.BackColor = Color.FromArgb(11, 20, 38);
            tabMaintenance.Controls.Add(dgvMaintenance);
            tabMaintenance.Location = new Point(4, 37);
            tabMaintenance.Name = "tabMaintenance";
            tabMaintenance.Padding = new Padding(3);
            tabMaintenance.Size = new Size(1290, 567);
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
            dgvMaintenance.Size = new Size(1284, 561);
            dgvMaintenance.TabIndex = 0;
            // 
            // tabUtilities
            // 
            tabUtilities.BackColor = Color.FromArgb(11, 20, 38);
            tabUtilities.Controls.Add(dgvUtilities);
            tabUtilities.Location = new Point(4, 37);
            tabUtilities.Name = "tabUtilities";
            tabUtilities.Padding = new Padding(3);
            tabUtilities.Size = new Size(1290, 567);
            tabUtilities.TabIndex = 3;
            tabUtilities.Text = "Utilities";
            // 
            // dgvUtilities
            // 
            dgvUtilities.ColumnHeadersHeight = 29;
            dgvUtilities.Dock = DockStyle.Fill;
            dgvUtilities.Location = new Point(3, 3);
            dgvUtilities.Name = "dgvUtilities";
            dgvUtilities.RowHeadersWidth = 51;
            dgvUtilities.Size = new Size(1284, 561);
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
        private ComboBox cboPaymentPeriod;
        private Label lblPaymentTotal;
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
    }
}