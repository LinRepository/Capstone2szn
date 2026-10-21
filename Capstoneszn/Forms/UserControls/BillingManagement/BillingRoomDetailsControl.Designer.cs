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
            lblPeriodValue = new Label();
            lblRoomNumber = new Label();
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
            colShare = new DataGridViewTextBoxColumn();
            colPaid = new DataGridViewTextBoxColumn();
            colMaintenance = new DataGridViewTextBoxColumn();
            colOutstanding = new DataGridViewTextBoxColumn();
            colAdvance = new DataGridViewTextBoxColumn();
            colPayment = new DataGridViewButtonColumn();
            pnlTenantsCaption = new Panel();
            lblTenantsCaption = new Label();
            pnlRoomBillingHeader.SuspendLayout();
            pnlRoomBillingSummary.SuspendLayout();
            tblRoomBillingSummary.SuspendLayout();
            pnlPeriodBill.SuspendLayout();
            pnlPeriodPaid.SuspendLayout();
            pnlOutstanding.SuspendLayout();
            pnlOverdue.SuspendLayout();
            pnlTenantPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenantPayments).BeginInit();
            pnlTenantsCaption.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomBillingHeader
            // 
            pnlRoomBillingHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomBillingHeader.Controls.Add(lblBillStatusValue);
            pnlRoomBillingHeader.Controls.Add(lblPeriodValue);
            pnlRoomBillingHeader.Controls.Add(lblRoomNumber);
            pnlRoomBillingHeader.Controls.Add(btnBackRoomBilling);
            pnlRoomBillingHeader.Dock = DockStyle.Top;
            pnlRoomBillingHeader.Location = new Point(0, 0);
            pnlRoomBillingHeader.Name = "pnlRoomBillingHeader";
            pnlRoomBillingHeader.Size = new Size(1300, 90);
            pnlRoomBillingHeader.TabIndex = 0;
            // 
            // lblBillStatusValue
            // 
            lblBillStatusValue.Dock = DockStyle.Fill;
            lblBillStatusValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillStatusValue.ForeColor = Color.White;
            lblBillStatusValue.Location = new Point(780, 0);
            lblBillStatusValue.Name = "lblBillStatusValue";
            lblBillStatusValue.Padding = new Padding(0, 0, 20, 0);
            lblBillStatusValue.Size = new Size(518, 88);
            lblBillStatusValue.TabIndex = 3;
            lblBillStatusValue.Text = "-";
            lblBillStatusValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPeriodValue
            // 
            lblPeriodValue.Dock = DockStyle.Left;
            lblPeriodValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriodValue.ForeColor = Color.White;
            lblPeriodValue.Location = new Point(400, 0);
            lblPeriodValue.Name = "lblPeriodValue";
            lblPeriodValue.Size = new Size(380, 88);
            lblPeriodValue.TabIndex = 2;
            lblPeriodValue.Text = "-";
            lblPeriodValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.Dock = DockStyle.Left;
            lblRoomNumber.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.Location = new Point(140, 0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(260, 88);
            lblRoomNumber.TabIndex = 1;
            lblRoomNumber.Text = "Room -";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackRoomBilling
            // 
            btnBackRoomBilling.Cursor = Cursors.Hand;
            btnBackRoomBilling.Dock = DockStyle.Left;
            btnBackRoomBilling.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackRoomBilling.Location = new Point(0, 0);
            btnBackRoomBilling.Margin = new Padding(0);
            btnBackRoomBilling.Name = "btnBackRoomBilling";
            btnBackRoomBilling.Size = new Size(140, 88);
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
            lblPeriodBillValue.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            lblPeriodBillTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriodBillTitle.ForeColor = Color.Gainsboro;
            lblPeriodBillTitle.Location = new Point(0, 0);
            lblPeriodBillTitle.Margin = new Padding(0);
            lblPeriodBillTitle.Name = "lblPeriodBillTitle";
            lblPeriodBillTitle.Size = new Size(308, 40);
            lblPeriodBillTitle.TabIndex = 0;
            lblPeriodBillTitle.Text = "This Period";
            lblPeriodBillTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlPeriodPaid
            // 
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
            lblPeriodPaidValue.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            lblPeriodPaidTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            lblOutstandingValue.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            lblOutstandingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            lblOverdueValue.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            lblOverdueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            pnlTenantPayments.Controls.Add(pnlTenantsCaption);
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
            dgvTenantPayments.Columns.AddRange(new DataGridViewColumn[] { colTenantName, colShare, colPaid, colMaintenance, colOutstanding, colAdvance, colPayment });
            dgvTenantPayments.Dock = DockStyle.Fill;
            dgvTenantPayments.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvTenantPayments.Location = new Point(12, 44);
            dgvTenantPayments.MultiSelect = false;
            dgvTenantPayments.Name = "dgvTenantPayments";
            dgvTenantPayments.ReadOnly = true;
            dgvTenantPayments.RowHeadersVisible = false;
            dgvTenantPayments.RowHeadersWidth = 51;
            dgvTenantPayments.RowTemplate.Height = 38;
            dgvTenantPayments.ScrollBars = ScrollBars.Vertical;
            dgvTenantPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenantPayments.Size = new Size(1276, 474);
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
            // colShare
            // 
            colShare.DataPropertyName = "PeriodShare";
            colShare.FillWeight = 90F;
            colShare.HeaderText = "This Period";
            colShare.MinimumWidth = 6;
            colShare.Name = "colShare";
            colShare.ReadOnly = true;
            // 
            // colPaid
            // 
            colPaid.DataPropertyName = "PeriodPaid";
            colPaid.FillWeight = 90F;
            colPaid.HeaderText = "Paid This Period";
            colPaid.MinimumWidth = 6;
            colPaid.Name = "colPaid";
            colPaid.ReadOnly = true;
            // 
            // colMaintenance
            // 
            colMaintenance.DataPropertyName = "MaintenanceOwed";
            colMaintenance.FillWeight = 90F;
            colMaintenance.HeaderText = "Maintenance Owed";
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
            // colAdvance
            // 
            colAdvance.DataPropertyName = "Advance";
            colAdvance.FillWeight = 90F;
            colAdvance.HeaderText = "Paid Ahead";
            colAdvance.MinimumWidth = 6;
            colAdvance.Name = "colAdvance";
            colAdvance.ReadOnly = true;
            // 
            // colPayment
            // 
            colPayment.HeaderText = "Action";
            colPayment.MinimumWidth = 6;
            colPayment.Name = "colPayment";
            colPayment.ReadOnly = true;
            // 
            // pnlTenantsCaption
            // 
            pnlTenantsCaption.Controls.Add(lblTenantsCaption);
            pnlTenantsCaption.Dock = DockStyle.Top;
            pnlTenantsCaption.Location = new Point(12, 0);
            pnlTenantsCaption.Name = "pnlTenantsCaption";
            pnlTenantsCaption.Size = new Size(1276, 44);
            pnlTenantsCaption.TabIndex = 0;
            // 
            // lblTenantsCaption
            // 
            lblTenantsCaption.Dock = DockStyle.Fill;
            lblTenantsCaption.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantsCaption.ForeColor = Color.White;
            lblTenantsCaption.Location = new Point(0, 0);
            lblTenantsCaption.Margin = new Padding(0);
            lblTenantsCaption.Name = "lblTenantsCaption";
            lblTenantsCaption.Size = new Size(1276, 44);
            lblTenantsCaption.TabIndex = 0;
            lblTenantsCaption.Text = "Current tenants";
            lblTenantsCaption.TextAlign = ContentAlignment.MiddleLeft;
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
            pnlRoomBillingSummary.ResumeLayout(false);
            tblRoomBillingSummary.ResumeLayout(false);
            pnlPeriodBill.ResumeLayout(false);
            pnlPeriodPaid.ResumeLayout(false);
            pnlOutstanding.ResumeLayout(false);
            pnlOverdue.ResumeLayout(false);
            pnlTenantPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTenantPayments).EndInit();
            pnlTenantsCaption.ResumeLayout(false);
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
        private Panel pnlTenantsCaption;
        private Label lblTenantsCaption;
        private DataGridView dgvTenantPayments;
        private DataGridViewTextBoxColumn colTenantName;
        private DataGridViewTextBoxColumn colShare;
        private DataGridViewTextBoxColumn colPaid;
        private DataGridViewTextBoxColumn colMaintenance;
        private DataGridViewTextBoxColumn colOutstanding;
        private DataGridViewTextBoxColumn colAdvance;
        private DataGridViewButtonColumn colPayment;
    }
}
