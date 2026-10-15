namespace Capstoneszn.Forms.UtilityForms
{
    partial class AddOtherForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnConfirm = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            dtpChargeDate = new DateTimePicker();
            label3 = new Label();
            rbTenant = new RadioButton();
            rbOutsider = new RadioButton();
            label4 = new Label();
            cbTenant = new ComboBox();
            label5 = new Label();
            txtAmount = new TextBox();
            btnAddtoList = new Button();
            dgvCharges = new DataGridView();
            colType = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colRemove = new DataGridViewButtonColumn();
            label6 = new Label();
            label7 = new Label();
            lblTotalAmount = new Label();
            txtOutsiderName = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCharges).BeginInit();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(559, 683);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(100, 37);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(453, 683);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 37);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 40);
            label1.Name = "label1";
            label1.Size = new Size(113, 23);
            label1.TabIndex = 1;
            label1.Text = "Utilitiy Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(24, 95);
            label2.Name = "label2";
            label2.Size = new Size(110, 23);
            label2.TabIndex = 1;
            label2.Text = "Charge Date:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(160, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(499, 30);
            textBox1.TabIndex = 2;
            // 
            // dtpChargeDate
            // 
            dtpChargeDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpChargeDate.Format = DateTimePickerFormat.Short;
            dtpChargeDate.Location = new Point(160, 89);
            dtpChargeDate.Name = "dtpChargeDate";
            dtpChargeDate.Size = new Size(500, 30);
            dtpChargeDate.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(24, 144);
            label3.Name = "label3";
            label3.Size = new Size(91, 23);
            label3.TabIndex = 1;
            label3.Text = "Charge To:";
            // 
            // rbTenant
            // 
            rbTenant.AutoSize = true;
            rbTenant.Font = new Font("Segoe UI", 10.2F);
            rbTenant.ForeColor = Color.White;
            rbTenant.Location = new Point(160, 142);
            rbTenant.Name = "rbTenant";
            rbTenant.Size = new Size(82, 27);
            rbTenant.TabIndex = 4;
            rbTenant.TabStop = true;
            rbTenant.Text = "Tenant";
            rbTenant.UseVisualStyleBackColor = true;
            // 
            // rbOutsider
            // 
            rbOutsider.AutoSize = true;
            rbOutsider.Font = new Font("Segoe UI", 10.2F);
            rbOutsider.ForeColor = Color.White;
            rbOutsider.Location = new Point(257, 142);
            rbOutsider.Name = "rbOutsider";
            rbOutsider.Size = new Size(96, 27);
            rbOutsider.TabIndex = 4;
            rbOutsider.TabStop = true;
            rbOutsider.Text = "Outsider";
            rbOutsider.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(24, 198);
            label4.Name = "label4";
            label4.Size = new Size(65, 23);
            label4.TabIndex = 1;
            label4.Text = "Tenant:";
            // 
            // cbTenant
            // 
            cbTenant.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTenant.FormattingEnabled = true;
            cbTenant.Location = new Point(160, 190);
            cbTenant.Name = "cbTenant";
            cbTenant.Size = new Size(499, 31);
            cbTenant.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(24, 293);
            label5.Name = "label5";
            label5.Size = new Size(148, 46);
            label5.TabIndex = 1;
            label5.Text = "Amount:";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.Location = new Point(201, 288);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "0.00 ";
            txtAmount.Size = new Size(458, 51);
            txtAmount.TabIndex = 2;
            txtAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // btnAddtoList
            // 
            btnAddtoList.BackColor = Color.White;
            btnAddtoList.FlatStyle = FlatStyle.Flat;
            btnAddtoList.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddtoList.Location = new Point(559, 345);
            btnAddtoList.Name = "btnAddtoList";
            btnAddtoList.Size = new Size(100, 37);
            btnAddtoList.TabIndex = 0;
            btnAddtoList.Text = "Add to list";
            btnAddtoList.UseVisualStyleBackColor = false;
            btnAddtoList.Click += btnAddtoList_Click;
            // 
            // dgvCharges
            // 
            dgvCharges.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCharges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCharges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCharges.Columns.AddRange(new DataGridViewColumn[] { colType, colName, colAmount, colRemove });
            dgvCharges.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvCharges.Location = new Point(24, 388);
            dgvCharges.Name = "dgvCharges";
            dgvCharges.RowHeadersVisible = false;
            dgvCharges.RowHeadersWidth = 51;
            dgvCharges.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCharges.Size = new Size(635, 240);
            dgvCharges.TabIndex = 6;
            dgvCharges.CellContentClick += dgvCharges_CellContentClick;
            // 
            // colType
            // 
            colType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colType.FillWeight = 40F;
            colType.HeaderText = "Type";
            colType.MinimumWidth = 6;
            colType.Name = "colType";
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.HeaderText = "Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            // 
            // colAmount
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "₱#,##0.00";
            dataGridViewCellStyle2.NullValue = null;
            colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            colAmount.HeaderText = "Amount";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            colAmount.Width = 125;
            // 
            // colRemove
            // 
            colRemove.HeaderText = "Remove";
            colRemove.MinimumWidth = 6;
            colRemove.Name = "colRemove";
            colRemove.Resizable = DataGridViewTriState.True;
            colRemove.SortMode = DataGridViewColumnSortMode.Automatic;
            colRemove.Text = "X";
            colRemove.UseColumnTextForButtonValue = true;
            colRemove.Width = 125;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(201, 288);
            label6.Name = "label6";
            label6.Size = new Size(40, 46);
            label6.TabIndex = 7;
            label6.Text = "₱";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(479, 631);
            label7.Name = "label7";
            label7.Size = new Size(75, 23);
            label7.TabIndex = 1;
            label7.Text = "Total: ₱ ";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.ForeColor = Color.White;
            lblTotalAmount.Location = new Point(614, 631);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(45, 23);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "0.00";
            // 
            // txtOutsiderName
            // 
            txtOutsiderName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOutsiderName.Location = new Point(160, 240);
            txtOutsiderName.Name = "txtOutsiderName";
            txtOutsiderName.Size = new Size(499, 30);
            txtOutsiderName.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(24, 247);
            label8.Name = "label8";
            label8.Size = new Size(130, 23);
            label8.TabIndex = 1;
            label8.Text = "Outsider Name:";
            // 
            // AddOtherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(672, 733);
            Controls.Add(label6);
            Controls.Add(dgvCharges);
            Controls.Add(cbTenant);
            Controls.Add(rbOutsider);
            Controls.Add(rbTenant);
            Controls.Add(dtpChargeDate);
            Controls.Add(txtAmount);
            Controls.Add(txtOutsiderName);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(lblTotalAmount);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddtoList);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddOtherForm";
            Padding = new Padding(10);
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddOtherForm";
            Load += AddOtherForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCharges).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirm;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private DateTimePicker dtpChargeDate;
        private Label label3;
        private RadioButton rbTenant;
        private RadioButton rbOutsider;
        private Label label4;
        private ComboBox cbTenant;
        private Label label5;
        private TextBox txtAmount;
        private Button btnAddtoList;
        private DataGridView dgvCharges;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewButtonColumn colRemove;
        private Label label6;
        private Label label7;
        private Label lblTotalAmount;
        private TextBox txtOutsiderName;
        private Label label8;
    }
}