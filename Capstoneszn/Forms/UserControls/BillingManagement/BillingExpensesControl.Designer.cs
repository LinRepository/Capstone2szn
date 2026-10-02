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
            lblExpensesTitle = new Label();
            btnBackExpenses = new Button();
            pnlExpensesContent = new Panel();
            tabExpenses = new TabControl();
            tabAll = new TabPage();
            tabMaintenance = new TabPage();
            dgvAll = new DataGridView();
            colAllDate = new DataGridViewTextBoxColumn();
            colAllDescription = new DataGridViewTextBoxColumn();
            colAllAmount = new DataGridViewTextBoxColumn();
            dgvMaintenance = new DataGridView();
            colMaintenanaceDate = new DataGridViewTextBoxColumn();
            colMaintenanceDescription = new DataGridViewTextBoxColumn();
            colMaintenanceAmount = new DataGridViewTextBoxColumn();
            tabUtilities = new TabPage();
            dgvUtilities = new DataGridView();
            colUtilitiesDate = new DataGridViewTextBoxColumn();
            colUtilitiesDescription = new DataGridViewTextBoxColumn();
            colUtilitiesAmount = new DataGridViewTextBoxColumn();
            pnlExpensesHeader.SuspendLayout();
            pnlExpensesContent.SuspendLayout();
            tabExpenses.SuspendLayout();
            tabAll.SuspendLayout();
            tabMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).BeginInit();
            tabUtilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUtilities).BeginInit();
            SuspendLayout();
            // 
            // pnlExpensesHeader
            // 
            pnlExpensesHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlExpensesHeader.Controls.Add(lblExpensesTitle);
            pnlExpensesHeader.Controls.Add(btnBackExpenses);
            pnlExpensesHeader.Dock = DockStyle.Top;
            pnlExpensesHeader.Location = new Point(0, 0);
            pnlExpensesHeader.Name = "pnlExpensesHeader";
            pnlExpensesHeader.Size = new Size(1300, 90);
            pnlExpensesHeader.TabIndex = 0;
            // 
            // lblExpensesTitle
            // 
            lblExpensesTitle.Dock = DockStyle.Fill;
            lblExpensesTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpensesTitle.ForeColor = Color.White;
            lblExpensesTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblExpensesTitle.Location = new Point(140, 0);
            lblExpensesTitle.Name = "lblExpensesTitle";
            lblExpensesTitle.Size = new Size(1158, 88);
            lblExpensesTitle.TabIndex = 7;
            lblExpensesTitle.Text = "Expenses";
            lblExpensesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackExpenses
            // 
            btnBackExpenses.Dock = DockStyle.Left;
            btnBackExpenses.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackExpenses.Location = new Point(0, 0);
            btnBackExpenses.Margin = new Padding(0);
            btnBackExpenses.Name = "btnBackExpenses";
            btnBackExpenses.Size = new Size(140, 88);
            btnBackExpenses.TabIndex = 2;
            btnBackExpenses.Text = "←";
            btnBackExpenses.TextAlign = ContentAlignment.TopCenter;
            btnBackExpenses.UseVisualStyleBackColor = true;
            btnBackExpenses.Click += btnBackExpenses_Click;
            // 
            // pnlExpensesContent
            // 
            pnlExpensesContent.BorderStyle = BorderStyle.FixedSingle;
            pnlExpensesContent.Controls.Add(tabExpenses);
            pnlExpensesContent.Dock = DockStyle.Fill;
            pnlExpensesContent.Location = new Point(0, 90);
            pnlExpensesContent.Name = "pnlExpensesContent";
            pnlExpensesContent.Size = new Size(1300, 660);
            pnlExpensesContent.TabIndex = 2;
            // 
            // tabExpenses
            // 
            tabExpenses.Controls.Add(tabAll);
            tabExpenses.Controls.Add(tabMaintenance);
            tabExpenses.Controls.Add(tabUtilities);
            tabExpenses.Dock = DockStyle.Fill;
            tabExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabExpenses.Location = new Point(0, 0);
            tabExpenses.Name = "tabExpenses";
            tabExpenses.SelectedIndex = 0;
            tabExpenses.Size = new Size(1298, 658);
            tabExpenses.TabIndex = 0;
            // 
            // tabAll
            // 
            tabAll.Controls.Add(dgvAll);
            tabAll.Location = new Point(4, 37);
            tabAll.Name = "tabAll";
            tabAll.Padding = new Padding(3);
            tabAll.Size = new Size(1290, 617);
            tabAll.TabIndex = 0;
            tabAll.Text = "All";
            tabAll.UseVisualStyleBackColor = true;
            // 
            // tabMaintenance
            // 
            tabMaintenance.Controls.Add(dgvMaintenance);
            tabMaintenance.Location = new Point(4, 37);
            tabMaintenance.Name = "tabMaintenance";
            tabMaintenance.Padding = new Padding(3);
            tabMaintenance.Size = new Size(1290, 617);
            tabMaintenance.TabIndex = 1;
            tabMaintenance.Text = "Maintenance";
            tabMaintenance.UseVisualStyleBackColor = true;
            // 
            // dgvAll
            // 
            dgvAll.AllowUserToAddRows = false;
            dgvAll.AllowUserToDeleteRows = false;
            dgvAll.AllowUserToResizeRows = false;
            dgvAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAll.Columns.AddRange(new DataGridViewColumn[] { colAllDate, colAllDescription, colAllAmount });
            dgvAll.Dock = DockStyle.Fill;
            dgvAll.Location = new Point(3, 3);
            dgvAll.MultiSelect = false;
            dgvAll.Name = "dgvAll";
            dgvAll.ReadOnly = true;
            dgvAll.RowHeadersVisible = false;
            dgvAll.RowHeadersWidth = 51;
            dgvAll.ScrollBars = ScrollBars.Vertical;
            dgvAll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAll.Size = new Size(1284, 611);
            dgvAll.TabIndex = 1;
            // 
            // colAllDate
            // 
            colAllDate.HeaderText = "Date";
            colAllDate.MinimumWidth = 6;
            colAllDate.Name = "colAllDate";
            colAllDate.ReadOnly = true;
            // 
            // colAllDescription
            // 
            colAllDescription.HeaderText = "Description";
            colAllDescription.MinimumWidth = 6;
            colAllDescription.Name = "colAllDescription";
            colAllDescription.ReadOnly = true;
            // 
            // colAllAmount
            // 
            colAllAmount.HeaderText = "Amount";
            colAllAmount.MinimumWidth = 6;
            colAllAmount.Name = "colAllAmount";
            colAllAmount.ReadOnly = true;
            // 
            // dgvMaintenance
            // 
            dgvMaintenance.AllowUserToAddRows = false;
            dgvMaintenance.AllowUserToDeleteRows = false;
            dgvMaintenance.AllowUserToResizeRows = false;
            dgvMaintenance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaintenance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaintenance.Columns.AddRange(new DataGridViewColumn[] { colMaintenanaceDate, colMaintenanceDescription, colMaintenanceAmount });
            dgvMaintenance.Dock = DockStyle.Fill;
            dgvMaintenance.Location = new Point(3, 3);
            dgvMaintenance.MultiSelect = false;
            dgvMaintenance.Name = "dgvMaintenance";
            dgvMaintenance.ReadOnly = true;
            dgvMaintenance.RowHeadersVisible = false;
            dgvMaintenance.RowHeadersWidth = 51;
            dgvMaintenance.ScrollBars = ScrollBars.Vertical;
            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaintenance.Size = new Size(1284, 611);
            dgvMaintenance.TabIndex = 1;
            // 
            // colMaintenanaceDate
            // 
            colMaintenanaceDate.HeaderText = "Date";
            colMaintenanaceDate.MinimumWidth = 6;
            colMaintenanaceDate.Name = "colMaintenanaceDate";
            colMaintenanaceDate.ReadOnly = true;
            // 
            // colMaintenanceDescription
            // 
            colMaintenanceDescription.HeaderText = "Description";
            colMaintenanceDescription.MinimumWidth = 6;
            colMaintenanceDescription.Name = "colMaintenanceDescription";
            colMaintenanceDescription.ReadOnly = true;
            // 
            // colMaintenanceAmount
            // 
            colMaintenanceAmount.HeaderText = "Amount";
            colMaintenanceAmount.MinimumWidth = 6;
            colMaintenanceAmount.Name = "colMaintenanceAmount";
            colMaintenanceAmount.ReadOnly = true;
            // 
            // tabUtilities
            // 
            tabUtilities.Controls.Add(dgvUtilities);
            tabUtilities.Location = new Point(4, 37);
            tabUtilities.Name = "tabUtilities";
            tabUtilities.Padding = new Padding(3);
            tabUtilities.Size = new Size(1290, 617);
            tabUtilities.TabIndex = 2;
            tabUtilities.Text = "Utilities";
            tabUtilities.UseVisualStyleBackColor = true;
            // 
            // dgvUtilities
            // 
            dgvUtilities.AllowUserToAddRows = false;
            dgvUtilities.AllowUserToDeleteRows = false;
            dgvUtilities.AllowUserToResizeRows = false;
            dgvUtilities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUtilities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUtilities.Columns.AddRange(new DataGridViewColumn[] { colUtilitiesDate, colUtilitiesDescription, colUtilitiesAmount });
            dgvUtilities.Dock = DockStyle.Fill;
            dgvUtilities.Location = new Point(3, 3);
            dgvUtilities.MultiSelect = false;
            dgvUtilities.Name = "dgvUtilities";
            dgvUtilities.ReadOnly = true;
            dgvUtilities.RowHeadersVisible = false;
            dgvUtilities.RowHeadersWidth = 51;
            dgvUtilities.ScrollBars = ScrollBars.Vertical;
            dgvUtilities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUtilities.Size = new Size(1284, 611);
            dgvUtilities.TabIndex = 1;
            // 
            // colUtilitiesDate
            // 
            colUtilitiesDate.HeaderText = "Date";
            colUtilitiesDate.MinimumWidth = 6;
            colUtilitiesDate.Name = "colUtilitiesDate";
            colUtilitiesDate.ReadOnly = true;
            // 
            // colUtilitiesDescription
            // 
            colUtilitiesDescription.HeaderText = "Description";
            colUtilitiesDescription.MinimumWidth = 6;
            colUtilitiesDescription.Name = "colUtilitiesDescription";
            colUtilitiesDescription.ReadOnly = true;
            // 
            // colUtilitiesAmount
            // 
            colUtilitiesAmount.HeaderText = "Amount";
            colUtilitiesAmount.MinimumWidth = 6;
            colUtilitiesAmount.Name = "colUtilitiesAmount";
            colUtilitiesAmount.ReadOnly = true;
            // 
            // BillingExpensesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlExpensesContent);
            Controls.Add(pnlExpensesHeader);
            Name = "BillingExpensesControl";
            Size = new Size(1300, 750);
            pnlExpensesHeader.ResumeLayout(false);
            pnlExpensesContent.ResumeLayout(false);
            tabExpenses.ResumeLayout(false);
            tabAll.ResumeLayout(false);
            tabMaintenance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAll).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).EndInit();
            tabUtilities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUtilities).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlExpensesHeader;
        private Panel pnlExpensesContent;
        private Button btnBackExpenses;
        private Label lblExpensesTitle;
        private TabControl tabExpenses;
        private TabPage tabAll;
        private DataGridView dgvAll;
        private DataGridViewTextBoxColumn colAllDate;
        private DataGridViewTextBoxColumn colAllDescription;
        private DataGridViewTextBoxColumn colAllAmount;
        private TabPage tabMaintenance;
        private DataGridView dgvMaintenance;
        private DataGridViewTextBoxColumn colMaintenanaceDate;
        private DataGridViewTextBoxColumn colMaintenanceDescription;
        private DataGridViewTextBoxColumn colMaintenanceAmount;
        private TabPage tabUtilities;
        private DataGridView dgvUtilities;
        private DataGridViewTextBoxColumn colUtilitiesDate;
        private DataGridViewTextBoxColumn colUtilitiesDescription;
        private DataGridViewTextBoxColumn colUtilitiesAmount;
    }
}
