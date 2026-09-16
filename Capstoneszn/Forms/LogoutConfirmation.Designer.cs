namespace Capstoneszn.Forms
{
    partial class LogoutConfirmationForm
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
            btnLogoutYes = new Button();
            btnLogoutCancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnLogoutYes
            // 
            btnLogoutYes.BackColor = Color.White;
            btnLogoutYes.Cursor = Cursors.Hand;
            btnLogoutYes.FlatStyle = FlatStyle.Flat;
            btnLogoutYes.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogoutYes.Location = new Point(108, 151);
            btnLogoutYes.Name = "btnLogoutYes";
            btnLogoutYes.Size = new Size(135, 59);
            btnLogoutYes.TabIndex = 0;
            btnLogoutYes.Text = "Yes";
            btnLogoutYes.UseVisualStyleBackColor = false;
            btnLogoutYes.Click += button1_Click;
            // 
            // btnLogoutCancel
            // 
            btnLogoutCancel.BackColor = Color.White;
            btnLogoutCancel.Cursor = Cursors.Hand;
            btnLogoutCancel.FlatStyle = FlatStyle.Flat;
            btnLogoutCancel.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogoutCancel.Location = new Point(277, 151);
            btnLogoutCancel.Name = "btnLogoutCancel";
            btnLogoutCancel.Size = new Size(151, 59);
            btnLogoutCancel.TabIndex = 1;
            btnLogoutCancel.Text = "Cancel";
            btnLogoutCancel.UseVisualStyleBackColor = false;
            btnLogoutCancel.Click += btnLogoutCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(108, 68);
            label1.Name = "label1";
            label1.Size = new Size(320, 54);
            label1.TabIndex = 2;
            label1.Text = "Confirm Logout?";
            // 
            // LogoutConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(545, 285);
            Controls.Add(label1);
            Controls.Add(btnLogoutCancel);
            Controls.Add(btnLogoutYes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LogoutConfirmationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Logout Confirmation";
            Load += LogoutConfirmationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogoutYes;
        private Button btnLogoutCancel;
        private Label label1;
    }
}