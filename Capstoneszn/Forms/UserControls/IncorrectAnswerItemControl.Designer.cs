namespace Capstoneszn.Forms.UserControls
{
    partial class IncorrectAnswerItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            lblQuestionNo = new Label();
            lblQuestion = new Label();
            lblQuestionAnswer = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblQuestionAnswer, 0, 2);
            tableLayoutPanel1.Controls.Add(lblQuestion, 0, 1);
            tableLayoutPanel1.Controls.Add(lblQuestionNo, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(300, 150);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblQuestionNo
            // 
            lblQuestionNo.BorderStyle = BorderStyle.FixedSingle;
            lblQuestionNo.Dock = DockStyle.Fill;
            lblQuestionNo.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionNo.ForeColor = Color.White;
            lblQuestionNo.Location = new Point(3, 0);
            lblQuestionNo.Name = "lblQuestionNo";
            lblQuestionNo.Size = new Size(294, 50);
            lblQuestionNo.TabIndex = 6;
            lblQuestionNo.Text = "Question No #";
            lblQuestionNo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuestion
            // 
            lblQuestion.BorderStyle = BorderStyle.FixedSingle;
            lblQuestion.Dock = DockStyle.Fill;
            lblQuestion.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion.ForeColor = Color.White;
            lblQuestion.Location = new Point(3, 50);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(294, 50);
            lblQuestion.TabIndex = 7;
            lblQuestion.Text = "What is your progress?";
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuestionAnswer
            // 
            lblQuestionAnswer.BorderStyle = BorderStyle.FixedSingle;
            lblQuestionAnswer.Dock = DockStyle.Fill;
            lblQuestionAnswer.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestionAnswer.ForeColor = Color.White;
            lblQuestionAnswer.Location = new Point(3, 100);
            lblQuestionAnswer.Name = "lblQuestionAnswer";
            lblQuestionAnswer.Size = new Size(294, 50);
            lblQuestionAnswer.TabIndex = 8;
            lblQuestionAnswer.Text = "Your Answer: nganga";
            lblQuestionAnswer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IncorrectAnswerItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(tableLayoutPanel1);
            Name = "IncorrectAnswerItemControl";
            Size = new Size(300, 150);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblQuestionAnswer;
        private Label lblQuestion;
        private Label lblQuestionNo;
    }
}
