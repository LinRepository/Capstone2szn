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
            btnClear = new Button();
            btnConfirmMoveIn = new Button();
            btnCancelMoveIn = new Button();
            pnlMoveInContent = new Panel();
            pnlDate = new Panel();
            dtpMoveInDate = new DateTimePicker();
            lblMoveInDate = new Label();
            pnlContactNumber = new Panel();
            lblContactNumber = new Label();
            txtContactNumber = new TextBox();
            pnlAddress = new Panel();
            lblAddress = new Label();
            txtAddress = new TextBox();
            pnlLName = new Panel();
            lblLName = new Label();
            txtLName = new TextBox();
            pnlMName = new Panel();
            lblMName = new Label();
            txtMName = new TextBox();
            pnlFName = new Panel();
            lblFName = new Label();
            txtFName = new TextBox();
            pnlMoveInHeader.SuspendLayout();
            pnlMoveInActions.SuspendLayout();
            pnlMoveInContent.SuspendLayout();
            pnlDate.SuspendLayout();
            pnlContactNumber.SuspendLayout();
            pnlAddress.SuspendLayout();
            pnlLName.SuspendLayout();
            pnlMName.SuspendLayout();
            pnlFName.SuspendLayout();
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
            pnlMoveInActions.Controls.Add(btnClear);
            pnlMoveInActions.Controls.Add(btnConfirmMoveIn);
            pnlMoveInActions.Controls.Add(btnCancelMoveIn);
            pnlMoveInActions.Dock = DockStyle.Bottom;
            pnlMoveInActions.Location = new Point(0, 433);
            pnlMoveInActions.Margin = new Padding(0);
            pnlMoveInActions.Name = "pnlMoveInActions";
            pnlMoveInActions.Size = new Size(582, 50);
            pnlMoveInActions.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(21, 10);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnConfirmMoveIn
            // 
            btnConfirmMoveIn.Cursor = Cursors.Hand;
            btnConfirmMoveIn.Location = new Point(465, 10);
            btnConfirmMoveIn.Name = "btnConfirmMoveIn";
            btnConfirmMoveIn.Size = new Size(94, 29);
            btnConfirmMoveIn.TabIndex = 1;
            btnConfirmMoveIn.Text = "Confirm";
            btnConfirmMoveIn.UseVisualStyleBackColor = true;
            btnConfirmMoveIn.Click += btnConfirmMoveIn_Click;
            // 
            // btnCancelMoveIn
            // 
            btnCancelMoveIn.Cursor = Cursors.Hand;
            btnCancelMoveIn.Location = new Point(350, 10);
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
            pnlMoveInContent.Controls.Add(pnlDate);
            pnlMoveInContent.Controls.Add(pnlContactNumber);
            pnlMoveInContent.Controls.Add(pnlAddress);
            pnlMoveInContent.Controls.Add(pnlLName);
            pnlMoveInContent.Controls.Add(pnlMName);
            pnlMoveInContent.Controls.Add(pnlFName);
            pnlMoveInContent.Dock = DockStyle.Fill;
            pnlMoveInContent.Location = new Point(0, 75);
            pnlMoveInContent.Name = "pnlMoveInContent";
            pnlMoveInContent.Size = new Size(582, 358);
            pnlMoveInContent.TabIndex = 2;
            // 
            // pnlDate
            // 
            pnlDate.BorderStyle = BorderStyle.FixedSingle;
            pnlDate.Controls.Add(dtpMoveInDate);
            pnlDate.Controls.Add(lblMoveInDate);
            pnlDate.Dock = DockStyle.Fill;
            pnlDate.Location = new Point(0, 300);
            pnlDate.Name = "pnlDate";
            pnlDate.Size = new Size(580, 56);
            pnlDate.TabIndex = 48;
            // 
            // dtpMoveInDate
            // 
            dtpMoveInDate.Cursor = Cursors.Hand;
            dtpMoveInDate.Location = new Point(267, 15);
            dtpMoveInDate.Name = "dtpMoveInDate";
            dtpMoveInDate.Size = new Size(259, 27);
            dtpMoveInDate.TabIndex = 31;
            // 
            // lblMoveInDate
            // 
            lblMoveInDate.Dock = DockStyle.Left;
            lblMoveInDate.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveInDate.ForeColor = Color.White;
            lblMoveInDate.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveInDate.Location = new Point(0, 0);
            lblMoveInDate.Margin = new Padding(0);
            lblMoveInDate.Name = "lblMoveInDate";
            lblMoveInDate.Size = new Size(210, 54);
            lblMoveInDate.TabIndex = 28;
            lblMoveInDate.Text = "Date";
            lblMoveInDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContactNumber
            // 
            pnlContactNumber.BorderStyle = BorderStyle.FixedSingle;
            pnlContactNumber.Controls.Add(lblContactNumber);
            pnlContactNumber.Controls.Add(txtContactNumber);
            pnlContactNumber.Dock = DockStyle.Top;
            pnlContactNumber.Location = new Point(0, 240);
            pnlContactNumber.Name = "pnlContactNumber";
            pnlContactNumber.Padding = new Padding(10);
            pnlContactNumber.Size = new Size(580, 60);
            pnlContactNumber.TabIndex = 47;
            // 
            // lblContactNumber
            // 
            lblContactNumber.Dock = DockStyle.Left;
            lblContactNumber.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNumber.ForeColor = Color.White;
            lblContactNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblContactNumber.Location = new Point(10, 10);
            lblContactNumber.Margin = new Padding(0);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(200, 38);
            lblContactNumber.TabIndex = 32;
            lblContactNumber.Text = "Contact Number";
            lblContactNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Cursor = Cursors.IBeam;
            txtContactNumber.Dock = DockStyle.Right;
            txtContactNumber.Location = new Point(213, 10);
            txtContactNumber.Multiline = true;
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(355, 38);
            txtContactNumber.TabIndex = 31;
            // 
            // pnlAddress
            // 
            pnlAddress.BorderStyle = BorderStyle.FixedSingle;
            pnlAddress.Controls.Add(lblAddress);
            pnlAddress.Controls.Add(txtAddress);
            pnlAddress.Dock = DockStyle.Top;
            pnlAddress.Location = new Point(0, 180);
            pnlAddress.Name = "pnlAddress";
            pnlAddress.Padding = new Padding(10);
            pnlAddress.Size = new Size(580, 60);
            pnlAddress.TabIndex = 45;
            // 
            // lblAddress
            // 
            lblAddress.Dock = DockStyle.Left;
            lblAddress.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.White;
            lblAddress.ImageAlign = ContentAlignment.MiddleRight;
            lblAddress.Location = new Point(10, 10);
            lblAddress.Margin = new Padding(0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(200, 38);
            lblAddress.TabIndex = 39;
            lblAddress.Text = "Address";
            lblAddress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAddress
            // 
            txtAddress.Cursor = Cursors.IBeam;
            txtAddress.Dock = DockStyle.Right;
            txtAddress.Location = new Point(213, 10);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(355, 38);
            txtAddress.TabIndex = 38;
            // 
            // pnlLName
            // 
            pnlLName.BorderStyle = BorderStyle.FixedSingle;
            pnlLName.Controls.Add(lblLName);
            pnlLName.Controls.Add(txtLName);
            pnlLName.Dock = DockStyle.Top;
            pnlLName.Location = new Point(0, 120);
            pnlLName.Name = "pnlLName";
            pnlLName.Padding = new Padding(10);
            pnlLName.Size = new Size(580, 60);
            pnlLName.TabIndex = 43;
            // 
            // lblLName
            // 
            lblLName.Dock = DockStyle.Left;
            lblLName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLName.ForeColor = Color.White;
            lblLName.ImageAlign = ContentAlignment.MiddleRight;
            lblLName.Location = new Point(10, 10);
            lblLName.Margin = new Padding(0);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(200, 38);
            lblLName.TabIndex = 38;
            lblLName.Text = "Last Name";
            lblLName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtLName
            // 
            txtLName.Cursor = Cursors.IBeam;
            txtLName.Dock = DockStyle.Right;
            txtLName.Location = new Point(213, 10);
            txtLName.Multiline = true;
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(355, 38);
            txtLName.TabIndex = 37;
            // 
            // pnlMName
            // 
            pnlMName.BorderStyle = BorderStyle.FixedSingle;
            pnlMName.Controls.Add(lblMName);
            pnlMName.Controls.Add(txtMName);
            pnlMName.Dock = DockStyle.Top;
            pnlMName.Location = new Point(0, 60);
            pnlMName.Name = "pnlMName";
            pnlMName.Padding = new Padding(10);
            pnlMName.Size = new Size(580, 60);
            pnlMName.TabIndex = 41;
            // 
            // lblMName
            // 
            lblMName.Dock = DockStyle.Left;
            lblMName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMName.ForeColor = Color.White;
            lblMName.ImageAlign = ContentAlignment.MiddleRight;
            lblMName.Location = new Point(10, 10);
            lblMName.Margin = new Padding(0);
            lblMName.Name = "lblMName";
            lblMName.Size = new Size(200, 38);
            lblMName.TabIndex = 37;
            lblMName.Text = "Middle Name";
            lblMName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMName
            // 
            txtMName.Cursor = Cursors.IBeam;
            txtMName.Dock = DockStyle.Right;
            txtMName.Location = new Point(213, 10);
            txtMName.Multiline = true;
            txtMName.Name = "txtMName";
            txtMName.Size = new Size(355, 38);
            txtMName.TabIndex = 36;
            // 
            // pnlFName
            // 
            pnlFName.BorderStyle = BorderStyle.FixedSingle;
            pnlFName.Controls.Add(lblFName);
            pnlFName.Controls.Add(txtFName);
            pnlFName.Dock = DockStyle.Top;
            pnlFName.Location = new Point(0, 0);
            pnlFName.Name = "pnlFName";
            pnlFName.Padding = new Padding(10);
            pnlFName.Size = new Size(580, 60);
            pnlFName.TabIndex = 39;
            // 
            // lblFName
            // 
            lblFName.Dock = DockStyle.Left;
            lblFName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFName.ForeColor = Color.White;
            lblFName.ImageAlign = ContentAlignment.MiddleRight;
            lblFName.Location = new Point(10, 10);
            lblFName.Margin = new Padding(0);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(200, 38);
            lblFName.TabIndex = 31;
            lblFName.Text = "First Name";
            lblFName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtFName
            // 
            txtFName.Cursor = Cursors.IBeam;
            txtFName.Dock = DockStyle.Right;
            txtFName.Location = new Point(213, 10);
            txtFName.Multiline = true;
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(355, 38);
            txtFName.TabIndex = 30;
            // 
            // MoveInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(582, 483);
            Controls.Add(pnlMoveInContent);
            Controls.Add(pnlMoveInActions);
            Controls.Add(pnlMoveInHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveInForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Move In Tenant";
            Load += MoveInForm_Load;
            pnlMoveInHeader.ResumeLayout(false);
            pnlMoveInActions.ResumeLayout(false);
            pnlMoveInContent.ResumeLayout(false);
            pnlDate.ResumeLayout(false);
            pnlContactNumber.ResumeLayout(false);
            pnlContactNumber.PerformLayout();
            pnlAddress.ResumeLayout(false);
            pnlAddress.PerformLayout();
            pnlLName.ResumeLayout(false);
            pnlLName.PerformLayout();
            pnlMName.ResumeLayout(false);
            pnlMName.PerformLayout();
            pnlFName.ResumeLayout(false);
            pnlFName.PerformLayout();
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
        private DateTimePicker dtpMoveInDate;
        private Panel pnlLName;
        private Panel pnlMName;
        private Panel pnlFName;
        private TextBox txtLName;
        private TextBox txtMName;
        private TextBox txtFName;
        private Panel pnlAddress;
        private TextBox txtAddress;
        private Panel pnlDate;
        private Panel pnlContactNumber;
        private TextBox txtContactNumber;
        private Label lblFName;
        private Label lblMName;
        private Label lblContactNumber;
        private Label lblAddress;
        private Label lblLName;
        private Button btnClear;
    }
}