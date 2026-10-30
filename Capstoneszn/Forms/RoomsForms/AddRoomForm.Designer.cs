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
            pnlElectricityAddRoom = new Panel();
            panel4 = new Panel();
            textBox2 = new TextBox();
            lblElectricityAccountNumber = new Label();
            panel3 = new Panel();
            textBox1 = new TextBox();
            lblElectricityAccountName = new Label();
            panel2 = new Panel();
            lblElectricity = new Label();
            panel1 = new Panel();
            txtSetCapacity = new TextBox();
            lblSetCapacity = new Label();
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
            pnlElectricityAddRoom.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
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
            pnlAddRoomHeader.Size = new Size(457, 65);
            pnlAddRoomHeader.TabIndex = 0;
            // 
            // lblAddRoomDescription
            // 
            lblAddRoomDescription.AutoSize = true;
            lblAddRoomDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddRoomDescription.ForeColor = Color.White;
            lblAddRoomDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblAddRoomDescription.Location = new Point(94, 39);
            lblAddRoomDescription.Name = "lblAddRoomDescription";
            lblAddRoomDescription.Size = new Size(273, 23);
            lblAddRoomDescription.TabIndex = 25;
            lblAddRoomDescription.Text = "Add one room to an existing floor.";
            lblAddRoomDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAddRoomTitle
            // 
            lblAddRoomTitle.AutoSize = true;
            lblAddRoomTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddRoomTitle.ForeColor = Color.White;
            lblAddRoomTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddRoomTitle.Location = new Point(159, 4);
            lblAddRoomTitle.Name = "lblAddRoomTitle";
            lblAddRoomTitle.Size = new Size(134, 35);
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
            pnlAddRoomActions.Location = new Point(0, 553);
            pnlAddRoomActions.Name = "pnlAddRoomActions";
            pnlAddRoomActions.Size = new Size(457, 50);
            pnlAddRoomActions.TabIndex = 1;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(334, 10);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(110, 29);
            btnAddRoom.TabIndex = 1;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnCancelAddRoom
            // 
            btnCancelAddRoom.Location = new Point(226, 10);
            btnCancelAddRoom.Name = "btnCancelAddRoom";
            btnCancelAddRoom.Size = new Size(94, 29);
            btnCancelAddRoom.TabIndex = 0;
            btnCancelAddRoom.Text = "Cancel";
            btnCancelAddRoom.UseVisualStyleBackColor = true;
            btnCancelAddRoom.Click += btnCancelAddRoom_Click;
            // 
            // pnlAddRoomContent
            // 
            pnlAddRoomContent.Controls.Add(pnlElectricityAddRoom);
            pnlAddRoomContent.Controls.Add(pnlRoomPrice);
            pnlAddRoomContent.Controls.Add(pnlRoomType);
            pnlAddRoomContent.Controls.Add(pnlRoomNumber);
            pnlAddRoomContent.Controls.Add(pnlFloor);
            pnlAddRoomContent.Dock = DockStyle.Fill;
            pnlAddRoomContent.Location = new Point(0, 65);
            pnlAddRoomContent.Name = "pnlAddRoomContent";
            pnlAddRoomContent.Size = new Size(457, 488);
            pnlAddRoomContent.TabIndex = 2;
            // 
            // pnlElectricityAddRoom
            // 
            pnlElectricityAddRoom.BorderStyle = BorderStyle.FixedSingle;
            pnlElectricityAddRoom.Controls.Add(panel4);
            pnlElectricityAddRoom.Controls.Add(panel3);
            pnlElectricityAddRoom.Controls.Add(panel2);
            pnlElectricityAddRoom.Controls.Add(panel1);
            pnlElectricityAddRoom.Dock = DockStyle.Fill;
            pnlElectricityAddRoom.Location = new Point(0, 240);
            pnlElectricityAddRoom.Name = "pnlElectricityAddRoom";
            pnlElectricityAddRoom.Size = new Size(457, 248);
            pnlElectricityAddRoom.TabIndex = 39;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(lblElectricityAccountNumber);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 174);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(455, 60);
            panel4.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Left;
            textBox2.Font = new Font("Segoe UI", 13.2000008F);
            textBox2.Location = new Point(190, 10);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(254, 37);
            textBox2.TabIndex = 30;
            // 
            // lblElectricityAccountNumber
            // 
            lblElectricityAccountNumber.Dock = DockStyle.Left;
            lblElectricityAccountNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectricityAccountNumber.ForeColor = Color.White;
            lblElectricityAccountNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblElectricityAccountNumber.Location = new Point(10, 10);
            lblElectricityAccountNumber.Margin = new Padding(0);
            lblElectricityAccountNumber.Name = "lblElectricityAccountNumber";
            lblElectricityAccountNumber.Size = new Size(180, 38);
            lblElectricityAccountNumber.TabIndex = 29;
            lblElectricityAccountNumber.Text = "Elec. Account Number";
            lblElectricityAccountNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(lblElectricityAccountName);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 114);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(455, 60);
            panel3.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Left;
            textBox1.Font = new Font("Segoe UI", 13.2000008F);
            textBox1.Location = new Point(190, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(254, 37);
            textBox1.TabIndex = 29;
            // 
            // lblElectricityAccountName
            // 
            lblElectricityAccountName.Dock = DockStyle.Left;
            lblElectricityAccountName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectricityAccountName.ForeColor = Color.White;
            lblElectricityAccountName.ImageAlign = ContentAlignment.MiddleRight;
            lblElectricityAccountName.Location = new Point(10, 10);
            lblElectricityAccountName.Margin = new Padding(0);
            lblElectricityAccountName.Name = "lblElectricityAccountName";
            lblElectricityAccountName.Size = new Size(180, 38);
            lblElectricityAccountName.TabIndex = 28;
            lblElectricityAccountName.Text = "Elec. Account Name";
            lblElectricityAccountName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblElectricity);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(455, 54);
            panel2.TabIndex = 4;
            // 
            // lblElectricity
            // 
            lblElectricity.AutoSize = true;
            lblElectricity.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectricity.ForeColor = Color.White;
            lblElectricity.ImageAlign = ContentAlignment.MiddleRight;
            lblElectricity.Location = new Point(94, 11);
            lblElectricity.Name = "lblElectricity";
            lblElectricity.Size = new Size(271, 35);
            lblElectricity.TabIndex = 26;
            lblElectricity.Text = "Add Electricity Account";
            lblElectricity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtSetCapacity);
            panel1.Controls.Add(lblSetCapacity);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(455, 60);
            panel1.TabIndex = 3;
            // 
            // txtSetCapacity
            // 
            txtSetCapacity.Dock = DockStyle.Fill;
            txtSetCapacity.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSetCapacity.Location = new Point(190, 10);
            txtSetCapacity.Name = "txtSetCapacity";
            txtSetCapacity.Size = new Size(253, 37);
            txtSetCapacity.TabIndex = 36;
            // 
            // lblSetCapacity
            // 
            lblSetCapacity.Dock = DockStyle.Left;
            lblSetCapacity.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSetCapacity.ForeColor = Color.White;
            lblSetCapacity.ImageAlign = ContentAlignment.MiddleRight;
            lblSetCapacity.Location = new Point(10, 10);
            lblSetCapacity.Margin = new Padding(0);
            lblSetCapacity.Name = "lblSetCapacity";
            lblSetCapacity.Size = new Size(180, 38);
            lblSetCapacity.TabIndex = 35;
            lblSetCapacity.Text = "Set Capacity";
            lblSetCapacity.TextAlign = ContentAlignment.MiddleCenter;
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
            pnlRoomPrice.Size = new Size(457, 60);
            pnlRoomPrice.TabIndex = 38;
            // 
            // txtRoomPrice
            // 
            txtRoomPrice.Dock = DockStyle.Fill;
            txtRoomPrice.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomPrice.Location = new Point(190, 10);
            txtRoomPrice.Name = "txtRoomPrice";
            txtRoomPrice.PlaceholderText = "₱0.00";
            txtRoomPrice.Size = new Size(255, 37);
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
            pnlRoomType.Size = new Size(457, 60);
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
            cboRoomType.Font = new Font("Segoe UI", 12F);
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Location = new Point(190, 11);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new Size(255, 36);
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
            pnlRoomNumber.Size = new Size(457, 60);
            pnlRoomNumber.TabIndex = 36;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Dock = DockStyle.Fill;
            txtRoomNumber.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomNumber.Location = new Point(190, 10);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.PlaceholderText = "e.g 202";
            txtRoomNumber.Size = new Size(255, 37);
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
            pnlFloor.Size = new Size(457, 60);
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
            cboFloor.Font = new Font("Segoe UI", 12F);
            cboFloor.FormattingEnabled = true;
            cboFloor.Location = new Point(190, 11);
            cboFloor.Name = "cboFloor";
            cboFloor.Size = new Size(255, 36);
            cboFloor.TabIndex = 28;
            // 
            // AddRoomForm
            // 
            AcceptButton = btnAddRoom;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            CancelButton = btnCancelAddRoom;
            ClientSize = new Size(457, 603);
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
            pnlElectricityAddRoom.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Panel pnlElectricityAddRoom;
        private Panel panel3;
        private Panel panel4;
        private Label lblElectricityAccountName;
        private Label lblElectricityAccountNumber;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panel1;
        private Label lblSetCapacity;
        private TextBox txtSetCapacity;
        private Panel panel2;
        private Label lblElectricity;
    }
}