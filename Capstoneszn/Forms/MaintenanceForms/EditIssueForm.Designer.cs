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
            lblEditIssueTitle = new Label();
            pnlEditIssueActions = new Panel();
            btnSaveIssueChanges = new Button();
            btnCancelEditIssue = new Button();
            pnlEditIssueContent = new Panel();
            pnlIssueStatus = new Panel();
            cboIssueStatus = new ComboBox();
            lblIssueStatus = new Label();
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
            lblRoomValue = new Label();
            lblRoom = new Label();
            pnlEditIssueHeader.SuspendLayout();
            pnlEditIssueActions.SuspendLayout();
            pnlEditIssueContent.SuspendLayout();
            pnlIssueStatus.SuspendLayout();
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
            // pnlEditIssueHeader
            // 
            pnlEditIssueHeader.Controls.Add(lblEditIssueTitle);
            pnlEditIssueHeader.Dock = DockStyle.Top;
            pnlEditIssueHeader.Location = new Point(0, 0);
            pnlEditIssueHeader.Name = "pnlEditIssueHeader";
            pnlEditIssueHeader.Size = new Size(482, 50);
            pnlEditIssueHeader.TabIndex = 0;
            // 
            // lblEditIssueTitle
            // 
            lblEditIssueTitle.AutoSize = true;
            lblEditIssueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditIssueTitle.ForeColor = Color.White;
            lblEditIssueTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblEditIssueTitle.Location = new Point(135, 11);
            lblEditIssueTitle.Name = "lblEditIssueTitle";
            lblEditIssueTitle.Size = new Size(210, 28);
            lblEditIssueTitle.TabIndex = 40;
            lblEditIssueTitle.Text = "Edit Maintenance Issue";
            lblEditIssueTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblEditIssueTitle.Visible = false;
            // 
            // pnlEditIssueActions
            // 
            pnlEditIssueActions.Controls.Add(btnSaveIssueChanges);
            pnlEditIssueActions.Controls.Add(btnCancelEditIssue);
            pnlEditIssueActions.Dock = DockStyle.Bottom;
            pnlEditIssueActions.Location = new Point(0, 503);
            pnlEditIssueActions.Name = "pnlEditIssueActions";
            pnlEditIssueActions.Size = new Size(482, 50);
            pnlEditIssueActions.TabIndex = 1;
            // 
            // btnSaveIssueChanges
            // 
            btnSaveIssueChanges.Location = new Point(367, 10);
            btnSaveIssueChanges.Name = "btnSaveIssueChanges";
            btnSaveIssueChanges.Size = new Size(94, 29);
            btnSaveIssueChanges.TabIndex = 1;
            btnSaveIssueChanges.Text = "Save";
            btnSaveIssueChanges.UseVisualStyleBackColor = true;
            // 
            // btnCancelEditIssue
            // 
            btnCancelEditIssue.Location = new Point(252, 10);
            btnCancelEditIssue.Name = "btnCancelEditIssue";
            btnCancelEditIssue.Size = new Size(94, 29);
            btnCancelEditIssue.TabIndex = 0;
            btnCancelEditIssue.Text = "Cancel";
            btnCancelEditIssue.UseVisualStyleBackColor = true;
            // 
            // pnlEditIssueContent
            // 
            pnlEditIssueContent.AutoScroll = true;
            pnlEditIssueContent.Controls.Add(pnlIssueStatus);
            pnlEditIssueContent.Controls.Add(pnlIssueInformation);
            pnlEditIssueContent.Controls.Add(pnlResponsible);
            pnlEditIssueContent.Controls.Add(pnlAffectedTenants);
            pnlEditIssueContent.Controls.Add(pnlRoomSelection);
            pnlEditIssueContent.Dock = DockStyle.Fill;
            pnlEditIssueContent.Location = new Point(0, 50);
            pnlEditIssueContent.Name = "pnlEditIssueContent";
            pnlEditIssueContent.Padding = new Padding(15);
            pnlEditIssueContent.Size = new Size(482, 453);
            pnlEditIssueContent.TabIndex = 2;
            // 
            // pnlIssueStatus
            // 
            pnlIssueStatus.Controls.Add(cboIssueStatus);
            pnlIssueStatus.Controls.Add(lblIssueStatus);
            pnlIssueStatus.Dock = DockStyle.Top;
            pnlIssueStatus.Location = new Point(15, 685);
            pnlIssueStatus.Name = "pnlIssueStatus";
            pnlIssueStatus.Size = new Size(431, 75);
            pnlIssueStatus.TabIndex = 44;
            // 
            // cboIssueStatus
            // 
            cboIssueStatus.Dock = DockStyle.Fill;
            cboIssueStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIssueStatus.FormattingEnabled = true;
            cboIssueStatus.Items.AddRange(new object[] { "Pending", "Completed" });
            cboIssueStatus.Location = new Point(0, 40);
            cboIssueStatus.Name = "cboIssueStatus";
            cboIssueStatus.Size = new Size(431, 28);
            cboIssueStatus.TabIndex = 42;
            // 
            // lblIssueStatus
            // 
            lblIssueStatus.Dock = DockStyle.Top;
            lblIssueStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueStatus.ForeColor = Color.White;
            lblIssueStatus.ImageAlign = ContentAlignment.MiddleRight;
            lblIssueStatus.Location = new Point(0, 0);
            lblIssueStatus.Name = "lblIssueStatus";
            lblIssueStatus.Size = new Size(431, 40);
            lblIssueStatus.TabIndex = 41;
            lblIssueStatus.Text = "Status";
            lblIssueStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblIssueStatus.Visible = false;
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
            pnlIssueInformation.Location = new Point(15, 415);
            pnlIssueInformation.Name = "pnlIssueInformation";
            pnlIssueInformation.Size = new Size(431, 270);
            pnlIssueInformation.TabIndex = 4;
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
            pnlResponsible.Location = new Point(15, 245);
            pnlResponsible.Name = "pnlResponsible";
            pnlResponsible.Size = new Size(431, 170);
            pnlResponsible.TabIndex = 3;
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
            pnlAffectedTenants.Location = new Point(15, 75);
            pnlAffectedTenants.Name = "pnlAffectedTenants";
            pnlAffectedTenants.Size = new Size(431, 170);
            pnlAffectedTenants.TabIndex = 1;
            // 
            // clbAffectedTenants
            // 
            clbAffectedTenants.CheckOnClick = true;
            clbAffectedTenants.Dock = DockStyle.Fill;
            clbAffectedTenants.FormattingEnabled = true;
            clbAffectedTenants.Location = new Point(0, 73);
            clbAffectedTenants.Name = "clbAffectedTenants";
            clbAffectedTenants.Size = new Size(431, 97);
            clbAffectedTenants.TabIndex = 47;
            clbAffectedTenants.Visible = false;
            // 
            // pnlTenantOptions
            // 
            pnlTenantOptions.Controls.Add(pnlTenantSpecify);
            pnlTenantOptions.Controls.Add(pnlTenantNone);
            pnlTenantOptions.Controls.Add(pnlTenantAll);
            pnlTenantOptions.Dock = DockStyle.Top;
            pnlTenantOptions.Location = new Point(0, 28);
            pnlTenantOptions.Name = "pnlTenantOptions";
            pnlTenantOptions.Size = new Size(431, 45);
            pnlTenantOptions.TabIndex = 45;
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
            lblAffectedTenants.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAffectedTenants.ForeColor = Color.White;
            lblAffectedTenants.ImageAlign = ContentAlignment.MiddleRight;
            lblAffectedTenants.Location = new Point(0, 0);
            lblAffectedTenants.Name = "lblAffectedTenants";
            lblAffectedTenants.Size = new Size(431, 28);
            lblAffectedTenants.TabIndex = 41;
            lblAffectedTenants.Text = "Affected Tenant(s)";
            lblAffectedTenants.TextAlign = ContentAlignment.MiddleCenter;
            lblAffectedTenants.Visible = false;
            // 
            // pnlRoomSelection
            // 
            pnlRoomSelection.Controls.Add(lblRoomValue);
            pnlRoomSelection.Controls.Add(lblRoom);
            pnlRoomSelection.Dock = DockStyle.Top;
            pnlRoomSelection.Location = new Point(15, 15);
            pnlRoomSelection.Name = "pnlRoomSelection";
            pnlRoomSelection.Size = new Size(431, 60);
            pnlRoomSelection.TabIndex = 0;
            // 
            // lblRoomValue
            // 
            lblRoomValue.Dock = DockStyle.Fill;
            lblRoomValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomValue.ForeColor = Color.White;
            lblRoomValue.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomValue.Location = new Point(0, 28);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(431, 32);
            lblRoomValue.TabIndex = 42;
            lblRoomValue.Text = "Room ###";
            lblRoomValue.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomValue.Visible = false;
            // 
            // lblRoom
            // 
            lblRoom.Dock = DockStyle.Top;
            lblRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.ForeColor = Color.White;
            lblRoom.ImageAlign = ContentAlignment.MiddleRight;
            lblRoom.Location = new Point(0, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(431, 28);
            lblRoom.TabIndex = 41;
            lblRoom.Text = "Room";
            lblRoom.TextAlign = ContentAlignment.MiddleCenter;
            lblRoom.Visible = false;
            // 
            // EditIssueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 553);
            Controls.Add(pnlEditIssueContent);
            Controls.Add(pnlEditIssueActions);
            Controls.Add(pnlEditIssueHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditIssueForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Maintenance Issue";
            pnlEditIssueHeader.ResumeLayout(false);
            pnlEditIssueHeader.PerformLayout();
            pnlEditIssueActions.ResumeLayout(false);
            pnlEditIssueContent.ResumeLayout(false);
            pnlIssueStatus.ResumeLayout(false);
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
    }
}