namespace Capstoneszn
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLoginHeader = new Panel();
            lblLoginFormTitle = new Label();
            pnlLoginContent = new Panel();
            txtLoginPassword = new TextBox();
            txtLoginUsername = new TextBox();
            btnLogin = new Button();
            lnkForgotPassword = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            chkShowPassword = new CheckBox();
            pictureBox1 = new PictureBox();
            pnlLoginHeader.SuspendLayout();
            pnlLoginContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlLoginHeader
            // 
            pnlLoginHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlLoginHeader.Controls.Add(lblLoginFormTitle);
            pnlLoginHeader.Dock = DockStyle.Top;
            pnlLoginHeader.Location = new Point(0, 0);
            pnlLoginHeader.Name = "pnlLoginHeader";
            pnlLoginHeader.Size = new Size(682, 60);
            pnlLoginHeader.TabIndex = 0;
            // 
            // lblLoginFormTitle
            // 
            lblLoginFormTitle.Dock = DockStyle.Fill;
            lblLoginFormTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoginFormTitle.ForeColor = Color.White;
            lblLoginFormTitle.Location = new Point(0, 0);
            lblLoginFormTitle.Name = "lblLoginFormTitle";
            lblLoginFormTitle.Size = new Size(680, 58);
            lblLoginFormTitle.TabIndex = 7;
            lblLoginFormTitle.Text = "LOGIN";
            lblLoginFormTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            pnlLoginContent.Controls.Add(pictureBox1);
            pnlLoginContent.Dock = DockStyle.Fill;
            pnlLoginContent.Location = new Point(0, 60);
            pnlLoginContent.Name = "pnlLoginContent";
            pnlLoginContent.Size = new Size(682, 593);
            pnlLoginContent.TabIndex = 1;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.Cursor = Cursors.IBeam;
            txtLoginPassword.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLoginPassword.Location = new Point(161, 328);
            txtLoginPassword.Multiline = true;
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.Size = new Size(350, 40);
            txtLoginPassword.TabIndex = 23;
            txtLoginPassword.Text = "Password";
            txtLoginPassword.UseSystemPasswordChar = true;
            txtLoginPassword.TextChanged += txtLoginPassword_TextChanged;
            // 
            // txtLoginUsername
            // 
            txtLoginUsername.Cursor = Cursors.IBeam;
            txtLoginUsername.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLoginUsername.Location = new Point(161, 239);
            txtLoginUsername.Multiline = true;
            txtLoginUsername.Name = "txtLoginUsername";
            txtLoginUsername.Size = new Size(350, 40);
            txtLoginUsername.TabIndex = 22;
            txtLoginUsername.Text = "Username";
            txtLoginUsername.TextChanged += txtLoginUsername_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(164, 435);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(347, 60);
            btnLogin.TabIndex = 21;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Cursor = Cursors.Hand;
            lnkForgotPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lnkForgotPassword.ForeColor = Color.White;
            lnkForgotPassword.Location = new Point(260, 507);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(154, 25);
            lnkForgotPassword.TabIndex = 20;
            lnkForgotPassword.Text = "Forgot Password?";
            lnkForgotPassword.Click += lnkForgotPassword_Click;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(161, 290);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(120, 35);
            lblPassword.TabIndex = 19;
            lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(161, 201);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(127, 35);
            lblUsername.TabIndex = 18;
            lblUsername.Text = "Username";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowPassword.ForeColor = Color.White;
            chkShowPassword.Location = new Point(164, 374);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(153, 29);
            chkShowPassword.TabIndex = 17;
            chkShowPassword.Text = "ShowPassword";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.catlogin;
            pictureBox1.Location = new Point(254, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(170, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(682, 653);
            Controls.Add(pnlLoginContent);
            Controls.Add(pnlLoginHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += SelectBuildingForm_Load;
            pnlLoginHeader.ResumeLayout(false);
            pnlLoginContent.ResumeLayout(false);
            pnlLoginContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLoginHeader;
        private Label lblLoginFormTitle;
        private Panel pnlLoginContent;
        private PictureBox pictureBox1;
        private TextBox txtLoginPassword;
        private TextBox txtLoginUsername;
        private Button btnLogin;
        private Label lnkForgotPassword;
        private Label lblPassword;
        private Label lblUsername;
        private CheckBox chkShowPassword;
    }
}
