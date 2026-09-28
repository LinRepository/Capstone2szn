namespace Capstoneszn.Forms
{
    partial class AddRoomForm
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
            pnlAddRoomHeader = new Panel();
            lblAddRoomDescription = new Label();
            lblAddRoomTitle = new Label();
            pnlAddRoomActions = new Panel();
            btnAddRoom = new Button();
            btnCancelAddRoom = new Button();
            pnlAddRoomContent = new Panel();
            pnlRoomPrice = new Panel();
            txtRoomPrice = new TextBox();
            lblRoomPrice = new Label();
            pnlRoomType = new Panel();
            lblRoomType = new Label();
            cboRoomType = new ComboBox();
            pnlRoomNumber = new Panel();
            txtRoomNumber = new TextBox();
            lblRoomNumber = new Label();
            pnlFloor = new Panel();
            lblFloor = new Label();
            cboFloor = new ComboBox();
            pnlAddRoomHeader.SuspendLayout();
            pnlAddRoomActions.SuspendLayout();
            pnlAddRoomContent.SuspendLayout();
            pnlRoomPrice.SuspendLayout();
            pnlRoomType.SuspendLayout();
            pnlRoomNumber.SuspendLayout();
            pnlFloor.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAddRoomHeader
            // 
            pnlAddRoomHeader.Controls.Add(lblAddRoomDescription);
            pnlAddRoomHeader.Controls.Add(lblAddRoomTitle);
            pnlAddRoomHeader.Dock = DockStyle.Top;
            pnlAddRoomHeader.Location = new Point(0, 0);
            pnlAddRoomHeader.Name = "pnlAddRoomHeader";
            pnlAddRoomHeader.Size = new Size(432, 65);
            pnlAddRoomHeader.TabIndex = 0;
            // 
            // lblAddRoomDescription
            // 
            lblAddRoomDescription.AutoSize = true;
            lblAddRoomDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddRoomDescription.ForeColor = Color.White;
            lblAddRoomDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblAddRoomDescription.Location = new Point(54, 36);
            lblAddRoomDescription.Name = "lblAddRoomDescription";
            lblAddRoomDescription.Size = new Size(273, 23);
            lblAddRoomDescription.TabIndex = 25;
            lblAddRoomDescription.Text = "Add one room to an existing floor.";
            lblAddRoomDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAddRoomTitle
            // 
            lblAddRoomTitle.AutoSize = true;
            lblAddRoomTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddRoomTitle.ForeColor = Color.White;
            lblAddRoomTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddRoomTitle.Location = new Point(131, 5);
            lblAddRoomTitle.Name = "lblAddRoomTitle";
            lblAddRoomTitle.Size = new Size(106, 28);
            lblAddRoomTitle.TabIndex = 24;
            lblAddRoomTitle.Text = "Add Room";
            lblAddRoomTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAddRoomActions
            // 
            pnlAddRoomActions.BorderStyle = BorderStyle.FixedSingle;
            pnlAddRoomActions.Controls.Add(btnAddRoom);
            pnlAddRoomActions.Controls.Add(btnCancelAddRoom);
            pnlAddRoomActions.Dock = DockStyle.Bottom;
            pnlAddRoomActions.Location = new Point(0, 342);
            pnlAddRoomActions.Name = "pnlAddRoomActions";
            pnlAddRoomActions.Size = new Size(432, 50);
            pnlAddRoomActions.TabIndex = 1;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(298, 11);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(110, 29);
            btnAddRoom.TabIndex = 1;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnCancelAddRoom
            // 
            btnCancelAddRoom.Location = new Point(190, 11);
            btnCancelAddRoom.Name = "btnCancelAddRoom";
            btnCancelAddRoom.Size = new Size(94, 29);
            btnCancelAddRoom.TabIndex = 0;
            btnCancelAddRoom.Text = "Cancel";
            btnCancelAddRoom.UseVisualStyleBackColor = true;
            btnCancelAddRoom.Click += btnCancelAddRoom_Click;
            // 
            // pnlAddRoomContent
            // 
            pnlAddRoomContent.Controls.Add(pnlRoomPrice);
            pnlAddRoomContent.Controls.Add(pnlRoomType);
            pnlAddRoomContent.Controls.Add(pnlRoomNumber);
            pnlAddRoomContent.Controls.Add(pnlFloor);
            pnlAddRoomContent.Dock = DockStyle.Fill;
            pnlAddRoomContent.Location = new Point(0, 65);
            pnlAddRoomContent.Name = "pnlAddRoomContent";
            pnlAddRoomContent.Size = new Size(432, 277);
            pnlAddRoomContent.TabIndex = 2;
            // 
            // pnlRoomPrice
            // 
            pnlRoomPrice.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomPrice.Controls.Add(txtRoomPrice);
            pnlRoomPrice.Controls.Add(lblRoomPrice);
            pnlRoomPrice.Dock = DockStyle.Top;
            pnlRoomPrice.Location = new Point(0, 180);
            pnlRoomPrice.Name = "pnlRoomPrice";
            pnlRoomPrice.Padding = new Padding(10);
            pnlRoomPrice.Size = new Size(432, 60);
            pnlRoomPrice.TabIndex = 38;
            // 
            // txtRoomPrice
            // 
            txtRoomPrice.Dock = DockStyle.Fill;
            txtRoomPrice.Location = new Point(190, 10);
            txtRoomPrice.Multiline = true;
            txtRoomPrice.Name = "txtRoomPrice";
            txtRoomPrice.Size = new Size(230, 38);
            txtRoomPrice.TabIndex = 35;
            // 
            // lblRoomPrice
            // 
            lblRoomPrice.Dock = DockStyle.Left;
            lblRoomPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomPrice.ForeColor = Color.White;
            lblRoomPrice.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomPrice.Location = new Point(10, 10);
            lblRoomPrice.Margin = new Padding(0);
            lblRoomPrice.Name = "lblRoomPrice";
            lblRoomPrice.Size = new Size(180, 38);
            lblRoomPrice.TabIndex = 34;
            lblRoomPrice.Text = "Room Price";
            lblRoomPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomType
            // 
            pnlRoomType.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomType.Controls.Add(lblRoomType);
            pnlRoomType.Controls.Add(cboRoomType);
            pnlRoomType.Dock = DockStyle.Top;
            pnlRoomType.Location = new Point(0, 120);
            pnlRoomType.Name = "pnlRoomType";
            pnlRoomType.Padding = new Padding(10);
            pnlRoomType.Size = new Size(432, 60);
            pnlRoomType.TabIndex = 37;
            // 
            // lblRoomType
            // 
            lblRoomType.Dock = DockStyle.Left;
            lblRoomType.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomType.ForeColor = Color.White;
            lblRoomType.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomType.Location = new Point(10, 10);
            lblRoomType.Margin = new Padding(0);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(180, 38);
            lblRoomType.TabIndex = 31;
            lblRoomType.Text = "Room Type";
            lblRoomType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboRoomType
            // 
            cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(190, 17);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(230, 28);
            cboRoomType.TabIndex = 31;
            // 
            // pnlRoomNumber
            // 
            pnlRoomNumber.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomNumber.Controls.Add(txtRoomNumber);
            pnlRoomNumber.Controls.Add(lblRoomNumber);
            pnlRoomNumber.Dock = DockStyle.Top;
            pnlRoomNumber.Location = new Point(0, 60);
            pnlRoomNumber.Name = "pnlRoomNumber";
            pnlRoomNumber.Padding = new Padding(10);
            pnlRoomNumber.Size = new Size(432, 60);
            pnlRoomNumber.TabIndex = 36;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Dock = DockStyle.Fill;
            txtRoomNumber.Location = new Point(190, 10);
            txtRoomNumber.Multiline = true;
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(230, 38);
            txtRoomNumber.TabIndex = 35;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.Dock = DockStyle.Left;
            lblRoomNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomNumber.Location = new Point(10, 10);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(180, 38);
            lblRoomNumber.TabIndex = 28;
            lblRoomNumber.Text = "Room Number";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFloor
            // 
            pnlFloor.BorderStyle = BorderStyle.FixedSingle;
            pnlFloor.Controls.Add(lblFloor);
            pnlFloor.Controls.Add(cboFloor);
            pnlFloor.Dock = DockStyle.Top;
            pnlFloor.Location = new Point(0, 0);
            pnlFloor.Name = "pnlFloor";
            pnlFloor.Padding = new Padding(10);
            pnlFloor.Size = new Size(432, 60);
            pnlFloor.TabIndex = 35;
            // 
            // lblFloor
            // 
            lblFloor.Dock = DockStyle.Left;
            lblFloor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloor.ForeColor = Color.White;
            lblFloor.ImageAlign = ContentAlignment.MiddleRight;
            lblFloor.Location = new Point(10, 10);
            lblFloor.Margin = new Padding(0);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(180, 38);
            lblFloor.TabIndex = 27;
            lblFloor.Text = "Floor";
            lblFloor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboFloor
            // 
            cboFloor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFloor.FormattingEnabled = true;
            cboFloor.Location = new Point(190, 15);
            cboFloor.Name = "cboFloor";
            cboFloor.Size = new Size(230, 28);
            cboFloor.TabIndex = 28;
            // 
            // AddRoomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(432, 392);
            Controls.Add(pnlAddRoomContent);
            Controls.Add(pnlAddRoomActions);
            Controls.Add(pnlAddRoomHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddRoomForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Room";
            Load += AddRoomForm_Load;
            pnlAddRoomHeader.ResumeLayout(false);
            pnlAddRoomHeader.PerformLayout();
            pnlAddRoomActions.ResumeLayout(false);
            pnlAddRoomContent.ResumeLayout(false);
            pnlRoomPrice.ResumeLayout(false);
            pnlRoomPrice.PerformLayout();
            pnlRoomType.ResumeLayout(false);
            pnlRoomNumber.ResumeLayout(false);
            pnlRoomNumber.PerformLayout();
            pnlFloor.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAddRoomHeader;
        private Panel pnlAddRoomActions;
        private Panel pnlAddRoomContent;
        private Button btnAddRoom;
        private Button btnCancelAddRoom;
        private Label lblAddRoomDescription;
        private Label lblAddRoomTitle;
        private ComboBox cboFloor;
        private ComboBox cboRoomType;
        private Panel pnlFloor;
        private Panel pnlRoomPrice;
        private Label lblRoomPrice;
        private Panel pnlRoomType;
        private Label lblRoomType;
        private Panel pnlRoomNumber;
        private Label lblRoomNumber;
        private Label lblFloor;
        private TextBox txtRoomPrice;
        private TextBox txtRoomNumber;
    }
}