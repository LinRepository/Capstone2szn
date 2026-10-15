namespace Capstoneszn.Forms.UserControls.Utilities
{
    partial class RecordElectricityExpenseForm
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
            label1 = new Label();
            label2 = new Label();
            dtpPaymentDate = new DateTimePicker();
            label3 = new Label();
            txtAmount = new TextBox();
            label4 = new Label();
            btnConfirmRecordElectricityExpense = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.ForeColor = Color.White;
            label1.Location = new Point(69, 19);
            label1.Name = "label1";
            label1.Size = new Size(306, 53);
            label1.TabIndex = 0;
            label1.Text = "This payment will create an electricity bill expense record.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(69, 99);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 0;
            label2.Text = "Date";
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Format = DateTimePickerFormat.Short;
            dtpPaymentDate.Location = new Point(69, 122);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(306, 27);
            dtpPaymentDate.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(69, 177);
            label3.Name = "label3";
            label3.Size = new Size(83, 28);
            label3.TabIndex = 0;
            label3.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.Location = new Point(69, 208);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "0.0 ";
            txtAmount.Size = new Size(306, 51);
            txtAmount.TabIndex = 2;
            txtAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(81, 217);
            label4.Name = "label4";
            label4.Size = new Size(33, 38);
            label4.TabIndex = 0;
            label4.Text = "₱";
            // 
            // btnConfirmRecordElectricityExpense
            // 
            btnConfirmRecordElectricityExpense.Location = new Point(306, 302);
            btnConfirmRecordElectricityExpense.Name = "btnConfirmRecordElectricityExpense";
            btnConfirmRecordElectricityExpense.Size = new Size(112, 43);
            btnConfirmRecordElectricityExpense.TabIndex = 3;
            btnConfirmRecordElectricityExpense.Text = "Confirm";
            btnConfirmRecordElectricityExpense.UseVisualStyleBackColor = true;
            btnConfirmRecordElectricityExpense.Click += btnConfirmRecordElectricityExpense_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(188, 302);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 43);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // RecordElectricityExpenseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(445, 366);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirmRecordElectricityExpense);
            Controls.Add(label4);
            Controls.Add(txtAmount);
            Controls.Add(dtpPaymentDate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RecordElectricityExpenseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RecordElectricityExpenseForm";
            Load += RecordElectricityExpenseForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpPaymentDate;
        private Label label3;
        private TextBox txtAmount;
        private Label label4;
        private Button btnConfirmRecordElectricityExpense;
        private Button btnCancel;
    }
}