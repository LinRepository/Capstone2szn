namespace Capstoneszn.UserControls
{
    partial class MoveInForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlMoveInHeader = new Panel();
            lblRoomInfo = new Label();
            lblSlotsLeft = new Label();
            lblMoveInTitle = new Label();
            pnlMoveInActions = new Panel();
            btnConfirmMoveIn = new Button();
            btnCancelMoveIn = new Button();
            pnlMoveInContent = new Panel();
            pnlListArea = new Panel();
            dgvMoveInList = new DataGridView();
            colNo = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colContact = new DataGridViewTextBoxColumn();
            colRemove = new DataGridViewButtonColumn();
            pnlListHeader = new Panel();
            lblOccupantCount = new Label();
            lblListTitle = new Label();
            pnlListBottom = new Panel();
            pnlSummary = new Panel();
            lblSummaryNote = new Label();
            tlpSummary = new TableLayoutPanel();
            lblTotalDueCaption = new Label();
            lblTotalDue = new Label();
            lblShareCaption = new Label();
            lblShare = new Label();
            lblCoversCaption = new Label();
            lblCovers = new Label();
            lblNextDueCaption = new Label();
            lblNextDue = new Label();
            grpWhoPays = new GroupBox();
            lblPayNote = new Label();
            rdoIndividual = new RadioButton();
            cboPaidBy = new ComboBox();
            lblPaidBy = new Label();
            rdoWholeRoom = new RadioButton();
            pnlDetails = new Panel();
            pnlDate = new Panel();
            dtpMoveInDate = new DateTimePicker();
            lblMoveInDate = new Label();
            pnlDependentOf = new Panel();
            cboDependentOf = new ComboBox();
            lblDependentOf = new Label();
            pnlContactNumber = new Panel();
            txtContactNumber = new TextBox();
            lblContactNumber = new Label();
            pnlAddress = new Panel();
            txtAddress = new TextBox();
            lblAddress = new Label();
            pnlLName = new Panel();
            txtLName = new TextBox();
            lblLName = new Label();
            pnlMName = new Panel();
            txtMName = new TextBox();
            lblMName = new Label();
            pnlFName = new Panel();
            txtFName = new TextBox();
            lblFName = new Label();
            grpOccupantType = new GroupBox();
            rdoDependent = new RadioButton();
            rdoTenant = new RadioButton();
            lblDetailsTitle = new Label();
            pnlDetailButtons = new Panel();
            btnAddToList = new Button();
            btnClear = new Button();
            pnlMoveInHeader.SuspendLayout();
            pnlMoveInActions.SuspendLayout();
            pnlMoveInContent.SuspendLayout();
            pnlListArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMoveInList).BeginInit();
            pnlListHeader.SuspendLayout();
            pnlListBottom.SuspendLayout();
            pnlSummary.SuspendLayout();
            tlpSummary.SuspendLayout();
            grpWhoPays.SuspendLayout();
            pnlDetails.SuspendLayout();
            pnlDate.SuspendLayout();
            pnlDependentOf.SuspendLayout();
            pnlContactNumber.SuspendLayout();
            pnlAddress.SuspendLayout();
            pnlLName.SuspendLayout();
            pnlMName.SuspendLayout();
            pnlFName.SuspendLayout();
            grpOccupantType.SuspendLayout();
            pnlDetailButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMoveInHeader
            // 
            pnlMoveInHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlMoveInHeader.Controls.Add(lblRoomInfo);
            pnlMoveInHeader.Controls.Add(lblSlotsLeft);
            pnlMoveInHeader.Controls.Add(lblMoveInTitle);
            pnlMoveInHeader.Dock = DockStyle.Top;
            pnlMoveInHeader.Location = new Point(0, 0);
            pnlMoveInHeader.Margin = new Padding(0);
            pnlMoveInHeader.Name = "pnlMoveInHeader";
            pnlMoveInHeader.Size = new Size(1180, 76);
            pnlMoveInHeader.TabIndex = 0;
            // 
            // lblRoomInfo
            // 
            lblRoomInfo.Dock = DockStyle.Fill;
            lblRoomInfo.Font = new Font("Segoe UI", 10.8F);
            lblRoomInfo.ForeColor = Color.FromArgb(200, 205, 240);
            lblRoomInfo.Location = new Point(0, 38);
            lblRoomInfo.Margin = new Padding(0);
            lblRoomInfo.Name = "lblRoomInfo";
            lblRoomInfo.Padding = new Padding(180, 0, 0, 0);
            lblRoomInfo.Size = new Size(998, 36);
            lblRoomInfo.TabIndex = 2;
            lblRoomInfo.Text = "Room ### · Room Type · ₱0.00 / month · Capacity 0";
            lblRoomInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSlotsLeft
            // 
            lblSlotsLeft.Dock = DockStyle.Right;
            lblSlotsLeft.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblSlotsLeft.ForeColor = Color.FromArgb(147, 197, 253);
            lblSlotsLeft.Location = new Point(998, 38);
            lblSlotsLeft.Margin = new Padding(0);
            lblSlotsLeft.Name = "lblSlotsLeft";
            lblSlotsLeft.Size = new Size(180, 36);
            lblSlotsLeft.TabIndex = 1;
            lblSlotsLeft.Text = "0 slots left";
            lblSlotsLeft.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMoveInTitle
            // 
            lblMoveInTitle.Dock = DockStyle.Top;
            lblMoveInTitle.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveInTitle.ForeColor = Color.White;
            lblMoveInTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveInTitle.Location = new Point(0, 0);
            lblMoveInTitle.Margin = new Padding(0);
            lblMoveInTitle.Name = "lblMoveInTitle";
            lblMoveInTitle.Size = new Size(1178, 38);
            lblMoveInTitle.TabIndex = 0;
            lblMoveInTitle.Text = "Move In";
            lblMoveInTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMoveInActions
            // 
            pnlMoveInActions.BorderStyle = BorderStyle.FixedSingle;
            pnlMoveInActions.Controls.Add(btnConfirmMoveIn);
            pnlMoveInActions.Controls.Add(btnCancelMoveIn);
            pnlMoveInActions.Dock = DockStyle.Bottom;
            pnlMoveInActions.Location = new Point(0, 664);
            pnlMoveInActions.Margin = new Padding(0);
            pnlMoveInActions.Name = "pnlMoveInActions";
            pnlMoveInActions.Size = new Size(1180, 56);
            pnlMoveInActions.TabIndex = 2;
            // 
            // btnConfirmMoveIn
            // 
            btnConfirmMoveIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmMoveIn.Cursor = Cursors.Hand;
            btnConfirmMoveIn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnConfirmMoveIn.Location = new Point(966, 9);
            btnConfirmMoveIn.Name = "btnConfirmMoveIn";
            btnConfirmMoveIn.Size = new Size(200, 36);
            btnConfirmMoveIn.TabIndex = 1;
            btnConfirmMoveIn.Text = "Continue to Payment";
            btnConfirmMoveIn.UseVisualStyleBackColor = true;
            btnConfirmMoveIn.Click += btnConfirmMoveIn_Click;
            // 
            // btnCancelMoveIn
            // 
            btnCancelMoveIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelMoveIn.Cursor = Cursors.Hand;
            btnCancelMoveIn.Font = new Font("Segoe UI", 10.8F);
            btnCancelMoveIn.Location = new Point(830, 9);
            btnCancelMoveIn.Name = "btnCancelMoveIn";
            btnCancelMoveIn.Size = new Size(120, 36);
            btnCancelMoveIn.TabIndex = 0;
            btnCancelMoveIn.Text = "Cancel";
            btnCancelMoveIn.UseVisualStyleBackColor = true;
            btnCancelMoveIn.Click += btnCancelMoveIn_Click;
            // 
            // pnlMoveInContent
            // 
            pnlMoveInContent.BorderStyle = BorderStyle.FixedSingle;
            pnlMoveInContent.Controls.Add(pnlListArea);
            pnlMoveInContent.Controls.Add(pnlDetails);
            pnlMoveInContent.Dock = DockStyle.Fill;
            pnlMoveInContent.Location = new Point(0, 76);
            pnlMoveInContent.Name = "pnlMoveInContent";
            pnlMoveInContent.Padding = new Padding(12);
            pnlMoveInContent.Size = new Size(1180, 588);
            pnlMoveInContent.TabIndex = 1;
            // 
            // pnlListArea
            // 
            pnlListArea.Controls.Add(dgvMoveInList);
            pnlListArea.Controls.Add(pnlListHeader);
            pnlListArea.Controls.Add(pnlListBottom);
            pnlListArea.Dock = DockStyle.Fill;
            pnlListArea.Location = new Point(442, 12);
            pnlListArea.Name = "pnlListArea";
            pnlListArea.Padding = new Padding(14, 0, 0, 0);
            pnlListArea.Size = new Size(724, 562);
            pnlListArea.TabIndex = 1;
            // 
            // dgvMoveInList
            // 
            dgvMoveInList.AllowUserToAddRows = false;
            dgvMoveInList.AllowUserToDeleteRows = false;
            dgvMoveInList.AllowUserToResizeRows = false;
            dgvMoveInList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMoveInList.BackgroundColor = Color.FromArgb(25, 25, 70);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 110);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 45, 110);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvMoveInList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMoveInList.ColumnHeadersHeight = 36;
            dgvMoveInList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMoveInList.Columns.AddRange(new DataGridViewColumn[] { colNo, colName, colType, colContact, colRemove });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(35, 35, 90);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(60, 60, 140);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMoveInList.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMoveInList.Dock = DockStyle.Fill;
            dgvMoveInList.EnableHeadersVisualStyles = false;
            dgvMoveInList.GridColor = Color.FromArgb(60, 60, 120);
            dgvMoveInList.Location = new Point(14, 40);
            dgvMoveInList.MultiSelect = false;
            dgvMoveInList.Name = "dgvMoveInList";
            dgvMoveInList.ReadOnly = true;
            dgvMoveInList.RowHeadersVisible = false;
            dgvMoveInList.RowHeadersWidth = 51;
            dgvMoveInList.RowTemplate.Height = 36;
            dgvMoveInList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMoveInList.Size = new Size(710, 342);
            dgvMoveInList.TabIndex = 1;
            dgvMoveInList.CellContentClick += dgvMoveInList_CellContentClick;
            // 
            // colNo
            // 
            colNo.FillWeight = 8F;
            colNo.HeaderText = "#";
            colNo.MinimumWidth = 6;
            colNo.Name = "colNo";
            colNo.ReadOnly = true;
            // 
            // colName
            // 
            colName.FillWeight = 36F;
            colName.HeaderText = "Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colType
            // 
            colType.FillWeight = 30F;
            colType.HeaderText = "Type";
            colType.MinimumWidth = 6;
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colContact
            // 
            colContact.FillWeight = 20F;
            colContact.HeaderText = "Contact";
            colContact.MinimumWidth = 6;
            colContact.Name = "colContact";
            colContact.ReadOnly = true;
            // 
            // colRemove
            // 
            colRemove.FillWeight = 8F;
            colRemove.FlatStyle = FlatStyle.Flat;
            colRemove.HeaderText = "";
            colRemove.MinimumWidth = 6;
            colRemove.Name = "colRemove";
            colRemove.ReadOnly = true;
            colRemove.Text = "X";
            colRemove.ToolTipText = "Remove from list";
            colRemove.UseColumnTextForButtonValue = true;
            // 
            // pnlListHeader
            // 
            pnlListHeader.Controls.Add(lblOccupantCount);
            pnlListHeader.Controls.Add(lblListTitle);
            pnlListHeader.Dock = DockStyle.Top;
            pnlListHeader.Location = new Point(14, 0);
            pnlListHeader.Name = "pnlListHeader";
            pnlListHeader.Size = new Size(710, 40);
            pnlListHeader.TabIndex = 0;
            // 
            // lblOccupantCount
            // 
            lblOccupantCount.Dock = DockStyle.Right;
            lblOccupantCount.Font = new Font("Segoe UI", 10.8F);
            lblOccupantCount.ForeColor = Color.FromArgb(200, 205, 240);
            lblOccupantCount.Location = new Point(410, 0);
            lblOccupantCount.Name = "lblOccupantCount";
            lblOccupantCount.Size = new Size(300, 40);
            lblOccupantCount.TabIndex = 1;
            lblOccupantCount.Text = "0 occupants · 0 paying";
            lblOccupantCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblListTitle
            // 
            lblListTitle.Dock = DockStyle.Left;
            lblListTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.White;
            lblListTitle.Location = new Point(0, 0);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(220, 40);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "Moving In";
            lblListTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlListBottom
            // 
            pnlListBottom.Controls.Add(pnlSummary);
            pnlListBottom.Controls.Add(grpWhoPays);
            pnlListBottom.Dock = DockStyle.Bottom;
            pnlListBottom.Location = new Point(14, 382);
            pnlListBottom.Name = "pnlListBottom";
            pnlListBottom.Padding = new Padding(0, 12, 0, 0);
            pnlListBottom.Size = new Size(710, 180);
            pnlListBottom.TabIndex = 2;
            // 
            // pnlSummary
            // 
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Controls.Add(lblSummaryNote);
            pnlSummary.Controls.Add(tlpSummary);
            pnlSummary.Dock = DockStyle.Fill;
            pnlSummary.Location = new Point(366, 12);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Padding = new Padding(12, 6, 12, 6);
            pnlSummary.Size = new Size(344, 168);
            pnlSummary.TabIndex = 1;
            // 
            // lblSummaryNote
            // 
            lblSummaryNote.Dock = DockStyle.Fill;
            lblSummaryNote.Font = new Font("Segoe UI", 10.2F);
            lblSummaryNote.ForeColor = Color.FromArgb(147, 197, 253);
            lblSummaryNote.Location = new Point(12, 122);
            lblSummaryNote.Name = "lblSummaryNote";
            lblSummaryNote.Size = new Size(318, 38);
            lblSummaryNote.TabIndex = 1;
            lblSummaryNote.Text = "Add at least one paying tenant.";
            lblSummaryNote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpSummary
            // 
            tlpSummary.ColumnCount = 2;
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpSummary.Controls.Add(lblTotalDueCaption, 0, 0);
            tlpSummary.Controls.Add(lblTotalDue, 1, 0);
            tlpSummary.Controls.Add(lblShareCaption, 0, 1);
            tlpSummary.Controls.Add(lblShare, 1, 1);
            tlpSummary.Controls.Add(lblCoversCaption, 0, 2);
            tlpSummary.Controls.Add(lblCovers, 1, 2);
            tlpSummary.Controls.Add(lblNextDueCaption, 0, 3);
            tlpSummary.Controls.Add(lblNextDue, 1, 3);
            tlpSummary.Dock = DockStyle.Top;
            tlpSummary.Location = new Point(12, 6);
            tlpSummary.Name = "tlpSummary";
            tlpSummary.RowCount = 4;
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSummary.Size = new Size(318, 116);
            tlpSummary.TabIndex = 0;
            // 
            // lblTotalDueCaption
            // 
            lblTotalDueCaption.Dock = DockStyle.Fill;
            lblTotalDueCaption.Font = new Font("Segoe UI", 10.2F);
            lblTotalDueCaption.ForeColor = Color.FromArgb(200, 205, 240);
            lblTotalDueCaption.Location = new Point(3, 0);
            lblTotalDueCaption.Name = "lblTotalDueCaption";
            lblTotalDueCaption.Size = new Size(168, 29);
            lblTotalDueCaption.TabIndex = 0;
            lblTotalDueCaption.Text = "Total due today";
            lblTotalDueCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalDue
            // 
            lblTotalDue.Dock = DockStyle.Fill;
            lblTotalDue.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblTotalDue.ForeColor = Color.White;
            lblTotalDue.Location = new Point(177, 0);
            lblTotalDue.Name = "lblTotalDue";
            lblTotalDue.Size = new Size(138, 29);
            lblTotalDue.TabIndex = 1;
            lblTotalDue.Text = "₱0.00";
            lblTotalDue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblShareCaption
            // 
            lblShareCaption.Dock = DockStyle.Fill;
            lblShareCaption.Font = new Font("Segoe UI", 10.2F);
            lblShareCaption.ForeColor = Color.FromArgb(200, 205, 240);
            lblShareCaption.Location = new Point(3, 29);
            lblShareCaption.Name = "lblShareCaption";
            lblShareCaption.Size = new Size(168, 29);
            lblShareCaption.TabIndex = 2;
            lblShareCaption.Text = "Share per paying tenant";
            lblShareCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblShare
            // 
            lblShare.Dock = DockStyle.Fill;
            lblShare.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblShare.ForeColor = Color.White;
            lblShare.Location = new Point(177, 29);
            lblShare.Name = "lblShare";
            lblShare.Size = new Size(138, 29);
            lblShare.TabIndex = 3;
            lblShare.Text = "—";
            lblShare.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCoversCaption
            // 
            lblCoversCaption.Dock = DockStyle.Fill;
            lblCoversCaption.Font = new Font("Segoe UI", 10.2F);
            lblCoversCaption.ForeColor = Color.FromArgb(200, 205, 240);
            lblCoversCaption.Location = new Point(3, 58);
            lblCoversCaption.Name = "lblCoversCaption";
            lblCoversCaption.Size = new Size(168, 29);
            lblCoversCaption.TabIndex = 4;
            lblCoversCaption.Text = "Covers";
            lblCoversCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCovers
            // 
            lblCovers.Dock = DockStyle.Fill;
            lblCovers.Font = new Font("Segoe UI", 10.2F);
            lblCovers.ForeColor = Color.White;
            lblCovers.Location = new Point(177, 58);
            lblCovers.Name = "lblCovers";
            lblCovers.Size = new Size(138, 29);
            lblCovers.TabIndex = 5;
            lblCovers.Text = "—";
            lblCovers.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNextDueCaption
            // 
            lblNextDueCaption.Dock = DockStyle.Fill;
            lblNextDueCaption.Font = new Font("Segoe UI", 10.2F);
            lblNextDueCaption.ForeColor = Color.FromArgb(200, 205, 240);
            lblNextDueCaption.Location = new Point(3, 87);
            lblNextDueCaption.Name = "lblNextDueCaption";
            lblNextDueCaption.Size = new Size(168, 29);
            lblNextDueCaption.TabIndex = 6;
            lblNextDueCaption.Text = "Next due";
            lblNextDueCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNextDue
            // 
            lblNextDue.Dock = DockStyle.Fill;
            lblNextDue.Font = new Font("Segoe UI", 10.2F);
            lblNextDue.ForeColor = Color.White;
            lblNextDue.Location = new Point(177, 87);
            lblNextDue.Name = "lblNextDue";
            lblNextDue.Size = new Size(138, 29);
            lblNextDue.TabIndex = 7;
            lblNextDue.Text = "—";
            lblNextDue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpWhoPays
            // 
            grpWhoPays.Controls.Add(lblPayNote);
            grpWhoPays.Controls.Add(rdoIndividual);
            grpWhoPays.Controls.Add(cboPaidBy);
            grpWhoPays.Controls.Add(lblPaidBy);
            grpWhoPays.Controls.Add(rdoWholeRoom);
            grpWhoPays.Dock = DockStyle.Left;
            grpWhoPays.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            grpWhoPays.ForeColor = Color.White;
            grpWhoPays.Location = new Point(0, 12);
            grpWhoPays.Name = "grpWhoPays";
            grpWhoPays.Size = new Size(366, 168);
            grpWhoPays.TabIndex = 0;
            grpWhoPays.TabStop = false;
            grpWhoPays.Text = "Who pays the move-in?";
            // 
            // lblPayNote
            // 
            lblPayNote.Font = new Font("Segoe UI", 10.2F);
            lblPayNote.ForeColor = Color.FromArgb(200, 205, 240);
            lblPayNote.Location = new Point(14, 30);
            lblPayNote.Name = "lblPayNote";
            lblPayNote.Size = new Size(340, 120);
            lblPayNote.TabIndex = 4;
            lblPayNote.Text = "Paid by the only paying tenant. Dependents have no share.";
            lblPayNote.Visible = false;
            // 
            // rdoIndividual
            // 
            rdoIndividual.AutoSize = true;
            rdoIndividual.Cursor = Cursors.Hand;
            rdoIndividual.Font = new Font("Segoe UI", 10.2F);
            rdoIndividual.Location = new Point(14, 110);
            rdoIndividual.Name = "rdoIndividual";
            rdoIndividual.Size = new Size(278, 27);
            rdoIndividual.TabIndex = 3;
            rdoIndividual.Text = "Individual (each pays own share)";
            rdoIndividual.UseVisualStyleBackColor = true;
            rdoIndividual.CheckedChanged += rdoPaymentMode_CheckedChanged;
            // 
            // cboPaidBy
            // 
            cboPaidBy.Cursor = Cursors.Hand;
            cboPaidBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaidBy.Font = new Font("Segoe UI", 10.2F);
            cboPaidBy.FormattingEnabled = true;
            cboPaidBy.Location = new Point(110, 66);
            cboPaidBy.Name = "cboPaidBy";
            cboPaidBy.Size = new Size(240, 31);
            cboPaidBy.TabIndex = 2;
            // 
            // lblPaidBy
            // 
            lblPaidBy.Font = new Font("Segoe UI", 10.2F);
            lblPaidBy.ForeColor = Color.FromArgb(200, 205, 240);
            lblPaidBy.Location = new Point(36, 66);
            lblPaidBy.Name = "lblPaidBy";
            lblPaidBy.Size = new Size(72, 31);
            lblPaidBy.TabIndex = 1;
            lblPaidBy.Text = "Paid by";
            lblPaidBy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rdoWholeRoom
            // 
            rdoWholeRoom.AutoSize = true;
            rdoWholeRoom.Checked = true;
            rdoWholeRoom.Cursor = Cursors.Hand;
            rdoWholeRoom.Font = new Font("Segoe UI", 10.2F);
            rdoWholeRoom.Location = new Point(14, 32);
            rdoWholeRoom.Name = "rdoWholeRoom";
            rdoWholeRoom.Size = new Size(290, 27);
            rdoWholeRoom.TabIndex = 0;
            rdoWholeRoom.TabStop = true;
            rdoWholeRoom.Text = "Whole Room (one tenant pays all)";
            rdoWholeRoom.UseVisualStyleBackColor = true;
            rdoWholeRoom.CheckedChanged += rdoPaymentMode_CheckedChanged;
            // 
            // pnlDetails
            // 
            pnlDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlDetails.Controls.Add(pnlDate);
            pnlDetails.Controls.Add(pnlDependentOf);
            pnlDetails.Controls.Add(pnlContactNumber);
            pnlDetails.Controls.Add(pnlAddress);
            pnlDetails.Controls.Add(pnlLName);
            pnlDetails.Controls.Add(pnlMName);
            pnlDetails.Controls.Add(pnlFName);
            pnlDetails.Controls.Add(grpOccupantType);
            pnlDetails.Controls.Add(lblDetailsTitle);
            pnlDetails.Controls.Add(pnlDetailButtons);
            pnlDetails.Dock = DockStyle.Left;
            pnlDetails.Location = new Point(12, 12);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(430, 562);
            pnlDetails.TabIndex = 0;
            // 
            // pnlDate
            // 
            pnlDate.Controls.Add(dtpMoveInDate);
            pnlDate.Controls.Add(lblMoveInDate);
            pnlDate.Dock = DockStyle.Top;
            pnlDate.Location = new Point(0, 412);
            pnlDate.Name = "pnlDate";
            pnlDate.Size = new Size(428, 52);
            pnlDate.TabIndex = 8;
            pnlDate.Visible = false;
            // 
            // dtpMoveInDate
            // 
            dtpMoveInDate.Enabled = false;
            dtpMoveInDate.Location = new Point(173, 12);
            dtpMoveInDate.Name = "dtpMoveInDate";
            dtpMoveInDate.Size = new Size(240, 27);
            dtpMoveInDate.TabIndex = 1;
            // 
            // lblMoveInDate
            // 
            lblMoveInDate.Font = new Font("Segoe UI", 12F);
            lblMoveInDate.ForeColor = Color.White;
            lblMoveInDate.Location = new Point(8, 8);
            lblMoveInDate.Name = "lblMoveInDate";
            lblMoveInDate.Size = new Size(160, 34);
            lblMoveInDate.TabIndex = 0;
            lblMoveInDate.Text = "Date";
            lblMoveInDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDependentOf
            // 
            pnlDependentOf.Controls.Add(cboDependentOf);
            pnlDependentOf.Controls.Add(lblDependentOf);
            pnlDependentOf.Dock = DockStyle.Top;
            pnlDependentOf.Location = new Point(0, 360);
            pnlDependentOf.Name = "pnlDependentOf";
            pnlDependentOf.Padding = new Padding(8);
            pnlDependentOf.Size = new Size(428, 52);
            pnlDependentOf.TabIndex = 7;
            pnlDependentOf.Visible = false;
            // 
            // cboDependentOf
            // 
            cboDependentOf.Cursor = Cursors.Hand;
            cboDependentOf.Dock = DockStyle.Fill;
            cboDependentOf.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDependentOf.Font = new Font("Segoe UI", 12F);
            cboDependentOf.FormattingEnabled = true;
            cboDependentOf.Location = new Point(173, 8);
            cboDependentOf.Name = "cboDependentOf";
            cboDependentOf.Size = new Size(247, 36);
            cboDependentOf.TabIndex = 1;
            // 
            // lblDependentOf
            // 
            lblDependentOf.Dock = DockStyle.Left;
            lblDependentOf.Font = new Font("Segoe UI", 12F);
            lblDependentOf.ForeColor = Color.White;
            lblDependentOf.Location = new Point(8, 8);
            lblDependentOf.Name = "lblDependentOf";
            lblDependentOf.Size = new Size(165, 36);
            lblDependentOf.TabIndex = 0;
            lblDependentOf.Text = "Dependent of";
            lblDependentOf.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContactNumber
            // 
            pnlContactNumber.Controls.Add(txtContactNumber);
            pnlContactNumber.Controls.Add(lblContactNumber);
            pnlContactNumber.Dock = DockStyle.Top;
            pnlContactNumber.Location = new Point(0, 308);
            pnlContactNumber.Name = "pnlContactNumber";
            pnlContactNumber.Padding = new Padding(8);
            pnlContactNumber.Size = new Size(428, 52);
            pnlContactNumber.TabIndex = 6;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Cursor = Cursors.IBeam;
            txtContactNumber.Dock = DockStyle.Fill;
            txtContactNumber.Font = new Font("Segoe UI", 12F);
            txtContactNumber.Location = new Point(173, 8);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.PlaceholderText = "09XXXXXXXXX";
            txtContactNumber.Size = new Size(247, 34);
            txtContactNumber.TabIndex = 1;
            // 
            // lblContactNumber
            // 
            lblContactNumber.Dock = DockStyle.Left;
            lblContactNumber.Font = new Font("Segoe UI", 12F);
            lblContactNumber.ForeColor = Color.White;
            lblContactNumber.Location = new Point(8, 8);
            lblContactNumber.Margin = new Padding(0);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(165, 36);
            lblContactNumber.TabIndex = 0;
            lblContactNumber.Text = "Contact Number";
            lblContactNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlAddress
            // 
            pnlAddress.Controls.Add(txtAddress);
            pnlAddress.Controls.Add(lblAddress);
            pnlAddress.Dock = DockStyle.Top;
            pnlAddress.Location = new Point(0, 256);
            pnlAddress.Name = "pnlAddress";
            pnlAddress.Padding = new Padding(8);
            pnlAddress.Size = new Size(428, 52);
            pnlAddress.TabIndex = 5;
            // 
            // txtAddress
            // 
            txtAddress.Cursor = Cursors.IBeam;
            txtAddress.Dock = DockStyle.Fill;
            txtAddress.Font = new Font("Segoe UI", 12F);
            txtAddress.Location = new Point(173, 8);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(247, 34);
            txtAddress.TabIndex = 1;
            // 
            // lblAddress
            // 
            lblAddress.Dock = DockStyle.Left;
            lblAddress.Font = new Font("Segoe UI", 12F);
            lblAddress.ForeColor = Color.White;
            lblAddress.Location = new Point(8, 8);
            lblAddress.Margin = new Padding(0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(165, 36);
            lblAddress.TabIndex = 0;
            lblAddress.Text = "Address";
            lblAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLName
            // 
            pnlLName.Controls.Add(txtLName);
            pnlLName.Controls.Add(lblLName);
            pnlLName.Dock = DockStyle.Top;
            pnlLName.Location = new Point(0, 204);
            pnlLName.Name = "pnlLName";
            pnlLName.Padding = new Padding(8);
            pnlLName.Size = new Size(428, 52);
            pnlLName.TabIndex = 4;
            // 
            // txtLName
            // 
            txtLName.Cursor = Cursors.IBeam;
            txtLName.Dock = DockStyle.Fill;
            txtLName.Font = new Font("Segoe UI", 12F);
            txtLName.Location = new Point(173, 8);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(247, 34);
            txtLName.TabIndex = 1;
            // 
            // lblLName
            // 
            lblLName.Dock = DockStyle.Left;
            lblLName.Font = new Font("Segoe UI", 12F);
            lblLName.ForeColor = Color.White;
            lblLName.Location = new Point(8, 8);
            lblLName.Margin = new Padding(0);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(165, 36);
            lblLName.TabIndex = 0;
            lblLName.Text = "Last Name";
            lblLName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlMName
            // 
            pnlMName.Controls.Add(txtMName);
            pnlMName.Controls.Add(lblMName);
            pnlMName.Dock = DockStyle.Top;
            pnlMName.Location = new Point(0, 152);
            pnlMName.Name = "pnlMName";
            pnlMName.Padding = new Padding(8);
            pnlMName.Size = new Size(428, 52);
            pnlMName.TabIndex = 3;
            // 
            // txtMName
            // 
            txtMName.Cursor = Cursors.IBeam;
            txtMName.Dock = DockStyle.Fill;
            txtMName.Font = new Font("Segoe UI", 12F);
            txtMName.Location = new Point(173, 8);
            txtMName.Name = "txtMName";
            txtMName.PlaceholderText = "Optional";
            txtMName.Size = new Size(247, 34);
            txtMName.TabIndex = 1;
            // 
            // lblMName
            // 
            lblMName.Dock = DockStyle.Left;
            lblMName.Font = new Font("Segoe UI", 12F);
            lblMName.ForeColor = Color.White;
            lblMName.Location = new Point(8, 8);
            lblMName.Margin = new Padding(0);
            lblMName.Name = "lblMName";
            lblMName.Size = new Size(165, 36);
            lblMName.TabIndex = 0;
            lblMName.Text = "Middle Name";
            lblMName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFName
            // 
            pnlFName.Controls.Add(txtFName);
            pnlFName.Controls.Add(lblFName);
            pnlFName.Dock = DockStyle.Top;
            pnlFName.Location = new Point(0, 100);
            pnlFName.Name = "pnlFName";
            pnlFName.Padding = new Padding(8);
            pnlFName.Size = new Size(428, 52);
            pnlFName.TabIndex = 2;
            // 
            // txtFName
            // 
            txtFName.Cursor = Cursors.IBeam;
            txtFName.Dock = DockStyle.Fill;
            txtFName.Font = new Font("Segoe UI", 12F);
            txtFName.Location = new Point(173, 8);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(247, 34);
            txtFName.TabIndex = 1;
            // 
            // lblFName
            // 
            lblFName.Dock = DockStyle.Left;
            lblFName.Font = new Font("Segoe UI", 12F);
            lblFName.ForeColor = Color.White;
            lblFName.Location = new Point(8, 8);
            lblFName.Margin = new Padding(0);
            lblFName.Name = "lblFName";
            lblFName.Size = new Size(165, 36);
            lblFName.TabIndex = 0;
            lblFName.Text = "First Name";
            lblFName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpOccupantType
            // 
            grpOccupantType.Controls.Add(rdoDependent);
            grpOccupantType.Controls.Add(rdoTenant);
            grpOccupantType.Dock = DockStyle.Top;
            grpOccupantType.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            grpOccupantType.ForeColor = Color.White;
            grpOccupantType.Location = new Point(0, 40);
            grpOccupantType.Name = "grpOccupantType";
            grpOccupantType.Size = new Size(428, 60);
            grpOccupantType.TabIndex = 1;
            grpOccupantType.TabStop = false;
            grpOccupantType.Text = "Type";
            // 
            // rdoDependent
            // 
            rdoDependent.AutoSize = true;
            rdoDependent.Cursor = Cursors.Hand;
            rdoDependent.Font = new Font("Segoe UI", 10.8F);
            rdoDependent.Location = new Point(220, 24);
            rdoDependent.Name = "rdoDependent";
            rdoDependent.Size = new Size(121, 29);
            rdoDependent.TabIndex = 1;
            rdoDependent.Text = "Dependent";
            rdoDependent.UseVisualStyleBackColor = true;
            rdoDependent.CheckedChanged += rdoOccupantType_CheckedChanged;
            // 
            // rdoTenant
            // 
            rdoTenant.AutoSize = true;
            rdoTenant.Checked = true;
            rdoTenant.Cursor = Cursors.Hand;
            rdoTenant.Font = new Font("Segoe UI", 10.8F);
            rdoTenant.Location = new Point(16, 24);
            rdoTenant.Name = "rdoTenant";
            rdoTenant.Size = new Size(136, 29);
            rdoTenant.TabIndex = 0;
            rdoTenant.TabStop = true;
            rdoTenant.Text = "Tenant (pays)";
            rdoTenant.UseVisualStyleBackColor = true;
            rdoTenant.CheckedChanged += rdoOccupantType_CheckedChanged;
            // 
            // lblDetailsTitle
            // 
            lblDetailsTitle.Dock = DockStyle.Top;
            lblDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetailsTitle.ForeColor = Color.White;
            lblDetailsTitle.Location = new Point(0, 0);
            lblDetailsTitle.Name = "lblDetailsTitle";
            lblDetailsTitle.Padding = new Padding(8, 0, 0, 0);
            lblDetailsTitle.Size = new Size(428, 40);
            lblDetailsTitle.TabIndex = 0;
            lblDetailsTitle.Text = "Occupant Details";
            lblDetailsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDetailButtons
            // 
            pnlDetailButtons.Controls.Add(btnAddToList);
            pnlDetailButtons.Controls.Add(btnClear);
            pnlDetailButtons.Dock = DockStyle.Bottom;
            pnlDetailButtons.Location = new Point(0, 500);
            pnlDetailButtons.Name = "pnlDetailButtons";
            pnlDetailButtons.Size = new Size(428, 60);
            pnlDetailButtons.TabIndex = 9;
            // 
            // btnAddToList
            // 
            btnAddToList.Cursor = Cursors.Hand;
            btnAddToList.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnAddToList.Location = new Point(152, 12);
            btnAddToList.Name = "btnAddToList";
            btnAddToList.Size = new Size(264, 36);
            btnAddToList.TabIndex = 1;
            btnAddToList.Text = "Add to List  →";
            btnAddToList.UseVisualStyleBackColor = true;
            btnAddToList.Click += btnAddToList_Click;
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.Font = new Font("Segoe UI", 10.8F);
            btnClear.Location = new Point(12, 12);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(128, 36);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // MoveInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(1180, 720);
            Controls.Add(pnlMoveInContent);
            Controls.Add(pnlMoveInActions);
            Controls.Add(pnlMoveInHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveInForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Move In Tenant";
            Load += MoveInForm_Load;
            pnlMoveInHeader.ResumeLayout(false);
            pnlMoveInActions.ResumeLayout(false);
            pnlMoveInContent.ResumeLayout(false);
            pnlListArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMoveInList).EndInit();
            pnlListHeader.ResumeLayout(false);
            pnlListBottom.ResumeLayout(false);
            pnlSummary.ResumeLayout(false);
            tlpSummary.ResumeLayout(false);
            grpWhoPays.ResumeLayout(false);
            grpWhoPays.PerformLayout();
            pnlDetails.ResumeLayout(false);
            pnlDate.ResumeLayout(false);
            pnlDependentOf.ResumeLayout(false);
            pnlContactNumber.ResumeLayout(false);
            pnlContactNumber.PerformLayout();
            pnlAddress.ResumeLayout(false);
            pnlAddress.PerformLayout();
            pnlLName.ResumeLayout(false);
            pnlLName.PerformLayout();
            pnlMName.ResumeLayout(false);
            pnlMName.PerformLayout();
            pnlFName.ResumeLayout(false);
            pnlFName.PerformLayout();
            grpOccupantType.ResumeLayout(false);
            grpOccupantType.PerformLayout();
            pnlDetailButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // ---- Existing controls (names unchanged; MoveInForm.cs uses them) ----
        private Panel pnlMoveInHeader;
        private Label lblMoveInTitle;
        private Panel pnlMoveInActions;
        private Button btnConfirmMoveIn;
        private Button btnCancelMoveIn;
        private Panel pnlMoveInContent;
        private Label lblMoveInDate;
        private DateTimePicker dtpMoveInDate;
        private Panel pnlLName;
        private Panel pnlMName;
        private Panel pnlFName;
        private TextBox txtLName;
        private TextBox txtMName;
        private TextBox txtFName;
        private Panel pnlAddress;
        private TextBox txtAddress;
        private Panel pnlDate;
        private Panel pnlContactNumber;
        private TextBox txtContactNumber;
        private Label lblFName;
        private Label lblMName;
        private Label lblContactNumber;
        private Label lblAddress;
        private Label lblLName;
        private Button btnClear;

        // ---- New controls (Layout A) ----
        private Label lblRoomInfo;
        private Label lblSlotsLeft;
        private Panel pnlDetails;
        private Label lblDetailsTitle;
        private GroupBox grpOccupantType;
        private RadioButton rdoTenant;
        private RadioButton rdoDependent;
        private Panel pnlDependentOf;
        private Label lblDependentOf;
        private ComboBox cboDependentOf;
        private Panel pnlDetailButtons;
        private Button btnAddToList;
        private Panel pnlListArea;
        private Panel pnlListHeader;
        private Label lblListTitle;
        private Label lblOccupantCount;
        private DataGridView dgvMoveInList;
        private DataGridViewTextBoxColumn colNo;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colContact;
        private DataGridViewButtonColumn colRemove;
        private Panel pnlListBottom;
        private GroupBox grpWhoPays;
        private RadioButton rdoWholeRoom;
        private Label lblPaidBy;
        private ComboBox cboPaidBy;
        private RadioButton rdoIndividual;
        private Label lblPayNote;
        private Panel pnlSummary;
        private TableLayoutPanel tlpSummary;
        private Label lblTotalDueCaption;
        private Label lblTotalDue;
        private Label lblShareCaption;
        private Label lblShare;
        private Label lblCoversCaption;
        private Label lblCovers;
        private Label lblNextDueCaption;
        private Label lblNextDue;
        private Label lblSummaryNote;
    }
}