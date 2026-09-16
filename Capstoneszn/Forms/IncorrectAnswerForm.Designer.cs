namespace Capstoneszn.Forms
{
    partial class IncorrectAnswerForm
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
            pnlWrongAnswerHeader = new Panel();
            pnlWrongAnswerActionsButtons = new Panel();
            pnlWrongAnswerContent = new Panel();
            lblWrongAnswerTitle = new Label();
            btnWrongAnswerOK = new Button();
            lblIncorrectDescription = new Label();
            flpIncorrectAnswers = new FlowLayoutPanel();
            pnlWrongAnswerHeader.SuspendLayout();
            pnlWrongAnswerActionsButtons.SuspendLayout();
            pnlWrongAnswerContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlWrongAnswerHeader
            // 
            pnlWrongAnswerHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlWrongAnswerHeader.Controls.Add(lblWrongAnswerTitle);
            pnlWrongAnswerHeader.Dock = DockStyle.Top;
            pnlWrongAnswerHeader.Location = new Point(0, 0);
            pnlWrongAnswerHeader.Name = "pnlWrongAnswerHeader";
            pnlWrongAnswerHeader.Size = new Size(482, 60);
            pnlWrongAnswerHeader.TabIndex = 0;
            // 
            // pnlWrongAnswerActionsButtons
            // 
            pnlWrongAnswerActionsButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlWrongAnswerActionsButtons.Controls.Add(btnWrongAnswerOK);
            pnlWrongAnswerActionsButtons.Dock = DockStyle.Bottom;
            pnlWrongAnswerActionsButtons.Location = new Point(0, 403);
            pnlWrongAnswerActionsButtons.Name = "pnlWrongAnswerActionsButtons";
            pnlWrongAnswerActionsButtons.Size = new Size(482, 50);
            pnlWrongAnswerActionsButtons.TabIndex = 1;
            // 
            // pnlWrongAnswerContent
            // 
            pnlWrongAnswerContent.Controls.Add(flpIncorrectAnswers);
            pnlWrongAnswerContent.Controls.Add(lblIncorrectDescription);
            pnlWrongAnswerContent.Dock = DockStyle.Fill;
            pnlWrongAnswerContent.Location = new Point(0, 60);
            pnlWrongAnswerContent.Name = "pnlWrongAnswerContent";
            pnlWrongAnswerContent.Size = new Size(482, 343);
            pnlWrongAnswerContent.TabIndex = 2;
            // 
            // lblWrongAnswerTitle
            // 
            lblWrongAnswerTitle.BorderStyle = BorderStyle.FixedSingle;
            lblWrongAnswerTitle.Dock = DockStyle.Fill;
            lblWrongAnswerTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWrongAnswerTitle.ForeColor = Color.White;
            lblWrongAnswerTitle.Location = new Point(0, 0);
            lblWrongAnswerTitle.Name = "lblWrongAnswerTitle";
            lblWrongAnswerTitle.Size = new Size(480, 58);
            lblWrongAnswerTitle.TabIndex = 4;
            lblWrongAnswerTitle.Text = "Incorrect Answers";
            lblWrongAnswerTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnWrongAnswerOK
            // 
            btnWrongAnswerOK.Cursor = Cursors.Hand;
            btnWrongAnswerOK.Location = new Point(192, 12);
            btnWrongAnswerOK.Name = "btnWrongAnswerOK";
            btnWrongAnswerOK.Size = new Size(94, 29);
            btnWrongAnswerOK.TabIndex = 0;
            btnWrongAnswerOK.Text = "OK";
            btnWrongAnswerOK.UseVisualStyleBackColor = true;
            // 
            // lblIncorrectDescription
            // 
            lblIncorrectDescription.BorderStyle = BorderStyle.FixedSingle;
            lblIncorrectDescription.Dock = DockStyle.Top;
            lblIncorrectDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIncorrectDescription.ForeColor = Color.White;
            lblIncorrectDescription.Location = new Point(0, 0);
            lblIncorrectDescription.Name = "lblIncorrectDescription";
            lblIncorrectDescription.Size = new Size(482, 40);
            lblIncorrectDescription.TabIndex = 5;
            lblIncorrectDescription.Text = "All 3 security questions were answered incorrectly.";
            lblIncorrectDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpIncorrectAnswers
            // 
            flpIncorrectAnswers.AutoScroll = true;
            flpIncorrectAnswers.BorderStyle = BorderStyle.FixedSingle;
            flpIncorrectAnswers.Dock = DockStyle.Fill;
            flpIncorrectAnswers.FlowDirection = FlowDirection.TopDown;
            flpIncorrectAnswers.Location = new Point(0, 40);
            flpIncorrectAnswers.Name = "flpIncorrectAnswers";
            flpIncorrectAnswers.Size = new Size(482, 303);
            flpIncorrectAnswers.TabIndex = 6;
            // 
            // IncorrectAnswerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 453);
            Controls.Add(pnlWrongAnswerContent);
            Controls.Add(pnlWrongAnswerActionsButtons);
            Controls.Add(pnlWrongAnswerHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "IncorrectAnswerForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Incorrect Answer";
            pnlWrongAnswerHeader.ResumeLayout(false);
            pnlWrongAnswerActionsButtons.ResumeLayout(false);
            pnlWrongAnswerContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlWrongAnswerHeader;
        private Panel pnlWrongAnswerActionsButtons;
        private Panel pnlWrongAnswerContent;
        private Label lblWrongAnswerTitle;
        private Button btnWrongAnswerOK;
        private Label lblIncorrectDescription;
        private FlowLayoutPanel flpIncorrectAnswers;
    }
}