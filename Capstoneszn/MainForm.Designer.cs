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
            btnHamburger = new Button();
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
            btnLogout = new Button();
            lblSystemName = new Label();
            pictureBox1 = new PictureBox();
            pnlHeader = new Panel();
            lblUserRole = new Label();
            lblCurrentUser = new Label();
            btnNotification = new Button();
            lblDate = new Label();
            lblTime = new Label();
            pnlContent = new Panel();
            pnlSideBar.SuspendLayout();
            flpNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSideBar
            // 
            pnlSideBar.Controls.Add(btnHamburger);
            pnlSideBar.Controls.Add(flpNavigation);
            pnlSideBar.Controls.Add(btnLogout);
            pnlSideBar.Dock = DockStyle.Left;
            pnlSideBar.Location = new Point(0, 0);
            pnlSideBar.Name = "pnlSideBar";
            pnlSideBar.Size = new Size(220, 721);
            pnlSideBar.TabIndex = 0;
            // 
            // btnHamburger
            // 
            btnHamburger.BackColor = Color.Transparent;
            btnHamburger.FlatStyle = FlatStyle.Popup;
            btnHamburger.ForeColor = Color.White;
            btnHamburger.Location = new Point(0, 0);
            btnHamburger.Name = "btnHamburger";
            btnHamburger.Size = new Size(94, 60);
            btnHamburger.TabIndex = 14;
            btnHamburger.Text = "☰";
            btnHamburger.UseVisualStyleBackColor = false;
            btnHamburger.Click += btnHamburger_Click;
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
            flpNavigation.Dock = DockStyle.Bottom;
            flpNavigation.FlowDirection = FlowDirection.TopDown;
            flpNavigation.Location = new Point(0, 98);
            flpNavigation.Name = "flpNavigation";
            flpNavigation.Size = new Size(220, 578);
            flpNavigation.TabIndex = 0;
            flpNavigation.WrapContents = false;
            // 
            // btnHome
            // 
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(0, 0, 0, 5);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(15, 0, 0, 0);
            btnHome.Size = new Size(213, 45);
            btnHome.TabIndex = 3;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnTenants
            // 
            btnTenants.FlatAppearance.BorderSize = 0;
            btnTenants.FlatStyle = FlatStyle.Flat;
            btnTenants.ForeColor = Color.White;
            btnTenants.Location = new Point(0, 50);
            btnTenants.Margin = new Padding(0, 0, 0, 5);
            btnTenants.Name = "btnTenants";
            btnTenants.Padding = new Padding(15, 0, 0, 0);
            btnTenants.Size = new Size(213, 45);
            btnTenants.TabIndex = 4;
            btnTenants.Text = "Tenants";
            btnTenants.TextAlign = ContentAlignment.MiddleLeft;
            btnTenants.UseVisualStyleBackColor = true;
            btnTenants.Click += btnTenants_Click;
            // 
            // btnRooms
            // 
            btnRooms.FlatAppearance.BorderSize = 0;
            btnRooms.FlatStyle = FlatStyle.Flat;
            btnRooms.ForeColor = Color.White;
            btnRooms.Location = new Point(0, 100);
            btnRooms.Margin = new Padding(0, 0, 0, 5);
            btnRooms.Name = "btnRooms";
            btnRooms.Padding = new Padding(15, 0, 0, 0);
            btnRooms.Size = new Size(213, 45);
            btnRooms.TabIndex = 5;
            btnRooms.Text = "Rooms";
            btnRooms.TextAlign = ContentAlignment.MiddleLeft;
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnUtilities
            // 
            btnUtilities.FlatAppearance.BorderSize = 0;
            btnUtilities.FlatStyle = FlatStyle.Flat;
            btnUtilities.ForeColor = Color.White;
            btnUtilities.Location = new Point(0, 150);
            btnUtilities.Margin = new Padding(0, 0, 0, 5);
            btnUtilities.Name = "btnUtilities";
            btnUtilities.Padding = new Padding(15, 0, 0, 0);
            btnUtilities.Size = new Size(213, 45);
            btnUtilities.TabIndex = 6;
            btnUtilities.Text = "Utilities";
            btnUtilities.TextAlign = ContentAlignment.MiddleLeft;
            btnUtilities.UseVisualStyleBackColor = true;
            btnUtilities.Click += btnUtilities_Click;
            // 
            // btnMaintenance
            // 
            btnMaintenance.FlatAppearance.BorderSize = 0;
            btnMaintenance.FlatStyle = FlatStyle.Flat;
            btnMaintenance.ForeColor = Color.White;
            btnMaintenance.Location = new Point(0, 200);
            btnMaintenance.Margin = new Padding(0, 0, 0, 5);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Padding = new Padding(15, 0, 0, 0);
            btnMaintenance.Size = new Size(213, 45);
            btnMaintenance.TabIndex = 7;
            btnMaintenance.Text = "Maintenance";
            btnMaintenance.TextAlign = ContentAlignment.MiddleLeft;
            btnMaintenance.UseVisualStyleBackColor = true;
            btnMaintenance.Click += btnMaintenance_Click;
            // 
            // btnBillingManagement
            // 
            btnBillingManagement.FlatAppearance.BorderSize = 0;
            btnBillingManagement.FlatStyle = FlatStyle.Flat;
            btnBillingManagement.ForeColor = Color.White;
            btnBillingManagement.Location = new Point(0, 250);
            btnBillingManagement.Margin = new Padding(0, 0, 0, 5);
            btnBillingManagement.Name = "btnBillingManagement";
            btnBillingManagement.Padding = new Padding(15, 0, 0, 0);
            btnBillingManagement.Size = new Size(213, 45);
            btnBillingManagement.TabIndex = 8;
            btnBillingManagement.Text = "Bill Management";
            btnBillingManagement.TextAlign = ContentAlignment.MiddleLeft;
            btnBillingManagement.UseVisualStyleBackColor = true;
            btnBillingManagement.Click += btnBilling_Click;
            // 
            // btnReports
            // 
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(0, 300);
            btnReports.Margin = new Padding(0, 0, 0, 5);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(15, 0, 0, 0);
            btnReports.Size = new Size(213, 45);
            btnReports.TabIndex = 9;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnPaymentHistory
            // 
            btnPaymentHistory.FlatAppearance.BorderSize = 0;
            btnPaymentHistory.FlatStyle = FlatStyle.Flat;
            btnPaymentHistory.ForeColor = Color.White;
            btnPaymentHistory.Location = new Point(0, 350);
            btnPaymentHistory.Margin = new Padding(0, 0, 0, 5);
            btnPaymentHistory.Name = "btnPaymentHistory";
            btnPaymentHistory.Padding = new Padding(15, 0, 0, 0);
            btnPaymentHistory.Size = new Size(213, 45);
            btnPaymentHistory.TabIndex = 10;
            btnPaymentHistory.Text = "Payment History";
            btnPaymentHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnPaymentHistory.UseVisualStyleBackColor = true;
            btnPaymentHistory.Click += btnPaymentHistory_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.FlatAppearance.BorderSize = 0;
            btnEmployee.FlatStyle = FlatStyle.Flat;
            btnEmployee.ForeColor = Color.White;
            btnEmployee.Location = new Point(0, 400);
            btnEmployee.Margin = new Padding(0, 0, 0, 5);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Padding = new Padding(15, 0, 0, 0);
            btnEmployee.Size = new Size(213, 45);
            btnEmployee.TabIndex = 11;
            btnEmployee.Text = "Employee";
            btnEmployee.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnAuditLogs
            // 
            btnAuditLogs.FlatAppearance.BorderSize = 0;
            btnAuditLogs.FlatStyle = FlatStyle.Flat;
            btnAuditLogs.ForeColor = Color.White;
            btnAuditLogs.Location = new Point(0, 450);
            btnAuditLogs.Margin = new Padding(0, 0, 0, 5);
            btnAuditLogs.Name = "btnAuditLogs";
            btnAuditLogs.Padding = new Padding(15, 0, 0, 0);
            btnAuditLogs.Size = new Size(213, 45);
            btnAuditLogs.TabIndex = 12;
            btnAuditLogs.Text = "Audit Logs";
            btnAuditLogs.TextAlign = ContentAlignment.MiddleLeft;
            btnAuditLogs.UseVisualStyleBackColor = true;
            btnAuditLogs.Click += btnAuditLogs_Click;
            // 
            // btnSettings
            // 
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(0, 500);
            btnSettings.Margin = new Padding(0, 0, 0, 5);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(15, 0, 0, 0);
            btnSettings.Size = new Size(213, 45);
            btnSettings.TabIndex = 13;
            btnSettings.Text = "Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 676);
            btnLogout.Margin = new Padding(0, 0, 0, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(15, 0, 0, 0);
            btnLogout.Size = new Size(220, 45);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // lblSystemName
            // 
            lblSystemName.AutoSize = true;
            lblSystemName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSystemName.ForeColor = Color.White;
            lblSystemName.ImageAlign = ContentAlignment.MiddleRight;
            lblSystemName.Location = new Point(149, 61);
            lblSystemName.Name = "lblSystemName";
            lblSystemName.Size = new Size(128, 25);
            lblSystemName.TabIndex = 1;
            lblSystemName.Text = "Building Name";
            lblSystemName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(23, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblUserRole);
            pnlHeader.Controls.Add(lblCurrentUser);
            pnlHeader.Controls.Add(btnNotification);
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(lblTime);
            pnlHeader.Controls.Add(pictureBox1);
            pnlHeader.Controls.Add(lblSystemName);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(220, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1130, 150);
            pnlHeader.TabIndex = 1;
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserRole.ForeColor = Color.White;
            lblUserRole.ImageAlign = ContentAlignment.MiddleRight;
            lblUserRole.Location = new Point(931, 84);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(86, 25);
            lblUserRole.TabIndex = 6;
            lblUserRole.Text = "User Role";
            lblUserRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentUser.ForeColor = Color.White;
            lblCurrentUser.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentUser.Location = new Point(949, 50);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(47, 25);
            lblCurrentUser.TabIndex = 5;
            lblCurrentUser.Text = "User";
            lblCurrentUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNotification
            // 
            btnNotification.Location = new Point(1044, 50);
            btnNotification.Name = "btnNotification";
            btnNotification.Size = new Size(50, 50);
            btnNotification.TabIndex = 4;
            btnNotification.Text = "Notification";
            btnNotification.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.White;
            lblDate.ImageAlign = ContentAlignment.MiddleRight;
            lblDate.Location = new Point(562, 61);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(118, 25);
            lblDate.TabIndex = 3;
            lblDate.Text = "MM:DD:YYYY";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.White;
            lblTime.ImageAlign = ContentAlignment.MiddleRight;
            lblTime.Location = new Point(470, 61);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(56, 25);
            lblTime.TabIndex = 2;
            lblTime.Text = "00:00";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 150);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1130, 571);
            pnlContent.TabIndex = 2;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(1350, 721);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSideBar);
            MinimumSize = new Size(1366, 768);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KSU";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            pnlSideBar.ResumeLayout(false);
            flpNavigation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSideBar;
        private Panel pnlHeader;
        private Panel pnlContent;
        private PictureBox pictureBox1;
        private Label lblSystemName;
        private Button btnSettings;
        private Button btnAuditLogs;
        private Button btnEmployee;
        private Button btnPaymentHistory;
        private Button btnReports;
        private Button btnBillingManagement;
        private Button btnMaintenance;
        private Button btnUtilities;
        private Button btnRooms;
        private Button btnTenants;
        private Button btnHome;
        private Button btnLogout;
        private Label lblDate;
        private Label lblTime;
        private Button btnNotification;
        private FlowLayoutPanel flpNavigation;
        private Button btnHamburger;
        private Label lblUserRole;
        private Label lblCurrentUser;
    }
}