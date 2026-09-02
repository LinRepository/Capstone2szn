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
            lblRoomNumber = new Label();
            btnBackRoomBilling = new Button();
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
            colTenantName = new DataGridViewTextBoxColumn();
            colPaid = new DataGridViewTextBoxColumn();
            colMakePayment = new DataGridViewButtonColumn();
            pnlRoomBillingHeader.SuspendLayout();
            pnlRoomBillingSummary.SuspendLayout();
            tblRoomBillingSummary.SuspendLayout();
            pnlTotalPaid.SuspendLayout();
            pnlCurrentDue.SuspendLayout();
            pnlTotalBill.SuspendLayout();
            pnlTenantPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenantPayments).BeginInit();
            SuspendLayout();
            // 
            // pnlRoomBillingHeader
            // 
            pnlRoomBillingHeader.Controls.Add(lblRoomNumber);
            pnlRoomBillingHeader.Controls.Add(btnBackRoomBilling);
            pnlRoomBillingHeader.Dock = DockStyle.Top;
            pnlRoomBillingHeader.Location = new Point(0, 0);
            pnlRoomBillingHeader.Name = "pnlRoomBillingHeader";
            pnlRoomBillingHeader.Size = new Size(1300, 90);
            pnlRoomBillingHeader.TabIndex = 0;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.Dock = DockStyle.Fill;
            lblRoomNumber.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomNumber.Location = new Point(140, 0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(1160, 90);
            lblRoomNumber.TabIndex = 6;
            lblRoomNumber.Text = "Room ###";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
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
            lblTotalPaidValue.Size = new Size(70, 31);
            lblTotalPaidValue.TabIndex = 22;
            lblTotalPaidValue.Text = "####";
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
            lblCurrentDueValue.Size = new Size(70, 31);
            lblCurrentDueValue.TabIndex = 22;
            lblCurrentDueValue.Text = "####";
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
            lblTotalBillValue.Size = new Size(70, 31);
            lblTotalBillValue.TabIndex = 22;
            lblTotalBillValue.Text = "####";
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
            dgvTenantPayments.Columns.AddRange(new DataGridViewColumn[] { colTenantName, colPaid, colMakePayment });
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
            // colTenantName
            // 
            colTenantName.HeaderText = "Tenant";
            colTenantName.MinimumWidth = 6;
            colTenantName.Name = "colTenantName";
            colTenantName.ReadOnly = true;
            // 
            // colPaid
            // 
            colPaid.HeaderText = "Paid";
            colPaid.MinimumWidth = 6;
            colPaid.Name = "colPaid";
            colPaid.ReadOnly = true;
            // 
            // colMakePayment
            // 
            colMakePayment.HeaderText = "Action";
            colMakePayment.MinimumWidth = 6;
            colMakePayment.Name = "colMakePayment";
            colMakePayment.ReadOnly = true;
            colMakePayment.Text = "Make Payment";
            colMakePayment.UseColumnTextForButtonValue = true;
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
            pnlRoomBillingHeader.ResumeLayout(false);
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
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoomBillingHeader;
        private Button btnBackRoomBilling;
        private Label lblRoomNumber;
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
        private DataGridViewTextBoxColumn colTenantName;
        private DataGridViewTextBoxColumn colPaid;
        private DataGridViewButtonColumn colMakePayment;
    }
}
