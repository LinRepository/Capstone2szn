namespace Capstoneszn
{
    partial class PasswordResetForm
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
            label2 = new Label();
            InputResetPassword = new TextBox();
            InputConfirmResetPassword = new TextBox();
            btnSetPassword = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(157, 103);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 0;
            label1.Text = "Enter Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(157, 185);
            label2.Name = "label2";
            label2.Size = new Size(161, 20);
            label2.TabIndex = 1;
            label2.Text = "Confirm New Password";
            // 
            // InputResetPassword
            // 
            InputResetPassword.Location = new Point(157, 126);
            InputResetPassword.Multiline = true;
            InputResetPassword.Name = "InputResetPassword";
            InputResetPassword.Size = new Size(179, 34);
            InputResetPassword.TabIndex = 2;
            // 
            // InputConfirmResetPassword
            // 
            InputConfirmResetPassword.Location = new Point(157, 208);
            InputConfirmResetPassword.Multiline = true;
            InputConfirmResetPassword.Name = "InputConfirmResetPassword";
            InputConfirmResetPassword.Size = new Size(179, 34);
            InputConfirmResetPassword.TabIndex = 3;
            // 
            // btnSetPassword
            // 
            btnSetPassword.Location = new Point(175, 278);
            btnSetPassword.Name = "btnSetPassword";
            btnSetPassword.Size = new Size(126, 29);
            btnSetPassword.TabIndex = 4;
            btnSetPassword.Text = "Set Password";
            btnSetPassword.UseVisualStyleBackColor = true;
            // 
            // PasswordResetForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(800, 450);
            Controls.Add(btnSetPassword);
            Controls.Add(InputConfirmResetPassword);
            Controls.Add(InputResetPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PasswordResetForm";
            Text = "PasswordResetForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox InputResetPassword;
        private TextBox InputConfirmResetPassword;
        private Button btnSetPassword;
    }
}