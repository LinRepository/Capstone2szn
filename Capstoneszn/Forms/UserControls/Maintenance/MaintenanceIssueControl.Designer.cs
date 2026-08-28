namespace Capstoneszn.Forms.UserControls
{
    partial class MaintenanceIssueControl
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
            pnlIssueHeader = new Panel();
            pnlStatus = new Panel();
            lblStatusValue = new Label();
            lblStatusTitle = new Label();
            pnlUnit = new Panel();
            lblUnitValue = new Label();
            lblUnitTitle = new Label();
            pnlIssueFooter = new Panel();
            pnlIssueActions = new Panel();
            btnDeleteIssue = new Button();
            btnEditIssue = new Button();
            btnViewMaterials = new Button();
            pnlIssueDate = new Panel();
            lblDateValue = new Label();
            lblDateTitle = new Label();
            pnlIssueContent = new Panel();
            pnlDescription = new Panel();
            lblDescriptionValue = new Label();
            lblDescriptionTitle = new Label();
            pnlResponsible = new Panel();
            lblResponsibleValue = new Label();
            lblResponsibleTitle = new Label();
            pnlIssue = new Panel();
            lblIssueValue = new Label();
            lblIssueTitle = new Label();
            pnlIssueHeader.SuspendLayout();
            pnlStatus.SuspendLayout();
            pnlUnit.SuspendLayout();
            pnlIssueFooter.SuspendLayout();
            pnlIssueActions.SuspendLayout();
            pnlIssueDate.SuspendLayout();
            pnlIssueContent.SuspendLayout();
            pnlDescription.SuspendLayout();
            pnlResponsible.SuspendLayout();
            pnlIssue.SuspendLayout();
            SuspendLayout();
            // 
            // pnlIssueHeader
            // 
            pnlIssueHeader.Controls.Add(pnlStatus);
            pnlIssueHeader.Controls.Add(pnlUnit);
            pnlIssueHeader.Dock = DockStyle.Top;
            pnlIssueHeader.Location = new Point(0, 0);
            pnlIssueHeader.Name = "pnlIssueHeader";
            pnlIssueHeader.Size = new Size(850, 55);
            pnlIssueHeader.TabIndex = 0;
            // 
            // pnlStatus
            // 
            pnlStatus.Controls.Add(lblStatusValue);
            pnlStatus.Controls.Add(lblStatusTitle);
            pnlStatus.Dock = DockStyle.Right;
            pnlStatus.Location = new Point(425, 0);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(425, 55);
            pnlStatus.TabIndex = 1;
            // 
            // lblStatusValue
            // 
            lblStatusValue.Dock = DockStyle.Fill;
            lblStatusValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusValue.ForeColor = Color.White;
            lblStatusValue.ImageAlign = ContentAlignment.MiddleRight;
            lblStatusValue.Location = new Point(200, 0);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(225, 55);
            lblStatusValue.TabIndex = 42;
            lblStatusValue.Text = "Pending/Completed";
            lblStatusValue.TextAlign = ContentAlignment.MiddleCenter;
            lblStatusValue.Visible = false;
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.Dock = DockStyle.Left;
            lblStatusTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusTitle.ForeColor = Color.White;
            lblStatusTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblStatusTitle.Location = new Point(0, 0);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(200, 55);
            lblStatusTitle.TabIndex = 41;
            lblStatusTitle.Text = "Status";
            lblStatusTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblStatusTitle.Visible = false;
            // 
            // pnlUnit
            // 
            pnlUnit.Controls.Add(lblUnitValue);
            pnlUnit.Controls.Add(lblUnitTitle);
            pnlUnit.Dock = DockStyle.Left;
            pnlUnit.Location = new Point(0, 0);
            pnlUnit.Name = "pnlUnit";
            pnlUnit.Size = new Size(425, 55);
            pnlUnit.TabIndex = 0;
            // 
            // lblUnitValue
            // 
            lblUnitValue.Dock = DockStyle.Fill;
            lblUnitValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitValue.ForeColor = Color.White;
            lblUnitValue.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitValue.Location = new Point(225, 0);
            lblUnitValue.Name = "lblUnitValue";
            lblUnitValue.Size = new Size(200, 55);
            lblUnitValue.TabIndex = 42;
            lblUnitValue.Text = "ROOM ###";
            lblUnitValue.TextAlign = ContentAlignment.MiddleCenter;
            lblUnitValue.Visible = false;
            // 
            // lblUnitTitle
            // 
            lblUnitTitle.Dock = DockStyle.Left;
            lblUnitTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitTitle.ForeColor = Color.White;
            lblUnitTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitTitle.Location = new Point(0, 0);
            lblUnitTitle.Name = "lblUnitTitle";
            lblUnitTitle.Size = new Size(225, 55);
            lblUnitTitle.TabIndex = 41;
            lblUnitTitle.Text = "Unit";
            lblUnitTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblUnitTitle.Visible = false;
            // 
            // pnlIssueFooter
            // 
            pnlIssueFooter.Controls.Add(pnlIssueActions);
            pnlIssueFooter.Controls.Add(pnlIssueDate);
            pnlIssueFooter.Dock = DockStyle.Bottom;
            pnlIssueFooter.Location = new Point(0, 245);
            pnlIssueFooter.Name = "pnlIssueFooter";
            pnlIssueFooter.Size = new Size(850, 55);
            pnlIssueFooter.TabIndex = 1;
            // 
            // pnlIssueActions
            // 
            pnlIssueActions.Controls.Add(btnDeleteIssue);
            pnlIssueActions.Controls.Add(btnEditIssue);
            pnlIssueActions.Controls.Add(btnViewMaterials);
            pnlIssueActions.Dock = DockStyle.Fill;
            pnlIssueActions.Location = new Point(325, 0);
            pnlIssueActions.Name = "pnlIssueActions";
            pnlIssueActions.Size = new Size(525, 55);
            pnlIssueActions.TabIndex = 1;
            // 
            // btnDeleteIssue
            // 
            btnDeleteIssue.Location = new Point(396, 13);
            btnDeleteIssue.Name = "btnDeleteIssue";
            btnDeleteIssue.Size = new Size(111, 29);
            btnDeleteIssue.TabIndex = 2;
            btnDeleteIssue.Text = "Delete";
            btnDeleteIssue.UseVisualStyleBackColor = true;
            // 
            // btnEditIssue
            // 
            btnEditIssue.Location = new Point(267, 13);
            btnEditIssue.Name = "btnEditIssue";
            btnEditIssue.Size = new Size(111, 29);
            btnEditIssue.TabIndex = 1;
            btnEditIssue.Text = "Edit";
            btnEditIssue.UseVisualStyleBackColor = true;
            // 
            // btnViewMaterials
            // 
            btnViewMaterials.Location = new Point(42, 13);
            btnViewMaterials.Name = "btnViewMaterials";
            btnViewMaterials.Size = new Size(150, 29);
            btnViewMaterials.TabIndex = 0;
            btnViewMaterials.Text = "View Materials";
            btnViewMaterials.UseVisualStyleBackColor = true;
            // 
            // pnlIssueDate
            // 
            pnlIssueDate.Controls.Add(lblDateValue);
            pnlIssueDate.Controls.Add(lblDateTitle);
            pnlIssueDate.Dock = DockStyle.Left;
            pnlIssueDate.Location = new Point(0, 0);
            pnlIssueDate.Name = "pnlIssueDate";
            pnlIssueDate.Size = new Size(325, 55);
            pnlIssueDate.TabIndex = 0;
            // 
            // lblDateValue
            // 
            lblDateValue.Dock = DockStyle.Fill;
            lblDateValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateValue.ForeColor = Color.White;
            lblDateValue.ImageAlign = ContentAlignment.MiddleRight;
            lblDateValue.Location = new Point(0, 25);
            lblDateValue.Name = "lblDateValue";
            lblDateValue.Size = new Size(325, 30);
            lblDateValue.TabIndex = 42;
            lblDateValue.Text = "MM/DD/YYYY";
            lblDateValue.TextAlign = ContentAlignment.MiddleCenter;
            lblDateValue.Visible = false;
            // 
            // lblDateTitle
            // 
            lblDateTitle.Dock = DockStyle.Top;
            lblDateTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateTitle.ForeColor = Color.White;
            lblDateTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblDateTitle.Location = new Point(0, 0);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(325, 25);
            lblDateTitle.TabIndex = 41;
            lblDateTitle.Text = "Date";
            lblDateTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblDateTitle.Visible = false;
            // 
            // pnlIssueContent
            // 
            pnlIssueContent.Controls.Add(pnlDescription);
            pnlIssueContent.Controls.Add(pnlResponsible);
            pnlIssueContent.Controls.Add(pnlIssue);
            pnlIssueContent.Dock = DockStyle.Fill;
            pnlIssueContent.Location = new Point(0, 55);
            pnlIssueContent.Name = "pnlIssueContent";
            pnlIssueContent.Size = new Size(850, 190);
            pnlIssueContent.TabIndex = 2;
            // 
            // pnlDescription
            // 
            pnlDescription.AutoScroll = true;
            pnlDescription.Controls.Add(lblDescriptionValue);
            pnlDescription.Controls.Add(lblDescriptionTitle);
            pnlDescription.Dock = DockStyle.Fill;
            pnlDescription.Location = new Point(0, 60);
            pnlDescription.Name = "pnlDescription";
            pnlDescription.Size = new Size(850, 70);
            pnlDescription.TabIndex = 2;
            // 
            // lblDescriptionValue
            // 
            lblDescriptionValue.AutoEllipsis = true;
            lblDescriptionValue.Dock = DockStyle.Fill;
            lblDescriptionValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescriptionValue.ForeColor = Color.White;
            lblDescriptionValue.ImageAlign = ContentAlignment.MiddleRight;
            lblDescriptionValue.Location = new Point(0, 28);
            lblDescriptionValue.Name = "lblDescriptionValue";
            lblDescriptionValue.Padding = new Padding(15, 0, 0, 0);
            lblDescriptionValue.Size = new Size(850, 42);
            lblDescriptionValue.TabIndex = 43;
            lblDescriptionValue.Text = "description details are displayed here";
            lblDescriptionValue.TextAlign = ContentAlignment.MiddleLeft;
            lblDescriptionValue.Visible = false;
            // 
            // lblDescriptionTitle
            // 
            lblDescriptionTitle.AutoSize = true;
            lblDescriptionTitle.Dock = DockStyle.Top;
            lblDescriptionTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescriptionTitle.ForeColor = Color.White;
            lblDescriptionTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblDescriptionTitle.Location = new Point(0, 0);
            lblDescriptionTitle.Name = "lblDescriptionTitle";
            lblDescriptionTitle.Padding = new Padding(15, 0, 0, 0);
            lblDescriptionTitle.Size = new Size(127, 28);
            lblDescriptionTitle.TabIndex = 42;
            lblDescriptionTitle.Text = "Description";
            lblDescriptionTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblDescriptionTitle.Visible = false;
            // 
            // pnlResponsible
            // 
            pnlResponsible.AutoScroll = true;
            pnlResponsible.Controls.Add(lblResponsibleValue);
            pnlResponsible.Controls.Add(lblResponsibleTitle);
            pnlResponsible.Dock = DockStyle.Bottom;
            pnlResponsible.Location = new Point(0, 130);
            pnlResponsible.Name = "pnlResponsible";
            pnlResponsible.Size = new Size(850, 60);
            pnlResponsible.TabIndex = 1;
            // 
            // lblResponsibleValue
            // 
            lblResponsibleValue.Dock = DockStyle.Fill;
            lblResponsibleValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResponsibleValue.ForeColor = Color.White;
            lblResponsibleValue.ImageAlign = ContentAlignment.MiddleRight;
            lblResponsibleValue.Location = new Point(0, 28);
            lblResponsibleValue.Name = "lblResponsibleValue";
            lblResponsibleValue.Padding = new Padding(15, 0, 0, 0);
            lblResponsibleValue.Size = new Size(850, 32);
            lblResponsibleValue.TabIndex = 43;
            lblResponsibleValue.Text = "responsible person are displayed here";
            lblResponsibleValue.TextAlign = ContentAlignment.MiddleLeft;
            lblResponsibleValue.Visible = false;
            // 
            // lblResponsibleTitle
            // 
            lblResponsibleTitle.AutoSize = true;
            lblResponsibleTitle.Dock = DockStyle.Top;
            lblResponsibleTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResponsibleTitle.ForeColor = Color.White;
            lblResponsibleTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblResponsibleTitle.Location = new Point(0, 0);
            lblResponsibleTitle.Name = "lblResponsibleTitle";
            lblResponsibleTitle.Padding = new Padding(15, 0, 0, 0);
            lblResponsibleTitle.Size = new Size(131, 28);
            lblResponsibleTitle.TabIndex = 42;
            lblResponsibleTitle.Text = "Responsible";
            lblResponsibleTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblResponsibleTitle.Visible = false;
            // 
            // pnlIssue
            // 
            pnlIssue.AutoScroll = true;
            pnlIssue.Controls.Add(lblIssueValue);
            pnlIssue.Controls.Add(lblIssueTitle);
            pnlIssue.Dock = DockStyle.Top;
            pnlIssue.Location = new Point(0, 0);
            pnlIssue.Name = "pnlIssue";
            pnlIssue.Size = new Size(850, 60);
            pnlIssue.TabIndex = 0;
            // 
            // lblIssueValue
            // 
            lblIssueValue.Dock = DockStyle.Fill;
            lblIssueValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueValue.ForeColor = Color.White;
            lblIssueValue.ImageAlign = ContentAlignment.MiddleRight;
            lblIssueValue.Location = new Point(0, 28);
            lblIssueValue.Name = "lblIssueValue";
            lblIssueValue.Padding = new Padding(15, 0, 0, 0);
            lblIssueValue.Size = new Size(850, 32);
            lblIssueValue.TabIndex = 43;
            lblIssueValue.Text = "issue details are displayed here";
            lblIssueValue.TextAlign = ContentAlignment.MiddleLeft;
            lblIssueValue.Visible = false;
            // 
            // lblIssueTitle
            // 
            lblIssueTitle.AutoSize = true;
            lblIssueTitle.Dock = DockStyle.Top;
            lblIssueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueTitle.ForeColor = Color.White;
            lblIssueTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblIssueTitle.Location = new Point(0, 0);
            lblIssueTitle.Name = "lblIssueTitle";
            lblIssueTitle.Padding = new Padding(15, 0, 0, 0);
            lblIssueTitle.Size = new Size(69, 28);
            lblIssueTitle.TabIndex = 42;
            lblIssueTitle.Text = "Issue";
            lblIssueTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblIssueTitle.Visible = false;
            // 
            // MaintenanceIssueControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlIssueContent);
            Controls.Add(pnlIssueFooter);
            Controls.Add(pnlIssueHeader);
            Cursor = Cursors.Hand;
            Name = "MaintenanceIssueControl";
            Size = new Size(850, 300);
            pnlIssueHeader.ResumeLayout(false);
            pnlStatus.ResumeLayout(false);
            pnlUnit.ResumeLayout(false);
            pnlIssueFooter.ResumeLayout(false);
            pnlIssueActions.ResumeLayout(false);
            pnlIssueDate.ResumeLayout(false);
            pnlIssueContent.ResumeLayout(false);
            pnlDescription.ResumeLayout(false);
            pnlDescription.PerformLayout();
            pnlResponsible.ResumeLayout(false);
            pnlResponsible.PerformLayout();
            pnlIssue.ResumeLayout(false);
            pnlIssue.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlIssueHeader;
        private Panel pnlIssueFooter;
        private Panel pnlIssueContent;
        private Panel pnlStatus;
        private Panel pnlUnit;
        private Label lblStatusTitle;
        private Label lblUnitTitle;
        private Panel pnlIssueActions;
        private Panel pnlIssueDate;
        private Panel pnlDescription;
        private Panel pnlResponsible;
        private Panel pnlIssue;
        private Button btnDeleteIssue;
        private Button btnEditIssue;
        private Button btnViewMaterials;
        private Label lblDescriptionValue;
        private Label lblDescriptionTitle;
        private Label lblResponsibleValue;
        private Label lblResponsibleTitle;
        private Label lblIssueValue;
        private Label lblIssueTitle;
        private Label lblStatusValue;
        private Label lblUnitValue;
        private Label lblDateValue;
        private Label lblDateTitle;
    }
}
