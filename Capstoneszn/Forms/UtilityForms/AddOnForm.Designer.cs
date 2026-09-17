namespace Capstoneszn.Forms.UtilityForms
{
    partial class AddOnForm
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
            pnlAddOnHeader = new Panel();
            pnlAddOnActionButtons = new Panel();
            panel3 = new Panel();
            btnAdd = new Button();
            btnCancel = new Button();
            tblAddOn = new TableLayoutPanel();
            pnlUtilityName = new Panel();
            pnlDateRadioButtons = new Panel();
            pnlTenantName = new Panel();
            pnlName = new Panel();
            pnlAmount = new Panel();
            lblUtilityName = new Label();
            txtUtilityName = new TextBox();
            txtAmount = new TextBox();
            txtName = new TextBox();
            lblAddOnTitle = new Label();
            cboTenantName = new ComboBox();
            pnlRadioButtons = new Panel();
            pnlDate = new Panel();
            rbTenant = new RadioButton();
            rbOutsider = new RadioButton();
            dtpDate = new DateTimePicker();
            lblName = new Label();
            lblAmount = new Label();
            lblDate = new Label();
            lblTenantName = new Label();
            pnlAddOnHeader.SuspendLayout();
            pnlAddOnActionButtons.SuspendLayout();
            panel3.SuspendLayout();
            tblAddOn.SuspendLayout();
            pnlUtilityName.SuspendLayout();
            pnlDateRadioButtons.SuspendLayout();
            pnlTenantName.SuspendLayout();
            pnlName.SuspendLayout();
            pnlAmount.SuspendLayout();
            pnlRadioButtons.SuspendLayout();
            pnlDate.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAddOnHeader
            // 
            pnlAddOnHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlAddOnHeader.Controls.Add(lblAddOnTitle);
            pnlAddOnHeader.Dock = DockStyle.Top;
            pnlAddOnHeader.Location = new Point(0, 0);
            pnlAddOnHeader.Name = "pnlAddOnHeader";
            pnlAddOnHeader.Size = new Size(532, 60);
            pnlAddOnHeader.TabIndex = 0;
            // 
            // pnlAddOnActionButtons
            // 
            pnlAddOnActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlAddOnActionButtons.Controls.Add(btnCancel);
            pnlAddOnActionButtons.Controls.Add(btnAdd);
            pnlAddOnActionButtons.Dock = DockStyle.Bottom;
            pnlAddOnActionButtons.Location = new Point(0, 443);
            pnlAddOnActionButtons.Name = "pnlAddOnActionButtons";
            pnlAddOnActionButtons.Size = new Size(532, 60);
            pnlAddOnActionButtons.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(tblAddOn);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 60);
            panel3.Name = "panel3";
            panel3.Size = new Size(532, 383);
            panel3.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Location = new Point(355, 18);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Location = new Point(234, 18);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // tblAddOn
            // 
            tblAddOn.ColumnCount = 1;
            tblAddOn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAddOn.Controls.Add(pnlAmount, 0, 4);
            tblAddOn.Controls.Add(pnlName, 0, 3);
            tblAddOn.Controls.Add(pnlTenantName, 0, 2);
            tblAddOn.Controls.Add(pnlDateRadioButtons, 0, 1);
            tblAddOn.Controls.Add(pnlUtilityName, 0, 0);
            tblAddOn.Dock = DockStyle.Fill;
            tblAddOn.Location = new Point(0, 0);
            tblAddOn.Name = "tblAddOn";
            tblAddOn.RowCount = 5;
            tblAddOn.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblAddOn.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblAddOn.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblAddOn.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblAddOn.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblAddOn.Size = new Size(530, 381);
            tblAddOn.TabIndex = 0;
            // 
            // pnlUtilityName
            // 
            pnlUtilityName.BorderStyle = BorderStyle.FixedSingle;
            pnlUtilityName.Controls.Add(txtUtilityName);
            pnlUtilityName.Controls.Add(lblUtilityName);
            pnlUtilityName.Dock = DockStyle.Fill;
            pnlUtilityName.Location = new Point(3, 3);
            pnlUtilityName.Name = "pnlUtilityName";
            pnlUtilityName.Size = new Size(524, 70);
            pnlUtilityName.TabIndex = 0;
            // 
            // pnlDateRadioButtons
            // 
            pnlDateRadioButtons.Controls.Add(pnlDate);
            pnlDateRadioButtons.Controls.Add(pnlRadioButtons);
            pnlDateRadioButtons.Dock = DockStyle.Fill;
            pnlDateRadioButtons.Location = new Point(3, 79);
            pnlDateRadioButtons.Name = "pnlDateRadioButtons";
            pnlDateRadioButtons.Size = new Size(524, 70);
            pnlDateRadioButtons.TabIndex = 1;
            // 
            // pnlTenantName
            // 
            pnlTenantName.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantName.Controls.Add(lblTenantName);
            pnlTenantName.Controls.Add(cboTenantName);
            pnlTenantName.Dock = DockStyle.Fill;
            pnlTenantName.Location = new Point(3, 155);
            pnlTenantName.Name = "pnlTenantName";
            pnlTenantName.Size = new Size(524, 70);
            pnlTenantName.TabIndex = 2;
            // 
            // pnlName
            // 
            pnlName.BorderStyle = BorderStyle.FixedSingle;
            pnlName.Controls.Add(lblName);
            pnlName.Controls.Add(txtName);
            pnlName.Dock = DockStyle.Fill;
            pnlName.Location = new Point(3, 231);
            pnlName.Name = "pnlName";
            pnlName.Size = new Size(524, 70);
            pnlName.TabIndex = 3;
            // 
            // pnlAmount
            // 
            pnlAmount.BorderStyle = BorderStyle.FixedSingle;
            pnlAmount.Controls.Add(lblAmount);
            pnlAmount.Controls.Add(txtAmount);
            pnlAmount.Dock = DockStyle.Fill;
            pnlAmount.Location = new Point(3, 307);
            pnlAmount.Name = "pnlAmount";
            pnlAmount.Size = new Size(524, 71);
            pnlAmount.TabIndex = 4;
            // 
            // lblUtilityName
            // 
            lblUtilityName.AutoSize = true;
            lblUtilityName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilityName.ForeColor = Color.Transparent;
            lblUtilityName.Location = new Point(0, 0);
            lblUtilityName.Name = "lblUtilityName";
            lblUtilityName.Size = new Size(109, 25);
            lblUtilityName.TabIndex = 0;
            lblUtilityName.Text = "Utility Name";
            // 
            // txtUtilityName
            // 
            txtUtilityName.Location = new Point(138, 12);
            txtUtilityName.Multiline = true;
            txtUtilityName.Name = "txtUtilityName";
            txtUtilityName.Size = new Size(205, 40);
            txtUtilityName.TabIndex = 1;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(138, 16);
            txtAmount.Multiline = true;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(205, 40);
            txtAmount.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(138, 13);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(205, 40);
            txtName.TabIndex = 2;
            // 
            // lblAddOnTitle
            // 
            lblAddOnTitle.Dock = DockStyle.Fill;
            lblAddOnTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddOnTitle.ForeColor = Color.White;
            lblAddOnTitle.Location = new Point(0, 0);
            lblAddOnTitle.Name = "lblAddOnTitle";
            lblAddOnTitle.Size = new Size(530, 58);
            lblAddOnTitle.TabIndex = 7;
            lblAddOnTitle.Text = "Add On Utility";
            lblAddOnTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboTenantName
            // 
            cboTenantName.FormattingEnabled = true;
            cboTenantName.Location = new Point(138, 21);
            cboTenantName.Name = "cboTenantName";
            cboTenantName.Size = new Size(205, 28);
            cboTenantName.TabIndex = 0;
            // 
            // pnlRadioButtons
            // 
            pnlRadioButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlRadioButtons.Controls.Add(rbOutsider);
            pnlRadioButtons.Controls.Add(rbTenant);
            pnlRadioButtons.Dock = DockStyle.Right;
            pnlRadioButtons.Location = new Point(299, 0);
            pnlRadioButtons.Name = "pnlRadioButtons";
            pnlRadioButtons.Padding = new Padding(5);
            pnlRadioButtons.Size = new Size(225, 70);
            pnlRadioButtons.TabIndex = 0;
            // 
            // pnlDate
            // 
            pnlDate.BorderStyle = BorderStyle.FixedSingle;
            pnlDate.Controls.Add(lblDate);
            pnlDate.Controls.Add(dtpDate);
            pnlDate.Dock = DockStyle.Left;
            pnlDate.Location = new Point(0, 0);
            pnlDate.Name = "pnlDate";
            pnlDate.Size = new Size(299, 70);
            pnlDate.TabIndex = 1;
            // 
            // rbTenant
            // 
            rbTenant.AutoSize = true;
            rbTenant.Dock = DockStyle.Left;
            rbTenant.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbTenant.ForeColor = Color.Transparent;
            rbTenant.Location = new Point(5, 5);
            rbTenant.Name = "rbTenant";
            rbTenant.Size = new Size(90, 58);
            rbTenant.TabIndex = 0;
            rbTenant.TabStop = true;
            rbTenant.Text = "Tenant";
            rbTenant.UseVisualStyleBackColor = true;
            // 
            // rbOutsider
            // 
            rbOutsider.AutoSize = true;
            rbOutsider.Dock = DockStyle.Right;
            rbOutsider.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbOutsider.ForeColor = Color.Transparent;
            rbOutsider.Location = new Point(110, 5);
            rbOutsider.Name = "rbOutsider";
            rbOutsider.Size = new Size(108, 58);
            rbOutsider.TabIndex = 1;
            rbOutsider.TabStop = true;
            rbOutsider.Text = "Outsider";
            rbOutsider.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(30, 32);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(242, 27);
            dtpDate.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.Transparent;
            lblName.Location = new Point(3, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 3;
            lblName.Text = "Name";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.Transparent;
            lblAmount.Location = new Point(2, 0);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(77, 25);
            lblAmount.TabIndex = 3;
            lblAmount.Text = "Amount";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.Transparent;
            lblDate.Location = new Point(2, 5);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(49, 25);
            lblDate.TabIndex = 4;
            lblDate.Text = "Date";
            // 
            // lblTenantName
            // 
            lblTenantName.AutoSize = true;
            lblTenantName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantName.ForeColor = Color.Transparent;
            lblTenantName.Location = new Point(0, 0);
            lblTenantName.Name = "lblTenantName";
            lblTenantName.Size = new Size(115, 25);
            lblTenantName.TabIndex = 4;
            lblTenantName.Text = "Tenant Name";
            // 
            // AddOnForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(532, 503);
            Controls.Add(panel3);
            Controls.Add(pnlAddOnActionButtons);
            Controls.Add(pnlAddOnHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddOnForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddOn";
            pnlAddOnHeader.ResumeLayout(false);
            pnlAddOnActionButtons.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tblAddOn.ResumeLayout(false);
            pnlUtilityName.ResumeLayout(false);
            pnlUtilityName.PerformLayout();
            pnlDateRadioButtons.ResumeLayout(false);
            pnlTenantName.ResumeLayout(false);
            pnlTenantName.PerformLayout();
            pnlName.ResumeLayout(false);
            pnlName.PerformLayout();
            pnlAmount.ResumeLayout(false);
            pnlAmount.PerformLayout();
            pnlRadioButtons.ResumeLayout(false);
            pnlRadioButtons.PerformLayout();
            pnlDate.ResumeLayout(false);
            pnlDate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAddOnHeader;
        private Panel pnlAddOnActionButtons;
        private Panel panel3;
        private Button btnAdd;
        private Button btnCancel;
        private TableLayoutPanel tblAddOn;
        private Panel pnlAmount;
        private Panel pnlName;
        private Panel pnlTenantName;
        private Panel pnlDateRadioButtons;
        private Panel pnlUtilityName;
        private Label lblUtilityName;
        private TextBox txtUtilityName;
        private TextBox txtAmount;
        private TextBox txtName;
        private Label lblAddOnTitle;
        private ComboBox cboTenantName;
        private Panel pnlDate;
        private Panel pnlRadioButtons;
        private RadioButton rbOutsider;
        private RadioButton rbTenant;
        private DateTimePicker dtpDate;
        private Label lblAmount;
        private Label lblName;
        private Label lblDate;
        private Label lblTenantName;
    }
}