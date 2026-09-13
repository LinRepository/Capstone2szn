namespace Capstoneszn.UserControls
{
    partial class EmployeeControl
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
            pnlEmployeeHeader = new Panel();
            lblEmployeeTitle = new Label();
            pnlContentHeaderEmployee = new Panel();
            pnlActiveEmployee = new Panel();
            lblActiveEmployeeValue = new Label();
            lblActiveEmployee = new Label();
            btnAddEmployee = new Button();
            pnlSpacing = new Panel();
            pnlRegisteredEmployee = new Panel();
            lblRegisteredEmployeeValue = new Label();
            lblRegisteredEmployee = new Label();
            pnlEmployeeContent = new Panel();
            dgvEmployee = new DataGridView();
            colEmployeeID = new DataGridViewTextBoxColumn();
            colNameEmployee = new DataGridViewTextBoxColumn();
            colAddressEmployee = new DataGridViewTextBoxColumn();
            colDateHiredEmployee = new DataGridViewTextBoxColumn();
            colStatusEmployee = new DataGridViewCheckBoxColumn();
            colActionEditEmployee = new DataGridViewButtonColumn();
            colActionArchiveEmployee = new DataGridViewButtonColumn();
            pnlEmployeeHeader.SuspendLayout();
            pnlContentHeaderEmployee.SuspendLayout();
            pnlActiveEmployee.SuspendLayout();
            pnlRegisteredEmployee.SuspendLayout();
            pnlEmployeeContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // pnlEmployeeHeader
            // 
            pnlEmployeeHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlEmployeeHeader.Controls.Add(lblEmployeeTitle);
            pnlEmployeeHeader.Dock = DockStyle.Top;
            pnlEmployeeHeader.Location = new Point(10, 10);
            pnlEmployeeHeader.Name = "pnlEmployeeHeader";
            pnlEmployeeHeader.Size = new Size(1280, 85);
            pnlEmployeeHeader.TabIndex = 9;
            // 
            // lblEmployeeTitle
            // 
            lblEmployeeTitle.Dock = DockStyle.Fill;
            lblEmployeeTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmployeeTitle.ForeColor = Color.White;
            lblEmployeeTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblEmployeeTitle.Location = new Point(0, 0);
            lblEmployeeTitle.Name = "lblEmployeeTitle";
            lblEmployeeTitle.Size = new Size(1278, 83);
            lblEmployeeTitle.TabIndex = 6;
            lblEmployeeTitle.Text = "Employee";
            lblEmployeeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContentHeaderEmployee
            // 
            pnlContentHeaderEmployee.BorderStyle = BorderStyle.FixedSingle;
            pnlContentHeaderEmployee.Controls.Add(pnlActiveEmployee);
            pnlContentHeaderEmployee.Controls.Add(btnAddEmployee);
            pnlContentHeaderEmployee.Controls.Add(pnlSpacing);
            pnlContentHeaderEmployee.Controls.Add(pnlRegisteredEmployee);
            pnlContentHeaderEmployee.Dock = DockStyle.Top;
            pnlContentHeaderEmployee.Location = new Point(10, 95);
            pnlContentHeaderEmployee.Name = "pnlContentHeaderEmployee";
            pnlContentHeaderEmployee.Padding = new Padding(5);
            pnlContentHeaderEmployee.Size = new Size(1280, 100);
            pnlContentHeaderEmployee.TabIndex = 10;
            // 
            // pnlActiveEmployee
            // 
            pnlActiveEmployee.BorderStyle = BorderStyle.FixedSingle;
            pnlActiveEmployee.Controls.Add(lblActiveEmployeeValue);
            pnlActiveEmployee.Controls.Add(lblActiveEmployee);
            pnlActiveEmployee.Dock = DockStyle.Left;
            pnlActiveEmployee.Location = new Point(380, 5);
            pnlActiveEmployee.Name = "pnlActiveEmployee";
            pnlActiveEmployee.Size = new Size(300, 88);
            pnlActiveEmployee.TabIndex = 3;
            // 
            // lblActiveEmployeeValue
            // 
            lblActiveEmployeeValue.Dock = DockStyle.Fill;
            lblActiveEmployeeValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblActiveEmployeeValue.ForeColor = Color.White;
            lblActiveEmployeeValue.ImageAlign = ContentAlignment.MiddleRight;
            lblActiveEmployeeValue.Location = new Point(190, 0);
            lblActiveEmployeeValue.Name = "lblActiveEmployeeValue";
            lblActiveEmployeeValue.Size = new Size(108, 86);
            lblActiveEmployeeValue.TabIndex = 44;
            lblActiveEmployeeValue.Text = "#";
            lblActiveEmployeeValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActiveEmployee
            // 
            lblActiveEmployee.Dock = DockStyle.Left;
            lblActiveEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblActiveEmployee.ForeColor = Color.White;
            lblActiveEmployee.ImageAlign = ContentAlignment.MiddleRight;
            lblActiveEmployee.Location = new Point(0, 0);
            lblActiveEmployee.Name = "lblActiveEmployee";
            lblActiveEmployee.Size = new Size(190, 86);
            lblActiveEmployee.TabIndex = 43;
            lblActiveEmployee.Text = "Current Active";
            lblActiveEmployee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Cursor = Cursors.Hand;
            btnAddEmployee.Dock = DockStyle.Right;
            btnAddEmployee.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddEmployee.Location = new Point(1073, 5);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(200, 88);
            btnAddEmployee.TabIndex = 2;
            btnAddEmployee.Text = "Add Employee";
            btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // pnlSpacing
            // 
            pnlSpacing.Dock = DockStyle.Left;
            pnlSpacing.Location = new Point(305, 5);
            pnlSpacing.Name = "pnlSpacing";
            pnlSpacing.Size = new Size(75, 88);
            pnlSpacing.TabIndex = 1;
            // 
            // pnlRegisteredEmployee
            // 
            pnlRegisteredEmployee.BorderStyle = BorderStyle.FixedSingle;
            pnlRegisteredEmployee.Controls.Add(lblRegisteredEmployeeValue);
            pnlRegisteredEmployee.Controls.Add(lblRegisteredEmployee);
            pnlRegisteredEmployee.Dock = DockStyle.Left;
            pnlRegisteredEmployee.Location = new Point(5, 5);
            pnlRegisteredEmployee.Name = "pnlRegisteredEmployee";
            pnlRegisteredEmployee.Size = new Size(300, 88);
            pnlRegisteredEmployee.TabIndex = 0;
            // 
            // lblRegisteredEmployeeValue
            // 
            lblRegisteredEmployeeValue.Dock = DockStyle.Fill;
            lblRegisteredEmployeeValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegisteredEmployeeValue.ForeColor = Color.White;
            lblRegisteredEmployeeValue.ImageAlign = ContentAlignment.MiddleRight;
            lblRegisteredEmployeeValue.Location = new Point(190, 0);
            lblRegisteredEmployeeValue.Name = "lblRegisteredEmployeeValue";
            lblRegisteredEmployeeValue.Size = new Size(108, 86);
            lblRegisteredEmployeeValue.TabIndex = 43;
            lblRegisteredEmployeeValue.Text = "#";
            lblRegisteredEmployeeValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRegisteredEmployee
            // 
            lblRegisteredEmployee.Dock = DockStyle.Left;
            lblRegisteredEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegisteredEmployee.ForeColor = Color.White;
            lblRegisteredEmployee.ImageAlign = ContentAlignment.MiddleRight;
            lblRegisteredEmployee.Location = new Point(0, 0);
            lblRegisteredEmployee.Name = "lblRegisteredEmployee";
            lblRegisteredEmployee.Size = new Size(190, 86);
            lblRegisteredEmployee.TabIndex = 42;
            lblRegisteredEmployee.Text = " Total Registered Employees";
            lblRegisteredEmployee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlEmployeeContent
            // 
            pnlEmployeeContent.BorderStyle = BorderStyle.FixedSingle;
            pnlEmployeeContent.Controls.Add(dgvEmployee);
            pnlEmployeeContent.Dock = DockStyle.Fill;
            pnlEmployeeContent.Location = new Point(10, 195);
            pnlEmployeeContent.Name = "pnlEmployeeContent";
            pnlEmployeeContent.Padding = new Padding(5);
            pnlEmployeeContent.Size = new Size(1280, 545);
            pnlEmployeeContent.TabIndex = 11;
            // 
            // dgvEmployee
            // 
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AllowUserToDeleteRows = false;
            dgvEmployee.AllowUserToResizeRows = false;
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Columns.AddRange(new DataGridViewColumn[] { colEmployeeID, colNameEmployee, colAddressEmployee, colDateHiredEmployee, colStatusEmployee, colActionEditEmployee, colActionArchiveEmployee });
            dgvEmployee.Dock = DockStyle.Fill;
            dgvEmployee.Location = new Point(5, 5);
            dgvEmployee.MultiSelect = false;
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.ReadOnly = true;
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.ScrollBars = ScrollBars.Vertical;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.Size = new Size(1268, 533);
            dgvEmployee.TabIndex = 0;
            // 
            // colEmployeeID
            // 
            colEmployeeID.HeaderText = "ID";
            colEmployeeID.MinimumWidth = 6;
            colEmployeeID.Name = "colEmployeeID";
            colEmployeeID.ReadOnly = true;
            // 
            // colNameEmployee
            // 
            colNameEmployee.HeaderText = "Name";
            colNameEmployee.MinimumWidth = 6;
            colNameEmployee.Name = "colNameEmployee";
            colNameEmployee.ReadOnly = true;
            // 
            // colAddressEmployee
            // 
            colAddressEmployee.HeaderText = "Address";
            colAddressEmployee.MinimumWidth = 6;
            colAddressEmployee.Name = "colAddressEmployee";
            colAddressEmployee.ReadOnly = true;
            // 
            // colDateHiredEmployee
            // 
            colDateHiredEmployee.HeaderText = "DateHired";
            colDateHiredEmployee.MinimumWidth = 6;
            colDateHiredEmployee.Name = "colDateHiredEmployee";
            colDateHiredEmployee.ReadOnly = true;
            // 
            // colStatusEmployee
            // 
            colStatusEmployee.HeaderText = "Status";
            colStatusEmployee.MinimumWidth = 6;
            colStatusEmployee.Name = "colStatusEmployee";
            colStatusEmployee.ReadOnly = true;
            // 
            // colActionEditEmployee
            // 
            colActionEditEmployee.HeaderText = "Edit";
            colActionEditEmployee.MinimumWidth = 6;
            colActionEditEmployee.Name = "colActionEditEmployee";
            colActionEditEmployee.ReadOnly = true;
            // 
            // colActionArchiveEmployee
            // 
            colActionArchiveEmployee.HeaderText = "Archive";
            colActionArchiveEmployee.MinimumWidth = 6;
            colActionArchiveEmployee.Name = "colActionArchiveEmployee";
            colActionArchiveEmployee.ReadOnly = true;
            // 
            // EmployeeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlEmployeeContent);
            Controls.Add(pnlContentHeaderEmployee);
            Controls.Add(pnlEmployeeHeader);
            Name = "EmployeeControl";
            Padding = new Padding(10);
            Size = new Size(1300, 750);
            pnlEmployeeHeader.ResumeLayout(false);
            pnlContentHeaderEmployee.ResumeLayout(false);
            pnlActiveEmployee.ResumeLayout(false);
            pnlRegisteredEmployee.ResumeLayout(false);
            pnlEmployeeContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlEmployeeHeader;
        private Label lblEmployeeTitle;
        private Panel pnlContentHeaderEmployee;
        private Button btnAddEmployee;
        private Panel pnlSpacing;
        private Panel pnlRegisteredEmployee;
        private Panel pnlActiveEmployee;
        private Label lblRegisteredEmployee;
        private Label lblActiveEmployee;
        private Label lblRegisteredEmployeeValue;
        private Label lblActiveEmployeeValue;
        private Panel pnlEmployeeContent;
        private DataGridView dgvEmployee;
        private DataGridViewTextBoxColumn colEmployeeID;
        private DataGridViewTextBoxColumn colNameEmployee;
        private DataGridViewTextBoxColumn colAddressEmployee;
        private DataGridViewTextBoxColumn colDateHiredEmployee;
        private DataGridViewCheckBoxColumn colStatusEmployee;
        private DataGridViewButtonColumn colActionEditEmployee;
        private DataGridViewButtonColumn colActionArchiveEmployee;
    }
}
