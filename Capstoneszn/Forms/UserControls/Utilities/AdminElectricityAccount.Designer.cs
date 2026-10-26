namespace Capstoneszn.Forms.UserControls.Utilities
{
    partial class AdminElectricityAccount
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
            panel1 = new Panel();
            panel12 = new Panel();
            panel10 = new Panel();
            panel14 = new Panel();
            lblStatus = new Label();
            panel13 = new Panel();
            label7 = new Label();
            panel11 = new Panel();
            btnRecordExpenses = new Button();
            panel5 = new Panel();
            txtAmount = new TextBox();
            panel9 = new Panel();
            label3 = new Label();
            panel7 = new Panel();
            panel8 = new Panel();
            lblAccountNumber = new Label();
            panel4 = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            panel3 = new Panel();
            lblAccountName = new Label();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            panel14.SuspendLayout();
            panel13.SuspendLayout();
            panel11.SuspendLayout();
            panel5.SuspendLayout();
            panel9.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel12);
            panel1.Controls.Add(panel10);
            panel1.Controls.Add(panel11);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1535, 91);
            panel1.TabIndex = 0;
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(1200, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(85, 91);
            panel12.TabIndex = 7;
            // 
            // panel10
            // 
            panel10.Controls.Add(panel14);
            panel10.Controls.Add(panel13);
            panel10.Dock = DockStyle.Left;
            panel10.Location = new Point(900, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(300, 91);
            panel10.TabIndex = 6;
            // 
            // panel14
            // 
            panel14.Controls.Add(lblStatus);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(0, 45);
            panel14.Name = "panel14";
            panel14.Size = new Size(300, 46);
            panel14.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(136, 13);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(18, 23);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "?";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            panel13.Controls.Add(label7);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(300, 45);
            panel13.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(125, 12);
            label7.Name = "label7";
            label7.Size = new Size(56, 23);
            label7.TabIndex = 1;
            label7.Text = "Status";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            panel11.Controls.Add(btnRecordExpenses);
            panel11.Dock = DockStyle.Right;
            panel11.Location = new Point(1285, 0);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(10);
            panel11.Size = new Size(250, 91);
            panel11.TabIndex = 6;
            // 
            // btnRecordExpenses
            // 
            btnRecordExpenses.BackColor = Color.White;
            btnRecordExpenses.Dock = DockStyle.Fill;
            btnRecordExpenses.FlatStyle = FlatStyle.Flat;
            btnRecordExpenses.Location = new Point(10, 10);
            btnRecordExpenses.Name = "btnRecordExpenses";
            btnRecordExpenses.Size = new Size(230, 71);
            btnRecordExpenses.TabIndex = 1;
            btnRecordExpenses.Text = "Record Expense";
            btnRecordExpenses.UseVisualStyleBackColor = false;
            btnRecordExpenses.Click += btnRecordExpenses_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtAmount);
            panel5.Controls.Add(panel9);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(600, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(300, 91);
            panel5.TabIndex = 3;
            // 
            // txtAmount
            // 
            txtAmount.BackColor = Color.FromArgb(25, 25, 70);
            txtAmount.BorderStyle = BorderStyle.None;
            txtAmount.Dock = DockStyle.Fill;
            txtAmount.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = Color.White;
            txtAmount.Location = new Point(0, 45);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "Enter amount";
            txtAmount.Size = new Size(300, 36);
            txtAmount.TabIndex = 3;
            txtAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // panel9
            // 
            panel9.Controls.Add(label3);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(300, 45);
            panel9.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(121, 12);
            label3.Name = "label3";
            label3.Size = new Size(72, 23);
            label3.TabIndex = 1;
            label3.Text = "Amount";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(panel4);
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(300, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(300, 91);
            panel7.TabIndex = 5;
            // 
            // panel8
            // 
            panel8.Controls.Add(lblAccountNumber);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 45);
            panel8.Name = "panel8";
            panel8.Size = new Size(300, 46);
            panel8.TabIndex = 3;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountNumber.ForeColor = Color.White;
            lblAccountNumber.Location = new Point(133, 12);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(18, 23);
            lblAccountNumber.TabIndex = 1;
            lblAccountNumber.Text = "?";
            lblAccountNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 45);
            panel4.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(77, 12);
            label2.Name = "label2";
            label2.Size = new Size(141, 23);
            label2.TabIndex = 1;
            label2.Text = "Account Number";
            // 
            // panel6
            // 
            panel6.Controls.Add(panel3);
            panel6.Controls.Add(panel2);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(300, 91);
            panel6.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblAccountName);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 45);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 46);
            panel3.TabIndex = 2;
            // 
            // lblAccountName
            // 
            lblAccountName.AutoSize = true;
            lblAccountName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountName.ForeColor = Color.White;
            lblAccountName.Location = new Point(136, 12);
            lblAccountName.Name = "lblAccountName";
            lblAccountName.Size = new Size(18, 23);
            lblAccountName.TabIndex = 1;
            lblAccountName.Text = "?";
            lblAccountName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 45);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(93, 12);
            label1.Name = "label1";
            label1.Size = new Size(124, 23);
            label1.TabIndex = 0;
            label1.Text = "Account Name";
            // 
            // AdminElectricityAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            Controls.Add(panel1);
            Name = "AdminElectricityAccount";
            Size = new Size(1535, 91);
            Load += AdminElectricityAccount_Load;
            panel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel11.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private Panel panel5;
        private Panel panel7;
        private Panel panel6;
        private Panel panel3;
        private Label lblAccountName;
        private Panel panel2;
        private Label label2;
        private Button btnRecordExpenses;
        private Panel panel11;
        private Panel panel10;
        private Panel panel9;
        private Panel panel8;
        private Label lblAccountNumber;
        private Panel panel4;
        private Panel panel12;
        private Panel panel14;
        private Label lblStatus;
        private Panel panel13;
        private Label label7;
        private TextBox txtAmount;
    }
}
