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
            pnlHomeContent = new Panel();
            tblDashBoard = new TableLayoutPanel();
            pnlRecentActivities = new Panel();
            lvRecentActivities = new ListView();
            Time = new ColumnHeader();
            Activity = new ColumnHeader();
            pnlNestedHeaderRecentActivities = new Panel();
            btnViewAllActivities = new Button();
            lblRecentActivitiesTitle = new Label();
            pnlNotificationView = new Panel();
            lvNotification = new ListView();
            Date = new ColumnHeader();
            Description = new ColumnHeader();
            pnlNestedHeaderNotification = new Panel();
            btnViewAllNotifications = new Button();
            lblNotificationTitle = new Label();
            pnlRoomOverview = new Panel();
            flpRoomOverview = new FlowLayoutPanel();
            pnlNestedHeaderRoom = new Panel();
            lblMaintenance = new Label();
            lblOccupied = new Label();
            lblAvailable = new Label();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            lblRoomOverviewTitle = new Label();
            pnlMaintenanceView = new Panel();
            dgvMaintenance = new DataGridView();
            Room = new DataGridViewTextBoxColumn();
            Issue = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            pnlNestedHeaderMaintenanceView = new Panel();
            btnViewAllMaintenance = new Button();
            lblMaintenanceTitle = new Label();
            flpDashBoardCards.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            pnlHomeContent.SuspendLayout();
            tblDashBoard.SuspendLayout();
            pnlRecentActivities.SuspendLayout();
            pnlNestedHeaderRecentActivities.SuspendLayout();
            pnlNotificationView.SuspendLayout();
            pnlNestedHeaderNotification.SuspendLayout();
            pnlRoomOverview.SuspendLayout();
            pnlNestedHeaderRoom.SuspendLayout();
            pnlMaintenanceView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).BeginInit();
            pnlNestedHeaderMaintenanceView.SuspendLayout();
            SuspendLayout();
            // 
            // flpDashBoardCards
            // 
            flpDashBoardCards.BackColor = SystemColors.ActiveBorder;
            flpDashBoardCards.BorderStyle = BorderStyle.FixedSingle;
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
            panel1.BackColor = Color.Black;
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
            panel2.BackColor = Color.Black;
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
            panel3.BackColor = Color.Black;
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
            // pnlHomeContent
            // 
            pnlHomeContent.BorderStyle = BorderStyle.FixedSingle;
            pnlHomeContent.Controls.Add(tblDashBoard);
            pnlHomeContent.Dock = DockStyle.Fill;
            pnlHomeContent.Location = new Point(20, 150);
            pnlHomeContent.Name = "pnlHomeContent";
            pnlHomeContent.Size = new Size(1261, 580);
            pnlHomeContent.TabIndex = 1;
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
            tblDashBoard.Location = new Point(0, 0);
            tblDashBoard.Margin = new Padding(0);
            tblDashBoard.Name = "tblDashBoard";
            tblDashBoard.RowCount = 2;
            tblDashBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblDashBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tblDashBoard.Size = new Size(1259, 578);
            tblDashBoard.TabIndex = 2;
            // 
            // pnlRecentActivities
            // 
            pnlRecentActivities.Controls.Add(lvRecentActivities);
            pnlRecentActivities.Controls.Add(pnlNestedHeaderRecentActivities);
            pnlRecentActivities.Dock = DockStyle.Fill;
            pnlRecentActivities.Location = new Point(5, 5);
            pnlRecentActivities.Margin = new Padding(5);
            pnlRecentActivities.Name = "pnlRecentActivities";
            pnlRecentActivities.Padding = new Padding(10);
            pnlRecentActivities.Size = new Size(871, 182);
            pnlRecentActivities.TabIndex = 0;
            // 
            // lvRecentActivities
            // 
            lvRecentActivities.Columns.AddRange(new ColumnHeader[] { Time, Activity });
            lvRecentActivities.Dock = DockStyle.Fill;
            lvRecentActivities.Location = new Point(10, 55);
            lvRecentActivities.Name = "lvRecentActivities";
            lvRecentActivities.Size = new Size(851, 117);
            lvRecentActivities.TabIndex = 13;
            lvRecentActivities.UseCompatibleStateImageBehavior = false;
            // 
            // pnlNestedHeaderRecentActivities
            // 
            pnlNestedHeaderRecentActivities.BorderStyle = BorderStyle.FixedSingle;
            pnlNestedHeaderRecentActivities.Controls.Add(btnViewAllActivities);
            pnlNestedHeaderRecentActivities.Controls.Add(lblRecentActivitiesTitle);
            pnlNestedHeaderRecentActivities.Dock = DockStyle.Top;
            pnlNestedHeaderRecentActivities.Location = new Point(10, 10);
            pnlNestedHeaderRecentActivities.Name = "pnlNestedHeaderRecentActivities";
            pnlNestedHeaderRecentActivities.Padding = new Padding(5);
            pnlNestedHeaderRecentActivities.Size = new Size(851, 45);
            pnlNestedHeaderRecentActivities.TabIndex = 12;
            // 
            // btnViewAllActivities
            // 
            btnViewAllActivities.Cursor = Cursors.Hand;
            btnViewAllActivities.Dock = DockStyle.Right;
            btnViewAllActivities.Location = new Point(739, 5);
            btnViewAllActivities.Name = "btnViewAllActivities";
            btnViewAllActivities.Size = new Size(105, 33);
            btnViewAllActivities.TabIndex = 10;
            btnViewAllActivities.Text = "View All";
            btnViewAllActivities.UseVisualStyleBackColor = true;
            btnViewAllActivities.Click += btnViewAllActivities_Click;
            // 
            // lblRecentActivitiesTitle
            // 
            lblRecentActivitiesTitle.Dock = DockStyle.Left;
            lblRecentActivitiesTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecentActivitiesTitle.ForeColor = Color.White;
            lblRecentActivitiesTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRecentActivitiesTitle.Location = new Point(5, 5);
            lblRecentActivitiesTitle.Margin = new Padding(0);
            lblRecentActivitiesTitle.Name = "lblRecentActivitiesTitle";
            lblRecentActivitiesTitle.Size = new Size(250, 33);
            lblRecentActivitiesTitle.TabIndex = 9;
            lblRecentActivitiesTitle.Text = "Recent Activities";
            lblRecentActivitiesTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlNotificationView
            // 
            pnlNotificationView.Controls.Add(lvNotification);
            pnlNotificationView.Controls.Add(pnlNestedHeaderNotification);
            pnlNotificationView.Dock = DockStyle.Fill;
            pnlNotificationView.Location = new Point(886, 5);
            pnlNotificationView.Margin = new Padding(5);
            pnlNotificationView.Name = "pnlNotificationView";
            pnlNotificationView.Padding = new Padding(10);
            pnlNotificationView.Size = new Size(368, 182);
            pnlNotificationView.TabIndex = 1;
            // 
            // lvNotification
            // 
            lvNotification.Columns.AddRange(new ColumnHeader[] { Date, Description });
            lvNotification.Dock = DockStyle.Fill;
            lvNotification.Location = new Point(10, 55);
            lvNotification.Name = "lvNotification";
            lvNotification.Size = new Size(348, 117);
            lvNotification.TabIndex = 12;
            lvNotification.UseCompatibleStateImageBehavior = false;
            // 
            // pnlNestedHeaderNotification
            // 
            pnlNestedHeaderNotification.BorderStyle = BorderStyle.FixedSingle;
            pnlNestedHeaderNotification.Controls.Add(btnViewAllNotifications);
            pnlNestedHeaderNotification.Controls.Add(lblNotificationTitle);
            pnlNestedHeaderNotification.Dock = DockStyle.Top;
            pnlNestedHeaderNotification.Location = new Point(10, 10);
            pnlNestedHeaderNotification.Name = "pnlNestedHeaderNotification";
            pnlNestedHeaderNotification.Padding = new Padding(5);
            pnlNestedHeaderNotification.Size = new Size(348, 45);
            pnlNestedHeaderNotification.TabIndex = 10;
            // 
            // btnViewAllNotifications
            // 
            btnViewAllNotifications.Cursor = Cursors.Hand;
            btnViewAllNotifications.Dock = DockStyle.Right;
            btnViewAllNotifications.Location = new Point(236, 5);
            btnViewAllNotifications.Name = "btnViewAllNotifications";
            btnViewAllNotifications.Size = new Size(105, 33);
            btnViewAllNotifications.TabIndex = 9;
            btnViewAllNotifications.Text = "View All";
            btnViewAllNotifications.UseVisualStyleBackColor = true;
            btnViewAllNotifications.Click += btnViewAllNotifications_Click;
            // 
            // lblNotificationTitle
            // 
            lblNotificationTitle.Dock = DockStyle.Left;
            lblNotificationTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNotificationTitle.ForeColor = Color.White;
            lblNotificationTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblNotificationTitle.Location = new Point(5, 5);
            lblNotificationTitle.Margin = new Padding(0);
            lblNotificationTitle.Name = "lblNotificationTitle";
            lblNotificationTitle.Size = new Size(150, 33);
            lblNotificationTitle.TabIndex = 8;
            lblNotificationTitle.Text = "Notification";
            lblNotificationTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlRoomOverview
            // 
            pnlRoomOverview.BackColor = Color.FromArgb(11, 20, 38);
            pnlRoomOverview.Controls.Add(flpRoomOverview);
            pnlRoomOverview.Controls.Add(pnlNestedHeaderRoom);
            pnlRoomOverview.Dock = DockStyle.Fill;
            pnlRoomOverview.Location = new Point(5, 197);
            pnlRoomOverview.Margin = new Padding(5);
            pnlRoomOverview.Name = "pnlRoomOverview";
            pnlRoomOverview.Padding = new Padding(10);
            pnlRoomOverview.Size = new Size(871, 376);
            pnlRoomOverview.TabIndex = 2;
            // 
            // flpRoomOverview
            // 
            flpRoomOverview.AutoScroll = true;
            flpRoomOverview.BorderStyle = BorderStyle.FixedSingle;
            flpRoomOverview.Dock = DockStyle.Fill;
            flpRoomOverview.Location = new Point(10, 56);
            flpRoomOverview.Name = "flpRoomOverview";
            flpRoomOverview.Padding = new Padding(5);
            flpRoomOverview.Size = new Size(851, 310);
            flpRoomOverview.TabIndex = 12;
            // 
            // pnlNestedHeaderRoom
            // 
            pnlNestedHeaderRoom.BackColor = Color.SlateGray;
            pnlNestedHeaderRoom.Controls.Add(lblMaintenance);
            pnlNestedHeaderRoom.Controls.Add(lblOccupied);
            pnlNestedHeaderRoom.Controls.Add(lblAvailable);
            pnlNestedHeaderRoom.Controls.Add(panel6);
            pnlNestedHeaderRoom.Controls.Add(panel5);
            pnlNestedHeaderRoom.Controls.Add(panel4);
            pnlNestedHeaderRoom.Controls.Add(lblRoomOverviewTitle);
            pnlNestedHeaderRoom.Dock = DockStyle.Top;
            pnlNestedHeaderRoom.Location = new Point(10, 10);
            pnlNestedHeaderRoom.Margin = new Padding(1);
            pnlNestedHeaderRoom.Name = "pnlNestedHeaderRoom";
            pnlNestedHeaderRoom.Size = new Size(851, 46);
            pnlNestedHeaderRoom.TabIndex = 11;
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
            // panel6
            // 
            panel6.BackColor = Color.LightSlateGray;
            panel6.Location = new Point(589, 12);
            panel6.Name = "panel6";
            panel6.Size = new Size(25, 25);
            panel6.TabIndex = 12;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Crimson;
            panel5.Location = new Point(419, 12);
            panel5.Name = "panel5";
            panel5.Size = new Size(25, 25);
            panel5.TabIndex = 11;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Chartreuse;
            panel4.Location = new Point(233, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(25, 25);
            panel4.TabIndex = 10;
            // 
            // lblRoomOverviewTitle
            // 
            lblRoomOverviewTitle.BackColor = Color.Transparent;
            lblRoomOverviewTitle.Dock = DockStyle.Left;
            lblRoomOverviewTitle.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomOverviewTitle.ForeColor = Color.White;
            lblRoomOverviewTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomOverviewTitle.Location = new Point(0, 0);
            lblRoomOverviewTitle.Margin = new Padding(0);
            lblRoomOverviewTitle.Name = "lblRoomOverviewTitle";
            lblRoomOverviewTitle.Size = new Size(205, 46);
            lblRoomOverviewTitle.TabIndex = 9;
            lblRoomOverviewTitle.Text = "Room Overview";
            lblRoomOverviewTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlMaintenanceView
            // 
            pnlMaintenanceView.Controls.Add(dgvMaintenance);
            pnlMaintenanceView.Controls.Add(pnlNestedHeaderMaintenanceView);
            pnlMaintenanceView.Dock = DockStyle.Fill;
            pnlMaintenanceView.Location = new Point(886, 197);
            pnlMaintenanceView.Margin = new Padding(5);
            pnlMaintenanceView.Name = "pnlMaintenanceView";
            pnlMaintenanceView.Padding = new Padding(10);
            pnlMaintenanceView.Size = new Size(368, 376);
            pnlMaintenanceView.TabIndex = 3;
            // 
            // dgvMaintenance
            // 
            dgvMaintenance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaintenance.Columns.AddRange(new DataGridViewColumn[] { Room, Issue, Status });
            dgvMaintenance.Dock = DockStyle.Fill;
            dgvMaintenance.Location = new Point(10, 55);
            dgvMaintenance.Name = "dgvMaintenance";
            dgvMaintenance.RowHeadersWidth = 51;
            dgvMaintenance.Size = new Size(348, 311);
            dgvMaintenance.TabIndex = 12;
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
            // pnlNestedHeaderMaintenanceView
            // 
            pnlNestedHeaderMaintenanceView.BorderStyle = BorderStyle.FixedSingle;
            pnlNestedHeaderMaintenanceView.Controls.Add(btnViewAllMaintenance);
            pnlNestedHeaderMaintenanceView.Controls.Add(lblMaintenanceTitle);
            pnlNestedHeaderMaintenanceView.Dock = DockStyle.Top;
            pnlNestedHeaderMaintenanceView.Location = new Point(10, 10);
            pnlNestedHeaderMaintenanceView.Name = "pnlNestedHeaderMaintenanceView";
            pnlNestedHeaderMaintenanceView.Padding = new Padding(5);
            pnlNestedHeaderMaintenanceView.Size = new Size(348, 45);
            pnlNestedHeaderMaintenanceView.TabIndex = 11;
            // 
            // btnViewAllMaintenance
            // 
            btnViewAllMaintenance.Cursor = Cursors.Hand;
            btnViewAllMaintenance.Dock = DockStyle.Right;
            btnViewAllMaintenance.Location = new Point(236, 5);
            btnViewAllMaintenance.Name = "btnViewAllMaintenance";
            btnViewAllMaintenance.Size = new Size(105, 33);
            btnViewAllMaintenance.TabIndex = 10;
            btnViewAllMaintenance.Text = "View All";
            btnViewAllMaintenance.UseVisualStyleBackColor = true;
            btnViewAllMaintenance.Click += btnViewAllMaintenance_Click;
            // 
            // lblMaintenanceTitle
            // 
            lblMaintenanceTitle.Dock = DockStyle.Left;
            lblMaintenanceTitle.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceTitle.ForeColor = Color.White;
            lblMaintenanceTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMaintenanceTitle.Location = new Point(5, 5);
            lblMaintenanceTitle.Margin = new Padding(0);
            lblMaintenanceTitle.Name = "lblMaintenanceTitle";
            lblMaintenanceTitle.Size = new Size(190, 33);
            lblMaintenanceTitle.TabIndex = 9;
            lblMaintenanceTitle.Text = "Maintenance View";
            lblMaintenanceTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HomeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlHomeContent);
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
            pnlHomeContent.ResumeLayout(false);
            tblDashBoard.ResumeLayout(false);
            pnlRecentActivities.ResumeLayout(false);
            pnlNestedHeaderRecentActivities.ResumeLayout(false);
            pnlNotificationView.ResumeLayout(false);
            pnlNestedHeaderNotification.ResumeLayout(false);
            pnlRoomOverview.ResumeLayout(false);
            pnlNestedHeaderRoom.ResumeLayout(false);
            pnlNestedHeaderRoom.PerformLayout();
            pnlMaintenanceView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).EndInit();
            pnlNestedHeaderMaintenanceView.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpDashBoardCards;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label lblAvailableTitle;
        private Label lblOccupancyTitle;
        private Label lblTotalTitle;
        private Label lblAvailableCount;
        private Label lblOccupancyRate;
        private Label lblTotalCount;
        private Panel pnlHomeContent;
        private TableLayoutPanel tblDashBoard;
        private Panel pnlRecentActivities;
        private Button btnViewAllActivities;
        private Label lblRecentActivitiesTitle;
        private Panel pnlNotificationView;
        private Panel pnlRoomOverview;
        private FlowLayoutPanel flpRoomOverview;
        private Panel pnlNestedHeaderRoom;
        private Label lblMaintenance;
        private Label lblOccupied;
        private Label lblAvailable;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Label lblRoomOverviewTitle;
        private Panel pnlMaintenanceView;
        private Panel pnlNestedHeaderRecentActivities;
        private ListView lvRecentActivities;
        private ColumnHeader Time;
        private ColumnHeader Activity;
        private Panel pnlNestedHeaderNotification;
        private Label lblNotificationTitle;
        private Button btnViewAllNotifications;
        private ListView lvNotification;
        private ColumnHeader Date;
        private ColumnHeader Description;
        private DataGridView dgvMaintenance;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn Issue;
        private DataGridViewTextBoxColumn Status;
        private Panel pnlNestedHeaderMaintenanceView;
        private Button btnViewAllMaintenance;
        private Label lblMaintenanceTitle;
    }
}
