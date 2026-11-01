namespace Capstoneszn.Forms.SettingsForms
{
    partial class RestoreConfirmForm
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
            pnlRestoreHeader = new Panel();
            lblRestoreTitle = new Label();
            lblRestoreWarning = new Label();
            lblRestorePassword = new Label();
            txtRestorePassword = new TextBox();
            btnConfirmRestore = new Button();
            btnCancelRestore = new Button();
            pnlRestoreHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRestoreHeader
            // 
            pnlRestoreHeader.Controls.Add(lblRestoreTitle);
            pnlRestoreHeader.Dock = DockStyle.Top;
            pnlRestoreHeader.Location = new Point(0, 0);
            pnlRestoreHeader.Name = "pnlRestoreHeader";
            pnlRestoreHeader.Size = new Size(580, 70);
            pnlRestoreHeader.TabIndex = 0;
            // 
            // lblRestoreTitle
            // 
            lblRestoreTitle.Dock = DockStyle.Fill;
            lblRestoreTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRestoreTitle.ForeColor = Color.White;
            lblRestoreTitle.Location = new Point(0, 0);
            lblRestoreTitle.Name = "lblRestoreTitle";
            lblRestoreTitle.Size = new Size(580, 70);
            lblRestoreTitle.TabIndex = 0;
            lblRestoreTitle.Text = "Restore Data";
            lblRestoreTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRestoreWarning
            // 
            lblRestoreWarning.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRestoreWarning.ForeColor = Color.White;
            lblRestoreWarning.Location = new Point(25, 80);
            lblRestoreWarning.Name = "lblRestoreWarning";
            lblRestoreWarning.Size = new Size(530, 185);
            lblRestoreWarning.TabIndex = 1;
            lblRestoreWarning.Text = "(warning text is set by code)";
            // 
            // lblRestorePassword
            // 
            lblRestorePassword.AutoSize = true;
            lblRestorePassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRestorePassword.ForeColor = Color.White;
            lblRestorePassword.Location = new Point(25, 275);
            lblRestorePassword.Name = "lblRestorePassword";
            lblRestorePassword.Size = new Size(276, 25);
            lblRestorePassword.TabIndex = 2;
            lblRestorePassword.Text = "Enter your password to continue:";
            // 
            // txtRestorePassword
            // 
            txtRestorePassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRestorePassword.Location = new Point(25, 305);
            txtRestorePassword.Name = "txtRestorePassword";
            txtRestorePassword.Size = new Size(530, 34);
            txtRestorePassword.TabIndex = 3;
            txtRestorePassword.UseSystemPasswordChar = true;
            // 
            // btnConfirmRestore
            // 
            btnConfirmRestore.Cursor = Cursors.Hand;
            btnConfirmRestore.DialogResult = DialogResult.OK;
            btnConfirmRestore.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirmRestore.Location = new Point(455, 360);
            btnConfirmRestore.Name = "btnConfirmRestore";
            btnConfirmRestore.Size = new Size(100, 38);
            btnConfirmRestore.TabIndex = 4;
            btnConfirmRestore.Text = "Restore";
            btnConfirmRestore.UseVisualStyleBackColor = true;
            // 
            // btnCancelRestore
            // 
            btnCancelRestore.Cursor = Cursors.Hand;
            btnCancelRestore.DialogResult = DialogResult.Cancel;
            btnCancelRestore.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelRestore.Location = new Point(345, 360);
            btnCancelRestore.Name = "btnCancelRestore";
            btnCancelRestore.Size = new Size(100, 38);
            btnCancelRestore.TabIndex = 5;
            btnCancelRestore.Text = "Cancel";
            btnCancelRestore.UseVisualStyleBackColor = true;
            // 
            // RestoreConfirmForm
            // 
            AcceptButton = btnConfirmRestore;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            CancelButton = btnCancelRestore;
            ClientSize = new Size(580, 420);
            Controls.Add(btnCancelRestore);
            Controls.Add(btnConfirmRestore);
            Controls.Add(txtRestorePassword);
            Controls.Add(lblRestorePassword);
            Controls.Add(lblRestoreWarning);
            Controls.Add(pnlRestoreHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RestoreConfirmForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Restore";
            pnlRestoreHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlRestoreHeader;
        private Label lblRestoreTitle;
        private Label lblRestoreWarning;
        private Label lblRestorePassword;
        private TextBox txtRestorePassword;
        private Button btnConfirmRestore;
        private Button btnCancelRestore;
    }
}