namespace Capstoneszn.Forms.EmployeeForms
{
    partial class AddEmployeeForm
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
            txtAddFullName = new TextBox();
            AddEmployeeContent = new Panel();
            btnCancel = new Button();
            btnAdd = new Button();
            dtpDate = new DateTimePicker();
            lblAddEmployeeTitle = new Label();
            txtAddPassword = new TextBox();
            txtAddUsername = new TextBox();
            txtAddAddress = new TextBox();
            lblAddDateHired = new Label();
            lblAddPassword = new Label();
            lblAddUsername = new Label();
            lblAddAddress = new Label();
            lblAddFullName = new Label();
            AddEmployeeContent.SuspendLayout();
            SuspendLayout();
            // 
            // txtAddFullName
            // 
            txtAddFullName.Cursor = Cursors.IBeam;
            txtAddFullName.Font = new Font("Segoe UI", 12F);
            txtAddFullName.Location = new Point(66, 127);
            txtAddFullName.Multiline = true;
            txtAddFullName.Name = "txtAddFullName";
            txtAddFullName.Size = new Size(416, 40);
            txtAddFullName.TabIndex = 0;
            // 
            // AddEmployeeContent
            // 
            AddEmployeeContent.Controls.Add(btnCancel);
            AddEmployeeContent.Controls.Add(btnAdd);
            AddEmployeeContent.Controls.Add(dtpDate);
            AddEmployeeContent.Controls.Add(lblAddEmployeeTitle);
            AddEmployeeContent.Controls.Add(txtAddPassword);
            AddEmployeeContent.Controls.Add(txtAddUsername);
            AddEmployeeContent.Controls.Add(txtAddAddress);
            AddEmployeeContent.Controls.Add(lblAddDateHired);
            AddEmployeeContent.Controls.Add(lblAddPassword);
            AddEmployeeContent.Controls.Add(lblAddUsername);
            AddEmployeeContent.Controls.Add(lblAddAddress);
            AddEmployeeContent.Controls.Add(txtAddFullName);
            AddEmployeeContent.Controls.Add(lblAddFullName);
            AddEmployeeContent.Dock = DockStyle.Fill;
            AddEmployeeContent.Location = new Point(0, 0);
            AddEmployeeContent.Name = "AddEmployeeContent";
            AddEmployeeContent.Padding = new Padding(20);
            AddEmployeeContent.Size = new Size(548, 632);
            AddEmployeeContent.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.Location = new Point(238, 566);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(119, 43);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += button2_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F);
            btnAdd.Location = new Point(363, 566);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(119, 43);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            dtpDate.Enabled = false;
            dtpDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.Location = new Point(66, 311);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(416, 34);
            dtpDate.TabIndex = 3;
            // 
            // lblAddEmployeeTitle
            // 
            lblAddEmployeeTitle.AutoSize = true;
            lblAddEmployeeTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddEmployeeTitle.ForeColor = Color.White;
            lblAddEmployeeTitle.Location = new Point(66, 20);
            lblAddEmployeeTitle.Name = "lblAddEmployeeTitle";
            lblAddEmployeeTitle.Size = new Size(388, 38);
            lblAddEmployeeTitle.TabIndex = 2;
            lblAddEmployeeTitle.Text = "Fill this form to add employee";
            // 
            // txtAddPassword
            // 
            txtAddPassword.Font = new Font("Segoe UI", 12F);
            txtAddPassword.Location = new Point(66, 492);
            txtAddPassword.Multiline = true;
            txtAddPassword.Name = "txtAddPassword";
            txtAddPassword.ReadOnly = true;
            txtAddPassword.Size = new Size(416, 40);
            txtAddPassword.TabIndex = 0;
            // 
            // txtAddUsername
            // 
            txtAddUsername.Font = new Font("Segoe UI", 12F);
            txtAddUsername.Location = new Point(66, 397);
            txtAddUsername.Multiline = true;
            txtAddUsername.Name = "txtAddUsername";
            txtAddUsername.PlaceholderText = " @Employee1";
            txtAddUsername.Size = new Size(416, 40);
            txtAddUsername.TabIndex = 0;
            // 
            // txtAddAddress
            // 
            txtAddAddress.Cursor = Cursors.IBeam;
            txtAddAddress.Font = new Font("Segoe UI", 12F);
            txtAddAddress.Location = new Point(66, 219);
            txtAddAddress.Multiline = true;
            txtAddAddress.Name = "txtAddAddress";
            txtAddAddress.Size = new Size(416, 40);
            txtAddAddress.TabIndex = 0;
            // 
            // lblAddDateHired
            // 
            lblAddDateHired.AutoSize = true;
            lblAddDateHired.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddDateHired.ForeColor = Color.White;
            lblAddDateHired.Location = new Point(66, 280);
            lblAddDateHired.Name = "lblAddDateHired";
            lblAddDateHired.Size = new Size(106, 28);
            lblAddDateHired.TabIndex = 1;
            lblAddDateHired.Text = "Date Hired";
            // 
            // lblAddPassword
            // 
            lblAddPassword.AutoSize = true;
            lblAddPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddPassword.ForeColor = Color.White;
            lblAddPassword.Location = new Point(66, 461);
            lblAddPassword.Name = "lblAddPassword";
            lblAddPassword.Size = new Size(93, 28);
            lblAddPassword.TabIndex = 1;
            lblAddPassword.Text = "Password";
            // 
            // lblAddUsername
            // 
            lblAddUsername.AutoSize = true;
            lblAddUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddUsername.ForeColor = Color.White;
            lblAddUsername.Location = new Point(66, 368);
            lblAddUsername.Name = "lblAddUsername";
            lblAddUsername.Size = new Size(99, 28);
            lblAddUsername.TabIndex = 1;
            lblAddUsername.Text = "Username";
            // 
            // lblAddAddress
            // 
            lblAddAddress.AutoSize = true;
            lblAddAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddAddress.ForeColor = Color.White;
            lblAddAddress.Location = new Point(66, 188);
            lblAddAddress.Name = "lblAddAddress";
            lblAddAddress.Size = new Size(82, 28);
            lblAddAddress.TabIndex = 1;
            lblAddAddress.Text = "Address";
            // 
            // lblAddFullName
            // 
            lblAddFullName.AutoSize = true;
            lblAddFullName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddFullName.ForeColor = Color.White;
            lblAddFullName.Location = new Point(66, 96);
            lblAddFullName.Name = "lblAddFullName";
            lblAddFullName.Size = new Size(100, 28);
            lblAddFullName.TabIndex = 1;
            lblAddFullName.Text = "Full Name";
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(548, 632);
            Controls.Add(AddEmployeeContent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEmployeeForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddEmployeeForm";
            Load += AddEmployeeForm_Load;
            AddEmployeeContent.ResumeLayout(false);
            AddEmployeeContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtAddFullName;
        private Panel AddEmployeeContent;
        private Label lblAddFullName;
        private TextBox txtAddAddress;
        private Label lblAddAddress;
        private Label lblAddEmployeeTitle;
        private DateTimePicker dtpDate;
        private TextBox txtAddPassword;
        private Label lblAddDateHired;
        private Label lblAddPassword;
        private Button btnCancel;
        private Button btnAdd;
        private TextBox txtAddUsername;
        private Label lblAddUsername;
    }
}