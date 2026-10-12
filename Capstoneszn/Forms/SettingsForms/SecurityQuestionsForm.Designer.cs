namespace Capstoneszn.Forms.SettingsForms
{
    partial class SecurityQuestionsForm
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
            pnlSecurityQuestionsHeader = new Panel();
            lblSecurityQuestionsHint = new Label();
            lblSecurityQuestionsTitle = new Label();
            pnlSecurityQuestionsActions = new Panel();
            btnCancelSecurityQuestions = new Button();
            btnSaveSecurityQuestions = new Button();
            pnlPasswordConfirm = new Panel();
            txtCurrentPassword = new TextBox();
            lblCurrentPassword = new Label();
            pnlSecurityQuestionsContent = new Panel();
            pnlQuestion2 = new Panel();
            txtAnswer2 = new TextBox();
            lblAnswerCaption2 = new Label();
            txtQuestion2 = new TextBox();
            lblQuestionCaption2 = new Label();
            lblQuestion2 = new Label();
            pnlQuestion3 = new Panel();
            txtAnswer3 = new TextBox();
            lblAnswerCaption3 = new Label();
            txtQuestion3 = new TextBox();
            lblQuestionCaption3 = new Label();
            lblQuestion3 = new Label();
            pnlQuestion1 = new Panel();
            txtAnswer1 = new TextBox();
            lblAnswerCaption1 = new Label();
            txtQuestion1 = new TextBox();
            lblQuestionCaption1 = new Label();
            lblQuestion1 = new Label();
            pnlSecurityQuestionsHeader.SuspendLayout();
            pnlSecurityQuestionsActions.SuspendLayout();
            pnlPasswordConfirm.SuspendLayout();
            pnlSecurityQuestionsContent.SuspendLayout();
            pnlQuestion2.SuspendLayout();
            pnlQuestion3.SuspendLayout();
            pnlQuestion1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSecurityQuestionsHeader
            // 
            pnlSecurityQuestionsHeader.Controls.Add(lblSecurityQuestionsHint);
            pnlSecurityQuestionsHeader.Controls.Add(lblSecurityQuestionsTitle);
            pnlSecurityQuestionsHeader.Dock = DockStyle.Top;
            pnlSecurityQuestionsHeader.Location = new Point(0, 0);
            pnlSecurityQuestionsHeader.Name = "pnlSecurityQuestionsHeader";
            pnlSecurityQuestionsHeader.Size = new Size(700, 110);
            pnlSecurityQuestionsHeader.TabIndex = 0;
            // 
            // lblSecurityQuestionsHint
            // 
            lblSecurityQuestionsHint.Dock = DockStyle.Fill;
            lblSecurityQuestionsHint.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSecurityQuestionsHint.ForeColor = Color.White;
            lblSecurityQuestionsHint.Location = new Point(0, 50);
            lblSecurityQuestionsHint.Name = "lblSecurityQuestionsHint";
            lblSecurityQuestionsHint.Size = new Size(700, 60);
            lblSecurityQuestionsHint.TabIndex = 1;
            lblSecurityQuestionsHint.Text = "Write three questions only you can answer. Answers are case-sensitive.";
            lblSecurityQuestionsHint.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSecurityQuestionsTitle
            // 
            lblSecurityQuestionsTitle.Dock = DockStyle.Top;
            lblSecurityQuestionsTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSecurityQuestionsTitle.ForeColor = Color.White;
            lblSecurityQuestionsTitle.Location = new Point(0, 0);
            lblSecurityQuestionsTitle.Name = "lblSecurityQuestionsTitle";
            lblSecurityQuestionsTitle.Size = new Size(700, 50);
            lblSecurityQuestionsTitle.TabIndex = 0;
            lblSecurityQuestionsTitle.Text = "Security Questions";
            lblSecurityQuestionsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSecurityQuestionsActions
            // 
            pnlSecurityQuestionsActions.Controls.Add(btnCancelSecurityQuestions);
            pnlSecurityQuestionsActions.Controls.Add(btnSaveSecurityQuestions);
            pnlSecurityQuestionsActions.Dock = DockStyle.Bottom;
            pnlSecurityQuestionsActions.Location = new Point(0, 580);
            pnlSecurityQuestionsActions.Name = "pnlSecurityQuestionsActions";
            pnlSecurityQuestionsActions.Padding = new Padding(15);
            pnlSecurityQuestionsActions.Size = new Size(700, 70);
            pnlSecurityQuestionsActions.TabIndex = 3;
            // 
            // btnCancelSecurityQuestions
            // 
            btnCancelSecurityQuestions.Cursor = Cursors.Hand;
            btnCancelSecurityQuestions.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelSecurityQuestions.Location = new Point(405, 15);
            btnCancelSecurityQuestions.Name = "btnCancelSecurityQuestions";
            btnCancelSecurityQuestions.Size = new Size(130, 40);
            btnCancelSecurityQuestions.TabIndex = 1;
            btnCancelSecurityQuestions.Text = "Cancel";
            btnCancelSecurityQuestions.UseVisualStyleBackColor = true;
            btnCancelSecurityQuestions.Click += btnCancelSecurityQuestions_Click;
            // 
            // btnSaveSecurityQuestions
            // 
            btnSaveSecurityQuestions.Cursor = Cursors.Hand;
            btnSaveSecurityQuestions.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSaveSecurityQuestions.Location = new Point(555, 15);
            btnSaveSecurityQuestions.Name = "btnSaveSecurityQuestions";
            btnSaveSecurityQuestions.Size = new Size(130, 40);
            btnSaveSecurityQuestions.TabIndex = 0;
            btnSaveSecurityQuestions.Text = "Save";
            btnSaveSecurityQuestions.UseVisualStyleBackColor = true;
            btnSaveSecurityQuestions.Click += btnSaveSecurityQuestions_Click;
            // 
            // pnlPasswordConfirm
            // 
            pnlPasswordConfirm.BorderStyle = BorderStyle.FixedSingle;
            pnlPasswordConfirm.Controls.Add(txtCurrentPassword);
            pnlPasswordConfirm.Controls.Add(lblCurrentPassword);
            pnlPasswordConfirm.Dock = DockStyle.Bottom;
            pnlPasswordConfirm.Location = new Point(0, 500);
            pnlPasswordConfirm.Name = "pnlPasswordConfirm";
            pnlPasswordConfirm.Size = new Size(700, 80);
            pnlPasswordConfirm.TabIndex = 2;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCurrentPassword.Location = new Point(230, 26);
            txtCurrentPassword.MaxLength = 72;
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '*';
            txtCurrentPassword.Size = new Size(410, 31);
            txtCurrentPassword.TabIndex = 1;
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentPassword.ForeColor = Color.White;
            lblCurrentPassword.Location = new Point(50, 30);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(150, 25);
            lblCurrentPassword.TabIndex = 0;
            lblCurrentPassword.Text = "Current Password";
            // 
            // pnlSecurityQuestionsContent
            // 
            pnlSecurityQuestionsContent.Controls.Add(pnlQuestion2);
            pnlSecurityQuestionsContent.Controls.Add(pnlQuestion3);
            pnlSecurityQuestionsContent.Controls.Add(pnlQuestion1);
            pnlSecurityQuestionsContent.Dock = DockStyle.Fill;
            pnlSecurityQuestionsContent.Location = new Point(0, 110);
            pnlSecurityQuestionsContent.Name = "pnlSecurityQuestionsContent";
            pnlSecurityQuestionsContent.Size = new Size(700, 390);
            pnlSecurityQuestionsContent.TabIndex = 1;
            // 
            // pnlQuestion2
            // 
            pnlQuestion2.BorderStyle = BorderStyle.FixedSingle;
            pnlQuestion2.Controls.Add(txtAnswer2);
            pnlQuestion2.Controls.Add(lblAnswerCaption2);
            pnlQuestion2.Controls.Add(txtQuestion2);
            pnlQuestion2.Controls.Add(lblQuestionCaption2);
            pnlQuestion2.Controls.Add(lblQuestion2);
            pnlQuestion2.Dock = DockStyle.Fill;
            pnlQuestion2.Location = new Point(0, 130);
            pnlQuestion2.Name = "pnlQuestion2";
            pnlQuestion2.Size = new Size(700, 130);
            pnlQuestion2.TabIndex = 1;
            // 
            // txtAnswer2
            // 
            txtAnswer2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnswer2.Location = new Point(160, 82);
            txtAnswer2.MaxLength = 255;
            txtAnswer2.Name = "txtAnswer2";
            txtAnswer2.Size = new Size(480, 31);
            txtAnswer2.TabIndex = 4;
            // 
            // lblAnswerCaption2
            // 
            lblAnswerCaption2.AutoSize = true;
            lblAnswerCaption2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAnswerCaption2.ForeColor = Color.White;
            lblAnswerCaption2.Location = new Point(50, 86);
            lblAnswerCaption2.Name = "lblAnswerCaption2";
            lblAnswerCaption2.Size = new Size(70, 25);
            lblAnswerCaption2.TabIndex = 3;
            lblAnswerCaption2.Text = "Answer";
            // 
            // txtQuestion2
            // 
            txtQuestion2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuestion2.Location = new Point(160, 38);
            txtQuestion2.MaxLength = 120;
            txtQuestion2.Name = "txtQuestion2";
            txtQuestion2.Size = new Size(480, 31);
            txtQuestion2.TabIndex = 2;
            // 
            // lblQuestionCaption2
            // 
            lblQuestionCaption2.AutoSize = true;
            lblQuestionCaption2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionCaption2.ForeColor = Color.White;
            lblQuestionCaption2.Location = new Point(50, 42);
            lblQuestionCaption2.Name = "lblQuestionCaption2";
            lblQuestionCaption2.Size = new Size(84, 25);
            lblQuestionCaption2.TabIndex = 1;
            lblQuestionCaption2.Text = "Question";
            // 
            // lblQuestion2
            // 
            lblQuestion2.Dock = DockStyle.Top;
            lblQuestion2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion2.ForeColor = Color.White;
            lblQuestion2.Location = new Point(0, 0);
            lblQuestion2.Name = "lblQuestion2";
            lblQuestion2.Size = new Size(698, 30);
            lblQuestion2.TabIndex = 0;
            lblQuestion2.Text = "Question No. 2";
            lblQuestion2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlQuestion3
            // 
            pnlQuestion3.BorderStyle = BorderStyle.FixedSingle;
            pnlQuestion3.Controls.Add(txtAnswer3);
            pnlQuestion3.Controls.Add(lblAnswerCaption3);
            pnlQuestion3.Controls.Add(txtQuestion3);
            pnlQuestion3.Controls.Add(lblQuestionCaption3);
            pnlQuestion3.Controls.Add(lblQuestion3);
            pnlQuestion3.Dock = DockStyle.Bottom;
            pnlQuestion3.Location = new Point(0, 260);
            pnlQuestion3.Name = "pnlQuestion3";
            pnlQuestion3.Size = new Size(700, 130);
            pnlQuestion3.TabIndex = 2;
            // 
            // txtAnswer3
            // 
            txtAnswer3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnswer3.Location = new Point(160, 82);
            txtAnswer3.MaxLength = 255;
            txtAnswer3.Name = "txtAnswer3";
            txtAnswer3.Size = new Size(480, 31);
            txtAnswer3.TabIndex = 4;
            // 
            // lblAnswerCaption3
            // 
            lblAnswerCaption3.AutoSize = true;
            lblAnswerCaption3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAnswerCaption3.ForeColor = Color.White;
            lblAnswerCaption3.Location = new Point(50, 86);
            lblAnswerCaption3.Name = "lblAnswerCaption3";
            lblAnswerCaption3.Size = new Size(70, 25);
            lblAnswerCaption3.TabIndex = 3;
            lblAnswerCaption3.Text = "Answer";
            // 
            // txtQuestion3
            // 
            txtQuestion3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuestion3.Location = new Point(160, 38);
            txtQuestion3.MaxLength = 120;
            txtQuestion3.Name = "txtQuestion3";
            txtQuestion3.Size = new Size(480, 31);
            txtQuestion3.TabIndex = 2;
            // 
            // lblQuestionCaption3
            // 
            lblQuestionCaption3.AutoSize = true;
            lblQuestionCaption3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionCaption3.ForeColor = Color.White;
            lblQuestionCaption3.Location = new Point(50, 42);
            lblQuestionCaption3.Name = "lblQuestionCaption3";
            lblQuestionCaption3.Size = new Size(84, 25);
            lblQuestionCaption3.TabIndex = 1;
            lblQuestionCaption3.Text = "Question";
            // 
            // lblQuestion3
            // 
            lblQuestion3.Dock = DockStyle.Top;
            lblQuestion3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion3.ForeColor = Color.White;
            lblQuestion3.Location = new Point(0, 0);
            lblQuestion3.Name = "lblQuestion3";
            lblQuestion3.Size = new Size(698, 30);
            lblQuestion3.TabIndex = 0;
            lblQuestion3.Text = "Question No. 3";
            lblQuestion3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlQuestion1
            // 
            pnlQuestion1.BorderStyle = BorderStyle.FixedSingle;
            pnlQuestion1.Controls.Add(txtAnswer1);
            pnlQuestion1.Controls.Add(lblAnswerCaption1);
            pnlQuestion1.Controls.Add(txtQuestion1);
            pnlQuestion1.Controls.Add(lblQuestionCaption1);
            pnlQuestion1.Controls.Add(lblQuestion1);
            pnlQuestion1.Dock = DockStyle.Top;
            pnlQuestion1.Location = new Point(0, 0);
            pnlQuestion1.Name = "pnlQuestion1";
            pnlQuestion1.Size = new Size(700, 130);
            pnlQuestion1.TabIndex = 0;
            // 
            // txtAnswer1
            // 
            txtAnswer1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnswer1.Location = new Point(160, 82);
            txtAnswer1.MaxLength = 255;
            txtAnswer1.Name = "txtAnswer1";
            txtAnswer1.Size = new Size(480, 31);
            txtAnswer1.TabIndex = 4;
            // 
            // lblAnswerCaption1
            // 
            lblAnswerCaption1.AutoSize = true;
            lblAnswerCaption1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAnswerCaption1.ForeColor = Color.White;
            lblAnswerCaption1.Location = new Point(50, 86);
            lblAnswerCaption1.Name = "lblAnswerCaption1";
            lblAnswerCaption1.Size = new Size(70, 25);
            lblAnswerCaption1.TabIndex = 3;
            lblAnswerCaption1.Text = "Answer";
            // 
            // txtQuestion1
            // 
            txtQuestion1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuestion1.Location = new Point(160, 38);
            txtQuestion1.MaxLength = 120;
            txtQuestion1.Name = "txtQuestion1";
            txtQuestion1.Size = new Size(480, 31);
            txtQuestion1.TabIndex = 2;
            // 
            // lblQuestionCaption1
            // 
            lblQuestionCaption1.AutoSize = true;
            lblQuestionCaption1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionCaption1.ForeColor = Color.White;
            lblQuestionCaption1.Location = new Point(50, 42);
            lblQuestionCaption1.Name = "lblQuestionCaption1";
            lblQuestionCaption1.Size = new Size(84, 25);
            lblQuestionCaption1.TabIndex = 1;
            lblQuestionCaption1.Text = "Question";
            // 
            // lblQuestion1
            // 
            lblQuestion1.Dock = DockStyle.Top;
            lblQuestion1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion1.ForeColor = Color.White;
            lblQuestion1.Location = new Point(0, 0);
            lblQuestion1.Name = "lblQuestion1";
            lblQuestion1.Size = new Size(698, 30);
            lblQuestion1.TabIndex = 0;
            lblQuestion1.Text = "Question No. 1";
            lblQuestion1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecurityQuestionsForm
            // 
            AcceptButton = btnSaveSecurityQuestions;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 20, 38);
            CancelButton = btnCancelSecurityQuestions;
            ClientSize = new Size(700, 650);
            Controls.Add(pnlSecurityQuestionsContent);
            Controls.Add(pnlPasswordConfirm);
            Controls.Add(pnlSecurityQuestionsActions);
            Controls.Add(pnlSecurityQuestionsHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SecurityQuestionsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Security Questions";
            FormClosing += SecurityQuestionsForm_FormClosing;
            Load += SecurityQuestionsForm_Load;
            pnlSecurityQuestionsHeader.ResumeLayout(false);
            pnlSecurityQuestionsActions.ResumeLayout(false);
            pnlPasswordConfirm.ResumeLayout(false);
            pnlPasswordConfirm.PerformLayout();
            pnlSecurityQuestionsContent.ResumeLayout(false);
            pnlQuestion2.ResumeLayout(false);
            pnlQuestion2.PerformLayout();
            pnlQuestion3.ResumeLayout(false);
            pnlQuestion3.PerformLayout();
            pnlQuestion1.ResumeLayout(false);
            pnlQuestion1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSecurityQuestionsHeader;
        private Label lblSecurityQuestionsTitle;
        private Label lblSecurityQuestionsHint;
        private Panel pnlSecurityQuestionsActions;
        private Button btnCancelSecurityQuestions;
        private Button btnSaveSecurityQuestions;
        private Panel pnlPasswordConfirm;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Panel pnlSecurityQuestionsContent;
        private Panel pnlQuestion1;
        private Label lblQuestion1;
        private Label lblQuestionCaption1;
        private TextBox txtQuestion1;
        private Label lblAnswerCaption1;
        private TextBox txtAnswer1;
        private Panel pnlQuestion2;
        private Label lblQuestion2;
        private Label lblQuestionCaption2;
        private TextBox txtQuestion2;
        private Label lblAnswerCaption2;
        private TextBox txtAnswer2;
        private Panel pnlQuestion3;
        private Label lblQuestion3;
        private Label lblQuestionCaption3;
        private TextBox txtQuestion3;
        private Label lblAnswerCaption3;
        private TextBox txtAnswer3;
    }
}