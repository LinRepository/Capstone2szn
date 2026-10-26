namespace Capstoneszn.Forms.UserControls.Employee
{
    partial class EmployeeSalaryForm
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
            btnCancel = new Button();
            btnSave = new Button();
            txtNewSalary = new TextBox();
            lblCurrentSalary = new Label();
            lblEntertheSalaryofEmployees = new Label();
            lblPesoSign = new Label();
            lblSalaryPerPeriod = new Label();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(285, 283);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(113, 46);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(404, 283);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(113, 46);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtNewSalary
            // 
            txtNewSalary.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewSalary.Location = new Point(131, 164);
            txtNewSalary.Name = "txtNewSalary";
            txtNewSalary.Size = new Size(267, 43);
            txtNewSalary.TabIndex = 2;
            // 
            // lblCurrentSalary
            // 
            lblCurrentSalary.AutoSize = true;
            lblCurrentSalary.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentSalary.Location = new Point(114, 67);
            lblCurrentSalary.Name = "lblCurrentSalary";
            lblCurrentSalary.Size = new Size(139, 28);
            lblCurrentSalary.TabIndex = 3;
            lblCurrentSalary.Text = "Current Salary:";
            lblCurrentSalary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEntertheSalaryofEmployees
            // 
            lblEntertheSalaryofEmployees.AutoSize = true;
            lblEntertheSalaryofEmployees.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEntertheSalaryofEmployees.Location = new Point(131, 133);
            lblEntertheSalaryofEmployees.Name = "lblEntertheSalaryofEmployees";
            lblEntertheSalaryofEmployees.Size = new Size(267, 28);
            lblEntertheSalaryofEmployees.TabIndex = 3;
            lblEntertheSalaryofEmployees.Text = "Enter the salary of employees";
            // 
            // lblPesoSign
            // 
            lblPesoSign.AutoSize = true;
            lblPesoSign.BackColor = Color.White;
            lblPesoSign.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPesoSign.ForeColor = Color.Black;
            lblPesoSign.Location = new Point(131, 166);
            lblPesoSign.Name = "lblPesoSign";
            lblPesoSign.Size = new Size(41, 38);
            lblPesoSign.TabIndex = 3;
            lblPesoSign.Text = " ₱";
            lblPesoSign.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSalaryPerPeriod
            // 
            lblSalaryPerPeriod.AutoSize = true;
            lblSalaryPerPeriod.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSalaryPerPeriod.Location = new Point(259, 67);
            lblSalaryPerPeriod.Name = "lblSalaryPerPeriod";
            lblSalaryPerPeriod.Size = new Size(160, 28);
            lblSalaryPerPeriod.TabIndex = 3;
            lblSalaryPerPeriod.Text = "[SalaryPerPeriod]";
            lblSalaryPerPeriod.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EmployeeSalaryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(529, 341);
            Controls.Add(lblEntertheSalaryofEmployees);
            Controls.Add(lblPesoSign);
            Controls.Add(lblSalaryPerPeriod);
            Controls.Add(lblCurrentSalary);
            Controls.Add(txtNewSalary);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeSalaryForm";
            Text = "Salary";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancel;
        private Button btnSave;
        private TextBox txtNewSalary;
        private Label lblCurrentSalary;
        private Label lblEntertheSalaryofEmployees;
        private Label lblPesoSign;
        private Label lblSalaryPerPeriod;
    }
}