namespace Capstoneszn.UserControls
{
    partial class RoomsControl
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
            pnlRoomsHeader = new Panel();
            lblRoomsTitle = new Label();
            pnlRoomsHeaderContent = new Panel();
            panel5 = new Panel();
            btnAddRoom = new Button();
            panel4 = new Panel();
            btnArchiveRoom = new Button();
            panel3 = new Panel();
            lblLegendMaintenance = new Label();
            pnlLegendMaintenance = new Panel();
            panel2 = new Panel();
            lblLegendOccupied = new Label();
            pnlLegendOccupied = new Panel();
            panel1 = new Panel();
            lblLegendAvailable = new Label();
            pnlLegendAvailable = new Panel();
            pnlRoomsContent = new Panel();
            flpRoomsOverview = new FlowLayoutPanel();
            pnlRoomsHeader.SuspendLayout();
            pnlRoomsHeaderContent.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            pnlRoomsContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomsHeader
            // 
            pnlRoomsHeader.Controls.Add(lblRoomsTitle);
            pnlRoomsHeader.Dock = DockStyle.Top;
            pnlRoomsHeader.Location = new Point(5, 5);
            pnlRoomsHeader.Margin = new Padding(0);
            pnlRoomsHeader.Name = "pnlRoomsHeader";
            pnlRoomsHeader.Size = new Size(1290, 85);
            pnlRoomsHeader.TabIndex = 0;
            // 
            // lblRoomsTitle
            // 
            lblRoomsTitle.BorderStyle = BorderStyle.FixedSingle;
            lblRoomsTitle.Dock = DockStyle.Fill;
            lblRoomsTitle.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomsTitle.ForeColor = Color.White;
            lblRoomsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomsTitle.Location = new Point(0, 0);
            lblRoomsTitle.Margin = new Padding(0);
            lblRoomsTitle.Name = "lblRoomsTitle";
            lblRoomsTitle.Size = new Size(1290, 85);
            lblRoomsTitle.TabIndex = 23;
            lblRoomsTitle.Text = "Rooms";
            lblRoomsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomsHeaderContent
            // 
            pnlRoomsHeaderContent.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomsHeaderContent.Controls.Add(panel5);
            pnlRoomsHeaderContent.Controls.Add(panel4);
            pnlRoomsHeaderContent.Controls.Add(panel3);
            pnlRoomsHeaderContent.Controls.Add(panel2);
            pnlRoomsHeaderContent.Controls.Add(panel1);
            pnlRoomsHeaderContent.Dock = DockStyle.Top;
            pnlRoomsHeaderContent.Location = new Point(5, 90);
            pnlRoomsHeaderContent.Name = "pnlRoomsHeaderContent";
            pnlRoomsHeaderContent.Padding = new Padding(10, 5, 10, 5);
            pnlRoomsHeaderContent.Size = new Size(1290, 70);
            pnlRoomsHeaderContent.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnAddRoom);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(1018, 5);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10);
            panel5.Size = new Size(130, 58);
            panel5.TabIndex = 34;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Dock = DockStyle.Fill;
            btnAddRoom.Location = new Point(10, 10);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(110, 38);
            btnAddRoom.TabIndex = 37;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnArchiveRoom);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1148, 5);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(130, 58);
            panel4.TabIndex = 33;
            // 
            // btnArchiveRoom
            // 
            btnArchiveRoom.Dock = DockStyle.Fill;
            btnArchiveRoom.Location = new Point(10, 10);
            btnArchiveRoom.Name = "btnArchiveRoom";
            btnArchiveRoom.Size = new Size(110, 38);
            btnArchiveRoom.TabIndex = 34;
            btnArchiveRoom.Text = "Archive Room";
            btnArchiveRoom.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblLegendMaintenance);
            panel3.Controls.Add(pnlLegendMaintenance);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(410, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 58);
            panel3.TabIndex = 32;
            // 
            // lblLegendMaintenance
            // 
            lblLegendMaintenance.AutoSize = true;
            lblLegendMaintenance.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLegendMaintenance.ForeColor = Color.White;
            lblLegendMaintenance.ImageAlign = ContentAlignment.MiddleRight;
            lblLegendMaintenance.Location = new Point(62, 17);
            lblLegendMaintenance.Margin = new Padding(0);
            lblLegendMaintenance.Name = "lblLegendMaintenance";
            lblLegendMaintenance.Size = new Size(112, 25);
            lblLegendMaintenance.TabIndex = 28;
            lblLegendMaintenance.Text = "Maintenance";
            lblLegendMaintenance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLegendMaintenance
            // 
            pnlLegendMaintenance.BackColor = Color.LightSlateGray;
            pnlLegendMaintenance.Location = new Point(35, 17);
            pnlLegendMaintenance.Name = "pnlLegendMaintenance";
            pnlLegendMaintenance.Size = new Size(25, 25);
            pnlLegendMaintenance.TabIndex = 25;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblLegendOccupied);
            panel2.Controls.Add(pnlLegendOccupied);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(210, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 58);
            panel2.TabIndex = 31;
            // 
            // lblLegendOccupied
            // 
            lblLegendOccupied.AutoSize = true;
            lblLegendOccupied.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLegendOccupied.ForeColor = Color.White;
            lblLegendOccupied.ImageAlign = ContentAlignment.MiddleRight;
            lblLegendOccupied.Location = new Point(70, 17);
            lblLegendOccupied.Margin = new Padding(0);
            lblLegendOccupied.Name = "lblLegendOccupied";
            lblLegendOccupied.Size = new Size(87, 25);
            lblLegendOccupied.TabIndex = 27;
            lblLegendOccupied.Text = "Occupied";
            lblLegendOccupied.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLegendOccupied
            // 
            pnlLegendOccupied.BackColor = Color.Crimson;
            pnlLegendOccupied.Location = new Point(42, 17);
            pnlLegendOccupied.Name = "pnlLegendOccupied";
            pnlLegendOccupied.Size = new Size(25, 25);
            pnlLegendOccupied.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblLegendAvailable);
            panel1.Controls.Add(pnlLegendAvailable);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(10, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 58);
            panel1.TabIndex = 30;
            // 
            // lblLegendAvailable
            // 
            lblLegendAvailable.AutoSize = true;
            lblLegendAvailable.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLegendAvailable.ForeColor = Color.White;
            lblLegendAvailable.ImageAlign = ContentAlignment.MiddleRight;
            lblLegendAvailable.Location = new Point(63, 17);
            lblLegendAvailable.Margin = new Padding(0);
            lblLegendAvailable.Name = "lblLegendAvailable";
            lblLegendAvailable.Size = new Size(83, 25);
            lblLegendAvailable.TabIndex = 26;
            lblLegendAvailable.Text = "Available";
            lblLegendAvailable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLegendAvailable
            // 
            pnlLegendAvailable.BackColor = Color.Chartreuse;
            pnlLegendAvailable.Location = new Point(35, 17);
            pnlLegendAvailable.Name = "pnlLegendAvailable";
            pnlLegendAvailable.Size = new Size(25, 25);
            pnlLegendAvailable.TabIndex = 23;
            // 
            // pnlRoomsContent
            // 
            pnlRoomsContent.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomsContent.Controls.Add(flpRoomsOverview);
            pnlRoomsContent.Dock = DockStyle.Fill;
            pnlRoomsContent.Location = new Point(5, 160);
            pnlRoomsContent.Name = "pnlRoomsContent";
            pnlRoomsContent.Size = new Size(1290, 585);
            pnlRoomsContent.TabIndex = 2;
            // 
            // flpRoomsOverview
            // 
            flpRoomsOverview.AutoScroll = true;
            flpRoomsOverview.Dock = DockStyle.Fill;
            flpRoomsOverview.FlowDirection = FlowDirection.TopDown;
            flpRoomsOverview.Location = new Point(0, 0);
            flpRoomsOverview.Name = "flpRoomsOverview";
            flpRoomsOverview.Size = new Size(1288, 583);
            flpRoomsOverview.TabIndex = 0;
            flpRoomsOverview.WrapContents = false;
            flpRoomsOverview.Paint += flpRoomsOverview_Paint;
            // 
            // RoomsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlRoomsContent);
            Controls.Add(pnlRoomsHeaderContent);
            Controls.Add(pnlRoomsHeader);
            Name = "RoomsControl";
            Padding = new Padding(5);
            Size = new Size(1300, 750);
            Load += RoomsControl_Load;
            pnlRoomsHeader.ResumeLayout(false);
            pnlRoomsHeaderContent.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlRoomsContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoomsHeader;
        private Panel pnlRoomsHeaderContent;
        private Label lblRoomsTitle;
        private Label lblLegendMaintenance;
        private Label lblLegendOccupied;
        private Label lblLegendAvailable;
        private Panel pnlLegendMaintenance;
        private Panel pnlLegendOccupied;
        private Panel pnlLegendAvailable;
        private Panel pnlRoomsContent;
        private FlowLayoutPanel flpRoomsOverview;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Button btnArchiveRoom;
        private Panel panel5;
        private Panel panel4;
        private Button btnAddRoom;
    }
}
