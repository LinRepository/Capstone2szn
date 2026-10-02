namespace Capstoneszn.Forms.EmployeeForms
{
    partial class EditEmployeeForm
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
            lblEditEmployeeTitle = new Label();
            txtEditFullName = new TextBox();
            lblEditFullName = new Label();
            lblEditAddress = new Label();
            txtEditAddress = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblEditEmployeeTitle
            // 
            lblEditEmployeeTitle.AutoSize = true;
            lblEditEmployeeTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditEmployeeTitle.ForeColor = Color.White;
            lblEditEmployeeTitle.Location = new Point(165, 9);
            lblEditEmployeeTitle.Name = "lblEditEmployeeTitle";
            lblEditEmployeeTitle.Size = new Size(201, 28);
            lblEditEmployeeTitle.TabIndex = 0;
            lblEditEmployeeTitle.Text = "Edit Employee Details";
            // 
            // txtEditFullName
            // 
            txtEditFullName.Location = new Point(71, 111);
            txtEditFullName.Multiline = true;
            txtEditFullName.Name = "txtEditFullName";
            txtEditFullName.Size = new Size(416, 40);
            txtEditFullName.TabIndex = 1;
            // 
            // lblEditFullName
            // 
            lblEditFullName.AutoSize = true;
            lblEditFullName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditFullName.ForeColor = Color.White;
            lblEditFullName.Location = new Point(71, 80);
            lblEditFullName.Name = "lblEditFullName";
            lblEditFullName.Size = new Size(100, 28);
            lblEditFullName.TabIndex = 0;
            lblEditFullName.Text = "Full Name";
            // 
            // lblEditAddress
            // 
            lblEditAddress.AutoSize = true;
            lblEditAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditAddress.ForeColor = Color.White;
            lblEditAddress.Location = new Point(71, 172);
            lblEditAddress.Name = "lblEditAddress";
            lblEditAddress.Size = new Size(82, 28);
            lblEditAddress.TabIndex = 0;
            lblEditAddress.Text = "Address";
            // 
            // txtEditAddress
            // 
            txtEditAddress.Location = new Point(71, 203);
            txtEditAddress.Multiline = true;
            txtEditAddress.Name = "txtEditAddress";
            txtEditAddress.Size = new Size(416, 40);
            txtEditAddress.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(339, 294);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(148, 51);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save changes";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(224, 294);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 51);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += button2_Click;
            // 
            // EditEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(548, 357);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEditAddress);
            Controls.Add(lblEditAddress);
            Controls.Add(txtEditFullName);
            Controls.Add(lblEditFullName);
            Controls.Add(lblEditEmployeeTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditEmployeeForm";
            Text = "EditEmployeeForm";
            Load += EditEmployeeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEditEmployeeTitle;
        private TextBox txtEditFullName;
        private Label lblEditFullName;
        private Label lblEditAddress;
        private TextBox txtEditAddress;
        private Button btnSave;
        private Button btnCancel;
    }
}