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
            label1 = new Label();
            InputUsername = new TextBox();
            InputPassword = new TextBox();
            btnLogin = new Button();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(417, 51);
            label1.Name = "label1";
            label1.Size = new Size(129, 50);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            // 
            // InputUsername
            // 
            InputUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InputUsername.Location = new Point(380, 182);
            InputUsername.Multiline = true;
            InputUsername.Name = "InputUsername";
            InputUsername.Size = new Size(200, 50);
            InputUsername.TabIndex = 1;
            InputUsername.Text = "Username";
            InputUsername.TextAlign = HorizontalAlignment.Center;
            // 
            // InputPassword
            // 
            InputPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InputPassword.Location = new Point(380, 268);
            InputPassword.Multiline = true;
            InputPassword.Name = "InputPassword";
            InputPassword.Size = new Size(200, 50);
            InputPassword.TabIndex = 2;
            InputPassword.Text = "Password";
            InputPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(426, 387);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(380, 334);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(128, 24);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "ShowPassword";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(982, 653);
            Controls.Add(checkBox1);
            Controls.Add(btnLogin);
            Controls.Add(InputPassword);
            Controls.Add(InputUsername);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox InputUsername;
        private TextBox InputPassword;
        private Button btnLogin;
        private CheckBox checkBox1;
    }
}