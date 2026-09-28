namespace Capstoneszn.Forms
{
    partial class ManageRoomsForm
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
            pnlManageRoomsHeader = new Panel();
            lblArchiveInstruction = new Label();
            btnCloseManageRooms = new Button();
            lblManageRoomsTitle = new Label();
            pnlManageRoomsActions = new Panel();
            btnAddRoom = new Button();
            btnArchiveRoom = new Button();
            pnlManageRoomsContent = new Panel();
            flpManageRooms = new FlowLayoutPanel();
            pnlManageRoomsHeader.SuspendLayout();
            pnlManageRoomsActions.SuspendLayout();
            pnlManageRoomsContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlManageRoomsHeader
            // 
            pnlManageRoomsHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlManageRoomsHeader.Controls.Add(lblArchiveInstruction);
            pnlManageRoomsHeader.Controls.Add(btnCloseManageRooms);
            pnlManageRoomsHeader.Controls.Add(lblManageRoomsTitle);
            pnlManageRoomsHeader.Dock = DockStyle.Top;
            pnlManageRoomsHeader.Location = new Point(0, 0);
            pnlManageRoomsHeader.Name = "pnlManageRoomsHeader";
            pnlManageRoomsHeader.Size = new Size(782, 69);
            pnlManageRoomsHeader.TabIndex = 0;
            // 
            // lblArchiveInstruction
            // 
            lblArchiveInstruction.AutoSize = true;
            lblArchiveInstruction.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArchiveInstruction.ForeColor = Color.White;
            lblArchiveInstruction.ImageAlign = ContentAlignment.MiddleRight;
            lblArchiveInstruction.Location = new Point(283, 42);
            lblArchiveInstruction.Name = "lblArchiveInstruction";
            lblArchiveInstruction.Size = new Size(199, 23);
            lblArchiveInstruction.TabIndex = 23;
            lblArchiveInstruction.Text = "Select a room to archive.";
            lblArchiveInstruction.TextAlign = ContentAlignment.MiddleCenter;
            lblArchiveInstruction.Visible = false;
            // 
            // btnCloseManageRooms
            // 
            btnCloseManageRooms.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseManageRooms.FlatStyle = FlatStyle.Flat;
            btnCloseManageRooms.ForeColor = Color.White;
            btnCloseManageRooms.Location = new Point(738, 12);
            btnCloseManageRooms.Name = "btnCloseManageRooms";
            btnCloseManageRooms.Size = new Size(30, 30);
            btnCloseManageRooms.TabIndex = 22;
            btnCloseManageRooms.TabStop = false;
            btnCloseManageRooms.Text = "X";
            btnCloseManageRooms.UseVisualStyleBackColor = true;
            // 
            // lblManageRoomsTitle
            // 
            lblManageRoomsTitle.AutoSize = true;
            lblManageRoomsTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManageRoomsTitle.ForeColor = Color.White;
            lblManageRoomsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblManageRoomsTitle.Location = new Point(296, 8);
            lblManageRoomsTitle.Name = "lblManageRoomsTitle";
            lblManageRoomsTitle.Size = new Size(173, 31);
            lblManageRoomsTitle.TabIndex = 7;
            lblManageRoomsTitle.Text = "Manage Rooms";
            lblManageRoomsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlManageRoomsActions
            // 
            pnlManageRoomsActions.BorderStyle = BorderStyle.FixedSingle;
            pnlManageRoomsActions.Controls.Add(btnAddRoom);
            pnlManageRoomsActions.Controls.Add(btnArchiveRoom);
            pnlManageRoomsActions.Dock = DockStyle.Top;
            pnlManageRoomsActions.Location = new Point(0, 69);
            pnlManageRoomsActions.Name = "pnlManageRoomsActions";
            pnlManageRoomsActions.Size = new Size(782, 49);
            pnlManageRoomsActions.TabIndex = 9;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(11, 10);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(105, 30);
            btnAddRoom.TabIndex = 0;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnArchiveRoom
            // 
            btnArchiveRoom.Location = new Point(139, 10);
            btnArchiveRoom.Name = "btnArchiveRoom";
            btnArchiveRoom.Size = new Size(105, 30);
            btnArchiveRoom.TabIndex = 0;
            btnArchiveRoom.Text = "Archive Room";
            btnArchiveRoom.UseVisualStyleBackColor = true;
            btnArchiveRoom.Click += btnArchiveRoom_Click;
            // 
            // pnlManageRoomsContent
            // 
            pnlManageRoomsContent.BorderStyle = BorderStyle.FixedSingle;
            pnlManageRoomsContent.Controls.Add(flpManageRooms);
            pnlManageRoomsContent.Dock = DockStyle.Fill;
            pnlManageRoomsContent.Location = new Point(0, 118);
            pnlManageRoomsContent.Name = "pnlManageRoomsContent";
            pnlManageRoomsContent.Padding = new Padding(10);
            pnlManageRoomsContent.Size = new Size(782, 435);
            pnlManageRoomsContent.TabIndex = 10;
            // 
            // flpManageRooms
            // 
            flpManageRooms.AutoScroll = true;
            flpManageRooms.BorderStyle = BorderStyle.FixedSingle;
            flpManageRooms.Dock = DockStyle.Fill;
            flpManageRooms.FlowDirection = FlowDirection.TopDown;
            flpManageRooms.Location = new Point(10, 10);
            flpManageRooms.Name = "flpManageRooms";
            flpManageRooms.Size = new Size(760, 413);
            flpManageRooms.TabIndex = 0;
            flpManageRooms.WrapContents = false;
            // 
            // ManageRoomsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(782, 553);
            Controls.Add(pnlManageRoomsContent);
            Controls.Add(pnlManageRoomsActions);
            Controls.Add(pnlManageRoomsHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageRoomsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Rooms";
            Load += ManageRoomsForm_Load;
            pnlManageRoomsHeader.ResumeLayout(false);
            pnlManageRoomsHeader.PerformLayout();
            pnlManageRoomsActions.ResumeLayout(false);
            pnlManageRoomsContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlManageRoomsHeader;
        private Label lblManageRoomsTitle;
        private Button btnCloseManageRooms;
        private Panel pnlManageRoomsActions;
        private Button btnAddRoom;
        private Button btnArchiveRoom;
        private Panel pnlManageRoomsContent;
        private FlowLayoutPanel flpManageRooms;
        private Label lblArchiveInstruction;
    }
}