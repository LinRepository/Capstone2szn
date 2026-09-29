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
<<<<<<< HEAD
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel5 = new Panel();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewButtonColumn();
            panel2 = new Panel();
            textBox1 = new TextBox();
            tabPage2 = new TabPage();
            panel6 = new Panel();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            panel3 = new Panel();
            textBox2 = new TextBox();
            tabPage3 = new TabPage();
            panel7 = new Panel();
            dataGridView3 = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            panel4 = new Panel();
            textBox3 = new TextBox();
            panel1 = new Panel();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            tabPage2.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel3.SuspendLayout();
            tabPage3.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 14F);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(10, 3);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1300, 750);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 40);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1292, 706);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Rent";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 72);
            panel5.Name = "panel5";
            panel5.Size = new Size(1286, 631);
            panel5.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1286, 631);
            dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.FillWeight = 91.24088F;
            Column1.HeaderText = "Date";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.FillWeight = 95.26033F;
            Column2.HeaderText = "Time";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.FillWeight = 98.49911F;
            Column3.HeaderText = "Tenant Name";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.FillWeight = 101.731644F;
            Column4.HeaderText = "Room";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.FillWeight = 104.923828F;
            Column5.HeaderText = "Type";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.FillWeight = 107.2798F;
            Column6.HeaderText = "Tags";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.FillWeight = 110.3906F;
            Column7.HeaderText = "Method";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.FillWeight = 112.603455F;
            Column8.HeaderText = "Amount";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.FillWeight = 78.0704346F;
            Column9.HeaderText = "Receipt";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(1286, 69);
            panel2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Dock = DockStyle.Top;
            textBox1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            textBox1.Location = new Point(10, 10);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "🔍Search";
            textBox1.Size = new Size(1266, 52);
            textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel6);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 40);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(1292, 706);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Maintenance";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(dataGridView2);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 69);
            panel6.Name = "panel6";
            panel6.Size = new Size(1292, 637);
            panel6.TabIndex = 4;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView2.ColumnHeadersHeight = 50;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn8, dataGridViewButtonColumn1 });
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1292, 637);
            dataGridView2.TabIndex = 2;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.FillWeight = 40F;
            dataGridViewTextBoxColumn1.HeaderText = "Date";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.FillWeight = 40F;
            dataGridViewTextBoxColumn2.HeaderText = "Time";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Responsible";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.FillWeight = 30F;
            dataGridViewTextBoxColumn4.HeaderText = "Room";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Issue";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.FillWeight = 50F;
            dataGridViewTextBoxColumn8.HeaderText = "Amount";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewButtonColumn1.FillWeight = 50F;
            dataGridViewButtonColumn1.HeaderText = "Reciept";
            dataGridViewButtonColumn1.MinimumWidth = 6;
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(1292, 69);
            panel3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Dock = DockStyle.Top;
            textBox2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            textBox2.Location = new Point(10, 10);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "🔍Search";
            textBox2.Size = new Size(1272, 52);
            textBox2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel7);
            tabPage3.Controls.Add(panel4);
            tabPage3.Location = new Point(4, 40);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1292, 706);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Global";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            panel7.Controls.Add(dataGridView3);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 69);
            panel7.Name = "panel7";
            panel7.Size = new Size(1292, 637);
            panel7.TabIndex = 7;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView3.ColumnHeadersHeight = 50;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewButtonColumn2 });
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView3.Location = new Point(0, 0);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(1292, 637);
            dataGridView3.TabIndex = 5;
=======
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
>>>>>>> e5b64bf69117873f4de279446c82eefe825544df
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
<<<<<<< HEAD
            // panel4
            // 
            panel4.Controls.Add(textBox3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(1292, 69);
            panel4.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Dock = DockStyle.Top;
            textBox3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            textBox3.Location = new Point(10, 10);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "🔍Search";
            textBox3.Size = new Size(1272, 52);
            textBox3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1300, 750);
            panel1.TabIndex = 2;
=======
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
>>>>>>> e5b64bf69117873f4de279446c82eefe825544df
            // 
            // PaymentHistoryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 50);
<<<<<<< HEAD
            Controls.Add(panel1);
            Name = "PaymentHistoryControl";
            Size = new Size(1300, 750);
            Load += PaymentHistoryControl_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabPage3.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
=======
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
>>>>>>> e5b64bf69117873f4de279446c82eefe825544df
            ResumeLayout(false);
        }

        #endregion
<<<<<<< HEAD
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
=======

        private Label label1;
        private TabPage tabPage3;
>>>>>>> e5b64bf69117873f4de279446c82eefe825544df
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewButtonColumn dataGridViewButtonColumn2;
<<<<<<< HEAD
        private Panel panel1;
        private Panel panel3;
        private TextBox textBox2;
        private Panel panel4;
        private TextBox textBox3;
        private Panel panel6;
        private Panel panel7;
        private TabPage tabPage1;
        private Panel panel5;
        private Panel panel2;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewButtonColumn Column9;
=======
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
>>>>>>> e5b64bf69117873f4de279446c82eefe825544df
    }
}
