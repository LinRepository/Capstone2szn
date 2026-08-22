namespace Capstoneszn.Forms
{
    partial class SetGlobalRentConfirmationForm
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
            pnlGlobalRentHeader = new Panel();
            pnlGlobalRentActions = new Panel();
            pnlGlobalRentContent = new Panel();
            lblGlobalRentTitle = new Label();
            btnCancelGlobalRent = new Button();
            btnConfirmGlobalRent = new Button();
            lblCurrentRentTitle = new Label();
            lblNewRentTitle = new Label();
            lblGlobalRentNotice = new Label();
            lblGlobalRentQuestion = new Label();
            pnlRentComparison = new Panel();
            pnlCurrentRent = new Panel();
            pnlNewRent = new Panel();
            lblCurrentRentValue = new Label();
            lblNewRentValue = new Label();
            pnlGlobalRentHeader.SuspendLayout();
            pnlGlobalRentActions.SuspendLayout();
            pnlGlobalRentContent.SuspendLayout();
            pnlRentComparison.SuspendLayout();
            pnlCurrentRent.SuspendLayout();
            pnlNewRent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGlobalRentHeader
            // 
            pnlGlobalRentHeader.Controls.Add(lblGlobalRentTitle);
            pnlGlobalRentHeader.Dock = DockStyle.Top;
            pnlGlobalRentHeader.Location = new Point(0, 0);
            pnlGlobalRentHeader.Name = "pnlGlobalRentHeader";
            pnlGlobalRentHeader.Size = new Size(482, 55);
            pnlGlobalRentHeader.TabIndex = 0;
            // 
            // pnlGlobalRentActions
            // 
            pnlGlobalRentActions.Controls.Add(btnConfirmGlobalRent);
            pnlGlobalRentActions.Controls.Add(btnCancelGlobalRent);
            pnlGlobalRentActions.Dock = DockStyle.Bottom;
            pnlGlobalRentActions.Location = new Point(0, 298);
            pnlGlobalRentActions.Name = "pnlGlobalRentActions";
            pnlGlobalRentActions.Size = new Size(482, 55);
            pnlGlobalRentActions.TabIndex = 1;
            // 
            // pnlGlobalRentContent
            // 
            pnlGlobalRentContent.Controls.Add(pnlRentComparison);
            pnlGlobalRentContent.Controls.Add(lblGlobalRentQuestion);
            pnlGlobalRentContent.Controls.Add(lblGlobalRentNotice);
            pnlGlobalRentContent.Dock = DockStyle.Fill;
            pnlGlobalRentContent.Location = new Point(0, 55);
            pnlGlobalRentContent.Name = "pnlGlobalRentContent";
            pnlGlobalRentContent.Size = new Size(482, 243);
            pnlGlobalRentContent.TabIndex = 2;
            // 
            // lblGlobalRentTitle
            // 
            lblGlobalRentTitle.AutoSize = true;
            lblGlobalRentTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGlobalRentTitle.ForeColor = Color.White;
            lblGlobalRentTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblGlobalRentTitle.Location = new Point(122, 12);
            lblGlobalRentTitle.Name = "lblGlobalRentTitle";
            lblGlobalRentTitle.Size = new Size(220, 31);
            lblGlobalRentTitle.TabIndex = 33;
            lblGlobalRentTitle.Text = "Confirm Global Rent";
            lblGlobalRentTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblGlobalRentTitle.Visible = false;
            // 
            // btnCancelGlobalRent
            // 
            btnCancelGlobalRent.Location = new Point(225, 14);
            btnCancelGlobalRent.Name = "btnCancelGlobalRent";
            btnCancelGlobalRent.Size = new Size(94, 29);
            btnCancelGlobalRent.TabIndex = 0;
            btnCancelGlobalRent.Text = "Cancel";
            btnCancelGlobalRent.UseVisualStyleBackColor = true;
            // 
            // btnConfirmGlobalRent
            // 
            btnConfirmGlobalRent.Location = new Point(335, 14);
            btnConfirmGlobalRent.Name = "btnConfirmGlobalRent";
            btnConfirmGlobalRent.Size = new Size(135, 29);
            btnConfirmGlobalRent.TabIndex = 1;
            btnConfirmGlobalRent.Text = "Set Global Rent";
            btnConfirmGlobalRent.UseVisualStyleBackColor = true;
            // 
            // lblCurrentRentTitle
            // 
            lblCurrentRentTitle.AutoSize = true;
            lblCurrentRentTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentRentTitle.ForeColor = Color.White;
            lblCurrentRentTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentRentTitle.Location = new Point(31, 21);
            lblCurrentRentTitle.Name = "lblCurrentRentTitle";
            lblCurrentRentTitle.Size = new Size(184, 28);
            lblCurrentRentTitle.TabIndex = 34;
            lblCurrentRentTitle.Text = "Current Global Rent";
            lblCurrentRentTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentRentTitle.Visible = false;
            // 
            // lblNewRentTitle
            // 
            lblNewRentTitle.AutoSize = true;
            lblNewRentTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewRentTitle.ForeColor = Color.White;
            lblNewRentTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblNewRentTitle.Location = new Point(43, 21);
            lblNewRentTitle.Name = "lblNewRentTitle";
            lblNewRentTitle.Size = new Size(158, 28);
            lblNewRentTitle.TabIndex = 35;
            lblNewRentTitle.Text = "New Global Rent";
            lblNewRentTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblNewRentTitle.Visible = false;
            // 
            // lblGlobalRentNotice
            // 
            lblGlobalRentNotice.Dock = DockStyle.Bottom;
            lblGlobalRentNotice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGlobalRentNotice.ForeColor = Color.White;
            lblGlobalRentNotice.ImageAlign = ContentAlignment.MiddleRight;
            lblGlobalRentNotice.Location = new Point(0, 178);
            lblGlobalRentNotice.Name = "lblGlobalRentNotice";
            lblGlobalRentNotice.Size = new Size(482, 65);
            lblGlobalRentNotice.TabIndex = 36;
            lblGlobalRentNotice.Text = "Vacant rooms will use the new rent immediately.\r\nOccupied rooms will use the new rent on the next billing cycle.";
            lblGlobalRentNotice.TextAlign = ContentAlignment.MiddleCenter;
            lblGlobalRentNotice.Visible = false;
            // 
            // lblGlobalRentQuestion
            // 
            lblGlobalRentQuestion.Dock = DockStyle.Top;
            lblGlobalRentQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGlobalRentQuestion.ForeColor = Color.White;
            lblGlobalRentQuestion.ImageAlign = ContentAlignment.MiddleRight;
            lblGlobalRentQuestion.Location = new Point(0, 0);
            lblGlobalRentQuestion.Margin = new Padding(0);
            lblGlobalRentQuestion.Name = "lblGlobalRentQuestion";
            lblGlobalRentQuestion.Size = new Size(482, 50);
            lblGlobalRentQuestion.TabIndex = 38;
            lblGlobalRentQuestion.Text = "Are you sure you want to update the global rent?";
            lblGlobalRentQuestion.TextAlign = ContentAlignment.MiddleCenter;
            lblGlobalRentQuestion.Visible = false;
            // 
            // pnlRentComparison
            // 
            pnlRentComparison.Controls.Add(pnlNewRent);
            pnlRentComparison.Controls.Add(pnlCurrentRent);
            pnlRentComparison.Dock = DockStyle.Fill;
            pnlRentComparison.Location = new Point(0, 50);
            pnlRentComparison.Margin = new Padding(0);
            pnlRentComparison.Name = "pnlRentComparison";
            pnlRentComparison.Size = new Size(482, 128);
            pnlRentComparison.TabIndex = 39;
            // 
            // pnlCurrentRent
            // 
            pnlCurrentRent.Controls.Add(lblCurrentRentValue);
            pnlCurrentRent.Controls.Add(lblCurrentRentTitle);
            pnlCurrentRent.Dock = DockStyle.Left;
            pnlCurrentRent.Location = new Point(0, 0);
            pnlCurrentRent.Margin = new Padding(0);
            pnlCurrentRent.Name = "pnlCurrentRent";
            pnlCurrentRent.Size = new Size(240, 128);
            pnlCurrentRent.TabIndex = 36;
            // 
            // pnlNewRent
            // 
            pnlNewRent.Controls.Add(lblNewRentValue);
            pnlNewRent.Controls.Add(lblNewRentTitle);
            pnlNewRent.Dock = DockStyle.Right;
            pnlNewRent.Location = new Point(242, 0);
            pnlNewRent.Margin = new Padding(0);
            pnlNewRent.Name = "pnlNewRent";
            pnlNewRent.Size = new Size(240, 128);
            pnlNewRent.TabIndex = 37;
            // 
            // lblCurrentRentValue
            // 
            lblCurrentRentValue.AutoSize = true;
            lblCurrentRentValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentRentValue.ForeColor = Color.White;
            lblCurrentRentValue.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentRentValue.Location = new Point(89, 63);
            lblCurrentRentValue.Name = "lblCurrentRentValue";
            lblCurrentRentValue.Size = new Size(61, 28);
            lblCurrentRentValue.TabIndex = 36;
            lblCurrentRentValue.Text = "₱0.00";
            lblCurrentRentValue.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentRentValue.Visible = false;
            // 
            // lblNewRentValue
            // 
            lblNewRentValue.AutoSize = true;
            lblNewRentValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewRentValue.ForeColor = Color.White;
            lblNewRentValue.ImageAlign = ContentAlignment.MiddleRight;
            lblNewRentValue.Location = new Point(88, 63);
            lblNewRentValue.Name = "lblNewRentValue";
            lblNewRentValue.Size = new Size(61, 28);
            lblNewRentValue.TabIndex = 36;
            lblNewRentValue.Text = "₱0.00";
            lblNewRentValue.TextAlign = ContentAlignment.MiddleCenter;
            lblNewRentValue.Visible = false;
            // 
            // SetGlobalRentConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 353);
            Controls.Add(pnlGlobalRentContent);
            Controls.Add(pnlGlobalRentActions);
            Controls.Add(pnlGlobalRentHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetGlobalRentConfirmationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Global Rent";
            pnlGlobalRentHeader.ResumeLayout(false);
            pnlGlobalRentHeader.PerformLayout();
            pnlGlobalRentActions.ResumeLayout(false);
            pnlGlobalRentContent.ResumeLayout(false);
            pnlRentComparison.ResumeLayout(false);
            pnlCurrentRent.ResumeLayout(false);
            pnlCurrentRent.PerformLayout();
            pnlNewRent.ResumeLayout(false);
            pnlNewRent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlGlobalRentHeader;
        private Panel pnlGlobalRentActions;
        private Panel pnlGlobalRentContent;
        private Label lblGlobalRentTitle;
        private Button btnConfirmGlobalRent;
        private Button btnCancelGlobalRent;
        private Label lblGlobalRentNotice;
        private Label lblNewRentTitle;
        private Label lblCurrentRentTitle;
        private Label lblGlobalRentQuestion;
        private Panel pnlRentComparison;
        private Panel pnlCurrentRent;
        private Panel pnlNewRent;
        private Label lblNewRentValue;
        private Label lblCurrentRentValue;
    }
}