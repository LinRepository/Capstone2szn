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
            pnlNotificationSearchContainer = new Panel();
            txtNotificationSearch = new TextBox();
            picNotificationSearch = new PictureBox();
            btnNotificationMarkAsRead = new Button();
            btnNotificationDelete = new Button();
            pnlNotificationContent = new Panel();
            flpNotifications = new FlowLayoutPanel();
            panel1 = new Panel();
            pnlNotificationHeader.SuspendLayout();
            pnlNotificationHeaderContent.SuspendLayout();
            pnlNotificationSearchContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picNotificationSearch).BeginInit();
            pnlNotificationContent.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlNotificationHeader
            // 
            pnlNotificationHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlNotificationHeader.Controls.Add(lblNotificationTitle);
            pnlNotificationHeader.Dock = DockStyle.Top;
            pnlNotificationHeader.Location = new Point(10, 10);
            pnlNotificationHeader.Name = "pnlNotificationHeader";
            pnlNotificationHeader.Size = new Size(1280, 85);
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
            lblNotificationTitle.Size = new Size(1278, 83);
            lblNotificationTitle.TabIndex = 7;
            lblNotificationTitle.Text = "Notification";
            lblNotificationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNotificationHeaderContent
            // 
            pnlNotificationHeaderContent.BorderStyle = BorderStyle.FixedSingle;
            pnlNotificationHeaderContent.Controls.Add(panel1);
            pnlNotificationHeaderContent.Controls.Add(pnlNotificationSearchContainer);
            pnlNotificationHeaderContent.Dock = DockStyle.Top;
            pnlNotificationHeaderContent.Location = new Point(10, 95);
            pnlNotificationHeaderContent.Name = "pnlNotificationHeaderContent";
            pnlNotificationHeaderContent.Size = new Size(1280, 75);
            pnlNotificationHeaderContent.TabIndex = 1;
            // 
            // pnlNotificationSearchContainer
            // 
            pnlNotificationSearchContainer.BackColor = Color.Transparent;
            pnlNotificationSearchContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlNotificationSearchContainer.Controls.Add(txtNotificationSearch);
            pnlNotificationSearchContainer.Controls.Add(picNotificationSearch);
            pnlNotificationSearchContainer.Dock = DockStyle.Left;
            pnlNotificationSearchContainer.Location = new Point(0, 0);
            pnlNotificationSearchContainer.Name = "pnlNotificationSearchContainer";
            pnlNotificationSearchContainer.Size = new Size(450, 73);
            pnlNotificationSearchContainer.TabIndex = 4;
            // 
            // txtNotificationSearch
            // 
            txtNotificationSearch.Cursor = Cursors.IBeam;
            txtNotificationSearch.Location = new Point(14, 14);
            txtNotificationSearch.Multiline = true;
            txtNotificationSearch.Name = "txtNotificationSearch";
            txtNotificationSearch.Size = new Size(376, 40);
            txtNotificationSearch.TabIndex = 0;
            txtNotificationSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // picNotificationSearch
            // 
            picNotificationSearch.BackColor = Color.White;
            picNotificationSearch.Cursor = Cursors.Hand;
            picNotificationSearch.Location = new Point(396, 14);
            picNotificationSearch.Name = "picNotificationSearch";
            picNotificationSearch.Size = new Size(40, 40);
            picNotificationSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picNotificationSearch.TabIndex = 1;
            picNotificationSearch.TabStop = false;
            // 
            // btnNotificationMarkAsRead
            // 
            btnNotificationMarkAsRead.Location = new Point(163, 26);
            btnNotificationMarkAsRead.Name = "btnNotificationMarkAsRead";
            btnNotificationMarkAsRead.Size = new Size(110, 29);
            btnNotificationMarkAsRead.TabIndex = 1;
            btnNotificationMarkAsRead.Text = "Mark as Read";
            btnNotificationMarkAsRead.UseVisualStyleBackColor = true;
            // 
            // btnNotificationDelete
            // 
            btnNotificationDelete.Location = new Point(39, 26);
            btnNotificationDelete.Name = "btnNotificationDelete";
            btnNotificationDelete.Size = new Size(95, 29);
            btnNotificationDelete.TabIndex = 0;
            btnNotificationDelete.Text = "Delete";
            btnNotificationDelete.UseVisualStyleBackColor = true;
            // 
            // pnlNotificationContent
            // 
            pnlNotificationContent.Controls.Add(flpNotifications);
            pnlNotificationContent.Dock = DockStyle.Fill;
            pnlNotificationContent.Location = new Point(10, 170);
            pnlNotificationContent.Name = "pnlNotificationContent";
            pnlNotificationContent.Padding = new Padding(10);
            pnlNotificationContent.Size = new Size(1280, 570);
            pnlNotificationContent.TabIndex = 2;
            // 
            // flpNotifications
            // 
            flpNotifications.Dock = DockStyle.Fill;
            flpNotifications.Location = new Point(10, 10);
            flpNotifications.Name = "flpNotifications";
            flpNotifications.Size = new Size(1260, 550);
            flpNotifications.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnNotificationDelete);
            panel1.Controls.Add(btnNotificationMarkAsRead);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(978, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 73);
            panel1.TabIndex = 5;
            // 
            // NotificationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
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
            pnlNotificationSearchContainer.ResumeLayout(false);
            pnlNotificationSearchContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picNotificationSearch).EndInit();
            pnlNotificationContent.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlNotificationHeader;
        private Label lblNotificationTitle;
        private Panel pnlNotificationHeaderContent;
        private Panel pnlNotificationContent;
        private FlowLayoutPanel flpNotifications;
        private Button btnNotificationMarkAsRead;
        private Button btnNotificationDelete;
        private Panel pnlNotificationSearchContainer;
        private TextBox txtNotificationSearch;
        private PictureBox picNotificationSearch;
        private Panel panel1;
    }
}
