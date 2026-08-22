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
            btnCloseManageRooms = new Button();
            lblManageRoomsTitle = new Label();
            pnlManageRoomsActions = new Panel();
            btnSetGlobalRent = new Button();
            btnAddRoom = new Button();
            btnArchiveRoom = new Button();
            pnlManageRoomsContent = new Panel();
            flpManageRooms = new FlowLayoutPanel();
            pnlFloorSection = new Panel();
            lblFloor = new Label();
            flpFloorRooms = new FlowLayoutPanel();
            label2 = new Label();
            lblArchiveInstruction = new Label();
            pnlManageRoomsHeader.SuspendLayout();
            pnlManageRoomsActions.SuspendLayout();
            pnlManageRoomsContent.SuspendLayout();
            flpManageRooms.SuspendLayout();
            pnlFloorSection.SuspendLayout();
            flpFloorRooms.SuspendLayout();
            SuspendLayout();
            // 
            // pnlManageRoomsHeader
            // 
            pnlManageRoomsHeader.Controls.Add(lblArchiveInstruction);
            pnlManageRoomsHeader.Controls.Add(btnCloseManageRooms);
            pnlManageRoomsHeader.Controls.Add(lblManageRoomsTitle);
            pnlManageRoomsHeader.Dock = DockStyle.Top;
            pnlManageRoomsHeader.Location = new Point(0, 0);
            pnlManageRoomsHeader.Name = "pnlManageRoomsHeader";
            pnlManageRoomsHeader.Size = new Size(782, 69);
            pnlManageRoomsHeader.TabIndex = 0;
            // 
            // btnCloseManageRooms
            // 
            btnCloseManageRooms.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseManageRooms.FlatStyle = FlatStyle.Flat;
            btnCloseManageRooms.ForeColor = Color.White;
            btnCloseManageRooms.Location = new Point(740, 12);
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
            pnlManageRoomsActions.Controls.Add(btnSetGlobalRent);
            pnlManageRoomsActions.Controls.Add(btnAddRoom);
            pnlManageRoomsActions.Controls.Add(btnArchiveRoom);
            pnlManageRoomsActions.Dock = DockStyle.Top;
            pnlManageRoomsActions.Location = new Point(0, 69);
            pnlManageRoomsActions.Name = "pnlManageRoomsActions";
            pnlManageRoomsActions.Size = new Size(782, 49);
            pnlManageRoomsActions.TabIndex = 9;
            // 
            // btnSetGlobalRent
            // 
            btnSetGlobalRent.Location = new Point(637, 9);
            btnSetGlobalRent.Name = "btnSetGlobalRent";
            btnSetGlobalRent.Size = new Size(135, 30);
            btnSetGlobalRent.TabIndex = 10;
            btnSetGlobalRent.Text = "Set Global Rent";
            btnSetGlobalRent.UseVisualStyleBackColor = true;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(340, 9);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(105, 30);
            btnAddRoom.TabIndex = 0;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            // 
            // btnArchiveRoom
            // 
            btnArchiveRoom.Location = new Point(10, 10);
            btnArchiveRoom.Name = "btnArchiveRoom";
            btnArchiveRoom.Size = new Size(105, 30);
            btnArchiveRoom.TabIndex = 0;
            btnArchiveRoom.Text = "Archive Room";
            btnArchiveRoom.UseVisualStyleBackColor = true;
            // 
            // pnlManageRoomsContent
            // 
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
            flpManageRooms.Controls.Add(pnlFloorSection);
            flpManageRooms.Dock = DockStyle.Fill;
            flpManageRooms.FlowDirection = FlowDirection.TopDown;
            flpManageRooms.Location = new Point(10, 10);
            flpManageRooms.Name = "flpManageRooms";
            flpManageRooms.Size = new Size(762, 415);
            flpManageRooms.TabIndex = 0;
            flpManageRooms.WrapContents = false;
            // 
            // pnlFloorSection
            // 
            pnlFloorSection.Controls.Add(flpFloorRooms);
            pnlFloorSection.Controls.Add(lblFloor);
            pnlFloorSection.Location = new Point(5, 5);
            pnlFloorSection.Margin = new Padding(5);
            pnlFloorSection.Name = "pnlFloorSection";
            pnlFloorSection.Padding = new Padding(5);
            pnlFloorSection.Size = new Size(752, 95);
            pnlFloorSection.TabIndex = 0;
            // 
            // lblFloor
            // 
            lblFloor.Dock = DockStyle.Top;
            lblFloor.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloor.ForeColor = Color.White;
            lblFloor.ImageAlign = ContentAlignment.MiddleRight;
            lblFloor.Location = new Point(5, 5);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(742, 25);
            lblFloor.TabIndex = 8;
            lblFloor.Text = "Floor 1";
            lblFloor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flpFloorRooms
            // 
            flpFloorRooms.Controls.Add(label2);
            flpFloorRooms.Dock = DockStyle.Fill;
            flpFloorRooms.Location = new Point(5, 30);
            flpFloorRooms.Name = "flpFloorRooms";
            flpFloorRooms.Padding = new Padding(5);
            flpFloorRooms.Size = new Size(742, 60);
            flpFloorRooms.TabIndex = 9;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Cursor = Cursors.Hand;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.ImageAlign = ContentAlignment.MiddleRight;
            label2.Location = new Point(10, 10);
            label2.Margin = new Padding(5);
            label2.Name = "label2";
            label2.Size = new Size(65, 40);
            label2.TabIndex = 8;
            label2.Text = "101";
            label2.TextAlign = ContentAlignment.MiddleCenter;
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
            pnlManageRoomsHeader.ResumeLayout(false);
            pnlManageRoomsHeader.PerformLayout();
            pnlManageRoomsActions.ResumeLayout(false);
            pnlManageRoomsContent.ResumeLayout(false);
            flpManageRooms.ResumeLayout(false);
            pnlFloorSection.ResumeLayout(false);
            flpFloorRooms.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlManageRoomsHeader;
        private Label lblManageRoomsTitle;
        private Button btnCloseManageRooms;
        private Panel pnlManageRoomsActions;
        private Button btnSetGlobalRent;
        private Button btnAddRoom;
        private Button btnArchiveRoom;
        private Panel pnlManageRoomsContent;
        private FlowLayoutPanel flpManageRooms;
        private Panel pnlFloorSection;
        private FlowLayoutPanel flpFloorRooms;
        private Label lblFloor;
        private Label label2;
        private Label lblArchiveInstruction;
    }
}