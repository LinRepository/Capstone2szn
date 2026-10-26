namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class EditWaterAccount
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
            label4 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            lblCurrentName = new Label();
            lblCurrentNumber = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            label5 = new Label();
            label8 = new Label();
            txtNewName = new TextBox();
            txtNewNumber = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(219, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 28);
            label1.TabIndex = 0;
            label1.Text = "Current:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(203, 177);
            label4.Name = "label4";
            label4.Size = new Size(106, 28);
            label4.TabIndex = 0;
            label4.Text = "Change to:";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(390, 345);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 43);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(277, 345);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 43);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(lblCurrentName, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCurrentNumber, 1, 1);
            tableLayoutPanel1.Location = new Point(12, 40);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(485, 90);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(236, 45);
            label2.TabIndex = 0;
            label2.Text = "Account name:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 45);
            label3.Name = "label3";
            label3.Size = new Size(236, 45);
            label3.TabIndex = 0;
            label3.Text = "Account number:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
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
            lblCurrentName.TabIndex = 0;
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
            lblCurrentNumber.TabIndex = 0;
            lblCurrentNumber.Text = "Not set yet";
            lblCurrentNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Controls.Add(label8, 0, 1);
            tableLayoutPanel2.Controls.Add(txtNewName, 1, 0);
            tableLayoutPanel2.Controls.Add(txtNewNumber, 1, 1);
            tableLayoutPanel2.Location = new Point(12, 208);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(485, 90);
            tableLayoutPanel2.TabIndex = 6;
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
            label5.TabIndex = 0;
            label5.Text = "Account name:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 45);
            label8.Name = "label8";
            label8.Size = new Size(236, 45);
            label8.TabIndex = 0;
            label8.Text = "Account number:";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNewName
            // 
            txtNewName.Dock = DockStyle.Fill;
            txtNewName.Font = new Font("Segoe UI", 12F);
            txtNewName.Location = new Point(245, 3);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(237, 34);
            txtNewName.TabIndex = 1;
            // 
            // txtNewNumber
            // 
            txtNewNumber.Dock = DockStyle.Fill;
            txtNewNumber.Font = new Font("Segoe UI", 12F);
            txtNewNumber.Location = new Point(245, 48);
            txtNewNumber.Name = "txtNewNumber";
            txtNewNumber.Size = new Size(237, 34);
            txtNewNumber.TabIndex = 1;
            // 
            // EditWaterAccount
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            CancelButton = btnCancel;
            ClientSize = new Size(509, 400);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditWaterAccount";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Water Account";
            Load += EditWaterAccount_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        private Button btnSave;
        private Button btnCancel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label3;
        private Label lblCurrentName;
        private Label lblCurrentNumber;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private Label label8;
        private TextBox txtNewName;
        private TextBox txtNewNumber;
    }
}