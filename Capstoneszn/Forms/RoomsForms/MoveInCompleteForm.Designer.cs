namespace Capstoneszn.Forms.RoomsForms
{
    partial class MoveInCompleteForm
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
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvReceiptNoStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvAmountStyle = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblCompleteSubtitle = new Label();
            lblCompleteTitle = new Label();
            lblCheck = new Label();
            pnlStrip = new Panel();
            tlpStrip = new TableLayoutPanel();
            lblTotalCaption = new Label();
            lblDateCaption = new Label();
            lblNextDueCaption = new Label();
            lblTotalValue = new Label();
            lblDateValue = new Label();
            lblNextDueValue = new Label();
            pnlBody = new Panel();
            dgvReceipts = new DataGridView();
            colReceiptNo = new DataGridViewTextBoxColumn();
            colPayer = new DataGridViewTextBoxColumn();
            colMethod = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colView = new DataGridViewButtonColumn();
            lblReceiptsTitle = new Label();
            lblHint = new Label();
            pnlActions = new Panel();
            btnClose = new Button();
            pnlHeader.SuspendLayout();
            pnlStrip.SuspendLayout();
            tlpStrip.SuspendLayout();
            pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceipts).BeginInit();
            pnlActions.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lblCompleteSubtitle);
            pnlHeader.Controls.Add(lblCompleteTitle);
            pnlHeader.Controls.Add(lblCheck);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(16, 10, 16, 6);
            pnlHeader.Size = new Size(760, 136);
            pnlHeader.TabIndex = 0;
            //
            // lblCompleteSubtitle
            //
            lblCompleteSubtitle.Dock = DockStyle.Fill;
            lblCompleteSubtitle.Font = new Font("Segoe UI", 10.8F);
            lblCompleteSubtitle.ForeColor = Color.FromArgb(201, 204, 242);
            lblCompleteSubtitle.Location = new Point(16, 98);
            lblCompleteSubtitle.Name = "lblCompleteSubtitle";
            lblCompleteSubtitle.Size = new Size(726, 30);
            lblCompleteSubtitle.TabIndex = 2;
            lblCompleteSubtitle.Text = "Room ### · 0 moved in · 0 payments recorded";
            lblCompleteSubtitle.TextAlign = ContentAlignment.TopCenter;
            //
            // lblCompleteTitle
            //
            lblCompleteTitle.Dock = DockStyle.Top;
            lblCompleteTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCompleteTitle.ForeColor = Color.White;
            lblCompleteTitle.Location = new Point(16, 60);
            lblCompleteTitle.Name = "lblCompleteTitle";
            lblCompleteTitle.Size = new Size(726, 38);
            lblCompleteTitle.TabIndex = 1;
            lblCompleteTitle.Text = "Move-In Complete";
            lblCompleteTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblCheck
            //
            lblCheck.Dock = DockStyle.Top;
            lblCheck.Font = new Font("Segoe UI Symbol", 25.8F);
            lblCheck.ForeColor = Color.FromArgb(134, 239, 172);
            lblCheck.Location = new Point(16, 10);
            lblCheck.Name = "lblCheck";
            lblCheck.Size = new Size(726, 50);
            lblCheck.TabIndex = 0;
            lblCheck.Text = "✔";
            lblCheck.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlStrip
            //
            pnlStrip.BorderStyle = BorderStyle.FixedSingle;
            pnlStrip.Controls.Add(tlpStrip);
            pnlStrip.Dock = DockStyle.Top;
            pnlStrip.Location = new Point(0, 136);
            pnlStrip.Name = "pnlStrip";
            pnlStrip.Padding = new Padding(16, 6, 16, 6);
            pnlStrip.Size = new Size(760, 70);
            pnlStrip.TabIndex = 1;
            //
            // tlpStrip
            //
            tlpStrip.ColumnCount = 3;
            tlpStrip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tlpStrip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tlpStrip.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tlpStrip.Controls.Add(lblTotalCaption, 0, 0);
            tlpStrip.Controls.Add(lblDateCaption, 1, 0);
            tlpStrip.Controls.Add(lblNextDueCaption, 2, 0);
            tlpStrip.Controls.Add(lblTotalValue, 0, 1);
            tlpStrip.Controls.Add(lblDateValue, 1, 1);
            tlpStrip.Controls.Add(lblNextDueValue, 2, 1);
            tlpStrip.Dock = DockStyle.Fill;
            tlpStrip.Location = new Point(16, 6);
            tlpStrip.Name = "tlpStrip";
            tlpStrip.RowCount = 2;
            tlpStrip.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
            tlpStrip.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
            tlpStrip.Size = new Size(726, 56);
            tlpStrip.TabIndex = 0;
            //
            // lblTotalCaption
            //
            lblTotalCaption.Dock = DockStyle.Fill;
            lblTotalCaption.Font = new Font("Segoe UI", 9F);
            lblTotalCaption.ForeColor = Color.FromArgb(201, 204, 242);
            lblTotalCaption.Name = "lblTotalCaption";
            lblTotalCaption.TabIndex = 0;
            lblTotalCaption.Text = "Total recorded";
            lblTotalCaption.TextAlign = ContentAlignment.BottomLeft;
            //
            // lblDateCaption
            //
            lblDateCaption.Dock = DockStyle.Fill;
            lblDateCaption.Font = new Font("Segoe UI", 9F);
            lblDateCaption.ForeColor = Color.FromArgb(201, 204, 242);
            lblDateCaption.Name = "lblDateCaption";
            lblDateCaption.TabIndex = 1;
            lblDateCaption.Text = "Date";
            lblDateCaption.TextAlign = ContentAlignment.BottomLeft;
            //
            // lblNextDueCaption
            //
            lblNextDueCaption.Dock = DockStyle.Fill;
            lblNextDueCaption.Font = new Font("Segoe UI", 9F);
            lblNextDueCaption.ForeColor = Color.FromArgb(201, 204, 242);
            lblNextDueCaption.Name = "lblNextDueCaption";
            lblNextDueCaption.TabIndex = 2;
            lblNextDueCaption.Text = "Next rent due";
            lblNextDueCaption.TextAlign = ContentAlignment.BottomLeft;
            //
            // lblTotalValue
            //
            lblTotalValue.Dock = DockStyle.Fill;
            lblTotalValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.White;
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.TabIndex = 3;
            lblTotalValue.Text = "₱0.00";
            lblTotalValue.TextAlign = ContentAlignment.TopLeft;
            //
            // lblDateValue
            //
            lblDateValue.Dock = DockStyle.Fill;
            lblDateValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDateValue.ForeColor = Color.White;
            lblDateValue.Name = "lblDateValue";
            lblDateValue.TabIndex = 4;
            lblDateValue.Text = "-";
            lblDateValue.TextAlign = ContentAlignment.TopLeft;
            //
            // lblNextDueValue
            //
            lblNextDueValue.Dock = DockStyle.Fill;
            lblNextDueValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNextDueValue.ForeColor = Color.White;
            lblNextDueValue.Name = "lblNextDueValue";
            lblNextDueValue.TabIndex = 5;
            lblNextDueValue.Text = "-";
            lblNextDueValue.TextAlign = ContentAlignment.TopLeft;
            //
            // pnlBody
            //
            pnlBody.Controls.Add(dgvReceipts);
            pnlBody.Controls.Add(lblReceiptsTitle);
            pnlBody.Controls.Add(lblHint);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 206);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(16, 6, 16, 6);
            pnlBody.Size = new Size(760, 338);
            pnlBody.TabIndex = 2;
            //
            // dgvReceipts
            //
            dgvReceipts.AllowUserToAddRows = false;
            dgvReceipts.AllowUserToDeleteRows = false;
            dgvReceipts.AllowUserToResizeRows = false;
            dgvReceipts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceipts.BackgroundColor = Color.FromArgb(25, 25, 70);
            dgvReceipts.BorderStyle = BorderStyle.FixedSingle;
            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(35, 37, 106);
            dgvHeaderStyle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.White;
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(35, 37, 106);
            dgvHeaderStyle.SelectionForeColor = Color.White;
            dgvHeaderStyle.WrapMode = DataGridViewTriState.False;
            dgvReceipts.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvReceipts.ColumnHeadersHeight = 36;
            dgvReceipts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReceipts.Columns.AddRange(new DataGridViewColumn[] { colReceiptNo, colPayer, colMethod, colAmount, colView });
            dgvCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle.BackColor = Color.FromArgb(25, 25, 70);
            dgvCellStyle.Font = new Font("Segoe UI", 10.2F);
            dgvCellStyle.ForeColor = Color.White;
            dgvCellStyle.SelectionBackColor = Color.FromArgb(25, 25, 70);
            dgvCellStyle.SelectionForeColor = Color.White;
            dgvCellStyle.WrapMode = DataGridViewTriState.False;
            dgvReceipts.DefaultCellStyle = dgvCellStyle;
            dgvReceipts.Dock = DockStyle.Fill;
            dgvReceipts.EnableHeadersVisualStyles = false;
            dgvReceipts.GridColor = Color.FromArgb(52, 56, 143);
            dgvReceipts.Location = new Point(16, 40);
            dgvReceipts.MultiSelect = false;
            dgvReceipts.Name = "dgvReceipts";
            dgvReceipts.ReadOnly = true;
            dgvReceipts.RowHeadersVisible = false;
            dgvReceipts.RowHeadersWidth = 51;
            dgvReceipts.RowTemplate.Height = 40;
            dgvReceipts.ScrollBars = ScrollBars.Vertical;
            dgvReceipts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReceipts.Size = new Size(728, 248);
            dgvReceipts.TabIndex = 1;
            dgvReceipts.CellContentClick += dgvReceipts_CellContentClick;
            //
            // colReceiptNo
            //
            dgvReceiptNoStyle.Font = new Font("Consolas", 10.2F);
            colReceiptNo.DefaultCellStyle = dgvReceiptNoStyle;
            colReceiptNo.FillWeight = 26F;
            colReceiptNo.HeaderText = "Receipt No.";
            colReceiptNo.MinimumWidth = 6;
            colReceiptNo.Name = "colReceiptNo";
            colReceiptNo.ReadOnly = true;
            //
            // colPayer
            //
            colPayer.FillWeight = 32F;
            colPayer.HeaderText = "Payer";
            colPayer.MinimumWidth = 6;
            colPayer.Name = "colPayer";
            colPayer.ReadOnly = true;
            //
            // colMethod
            //
            colMethod.FillWeight = 12F;
            colMethod.HeaderText = "Method";
            colMethod.MinimumWidth = 6;
            colMethod.Name = "colMethod";
            colMethod.ReadOnly = true;
            //
            // colAmount
            //
            dgvAmountStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAmountStyle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            colAmount.DefaultCellStyle = dgvAmountStyle;
            colAmount.FillWeight = 14F;
            colAmount.HeaderText = "Amount";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;
            //
            // colView
            //
            colView.FillWeight = 16F;
            colView.FlatStyle = FlatStyle.Flat;
            colView.HeaderText = "";
            colView.MinimumWidth = 6;
            colView.Name = "colView";
            colView.ReadOnly = true;
            colView.Text = "View / Print";
            colView.ToolTipText = "Open this receipt";
            colView.UseColumnTextForButtonValue = true;
            //
            // lblReceiptsTitle
            //
            lblReceiptsTitle.Dock = DockStyle.Top;
            lblReceiptsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblReceiptsTitle.ForeColor = Color.White;
            lblReceiptsTitle.Location = new Point(16, 6);
            lblReceiptsTitle.Name = "lblReceiptsTitle";
            lblReceiptsTitle.Size = new Size(728, 34);
            lblReceiptsTitle.TabIndex = 0;
            lblReceiptsTitle.Text = "Receipts";
            lblReceiptsTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblHint
            //
            lblHint.Dock = DockStyle.Bottom;
            lblHint.Font = new Font("Segoe UI", 9.6F);
            lblHint.ForeColor = Color.FromArgb(201, 204, 242);
            lblHint.Location = new Point(16, 288);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(728, 44);
            lblHint.TabIndex = 2;
            lblHint.Text = "View / Print opens the receipt. Receipts can also be reprinted later from Payment History.";
            lblHint.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlActions
            //
            pnlActions.BorderStyle = BorderStyle.FixedSingle;
            pnlActions.Controls.Add(btnClose);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 544);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(760, 56);
            pnlActions.TabIndex = 3;
            //
            // btnClose
            //
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnClose.Location = new Point(616, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(128, 36);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            //
            // MoveInCompleteForm
            //
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(760, 600);
            Controls.Add(pnlBody);
            Controls.Add(pnlActions);
            Controls.Add(pnlStrip);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveInCompleteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Move-In Complete";
            pnlHeader.ResumeLayout(false);
            pnlStrip.ResumeLayout(false);
            tlpStrip.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReceipts).EndInit();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblCheck;
        private Label lblCompleteTitle;
        private Label lblCompleteSubtitle;
        private Panel pnlStrip;
        private TableLayoutPanel tlpStrip;
        private Label lblTotalCaption;
        private Label lblDateCaption;
        private Label lblNextDueCaption;
        private Label lblTotalValue;
        private Label lblDateValue;
        private Label lblNextDueValue;
        private Panel pnlBody;
        private Label lblReceiptsTitle;
        private DataGridView dgvReceipts;
        private DataGridViewTextBoxColumn colReceiptNo;
        private DataGridViewTextBoxColumn colPayer;
        private DataGridViewTextBoxColumn colMethod;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewButtonColumn colView;
        private Label lblHint;
        private Panel pnlActions;
        private Button btnClose;
    }
}