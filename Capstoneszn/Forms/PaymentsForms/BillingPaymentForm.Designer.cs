namespace Capstoneszn.Forms.PaymentsForms
{
    partial class BillingPaymentForm
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
            lblMakePaymentTitle = new Label();
            pnlPaymentContent = new Panel();
            flpPaymentDetails = new FlowLayoutPanel();
            pnlPaymentInput = new Panel();
            pnl4 = new Panel();
            lblAfterPaymentValue = new Label();
            pnl3 = new Panel();
            lblAmount = new Label();
            txtAmount = new TextBox();
            panel8 = new Panel();
            txtReferenceNumber = new TextBox();
            lblReferenceNumber = new Label();
            pnl2 = new Panel();
            radioButtonGcash = new RadioButton();
            radioButtonCash = new RadioButton();
            cboPaymentType = new ComboBox();
            lblPaymentMethod = new Label();
            lblPaymentType = new Label();
            pnl1 = new Panel();
            cboCategoryType = new ComboBox();
            dtpDate = new DateTimePicker();
            lblCategory = new Label();
            lblDate = new Label();
            pnlPaymentBottom = new Panel();
            btnClear = new Button();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlPaymentHeader.SuspendLayout();
            pnlPaymentContent.SuspendLayout();
            pnlPaymentInput.SuspendLayout();
            pnl4.SuspendLayout();
            pnl3.SuspendLayout();
            panel8.SuspendLayout();
            pnl2.SuspendLayout();
            pnl1.SuspendLayout();
            pnlPaymentBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPaymentHeader
            // 
            pnlPaymentHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentHeader.Controls.Add(lblMakePaymentTitle);
            pnlPaymentHeader.Dock = DockStyle.Top;
            pnlPaymentHeader.Location = new Point(0, 0);
            pnlPaymentHeader.Name = "pnlPaymentHeader";
            pnlPaymentHeader.Size = new Size(832, 60);
            pnlPaymentHeader.TabIndex = 0;
            // 
            // lblMakePaymentTitle
            // 
            lblMakePaymentTitle.Dock = DockStyle.Fill;
            lblMakePaymentTitle.Font = new Font("Segoe UI", 12F);
            lblMakePaymentTitle.ForeColor = Color.White;
            lblMakePaymentTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMakePaymentTitle.Location = new Point(0, 0);
            lblMakePaymentTitle.Margin = new Padding(0);
            lblMakePaymentTitle.Name = "lblMakePaymentTitle";
            lblMakePaymentTitle.Size = new Size(830, 58);
            lblMakePaymentTitle.TabIndex = 33;
            lblMakePaymentTitle.Text = "Make Payment";
            lblMakePaymentTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPaymentContent
            // 
            pnlPaymentContent.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentContent.Controls.Add(flpPaymentDetails);
            pnlPaymentContent.Controls.Add(pnlPaymentInput);
            pnlPaymentContent.Dock = DockStyle.Fill;
            pnlPaymentContent.Location = new Point(0, 60);
            pnlPaymentContent.Name = "pnlPaymentContent";
            pnlPaymentContent.Size = new Size(832, 598);
            pnlPaymentContent.TabIndex = 1;
            // 
            // flpPaymentDetails
            // 
            flpPaymentDetails.BorderStyle = BorderStyle.FixedSingle;
            flpPaymentDetails.Dock = DockStyle.Fill;
            flpPaymentDetails.FlowDirection = FlowDirection.TopDown;
            flpPaymentDetails.Location = new Point(0, 282);
            flpPaymentDetails.Name = "flpPaymentDetails";
            flpPaymentDetails.Size = new Size(830, 314);
            flpPaymentDetails.TabIndex = 2;
            // 
            // pnlPaymentInput
            // 
            pnlPaymentInput.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentInput.Controls.Add(pnl4);
            pnlPaymentInput.Controls.Add(pnl3);
            pnlPaymentInput.Controls.Add(pnl2);
            pnlPaymentInput.Controls.Add(pnl1);
            pnlPaymentInput.Dock = DockStyle.Top;
            pnlPaymentInput.Location = new Point(0, 0);
            pnlPaymentInput.Name = "pnlPaymentInput";
            pnlPaymentInput.Size = new Size(830, 282);
            pnlPaymentInput.TabIndex = 1;
            // 
            // pnl4
            // 
            pnl4.Controls.Add(lblAfterPaymentValue);
            pnl4.Dock = DockStyle.Fill;
            pnl4.Location = new Point(0, 210);
            pnl4.Name = "pnl4";
            pnl4.Size = new Size(828, 70);
            pnl4.TabIndex = 3;
            // 
            // lblAfterPaymentValue
            // 
            lblAfterPaymentValue.AutoSize = true;
            lblAfterPaymentValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAfterPaymentValue.ForeColor = Color.White;
            lblAfterPaymentValue.ImageAlign = ContentAlignment.MiddleRight;
            lblAfterPaymentValue.Location = new Point(25, 21);
            lblAfterPaymentValue.Margin = new Padding(0);
            lblAfterPaymentValue.Name = "lblAfterPaymentValue";
            lblAfterPaymentValue.Size = new Size(207, 31);
            lblAfterPaymentValue.TabIndex = 39;
            lblAfterPaymentValue.Text = "AfterPaymentValue";
            lblAfterPaymentValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnl3
            // 
            pnl3.Controls.Add(lblAmount);
            pnl3.Controls.Add(txtAmount);
            pnl3.Controls.Add(panel8);
            pnl3.Dock = DockStyle.Top;
            pnl3.Location = new Point(0, 140);
            pnl3.Name = "pnl3";
            pnl3.Size = new Size(828, 70);
            pnl3.TabIndex = 2;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 12F);
            lblAmount.ForeColor = Color.White;
            lblAmount.ImageAlign = ContentAlignment.MiddleRight;
            lblAmount.Location = new Point(499, 1);
            lblAmount.Margin = new Padding(0);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(83, 28);
            lblAmount.TabIndex = 35;
            lblAmount.Text = "Amount";
            lblAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(499, 32);
            txtAmount.Multiline = true;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(300, 35);
            txtAmount.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(txtReferenceNumber);
            panel8.Controls.Add(lblReferenceNumber);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(350, 70);
            panel8.TabIndex = 1;
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.Location = new Point(25, 32);
            txtReferenceNumber.Multiline = true;
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.Size = new Size(300, 35);
            txtReferenceNumber.TabIndex = 0;
            // 
            // lblReferenceNumber
            // 
            lblReferenceNumber.AutoSize = true;
            lblReferenceNumber.Dock = DockStyle.Top;
            lblReferenceNumber.Font = new Font("Segoe UI", 12F);
            lblReferenceNumber.ForeColor = Color.White;
            lblReferenceNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblReferenceNumber.Location = new Point(0, 0);
            lblReferenceNumber.Margin = new Padding(0);
            lblReferenceNumber.Name = "lblReferenceNumber";
            lblReferenceNumber.Size = new Size(244, 28);
            lblReferenceNumber.TabIndex = 34;
            lblReferenceNumber.Text = "Reference No. (Gcash only)";
            lblReferenceNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnl2
            // 
            pnl2.Controls.Add(radioButtonGcash);
            pnl2.Controls.Add(radioButtonCash);
            pnl2.Controls.Add(cboPaymentType);
            pnl2.Controls.Add(lblPaymentMethod);
            pnl2.Controls.Add(lblPaymentType);
            pnl2.Dock = DockStyle.Top;
            pnl2.Location = new Point(0, 70);
            pnl2.Name = "pnl2";
            pnl2.Size = new Size(828, 70);
            pnl2.TabIndex = 1;
            // 
            // radioButtonGcash
            // 
            radioButtonGcash.AutoSize = true;
            radioButtonGcash.ForeColor = Color.Transparent;
            radioButtonGcash.Location = new Point(682, 40);
            radioButtonGcash.Name = "radioButtonGcash";
            radioButtonGcash.Size = new Size(69, 24);
            radioButtonGcash.TabIndex = 42;
            radioButtonGcash.TabStop = true;
            radioButtonGcash.Text = "Gcash";
            radioButtonGcash.UseVisualStyleBackColor = true;
            // 
            // radioButtonCash
            // 
            radioButtonCash.AutoSize = true;
            radioButtonCash.ForeColor = Color.Transparent;
            radioButtonCash.Location = new Point(593, 40);
            radioButtonCash.Name = "radioButtonCash";
            radioButtonCash.Size = new Size(61, 24);
            radioButtonCash.TabIndex = 41;
            radioButtonCash.TabStop = true;
            radioButtonCash.Text = "Cash";
            radioButtonCash.UseVisualStyleBackColor = true;
            // 
            // cboPaymentType
            // 
            cboPaymentType.FormattingEnabled = true;
            cboPaymentType.Location = new Point(25, 34);
            cboPaymentType.Name = "cboPaymentType";
            cboPaymentType.Size = new Size(260, 28);
            cboPaymentType.TabIndex = 40;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 12F);
            lblPaymentMethod.ForeColor = Color.White;
            lblPaymentMethod.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentMethod.Location = new Point(593, 3);
            lblPaymentMethod.Margin = new Padding(0);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(162, 28);
            lblPaymentMethod.TabIndex = 37;
            lblPaymentMethod.Text = "Payment Method";
            lblPaymentMethod.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPaymentType
            // 
            lblPaymentType.AutoSize = true;
            lblPaymentType.Font = new Font("Segoe UI", 12F);
            lblPaymentType.ForeColor = Color.White;
            lblPaymentType.ImageAlign = ContentAlignment.MiddleRight;
            lblPaymentType.Location = new Point(125, 3);
            lblPaymentType.Margin = new Padding(0);
            lblPaymentType.Name = "lblPaymentType";
            lblPaymentType.Size = new Size(133, 28);
            lblPaymentType.TabIndex = 36;
            lblPaymentType.Text = "Payment Type";
            lblPaymentType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnl1
            // 
            pnl1.Controls.Add(cboCategoryType);
            pnl1.Controls.Add(dtpDate);
            pnl1.Controls.Add(lblCategory);
            pnl1.Controls.Add(lblDate);
            pnl1.Dock = DockStyle.Top;
            pnl1.Location = new Point(0, 0);
            pnl1.Name = "pnl1";
            pnl1.Size = new Size(828, 70);
            pnl1.TabIndex = 0;
            // 
            // cboCategoryType
            // 
            cboCategoryType.FormattingEnabled = true;
            cboCategoryType.Location = new Point(539, 32);
            cboCategoryType.Name = "cboCategoryType";
            cboCategoryType.Size = new Size(260, 28);
            cboCategoryType.TabIndex = 39;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(11, 33);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 38;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 12F);
            lblCategory.ForeColor = Color.White;
            lblCategory.ImageAlign = ContentAlignment.MiddleRight;
            lblCategory.Location = new Point(630, -2);
            lblCategory.Margin = new Padding(0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(92, 28);
            lblCategory.TabIndex = 37;
            lblCategory.Text = "Category";
            lblCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F);
            lblDate.ForeColor = Color.White;
            lblDate.ImageAlign = ContentAlignment.MiddleRight;
            lblDate.Location = new Point(110, 2);
            lblDate.Margin = new Padding(0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(53, 28);
            lblDate.TabIndex = 36;
            lblDate.Text = "Date";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPaymentBottom
            // 
            pnlPaymentBottom.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentBottom.Controls.Add(btnClear);
            pnlPaymentBottom.Controls.Add(btnConfirm);
            pnlPaymentBottom.Controls.Add(btnCancel);
            pnlPaymentBottom.Dock = DockStyle.Bottom;
            pnlPaymentBottom.Location = new Point(0, 598);
            pnlPaymentBottom.Name = "pnlPaymentBottom";
            pnlPaymentBottom.Size = new Size(832, 60);
            pnlPaymentBottom.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(24, 19);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(661, 19);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(549, 19);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // BillingPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(832, 658);
            Controls.Add(pnlPaymentBottom);
            Controls.Add(pnlPaymentContent);
            Controls.Add(pnlPaymentHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BillingPaymentForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BillingPaymentForm";
            pnlPaymentHeader.ResumeLayout(false);
            pnlPaymentContent.ResumeLayout(false);
            pnlPaymentInput.ResumeLayout(false);
            pnl4.ResumeLayout(false);
            pnl4.PerformLayout();
            pnl3.ResumeLayout(false);
            pnl3.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            pnl2.ResumeLayout(false);
            pnl2.PerformLayout();
            pnl1.ResumeLayout(false);
            pnl1.PerformLayout();
            pnlPaymentBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPaymentHeader;
        private Panel pnlPaymentContent;
        private Panel pnlPaymentBottom;
        private Label lblMakePaymentTitle;
        private Button btnClear;
        private Button btnConfirm;
        private Button btnCancel;
        private Panel pnlPaymentInput;
        private Label lblReferenceNumber;
        private Panel pnl3;
        private Panel pnl2;
        private Panel pnl1;
        private TextBox txtReferenceNumber;
        private TextBox txtAmount;
        private Panel panel8;
        private Label lblAmount;
        private Label lblPaymentMethod;
        private Label lblPaymentType;
        private ComboBox cboCategoryType;
        private DateTimePicker dtpDate;
        private Label lblCategory;
        private Label lblDate;
        private RadioButton radioButtonGcash;
        private RadioButton radioButtonCash;
        private ComboBox cboPaymentType;
        private FlowLayoutPanel flpPaymentDetails;
        private Panel pnl4;
        private Label lblAfterPaymentValue;
    }
}