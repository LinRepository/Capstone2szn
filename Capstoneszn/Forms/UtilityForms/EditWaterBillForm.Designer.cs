namespace Capstoneszn.Forms.UtilityForms
{
    partial class EditWaterBillForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlEditWaterBillContent = new Panel();
            dtpDueDate = new DateTimePicker();
            dtpStartBillingPeriod = new DateTimePicker();
            label1 = new Label();
            lvlDueDate = new Label();
            label2 = new Label();
            lblTotalBIll = new Label();
            txtTotalBill = new TextBox();
            pnlEditWaterBillActionButtons = new Panel();
            btnCancel = new Button();
            btnUpdateBill = new Button();
            pnlEditWaterBillHeader = new Panel();
            lblEditWaterBillTitle = new Label();
            pnlAdminContribution = new Panel();
            lblSharePeso = new Label();
            rdoCustomAmount = new RadioButton();
            rdoDefaultShare = new RadioButton();
            lblShare = new Label();
            label3 = new Label();
            txtAdminShare = new TextBox();
            pnlTenantAllocation = new Panel();
            lblActiveTenantCount = new Label();
            lblDivideCaption = new Label();
            label6 = new Label();
            dgvWaterPreview = new DataGridView();
            colPreviewRoom = new DataGridViewTextBoxColumn();
            colPreviewTenant = new DataGridViewTextBoxColumn();
            colPreviewAmount = new DataGridViewTextBoxColumn();
            label4 = new Label();
            pnlEditWaterBillContent.SuspendLayout();
            pnlEditWaterBillActionButtons.SuspendLayout();
            pnlEditWaterBillHeader.SuspendLayout();
            pnlAdminContribution.SuspendLayout();
            pnlTenantAllocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaterPreview).BeginInit();
            SuspendLayout();
            // 
            // pnlEditWaterBillContent
            // 
            pnlEditWaterBillContent.BorderStyle = BorderStyle.FixedSingle;
            pnlEditWaterBillContent.Controls.Add(dgvWaterPreview);
            pnlEditWaterBillContent.Controls.Add(pnlTenantAllocation);
            pnlEditWaterBillContent.Controls.Add(pnlAdminContribution);
            pnlEditWaterBillContent.Controls.Add(dtpDueDate);
            pnlEditWaterBillContent.Controls.Add(dtpStartBillingPeriod);
            pnlEditWaterBillContent.Controls.Add(label1);
            pnlEditWaterBillContent.Controls.Add(lvlDueDate);
            pnlEditWaterBillContent.Controls.Add(label4);
            pnlEditWaterBillContent.Controls.Add(label2);
            pnlEditWaterBillContent.Controls.Add(lblTotalBIll);
            pnlEditWaterBillContent.Controls.Add(txtTotalBill);
            pnlEditWaterBillContent.Dock = DockStyle.Fill;
            pnlEditWaterBillContent.Location = new Point(0, 60);
            pnlEditWaterBillContent.Name = "pnlEditWaterBillContent";
            pnlEditWaterBillContent.Size = new Size(796, 591);
            pnlEditWaterBillContent.TabIndex = 5;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(280, 40);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(240, 27);
            dtpDueDate.TabIndex = 7;
            // 
            // dtpStartBillingPeriod
            // 
            dtpStartBillingPeriod.CustomFormat = "MMMM yyyy";
            dtpStartBillingPeriod.Enabled = false;
            dtpStartBillingPeriod.Format = DateTimePickerFormat.Custom;
            dtpStartBillingPeriod.Location = new Point(21, 40);
            dtpStartBillingPeriod.Name = "dtpStartBillingPeriod";
            dtpStartBillingPeriod.Size = new Size(240, 27);
            dtpStartBillingPeriod.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(537, 43);
            label1.Name = "label1";
            label1.Size = new Size(40, 46);
            label1.TabIndex = 6;
            label1.Text = "₱";
            // 
            // lvlDueDate
            // 
            lvlDueDate.AutoSize = true;
            lvlDueDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lvlDueDate.ForeColor = Color.Transparent;
            lvlDueDate.Location = new Point(280, 12);
            lvlDueDate.Name = "lvlDueDate";
            lvlDueDate.Size = new Size(86, 25);
            lvlDueDate.TabIndex = 1;
            lvlDueDate.Text = "Due Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(21, 12);
            label2.Name = "label2";
            label2.Size = new Size(117, 25);
            label2.TabIndex = 1;
            label2.Text = "Billing Month";
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
            // txtTotalBill
            // 
            txtTotalBill.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalBill.Location = new Point(537, 40);
            txtTotalBill.Name = "txtTotalBill";
            txtTotalBill.Size = new Size(240, 51);
            txtTotalBill.TabIndex = 0;
            txtTotalBill.TextAlign = HorizontalAlignment.Right;
            // 
            // pnlEditWaterBillActionButtons
            // 
            pnlEditWaterBillActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlEditWaterBillActionButtons.Controls.Add(btnCancel);
            pnlEditWaterBillActionButtons.Controls.Add(btnUpdateBill);
            pnlEditWaterBillActionButtons.Dock = DockStyle.Bottom;
            pnlEditWaterBillActionButtons.Location = new Point(0, 651);
            pnlEditWaterBillActionButtons.Name = "pnlEditWaterBillActionButtons";
            pnlEditWaterBillActionButtons.Padding = new Padding(5);
            pnlEditWaterBillActionButtons.Size = new Size(796, 56);
            pnlEditWaterBillActionButtons.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(565, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 44);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdateBill
            // 
            btnUpdateBill.AutoSize = true;
            btnUpdateBill.BackColor = Color.DeepSkyBlue;
            btnUpdateBill.Dock = DockStyle.Right;
            btnUpdateBill.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateBill.Location = new Point(659, 5);
            btnUpdateBill.Name = "btnUpdateBill";
            btnUpdateBill.Size = new Size(130, 44);
            btnUpdateBill.TabIndex = 0;
            btnUpdateBill.Text = "Update Bill";
            btnUpdateBill.UseVisualStyleBackColor = false;
            btnUpdateBill.Click += btnConfirm_Click;
            // 
            // pnlEditWaterBillHeader
            // 
            pnlEditWaterBillHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlEditWaterBillHeader.Controls.Add(lblEditWaterBillTitle);
            pnlEditWaterBillHeader.Dock = DockStyle.Top;
            pnlEditWaterBillHeader.Location = new Point(0, 0);
            pnlEditWaterBillHeader.Name = "pnlEditWaterBillHeader";
            pnlEditWaterBillHeader.Size = new Size(796, 60);
            pnlEditWaterBillHeader.TabIndex = 3;
            // 
            // lblEditWaterBillTitle
            // 
            lblEditWaterBillTitle.Dock = DockStyle.Fill;
            lblEditWaterBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditWaterBillTitle.ForeColor = Color.White;
            lblEditWaterBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblEditWaterBillTitle.Location = new Point(0, 0);
            lblEditWaterBillTitle.Name = "lblEditWaterBillTitle";
            lblEditWaterBillTitle.Size = new Size(794, 58);
            lblEditWaterBillTitle.TabIndex = 13;
            lblEditWaterBillTitle.Text = "Edit Water Bill";
            lblEditWaterBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAdminContribution
            // 
            pnlAdminContribution.BackColor = Color.FromArgb(11, 20, 50);
            pnlAdminContribution.Controls.Add(lblSharePeso);
            pnlAdminContribution.Controls.Add(rdoCustomAmount);
            pnlAdminContribution.Controls.Add(rdoDefaultShare);
            pnlAdminContribution.Controls.Add(lblShare);
            pnlAdminContribution.Controls.Add(label3);
            pnlAdminContribution.Controls.Add(txtAdminShare);
            pnlAdminContribution.Location = new Point(21, 108);
            pnlAdminContribution.Name = "pnlAdminContribution";
            pnlAdminContribution.Padding = new Padding(5);
            pnlAdminContribution.Size = new Size(462, 121);
            pnlAdminContribution.TabIndex = 6;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(8, 8);
            label3.Name = "label3";
            label3.Size = new Size(170, 25);
            label3.TabIndex = 1;
            label3.Text = "Admin Contribution";
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
            pnlTenantAllocation.TabIndex = 8;
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
            // dgvWaterPreview
            // 
            dgvWaterPreview.AllowUserToAddRows = false;
            dgvWaterPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvWaterPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvWaterPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWaterPreview.Columns.AddRange(new DataGridViewColumn[] { colPreviewRoom, colPreviewTenant, colPreviewAmount });
            dgvWaterPreview.Location = new Point(21, 270);
            dgvWaterPreview.Name = "dgvWaterPreview";
            dgvWaterPreview.ReadOnly = true;
            dgvWaterPreview.RowHeadersVisible = false;
            dgvWaterPreview.RowHeadersWidth = 51;
            dgvWaterPreview.Size = new Size(756, 306);
            dgvWaterPreview.TabIndex = 9;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(21, 242);
            label4.Name = "label4";
            label4.Size = new Size(72, 25);
            label4.TabIndex = 1;
            label4.Text = "Preview";
            // 
            // EditWaterBillForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(796, 707);
            Controls.Add(pnlEditWaterBillContent);
            Controls.Add(pnlEditWaterBillActionButtons);
            Controls.Add(pnlEditWaterBillHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditWaterBillForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Water Bill";
            Load += EditWaterBillForm_Load;
            pnlEditWaterBillContent.ResumeLayout(false);
            pnlEditWaterBillContent.PerformLayout();
            pnlEditWaterBillActionButtons.ResumeLayout(false);
            pnlEditWaterBillActionButtons.PerformLayout();
            pnlEditWaterBillHeader.ResumeLayout(false);
            pnlAdminContribution.ResumeLayout(false);
            pnlAdminContribution.PerformLayout();
            pnlTenantAllocation.ResumeLayout(false);
            pnlTenantAllocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaterPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEditWaterBillContent;
        private Label lblTotalBIll;
        private TextBox txtTotalBill;
        private Panel pnlEditWaterBillActionButtons;
        private Button btnCancel;
        private Button btnUpdateBill;
        private Panel pnlEditWaterBillHeader;
        private Label lblEditWaterBillTitle;
        private Label label1;
        private DateTimePicker dtpStartBillingPeriod;
        private DateTimePicker dtpDueDate;
        private Label label2;
        private Label lvlDueDate;
        private Panel pnlAdminContribution;
        private Label lblSharePeso;
        private RadioButton rdoCustomAmount;
        private RadioButton rdoDefaultShare;
        private Label lblShare;
        private Label label3;
        private TextBox txtAdminShare;
        private Panel pnlTenantAllocation;
        private Label lblActiveTenantCount;
        private Label lblDivideCaption;
        private Label label6;
        private DataGridView dgvWaterPreview;
        private DataGridViewTextBoxColumn colPreviewRoom;
        private DataGridViewTextBoxColumn colPreviewTenant;
        private DataGridViewTextBoxColumn colPreviewAmount;
        private Label label4;
    }
}