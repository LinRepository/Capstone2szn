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
            pnlReportsFilter = new Panel();
            btnPrintReport = new Button();
            btnClearReport = new Button();
            btnGenerateReport = new Button();
            cboReportRoom = new ComboBox();
            lblReportRoom = new Label();
            dtpReportTo = new DateTimePicker();
            lblReportTo = new Label();
            dtpReportFrom = new DateTimePicker();
            lblReportFrom = new Label();
            pnlReportsSummary = new Panel();
            tlpSummary = new TableLayoutPanel();
            lblSummaryNote = new Label();
            pnlReportsContent = new Panel();
            tabReports = new TabControl();
            tabReceived = new TabPage();
            dgvReceived = new DataGridView();
            tabExpenses = new TabPage();
            dgvExpenses = new DataGridView();
            pnlReportsHeader.SuspendLayout();
            pnlReportsFilter.SuspendLayout();
            pnlReportsSummary.SuspendLayout();
            pnlReportsContent.SuspendLayout();
            tabReports.SuspendLayout();
            tabReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceived).BeginInit();
            tabExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            //
            // pnlReportsHeader
            //
            pnlReportsHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlReportsHeader.Controls.Add(lblReportsTitle);
            pnlReportsHeader.Dock = DockStyle.Top;
            pnlReportsHeader.Location = new Point(10, 10);
            pnlReportsHeader.Name = "pnlReportsHeader";
            pnlReportsHeader.Size = new Size(1280, 70);
            pnlReportsHeader.TabIndex = 0;
            //
            // lblReportsTitle
            //
            lblReportsTitle.Dock = DockStyle.Fill;
            lblReportsTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReportsTitle.ForeColor = Color.White;
            lblReportsTitle.Location = new Point(0, 0);
            lblReportsTitle.Name = "lblReportsTitle";
            lblReportsTitle.Size = new Size(1278, 68);
            lblReportsTitle.TabIndex = 0;
            lblReportsTitle.Text = "Reports";
            lblReportsTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlReportsFilter
            //
            pnlReportsFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlReportsFilter.Controls.Add(btnPrintReport);
            pnlReportsFilter.Controls.Add(btnClearReport);
            pnlReportsFilter.Controls.Add(btnGenerateReport);
            pnlReportsFilter.Controls.Add(cboReportRoom);
            pnlReportsFilter.Controls.Add(lblReportRoom);
            pnlReportsFilter.Controls.Add(dtpReportTo);
            pnlReportsFilter.Controls.Add(lblReportTo);
            pnlReportsFilter.Controls.Add(dtpReportFrom);
            pnlReportsFilter.Controls.Add(lblReportFrom);
            pnlReportsFilter.Dock = DockStyle.Top;
            pnlReportsFilter.Location = new Point(10, 80);
            pnlReportsFilter.Name = "pnlReportsFilter";
            pnlReportsFilter.Size = new Size(1280, 75);
            pnlReportsFilter.TabIndex = 1;
            //
            // lblReportFrom
            //
            lblReportFrom.AutoSize = true;
            lblReportFrom.Font = new Font("Segoe UI", 10.2F);
            lblReportFrom.ForeColor = Color.White;
            lblReportFrom.Location = new Point(12, 6);
            lblReportFrom.Name = "lblReportFrom";
            lblReportFrom.Size = new Size(90, 23);
            lblReportFrom.TabIndex = 0;
            lblReportFrom.Text = "Date From";
            //
            // dtpReportFrom
            //
            dtpReportFrom.Font = new Font("Segoe UI", 10.2F);
            dtpReportFrom.Format = DateTimePickerFormat.Custom;
            dtpReportFrom.CustomFormat = "MMM dd, yyyy";
            dtpReportFrom.Location = new Point(12, 32);
            dtpReportFrom.Name = "dtpReportFrom";
            dtpReportFrom.Size = new Size(180, 30);
            dtpReportFrom.TabIndex = 1;
            //
            // lblReportTo
            //
            lblReportTo.AutoSize = true;
            lblReportTo.Font = new Font("Segoe UI", 10.2F);
            lblReportTo.ForeColor = Color.White;
            lblReportTo.Location = new Point(210, 6);
            lblReportTo.Name = "lblReportTo";
            lblReportTo.Size = new Size(68, 23);
            lblReportTo.TabIndex = 2;
            lblReportTo.Text = "Date To";
            //
            // dtpReportTo
            //
            dtpReportTo.Font = new Font("Segoe UI", 10.2F);
            dtpReportTo.Format = DateTimePickerFormat.Custom;
            dtpReportTo.CustomFormat = "MMM dd, yyyy";
            dtpReportTo.Location = new Point(210, 32);
            dtpReportTo.Name = "dtpReportTo";
            dtpReportTo.Size = new Size(180, 30);
            dtpReportTo.TabIndex = 3;
            //
            // lblReportRoom
            //
            lblReportRoom.AutoSize = true;
            lblReportRoom.Font = new Font("Segoe UI", 10.2F);
            lblReportRoom.ForeColor = Color.White;
            lblReportRoom.Location = new Point(410, 6);
            lblReportRoom.Name = "lblReportRoom";
            lblReportRoom.Size = new Size(213, 23);
            lblReportRoom.TabIndex = 4;
            lblReportRoom.Text = "Room (Received tab only)";
            //
            // cboReportRoom
            //
            cboReportRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboReportRoom.Font = new Font("Segoe UI", 10.2F);
            cboReportRoom.FormattingEnabled = true;
            cboReportRoom.Location = new Point(410, 31);
            cboReportRoom.Name = "cboReportRoom";
            cboReportRoom.Size = new Size(200, 31);
            cboReportRoom.TabIndex = 5;
            //
            // btnGenerateReport
            //
            btnGenerateReport.Font = new Font("Segoe UI", 10.2F);
            btnGenerateReport.Location = new Point(640, 29);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 34);
            btnGenerateReport.TabIndex = 6;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            //
            // btnClearReport
            //
            btnClearReport.Font = new Font("Segoe UI", 10.2F);
            btnClearReport.Location = new Point(800, 29);
            btnClearReport.Name = "btnClearReport";
            btnClearReport.Size = new Size(100, 34);
            btnClearReport.TabIndex = 7;
            btnClearReport.Text = "Clear";
            btnClearReport.UseVisualStyleBackColor = true;
            //
            // btnPrintReport
            //
            btnPrintReport.Font = new Font("Segoe UI", 10.2F);
            btnPrintReport.Location = new Point(910, 29);
            btnPrintReport.Name = "btnPrintReport";
            btnPrintReport.Size = new Size(120, 34);
            btnPrintReport.TabIndex = 8;
            btnPrintReport.Text = "Print / PDF";
            btnPrintReport.UseVisualStyleBackColor = true;
            //
            // pnlReportsSummary
            //
            pnlReportsSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlReportsSummary.Controls.Add(tlpSummary);
            pnlReportsSummary.Controls.Add(lblSummaryNote);
            pnlReportsSummary.Dock = DockStyle.Top;
            pnlReportsSummary.Location = new Point(10, 155);
            pnlReportsSummary.Name = "pnlReportsSummary";
            pnlReportsSummary.Padding = new Padding(5);
            pnlReportsSummary.Size = new Size(1280, 120);
            pnlReportsSummary.TabIndex = 2;
            //
            // tlpSummary
            //
            tlpSummary.ColumnCount = 5;
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpSummary.Dock = DockStyle.Fill;
            tlpSummary.Location = new Point(5, 5);
            tlpSummary.Name = "tlpSummary";
            tlpSummary.RowCount = 1;
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSummary.Size = new Size(1268, 82);
            tlpSummary.TabIndex = 0;
            //
            // lblSummaryNote
            //
            lblSummaryNote.Dock = DockStyle.Bottom;
            lblSummaryNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSummaryNote.ForeColor = Color.Silver;
            lblSummaryNote.Location = new Point(5, 87);
            lblSummaryNote.Name = "lblSummaryNote";
            lblSummaryNote.Size = new Size(1268, 26);
            lblSummaryNote.TabIndex = 1;
            lblSummaryNote.Text = "Net Income = Rent Collected - Expenses. Water and maintenance collections reimburse costs paid for tenants, so they are not counted as income.";
            lblSummaryNote.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlReportsContent
            //
            pnlReportsContent.BorderStyle = BorderStyle.FixedSingle;
            pnlReportsContent.Controls.Add(tabReports);
            pnlReportsContent.Dock = DockStyle.Fill;
            pnlReportsContent.Location = new Point(10, 275);
            pnlReportsContent.Name = "pnlReportsContent";
            pnlReportsContent.Size = new Size(1280, 465);
            pnlReportsContent.TabIndex = 3;
            //
            // tabReports
            //
            tabReports.Controls.Add(tabReceived);
            tabReports.Controls.Add(tabExpenses);
            tabReports.Dock = DockStyle.Fill;
            tabReports.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabReports.Location = new Point(0, 0);
            tabReports.Name = "tabReports";
            tabReports.SelectedIndex = 0;
            tabReports.Size = new Size(1278, 463);
            tabReports.TabIndex = 0;
            //
            // tabReceived
            //
            tabReceived.BackColor = Color.FromArgb(11, 20, 38);
            tabReceived.Controls.Add(dgvReceived);
            tabReceived.Location = new Point(4, 37);
            tabReceived.Name = "tabReceived";
            tabReceived.Padding = new Padding(3);
            tabReceived.Size = new Size(1270, 422);
            tabReceived.TabIndex = 0;
            tabReceived.Text = "Received";
            //
            // dgvReceived
            //
            dgvReceived.Dock = DockStyle.Fill;
            dgvReceived.Location = new Point(3, 3);
            dgvReceived.Name = "dgvReceived";
            dgvReceived.Size = new Size(1264, 416);
            dgvReceived.TabIndex = 0;
            //
            // tabExpenses
            //
            tabExpenses.BackColor = Color.FromArgb(11, 20, 38);
            tabExpenses.Controls.Add(dgvExpenses);
            tabExpenses.Location = new Point(4, 37);
            tabExpenses.Name = "tabExpenses";
            tabExpenses.Padding = new Padding(3);
            tabExpenses.Size = new Size(1270, 422);
            tabExpenses.TabIndex = 1;
            tabExpenses.Text = "Expenses";
            //
            // dgvExpenses
            //
            dgvExpenses.Dock = DockStyle.Fill;
            dgvExpenses.Location = new Point(3, 3);
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.Size = new Size(1264, 416);
            dgvExpenses.TabIndex = 0;
            //
            // ReportsControl
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlReportsContent);
            Controls.Add(pnlReportsSummary);
            Controls.Add(pnlReportsFilter);
            Controls.Add(pnlReportsHeader);
            Name = "ReportsControl";
            Padding = new Padding(10);
            Size = new Size(1300, 750);
            pnlReportsHeader.ResumeLayout(false);
            pnlReportsFilter.ResumeLayout(false);
            pnlReportsFilter.PerformLayout();
            pnlReportsSummary.ResumeLayout(false);
            pnlReportsContent.ResumeLayout(false);
            tabReports.ResumeLayout(false);
            tabReceived.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReceived).EndInit();
            tabExpenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlReportsHeader;
        private Label lblReportsTitle;
        private Panel pnlReportsFilter;
        private Label lblReportFrom;
        private DateTimePicker dtpReportFrom;
        private Label lblReportTo;
        private DateTimePicker dtpReportTo;
        private Label lblReportRoom;
        private ComboBox cboReportRoom;
        private Button btnGenerateReport;
        private Button btnClearReport;
        private Button btnPrintReport;
        private Panel pnlReportsSummary;
        private TableLayoutPanel tlpSummary;
        private Label lblSummaryNote;
        private Panel pnlReportsContent;
        private TabControl tabReports;
        private TabPage tabReceived;
        private DataGridView dgvReceived;
        private TabPage tabExpenses;
        private DataGridView dgvExpenses;
    }
}
