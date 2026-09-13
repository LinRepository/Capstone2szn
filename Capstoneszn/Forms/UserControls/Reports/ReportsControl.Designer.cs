namespace Capstoneszn.UserControls
{
    partial class ReportsControl
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
            pnlReportsHeader = new Panel();
            lblReportsTitle = new Label();
            pnlReportsContent = new Panel();
            panel3 = new Panel();
            panel5 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvExpenses = new DataGridView();
            colReportsExpensesDate = new DataGridViewTextBoxColumn();
            colReportsExpensesCategory = new DataGridViewTextBoxColumn();
            colReportsExpensesAmount = new DataGridViewTextBoxColumn();
            dgvReceived = new DataGridView();
            colReportsReceivedDate = new DataGridViewTextBoxColumn();
            colReportsReceivedTenant = new DataGridViewTextBoxColumn();
            colReportsReceivedAmount = new DataGridViewTextBoxColumn();
            pnlReportsSummaryCards = new Panel();
            tblSummarCards = new TableLayoutPanel();
            panel1 = new Panel();
            lblTotalReceivedValue = new Label();
            lblTotalReceived = new Label();
            panel2 = new Panel();
            lblTotalExpensesValue = new Label();
            lblTotalExpenses = new Label();
            panel4 = new Panel();
            lblEarningsValue = new Label();
            lblEarnings = new Label();
            pnlReportsHeaderContent = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel6 = new Panel();
            label2 = new Label();
            label1 = new Label();
            lblReportsTo = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            panel7 = new Panel();
            lblReportsTenant = new Label();
            comboBox1 = new ComboBox();
            panel8 = new Panel();
            btnReportsX = new Button();
            btnGenerateReports = new Button();
            pnlReportsHeader.SuspendLayout();
            pnlReportsContent.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReceived).BeginInit();
            pnlReportsSummaryCards.SuspendLayout();
            tblSummarCards.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            pnlReportsHeaderContent.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // pnlReportsHeader
            // 
            pnlReportsHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlReportsHeader.Controls.Add(lblReportsTitle);
            pnlReportsHeader.Dock = DockStyle.Top;
            pnlReportsHeader.Location = new Point(10, 10);
            pnlReportsHeader.Name = "pnlReportsHeader";
            pnlReportsHeader.Size = new Size(1280, 85);
            pnlReportsHeader.TabIndex = 0;
            // 
            // lblReportsTitle
            // 
            lblReportsTitle.Dock = DockStyle.Fill;
            lblReportsTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReportsTitle.ForeColor = Color.White;
            lblReportsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblReportsTitle.Location = new Point(0, 0);
            lblReportsTitle.Name = "lblReportsTitle";
            lblReportsTitle.Size = new Size(1278, 83);
            lblReportsTitle.TabIndex = 7;
            lblReportsTitle.Text = "Reports";
            lblReportsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlReportsContent
            // 
            pnlReportsContent.BorderStyle = BorderStyle.FixedSingle;
            pnlReportsContent.Controls.Add(panel3);
            pnlReportsContent.Dock = DockStyle.Fill;
            pnlReportsContent.Location = new Point(10, 95);
            pnlReportsContent.Name = "pnlReportsContent";
            pnlReportsContent.Size = new Size(1280, 645);
            pnlReportsContent.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(pnlReportsSummaryCards);
            panel3.Controls.Add(pnlReportsHeaderContent);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1278, 643);
            panel3.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(tableLayoutPanel1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 190);
            panel5.Name = "panel5";
            panel5.Size = new Size(1278, 453);
            panel5.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dgvExpenses, 0, 1);
            tableLayoutPanel1.Controls.Add(dgvReceived, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1276, 451);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvExpenses
            // 
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;
            dgvExpenses.AllowUserToResizeRows = false;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Columns.AddRange(new DataGridViewColumn[] { colReportsExpensesDate, colReportsExpensesCategory, colReportsExpensesAmount });
            dgvExpenses.Dock = DockStyle.Fill;
            dgvExpenses.Location = new Point(3, 228);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.ReadOnly = true;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.RowHeadersWidth = 51;
            dgvExpenses.ScrollBars = ScrollBars.Vertical;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(1270, 220);
            dgvExpenses.TabIndex = 1;
            // 
            // colReportsExpensesDate
            // 
            colReportsExpensesDate.HeaderText = "Date";
            colReportsExpensesDate.MinimumWidth = 6;
            colReportsExpensesDate.Name = "colReportsExpensesDate";
            colReportsExpensesDate.ReadOnly = true;
            // 
            // colReportsExpensesCategory
            // 
            colReportsExpensesCategory.HeaderText = "Category";
            colReportsExpensesCategory.MinimumWidth = 6;
            colReportsExpensesCategory.Name = "colReportsExpensesCategory";
            colReportsExpensesCategory.ReadOnly = true;
            // 
            // colReportsExpensesAmount
            // 
            colReportsExpensesAmount.HeaderText = "Amount";
            colReportsExpensesAmount.MinimumWidth = 6;
            colReportsExpensesAmount.Name = "colReportsExpensesAmount";
            colReportsExpensesAmount.ReadOnly = true;
            // 
            // dgvReceived
            // 
            dgvReceived.AllowUserToAddRows = false;
            dgvReceived.AllowUserToDeleteRows = false;
            dgvReceived.AllowUserToResizeRows = false;
            dgvReceived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceived.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReceived.Columns.AddRange(new DataGridViewColumn[] { colReportsReceivedDate, colReportsReceivedTenant, colReportsReceivedAmount });
            dgvReceived.Dock = DockStyle.Fill;
            dgvReceived.Location = new Point(3, 3);
            dgvReceived.MultiSelect = false;
            dgvReceived.Name = "dgvReceived";
            dgvReceived.ReadOnly = true;
            dgvReceived.RowHeadersVisible = false;
            dgvReceived.RowHeadersWidth = 51;
            dgvReceived.ScrollBars = ScrollBars.Vertical;
            dgvReceived.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceived.Size = new Size(1270, 219);
            dgvReceived.TabIndex = 0;
            // 
            // colReportsReceivedDate
            // 
            colReportsReceivedDate.HeaderText = "Date";
            colReportsReceivedDate.MinimumWidth = 6;
            colReportsReceivedDate.Name = "colReportsReceivedDate";
            colReportsReceivedDate.ReadOnly = true;
            // 
            // colReportsReceivedTenant
            // 
            colReportsReceivedTenant.HeaderText = "Tenant Name";
            colReportsReceivedTenant.MinimumWidth = 6;
            colReportsReceivedTenant.Name = "colReportsReceivedTenant";
            colReportsReceivedTenant.ReadOnly = true;
            // 
            // colReportsReceivedAmount
            // 
            colReportsReceivedAmount.HeaderText = "Amount";
            colReportsReceivedAmount.MinimumWidth = 6;
            colReportsReceivedAmount.Name = "colReportsReceivedAmount";
            colReportsReceivedAmount.ReadOnly = true;
            // 
            // pnlReportsSummaryCards
            // 
            pnlReportsSummaryCards.Controls.Add(tblSummarCards);
            pnlReportsSummaryCards.Dock = DockStyle.Top;
            pnlReportsSummaryCards.Location = new Point(0, 80);
            pnlReportsSummaryCards.Name = "pnlReportsSummaryCards";
            pnlReportsSummaryCards.Padding = new Padding(5);
            pnlReportsSummaryCards.Size = new Size(1278, 110);
            pnlReportsSummaryCards.TabIndex = 1;
            // 
            // tblSummarCards
            // 
            tblSummarCards.ColumnCount = 3;
            tblSummarCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblSummarCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblSummarCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblSummarCards.Controls.Add(panel1, 0, 0);
            tblSummarCards.Controls.Add(panel2, 1, 0);
            tblSummarCards.Controls.Add(panel4, 2, 0);
            tblSummarCards.Dock = DockStyle.Fill;
            tblSummarCards.Location = new Point(5, 5);
            tblSummarCards.Name = "tblSummarCards";
            tblSummarCards.RowCount = 1;
            tblSummarCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSummarCards.Size = new Size(1268, 100);
            tblSummarCards.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalReceivedValue);
            panel1.Controls.Add(lblTotalReceived);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(416, 94);
            panel1.TabIndex = 0;
            // 
            // lblTotalReceivedValue
            // 
            lblTotalReceivedValue.BorderStyle = BorderStyle.FixedSingle;
            lblTotalReceivedValue.Dock = DockStyle.Left;
            lblTotalReceivedValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalReceivedValue.ForeColor = Color.White;
            lblTotalReceivedValue.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalReceivedValue.Location = new Point(200, 0);
            lblTotalReceivedValue.Name = "lblTotalReceivedValue";
            lblTotalReceivedValue.Size = new Size(200, 94);
            lblTotalReceivedValue.TabIndex = 44;
            lblTotalReceivedValue.Text = "₱ ####";
            lblTotalReceivedValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalReceived
            // 
            lblTotalReceived.BorderStyle = BorderStyle.FixedSingle;
            lblTotalReceived.Dock = DockStyle.Left;
            lblTotalReceived.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalReceived.ForeColor = Color.White;
            lblTotalReceived.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalReceived.Location = new Point(0, 0);
            lblTotalReceived.Name = "lblTotalReceived";
            lblTotalReceived.Size = new Size(200, 94);
            lblTotalReceived.TabIndex = 43;
            lblTotalReceived.Text = "Total Received";
            lblTotalReceived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTotalExpensesValue);
            panel2.Controls.Add(lblTotalExpenses);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(425, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(416, 94);
            panel2.TabIndex = 1;
            // 
            // lblTotalExpensesValue
            // 
            lblTotalExpensesValue.BorderStyle = BorderStyle.FixedSingle;
            lblTotalExpensesValue.Dock = DockStyle.Left;
            lblTotalExpensesValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalExpensesValue.ForeColor = Color.White;
            lblTotalExpensesValue.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalExpensesValue.Location = new Point(200, 0);
            lblTotalExpensesValue.Name = "lblTotalExpensesValue";
            lblTotalExpensesValue.Size = new Size(200, 94);
            lblTotalExpensesValue.TabIndex = 45;
            lblTotalExpensesValue.Text = "₱ ####";
            lblTotalExpensesValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalExpenses
            // 
            lblTotalExpenses.BorderStyle = BorderStyle.FixedSingle;
            lblTotalExpenses.Dock = DockStyle.Left;
            lblTotalExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalExpenses.ForeColor = Color.White;
            lblTotalExpenses.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalExpenses.Location = new Point(0, 0);
            lblTotalExpenses.Name = "lblTotalExpenses";
            lblTotalExpenses.Size = new Size(200, 94);
            lblTotalExpenses.TabIndex = 44;
            lblTotalExpenses.Text = " Total Expenses";
            lblTotalExpenses.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblEarningsValue);
            panel4.Controls.Add(lblEarnings);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(847, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(418, 94);
            panel4.TabIndex = 2;
            // 
            // lblEarningsValue
            // 
            lblEarningsValue.BorderStyle = BorderStyle.FixedSingle;
            lblEarningsValue.Dock = DockStyle.Left;
            lblEarningsValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEarningsValue.ForeColor = Color.White;
            lblEarningsValue.ImageAlign = ContentAlignment.MiddleRight;
            lblEarningsValue.Location = new Point(200, 0);
            lblEarningsValue.Name = "lblEarningsValue";
            lblEarningsValue.Size = new Size(200, 94);
            lblEarningsValue.TabIndex = 45;
            lblEarningsValue.Text = "₱ ####";
            lblEarningsValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEarnings
            // 
            lblEarnings.BorderStyle = BorderStyle.FixedSingle;
            lblEarnings.Dock = DockStyle.Left;
            lblEarnings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEarnings.ForeColor = Color.White;
            lblEarnings.ImageAlign = ContentAlignment.MiddleRight;
            lblEarnings.Location = new Point(0, 0);
            lblEarnings.Name = "lblEarnings";
            lblEarnings.Size = new Size(200, 94);
            lblEarnings.TabIndex = 44;
            lblEarnings.Text = "Earnings";
            lblEarnings.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlReportsHeaderContent
            // 
            pnlReportsHeaderContent.BorderStyle = BorderStyle.FixedSingle;
            pnlReportsHeaderContent.Controls.Add(tableLayoutPanel2);
            pnlReportsHeaderContent.Dock = DockStyle.Top;
            pnlReportsHeaderContent.Location = new Point(0, 0);
            pnlReportsHeaderContent.Name = "pnlReportsHeaderContent";
            pnlReportsHeaderContent.Size = new Size(1278, 80);
            pnlReportsHeaderContent.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(panel6, 0, 0);
            tableLayoutPanel2.Controls.Add(panel7, 1, 0);
            tableLayoutPanel2.Controls.Add(panel8, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1276, 78);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(label2);
            panel6.Controls.Add(label1);
            panel6.Controls.Add(lblReportsTo);
            panel6.Controls.Add(dateTimePicker2);
            panel6.Controls.Add(dateTimePicker1);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(632, 72);
            panel6.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.ImageAlign = ContentAlignment.MiddleRight;
            label2.Location = new Point(392, 0);
            label2.Name = "label2";
            label2.Size = new Size(78, 28);
            label2.TabIndex = 43;
            label2.Text = "Date To";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(84, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 28);
            label1.TabIndex = 42;
            label1.Text = "Date From";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblReportsTo
            // 
            lblReportsTo.AutoSize = true;
            lblReportsTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReportsTo.ForeColor = Color.White;
            lblReportsTo.ImageAlign = ContentAlignment.MiddleRight;
            lblReportsTo.Location = new Point(271, 30);
            lblReportsTo.Name = "lblReportsTo";
            lblReportsTo.Size = new Size(32, 28);
            lblReportsTo.TabIndex = 40;
            lblReportsTo.Text = "To";
            lblReportsTo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(309, 31);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(15, 31);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblReportsTenant);
            panel7.Controls.Add(comboBox1);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(641, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(249, 72);
            panel7.TabIndex = 1;
            // 
            // lblReportsTenant
            // 
            lblReportsTenant.AutoSize = true;
            lblReportsTenant.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReportsTenant.ForeColor = Color.White;
            lblReportsTenant.ImageAlign = ContentAlignment.MiddleRight;
            lblReportsTenant.Location = new Point(21, 0);
            lblReportsTenant.Name = "lblReportsTenant";
            lblReportsTenant.Size = new Size(77, 28);
            lblReportsTenant.TabIndex = 41;
            lblReportsTenant.Text = "Tenants";
            lblReportsTenant.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(21, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(210, 28);
            comboBox1.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnReportsX);
            panel8.Controls.Add(btnGenerateReports);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(896, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(377, 72);
            panel8.TabIndex = 2;
            // 
            // btnReportsX
            // 
            btnReportsX.Location = new Point(114, 22);
            btnReportsX.Name = "btnReportsX";
            btnReportsX.Size = new Size(94, 28);
            btnReportsX.TabIndex = 43;
            btnReportsX.Text = "X";
            btnReportsX.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReports
            // 
            btnGenerateReports.Location = new Point(214, 22);
            btnGenerateReports.Name = "btnGenerateReports";
            btnGenerateReports.Size = new Size(159, 28);
            btnGenerateReports.TabIndex = 42;
            btnGenerateReports.Text = "GenerateReports";
            btnGenerateReports.UseVisualStyleBackColor = true;
            // 
            // ReportsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlReportsContent);
            Controls.Add(pnlReportsHeader);
            Name = "ReportsControl";
            Padding = new Padding(10);
            Size = new Size(1300, 750);
            pnlReportsHeader.ResumeLayout(false);
            pnlReportsContent.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReceived).EndInit();
            pnlReportsSummaryCards.ResumeLayout(false);
            tblSummarCards.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            pnlReportsHeaderContent.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlReportsHeader;
        private Label lblReportsTitle;
        private Panel pnlReportsContent;
        private Panel panel3;
        private Panel pnlReportsSummaryCards;
        private Panel pnlReportsHeaderContent;
        private TableLayoutPanel tblSummarCards;
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Label lblTotalReceived;
        private Label lblTotalReceivedValue;
        private Label lblTotalExpensesValue;
        private Label lblTotalExpenses;
        private Label lblEarningsValue;
        private Label lblEarnings;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvReceived;
        private DataGridView dgvExpenses;
        private DataGridViewTextBoxColumn colReportsExpensesDate;
        private DataGridViewTextBoxColumn colReportsExpensesCategory;
        private DataGridViewTextBoxColumn colReportsExpensesAmount;
        private DataGridViewTextBoxColumn colReportsReceivedDate;
        private DataGridViewTextBoxColumn colReportsReceivedTenant;
        private DataGridViewTextBoxColumn colReportsReceivedAmount;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label lblReportsTo;
        private Button btnReportsX;
        private Button btnGenerateReports;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel6;
        private Panel panel7;
        private ComboBox comboBox1;
        private Panel panel8;
        private Label label2;
        private Label label1;
        private Label lblReportsTenant;
    }
}
