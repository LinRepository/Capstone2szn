namespace Capstoneszn.Forms.UtilityForms
{
    partial class AddWaterBillForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlAddBillHeader = new Panel();
            lblAddWaterBillTitle = new Label();
            pnlAddBillActionButtons = new Panel();
            btnCancel = new Button();
            btnAddBill = new Button();
            pnlAddBillContent = new Panel();
            dgvWaterPreview = new DataGridView();
            colPreviewRoom = new DataGridViewTextBoxColumn();
            colPreviewTenant = new DataGridViewTextBoxColumn();
            colPreviewAmount = new DataGridViewTextBoxColumn();
            pnlTenantAllocation = new Panel();
            lblActiveTenantCount = new Label();
            lblDivideCaption = new Label();
            label6 = new Label();
            pnlAdminContribution = new Panel();
            lblSharePeso = new Label();
            rdoCustomAmount = new RadioButton();
            rdoDefaultShare = new RadioButton();
            lblShare = new Label();
            label2 = new Label();
            txtAdminShare = new TextBox();
            dtpDueDate = new DateTimePicker();
            lblPreview = new Label();
            dtpBillingMonth = new DateTimePicker();
            lblTotalPeso = new Label();
            label4 = new Label();
            label3 = new Label();
            lblTotalBIll = new Label();
            txtTotalAmount = new TextBox();
            pnlAddBillHeader.SuspendLayout();
            pnlAddBillActionButtons.SuspendLayout();
            pnlAddBillContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaterPreview).BeginInit();
            pnlTenantAllocation.SuspendLayout();
            pnlAdminContribution.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAddBillHeader
            // 
            pnlAddBillHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBillHeader.Controls.Add(lblAddWaterBillTitle);
            pnlAddBillHeader.Dock = DockStyle.Top;
            pnlAddBillHeader.Location = new Point(0, 0);
            pnlAddBillHeader.Name = "pnlAddBillHeader";
            pnlAddBillHeader.Size = new Size(796, 60);
            pnlAddBillHeader.TabIndex = 0;
            // 
            // lblAddWaterBillTitle
            // 
            lblAddWaterBillTitle.Dock = DockStyle.Fill;
            lblAddWaterBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddWaterBillTitle.ForeColor = Color.White;
            lblAddWaterBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddWaterBillTitle.Location = new Point(0, 0);
            lblAddWaterBillTitle.Name = "lblAddWaterBillTitle";
            lblAddWaterBillTitle.Size = new Size(794, 58);
            lblAddWaterBillTitle.TabIndex = 13;
            lblAddWaterBillTitle.Text = "Add Water Bill";
            lblAddWaterBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAddBillActionButtons
            // 
            pnlAddBillActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBillActionButtons.Controls.Add(btnCancel);
            pnlAddBillActionButtons.Controls.Add(btnAddBill);
            pnlAddBillActionButtons.Dock = DockStyle.Bottom;
            pnlAddBillActionButtons.Location = new Point(0, 651);
            pnlAddBillActionButtons.Name = "pnlAddBillActionButtons";
            pnlAddBillActionButtons.Padding = new Padding(5);
            pnlAddBillActionButtons.Size = new Size(796, 56);
            pnlAddBillActionButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(565, 5);
            btnCancel.Margin = new Padding(5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 44);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAddBill
            // 
            btnAddBill.AutoSize = true;
            btnAddBill.BackColor = Color.DeepSkyBlue;
            btnAddBill.Dock = DockStyle.Right;
            btnAddBill.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddBill.Location = new Point(659, 5);
            btnAddBill.Margin = new Padding(5);
            btnAddBill.Name = "btnAddBill";
            btnAddBill.Size = new Size(130, 44);
            btnAddBill.TabIndex = 0;
            btnAddBill.Text = "Add Bill";
            btnAddBill.UseVisualStyleBackColor = false;
            btnAddBill.Click += btnConfirm_Click;
            // 
            // pnlAddBillContent
            // 
            pnlAddBillContent.AutoScroll = true;
            pnlAddBillContent.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBillContent.Controls.Add(dgvWaterPreview);
            pnlAddBillContent.Controls.Add(pnlTenantAllocation);
            pnlAddBillContent.Controls.Add(pnlAdminContribution);
            pnlAddBillContent.Controls.Add(dtpDueDate);
            pnlAddBillContent.Controls.Add(lblPreview);
            pnlAddBillContent.Controls.Add(dtpBillingMonth);
            pnlAddBillContent.Controls.Add(lblTotalPeso);
            pnlAddBillContent.Controls.Add(label4);
            pnlAddBillContent.Controls.Add(label3);
            pnlAddBillContent.Controls.Add(lblTotalBIll);
            pnlAddBillContent.Controls.Add(txtTotalAmount);
            pnlAddBillContent.Dock = DockStyle.Fill;
            pnlAddBillContent.Location = new Point(0, 60);
            pnlAddBillContent.Name = "pnlAddBillContent";
            pnlAddBillContent.Padding = new Padding(10);
            pnlAddBillContent.Size = new Size(796, 591);
            pnlAddBillContent.TabIndex = 2;
            // 
            // dgvWaterPreview
            // 
            dgvWaterPreview.AllowUserToAddRows = false;
            dgvWaterPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvWaterPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvWaterPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWaterPreview.Columns.AddRange(new DataGridViewColumn[] { colPreviewRoom, colPreviewTenant, colPreviewAmount });
            dgvWaterPreview.Location = new Point(21, 270);
            dgvWaterPreview.Name = "dgvWaterPreview";
            dgvWaterPreview.ReadOnly = true;
            dgvWaterPreview.RowHeadersVisible = false;
            dgvWaterPreview.RowHeadersWidth = 51;
            dgvWaterPreview.Size = new Size(756, 306);
            dgvWaterPreview.TabIndex = 6;
            // 
            // colPreviewRoom
            // 
            colPreviewRoom.FillWeight = 20F;
            colPreviewRoom.HeaderText = "Room";
            colPreviewRoom.MinimumWidth = 6;
            colPreviewRoom.Name = "colPreviewRoom";
            colPreviewRoom.ReadOnly = true;
            // 
            // colPreviewTenant
            // 
            colPreviewTenant.HeaderText = "Tenant";
            colPreviewTenant.MinimumWidth = 6;
            colPreviewTenant.Name = "colPreviewTenant";
            colPreviewTenant.ReadOnly = true;
            // 
            // colPreviewAmount
            // 
            colPreviewAmount.FillWeight = 50F;
            colPreviewAmount.HeaderText = "Amount";
            colPreviewAmount.MinimumWidth = 6;
            colPreviewAmount.Name = "colPreviewAmount";
            colPreviewAmount.ReadOnly = true;
            // 
            // pnlTenantAllocation
            // 
            pnlTenantAllocation.BackColor = Color.FromArgb(11, 20, 50);
            pnlTenantAllocation.Controls.Add(lblActiveTenantCount);
            pnlTenantAllocation.Controls.Add(lblDivideCaption);
            pnlTenantAllocation.Controls.Add(label6);
            pnlTenantAllocation.Location = new Point(505, 108);
            pnlTenantAllocation.Name = "pnlTenantAllocation";
            pnlTenantAllocation.Padding = new Padding(5);
            pnlTenantAllocation.Size = new Size(272, 121);
            pnlTenantAllocation.TabIndex = 5;
            // 
            // lblActiveTenantCount
            // 
            lblActiveTenantCount.AutoSize = true;
            lblActiveTenantCount.BorderStyle = BorderStyle.Fixed3D;
            lblActiveTenantCount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblActiveTenantCount.ForeColor = Color.Transparent;
            lblActiveTenantCount.Location = new Point(208, 54);
            lblActiveTenantCount.Name = "lblActiveTenantCount";
            lblActiveTenantCount.Size = new Size(37, 48);
            lblActiveTenantCount.TabIndex = 1;
            lblActiveTenantCount.Text = "?";
            // 
            // lblDivideCaption
            // 
            lblDivideCaption.AutoSize = true;
            lblDivideCaption.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDivideCaption.ForeColor = Color.Transparent;
            lblDivideCaption.Location = new Point(8, 67);
            lblDivideCaption.Name = "lblDivideCaption";
            lblDivideCaption.Size = new Size(194, 20);
            lblDivideCaption.TabIndex = 1;
            lblDivideCaption.Text = "Divide by all activie tenants:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(8, 8);
            label6.Name = "label6";
            label6.Size = new Size(147, 25);
            label6.TabIndex = 1;
            label6.Text = "Tenant Allocation";
            // 
            // pnlAdminContribution
            // 
            pnlAdminContribution.BackColor = Color.FromArgb(11, 20, 50);
            pnlAdminContribution.Controls.Add(lblSharePeso);
            pnlAdminContribution.Controls.Add(rdoCustomAmount);
            pnlAdminContribution.Controls.Add(rdoDefaultShare);
            pnlAdminContribution.Controls.Add(lblShare);
            pnlAdminContribution.Controls.Add(label2);
            pnlAdminContribution.Controls.Add(txtAdminShare);
            pnlAdminContribution.Location = new Point(21, 108);
            pnlAdminContribution.Name = "pnlAdminContribution";
            pnlAdminContribution.Padding = new Padding(5);
            pnlAdminContribution.Size = new Size(462, 121);
            pnlAdminContribution.TabIndex = 4;
            // 
            // lblSharePeso
            // 
            lblSharePeso.AutoSize = true;
            lblSharePeso.BackColor = Color.White;
            lblSharePeso.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSharePeso.Location = new Point(89, 72);
            lblSharePeso.Name = "lblSharePeso";
            lblSharePeso.Size = new Size(28, 31);
            lblSharePeso.TabIndex = 2;
            lblSharePeso.Text = "₱";
            // 
            // rdoCustomAmount
            // 
            rdoCustomAmount.Appearance = Appearance.Button;
            rdoCustomAmount.AutoSize = true;
            rdoCustomAmount.BackColor = Color.White;
            rdoCustomAmount.FlatStyle = FlatStyle.Flat;
            rdoCustomAmount.Location = new Point(326, 8);
            rdoCustomAmount.Name = "rdoCustomAmount";
            rdoCustomAmount.Size = new Size(128, 32);
            rdoCustomAmount.TabIndex = 2;
            rdoCustomAmount.TabStop = true;
            rdoCustomAmount.Text = "Custom Amount";
            rdoCustomAmount.UseVisualStyleBackColor = false;
            // 
            // rdoDefaultShare
            // 
            rdoDefaultShare.Appearance = Appearance.Button;
            rdoDefaultShare.AutoSize = true;
            rdoDefaultShare.BackColor = Color.White;
            rdoDefaultShare.FlatStyle = FlatStyle.Flat;
            rdoDefaultShare.Location = new Point(211, 8);
            rdoDefaultShare.Name = "rdoDefaultShare";
            rdoDefaultShare.Size = new Size(109, 32);
            rdoDefaultShare.TabIndex = 2;
            rdoDefaultShare.TabStop = true;
            rdoDefaultShare.Text = "Default share";
            rdoDefaultShare.UseVisualStyleBackColor = false;
            // 
            // lblShare
            // 
            lblShare.AutoSize = true;
            lblShare.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShare.ForeColor = Color.Transparent;
            lblShare.Location = new Point(8, 77);
            lblShare.Name = "lblShare";
            lblShare.Size = new Size(60, 25);
            lblShare.TabIndex = 1;
            lblShare.Text = "Share:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(8, 8);
            label2.Name = "label2";
            label2.Size = new Size(170, 25);
            label2.TabIndex = 1;
            label2.Text = "Admin Contribution";
            // 
            // txtAdminShare
            // 
            txtAdminShare.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdminShare.Location = new Point(80, 71);
            txtAdminShare.Name = "txtAdminShare";
            txtAdminShare.Size = new Size(374, 34);
            txtAdminShare.TabIndex = 0;
            txtAdminShare.TextAlign = HorizontalAlignment.Right;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(280, 40);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(240, 27);
            dtpDueDate.TabIndex = 3;
            // 
            // lblPreview
            // 
            lblPreview.AutoSize = true;
            lblPreview.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPreview.ForeColor = Color.Transparent;
            lblPreview.Location = new Point(21, 242);
            lblPreview.Name = "lblPreview";
            lblPreview.Size = new Size(72, 25);
            lblPreview.TabIndex = 1;
            lblPreview.Text = "Preview";
            // 
            // dtpBillingMonth
            // 
            dtpBillingMonth.CustomFormat = "MMMM yyyy";
            dtpBillingMonth.Format = DateTimePickerFormat.Custom;
            dtpBillingMonth.Location = new Point(21, 40);
            dtpBillingMonth.Name = "dtpBillingMonth";
            dtpBillingMonth.Size = new Size(240, 27);
            dtpBillingMonth.TabIndex = 3;
            // 
            // lblTotalPeso
            // 
            lblTotalPeso.AutoSize = true;
            lblTotalPeso.BackColor = Color.White;
            lblTotalPeso.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalPeso.Location = new Point(537, 43);
            lblTotalPeso.Name = "lblTotalPeso";
            lblTotalPeso.Size = new Size(40, 46);
            lblTotalPeso.TabIndex = 2;
            lblTotalPeso.Text = "₱";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(280, 12);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 1;
            label4.Text = "Due Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(21, 12);
            label3.Name = "label3";
            label3.Size = new Size(117, 25);
            label3.TabIndex = 1;
            label3.Text = "Billing Month";
            // 
            // lblTotalBIll
            // 
            lblTotalBIll.AutoSize = true;
            lblTotalBIll.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalBIll.ForeColor = Color.Transparent;
            lblTotalBIll.Location = new Point(537, 12);
            lblTotalBIll.Name = "lblTotalBIll";
            lblTotalBIll.Size = new Size(146, 25);
            lblTotalBIll.TabIndex = 1;
            lblTotalBIll.Text = "Total Bill Amount";
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalAmount.Location = new Point(537, 40);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.Size = new Size(240, 51);
            txtTotalAmount.TabIndex = 0;
            txtTotalAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // AddWaterBillForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(796, 707);
            Controls.Add(pnlAddBillContent);
            Controls.Add(pnlAddBillActionButtons);
            Controls.Add(pnlAddBillHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddWaterBillForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Water Bill";
            Load += AddWaterBillForm_Load;
            pnlAddBillHeader.ResumeLayout(false);
            pnlAddBillActionButtons.ResumeLayout(false);
            pnlAddBillActionButtons.PerformLayout();
            pnlAddBillContent.ResumeLayout(false);
            pnlAddBillContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaterPreview).EndInit();
            pnlTenantAllocation.ResumeLayout(false);
            pnlTenantAllocation.PerformLayout();
            pnlAdminContribution.ResumeLayout(false);
            pnlAdminContribution.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAddBillHeader;
        private Panel pnlAddBillActionButtons;
        private Panel pnlAddBillContent;
        private Label lblAddWaterBillTitle;
        private Button btnCancel;
        private Button btnAddBill;
        private Label lblTotalBIll;
        private TextBox txtTotalAmount;
        private DateTimePicker dtpDueDate;
        private DateTimePicker dtpBillingMonth;
        private Label lblTotalPeso;
        private Label label4;
        private Label label3;
        private Panel pnlAdminContribution;
        private RadioButton rdoDefaultShare;
        private Label label2;
        private RadioButton rdoCustomAmount;
        private Label lblShare;
        private TextBox txtAdminShare;
        private Panel pnlTenantAllocation;
        private Label lblActiveTenantCount;
        private Label label6;
        private Label lblDivideCaption;
        private DataGridView dgvWaterPreview;
        private Label lblSharePeso;
        private Label lblPreview;
        private DataGridViewTextBoxColumn colPreviewRoom;
        private DataGridViewTextBoxColumn colPreviewTenant;
        private DataGridViewTextBoxColumn colPreviewAmount;
    }
}