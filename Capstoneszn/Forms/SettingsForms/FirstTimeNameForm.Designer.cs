namespace Capstoneszn.Forms.SettingsForms
{
    partial class FirstTimeNameForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlFirstTimeNameHeader = new Panel();
            lblFirstTimeNameTitle = new Label();
            pnlFirstTimeNameActions = new Panel();
            btnSaveName = new Button();
            pnlFirstTimeNameContent = new Panel();
            lblGreeting = new Label();
            lblName = new Label();
            txtName = new TextBox();
            pnlFirstTimeNameHeader.SuspendLayout();
            pnlFirstTimeNameActions.SuspendLayout();
            pnlFirstTimeNameContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFirstTimeNameHeader
            // 
            pnlFirstTimeNameHeader.Controls.Add(lblFirstTimeNameTitle);
            pnlFirstTimeNameHeader.Dock = DockStyle.Top;
            pnlFirstTimeNameHeader.Location = new Point(0, 0);
            pnlFirstTimeNameHeader.Name = "pnlFirstTimeNameHeader";
            pnlFirstTimeNameHeader.Size = new Size(540, 70);
            pnlFirstTimeNameHeader.TabIndex = 0;
            // 
            // lblFirstTimeNameTitle
            // 
            lblFirstTimeNameTitle.Dock = DockStyle.Fill;
            lblFirstTimeNameTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstTimeNameTitle.ForeColor = Color.White;
            lblFirstTimeNameTitle.Location = new Point(0, 0);
            lblFirstTimeNameTitle.Name = "lblFirstTimeNameTitle";
            lblFirstTimeNameTitle.Size = new Size(540, 70);
            lblFirstTimeNameTitle.TabIndex = 0;
            lblFirstTimeNameTitle.Text = "Welcome to KSU: Billing Management System!";
            lblFirstTimeNameTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFirstTimeNameActions
            // 
            pnlFirstTimeNameActions.Controls.Add(btnSaveName);
            pnlFirstTimeNameActions.Dock = DockStyle.Bottom;
            pnlFirstTimeNameActions.Location = new Point(0, 270);
            pnlFirstTimeNameActions.Name = "pnlFirstTimeNameActions";
            pnlFirstTimeNameActions.Size = new Size(540, 70);
            pnlFirstTimeNameActions.TabIndex = 2;
            // 
            // btnSaveName
            // 
            btnSaveName.Cursor = Cursors.Hand;
            btnSaveName.Location = new Point(420, 24);
            btnSaveName.Name = "btnSaveName";
            btnSaveName.Size = new Size(94, 29);
            btnSaveName.TabIndex = 0;
            btnSaveName.Text = "Save";
            btnSaveName.UseVisualStyleBackColor = true;
            btnSaveName.Click += btnSaveName_Click;
            // 
            // pnlFirstTimeNameContent
            // 
            pnlFirstTimeNameContent.Controls.Add(lblGreeting);
            pnlFirstTimeNameContent.Controls.Add(lblName);
            pnlFirstTimeNameContent.Controls.Add(txtName);
            pnlFirstTimeNameContent.Dock = DockStyle.Fill;
            pnlFirstTimeNameContent.Location = new Point(0, 70);
            pnlFirstTimeNameContent.Name = "pnlFirstTimeNameContent";
            pnlFirstTimeNameContent.Size = new Size(540, 200);
            pnlFirstTimeNameContent.TabIndex = 1;
            // 
            // lblGreeting
            // 
            lblGreeting.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGreeting.ForeColor = Color.White;
            lblGreeting.Location = new Point(24, 12);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(490, 90);
            lblGreeting.TabIndex = 0;
            lblGreeting.Text = "We're glad to have you! Before you get started, please tell us your name. " +
                "It will be shown on the main screen and on the reports you generate.";
            lblGreeting.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(24, 128);
            lblName.Name = "lblName";
            lblName.Size = new Size(150, 37);
            lblName.TabIndex = 1;
            lblName.Text = "Your Name";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 13.2000008F);
            txtName.Location = new Point(180, 128);
            txtName.MaxLength = 150;
            txtName.Name = "txtName";
            txtName.Size = new Size(334, 37);
            txtName.TabIndex = 0;
            // 
            // FirstTimeNameForm
            // 
            AcceptButton = btnSaveName;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(540, 340);
            Controls.Add(pnlFirstTimeNameContent);
            Controls.Add(pnlFirstTimeNameActions);
            Controls.Add(pnlFirstTimeNameHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FirstTimeNameForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Welcome";
            FormClosing += FirstTimeNameForm_FormClosing;
            Load += FirstTimeNameForm_Load;
            pnlFirstTimeNameHeader.ResumeLayout(false);
            pnlFirstTimeNameActions.ResumeLayout(false);
            pnlFirstTimeNameContent.ResumeLayout(false);
            pnlFirstTimeNameContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFirstTimeNameHeader;
        private Label lblFirstTimeNameTitle;
        private Panel pnlFirstTimeNameActions;
        private Button btnSaveName;
        private Panel pnlFirstTimeNameContent;
        private Label lblGreeting;
        private Label lblName;
        private TextBox txtName;
    }
}
