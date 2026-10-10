namespace Capstoneszn.Forms.UtilityForms
{
    partial class AddOtherForm
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
            pnlOtherHeader = new Panel();
            lblAddOtherBillTitle = new Label();
            pnlOtherActionButton = new Panel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlOtherContent = new Panel();
            txtAmount = new TextBox();
            cboName = new ComboBox();
            txtName = new TextBox();
            panel1 = new Panel();
            radiobtnOutsider = new RadioButton();
            radiobtnTenant = new RadioButton();
            dtpDate = new DateTimePicker();
            txtUtilityName = new TextBox();
            lblAmount = new Label();
            lblName = new Label();
            lblDate = new Label();
            lblUtilityName = new Label();
            pnlOtherHeader.SuspendLayout();
            pnlOtherActionButton.SuspendLayout();
            pnlOtherContent.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlOtherHeader
            // 
            pnlOtherHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlOtherHeader.Controls.Add(lblAddOtherBillTitle);
            pnlOtherHeader.Dock = DockStyle.Top;
            pnlOtherHeader.Location = new Point(0, 0);
            pnlOtherHeader.Name = "pnlOtherHeader";
            pnlOtherHeader.Size = new Size(482, 60);
            pnlOtherHeader.TabIndex = 1;
            // 
            // lblAddOtherBillTitle
            // 
            lblAddOtherBillTitle.Dock = DockStyle.Fill;
            lblAddOtherBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddOtherBillTitle.ForeColor = Color.White;
            lblAddOtherBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddOtherBillTitle.Location = new Point(0, 0);
            lblAddOtherBillTitle.Name = "lblAddOtherBillTitle";
            lblAddOtherBillTitle.Size = new Size(480, 58);
            lblAddOtherBillTitle.TabIndex = 14;
            lblAddOtherBillTitle.Text = "Add Other Bill";
            lblAddOtherBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlOtherActionButton
            // 
            pnlOtherActionButton.Controls.Add(btnConfirm);
            pnlOtherActionButton.Controls.Add(btnCancel);
            pnlOtherActionButton.Dock = DockStyle.Bottom;
            pnlOtherActionButton.Location = new Point(0, 503);
            pnlOtherActionButton.Name = "pnlOtherActionButton";
            pnlOtherActionButton.Size = new Size(482, 50);
            pnlOtherActionButton.TabIndex = 2;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(252, 9);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(139, 9);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlOtherContent
            // 
            pnlOtherContent.Controls.Add(txtAmount);
            pnlOtherContent.Controls.Add(cboName);
            pnlOtherContent.Controls.Add(txtName);
            pnlOtherContent.Controls.Add(panel1);
            pnlOtherContent.Controls.Add(dtpDate);
            pnlOtherContent.Controls.Add(txtUtilityName);
            pnlOtherContent.Controls.Add(lblAmount);
            pnlOtherContent.Controls.Add(lblName);
            pnlOtherContent.Controls.Add(lblDate);
            pnlOtherContent.Controls.Add(lblUtilityName);
            pnlOtherContent.Dock = DockStyle.Fill;
            pnlOtherContent.Location = new Point(0, 60);
            pnlOtherContent.Name = "pnlOtherContent";
            pnlOtherContent.Size = new Size(482, 443);
            pnlOtherContent.TabIndex = 3;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(82, 390);
            txtAmount.Multiline = true;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(300, 40);
            txtAmount.TabIndex = 25;
            // 
            // cboName
            // 
            cboName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboName.FormattingEnabled = true;
            cboName.Location = new Point(82, 311);
            cboName.Name = "cboName";
            cboName.Size = new Size(300, 33);
            cboName.TabIndex = 24;
            // 
            // txtName
            // 
            txtName.Location = new Point(82, 265);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 40);
            txtName.TabIndex = 23;
            // 
            // panel1
            // 
            panel1.Controls.Add(radiobtnOutsider);
            panel1.Controls.Add(radiobtnTenant);
            panel1.Location = new Point(82, 168);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 60);
            panel1.TabIndex = 22;
            panel1.Paint += panel1_Paint;
            // 
            // radiobtnOutsider
            // 
            radiobtnOutsider.AutoSize = true;
            radiobtnOutsider.ForeColor = Color.Transparent;
            radiobtnOutsider.Location = new Point(157, 19);
            radiobtnOutsider.Name = "radiobtnOutsider";
            radiobtnOutsider.Size = new Size(86, 24);
            radiobtnOutsider.TabIndex = 23;
            radiobtnOutsider.TabStop = true;
            radiobtnOutsider.Text = "Outsider";
            radiobtnOutsider.UseVisualStyleBackColor = true;
            // 
            // radiobtnTenant
            // 
            radiobtnTenant.AutoSize = true;
            radiobtnTenant.ForeColor = Color.Transparent;
            radiobtnTenant.Location = new Point(57, 19);
            radiobtnTenant.Name = "radiobtnTenant";
            radiobtnTenant.Size = new Size(74, 24);
            radiobtnTenant.TabIndex = 0;
            radiobtnTenant.TabStop = true;
            radiobtnTenant.Text = "Tenant";
            radiobtnTenant.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(82, 135);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(300, 27);
            dtpDate.TabIndex = 21;
            // 
            // txtUtilityName
            // 
            txtUtilityName.Location = new Point(82, 45);
            txtUtilityName.Multiline = true;
            txtUtilityName.Name = "txtUtilityName";
            txtUtilityName.Size = new Size(300, 40);
            txtUtilityName.TabIndex = 20;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 13.2000008F);
            lblAmount.ForeColor = Color.White;
            lblAmount.ImageAlign = ContentAlignment.MiddleRight;
            lblAmount.Location = new Point(82, 356);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(96, 31);
            lblAmount.TabIndex = 19;
            lblAmount.Text = "Amount";
            lblAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 13.2000008F);
            lblName.ForeColor = Color.White;
            lblName.ImageAlign = ContentAlignment.MiddleRight;
            lblName.Location = new Point(82, 231);
            lblName.Name = "lblName";
            lblName.Size = new Size(75, 31);
            lblName.TabIndex = 18;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 13.2000008F);
            lblDate.ForeColor = Color.White;
            lblDate.ImageAlign = ContentAlignment.MiddleRight;
            lblDate.Location = new Point(82, 101);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(62, 31);
            lblDate.TabIndex = 17;
            lblDate.Text = "Date";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUtilityName
            // 
            lblUtilityName.AutoSize = true;
            lblUtilityName.Font = new Font("Segoe UI", 13.2000008F);
            lblUtilityName.ForeColor = Color.White;
            lblUtilityName.ImageAlign = ContentAlignment.MiddleRight;
            lblUtilityName.Location = new Point(82, 11);
            lblUtilityName.Name = "lblUtilityName";
            lblUtilityName.Size = new Size(142, 31);
            lblUtilityName.TabIndex = 16;
            lblUtilityName.Text = "Utility Name";
            lblUtilityName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddOtherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 553);
            Controls.Add(pnlOtherContent);
            Controls.Add(pnlOtherActionButton);
            Controls.Add(pnlOtherHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddOtherForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddOtherForm";
            pnlOtherHeader.ResumeLayout(false);
            pnlOtherActionButton.ResumeLayout(false);
            pnlOtherContent.ResumeLayout(false);
            pnlOtherContent.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlOtherHeader;
        private Label lblAddOtherBillTitle;
        private Panel pnlOtherActionButton;
        private Button btnConfirm;
        private Button btnCancel;
        private Panel pnlOtherContent;
        private Label lblAmount;
        private Label lblName;
        private Label lblDate;
        private Label lblUtilityName;
        private TextBox txtUtilityName;
        private DateTimePicker dtpDate;
        private Panel panel1;
        private RadioButton radiobtnOutsider;
        private RadioButton radiobtnTenant;
        private TextBox txtName;
        private ComboBox cboName;
        private TextBox txtAmount;
    }
}