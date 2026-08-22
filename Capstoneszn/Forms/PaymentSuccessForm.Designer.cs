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
            panel1 = new Panel();
            lblConfirmationTitle = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            btnPrintReceipt = new Button();
            btnAnotherTransaction = new Button();
            btnClose = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblConfirmationTitle);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 60);
            panel1.TabIndex = 0;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(64, 28);
            label1.Name = "label1";
            label1.Size = new Size(368, 25);
            label1.TabIndex = 6;
            label1.Text = "The payment has been recorded successfully.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnClose);
            panel2.Controls.Add(btnAnotherTransaction);
            panel2.Controls.Add(btnPrintReceipt);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 323);
            panel2.Name = "panel2";
            panel2.Size = new Size(482, 80);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 60);
            panel3.Name = "panel3";
            panel3.Size = new Size(482, 263);
            panel3.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.ImageAlign = ContentAlignment.MiddleRight;
            label2.Location = new Point(112, 112);
            label2.Name = "label2";
            label2.Size = new Size(149, 25);
            label2.TabIndex = 7;
            label2.Text = "Confirm Payment";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Location = new Point(12, 27);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(125, 29);
            btnPrintReceipt.TabIndex = 0;
            btnPrintReceipt.Text = "Print Receipt";
            btnPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // btnAnotherTransaction
            // 
            btnAnotherTransaction.Location = new Point(146, 27);
            btnAnotherTransaction.Name = "btnAnotherTransaction";
            btnAnotherTransaction.Size = new Size(220, 29);
            btnAnotherTransaction.TabIndex = 1;
            btnAnotherTransaction.Text = "Make Another Transaction";
            btnAnotherTransaction.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(376, 27);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // PaymentSuccessForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 403);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentSuccessForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Payment Successful";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label lblConfirmationTitle;
        private Label label1;
        private Label label2;
        private Button btnClose;
        private Button btnAnotherTransaction;
        private Button btnPrintReceipt;
    }
}