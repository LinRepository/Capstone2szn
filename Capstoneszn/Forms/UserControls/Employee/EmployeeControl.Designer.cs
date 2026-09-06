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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewCheckBoxColumn();
            Column7 = new DataGridViewButtonColumn();
            Column6 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(11, 20, 50);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(24, 20);
            label1.Name = "label1";
            label1.Size = new Size(370, 146);
            label1.TabIndex = 0;
            label1.Text = " ";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(11, 20, 50);
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(411, 20);
            label2.Name = "label2";
            label2.Size = new Size(370, 146);
            label2.TabIndex = 1;
            label2.Text = " ";
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(11, 20, 50);
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(24, 184);
            label3.Name = "label3";
            label3.Size = new Size(1258, 548);
            label3.TabIndex = 2;
            label3.Text = " ";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(1, 100, 200);
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(962, 20);
            button1.Name = "button1";
            button1.Size = new Size(320, 146);
            button1.TabIndex = 3;
            button1.Text = "+ Add new employee";
            button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(11, 20, 50);
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(58, 30);
            label4.Name = "label4";
            label4.Size = new Size(306, 31);
            label4.TabIndex = 4;
            label4.Text = "Total Registered Employees";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(11, 20, 50);
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(506, 30);
            label5.Name = "label5";
            label5.Size = new Size(168, 31);
            label5.TabIndex = 5;
            label5.Text = "Current Active";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(11, 20, 50);
            label6.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(177, 81);
            label6.Name = "label6";
            label6.Size = new Size(43, 50);
            label6.TabIndex = 6;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(11, 20, 50);
            label7.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(563, 81);
            label7.Name = "label7";
            label7.Size = new Size(43, 50);
            label7.TabIndex = 7;
            label7.Text = "0";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column7, Column6 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(35, 196);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RightToLeft = RightToLeft.No;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1235, 522);
            dataGridView1.TabIndex = 8;
            // 
            // Column1
            // 
            Column1.FillWeight = 50F;
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 152;
            // 
            // Column2
            // 
            Column2.HeaderText = "Name";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 303;
            // 
            // Column3
            // 
            Column3.HeaderText = "Address";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 303;
            // 
            // Column4
            // 
            Column4.FillWeight = 50F;
            Column4.HeaderText = "Date Hired";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 151;
            // 
            // Column5
            // 
            Column5.FillWeight = 30F;
            Column5.HeaderText = "Status";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 91;
            // 
            // Column7
            // 
            Column7.FillWeight = 30F;
            Column7.HeaderText = "Edit";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 91;
            // 
            // Column6
            // 
            Column6.FillWeight = 30F;
            Column6.HeaderText = "Archive";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 91;
            // 
            // EmployeeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(dataGridView1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EmployeeControl";
            Size = new Size(1300, 750);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewCheckBoxColumn Column5;
        private DataGridViewButtonColumn Column7;
        private DataGridViewTextBoxColumn Column6;
    }
}
