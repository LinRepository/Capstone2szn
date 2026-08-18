namespace Capstoneszn.Forms
{
    partial class PaymentForm
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
            pnlPaymentHeader = new Panel();
            lblPaymentDescription = new Label();
            lblPaymentTitle = new Label();
            pnlPaymentActions = new Panel();
            btnContinuePayment = new Button();
            btnCancelPayment = new Button();
            pnlPaymentContent = new Panel();
            pnlAmountReferenceNumber = new Panel();
            pnlReferenceNumber = new Panel();
            lblReferenceNumber = new Label();
            txtReferenceNumber = new TextBox();
            pnlPaymentAmount = new Panel();
            txtPaymentAmount = new TextBox();
            lblPaymentAmount = new Label();
            pnlCategoryPaymentType = new Panel();
            pnlPaymentCategory = new Panel();
            cboPaymentCategory = new ComboBox();
            lblPaymentCategory = new Label();
            pnlPaymentType = new Panel();
            lblPaymentType = new Label();
            cboPaymentType = new ComboBox();
            pnlDatePaymentMethod = new Panel();
            pnlPaymentMethod = new Panel();
            pnlPaymentMethodOptions = new Panel();
            RadioBtnGCash = new RadioButton();
            RadioBtnCash = new RadioButton();
            lblPaymentMethod = new Label();
            pnlPaymentDate = new Panel();
            lblPaymentDate = new Label();
            dtpPaymentDate = new DateTimePicker();
            pnlPaymentRemarks = new Panel();
            txtPaymentRemarks = new TextBox();
            lblPaymentRemarks = new Label();
            pnlPaymentHeader.SuspendLayout();
            pnlPaymentActions.SuspendLayout();
            pnlPaymentContent.SuspendLayout();
            pnlAmountReferenceNumber.SuspendLayout();
            pnlReferenceNumber.SuspendLayout();
            pnlPaymentAmount.SuspendLayout();
            pnlCategoryPaymentType.SuspendLayout();
            pnlPaymentCategory.SuspendLayout();
            pnlPaymentType.SuspendLayout();
            pnlDatePaymentMethod.SuspendLayout();
            pnlPaymentMethod.SuspendLayout();
            pnlPaymentMethodOptions.SuspendLayout();
            pnlPaymentDate.SuspendLayout();
            pnlPaymentRemarks.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPaymentHeader
            // 
            pnlPaymentHeader.Controls.Add(lblPaymentDescription);
            pnlPaymentHeader.Controls.Add(lblPaymentTitle);
            pnlPaymentHeader.Dock = DockStyle.Top;
            pnlPaymentHeader.Location = new Point(0, 0);
            pnlPaymentHeader.Margin = new Padding(0);
            pnlPaymentHeader.Name = "pnlPaymentHeader";
            pnlPaymentHeader.Size = new Size(782, 70);
            pnlPaymentHeader.TabIndex = 0;
            // 
            // lblPaymentDescription
            // 
            lblPaymentDescription.AutoSize = true;
            lblPaymentDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentDescription.ForeColor = Color.White;
            lblPaymentDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentDescription.Location = new Point(227, 34);
            lblPaymentDescription.Name = "lblPaymentDescription";
            lblPaymentDescription.Size = new Size(332, 25);
            lblPaymentDescription.TabIndex = 4;
            lblPaymentDescription.Text = "Fill in details below to record a payment.";
            lblPaymentDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPaymentTitle
            // 
            lblPaymentTitle.AutoSize = true;
            lblPaymentTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentTitle.ForeColor = Color.White;
            lblPaymentTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentTitle.Location = new Point(314, 9);
            lblPaymentTitle.Name = "lblPaymentTitle";
            lblPaymentTitle.Size = new Size(128, 25);
            lblPaymentTitle.TabIndex = 3;
            lblPaymentTitle.Text = "Make Payment";
            lblPaymentTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPaymentActions
            // 
            pnlPaymentActions.Controls.Add(btnContinuePayment);
            pnlPaymentActions.Controls.Add(btnCancelPayment);
            pnlPaymentActions.Dock = DockStyle.Bottom;
            pnlPaymentActions.Location = new Point(0, 503);
            pnlPaymentActions.Margin = new Padding(0);
            pnlPaymentActions.Name = "pnlPaymentActions";
            pnlPaymentActions.Size = new Size(782, 50);
            pnlPaymentActions.TabIndex = 1;
            // 
            // btnContinuePayment
            // 
            btnContinuePayment.Location = new Point(659, 11);
            btnContinuePayment.Name = "btnContinuePayment";
            btnContinuePayment.Size = new Size(94, 29);
            btnContinuePayment.TabIndex = 1;
            btnContinuePayment.Text = "Confirm";
            btnContinuePayment.UseVisualStyleBackColor = true;
            // 
            // btnCancelPayment
            // 
            btnCancelPayment.Location = new Point(533, 11);
            btnCancelPayment.Name = "btnCancelPayment";
            btnCancelPayment.Size = new Size(94, 29);
            btnCancelPayment.TabIndex = 0;
            btnCancelPayment.Text = "Cancel";
            btnCancelPayment.UseVisualStyleBackColor = true;
            // 
            // pnlPaymentContent
            // 
            pnlPaymentContent.Controls.Add(pnlAmountReferenceNumber);
            pnlPaymentContent.Controls.Add(pnlCategoryPaymentType);
            pnlPaymentContent.Controls.Add(pnlDatePaymentMethod);
            pnlPaymentContent.Controls.Add(pnlPaymentRemarks);
            pnlPaymentContent.Dock = DockStyle.Fill;
            pnlPaymentContent.Location = new Point(0, 70);
            pnlPaymentContent.Margin = new Padding(0);
            pnlPaymentContent.Name = "pnlPaymentContent";
            pnlPaymentContent.Padding = new Padding(10);
            pnlPaymentContent.Size = new Size(782, 433);
            pnlPaymentContent.TabIndex = 2;
            // 
            // pnlAmountReferenceNumber
            // 
            pnlAmountReferenceNumber.Controls.Add(pnlReferenceNumber);
            pnlAmountReferenceNumber.Controls.Add(pnlPaymentAmount);
            pnlAmountReferenceNumber.Dock = DockStyle.Fill;
            pnlAmountReferenceNumber.Location = new Point(10, 210);
            pnlAmountReferenceNumber.Name = "pnlAmountReferenceNumber";
            pnlAmountReferenceNumber.Size = new Size(762, 113);
            pnlAmountReferenceNumber.TabIndex = 3;
            // 
            // pnlReferenceNumber
            // 
            pnlReferenceNumber.Controls.Add(lblReferenceNumber);
            pnlReferenceNumber.Controls.Add(txtReferenceNumber);
            pnlReferenceNumber.Dock = DockStyle.Right;
            pnlReferenceNumber.Location = new Point(387, 0);
            pnlReferenceNumber.Name = "pnlReferenceNumber";
            pnlReferenceNumber.Size = new Size(375, 113);
            pnlReferenceNumber.TabIndex = 1;
            // 
            // lblReferenceNumber
            // 
            lblReferenceNumber.AutoSize = true;
            lblReferenceNumber.Dock = DockStyle.Top;
            lblReferenceNumber.Font = new Font("Segoe UI", 13.8F);
            lblReferenceNumber.ForeColor = Color.White;
            lblReferenceNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblReferenceNumber.Location = new Point(0, 0);
            lblReferenceNumber.Margin = new Padding(0);
            lblReferenceNumber.Name = "lblReferenceNumber";
            lblReferenceNumber.Size = new Size(272, 31);
            lblReferenceNumber.TabIndex = 6;
            lblReferenceNumber.Text = "Reference Gcash Number";
            lblReferenceNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.BorderStyle = BorderStyle.FixedSingle;
            txtReferenceNumber.Location = new Point(60, 65);
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.Size = new Size(125, 27);
            txtReferenceNumber.TabIndex = 7;
            txtReferenceNumber.Visible = false;
            // 
            // pnlPaymentAmount
            // 
            pnlPaymentAmount.Controls.Add(txtPaymentAmount);
            pnlPaymentAmount.Controls.Add(lblPaymentAmount);
            pnlPaymentAmount.Dock = DockStyle.Left;
            pnlPaymentAmount.Location = new Point(0, 0);
            pnlPaymentAmount.Name = "pnlPaymentAmount";
            pnlPaymentAmount.Size = new Size(375, 113);
            pnlPaymentAmount.TabIndex = 0;
            // 
            // txtPaymentAmount
            // 
            txtPaymentAmount.BorderStyle = BorderStyle.FixedSingle;
            txtPaymentAmount.Location = new Point(55, 48);
            txtPaymentAmount.Name = "txtPaymentAmount";
            txtPaymentAmount.Size = new Size(125, 27);
            txtPaymentAmount.TabIndex = 8;
            // 
            // lblPaymentAmount
            // 
            lblPaymentAmount.AutoSize = true;
            lblPaymentAmount.Dock = DockStyle.Top;
            lblPaymentAmount.Font = new Font("Segoe UI", 13.8F);
            lblPaymentAmount.ForeColor = Color.White;
            lblPaymentAmount.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentAmount.Location = new Point(0, 0);
            lblPaymentAmount.Margin = new Padding(0);
            lblPaymentAmount.Name = "lblPaymentAmount";
            lblPaymentAmount.Size = new Size(96, 31);
            lblPaymentAmount.TabIndex = 5;
            lblPaymentAmount.Text = "Amount";
            lblPaymentAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCategoryPaymentType
            // 
            pnlCategoryPaymentType.Controls.Add(pnlPaymentCategory);
            pnlCategoryPaymentType.Controls.Add(pnlPaymentType);
            pnlCategoryPaymentType.Dock = DockStyle.Top;
            pnlCategoryPaymentType.Location = new Point(10, 110);
            pnlCategoryPaymentType.Name = "pnlCategoryPaymentType";
            pnlCategoryPaymentType.Size = new Size(762, 100);
            pnlCategoryPaymentType.TabIndex = 2;
            // 
            // pnlPaymentCategory
            // 
            pnlPaymentCategory.Controls.Add(cboPaymentCategory);
            pnlPaymentCategory.Controls.Add(lblPaymentCategory);
            pnlPaymentCategory.Dock = DockStyle.Left;
            pnlPaymentCategory.Location = new Point(0, 0);
            pnlPaymentCategory.Name = "pnlPaymentCategory";
            pnlPaymentCategory.Size = new Size(375, 100);
            pnlPaymentCategory.TabIndex = 3;
            // 
            // cboPaymentCategory
            // 
            cboPaymentCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentCategory.FormattingEnabled = true;
            cboPaymentCategory.Location = new Point(103, 42);
            cboPaymentCategory.Name = "cboPaymentCategory";
            cboPaymentCategory.Size = new Size(151, 28);
            cboPaymentCategory.TabIndex = 0;
            // 
            // lblPaymentCategory
            // 
            lblPaymentCategory.AutoSize = true;
            lblPaymentCategory.Dock = DockStyle.Top;
            lblPaymentCategory.Font = new Font("Segoe UI", 13.8F);
            lblPaymentCategory.ForeColor = Color.White;
            lblPaymentCategory.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentCategory.Location = new Point(0, 0);
            lblPaymentCategory.Margin = new Padding(0);
            lblPaymentCategory.Name = "lblPaymentCategory";
            lblPaymentCategory.Size = new Size(106, 31);
            lblPaymentCategory.TabIndex = 6;
            lblPaymentCategory.Text = "Category";
            lblPaymentCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPaymentType
            // 
            pnlPaymentType.Controls.Add(lblPaymentType);
            pnlPaymentType.Controls.Add(cboPaymentType);
            pnlPaymentType.Dock = DockStyle.Right;
            pnlPaymentType.Location = new Point(387, 0);
            pnlPaymentType.Name = "pnlPaymentType";
            pnlPaymentType.Size = new Size(375, 100);
            pnlPaymentType.TabIndex = 0;
            // 
            // lblPaymentType
            // 
            lblPaymentType.AutoSize = true;
            lblPaymentType.Dock = DockStyle.Top;
            lblPaymentType.Font = new Font("Segoe UI", 13.8F);
            lblPaymentType.ForeColor = Color.White;
            lblPaymentType.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentType.Location = new Point(0, 0);
            lblPaymentType.Margin = new Padding(0);
            lblPaymentType.Name = "lblPaymentType";
            lblPaymentType.Size = new Size(156, 31);
            lblPaymentType.TabIndex = 8;
            lblPaymentType.Text = "Payment Type";
            lblPaymentType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboPaymentType
            // 
            cboPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentType.FormattingEnabled = true;
            cboPaymentType.Location = new Point(34, 42);
            cboPaymentType.Name = "cboPaymentType";
            cboPaymentType.Size = new Size(151, 28);
            cboPaymentType.TabIndex = 7;
            // 
            // pnlDatePaymentMethod
            // 
            pnlDatePaymentMethod.Controls.Add(pnlPaymentMethod);
            pnlDatePaymentMethod.Controls.Add(pnlPaymentDate);
            pnlDatePaymentMethod.Dock = DockStyle.Top;
            pnlDatePaymentMethod.Location = new Point(10, 10);
            pnlDatePaymentMethod.Name = "pnlDatePaymentMethod";
            pnlDatePaymentMethod.Size = new Size(762, 100);
            pnlDatePaymentMethod.TabIndex = 1;
            // 
            // pnlPaymentMethod
            // 
            pnlPaymentMethod.Controls.Add(pnlPaymentMethodOptions);
            pnlPaymentMethod.Controls.Add(lblPaymentMethod);
            pnlPaymentMethod.Dock = DockStyle.Right;
            pnlPaymentMethod.Location = new Point(387, 0);
            pnlPaymentMethod.Name = "pnlPaymentMethod";
            pnlPaymentMethod.Size = new Size(375, 100);
            pnlPaymentMethod.TabIndex = 1;
            // 
            // pnlPaymentMethodOptions
            // 
            pnlPaymentMethodOptions.Controls.Add(RadioBtnGCash);
            pnlPaymentMethodOptions.Controls.Add(RadioBtnCash);
            pnlPaymentMethodOptions.Location = new Point(65, 34);
            pnlPaymentMethodOptions.Name = "pnlPaymentMethodOptions";
            pnlPaymentMethodOptions.Size = new Size(250, 50);
            pnlPaymentMethodOptions.TabIndex = 5;
            // 
            // RadioBtnGCash
            // 
            RadioBtnGCash.AutoSize = true;
            RadioBtnGCash.ForeColor = Color.White;
            RadioBtnGCash.Location = new Point(150, 13);
            RadioBtnGCash.Name = "RadioBtnGCash";
            RadioBtnGCash.Size = new Size(69, 24);
            RadioBtnGCash.TabIndex = 1;
            RadioBtnGCash.TabStop = true;
            RadioBtnGCash.Text = "Gcash";
            RadioBtnGCash.UseVisualStyleBackColor = true;
            // 
            // RadioBtnCash
            // 
            RadioBtnCash.AutoSize = true;
            RadioBtnCash.ForeColor = Color.White;
            RadioBtnCash.Location = new Point(41, 13);
            RadioBtnCash.Name = "RadioBtnCash";
            RadioBtnCash.Size = new Size(61, 24);
            RadioBtnCash.TabIndex = 0;
            RadioBtnCash.TabStop = true;
            RadioBtnCash.Text = "Cash";
            RadioBtnCash.UseVisualStyleBackColor = true;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Dock = DockStyle.Top;
            lblPaymentMethod.Font = new Font("Segoe UI", 13.8F);
            lblPaymentMethod.ForeColor = Color.White;
            lblPaymentMethod.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentMethod.Location = new Point(0, 0);
            lblPaymentMethod.Margin = new Padding(0);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(189, 31);
            lblPaymentMethod.TabIndex = 4;
            lblPaymentMethod.Text = "Payment Method";
            lblPaymentMethod.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPaymentDate
            // 
            pnlPaymentDate.Controls.Add(lblPaymentDate);
            pnlPaymentDate.Controls.Add(dtpPaymentDate);
            pnlPaymentDate.Dock = DockStyle.Left;
            pnlPaymentDate.Location = new Point(0, 0);
            pnlPaymentDate.Name = "pnlPaymentDate";
            pnlPaymentDate.Size = new Size(375, 100);
            pnlPaymentDate.TabIndex = 0;
            // 
            // lblPaymentDate
            // 
            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Dock = DockStyle.Top;
            lblPaymentDate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentDate.ForeColor = Color.White;
            lblPaymentDate.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentDate.Location = new Point(0, 0);
            lblPaymentDate.Margin = new Padding(0);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new Size(62, 31);
            lblPaymentDate.TabIndex = 3;
            lblPaymentDate.Text = "Date";
            lblPaymentDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Location = new Point(55, 38);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(250, 27);
            dtpPaymentDate.TabIndex = 0;
            // 
            // pnlPaymentRemarks
            // 
            pnlPaymentRemarks.Controls.Add(txtPaymentRemarks);
            pnlPaymentRemarks.Controls.Add(lblPaymentRemarks);
            pnlPaymentRemarks.Dock = DockStyle.Bottom;
            pnlPaymentRemarks.Location = new Point(10, 323);
            pnlPaymentRemarks.Name = "pnlPaymentRemarks";
            pnlPaymentRemarks.Size = new Size(762, 100);
            pnlPaymentRemarks.TabIndex = 0;
            // 
            // txtPaymentRemarks
            // 
            txtPaymentRemarks.Dock = DockStyle.Fill;
            txtPaymentRemarks.Location = new Point(0, 25);
            txtPaymentRemarks.Multiline = true;
            txtPaymentRemarks.Name = "txtPaymentRemarks";
            txtPaymentRemarks.ScrollBars = ScrollBars.Vertical;
            txtPaymentRemarks.Size = new Size(762, 75);
            txtPaymentRemarks.TabIndex = 10;
            // 
            // lblPaymentRemarks
            // 
            lblPaymentRemarks.AutoSize = true;
            lblPaymentRemarks.Dock = DockStyle.Top;
            lblPaymentRemarks.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentRemarks.ForeColor = Color.White;
            lblPaymentRemarks.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentRemarks.Location = new Point(0, 0);
            lblPaymentRemarks.Margin = new Padding(0);
            lblPaymentRemarks.Name = "lblPaymentRemarks";
            lblPaymentRemarks.Size = new Size(163, 25);
            lblPaymentRemarks.TabIndex = 7;
            lblPaymentRemarks.Text = "Remarks (Optional)";
            lblPaymentRemarks.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(782, 553);
            Controls.Add(pnlPaymentContent);
            Controls.Add(pnlPaymentActions);
            Controls.Add(pnlPaymentHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Make Payment";
            pnlPaymentHeader.ResumeLayout(false);
            pnlPaymentHeader.PerformLayout();
            pnlPaymentActions.ResumeLayout(false);
            pnlPaymentContent.ResumeLayout(false);
            pnlAmountReferenceNumber.ResumeLayout(false);
            pnlReferenceNumber.ResumeLayout(false);
            pnlReferenceNumber.PerformLayout();
            pnlPaymentAmount.ResumeLayout(false);
            pnlPaymentAmount.PerformLayout();
            pnlCategoryPaymentType.ResumeLayout(false);
            pnlPaymentCategory.ResumeLayout(false);
            pnlPaymentCategory.PerformLayout();
            pnlPaymentType.ResumeLayout(false);
            pnlPaymentType.PerformLayout();
            pnlDatePaymentMethod.ResumeLayout(false);
            pnlPaymentMethod.ResumeLayout(false);
            pnlPaymentMethod.PerformLayout();
            pnlPaymentMethodOptions.ResumeLayout(false);
            pnlPaymentMethodOptions.PerformLayout();
            pnlPaymentDate.ResumeLayout(false);
            pnlPaymentDate.PerformLayout();
            pnlPaymentRemarks.ResumeLayout(false);
            pnlPaymentRemarks.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPaymentHeader;
        private Panel pnlPaymentActions;
        private Panel pnlPaymentContent;
        private Label lblPaymentDescription;
        private Label lblPaymentTitle;
        private Panel pnlDatePaymentMethod;
        private Panel pnlPaymentRemarks;
        private Panel pnlCategoryPaymentType;
        private Panel pnlPaymentMethod;
        private Panel pnlPaymentDate;
        private Panel pnlAmountReferenceNumber;
        private Panel pnlPaymentCategory;
        private Panel pnlPaymentType;
        private Button btnContinuePayment;
        private Button btnCancelPayment;
        private DateTimePicker dtpPaymentDate;
        private Panel pnlReferenceNumber;
        private Panel pnlPaymentAmount;
        private Label lblPaymentAmount;
        private Label lblReferenceNumber;
        private Label lblPaymentMethod;
        private Label lblPaymentDate;
        private Label lblPaymentRemarks;
        private Label lblPaymentType;
        private ComboBox cboPaymentType;
        private Label lblPaymentCategory;
        private ComboBox cboPaymentCategory;
        private TextBox txtPaymentAmount;
        private TextBox txtReferenceNumber;
        private TextBox txtPaymentRemarks;
        private Panel pnlPaymentMethodOptions;
        private RadioButton RadioBtnGCash;
        private RadioButton RadioBtnCash;
    }
}