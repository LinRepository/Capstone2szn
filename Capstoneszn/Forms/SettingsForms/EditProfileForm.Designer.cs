namespace Capstoneszn.Forms.SettingsForms
{
    partial class EditProfileForm
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
            pnlEditProfileHeader = new Panel();
            lblEditProfileTitle = new Label();
            pnlEditProfileActions = new Panel();
            btnSaveProfileChanges = new Button();
            btnCancelEditProfile = new Button();
            pnlEditProfileContent = new Panel();
            tblEditProfileInformation = new TableLayoutPanel();
            lblEnterPassword = new Label();
            lblEditProfileUsername = new Label();
            lblEditProfileRoleValue = new Label();
            lblEditProfileRole = new Label();
            lblEditProfileName = new Label();
            txtUsername = new TextBox();
            txtName = new TextBox();
            txtEnterPassword = new TextBox();
            pnlEditProfileHeader.SuspendLayout();
            pnlEditProfileActions.SuspendLayout();
            pnlEditProfileContent.SuspendLayout();
            tblEditProfileInformation.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEditProfileHeader
            // 
            pnlEditProfileHeader.Controls.Add(lblEditProfileTitle);
            pnlEditProfileHeader.Dock = DockStyle.Top;
            pnlEditProfileHeader.Location = new Point(0, 0);
            pnlEditProfileHeader.Name = "pnlEditProfileHeader";
            pnlEditProfileHeader.Size = new Size(482, 60);
            pnlEditProfileHeader.TabIndex = 0;
            // 
            // lblEditProfileTitle
            // 
            lblEditProfileTitle.Dock = DockStyle.Fill;
            lblEditProfileTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditProfileTitle.ForeColor = Color.White;
            lblEditProfileTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblEditProfileTitle.Location = new Point(0, 0);
            lblEditProfileTitle.Name = "lblEditProfileTitle";
            lblEditProfileTitle.Size = new Size(482, 60);
            lblEditProfileTitle.TabIndex = 12;
            lblEditProfileTitle.Text = "Edit Profile";
            lblEditProfileTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlEditProfileActions
            // 
            pnlEditProfileActions.Controls.Add(btnSaveProfileChanges);
            pnlEditProfileActions.Controls.Add(btnCancelEditProfile);
            pnlEditProfileActions.Dock = DockStyle.Bottom;
            pnlEditProfileActions.Location = new Point(0, 343);
            pnlEditProfileActions.Name = "pnlEditProfileActions";
            pnlEditProfileActions.Size = new Size(482, 60);
            pnlEditProfileActions.TabIndex = 1;
            // 
            // btnSaveProfileChanges
            // 
            btnSaveProfileChanges.Cursor = Cursors.Hand;
            btnSaveProfileChanges.Location = new Point(376, 19);
            btnSaveProfileChanges.Name = "btnSaveProfileChanges";
            btnSaveProfileChanges.Size = new Size(94, 29);
            btnSaveProfileChanges.TabIndex = 1;
            btnSaveProfileChanges.Text = "Save";
            btnSaveProfileChanges.UseVisualStyleBackColor = true;
            btnSaveProfileChanges.Click += btnSaveProfileChanges_Click;
            // 
            // btnCancelEditProfile
            // 
            btnCancelEditProfile.Cursor = Cursors.Hand;
            btnCancelEditProfile.Location = new Point(261, 19);
            btnCancelEditProfile.Name = "btnCancelEditProfile";
            btnCancelEditProfile.Size = new Size(94, 29);
            btnCancelEditProfile.TabIndex = 0;
            btnCancelEditProfile.Text = "Cancel";
            btnCancelEditProfile.UseVisualStyleBackColor = true;
            btnCancelEditProfile.Click += btnCancelEditProfile_Click;
            // 
            // pnlEditProfileContent
            // 
            pnlEditProfileContent.Controls.Add(tblEditProfileInformation);
            pnlEditProfileContent.Dock = DockStyle.Fill;
            pnlEditProfileContent.Location = new Point(0, 60);
            pnlEditProfileContent.Name = "pnlEditProfileContent";
            pnlEditProfileContent.Size = new Size(482, 283);
            pnlEditProfileContent.TabIndex = 2;
            // 
            // tblEditProfileInformation
            // 
            tblEditProfileInformation.ColumnCount = 2;
            tblEditProfileInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblEditProfileInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tblEditProfileInformation.Controls.Add(lblEnterPassword, 0, 3);
            tblEditProfileInformation.Controls.Add(lblEditProfileUsername, 0, 2);
            tblEditProfileInformation.Controls.Add(lblEditProfileRoleValue, 1, 1);
            tblEditProfileInformation.Controls.Add(lblEditProfileRole, 0, 1);
            tblEditProfileInformation.Controls.Add(lblEditProfileName, 0, 0);
            tblEditProfileInformation.Controls.Add(txtUsername, 1, 2);
            tblEditProfileInformation.Controls.Add(txtName, 1, 0);
            tblEditProfileInformation.Controls.Add(txtEnterPassword, 1, 3);
            tblEditProfileInformation.Dock = DockStyle.Fill;
            tblEditProfileInformation.Location = new Point(0, 0);
            tblEditProfileInformation.Name = "tblEditProfileInformation";
            tblEditProfileInformation.RowCount = 4;
            tblEditProfileInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblEditProfileInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblEditProfileInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblEditProfileInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tblEditProfileInformation.Size = new Size(482, 283);
            tblEditProfileInformation.TabIndex = 0;
            // 
            // lblEnterPassword
            // 
            lblEnterPassword.Dock = DockStyle.Fill;
            lblEnterPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnterPassword.ForeColor = Color.White;
            lblEnterPassword.ImageAlign = ContentAlignment.MiddleRight;
            lblEnterPassword.Location = new Point(3, 210);
            lblEnterPassword.Name = "lblEnterPassword";
            lblEnterPassword.Size = new Size(162, 73);
            lblEnterPassword.TabIndex = 17;
            lblEnterPassword.Text = "Enter your Password:";
            lblEnterPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEditProfileUsername
            // 
            lblEditProfileUsername.Dock = DockStyle.Fill;
            lblEditProfileUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditProfileUsername.ForeColor = Color.White;
            lblEditProfileUsername.ImageAlign = ContentAlignment.MiddleRight;
            lblEditProfileUsername.Location = new Point(3, 140);
            lblEditProfileUsername.Name = "lblEditProfileUsername";
            lblEditProfileUsername.Size = new Size(162, 70);
            lblEditProfileUsername.TabIndex = 16;
            lblEditProfileUsername.Text = "Username:";
            lblEditProfileUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEditProfileRoleValue
            // 
            lblEditProfileRoleValue.Dock = DockStyle.Fill;
            lblEditProfileRoleValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditProfileRoleValue.ForeColor = Color.White;
            lblEditProfileRoleValue.ImageAlign = ContentAlignment.MiddleRight;
            lblEditProfileRoleValue.Location = new Point(173, 75);
            lblEditProfileRoleValue.Margin = new Padding(5);
            lblEditProfileRoleValue.Name = "lblEditProfileRoleValue";
            lblEditProfileRoleValue.Size = new Size(304, 60);
            lblEditProfileRoleValue.TabIndex = 15;
            lblEditProfileRoleValue.Text = "RollerCoaster";
            lblEditProfileRoleValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEditProfileRole
            // 
            lblEditProfileRole.Dock = DockStyle.Fill;
            lblEditProfileRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditProfileRole.ForeColor = Color.White;
            lblEditProfileRole.ImageAlign = ContentAlignment.MiddleRight;
            lblEditProfileRole.Location = new Point(3, 70);
            lblEditProfileRole.Name = "lblEditProfileRole";
            lblEditProfileRole.Size = new Size(162, 70);
            lblEditProfileRole.TabIndex = 14;
            lblEditProfileRole.Text = "Role:";
            lblEditProfileRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEditProfileName
            // 
            lblEditProfileName.Dock = DockStyle.Fill;
            lblEditProfileName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditProfileName.ForeColor = Color.White;
            lblEditProfileName.ImageAlign = ContentAlignment.MiddleRight;
            lblEditProfileName.Location = new Point(3, 0);
            lblEditProfileName.Name = "lblEditProfileName";
            lblEditProfileName.Size = new Size(162, 70);
            lblEditProfileName.TabIndex = 13;
            lblEditProfileName.Text = "Name:";
            lblEditProfileName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(171, 160);
            txtUsername.Margin = new Padding(3, 20, 3, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(299, 34);
            txtUsername.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(171, 20);
            txtName.Margin = new Padding(3, 20, 3, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(299, 34);
            txtName.TabIndex = 0;
            // 
            // txtEnterPassword
            // 
            txtEnterPassword.Font = new Font("Segoe UI", 12F);
            txtEnterPassword.Location = new Point(171, 230);
            txtEnterPassword.Margin = new Padding(3, 20, 3, 3);
            txtEnterPassword.Name = "txtEnterPassword";
            txtEnterPassword.Size = new Size(299, 34);
            txtEnterPassword.TabIndex = 18;
            // 
            // EditProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(482, 403);
            Controls.Add(pnlEditProfileContent);
            Controls.Add(pnlEditProfileActions);
            Controls.Add(pnlEditProfileHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditProfileForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Profile";
            Load += EditProfileForm_Load;
            pnlEditProfileHeader.ResumeLayout(false);
            pnlEditProfileActions.ResumeLayout(false);
            pnlEditProfileContent.ResumeLayout(false);
            tblEditProfileInformation.ResumeLayout(false);
            tblEditProfileInformation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEditProfileHeader;
        private Panel pnlEditProfileActions;
        private Label lblEditProfileTitle;
        private Button btnSaveProfileChanges;
        private Button btnCancelEditProfile;
        private Panel pnlEditProfileContent;
        private TableLayoutPanel tblEditProfileInformation;
        private TextBox txtName;
        private TextBox txtUsername;
        private Label lblEditProfileUsername;
        private Label lblEditProfileRoleValue;
        private Label lblEditProfileRole;
        private Label lblEditProfileName;
        private Label lblEnterPassword;
        private TextBox txtEnterPassword;
    }
}