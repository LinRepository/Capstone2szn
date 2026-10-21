namespace Capstoneszn.Forms.TenantForms
{
    partial class TenantBillingForm
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
            pnlHeader = new Panel();
            lblTenantInfo = new Label();
            lblTitle = new Label();
            pnlSummary = new Panel();
            dgvSummary = new DataGridView();
            pnlSummaryHeader = new Panel();
            lblCreditNote = new Label();
            lblSummaryTitle = new Label();
            pnlFilter = new Panel();
            cboCategory = new ComboBox();
            lblFilter = new Label();
            pnlActions = new Panel();
            btnClose = new Button();
            pnlBills = new Panel();
            dgvBills = new DataGridView();
            pnlBillsHeader = new Panel();
            lblBillsTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSummary).BeginInit();
            pnlSummaryHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlActions.SuspendLayout();
            pnlBills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
            pnlBillsHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lblTenantInfo);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(980, 85);
            pnlHeader.TabIndex = 0;
            // 
            // lblTenantInfo
            // 
            lblTenantInfo.Dock = DockStyle.Fill;
            lblTenantInfo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantInfo.ForeColor = Color.White;
            lblTenantInfo.Location = new Point(0, 45);
            lblTenantInfo.Name = "lblTenantInfo";
            lblTenantInfo.Size = new Size(978, 38);
            lblTenantInfo.TabIndex = 1;
            lblTenantInfo.Text = "-";
            lblTenantInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(978, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Billing Summary";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSummary
            // 
            pnlSummary.Controls.Add(dgvSummary);
            pnlSummary.Controls.Add(pnlSummaryHeader);
            pnlSummary.Dock = DockStyle.Top;
            pnlSummary.Location = new Point(0, 85);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Padding = new Padding(10, 0, 10, 10);
            pnlSummary.Size = new Size(980, 240);
            pnlSummary.TabIndex = 1;
            // 
            // dgvSummary
            // 
            dgvSummary.AllowUserToAddRows = false;
            dgvSummary.AllowUserToDeleteRows = false;
            dgvSummary.AllowUserToResizeRows = false;
            dgvSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSummary.Dock = DockStyle.Fill;
            dgvSummary.Location = new Point(10, 45);
            dgvSummary.MultiSelect = false;
            dgvSummary.Name = "dgvSummary";
            dgvSummary.ReadOnly = true;
            dgvSummary.RowHeadersVisible = false;
            dgvSummary.RowHeadersWidth = 51;
            dgvSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSummary.Size = new Size(960, 185);
            dgvSummary.TabIndex = 1;
            // 
            // pnlSummaryHeader
            // 
            pnlSummaryHeader.Controls.Add(lblCreditNote);
            pnlSummaryHeader.Controls.Add(lblSummaryTitle);
            pnlSummaryHeader.Dock = DockStyle.Top;
            pnlSummaryHeader.Location = new Point(10, 0);
            pnlSummaryHeader.Name = "pnlSummaryHeader";
            pnlSummaryHeader.Size = new Size(960, 45);
            pnlSummaryHeader.TabIndex = 0;
            // 
            // lblCreditNote
            // 
            lblCreditNote.Dock = DockStyle.Right;
            lblCreditNote.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreditNote.ForeColor = Color.White;
            lblCreditNote.Location = new Point(510, 0);
            lblCreditNote.Name = "lblCreditNote";
            lblCreditNote.Size = new Size(450, 45);
            lblCreditNote.TabIndex = 1;
            lblCreditNote.Text = "-";
            lblCreditNote.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.Dock = DockStyle.Left;
            lblSummaryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSummaryTitle.ForeColor = Color.White;
            lblSummaryTitle.Location = new Point(0, 0);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(300, 45);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "Totals by Category";
            lblSummaryTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(cboCategory);
            pnlFilter.Controls.Add(lblFilter);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 325);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(10, 5, 10, 5);
            pnlFilter.Size = new Size(980, 55);
            pnlFilter.TabIndex = 2;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(120, 10);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(260, 33);
            cboCategory.TabIndex = 1;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            // 
            // lblFilter
            // 
            lblFilter.Dock = DockStyle.Left;
            lblFilter.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFilter.ForeColor = Color.White;
            lblFilter.Location = new Point(10, 5);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(105, 45);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Category";
            lblFilter.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnClose);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 660);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10);
            pnlActions.Size = new Size(980, 60);
            pnlActions.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Right;
            btnClose.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(830, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 40);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlBills
            // 
            pnlBills.Controls.Add(dgvBills);
            pnlBills.Controls.Add(pnlBillsHeader);
            pnlBills.Dock = DockStyle.Fill;
            pnlBills.Location = new Point(0, 380);
            pnlBills.Name = "pnlBills";
            pnlBills.Padding = new Padding(10, 0, 10, 0);
            pnlBills.Size = new Size(980, 280);
            pnlBills.TabIndex = 3;
            // 
            // dgvBills
            // 
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.AllowUserToResizeRows = false;
            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBills.Dock = DockStyle.Fill;
            dgvBills.Location = new Point(10, 40);
            dgvBills.MultiSelect = false;
            dgvBills.Name = "dgvBills";
            dgvBills.ReadOnly = true;
            dgvBills.RowHeadersVisible = false;
            dgvBills.RowHeadersWidth = 51;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.Size = new Size(960, 240);
            dgvBills.TabIndex = 1;
            dgvBills.CellFormatting += dgvBills_CellFormatting;
            // 
            // pnlBillsHeader
            // 
            pnlBillsHeader.Controls.Add(lblBillsTitle);
            pnlBillsHeader.Dock = DockStyle.Top;
            pnlBillsHeader.Location = new Point(10, 0);
            pnlBillsHeader.Name = "pnlBillsHeader";
            pnlBillsHeader.Size = new Size(960, 40);
            pnlBillsHeader.TabIndex = 0;
            // 
            // lblBillsTitle
            // 
            lblBillsTitle.Dock = DockStyle.Left;
            lblBillsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillsTitle.ForeColor = Color.White;
            lblBillsTitle.Location = new Point(0, 0);
            lblBillsTitle.Name = "lblBillsTitle";
            lblBillsTitle.Size = new Size(400, 40);
            lblBillsTitle.TabIndex = 0;
            lblBillsTitle.Text = "Bill History";
            lblBillsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TenantBillingForm
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            CancelButton = btnClose;
            ClientSize = new Size(980, 720);
            Controls.Add(pnlBills);
            Controls.Add(pnlActions);
            Controls.Add(pnlFilter);
            Controls.Add(pnlSummary);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TenantBillingForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Billing Summary";
            Load += TenantBillingForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSummary).EndInit();
            pnlSummaryHeader.ResumeLayout(false);
            pnlFilter.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            pnlBills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            pnlBillsHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblTenantInfo;
        private Panel pnlSummary;
        private Panel pnlSummaryHeader;
        private Label lblSummaryTitle;
        private Label lblCreditNote;
        private DataGridView dgvSummary;
        private Panel pnlFilter;
        private Label lblFilter;
        private ComboBox cboCategory;
        private Panel pnlBills;
        private Panel pnlBillsHeader;
        private Label lblBillsTitle;
        private DataGridView dgvBills;
        private Panel pnlActions;
        private Button btnClose;
    }
}