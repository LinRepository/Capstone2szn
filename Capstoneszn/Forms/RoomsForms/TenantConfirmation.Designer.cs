namespace Capstoneszn.Forms.RoomsForms
{
    partial class TenantConfirmation
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
            pnlTenantConfirmationContent = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblFName = new Label();
            lblMName = new Label();
            lblLName = new Label();
            lblAddress = new Label();
            lblContactNumber = new Label();
            lblDate = new Label();
            lblFNameValue = new Label();
            lblMNameValue = new Label();
            lblLNameValue = new Label();
            lblAddressValue = new Label();
            lblContactNumberValue = new Label();
            dtpDateValue = new DateTimePicker();
            pnlTenantConfirmationContent.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTenantConfirmationContent
            // 
            pnlTenantConfirmationContent.Controls.Add(tableLayoutPanel1);
            pnlTenantConfirmationContent.Dock = DockStyle.Fill;
            pnlTenantConfirmationContent.Location = new Point(0, 0);
            pnlTenantConfirmationContent.Name = "pnlTenantConfirmationContent";
            pnlTenantConfirmationContent.Size = new Size(580, 350);
            pnlTenantConfirmationContent.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblContactNumberValue, 1, 4);
            tableLayoutPanel1.Controls.Add(lblAddressValue, 1, 3);
            tableLayoutPanel1.Controls.Add(lblLNameValue, 1, 2);
            tableLayoutPanel1.Controls.Add(lblMNameValue, 1, 1);
            tableLayoutPanel1.Controls.Add(lblFNameValue, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDate, 0, 5);
            tableLayoutPanel1.Controls.Add(lblContactNumber, 0, 4);
            tableLayoutPanel1.Controls.Add(lblAddress, 0, 3);
            tableLayoutPanel1.Controls.Add(lblLName, 0, 2);
            tableLayoutPanel1.Controls.Add(lblMName, 0, 1);
            tableLayoutPanel1.Controls.Add(lblFName, 0, 0);
            tableLayoutPanel1.Controls.Add(dtpDateValue, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Size = new Size(580, 350);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblFName
            // 
            lblFName.Dock = DockStyle.Left;
            lblFName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFName.ForeColor = Color.White;
            lblFName.ImageAlign = ContentAlignment.MiddleRight;
            lblFName.Location = new Point(0, 0);
            lblFName.Margin = new Padding(0);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(200, 58);
            lblFName.TabIndex = 32;
            lblFName.Text = "First Name";
            lblFName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMName
            // 
            lblMName.Dock = DockStyle.Left;
            lblMName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMName.ForeColor = Color.White;
            lblMName.ImageAlign = ContentAlignment.MiddleRight;
            lblMName.Location = new Point(0, 58);
            lblMName.Margin = new Padding(0);
            lblMName.Name = "lblMName";
            lblMName.Size = new Size(200, 58);
            lblMName.TabIndex = 34;
            lblMName.Text = "Middle Name";
            lblMName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLName
            // 
            lblLName.Dock = DockStyle.Left;
            lblLName.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLName.ForeColor = Color.White;
            lblLName.ImageAlign = ContentAlignment.MiddleRight;
            lblLName.Location = new Point(0, 116);
            lblLName.Margin = new Padding(0);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(200, 58);
            lblLName.TabIndex = 36;
            lblLName.Text = "Last Name";
            lblLName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAddress
            // 
            lblAddress.Dock = DockStyle.Left;
            lblAddress.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.White;
            lblAddress.ImageAlign = ContentAlignment.MiddleRight;
            lblAddress.Location = new Point(0, 174);
            lblAddress.Margin = new Padding(0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(200, 58);
            lblAddress.TabIndex = 38;
            lblAddress.Text = "Address";
            lblAddress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblContactNumber
            // 
            lblContactNumber.Dock = DockStyle.Left;
            lblContactNumber.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNumber.ForeColor = Color.White;
            lblContactNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblContactNumber.Location = new Point(0, 232);
            lblContactNumber.Margin = new Padding(0);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(200, 58);
            lblContactNumber.TabIndex = 40;
            lblContactNumber.Text = "Contact Number";
            lblContactNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            lblDate.Dock = DockStyle.Left;
            lblDate.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.White;
            lblDate.ImageAlign = ContentAlignment.MiddleRight;
            lblDate.Location = new Point(0, 290);
            lblDate.Margin = new Padding(0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(200, 60);
            lblDate.TabIndex = 42;
            lblDate.Text = "Date";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFNameValue
            // 
            lblFNameValue.Dock = DockStyle.Left;
            lblFNameValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFNameValue.ForeColor = Color.White;
            lblFNameValue.ImageAlign = ContentAlignment.MiddleRight;
            lblFNameValue.Location = new Point(290, 0);
            lblFNameValue.Margin = new Padding(0);
            lblFNameValue.Name = "lblFNameValue";
            lblFNameValue.Size = new Size(270, 58);
            lblFNameValue.TabIndex = 43;
            lblFNameValue.Text = "-";
            lblFNameValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMNameValue
            // 
            lblMNameValue.Dock = DockStyle.Left;
            lblMNameValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMNameValue.ForeColor = Color.White;
            lblMNameValue.ImageAlign = ContentAlignment.MiddleRight;
            lblMNameValue.Location = new Point(290, 58);
            lblMNameValue.Margin = new Padding(0);
            lblMNameValue.Name = "lblMNameValue";
            lblMNameValue.Size = new Size(270, 58);
            lblMNameValue.TabIndex = 44;
            lblMNameValue.Text = "-";
            lblMNameValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLNameValue
            // 
            lblLNameValue.Dock = DockStyle.Left;
            lblLNameValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLNameValue.ForeColor = Color.White;
            lblLNameValue.ImageAlign = ContentAlignment.MiddleRight;
            lblLNameValue.Location = new Point(290, 116);
            lblLNameValue.Margin = new Padding(0);
            lblLNameValue.Name = "lblLNameValue";
            lblLNameValue.Size = new Size(270, 58);
            lblLNameValue.TabIndex = 45;
            lblLNameValue.Text = "-";
            lblLNameValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAddressValue
            // 
            lblAddressValue.Dock = DockStyle.Left;
            lblAddressValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddressValue.ForeColor = Color.White;
            lblAddressValue.ImageAlign = ContentAlignment.MiddleRight;
            lblAddressValue.Location = new Point(290, 174);
            lblAddressValue.Margin = new Padding(0);
            lblAddressValue.Name = "lblAddressValue";
            lblAddressValue.Size = new Size(270, 58);
            lblAddressValue.TabIndex = 46;
            lblAddressValue.Text = "-";
            lblAddressValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblContactNumberValue
            // 
            lblContactNumberValue.Dock = DockStyle.Left;
            lblContactNumberValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContactNumberValue.ForeColor = Color.White;
            lblContactNumberValue.ImageAlign = ContentAlignment.MiddleRight;
            lblContactNumberValue.Location = new Point(290, 232);
            lblContactNumberValue.Margin = new Padding(0);
            lblContactNumberValue.Name = "lblContactNumberValue";
            lblContactNumberValue.Size = new Size(270, 58);
            lblContactNumberValue.TabIndex = 47;
            lblContactNumberValue.Text = "-";
            lblContactNumberValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpDateValue
            // 
            dtpDateValue.Location = new Point(293, 293);
            dtpDateValue.Name = "dtpDateValue";
            dtpDateValue.Size = new Size(267, 27);
            dtpDateValue.TabIndex = 48;
            // 
            // TenantConfirmation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlTenantConfirmationContent);
            Name = "TenantConfirmation";
            Size = new Size(580, 350);
            pnlTenantConfirmationContent.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTenantConfirmationContent;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblDate;
        private Label lblContactNumber;
        private Label lblAddress;
        private Label lblLName;
        private Label lblMName;
        private Label lblFName;
        private Label lblFNameValue;
        private Label lblContactNumberValue;
        private Label lblAddressValue;
        private Label lblLNameValue;
        private Label lblMNameValue;
        private DateTimePicker dtpDateValue;
    }
}
