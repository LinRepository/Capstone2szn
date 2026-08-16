namespace Capstoneszn.UserControls
{
    partial class MoveInForm
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
            pnlMoveInHeader = new Panel();
            lblMoveInTitle = new Label();
            lblMoveInDescription = new Label();
            pnlMoveInActions = new Panel();
            pnlMoveInContent = new Panel();
            btnCancelMoveIn = new Button();
            btnConfirmMoveIn = new Button();
            lblTenantName = new Label();
            lblContactNumber = new Label();
            lblMoveInDate = new Label();
            txtTenantName = new TextBox();
            txtContactNumber = new TextBox();
            dtpMoveInDate = new DateTimePicker();
            pnlMoveInHeader.SuspendLayout();
            pnlMoveInActions.SuspendLayout();
            pnlMoveInContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMoveInHeader
            // 
            pnlMoveInHeader.Controls.Add(lblMoveInDescription);
            pnlMoveInHeader.Controls.Add(lblMoveInTitle);
            pnlMoveInHeader.Dock = DockStyle.Top;
            pnlMoveInHeader.Location = new Point(0, 0);
            pnlMoveInHeader.Margin = new Padding(0);
            pnlMoveInHeader.Name = "pnlMoveInHeader";
            pnlMoveInHeader.Size = new Size(782, 65);
            pnlMoveInHeader.TabIndex = 0;
            // 
            // lblMoveInTitle
            // 
            lblMoveInTitle.AutoSize = true;
            lblMoveInTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveInTitle.ForeColor = Color.White;
            lblMoveInTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveInTitle.Location = new Point(324, 9);
            lblMoveInTitle.Margin = new Padding(0);
            lblMoveInTitle.Name = "lblMoveInTitle";
            lblMoveInTitle.Size = new Size(142, 25);
            lblMoveInTitle.TabIndex = 25;
            lblMoveInTitle.Text = "Add New Tenant";
            lblMoveInTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMoveInDescription
            // 
            lblMoveInDescription.AutoSize = true;
            lblMoveInDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveInDescription.ForeColor = Color.White;
            lblMoveInDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveInDescription.Location = new Point(259, 34);
            lblMoveInDescription.Margin = new Padding(0);
            lblMoveInDescription.Name = "lblMoveInDescription";
            lblMoveInDescription.Size = new Size(288, 25);
            lblMoveInDescription.TabIndex = 26;
            lblMoveInDescription.Text = "Enter the tenant information below";
            lblMoveInDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMoveInActions
            // 
            pnlMoveInActions.Controls.Add(btnConfirmMoveIn);
            pnlMoveInActions.Controls.Add(btnCancelMoveIn);
            pnlMoveInActions.Dock = DockStyle.Bottom;
            pnlMoveInActions.Location = new Point(0, 388);
            pnlMoveInActions.Margin = new Padding(0);
            pnlMoveInActions.Name = "pnlMoveInActions";
            pnlMoveInActions.Size = new Size(782, 65);
            pnlMoveInActions.TabIndex = 1;
            // 
            // pnlMoveInContent
            // 
            pnlMoveInContent.Controls.Add(dtpMoveInDate);
            pnlMoveInContent.Controls.Add(txtContactNumber);
            pnlMoveInContent.Controls.Add(txtTenantName);
            pnlMoveInContent.Controls.Add(lblMoveInDate);
            pnlMoveInContent.Controls.Add(lblContactNumber);
            pnlMoveInContent.Controls.Add(lblTenantName);
            pnlMoveInContent.Dock = DockStyle.Fill;
            pnlMoveInContent.Location = new Point(0, 65);
            pnlMoveInContent.Name = "pnlMoveInContent";
            pnlMoveInContent.Size = new Size(782, 323);
            pnlMoveInContent.TabIndex = 2;
            // 
            // btnCancelMoveIn
            // 
            btnCancelMoveIn.Location = new Point(503, 24);
            btnCancelMoveIn.Name = "btnCancelMoveIn";
            btnCancelMoveIn.Size = new Size(94, 29);
            btnCancelMoveIn.TabIndex = 0;
            btnCancelMoveIn.Text = "Cancel";
            btnCancelMoveIn.UseVisualStyleBackColor = true;
            // 
            // btnConfirmMoveIn
            // 
            btnConfirmMoveIn.Location = new Point(634, 24);
            btnConfirmMoveIn.Name = "btnConfirmMoveIn";
            btnConfirmMoveIn.Size = new Size(94, 29);
            btnConfirmMoveIn.TabIndex = 1;
            btnConfirmMoveIn.Text = "Confirm";
            btnConfirmMoveIn.UseVisualStyleBackColor = true;
            // 
            // lblTenantName
            // 
            lblTenantName.AutoSize = true;
            lblTenantName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantName.ForeColor = Color.White;
            lblTenantName.ImageAlign = ContentAlignment.MiddleRight;
            lblTenantName.Location = new Point(74, 40);
            lblTenantName.Margin = new Padding(0);
            lblTenantName.Name = "lblTenantName";
            lblTenantName.Size = new Size(115, 25);
            lblTenantName.TabIndex = 26;
            lblTenantName.Text = "Tenant Name";
            lblTenantName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblContactNumber
            // 
            lblContactNumber.AutoSize = true;
            lblContactNumber.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNumber.ForeColor = Color.White;
            lblContactNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblContactNumber.Location = new Point(74, 103);
            lblContactNumber.Margin = new Padding(0);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(143, 25);
            lblContactNumber.TabIndex = 27;
            lblContactNumber.Text = "Contact Number";
            lblContactNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMoveInDate
            // 
            lblMoveInDate.AutoSize = true;
            lblMoveInDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveInDate.ForeColor = Color.White;
            lblMoveInDate.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveInDate.Location = new Point(74, 163);
            lblMoveInDate.Margin = new Padding(0);
            lblMoveInDate.Name = "lblMoveInDate";
            lblMoveInDate.Size = new Size(49, 25);
            lblMoveInDate.TabIndex = 28;
            lblMoveInDate.Text = "Date";
            lblMoveInDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTenantName
            // 
            txtTenantName.Location = new Point(92, 68);
            txtTenantName.Name = "txtTenantName";
            txtTenantName.Size = new Size(125, 27);
            txtTenantName.TabIndex = 29;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(92, 131);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(125, 27);
            txtContactNumber.TabIndex = 30;
            // 
            // dtpMoveInDate
            // 
            dtpMoveInDate.Format = DateTimePickerFormat.Short;
            dtpMoveInDate.Location = new Point(92, 215);
            dtpMoveInDate.Name = "dtpMoveInDate";
            dtpMoveInDate.Size = new Size(250, 27);
            dtpMoveInDate.TabIndex = 31;
            // 
            // MoveInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(782, 453);
            Controls.Add(pnlMoveInContent);
            Controls.Add(pnlMoveInActions);
            Controls.Add(pnlMoveInHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveInForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Move In Tenant";
            pnlMoveInHeader.ResumeLayout(false);
            pnlMoveInHeader.PerformLayout();
            pnlMoveInActions.ResumeLayout(false);
            pnlMoveInContent.ResumeLayout(false);
            pnlMoveInContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMoveInHeader;
        private Label lblMoveInDescription;
        private Label lblMoveInTitle;
        private Panel pnlMoveInActions;
        private Button btnConfirmMoveIn;
        private Button btnCancelMoveIn;
        private Panel pnlMoveInContent;
        private Label lblMoveInDate;
        private Label lblContactNumber;
        private Label lblTenantName;
        private DateTimePicker dtpMoveInDate;
        private TextBox txtContactNumber;
        private TextBox txtTenantName;
    }
}