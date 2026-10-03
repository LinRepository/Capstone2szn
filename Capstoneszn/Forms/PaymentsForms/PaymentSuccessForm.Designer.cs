namespace Capstoneszn.Forms
{
    partial class PaymentSuccessForm
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
            pnlPaymentSuccessHeader = new Panel();
            lblConfirmationTitle = new Label();
            lblDescription = new Label();
            pnlPaymentSuccessActions = new Panel();
            btnClose = new Button();
            btnAnotherTransaction = new Button();
            btnPrintReceipt = new Button();
            pnlPaymentSuccessContent = new Panel();
            pnlCategory = new Panel();
            lblCategoryValue = new Label();
            lblCategory = new Label();
            pnlDate = new Panel();
            lblDateValue = new Label();
            lblDate = new Label();
            pnlTransactionID = new Panel();
            lblTransactionIDValue = new Label();
            lblTransactionID = new Label();
            pnlPaymentSuccessHeader.SuspendLayout();
            pnlPaymentSuccessActions.SuspendLayout();
            pnlPaymentSuccessContent.SuspendLayout();
            pnlCategory.SuspendLayout();
            pnlDate.SuspendLayout();
            pnlTransactionID.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPaymentSuccessHeader
            // 
            pnlPaymentSuccessHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentSuccessHeader.Controls.Add(lblConfirmationTitle);
            pnlPaymentSuccessHeader.Controls.Add(lblDescription);
            pnlPaymentSuccessHeader.Dock = DockStyle.Top;
            pnlPaymentSuccessHeader.Location = new Point(0, 0);
            pnlPaymentSuccessHeader.Name = "pnlPaymentSuccessHeader";
            pnlPaymentSuccessHeader.Size = new Size(482, 60);
            pnlPaymentSuccessHeader.TabIndex = 0;
            // 
            // lblConfirmationTitle
            // 
            lblConfirmationTitle.AutoSize = true;
            lblConfirmationTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmationTitle.ForeColor = Color.White;
            lblConfirmationTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmationTitle.Location = new Point(149, 4);
            lblConfirmationTitle.Name = "lblConfirmationTitle";
            lblConfirmationTitle.Size = new Size(166, 25);
            lblConfirmationTitle.TabIndex = 5;
            lblConfirmationTitle.Text = "Payment Successful";
            lblConfirmationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.White;
            lblDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblDescription.Location = new Point(64, 28);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(368, 25);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "The payment has been recorded successfully.";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPaymentSuccessActions
            // 
            pnlPaymentSuccessActions.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentSuccessActions.Controls.Add(btnClose);
            pnlPaymentSuccessActions.Controls.Add(btnAnotherTransaction);
            pnlPaymentSuccessActions.Controls.Add(btnPrintReceipt);
            pnlPaymentSuccessActions.Dock = DockStyle.Bottom;
            pnlPaymentSuccessActions.Location = new Point(0, 323);
            pnlPaymentSuccessActions.Name = "pnlPaymentSuccessActions";
            pnlPaymentSuccessActions.Size = new Size(482, 80);
            pnlPaymentSuccessActions.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(376, 27);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnAnotherTransaction
            // 
            btnAnotherTransaction.Location = new Point(146, 27);
            btnAnotherTransaction.Name = "btnAnotherTransaction";
            btnAnotherTransaction.Size = new Size(220, 29);
            btnAnotherTransaction.TabIndex = 1;
            btnAnotherTransaction.Text = "Make Another Transaction";
            btnAnotherTransaction.UseVisualStyleBackColor = true;
            btnAnotherTransaction.Click += btnAnotherTransaction_Click;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Location = new Point(12, 27);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(125, 29);
            btnPrintReceipt.TabIndex = 0;
            btnPrintReceipt.Text = "Print Receipt";
            btnPrintReceipt.UseVisualStyleBackColor = true;
            btnPrintReceipt.Click += btnPrintReceipt_Click;
            // 
            // pnlPaymentSuccessContent
            // 
            pnlPaymentSuccessContent.Controls.Add(pnlCategory);
            pnlPaymentSuccessContent.Controls.Add(pnlDate);
            pnlPaymentSuccessContent.Controls.Add(pnlTransactionID);
            pnlPaymentSuccessContent.Dock = DockStyle.Fill;
            pnlPaymentSuccessContent.Location = new Point(0, 60);
            pnlPaymentSuccessContent.Name = "pnlPaymentSuccessContent";
            pnlPaymentSuccessContent.Size = new Size(482, 263);
            pnlPaymentSuccessContent.TabIndex = 2;
            // 
            // pnlCategory
            // 
            pnlCategory.BorderStyle = BorderStyle.FixedSingle;
            pnlCategory.Controls.Add(lblCategoryValue);
            pnlCategory.Controls.Add(lblCategory);
            pnlCategory.Dock = DockStyle.Top;
            pnlCategory.Location = new Point(0, 170);
            pnlCategory.Name = "pnlCategory";
            pnlCategory.Size = new Size(482, 85);
            pnlCategory.TabIndex = 2;
            // 
            // lblCategoryValue
            // 
            lblCategoryValue.AutoSize = true;
            lblCategoryValue.Font = new Font("Segoe UI", 13.2000008F);
            lblCategoryValue.ForeColor = Color.White;
            lblCategoryValue.ImageAlign = ContentAlignment.MiddleRight;
            lblCategoryValue.Location = new Point(193, 28);
            lblCategoryValue.Name = "lblCategoryValue";
            lblCategoryValue.Size = new Size(23, 31);
            lblCategoryValue.TabIndex = 8;
            lblCategoryValue.Text = "-";
            lblCategoryValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 13.2000008F);
            lblCategory.ForeColor = Color.White;
            lblCategory.ImageAlign = ContentAlignment.MiddleRight;
            lblCategory.Location = new Point(3, 28);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(106, 31);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Category";
            lblCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDate
            // 
            pnlDate.BorderStyle = BorderStyle.FixedSingle;
            pnlDate.Controls.Add(lblDateValue);
            pnlDate.Controls.Add(lblDate);
            pnlDate.Dock = DockStyle.Top;
            pnlDate.Location = new Point(0, 85);
            pnlDate.Name = "pnlDate";
            pnlDate.Size = new Size(482, 85);
            pnlDate.TabIndex = 1;
            // 
            // lblDateValue
            // 
            lblDateValue.AutoSize = true;
            lblDateValue.Font = new Font("Segoe UI", 13.2000008F);
            lblDateValue.ForeColor = Color.White;
            lblDateValue.ImageAlign = ContentAlignment.MiddleRight;
            lblDateValue.Location = new Point(193, 26);
            lblDateValue.Name = "lblDateValue";
            lblDateValue.Size = new Size(23, 31);
            lblDateValue.TabIndex = 8;
            lblDateValue.Text = "-";
            lblDateValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 13.2000008F);
            lblDate.ForeColor = Color.White;
            lblDate.ImageAlign = ContentAlignment.MiddleRight;
            lblDate.Location = new Point(3, 26);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(62, 31);
            lblDate.TabIndex = 6;
            lblDate.Text = "Date";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTransactionID
            // 
            pnlTransactionID.BorderStyle = BorderStyle.FixedSingle;
            pnlTransactionID.Controls.Add(lblTransactionIDValue);
            pnlTransactionID.Controls.Add(lblTransactionID);
            pnlTransactionID.Dock = DockStyle.Top;
            pnlTransactionID.Location = new Point(0, 0);
            pnlTransactionID.Name = "pnlTransactionID";
            pnlTransactionID.Size = new Size(482, 85);
            pnlTransactionID.TabIndex = 0;
            // 
            // lblTransactionIDValue
            // 
            lblTransactionIDValue.AutoSize = true;
            lblTransactionIDValue.Font = new Font("Segoe UI", 13.2000008F);
            lblTransactionIDValue.ForeColor = Color.White;
            lblTransactionIDValue.ImageAlign = ContentAlignment.MiddleRight;
            lblTransactionIDValue.Location = new Point(193, 23);
            lblTransactionIDValue.Name = "lblTransactionIDValue";
            lblTransactionIDValue.Size = new Size(23, 31);
            lblTransactionIDValue.TabIndex = 7;
            lblTransactionIDValue.Text = "-";
            lblTransactionIDValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTransactionID
            // 
            lblTransactionID.AutoSize = true;
            lblTransactionID.Font = new Font("Segoe UI", 13.2000008F);
            lblTransactionID.ForeColor = Color.White;
            lblTransactionID.ImageAlign = ContentAlignment.MiddleRight;
            lblTransactionID.Location = new Point(3, 23);
            lblTransactionID.Name = "lblTransactionID";
            lblTransactionID.Size = new Size(158, 31);
            lblTransactionID.TabIndex = 6;
            lblTransactionID.Text = "Transaction ID";
            lblTransactionID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PaymentSuccessForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 403);
            Controls.Add(pnlPaymentSuccessContent);
            Controls.Add(pnlPaymentSuccessActions);
            Controls.Add(pnlPaymentSuccessHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentSuccessForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Payment Successful";
            Load += PaymentSuccessForm_Load;
            pnlPaymentSuccessHeader.ResumeLayout(false);
            pnlPaymentSuccessHeader.PerformLayout();
            pnlPaymentSuccessActions.ResumeLayout(false);
            pnlPaymentSuccessContent.ResumeLayout(false);
            pnlCategory.ResumeLayout(false);
            pnlCategory.PerformLayout();
            pnlDate.ResumeLayout(false);
            pnlDate.PerformLayout();
            pnlTransactionID.ResumeLayout(false);
            pnlTransactionID.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPaymentSuccessHeader;
        private Panel pnlPaymentSuccessActions;
        private Panel pnlPaymentSuccessContent;
        private Label lblConfirmationTitle;
        private Label lblDescription;
        private Button btnClose;
        private Button btnAnotherTransaction;
        private Button btnPrintReceipt;
        private Panel pnlCategory;
        private Panel pnlDate;
        private Panel pnlTransactionID;
        private Label lblTransactionID;
        private Label lblCategory;
        private Label lblDate;
        private Label lblCategoryValue;
        private Label lblDateValue;
        private Label lblTransactionIDValue;
    }
}