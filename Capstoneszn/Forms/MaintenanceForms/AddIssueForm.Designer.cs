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
        ///
        /// NEW (Nov 21) - Add Issue redesign, Option A:
        ///   - Description removed (done earlier); the column it left behind is
        ///     reclaimed instead of being left as dead space.
        ///   - "Materials Needed?" moved into ISSUE DETAILS, because it describes
        ///     the issue, not the people. The right heading is now just PEOPLE.
        ///   - The six radio panels lost BorderStyle.FixedSingle. They are KEPT as
        ///     separate panels on purpose: RadioGroupHelper.Link in AddIssueForm.cs
        ///     depends on them not being natively grouped. Merging them into one
        ///     container would group them twice. Not worth the risk before the
        ///     defense.
        ///   - Every section is sized to its content, so both columns end at the
        ///     same height and nothing is cut off.
        ///   - ClientSize 900 x 548  ->  880 x 470.
        ///   - pnlAddIssueContent is now Dock.Fill instead of a fixed Location/Size.
        private void InitializeComponent()
        {
            pnlAddIssueHeader = new Panel();
            pnlIssueType = new Panel();
            rdoIssueTypeBuilding = new RadioButton();
            rdoIssueTypeRoom = new RadioButton();
            lblIssueType = new Label();
            lblAddIssueTitle = new Label();
            pnlAddIssueActions = new Panel();
            btnAddIssue = new Button();
            btnCancelIssue = new Button();
            pnlAddIssueContent = new Panel();
            tlpAddIssue = new TableLayoutPanel();
            pnlIssueDetailsColumn = new Panel();
            pnlIssueInformation = new Panel();
            dtpIssueDate = new DateTimePicker();
            pnlMaterialsNeeded = new Panel();
            pnlMaterialsNo = new Panel();
            rdoMaterialsNo = new RadioButton();
            pnlMaterialsYes = new Panel();
            rdoMaterialsYes = new RadioButton();
            lblMaterialsNeeded = new Label();
            lblIssueDate = new Label();
            txtIssue = new TextBox();
            lblIssue = new Label();
            pnlRoomSelection = new Panel();
            cboRoom = new ComboBox();
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
            lblPeopleHeading = new Label();
            pnlAddIssueHeader.SuspendLayout();
            pnlIssueType.SuspendLayout();
            pnlAddIssueActions.SuspendLayout();
            pnlAddIssueContent.SuspendLayout();
            tlpAddIssue.SuspendLayout();
            pnlIssueDetailsColumn.SuspendLayout();
            pnlIssueInformation.SuspendLayout();
            pnlMaterialsNeeded.SuspendLayout();
            pnlMaterialsNo.SuspendLayout();
            pnlMaterialsYes.SuspendLayout();
            pnlRoomSelection.SuspendLayout();
            pnlPeopleColumn.SuspendLayout();
            pnlAffectedTenants.SuspendLayout();
            pnlTenantOptions.SuspendLayout();
            pnlTenantNone.SuspendLayout();
            pnlTenantSpecify.SuspendLayout();
            pnlTenantAll.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAddIssueHeader
            // 
            pnlAddIssueHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlAddIssueHeader.Controls.Add(pnlIssueType);
            pnlAddIssueHeader.Controls.Add(lblAddIssueTitle);
            pnlAddIssueHeader.Dock = DockStyle.Top;
            pnlAddIssueHeader.Location = new Point(0, 0);
            pnlAddIssueHeader.Name = "pnlAddIssueHeader";
            pnlAddIssueHeader.Size = new Size(880, 60);
            pnlAddIssueHeader.TabIndex = 0;
            // 
            // pnlIssueType
            // 
            pnlIssueType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlIssueType.Controls.Add(rdoIssueTypeBuilding);
            pnlIssueType.Controls.Add(rdoIssueTypeRoom);
            pnlIssueType.Controls.Add(lblIssueType);
            pnlIssueType.Location = new Point(518, 9);
            pnlIssueType.Name = "pnlIssueType";
            pnlIssueType.Size = new Size(330, 40);
            pnlIssueType.TabIndex = 0;
            // 
            // rdoIssueTypeBuilding
            // 
            rdoIssueTypeBuilding.AutoSize = true;
            rdoIssueTypeBuilding.Cursor = Cursors.Hand;
            rdoIssueTypeBuilding.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoIssueTypeBuilding.ForeColor = Color.White;
            rdoIssueTypeBuilding.Location = new Point(170, 7);
            rdoIssueTypeBuilding.Name = "rdoIssueTypeBuilding";
            rdoIssueTypeBuilding.Size = new Size(93, 27);
            rdoIssueTypeBuilding.TabIndex = 2;
            rdoIssueTypeBuilding.Text = "Building";
            rdoIssueTypeBuilding.UseVisualStyleBackColor = true;
            // 
            // rdoIssueTypeRoom
            // 
            rdoIssueTypeRoom.AutoSize = true;
            rdoIssueTypeRoom.Checked = true;
            rdoIssueTypeRoom.Cursor = Cursors.Hand;
            rdoIssueTypeRoom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoIssueTypeRoom.ForeColor = Color.White;
            rdoIssueTypeRoom.Location = new Point(75, 7);
            rdoIssueTypeRoom.Name = "rdoIssueTypeRoom";
            rdoIssueTypeRoom.Size = new Size(76, 27);
            rdoIssueTypeRoom.TabIndex = 1;
            rdoIssueTypeRoom.TabStop = true;
            rdoIssueTypeRoom.Text = "Room";
            rdoIssueTypeRoom.UseVisualStyleBackColor = true;
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
            // lblAddIssueTitle
            // 
            lblAddIssueTitle.AutoSize = true;
            lblAddIssueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddIssueTitle.ForeColor = Color.White;
            lblAddIssueTitle.Location = new Point(20, 15);
            lblAddIssueTitle.Name = "lblAddIssueTitle";
            lblAddIssueTitle.Size = new Size(232, 28);
            lblAddIssueTitle.TabIndex = 39;
            lblAddIssueTitle.Text = "Add Maintenance Issue";
            // 
            // pnlAddIssueActions
            // 
            pnlAddIssueActions.BorderStyle = BorderStyle.FixedSingle;
            pnlAddIssueActions.Controls.Add(btnAddIssue);
            pnlAddIssueActions.Controls.Add(btnCancelIssue);
            pnlAddIssueActions.Dock = DockStyle.Bottom;
            pnlAddIssueActions.Location = new Point(0, 403);
            pnlAddIssueActions.Name = "pnlAddIssueActions";
            pnlAddIssueActions.Size = new Size(880, 61);
            pnlAddIssueActions.TabIndex = 2;
            // 
            // btnAddIssue
            // 
            btnAddIssue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddIssue.Cursor = Cursors.Hand;
            btnAddIssue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddIssue.Location = new Point(743, 14);
            btnAddIssue.Name = "btnAddIssue";
            btnAddIssue.Size = new Size(115, 34);
            btnAddIssue.TabIndex = 1;
            btnAddIssue.Text = "Add Issue";
            btnAddIssue.UseVisualStyleBackColor = true;
            btnAddIssue.Click += btnAddIssue_Click;
            // 
            // btnCancelIssue
            // 
            btnCancelIssue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelIssue.Cursor = Cursors.Hand;
            btnCancelIssue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelIssue.Location = new Point(618, 14);
            btnCancelIssue.Name = "btnCancelIssue";
            btnCancelIssue.Size = new Size(115, 34);
            btnCancelIssue.TabIndex = 0;
            btnCancelIssue.Text = "Cancel";
            btnCancelIssue.UseVisualStyleBackColor = true;
            btnCancelIssue.Click += btnCancelIssue_Click;
            // 
            // pnlAddIssueContent
            // 
            pnlAddIssueContent.AutoScroll = true;
            pnlAddIssueContent.Controls.Add(tlpAddIssue);
            pnlAddIssueContent.Dock = DockStyle.Top;
            pnlAddIssueContent.Location = new Point(0, 60);
            pnlAddIssueContent.Name = "pnlAddIssueContent";
            pnlAddIssueContent.Padding = new Padding(15);
            pnlAddIssueContent.Size = new Size(880, 341);
            pnlAddIssueContent.TabIndex = 1;
            // 
            // tlpAddIssue
            // 
            tlpAddIssue.ColumnCount = 2;
            tlpAddIssue.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpAddIssue.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpAddIssue.Controls.Add(pnlIssueDetailsColumn, 0, 0);
            tlpAddIssue.Controls.Add(pnlPeopleColumn, 1, 0);
            tlpAddIssue.Dock = DockStyle.Fill;
            tlpAddIssue.Location = new Point(15, 15);
            tlpAddIssue.Name = "tlpAddIssue";
            tlpAddIssue.RowCount = 1;
            tlpAddIssue.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpAddIssue.Size = new Size(850, 311);
            tlpAddIssue.TabIndex = 0;
            // 
            // pnlIssueDetailsColumn
            // 
            pnlIssueDetailsColumn.Controls.Add(pnlIssueInformation);
            pnlIssueDetailsColumn.Controls.Add(pnlRoomSelection);
            pnlIssueDetailsColumn.Controls.Add(lblIssueDetailsHeading);
            pnlIssueDetailsColumn.Dock = DockStyle.Fill;
            pnlIssueDetailsColumn.Location = new Point(0, 0);
            pnlIssueDetailsColumn.Margin = new Padding(0);
            pnlIssueDetailsColumn.Name = "pnlIssueDetailsColumn";
            pnlIssueDetailsColumn.Padding = new Padding(0, 0, 15, 0);
            pnlIssueDetailsColumn.Size = new Size(425, 311);
            pnlIssueDetailsColumn.TabIndex = 0;
            // 
            // pnlIssueInformation
            // 
            pnlIssueInformation.Controls.Add(dtpIssueDate);
            pnlIssueInformation.Controls.Add(pnlMaterialsNeeded);
            pnlIssueInformation.Controls.Add(lblIssueDate);
            pnlIssueInformation.Controls.Add(txtIssue);
            pnlIssueInformation.Controls.Add(lblIssue);
            pnlIssueInformation.Dock = DockStyle.Top;
            pnlIssueInformation.Location = new Point(0, 90);
            pnlIssueInformation.Name = "pnlIssueInformation";
            pnlIssueInformation.Size = new Size(410, 219);
            pnlIssueInformation.TabIndex = 2;
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpIssueDate.Format = DateTimePickerFormat.Short;
            dtpIssueDate.Location = new Point(3, 107);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new Size(170, 30);
            dtpIssueDate.TabIndex = 5;
            // 
            // pnlMaterialsNeeded
            // 
            pnlMaterialsNeeded.Controls.Add(pnlMaterialsNo);
            pnlMaterialsNeeded.Controls.Add(pnlMaterialsYes);
            pnlMaterialsNeeded.Controls.Add(lblMaterialsNeeded);
            pnlMaterialsNeeded.Location = new Point(0, 146);
            pnlMaterialsNeeded.Name = "pnlMaterialsNeeded";
            pnlMaterialsNeeded.Size = new Size(410, 65);
            pnlMaterialsNeeded.TabIndex = 3;
            // 
            // pnlMaterialsNo
            // 
            pnlMaterialsNo.Controls.Add(rdoMaterialsNo);
            pnlMaterialsNo.Dock = DockStyle.Fill;
            pnlMaterialsNo.Location = new Point(100, 30);
            pnlMaterialsNo.Name = "pnlMaterialsNo";
            pnlMaterialsNo.Size = new Size(310, 35);
            pnlMaterialsNo.TabIndex = 2;
            // 
            // rdoMaterialsNo
            // 
            rdoMaterialsNo.AutoSize = true;
            rdoMaterialsNo.Cursor = Cursors.Hand;
            rdoMaterialsNo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoMaterialsNo.ForeColor = Color.White;
            rdoMaterialsNo.Location = new Point(0, 7);
            rdoMaterialsNo.Name = "rdoMaterialsNo";
            rdoMaterialsNo.Size = new Size(54, 27);
            rdoMaterialsNo.TabIndex = 0;
            rdoMaterialsNo.TabStop = true;
            rdoMaterialsNo.Text = "No";
            rdoMaterialsNo.UseVisualStyleBackColor = true;
            // 
            // pnlMaterialsYes
            // 
            pnlMaterialsYes.Controls.Add(rdoMaterialsYes);
            pnlMaterialsYes.Dock = DockStyle.Left;
            pnlMaterialsYes.Location = new Point(0, 30);
            pnlMaterialsYes.Name = "pnlMaterialsYes";
            pnlMaterialsYes.Size = new Size(100, 35);
            pnlMaterialsYes.TabIndex = 1;
            // 
            // rdoMaterialsYes
            // 
            rdoMaterialsYes.AutoSize = true;
            rdoMaterialsYes.Cursor = Cursors.Hand;
            rdoMaterialsYes.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rdoMaterialsYes.ForeColor = Color.White;
            rdoMaterialsYes.Location = new Point(0, 7);
            rdoMaterialsYes.Name = "rdoMaterialsYes";
            rdoMaterialsYes.Size = new Size(55, 27);
            rdoMaterialsYes.TabIndex = 0;
            rdoMaterialsYes.TabStop = true;
            rdoMaterialsYes.Text = "Yes";
            rdoMaterialsYes.UseVisualStyleBackColor = true;
            // 
            // lblMaterialsNeeded
            // 
            lblMaterialsNeeded.Dock = DockStyle.Top;
            lblMaterialsNeeded.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialsNeeded.ForeColor = Color.White;
            lblMaterialsNeeded.Location = new Point(0, 0);
            lblMaterialsNeeded.Name = "lblMaterialsNeeded";
            lblMaterialsNeeded.Size = new Size(410, 30);
            lblMaterialsNeeded.TabIndex = 0;
            lblMaterialsNeeded.Text = "Materials Needed?";
            lblMaterialsNeeded.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblIssueDate
            // 
            lblIssueDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueDate.ForeColor = Color.White;
            lblIssueDate.Location = new Point(0, 76);
            lblIssueDate.Name = "lblIssueDate";
            lblIssueDate.Size = new Size(420, 30);
            lblIssueDate.TabIndex = 4;
            lblIssueDate.Text = "Date Reported";
            lblIssueDate.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtIssue
            // 
            txtIssue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIssue.Location = new Point(3, 33);
            txtIssue.MaxLength = 150;
            txtIssue.Name = "txtIssue";
            txtIssue.Size = new Size(414, 31);
            txtIssue.TabIndex = 1;
            // 
            // lblIssue
            // 
            lblIssue.Dock = DockStyle.Top;
            lblIssue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssue.ForeColor = Color.White;
            lblIssue.Location = new Point(0, 0);
            lblIssue.Name = "lblIssue";
            lblIssue.Size = new Size(410, 30);
            lblIssue.TabIndex = 0;
            lblIssue.Text = "Issue Title";
            lblIssue.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlRoomSelection
            // 
            pnlRoomSelection.Controls.Add(cboRoom);
            pnlRoomSelection.Controls.Add(lblRoom);
            pnlRoomSelection.Dock = DockStyle.Top;
            pnlRoomSelection.Location = new Point(0, 30);
            pnlRoomSelection.Name = "pnlRoomSelection";
            pnlRoomSelection.Size = new Size(410, 60);
            pnlRoomSelection.TabIndex = 1;
            // 
            // cboRoom
            // 
            cboRoom.Cursor = Cursors.Hand;
            cboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new Point(0, 31);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new Size(200, 31);
            cboRoom.TabIndex = 1;
            // 
            // lblRoom
            // 
            lblRoom.Dock = DockStyle.Top;
            lblRoom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.ForeColor = Color.White;
            lblRoom.Location = new Point(0, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(410, 28);
            lblRoom.TabIndex = 0;
            lblRoom.Text = "Room";
            lblRoom.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblIssueDetailsHeading
            // 
            lblIssueDetailsHeading.Dock = DockStyle.Top;
            lblIssueDetailsHeading.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIssueDetailsHeading.ForeColor = Color.FromArgb(170, 180, 215);
            lblIssueDetailsHeading.Location = new Point(0, 0);
            lblIssueDetailsHeading.Name = "lblIssueDetailsHeading";
            lblIssueDetailsHeading.Size = new Size(410, 30);
            lblIssueDetailsHeading.TabIndex = 0;
            lblIssueDetailsHeading.Text = "ISSUE DETAILS";
            // 
            // pnlPeopleColumn
            // 
            pnlPeopleColumn.Controls.Add(pnlAffectedTenants);
            pnlPeopleColumn.Controls.Add(lblPeopleHeading);
            pnlPeopleColumn.Dock = DockStyle.Fill;
            pnlPeopleColumn.Location = new Point(425, 0);
            pnlPeopleColumn.Margin = new Padding(0);
            pnlPeopleColumn.Name = "pnlPeopleColumn";
            pnlPeopleColumn.Padding = new Padding(15, 0, 0, 0);
            pnlPeopleColumn.Size = new Size(425, 311);
            pnlPeopleColumn.TabIndex = 1;
            // 
            // pnlAffectedTenants
            // 
            pnlAffectedTenants.Controls.Add(clbAffectedTenants);
            pnlAffectedTenants.Controls.Add(pnlTenantOptions);
            pnlAffectedTenants.Controls.Add(lblTenantHint);
            pnlAffectedTenants.Controls.Add(lblAffectedTenants);
            pnlAffectedTenants.Dock = DockStyle.Top;
            pnlAffectedTenants.Location = new Point(15, 30);
            pnlAffectedTenants.Name = "pnlAffectedTenants";
            pnlAffectedTenants.Size = new Size(410, 167);
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
            clbAffectedTenants.Size = new Size(410, 75);
            clbAffectedTenants.TabIndex = 3;
            // 
            // pnlTenantOptions
            // 
            pnlTenantOptions.Controls.Add(pnlTenantNone);
            pnlTenantOptions.Controls.Add(pnlTenantSpecify);
            pnlTenantOptions.Controls.Add(pnlTenantAll);
            pnlTenantOptions.Dock = DockStyle.Top;
            pnlTenantOptions.Location = new Point(0, 52);
            pnlTenantOptions.Name = "pnlTenantOptions";
            pnlTenantOptions.Size = new Size(410, 40);
            pnlTenantOptions.TabIndex = 2;
            // 
            // pnlTenantNone
            // 
            pnlTenantNone.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantNone.Controls.Add(rdoTenantNone);
            pnlTenantNone.Dock = DockStyle.Fill;
            pnlTenantNone.Location = new Point(220, 0);
            pnlTenantNone.Name = "pnlTenantNone";
            pnlTenantNone.Size = new Size(190, 40);
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
            lblTenantHint.Size = new Size(410, 22);
            lblTenantHint.TabIndex = 1;
            lblTenantHint.Text = "Optional. They pay; the cost is split equally.";
            // 
            // lblAffectedTenants
            // 
            lblAffectedTenants.Dock = DockStyle.Top;
            lblAffectedTenants.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAffectedTenants.ForeColor = Color.White;
            lblAffectedTenants.Location = new Point(0, 0);
            lblAffectedTenants.Name = "lblAffectedTenants";
            lblAffectedTenants.Size = new Size(410, 30);
            lblAffectedTenants.TabIndex = 0;
            lblAffectedTenants.Text = "Charged Tenant(s)";
            lblAffectedTenants.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblPeopleHeading
            // 
            lblPeopleHeading.Dock = DockStyle.Top;
            lblPeopleHeading.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPeopleHeading.ForeColor = Color.FromArgb(170, 180, 215);
            lblPeopleHeading.Location = new Point(15, 0);
            lblPeopleHeading.Name = "lblPeopleHeading";
            lblPeopleHeading.Size = new Size(410, 30);
            lblPeopleHeading.TabIndex = 0;
            lblPeopleHeading.Text = "PEOPLE";
            // 
            // AddIssueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(880, 464);
            Controls.Add(pnlAddIssueContent);
            Controls.Add(pnlAddIssueActions);
            Controls.Add(pnlAddIssueHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddIssueForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Maintenance Issue";
            Load += AddIssueForm_Load;
            pnlAddIssueHeader.ResumeLayout(false);
            pnlAddIssueHeader.PerformLayout();
            pnlIssueType.ResumeLayout(false);
            pnlIssueType.PerformLayout();
            pnlAddIssueActions.ResumeLayout(false);
            pnlAddIssueContent.ResumeLayout(false);
            tlpAddIssue.ResumeLayout(false);
            pnlIssueDetailsColumn.ResumeLayout(false);
            pnlIssueInformation.ResumeLayout(false);
            pnlIssueInformation.PerformLayout();
            pnlMaterialsNeeded.ResumeLayout(false);
            pnlMaterialsNo.ResumeLayout(false);
            pnlMaterialsNo.PerformLayout();
            pnlMaterialsYes.ResumeLayout(false);
            pnlMaterialsYes.PerformLayout();
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
        private Button btnAddIssue;
        private Button btnCancelIssue;
        private Panel pnlMaterialsNeeded;
        private Panel pnlIssueInformation;
        private Label lblIssue;
        private TextBox txtIssue;
        private DateTimePicker dtpIssueDate;
        private Panel pnlMaterialsNo;
        private RadioButton rdoMaterialsNo;
        private Panel pnlMaterialsYes;
        private RadioButton rdoMaterialsYes;
        private Label lblMaterialsNeeded;
        private Label lblIssueDate;
        private Panel pnlIssueType;
        private Label lblIssueType;
        private RadioButton rdoIssueTypeRoom;
        private RadioButton rdoIssueTypeBuilding;
        private TableLayoutPanel tlpAddIssue;
        private Panel pnlIssueDetailsColumn;
        private Label lblIssueDetailsHeading;
        private Panel pnlPeopleColumn;
        private Label lblTenantHint;
        private Label lblPeopleHeading;
    }
}