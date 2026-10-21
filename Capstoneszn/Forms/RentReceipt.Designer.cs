namespace Capstoneszn.Forms
{
    partial class RentReceipt
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
            label8 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label7 = new Label();
            label5 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(615, 103);
            panel1.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(493, 49);
            label8.Name = "label8";
            label8.Size = new Size(81, 25);
            label8.TabIndex = 0;
            label8.Text = "[Balance]";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(335, 49);
            label6.Name = "label6";
            label6.Size = new Size(87, 25);
            label6.TabIndex = 0;
            label6.Text = "[Amount]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(181, 49);
            label4.Name = "label4";
            label4.Size = new Size(94, 25);
            label4.TabIndex = 0;
            label4.Text = "[Due date]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(16, 49);
            label3.Name = "label3";
            label3.Size = new Size(115, 25);
            label3.TabIndex = 0;
            label3.Text = "[Rent month]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(44, 15);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 0;
            label2.Text = "Period";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(503, 15);
            label7.Name = "label7";
            label7.Size = new Size(71, 25);
            label7.TabIndex = 0;
            label7.Text = "Balance";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(324, 15);
            label5.Name = "label5";
            label5.Size = new Size(112, 25);
            label5.TabIndex = 0;
            label5.Text = "Amount due";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(191, 15);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 0;
            label1.Text = "Due date";
            // 
            // RentReceipt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            Controls.Add(panel1);
            Name = "RentReceipt";
            Size = new Size(615, 103);
            Load += RentReceipt_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label8;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
        private Label label5;
        private Label label1;
    }
}
