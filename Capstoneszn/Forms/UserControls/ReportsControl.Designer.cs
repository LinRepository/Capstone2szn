namespace Capstoneszn.UserControls
{
    partial class ReportsControl
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
            panel1 = new Panel();
            label11 = new Label();
            button2 = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            label12 = new Label();
            label13 = new Label();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            label9 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label9);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1300, 750);
            panel1.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(11, 20, 60);
            label11.ForeColor = Color.White;
            label11.Location = new Point(101, 133);
            label11.Name = "label11";
            label11.Size = new Size(106, 20);
            label11.TabIndex = 13;
            label11.Text = "Total Received";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(1043, 60);
            button2.Name = "button2";
            button2.Size = new Size(213, 45);
            button2.TabIndex = 12;
            button2.Text = "Clear All";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(11, 20, 60);
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Location = new Point(482, 131);
            label8.Name = "label8";
            label8.Size = new Size(193, 79);
            label8.TabIndex = 9;
            label8.Text = "   ";
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(11, 20, 60);
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Location = new Point(271, 131);
            label7.Name = "label7";
            label7.Size = new Size(193, 79);
            label7.TabIndex = 8;
            label7.Text = "   ";
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(11, 20, 60);
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Location = new Point(60, 131);
            label6.Name = "label6";
            label6.Size = new Size(193, 79);
            label6.TabIndex = 7;
            label6.Text = "   ";
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(11, 20, 60);
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Location = new Point(46, 117);
            label5.Name = "label5";
            label5.Size = new Size(979, 112);
            label5.TabIndex = 6;
            label5.Text = "   ";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "All tenants", "Aldrin Carl", "Warren Austria" });
            comboBox1.Location = new Point(859, 60);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(166, 28);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "All tenant (default)";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(482, 61);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(270, 27);
            dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(156, 62);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(270, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(11, 20, 50);
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(911, 29);
            label4.Name = "label4";
            label4.Size = new Size(69, 28);
            label4.TabIndex = 2;
            label4.Text = "Tenant";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(11, 20, 50);
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(444, 61);
            label3.Name = "label3";
            label3.Size = new Size(32, 28);
            label3.TabIndex = 2;
            label3.Text = "To";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(11, 20, 50);
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(46, 62);
            label2.Name = "label2";
            label2.Size = new Size(104, 28);
            label2.TabIndex = 2;
            label2.Text = "Date from:";
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1043, 117);
            button1.Name = "button1";
            button1.Size = new Size(213, 112);
            button1.TabIndex = 1;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(11, 20, 50);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(22, 16);
            label1.Name = "label1";
            label1.Size = new Size(1250, 709);
            label1.TabIndex = 0;
            label1.Text = "   ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.FromArgb(11, 20, 60);
            label12.ForeColor = Color.White;
            label12.Location = new Point(320, 133);
            label12.Name = "label12";
            label12.Size = new Size(106, 20);
            label12.TabIndex = 14;
            label12.Text = "Total Expenses";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.FromArgb(11, 20, 60);
            label13.ForeColor = Color.White;
            label13.Location = new Point(547, 133);
            label13.Name = "label13";
            label13.Size = new Size(56, 20);
            label13.TabIndex = 15;
            label13.Text = "Margin";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGridView1.Location = new Point(46, 241);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(598, 468);
            dataGridView1.TabIndex = 16;
            // 
            // Column1
            // 
            Column1.HeaderText = "Date";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Tenant";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Amount";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(11, 20, 60);
            label9.Font = new Font("Segoe UI", 15F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(147, 163);
            label9.Name = "label9";
            label9.Size = new Size(81, 35);
            label9.TabIndex = 17;
            label9.Text = "label9";
            // 
            // ReportsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(panel1);
            Name = "ReportsControl";
            Size = new Size(1300, 750);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Button button1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button button2;
        private Label label11;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Label label13;
        private Label label12;
        private Label label9;
    }
}
