namespace Capstoneszn.Forms.PaymentsForms
{
    partial class VoidPaymentForm
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
            pnlVoidHeader = new Panel();
            lblVoidTitle = new Label();
            pnlVoidActions = new Panel();
            btnConfirmVoid = new Button();
            btnCancelVoid = new Button();
            pnlVoidContent = new Panel();
            txtVoidReason = new TextBox();
            lblVoidReason = new Label();
            lblVoidImpact = new Label();
            lblVoidDetails = new Label();
            pnlVoidHeader.SuspendLayout();
            pnlVoidActions.SuspendLayout();
            pnlVoidContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlVoidHeader
            // 
            pnlVoidHeader.Controls.Add(lblVoidTitle);
            pnlVoidHeader.Dock = DockStyle.Top;
            pnlVoidHeader.Location = new Point(0, 0);
            pnlVoidHeader.Name = "pnlVoidHeader";
            pnlVoidHeader.Size = new Size(560, 50);
            pnlVoidHeader.TabIndex = 0;
            // 
            // lblVoidTitle
            // 
            lblVoidTitle.Dock = DockStyle.Fill;
            lblVoidTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVoidTitle.ForeColor = Color.Salmon;
            lblVoidTitle.Location = new Point(0, 0);
            lblVoidTitle.Name = "lblVoidTitle";
            lblVoidTitle.Size = new Size(560, 50);
            lblVoidTitle.TabIndex = 0;
            lblVoidTitle.Text = "Void Payment";
            lblVoidTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlVoidActions
            // 
            pnlVoidActions.Controls.Add(btnConfirmVoid);
            pnlVoidActions.Controls.Add(btnCancelVoid);
            pnlVoidActions.Dock = DockStyle.Bottom;
            pnlVoidActions.Location = new Point(0, 455);
            pnlVoidActions.Name = "pnlVoidActions";
            pnlVoidActions.Size = new Size(560, 55);
            pnlVoidActions.TabIndex = 2;
            // 
            // btnConfirmVoid
            // 
            btnConfirmVoid.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirmVoid.Location = new Point(420, 10);
            btnConfirmVoid.Name = "btnConfirmVoid";
            btnConfirmVoid.Size = new Size(125, 35);
            btnConfirmVoid.TabIndex = 1;
            btnConfirmVoid.Text = "Void Payment";
            btnConfirmVoid.UseVisualStyleBackColor = true;
            btnConfirmVoid.Click += btnConfirmVoid_Click;
            // 
            // btnCancelVoid
            // 
            btnCancelVoid.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelVoid.Location = new Point(300, 10);
            btnCancelVoid.Name = "btnCancelVoid";
            btnCancelVoid.Size = new Size(110, 35);
            btnCancelVoid.TabIndex = 0;
            btnCancelVoid.Text = "Cancel";
            btnCancelVoid.UseVisualStyleBackColor = true;
            btnCancelVoid.Click += btnCancelVoid_Click;
            // 
            // pnlVoidContent
            // 
            pnlVoidContent.Controls.Add(txtVoidReason);
            pnlVoidContent.Controls.Add(lblVoidReason);
            pnlVoidContent.Controls.Add(lblVoidImpact);
            pnlVoidContent.Controls.Add(lblVoidDetails);
            pnlVoidContent.Dock = DockStyle.Fill;
            pnlVoidContent.Location = new Point(0, 50);
            pnlVoidContent.Name = "pnlVoidContent";
            pnlVoidContent.Padding = new Padding(15, 5, 15, 5);
            pnlVoidContent.Size = new Size(560, 405);
            pnlVoidContent.TabIndex = 1;
            // 
            // txtVoidReason
            // 
            txtVoidReason.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVoidReason.Location = new Point(15, 320);
            txtVoidReason.MaxLength = 255;
            txtVoidReason.Multiline = true;
            txtVoidReason.Name = "txtVoidReason";
            txtVoidReason.PlaceholderText = "e.g. Wrong amount entered; recorded again as receipt R...";
            txtVoidReason.ScrollBars = ScrollBars.Vertical;
            txtVoidReason.Size = new Size(530, 75);
            txtVoidReason.TabIndex = 0;
            // 
            // lblVoidReason
            // 
            lblVoidReason.AutoSize = true;
            lblVoidReason.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVoidReason.ForeColor = Color.White;
            lblVoidReason.Location = new Point(15, 290);
            lblVoidReason.Name = "lblVoidReason";
            lblVoidReason.Size = new Size(154, 25);
            lblVoidReason.TabIndex = 2;
            lblVoidReason.Text = "Reason (required):";
            // 
            // lblVoidImpact
            // 
            lblVoidImpact.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVoidImpact.ForeColor = Color.Salmon;
            lblVoidImpact.Location = new Point(15, 135);
            lblVoidImpact.Name = "lblVoidImpact";
            lblVoidImpact.Size = new Size(530, 150);
            lblVoidImpact.TabIndex = 1;
            lblVoidImpact.Text = "Impact";
            // 
            // lblVoidDetails
            // 
            lblVoidDetails.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVoidDetails.ForeColor = Color.White;
            lblVoidDetails.Location = new Point(15, 5);
            lblVoidDetails.Name = "lblVoidDetails";
            lblVoidDetails.Size = new Size(530, 125);
            lblVoidDetails.TabIndex = 0;
            lblVoidDetails.Text = "Details";
            // 
            // VoidPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(560, 510);
            Controls.Add(pnlVoidContent);
            Controls.Add(pnlVoidActions);
            Controls.Add(pnlVoidHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VoidPaymentForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Void Payment";
            Load += VoidPaymentForm_Load;
            pnlVoidHeader.ResumeLayout(false);
            pnlVoidActions.ResumeLayout(false);
            pnlVoidContent.ResumeLayout(false);
            pnlVoidContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlVoidHeader;
        private Label lblVoidTitle;
        private Panel pnlVoidActions;
        private Button btnConfirmVoid;
        private Button btnCancelVoid;
        private Panel pnlVoidContent;
        private Label lblVoidDetails;
        private Label lblVoidImpact;
        private Label lblVoidReason;
        private TextBox txtVoidReason;
    }
}