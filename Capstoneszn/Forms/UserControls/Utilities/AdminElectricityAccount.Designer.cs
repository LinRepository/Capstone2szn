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
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label3 = new Label();
            txtAmount = new TextBox();
            lblAccountNumber = new Label();
            lblStatus = new Label();
            lblAccountName = new Label();
            label2 = new Label();
            label7 = new Label();
            panel11 = new Panel();
            btnRecordExpenses = new Button();
            panel6 = new Panel();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel11.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel11);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(221, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1314, 60);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1101, 60);
            panel2.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 303F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 199F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(txtAmount, 2, 1);
            tableLayoutPanel1.Controls.Add(lblAccountNumber, 1, 1);
            tableLayoutPanel1.Controls.Add(lblStatus, 3, 1);
            tableLayoutPanel1.Controls.Add(lblAccountName, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label7, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1101, 60);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(291, 28);
            label1.TabIndex = 0;
            label1.Text = "Account Name";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(600, 1);
            label3.Name = "label3";
            label3.Size = new Size(297, 28);
            label3.TabIndex = 1;
            label3.Text = "Amount";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAmount
            // 
            txtAmount.BorderStyle = BorderStyle.FixedSingle;
            txtAmount.Dock = DockStyle.Fill;
            txtAmount.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = Color.Black;
            txtAmount.Location = new Point(600, 33);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "Enter amount";
            txtAmount.Size = new Size(297, 31);
            txtAmount.TabIndex = 3;
            txtAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Dock = DockStyle.Fill;
            lblAccountNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountNumber.ForeColor = Color.Black;
            lblAccountNumber.Location = new Point(302, 30);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(291, 29);
            lblAccountNumber.TabIndex = 1;
            lblAccountNumber.Text = "?";
            lblAccountNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(904, 30);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(193, 29);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "?";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAccountName
            // 
            lblAccountName.AutoSize = true;
            lblAccountName.Dock = DockStyle.Fill;
            lblAccountName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountName.ForeColor = Color.Black;
            lblAccountName.Location = new Point(4, 30);
            lblAccountName.Name = "lblAccountName";
            lblAccountName.Size = new Size(291, 29);
            lblAccountName.TabIndex = 1;
            lblAccountName.Text = "?";
            lblAccountName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(302, 1);
            label2.Name = "label2";
            label2.Size = new Size(291, 28);
            label2.TabIndex = 1;
            label2.Text = "Account Number";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(904, 1);
            label7.Name = "label7";
            label7.Size = new Size(193, 28);
            label7.TabIndex = 1;
            label7.Text = "Status";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            panel11.Controls.Add(btnRecordExpenses);
            panel11.Dock = DockStyle.Right;
            panel11.Location = new Point(1101, 0);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(8);
            panel11.Size = new Size(213, 60);
            panel11.TabIndex = 6;
            // 
            // btnRecordExpenses
            // 
            btnRecordExpenses.BackColor = Color.White;
            btnRecordExpenses.Dock = DockStyle.Fill;
            btnRecordExpenses.FlatStyle = FlatStyle.Flat;
            btnRecordExpenses.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRecordExpenses.Location = new Point(8, 8);
            btnRecordExpenses.Name = "btnRecordExpenses";
            btnRecordExpenses.Size = new Size(197, 44);
            btnRecordExpenses.TabIndex = 1;
            btnRecordExpenses.Text = "Record Expense";
            btnRecordExpenses.UseVisualStyleBackColor = false;
            btnRecordExpenses.Click += btnRecordExpenses_Click;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(label4);
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(221, 60);
            panel6.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(31, 18);
            label4.Name = "label4";
            label4.Size = new Size(134, 23);
            label4.TabIndex = 0;
            label4.Text = "Admin Account";
            // 
            // AdminElectricityAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(panel6);
            Name = "AdminElectricityAccount";
            Size = new Size(1535, 60);
            Load += AdminElectricityAccount_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel11.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private Panel panel6;
        private Label lblAccountName;
        private Label label2;
        private Button btnRecordExpenses;
        private Panel panel11;
        private Label lblAccountNumber;
        private Label lblStatus;
        private Label label7;
        private TextBox txtAmount;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
    }
}
