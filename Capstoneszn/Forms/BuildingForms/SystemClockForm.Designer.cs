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
            SuspendLayout();
            // 
            // lblDateandTime
            // 
            lblDateandTime.AutoSize = true;
            lblDateandTime.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateandTime.ForeColor = Color.White;
            lblDateandTime.Location = new Point(64, 149);
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
            lblMessage.Location = new Point(38, 80);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(166, 20);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Confirm data and time?";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(715, 267);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(112, 47);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnGoBack
            // 
            btnGoBack.BackColor = Color.White;
            btnGoBack.FlatStyle = FlatStyle.Flat;
            btnGoBack.Location = new Point(608, 267);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(101, 47);
            btnGoBack.TabIndex = 1;
            btnGoBack.Text = "Go Back";
            btnGoBack.UseVisualStyleBackColor = false;
            btnGoBack.Click += btnGoBack_Click;
            // 
            // SystemClockForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(839, 326);
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
    }
}