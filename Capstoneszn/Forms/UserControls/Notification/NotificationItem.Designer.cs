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
            lblTitle = new Label();
            panel1 = new Panel();
            lblDays = new Label();
            lblDescription = new Label();
            pnlColourStrip = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(37, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(228, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Notification Title (Rent Due)";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pnlColourStrip);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1278, 80);
            panel1.TabIndex = 2;
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDays.ForeColor = Color.White;
            lblDays.Location = new Point(42, 10);
            lblDays.Name = "lblDays";
            lblDays.Size = new Size(148, 28);
            lblDays.TabIndex = 2;
            lblDays.Text = "Due or overdue";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(37, 41);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(301, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description (Near due for room 202)";
            // 
            // pnlColourStrip
            // 
            pnlColourStrip.Dock = DockStyle.Left;
            pnlColourStrip.Location = new Point(0, 0);
            pnlColourStrip.Name = "pnlColourStrip";
            pnlColourStrip.Size = new Size(57, 80);
            pnlColourStrip.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lblDays);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(1053, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(225, 80);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblDescription);
            panel3.Controls.Add(lblTitle);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(57, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(996, 80);
            panel3.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(42, 38);
            label1.Name = "label1";
            label1.Size = new Size(132, 28);
            label1.TabIndex = 2;
            label1.Text = "View billing >";
            // 
            // NotificationItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel1);
            Cursor = Cursors.Hand;
            Name = "NotificationItem";
            Size = new Size(1278, 80);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Panel panel1;
        private Label lblDays;
        private Label lblDescription;
        private Panel pnlColourStrip;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
    }
}
