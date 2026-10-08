namespace Capstoneszn.Forms
{
    partial class ConfirmPaymentForm
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
            pnlPaymentDetails = new Panel();
            tblPaymentDetails = new TableLayoutPanel();
            lblConfirmCategoryValue = new Label();
            lblConfirmCategoryTitle = new Label();
            lblConfirmDateValue = new Label();
            lblConfirmDateTitle = new Label();
            lblConfirmReferenceTitle = new Label();
            lblConfirmReferenceValue = new Label();
            lblConfirmAmountTitle = new Label();
            lblConfirmAmountValue = new Label();
            lblConfirmPaymentTypeTitle = new Label();
            lblConfirmPaymentMethodTitle = new Label();
            lblConfirmPaymentMethodValue = new Label();
            lblConfirmPaymentTypeValue = new Label();
            pnlPaymentHeader = new Panel();
            lblPaymentSummary = new Label();
            lblConfirmationTitle = new Label();
            panel2 = new Panel();
            btnConfirmPayment = new Button();
            btnCancelPayment = new Button();
            pnlPaymentDetails.SuspendLayout();
            tblPaymentDetails.SuspendLayout();
            pnlPaymentHeader.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPaymentDetails
            // 
            pnlPaymentDetails.Controls.Add(tblPaymentDetails);
            pnlPaymentDetails.Dock = DockStyle.Fill;
            pnlPaymentDetails.Location = new Point(0, 65);
            pnlPaymentDetails.Name = "pnlPaymentDetails";
            pnlPaymentDetails.Size = new Size(482, 338);
            pnlPaymentDetails.TabIndex = 0;
            // 
            // tblPaymentDetails
            // 
            tblPaymentDetails.ColumnCount = 2;
            tblPaymentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPaymentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPaymentDetails.Controls.Add(lblConfirmCategoryValue, 1, 1);
            tblPaymentDetails.Controls.Add(lblConfirmCategoryTitle, 0, 1);
            tblPaymentDetails.Controls.Add(lblConfirmDateValue, 1, 0);
            tblPaymentDetails.Controls.Add(lblConfirmDateTitle, 0, 0);
            tblPaymentDetails.Controls.Add(lblConfirmReferenceTitle, 0, 4);
            tblPaymentDetails.Controls.Add(lblConfirmReferenceValue, 1, 4);
            tblPaymentDetails.Controls.Add(lblConfirmAmountTitle, 0, 5);
            tblPaymentDetails.Controls.Add(lblConfirmAmountValue, 1, 5);
            tblPaymentDetails.Controls.Add(lblConfirmPaymentTypeTitle, 0, 2);
            tblPaymentDetails.Controls.Add(lblConfirmPaymentMethodTitle, 0, 3);
            tblPaymentDetails.Controls.Add(lblConfirmPaymentMethodValue, 1, 3);
            tblPaymentDetails.Controls.Add(lblConfirmPaymentTypeValue, 1, 2);
            tblPaymentDetails.Dock = DockStyle.Fill;
            tblPaymentDetails.Location = new Point(0, 0);
            tblPaymentDetails.Name = "tblPaymentDetails";
            tblPaymentDetails.RowCount = 6;
            tblPaymentDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblPaymentDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblPaymentDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblPaymentDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblPaymentDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblPaymentDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblPaymentDetails.Size = new Size(482, 338);
            tblPaymentDetails.TabIndex = 1;
            // 
            // lblConfirmCategoryValue
            // 
            lblConfirmCategoryValue.AutoSize = true;
            lblConfirmCategoryValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmCategoryValue.ForeColor = Color.White;
            lblConfirmCategoryValue.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmCategoryValue.Location = new Point(244, 56);
            lblConfirmCategoryValue.Name = "lblConfirmCategoryValue";
            lblConfirmCategoryValue.Size = new Size(19, 25);
            lblConfirmCategoryValue.TabIndex = 8;
            lblConfirmCategoryValue.Text = "-";
            lblConfirmCategoryValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmCategoryTitle
            // 
            lblConfirmCategoryTitle.AutoSize = true;
            lblConfirmCategoryTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmCategoryTitle.ForeColor = Color.White;
            lblConfirmCategoryTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmCategoryTitle.Location = new Point(3, 56);
            lblConfirmCategoryTitle.Name = "lblConfirmCategoryTitle";
            lblConfirmCategoryTitle.Size = new Size(84, 25);
            lblConfirmCategoryTitle.TabIndex = 7;
            lblConfirmCategoryTitle.Text = "Category";
            lblConfirmCategoryTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmDateValue
            // 
            lblConfirmDateValue.AutoSize = true;
            lblConfirmDateValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmDateValue.ForeColor = Color.White;
            lblConfirmDateValue.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmDateValue.Location = new Point(244, 0);
            lblConfirmDateValue.Name = "lblConfirmDateValue";
            lblConfirmDateValue.Size = new Size(19, 25);
            lblConfirmDateValue.TabIndex = 6;
            lblConfirmDateValue.Text = "-";
            lblConfirmDateValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmDateTitle
            // 
            lblConfirmDateTitle.AutoSize = true;
            lblConfirmDateTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmDateTitle.ForeColor = Color.White;
            lblConfirmDateTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmDateTitle.Location = new Point(3, 0);
            lblConfirmDateTitle.Name = "lblConfirmDateTitle";
            lblConfirmDateTitle.Size = new Size(49, 25);
            lblConfirmDateTitle.TabIndex = 5;
            lblConfirmDateTitle.Text = "Date";
            lblConfirmDateTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmReferenceTitle
            // 
            lblConfirmReferenceTitle.AutoSize = true;
            lblConfirmReferenceTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmReferenceTitle.ForeColor = Color.White;
            lblConfirmReferenceTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmReferenceTitle.Location = new Point(3, 224);
            lblConfirmReferenceTitle.Name = "lblConfirmReferenceTitle";
            lblConfirmReferenceTitle.Size = new Size(158, 25);
            lblConfirmReferenceTitle.TabIndex = 13;
            lblConfirmReferenceTitle.Text = "Reference Number";
            lblConfirmReferenceTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmReferenceValue
            // 
            lblConfirmReferenceValue.AutoSize = true;
            lblConfirmReferenceValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmReferenceValue.ForeColor = Color.White;
            lblConfirmReferenceValue.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmReferenceValue.Location = new Point(244, 224);
            lblConfirmReferenceValue.Name = "lblConfirmReferenceValue";
            lblConfirmReferenceValue.Size = new Size(19, 25);
            lblConfirmReferenceValue.TabIndex = 14;
            lblConfirmReferenceValue.Text = "-";
            lblConfirmReferenceValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmAmountTitle
            // 
            lblConfirmAmountTitle.AutoSize = true;
            lblConfirmAmountTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmAmountTitle.ForeColor = Color.White;
            lblConfirmAmountTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmAmountTitle.Location = new Point(3, 280);
            lblConfirmAmountTitle.Name = "lblConfirmAmountTitle";
            lblConfirmAmountTitle.Size = new Size(77, 25);
            lblConfirmAmountTitle.TabIndex = 11;
            lblConfirmAmountTitle.Text = "Amount";
            lblConfirmAmountTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmAmountValue
            // 
            lblConfirmAmountValue.AutoSize = true;
            lblConfirmAmountValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmAmountValue.ForeColor = Color.White;
            lblConfirmAmountValue.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmAmountValue.Location = new Point(244, 280);
            lblConfirmAmountValue.Name = "lblConfirmAmountValue";
            lblConfirmAmountValue.Size = new Size(57, 25);
            lblConfirmAmountValue.TabIndex = 12;
            lblConfirmAmountValue.Text = "₱0.00";
            lblConfirmAmountValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmPaymentTypeTitle
            // 
            lblConfirmPaymentTypeTitle.AutoSize = true;
            lblConfirmPaymentTypeTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmPaymentTypeTitle.ForeColor = Color.White;
            lblConfirmPaymentTypeTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmPaymentTypeTitle.Location = new Point(3, 112);
            lblConfirmPaymentTypeTitle.Name = "lblConfirmPaymentTypeTitle";
            lblConfirmPaymentTypeTitle.Size = new Size(122, 25);
            lblConfirmPaymentTypeTitle.TabIndex = 15;
            lblConfirmPaymentTypeTitle.Text = "Payment Type";
            lblConfirmPaymentTypeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmPaymentMethodTitle
            // 
            lblConfirmPaymentMethodTitle.AutoSize = true;
            lblConfirmPaymentMethodTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmPaymentMethodTitle.ForeColor = Color.White;
            lblConfirmPaymentMethodTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmPaymentMethodTitle.Location = new Point(3, 168);
            lblConfirmPaymentMethodTitle.Name = "lblConfirmPaymentMethodTitle";
            lblConfirmPaymentMethodTitle.Size = new Size(148, 25);
            lblConfirmPaymentMethodTitle.TabIndex = 9;
            lblConfirmPaymentMethodTitle.Text = "Payment Method\n";
            lblConfirmPaymentMethodTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmPaymentMethodValue
            // 
            lblConfirmPaymentMethodValue.AutoSize = true;
            lblConfirmPaymentMethodValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmPaymentMethodValue.ForeColor = Color.White;
            lblConfirmPaymentMethodValue.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmPaymentMethodValue.Location = new Point(244, 168);
            lblConfirmPaymentMethodValue.Name = "lblConfirmPaymentMethodValue";
            lblConfirmPaymentMethodValue.Size = new Size(19, 25);
            lblConfirmPaymentMethodValue.TabIndex = 10;
            lblConfirmPaymentMethodValue.Text = "-";
            lblConfirmPaymentMethodValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmPaymentTypeValue
            // 
            lblConfirmPaymentTypeValue.AutoSize = true;
            lblConfirmPaymentTypeValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmPaymentTypeValue.ForeColor = Color.White;
            lblConfirmPaymentTypeValue.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmPaymentTypeValue.Location = new Point(244, 112);
            lblConfirmPaymentTypeValue.Name = "lblConfirmPaymentTypeValue";
            lblConfirmPaymentTypeValue.Size = new Size(19, 25);
            lblConfirmPaymentTypeValue.TabIndex = 16;
            lblConfirmPaymentTypeValue.Text = "-";
            lblConfirmPaymentTypeValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPaymentHeader
            // 
            pnlPaymentHeader.Controls.Add(lblPaymentSummary);
            pnlPaymentHeader.Controls.Add(lblConfirmationTitle);
            pnlPaymentHeader.Dock = DockStyle.Top;
            pnlPaymentHeader.Location = new Point(0, 0);
            pnlPaymentHeader.Name = "pnlPaymentHeader";
            pnlPaymentHeader.Size = new Size(482, 65);
            pnlPaymentHeader.TabIndex = 1;
            // 
            // lblPaymentSummary
            // 
            lblPaymentSummary.AutoSize = true;
            lblPaymentSummary.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentSummary.ForeColor = Color.White;
            lblPaymentSummary.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentSummary.Location = new Point(26, 34);
            lblPaymentSummary.Name = "lblPaymentSummary";
            lblPaymentSummary.Size = new Size(429, 25);
            lblPaymentSummary.TabIndex = 5;
            lblPaymentSummary.Text = "Please review the payment details before confirming.";
            lblPaymentSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmationTitle
            // 
            lblConfirmationTitle.AutoSize = true;
            lblConfirmationTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmationTitle.ForeColor = Color.White;
            lblConfirmationTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmationTitle.Location = new Point(163, 9);
            lblConfirmationTitle.Name = "lblConfirmationTitle";
            lblConfirmationTitle.Size = new Size(149, 25);
            lblConfirmationTitle.TabIndex = 4;
            lblConfirmationTitle.Text = "Confirm Payment";
            lblConfirmationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnConfirmPayment);
            panel2.Controls.Add(btnCancelPayment);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 403);
            panel2.Name = "panel2";
            panel2.Size = new Size(482, 50);
            panel2.TabIndex = 2;
            // 
            // btnConfirmPayment
            // 
            btnConfirmPayment.Location = new Point(361, 12);
            btnConfirmPayment.Name = "btnConfirmPayment";
            btnConfirmPayment.Size = new Size(94, 29);
            btnConfirmPayment.TabIndex = 1;
            btnConfirmPayment.Text = "Confirm Payment";
            btnConfirmPayment.UseVisualStyleBackColor = true;
            btnConfirmPayment.Click += btnConfirmPayment_Click;
            // 
            // btnCancelPayment
            // 
            btnCancelPayment.Location = new Point(246, 12);
            btnCancelPayment.Name = "btnCancelPayment";
            btnCancelPayment.Size = new Size(94, 29);
            btnCancelPayment.TabIndex = 0;
            btnCancelPayment.Text = "Cancel";
            btnCancelPayment.UseVisualStyleBackColor = true;
            btnCancelPayment.Click += btnCancelPayment_Click;
            // 
            // ConfirmPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 453);
            Controls.Add(pnlPaymentDetails);
            Controls.Add(panel2);
            Controls.Add(pnlPaymentHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfirmPaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Payment";
            Load += ConfirmPaymentForm_Load;
            pnlPaymentDetails.ResumeLayout(false);
            tblPaymentDetails.ResumeLayout(false);
            tblPaymentDetails.PerformLayout();
            pnlPaymentHeader.ResumeLayout(false);
            pnlPaymentHeader.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPaymentDetails;
        private Panel pnlPaymentHeader;
        private Panel panel2;
        private Label lblConfirmationTitle;
        private Button btnConfirmPayment;
        private Button btnCancelPayment;
        private Label lblPaymentSummary;
        private TableLayoutPanel tblPaymentDetails;
        private Label lblConfirmReferenceValue;
        private Label lblConfirmReferenceTitle;
        private Label lblConfirmAmountValue;
        private Label lblConfirmAmountTitle;
        private Label lblConfirmPaymentMethodValue;
        private Label lblConfirmPaymentMethodTitle;
        private Label lblConfirmCategoryValue;
        private Label lblConfirmCategoryTitle;
        private Label lblConfirmDateValue;
        private Label lblConfirmDateTitle;
        private Label lblConfirmPaymentTypeValue;
        private Label lblConfirmPaymentTypeTitle;
    }
}