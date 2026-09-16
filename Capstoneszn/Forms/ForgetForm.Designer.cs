namespace Capstoneszn
{
    partial class ForgetForm
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
            lblSecurityVerificationTitle = new Label();
            lblSecurityVerificationDescription = new Label();
            lblQuestionOne = new Label();
            lblQuestion2 = new Label();
            lblQuestion3 = new Label();
            btnVerify = new Button();
            txtQuestionOne = new TextBox();
            txtQuestionTwo = new TextBox();
            txtQuestionThree = new TextBox();
            pnlSecurityVerificationHeader = new Panel();
            pnlSecurityVerificationActionButtons = new Panel();
            pnlSecurityVerificationContent = new Panel();
            btnCancel = new Button();
            pnlSecurityVerificationHeader.SuspendLayout();
            pnlSecurityVerificationActionButtons.SuspendLayout();
            pnlSecurityVerificationContent.SuspendLayout();
            SuspendLayout();
            // 
            // lblSecurityVerificationTitle
            // 
            lblSecurityVerificationTitle.Dock = DockStyle.Fill;
            lblSecurityVerificationTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSecurityVerificationTitle.ForeColor = Color.White;
            lblSecurityVerificationTitle.Location = new Point(0, 0);
            lblSecurityVerificationTitle.Name = "lblSecurityVerificationTitle";
            lblSecurityVerificationTitle.Size = new Size(630, 48);
            lblSecurityVerificationTitle.TabIndex = 0;
            lblSecurityVerificationTitle.Text = "Security Verification";
            lblSecurityVerificationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSecurityVerificationDescription
            // 
            lblSecurityVerificationDescription.Dock = DockStyle.Top;
            lblSecurityVerificationDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSecurityVerificationDescription.ForeColor = Color.White;
            lblSecurityVerificationDescription.Location = new Point(0, 0);
            lblSecurityVerificationDescription.Name = "lblSecurityVerificationDescription";
            lblSecurityVerificationDescription.Size = new Size(630, 40);
            lblSecurityVerificationDescription.TabIndex = 1;
            lblSecurityVerificationDescription.Text = "Please answer these security question to verify ";
            lblSecurityVerificationDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuestionOne
            // 
            lblQuestionOne.AutoSize = true;
            lblQuestionOne.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionOne.ForeColor = Color.White;
            lblQuestionOne.Location = new Point(111, 81);
            lblQuestionOne.Name = "lblQuestionOne";
            lblQuestionOne.Size = new Size(155, 31);
            lblQuestionOne.TabIndex = 2;
            lblQuestionOne.Text = "Question no.1";
            lblQuestionOne.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuestion2
            // 
            lblQuestion2.AutoSize = true;
            lblQuestion2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion2.ForeColor = Color.White;
            lblQuestion2.Location = new Point(111, 189);
            lblQuestion2.Name = "lblQuestion2";
            lblQuestion2.Size = new Size(155, 31);
            lblQuestion2.TabIndex = 3;
            lblQuestion2.Text = "Question no.2";
            lblQuestion2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuestion3
            // 
            lblQuestion3.AutoSize = true;
            lblQuestion3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion3.ForeColor = Color.White;
            lblQuestion3.Location = new Point(111, 298);
            lblQuestion3.Name = "lblQuestion3";
            lblQuestion3.Size = new Size(155, 31);
            lblQuestion3.TabIndex = 4;
            lblQuestion3.Text = "Question no.3";
            lblQuestion3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnVerify
            // 
            btnVerify.Cursor = Cursors.Hand;
            btnVerify.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerify.Location = new Point(419, 12);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(200, 35);
            btnVerify.TabIndex = 5;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // txtQuestionOne
            // 
            txtQuestionOne.Location = new Point(111, 119);
            txtQuestionOne.Multiline = true;
            txtQuestionOne.Name = "txtQuestionOne";
            txtQuestionOne.Size = new Size(350, 40);
            txtQuestionOne.TabIndex = 6;
            // 
            // txtQuestionTwo
            // 
            txtQuestionTwo.Location = new Point(111, 227);
            txtQuestionTwo.Multiline = true;
            txtQuestionTwo.Name = "txtQuestionTwo";
            txtQuestionTwo.Size = new Size(350, 40);
            txtQuestionTwo.TabIndex = 7;
            // 
            // txtQuestionThree
            // 
            txtQuestionThree.Location = new Point(111, 336);
            txtQuestionThree.Multiline = true;
            txtQuestionThree.Name = "txtQuestionThree";
            txtQuestionThree.Size = new Size(350, 40);
            txtQuestionThree.TabIndex = 8;
            // 
            // pnlSecurityVerificationHeader
            // 
            pnlSecurityVerificationHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlSecurityVerificationHeader.Controls.Add(lblSecurityVerificationTitle);
            pnlSecurityVerificationHeader.Dock = DockStyle.Top;
            pnlSecurityVerificationHeader.Location = new Point(0, 0);
            pnlSecurityVerificationHeader.Name = "pnlSecurityVerificationHeader";
            pnlSecurityVerificationHeader.Size = new Size(632, 50);
            pnlSecurityVerificationHeader.TabIndex = 9;
            // 
            // pnlSecurityVerificationActionButtons
            // 
            pnlSecurityVerificationActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlSecurityVerificationActionButtons.Controls.Add(btnCancel);
            pnlSecurityVerificationActionButtons.Controls.Add(btnVerify);
            pnlSecurityVerificationActionButtons.Dock = DockStyle.Bottom;
            pnlSecurityVerificationActionButtons.Location = new Point(0, 493);
            pnlSecurityVerificationActionButtons.Name = "pnlSecurityVerificationActionButtons";
            pnlSecurityVerificationActionButtons.Size = new Size(632, 60);
            pnlSecurityVerificationActionButtons.TabIndex = 10;
            // 
            // pnlSecurityVerificationContent
            // 
            pnlSecurityVerificationContent.BorderStyle = BorderStyle.FixedSingle;
            pnlSecurityVerificationContent.Controls.Add(txtQuestionOne);
            pnlSecurityVerificationContent.Controls.Add(lblSecurityVerificationDescription);
            pnlSecurityVerificationContent.Controls.Add(txtQuestionTwo);
            pnlSecurityVerificationContent.Controls.Add(txtQuestionThree);
            pnlSecurityVerificationContent.Controls.Add(lblQuestion3);
            pnlSecurityVerificationContent.Controls.Add(lblQuestion2);
            pnlSecurityVerificationContent.Controls.Add(lblQuestionOne);
            pnlSecurityVerificationContent.Dock = DockStyle.Fill;
            pnlSecurityVerificationContent.Location = new Point(0, 50);
            pnlSecurityVerificationContent.Name = "pnlSecurityVerificationContent";
            pnlSecurityVerificationContent.Size = new Size(632, 443);
            pnlSecurityVerificationContent.TabIndex = 11;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(248, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 35);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ForgetForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(632, 553);
            Controls.Add(pnlSecurityVerificationContent);
            Controls.Add(pnlSecurityVerificationActionButtons);
            Controls.Add(pnlSecurityVerificationHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ForgetForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgetForm";
            Load += ForgetForm_Load;
            pnlSecurityVerificationHeader.ResumeLayout(false);
            pnlSecurityVerificationActionButtons.ResumeLayout(false);
            pnlSecurityVerificationContent.ResumeLayout(false);
            pnlSecurityVerificationContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblSecurityVerificationTitle;
        private Label lblSecurityVerificationDescription;
        private Label lblQuestionOne;
        private Label lblQuestion2;
        private Label lblQuestion3;
        private Button btnVerify;
        private TextBox txtQuestionOne;
        private TextBox txtQuestionTwo;
        private TextBox txtQuestionThree;
        private Panel pnlSecurityVerificationHeader;
        private Panel pnlSecurityVerificationActionButtons;
        private Panel pnlSecurityVerificationContent;
        private Button btnCancel;
    }
}