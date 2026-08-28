namespace Capstoneszn.Forms
{
    partial class AddIssueForm
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
            pnlAddIssueHeader = new Panel();
            lblAddIssueTitle = new Label();
            pnlAddIssueActions = new Panel();
            btnAddIssue = new Button();
            btnCancelIssue = new Button();
            pnlAddIssueContent = new Panel();
            pnlMaterialsNeeded = new Panel();
            pnlMaterialsNo = new Panel();
            rdoMaterialsNo = new RadioButton();
            pnlMaterialsYes = new Panel();
            rdoMaterialsYes = new RadioButton();
            lblMaterialsNeeded = new Label();
            pnlIssueInformation = new Panel();
            lblIssueDate = new Label();
            dtpIssueDate = new DateTimePicker();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtIssue = new TextBox();
            lblIssue = new Label();
            pnlResponsible = new Panel();
            clbResponsible = new CheckedListBox();
            pnlResponsibleOptions = new Panel();
            pnlResponsibleSpecify = new Panel();
            rdoResponsibleSpecify = new RadioButton();
            pnlResponsibleNone = new Panel();
            rdoResponsibleNone = new RadioButton();
            pnlResponsibleAll = new Panel();
            rdoResponsibleAll = new RadioButton();
            lblResponsible = new Label();
            pnlAffectedTenants = new Panel();
            clbAffectedTenants = new CheckedListBox();
            pnlTenantOptions = new Panel();
            pnlTenantSpecify = new Panel();
            rdoTenantSpecify = new RadioButton();
            pnlTenantNone = new Panel();
            rdoTenantNone = new RadioButton();
            pnlTenantAll = new Panel();
            rdoTenantAll = new RadioButton();
            lblAffectedTenants = new Label();
            pnlRoomSelection = new Panel();
            cboRoom = new ComboBox();
            lblRoom = new Label();
            pnlAddIssueHeader.SuspendLayout();
            pnlAddIssueActions.SuspendLayout();
            pnlAddIssueContent.SuspendLayout();
            pnlMaterialsNeeded.SuspendLayout();
            pnlMaterialsNo.SuspendLayout();
            pnlMaterialsYes.SuspendLayout();
            pnlIssueInformation.SuspendLayout();
            pnlResponsible.SuspendLayout();
            pnlResponsibleOptions.SuspendLayout();
            pnlResponsibleSpecify.SuspendLayout();
            pnlResponsibleNone.SuspendLayout();
            pnlResponsibleAll.SuspendLayout();
            pnlAffectedTenants.SuspendLayout();
            pnlTenantOptions.SuspendLayout();
            pnlTenantSpecify.SuspendLayout();
            pnlTenantNone.SuspendLayout();
            pnlTenantAll.SuspendLayout();
            pnlRoomSelection.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAddIssueHeader
            // 
            pnlAddIssueHeader.Controls.Add(lblAddIssueTitle);
            pnlAddIssueHeader.Dock = DockStyle.Top;
            pnlAddIssueHeader.Location = new Point(0, 0);
            pnlAddIssueHeader.Name = "pnlAddIssueHeader";
            pnlAddIssueHeader.Size = new Size(482, 50);
            pnlAddIssueHeader.TabIndex = 0;
            // 
            // lblAddIssueTitle
            // 
            lblAddIssueTitle.AutoSize = true;
            lblAddIssueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddIssueTitle.ForeColor = Color.White;
            lblAddIssueTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddIssueTitle.Location = new Point(141, 9);
            lblAddIssueTitle.Name = "lblAddIssueTitle";
            lblAddIssueTitle.Size = new Size(213, 28);
            lblAddIssueTitle.TabIndex = 39;
            lblAddIssueTitle.Text = "Add Maintenance Issue";
            lblAddIssueTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblAddIssueTitle.Visible = false;
            // 
            // pnlAddIssueActions
            // 
            pnlAddIssueActions.Controls.Add(btnAddIssue);
            pnlAddIssueActions.Controls.Add(btnCancelIssue);
            pnlAddIssueActions.Dock = DockStyle.Bottom;
            pnlAddIssueActions.Location = new Point(0, 503);
            pnlAddIssueActions.Name = "pnlAddIssueActions";
            pnlAddIssueActions.Size = new Size(482, 50);
            pnlAddIssueActions.TabIndex = 1;
            // 
            // btnAddIssue
            // 
            btnAddIssue.Location = new Point(355, 11);
            btnAddIssue.Name = "btnAddIssue";
            btnAddIssue.Size = new Size(105, 29);
            btnAddIssue.TabIndex = 0;
            btnAddIssue.Text = "Add Issue";
            btnAddIssue.UseVisualStyleBackColor = true;
            // 
            // btnCancelIssue
            // 
            btnCancelIssue.Location = new Point(238, 11);
            btnCancelIssue.Name = "btnCancelIssue";
            btnCancelIssue.Size = new Size(94, 29);
            btnCancelIssue.TabIndex = 0;
            btnCancelIssue.Text = "Cancel";
            btnCancelIssue.UseVisualStyleBackColor = true;
            // 
            // pnlAddIssueContent
            // 
            pnlAddIssueContent.AutoScroll = true;
            pnlAddIssueContent.Controls.Add(pnlMaterialsNeeded);
            pnlAddIssueContent.Controls.Add(pnlIssueInformation);
            pnlAddIssueContent.Controls.Add(pnlResponsible);
            pnlAddIssueContent.Controls.Add(pnlAffectedTenants);
            pnlAddIssueContent.Controls.Add(pnlRoomSelection);
            pnlAddIssueContent.Dock = DockStyle.Fill;
            pnlAddIssueContent.Location = new Point(0, 50);
            pnlAddIssueContent.Name = "pnlAddIssueContent";
            pnlAddIssueContent.Padding = new Padding(15);
            pnlAddIssueContent.Size = new Size(482, 453);
            pnlAddIssueContent.TabIndex = 2;
            // 
            // pnlMaterialsNeeded
            // 
            pnlMaterialsNeeded.Controls.Add(pnlMaterialsNo);
            pnlMaterialsNeeded.Controls.Add(pnlMaterialsYes);
            pnlMaterialsNeeded.Controls.Add(lblMaterialsNeeded);
            pnlMaterialsNeeded.Dock = DockStyle.Top;
            pnlMaterialsNeeded.Location = new Point(15, 675);
            pnlMaterialsNeeded.Name = "pnlMaterialsNeeded";
            pnlMaterialsNeeded.Size = new Size(431, 85);
            pnlMaterialsNeeded.TabIndex = 1;
            // 
            // pnlMaterialsNo
            // 
            pnlMaterialsNo.Controls.Add(rdoMaterialsNo);
            pnlMaterialsNo.Dock = DockStyle.Right;
            pnlMaterialsNo.Location = new Point(201, 40);
            pnlMaterialsNo.Name = "pnlMaterialsNo";
            pnlMaterialsNo.Size = new Size(230, 45);
            pnlMaterialsNo.TabIndex = 57;
            // 
            // rdoMaterialsNo
            // 
            rdoMaterialsNo.AutoSize = true;
            rdoMaterialsNo.ForeColor = Color.Transparent;
            rdoMaterialsNo.Location = new Point(91, 10);
            rdoMaterialsNo.Name = "rdoMaterialsNo";
            rdoMaterialsNo.Size = new Size(50, 24);
            rdoMaterialsNo.TabIndex = 44;
            rdoMaterialsNo.TabStop = true;
            rdoMaterialsNo.Text = "No";
            rdoMaterialsNo.UseVisualStyleBackColor = true;
            // 
            // pnlMaterialsYes
            // 
            pnlMaterialsYes.Controls.Add(rdoMaterialsYes);
            pnlMaterialsYes.Dock = DockStyle.Left;
            pnlMaterialsYes.Location = new Point(0, 40);
            pnlMaterialsYes.Name = "pnlMaterialsYes";
            pnlMaterialsYes.Size = new Size(230, 45);
            pnlMaterialsYes.TabIndex = 56;
            // 
            // rdoMaterialsYes
            // 
            rdoMaterialsYes.AutoSize = true;
            rdoMaterialsYes.ForeColor = Color.Transparent;
            rdoMaterialsYes.Location = new Point(91, 10);
            rdoMaterialsYes.Name = "rdoMaterialsYes";
            rdoMaterialsYes.Size = new Size(51, 24);
            rdoMaterialsYes.TabIndex = 44;
            rdoMaterialsYes.TabStop = true;
            rdoMaterialsYes.Text = "Yes";
            rdoMaterialsYes.UseVisualStyleBackColor = true;
            // 
            // lblMaterialsNeeded
            // 
            lblMaterialsNeeded.Dock = DockStyle.Top;
            lblMaterialsNeeded.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialsNeeded.ForeColor = Color.White;
            lblMaterialsNeeded.ImageAlign = ContentAlignment.MiddleRight;
            lblMaterialsNeeded.Location = new Point(0, 0);
            lblMaterialsNeeded.Name = "lblMaterialsNeeded";
            lblMaterialsNeeded.Size = new Size(431, 40);
            lblMaterialsNeeded.TabIndex = 55;
            lblMaterialsNeeded.Text = "Materials Needed?";
            lblMaterialsNeeded.TextAlign = ContentAlignment.MiddleCenter;
            lblMaterialsNeeded.Visible = false;
            // 
            // pnlIssueInformation
            // 
            pnlIssueInformation.Controls.Add(lblIssueDate);
            pnlIssueInformation.Controls.Add(dtpIssueDate);
            pnlIssueInformation.Controls.Add(txtDescription);
            pnlIssueInformation.Controls.Add(lblDescription);
            pnlIssueInformation.Controls.Add(txtIssue);
            pnlIssueInformation.Controls.Add(lblIssue);
            pnlIssueInformation.Dock = DockStyle.Top;
            pnlIssueInformation.Location = new Point(15, 405);
            pnlIssueInformation.Name = "pnlIssueInformation";
            pnlIssueInformation.Size = new Size(431, 270);
            pnlIssueInformation.TabIndex = 3;
            // 
            // lblIssueDate
            // 
            lblIssueDate.Dock = DockStyle.Bottom;
            lblIssueDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueDate.ForeColor = Color.White;
            lblIssueDate.ImageAlign = ContentAlignment.MiddleRight;
            lblIssueDate.Location = new Point(0, 203);
            lblIssueDate.Name = "lblIssueDate";
            lblIssueDate.Size = new Size(431, 40);
            lblIssueDate.TabIndex = 54;
            lblIssueDate.Text = "Date";
            lblIssueDate.TextAlign = ContentAlignment.MiddleCenter;
            lblIssueDate.Visible = false;
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Dock = DockStyle.Bottom;
            dtpIssueDate.Format = DateTimePickerFormat.Short;
            dtpIssueDate.Location = new Point(0, 243);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new Size(431, 27);
            dtpIssueDate.TabIndex = 53;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Location = new Point(0, 114);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(431, 156);
            txtDescription.TabIndex = 51;
            // 
            // lblDescription
            // 
            lblDescription.Dock = DockStyle.Top;
            lblDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.White;
            lblDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblDescription.Location = new Point(0, 74);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(431, 40);
            lblDescription.TabIndex = 51;
            lblDescription.Text = "Description";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            lblDescription.Visible = false;
            // 
            // txtIssue
            // 
            txtIssue.Dock = DockStyle.Top;
            txtIssue.Location = new Point(0, 40);
            txtIssue.Multiline = true;
            txtIssue.Name = "txtIssue";
            txtIssue.Size = new Size(431, 34);
            txtIssue.TabIndex = 49;
            // 
            // lblIssue
            // 
            lblIssue.Dock = DockStyle.Top;
            lblIssue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssue.ForeColor = Color.White;
            lblIssue.ImageAlign = ContentAlignment.MiddleRight;
            lblIssue.Location = new Point(0, 0);
            lblIssue.Name = "lblIssue";
            lblIssue.Size = new Size(431, 40);
            lblIssue.TabIndex = 48;
            lblIssue.Text = "Issue";
            lblIssue.TextAlign = ContentAlignment.MiddleCenter;
            lblIssue.Visible = false;
            // 
            // pnlResponsible
            // 
            pnlResponsible.Controls.Add(clbResponsible);
            pnlResponsible.Controls.Add(pnlResponsibleOptions);
            pnlResponsible.Controls.Add(lblResponsible);
            pnlResponsible.Dock = DockStyle.Top;
            pnlResponsible.Location = new Point(15, 235);
            pnlResponsible.Name = "pnlResponsible";
            pnlResponsible.Size = new Size(431, 170);
            pnlResponsible.TabIndex = 2;
            // 
            // clbResponsible
            // 
            clbResponsible.CheckOnClick = true;
            clbResponsible.Dock = DockStyle.Fill;
            clbResponsible.FormattingEnabled = true;
            clbResponsible.Location = new Point(0, 85);
            clbResponsible.Name = "clbResponsible";
            clbResponsible.Size = new Size(431, 85);
            clbResponsible.TabIndex = 49;
            clbResponsible.Visible = false;
            // 
            // pnlResponsibleOptions
            // 
            pnlResponsibleOptions.Controls.Add(pnlResponsibleSpecify);
            pnlResponsibleOptions.Controls.Add(pnlResponsibleNone);
            pnlResponsibleOptions.Controls.Add(pnlResponsibleAll);
            pnlResponsibleOptions.Dock = DockStyle.Top;
            pnlResponsibleOptions.Location = new Point(0, 40);
            pnlResponsibleOptions.Name = "pnlResponsibleOptions";
            pnlResponsibleOptions.Size = new Size(431, 45);
            pnlResponsibleOptions.TabIndex = 48;
            // 
            // pnlResponsibleSpecify
            // 
            pnlResponsibleSpecify.Controls.Add(rdoResponsibleSpecify);
            pnlResponsibleSpecify.Dock = DockStyle.Fill;
            pnlResponsibleSpecify.Location = new Point(150, 0);
            pnlResponsibleSpecify.Name = "pnlResponsibleSpecify";
            pnlResponsibleSpecify.Size = new Size(131, 45);
            pnlResponsibleSpecify.TabIndex = 2;
            // 
            // rdoResponsibleSpecify
            // 
            rdoResponsibleSpecify.AutoSize = true;
            rdoResponsibleSpecify.ForeColor = Color.Transparent;
            rdoResponsibleSpecify.Location = new Point(52, 10);
            rdoResponsibleSpecify.Name = "rdoResponsibleSpecify";
            rdoResponsibleSpecify.Size = new Size(78, 24);
            rdoResponsibleSpecify.TabIndex = 3;
            rdoResponsibleSpecify.TabStop = true;
            rdoResponsibleSpecify.Text = "Specify";
            rdoResponsibleSpecify.UseVisualStyleBackColor = true;
            // 
            // pnlResponsibleNone
            // 
            pnlResponsibleNone.Controls.Add(rdoResponsibleNone);
            pnlResponsibleNone.Dock = DockStyle.Right;
            pnlResponsibleNone.Location = new Point(281, 0);
            pnlResponsibleNone.Name = "pnlResponsibleNone";
            pnlResponsibleNone.Size = new Size(150, 45);
            pnlResponsibleNone.TabIndex = 1;
            // 
            // rdoResponsibleNone
            // 
            rdoResponsibleNone.AutoSize = true;
            rdoResponsibleNone.ForeColor = Color.Transparent;
            rdoResponsibleNone.Location = new Point(42, 10);
            rdoResponsibleNone.Name = "rdoResponsibleNone";
            rdoResponsibleNone.Size = new Size(66, 24);
            rdoResponsibleNone.TabIndex = 4;
            rdoResponsibleNone.TabStop = true;
            rdoResponsibleNone.Text = "None";
            rdoResponsibleNone.UseVisualStyleBackColor = true;
            // 
            // pnlResponsibleAll
            // 
            pnlResponsibleAll.Controls.Add(rdoResponsibleAll);
            pnlResponsibleAll.Dock = DockStyle.Left;
            pnlResponsibleAll.Location = new Point(0, 0);
            pnlResponsibleAll.Name = "pnlResponsibleAll";
            pnlResponsibleAll.Size = new Size(150, 45);
            pnlResponsibleAll.TabIndex = 0;
            // 
            // rdoResponsibleAll
            // 
            rdoResponsibleAll.AutoSize = true;
            rdoResponsibleAll.ForeColor = Color.Transparent;
            rdoResponsibleAll.Location = new Point(51, 10);
            rdoResponsibleAll.Name = "rdoResponsibleAll";
            rdoResponsibleAll.Size = new Size(48, 24);
            rdoResponsibleAll.TabIndex = 43;
            rdoResponsibleAll.TabStop = true;
            rdoResponsibleAll.Text = "All";
            rdoResponsibleAll.UseVisualStyleBackColor = true;
            // 
            // lblResponsible
            // 
            lblResponsible.Dock = DockStyle.Top;
            lblResponsible.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResponsible.ForeColor = Color.White;
            lblResponsible.ImageAlign = ContentAlignment.MiddleRight;
            lblResponsible.Location = new Point(0, 0);
            lblResponsible.Name = "lblResponsible";
            lblResponsible.Size = new Size(431, 40);
            lblResponsible.TabIndex = 47;
            lblResponsible.Text = "Responsible";
            lblResponsible.TextAlign = ContentAlignment.MiddleCenter;
            lblResponsible.Visible = false;
            // 
            // pnlAffectedTenants
            // 
            pnlAffectedTenants.Controls.Add(clbAffectedTenants);
            pnlAffectedTenants.Controls.Add(pnlTenantOptions);
            pnlAffectedTenants.Controls.Add(lblAffectedTenants);
            pnlAffectedTenants.Dock = DockStyle.Top;
            pnlAffectedTenants.Location = new Point(15, 65);
            pnlAffectedTenants.Name = "pnlAffectedTenants";
            pnlAffectedTenants.Size = new Size(431, 170);
            pnlAffectedTenants.TabIndex = 1;
            // 
            // clbAffectedTenants
            // 
            clbAffectedTenants.CheckOnClick = true;
            clbAffectedTenants.Dock = DockStyle.Fill;
            clbAffectedTenants.FormattingEnabled = true;
            clbAffectedTenants.Location = new Point(0, 85);
            clbAffectedTenants.Name = "clbAffectedTenants";
            clbAffectedTenants.Size = new Size(431, 85);
            clbAffectedTenants.TabIndex = 46;
            clbAffectedTenants.Visible = false;
            // 
            // pnlTenantOptions
            // 
            pnlTenantOptions.Controls.Add(pnlTenantSpecify);
            pnlTenantOptions.Controls.Add(pnlTenantNone);
            pnlTenantOptions.Controls.Add(pnlTenantAll);
            pnlTenantOptions.Dock = DockStyle.Top;
            pnlTenantOptions.Location = new Point(0, 40);
            pnlTenantOptions.Name = "pnlTenantOptions";
            pnlTenantOptions.Size = new Size(431, 45);
            pnlTenantOptions.TabIndex = 44;
            // 
            // pnlTenantSpecify
            // 
            pnlTenantSpecify.Controls.Add(rdoTenantSpecify);
            pnlTenantSpecify.Dock = DockStyle.Fill;
            pnlTenantSpecify.Location = new Point(150, 0);
            pnlTenantSpecify.Name = "pnlTenantSpecify";
            pnlTenantSpecify.Size = new Size(131, 45);
            pnlTenantSpecify.TabIndex = 2;
            // 
            // rdoTenantSpecify
            // 
            rdoTenantSpecify.AutoSize = true;
            rdoTenantSpecify.ForeColor = Color.Transparent;
            rdoTenantSpecify.Location = new Point(53, 10);
            rdoTenantSpecify.Name = "rdoTenantSpecify";
            rdoTenantSpecify.Size = new Size(78, 24);
            rdoTenantSpecify.TabIndex = 1;
            rdoTenantSpecify.TabStop = true;
            rdoTenantSpecify.Text = "Specify";
            rdoTenantSpecify.UseVisualStyleBackColor = true;
            // 
            // pnlTenantNone
            // 
            pnlTenantNone.Controls.Add(rdoTenantNone);
            pnlTenantNone.Dock = DockStyle.Right;
            pnlTenantNone.Location = new Point(281, 0);
            pnlTenantNone.Name = "pnlTenantNone";
            pnlTenantNone.Size = new Size(150, 45);
            pnlTenantNone.TabIndex = 1;
            // 
            // rdoTenantNone
            // 
            rdoTenantNone.AutoSize = true;
            rdoTenantNone.ForeColor = Color.Transparent;
            rdoTenantNone.Location = new Point(39, 10);
            rdoTenantNone.Name = "rdoTenantNone";
            rdoTenantNone.Size = new Size(66, 24);
            rdoTenantNone.TabIndex = 2;
            rdoTenantNone.TabStop = true;
            rdoTenantNone.Text = "None";
            rdoTenantNone.UseVisualStyleBackColor = true;
            // 
            // pnlTenantAll
            // 
            pnlTenantAll.Controls.Add(rdoTenantAll);
            pnlTenantAll.Dock = DockStyle.Left;
            pnlTenantAll.Location = new Point(0, 0);
            pnlTenantAll.Name = "pnlTenantAll";
            pnlTenantAll.Size = new Size(150, 45);
            pnlTenantAll.TabIndex = 0;
            // 
            // rdoTenantAll
            // 
            rdoTenantAll.AutoSize = true;
            rdoTenantAll.ForeColor = Color.Transparent;
            rdoTenantAll.Location = new Point(46, 10);
            rdoTenantAll.Name = "rdoTenantAll";
            rdoTenantAll.Size = new Size(48, 24);
            rdoTenantAll.TabIndex = 41;
            rdoTenantAll.TabStop = true;
            rdoTenantAll.Text = "All";
            rdoTenantAll.UseVisualStyleBackColor = true;
            // 
            // lblAffectedTenants
            // 
            lblAffectedTenants.Dock = DockStyle.Top;
            lblAffectedTenants.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAffectedTenants.ForeColor = Color.White;
            lblAffectedTenants.ImageAlign = ContentAlignment.MiddleRight;
            lblAffectedTenants.Location = new Point(0, 0);
            lblAffectedTenants.Name = "lblAffectedTenants";
            lblAffectedTenants.Size = new Size(431, 40);
            lblAffectedTenants.TabIndex = 43;
            lblAffectedTenants.Text = "Affected Tenant(s)";
            lblAffectedTenants.TextAlign = ContentAlignment.MiddleCenter;
            lblAffectedTenants.Visible = false;
            // 
            // pnlRoomSelection
            // 
            pnlRoomSelection.Controls.Add(cboRoom);
            pnlRoomSelection.Controls.Add(lblRoom);
            pnlRoomSelection.Dock = DockStyle.Top;
            pnlRoomSelection.Location = new Point(15, 15);
            pnlRoomSelection.Name = "pnlRoomSelection";
            pnlRoomSelection.Size = new Size(431, 50);
            pnlRoomSelection.TabIndex = 0;
            // 
            // cboRoom
            // 
            cboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new Point(202, 11);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new Size(200, 28);
            cboRoom.TabIndex = 40;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.ForeColor = Color.White;
            lblRoom.ImageAlign = ContentAlignment.MiddleRight;
            lblRoom.Location = new Point(134, 13);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(60, 25);
            lblRoom.TabIndex = 39;
            lblRoom.Text = "Room";
            lblRoom.TextAlign = ContentAlignment.MiddleCenter;
            lblRoom.Visible = false;
            // 
            // AddIssueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 553);
            Controls.Add(pnlAddIssueContent);
            Controls.Add(pnlAddIssueActions);
            Controls.Add(pnlAddIssueHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddIssueForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Maintenance Issue";
            Load += AddIssueForm_Load;
            pnlAddIssueHeader.ResumeLayout(false);
            pnlAddIssueHeader.PerformLayout();
            pnlAddIssueActions.ResumeLayout(false);
            pnlAddIssueContent.ResumeLayout(false);
            pnlMaterialsNeeded.ResumeLayout(false);
            pnlMaterialsNo.ResumeLayout(false);
            pnlMaterialsNo.PerformLayout();
            pnlMaterialsYes.ResumeLayout(false);
            pnlMaterialsYes.PerformLayout();
            pnlIssueInformation.ResumeLayout(false);
            pnlIssueInformation.PerformLayout();
            pnlResponsible.ResumeLayout(false);
            pnlResponsibleOptions.ResumeLayout(false);
            pnlResponsibleSpecify.ResumeLayout(false);
            pnlResponsibleSpecify.PerformLayout();
            pnlResponsibleNone.ResumeLayout(false);
            pnlResponsibleNone.PerformLayout();
            pnlResponsibleAll.ResumeLayout(false);
            pnlResponsibleAll.PerformLayout();
            pnlAffectedTenants.ResumeLayout(false);
            pnlTenantOptions.ResumeLayout(false);
            pnlTenantSpecify.ResumeLayout(false);
            pnlTenantSpecify.PerformLayout();
            pnlTenantNone.ResumeLayout(false);
            pnlTenantNone.PerformLayout();
            pnlTenantAll.ResumeLayout(false);
            pnlTenantAll.PerformLayout();
            pnlRoomSelection.ResumeLayout(false);
            pnlRoomSelection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAddIssueHeader;
        private Panel pnlAddIssueActions;
        private Panel pnlAddIssueContent;
        private Label lblAddIssueTitle;
        private Panel pnlRoomSelection;
        private ComboBox cboRoom;
        private Label lblRoom;
        private Panel pnlAffectedTenants;
        private CheckedListBox clbAffectedTenants;
        private Panel pnlTenantOptions;
        private RadioButton rdoTenantAll;
        private RadioButton rdoTenantSpecify;
        private RadioButton rdoTenantNone;
        private Label lblAffectedTenants;
        private Panel pnlTenantSpecify;
        private Panel pnlTenantNone;
        private Panel pnlTenantAll;
        private Panel pnlResponsible;
        private CheckedListBox clbResponsible;
        private Panel pnlResponsibleOptions;
        private Panel pnlResponsibleSpecify;
        private RadioButton rdoResponsibleSpecify;
        private Panel pnlResponsibleNone;
        private RadioButton rdoResponsibleNone;
        private Panel pnlResponsibleAll;
        private RadioButton rdoResponsibleAll;
        private Label lblResponsible;
        private Button btnAddIssue;
        private Button btnCancelIssue;
        private Panel pnlMaterialsNeeded;
        private Panel pnlIssueInformation;
        private Label lblIssue;
        private TextBox txtIssue;
        private TextBox txtDescription;
        private Label lblDescription;
        private DateTimePicker dtpIssueDate;
        private Panel pnlMaterialsNo;
        private RadioButton rdoMaterialsNo;
        private Panel pnlMaterialsYes;
        private RadioButton rdoMaterialsYes;
        private Label lblMaterialsNeeded;
        private Label lblIssueDate;
    }
}