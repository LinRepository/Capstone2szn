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
            pnlRoomBillingSummary = new Panel();
            tblRoomBillingSummary = new TableLayoutPanel();
            pnlTotalPaid = new Panel();
            lblTotalPaidValue = new Label();
            lblTotalPaidTitle = new Label();
            pnlCurrentDue = new Panel();
            lblCurrentDueValue = new Label();
            lblCurrentDueTitle = new Label();
            pnlTotalBill = new Panel();
            lblTotalBillValue = new Label();
            lblTotalBillTitle = new Label();
            pnlTenantPayments = new Panel();
            dgvTenantPayments = new DataGridView();
            btnBackRoomBilling = new Button();
            lblRoomNumber = new Label();
            lblPeriodValue = new Label();
            lblBillStatusValue = new Label();
            pnlRoomBillingHeader = new Panel();
            colTenantName = new DataGridViewTextBoxColumn();
            colShare = new DataGridViewTextBoxColumn();
            colPaid = new DataGridViewTextBoxColumn();
            colBalance = new DataGridViewTextBoxColumn();
            colPayment = new DataGridViewButtonColumn();
            pnlRoomBillingSummary.SuspendLayout();
            tblRoomBillingSummary.SuspendLayout();
            pnlTotalPaid.SuspendLayout();
            pnlCurrentDue.SuspendLayout();
            pnlTotalBill.SuspendLayout();
            pnlTenantPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenantPayments).BeginInit();
            pnlRoomBillingHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomBillingSummary
            // 
            pnlRoomBillingSummary.Controls.Add(tblRoomBillingSummary);
            pnlRoomBillingSummary.Dock = DockStyle.Top;
            pnlRoomBillingSummary.Location = new Point(0, 90);
            pnlRoomBillingSummary.Name = "pnlRoomBillingSummary";
            pnlRoomBillingSummary.Size = new Size(1300, 125);
            pnlRoomBillingSummary.TabIndex = 1;
            // 
            // tblRoomBillingSummary
            // 
            tblRoomBillingSummary.ColumnCount = 3;
            tblRoomBillingSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblRoomBillingSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblRoomBillingSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblRoomBillingSummary.Controls.Add(pnlTotalPaid, 1, 0);
            tblRoomBillingSummary.Controls.Add(pnlCurrentDue, 2, 0);
            tblRoomBillingSummary.Controls.Add(pnlTotalBill, 0, 0);
            tblRoomBillingSummary.Dock = DockStyle.Fill;
            tblRoomBillingSummary.Location = new Point(0, 0);
            tblRoomBillingSummary.Name = "tblRoomBillingSummary";
            tblRoomBillingSummary.Padding = new Padding(5);
            tblRoomBillingSummary.RowCount = 1;
            tblRoomBillingSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRoomBillingSummary.Size = new Size(1300, 125);
            tblRoomBillingSummary.TabIndex = 0;
            // 
            // pnlTotalPaid
            // 
            pnlTotalPaid.Controls.Add(lblTotalPaidValue);
            pnlTotalPaid.Controls.Add(lblTotalPaidTitle);
            pnlTotalPaid.Dock = DockStyle.Fill;
            pnlTotalPaid.Location = new Point(438, 8);
            pnlTotalPaid.Name = "pnlTotalPaid";
            pnlTotalPaid.Size = new Size(424, 109);
            pnlTotalPaid.TabIndex = 0;
            // 
            // lblTotalPaidValue
            // 
            lblTotalPaidValue.AutoSize = true;
            lblTotalPaidValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalPaidValue.ForeColor = Color.White;
            lblTotalPaidValue.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalPaidValue.Location = new Point(244, 42);
            lblTotalPaidValue.Margin = new Padding(0);
            lblTotalPaidValue.Name = "lblTotalPaidValue";
            lblTotalPaidValue.Size = new Size(62, 31);
            lblTotalPaidValue.TabIndex = 22;
            lblTotalPaidValue.Text = "3000";
            lblTotalPaidValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalPaidTitle
            // 
            lblTotalPaidTitle.AutoSize = true;
            lblTotalPaidTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalPaidTitle.ForeColor = Color.White;
            lblTotalPaidTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalPaidTitle.Location = new Point(103, 42);
            lblTotalPaidTitle.Margin = new Padding(0);
            lblTotalPaidTitle.Name = "lblTotalPaidTitle";
            lblTotalPaidTitle.Size = new Size(113, 31);
            lblTotalPaidTitle.TabIndex = 21;
            lblTotalPaidTitle.Text = "Total Paid";
            lblTotalPaidTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCurrentDue
            // 
            pnlCurrentDue.Controls.Add(lblCurrentDueValue);
            pnlCurrentDue.Controls.Add(lblCurrentDueTitle);
            pnlCurrentDue.Dock = DockStyle.Fill;
            pnlCurrentDue.Location = new Point(868, 8);
            pnlCurrentDue.Name = "pnlCurrentDue";
            pnlCurrentDue.Size = new Size(424, 109);
            pnlCurrentDue.TabIndex = 1;
            // 
            // lblCurrentDueValue
            // 
            lblCurrentDueValue.AutoSize = true;
            lblCurrentDueValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentDueValue.ForeColor = Color.White;
            lblCurrentDueValue.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentDueValue.Location = new Point(223, 42);
            lblCurrentDueValue.Margin = new Padding(0);
            lblCurrentDueValue.Name = "lblCurrentDueValue";
            lblCurrentDueValue.Size = new Size(62, 31);
            lblCurrentDueValue.TabIndex = 22;
            lblCurrentDueValue.Text = "6000";
            lblCurrentDueValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentDueTitle
            // 
            lblCurrentDueTitle.AutoSize = true;
            lblCurrentDueTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentDueTitle.ForeColor = Color.White;
            lblCurrentDueTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentDueTitle.Location = new Point(77, 42);
            lblCurrentDueTitle.Margin = new Padding(0);
            lblCurrentDueTitle.Name = "lblCurrentDueTitle";
            lblCurrentDueTitle.Size = new Size(137, 31);
            lblCurrentDueTitle.TabIndex = 21;
            lblCurrentDueTitle.Text = "Current Due";
            lblCurrentDueTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTotalBill
            // 
            pnlTotalBill.Controls.Add(lblTotalBillValue);
            pnlTotalBill.Controls.Add(lblTotalBillTitle);
            pnlTotalBill.Dock = DockStyle.Fill;
            pnlTotalBill.Location = new Point(8, 8);
            pnlTotalBill.Name = "pnlTotalBill";
            pnlTotalBill.Size = new Size(424, 109);
            pnlTotalBill.TabIndex = 2;
            // 
            // lblTotalBillValue
            // 
            lblTotalBillValue.AutoSize = true;
            lblTotalBillValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalBillValue.ForeColor = Color.White;
            lblTotalBillValue.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalBillValue.Location = new Point(250, 42);
            lblTotalBillValue.Margin = new Padding(0);
            lblTotalBillValue.Name = "lblTotalBillValue";
            lblTotalBillValue.Size = new Size(62, 31);
            lblTotalBillValue.TabIndex = 22;
            lblTotalBillValue.Text = "3000";
            lblTotalBillValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalBillTitle
            // 
            lblTotalBillTitle.AutoSize = true;
            lblTotalBillTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalBillTitle.ForeColor = Color.White;
            lblTotalBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalBillTitle.Location = new Point(132, 42);
            lblTotalBillTitle.Margin = new Padding(0);
            lblTotalBillTitle.Name = "lblTotalBillTitle";
            lblTotalBillTitle.Size = new Size(100, 31);
            lblTotalBillTitle.TabIndex = 21;
            lblTotalBillTitle.Text = "Total Bill";
            lblTotalBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTenantPayments
            // 
            pnlTenantPayments.Controls.Add(dgvTenantPayments);
            pnlTenantPayments.Dock = DockStyle.Fill;
            pnlTenantPayments.Location = new Point(0, 215);
            pnlTenantPayments.Name = "pnlTenantPayments";
            pnlTenantPayments.Size = new Size(1300, 535);
            pnlTenantPayments.TabIndex = 3;
            // 
            // dgvTenantPayments
            // 
            dgvTenantPayments.AllowUserToAddRows = false;
            dgvTenantPayments.AllowUserToDeleteRows = false;
            dgvTenantPayments.AllowUserToResizeRows = false;
            dgvTenantPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTenantPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTenantPayments.Columns.AddRange(new DataGridViewColumn[] { colTenantName, colShare, colPaid, colBalance, colPayment });
            dgvTenantPayments.Dock = DockStyle.Fill;
            dgvTenantPayments.Location = new Point(0, 0);
            dgvTenantPayments.MultiSelect = false;
            dgvTenantPayments.Name = "dgvTenantPayments";
            dgvTenantPayments.ReadOnly = true;
            dgvTenantPayments.RowHeadersVisible = false;
            dgvTenantPayments.RowHeadersWidth = 51;
            dgvTenantPayments.ScrollBars = ScrollBars.Vertical;
            dgvTenantPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenantPayments.Size = new Size(1300, 535);
            dgvTenantPayments.TabIndex = 0;
            // 
            // btnBackRoomBilling
            // 
            btnBackRoomBilling.Dock = DockStyle.Left;
            btnBackRoomBilling.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackRoomBilling.Location = new Point(0, 0);
            btnBackRoomBilling.Margin = new Padding(0);
            btnBackRoomBilling.Name = "btnBackRoomBilling";
            btnBackRoomBilling.Size = new Size(140, 90);
            btnBackRoomBilling.TabIndex = 1;
            btnBackRoomBilling.Text = "←";
            btnBackRoomBilling.TextAlign = ContentAlignment.TopCenter;
            btnBackRoomBilling.UseVisualStyleBackColor = true;
            btnBackRoomBilling.Click += btnBackRoomBilling_Click;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.Dock = DockStyle.Left;
            lblRoomNumber.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomNumber.Location = new Point(140, 0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(292, 90);
            lblRoomNumber.TabIndex = 6;
            lblRoomNumber.Text = "Room 202";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPeriodValue
            // 
            lblPeriodValue.Dock = DockStyle.Left;
            lblPeriodValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriodValue.ForeColor = Color.White;
            lblPeriodValue.ImageAlign = ContentAlignment.MiddleRight;
            lblPeriodValue.Location = new Point(432, 0);
            lblPeriodValue.Name = "lblPeriodValue";
            lblPeriodValue.Size = new Size(292, 90);
            lblPeriodValue.TabIndex = 7;
            lblPeriodValue.Text = "PeriodValue";
            lblPeriodValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBillStatusValue
            // 
            lblBillStatusValue.Dock = DockStyle.Left;
            lblBillStatusValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillStatusValue.ForeColor = Color.White;
            lblBillStatusValue.ImageAlign = ContentAlignment.MiddleRight;
            lblBillStatusValue.Location = new Point(724, 0);
            lblBillStatusValue.Name = "lblBillStatusValue";
            lblBillStatusValue.Size = new Size(292, 90);
            lblBillStatusValue.TabIndex = 8;
            lblBillStatusValue.Text = "BillStatusValue";
            lblBillStatusValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomBillingHeader
            // 
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
            // colTenantName
            // 
            colTenantName.HeaderText = "Tenant";
            colTenantName.MinimumWidth = 6;
            colTenantName.Name = "colTenantName";
            colTenantName.ReadOnly = true;
            // 
            // colShare
            // 
            colShare.HeaderText = "Share";
            colShare.MinimumWidth = 6;
            colShare.Name = "colShare";
            colShare.ReadOnly = true;
            // 
            // colPaid
            // 
            colPaid.HeaderText = "Paid";
            colPaid.MinimumWidth = 6;
            colPaid.Name = "colPaid";
            colPaid.ReadOnly = true;
            // 
            // colBalance
            // 
            colBalance.HeaderText = "Balance";
            colBalance.MinimumWidth = 6;
            colBalance.Name = "colBalance";
            colBalance.ReadOnly = true;
            // 
            // colPayment
            // 
            colPayment.HeaderText = "Action Payment";
            colPayment.MinimumWidth = 6;
            colPayment.Name = "colPayment";
            colPayment.ReadOnly = true;
            // 
            // BillingRoomDetailsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlTenantPayments);
            Controls.Add(pnlRoomBillingSummary);
            Controls.Add(pnlRoomBillingHeader);
            Name = "BillingRoomDetailsControl";
            Size = new Size(1300, 750);
            pnlRoomBillingSummary.ResumeLayout(false);
            tblRoomBillingSummary.ResumeLayout(false);
            pnlTotalPaid.ResumeLayout(false);
            pnlTotalPaid.PerformLayout();
            pnlCurrentDue.ResumeLayout(false);
            pnlCurrentDue.PerformLayout();
            pnlTotalBill.ResumeLayout(false);
            pnlTotalBill.PerformLayout();
            pnlTenantPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTenantPayments).EndInit();
            pnlRoomBillingHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlRoomBillingSummary;
        private Panel pnlTenantPayments;
        private TableLayoutPanel tblRoomBillingSummary;
        private Panel pnlTotalPaid;
        private Panel pnlCurrentDue;
        private Panel pnlTotalBill;
        private Label lblTotalBillTitle;
        private Label lblTotalBillValue;
        private Label lblTotalPaidValue;
        private Label lblTotalPaidTitle;
        private Label lblCurrentDueValue;
        private Label lblCurrentDueTitle;
        private DataGridView dgvTenantPayments;
        private Button btnBackRoomBilling;
        private Label lblRoomNumber;
        private Label lblPeriodValue;
        private Label lblBillStatusValue;
        private Panel pnlRoomBillingHeader;
        private DataGridViewTextBoxColumn colTenantName;
        private DataGridViewTextBoxColumn colShare;
        private DataGridViewTextBoxColumn colPaid;
        private DataGridViewTextBoxColumn colBalance;
        private DataGridViewButtonColumn colPayment;
    }
}
