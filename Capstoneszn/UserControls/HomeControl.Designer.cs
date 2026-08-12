namespace Capstoneszn.UserControls
{
    partial class HomeControl
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
            flpDashBoardCards = new FlowLayoutPanel();
            panel1 = new Panel();
            lblAvailableCount = new Label();
            lblAvailableTitle = new Label();
            panel2 = new Panel();
            lblOccupancyRate = new Label();
            lblOccupancyTitle = new Label();
            panel3 = new Panel();
            lblTotalCount = new Label();
            lblTotalTitle = new Label();
            tblDashBoard = new TableLayoutPanel();
            pnlRecentActivities = new Panel();
            lvRecentActivities = new ListView();
            Time = new ColumnHeader();
            Activity = new ColumnHeader();
            btnViewAllActivities = new Button();
            lblRecentActivitiesTitle = new Label();
            pnlNotificationView = new Panel();
            listView1 = new ListView();
            Date = new ColumnHeader();
            Description = new ColumnHeader();
            btnViewAllNotifications = new Button();
            lblNotificationTitle = new Label();
            pnlRoomOverview = new Panel();
            lblRoomOverviewTitle = new Label();
            pnlMaintenanceView = new Panel();
            dgvMaintenance = new DataGridView();
            Room = new DataGridViewTextBoxColumn();
            Issue = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            btnViewAllMaintenance = new Button();
            lblMaintenanceTitle = new Label();
            pnlRoomHeader = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            lblAvailable = new Label();
            lblOccupied = new Label();
            lblMaintenance = new Label();
            flpRoomOverview = new FlowLayoutPanel();
            flpDashBoardCards.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tblDashBoard.SuspendLayout();
            pnlRecentActivities.SuspendLayout();
            pnlNotificationView.SuspendLayout();
            pnlRoomOverview.SuspendLayout();
            pnlMaintenanceView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).BeginInit();
            pnlRoomHeader.SuspendLayout();
            SuspendLayout();
            // 
            // flpDashBoardCards
            // 
            flpDashBoardCards.BackColor = Color.Transparent;
            flpDashBoardCards.Controls.Add(panel1);
            flpDashBoardCards.Controls.Add(panel2);
            flpDashBoardCards.Controls.Add(panel3);
            flpDashBoardCards.Dock = DockStyle.Top;
            flpDashBoardCards.Location = new Point(20, 20);
            flpDashBoardCards.Margin = new Padding(0);
            flpDashBoardCards.Name = "flpDashBoardCards";
            flpDashBoardCards.Size = new Size(1261, 130);
            flpDashBoardCards.TabIndex = 0;
            flpDashBoardCards.WrapContents = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblAvailableCount);
            panel1.Controls.Add(lblAvailableTitle);
            panel1.Location = new Point(45, 2);
            panel1.Margin = new Padding(45, 2, 45, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(325, 125);
            panel1.TabIndex = 0;
            // 
            // lblAvailableCount
            // 
            lblAvailableCount.AutoSize = true;
            lblAvailableCount.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvailableCount.ForeColor = Color.White;
            lblAvailableCount.ImageAlign = ContentAlignment.MiddleRight;
            lblAvailableCount.Location = new Point(240, 51);
            lblAvailableCount.Margin = new Padding(0);
            lblAvailableCount.Name = "lblAvailableCount";
            lblAvailableCount.Size = new Size(28, 35);
            lblAvailableCount.TabIndex = 6;
            lblAvailableCount.Text = "0";
            lblAvailableCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAvailableTitle
            // 
            lblAvailableTitle.AutoSize = true;
            lblAvailableTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvailableTitle.ForeColor = Color.White;
            lblAvailableTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAvailableTitle.Location = new Point(30, 51);
            lblAvailableTitle.Margin = new Padding(0);
            lblAvailableTitle.Name = "lblAvailableTitle";
            lblAvailableTitle.Size = new Size(178, 35);
            lblAvailableTitle.TabIndex = 3;
            lblAvailableTitle.Text = "Available Units";
            lblAvailableTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblOccupancyRate);
            panel2.Controls.Add(lblOccupancyTitle);
            panel2.Location = new Point(460, 2);
            panel2.Margin = new Padding(45, 2, 45, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(325, 125);
            panel2.TabIndex = 1;
            // 
            // lblOccupancyRate
            // 
            lblOccupancyRate.AutoSize = true;
            lblOccupancyRate.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOccupancyRate.ForeColor = Color.White;
            lblOccupancyRate.ImageAlign = ContentAlignment.MiddleRight;
            lblOccupancyRate.Location = new Point(223, 51);
            lblOccupancyRate.Margin = new Padding(0);
            lblOccupancyRate.Name = "lblOccupancyRate";
            lblOccupancyRate.Size = new Size(28, 35);
            lblOccupancyRate.TabIndex = 6;
            lblOccupancyRate.Text = "0";
            lblOccupancyRate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOccupancyTitle
            // 
            lblOccupancyTitle.AutoSize = true;
            lblOccupancyTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOccupancyTitle.ForeColor = Color.White;
            lblOccupancyTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblOccupancyTitle.Location = new Point(52, 51);
            lblOccupancyTitle.Margin = new Padding(0);
            lblOccupancyTitle.Name = "lblOccupancyTitle";
            lblOccupancyTitle.Size = new Size(138, 35);
            lblOccupancyTitle.TabIndex = 4;
            lblOccupancyTitle.Text = "Occupancy";
            lblOccupancyTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTotalCount);
            panel3.Controls.Add(lblTotalTitle);
            panel3.Location = new Point(875, 2);
            panel3.Margin = new Padding(45, 2, 45, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(325, 125);
            panel3.TabIndex = 2;
            // 
            // lblTotalCount
            // 
            lblTotalCount.AutoSize = true;
            lblTotalCount.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalCount.ForeColor = Color.White;
            lblTotalCount.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalCount.Location = new Point(225, 51);
            lblTotalCount.Margin = new Padding(0);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(28, 35);
            lblTotalCount.TabIndex = 6;
            lblTotalCount.Text = "0";
            lblTotalCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalTitle.ForeColor = Color.White;
            lblTotalTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTotalTitle.Location = new Point(67, 51);
            lblTotalTitle.Margin = new Padding(0);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(131, 35);
            lblTotalTitle.TabIndex = 5;
            lblTotalTitle.Text = "Total Units";
            lblTotalTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblDashBoard
            // 
            tblDashBoard.BackColor = Color.Transparent;
            tblDashBoard.ColumnCount = 2;
            tblDashBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tblDashBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblDashBoard.Controls.Add(pnlRecentActivities, 0, 0);
            tblDashBoard.Controls.Add(pnlNotificationView, 1, 0);
            tblDashBoard.Controls.Add(pnlRoomOverview, 0, 1);
            tblDashBoard.Controls.Add(pnlMaintenanceView, 1, 1);
            tblDashBoard.Dock = DockStyle.Fill;
            tblDashBoard.Location = new Point(20, 150);
            tblDashBoard.Margin = new Padding(0);
            tblDashBoard.Name = "tblDashBoard";
            tblDashBoard.RowCount = 2;
            tblDashBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblDashBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tblDashBoard.Size = new Size(1261, 580);
            tblDashBoard.TabIndex = 1;
            // 
            // pnlRecentActivities
            // 
            pnlRecentActivities.Controls.Add(lvRecentActivities);
            pnlRecentActivities.Controls.Add(btnViewAllActivities);
            pnlRecentActivities.Controls.Add(lblRecentActivitiesTitle);
            pnlRecentActivities.Dock = DockStyle.Fill;
            pnlRecentActivities.Location = new Point(5, 5);
            pnlRecentActivities.Margin = new Padding(5);
            pnlRecentActivities.Name = "pnlRecentActivities";
            pnlRecentActivities.Padding = new Padding(10);
            pnlRecentActivities.Size = new Size(872, 183);
            pnlRecentActivities.TabIndex = 0;
            // 
            // lvRecentActivities
            // 
            lvRecentActivities.Columns.AddRange(new ColumnHeader[] { Time, Activity });
            lvRecentActivities.Location = new Point(10, 45);
            lvRecentActivities.Name = "lvRecentActivities";
            lvRecentActivities.Size = new Size(849, 133);
            lvRecentActivities.TabIndex = 11;
            lvRecentActivities.UseCompatibleStateImageBehavior = false;
            // 
            // btnViewAllActivities
            // 
            btnViewAllActivities.Location = new Point(765, 10);
            btnViewAllActivities.Name = "btnViewAllActivities";
            btnViewAllActivities.Size = new Size(94, 29);
            btnViewAllActivities.TabIndex = 10;
            btnViewAllActivities.Text = "View All";
            btnViewAllActivities.UseVisualStyleBackColor = true;
            // 
            // lblRecentActivitiesTitle
            // 
            lblRecentActivitiesTitle.AutoSize = true;
            lblRecentActivitiesTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecentActivitiesTitle.ForeColor = Color.White;
            lblRecentActivitiesTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRecentActivitiesTitle.Location = new Point(10, 7);
            lblRecentActivitiesTitle.Margin = new Padding(0);
            lblRecentActivitiesTitle.Name = "lblRecentActivitiesTitle";
            lblRecentActivitiesTitle.Size = new Size(154, 28);
            lblRecentActivitiesTitle.TabIndex = 9;
            lblRecentActivitiesTitle.Text = "Recent Activities";
            lblRecentActivitiesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNotificationView
            // 
            pnlNotificationView.Controls.Add(listView1);
            pnlNotificationView.Controls.Add(btnViewAllNotifications);
            pnlNotificationView.Controls.Add(lblNotificationTitle);
            pnlNotificationView.Dock = DockStyle.Fill;
            pnlNotificationView.Location = new Point(887, 5);
            pnlNotificationView.Margin = new Padding(5);
            pnlNotificationView.Name = "pnlNotificationView";
            pnlNotificationView.Padding = new Padding(10);
            pnlNotificationView.Size = new Size(369, 183);
            pnlNotificationView.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { Date, Description });
            listView1.Location = new Point(13, 45);
            listView1.Name = "listView1";
            listView1.Size = new Size(343, 130);
            listView1.TabIndex = 9;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnViewAllNotifications
            // 
            btnViewAllNotifications.Location = new Point(262, 10);
            btnViewAllNotifications.Name = "btnViewAllNotifications";
            btnViewAllNotifications.Size = new Size(94, 29);
            btnViewAllNotifications.TabIndex = 8;
            btnViewAllNotifications.Text = "View All";
            btnViewAllNotifications.UseVisualStyleBackColor = true;
            // 
            // lblNotificationTitle
            // 
            lblNotificationTitle.AutoSize = true;
            lblNotificationTitle.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNotificationTitle.ForeColor = Color.White;
            lblNotificationTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblNotificationTitle.Location = new Point(13, 10);
            lblNotificationTitle.Margin = new Padding(0);
            lblNotificationTitle.Name = "lblNotificationTitle";
            lblNotificationTitle.Size = new Size(134, 31);
            lblNotificationTitle.TabIndex = 7;
            lblNotificationTitle.Text = "Notification";
            lblNotificationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomOverview
            // 
            pnlRoomOverview.Controls.Add(flpRoomOverview);
            pnlRoomOverview.Controls.Add(pnlRoomHeader);
            pnlRoomOverview.Dock = DockStyle.Fill;
            pnlRoomOverview.Location = new Point(5, 198);
            pnlRoomOverview.Margin = new Padding(5);
            pnlRoomOverview.Name = "pnlRoomOverview";
            pnlRoomOverview.Padding = new Padding(5);
            pnlRoomOverview.Size = new Size(872, 377);
            pnlRoomOverview.TabIndex = 2;
            // 
            // lblRoomOverviewTitle
            // 
            lblRoomOverviewTitle.AutoSize = true;
            lblRoomOverviewTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomOverviewTitle.ForeColor = Color.White;
            lblRoomOverviewTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomOverviewTitle.Location = new Point(6, 6);
            lblRoomOverviewTitle.Margin = new Padding(0);
            lblRoomOverviewTitle.Name = "lblRoomOverviewTitle";
            lblRoomOverviewTitle.Size = new Size(190, 35);
            lblRoomOverviewTitle.TabIndex = 9;
            lblRoomOverviewTitle.Text = "Room Overview";
            lblRoomOverviewTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMaintenanceView
            // 
            pnlMaintenanceView.Controls.Add(dgvMaintenance);
            pnlMaintenanceView.Controls.Add(btnViewAllMaintenance);
            pnlMaintenanceView.Controls.Add(lblMaintenanceTitle);
            pnlMaintenanceView.Dock = DockStyle.Fill;
            pnlMaintenanceView.Location = new Point(887, 198);
            pnlMaintenanceView.Margin = new Padding(5);
            pnlMaintenanceView.Name = "pnlMaintenanceView";
            pnlMaintenanceView.Padding = new Padding(10);
            pnlMaintenanceView.Size = new Size(369, 377);
            pnlMaintenanceView.TabIndex = 3;
            // 
            // dgvMaintenance
            // 
            dgvMaintenance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaintenance.Columns.AddRange(new DataGridViewColumn[] { Room, Issue, Status });
            dgvMaintenance.Location = new Point(13, 48);
            dgvMaintenance.Name = "dgvMaintenance";
            dgvMaintenance.RowHeadersWidth = 51;
            dgvMaintenance.Size = new Size(343, 316);
            dgvMaintenance.TabIndex = 10;
            // 
            // Room
            // 
            Room.HeaderText = "Room";
            Room.MinimumWidth = 6;
            Room.Name = "Room";
            Room.Width = 125;
            // 
            // Issue
            // 
            Issue.HeaderText = "Issue";
            Issue.MinimumWidth = 6;
            Issue.Name = "Issue";
            Issue.Width = 125;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // btnViewAllMaintenance
            // 
            btnViewAllMaintenance.Location = new Point(262, 13);
            btnViewAllMaintenance.Name = "btnViewAllMaintenance";
            btnViewAllMaintenance.Size = new Size(94, 29);
            btnViewAllMaintenance.TabIndex = 9;
            btnViewAllMaintenance.Text = "View All";
            btnViewAllMaintenance.UseVisualStyleBackColor = true;
            // 
            // lblMaintenanceTitle
            // 
            lblMaintenanceTitle.AutoSize = true;
            lblMaintenanceTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceTitle.ForeColor = Color.White;
            lblMaintenanceTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMaintenanceTitle.Location = new Point(10, 10);
            lblMaintenanceTitle.Margin = new Padding(0);
            lblMaintenanceTitle.Name = "lblMaintenanceTitle";
            lblMaintenanceTitle.Size = new Size(170, 28);
            lblMaintenanceTitle.TabIndex = 8;
            lblMaintenanceTitle.Text = "Maintenance View";
            lblMaintenanceTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomHeader
            // 
            pnlRoomHeader.Controls.Add(lblMaintenance);
            pnlRoomHeader.Controls.Add(lblOccupied);
            pnlRoomHeader.Controls.Add(lblAvailable);
            pnlRoomHeader.Controls.Add(panel6);
            pnlRoomHeader.Controls.Add(panel5);
            pnlRoomHeader.Controls.Add(panel4);
            pnlRoomHeader.Controls.Add(lblRoomOverviewTitle);
            pnlRoomHeader.Dock = DockStyle.Top;
            pnlRoomHeader.Location = new Point(5, 5);
            pnlRoomHeader.Margin = new Padding(1);
            pnlRoomHeader.Name = "pnlRoomHeader";
            pnlRoomHeader.Size = new Size(862, 46);
            pnlRoomHeader.TabIndex = 11;
            // 
            // panel4
            // 
            panel4.Location = new Point(233, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(25, 25);
            panel4.TabIndex = 10;
            // 
            // panel5
            // 
            panel5.Location = new Point(419, 12);
            panel5.Name = "panel5";
            panel5.Size = new Size(25, 25);
            panel5.TabIndex = 11;
            // 
            // panel6
            // 
            panel6.Location = new Point(589, 12);
            panel6.Name = "panel6";
            panel6.Size = new Size(25, 25);
            panel6.TabIndex = 12;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvailable.ForeColor = Color.White;
            lblAvailable.ImageAlign = ContentAlignment.MiddleRight;
            lblAvailable.Location = new Point(261, 12);
            lblAvailable.Margin = new Padding(0);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(83, 25);
            lblAvailable.TabIndex = 13;
            lblAvailable.Text = "Available";
            lblAvailable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOccupied
            // 
            lblOccupied.AutoSize = true;
            lblOccupied.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOccupied.ForeColor = Color.White;
            lblOccupied.ImageAlign = ContentAlignment.MiddleRight;
            lblOccupied.Location = new Point(447, 12);
            lblOccupied.Margin = new Padding(0);
            lblOccupied.Name = "lblOccupied";
            lblOccupied.Size = new Size(87, 25);
            lblOccupied.TabIndex = 14;
            lblOccupied.Text = "Occupied";
            lblOccupied.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaintenance
            // 
            lblMaintenance.AutoSize = true;
            lblMaintenance.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenance.ForeColor = Color.White;
            lblMaintenance.ImageAlign = ContentAlignment.MiddleRight;
            lblMaintenance.Location = new Point(617, 12);
            lblMaintenance.Margin = new Padding(0);
            lblMaintenance.Name = "lblMaintenance";
            lblMaintenance.Size = new Size(112, 25);
            lblMaintenance.TabIndex = 15;
            lblMaintenance.Text = "Maintenance";
            lblMaintenance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpRoomOverview
            // 
            flpRoomOverview.AutoScroll = true;
            flpRoomOverview.Dock = DockStyle.Fill;
            flpRoomOverview.Location = new Point(5, 51);
            flpRoomOverview.Name = "flpRoomOverview";
            flpRoomOverview.Padding = new Padding(5);
            flpRoomOverview.Size = new Size(862, 321);
            flpRoomOverview.TabIndex = 12;
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(tblDashBoard);
            Controls.Add(flpDashBoardCards);
            DoubleBuffered = true;
            Margin = new Padding(0);
            Name = "HomeControl";
            Padding = new Padding(20);
            Size = new Size(1301, 750);
            Load += HomeControl_Load;
            flpDashBoardCards.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tblDashBoard.ResumeLayout(false);
            pnlRecentActivities.ResumeLayout(false);
            pnlRecentActivities.PerformLayout();
            pnlNotificationView.ResumeLayout(false);
            pnlNotificationView.PerformLayout();
            pnlRoomOverview.ResumeLayout(false);
            pnlMaintenanceView.ResumeLayout(false);
            pnlMaintenanceView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).EndInit();
            pnlRoomHeader.ResumeLayout(false);
            pnlRoomHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpDashBoardCards;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TableLayoutPanel tblDashBoard;
        private Panel pnlRecentActivities;
        private Panel pnlNotificationView;
        private Panel pnlRoomOverview;
        private Panel pnlMaintenanceView;
        private Label lblAvailableTitle;
        private Label lblOccupancyTitle;
        private Label lblTotalTitle;
        private Label lblAvailableCount;
        private Label lblOccupancyRate;
        private Label lblTotalCount;
        private Label lblMaintenanceTitle;
        private Label lblNotificationTitle;
        private Button btnViewAllNotifications;
        private ListView listView1;
        private ListView lvRecentActivities;
        private ColumnHeader Time;
        private ColumnHeader Activity;
        private Button btnViewAllActivities;
        private Label lblRecentActivitiesTitle;
        private ColumnHeader Date;
        private ColumnHeader Description;
        private Label lblRoomOverviewTitle;
        private DataGridView dgvMaintenance;
        private Button btnViewAllMaintenance;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn Issue;
        private DataGridViewTextBoxColumn Status;
        private Panel pnlRoomHeader;
        private Label lblMaintenance;
        private Label lblOccupied;
        private Label lblAvailable;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private FlowLayoutPanel flpRoomOverview;
    }
}
