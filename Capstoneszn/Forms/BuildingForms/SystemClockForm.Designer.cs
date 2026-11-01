namespace Capstoneszn.Forms.BuildingForms
{
    partial class SystemClockForm
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
            lblDateandTime = new Label();
            lblMessage = new Label();
            btnConfirm = new Button();
            btnGoBack = new Button();
            dtpManualDateTime = new DateTimePicker();
            btnApplyTime = new Button();
            btnCheckAgain = new Button();
            btnFixAutomatically = new Button();
            btnSetManually = new Button();
            SuspendLayout();
            // 
            // lblDateandTime
            // 
            lblDateandTime.AutoSize = true;
            lblDateandTime.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateandTime.ForeColor = Color.White;
            lblDateandTime.Location = new Point(38, 120);
            lblDateandTime.Name = "lblDateandTime";
            lblDateandTime.Size = new Size(258, 46);
            lblDateandTime.TabIndex = 0;
            lblDateandTime.Text = "[Date and Time]";
            lblDateandTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.White;
            lblMessage.Location = new Point(38, 24);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(220, 20);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Checking the date and time...";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpManualDateTime
            // 
            dtpManualDateTime.CustomFormat = "MMMM dd, yyyy   hh:mm tt";
            dtpManualDateTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpManualDateTime.Format = DateTimePickerFormat.Custom;
            dtpManualDateTime.Location = new Point(38, 190);
            dtpManualDateTime.Name = "dtpManualDateTime";
            dtpManualDateTime.Size = new Size(360, 34);
            dtpManualDateTime.TabIndex = 2;
            dtpManualDateTime.Visible = false;
            // 
            // btnApplyTime
            // 
            btnApplyTime.BackColor = Color.White;
            btnApplyTime.FlatStyle = FlatStyle.Flat;
            btnApplyTime.Location = new Point(410, 187);
            btnApplyTime.Name = "btnApplyTime";
            btnApplyTime.Size = new Size(120, 40);
            btnApplyTime.TabIndex = 3;
            btnApplyTime.Text = "Apply Time";
            btnApplyTime.UseVisualStyleBackColor = false;
            btnApplyTime.Visible = false;
            btnApplyTime.Click += btnApplyTime_Click;
            // 
            // btnCheckAgain
            // 
            btnCheckAgain.BackColor = Color.White;
            btnCheckAgain.FlatStyle = FlatStyle.Flat;
            btnCheckAgain.Location = new Point(38, 267);
            btnCheckAgain.Name = "btnCheckAgain";
            btnCheckAgain.Size = new Size(130, 47);
            btnCheckAgain.TabIndex = 4;
            btnCheckAgain.Text = "Check Again";
            btnCheckAgain.UseVisualStyleBackColor = false;
            btnCheckAgain.Visible = false;
            btnCheckAgain.Click += btnCheckAgain_Click;
            // 
            // btnFixAutomatically
            // 
            btnFixAutomatically.BackColor = Color.White;
            btnFixAutomatically.FlatStyle = FlatStyle.Flat;
            btnFixAutomatically.Location = new Point(180, 267);
            btnFixAutomatically.Name = "btnFixAutomatically";
            btnFixAutomatically.Size = new Size(170, 47);
            btnFixAutomatically.TabIndex = 5;
            btnFixAutomatically.Text = "Fix Automatically";
            btnFixAutomatically.UseVisualStyleBackColor = false;
            btnFixAutomatically.Visible = false;
            btnFixAutomatically.Click += btnFixAutomatically_Click;
            // 
            // btnSetManually
            // 
            btnSetManually.BackColor = Color.White;
            btnSetManually.FlatStyle = FlatStyle.Flat;
            btnSetManually.Location = new Point(362, 267);
            btnSetManually.Name = "btnSetManually";
            btnSetManually.Size = new Size(140, 47);
            btnSetManually.TabIndex = 6;
            btnSetManually.Text = "Set Manually";
            btnSetManually.UseVisualStyleBackColor = false;
            btnSetManually.Visible = false;
            btnSetManually.Click += btnSetManually_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(715, 267);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(112, 47);
            btnConfirm.TabIndex = 8;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Visible = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnGoBack
            // 
            btnGoBack.BackColor = Color.White;
            btnGoBack.FlatStyle = FlatStyle.Flat;
            btnGoBack.Location = new Point(608, 267);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(101, 47);
            btnGoBack.TabIndex = 7;
            btnGoBack.Text = "Exit";   // was "Go Back" - the form now opens before Login, so this closes the app
            btnGoBack.UseVisualStyleBackColor = false;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // SystemClockForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(839, 326);
            Controls.Add(btnSetManually);
            Controls.Add(btnFixAutomatically);
            Controls.Add(btnCheckAgain);
            Controls.Add(btnApplyTime);
            Controls.Add(dtpManualDateTime);
            Controls.Add(btnGoBack);
            Controls.Add(btnConfirm);
            Controls.Add(lblMessage);
            Controls.Add(lblDateandTime);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SystemClockForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "System Clock Confirmation";
            Load += SystemClockForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDateandTime;
        private Label lblMessage;
        private Button btnConfirm;
        private Button btnGoBack;
        private DateTimePicker dtpManualDateTime;
        private Button btnApplyTime;
        private Button btnCheckAgain;
        private Button btnFixAutomatically;
        private Button btnSetManually;
    }
}