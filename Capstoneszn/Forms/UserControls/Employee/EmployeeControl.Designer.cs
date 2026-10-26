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
            pnlCardsContainer = new Panel();
            pnlActiveEmployee = new Panel();
            lblActiveEmployeeValue = new Label();
            lblActiveEmployee = new Label();
            pnlSpacing = new Panel();
            pnlRegisteredEmployee = new Panel();
            lblRegisteredEmployeeValue = new Label();
            lblRegisteredEmployee = new Label();
            pnlSalary = new Panel();
            btnSalary = new Button();
            pnlAddEmploye = new Panel();
            btnAddEmployee = new Button();
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
            pnlCardsContainer.SuspendLayout();
            pnlActiveEmployee.SuspendLayout();
            pnlRegisteredEmployee.SuspendLayout();
            pnlSalary.SuspendLayout();
            pnlAddEmploye.SuspendLayout();
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
            pnlEmployeeHeader.Size = new Size(1280, 69);
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
            lblEmployeeTitle.Size = new Size(1278, 67);
            lblEmployeeTitle.TabIndex = 6;
            lblEmployeeTitle.Text = "Employee";
            lblEmployeeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContentHeaderEmployee
            // 
            pnlContentHeaderEmployee.BorderStyle = BorderStyle.FixedSingle;
            pnlContentHeaderEmployee.Controls.Add(pnlCardsContainer);
            pnlContentHeaderEmployee.Controls.Add(pnlSalary);
            pnlContentHeaderEmployee.Controls.Add(pnlAddEmploye);
            pnlContentHeaderEmployee.Dock = DockStyle.Top;
            pnlContentHeaderEmployee.Location = new Point(10, 79);
            pnlContentHeaderEmployee.Name = "pnlContentHeaderEmployee";
            pnlContentHeaderEmployee.Padding = new Padding(5);
            pnlContentHeaderEmployee.Size = new Size(1280, 100);
            pnlContentHeaderEmployee.TabIndex = 10;
            // 
            // pnlCardsContainer
            // 
            pnlCardsContainer.Controls.Add(pnlActiveEmployee);
            pnlCardsContainer.Controls.Add(pnlSpacing);
            pnlCardsContainer.Controls.Add(pnlRegisteredEmployee);
            pnlCardsContainer.Dock = DockStyle.Left;
            pnlCardsContainer.Location = new Point(5, 5);
            pnlCardsContainer.Name = "pnlCardsContainer";
            pnlCardsContainer.Padding = new Padding(8);
            pnlCardsContainer.Size = new Size(616, 88);
            pnlCardsContainer.TabIndex = 6;
            // 
            // pnlActiveEmployee
            // 
            pnlActiveEmployee.BackColor = Color.FromArgb(25, 25, 100);
            pnlActiveEmployee.Controls.Add(lblActiveEmployeeValue);
            pnlActiveEmployee.Controls.Add(lblActiveEmployee);
            pnlActiveEmployee.Dock = DockStyle.Left;
            pnlActiveEmployee.Location = new Point(359, 8);
            pnlActiveEmployee.Name = "pnlActiveEmployee";
            pnlActiveEmployee.Size = new Size(247, 72);
            pnlActiveEmployee.TabIndex = 3;
            // 
            // lblActiveEmployeeValue
            // 
            lblActiveEmployeeValue.Dock = DockStyle.Fill;
            lblActiveEmployeeValue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblActiveEmployeeValue.ForeColor = Color.White;
            lblActiveEmployeeValue.ImageAlign = ContentAlignment.MiddleRight;
            lblActiveEmployeeValue.Location = new Point(175, 0);
            lblActiveEmployeeValue.Name = "lblActiveEmployeeValue";
            lblActiveEmployeeValue.Size = new Size(72, 72);
            lblActiveEmployeeValue.TabIndex = 44;
            lblActiveEmployeeValue.Text = "#";
            lblActiveEmployeeValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActiveEmployee
            // 
            lblActiveEmployee.Dock = DockStyle.Left;
            lblActiveEmployee.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblActiveEmployee.ForeColor = Color.White;
            lblActiveEmployee.ImageAlign = ContentAlignment.MiddleRight;
            lblActiveEmployee.Location = new Point(0, 0);
            lblActiveEmployee.Name = "lblActiveEmployee";
            lblActiveEmployee.Size = new Size(175, 72);
            lblActiveEmployee.TabIndex = 43;
            lblActiveEmployee.Text = "Current Active";
            lblActiveEmployee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSpacing
            // 
            pnlSpacing.Dock = DockStyle.Left;
            pnlSpacing.Location = new Point(308, 8);
            pnlSpacing.Name = "pnlSpacing";
            pnlSpacing.Size = new Size(51, 72);
            pnlSpacing.TabIndex = 1;
            // 
            // pnlRegisteredEmployee
            // 
            pnlRegisteredEmployee.BackColor = Color.FromArgb(25, 25, 100);
            pnlRegisteredEmployee.Controls.Add(lblRegisteredEmployeeValue);
            pnlRegisteredEmployee.Controls.Add(lblRegisteredEmployee);
            pnlRegisteredEmployee.Dock = DockStyle.Left;
            pnlRegisteredEmployee.Location = new Point(8, 8);
            pnlRegisteredEmployee.Name = "pnlRegisteredEmployee";
            pnlRegisteredEmployee.Size = new Size(300, 72);
            pnlRegisteredEmployee.TabIndex = 0;
            // 
            // lblRegisteredEmployeeValue
            // 
            lblRegisteredEmployeeValue.Dock = DockStyle.Fill;
            lblRegisteredEmployeeValue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblRegisteredEmployeeValue.ForeColor = Color.White;
            lblRegisteredEmployeeValue.ImageAlign = ContentAlignment.MiddleRight;
            lblRegisteredEmployeeValue.Location = new Point(228, 0);
            lblRegisteredEmployeeValue.Name = "lblRegisteredEmployeeValue";
            lblRegisteredEmployeeValue.Size = new Size(72, 72);
            lblRegisteredEmployeeValue.TabIndex = 43;
            lblRegisteredEmployeeValue.Text = "#";
            lblRegisteredEmployeeValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRegisteredEmployee
            // 
            lblRegisteredEmployee.Dock = DockStyle.Left;
            lblRegisteredEmployee.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblRegisteredEmployee.ForeColor = Color.White;
            lblRegisteredEmployee.ImageAlign = ContentAlignment.MiddleRight;
            lblRegisteredEmployee.Location = new Point(0, 0);
            lblRegisteredEmployee.Name = "lblRegisteredEmployee";
            lblRegisteredEmployee.Size = new Size(228, 72);
            lblRegisteredEmployee.TabIndex = 42;
            lblRegisteredEmployee.Text = " Total Registered Employees";
            lblRegisteredEmployee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSalary
            // 
            pnlSalary.Controls.Add(btnSalary);
            pnlSalary.Dock = DockStyle.Right;
            pnlSalary.Location = new Point(895, 5);
            pnlSalary.Name = "pnlSalary";
            pnlSalary.Padding = new Padding(10);
            pnlSalary.Size = new Size(142, 88);
            pnlSalary.TabIndex = 5;
            // 
            // btnSalary
            // 
            btnSalary.Dock = DockStyle.Fill;
            btnSalary.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalary.Location = new Point(10, 10);
            btnSalary.Name = "btnSalary";
            btnSalary.Size = new Size(122, 68);
            btnSalary.TabIndex = 0;
            btnSalary.Text = "Salary";
            btnSalary.UseVisualStyleBackColor = true;
            // 
            // pnlAddEmploye
            // 
            pnlAddEmploye.Controls.Add(btnAddEmployee);
            pnlAddEmploye.Dock = DockStyle.Right;
            pnlAddEmploye.Location = new Point(1037, 5);
            pnlAddEmploye.Name = "pnlAddEmploye";
            pnlAddEmploye.Padding = new Padding(10);
            pnlAddEmploye.Size = new Size(236, 88);
            pnlAddEmploye.TabIndex = 4;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Cursor = Cursors.Hand;
            btnAddEmployee.Dock = DockStyle.Fill;
            btnAddEmployee.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddEmployee.Location = new Point(10, 10);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(216, 68);
            btnAddEmployee.TabIndex = 2;
            btnAddEmployee.Text = "Add Employee";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // pnlEmployeeContent
            // 
            pnlEmployeeContent.BorderStyle = BorderStyle.FixedSingle;
            pnlEmployeeContent.Controls.Add(dgvEmployee);
            pnlEmployeeContent.Dock = DockStyle.Fill;
            pnlEmployeeContent.Location = new Point(10, 179);
            pnlEmployeeContent.Name = "pnlEmployeeContent";
            pnlEmployeeContent.Padding = new Padding(5);
            pnlEmployeeContent.Size = new Size(1280, 561);
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
            dgvEmployee.Size = new Size(1268, 549);
            dgvEmployee.TabIndex = 0;
            dgvEmployee.CellContentClick += dgvEmployee_CellContentClick;
            // 
            // colEmployeeID
            // 
            colEmployeeID.FillWeight = 40F;
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
            BackColor = Color.FromArgb(25, 25, 70);
            Controls.Add(pnlEmployeeContent);
            Controls.Add(pnlContentHeaderEmployee);
            Controls.Add(pnlEmployeeHeader);
            Name = "EmployeeControl";
            Padding = new Padding(10);
            Size = new Size(1300, 750);
            Load += EmployeeControl_Load;
            pnlEmployeeHeader.ResumeLayout(false);
            pnlContentHeaderEmployee.ResumeLayout(false);
            pnlCardsContainer.ResumeLayout(false);
            pnlActiveEmployee.ResumeLayout(false);
            pnlRegisteredEmployee.ResumeLayout(false);
            pnlSalary.ResumeLayout(false);
            pnlAddEmploye.ResumeLayout(false);
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
        private Panel pnlAddEmploye;
        private Panel pnlSalary;
        private Button btnSalary;
        private Panel pnlCardsContainer;
        private DataGridViewTextBoxColumn colEmployeeID;
        private DataGridViewTextBoxColumn colNameEmployee;
        private DataGridViewTextBoxColumn colAddressEmployee;
        private DataGridViewTextBoxColumn colDateHiredEmployee;
        private DataGridViewCheckBoxColumn colStatusEmployee;
        private DataGridViewButtonColumn colActionEditEmployee;
        private DataGridViewButtonColumn colActionArchiveEmployee;
    }
}
