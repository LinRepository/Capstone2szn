namespace Capstoneszn.Forms.SettingsForms
{
    partial class ChangePasswordForm
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
            pnlChangePasswordHeader = new Panel();
            pnlChangePasswordActions = new Panel();
            btnCancelChangePassword = new Button();
            btnSaveNewPassword = new Button();
            lblChangePasswordTitle = new Label();
            pnlChangePasswordContent = new Panel();
            tblChangePasswordInformation = new TableLayoutPanel();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtConfirmNewPassword = new TextBox();
            lblNewPassword = new Label();
            lblConfirmNewPassword = new Label();
            pnlChangePasswordHeader.SuspendLayout();
            pnlChangePasswordActions.SuspendLayout();
            pnlChangePasswordContent.SuspendLayout();
            tblChangePasswordInformation.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChangePasswordHeader
            // 
            pnlChangePasswordHeader.Controls.Add(lblChangePasswordTitle);
            pnlChangePasswordHeader.Dock = DockStyle.Top;
            pnlChangePasswordHeader.Location = new Point(0, 0);
            pnlChangePasswordHeader.Name = "pnlChangePasswordHeader";
            pnlChangePasswordHeader.Size = new Size(482, 70);
            pnlChangePasswordHeader.TabIndex = 0;
            // 
            // pnlChangePasswordActions
            // 
            pnlChangePasswordActions.Controls.Add(btnCancelChangePassword);
            pnlChangePasswordActions.Controls.Add(btnSaveNewPassword);
            pnlChangePasswordActions.Dock = DockStyle.Bottom;
            pnlChangePasswordActions.Location = new Point(0, 283);
            pnlChangePasswordActions.Name = "pnlChangePasswordActions";
            pnlChangePasswordActions.Size = new Size(482, 70);
            pnlChangePasswordActions.TabIndex = 1;
            // 
            // btnCancelChangePassword
            // 
            btnCancelChangePassword.Cursor = Cursors.Hand;
            btnCancelChangePassword.Location = new Point(244, 24);
            btnCancelChangePassword.Name = "btnCancelChangePassword";
            btnCancelChangePassword.Size = new Size(94, 29);
            btnCancelChangePassword.TabIndex = 1;
            btnCancelChangePassword.Text = "Cancel";
            btnCancelChangePassword.UseVisualStyleBackColor = true;
            // 
            // btnSaveNewPassword
            // 
            btnSaveNewPassword.Cursor = Cursors.Hand;
            btnSaveNewPassword.Location = new Point(362, 24);
            btnSaveNewPassword.Name = "btnSaveNewPassword";
            btnSaveNewPassword.Size = new Size(94, 29);
            btnSaveNewPassword.TabIndex = 0;
            btnSaveNewPassword.Text = "Save";
            btnSaveNewPassword.UseVisualStyleBackColor = true;
            // 
            // lblChangePasswordTitle
            // 
            lblChangePasswordTitle.Dock = DockStyle.Fill;
            lblChangePasswordTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChangePasswordTitle.ForeColor = Color.White;
            lblChangePasswordTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblChangePasswordTitle.Location = new Point(0, 0);
            lblChangePasswordTitle.Name = "lblChangePasswordTitle";
            lblChangePasswordTitle.Size = new Size(482, 70);
            lblChangePasswordTitle.TabIndex = 13;
            lblChangePasswordTitle.Text = "Change Password";
            lblChangePasswordTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlChangePasswordContent
            // 
            pnlChangePasswordContent.Controls.Add(tblChangePasswordInformation);
            pnlChangePasswordContent.Dock = DockStyle.Fill;
            pnlChangePasswordContent.Location = new Point(0, 70);
            pnlChangePasswordContent.Name = "pnlChangePasswordContent";
            pnlChangePasswordContent.Size = new Size(482, 213);
            pnlChangePasswordContent.TabIndex = 2;
            // 
            // tblChangePasswordInformation
            // 
            tblChangePasswordInformation.ColumnCount = 2;
            tblChangePasswordInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblChangePasswordInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tblChangePasswordInformation.Controls.Add(lblConfirmNewPassword, 0, 2);
            tblChangePasswordInformation.Controls.Add(lblNewPassword, 0, 1);
            tblChangePasswordInformation.Controls.Add(lblCurrentPassword, 0, 0);
            tblChangePasswordInformation.Controls.Add(txtCurrentPassword, 1, 0);
            tblChangePasswordInformation.Controls.Add(txtNewPassword, 1, 1);
            tblChangePasswordInformation.Controls.Add(txtConfirmNewPassword, 1, 2);
            tblChangePasswordInformation.Dock = DockStyle.Fill;
            tblChangePasswordInformation.Location = new Point(0, 0);
            tblChangePasswordInformation.Name = "tblChangePasswordInformation";
            tblChangePasswordInformation.RowCount = 3;
            tblChangePasswordInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblChangePasswordInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tblChangePasswordInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tblChangePasswordInformation.Size = new Size(482, 213);
            tblChangePasswordInformation.TabIndex = 0;
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.Dock = DockStyle.Fill;
            lblCurrentPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentPassword.ForeColor = Color.White;
            lblCurrentPassword.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentPassword.Location = new Point(3, 0);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(186, 70);
            lblCurrentPassword.TabIndex = 14;
            lblCurrentPassword.Text = "Current Password";
            lblCurrentPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(195, 15);
            txtCurrentPassword.Margin = new Padding(3, 15, 3, 3);
            txtCurrentPassword.Multiline = true;
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(261, 40);
            txtCurrentPassword.TabIndex = 15;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(195, 85);
            txtNewPassword.Margin = new Padding(3, 15, 3, 3);
            txtNewPassword.Multiline = true;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(261, 40);
            txtNewPassword.TabIndex = 15;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.Location = new Point(195, 156);
            txtConfirmNewPassword.Margin = new Padding(3, 15, 3, 3);
            txtConfirmNewPassword.Multiline = true;
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.Size = new Size(261, 40);
            txtConfirmNewPassword.TabIndex = 15;
            txtConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            lblNewPassword.Dock = DockStyle.Fill;
            lblNewPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewPassword.ForeColor = Color.White;
            lblNewPassword.ImageAlign = ContentAlignment.MiddleRight;
            lblNewPassword.Location = new Point(3, 70);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(186, 71);
            lblNewPassword.TabIndex = 16;
            lblNewPassword.Text = "New Password";
            lblNewPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblConfirmNewPassword
            // 
            lblConfirmNewPassword.Dock = DockStyle.Fill;
            lblConfirmNewPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmNewPassword.ForeColor = Color.White;
            lblConfirmNewPassword.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmNewPassword.Location = new Point(3, 141);
            lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            lblConfirmNewPassword.Size = new Size(186, 72);
            lblConfirmNewPassword.TabIndex = 17;
            lblConfirmNewPassword.Text = "Confirm New Password";
            lblConfirmNewPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 20, 38);
            ClientSize = new Size(482, 353);
            Controls.Add(pnlChangePasswordContent);
            Controls.Add(pnlChangePasswordActions);
            Controls.Add(pnlChangePasswordHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangePasswordForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Password";
            pnlChangePasswordHeader.ResumeLayout(false);
            pnlChangePasswordActions.ResumeLayout(false);
            pnlChangePasswordContent.ResumeLayout(false);
            tblChangePasswordInformation.ResumeLayout(false);
            tblChangePasswordInformation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlChangePasswordHeader;
        private Panel pnlChangePasswordActions;
        private Button btnCancelChangePassword;
        private Button btnSaveNewPassword;
        private Label lblChangePasswordTitle;
        private Panel pnlChangePasswordContent;
        private TableLayoutPanel tblChangePasswordInformation;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private TextBox txtConfirmNewPassword;
        private Label lblConfirmNewPassword;
        private Label lblNewPassword;
    }
}