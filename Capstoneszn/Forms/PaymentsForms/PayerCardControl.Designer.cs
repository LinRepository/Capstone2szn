namespace Capstoneszn.Forms.PaymentsForms
{
    partial class PayerCardControl
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
            lblPayerName = new Label();
            tlpCard = new TableLayoutPanel();
            pnlDue = new Panel();
            lblDueValue = new Label();
            lblDueCaption = new Label();
            pnlMethod = new Panel();
            pnlMethodOptions = new Panel();
            rdoGCash = new RadioButton();
            rdoCash = new RadioButton();
            lblMethodCaption = new Label();
            pnlAmountPaid = new Panel();
            txtAmountPaid = new TextBox();
            lblAmountPaidCaption = new Label();
            pnlReference = new Panel();
            txtReferenceNo = new TextBox();
            lblReferenceCaption = new Label();
            pnlResult = new Panel();
            lblCovers = new Label();
            lblCredit = new Label();
            lblPaymentType = new Label();
            tlpCard.SuspendLayout();
            pnlDue.SuspendLayout();
            pnlMethod.SuspendLayout();
            pnlMethodOptions.SuspendLayout();
            pnlAmountPaid.SuspendLayout();
            pnlReference.SuspendLayout();
            pnlResult.SuspendLayout();
            SuspendLayout();
            //
            // lblPayerName
            //
            lblPayerName.Dock = DockStyle.Top;
            lblPayerName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPayerName.ForeColor = Color.White;
            lblPayerName.Location = new Point(10, 6);
            lblPayerName.Name = "lblPayerName";
            lblPayerName.Size = new Size(618, 34);
            lblPayerName.TabIndex = 0;
            lblPayerName.Text = "Payer Name";
            lblPayerName.TextAlign = ContentAlignment.MiddleLeft;
            //
            // tlpCard
            //
            tlpCard.ColumnCount = 2;
            tlpCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCard.Controls.Add(pnlDue, 0, 0);
            tlpCard.Controls.Add(pnlMethod, 1, 0);
            tlpCard.Controls.Add(pnlAmountPaid, 0, 1);
            tlpCard.Controls.Add(pnlReference, 1, 1);
            tlpCard.Dock = DockStyle.Top;
            tlpCard.Location = new Point(10, 40);
            tlpCard.Name = "tlpCard";
            tlpCard.RowCount = 2;
            tlpCard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCard.Size = new Size(618, 132);
            tlpCard.TabIndex = 1;
            //
            // pnlDue
            //
            pnlDue.Controls.Add(lblDueValue);
            pnlDue.Controls.Add(lblDueCaption);
            pnlDue.Dock = DockStyle.Fill;
            pnlDue.Name = "pnlDue";
            pnlDue.Padding = new Padding(4, 0, 12, 0);
            pnlDue.TabIndex = 0;
            //
            // lblDueValue
            //
            lblDueValue.Dock = DockStyle.Fill;
            lblDueValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblDueValue.ForeColor = Color.White;
            lblDueValue.Name = "lblDueValue";
            lblDueValue.TabIndex = 1;
            lblDueValue.Text = "₱0.00";
            lblDueValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblDueCaption
            //
            lblDueCaption.Dock = DockStyle.Top;
            lblDueCaption.Font = new Font("Segoe UI", 10.2F);
            lblDueCaption.ForeColor = Color.FromArgb(184, 198, 224);
            lblDueCaption.Name = "lblDueCaption";
            lblDueCaption.Size = new Size(293, 24);
            lblDueCaption.TabIndex = 0;
            lblDueCaption.Text = "Share due";
            //
            // pnlMethod
            //
            pnlMethod.Controls.Add(pnlMethodOptions);
            pnlMethod.Controls.Add(lblMethodCaption);
            pnlMethod.Dock = DockStyle.Fill;
            pnlMethod.Name = "pnlMethod";
            pnlMethod.Padding = new Padding(12, 0, 4, 0);
            pnlMethod.TabIndex = 1;
            //
            // pnlMethodOptions
            //
            pnlMethodOptions.Controls.Add(rdoGCash);
            pnlMethodOptions.Controls.Add(rdoCash);
            pnlMethodOptions.Dock = DockStyle.Fill;
            pnlMethodOptions.Name = "pnlMethodOptions";
            pnlMethodOptions.TabIndex = 1;
            //
            // rdoGCash
            //
            rdoGCash.AutoSize = true;
            rdoGCash.Cursor = Cursors.Hand;
            rdoGCash.Font = new Font("Segoe UI", 10.8F);
            rdoGCash.ForeColor = Color.White;
            rdoGCash.Location = new Point(110, 8);
            rdoGCash.Name = "rdoGCash";
            rdoGCash.Size = new Size(83, 29);
            rdoGCash.TabIndex = 1;
            rdoGCash.Text = "GCash";
            rdoGCash.UseVisualStyleBackColor = true;
            rdoGCash.CheckedChanged += rdoMethod_CheckedChanged;
            //
            // rdoCash
            //
            rdoCash.AutoSize = true;
            rdoCash.Checked = true;
            rdoCash.Cursor = Cursors.Hand;
            rdoCash.Font = new Font("Segoe UI", 10.8F);
            rdoCash.ForeColor = Color.White;
            rdoCash.Location = new Point(0, 8);
            rdoCash.Name = "rdoCash";
            rdoCash.Size = new Size(71, 29);
            rdoCash.TabIndex = 0;
            rdoCash.TabStop = true;
            rdoCash.Text = "Cash";
            rdoCash.UseVisualStyleBackColor = true;
            rdoCash.CheckedChanged += rdoMethod_CheckedChanged;
            //
            // lblMethodCaption
            //
            lblMethodCaption.Dock = DockStyle.Top;
            lblMethodCaption.Font = new Font("Segoe UI", 10.2F);
            lblMethodCaption.ForeColor = Color.FromArgb(184, 198, 224);
            lblMethodCaption.Name = "lblMethodCaption";
            lblMethodCaption.Size = new Size(293, 24);
            lblMethodCaption.TabIndex = 0;
            lblMethodCaption.Text = "Payment Method";
            //
            // pnlAmountPaid
            //
            pnlAmountPaid.Controls.Add(txtAmountPaid);
            pnlAmountPaid.Controls.Add(lblAmountPaidCaption);
            pnlAmountPaid.Dock = DockStyle.Fill;
            pnlAmountPaid.Name = "pnlAmountPaid";
            pnlAmountPaid.Padding = new Padding(4, 0, 12, 0);
            pnlAmountPaid.TabIndex = 2;
            //
            // txtAmountPaid
            //
            txtAmountPaid.BorderStyle = BorderStyle.FixedSingle;
            txtAmountPaid.Cursor = Cursors.IBeam;
            txtAmountPaid.Dock = DockStyle.Top;
            txtAmountPaid.Font = new Font("Segoe UI", 12F);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(293, 34);
            txtAmountPaid.TabIndex = 1;
            txtAmountPaid.TextChanged += txtAmountPaid_TextChanged;
            txtAmountPaid.KeyPress += txtAmountPaid_KeyPress;
            //
            // lblAmountPaidCaption
            //
            lblAmountPaidCaption.Dock = DockStyle.Top;
            lblAmountPaidCaption.Font = new Font("Segoe UI", 10.2F);
            lblAmountPaidCaption.ForeColor = Color.FromArgb(184, 198, 224);
            lblAmountPaidCaption.Name = "lblAmountPaidCaption";
            lblAmountPaidCaption.Size = new Size(293, 24);
            lblAmountPaidCaption.TabIndex = 0;
            lblAmountPaidCaption.Text = "Amount Paid";
            //
            // pnlReference
            //
            pnlReference.Controls.Add(txtReferenceNo);
            pnlReference.Controls.Add(lblReferenceCaption);
            pnlReference.Dock = DockStyle.Fill;
            pnlReference.Name = "pnlReference";
            pnlReference.Padding = new Padding(12, 0, 4, 0);
            pnlReference.TabIndex = 3;
            //
            // txtReferenceNo
            //
            txtReferenceNo.BorderStyle = BorderStyle.FixedSingle;
            txtReferenceNo.Cursor = Cursors.IBeam;
            txtReferenceNo.Dock = DockStyle.Top;
            txtReferenceNo.Enabled = false;
            txtReferenceNo.Font = new Font("Segoe UI", 12F);
            txtReferenceNo.MaxLength = 100;
            txtReferenceNo.Name = "txtReferenceNo";
            txtReferenceNo.PlaceholderText = "Not needed for Cash";
            txtReferenceNo.Size = new Size(293, 34);
            txtReferenceNo.TabIndex = 1;
            //
            // lblReferenceCaption
            //
            lblReferenceCaption.Dock = DockStyle.Top;
            lblReferenceCaption.Font = new Font("Segoe UI", 10.2F);
            lblReferenceCaption.ForeColor = Color.FromArgb(184, 198, 224);
            lblReferenceCaption.Name = "lblReferenceCaption";
            lblReferenceCaption.Size = new Size(293, 24);
            lblReferenceCaption.TabIndex = 0;
            lblReferenceCaption.Text = "Reference GCash Number";
            //
            // pnlResult
            //
            pnlResult.Controls.Add(lblCovers);
            pnlResult.Controls.Add(lblCredit);
            pnlResult.Controls.Add(lblPaymentType);
            pnlResult.Dock = DockStyle.Fill;
            pnlResult.Location = new Point(10, 172);
            pnlResult.Name = "pnlResult";
            pnlResult.Padding = new Padding(4, 4, 4, 0);
            pnlResult.Size = new Size(618, 36);
            pnlResult.TabIndex = 2;
            //
            // lblCovers
            //
            lblCovers.Dock = DockStyle.Fill;
            lblCovers.Font = new Font("Segoe UI", 10.2F);
            lblCovers.ForeColor = Color.White;
            lblCovers.Name = "lblCovers";
            lblCovers.TabIndex = 1;
            lblCovers.Text = "Covers until —";
            lblCovers.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblCredit
            //
            lblCredit.Dock = DockStyle.Right;
            lblCredit.Font = new Font("Segoe UI", 10.2F);
            lblCredit.ForeColor = Color.FromArgb(147, 197, 253);
            lblCredit.Name = "lblCredit";
            lblCredit.Size = new Size(180, 32);
            lblCredit.TabIndex = 2;
            lblCredit.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblPaymentType
            //
            lblPaymentType.Dock = DockStyle.Left;
            lblPaymentType.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPaymentType.ForeColor = Color.FromArgb(134, 239, 172);
            lblPaymentType.Name = "lblPaymentType";
            lblPaymentType.Size = new Size(170, 32);
            lblPaymentType.TabIndex = 0;
            lblPaymentType.Text = "Full Payment";
            lblPaymentType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // PayerCardControl
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 30, 56);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnlResult);
            Controls.Add(tlpCard);
            Controls.Add(lblPayerName);
            Margin = new Padding(0, 0, 0, 12);
            Name = "PayerCardControl";
            Padding = new Padding(10, 6, 10, 6);
            Size = new Size(640, 216);
            tlpCard.ResumeLayout(false);
            pnlDue.ResumeLayout(false);
            pnlMethod.ResumeLayout(false);
            pnlMethodOptions.ResumeLayout(false);
            pnlMethodOptions.PerformLayout();
            pnlAmountPaid.ResumeLayout(false);
            pnlAmountPaid.PerformLayout();
            pnlReference.ResumeLayout(false);
            pnlReference.PerformLayout();
            pnlResult.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblPayerName;
        private TableLayoutPanel tlpCard;
        private Panel pnlDue;
        private Label lblDueCaption;
        private Label lblDueValue;
        private Panel pnlMethod;
        private Label lblMethodCaption;
        private Panel pnlMethodOptions;
        private RadioButton rdoCash;
        private RadioButton rdoGCash;
        private Panel pnlAmountPaid;
        private Label lblAmountPaidCaption;
        private TextBox txtAmountPaid;
        private Panel pnlReference;
        private Label lblReferenceCaption;
        private TextBox txtReferenceNo;
        private Panel pnlResult;
        private Label lblPaymentType;
        private Label lblCovers;
        private Label lblCredit;
    }
}
