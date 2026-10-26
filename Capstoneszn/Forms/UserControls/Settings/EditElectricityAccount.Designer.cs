namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class EditElectricityAccount
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
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            lblCurrentName = new Label();
            lblCurrentNumber = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            label5 = new Label();
            label6 = new Label();
            txtNewName = new TextBox();
            txtNewNumber = new TextBox();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.Location = new Point(389, 345);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(108, 43);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.Location = new Point(275, 345);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 43);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(219, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 28);
            label1.TabIndex = 1;
            label1.Text = "Current:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(lblCurrentName, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCurrentNumber, 1, 1);
            tableLayoutPanel1.Location = new Point(12, 40);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(485, 90);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(236, 45);
            label3.TabIndex = 1;
            label3.Text = "Account name:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 45);
            label4.Name = "label4";
            label4.Size = new Size(236, 45);
            label4.TabIndex = 1;
            label4.Text = "Account number:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentName
            // 
            lblCurrentName.AutoSize = true;
            lblCurrentName.Dock = DockStyle.Fill;
            lblCurrentName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentName.ForeColor = Color.White;
            lblCurrentName.Location = new Point(245, 0);
            lblCurrentName.Name = "lblCurrentName";
            lblCurrentName.Size = new Size(237, 45);
            lblCurrentName.TabIndex = 1;
            lblCurrentName.Text = "Not set yet";
            lblCurrentName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentNumber
            // 
            lblCurrentNumber.AutoSize = true;
            lblCurrentNumber.Dock = DockStyle.Fill;
            lblCurrentNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentNumber.ForeColor = Color.White;
            lblCurrentNumber.Location = new Point(245, 45);
            lblCurrentNumber.Name = "lblCurrentNumber";
            lblCurrentNumber.Size = new Size(237, 45);
            lblCurrentNumber.TabIndex = 1;
            lblCurrentNumber.Text = "Not set yet";
            lblCurrentNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Controls.Add(label6, 0, 1);
            tableLayoutPanel2.Controls.Add(txtNewName, 1, 0);
            tableLayoutPanel2.Controls.Add(txtNewNumber, 1, 1);
            tableLayoutPanel2.Location = new Point(12, 208);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(485, 90);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(236, 45);
            label5.TabIndex = 1;
            label5.Text = "Account name:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 45);
            label6.Name = "label6";
            label6.Size = new Size(236, 45);
            label6.TabIndex = 1;
            label6.Text = "Account number:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNewName
            // 
            txtNewName.Dock = DockStyle.Fill;
            txtNewName.Font = new Font("Segoe UI", 12F);
            txtNewName.Location = new Point(245, 3);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(237, 34);
            txtNewName.TabIndex = 2;
            // 
            // txtNewNumber
            // 
            txtNewNumber.Dock = DockStyle.Fill;
            txtNewNumber.Font = new Font("Segoe UI", 12F);
            txtNewNumber.Location = new Point(245, 48);
            txtNewNumber.Name = "txtNewNumber";
            txtNewNumber.Size = new Size(237, 34);
            txtNewNumber.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(203, 177);
            label2.Name = "label2";
            label2.Size = new Size(106, 28);
            label2.TabIndex = 1;
            label2.Text = "Change to:";
            // 
            // EditElectricityAccount
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            CancelButton = btnCancel;
            ClientSize = new Size(509, 400);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditElectricityAccount";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Electricity Account";
            Load += EditElectricityAccount_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label4;
        private Label lblCurrentName;
        private Label lblCurrentNumber;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private Label label6;
        private TextBox txtNewName;
        private TextBox txtNewNumber;
        private Label label2;
    }
}