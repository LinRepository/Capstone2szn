namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class ProfileManagementControl
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
            pnlProfileManagementHeader = new Panel();
            lblProfileManagementTitle = new Label();
            btnBackProfileManagement = new Button();
            pnlProfileManagementContent = new Panel();
            pnlProfileCenter = new Panel();
            pnlProfileActions = new Panel();
            tblProfileInformation = new TableLayoutPanel();
            btnEditProfile = new Button();
            btnChangePassword = new Button();
            btnManageSecurityQuestions = new Button();
            lbProfileNameTitle = new Label();
            lblProfileNameValue = new Label();
            lblProfileRoleTitle = new Label();
            lblProfileRoleValue = new Label();
            lblProfileUsernameTitle = new Label();
            lblProfileUsernameValue = new Label();
            pnlProfileManagementHeader.SuspendLayout();
            pnlProfileManagementContent.SuspendLayout();
            pnlProfileCenter.SuspendLayout();
            pnlProfileActions.SuspendLayout();
            tblProfileInformation.SuspendLayout();
            SuspendLayout();
            // 
            // pnlProfileManagementHeader
            // 
            pnlProfileManagementHeader.Controls.Add(lblProfileManagementTitle);
            pnlProfileManagementHeader.Controls.Add(btnBackProfileManagement);
            pnlProfileManagementHeader.Dock = DockStyle.Top;
            pnlProfileManagementHeader.Location = new Point(0, 0);
            pnlProfileManagementHeader.Name = "pnlProfileManagementHeader";
            pnlProfileManagementHeader.Size = new Size(1300, 100);
            pnlProfileManagementHeader.TabIndex = 0;
            // 
            // lblProfileManagementTitle
            // 
            lblProfileManagementTitle.Dock = DockStyle.Fill;
            lblProfileManagementTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileManagementTitle.ForeColor = Color.White;
            lblProfileManagementTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblProfileManagementTitle.Location = new Point(140, 0);
            lblProfileManagementTitle.Name = "lblProfileManagementTitle";
            lblProfileManagementTitle.Size = new Size(1160, 100);
            lblProfileManagementTitle.TabIndex = 12;
            lblProfileManagementTitle.Text = "Profile Management";
            lblProfileManagementTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackProfileManagement
            // 
            btnBackProfileManagement.Cursor = Cursors.Hand;
            btnBackProfileManagement.Dock = DockStyle.Left;
            btnBackProfileManagement.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackProfileManagement.Location = new Point(0, 0);
            btnBackProfileManagement.Margin = new Padding(0);
            btnBackProfileManagement.Name = "btnBackProfileManagement";
            btnBackProfileManagement.Size = new Size(140, 100);
            btnBackProfileManagement.TabIndex = 11;
            btnBackProfileManagement.Text = "←";
            btnBackProfileManagement.TextAlign = ContentAlignment.TopCenter;
            btnBackProfileManagement.UseVisualStyleBackColor = true;
            // 
            // pnlProfileManagementContent
            // 
            pnlProfileManagementContent.Controls.Add(pnlProfileCenter);
            pnlProfileManagementContent.Dock = DockStyle.Fill;
            pnlProfileManagementContent.Location = new Point(0, 100);
            pnlProfileManagementContent.Name = "pnlProfileManagementContent";
            pnlProfileManagementContent.Size = new Size(1300, 650);
            pnlProfileManagementContent.TabIndex = 1;
            // 
            // pnlProfileCenter
            // 
            pnlProfileCenter.Anchor = AnchorStyles.None;
            pnlProfileCenter.BorderStyle = BorderStyle.FixedSingle;
            pnlProfileCenter.Controls.Add(tblProfileInformation);
            pnlProfileCenter.Controls.Add(pnlProfileActions);
            pnlProfileCenter.Location = new Point(239, 82);
            pnlProfileCenter.Name = "pnlProfileCenter";
            pnlProfileCenter.Padding = new Padding(10);
            pnlProfileCenter.Size = new Size(800, 450);
            pnlProfileCenter.TabIndex = 0;
            // 
            // pnlProfileActions
            // 
            pnlProfileActions.Controls.Add(btnManageSecurityQuestions);
            pnlProfileActions.Controls.Add(btnChangePassword);
            pnlProfileActions.Controls.Add(btnEditProfile);
            pnlProfileActions.Dock = DockStyle.Bottom;
            pnlProfileActions.Location = new Point(10, 348);
            pnlProfileActions.Name = "pnlProfileActions";
            pnlProfileActions.Size = new Size(778, 90);
            pnlProfileActions.TabIndex = 1;
            // 
            // tblProfileInformation
            // 
            tblProfileInformation.ColumnCount = 2;
            tblProfileInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblProfileInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tblProfileInformation.Controls.Add(lblProfileUsernameValue, 1, 2);
            tblProfileInformation.Controls.Add(lblProfileUsernameTitle, 0, 2);
            tblProfileInformation.Controls.Add(lblProfileRoleValue, 1, 1);
            tblProfileInformation.Controls.Add(lblProfileRoleTitle, 0, 1);
            tblProfileInformation.Controls.Add(lblProfileNameValue, 1, 0);
            tblProfileInformation.Controls.Add(lbProfileNameTitle, 0, 0);
            tblProfileInformation.Dock = DockStyle.Fill;
            tblProfileInformation.Location = new Point(10, 10);
            tblProfileInformation.Name = "tblProfileInformation";
            tblProfileInformation.RowCount = 3;
            tblProfileInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblProfileInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblProfileInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblProfileInformation.Size = new Size(778, 338);
            tblProfileInformation.TabIndex = 2;
            // 
            // btnEditProfile
            // 
            btnEditProfile.Anchor = AnchorStyles.None;
            btnEditProfile.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditProfile.Location = new Point(14, 21);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(170, 50);
            btnEditProfile.TabIndex = 0;
            btnEditProfile.Text = "Edit Profile";
            btnEditProfile.UseVisualStyleBackColor = true;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.None;
            btnChangePassword.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangePassword.Location = new Point(196, 21);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(230, 50);
            btnChangePassword.TabIndex = 1;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // btnManageSecurityQuestions
            // 
            btnManageSecurityQuestions.Anchor = AnchorStyles.None;
            btnManageSecurityQuestions.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageSecurityQuestions.Location = new Point(438, 21);
            btnManageSecurityQuestions.Name = "btnManageSecurityQuestions";
            btnManageSecurityQuestions.Size = new Size(330, 50);
            btnManageSecurityQuestions.TabIndex = 2;
            btnManageSecurityQuestions.Text = "Manage Security Questions";
            btnManageSecurityQuestions.UseVisualStyleBackColor = true;
            // 
            // lbProfileNameTitle
            // 
            lbProfileNameTitle.Dock = DockStyle.Fill;
            lbProfileNameTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbProfileNameTitle.ForeColor = Color.White;
            lbProfileNameTitle.ImageAlign = ContentAlignment.MiddleRight;
            lbProfileNameTitle.Location = new Point(3, 0);
            lbProfileNameTitle.Name = "lbProfileNameTitle";
            lbProfileNameTitle.Size = new Size(227, 112);
            lbProfileNameTitle.TabIndex = 12;
            lbProfileNameTitle.Text = "Name:";
            lbProfileNameTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProfileNameValue
            // 
            lblProfileNameValue.Dock = DockStyle.Fill;
            lblProfileNameValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileNameValue.ForeColor = Color.White;
            lblProfileNameValue.ImageAlign = ContentAlignment.MiddleRight;
            lblProfileNameValue.Location = new Point(236, 0);
            lblProfileNameValue.Name = "lblProfileNameValue";
            lblProfileNameValue.Size = new Size(539, 112);
            lblProfileNameValue.TabIndex = 13;
            lblProfileNameValue.Text = "Admin User";
            lblProfileNameValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProfileRoleTitle
            // 
            lblProfileRoleTitle.Dock = DockStyle.Fill;
            lblProfileRoleTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileRoleTitle.ForeColor = Color.White;
            lblProfileRoleTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblProfileRoleTitle.Location = new Point(3, 112);
            lblProfileRoleTitle.Name = "lblProfileRoleTitle";
            lblProfileRoleTitle.Size = new Size(227, 112);
            lblProfileRoleTitle.TabIndex = 14;
            lblProfileRoleTitle.Text = "Role:";
            lblProfileRoleTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProfileRoleValue
            // 
            lblProfileRoleValue.Dock = DockStyle.Fill;
            lblProfileRoleValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileRoleValue.ForeColor = Color.White;
            lblProfileRoleValue.ImageAlign = ContentAlignment.MiddleRight;
            lblProfileRoleValue.Location = new Point(236, 112);
            lblProfileRoleValue.Name = "lblProfileRoleValue";
            lblProfileRoleValue.Size = new Size(539, 112);
            lblProfileRoleValue.TabIndex = 15;
            lblProfileRoleValue.Text = "Administrator";
            lblProfileRoleValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProfileUsernameTitle
            // 
            lblProfileUsernameTitle.Dock = DockStyle.Fill;
            lblProfileUsernameTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileUsernameTitle.ForeColor = Color.White;
            lblProfileUsernameTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblProfileUsernameTitle.Location = new Point(3, 224);
            lblProfileUsernameTitle.Name = "lblProfileUsernameTitle";
            lblProfileUsernameTitle.Size = new Size(227, 114);
            lblProfileUsernameTitle.TabIndex = 16;
            lblProfileUsernameTitle.Text = "Username:";
            lblProfileUsernameTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProfileUsernameValue
            // 
            lblProfileUsernameValue.Dock = DockStyle.Fill;
            lblProfileUsernameValue.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfileUsernameValue.ForeColor = Color.White;
            lblProfileUsernameValue.ImageAlign = ContentAlignment.MiddleRight;
            lblProfileUsernameValue.Location = new Point(236, 224);
            lblProfileUsernameValue.Name = "lblProfileUsernameValue";
            lblProfileUsernameValue.Size = new Size(539, 114);
            lblProfileUsernameValue.TabIndex = 17;
            lblProfileUsernameValue.Text = "admin123";
            lblProfileUsernameValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ProfileManagementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlProfileManagementContent);
            Controls.Add(pnlProfileManagementHeader);
            Name = "ProfileManagementControl";
            Size = new Size(1300, 750);
            pnlProfileManagementHeader.ResumeLayout(false);
            pnlProfileManagementContent.ResumeLayout(false);
            pnlProfileCenter.ResumeLayout(false);
            pnlProfileActions.ResumeLayout(false);
            tblProfileInformation.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlProfileManagementHeader;
        private Panel pnlProfileManagementContent;
        private Label lblProfileManagementTitle;
        private Button btnBackProfileManagement;
        private Panel pnlProfileCenter;
        private TableLayoutPanel tblProfileInformation;
        private Panel pnlProfileActions;
        private Button btnManageSecurityQuestions;
        private Button btnChangePassword;
        private Button btnEditProfile;
        private Label lblProfileUsernameValue;
        private Label lblProfileUsernameTitle;
        private Label lblProfileRoleValue;
        private Label lblProfileRoleTitle;
        private Label lblProfileNameValue;
        private Label lbProfileNameTitle;
    }
}
