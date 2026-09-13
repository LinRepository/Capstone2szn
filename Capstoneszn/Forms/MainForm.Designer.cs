namespace Capstoneszn
{
    partial class MainForm
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
            pnlSideBar = new Panel();
            flpNavigation = new FlowLayoutPanel();
            btnHome = new Button();
            btnTenants = new Button();
            btnRooms = new Button();
            btnUtilities = new Button();
            btnMaintenance = new Button();
            btnBillingManagement = new Button();
            btnReports = new Button();
            btnPaymentHistory = new Button();
            btnEmployee = new Button();
            btnAuditLogs = new Button();
            btnSettings = new Button();
            pnlSidebarBtn = new Panel();
            btnHamburger = new Button();
            btnLogout = new Button();
            pnlHeader = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlUsers = new Panel();
            lblUserRole = new Label();
            lblCurrentUser = new Label();
            pnlDateTime = new Panel();
            lblDate = new Label();
            lblTime = new Label();
            pnlSystemName = new Panel();
            lblSystemName = new Label();
            pnlLogo = new Panel();
            Logo = new PictureBox();
            panel1 = new Panel();
            btnNotification = new Button();
            pnlContent = new Panel();
            pnlSideBar.SuspendLayout();
            flpNavigation.SuspendLayout();
            pnlSidebarBtn.SuspendLayout();
            pnlHeader.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlUsers.SuspendLayout();
            pnlDateTime.SuspendLayout();
            pnlSystemName.SuspendLayout();
            pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSideBar
            // 
            pnlSideBar.BorderStyle = BorderStyle.FixedSingle;
            pnlSideBar.Controls.Add(flpNavigation);
            pnlSideBar.Controls.Add(pnlSidebarBtn);
            pnlSideBar.Controls.Add(btnLogout);
            pnlSideBar.Dock = DockStyle.Left;
            pnlSideBar.Location = new Point(0, 0);
            pnlSideBar.Name = "pnlSideBar";
            pnlSideBar.Size = new Size(220, 758);
            pnlSideBar.TabIndex = 0;
            // 
            // flpNavigation
            // 
            flpNavigation.AutoScroll = true;
            flpNavigation.Controls.Add(btnHome);
            flpNavigation.Controls.Add(btnTenants);
            flpNavigation.Controls.Add(btnRooms);
            flpNavigation.Controls.Add(btnUtilities);
            flpNavigation.Controls.Add(btnMaintenance);
            flpNavigation.Controls.Add(btnBillingManagement);
            flpNavigation.Controls.Add(btnReports);
            flpNavigation.Controls.Add(btnPaymentHistory);
            flpNavigation.Controls.Add(btnEmployee);
            flpNavigation.Controls.Add(btnAuditLogs);
            flpNavigation.Controls.Add(btnSettings);
            flpNavigation.Dock = DockStyle.Fill;
            flpNavigation.FlowDirection = FlowDirection.TopDown;
            flpNavigation.Location = new Point(0, 80);
            flpNavigation.Name = "flpNavigation";
            flpNavigation.Padding = new Padding(0, 50, 0, 0);
            flpNavigation.Size = new Size(218, 631);
            flpNavigation.TabIndex = 18;
            flpNavigation.WrapContents = false;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 50);
            btnHome.Margin = new Padding(0, 0, 0, 5);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(15, 0, 0, 0);
            btnHome.Size = new Size(213, 45);
            btnHome.TabIndex = 3;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click_1;
            // 
            // btnTenants
            // 
            btnTenants.Cursor = Cursors.Hand;
            btnTenants.FlatAppearance.BorderSize = 0;
            btnTenants.FlatStyle = FlatStyle.Flat;
            btnTenants.ForeColor = Color.White;
            btnTenants.Location = new Point(0, 100);
            btnTenants.Margin = new Padding(0, 0, 0, 5);
            btnTenants.Name = "btnTenants";
            btnTenants.Padding = new Padding(15, 0, 0, 0);
            btnTenants.Size = new Size(213, 45);
            btnTenants.TabIndex = 4;
            btnTenants.Text = "Tenants";
            btnTenants.TextAlign = ContentAlignment.MiddleLeft;
            btnTenants.UseVisualStyleBackColor = true;
            btnTenants.Click += btnTenants_Click_1;
            // 
            // btnRooms
            // 
            btnRooms.Cursor = Cursors.Hand;
            btnRooms.FlatAppearance.BorderSize = 0;
            btnRooms.FlatStyle = FlatStyle.Flat;
            btnRooms.ForeColor = Color.White;
            btnRooms.Location = new Point(0, 150);
            btnRooms.Margin = new Padding(0, 0, 0, 5);
            btnRooms.Name = "btnRooms";
            btnRooms.Padding = new Padding(15, 0, 0, 0);
            btnRooms.Size = new Size(213, 45);
            btnRooms.TabIndex = 5;
            btnRooms.Text = "Rooms";
            btnRooms.TextAlign = ContentAlignment.MiddleLeft;
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click_1;
            // 
            // btnUtilities
            // 
            btnUtilities.Cursor = Cursors.Hand;
            btnUtilities.FlatAppearance.BorderSize = 0;
            btnUtilities.FlatStyle = FlatStyle.Flat;
            btnUtilities.ForeColor = Color.White;
            btnUtilities.Location = new Point(0, 200);
            btnUtilities.Margin = new Padding(0, 0, 0, 5);
            btnUtilities.Name = "btnUtilities";
            btnUtilities.Padding = new Padding(15, 0, 0, 0);
            btnUtilities.Size = new Size(213, 45);
            btnUtilities.TabIndex = 6;
            btnUtilities.Text = "Utilities";
            btnUtilities.TextAlign = ContentAlignment.MiddleLeft;
            btnUtilities.UseVisualStyleBackColor = true;
            btnUtilities.Click += btnUtilities_Click_1;
            // 
            // btnMaintenance
            // 
            btnMaintenance.Cursor = Cursors.Hand;
            btnMaintenance.FlatAppearance.BorderSize = 0;
            btnMaintenance.FlatStyle = FlatStyle.Flat;
            btnMaintenance.ForeColor = Color.White;
            btnMaintenance.Location = new Point(0, 250);
            btnMaintenance.Margin = new Padding(0, 0, 0, 5);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Padding = new Padding(15, 0, 0, 0);
            btnMaintenance.Size = new Size(213, 45);
            btnMaintenance.TabIndex = 7;
            btnMaintenance.Text = "Maintenance";
            btnMaintenance.TextAlign = ContentAlignment.MiddleLeft;
            btnMaintenance.UseVisualStyleBackColor = true;
            btnMaintenance.Click += btnMaintenance_Click_1;
            // 
            // btnBillingManagement
            // 
            btnBillingManagement.Cursor = Cursors.Hand;
            btnBillingManagement.FlatAppearance.BorderSize = 0;
            btnBillingManagement.FlatStyle = FlatStyle.Flat;
            btnBillingManagement.ForeColor = Color.White;
            btnBillingManagement.Location = new Point(0, 300);
            btnBillingManagement.Margin = new Padding(0, 0, 0, 5);
            btnBillingManagement.Name = "btnBillingManagement";
            btnBillingManagement.Padding = new Padding(15, 0, 0, 0);
            btnBillingManagement.Size = new Size(213, 45);
            btnBillingManagement.TabIndex = 8;
            btnBillingManagement.Text = "Bill Management";
            btnBillingManagement.TextAlign = ContentAlignment.MiddleLeft;
            btnBillingManagement.UseVisualStyleBackColor = true;
            btnBillingManagement.Click += btnBillingManagement_Click;
            // 
            // btnReports
            // 
            btnReports.Cursor = Cursors.Hand;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(0, 350);
            btnReports.Margin = new Padding(0, 0, 0, 5);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(15, 0, 0, 0);
            btnReports.Size = new Size(213, 45);
            btnReports.TabIndex = 9;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click_1;
            // 
            // btnPaymentHistory
            // 
            btnPaymentHistory.Cursor = Cursors.Hand;
            btnPaymentHistory.FlatAppearance.BorderSize = 0;
            btnPaymentHistory.FlatStyle = FlatStyle.Flat;
            btnPaymentHistory.ForeColor = Color.White;
            btnPaymentHistory.Location = new Point(0, 400);
            btnPaymentHistory.Margin = new Padding(0, 0, 0, 5);
            btnPaymentHistory.Name = "btnPaymentHistory";
            btnPaymentHistory.Padding = new Padding(15, 0, 0, 0);
            btnPaymentHistory.Size = new Size(213, 45);
            btnPaymentHistory.TabIndex = 10;
            btnPaymentHistory.Text = "Payment History";
            btnPaymentHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnPaymentHistory.UseVisualStyleBackColor = true;
            btnPaymentHistory.Click += btnPaymentHistory_Click_1;
            // 
            // btnEmployee
            // 
            btnEmployee.Cursor = Cursors.Hand;
            btnEmployee.FlatAppearance.BorderSize = 0;
            btnEmployee.FlatStyle = FlatStyle.Flat;
            btnEmployee.ForeColor = Color.White;
            btnEmployee.Location = new Point(0, 450);
            btnEmployee.Margin = new Padding(0, 0, 0, 5);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Padding = new Padding(15, 0, 0, 0);
            btnEmployee.Size = new Size(213, 45);
            btnEmployee.TabIndex = 11;
            btnEmployee.Text = "Employee";
            btnEmployee.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click_1;
            // 
            // btnAuditLogs
            // 
            btnAuditLogs.Cursor = Cursors.Hand;
            btnAuditLogs.FlatAppearance.BorderSize = 0;
            btnAuditLogs.FlatStyle = FlatStyle.Flat;
            btnAuditLogs.ForeColor = Color.White;
            btnAuditLogs.Location = new Point(0, 500);
            btnAuditLogs.Margin = new Padding(0, 0, 0, 5);
            btnAuditLogs.Name = "btnAuditLogs";
            btnAuditLogs.Padding = new Padding(15, 0, 0, 0);
            btnAuditLogs.Size = new Size(213, 45);
            btnAuditLogs.TabIndex = 12;
            btnAuditLogs.Text = "Audit Logs";
            btnAuditLogs.TextAlign = ContentAlignment.MiddleLeft;
            btnAuditLogs.UseVisualStyleBackColor = true;
            btnAuditLogs.Click += btnAuditLogs_Click_1;
            // 
            // btnSettings
            // 
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(0, 550);
            btnSettings.Margin = new Padding(0, 0, 0, 5);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(15, 0, 0, 0);
            btnSettings.Size = new Size(213, 45);
            btnSettings.TabIndex = 13;
            btnSettings.Text = "Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click_1;
            // 
            // pnlSidebarBtn
            // 
            pnlSidebarBtn.Controls.Add(btnHamburger);
            pnlSidebarBtn.Dock = DockStyle.Top;
            pnlSidebarBtn.Location = new Point(0, 0);
            pnlSidebarBtn.Name = "pnlSidebarBtn";
            pnlSidebarBtn.Size = new Size(218, 80);
            pnlSidebarBtn.TabIndex = 17;
            // 
            // btnHamburger
            // 
            btnHamburger.BackColor = Color.Transparent;
            btnHamburger.Cursor = Cursors.Hand;
            btnHamburger.Dock = DockStyle.Left;
            btnHamburger.FlatStyle = FlatStyle.Popup;
            btnHamburger.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHamburger.ForeColor = Color.White;
            btnHamburger.Location = new Point(0, 0);
            btnHamburger.Name = "btnHamburger";
            btnHamburger.Size = new Size(110, 80);
            btnHamburger.TabIndex = 16;
            btnHamburger.Text = "☰";
            btnHamburger.UseVisualStyleBackColor = false;
            btnHamburger.Click += btnHamburger_Click;
            // 
            // btnLogout
            // 
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 711);
            btnLogout.Margin = new Padding(0, 0, 0, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(15, 0, 0, 0);
            btnLogout.Size = new Size(218, 45);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(tableLayoutPanel1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(220, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1167, 124);
            pnlHeader.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.7894735F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.05263F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.5789471F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.05263F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.5263157F));
            tableLayoutPanel1.Controls.Add(pnlUsers, 3, 0);
            tableLayoutPanel1.Controls.Add(pnlDateTime, 2, 0);
            tableLayoutPanel1.Controls.Add(pnlSystemName, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlLogo, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1165, 125);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlUsers
            // 
            pnlUsers.Controls.Add(lblUserRole);
            pnlUsers.Controls.Add(lblCurrentUser);
            pnlUsers.Dock = DockStyle.Fill;
            pnlUsers.Location = new Point(798, 3);
            pnlUsers.Name = "pnlUsers";
            pnlUsers.Padding = new Padding(5);
            pnlUsers.Size = new Size(239, 119);
            pnlUsers.TabIndex = 10;
            // 
            // lblUserRole
            // 
            lblUserRole.BorderStyle = BorderStyle.FixedSingle;
            lblUserRole.Dock = DockStyle.Bottom;
            lblUserRole.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserRole.ForeColor = Color.White;
            lblUserRole.ImageAlign = ContentAlignment.MiddleRight;
            lblUserRole.Location = new Point(5, 54);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(229, 60);
            lblUserRole.TabIndex = 7;
            lblUserRole.Text = "User Role";
            lblUserRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.BorderStyle = BorderStyle.FixedSingle;
            lblCurrentUser.Dock = DockStyle.Top;
            lblCurrentUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentUser.ForeColor = Color.White;
            lblCurrentUser.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentUser.Location = new Point(5, 5);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(229, 60);
            lblCurrentUser.TabIndex = 6;
            lblCurrentUser.Text = "User";
            lblCurrentUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDateTime
            // 
            pnlDateTime.Controls.Add(lblDate);
            pnlDateTime.Controls.Add(lblTime);
            pnlDateTime.Dock = DockStyle.Fill;
            pnlDateTime.Location = new Point(431, 3);
            pnlDateTime.Name = "pnlDateTime";
            pnlDateTime.Padding = new Padding(5);
            pnlDateTime.Size = new Size(361, 119);
            pnlDateTime.TabIndex = 9;
            // 
            // lblDate
            // 
            lblDate.BorderStyle = BorderStyle.FixedSingle;
            lblDate.Dock = DockStyle.Fill;
            lblDate.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.White;
            lblDate.ImageAlign = ContentAlignment.MiddleRight;
            lblDate.Location = new Point(175, 5);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(181, 109);
            lblDate.TabIndex = 3;
            lblDate.Text = "MM:DD:YYYY";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            lblTime.BorderStyle = BorderStyle.FixedSingle;
            lblTime.Dock = DockStyle.Left;
            lblTime.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.White;
            lblTime.ImageAlign = ContentAlignment.MiddleRight;
            lblTime.Location = new Point(5, 5);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(170, 109);
            lblTime.TabIndex = 2;
            lblTime.Text = "00:00";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSystemName
            // 
            pnlSystemName.Controls.Add(lblSystemName);
            pnlSystemName.Dock = DockStyle.Fill;
            pnlSystemName.Location = new Point(186, 3);
            pnlSystemName.Name = "pnlSystemName";
            pnlSystemName.Padding = new Padding(5);
            pnlSystemName.Size = new Size(239, 119);
            pnlSystemName.TabIndex = 8;
            // 
            // lblSystemName
            // 
            lblSystemName.BorderStyle = BorderStyle.FixedSingle;
            lblSystemName.Dock = DockStyle.Fill;
            lblSystemName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSystemName.ForeColor = Color.White;
            lblSystemName.ImageAlign = ContentAlignment.MiddleRight;
            lblSystemName.Location = new Point(5, 5);
            lblSystemName.Name = "lblSystemName";
            lblSystemName.Size = new Size(229, 109);
            lblSystemName.TabIndex = 2;
            lblSystemName.Text = "Building Name";
            lblSystemName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(Logo);
            pnlLogo.Dock = DockStyle.Fill;
            pnlLogo.Location = new Point(3, 3);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Padding = new Padding(5);
            pnlLogo.Size = new Size(177, 119);
            pnlLogo.TabIndex = 1;
            // 
            // Logo
            // 
            Logo.Anchor = AnchorStyles.None;
            Logo.BackColor = Color.White;
            Logo.Location = new Point(39, 8);
            Logo.Name = "Logo";
            Logo.Size = new Size(100, 100);
            Logo.SizeMode = PictureBoxSizeMode.Zoom;
            Logo.TabIndex = 1;
            Logo.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnNotification);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1043, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(119, 119);
            panel1.TabIndex = 11;
            // 
            // btnNotification
            // 
            btnNotification.Cursor = Cursors.Hand;
            btnNotification.Location = new Point(32, 30);
            btnNotification.Name = "btnNotification";
            btnNotification.Size = new Size(60, 60);
            btnNotification.TabIndex = 12;
            btnNotification.Text = "Notification";
            btnNotification.UseVisualStyleBackColor = true;
            btnNotification.Click += btnNotification_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 124);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1167, 634);
            pnlContent.TabIndex = 2;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(1387, 758);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSideBar);
            MinimumSize = new Size(1405, 805);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KSU";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            pnlSideBar.ResumeLayout(false);
            flpNavigation.ResumeLayout(false);
            pnlSidebarBtn.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlUsers.ResumeLayout(false);
            pnlDateTime.ResumeLayout(false);
            pnlSystemName.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSideBar;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Button btnLogout;
        private Button btnHamburger;
        private Panel pnlSidebarBtn;
        private FlowLayoutPanel flpNavigation;
        private Button btnHome;
        private Button btnTenants;
        private Button btnRooms;
        private Button btnUtilities;
        private Button btnMaintenance;
        private Button btnBillingManagement;
        private Button btnReports;
        private Button btnPaymentHistory;
        private Button btnEmployee;
        private Button btnAuditLogs;
        private Button btnSettings;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlUsers;
        private Label lblUserRole;
        private Label lblCurrentUser;
        private Panel pnlDateTime;
        private Label lblDate;
        private Label lblTime;
        private Panel pnlSystemName;
        private Label lblSystemName;
        private Panel pnlLogo;
        private PictureBox Logo;
        private Panel panel1;
        private Button btnNotification;
    }
}