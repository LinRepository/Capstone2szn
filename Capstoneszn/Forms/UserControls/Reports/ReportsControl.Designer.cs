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
            tabReports = new TabControl();
            TabReceived = new TabPage();
            panel9 = new Panel();
            dgvReceived = new DataGridView();
            colReportsReceivedDate = new DataGridViewTextBoxColumn();
            colRoom = new DataGridViewTextBoxColumn();
            colReportsReceivedTenant = new DataGridViewTextBoxColumn();
            colReportsReceivedAmount = new DataGridViewTextBoxColumn();
            panel10 = new Panel();
            lblReceived = new Label();
            pnlReportsSummaryCards = new Panel();
            panel1 = new Panel();
            lblTotalReceivedValue = new Label();
            lblTotalReceived = new Label();
            pnlReportsHeaderContent = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel6 = new Panel();
            label2 = new Label();
            label1 = new Label();
            lblReportsTo = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            panel7 = new Panel();
            lblReports = new Label();
            comboBox1 = new ComboBox();
            panel8 = new Panel();
            btnReportsX = new Button();
            btnGenerateReports = new Button();
            TabExpenses = new TabPage();
            panel11 = new Panel();
            dgvExpenses = new DataGridView();
            colReportsExpensesDate = new DataGridViewTextBoxColumn();
            colReportsExpensesCategory = new DataGridViewTextBoxColumn();
            colReportsExpensesAmount = new DataGridViewTextBoxColumn();
            panel12 = new Panel();
            lblExpenses = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dateTimePicker3 = new DateTimePicker();
            dateTimePicker4 = new DateTimePicker();
            lblTotalExpensesValue = new Label();
            lblTotalExpenses = new Label();
            pnlReportsHeader.SuspendLayout();
            pnlReportsContent.SuspendLayout();
            tabReports.SuspendLayout();
            TabReceived.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceived).BeginInit();
            panel10.SuspendLayout();
            pnlReportsSummaryCards.SuspendLayout();
            panel1.SuspendLayout();
            pnlReportsHeaderContent.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            TabExpenses.SuspendLayout();
            panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            panel12.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
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
            pnlReportsContent.Controls.Add(tabReports);
            pnlReportsContent.Dock = DockStyle.Fill;
            pnlReportsContent.Location = new Point(10, 95);
            pnlReportsContent.Name = "pnlReportsContent";
            pnlReportsContent.Size = new Size(1280, 645);
            pnlReportsContent.TabIndex = 1;
            // 
            // tabReports
            // 
            tabReports.Controls.Add(TabReceived);
            tabReports.Controls.Add(TabExpenses);
            tabReports.Dock = DockStyle.Fill;
            tabReports.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabReports.Location = new Point(0, 0);
            tabReports.Name = "tabReports";
            tabReports.Padding = new Point(0, 0);
            tabReports.SelectedIndex = 0;
            tabReports.Size = new Size(1278, 643);
            tabReports.TabIndex = 3;
            // 
            // TabReceived
            // 
            TabReceived.BackColor = Color.FromArgb(11, 20, 38);
            TabReceived.Controls.Add(panel9);
            TabReceived.Controls.Add(pnlReportsSummaryCards);
            TabReceived.Controls.Add(pnlReportsHeaderContent);
            TabReceived.Location = new Point(4, 37);
            TabReceived.Name = "TabReceived";
            TabReceived.Padding = new Padding(3);
            TabReceived.Size = new Size(1270, 602);
            TabReceived.TabIndex = 0;
            TabReceived.Text = "Received";
            // 
            // panel9
            // 
            panel9.Controls.Add(dgvReceived);
            panel9.Controls.Add(panel10);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(3, 163);
            panel9.Name = "panel9";
            panel9.Size = new Size(1264, 436);
            panel9.TabIndex = 3;
            // 
            // dgvReceived
            // 
            dgvReceived.AllowUserToAddRows = false;
            dgvReceived.AllowUserToDeleteRows = false;
            dgvReceived.AllowUserToResizeRows = false;
            dgvReceived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceived.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReceived.Columns.AddRange(new DataGridViewColumn[] { colReportsReceivedDate, colRoom, colReportsReceivedTenant, colReportsReceivedAmount });
            dgvReceived.Dock = DockStyle.Fill;
            dgvReceived.Location = new Point(0, 45);
            dgvReceived.MultiSelect = false;
            dgvReceived.Name = "dgvReceived";
            dgvReceived.ReadOnly = true;
            dgvReceived.RowHeadersVisible = false;
            dgvReceived.RowHeadersWidth = 51;
            dgvReceived.ScrollBars = ScrollBars.Vertical;
            dgvReceived.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceived.Size = new Size(1264, 391);
            dgvReceived.TabIndex = 4;
            // 
            // colReportsReceivedDate
            // 
            colReportsReceivedDate.HeaderText = "Date";
            colReportsReceivedDate.MinimumWidth = 6;
            colReportsReceivedDate.Name = "colReportsReceivedDate";
            colReportsReceivedDate.ReadOnly = true;
            // 
            // colRoom
            // 
            colRoom.HeaderText = "Room";
            colRoom.MinimumWidth = 6;
            colRoom.Name = "colRoom";
            colRoom.ReadOnly = true;
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
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(lblReceived);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(1264, 45);
            panel10.TabIndex = 3;
            // 
            // lblReceived
            // 
            lblReceived.Dock = DockStyle.Fill;
            lblReceived.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReceived.ForeColor = Color.White;
            lblReceived.ImageAlign = ContentAlignment.MiddleRight;
            lblReceived.Location = new Point(0, 0);
            lblReceived.Name = "lblReceived";
            lblReceived.Size = new Size(1262, 43);
            lblReceived.TabIndex = 43;
            lblReceived.Text = "Received";
            lblReceived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlReportsSummaryCards
            // 
            pnlReportsSummaryCards.BorderStyle = BorderStyle.FixedSingle;
            pnlReportsSummaryCards.Controls.Add(panel1);
            pnlReportsSummaryCards.Dock = DockStyle.Top;
            pnlReportsSummaryCards.Location = new Point(3, 83);
            pnlReportsSummaryCards.Name = "pnlReportsSummaryCards";
            pnlReportsSummaryCards.Padding = new Padding(5);
            pnlReportsSummaryCards.Size = new Size(1264, 80);
            pnlReportsSummaryCards.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalReceivedValue);
            panel1.Controls.Add(lblTotalReceived);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1252, 68);
            panel1.TabIndex = 1;
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
            lblTotalReceivedValue.Size = new Size(200, 68);
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
            lblTotalReceived.Size = new Size(200, 68);
            lblTotalReceived.TabIndex = 43;
            lblTotalReceived.Text = "Total Received";
            lblTotalReceived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlReportsHeaderContent
            // 
            pnlReportsHeaderContent.BorderStyle = BorderStyle.FixedSingle;
            pnlReportsHeaderContent.Controls.Add(tableLayoutPanel2);
            pnlReportsHeaderContent.Dock = DockStyle.Top;
            pnlReportsHeaderContent.Location = new Point(3, 3);
            pnlReportsHeaderContent.Name = "pnlReportsHeaderContent";
            pnlReportsHeaderContent.Size = new Size(1264, 80);
            pnlReportsHeaderContent.TabIndex = 1;
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
            tableLayoutPanel2.Size = new Size(1262, 78);
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
            panel6.Size = new Size(625, 72);
            panel6.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.ForeColor = Color.White;
            label2.ImageAlign = ContentAlignment.MiddleRight;
            label2.Location = new Point(432, 5);
            label2.Name = "label2";
            label2.Size = new Size(68, 23);
            label2.TabIndex = 43;
            label2.Text = "Date To";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.ForeColor = Color.White;
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(99, 5);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
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
            lblReportsTo.Location = new Point(297, 30);
            lblReportsTo.Name = "lblReportsTo";
            lblReportsTo.Size = new Size(32, 28);
            lblReportsTo.TabIndex = 40;
            lblReportsTo.Text = "To";
            lblReportsTo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Font = new Font("Segoe UI", 10.2F);
            dateTimePicker2.Location = new Point(336, 31);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(275, 30);
            dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 10.2F);
            dateTimePicker1.Location = new Point(13, 31);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(275, 30);
            dateTimePicker1.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(lblReports);
            panel7.Controls.Add(comboBox1);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(634, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(246, 72);
            panel7.TabIndex = 1;
            // 
            // lblReports
            // 
            lblReports.AutoSize = true;
            lblReports.Font = new Font("Segoe UI", 10.2F);
            lblReports.ForeColor = Color.White;
            lblReports.ImageAlign = ContentAlignment.MiddleRight;
            lblReports.Location = new Point(21, 5);
            lblReports.Name = "lblReports";
            lblReports.Size = new Size(62, 23);
            lblReports.TabIndex = 41;
            lblReports.Text = "Rooms";
            lblReports.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(21, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(210, 36);
            comboBox1.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnReportsX);
            panel8.Controls.Add(btnGenerateReports);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(886, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(373, 72);
            panel8.TabIndex = 2;
            // 
            // btnReportsX
            // 
            btnReportsX.Font = new Font("Segoe UI", 10.2F);
            btnReportsX.Location = new Point(263, 22);
            btnReportsX.Name = "btnReportsX";
            btnReportsX.Size = new Size(94, 28);
            btnReportsX.TabIndex = 43;
            btnReportsX.Text = "Clear";
            btnReportsX.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReports
            // 
            btnGenerateReports.Font = new Font("Segoe UI", 10.2F);
            btnGenerateReports.Location = new Point(81, 22);
            btnGenerateReports.Name = "btnGenerateReports";
            btnGenerateReports.Size = new Size(159, 28);
            btnGenerateReports.TabIndex = 42;
            btnGenerateReports.Text = "GenerateReports";
            btnGenerateReports.UseVisualStyleBackColor = true;
            // 
            // TabExpenses
            // 
            TabExpenses.BackColor = Color.FromArgb(11, 20, 38);
            TabExpenses.Controls.Add(panel11);
            TabExpenses.Controls.Add(panel3);
            TabExpenses.Location = new Point(4, 37);
            TabExpenses.Name = "TabExpenses";
            TabExpenses.Padding = new Padding(3);
            TabExpenses.Size = new Size(1270, 602);
            TabExpenses.TabIndex = 1;
            TabExpenses.Text = "Expenses";
            // 
            // panel11
            // 
            panel11.Controls.Add(dgvExpenses);
            panel11.Controls.Add(panel12);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(3, 83);
            panel11.Name = "panel11";
            panel11.Size = new Size(1264, 516);
            panel11.TabIndex = 6;
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
            dgvExpenses.Location = new Point(0, 45);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.ReadOnly = true;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.RowHeadersWidth = 51;
            dgvExpenses.ScrollBars = ScrollBars.Vertical;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(1264, 471);
            dgvExpenses.TabIndex = 4;
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
            // panel12
            // 
            panel12.Controls.Add(lblExpenses);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(1264, 45);
            panel12.TabIndex = 3;
            // 
            // lblExpenses
            // 
            lblExpenses.BorderStyle = BorderStyle.FixedSingle;
            lblExpenses.Dock = DockStyle.Fill;
            lblExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpenses.ForeColor = Color.White;
            lblExpenses.ImageAlign = ContentAlignment.MiddleRight;
            lblExpenses.Location = new Point(0, 0);
            lblExpenses.Name = "lblExpenses";
            lblExpenses.Size = new Size(1264, 45);
            lblExpenses.TabIndex = 42;
            lblExpenses.Text = "Expenses";
            lblExpenses.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(panel2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(1264, 80);
            panel3.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(dateTimePicker3);
            panel2.Controls.Add(dateTimePicker4);
            panel2.Controls.Add(lblTotalExpensesValue);
            panel2.Controls.Add(lblTotalExpenses);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(5, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1252, 68);
            panel2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10.2F);
            button1.Location = new Point(1136, 22);
            button1.Name = "button1";
            button1.Size = new Size(94, 28);
            button1.TabIndex = 52;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10.2F);
            button2.Location = new Point(945, 22);
            button2.Name = "button2";
            button2.Size = new Size(159, 28);
            button2.TabIndex = 51;
            button2.Text = "GenerateReports";
            button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.ForeColor = Color.White;
            label3.ImageAlign = ContentAlignment.MiddleRight;
            label3.Location = new Point(769, 6);
            label3.Name = "label3";
            label3.Size = new Size(68, 23);
            label3.TabIndex = 50;
            label3.Text = "Date To";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.ForeColor = Color.White;
            label4.ImageAlign = ContentAlignment.MiddleRight;
            label4.Location = new Point(505, 6);
            label4.Name = "label4";
            label4.Size = new Size(90, 23);
            label4.TabIndex = 49;
            label4.Text = "Date From";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.ImageAlign = ContentAlignment.MiddleRight;
            label5.Location = new Point(661, 32);
            label5.Name = "label5";
            label5.Size = new Size(32, 28);
            label5.TabIndex = 48;
            label5.Text = "To";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Font = new Font("Segoe UI", 10.2F);
            dateTimePicker3.Format = DateTimePickerFormat.Short;
            dateTimePicker3.Location = new Point(737, 32);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(140, 30);
            dateTimePicker3.TabIndex = 47;
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.Font = new Font("Segoe UI", 10.2F);
            dateTimePicker4.Format = DateTimePickerFormat.Short;
            dateTimePicker4.Location = new Point(477, 32);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new Size(140, 30);
            dateTimePicker4.TabIndex = 46;
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
            lblTotalExpensesValue.Size = new Size(200, 68);
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
            lblTotalExpenses.Size = new Size(200, 68);
            lblTotalExpenses.TabIndex = 44;
            lblTotalExpenses.Text = " Total Expenses";
            lblTotalExpenses.TextAlign = ContentAlignment.MiddleCenter;
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
            tabReports.ResumeLayout(false);
            TabReceived.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReceived).EndInit();
            panel10.ResumeLayout(false);
            pnlReportsSummaryCards.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnlReportsHeaderContent.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            TabExpenses.ResumeLayout(false);
            panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            panel12.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlReportsHeader;
        private Label lblReportsTitle;
        private Panel pnlReportsContent;
        private TabControl tabReports;
        private TabPage TabReceived;
        private Panel panel9;
        private DataGridView dgvReceived;
        private DataGridViewTextBoxColumn colReportsReceivedDate;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colReportsReceivedTenant;
        private DataGridViewTextBoxColumn colReportsReceivedAmount;
        private Panel panel10;
        private Label lblReceived;
        private Panel pnlReportsSummaryCards;
        private Panel pnlReportsHeaderContent;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel6;
        private Label label2;
        private Label label1;
        private Label lblReportsTo;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Panel panel7;
        private Label lblReports;
        private ComboBox comboBox1;
        private Panel panel8;
        private Button btnReportsX;
        private Button btnGenerateReports;
        private TabPage TabExpenses;
        private Panel panel11;
        private DataGridView dgvExpenses;
        private DataGridViewTextBoxColumn colReportsExpensesDate;
        private DataGridViewTextBoxColumn colReportsExpensesCategory;
        private DataGridViewTextBoxColumn colReportsExpensesAmount;
        private Panel panel12;
        private Label lblExpenses;
        private Panel panel3;
        private Panel panel1;
        private Label lblTotalReceivedValue;
        private Label lblTotalReceived;
        private Panel panel2;
        private Label lblTotalExpensesValue;
        private Label lblTotalExpenses;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dateTimePicker3;
        private DateTimePicker dateTimePicker4;
        private Button button1;
        private Button button2;
    }
}
