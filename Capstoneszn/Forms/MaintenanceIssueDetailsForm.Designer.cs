namespace Capstoneszn.Forms
{
    partial class MaintenanceIssueDetailsForm
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
            pnlIssueDetailsHeader = new Panel();
            btnCloseIssueDetails = new Button();
            lblIssueDetailsTitle = new Label();
            pnlIssueDetailsContent = new Panel();
            pnlDescription = new Panel();
            lblDescriptionValue = new Label();
            lblDescriptionTitle = new Label();
            pnlIssueStatusRow = new Panel();
            pnlResponsible = new Panel();
            lblResponsibleValue = new Label();
            lblResponsibleTitle = new Label();
            pnlAffectedTenants = new Panel();
            lblAffectedTenantsValue = new Label();
            lblAffectedTenantsTitle = new Label();
            pnlUnitDateRow = new Panel();
            pnlUnit = new Panel();
            lblUnitTitle = new Label();
            lblUnitValue = new Label();
            pnlDate = new Panel();
            lblDateTitle = new Label();
            lblDateValue = new Label();
            pnlIssue = new Panel();
            lblIssueTitle = new Label();
            lblIssueValue = new Label();
            pnlStatus = new Panel();
            lblStatusTitle = new Label();
            lblStatusValue = new Label();
            pnlIssueDetailsHeader.SuspendLayout();
            pnlIssueDetailsContent.SuspendLayout();
            pnlDescription.SuspendLayout();
            pnlIssueStatusRow.SuspendLayout();
            pnlResponsible.SuspendLayout();
            pnlAffectedTenants.SuspendLayout();
            pnlUnitDateRow.SuspendLayout();
            pnlUnit.SuspendLayout();
            pnlDate.SuspendLayout();
            pnlIssue.SuspendLayout();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // pnlIssueDetailsHeader
            // 
            pnlIssueDetailsHeader.Controls.Add(btnCloseIssueDetails);
            pnlIssueDetailsHeader.Controls.Add(lblIssueDetailsTitle);
            pnlIssueDetailsHeader.Dock = DockStyle.Top;
            pnlIssueDetailsHeader.Location = new Point(0, 0);
            pnlIssueDetailsHeader.Name = "pnlIssueDetailsHeader";
            pnlIssueDetailsHeader.Size = new Size(682, 65);
            pnlIssueDetailsHeader.TabIndex = 0;
            // 
            // btnCloseIssueDetails
            // 
            btnCloseIssueDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseIssueDetails.FlatStyle = FlatStyle.Flat;
            btnCloseIssueDetails.ForeColor = Color.White;
            btnCloseIssueDetails.Location = new Point(627, 17);
            btnCloseIssueDetails.Name = "btnCloseIssueDetails";
            btnCloseIssueDetails.Size = new Size(30, 30);
            btnCloseIssueDetails.TabIndex = 37;
            btnCloseIssueDetails.TabStop = false;
            btnCloseIssueDetails.Text = "X";
            btnCloseIssueDetails.UseVisualStyleBackColor = true;
            btnCloseIssueDetails.Click += btnCloseIssueDetails_Click;
            // 
            // lblIssueDetailsTitle
            // 
            lblIssueDetailsTitle.AutoSize = true;
            lblIssueDetailsTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueDetailsTitle.ForeColor = Color.White;
            lblIssueDetailsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblIssueDetailsTitle.Location = new Point(238, 21);
            lblIssueDetailsTitle.Name = "lblIssueDetailsTitle";
            lblIssueDetailsTitle.Size = new Size(208, 23);
            lblIssueDetailsTitle.TabIndex = 36;
            lblIssueDetailsTitle.Text = "Maintenance Issue Details";
            lblIssueDetailsTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblIssueDetailsTitle.Visible = false;
            // 
            // pnlIssueDetailsContent
            // 
            pnlIssueDetailsContent.AutoScroll = true;
            pnlIssueDetailsContent.Controls.Add(pnlDescription);
            pnlIssueDetailsContent.Controls.Add(pnlIssueStatusRow);
            pnlIssueDetailsContent.Controls.Add(pnlResponsible);
            pnlIssueDetailsContent.Controls.Add(pnlAffectedTenants);
            pnlIssueDetailsContent.Controls.Add(pnlUnitDateRow);
            pnlIssueDetailsContent.Dock = DockStyle.Fill;
            pnlIssueDetailsContent.Location = new Point(0, 65);
            pnlIssueDetailsContent.Name = "pnlIssueDetailsContent";
            pnlIssueDetailsContent.Size = new Size(682, 538);
            pnlIssueDetailsContent.TabIndex = 1;
            // 
            // pnlDescription
            // 
            pnlDescription.Controls.Add(lblDescriptionValue);
            pnlDescription.Controls.Add(lblDescriptionTitle);
            pnlDescription.Dock = DockStyle.Fill;
            pnlDescription.Location = new Point(0, 340);
            pnlDescription.Name = "pnlDescription";
            pnlDescription.Size = new Size(682, 198);
            pnlDescription.TabIndex = 6;
            // 
            // lblDescriptionValue
            // 
            lblDescriptionValue.AutoSize = true;
            lblDescriptionValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescriptionValue.ForeColor = Color.White;
            lblDescriptionValue.ImageAlign = ContentAlignment.MiddleRight;
            lblDescriptionValue.Location = new Point(314, 61);
            lblDescriptionValue.Name = "lblDescriptionValue";
            lblDescriptionValue.Size = new Size(52, 23);
            lblDescriptionValue.TabIndex = 40;
            lblDescriptionValue.Text = "Value";
            lblDescriptionValue.TextAlign = ContentAlignment.MiddleCenter;
            lblDescriptionValue.Visible = false;
            // 
            // lblDescriptionTitle
            // 
            lblDescriptionTitle.AutoSize = true;
            lblDescriptionTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescriptionTitle.ForeColor = Color.White;
            lblDescriptionTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblDescriptionTitle.Location = new Point(294, 3);
            lblDescriptionTitle.Name = "lblDescriptionTitle";
            lblDescriptionTitle.Size = new Size(96, 23);
            lblDescriptionTitle.TabIndex = 39;
            lblDescriptionTitle.Text = "Description";
            lblDescriptionTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblDescriptionTitle.Visible = false;
            // 
            // pnlIssueStatusRow
            // 
            pnlIssueStatusRow.Controls.Add(pnlStatus);
            pnlIssueStatusRow.Controls.Add(pnlIssue);
            pnlIssueStatusRow.Dock = DockStyle.Top;
            pnlIssueStatusRow.Location = new Point(0, 240);
            pnlIssueStatusRow.Name = "pnlIssueStatusRow";
            pnlIssueStatusRow.Size = new Size(682, 100);
            pnlIssueStatusRow.TabIndex = 3;
            // 
            // pnlResponsible
            // 
            pnlResponsible.Controls.Add(lblResponsibleValue);
            pnlResponsible.Controls.Add(lblResponsibleTitle);
            pnlResponsible.Dock = DockStyle.Top;
            pnlResponsible.Location = new Point(0, 165);
            pnlResponsible.Name = "pnlResponsible";
            pnlResponsible.Size = new Size(682, 75);
            pnlResponsible.TabIndex = 2;
            // 
            // lblResponsibleValue
            // 
            lblResponsibleValue.AutoSize = true;
            lblResponsibleValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResponsibleValue.ForeColor = Color.White;
            lblResponsibleValue.ImageAlign = ContentAlignment.MiddleRight;
            lblResponsibleValue.Location = new Point(238, 41);
            lblResponsibleValue.Name = "lblResponsibleValue";
            lblResponsibleValue.Size = new Size(208, 23);
            lblResponsibleValue.TabIndex = 40;
            lblResponsibleValue.Text = "Maintenance Issue Details";
            lblResponsibleValue.TextAlign = ContentAlignment.MiddleCenter;
            lblResponsibleValue.Visible = false;
            // 
            // lblResponsibleTitle
            // 
            lblResponsibleTitle.AutoSize = true;
            lblResponsibleTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResponsibleTitle.ForeColor = Color.White;
            lblResponsibleTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblResponsibleTitle.Location = new Point(238, 14);
            lblResponsibleTitle.Name = "lblResponsibleTitle";
            lblResponsibleTitle.Size = new Size(100, 23);
            lblResponsibleTitle.TabIndex = 39;
            lblResponsibleTitle.Text = "Responsible";
            lblResponsibleTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblResponsibleTitle.Visible = false;
            // 
            // pnlAffectedTenants
            // 
            pnlAffectedTenants.Controls.Add(lblAffectedTenantsValue);
            pnlAffectedTenants.Controls.Add(lblAffectedTenantsTitle);
            pnlAffectedTenants.Dock = DockStyle.Top;
            pnlAffectedTenants.Location = new Point(0, 75);
            pnlAffectedTenants.Name = "pnlAffectedTenants";
            pnlAffectedTenants.Size = new Size(682, 90);
            pnlAffectedTenants.TabIndex = 1;
            // 
            // lblAffectedTenantsValue
            // 
            lblAffectedTenantsValue.AutoSize = true;
            lblAffectedTenantsValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAffectedTenantsValue.ForeColor = Color.White;
            lblAffectedTenantsValue.ImageAlign = ContentAlignment.MiddleRight;
            lblAffectedTenantsValue.Location = new Point(238, 47);
            lblAffectedTenantsValue.Name = "lblAffectedTenantsValue";
            lblAffectedTenantsValue.Size = new Size(208, 23);
            lblAffectedTenantsValue.TabIndex = 40;
            lblAffectedTenantsValue.Text = "Maintenance Issue Details";
            lblAffectedTenantsValue.TextAlign = ContentAlignment.MiddleCenter;
            lblAffectedTenantsValue.Visible = false;
            // 
            // lblAffectedTenantsTitle
            // 
            lblAffectedTenantsTitle.AutoSize = true;
            lblAffectedTenantsTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAffectedTenantsTitle.ForeColor = Color.White;
            lblAffectedTenantsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAffectedTenantsTitle.Location = new Point(254, 12);
            lblAffectedTenantsTitle.Name = "lblAffectedTenantsTitle";
            lblAffectedTenantsTitle.Size = new Size(136, 23);
            lblAffectedTenantsTitle.TabIndex = 39;
            lblAffectedTenantsTitle.Text = "Affected Tenants";
            lblAffectedTenantsTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblAffectedTenantsTitle.Visible = false;
            // 
            // pnlUnitDateRow
            // 
            pnlUnitDateRow.Controls.Add(pnlUnit);
            pnlUnitDateRow.Controls.Add(pnlDate);
            pnlUnitDateRow.Dock = DockStyle.Top;
            pnlUnitDateRow.Location = new Point(0, 0);
            pnlUnitDateRow.Name = "pnlUnitDateRow";
            pnlUnitDateRow.Size = new Size(682, 75);
            pnlUnitDateRow.TabIndex = 0;
            // 
            // pnlUnit
            // 
            pnlUnit.Controls.Add(lblUnitTitle);
            pnlUnit.Controls.Add(lblUnitValue);
            pnlUnit.Dock = DockStyle.Left;
            pnlUnit.Location = new Point(0, 0);
            pnlUnit.Name = "pnlUnit";
            pnlUnit.Size = new Size(340, 75);
            pnlUnit.TabIndex = 42;
            // 
            // lblUnitTitle
            // 
            lblUnitTitle.AutoSize = true;
            lblUnitTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitTitle.ForeColor = Color.White;
            lblUnitTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitTitle.Location = new Point(150, 3);
            lblUnitTitle.Name = "lblUnitTitle";
            lblUnitTitle.Size = new Size(42, 23);
            lblUnitTitle.TabIndex = 39;
            lblUnitTitle.Text = "Unit";
            lblUnitTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblUnitTitle.Visible = false;
            // 
            // lblUnitValue
            // 
            lblUnitValue.AutoSize = true;
            lblUnitValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitValue.ForeColor = Color.White;
            lblUnitValue.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitValue.Location = new Point(152, 39);
            lblUnitValue.Name = "lblUnitValue";
            lblUnitValue.Size = new Size(40, 23);
            lblUnitValue.TabIndex = 40;
            lblUnitValue.Text = "###";
            lblUnitValue.TextAlign = ContentAlignment.MiddleCenter;
            lblUnitValue.Visible = false;
            // 
            // pnlDate
            // 
            pnlDate.Controls.Add(lblDateTitle);
            pnlDate.Controls.Add(lblDateValue);
            pnlDate.Dock = DockStyle.Right;
            pnlDate.Location = new Point(342, 0);
            pnlDate.Name = "pnlDate";
            pnlDate.Size = new Size(340, 75);
            pnlDate.TabIndex = 41;
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateTitle.ForeColor = Color.White;
            lblDateTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblDateTitle.Location = new Point(150, 3);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(46, 23);
            lblDateTitle.TabIndex = 39;
            lblDateTitle.Text = "Date";
            lblDateTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblDateTitle.Visible = false;
            // 
            // lblDateValue
            // 
            lblDateValue.AutoSize = true;
            lblDateValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateValue.ForeColor = Color.White;
            lblDateValue.ImageAlign = ContentAlignment.MiddleRight;
            lblDateValue.Location = new Point(156, 39);
            lblDateValue.Name = "lblDateValue";
            lblDateValue.Size = new Size(40, 23);
            lblDateValue.TabIndex = 40;
            lblDateValue.Text = "###";
            lblDateValue.TextAlign = ContentAlignment.MiddleCenter;
            lblDateValue.Visible = false;
            // 
            // pnlIssue
            // 
            pnlIssue.Controls.Add(lblIssueTitle);
            pnlIssue.Controls.Add(lblIssueValue);
            pnlIssue.Dock = DockStyle.Left;
            pnlIssue.Location = new Point(0, 0);
            pnlIssue.Name = "pnlIssue";
            pnlIssue.Size = new Size(410, 100);
            pnlIssue.TabIndex = 43;
            // 
            // lblIssueTitle
            // 
            lblIssueTitle.AutoSize = true;
            lblIssueTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueTitle.ForeColor = Color.White;
            lblIssueTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblIssueTitle.Location = new Point(150, 3);
            lblIssueTitle.Name = "lblIssueTitle";
            lblIssueTitle.Size = new Size(48, 23);
            lblIssueTitle.TabIndex = 39;
            lblIssueTitle.Text = "Issue";
            lblIssueTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblIssueTitle.Visible = false;
            // 
            // lblIssueValue
            // 
            lblIssueValue.AutoSize = true;
            lblIssueValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueValue.ForeColor = Color.White;
            lblIssueValue.ImageAlign = ContentAlignment.MiddleRight;
            lblIssueValue.Location = new Point(152, 39);
            lblIssueValue.Name = "lblIssueValue";
            lblIssueValue.Size = new Size(40, 23);
            lblIssueValue.TabIndex = 40;
            lblIssueValue.Text = "###";
            lblIssueValue.TextAlign = ContentAlignment.MiddleCenter;
            lblIssueValue.Visible = false;
            // 
            // pnlStatus
            // 
            pnlStatus.Controls.Add(lblStatusTitle);
            pnlStatus.Controls.Add(lblStatusValue);
            pnlStatus.Dock = DockStyle.Right;
            pnlStatus.Location = new Point(412, 0);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(270, 100);
            pnlStatus.TabIndex = 44;
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusTitle.ForeColor = Color.White;
            lblStatusTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblStatusTitle.Location = new Point(124, 3);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(56, 23);
            lblStatusTitle.TabIndex = 39;
            lblStatusTitle.Text = "Status";
            lblStatusTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblStatusTitle.Visible = false;
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusValue.ForeColor = Color.White;
            lblStatusValue.ImageAlign = ContentAlignment.MiddleRight;
            lblStatusValue.Location = new Point(140, 39);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(40, 23);
            lblStatusValue.TabIndex = 40;
            lblStatusValue.Text = "###";
            lblStatusValue.TextAlign = ContentAlignment.MiddleCenter;
            lblStatusValue.Visible = false;
            // 
            // MaintenanceIssueDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(682, 603);
            Controls.Add(pnlIssueDetailsContent);
            Controls.Add(pnlIssueDetailsHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MaintenanceIssueDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Maintenance Issue Details";
            pnlIssueDetailsHeader.ResumeLayout(false);
            pnlIssueDetailsHeader.PerformLayout();
            pnlIssueDetailsContent.ResumeLayout(false);
            pnlDescription.ResumeLayout(false);
            pnlDescription.PerformLayout();
            pnlIssueStatusRow.ResumeLayout(false);
            pnlResponsible.ResumeLayout(false);
            pnlResponsible.PerformLayout();
            pnlAffectedTenants.ResumeLayout(false);
            pnlAffectedTenants.PerformLayout();
            pnlUnitDateRow.ResumeLayout(false);
            pnlUnit.ResumeLayout(false);
            pnlUnit.PerformLayout();
            pnlDate.ResumeLayout(false);
            pnlDate.PerformLayout();
            pnlIssue.ResumeLayout(false);
            pnlIssue.PerformLayout();
            pnlStatus.ResumeLayout(false);
            pnlStatus.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlIssueDetailsHeader;
        private Panel pnlIssueDetailsContent;
        private Label lblIssueDetailsTitle;
        private Button btnCloseIssueDetails;
        private Panel pnlIssueStatusRow;
        private Panel pnlResponsible;
        private Panel pnlAffectedTenants;
        private Panel pnlUnitDateRow;
        private Panel pnlDescription;
        private Label lblDescriptionValue;
        private Label lblDescriptionTitle;
        private Label lblResponsibleValue;
        private Label lblResponsibleTitle;
        private Label lblAffectedTenantsValue;
        private Label lblAffectedTenantsTitle;
        private Label lblDateValue;
        private Label lblDateTitle;
        private Panel pnlUnit;
        private Label lblUnitTitle;
        private Label lblUnitValue;
        private Panel pnlDate;
        private Panel pnlStatus;
        private Label lblStatusTitle;
        private Label lblStatusValue;
        private Panel pnlIssue;
        private Label lblIssueTitle;
        private Label lblIssueValue;
    }
}