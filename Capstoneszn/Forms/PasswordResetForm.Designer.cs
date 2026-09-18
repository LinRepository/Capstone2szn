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
            lblEnterPassword = new Label();
            lblConfirmPassword = new Label();
            txtResetPassword = new TextBox();
            txtConfirmResetPassword = new TextBox();
            btnSetPassword = new Button();
            pnlPasswordResetHeader = new Panel();
            lblPasswordResetTitle = new Label();
            pnlPasswordResetActionButtons = new Panel();
            btnCancel = new Button();
            pnlPasswordResetContent = new Panel();
            pnlPasswordResetDescription = new Label();
            pnlPasswordResetHeader.SuspendLayout();
            pnlPasswordResetActionButtons.SuspendLayout();
            pnlPasswordResetContent.SuspendLayout();
            SuspendLayout();
            // 
            // lblEnterPassword
            // 
            lblEnterPassword.AutoSize = true;
            lblEnterPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnterPassword.ForeColor = Color.White;
            lblEnterPassword.Location = new Point(76, 98);
            lblEnterPassword.Name = "lblEnterPassword";
            lblEnterPassword.Size = new Size(184, 35);
            lblEnterPassword.TabIndex = 0;
            lblEnterPassword.Text = "Enter Password";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmPassword.ForeColor = Color.White;
            lblConfirmPassword.Location = new Point(76, 200);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(273, 35);
            lblConfirmPassword.TabIndex = 1;
            lblConfirmPassword.Text = "Confirm New Password";
            // 
            // txtResetPassword
            // 
            txtResetPassword.Location = new Point(76, 136);
            txtResetPassword.Multiline = true;
            txtResetPassword.Name = "txtResetPassword";
            txtResetPassword.Size = new Size(330, 40);
            txtResetPassword.TabIndex = 2;
            txtResetPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmResetPassword
            // 
            txtConfirmResetPassword.Location = new Point(76, 238);
            txtConfirmResetPassword.Multiline = true;
            txtConfirmResetPassword.Name = "txtConfirmResetPassword";
            txtConfirmResetPassword.Size = new Size(330, 40);
            txtConfirmResetPassword.TabIndex = 3;
            txtConfirmResetPassword.UseSystemPasswordChar = true;
            // 
            // btnSetPassword
            // 
            btnSetPassword.Cursor = Cursors.Hand;
            btnSetPassword.Location = new Point(339, 9);
            btnSetPassword.Name = "btnSetPassword";
            btnSetPassword.Size = new Size(130, 29);
            btnSetPassword.TabIndex = 4;
            btnSetPassword.Text = "Set Password";
            btnSetPassword.UseVisualStyleBackColor = true;
            btnSetPassword.Click += btnSetPassword_Click;
            // 
            // pnlPasswordResetHeader
            // 
            pnlPasswordResetHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlPasswordResetHeader.Controls.Add(lblPasswordResetTitle);
            pnlPasswordResetHeader.Dock = DockStyle.Top;
            pnlPasswordResetHeader.Location = new Point(0, 0);
            pnlPasswordResetHeader.Name = "pnlPasswordResetHeader";
            pnlPasswordResetHeader.Size = new Size(482, 50);
            pnlPasswordResetHeader.TabIndex = 6;
            // 
            // lblPasswordResetTitle
            // 
            lblPasswordResetTitle.Dock = DockStyle.Fill;
            lblPasswordResetTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPasswordResetTitle.ForeColor = Color.White;
            lblPasswordResetTitle.Location = new Point(0, 0);
            lblPasswordResetTitle.Name = "lblPasswordResetTitle";
            lblPasswordResetTitle.Size = new Size(480, 48);
            lblPasswordResetTitle.TabIndex = 6;
            lblPasswordResetTitle.Text = "Password Reset";
            lblPasswordResetTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPasswordResetActionButtons
            // 
            pnlPasswordResetActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlPasswordResetActionButtons.Controls.Add(btnCancel);
            pnlPasswordResetActionButtons.Controls.Add(btnSetPassword);
            pnlPasswordResetActionButtons.Dock = DockStyle.Bottom;
            pnlPasswordResetActionButtons.Location = new Point(0, 403);
            pnlPasswordResetActionButtons.Name = "pnlPasswordResetActionButtons";
            pnlPasswordResetActionButtons.Size = new Size(482, 50);
            pnlPasswordResetActionButtons.TabIndex = 7;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(191, 9);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(124, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnReturnLogin_Click;
            // 
            // pnlPasswordResetContent
            // 
            pnlPasswordResetContent.BorderStyle = BorderStyle.FixedSingle;
            pnlPasswordResetContent.Controls.Add(pnlPasswordResetDescription);
            pnlPasswordResetContent.Controls.Add(txtResetPassword);
            pnlPasswordResetContent.Controls.Add(txtConfirmResetPassword);
            pnlPasswordResetContent.Controls.Add(lblConfirmPassword);
            pnlPasswordResetContent.Controls.Add(lblEnterPassword);
            pnlPasswordResetContent.Dock = DockStyle.Fill;
            pnlPasswordResetContent.Location = new Point(0, 50);
            pnlPasswordResetContent.Name = "pnlPasswordResetContent";
            pnlPasswordResetContent.Size = new Size(482, 353);
            pnlPasswordResetContent.TabIndex = 8;
            // 
            // pnlPasswordResetDescription
            // 
            pnlPasswordResetDescription.Dock = DockStyle.Top;
            pnlPasswordResetDescription.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlPasswordResetDescription.ForeColor = Color.White;
            pnlPasswordResetDescription.Location = new Point(0, 0);
            pnlPasswordResetDescription.Name = "pnlPasswordResetDescription";
            pnlPasswordResetDescription.Size = new Size(480, 48);
            pnlPasswordResetDescription.TabIndex = 7;
            pnlPasswordResetDescription.Text = "Please set a new password";
            pnlPasswordResetDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PasswordResetForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 453);
            Controls.Add(pnlPasswordResetContent);
            Controls.Add(pnlPasswordResetActionButtons);
            Controls.Add(pnlPasswordResetHeader);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PasswordResetForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PasswordResetForm";
            Load += PasswordResetForm_Load;
            pnlPasswordResetHeader.ResumeLayout(false);
            pnlPasswordResetActionButtons.ResumeLayout(false);
            pnlPasswordResetContent.ResumeLayout(false);
            pnlPasswordResetContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblEnterPassword;
        private Label lblConfirmPassword;
        private TextBox txtResetPassword;
        private TextBox txtConfirmResetPassword;
        private Button btnSetPassword;
        private Panel pnlPasswordResetHeader;
        private Label lblPasswordResetTitle;
        private Panel pnlPasswordResetActionButtons;
        private Panel pnlPasswordResetContent;
        private Button btnReturnLogin;
        private Label pnlPasswordResetDescription;
        private Button btnCancel;
    }
}