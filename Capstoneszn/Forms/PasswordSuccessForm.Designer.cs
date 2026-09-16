namespace Capstoneszn.Forms
{
    partial class PasswordSuccessForm
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
            pnlPasswordSuccessActionButton = new Panel();
            btnReturn = new Button();
            pnlPasswordSuccessContent = new Panel();
            lblPasswordSuccessDescription = new Label();
            lblPasswordSuccessTitle = new Label();
            pnlPasswordSuccessActionButton.SuspendLayout();
            pnlPasswordSuccessContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPasswordSuccessActionButton
            // 
            pnlPasswordSuccessActionButton.BorderStyle = BorderStyle.FixedSingle;
            pnlPasswordSuccessActionButton.Controls.Add(btnReturn);
            pnlPasswordSuccessActionButton.Dock = DockStyle.Bottom;
            pnlPasswordSuccessActionButton.Location = new Point(0, 243);
            pnlPasswordSuccessActionButton.Name = "pnlPasswordSuccessActionButton";
            pnlPasswordSuccessActionButton.Size = new Size(332, 60);
            pnlPasswordSuccessActionButton.TabIndex = 0;
            // 
            // btnReturn
            // 
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.Location = new Point(101, 18);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(135, 29);
            btnReturn.TabIndex = 0;
            btnReturn.Text = "Return To Login";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // pnlPasswordSuccessContent
            // 
            pnlPasswordSuccessContent.BorderStyle = BorderStyle.FixedSingle;
            pnlPasswordSuccessContent.Controls.Add(lblPasswordSuccessDescription);
            pnlPasswordSuccessContent.Controls.Add(lblPasswordSuccessTitle);
            pnlPasswordSuccessContent.Dock = DockStyle.Fill;
            pnlPasswordSuccessContent.Location = new Point(0, 0);
            pnlPasswordSuccessContent.Name = "pnlPasswordSuccessContent";
            pnlPasswordSuccessContent.Size = new Size(332, 243);
            pnlPasswordSuccessContent.TabIndex = 1;
            // 
            // lblPasswordSuccessDescription
            // 
            lblPasswordSuccessDescription.BorderStyle = BorderStyle.FixedSingle;
            lblPasswordSuccessDescription.Dock = DockStyle.Top;
            lblPasswordSuccessDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPasswordSuccessDescription.ForeColor = Color.White;
            lblPasswordSuccessDescription.Location = new Point(0, 120);
            lblPasswordSuccessDescription.Name = "lblPasswordSuccessDescription";
            lblPasswordSuccessDescription.Size = new Size(330, 120);
            lblPasswordSuccessDescription.TabIndex = 10;
            lblPasswordSuccessDescription.Text = "Your Password Has Been Successfully Changed!";
            lblPasswordSuccessDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPasswordSuccessTitle
            // 
            lblPasswordSuccessTitle.BorderStyle = BorderStyle.FixedSingle;
            lblPasswordSuccessTitle.Dock = DockStyle.Top;
            lblPasswordSuccessTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPasswordSuccessTitle.ForeColor = Color.White;
            lblPasswordSuccessTitle.Location = new Point(0, 0);
            lblPasswordSuccessTitle.Name = "lblPasswordSuccessTitle";
            lblPasswordSuccessTitle.Size = new Size(330, 120);
            lblPasswordSuccessTitle.TabIndex = 9;
            lblPasswordSuccessTitle.Text = "Password Changed!";
            lblPasswordSuccessTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PasswordSuccessForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(332, 303);
            Controls.Add(pnlPasswordSuccessContent);
            Controls.Add(pnlPasswordSuccessActionButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PasswordSuccessForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PasswordSuccessForm";
            pnlPasswordSuccessActionButton.ResumeLayout(false);
            pnlPasswordSuccessContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPasswordSuccessActionButton;
        private Panel pnlPasswordSuccessContent;
        private Label lblPasswordSuccessTitle;
        private Label lblPasswordSuccessDescription;
        private Button btnReturn;
    }
}