namespace Capstoneszn.Forms.UtilityForms
{
    partial class EditElectricityAdmin
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
            label1 = new Label();
            txtAdminAccountName = new TextBox();
            label2 = new Label();
            txtAdminAccountNumber = new TextBox();
            label3 = new Label();
            txtAdminAmount = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(123, 12);
            label1.Name = "label1";
            label1.Size = new Size(141, 28);
            label1.TabIndex = 0;
            label1.Text = "Account Name";
            // 
            // txtAdminAccountName
            // 
            txtAdminAccountName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdminAccountName.Location = new Point(123, 43);
            txtAdminAccountName.Name = "txtAdminAccountName";
            txtAdminAccountName.Size = new Size(244, 34);
            txtAdminAccountName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(123, 93);
            label2.Name = "label2";
            label2.Size = new Size(161, 28);
            label2.TabIndex = 0;
            label2.Text = "Account Number";
            // 
            // txtAdminAccountNumber
            // 
            txtAdminAccountNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdminAccountNumber.Location = new Point(123, 124);
            txtAdminAccountNumber.Name = "txtAdminAccountNumber";
            txtAdminAccountNumber.Size = new Size(244, 34);
            txtAdminAccountNumber.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(123, 184);
            label3.Name = "label3";
            label3.Size = new Size(83, 28);
            label3.TabIndex = 0;
            label3.Text = "Amount";
            // 
            // txtAdminAmount
            // 
            txtAdminAmount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAdminAmount.Location = new Point(123, 215);
            txtAdminAmount.Name = "txtAdminAmount";
            txtAdminAmount.Size = new Size(244, 34);
            txtAdminAmount.TabIndex = 1;
            // 
            // EditElectricityAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(txtAdminAmount);
            Controls.Add(label3);
            Controls.Add(txtAdminAccountNumber);
            Controls.Add(label2);
            Controls.Add(txtAdminAccountName);
            Controls.Add(label1);
            Name = "EditElectricityAdmin";
            Size = new Size(517, 268);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAdminAccountName;
        private Label label2;
        private TextBox txtAdminAccountNumber;
        private Label label3;
        private TextBox txtAdminAmount;
    }
}
