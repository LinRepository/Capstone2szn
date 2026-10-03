namespace Capstoneszn.Forms.UserControls.Notification
{
    partial class NotificationItem
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
            label1 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 10);
            label1.Name = "label1";
            label1.Size = new Size(196, 20);
            label1.TabIndex = 0;
            label1.Text = "Notification Title (Rent Due)";
            // 
            // button1
            // 
            button1.Location = new Point(1158, 37);
            button1.Name = "button1";
            button1.Size = new Size(107, 29);
            button1.TabIndex = 1;
            button1.Text = "Mark as read";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1278, 77);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 41);
            label2.Name = "label2";
            label2.Size = new Size(251, 20);
            label2.TabIndex = 2;
            label2.Text = "Description (Near due for room 202)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(1158, 10);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 2;
            label3.Text = "Time (3m ago)";
            // 
            // NotificationItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel1);
            Name = "NotificationItem";
            Size = new Size(1278, 77);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Panel panel1;
        private Label label3;
        private Label label2;
    }
}
