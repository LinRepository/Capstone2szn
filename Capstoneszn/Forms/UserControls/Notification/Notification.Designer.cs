namespace Capstoneszn.Forms.UserControls
{
    partial class NotificationControl
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
            pnlNotificationHeader = new Panel();
            lblNotificationTitle = new Label();
            pnlNotificationHeaderContent = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel1 = new Panel();
            pnlNotificationSearchContainer = new Panel();
            txtNotificationSearch = new TextBox();
            pnlNotificationContent = new Panel();
            flpNotifications = new FlowLayoutPanel();
            pnlNotificationHeader.SuspendLayout();
            pnlNotificationHeaderContent.SuspendLayout();
            panel3.SuspendLayout();
            pnlNotificationSearchContainer.SuspendLayout();
            pnlNotificationContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlNotificationHeader
            // 
            pnlNotificationHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlNotificationHeader.Controls.Add(lblNotificationTitle);
            pnlNotificationHeader.Dock = DockStyle.Top;
            pnlNotificationHeader.Location = new Point(10, 10);
            pnlNotificationHeader.Name = "pnlNotificationHeader";
            pnlNotificationHeader.Size = new Size(1280, 53);
            pnlNotificationHeader.TabIndex = 0;
            // 
            // lblNotificationTitle
            // 
            lblNotificationTitle.Dock = DockStyle.Fill;
            lblNotificationTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNotificationTitle.ForeColor = Color.White;
            lblNotificationTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblNotificationTitle.Location = new Point(0, 0);
            lblNotificationTitle.Name = "lblNotificationTitle";
            lblNotificationTitle.Size = new Size(1278, 51);
            lblNotificationTitle.TabIndex = 7;
            lblNotificationTitle.Text = "Notification";
            lblNotificationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNotificationHeaderContent
            // 
            pnlNotificationHeaderContent.BorderStyle = BorderStyle.FixedSingle;
            pnlNotificationHeaderContent.Controls.Add(panel3);
            pnlNotificationHeaderContent.Controls.Add(pnlNotificationSearchContainer);
            pnlNotificationHeaderContent.Dock = DockStyle.Top;
            pnlNotificationHeaderContent.Location = new Point(10, 63);
            pnlNotificationHeaderContent.Name = "pnlNotificationHeaderContent";
            pnlNotificationHeaderContent.Size = new Size(1280, 57);
            pnlNotificationHeaderContent.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(panel1);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(948, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(330, 55);
            panel3.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(59, 16);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 6;
            label2.Text = "Near Due";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(233, 16);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 6;
            label1.Text = "Overdue";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkOrange;
            panel2.Location = new Point(18, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(35, 35);
            panel2.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Crimson;
            panel1.Location = new Point(192, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(35, 35);
            panel1.TabIndex = 5;
            // 
            // pnlNotificationSearchContainer
            // 
            pnlNotificationSearchContainer.BackColor = Color.Transparent;
            pnlNotificationSearchContainer.Controls.Add(txtNotificationSearch);
            pnlNotificationSearchContainer.Dock = DockStyle.Left;
            pnlNotificationSearchContainer.Location = new Point(0, 0);
            pnlNotificationSearchContainer.Name = "pnlNotificationSearchContainer";
            pnlNotificationSearchContainer.Size = new Size(398, 55);
            pnlNotificationSearchContainer.TabIndex = 4;
            // 
            // txtNotificationSearch
            // 
            txtNotificationSearch.Cursor = Cursors.IBeam;
            txtNotificationSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNotificationSearch.Location = new Point(9, 5);
            txtNotificationSearch.Multiline = true;
            txtNotificationSearch.Name = "txtNotificationSearch";
            txtNotificationSearch.PlaceholderText = "Search room number";
            txtNotificationSearch.Size = new Size(376, 40);
            txtNotificationSearch.TabIndex = 0;
            txtNotificationSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // pnlNotificationContent
            // 
            pnlNotificationContent.Controls.Add(flpNotifications);
            pnlNotificationContent.Dock = DockStyle.Fill;
            pnlNotificationContent.Location = new Point(10, 120);
            pnlNotificationContent.Name = "pnlNotificationContent";
            pnlNotificationContent.Padding = new Padding(10);
            pnlNotificationContent.Size = new Size(1280, 620);
            pnlNotificationContent.TabIndex = 2;
            // 
            // flpNotifications
            // 
            flpNotifications.Dock = DockStyle.Fill;
            flpNotifications.FlowDirection = FlowDirection.TopDown;
            flpNotifications.Location = new Point(10, 10);
            flpNotifications.Name = "flpNotifications";
            flpNotifications.Size = new Size(1260, 600);
            flpNotifications.TabIndex = 0;
            // 
            // NotificationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnlNotificationContent);
            Controls.Add(pnlNotificationHeaderContent);
            Controls.Add(pnlNotificationHeader);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Name = "NotificationControl";
            Padding = new Padding(10);
            Size = new Size(1300, 750);
            Load += NotificationControl_Load;
            pnlNotificationHeader.ResumeLayout(false);
            pnlNotificationHeaderContent.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlNotificationSearchContainer.ResumeLayout(false);
            pnlNotificationSearchContainer.PerformLayout();
            pnlNotificationContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlNotificationHeader;
        private Label lblNotificationTitle;
        private Panel pnlNotificationHeaderContent;
        private Panel pnlNotificationContent;
        private FlowLayoutPanel flpNotifications;
        private Panel pnlNotificationSearchContainer;
        private TextBox txtNotificationSearch;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Panel panel3;
    }
}
