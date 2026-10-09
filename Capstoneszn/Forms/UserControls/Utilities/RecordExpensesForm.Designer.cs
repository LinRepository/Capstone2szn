namespace Capstoneszn.Forms.UserControls.Utilities
{
    partial class RecordExpensesForm
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
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(69, 24);
            label1.Name = "label1";
            label1.Size = new Size(297, 20);
            label1.TabIndex = 0;
            label1.Text = "This payment will create an expense record.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(69, 99);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 0;
            label2.Text = "Date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(69, 122);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(306, 27);
            dateTimePicker1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(69, 177);
            label3.Name = "label3";
            label3.Size = new Size(83, 28);
            label3.TabIndex = 0;
            label3.Text = "Amount";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(69, 208);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "0.0 ";
            textBox1.Size = new Size(306, 51);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(81, 217);
            label4.Name = "label4";
            label4.Size = new Size(33, 38);
            label4.TabIndex = 0;
            label4.Text = "₱";
            // 
            // button1
            // 
            button1.Location = new Point(306, 302);
            button1.Name = "button1";
            button1.Size = new Size(112, 43);
            button1.TabIndex = 3;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(188, 302);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 43);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // RecordExpensesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(445, 366);
            Controls.Add(btnCancel);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RecordExpensesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RecordExpensesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private Button button1;
        private Button btnCancel;
    }
}