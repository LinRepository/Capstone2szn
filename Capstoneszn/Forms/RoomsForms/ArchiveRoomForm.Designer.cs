namespace Capstoneszn.Forms.RoomsForms
{
    partial class ArchiveRoomForm
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
            pnlArchiveRoomHeader = new Panel();
            lblArchiveRoomDescription = new Label();
            lblArchiveRoomTitle = new Label();
            pnlArchiveRoomActions = new Panel();
            lblSelectedRoom = new Label();
            btnArchiveSelected = new Button();
            btnCancelArchiveRoom = new Button();
            pnlArchiveRoomContent = new Panel();
            dgvArchivableRooms = new DataGridView();
            colFloor = new DataGridViewTextBoxColumn();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colRoomType = new DataGridViewTextBoxColumn();
            colCapacity = new DataGridViewTextBoxColumn();
            colRoomPrice = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblNoRooms = new Label();
            lblArchiveRule = new Label();
            pnlArchiveRoomHeader.SuspendLayout();
            pnlArchiveRoomActions.SuspendLayout();
            pnlArchiveRoomContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchivableRooms).BeginInit();
            SuspendLayout();
            // 
            // pnlArchiveRoomHeader
            // 
            pnlArchiveRoomHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlArchiveRoomHeader.Controls.Add(lblArchiveRoomDescription);
            pnlArchiveRoomHeader.Controls.Add(lblArchiveRoomTitle);
            pnlArchiveRoomHeader.Dock = DockStyle.Top;
            pnlArchiveRoomHeader.Location = new Point(0, 0);
            pnlArchiveRoomHeader.Margin = new Padding(0);
            pnlArchiveRoomHeader.Name = "pnlArchiveRoomHeader";
            pnlArchiveRoomHeader.Size = new Size(760, 75);
            pnlArchiveRoomHeader.TabIndex = 0;
            // 
            // lblArchiveRoomDescription
            // 
            lblArchiveRoomDescription.Dock = DockStyle.Fill;
            lblArchiveRoomDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveRoomDescription.ForeColor = Color.White;
            lblArchiveRoomDescription.Location = new Point(0, 38);
            lblArchiveRoomDescription.Margin = new Padding(0);
            lblArchiveRoomDescription.Name = "lblArchiveRoomDescription";
            lblArchiveRoomDescription.Size = new Size(758, 35);
            lblArchiveRoomDescription.TabIndex = 1;
            lblArchiveRoomDescription.Text = "Select an empty room to remove from the active room list.";
            lblArchiveRoomDescription.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblArchiveRoomTitle
            // 
            lblArchiveRoomTitle.Dock = DockStyle.Top;
            lblArchiveRoomTitle.Font = new Font("Segoe UI", 13.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveRoomTitle.ForeColor = Color.White;
            lblArchiveRoomTitle.Location = new Point(0, 0);
            lblArchiveRoomTitle.Margin = new Padding(0);
            lblArchiveRoomTitle.Name = "lblArchiveRoomTitle";
            lblArchiveRoomTitle.Size = new Size(758, 38);
            lblArchiveRoomTitle.TabIndex = 0;
            lblArchiveRoomTitle.Text = "Archive Room";
            lblArchiveRoomTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlArchiveRoomActions
            // 
            pnlArchiveRoomActions.BorderStyle = BorderStyle.FixedSingle;
            pnlArchiveRoomActions.Controls.Add(lblSelectedRoom);
            pnlArchiveRoomActions.Controls.Add(btnArchiveSelected);
            pnlArchiveRoomActions.Controls.Add(btnCancelArchiveRoom);
            pnlArchiveRoomActions.Dock = DockStyle.Bottom;
            pnlArchiveRoomActions.Location = new Point(0, 425);
            pnlArchiveRoomActions.Margin = new Padding(0);
            pnlArchiveRoomActions.Name = "pnlArchiveRoomActions";
            pnlArchiveRoomActions.Size = new Size(760, 55);
            pnlArchiveRoomActions.TabIndex = 2;
            // 
            // lblSelectedRoom
            // 
            lblSelectedRoom.AutoSize = true;
            lblSelectedRoom.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSelectedRoom.ForeColor = Color.Silver;
            lblSelectedRoom.Location = new Point(15, 15);
            lblSelectedRoom.Name = "lblSelectedRoom";
            lblSelectedRoom.Size = new Size(146, 23);
            lblSelectedRoom.TabIndex = 2;
            lblSelectedRoom.Text = "No room selected";
            // 
            // btnArchiveSelected
            // 
            btnArchiveSelected.Cursor = Cursors.Hand;
            btnArchiveSelected.Enabled = false;
            btnArchiveSelected.Location = new Point(605, 11);
            btnArchiveSelected.Name = "btnArchiveSelected";
            btnArchiveSelected.Size = new Size(140, 32);
            btnArchiveSelected.TabIndex = 1;
            btnArchiveSelected.Text = "Archive Selected";
            btnArchiveSelected.UseVisualStyleBackColor = true;
            btnArchiveSelected.Click += btnArchiveSelected_Click;
            // 
            // btnCancelArchiveRoom
            // 
            btnCancelArchiveRoom.Cursor = Cursors.Hand;
            btnCancelArchiveRoom.Location = new Point(480, 11);
            btnCancelArchiveRoom.Name = "btnCancelArchiveRoom";
            btnCancelArchiveRoom.Size = new Size(110, 32);
            btnCancelArchiveRoom.TabIndex = 0;
            btnCancelArchiveRoom.Text = "Cancel";
            btnCancelArchiveRoom.UseVisualStyleBackColor = true;
            btnCancelArchiveRoom.Click += btnCancelArchiveRoom_Click;
            // 
            // pnlArchiveRoomContent
            // 
            pnlArchiveRoomContent.Controls.Add(dgvArchivableRooms);
            pnlArchiveRoomContent.Controls.Add(lblNoRooms);
            pnlArchiveRoomContent.Controls.Add(lblArchiveRule);
            pnlArchiveRoomContent.Dock = DockStyle.Fill;
            pnlArchiveRoomContent.Location = new Point(0, 75);
            pnlArchiveRoomContent.Name = "pnlArchiveRoomContent";
            pnlArchiveRoomContent.Padding = new Padding(15, 5, 15, 15);
            pnlArchiveRoomContent.Size = new Size(760, 350);
            pnlArchiveRoomContent.TabIndex = 1;
            // 
            // dgvArchivableRooms
            // 
            dgvArchivableRooms.AllowUserToAddRows = false;
            dgvArchivableRooms.AllowUserToDeleteRows = false;
            dgvArchivableRooms.AllowUserToResizeRows = false;
            dgvArchivableRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchivableRooms.BackgroundColor = Color.DarkGray;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvArchivableRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvArchivableRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArchivableRooms.Columns.AddRange(new DataGridViewColumn[] { colFloor, colRoomNumber, colRoomType, colCapacity, colRoomPrice, colStatus });
            dgvArchivableRooms.Dock = DockStyle.Fill;
            dgvArchivableRooms.Location = new Point(15, 60);
            dgvArchivableRooms.MultiSelect = false;
            dgvArchivableRooms.Name = "dgvArchivableRooms";
            dgvArchivableRooms.ReadOnly = true;
            dgvArchivableRooms.RowHeadersVisible = false;
            dgvArchivableRooms.RowHeadersWidth = 51;
            dgvArchivableRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArchivableRooms.Size = new Size(730, 275);
            dgvArchivableRooms.TabIndex = 0;
            dgvArchivableRooms.SelectionChanged += dgvArchivableRooms_SelectionChanged;
            // 
            // colFloor
            // 
            colFloor.FillWeight = 70F;
            colFloor.HeaderText = "Floor";
            colFloor.MinimumWidth = 6;
            colFloor.Name = "colFloor";
            colFloor.ReadOnly = true;
            // 
            // colRoomNumber
            // 
            colRoomNumber.FillWeight = 80F;
            colRoomNumber.HeaderText = "Room";
            colRoomNumber.MinimumWidth = 6;
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // colRoomType
            // 
            colRoomType.HeaderText = "Type";
            colRoomType.MinimumWidth = 6;
            colRoomType.Name = "colRoomType";
            colRoomType.ReadOnly = true;
            // 
            // colCapacity
            // 
            colCapacity.FillWeight = 80F;
            colCapacity.HeaderText = "Capacity";
            colCapacity.MinimumWidth = 6;
            colCapacity.Name = "colCapacity";
            colCapacity.ReadOnly = true;
            // 
            // colRoomPrice
            // 
            colRoomPrice.HeaderText = "Room Price";
            colRoomPrice.MinimumWidth = 6;
            colRoomPrice.Name = "colRoomPrice";
            colRoomPrice.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lblNoRooms
            // 
            lblNoRooms.Dock = DockStyle.Fill;
            lblNoRooms.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoRooms.ForeColor = Color.Silver;
            lblNoRooms.Location = new Point(15, 60);
            lblNoRooms.Name = "lblNoRooms";
            lblNoRooms.Size = new Size(730, 275);
            lblNoRooms.TabIndex = 2;
            lblNoRooms.Text = "No room can be archived right now.";
            lblNoRooms.TextAlign = ContentAlignment.MiddleCenter;
            lblNoRooms.Visible = false;
            // 
            // lblArchiveRule
            // 
            lblArchiveRule.Dock = DockStyle.Top;
            lblArchiveRule.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveRule.ForeColor = Color.Silver;
            lblArchiveRule.Location = new Point(15, 5);
            lblArchiveRule.Name = "lblArchiveRule";
            lblArchiveRule.Size = new Size(730, 55);
            lblArchiveRule.TabIndex = 1;
            lblArchiveRule.Text = "Only Available and Unconfigured rooms are listed. An occupied room must have its tenants moved out first, and a room under maintenance must have its issue settled first.";
            lblArchiveRule.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ArchiveRoomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(760, 480);
            Controls.Add(pnlArchiveRoomContent);
            Controls.Add(pnlArchiveRoomActions);
            Controls.Add(pnlArchiveRoomHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ArchiveRoomForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Archive Room";
            Load += ArchiveRoomForm_Load;
            pnlArchiveRoomHeader.ResumeLayout(false);
            pnlArchiveRoomActions.ResumeLayout(false);
            pnlArchiveRoomActions.PerformLayout();
            pnlArchiveRoomContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArchivableRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlArchiveRoomHeader;
        private Label lblArchiveRoomTitle;
        private Label lblArchiveRoomDescription;
        private Panel pnlArchiveRoomActions;
        private Label lblSelectedRoom;
        private Button btnArchiveSelected;
        private Button btnCancelArchiveRoom;
        private Panel pnlArchiveRoomContent;
        private Label lblArchiveRule;
        private Label lblNoRooms;
        private DataGridView dgvArchivableRooms;
        private DataGridViewTextBoxColumn colFloor;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colRoomType;
        private DataGridViewTextBoxColumn colCapacity;
        private DataGridViewTextBoxColumn colRoomPrice;
        private DataGridViewTextBoxColumn colStatus;
    }
}