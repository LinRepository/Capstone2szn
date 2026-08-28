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
            cboFloor = new ComboBox();
            lblRoomNumber = new Label();
            lblFloor = new Label();
            lblRoomNumberValue = new Label();
            pnlAddRoomHeader.SuspendLayout();
            pnlAddRoomActions.SuspendLayout();
            pnlAddRoomContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAddRoomHeader
            // 
            pnlAddRoomHeader.Controls.Add(lblAddRoomDescription);
            pnlAddRoomHeader.Controls.Add(lblAddRoomTitle);
            pnlAddRoomHeader.Dock = DockStyle.Top;
            pnlAddRoomHeader.Location = new Point(0, 0);
            pnlAddRoomHeader.Name = "pnlAddRoomHeader";
            pnlAddRoomHeader.Size = new Size(382, 65);
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
            lblAddRoomDescription.Visible = false;
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
            lblAddRoomTitle.Visible = false;
            // 
            // pnlAddRoomActions
            // 
            pnlAddRoomActions.Controls.Add(btnAddRoom);
            pnlAddRoomActions.Controls.Add(btnCancelAddRoom);
            pnlAddRoomActions.Dock = DockStyle.Bottom;
            pnlAddRoomActions.Location = new Point(0, 303);
            pnlAddRoomActions.Name = "pnlAddRoomActions";
            pnlAddRoomActions.Size = new Size(382, 50);
            pnlAddRoomActions.TabIndex = 1;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(255, 11);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(110, 29);
            btnAddRoom.TabIndex = 1;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            // 
            // btnCancelAddRoom
            // 
            btnCancelAddRoom.Location = new Point(143, 11);
            btnCancelAddRoom.Name = "btnCancelAddRoom";
            btnCancelAddRoom.Size = new Size(94, 29);
            btnCancelAddRoom.TabIndex = 0;
            btnCancelAddRoom.Text = "Cancel";
            btnCancelAddRoom.UseVisualStyleBackColor = true;
            // 
            // pnlAddRoomContent
            // 
            pnlAddRoomContent.Controls.Add(lblRoomNumberValue);
            pnlAddRoomContent.Controls.Add(cboFloor);
            pnlAddRoomContent.Controls.Add(lblRoomNumber);
            pnlAddRoomContent.Controls.Add(lblFloor);
            pnlAddRoomContent.Dock = DockStyle.Fill;
            pnlAddRoomContent.Location = new Point(0, 65);
            pnlAddRoomContent.Name = "pnlAddRoomContent";
            pnlAddRoomContent.Size = new Size(382, 238);
            pnlAddRoomContent.TabIndex = 2;
            // 
            // cboFloor
            // 
            cboFloor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFloor.FormattingEnabled = true;
            cboFloor.Location = new Point(52, 64);
            cboFloor.Name = "cboFloor";
            cboFloor.Size = new Size(200, 28);
            cboFloor.TabIndex = 28;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomNumber.Location = new Point(50, 119);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(171, 25);
            lblRoomNumber.TabIndex = 27;
            lblRoomNumber.Text = "Next Room Number";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomNumber.Visible = false;
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloor.ForeColor = Color.White;
            lblFloor.ImageAlign = ContentAlignment.MiddleRight;
            lblFloor.Location = new Point(47, 30);
            lblFloor.Margin = new Padding(0);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(65, 31);
            lblFloor.TabIndex = 26;
            lblFloor.Text = "Floor";
            lblFloor.TextAlign = ContentAlignment.MiddleCenter;
            lblFloor.Visible = false;
            // 
            // lblRoomNumberValue
            // 
            lblRoomNumberValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumberValue.ForeColor = Color.White;
            lblRoomNumberValue.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomNumberValue.Location = new Point(50, 150);
            lblRoomNumberValue.Name = "lblRoomNumberValue";
            lblRoomNumberValue.Size = new Size(66, 25);
            lblRoomNumberValue.TabIndex = 29;
            lblRoomNumberValue.Text = "---";
            lblRoomNumberValue.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomNumberValue.Visible = false;
            // 
            // AddRoomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(382, 353);
            Controls.Add(pnlAddRoomContent);
            Controls.Add(pnlAddRoomActions);
            Controls.Add(pnlAddRoomHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddRoomForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Room";
            pnlAddRoomHeader.ResumeLayout(false);
            pnlAddRoomHeader.PerformLayout();
            pnlAddRoomActions.ResumeLayout(false);
            pnlAddRoomContent.ResumeLayout(false);
            pnlAddRoomContent.PerformLayout();
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
        private Label lblRoomNumber;
        private Label lblFloor;
        private ComboBox cboFloor;
        private Label lblRoomNumberValue;
    }
}