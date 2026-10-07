namespace Capstoneszn.Forms.PaymentsForms
{
    partial class New_Make_Payment
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
            panel1 = new Panel();
            lblPaymentDescription = new Label();
            lblPaymentTitle = new Label();
            panel2 = new Panel();
            btnClear = new Button();
            btnCancelPayment = new Button();
            btnContinuePayment = new Button();
            panel3 = new Panel();
            RadioBtnGCash = new RadioButton();
            RadioBtnCash = new RadioButton();
            dtpPaymentDate = new DateTimePicker();
            cboPaymentType = new ComboBox();
            cboPaymentCategory = new ComboBox();
            lblPaymentType = new Label();
            lblPaymentDate = new Label();
            lblPaymentMethod = new Label();
            lblPaymentCategory = new Label();
            lblPaymentAmount = new Label();
            txtAmountValue = new TextBox();
            label8 = new Label();
            panel4 = new Panel();
            txtReferenceNumber = new TextBox();
            RadioBtnRoom = new RadioButton();
            RadioBtnTenant = new RadioButton();
            lblReferenceNumber = new Label();
            lblPeso = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblPaymentDescription);
            panel1.Controls.Add(lblPaymentTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(845, 76);
            panel1.TabIndex = 0;
            // 
            // lblPaymentDescription
            // 
            lblPaymentDescription.AutoSize = true;
            lblPaymentDescription.ForeColor = Color.White;
            lblPaymentDescription.Location = new Point(277, 38);
            lblPaymentDescription.Name = "lblPaymentDescription";
            lblPaymentDescription.Size = new Size(297, 20);
            lblPaymentDescription.TabIndex = 1;
            lblPaymentDescription.Text = "Fields marked required must be completed.";
            // 
            // lblPaymentTitle
            // 
            lblPaymentTitle.AutoSize = true;
            lblPaymentTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentTitle.ForeColor = Color.White;
            lblPaymentTitle.Location = new Point(354, 10);
            lblPaymentTitle.Name = "lblPaymentTitle";
            lblPaymentTitle.Size = new Size(151, 28);
            lblPaymentTitle.TabIndex = 0;
            lblPaymentTitle.Text = "Payment Details";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnClear);
            panel2.Controls.Add(btnCancelPayment);
            panel2.Controls.Add(btnContinuePayment);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 474);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(845, 67);
            panel2.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.Dock = DockStyle.Left;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(10, 10);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(135, 47);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnCancelPayment
            // 
            btnCancelPayment.BackColor = Color.White;
            btnCancelPayment.FlatStyle = FlatStyle.Flat;
            btnCancelPayment.Location = new Point(555, 10);
            btnCancelPayment.Margin = new Padding(5);
            btnCancelPayment.Name = "btnCancelPayment";
            btnCancelPayment.Size = new Size(135, 48);
            btnCancelPayment.TabIndex = 0;
            btnCancelPayment.Text = "Cancel";
            btnCancelPayment.UseVisualStyleBackColor = false;
            // 
            // btnContinuePayment
            // 
            btnContinuePayment.BackColor = Color.White;
            btnContinuePayment.Dock = DockStyle.Right;
            btnContinuePayment.FlatStyle = FlatStyle.Flat;
            btnContinuePayment.Location = new Point(700, 10);
            btnContinuePayment.Margin = new Padding(5);
            btnContinuePayment.Name = "btnContinuePayment";
            btnContinuePayment.Size = new Size(135, 47);
            btnContinuePayment.TabIndex = 0;
            btnContinuePayment.Text = "Confirm";
            btnContinuePayment.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblPeso);
            panel3.Controls.Add(RadioBtnGCash);
            panel3.Controls.Add(RadioBtnCash);
            panel3.Controls.Add(dtpPaymentDate);
            panel3.Controls.Add(cboPaymentType);
            panel3.Controls.Add(cboPaymentCategory);
            panel3.Controls.Add(lblPaymentType);
            panel3.Controls.Add(lblPaymentDate);
            panel3.Controls.Add(lblPaymentMethod);
            panel3.Controls.Add(lblPaymentCategory);
            panel3.Controls.Add(lblPaymentAmount);
            panel3.Controls.Add(txtAmountValue);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 76);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(845, 465);
            panel3.TabIndex = 2;
            // 
            // RadioBtnGCash
            // 
            RadioBtnGCash.Appearance = Appearance.Button;
            RadioBtnGCash.BackColor = Color.FromArgb(11, 20, 38);
            RadioBtnGCash.FlatStyle = FlatStyle.Flat;
            RadioBtnGCash.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RadioBtnGCash.ForeColor = Color.White;
            RadioBtnGCash.Location = new Point(225, 334);
            RadioBtnGCash.Margin = new Padding(0);
            RadioBtnGCash.Name = "RadioBtnGCash";
            RadioBtnGCash.Size = new Size(203, 46);
            RadioBtnGCash.TabIndex = 6;
            RadioBtnGCash.TabStop = true;
            RadioBtnGCash.Text = "Gcash";
            RadioBtnGCash.TextAlign = ContentAlignment.MiddleCenter;
            RadioBtnGCash.UseVisualStyleBackColor = false;
            // 
            // RadioBtnCash
            // 
            RadioBtnCash.Appearance = Appearance.Button;
            RadioBtnCash.BackColor = Color.FromArgb(11, 20, 38);
            RadioBtnCash.FlatStyle = FlatStyle.Flat;
            RadioBtnCash.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RadioBtnCash.ForeColor = Color.White;
            RadioBtnCash.Location = new Point(22, 334);
            RadioBtnCash.Margin = new Padding(0, 3, 0, 3);
            RadioBtnCash.Name = "RadioBtnCash";
            RadioBtnCash.Size = new Size(203, 46);
            RadioBtnCash.TabIndex = 5;
            RadioBtnCash.TabStop = true;
            RadioBtnCash.Text = "Cash";
            RadioBtnCash.TextAlign = ContentAlignment.MiddleCenter;
            RadioBtnCash.UseVisualStyleBackColor = false;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpPaymentDate.Location = new Point(22, 247);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(443, 34);
            dtpPaymentDate.TabIndex = 3;
            // 
            // cboPaymentType
            // 
            cboPaymentType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboPaymentType.FormattingEnabled = true;
            cboPaymentType.Location = new Point(262, 162);
            cboPaymentType.Name = "cboPaymentType";
            cboPaymentType.Size = new Size(203, 36);
            cboPaymentType.TabIndex = 2;
            // 
            // cboPaymentCategory
            // 
            cboPaymentCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboPaymentCategory.FormattingEnabled = true;
            cboPaymentCategory.Location = new Point(22, 162);
            cboPaymentCategory.Name = "cboPaymentCategory";
            cboPaymentCategory.Size = new Size(203, 36);
            cboPaymentCategory.TabIndex = 2;
            // 
            // lblPaymentType
            // 
            lblPaymentType.AutoSize = true;
            lblPaymentType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentType.ForeColor = Color.White;
            lblPaymentType.Location = new Point(262, 131);
            lblPaymentType.Name = "lblPaymentType";
            lblPaymentType.Size = new Size(133, 28);
            lblPaymentType.TabIndex = 1;
            lblPaymentType.Text = "Payment Type";
            // 
            // lblPaymentDate
            // 
            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentDate.ForeColor = Color.White;
            lblPaymentDate.Location = new Point(22, 216);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new Size(156, 28);
            lblPaymentDate.TabIndex = 1;
            lblPaymentDate.Text = "Transaction Date";
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentMethod.ForeColor = Color.White;
            lblPaymentMethod.Location = new Point(22, 303);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(162, 28);
            lblPaymentMethod.TabIndex = 1;
            lblPaymentMethod.Text = "Payment Method";
            // 
            // lblPaymentCategory
            // 
            lblPaymentCategory.AutoSize = true;
            lblPaymentCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentCategory.ForeColor = Color.White;
            lblPaymentCategory.Location = new Point(22, 131);
            lblPaymentCategory.Name = "lblPaymentCategory";
            lblPaymentCategory.Size = new Size(92, 28);
            lblPaymentCategory.TabIndex = 1;
            lblPaymentCategory.Text = "Category";
            // 
            // lblPaymentAmount
            // 
            lblPaymentAmount.AutoSize = true;
            lblPaymentAmount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentAmount.ForeColor = Color.White;
            lblPaymentAmount.Location = new Point(22, 17);
            lblPaymentAmount.Name = "lblPaymentAmount";
            lblPaymentAmount.Size = new Size(83, 28);
            lblPaymentAmount.TabIndex = 1;
            lblPaymentAmount.Text = "Amount";
            // 
            // txtAmountValue
            // 
            txtAmountValue.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmountValue.Location = new Point(22, 48);
            txtAmountValue.Name = "txtAmountValue";
            txtAmountValue.PlaceholderText = "0.00 ";
            txtAmountValue.Size = new Size(443, 61);
            txtAmountValue.TabIndex = 0;
            txtAmountValue.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(11, 9);
            label8.Name = "label8";
            label8.Size = new Size(192, 28);
            label8.TabIndex = 1;
            label8.Text = "Record payment to *";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtReferenceNumber);
            panel4.Controls.Add(RadioBtnRoom);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(RadioBtnTenant);
            panel4.Controls.Add(lblReferenceNumber);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(498, 76);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(347, 398);
            panel4.TabIndex = 6;
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReferenceNumber.Location = new Point(11, 346);
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.Size = new Size(324, 34);
            txtReferenceNumber.TabIndex = 7;
            // 
            // RadioBtnRoom
            // 
            RadioBtnRoom.Appearance = Appearance.Button;
            RadioBtnRoom.BackColor = Color.FromArgb(11, 20, 38);
            RadioBtnRoom.FlatStyle = FlatStyle.Flat;
            RadioBtnRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RadioBtnRoom.ForeColor = Color.White;
            RadioBtnRoom.Location = new Point(11, 127);
            RadioBtnRoom.Margin = new Padding(0);
            RadioBtnRoom.Name = "RadioBtnRoom";
            RadioBtnRoom.Size = new Size(324, 62);
            RadioBtnRoom.TabIndex = 6;
            RadioBtnRoom.TabStop = true;
            RadioBtnRoom.Text = "Whole Room";
            RadioBtnRoom.TextAlign = ContentAlignment.MiddleCenter;
            RadioBtnRoom.UseVisualStyleBackColor = false;
            // 
            // RadioBtnTenant
            // 
            RadioBtnTenant.Appearance = Appearance.Button;
            RadioBtnTenant.BackColor = Color.FromArgb(11, 20, 38);
            RadioBtnTenant.FlatStyle = FlatStyle.Flat;
            RadioBtnTenant.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RadioBtnTenant.ForeColor = Color.White;
            RadioBtnTenant.Location = new Point(11, 51);
            RadioBtnTenant.Margin = new Padding(0);
            RadioBtnTenant.Name = "RadioBtnTenant";
            RadioBtnTenant.Size = new Size(324, 62);
            RadioBtnTenant.TabIndex = 5;
            RadioBtnTenant.TabStop = true;
            RadioBtnTenant.Text = "Individual Tenant";
            RadioBtnTenant.TextAlign = ContentAlignment.MiddleCenter;
            RadioBtnTenant.UseVisualStyleBackColor = false;
            // 
            // lblReferenceNumber
            // 
            lblReferenceNumber.AutoSize = true;
            lblReferenceNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReferenceNumber.ForeColor = Color.White;
            lblReferenceNumber.Location = new Point(11, 315);
            lblReferenceNumber.Name = "lblReferenceNumber";
            lblReferenceNumber.Size = new Size(189, 28);
            lblReferenceNumber.TabIndex = 1;
            lblReferenceNumber.Text = "Reference Gcash No.";
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.BackColor = Color.White;
            lblPeso.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeso.Location = new Point(35, 51);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(47, 54);
            lblPeso.TabIndex = 7;
            lblPeso.Text = "₱";
            // 
            // New_Make_Payment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(845, 541);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "New_Make_Payment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New_Make_Payment";
            Load += New_Make_Payment_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label lblPaymentTitle;
        private Label lblPaymentDescription;
        private TextBox txtAmountValue;
        private Label lblPaymentAmount;
        private ComboBox cboPaymentCategory;
        private ComboBox cboPaymentType;
        private Label lblPaymentType;
        private Label lblPaymentCategory;
        private Label lblPaymentDate;
        private DateTimePicker dtpPaymentDate;
        private RadioButton RadioBtnCash;
        private Label label8;
        private Panel panel4;
        private RadioButton RadioBtnGCash;
        private RadioButton RadioBtnTenant;
        private Button btnContinuePayment;
        private RadioButton RadioBtnRoom;
        private Button btnClear;
        private Button btnCancelPayment;
        private Label lblPaymentMethod;
        private Label lblReferenceNumber;
        private TextBox txtReferenceNumber;
        private Label lblPeso;
    }
}