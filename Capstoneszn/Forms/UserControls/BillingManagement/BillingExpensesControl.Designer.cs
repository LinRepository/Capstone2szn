namespace Capstoneszn.Forms.UserControls.BillingManagement
{
    partial class BillingExpensesControl
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
            pnlExpensesHeader = new Panel();
            pnlExpenseFilters = new Panel();
            pnlExpensesContent = new Panel();
            btnBackExpenses = new Button();
            lblExpensesTitle = new Label();
            btnAllExpenses = new Button();
            btnMaintenanceExpenses = new Button();
            btnUtilitiesExpenses = new Button();
            dgvExpenses = new DataGridView();
            colExpenseDate = new DataGridViewTextBoxColumn();
            colExpenseDescription = new DataGridViewTextBoxColumn();
            colExpenseAmount = new DataGridViewTextBoxColumn();
            pnlExpensesHeader.SuspendLayout();
            pnlExpenseFilters.SuspendLayout();
            pnlExpensesContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            // 
            // pnlExpensesHeader
            // 
            pnlExpensesHeader.Controls.Add(lblExpensesTitle);
            pnlExpensesHeader.Controls.Add(btnBackExpenses);
            pnlExpensesHeader.Dock = DockStyle.Top;
            pnlExpensesHeader.Location = new Point(0, 0);
            pnlExpensesHeader.Name = "pnlExpensesHeader";
            pnlExpensesHeader.Size = new Size(1300, 90);
            pnlExpensesHeader.TabIndex = 0;
            // 
            // pnlExpenseFilters
            // 
            pnlExpenseFilters.Controls.Add(btnUtilitiesExpenses);
            pnlExpenseFilters.Controls.Add(btnMaintenanceExpenses);
            pnlExpenseFilters.Controls.Add(btnAllExpenses);
            pnlExpenseFilters.Dock = DockStyle.Top;
            pnlExpenseFilters.Location = new Point(0, 90);
            pnlExpenseFilters.Name = "pnlExpenseFilters";
            pnlExpenseFilters.Padding = new Padding(10);
            pnlExpenseFilters.Size = new Size(1300, 65);
            pnlExpenseFilters.TabIndex = 1;
            // 
            // pnlExpensesContent
            // 
            pnlExpensesContent.Controls.Add(dgvExpenses);
            pnlExpensesContent.Dock = DockStyle.Fill;
            pnlExpensesContent.Location = new Point(0, 155);
            pnlExpensesContent.Name = "pnlExpensesContent";
            pnlExpensesContent.Size = new Size(1300, 595);
            pnlExpensesContent.TabIndex = 2;
            // 
            // btnBackExpenses
            // 
            btnBackExpenses.Dock = DockStyle.Left;
            btnBackExpenses.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackExpenses.Location = new Point(0, 0);
            btnBackExpenses.Margin = new Padding(0);
            btnBackExpenses.Name = "btnBackExpenses";
            btnBackExpenses.Size = new Size(140, 90);
            btnBackExpenses.TabIndex = 2;
            btnBackExpenses.Text = "←";
            btnBackExpenses.TextAlign = ContentAlignment.TopCenter;
            btnBackExpenses.UseVisualStyleBackColor = true;
            // 
            // lblExpensesTitle
            // 
            lblExpensesTitle.Dock = DockStyle.Fill;
            lblExpensesTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpensesTitle.ForeColor = Color.White;
            lblExpensesTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblExpensesTitle.Location = new Point(140, 0);
            lblExpensesTitle.Name = "lblExpensesTitle";
            lblExpensesTitle.Size = new Size(1160, 90);
            lblExpensesTitle.TabIndex = 7;
            lblExpensesTitle.Text = "Expenses";
            lblExpensesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAllExpenses
            // 
            btnAllExpenses.Dock = DockStyle.Left;
            btnAllExpenses.Location = new Point(10, 10);
            btnAllExpenses.Name = "btnAllExpenses";
            btnAllExpenses.Size = new Size(150, 45);
            btnAllExpenses.TabIndex = 0;
            btnAllExpenses.Text = "ALL";
            btnAllExpenses.UseVisualStyleBackColor = true;
            // 
            // btnMaintenanceExpenses
            // 
            btnMaintenanceExpenses.Dock = DockStyle.Left;
            btnMaintenanceExpenses.Location = new Point(160, 10);
            btnMaintenanceExpenses.Name = "btnMaintenanceExpenses";
            btnMaintenanceExpenses.Size = new Size(150, 45);
            btnMaintenanceExpenses.TabIndex = 1;
            btnMaintenanceExpenses.Text = "Maintenance";
            btnMaintenanceExpenses.UseVisualStyleBackColor = true;
            // 
            // btnUtilitiesExpenses
            // 
            btnUtilitiesExpenses.Dock = DockStyle.Left;
            btnUtilitiesExpenses.Location = new Point(310, 10);
            btnUtilitiesExpenses.Name = "btnUtilitiesExpenses";
            btnUtilitiesExpenses.Size = new Size(150, 45);
            btnUtilitiesExpenses.TabIndex = 2;
            btnUtilitiesExpenses.Text = "Utilities";
            btnUtilitiesExpenses.UseVisualStyleBackColor = true;
            // 
            // dgvExpenses
            // 
            dgvExpenses.AllowUserToAddRows = false;
            dgvExpenses.AllowUserToDeleteRows = false;
            dgvExpenses.AllowUserToResizeRows = false;
            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Columns.AddRange(new DataGridViewColumn[] { colExpenseDate, colExpenseDescription, colExpenseAmount });
            dgvExpenses.Dock = DockStyle.Fill;
            dgvExpenses.Location = new Point(0, 0);
            dgvExpenses.MultiSelect = false;
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.ReadOnly = true;
            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.RowHeadersWidth = 51;
            dgvExpenses.ScrollBars = ScrollBars.Vertical;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.Size = new Size(1300, 595);
            dgvExpenses.TabIndex = 0;
            // 
            // colExpenseDate
            // 
            colExpenseDate.HeaderText = "Date";
            colExpenseDate.MinimumWidth = 6;
            colExpenseDate.Name = "colExpenseDate";
            colExpenseDate.ReadOnly = true;
            // 
            // colExpenseDescription
            // 
            colExpenseDescription.HeaderText = "Description";
            colExpenseDescription.MinimumWidth = 6;
            colExpenseDescription.Name = "colExpenseDescription";
            colExpenseDescription.ReadOnly = true;
            // 
            // colExpenseAmount
            // 
            colExpenseAmount.HeaderText = "Amount";
            colExpenseAmount.MinimumWidth = 6;
            colExpenseAmount.Name = "colExpenseAmount";
            colExpenseAmount.ReadOnly = true;
            // 
            // BillingExpensesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlExpensesContent);
            Controls.Add(pnlExpenseFilters);
            Controls.Add(pnlExpensesHeader);
            Name = "BillingExpensesControl";
            Size = new Size(1300, 750);
            pnlExpensesHeader.ResumeLayout(false);
            pnlExpenseFilters.ResumeLayout(false);
            pnlExpensesContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlExpensesHeader;
        private Panel pnlExpenseFilters;
        private Panel pnlExpensesContent;
        private Button btnBackExpenses;
        private Label lblExpensesTitle;
        private Button btnUtilitiesExpenses;
        private Button btnMaintenanceExpenses;
        private Button btnAllExpenses;
        private DataGridView dgvExpenses;
        private DataGridViewTextBoxColumn colExpenseDate;
        private DataGridViewTextBoxColumn colExpenseDescription;
        private DataGridViewTextBoxColumn colExpenseAmount;
    }
}
