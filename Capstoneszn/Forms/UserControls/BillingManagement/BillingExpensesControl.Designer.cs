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
            dgvAll = new DataGridView();
            colAllDate = new DataGridViewTextBoxColumn();
            colAllDescription = new DataGridViewTextBoxColumn();
            colAllAmount = new DataGridViewTextBoxColumn();
            pnlExpensesFilter = new Panel();
            lblExpensesTotal = new Label();
            cboExpensePeriod = new ComboBox();
            pnlExpensesHeader.SuspendLayout();
            pnlExpensesContent.SuspendLayout();
            tabExpenses.SuspendLayout();
            tabAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAll).BeginInit();
            pnlExpensesFilter.SuspendLayout();
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
            pnlExpensesContent.Controls.Add(pnlExpensesFilter);
            pnlExpensesContent.Dock = DockStyle.Fill;
            pnlExpensesContent.Location = new Point(0, 90);
            pnlExpensesContent.Name = "pnlExpensesContent";
            pnlExpensesContent.Size = new Size(1300, 660);
            pnlExpensesContent.TabIndex = 2;
            //
            // pnlExpensesFilter
            //
            pnlExpensesFilter.Controls.Add(lblExpensesTotal);
            pnlExpensesFilter.Controls.Add(cboExpensePeriod);
            pnlExpensesFilter.Dock = DockStyle.Top;
            pnlExpensesFilter.Location = new Point(0, 0);
            pnlExpensesFilter.Name = "pnlExpensesFilter";
            pnlExpensesFilter.Size = new Size(1298, 55);
            pnlExpensesFilter.TabIndex = 0;
            //
            // cboExpensePeriod
            //
            cboExpensePeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExpensePeriod.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboExpensePeriod.FormattingEnabled = true;
            cboExpensePeriod.Location = new Point(12, 10);
            cboExpensePeriod.Name = "cboExpensePeriod";
            cboExpensePeriod.Size = new Size(220, 36);
            cboExpensePeriod.TabIndex = 0;
            //
            // lblExpensesTotal
            //
            lblExpensesTotal.AutoSize = true;
            lblExpensesTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpensesTotal.ForeColor = Color.White;
            lblExpensesTotal.Location = new Point(255, 13);
            lblExpensesTotal.Name = "lblExpensesTotal";
            lblExpensesTotal.Size = new Size(54, 28);
            lblExpensesTotal.TabIndex = 1;
            lblExpensesTotal.Text = "Total";
            //
            // tabExpenses
            //
            tabExpenses.Controls.Add(tabAll);
            tabExpenses.Dock = DockStyle.Fill;
            tabExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabExpenses.Location = new Point(0, 55);
            tabExpenses.Name = "tabExpenses";
            tabExpenses.SelectedIndex = 0;
            tabExpenses.Size = new Size(1298, 603);
            tabExpenses.TabIndex = 1;
            //
            // tabAll
            //
            tabAll.Controls.Add(dgvAll);
            tabAll.Location = new Point(4, 37);
            tabAll.Name = "tabAll";
            tabAll.Padding = new Padding(3);
            tabAll.Size = new Size(1290, 562);
            tabAll.TabIndex = 0;
            tabAll.Text = "All";
            tabAll.UseVisualStyleBackColor = true;
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
            dgvAll.Size = new Size(1284, 556);
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
            pnlExpensesFilter.ResumeLayout(false);
            pnlExpensesFilter.PerformLayout();
            tabExpenses.ResumeLayout(false);
            tabAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAll).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlExpensesHeader;
        private Panel pnlExpensesContent;
        private Button btnBackExpenses;
        private Label lblExpensesTitle;
        private Panel pnlExpensesFilter;
        private ComboBox cboExpensePeriod;
        private Label lblExpensesTotal;
        private TabControl tabExpenses;
        private TabPage tabAll;
        private DataGridView dgvAll;
        private DataGridViewTextBoxColumn colAllDate;
        private DataGridViewTextBoxColumn colAllDescription;
        private DataGridViewTextBoxColumn colAllAmount;

    }
}
