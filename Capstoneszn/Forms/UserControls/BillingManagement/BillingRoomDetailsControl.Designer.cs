namespace Capstoneszn.Forms.UserControls.BillingManagement
{
    partial class BillingRoomDetailsControl
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
            pnlRoomBillingHeader = new Panel();
            lblBillStatusValue = new Label();
            panel3 = new Panel();
            btnGenerateStatment = new Button();
            lblPeriodValue = new Label();
            lblRoomNumber = new Label();
            panel1 = new Panel();
            btnBackRoomBilling = new Button();
            pnlRoomBillingSummary = new Panel();
            tblRoomBillingSummary = new TableLayoutPanel();
            pnlPeriodBill = new Panel();
            lblPeriodBillValue = new Label();
            lblPeriodBillTitle = new Label();
            pnlPeriodPaid = new Panel();
            lblPeriodPaidValue = new Label();
            lblPeriodPaidTitle = new Label();
            pnlOutstanding = new Panel();
            lblOutstandingValue = new Label();
            lblOutstandingTitle = new Label();
            pnlOverdue = new Panel();
            lblOverdueValue = new Label();
            lblOverdueTitle = new Label();
            pnlTenantPayments = new Panel();
            dgvTenantPayments = new DataGridView();
            colTenantName = new DataGridViewTextBoxColumn();
            colRent = new DataGridViewTextBoxColumn();
            colWater = new DataGridViewTextBoxColumn();
            colMaintenance = new DataGridViewTextBoxColumn();
            colOutstanding = new DataGridViewTextBoxColumn();
            colCredits = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colPayment = new DataGridViewButtonColumn();
            pnlRoomBillingHeader.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            pnlRoomBillingSummary.SuspendLayout();
            tblRoomBillingSummary.SuspendLayout();
            pnlPeriodBill.SuspendLayout();
            pnlPeriodPaid.SuspendLayout();
            pnlOutstanding.SuspendLayout();
            pnlOverdue.SuspendLayout();
            pnlTenantPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenantPayments).BeginInit();
            SuspendLayout();
            // 
            // pnlRoomBillingHeader
            // 
            pnlRoomBillingHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomBillingHeader.Controls.Add(lblBillStatusValue);
            pnlRoomBillingHeader.Controls.Add(panel3);
            pnlRoomBillingHeader.Controls.Add(lblPeriodValue);
            pnlRoomBillingHeader.Controls.Add(lblRoomNumber);
            pnlRoomBillingHeader.Controls.Add(panel1);
            pnlRoomBillingHeader.Dock = DockStyle.Top;
            pnlRoomBillingHeader.Location = new Point(0, 0);
            pnlRoomBillingHeader.Name = "pnlRoomBillingHeader";
            pnlRoomBillingHeader.Size = new Size(1300, 90);
            pnlRoomBillingHeader.TabIndex = 0;
            // 
            // lblBillStatusValue
            // 
            lblBillStatusValue.Dock = DockStyle.Right;
            lblBillStatusValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillStatusValue.ForeColor = Color.White;
            lblBillStatusValue.Location = new Point(681, 0);
            lblBillStatusValue.Name = "lblBillStatusValue";
            lblBillStatusValue.Padding = new Padding(0, 0, 20, 0);
            lblBillStatusValue.Size = new Size(361, 88);
            lblBillStatusValue.TabIndex = 3;
            lblBillStatusValue.Text = "-";
            lblBillStatusValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnGenerateStatment);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1042, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(30, 15, 30, 15);
            panel3.Size = new Size(256, 88);
            panel3.TabIndex = 6;
            // 
            // btnGenerateStatment
            // 
            btnGenerateStatment.Dock = DockStyle.Fill;
            btnGenerateStatment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGenerateStatment.Location = new Point(30, 15);
            btnGenerateStatment.Name = "btnGenerateStatment";
            btnGenerateStatment.Size = new Size(196, 58);
            btnGenerateStatment.TabIndex = 4;
            btnGenerateStatment.Text = "Generate statement";
            btnGenerateStatment.UseVisualStyleBackColor = true;
            btnGenerateStatment.Click += btnGenerateStatment_Click;
            // 
            // lblPeriodValue
            // 
            lblPeriodValue.Dock = DockStyle.Left;
            lblPeriodValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriodValue.ForeColor = Color.White;
            lblPeriodValue.Location = new Point(320, 0);
            lblPeriodValue.Name = "lblPeriodValue";
            lblPeriodValue.Size = new Size(287, 88);
            lblPeriodValue.TabIndex = 2;
            lblPeriodValue.Text = "-";
            lblPeriodValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.Dock = DockStyle.Left;
            lblRoomNumber.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.Location = new Point(116, 0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(204, 88);
            lblRoomNumber.TabIndex = 1;
            lblRoomNumber.Text = "Room -";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnBackRoomBilling);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(116, 88);
            panel1.TabIndex = 1;
            // 
            // btnBackRoomBilling
            // 
            btnBackRoomBilling.Cursor = Cursors.Hand;
            btnBackRoomBilling.Dock = DockStyle.Fill;
            btnBackRoomBilling.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackRoomBilling.Location = new Point(10, 10);
            btnBackRoomBilling.Margin = new Padding(0);
            btnBackRoomBilling.Name = "btnBackRoomBilling";
            btnBackRoomBilling.Size = new Size(96, 68);
            btnBackRoomBilling.TabIndex = 0;
            btnBackRoomBilling.Text = "←";
            btnBackRoomBilling.TextAlign = ContentAlignment.TopCenter;
            btnBackRoomBilling.UseVisualStyleBackColor = true;
            btnBackRoomBilling.Click += btnBackRoomBilling_Click;
            // 
            // pnlRoomBillingSummary
            // 
            pnlRoomBillingSummary.Controls.Add(tblRoomBillingSummary);
            pnlRoomBillingSummary.Dock = DockStyle.Top;
            pnlRoomBillingSummary.Location = new Point(0, 90);
            pnlRoomBillingSummary.Name = "pnlRoomBillingSummary";
            pnlRoomBillingSummary.Padding = new Padding(6);
            pnlRoomBillingSummary.Size = new Size(1300, 130);
            pnlRoomBillingSummary.TabIndex = 1;
            // 
            // tblRoomBillingSummary
            // 
            tblRoomBillingSummary.ColumnCount = 4;
            tblRoomBillingSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblRoomBillingSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblRoomBillingSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblRoomBillingSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblRoomBillingSummary.Controls.Add(pnlPeriodBill, 0, 0);
            tblRoomBillingSummary.Controls.Add(pnlPeriodPaid, 1, 0);
            tblRoomBillingSummary.Controls.Add(pnlOutstanding, 2, 0);
            tblRoomBillingSummary.Controls.Add(pnlOverdue, 3, 0);
            tblRoomBillingSummary.Dock = DockStyle.Fill;
            tblRoomBillingSummary.Location = new Point(6, 6);
            tblRoomBillingSummary.Name = "tblRoomBillingSummary";
            tblRoomBillingSummary.RowCount = 1;
            tblRoomBillingSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRoomBillingSummary.Size = new Size(1288, 118);
            tblRoomBillingSummary.TabIndex = 0;
            // 
            // pnlPeriodBill
            // 
            pnlPeriodBill.BackColor = Color.FromArgb(25, 25, 80);
            pnlPeriodBill.BorderStyle = BorderStyle.FixedSingle;
            pnlPeriodBill.Controls.Add(lblPeriodBillValue);
            pnlPeriodBill.Controls.Add(lblPeriodBillTitle);
            pnlPeriodBill.Dock = DockStyle.Fill;
            pnlPeriodBill.Location = new Point(6, 6);
            pnlPeriodBill.Margin = new Padding(6);
            pnlPeriodBill.Name = "pnlPeriodBill";
            pnlPeriodBill.Size = new Size(310, 106);
            pnlPeriodBill.TabIndex = 0;
            // 
            // lblPeriodBillValue
            // 
            lblPeriodBillValue.Dock = DockStyle.Fill;
            lblPeriodBillValue.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            lblPeriodBillValue.ForeColor = Color.White;
            lblPeriodBillValue.Location = new Point(0, 40);
            lblPeriodBillValue.Margin = new Padding(0);
            lblPeriodBillValue.Name = "lblPeriodBillValue";
            lblPeriodBillValue.Size = new Size(308, 64);
            lblPeriodBillValue.TabIndex = 1;
            lblPeriodBillValue.Text = "0.00";
            lblPeriodBillValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPeriodBillTitle
            // 
            lblPeriodBillTitle.Dock = DockStyle.Top;
            lblPeriodBillTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblPeriodBillTitle.ForeColor = Color.Gainsboro;
            lblPeriodBillTitle.Location = new Point(0, 0);
            lblPeriodBillTitle.Margin = new Padding(0);
            lblPeriodBillTitle.Name = "lblPeriodBillTitle";
            lblPeriodBillTitle.Size = new Size(308, 40);
            lblPeriodBillTitle.TabIndex = 0;
            lblPeriodBillTitle.Text = "Current charges";
            lblPeriodBillTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlPeriodPaid
            // 
            pnlPeriodPaid.BackColor = Color.FromArgb(25, 25, 80);
            pnlPeriodPaid.BorderStyle = BorderStyle.FixedSingle;
            pnlPeriodPaid.Controls.Add(lblPeriodPaidValue);
            pnlPeriodPaid.Controls.Add(lblPeriodPaidTitle);
            pnlPeriodPaid.Dock = DockStyle.Fill;
            pnlPeriodPaid.Location = new Point(328, 6);
            pnlPeriodPaid.Margin = new Padding(6);
            pnlPeriodPaid.Name = "pnlPeriodPaid";
            pnlPeriodPaid.Size = new Size(310, 106);
            pnlPeriodPaid.TabIndex = 1;
            // 
            // lblPeriodPaidValue
            // 
            lblPeriodPaidValue.Dock = DockStyle.Fill;
            lblPeriodPaidValue.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            lblPeriodPaidValue.ForeColor = Color.White;
            lblPeriodPaidValue.Location = new Point(0, 40);
            lblPeriodPaidValue.Margin = new Padding(0);
            lblPeriodPaidValue.Name = "lblPeriodPaidValue";
            lblPeriodPaidValue.Size = new Size(308, 64);
            lblPeriodPaidValue.TabIndex = 1;
            lblPeriodPaidValue.Text = "0.00";
            lblPeriodPaidValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPeriodPaidTitle
            // 
            lblPeriodPaidTitle.Dock = DockStyle.Top;
            lblPeriodPaidTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblPeriodPaidTitle.ForeColor = Color.Gainsboro;
            lblPeriodPaidTitle.Location = new Point(0, 0);
            lblPeriodPaidTitle.Margin = new Padding(0);
            lblPeriodPaidTitle.Name = "lblPeriodPaidTitle";
            lblPeriodPaidTitle.Size = new Size(308, 40);
            lblPeriodPaidTitle.TabIndex = 0;
            lblPeriodPaidTitle.Text = "Paid This Period";
            lblPeriodPaidTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlOutstanding
            // 
            pnlOutstanding.BackColor = Color.FromArgb(25, 25, 80);
            pnlOutstanding.BorderStyle = BorderStyle.FixedSingle;
            pnlOutstanding.Controls.Add(lblOutstandingValue);
            pnlOutstanding.Controls.Add(lblOutstandingTitle);
            pnlOutstanding.Dock = DockStyle.Fill;
            pnlOutstanding.Location = new Point(650, 6);
            pnlOutstanding.Margin = new Padding(6);
            pnlOutstanding.Name = "pnlOutstanding";
            pnlOutstanding.Size = new Size(310, 106);
            pnlOutstanding.TabIndex = 2;
            // 
            // lblOutstandingValue
            // 
            lblOutstandingValue.Dock = DockStyle.Fill;
            lblOutstandingValue.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            lblOutstandingValue.ForeColor = Color.White;
            lblOutstandingValue.Location = new Point(0, 40);
            lblOutstandingValue.Margin = new Padding(0);
            lblOutstandingValue.Name = "lblOutstandingValue";
            lblOutstandingValue.Size = new Size(308, 64);
            lblOutstandingValue.TabIndex = 1;
            lblOutstandingValue.Text = "0.00";
            lblOutstandingValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOutstandingTitle
            // 
            lblOutstandingTitle.Dock = DockStyle.Top;
            lblOutstandingTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblOutstandingTitle.ForeColor = Color.Gainsboro;
            lblOutstandingTitle.Location = new Point(0, 0);
            lblOutstandingTitle.Margin = new Padding(0);
            lblOutstandingTitle.Name = "lblOutstandingTitle";
            lblOutstandingTitle.Size = new Size(308, 40);
            lblOutstandingTitle.TabIndex = 0;
            lblOutstandingTitle.Text = "Outstanding (All Periods)";
            lblOutstandingTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlOverdue
            // 
            pnlOverdue.BackColor = Color.FromArgb(25, 25, 80);
            pnlOverdue.BorderStyle = BorderStyle.FixedSingle;
            pnlOverdue.Controls.Add(lblOverdueValue);
            pnlOverdue.Controls.Add(lblOverdueTitle);
            pnlOverdue.Dock = DockStyle.Fill;
            pnlOverdue.Location = new Point(972, 6);
            pnlOverdue.Margin = new Padding(6);
            pnlOverdue.Name = "pnlOverdue";
            pnlOverdue.Size = new Size(310, 106);
            pnlOverdue.TabIndex = 3;
            // 
            // lblOverdueValue
            // 
            lblOverdueValue.Dock = DockStyle.Fill;
            lblOverdueValue.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold);
            lblOverdueValue.ForeColor = Color.White;
            lblOverdueValue.Location = new Point(0, 40);
            lblOverdueValue.Margin = new Padding(0);
            lblOverdueValue.Name = "lblOverdueValue";
            lblOverdueValue.Size = new Size(308, 64);
            lblOverdueValue.TabIndex = 1;
            lblOverdueValue.Text = "0.00";
            lblOverdueValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOverdueTitle
            // 
            lblOverdueTitle.Dock = DockStyle.Top;
            lblOverdueTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblOverdueTitle.ForeColor = Color.Gainsboro;
            lblOverdueTitle.Location = new Point(0, 0);
            lblOverdueTitle.Margin = new Padding(0);
            lblOverdueTitle.Name = "lblOverdueTitle";
            lblOverdueTitle.Size = new Size(308, 40);
            lblOverdueTitle.TabIndex = 0;
            lblOverdueTitle.Text = "Overdue";
            lblOverdueTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlTenantPayments
            // 
            pnlTenantPayments.Controls.Add(dgvTenantPayments);
            pnlTenantPayments.Dock = DockStyle.Fill;
            pnlTenantPayments.Location = new Point(0, 220);
            pnlTenantPayments.Name = "pnlTenantPayments";
            pnlTenantPayments.Padding = new Padding(12, 0, 12, 12);
            pnlTenantPayments.Size = new Size(1300, 530);
            pnlTenantPayments.TabIndex = 2;
            // 
            // dgvTenantPayments
            // 
            dgvTenantPayments.AllowUserToAddRows = false;
            dgvTenantPayments.AllowUserToDeleteRows = false;
            dgvTenantPayments.AllowUserToResizeRows = false;
            dgvTenantPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTenantPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTenantPayments.Columns.AddRange(new DataGridViewColumn[] { colTenantName, colRent, colWater, colMaintenance, colOutstanding, colCredits, colStatus, colPayment });
            dgvTenantPayments.Dock = DockStyle.Fill;
            dgvTenantPayments.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvTenantPayments.Location = new Point(12, 0);
            dgvTenantPayments.MultiSelect = false;
            dgvTenantPayments.Name = "dgvTenantPayments";
            dgvTenantPayments.ReadOnly = true;
            dgvTenantPayments.RowHeadersVisible = false;
            dgvTenantPayments.RowHeadersWidth = 51;
            dgvTenantPayments.RowTemplate.Height = 38;
            dgvTenantPayments.ScrollBars = ScrollBars.Vertical;
            dgvTenantPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenantPayments.Size = new Size(1276, 518);
            dgvTenantPayments.TabIndex = 1;
            dgvTenantPayments.CellContentClick += dgvTenantPayments_CellContentClick;
            dgvTenantPayments.CellDoubleClick += dgvTenantPayments_CellDoubleClick;
            dgvTenantPayments.CellFormatting += dgvTenantPayments_CellFormatting;
            // 
            // colTenantName
            // 
            colTenantName.DataPropertyName = "TenantName";
            colTenantName.FillWeight = 170F;
            colTenantName.HeaderText = "Tenant";
            colTenantName.MinimumWidth = 6;
            colTenantName.Name = "colTenantName";
            colTenantName.ReadOnly = true;
            // 
            // colRent
            // 
            colRent.HeaderText = "Rent";
            colRent.MinimumWidth = 6;
            colRent.Name = "colRent";
            colRent.ReadOnly = true;
            // 
            // colWater
            // 
            colWater.HeaderText = "Water";
            colWater.MinimumWidth = 6;
            colWater.Name = "colWater";
            colWater.ReadOnly = true;
            // 
            // colMaintenance
            // 
            colMaintenance.HeaderText = "Maintenance";
            colMaintenance.MinimumWidth = 6;
            colMaintenance.Name = "colMaintenance";
            colMaintenance.ReadOnly = true;
            // 
            // colOutstanding
            // 
            colOutstanding.DataPropertyName = "Outstanding";
            colOutstanding.FillWeight = 90F;
            colOutstanding.HeaderText = "Total Outstanding";
            colOutstanding.MinimumWidth = 6;
            colOutstanding.Name = "colOutstanding";
            colOutstanding.ReadOnly = true;
            // 
            // colCredits
            // 
            colCredits.DataPropertyName = "Advance";
            colCredits.FillWeight = 90F;
            colCredits.HeaderText = "Credits";
            colCredits.MinimumWidth = 6;
            colCredits.Name = "colCredits";
            colCredits.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colPayment
            // 
            colPayment.HeaderText = "Action";
            colPayment.MinimumWidth = 6;
            colPayment.Name = "colPayment";
            colPayment.ReadOnly = true;
            // 
            // BillingRoomDetailsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            Controls.Add(pnlTenantPayments);
            Controls.Add(pnlRoomBillingSummary);
            Controls.Add(pnlRoomBillingHeader);
            Name = "BillingRoomDetailsControl";
            Size = new Size(1300, 750);
            pnlRoomBillingHeader.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnlRoomBillingSummary.ResumeLayout(false);
            tblRoomBillingSummary.ResumeLayout(false);
            pnlPeriodBill.ResumeLayout(false);
            pnlPeriodPaid.ResumeLayout(false);
            pnlOutstanding.ResumeLayout(false);
            pnlOverdue.ResumeLayout(false);
            pnlTenantPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTenantPayments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoomBillingHeader;
        private Button btnBackRoomBilling;
        private Label lblRoomNumber;
        private Label lblPeriodValue;
        private Label lblBillStatusValue;
        private Panel pnlRoomBillingSummary;
        private TableLayoutPanel tblRoomBillingSummary;
        private Panel pnlPeriodBill;
        private Label lblPeriodBillTitle;
        private Label lblPeriodBillValue;
        private Panel pnlPeriodPaid;
        private Label lblPeriodPaidTitle;
        private Label lblPeriodPaidValue;
        private Panel pnlOutstanding;
        private Label lblOutstandingTitle;
        private Label lblOutstandingValue;
        private Panel pnlOverdue;
        private Label lblOverdueTitle;
        private Label lblOverdueValue;
        private Panel pnlTenantPayments;
        private DataGridView dgvTenantPayments;
        private Panel panel1;
        private Button btnGenerateStatment;
        private Panel panel3;
        private DataGridViewTextBoxColumn colTenantName;
        private DataGridViewTextBoxColumn colRent;
        private DataGridViewTextBoxColumn colWater;
        private DataGridViewTextBoxColumn colMaintenance;
        private DataGridViewTextBoxColumn colOutstanding;
        private DataGridViewTextBoxColumn colCredits;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewButtonColumn colPayment;
    }
}
