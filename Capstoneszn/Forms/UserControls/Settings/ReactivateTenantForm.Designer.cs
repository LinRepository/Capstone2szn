namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class ReactivateTenantForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReactivateTenantForm));
            pnlReactivateHeader = new Panel();
            lblTenantSummary = new Label();
            lblReactivateTitle = new Label();
            pnlReactivateActions = new Panel();
            lblSelectedRoom = new Label();
            btnContinueReactivate = new Button();
            btnCancelReactivate = new Button();
            pnlReactivateContent = new Panel();
            dgvAvailableRooms = new DataGridView();
            colFloor = new DataGridViewTextBoxColumn();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colRoomType = new DataGridViewTextBoxColumn();
            colOccupancy = new DataGridViewTextBoxColumn();
            colRoomPrice = new DataGridViewTextBoxColumn();
            colOnReactivation = new DataGridViewTextBoxColumn();
            lblNoRooms = new Label();
            lblReactivateRule = new Label();
            pnlReactivateHeader.SuspendLayout();
            pnlReactivateActions.SuspendLayout();
            pnlReactivateContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableRooms).BeginInit();
            SuspendLayout();
            // 
            // pnlReactivateHeader
            // 
            pnlReactivateHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlReactivateHeader.Controls.Add(lblTenantSummary);
            pnlReactivateHeader.Controls.Add(lblReactivateTitle);
            pnlReactivateHeader.Dock = DockStyle.Top;
            pnlReactivateHeader.Location = new Point(0, 0);
            pnlReactivateHeader.Margin = new Padding(0);
            pnlReactivateHeader.Name = "pnlReactivateHeader";
            pnlReactivateHeader.Size = new Size(860, 80);
            pnlReactivateHeader.TabIndex = 0;
            // 
            // lblTenantSummary
            // 
            lblTenantSummary.Dock = DockStyle.Fill;
            lblTenantSummary.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantSummary.ForeColor = Color.White;
            lblTenantSummary.Location = new Point(0, 38);
            lblTenantSummary.Margin = new Padding(0);
            lblTenantSummary.Name = "lblTenantSummary";
            lblTenantSummary.Size = new Size(858, 40);
            lblTenantSummary.TabIndex = 1;
            lblTenantSummary.Text = "-";
            lblTenantSummary.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblReactivateTitle
            // 
            lblReactivateTitle.Dock = DockStyle.Top;
            lblReactivateTitle.Font = new Font("Segoe UI", 13.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReactivateTitle.ForeColor = Color.White;
            lblReactivateTitle.Location = new Point(0, 0);
            lblReactivateTitle.Margin = new Padding(0);
            lblReactivateTitle.Name = "lblReactivateTitle";
            lblReactivateTitle.Size = new Size(858, 38);
            lblReactivateTitle.TabIndex = 0;
            lblReactivateTitle.Text = "Reactivate Tenant";
            lblReactivateTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlReactivateActions
            // 
            pnlReactivateActions.BorderStyle = BorderStyle.FixedSingle;
            pnlReactivateActions.Controls.Add(lblSelectedRoom);
            pnlReactivateActions.Controls.Add(btnContinueReactivate);
            pnlReactivateActions.Controls.Add(btnCancelReactivate);
            pnlReactivateActions.Dock = DockStyle.Bottom;
            pnlReactivateActions.Location = new Point(0, 445);
            pnlReactivateActions.Margin = new Padding(0);
            pnlReactivateActions.Name = "pnlReactivateActions";
            pnlReactivateActions.Size = new Size(860, 55);
            pnlReactivateActions.TabIndex = 2;
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
            // btnContinueReactivate
            // 
            btnContinueReactivate.Cursor = Cursors.Hand;
            btnContinueReactivate.Enabled = false;
            btnContinueReactivate.Location = new Point(705, 11);
            btnContinueReactivate.Name = "btnContinueReactivate";
            btnContinueReactivate.Size = new Size(140, 32);
            btnContinueReactivate.TabIndex = 1;
            btnContinueReactivate.Text = "Continue";
            btnContinueReactivate.UseVisualStyleBackColor = true;
            btnContinueReactivate.Click += btnContinueReactivate_Click;
            // 
            // btnCancelReactivate
            // 
            btnCancelReactivate.Cursor = Cursors.Hand;
            btnCancelReactivate.Location = new Point(580, 11);
            btnCancelReactivate.Name = "btnCancelReactivate";
            btnCancelReactivate.Size = new Size(110, 32);
            btnCancelReactivate.TabIndex = 0;
            btnCancelReactivate.Text = "Cancel";
            btnCancelReactivate.UseVisualStyleBackColor = true;
            btnCancelReactivate.Click += btnCancelReactivate_Click;
            // 
            // pnlReactivateContent
            // 
            pnlReactivateContent.Controls.Add(dgvAvailableRooms);
            pnlReactivateContent.Controls.Add(lblNoRooms);
            pnlReactivateContent.Controls.Add(lblReactivateRule);
            pnlReactivateContent.Dock = DockStyle.Fill;
            pnlReactivateContent.Location = new Point(0, 80);
            pnlReactivateContent.Name = "pnlReactivateContent";
            pnlReactivateContent.Padding = new Padding(15, 5, 15, 15);
            pnlReactivateContent.Size = new Size(860, 365);
            pnlReactivateContent.TabIndex = 1;
            // 
            // dgvAvailableRooms
            // 
            dgvAvailableRooms.AllowUserToAddRows = false;
            dgvAvailableRooms.AllowUserToDeleteRows = false;
            dgvAvailableRooms.AllowUserToResizeRows = false;
            dgvAvailableRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailableRooms.BackgroundColor = Color.DarkGray;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAvailableRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAvailableRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvailableRooms.Columns.AddRange(new DataGridViewColumn[] { colFloor, colRoomNumber, colRoomType, colOccupancy, colRoomPrice, colOnReactivation });
            dgvAvailableRooms.Dock = DockStyle.Fill;
            dgvAvailableRooms.Location = new Point(15, 65);
            dgvAvailableRooms.MultiSelect = false;
            dgvAvailableRooms.Name = "dgvAvailableRooms";
            dgvAvailableRooms.ReadOnly = true;
            dgvAvailableRooms.RowHeadersVisible = false;
            dgvAvailableRooms.RowHeadersWidth = 51;
            dgvAvailableRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableRooms.Size = new Size(830, 285);
            dgvAvailableRooms.TabIndex = 0;
            dgvAvailableRooms.SelectionChanged += dgvAvailableRooms_SelectionChanged;
            // 
            // colFloor
            // 
            colFloor.FillWeight = 60F;
            colFloor.HeaderText = "Floor";
            colFloor.MinimumWidth = 6;
            colFloor.Name = "colFloor";
            colFloor.ReadOnly = true;
            // 
            // colRoomNumber
            // 
            colRoomNumber.FillWeight = 70F;
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
            // colOccupancy
            // 
            colOccupancy.FillWeight = 80F;
            colOccupancy.HeaderText = "Occupancy";
            colOccupancy.MinimumWidth = 6;
            colOccupancy.Name = "colOccupancy";
            colOccupancy.ReadOnly = true;
            // 
            // colRoomPrice
            // 
            colRoomPrice.HeaderText = "Room Price";
            colRoomPrice.MinimumWidth = 6;
            colRoomPrice.Name = "colRoomPrice";
            colRoomPrice.ReadOnly = true;
            // 
            // colOnReactivation
            // 
            colOnReactivation.FillWeight = 170F;
            colOnReactivation.HeaderText = "On Reactivation";
            colOnReactivation.MinimumWidth = 6;
            colOnReactivation.Name = "colOnReactivation";
            colOnReactivation.ReadOnly = true;
            // 
            // lblNoRooms
            // 
            lblNoRooms.Dock = DockStyle.Fill;
            lblNoRooms.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoRooms.ForeColor = Color.Silver;
            lblNoRooms.Location = new Point(15, 65);
            lblNoRooms.Name = "lblNoRooms";
            lblNoRooms.Size = new Size(830, 285);
            lblNoRooms.TabIndex = 2;
            lblNoRooms.Text = "No room has space right now. Configure a room or free a bed first.";
            lblNoRooms.TextAlign = ContentAlignment.MiddleCenter;
            lblNoRooms.Visible = false;
            // 
            // lblReactivateRule
            // 
            lblReactivateRule.Dock = DockStyle.Top;
            lblReactivateRule.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReactivateRule.ForeColor = Color.Silver;
            lblReactivateRule.Location = new Point(15, 5);
            lblReactivateRule.Name = "lblReactivateRule";
            lblReactivateRule.Size = new Size(830, 60);
            lblReactivateRule.TabIndex = 1;
            lblReactivateRule.Text = resources.GetString("lblReactivateRule.Text");
            lblReactivateRule.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ReactivateTenantForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(860, 500);
            Controls.Add(pnlReactivateContent);
            Controls.Add(pnlReactivateActions);
            Controls.Add(pnlReactivateHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReactivateTenantForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reactivate Tenant";
            Load += ReactivateTenantForm_Load;
            pnlReactivateHeader.ResumeLayout(false);
            pnlReactivateActions.ResumeLayout(false);
            pnlReactivateActions.PerformLayout();
            pnlReactivateContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAvailableRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlReactivateHeader;
        private Label lblReactivateTitle;
        private Label lblTenantSummary;
        private Panel pnlReactivateActions;
        private Label lblSelectedRoom;
        private Button btnContinueReactivate;
        private Button btnCancelReactivate;
        private Panel pnlReactivateContent;
        private Label lblReactivateRule;
        private Label lblNoRooms;
        private DataGridView dgvAvailableRooms;
        private DataGridViewTextBoxColumn colFloor;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colRoomType;
        private DataGridViewTextBoxColumn colOccupancy;
        private DataGridViewTextBoxColumn colRoomPrice;
        private DataGridViewTextBoxColumn colOnReactivation;
    }
}