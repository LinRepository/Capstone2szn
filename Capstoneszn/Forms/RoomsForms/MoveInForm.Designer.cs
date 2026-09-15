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
            lblMoveInDescription = new Label();
            lblMoveInTitle = new Label();
            pnlMoveInActions = new Panel();
            btnConfirmMoveIn = new Button();
            btnCancelMoveIn = new Button();
            pnlMoveInContent = new Panel();
            dtpMoveInDate = new DateTimePicker();
            txtContactNumber = new TextBox();
            txtTenantName = new TextBox();
            lblMoveInDate = new Label();
            lblContactNumber = new Label();
            lblTenantName = new Label();
            pnlMoveInHeader.SuspendLayout();
            pnlMoveInActions.SuspendLayout();
            pnlMoveInContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMoveInHeader
            // 
            pnlMoveInHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlMoveInHeader.Controls.Add(lblMoveInDescription);
            pnlMoveInHeader.Controls.Add(lblMoveInTitle);
            pnlMoveInHeader.Dock = DockStyle.Top;
            pnlMoveInHeader.Location = new Point(0, 0);
            pnlMoveInHeader.Margin = new Padding(0);
            pnlMoveInHeader.Name = "pnlMoveInHeader";
            pnlMoveInHeader.Size = new Size(582, 75);
            pnlMoveInHeader.TabIndex = 0;
            // 
            // lblMoveInDescription
            // 
            lblMoveInDescription.Dock = DockStyle.Bottom;
            lblMoveInDescription.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveInDescription.ForeColor = Color.White;
            lblMoveInDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveInDescription.Location = new Point(0, 37);
            lblMoveInDescription.Margin = new Padding(0);
            lblMoveInDescription.Name = "lblMoveInDescription";
            lblMoveInDescription.Size = new Size(580, 36);
            lblMoveInDescription.TabIndex = 26;
            lblMoveInDescription.Text = "Enter the tenant information below";
            lblMoveInDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMoveInTitle
            // 
            lblMoveInTitle.Dock = DockStyle.Top;
            lblMoveInTitle.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveInTitle.ForeColor = Color.White;
            lblMoveInTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveInTitle.Location = new Point(0, 0);
            lblMoveInTitle.Margin = new Padding(0);
            lblMoveInTitle.Name = "lblMoveInTitle";
            lblMoveInTitle.Size = new Size(580, 36);
            lblMoveInTitle.TabIndex = 25;
            lblMoveInTitle.Text = "Add New Tenant";
            lblMoveInTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMoveInActions
            // 
            pnlMoveInActions.BorderStyle = BorderStyle.FixedSingle;
            pnlMoveInActions.Controls.Add(btnConfirmMoveIn);
            pnlMoveInActions.Controls.Add(btnCancelMoveIn);
            pnlMoveInActions.Dock = DockStyle.Bottom;
            pnlMoveInActions.Location = new Point(0, 388);
            pnlMoveInActions.Margin = new Padding(0);
            pnlMoveInActions.Name = "pnlMoveInActions";
            pnlMoveInActions.Size = new Size(582, 65);
            pnlMoveInActions.TabIndex = 1;
            // 
            // btnConfirmMoveIn
            // 
            btnConfirmMoveIn.Cursor = Cursors.Hand;
            btnConfirmMoveIn.Location = new Point(453, 17);
            btnConfirmMoveIn.Name = "btnConfirmMoveIn";
            btnConfirmMoveIn.Size = new Size(94, 29);
            btnConfirmMoveIn.TabIndex = 1;
            btnConfirmMoveIn.Text = "Confirm";
            btnConfirmMoveIn.UseVisualStyleBackColor = true;
            // 
            // btnCancelMoveIn
            // 
            btnCancelMoveIn.Cursor = Cursors.Hand;
            btnCancelMoveIn.Location = new Point(336, 17);
            btnCancelMoveIn.Name = "btnCancelMoveIn";
            btnCancelMoveIn.Size = new Size(94, 29);
            btnCancelMoveIn.TabIndex = 0;
            btnCancelMoveIn.Text = "Cancel";
            btnCancelMoveIn.UseVisualStyleBackColor = true;
            btnCancelMoveIn.Click += btnCancelMoveIn_Click;
            // 
            // pnlMoveInContent
            // 
            pnlMoveInContent.BorderStyle = BorderStyle.FixedSingle;
            pnlMoveInContent.Controls.Add(dtpMoveInDate);
            pnlMoveInContent.Controls.Add(txtContactNumber);
            pnlMoveInContent.Controls.Add(txtTenantName);
            pnlMoveInContent.Controls.Add(lblMoveInDate);
            pnlMoveInContent.Controls.Add(lblContactNumber);
            pnlMoveInContent.Controls.Add(lblTenantName);
            pnlMoveInContent.Dock = DockStyle.Fill;
            pnlMoveInContent.Location = new Point(0, 75);
            pnlMoveInContent.Name = "pnlMoveInContent";
            pnlMoveInContent.Size = new Size(582, 313);
            pnlMoveInContent.TabIndex = 2;
            // 
            // dtpMoveInDate
            // 
            dtpMoveInDate.Cursor = Cursors.Hand;
            dtpMoveInDate.Format = DateTimePickerFormat.Short;
            dtpMoveInDate.Location = new Point(92, 242);
            dtpMoveInDate.Name = "dtpMoveInDate";
            dtpMoveInDate.Size = new Size(377, 27);
            dtpMoveInDate.TabIndex = 31;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Cursor = Cursors.IBeam;
            txtContactNumber.Location = new Point(92, 158);
            txtContactNumber.Multiline = true;
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(377, 40);
            txtContactNumber.TabIndex = 30;
            // 
            // txtTenantName
            // 
            txtTenantName.Cursor = Cursors.IBeam;
            txtTenantName.Location = new Point(92, 71);
            txtTenantName.Multiline = true;
            txtTenantName.Name = "txtTenantName";
            txtTenantName.Size = new Size(377, 40);
            txtTenantName.TabIndex = 29;
            // 
            // lblMoveInDate
            // 
            lblMoveInDate.AutoSize = true;
            lblMoveInDate.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveInDate.ForeColor = Color.White;
            lblMoveInDate.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveInDate.Location = new Point(92, 208);
            lblMoveInDate.Margin = new Padding(0);
            lblMoveInDate.Name = "lblMoveInDate";
            lblMoveInDate.Size = new Size(62, 31);
            lblMoveInDate.TabIndex = 28;
            lblMoveInDate.Text = "Date";
            lblMoveInDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblContactNumber
            // 
            lblContactNumber.AutoSize = true;
            lblContactNumber.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNumber.ForeColor = Color.White;
            lblContactNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblContactNumber.Location = new Point(92, 124);
            lblContactNumber.Margin = new Padding(0);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(183, 31);
            lblContactNumber.TabIndex = 27;
            lblContactNumber.Text = "Contact Number";
            lblContactNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenantName
            // 
            lblTenantName.AutoSize = true;
            lblTenantName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantName.ForeColor = Color.White;
            lblTenantName.ImageAlign = ContentAlignment.MiddleRight;
            lblTenantName.Location = new Point(92, 37);
            lblTenantName.Margin = new Padding(0);
            lblTenantName.Name = "lblTenantName";
            lblTenantName.Size = new Size(149, 31);
            lblTenantName.TabIndex = 26;
            lblTenantName.Text = "Tenant Name";
            lblTenantName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MoveInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(582, 453);
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