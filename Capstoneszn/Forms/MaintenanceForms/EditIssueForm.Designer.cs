namespace Capstoneszn.Forms
{
    partial class EditIssueForm
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
            pnlEditIssueHeader = new Panel();
            pnlIssueTypeInfo = new Panel();
            lblIssueTypeNote = new Label();
            lblIssueTypeValue = new Label();
            lblIssueType = new Label();
            lblEditIssueTitle = new Label();
            pnlEditIssueActions = new Panel();
            btnRepairDone = new Button();
            btnSaveIssueChanges = new Button();
            btnCancelEditIssue = new Button();
            pnlEditIssueContent = new Panel();
            tlpEditIssue = new TableLayoutPanel();
            pnlIssueDetailsColumn = new Panel();
            pnlIssueInformation = new Panel();
            txtDescription = new TextBox();
            lblIssueDate = new Label();
            dtpIssueDate = new DateTimePicker();
            lblDescription = new Label();
            txtIssue = new TextBox();
            lblIssue = new Label();
            pnlIssueStatus = new Panel();
            cboIssueStatus = new ComboBox();
            lblIssueStatus = new Label();
            pnlRoomSelection = new Panel();
            lblRoomValue = new Label();
            lblRoom = new Label();
            lblIssueDetailsHeading = new Label();
            pnlPeopleColumn = new Panel();
            pnlAffectedTenants = new Panel();
            clbAffectedTenants = new CheckedListBox();
            pnlTenantOptions = new Panel();
            pnlTenantNone = new Panel();
            rdoTenantNone = new RadioButton();
            pnlTenantSpecify = new Panel();
            rdoTenantSpecify = new RadioButton();
            pnlTenantAll = new Panel();
            rdoTenantAll = new RadioButton();
            lblTenantHint = new Label();
            lblAffectedTenants = new Label();
            pnlMaterials = new Panel();
            lblMaterialsCount = new Label();
            btnViewMaterials = new Button();
            lblMaterials = new Label();
            pnlResponsible = new Panel();
            clbResponsible = new CheckedListBox();
            pnlResponsibleOptions = new Panel();
            pnlResponsibleNone = new Panel();
            rdoResponsibleNone = new RadioButton();
            pnlResponsibleSpecify = new Panel();
            rdoResponsibleSpecify = new RadioButton();
            pnlResponsibleAll = new Panel();
            rdoResponsibleAll = new RadioButton();
            lblResponsible = new Label();
            lblPeopleHeading = new Label();
            pnlEditIssueHeader.SuspendLayout();
            pnlIssueTypeInfo.SuspendLayout();
            pnlEditIssueActions.SuspendLayout();
            pnlEditIssueContent.SuspendLayout();
            tlpEditIssue.SuspendLayout();
            pnlIssueDetailsColumn.SuspendLayout();
            pnlIssueInformation.SuspendLayout();
            pnlIssueStatus.SuspendLayout();
            pnlRoomSelection.SuspendLayout();
            pnlPeopleColumn.SuspendLayout();
            pnlAffectedTenants.SuspendLayout();
            pnlTenantOptions.SuspendLayout();
            pnlTenantNone.SuspendLayout();
            pnlTenantSpecify.SuspendLayout();
            pnlTenantAll.SuspendLayout();
            pnlMaterials.SuspendLayout();
            pnlResponsible.SuspendLayout();
            pnlResponsibleOptions.SuspendLayout();
            pnlResponsibleNone.SuspendLayout();
            pnlResponsibleSpecify.SuspendLayout();
            pnlResponsibleAll.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEditIssueHeader
            // 
            pnlEditIssueHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlEditIssueHeader.Controls.Add(pnlIssueTypeInfo);
            pnlEditIssueHeader.Controls.Add(lblEditIssueTitle);
            pnlEditIssueHeader.Dock = DockStyle.Top;
            pnlEditIssueHeader.Location = new Point(0, 0);
            pnlEditIssueHeader.Name = "pnlEditIssueHeader";
            pnlEditIssueHeader.Size = new Size(900, 60);
            pnlEditIssueHeader.TabIndex = 0;
            // 
            // pnlIssueTypeInfo
            // 
            pnlIssueTypeInfo.Controls.Add(lblIssueTypeNote);
            pnlIssueTypeInfo.Controls.Add(lblIssueTypeValue);
            pnlIssueTypeInfo.Controls.Add(lblIssueType);
            pnlIssueTypeInfo.Location = new Point(290, 9);
            pnlIssueTypeInfo.Name = "pnlIssueTypeInfo";
            pnlIssueTypeInfo.Size = new Size(380, 40);
            pnlIssueTypeInfo.TabIndex = 0;
            // 
            // lblIssueTypeNote
            // 
            lblIssueTypeNote.AutoSize = true;
            lblIssueTypeNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblIssueTypeNote.ForeColor = Color.FromArgb(170, 180, 215);
            lblIssueTypeNote.Location = new Point(165, 11);
            lblIssueTypeNote.Name = "lblIssueTypeNote";
            lblIssueTypeNote.Size = new Size(140, 20);
            lblIssueTypeNote.TabIndex = 2;
            lblIssueTypeNote.Text = "(cannot be changed)";
            // 
            // lblIssueTypeValue
            // 
            lblIssueTypeValue.AutoSize = true;
            lblIssueTypeValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIssueTypeValue.ForeColor = Color.White;
            lblIssueTypeValue.Location = new Point(70, 9);
            lblIssueTypeValue.Name = "lblIssueTypeValue";
            lblIssueTypeValue.Size = new Size(57, 23);
            lblIssueTypeValue.TabIndex = 1;
            lblIssueTypeValue.Text = "Room";
            // 
            // lblIssueType
            // 
            lblIssueType.AutoSize = true;
            lblIssueType.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueType.ForeColor = Color.FromArgb(170, 180, 215);
            lblIssueType.Location = new Point(15, 9);
            lblIssueType.Name = "lblIssueType";
            lblIssueType.Size = new Size(49, 23);
            lblIssueType.TabIndex = 0;
            lblIssueType.Text = "Type:";
            // 
            // lblEditIssueTitle
            // 
            lblEditIssueTitle.AutoSize = true;
            lblEditIssueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditIssueTitle.ForeColor = Color.White;
            lblEditIssueTitle.Location = new Point(20, 15);
            lblEditIssueTitle.Name = "lblEditIssueTitle";
            lblEditIssueTitle.Size = new Size(231, 28);
            lblEditIssueTitle.TabIndex = 40;
            lblEditIssueTitle.Text = "Edit Maintenance Issue";
            // 
            // pnlEditIssueActions
            // 
            pnlEditIssueActions.BorderStyle = BorderStyle.FixedSingle;
            pnlEditIssueActions.Controls.Add(btnRepairDone);
            pnlEditIssueActions.Controls.Add(btnSaveIssueChanges);
            pnlEditIssueActions.Controls.Add(btnCancelEditIssue);
            pnlEditIssueActions.Dock = DockStyle.Bottom;
            pnlEditIssueActions.Location = new Point(0, 556);
            pnlEditIssueActions.Name = "pnlEditIssueActions";
            pnlEditIssueActions.Size = new Size(900, 64);
            pnlEditIssueActions.TabIndex = 2;
            // 
            // btnRepairDone
            // 
            btnRepairDone.Cursor = Cursors.Hand;
            btnRepairDone.Location = new Point(20, 18);
            btnRepairDone.Name = "btnRepairDone";
            btnRepairDone.Size = new Size(120, 29);
            btnRepairDone.TabIndex = 2;
            btnRepairDone.Text = "Repair Done";
            btnRepairDone.UseVisualStyleBackColor = true;
            // 
            // btnSaveIssueChanges
            // 
            btnSaveIssueChanges.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveIssueChanges.Cursor = Cursors.Hand;
            btnSaveIssueChanges.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveIssueChanges.Location = new Point(743, 14);
            btnSaveIssueChanges.Name = "btnSaveIssueChanges";
            btnSaveIssueChanges.Size = new Size(135, 34);
            btnSaveIssueChanges.TabIndex = 1;
            btnSaveIssueChanges.Text = "Save Changes";
            btnSaveIssueChanges.UseVisualStyleBackColor = true;
            btnSaveIssueChanges.Click += btnSaveIssueChanges_Click;
            // 
            // btnCancelEditIssue
            // 
            btnCancelEditIssue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelEditIssue.Cursor = Cursors.Hand;
            btnCancelEditIssue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelEditIssue.Location = new Point(618, 14);
            btnCancelEditIssue.Name = "btnCancelEditIssue";
            btnCancelEditIssue.Size = new Size(115, 34);
            btnCancelEditIssue.TabIndex = 0;
            btnCancelEditIssue.Text = "Cancel";
            btnCancelEditIssue.UseVisualStyleBackColor = true;
            btnCancelEditIssue.Click += btnCancelEditIssue_Click;
            // 
            // pnlEditIssueContent
            // 
            pnlEditIssueContent.AutoScroll = true;
            pnlEditIssueContent.Controls.Add(tlpEditIssue);
            pnlEditIssueContent.Dock = DockStyle.Fill;
            pnlEditIssueContent.Location = new Point(0, 60);
            pnlEditIssueContent.Name = "pnlEditIssueContent";
            pnlEditIssueContent.Padding = new Padding(15);
            pnlEditIssueContent.Size = new Size(900, 496);
            pnlEditIssueContent.TabIndex = 1;
            // 
            // tlpEditIssue
            // 
            tlpEditIssue.ColumnCount = 2;
            tlpEditIssue.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpEditIssue.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpEditIssue.Controls.Add(pnlIssueDetailsColumn, 0, 0);
            tlpEditIssue.Controls.Add(pnlPeopleColumn, 1, 0);
            tlpEditIssue.Dock = DockStyle.Fill;
            tlpEditIssue.Location = new Point(15, 15);
            tlpEditIssue.Name = "tlpEditIssue";
            tlpEditIssue.RowCount = 1;
            tlpEditIssue.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpEditIssue.Size = new Size(870, 466);
            tlpEditIssue.TabIndex = 0;
            // 
            // pnlIssueDetailsColumn
            // 
            pnlIssueDetailsColumn.Controls.Add(pnlIssueInformation);
            pnlIssueDetailsColumn.Controls.Add(pnlIssueStatus);
            pnlIssueDetailsColumn.Controls.Add(pnlRoomSelection);
            pnlIssueDetailsColumn.Controls.Add(lblIssueDetailsHeading);
            pnlIssueDetailsColumn.Dock = DockStyle.Fill;
            pnlIssueDetailsColumn.Location = new Point(0, 0);
            pnlIssueDetailsColumn.Margin = new Padding(0);
            pnlIssueDetailsColumn.Name = "pnlIssueDetailsColumn";
            pnlIssueDetailsColumn.Padding = new Padding(0, 0, 15, 0);
            pnlIssueDetailsColumn.Size = new Size(435, 466);
            pnlIssueDetailsColumn.TabIndex = 0;
            // 
            // pnlIssueInformation
            // 
            pnlIssueInformation.Controls.Add(txtDescription);
            pnlIssueInformation.Controls.Add(lblIssueDate);
            pnlIssueInformation.Controls.Add(dtpIssueDate);
            pnlIssueInformation.Controls.Add(lblDescription);
            pnlIssueInformation.Controls.Add(txtIssue);
            pnlIssueInformation.Controls.Add(lblIssue);
            pnlIssueInformation.Dock = DockStyle.Fill;
            pnlIssueInformation.Location = new Point(0, 96);
            pnlIssueInformation.Name = "pnlIssueInformation";
            pnlIssueInformation.Size = new Size(420, 304);
            pnlIssueInformation.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(0, 91);
            txtDescription.MaxLength = 500;
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(420, 153);
            txtDescription.TabIndex = 3;
            // 
            // lblIssueDate
            // 
            lblIssueDate.Dock = DockStyle.Bottom;
            lblIssueDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueDate.ForeColor = Color.White;
            lblIssueDate.Location = new Point(0, 244);
            lblIssueDate.Name = "lblIssueDate";
            lblIssueDate.Size = new Size(420, 30);
            lblIssueDate.TabIndex = 4;
            lblIssueDate.Text = "Date Reported";
            lblIssueDate.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Dock = DockStyle.Bottom;
            dtpIssueDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpIssueDate.Format = DateTimePickerFormat.Short;
            dtpIssueDate.Location = new Point(0, 274);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new Size(420, 30);
            dtpIssueDate.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.Dock = DockStyle.Top;
            lblDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(0, 61);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(420, 30);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description";
            lblDescription.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtIssue
            // 
            txtIssue.Dock = DockStyle.Top;
            txtIssue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIssue.Location = new Point(0, 30);
            txtIssue.MaxLength = 150;
            txtIssue.Name = "txtIssue";
            txtIssue.Size = new Size(420, 31);
            txtIssue.TabIndex = 1;
            // 
            // lblIssue
            // 
            lblIssue.Dock = DockStyle.Top;
            lblIssue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssue.ForeColor = Color.White;
            lblIssue.Location = new Point(0, 0);
            lblIssue.Name = "lblIssue";
            lblIssue.Size = new Size(420, 30);
            lblIssue.TabIndex = 0;
            lblIssue.Text = "Issue Title";
            lblIssue.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlIssueStatus
            // 
            pnlIssueStatus.Controls.Add(cboIssueStatus);
            pnlIssueStatus.Controls.Add(lblIssueStatus);
            pnlIssueStatus.Dock = DockStyle.Bottom;
            pnlIssueStatus.Location = new Point(0, 400);
            pnlIssueStatus.Name = "pnlIssueStatus";
            pnlIssueStatus.Size = new Size(420, 66);
            pnlIssueStatus.TabIndex = 3;
            // 
            // cboIssueStatus
            // 
            cboIssueStatus.Cursor = Cursors.Hand;
            cboIssueStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIssueStatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboIssueStatus.FormattingEnabled = true;
            cboIssueStatus.Items.AddRange(new object[] { "Pending", "Complete" });
            cboIssueStatus.Location = new Point(0, 31);
            cboIssueStatus.Name = "cboIssueStatus";
            cboIssueStatus.Size = new Size(200, 31);
            cboIssueStatus.TabIndex = 1;
            // 
            // lblIssueStatus
            // 
            lblIssueStatus.Dock = DockStyle.Top;
            lblIssueStatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueStatus.ForeColor = Color.White;
            lblIssueStatus.Location = new Point(0, 0);
            lblIssueStatus.Name = "lblIssueStatus";
            lblIssueStatus.Size = new Size(420, 28);
            lblIssueStatus.TabIndex = 0;
            lblIssueStatus.Text = "Status";
            lblIssueStatus.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlRoomSelection
            // 
            pnlRoomSelection.Controls.Add(lblRoomValue);
            pnlRoomSelection.Controls.Add(lblRoom);
            pnlRoomSelection.Dock = DockStyle.Top;
            pnlRoomSelection.Location = new Point(0, 30);
            pnlRoomSelection.Name = "pnlRoomSelection";
            pnlRoomSelection.Size = new Size(420, 66);
            pnlRoomSelection.TabIndex = 1;
            // 
            // lblRoomValue
            // 
            lblRoomValue.BackColor = Color.FromArgb(45, 45, 100);
            lblRoomValue.BorderStyle = BorderStyle.FixedSingle;
            lblRoomValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomValue.ForeColor = Color.White;
            lblRoomValue.Location = new Point(0, 31);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Padding = new Padding(6, 0, 0, 0);
            lblRoomValue.Size = new Size(200, 31);
            lblRoomValue.TabIndex = 1;
            lblRoomValue.Text = "Room ###";
            lblRoomValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRoom
            // 
            lblRoom.Dock = DockStyle.Top;
            lblRoom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.ForeColor = Color.White;
            lblRoom.Location = new Point(0, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(420, 28);
            lblRoom.TabIndex = 0;
            lblRoom.Text = "Room (cannot be changed)";
            lblRoom.TextAlign = ContentAlignment.BottomLeft;
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
            pnlAffectedTenants.Controls.Add(clbAffectedTenants);
            pnlAffectedTenants.Controls.Add(pnlTenantOptions);
            pnlAffectedTenants.Controls.Add(lblTenantHint);
            pnlAffectedTenants.Controls.Add(lblAffectedTenants);
            pnlAffectedTenants.Dock = DockStyle.Fill;
            pnlAffectedTenants.Location = new Point(15, 180);
            pnlAffectedTenants.Name = "pnlAffectedTenants";
            pnlAffectedTenants.Size = new Size(420, 216);
            pnlAffectedTenants.TabIndex = 2;
            // 
            // clbAffectedTenants
            // 
            clbAffectedTenants.CheckOnClick = true;
            clbAffectedTenants.Dock = DockStyle.Fill;
            clbAffectedTenants.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clbAffectedTenants.FormattingEnabled = true;
            clbAffectedTenants.Location = new Point(0, 92);
            clbAffectedTenants.Name = "clbAffectedTenants";
            clbAffectedTenants.Size = new Size(420, 124);
            clbAffectedTenants.TabIndex = 3;
            clbAffectedTenants.Visible = false;
            // 
            // pnlTenantOptions
            // 
            pnlTenantOptions.Controls.Add(pnlTenantNone);
            pnlTenantOptions.Controls.Add(pnlTenantSpecify);
            pnlTenantOptions.Controls.Add(pnlTenantAll);
            pnlTenantOptions.Dock = DockStyle.Top;
            pnlTenantOptions.Location = new Point(0, 52);
            pnlTenantOptions.Name = "pnlTenantOptions";
            pnlTenantOptions.Size = new Size(420, 40);
            pnlTenantOptions.TabIndex = 2;
            // 
            // pnlTenantNone
            // 
            pnlTenantNone.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantNone.Controls.Add(rdoTenantNone);
            pnlTenantNone.Dock = DockStyle.Fill;
            pnlTenantNone.Location = new Point(220, 0);
            pnlTenantNone.Name = "pnlTenantNone";
            pnlTenantNone.Size = new Size(200, 40);
            pnlTenantNone.TabIndex = 2;
            // 
            // rdoTenantNone
            // 
            rdoTenantNone.AutoSize = true;
            rdoTenantNone.Cursor = Cursors.Hand;
            rdoTenantNone.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoTenantNone.ForeColor = Color.White;
            rdoTenantNone.Location = new Point(0, 7);
            rdoTenantNone.Name = "rdoTenantNone";
            rdoTenantNone.Size = new Size(73, 27);
            rdoTenantNone.TabIndex = 0;
            rdoTenantNone.TabStop = true;
            rdoTenantNone.Text = "None";
            rdoTenantNone.UseVisualStyleBackColor = true;
            // 
            // pnlTenantSpecify
            // 
            pnlTenantSpecify.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantSpecify.Controls.Add(rdoTenantSpecify);
            pnlTenantSpecify.Dock = DockStyle.Left;
            pnlTenantSpecify.Location = new Point(100, 0);
            pnlTenantSpecify.Name = "pnlTenantSpecify";
            pnlTenantSpecify.Size = new Size(120, 40);
            pnlTenantSpecify.TabIndex = 1;
            // 
            // rdoTenantSpecify
            // 
            rdoTenantSpecify.AutoSize = true;
            rdoTenantSpecify.Cursor = Cursors.Hand;
            rdoTenantSpecify.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoTenantSpecify.ForeColor = Color.White;
            rdoTenantSpecify.Location = new Point(0, 7);
            rdoTenantSpecify.Name = "rdoTenantSpecify";
            rdoTenantSpecify.Size = new Size(84, 27);
            rdoTenantSpecify.TabIndex = 0;
            rdoTenantSpecify.TabStop = true;
            rdoTenantSpecify.Text = "Specify";
            rdoTenantSpecify.UseVisualStyleBackColor = true;
            // 
            // pnlTenantAll
            // 
            pnlTenantAll.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantAll.Controls.Add(rdoTenantAll);
            pnlTenantAll.Dock = DockStyle.Left;
            pnlTenantAll.Location = new Point(0, 0);
            pnlTenantAll.Name = "pnlTenantAll";
            pnlTenantAll.Size = new Size(100, 40);
            pnlTenantAll.TabIndex = 0;
            // 
            // rdoTenantAll
            // 
            rdoTenantAll.AutoSize = true;
            rdoTenantAll.Cursor = Cursors.Hand;
            rdoTenantAll.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoTenantAll.ForeColor = Color.White;
            rdoTenantAll.Location = new Point(0, 7);
            rdoTenantAll.Name = "rdoTenantAll";
            rdoTenantAll.Size = new Size(50, 27);
            rdoTenantAll.TabIndex = 0;
            rdoTenantAll.TabStop = true;
            rdoTenantAll.Text = "All";
            rdoTenantAll.UseVisualStyleBackColor = true;
            // 
            // lblTenantHint
            // 
            lblTenantHint.Dock = DockStyle.Top;
            lblTenantHint.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantHint.ForeColor = Color.FromArgb(170, 180, 215);
            lblTenantHint.Location = new Point(0, 30);
            lblTenantHint.Name = "lblTenantHint";
            lblTenantHint.Size = new Size(420, 22);
            lblTenantHint.TabIndex = 1;
            lblTenantHint.Text = "Optional. Tenants of this room who will pay.";
            // 
            // lblAffectedTenants
            // 
            lblAffectedTenants.Dock = DockStyle.Top;
            lblAffectedTenants.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAffectedTenants.ForeColor = Color.White;
            lblAffectedTenants.Location = new Point(0, 0);
            lblAffectedTenants.Name = "lblAffectedTenants";
            lblAffectedTenants.Size = new Size(420, 30);
            lblAffectedTenants.TabIndex = 0;
            lblAffectedTenants.Text = "Affected Tenant(s)";
            lblAffectedTenants.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlMaterials
            // 
            pnlMaterials.Controls.Add(lblMaterialsCount);
            pnlMaterials.Controls.Add(btnViewMaterials);
            pnlMaterials.Controls.Add(lblMaterials);
            pnlMaterials.Dock = DockStyle.Bottom;
            pnlMaterials.Location = new Point(15, 396);
            pnlMaterials.Name = "pnlMaterials";
            pnlMaterials.Size = new Size(420, 70);
            pnlMaterials.TabIndex = 3;
            // 
            // lblMaterialsCount
            // 
            lblMaterialsCount.AutoSize = true;
            lblMaterialsCount.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialsCount.ForeColor = Color.FromArgb(170, 180, 215);
            lblMaterialsCount.Location = new Point(170, 39);
            lblMaterialsCount.Name = "lblMaterialsCount";
            lblMaterialsCount.Size = new Size(118, 20);
            lblMaterialsCount.TabIndex = 2;
            lblMaterialsCount.Text = "No materials yet";
            // 
            // btnViewMaterials
            // 
            btnViewMaterials.Cursor = Cursors.Hand;
            btnViewMaterials.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnViewMaterials.Location = new Point(0, 32);
            btnViewMaterials.Name = "btnViewMaterials";
            btnViewMaterials.Size = new Size(155, 34);
            btnViewMaterials.TabIndex = 1;
            btnViewMaterials.Text = "View Materials";
            btnViewMaterials.UseVisualStyleBackColor = true;
            btnViewMaterials.Click += btnViewMaterials_Click;
            // 
            // lblMaterials
            // 
            lblMaterials.Dock = DockStyle.Top;
            lblMaterials.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterials.ForeColor = Color.White;
            lblMaterials.Location = new Point(0, 0);
            lblMaterials.Name = "lblMaterials";
            lblMaterials.Size = new Size(420, 28);
            lblMaterials.TabIndex = 0;
            lblMaterials.Text = "Materials";
            lblMaterials.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlResponsible
            // 
            pnlResponsible.Controls.Add(clbResponsible);
            pnlResponsible.Controls.Add(pnlResponsibleOptions);
            pnlResponsible.Controls.Add(lblResponsible);
            pnlResponsible.Dock = DockStyle.Top;
            pnlResponsible.Location = new Point(15, 30);
            pnlResponsible.Name = "pnlResponsible";
            pnlResponsible.Size = new Size(420, 150);
            pnlResponsible.TabIndex = 1;
            // 
            // clbResponsible
            // 
            clbResponsible.CheckOnClick = true;
            clbResponsible.Dock = DockStyle.Fill;
            clbResponsible.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clbResponsible.FormattingEnabled = true;
            clbResponsible.Location = new Point(0, 70);
            clbResponsible.Name = "clbResponsible";
            clbResponsible.Size = new Size(420, 80);
            clbResponsible.TabIndex = 2;
            clbResponsible.Visible = false;
            // 
            // pnlResponsibleOptions
            // 
            pnlResponsibleOptions.Controls.Add(pnlResponsibleNone);
            pnlResponsibleOptions.Controls.Add(pnlResponsibleSpecify);
            pnlResponsibleOptions.Controls.Add(pnlResponsibleAll);
            pnlResponsibleOptions.Dock = DockStyle.Top;
            pnlResponsibleOptions.Location = new Point(0, 30);
            pnlResponsibleOptions.Name = "pnlResponsibleOptions";
            pnlResponsibleOptions.Size = new Size(420, 40);
            pnlResponsibleOptions.TabIndex = 1;
            // 
            // pnlResponsibleNone
            // 
            pnlResponsibleNone.BorderStyle = BorderStyle.FixedSingle;
            pnlResponsibleNone.Controls.Add(rdoResponsibleNone);
            pnlResponsibleNone.Dock = DockStyle.Fill;
            pnlResponsibleNone.Location = new Point(220, 0);
            pnlResponsibleNone.Name = "pnlResponsibleNone";
            pnlResponsibleNone.Size = new Size(200, 40);
            pnlResponsibleNone.TabIndex = 2;
            // 
            // rdoResponsibleNone
            // 
            rdoResponsibleNone.AutoSize = true;
            rdoResponsibleNone.Cursor = Cursors.Hand;
            rdoResponsibleNone.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoResponsibleNone.ForeColor = Color.White;
            rdoResponsibleNone.Location = new Point(0, 7);
            rdoResponsibleNone.Name = "rdoResponsibleNone";
            rdoResponsibleNone.Size = new Size(73, 27);
            rdoResponsibleNone.TabIndex = 0;
            rdoResponsibleNone.TabStop = true;
            rdoResponsibleNone.Text = "None";
            rdoResponsibleNone.UseVisualStyleBackColor = true;
            // 
            // pnlResponsibleSpecify
            // 
            pnlResponsibleSpecify.BorderStyle = BorderStyle.FixedSingle;
            pnlResponsibleSpecify.Controls.Add(rdoResponsibleSpecify);
            pnlResponsibleSpecify.Dock = DockStyle.Left;
            pnlResponsibleSpecify.Location = new Point(100, 0);
            pnlResponsibleSpecify.Name = "pnlResponsibleSpecify";
            pnlResponsibleSpecify.Size = new Size(120, 40);
            pnlResponsibleSpecify.TabIndex = 1;
            // 
            // rdoResponsibleSpecify
            // 
            rdoResponsibleSpecify.AutoSize = true;
            rdoResponsibleSpecify.Cursor = Cursors.Hand;
            rdoResponsibleSpecify.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoResponsibleSpecify.ForeColor = Color.White;
            rdoResponsibleSpecify.Location = new Point(0, 7);
            rdoResponsibleSpecify.Name = "rdoResponsibleSpecify";
            rdoResponsibleSpecify.Size = new Size(84, 27);
            rdoResponsibleSpecify.TabIndex = 0;
            rdoResponsibleSpecify.TabStop = true;
            rdoResponsibleSpecify.Text = "Specify";
            rdoResponsibleSpecify.UseVisualStyleBackColor = true;
            // 
            // pnlResponsibleAll
            // 
            pnlResponsibleAll.BorderStyle = BorderStyle.FixedSingle;
            pnlResponsibleAll.Controls.Add(rdoResponsibleAll);
            pnlResponsibleAll.Dock = DockStyle.Left;
            pnlResponsibleAll.Location = new Point(0, 0);
            pnlResponsibleAll.Name = "pnlResponsibleAll";
            pnlResponsibleAll.Size = new Size(100, 40);
            pnlResponsibleAll.TabIndex = 0;
            // 
            // rdoResponsibleAll
            // 
            rdoResponsibleAll.AutoSize = true;
            rdoResponsibleAll.Cursor = Cursors.Hand;
            rdoResponsibleAll.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoResponsibleAll.ForeColor = Color.White;
            rdoResponsibleAll.Location = new Point(0, 7);
            rdoResponsibleAll.Name = "rdoResponsibleAll";
            rdoResponsibleAll.Size = new Size(50, 27);
            rdoResponsibleAll.TabIndex = 0;
            rdoResponsibleAll.TabStop = true;
            rdoResponsibleAll.Text = "All";
            rdoResponsibleAll.UseVisualStyleBackColor = true;
            // 
            // lblResponsible
            // 
            lblResponsible.Dock = DockStyle.Top;
            lblResponsible.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResponsible.ForeColor = Color.White;
            lblResponsible.Location = new Point(0, 0);
            lblResponsible.Name = "lblResponsible";
            lblResponsible.Size = new Size(420, 30);
            lblResponsible.TabIndex = 0;
            lblResponsible.Text = "Responsible";
            lblResponsible.TextAlign = ContentAlignment.BottomLeft;
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
            // 
            // EditIssueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(900, 620);
            Controls.Add(pnlEditIssueContent);
            Controls.Add(pnlEditIssueActions);
            Controls.Add(pnlEditIssueHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditIssueForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Maintenance Issue";
            Load += EditIssueForm_Load;
            pnlEditIssueHeader.ResumeLayout(false);
            pnlEditIssueHeader.PerformLayout();
            pnlIssueTypeInfo.ResumeLayout(false);
            pnlIssueTypeInfo.PerformLayout();
            pnlEditIssueActions.ResumeLayout(false);
            pnlEditIssueContent.ResumeLayout(false);
            tlpEditIssue.ResumeLayout(false);
            pnlIssueDetailsColumn.ResumeLayout(false);
            pnlIssueInformation.ResumeLayout(false);
            pnlIssueInformation.PerformLayout();
            pnlIssueStatus.ResumeLayout(false);
            pnlRoomSelection.ResumeLayout(false);
            pnlPeopleColumn.ResumeLayout(false);
            pnlAffectedTenants.ResumeLayout(false);
            pnlTenantOptions.ResumeLayout(false);
            pnlTenantNone.ResumeLayout(false);
            pnlTenantNone.PerformLayout();
            pnlTenantSpecify.ResumeLayout(false);
            pnlTenantSpecify.PerformLayout();
            pnlTenantAll.ResumeLayout(false);
            pnlTenantAll.PerformLayout();
            pnlMaterials.ResumeLayout(false);
            pnlMaterials.PerformLayout();
            pnlResponsible.ResumeLayout(false);
            pnlResponsibleOptions.ResumeLayout(false);
            pnlResponsibleNone.ResumeLayout(false);
            pnlResponsibleNone.PerformLayout();
            pnlResponsibleSpecify.ResumeLayout(false);
            pnlResponsibleSpecify.PerformLayout();
            pnlResponsibleAll.ResumeLayout(false);
            pnlResponsibleAll.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEditIssueHeader;
        private Panel pnlEditIssueActions;
        private Panel pnlEditIssueContent;
        private Button btnSaveIssueChanges;
        private Button btnCancelEditIssue;
        private Label lblEditIssueTitle;
        private Panel pnlRoomSelection;
        private Label lblRoom;
        private Label lblRoomValue;
        private Panel pnlAffectedTenants;
        private Label lblAffectedTenants;
        private Panel pnlTenantOptions;
        private Panel pnlTenantSpecify;
        private RadioButton rdoTenantSpecify;
        private Panel pnlTenantNone;
        private RadioButton rdoTenantNone;
        private Panel pnlTenantAll;
        private RadioButton rdoTenantAll;
        private CheckedListBox clbAffectedTenants;
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
        private Panel pnlIssueInformation;
        private Label lblIssueDate;
        private DateTimePicker dtpIssueDate;
        private TextBox txtDescription;
        private Label lblDescription;
        private TextBox txtIssue;
        private Label lblIssue;
        private Panel pnlIssueStatus;
        private ComboBox cboIssueStatus;
        private Label lblIssueStatus;
        private Panel pnlIssueTypeInfo;
        private Label lblIssueType;
        private Label lblIssueTypeValue;
        private Label lblIssueTypeNote;
        private TableLayoutPanel tlpEditIssue;
        private Panel pnlIssueDetailsColumn;
        private Label lblIssueDetailsHeading;
        private Panel pnlPeopleColumn;
        private Label lblPeopleHeading;
        private Label lblTenantHint;
        private Panel pnlMaterials;
        private Label lblMaterials;
        private Button btnViewMaterials;
        private Label lblMaterialsCount;
        private Button btnRepairDone;
    }
}