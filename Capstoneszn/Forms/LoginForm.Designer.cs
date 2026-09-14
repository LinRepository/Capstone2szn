namespace Capstoneszn
{
    partial class LoginForm
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
            pnlLoginHeader = new Panel();
            lblTitle = new Label();
            pnlLoginBuildingName = new Panel();
            pictureBox1 = new PictureBox();
            pnlLoginContent = new Panel();
            txtLoginPassword = new TextBox();
            txtLoginUsername = new TextBox();
            btnLogin = new Button();
            lnkForgotPassword = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            chkShowPassword = new CheckBox();
            pnlLoginHeader.SuspendLayout();
            pnlLoginBuildingName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlLoginContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLoginHeader
            // 
            pnlLoginHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlLoginHeader.Controls.Add(lblTitle);
            pnlLoginHeader.Dock = DockStyle.Top;
            pnlLoginHeader.Location = new Point(0, 0);
            pnlLoginHeader.Name = "pnlLoginHeader";
            pnlLoginHeader.Size = new Size(682, 60);
            pnlLoginHeader.TabIndex = 9;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(680, 58);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "LOGIN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLoginBuildingName
            // 
            pnlLoginBuildingName.BorderStyle = BorderStyle.FixedSingle;
            pnlLoginBuildingName.Controls.Add(pictureBox1);
            pnlLoginBuildingName.Dock = DockStyle.Top;
            pnlLoginBuildingName.Location = new Point(0, 60);
            pnlLoginBuildingName.Name = "pnlLoginBuildingName";
            pnlLoginBuildingName.Size = new Size(682, 185);
            pnlLoginBuildingName.TabIndex = 10;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Location = new Point(256, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(170, 150);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlLoginContent
            // 
            pnlLoginContent.BorderStyle = BorderStyle.FixedSingle;
            pnlLoginContent.Controls.Add(txtLoginPassword);
            pnlLoginContent.Controls.Add(txtLoginUsername);
            pnlLoginContent.Controls.Add(btnLogin);
            pnlLoginContent.Controls.Add(lnkForgotPassword);
            pnlLoginContent.Controls.Add(lblPassword);
            pnlLoginContent.Controls.Add(lblUsername);
            pnlLoginContent.Controls.Add(chkShowPassword);
            pnlLoginContent.Dock = DockStyle.Fill;
            pnlLoginContent.Location = new Point(0, 245);
            pnlLoginContent.Name = "pnlLoginContent";
            pnlLoginContent.Size = new Size(682, 358);
            pnlLoginContent.TabIndex = 11;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.Cursor = Cursors.IBeam;
            txtLoginPassword.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLoginPassword.Location = new Point(194, 141);
            txtLoginPassword.Multiline = true;
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.Size = new Size(305, 40);
            txtLoginPassword.TabIndex = 16;
            txtLoginPassword.Text = "Password";
            txtLoginPassword.UseSystemPasswordChar = true;
            // 
            // txtLoginUsername
            // 
            txtLoginUsername.Cursor = Cursors.IBeam;
            txtLoginUsername.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLoginUsername.Location = new Point(194, 52);
            txtLoginUsername.Multiline = true;
            txtLoginUsername.Name = "txtLoginUsername";
            txtLoginUsername.Size = new Size(305, 40);
            txtLoginUsername.TabIndex = 15;
            txtLoginUsername.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(222, 236);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 60);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lnkForgotPassword.ForeColor = Color.White;
            lnkForgotPassword.Location = new Point(273, 299);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(143, 23);
            lnkForgotPassword.TabIndex = 13;
            lnkForgotPassword.Text = "Forgot Password?";
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(194, 103);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(120, 35);
            lblPassword.TabIndex = 12;
            lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(194, 14);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(127, 35);
            lblUsername.TabIndex = 11;
            lblUsername.Text = "Username";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowPassword.ForeColor = Color.White;
            chkShowPassword.Location = new Point(197, 187);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(153, 29);
            chkShowPassword.TabIndex = 10;
            chkShowPassword.Text = "ShowPassword";
            chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(682, 603);
            Controls.Add(pnlLoginContent);
            Controls.Add(pnlLoginBuildingName);
            Controls.Add(pnlLoginHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            pnlLoginHeader.ResumeLayout(false);
            pnlLoginBuildingName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlLoginContent.ResumeLayout(false);
            pnlLoginContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlLoginHeader;
        private Label lblTitle;
        private Panel pnlLoginBuildingName;
        private PictureBox pictureBox1;
        private Panel pnlLoginContent;
        private Button btnLogin;
        private Label lnkForgotPassword;
        private Label lblPassword;
        private Label lblUsername;
        private CheckBox chkShowPassword;
        private TextBox txtLoginPassword;
        private TextBox txtLoginUsername;
    }
}