namespace Capstoneszn.UserControls
{
    partial class PaymentHistoryControl
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            this.tabMaintenance = new TabPage();
            dgvMaintenance = new DataGridView();
            colMaintenanceReceipt = new DataGridViewButtonColumn();
            colMaintenanceAmount = new DataGridViewTextBoxColumn();
            colMaintenanceIssue = new DataGridViewTextBoxColumn();
            colMaintenanceRoom = new DataGridViewTextBoxColumn();
            colMaintenanceResponsible = new DataGridViewTextBoxColumn();
            colMaintenanceTime = new DataGridViewTextBoxColumn();
            colMaintenanceDate = new DataGridViewTextBoxColumn();
            txtMaintenanceSearch = new TextBox();
            this.tabRent = new TabPage();
            this.txtRentSearch = new TextBox();
            dgvRent = new DataGridView();
            colRentReceipt = new DataGridViewButtonColumn();
            colRentAmount = new DataGridViewTextBoxColumn();
            colRentMethod = new DataGridViewTextBoxColumn();
            colRentTags = new DataGridViewTextBoxColumn();
            colRentType = new DataGridViewTextBoxColumn();
            colRentRoom = new DataGridViewTextBoxColumn();
            colRentTenantName = new DataGridViewTextBoxColumn();
            colRentTime = new DataGridViewTextBoxColumn();
            colRentDate = new DataGridViewTextBoxColumn();
            tabPaymentHistory = new TabControl();
            this.tabMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).BeginInit();
            this.tabRent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRent).BeginInit();
            tabPaymentHistory.SuspendLayout();
            SuspendLayout();
            // 
            // tabMaintenance
            // 
            this.tabMaintenance.Controls.Add(txtMaintenanceSearch);
            this.tabMaintenance.Controls.Add(dgvMaintenance);
            this.tabMaintenance.Location = new Point(4, 40);
            this.tabMaintenance.Name = "tabMaintenance";
            this.tabMaintenance.Size = new Size(1290, 703);
            this.tabMaintenance.TabIndex = 1;
            this.tabMaintenance.Text = "Maintenance";
            this.tabMaintenance.UseVisualStyleBackColor = true;
            // 
            // dgvMaintenance
            // 
            dgvMaintenance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvMaintenance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvMaintenance.ColumnHeadersHeight = 50;
            dgvMaintenance.Columns.AddRange(new DataGridViewColumn[] { colMaintenanceDate, colMaintenanceTime, colMaintenanceResponsible, colMaintenanceRoom, colMaintenanceIssue, colMaintenanceAmount, colMaintenanceReceipt });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvMaintenance.DefaultCellStyle = dataGridViewCellStyle6;
            dgvMaintenance.Location = new Point(-3, 75);
            dgvMaintenance.Name = "dgvMaintenance";
            dgvMaintenance.RowHeadersWidth = 51;
            dgvMaintenance.Size = new Size(1298, 632);
            dgvMaintenance.TabIndex = 2;
            // 
            // colMaintenanceReceipt
            // 
            colMaintenanceReceipt.FillWeight = 50F;
            colMaintenanceReceipt.HeaderText = "Reciept";
            colMaintenanceReceipt.MinimumWidth = 6;
            colMaintenanceReceipt.Name = "colMaintenanceReceipt";
            // 
            // colMaintenanceAmount
            // 
            colMaintenanceAmount.FillWeight = 50F;
            colMaintenanceAmount.HeaderText = "Amount";
            colMaintenanceAmount.MinimumWidth = 6;
            colMaintenanceAmount.Name = "colMaintenanceAmount";
            // 
            // colMaintenanceIssue
            // 
            colMaintenanceIssue.HeaderText = "Issue";
            colMaintenanceIssue.MinimumWidth = 6;
            colMaintenanceIssue.Name = "colMaintenanceIssue";
            // 
            // colMaintenanceRoom
            // 
            colMaintenanceRoom.FillWeight = 30F;
            colMaintenanceRoom.HeaderText = "Room";
            colMaintenanceRoom.MinimumWidth = 6;
            colMaintenanceRoom.Name = "colMaintenanceRoom";
            // 
            // colMaintenanceResponsible
            // 
            colMaintenanceResponsible.HeaderText = "Responsible";
            colMaintenanceResponsible.MinimumWidth = 6;
            colMaintenanceResponsible.Name = "colMaintenanceResponsible";
            // 
            // colMaintenanceTime
            // 
            colMaintenanceTime.FillWeight = 40F;
            colMaintenanceTime.HeaderText = "Time";
            colMaintenanceTime.MinimumWidth = 6;
            colMaintenanceTime.Name = "colMaintenanceTime";
            // 
            // colMaintenanceDate
            // 
            colMaintenanceDate.FillWeight = 40F;
            colMaintenanceDate.HeaderText = "Date";
            colMaintenanceDate.MinimumWidth = 6;
            colMaintenanceDate.Name = "colMaintenanceDate";
            // 
            // txtMaintenanceSearch
            // 
            txtMaintenanceSearch.BorderStyle = BorderStyle.FixedSingle;
            txtMaintenanceSearch.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            txtMaintenanceSearch.Location = new Point(15, 13);
            txtMaintenanceSearch.Name = "txtMaintenanceSearch";
            txtMaintenanceSearch.PlaceholderText = "🔍Search";
            txtMaintenanceSearch.Size = new Size(1258, 52);
            txtMaintenanceSearch.TabIndex = 3;
            // 
            // tabRent
            // 
            this.tabRent.Controls.Add(dgvRent);
            this.tabRent.Controls.Add(this.txtRentSearch);
            this.tabRent.Location = new Point(4, 40);
            this.tabRent.Name = "tabRent";
            this.tabRent.Size = new Size(1290, 703);
            this.tabRent.TabIndex = 0;
            this.tabRent.Text = "Rent";
            this.tabRent.UseVisualStyleBackColor = true;
            // 
            // txtRentSearch
            // 
            this.txtRentSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtRentSearch.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.txtRentSearch.Location = new Point(15, 13);
            this.txtRentSearch.Name = "txtRentSearch";
            this.txtRentSearch.PlaceholderText = "🔍Search";
            this.txtRentSearch.Size = new Size(1258, 52);
            this.txtRentSearch.TabIndex = 0;
            // 
            // dgvRent
            // 
            dgvRent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvRent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvRent.ColumnHeadersHeight = 50;
            dgvRent.Columns.AddRange(new DataGridViewColumn[] { colRentDate, colRentTime, colRentTenantName, colRentRoom, colRentType, colRentTags, colRentMethod, colRentAmount, colRentReceipt });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvRent.DefaultCellStyle = dataGridViewCellStyle8;
            dgvRent.Location = new Point(-3, 75);
            dgvRent.Name = "dgvRent";
            dgvRent.RowHeadersWidth = 51;
            dgvRent.Size = new Size(1298, 632);
            dgvRent.TabIndex = 1;
            // 
            // colRentReceipt
            // 
            colRentReceipt.FillWeight = 80F;
            colRentReceipt.HeaderText = "Reciept";
            colRentReceipt.MinimumWidth = 6;
            colRentReceipt.Name = "colRentReceipt";
            // 
            // colRentAmount
            // 
            colRentAmount.HeaderText = "Amount";
            colRentAmount.MinimumWidth = 6;
            colRentAmount.Name = "colRentAmount";
            // 
            // colRentMethod
            // 
            colRentMethod.FillWeight = 80F;
            colRentMethod.HeaderText = "Method";
            colRentMethod.MinimumWidth = 6;
            colRentMethod.Name = "colRentMethod";
            // 
            // colRentTags
            // 
            colRentTags.HeaderText = "Tags";
            colRentTags.MinimumWidth = 6;
            colRentTags.Name = "colRentTags";
            // 
            // colRentType
            // 
            colRentType.FillWeight = 60F;
            colRentType.HeaderText = "Type";
            colRentType.MinimumWidth = 6;
            colRentType.Name = "colRentType";
            // 
            // colRentRoom
            // 
            colRentRoom.FillWeight = 50F;
            colRentRoom.HeaderText = "Room";
            colRentRoom.MinimumWidth = 6;
            colRentRoom.Name = "colRentRoom";
            // 
            // colRentTenantName
            // 
            colRentTenantName.HeaderText = "Tenant Name";
            colRentTenantName.MinimumWidth = 6;
            colRentTenantName.Name = "colRentTenantName";
            // 
            // colRentTime
            // 
            colRentTime.FillWeight = 60F;
            colRentTime.HeaderText = "Time";
            colRentTime.MinimumWidth = 6;
            colRentTime.Name = "colRentTime";
            // 
            // colRentDate
            // 
            colRentDate.FillWeight = 60F;
            colRentDate.HeaderText = "Date";
            colRentDate.MinimumWidth = 6;
            colRentDate.Name = "colRentDate";
            // 
            // tabPaymentHistory
            // 
            tabPaymentHistory.Controls.Add(this.tabRent);
            tabPaymentHistory.Controls.Add(this.tabMaintenance);
            tabPaymentHistory.Font = new Font("Segoe UI", 14F);
            tabPaymentHistory.Location = new Point(-1, 0);
            tabPaymentHistory.Name = "tabPaymentHistory";
            tabPaymentHistory.Padding = new Point(10, 3);
            tabPaymentHistory.SelectedIndex = 0;
            tabPaymentHistory.Size = new Size(1298, 747);
            tabPaymentHistory.TabIndex = 1;
            // 
            // PaymentHistoryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(tabPaymentHistory);
            Name = "PaymentHistoryControl";
            Size = new Size(1300, 750);
            this.tabMaintenance.ResumeLayout(false);
            this.tabMaintenance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).EndInit();
            this.tabRent.ResumeLayout(false);
            this.tabRent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRent).EndInit();
            tabPaymentHistory.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TabPage tabPage3;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewButtonColumn dataGridViewButtonColumn2;
        private TextBox textBox3;
        private TabPage tabPage2;
        private TextBox txtMaintenanceSearch;
        private DataGridView dgvMaintenance;
        private DataGridViewTextBoxColumn colMaintenanceDate;
        private DataGridViewTextBoxColumn colMaintenanceTime;
        private DataGridViewTextBoxColumn colMaintenanceResponsible;
        private DataGridViewTextBoxColumn colMaintenanceRoom;
        private DataGridViewTextBoxColumn colMaintenanceIssue;
        private DataGridViewTextBoxColumn colMaintenanceAmount;
        private DataGridViewButtonColumn colMaintenanceReceipt;
        private TabPage tabPage1;
        private DataGridView dgvRent;
        private DataGridViewTextBoxColumn colRentDate;
        private DataGridViewTextBoxColumn colRentTime;
        private DataGridViewTextBoxColumn colRentTenantName;
        private DataGridViewTextBoxColumn colRentRoom;
        private DataGridViewTextBoxColumn colRentType;
        private DataGridViewTextBoxColumn colRentTags;
        private DataGridViewTextBoxColumn colRentMethod;
        private DataGridViewTextBoxColumn colRentAmount;
        private DataGridViewButtonColumn colRentReceipt;
        private TextBox textBox1;
        private TabControl tabPaymentHistory;
    }
}
