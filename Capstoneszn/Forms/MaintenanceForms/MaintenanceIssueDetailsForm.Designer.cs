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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlIssueDetailsHeader = new Panel();
            lblStatusValue = new Label();
            lblStatusTitle = new Label();
            lblIssueDetailsTitle = new Label();
            pnlIssueDetailsActions = new Panel();
            btnCloseDetails = new Button();
            pnlIssueDetailsContent = new Panel();
            tlpIssueDetails = new TableLayoutPanel();
            pnlDetailsColumn = new Panel();
            pnlDescription = new Panel();
            lblDescriptionValue = new Label();
            lblDescriptionTitle = new Label();
            pnlDateRow = new Panel();
            pnlCompleted = new Panel();
            lblCompletedValue = new Label();
            lblCompletedTitle = new Label();
            pnlDate = new Panel();
            lblDateValue = new Label();
            lblDateTitle = new Label();
            pnlIssue = new Panel();
            lblIssueValue = new Label();
            lblIssueTitle = new Label();
            pnlUnit = new Panel();
            lblUnitValue = new Label();
            lblUnitTitle = new Label();
            lblIssueDetailsHeading = new Label();
            pnlPeopleColumn = new Panel();
            pnlAffectedTenants = new Panel();
            dgvAffectedTenants = new DataGridView();
            colTenantName = new DataGridViewTextBoxColumn();
            colTenantRoom = new DataGridViewTextBoxColumn();
            lblAffectedTenantsTitle = new Label();
            pnlMaterials = new Panel();
            dgvMaterials = new DataGridView();
            colMaterialName = new DataGridViewTextBoxColumn();
            colMaterialQty = new DataGridViewTextBoxColumn();
            lblMaterialsTitle = new Label();
            pnlResponsible = new Panel();
            lblResponsibleValue = new Label();
            lblResponsibleTitle = new Label();
            lblPeopleHeading = new Label();
            pnlIssueDetailsHeader.SuspendLayout();
            pnlIssueDetailsActions.SuspendLayout();
            pnlIssueDetailsContent.SuspendLayout();
            tlpIssueDetails.SuspendLayout();
            pnlDetailsColumn.SuspendLayout();
            pnlDescription.SuspendLayout();
            pnlDateRow.SuspendLayout();
            pnlCompleted.SuspendLayout();
            pnlDate.SuspendLayout();
            pnlIssue.SuspendLayout();
            pnlUnit.SuspendLayout();
            pnlPeopleColumn.SuspendLayout();
            pnlAffectedTenants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAffectedTenants).BeginInit();
            pnlMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).BeginInit();
            pnlResponsible.SuspendLayout();
            SuspendLayout();
            //
            // pnlIssueDetailsHeader
            //
            pnlIssueDetailsHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlIssueDetailsHeader.Controls.Add(lblStatusValue);
            pnlIssueDetailsHeader.Controls.Add(lblStatusTitle);
            pnlIssueDetailsHeader.Controls.Add(lblIssueDetailsTitle);
            pnlIssueDetailsHeader.Dock = DockStyle.Top;
            pnlIssueDetailsHeader.Location = new Point(0, 0);
            pnlIssueDetailsHeader.Name = "pnlIssueDetailsHeader";
            pnlIssueDetailsHeader.Size = new Size(900, 60);
            pnlIssueDetailsHeader.TabIndex = 0;
            //
            // lblStatusValue
            //
            lblStatusValue.AutoSize = true;
            lblStatusValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusValue.ForeColor = Color.White;
            lblStatusValue.Location = new Point(400, 16);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(41, 25);
            lblStatusValue.TabIndex = 2;
            lblStatusValue.Text = "###";
            //
            // lblStatusTitle
            //
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusTitle.ForeColor = Color.FromArgb(170, 180, 215);
            lblStatusTitle.Location = new Point(330, 17);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(61, 23);
            lblStatusTitle.TabIndex = 1;
            lblStatusTitle.Text = "Status:";
            //
            // lblIssueDetailsTitle
            //
            lblIssueDetailsTitle.AutoSize = true;
            lblIssueDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIssueDetailsTitle.ForeColor = Color.White;
            lblIssueDetailsTitle.Location = new Point(20, 15);
            lblIssueDetailsTitle.Name = "lblIssueDetailsTitle";
            lblIssueDetailsTitle.Size = new Size(266, 28);
            lblIssueDetailsTitle.TabIndex = 0;
            lblIssueDetailsTitle.Text = "Maintenance Issue Details";
            //
            // pnlIssueDetailsActions
            //
            pnlIssueDetailsActions.BorderStyle = BorderStyle.FixedSingle;
            pnlIssueDetailsActions.Controls.Add(btnCloseDetails);
            pnlIssueDetailsActions.Dock = DockStyle.Bottom;
            pnlIssueDetailsActions.Location = new Point(0, 556);
            pnlIssueDetailsActions.Name = "pnlIssueDetailsActions";
            pnlIssueDetailsActions.Size = new Size(900, 64);
            pnlIssueDetailsActions.TabIndex = 2;
            //
            // btnCloseDetails
            //
            btnCloseDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseDetails.Cursor = Cursors.Hand;
            btnCloseDetails.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCloseDetails.Location = new Point(763, 14);
            btnCloseDetails.Name = "btnCloseDetails";
            btnCloseDetails.Size = new Size(115, 34);
            btnCloseDetails.TabIndex = 0;
            btnCloseDetails.Text = "Close";
            btnCloseDetails.UseVisualStyleBackColor = true;
            btnCloseDetails.Click += btnCloseDetails_Click;
            //
            // pnlIssueDetailsContent
            //
            pnlIssueDetailsContent.AutoScroll = true;
            pnlIssueDetailsContent.Controls.Add(tlpIssueDetails);
            pnlIssueDetailsContent.Dock = DockStyle.Fill;
            pnlIssueDetailsContent.Location = new Point(0, 60);
            pnlIssueDetailsContent.Name = "pnlIssueDetailsContent";
            pnlIssueDetailsContent.Padding = new Padding(15);
            pnlIssueDetailsContent.Size = new Size(900, 496);
            pnlIssueDetailsContent.TabIndex = 1;
            //
            // tlpIssueDetails
            //
            tlpIssueDetails.ColumnCount = 2;
            tlpIssueDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpIssueDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpIssueDetails.Controls.Add(pnlDetailsColumn, 0, 0);
            tlpIssueDetails.Controls.Add(pnlPeopleColumn, 1, 0);
            tlpIssueDetails.Dock = DockStyle.Fill;
            tlpIssueDetails.Location = new Point(15, 15);
            tlpIssueDetails.Name = "tlpIssueDetails";
            tlpIssueDetails.RowCount = 1;
            tlpIssueDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpIssueDetails.Size = new Size(870, 466);
            tlpIssueDetails.TabIndex = 0;
            //
            // pnlDetailsColumn
            //
            pnlDetailsColumn.Controls.Add(pnlDescription);
            pnlDetailsColumn.Controls.Add(pnlDateRow);
            pnlDetailsColumn.Controls.Add(pnlIssue);
            pnlDetailsColumn.Controls.Add(pnlUnit);
            pnlDetailsColumn.Controls.Add(lblIssueDetailsHeading);
            pnlDetailsColumn.Dock = DockStyle.Fill;
            pnlDetailsColumn.Location = new Point(0, 0);
            pnlDetailsColumn.Margin = new Padding(0);
            pnlDetailsColumn.Name = "pnlDetailsColumn";
            pnlDetailsColumn.Padding = new Padding(0, 0, 15, 0);
            pnlDetailsColumn.Size = new Size(435, 466);
            pnlDetailsColumn.TabIndex = 0;
            //
            // pnlDescription
            //
            pnlDescription.Controls.Add(lblDescriptionValue);
            pnlDescription.Controls.Add(lblDescriptionTitle);
            pnlDescription.Dock = DockStyle.Fill;
            pnlDescription.Location = new Point(0, 142);
            pnlDescription.Name = "pnlDescription";
            pnlDescription.Padding = new Padding(0, 0, 0, 8);
            pnlDescription.Size = new Size(420, 268);
            pnlDescription.TabIndex = 3;
            //
            // lblDescriptionValue
            //
            lblDescriptionValue.BackColor = Color.FromArgb(35, 35, 85);
            lblDescriptionValue.BorderStyle = BorderStyle.FixedSingle;
            lblDescriptionValue.Dock = DockStyle.Fill;
            lblDescriptionValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescriptionValue.ForeColor = Color.White;
            lblDescriptionValue.Location = new Point(0, 26);
            lblDescriptionValue.Name = "lblDescriptionValue";
            lblDescriptionValue.Padding = new Padding(8, 6, 8, 6);
            lblDescriptionValue.Size = new Size(420, 234);
            lblDescriptionValue.TabIndex = 1;
            lblDescriptionValue.Text = "Value";
            //
            // lblDescriptionTitle
            //
            lblDescriptionTitle.Dock = DockStyle.Top;
            lblDescriptionTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescriptionTitle.ForeColor = Color.FromArgb(170, 180, 215);
            lblDescriptionTitle.Location = new Point(0, 0);
            lblDescriptionTitle.Name = "lblDescriptionTitle";
            lblDescriptionTitle.Size = new Size(420, 26);
            lblDescriptionTitle.TabIndex = 0;
            lblDescriptionTitle.Text = "Description";
            lblDescriptionTitle.TextAlign = ContentAlignment.BottomLeft;
            //
            // pnlDateRow
            //
            pnlDateRow.Controls.Add(pnlCompleted);
            pnlDateRow.Controls.Add(pnlDate);
            pnlDateRow.Dock = DockStyle.Bottom;
            pnlDateRow.Location = new Point(0, 410);
            pnlDateRow.Name = "pnlDateRow";
            pnlDateRow.Size = new Size(420, 56);
            pnlDateRow.TabIndex = 4;
            //
            // pnlCompleted
            //
            pnlCompleted.Controls.Add(lblCompletedValue);
            pnlCompleted.Controls.Add(lblCompletedTitle);
            pnlCompleted.Dock = DockStyle.Fill;
            pnlCompleted.Location = new Point(210, 0);
            pnlCompleted.Name = "pnlCompleted";
            pnlCompleted.Size = new Size(210, 56);
            pnlCompleted.TabIndex = 1;
            //
            // lblCompletedValue
            //
            lblCompletedValue.AutoEllipsis = true;
            lblCompletedValue.Dock = DockStyle.Fill;
            lblCompletedValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCompletedValue.ForeColor = Color.White;
            lblCompletedValue.Location = new Point(0, 24);
            lblCompletedValue.Name = "lblCompletedValue";
            lblCompletedValue.Size = new Size(210, 32);
            lblCompletedValue.TabIndex = 1;
            lblCompletedValue.Text = "-";
            lblCompletedValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblCompletedTitle
            //
            lblCompletedTitle.Dock = DockStyle.Top;
            lblCompletedTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCompletedTitle.ForeColor = Color.FromArgb(170, 180, 215);
            lblCompletedTitle.Location = new Point(0, 0);
            lblCompletedTitle.Name = "lblCompletedTitle";
            lblCompletedTitle.Size = new Size(210, 24);
            lblCompletedTitle.TabIndex = 0;
            lblCompletedTitle.Text = "Date Completed";
            lblCompletedTitle.TextAlign = ContentAlignment.BottomLeft;
            //
            // pnlDate
            //
            pnlDate.Controls.Add(lblDateValue);
            pnlDate.Controls.Add(lblDateTitle);
            pnlDate.Dock = DockStyle.Left;
            pnlDate.Location = new Point(0, 0);
            pnlDate.Name = "pnlDate";
            pnlDate.Size = new Size(210, 56);
            pnlDate.TabIndex = 0;
            //
            // lblDateValue
            //
            lblDateValue.AutoEllipsis = true;
            lblDateValue.Dock = DockStyle.Fill;
            lblDateValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateValue.ForeColor = Color.White;
            lblDateValue.Location = new Point(0, 24);
            lblDateValue.Name = "lblDateValue";
            lblDateValue.Size = new Size(210, 32);
            lblDateValue.TabIndex = 1;
            lblDateValue.Text = "###";
            lblDateValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblDateTitle
            //
            lblDateTitle.Dock = DockStyle.Top;
            lblDateTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateTitle.ForeColor = Color.FromArgb(170, 180, 215);
            lblDateTitle.Location = new Point(0, 0);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(210, 24);
            lblDateTitle.TabIndex = 0;
            lblDateTitle.Text = "Date Reported";
            lblDateTitle.TextAlign = ContentAlignment.BottomLeft;
            //
            // pnlIssue
            //
            pnlIssue.Controls.Add(lblIssueValue);
            pnlIssue.Controls.Add(lblIssueTitle);
            pnlIssue.Dock = DockStyle.Top;
            pnlIssue.Location = new Point(0, 86);
            pnlIssue.Name = "pnlIssue";
            pnlIssue.Size = new Size(420, 56);
            pnlIssue.TabIndex = 2;
            //
            // lblIssueValue
            //
            lblIssueValue.AutoEllipsis = true;
            lblIssueValue.Dock = DockStyle.Fill;
            lblIssueValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueValue.ForeColor = Color.White;
            lblIssueValue.Location = new Point(0, 24);
            lblIssueValue.Name = "lblIssueValue";
            lblIssueValue.Size = new Size(420, 32);
            lblIssueValue.TabIndex = 1;
            lblIssueValue.Text = "###";
            lblIssueValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblIssueTitle
            //
            lblIssueTitle.Dock = DockStyle.Top;
            lblIssueTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueTitle.ForeColor = Color.FromArgb(170, 180, 215);
            lblIssueTitle.Location = new Point(0, 0);
            lblIssueTitle.Name = "lblIssueTitle";
            lblIssueTitle.Size = new Size(420, 24);
            lblIssueTitle.TabIndex = 0;
            lblIssueTitle.Text = "Issue Title";
            lblIssueTitle.TextAlign = ContentAlignment.BottomLeft;
            //
            // pnlUnit
            //
            pnlUnit.Controls.Add(lblUnitValue);
            pnlUnit.Controls.Add(lblUnitTitle);
            pnlUnit.Dock = DockStyle.Top;
            pnlUnit.Location = new Point(0, 30);
            pnlUnit.Name = "pnlUnit";
            pnlUnit.Size = new Size(420, 56);
            pnlUnit.TabIndex = 1;
            //
            // lblUnitValue
            //
            lblUnitValue.AutoEllipsis = true;
            lblUnitValue.Dock = DockStyle.Fill;
            lblUnitValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnitValue.ForeColor = Color.White;
            lblUnitValue.Location = new Point(0, 24);
            lblUnitValue.Name = "lblUnitValue";
            lblUnitValue.Size = new Size(420, 32);
            lblUnitValue.TabIndex = 1;
            lblUnitValue.Text = "###";
            lblUnitValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblUnitTitle
            //
            lblUnitTitle.Dock = DockStyle.Top;
            lblUnitTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitTitle.ForeColor = Color.FromArgb(170, 180, 215);
            lblUnitTitle.Location = new Point(0, 0);
            lblUnitTitle.Name = "lblUnitTitle";
            lblUnitTitle.Size = new Size(420, 24);
            lblUnitTitle.TabIndex = 0;
            lblUnitTitle.Text = "Room";
            lblUnitTitle.TextAlign = ContentAlignment.BottomLeft;
            //
            // lblIssueDetailsHeading
            //
            lblIssueDetailsHeading.Dock = DockStyle.Top;
            lblIssueDetailsHeading.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIssueDetailsHeading.ForeColor = Color.FromArgb(170, 180, 215);
            lblIssueDetailsHeading.Location = new Point(0, 0);
            lblIssueDetailsHeading.Name = "lblIssueDetailsHeading";
            lblIssueDetailsHeading.Size = new Size(420, 30);
            lblIssueDetailsHeading.TabIndex = 0;
            lblIssueDetailsHeading.Text = "ISSUE DETAILS";
            lblIssueDetailsHeading.TextAlign = ContentAlignment.TopLeft;
            //
            // pnlPeopleColumn
            //
            pnlPeopleColumn.Controls.Add(pnlAffectedTenants);
            pnlPeopleColumn.Controls.Add(pnlMaterials);
            pnlPeopleColumn.Controls.Add(pnlResponsible);
            pnlPeopleColumn.Controls.Add(lblPeopleHeading);
            pnlPeopleColumn.Dock = DockStyle.Fill;
            pnlPeopleColumn.Location = new Point(435, 0);
            pnlPeopleColumn.Margin = new Padding(0);
            pnlPeopleColumn.Name = "pnlPeopleColumn";
            pnlPeopleColumn.Padding = new Padding(15, 0, 0, 0);
            pnlPeopleColumn.Size = new Size(435, 466);
            pnlPeopleColumn.TabIndex = 1;
            //
            // pnlAffectedTenants
            //
            pnlAffectedTenants.Controls.Add(dgvAffectedTenants);
            pnlAffectedTenants.Controls.Add(lblAffectedTenantsTitle);
            pnlAffectedTenants.Dock = DockStyle.Fill;
            pnlAffectedTenants.Location = new Point(15, 86);
            pnlAffectedTenants.Name = "pnlAffectedTenants";
            pnlAffectedTenants.Padding = new Padding(0, 0, 0, 8);
            pnlAffectedTenants.Size = new Size(420, 210);
            pnlAffectedTenants.TabIndex = 2;
            //
            // dgvAffectedTenants
            //
            dgvAffectedTenants.AllowUserToAddRows = false;
            dgvAffectedTenants.AllowUserToDeleteRows = false;
            dgvAffectedTenants.AllowUserToResizeRows = false;
            dgvAffectedTenants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAffectedTenants.BackgroundColor = Color.FromArgb(35, 35, 85);
            dgvAffectedTenants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAffectedTenants.Columns.AddRange(new DataGridViewColumn[] { colTenantName, colTenantRoom });
            dgvAffectedTenants.Dock = DockStyle.Fill;
            dgvAffectedTenants.Location = new Point(0, 26);
            dgvAffectedTenants.MultiSelect = false;
            dgvAffectedTenants.Name = "dgvAffectedTenants";
            dgvAffectedTenants.ReadOnly = true;
            dgvAffectedTenants.RowHeadersVisible = false;
            dgvAffectedTenants.RowHeadersWidth = 51;
            dgvAffectedTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAffectedTenants.Size = new Size(420, 176);
            dgvAffectedTenants.TabIndex = 1;
            //
            // colTenantName
            //
            colTenantName.DataPropertyName = "Name";
            colTenantName.FillWeight = 70F;
            colTenantName.HeaderText = "Tenant";
            colTenantName.MinimumWidth = 6;
            colTenantName.Name = "colTenantName";
            colTenantName.ReadOnly = true;
            //
            // colTenantRoom
            //
            colTenantRoom.DataPropertyName = "RoomNumber";
            colTenantRoom.FillWeight = 30F;
            colTenantRoom.HeaderText = "Room";
            colTenantRoom.MinimumWidth = 6;
            colTenantRoom.Name = "colTenantRoom";
            colTenantRoom.ReadOnly = true;
            //
            // lblAffectedTenantsTitle
            //
            lblAffectedTenantsTitle.Dock = DockStyle.Top;
            lblAffectedTenantsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAffectedTenantsTitle.ForeColor = Color.FromArgb(170, 180, 215);
            lblAffectedTenantsTitle.Location = new Point(0, 0);
            lblAffectedTenantsTitle.Name = "lblAffectedTenantsTitle";
            lblAffectedTenantsTitle.Size = new Size(420, 26);
            lblAffectedTenantsTitle.TabIndex = 0;
            lblAffectedTenantsTitle.Text = "Affected Tenants";
            lblAffectedTenantsTitle.TextAlign = ContentAlignment.BottomLeft;
            //
            // pnlMaterials
            //
            pnlMaterials.Controls.Add(dgvMaterials);
            pnlMaterials.Controls.Add(lblMaterialsTitle);
            pnlMaterials.Dock = DockStyle.Bottom;
            pnlMaterials.Location = new Point(15, 296);
            pnlMaterials.Name = "pnlMaterials";
            pnlMaterials.Size = new Size(420, 170);
            pnlMaterials.TabIndex = 3;
            //
            // dgvMaterials
            //
            dgvMaterials.AllowUserToAddRows = false;
            dgvMaterials.AllowUserToDeleteRows = false;
            dgvMaterials.AllowUserToResizeRows = false;
            dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterials.BackgroundColor = Color.FromArgb(35, 35, 85);
            dgvMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterials.Columns.AddRange(new DataGridViewColumn[] { colMaterialName, colMaterialQty });
            dgvMaterials.Dock = DockStyle.Fill;
            dgvMaterials.Location = new Point(0, 26);
            dgvMaterials.MultiSelect = false;
            dgvMaterials.Name = "dgvMaterials";
            dgvMaterials.ReadOnly = true;
            dgvMaterials.RowHeadersVisible = false;
            dgvMaterials.RowHeadersWidth = 51;
            dgvMaterials.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterials.Size = new Size(420, 144);
            dgvMaterials.TabIndex = 1;
            //
            // colMaterialName
            //
            colMaterialName.DataPropertyName = "MaterialName";
            colMaterialName.FillWeight = 75F;
            colMaterialName.HeaderText = "Material";
            colMaterialName.MinimumWidth = 6;
            colMaterialName.Name = "colMaterialName";
            colMaterialName.ReadOnly = true;
            //
            // colMaterialQty
            //
            colMaterialQty.DataPropertyName = "Quantity";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            colMaterialQty.DefaultCellStyle = dataGridViewCellStyle1;
            colMaterialQty.FillWeight = 25F;
            colMaterialQty.HeaderText = "Qty";
            colMaterialQty.MinimumWidth = 6;
            colMaterialQty.Name = "colMaterialQty";
            colMaterialQty.ReadOnly = true;
            //
            // lblMaterialsTitle
            //
            lblMaterialsTitle.Dock = DockStyle.Top;
            lblMaterialsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialsTitle.ForeColor = Color.FromArgb(170, 180, 215);
            lblMaterialsTitle.Location = new Point(0, 0);
            lblMaterialsTitle.Name = "lblMaterialsTitle";
            lblMaterialsTitle.Size = new Size(420, 26);
            lblMaterialsTitle.TabIndex = 0;
            lblMaterialsTitle.Text = "Materials";
            lblMaterialsTitle.TextAlign = ContentAlignment.BottomLeft;
            //
            // pnlResponsible
            //
            pnlResponsible.Controls.Add(lblResponsibleValue);
            pnlResponsible.Controls.Add(lblResponsibleTitle);
            pnlResponsible.Dock = DockStyle.Top;
            pnlResponsible.Location = new Point(15, 30);
            pnlResponsible.Name = "pnlResponsible";
            pnlResponsible.Size = new Size(420, 56);
            pnlResponsible.TabIndex = 1;
            //
            // lblResponsibleValue
            //
            lblResponsibleValue.AutoEllipsis = true;
            lblResponsibleValue.Dock = DockStyle.Fill;
            lblResponsibleValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResponsibleValue.ForeColor = Color.White;
            lblResponsibleValue.Location = new Point(0, 24);
            lblResponsibleValue.Name = "lblResponsibleValue";
            lblResponsibleValue.Size = new Size(420, 32);
            lblResponsibleValue.TabIndex = 1;
            lblResponsibleValue.Text = "###";
            lblResponsibleValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblResponsibleTitle
            //
            lblResponsibleTitle.Dock = DockStyle.Top;
            lblResponsibleTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResponsibleTitle.ForeColor = Color.FromArgb(170, 180, 215);
            lblResponsibleTitle.Location = new Point(0, 0);
            lblResponsibleTitle.Name = "lblResponsibleTitle";
            lblResponsibleTitle.Size = new Size(420, 24);
            lblResponsibleTitle.TabIndex = 0;
            lblResponsibleTitle.Text = "Responsible";
            lblResponsibleTitle.TextAlign = ContentAlignment.BottomLeft;
            //
            // lblPeopleHeading
            //
            lblPeopleHeading.Dock = DockStyle.Top;
            lblPeopleHeading.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPeopleHeading.ForeColor = Color.FromArgb(170, 180, 215);
            lblPeopleHeading.Location = new Point(15, 0);
            lblPeopleHeading.Name = "lblPeopleHeading";
            lblPeopleHeading.Size = new Size(420, 30);
            lblPeopleHeading.TabIndex = 0;
            lblPeopleHeading.Text = "PEOPLE AND MATERIALS";
            lblPeopleHeading.TextAlign = ContentAlignment.TopLeft;
            //
            // MaintenanceIssueDetailsForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(900, 620);
            Controls.Add(pnlIssueDetailsContent);
            Controls.Add(pnlIssueDetailsActions);
            Controls.Add(pnlIssueDetailsHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MaintenanceIssueDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Maintenance Issue Details";
            Load += MaintenanceIssueDetailsForm_Load;
            pnlIssueDetailsHeader.ResumeLayout(false);
            pnlIssueDetailsHeader.PerformLayout();
            pnlIssueDetailsActions.ResumeLayout(false);
            pnlIssueDetailsContent.ResumeLayout(false);
            tlpIssueDetails.ResumeLayout(false);
            pnlDetailsColumn.ResumeLayout(false);
            pnlDescription.ResumeLayout(false);
            pnlDateRow.ResumeLayout(false);
            pnlCompleted.ResumeLayout(false);
            pnlDate.ResumeLayout(false);
            pnlIssue.ResumeLayout(false);
            pnlUnit.ResumeLayout(false);
            pnlPeopleColumn.ResumeLayout(false);
            pnlAffectedTenants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAffectedTenants).EndInit();
            pnlMaterials.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).EndInit();
            pnlResponsible.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlIssueDetailsHeader;
        private Panel pnlIssueDetailsContent;
        private Label lblIssueDetailsTitle;
        private Panel pnlResponsible;
        private Panel pnlAffectedTenants;
        private Panel pnlDescription;
        private Label lblDescriptionValue;
        private Label lblDescriptionTitle;
        private Label lblResponsibleValue;
        private Label lblResponsibleTitle;
        private Label lblAffectedTenantsTitle;
        private Label lblDateValue;
        private Label lblDateTitle;
        private Panel pnlUnit;
        private Label lblUnitTitle;
        private Label lblUnitValue;
        private Panel pnlDate;
        private Label lblStatusTitle;
        private Label lblStatusValue;
        private Panel pnlIssue;
        private Label lblIssueTitle;
        private Label lblIssueValue;
        private Panel pnlIssueDetailsActions;
        private Button btnCloseDetails;
        private TableLayoutPanel tlpIssueDetails;
        private Panel pnlDetailsColumn;
        private Label lblIssueDetailsHeading;
        private Panel pnlDateRow;
        private Panel pnlCompleted;
        private Label lblCompletedTitle;
        private Label lblCompletedValue;
        private Panel pnlPeopleColumn;
        private Label lblPeopleHeading;
        private DataGridView dgvAffectedTenants;
        private DataGridViewTextBoxColumn colTenantName;
        private DataGridViewTextBoxColumn colTenantRoom;
        private Panel pnlMaterials;
        private Label lblMaterialsTitle;
        private DataGridView dgvMaterials;
        private DataGridViewTextBoxColumn colMaterialName;
        private DataGridViewTextBoxColumn colMaterialQty;
    }
}