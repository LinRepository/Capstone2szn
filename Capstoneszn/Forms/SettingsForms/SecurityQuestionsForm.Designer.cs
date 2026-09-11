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
            pnlSecurityQuestionsActions = new Panel();
            lblSecurityQuestionsTitle = new Label();
            pnlSecurityQuestionsContent = new Panel();
            pnlQuestion1 = new Panel();
            pnlQuestion3 = new Panel();
            pnlQuestion2 = new Panel();
            lblQuestion1 = new Label();
            txtAnswer1 = new TextBox();
            txtAnswer2 = new TextBox();
            txtAnswer3 = new TextBox();
            btnSaveSecurityQuestions = new Button();
            btnCancelSecurityQuestions = new Button();
            lblQuestion2 = new Label();
            lblQuestion3 = new Label();
            pnlSecurityQuestionsHeader.SuspendLayout();
            pnlSecurityQuestionsActions.SuspendLayout();
            pnlSecurityQuestionsContent.SuspendLayout();
            pnlQuestion1.SuspendLayout();
            pnlQuestion3.SuspendLayout();
            pnlQuestion2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSecurityQuestionsHeader
            // 
            pnlSecurityQuestionsHeader.Controls.Add(lblSecurityQuestionsTitle);
            pnlSecurityQuestionsHeader.Dock = DockStyle.Top;
            pnlSecurityQuestionsHeader.Location = new Point(0, 0);
            pnlSecurityQuestionsHeader.Name = "pnlSecurityQuestionsHeader";
            pnlSecurityQuestionsHeader.Size = new Size(682, 70);
            pnlSecurityQuestionsHeader.TabIndex = 0;
            // 
            // pnlSecurityQuestionsActions
            // 
            pnlSecurityQuestionsActions.Controls.Add(btnCancelSecurityQuestions);
            pnlSecurityQuestionsActions.Controls.Add(btnSaveSecurityQuestions);
            pnlSecurityQuestionsActions.Dock = DockStyle.Bottom;
            pnlSecurityQuestionsActions.Location = new Point(0, 373);
            pnlSecurityQuestionsActions.Name = "pnlSecurityQuestionsActions";
            pnlSecurityQuestionsActions.Size = new Size(682, 80);
            pnlSecurityQuestionsActions.TabIndex = 0;
            // 
            // lblSecurityQuestionsTitle
            // 
            lblSecurityQuestionsTitle.Dock = DockStyle.Fill;
            lblSecurityQuestionsTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSecurityQuestionsTitle.ForeColor = Color.White;
            lblSecurityQuestionsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblSecurityQuestionsTitle.Location = new Point(0, 0);
            lblSecurityQuestionsTitle.Name = "lblSecurityQuestionsTitle";
            lblSecurityQuestionsTitle.Size = new Size(682, 70);
            lblSecurityQuestionsTitle.TabIndex = 14;
            lblSecurityQuestionsTitle.Text = "Security Questions";
            lblSecurityQuestionsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSecurityQuestionsContent
            // 
            pnlSecurityQuestionsContent.Controls.Add(pnlQuestion2);
            pnlSecurityQuestionsContent.Controls.Add(pnlQuestion3);
            pnlSecurityQuestionsContent.Controls.Add(pnlQuestion1);
            pnlSecurityQuestionsContent.Dock = DockStyle.Fill;
            pnlSecurityQuestionsContent.Location = new Point(0, 70);
            pnlSecurityQuestionsContent.Name = "pnlSecurityQuestionsContent";
            pnlSecurityQuestionsContent.Size = new Size(682, 303);
            pnlSecurityQuestionsContent.TabIndex = 1;
            // 
            // pnlQuestion1
            // 
            pnlQuestion1.BorderStyle = BorderStyle.FixedSingle;
            pnlQuestion1.Controls.Add(txtAnswer1);
            pnlQuestion1.Controls.Add(lblQuestion1);
            pnlQuestion1.Dock = DockStyle.Top;
            pnlQuestion1.Location = new Point(0, 0);
            pnlQuestion1.Name = "pnlQuestion1";
            pnlQuestion1.Size = new Size(682, 100);
            pnlQuestion1.TabIndex = 0;
            // 
            // pnlQuestion3
            // 
            pnlQuestion3.BorderStyle = BorderStyle.FixedSingle;
            pnlQuestion3.Controls.Add(lblQuestion3);
            pnlQuestion3.Controls.Add(txtAnswer3);
            pnlQuestion3.Dock = DockStyle.Bottom;
            pnlQuestion3.Location = new Point(0, 203);
            pnlQuestion3.Name = "pnlQuestion3";
            pnlQuestion3.Size = new Size(682, 100);
            pnlQuestion3.TabIndex = 1;
            // 
            // pnlQuestion2
            // 
            pnlQuestion2.BorderStyle = BorderStyle.FixedSingle;
            pnlQuestion2.Controls.Add(lblQuestion2);
            pnlQuestion2.Controls.Add(txtAnswer2);
            pnlQuestion2.Dock = DockStyle.Fill;
            pnlQuestion2.Location = new Point(0, 100);
            pnlQuestion2.Name = "pnlQuestion2";
            pnlQuestion2.Size = new Size(682, 103);
            pnlQuestion2.TabIndex = 2;
            // 
            // lblQuestion1
            // 
            lblQuestion1.Dock = DockStyle.Top;
            lblQuestion1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion1.ForeColor = Color.White;
            lblQuestion1.ImageAlign = ContentAlignment.MiddleRight;
            lblQuestion1.Location = new Point(0, 0);
            lblQuestion1.Name = "lblQuestion1";
            lblQuestion1.Size = new Size(680, 45);
            lblQuestion1.TabIndex = 15;
            lblQuestion1.Text = "What is the name of your first dog?";
            lblQuestion1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAnswer1
            // 
            txtAnswer1.Location = new Point(119, 48);
            txtAnswer1.Multiline = true;
            txtAnswer1.Name = "txtAnswer1";
            txtAnswer1.Size = new Size(450, 35);
            txtAnswer1.TabIndex = 16;
            // 
            // txtAnswer2
            // 
            txtAnswer2.Location = new Point(119, 48);
            txtAnswer2.Multiline = true;
            txtAnswer2.Name = "txtAnswer2";
            txtAnswer2.Size = new Size(450, 35);
            txtAnswer2.TabIndex = 16;
            // 
            // txtAnswer3
            // 
            txtAnswer3.Location = new Point(119, 48);
            txtAnswer3.Multiline = true;
            txtAnswer3.Name = "txtAnswer3";
            txtAnswer3.Size = new Size(450, 35);
            txtAnswer3.TabIndex = 16;
            // 
            // btnSaveSecurityQuestions
            // 
            btnSaveSecurityQuestions.Cursor = Cursors.Hand;
            btnSaveSecurityQuestions.Location = new Point(544, 27);
            btnSaveSecurityQuestions.Name = "btnSaveSecurityQuestions";
            btnSaveSecurityQuestions.Size = new Size(94, 29);
            btnSaveSecurityQuestions.TabIndex = 0;
            btnSaveSecurityQuestions.Text = "Save";
            btnSaveSecurityQuestions.UseVisualStyleBackColor = true;
            // 
            // btnCancelSecurityQuestions
            // 
            btnCancelSecurityQuestions.Cursor = Cursors.Hand;
            btnCancelSecurityQuestions.Location = new Point(417, 27);
            btnCancelSecurityQuestions.Name = "btnCancelSecurityQuestions";
            btnCancelSecurityQuestions.Size = new Size(94, 29);
            btnCancelSecurityQuestions.TabIndex = 1;
            btnCancelSecurityQuestions.Text = "Cancel";
            btnCancelSecurityQuestions.UseVisualStyleBackColor = true;
            // 
            // lblQuestion2
            // 
            lblQuestion2.Dock = DockStyle.Top;
            lblQuestion2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion2.ForeColor = Color.White;
            lblQuestion2.ImageAlign = ContentAlignment.MiddleRight;
            lblQuestion2.Location = new Point(0, 0);
            lblQuestion2.Name = "lblQuestion2";
            lblQuestion2.Size = new Size(680, 45);
            lblQuestion2.TabIndex = 17;
            lblQuestion2.Text = "What is your mother’s maiden name?";
            lblQuestion2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuestion3
            // 
            lblQuestion3.Dock = DockStyle.Top;
            lblQuestion3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion3.ForeColor = Color.White;
            lblQuestion3.ImageAlign = ContentAlignment.MiddleRight;
            lblQuestion3.Location = new Point(0, 0);
            lblQuestion3.Name = "lblQuestion3";
            lblQuestion3.Size = new Size(680, 45);
            lblQuestion3.TabIndex = 17;
            lblQuestion3.Text = "What model is your first car?";
            lblQuestion3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecurityQuestionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 20, 38);
            ClientSize = new Size(682, 453);
            Controls.Add(pnlSecurityQuestionsContent);
            Controls.Add(pnlSecurityQuestionsActions);
            Controls.Add(pnlSecurityQuestionsHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SecurityQuestionsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Security Questions";
            pnlSecurityQuestionsHeader.ResumeLayout(false);
            pnlSecurityQuestionsActions.ResumeLayout(false);
            pnlSecurityQuestionsContent.ResumeLayout(false);
            pnlQuestion1.ResumeLayout(false);
            pnlQuestion1.PerformLayout();
            pnlQuestion3.ResumeLayout(false);
            pnlQuestion3.PerformLayout();
            pnlQuestion2.ResumeLayout(false);
            pnlQuestion2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSecurityQuestionsHeader;
        private Panel pnlSecurityQuestionsActions;
        private Label lblSecurityQuestionsTitle;
        private Panel pnlSecurityQuestionsContent;
        private Panel pnlQuestion2;
        private Panel pnlQuestion3;
        private Panel pnlQuestion1;
        private Label lblQuestion1;
        private Button btnCancelSecurityQuestions;
        private Button btnSaveSecurityQuestions;
        private TextBox txtAnswer2;
        private TextBox txtAnswer3;
        private TextBox txtAnswer1;
        private Label lblQuestion2;
        private Label lblQuestion3;
    }
}