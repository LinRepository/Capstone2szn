namespace Capstoneszn
{
    partial class FloorConfigurationForm
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
            lblTitle = new Label();
            flpFloors = new FlowLayoutPanel();
            pnlFloor = new Panel();
            nudRooms = new NumericUpDown();
            lblRooms = new Label();
            lblFloor = new Label();
            lblDescription = new Label();
            lblBuildingName = new Label();
            btnBack = new Button();
            btnCreate = new Button();
            pnlFloorConfigurationHeader = new Panel();
            pnlFloorConfigurationActionButtons = new Panel();
            pnlFloorConfigurationContent = new Panel();
            flpFloors.SuspendLayout();
            pnlFloor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRooms).BeginInit();
            pnlFloorConfigurationHeader.SuspendLayout();
            pnlFloorConfigurationActionButtons.SuspendLayout();
            pnlFloorConfigurationContent.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(680, 68);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Configure The Floors";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpFloors
            // 
            flpFloors.Anchor = AnchorStyles.None;
            flpFloors.AutoScroll = true;
            flpFloors.BorderStyle = BorderStyle.FixedSingle;
            flpFloors.Controls.Add(pnlFloor);
            flpFloors.FlowDirection = FlowDirection.TopDown;
            flpFloors.Location = new Point(79, 66);
            flpFloors.Name = "flpFloors";
            flpFloors.Size = new Size(520, 450);
            flpFloors.TabIndex = 1;
            flpFloors.WrapContents = false;
            flpFloors.Paint += flpFloors_Paint;
            // 
            // pnlFloor
            // 
            pnlFloor.BackColor = Color.White;
            pnlFloor.Controls.Add(nudRooms);
            pnlFloor.Controls.Add(lblRooms);
            pnlFloor.Controls.Add(lblFloor);
            pnlFloor.Location = new Point(3, 3);
            pnlFloor.Name = "pnlFloor";
            pnlFloor.Size = new Size(512, 100);
            pnlFloor.TabIndex = 0;
            // 
            // nudRooms
            // 
            nudRooms.Location = new Point(88, 54);
            nudRooms.Name = "nudRooms";
            nudRooms.Size = new Size(85, 27);
            nudRooms.TabIndex = 2;
            // 
            // lblRooms
            // 
            lblRooms.AutoSize = true;
            lblRooms.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRooms.Location = new Point(14, 52);
            lblRooms.Name = "lblRooms";
            lblRooms.Size = new Size(72, 25);
            lblRooms.TabIndex = 1;
            lblRooms.Text = "Rooms:";
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloor.Location = new Point(14, 11);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(68, 25);
            lblFloor.TabIndex = 0;
            lblFloor.Text = "Floor 1";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(79, 10);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(373, 25);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Specify how many rooms each floor contains.";
            // 
            // lblBuildingName
            // 
            lblBuildingName.AutoSize = true;
            lblBuildingName.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuildingName.ForeColor = Color.White;
            lblBuildingName.Location = new Point(79, 38);
            lblBuildingName.Name = "lblBuildingName";
            lblBuildingName.Size = new Size(128, 25);
            lblBuildingName.TabIndex = 3;
            lblBuildingName.Text = "Building Name";
            lblBuildingName.Click += lblBuildingName_Click;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.Location = new Point(454, 18);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnCreate
            // 
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.Location = new Point(563, 18);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // pnlFloorConfigurationHeader
            // 
            pnlFloorConfigurationHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlFloorConfigurationHeader.Controls.Add(lblTitle);
            pnlFloorConfigurationHeader.Dock = DockStyle.Top;
            pnlFloorConfigurationHeader.Location = new Point(0, 0);
            pnlFloorConfigurationHeader.Name = "pnlFloorConfigurationHeader";
            pnlFloorConfigurationHeader.Size = new Size(682, 70);
            pnlFloorConfigurationHeader.TabIndex = 6;
            // 
            // pnlFloorConfigurationActionButtons
            // 
            pnlFloorConfigurationActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlFloorConfigurationActionButtons.Controls.Add(btnCreate);
            pnlFloorConfigurationActionButtons.Controls.Add(btnBack);
            pnlFloorConfigurationActionButtons.Dock = DockStyle.Bottom;
            pnlFloorConfigurationActionButtons.Location = new Point(0, 593);
            pnlFloorConfigurationActionButtons.Name = "pnlFloorConfigurationActionButtons";
            pnlFloorConfigurationActionButtons.Size = new Size(682, 60);
            pnlFloorConfigurationActionButtons.TabIndex = 7;
            // 
            // pnlFloorConfigurationContent
            // 
            pnlFloorConfigurationContent.BorderStyle = BorderStyle.FixedSingle;
            pnlFloorConfigurationContent.Controls.Add(flpFloors);
            pnlFloorConfigurationContent.Controls.Add(lblDescription);
            pnlFloorConfigurationContent.Controls.Add(lblBuildingName);
            pnlFloorConfigurationContent.Dock = DockStyle.Fill;
            pnlFloorConfigurationContent.Location = new Point(0, 70);
            pnlFloorConfigurationContent.Name = "pnlFloorConfigurationContent";
            pnlFloorConfigurationContent.Size = new Size(682, 523);
            pnlFloorConfigurationContent.TabIndex = 8;
            // 
            // FloorConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(682, 653);
            Controls.Add(pnlFloorConfigurationContent);
            Controls.Add(pnlFloorConfigurationActionButtons);
            Controls.Add(pnlFloorConfigurationHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FloorConfigurationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FloorConfigurationForm";
            Load += FloorConfigurationForm_Load;
            flpFloors.ResumeLayout(false);
            pnlFloor.ResumeLayout(false);
            pnlFloor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRooms).EndInit();
            pnlFloorConfigurationHeader.ResumeLayout(false);
            pnlFloorConfigurationActionButtons.ResumeLayout(false);
            pnlFloorConfigurationContent.ResumeLayout(false);
            pnlFloorConfigurationContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private FlowLayoutPanel flpFloors;
        private Label lblDescription;
        private Label lblBuildingName;
        private Button btnBack;
        private Button btnCreate;
        private Panel pnlFloor;
        private Label lblFloor;
        private Label lblRooms;
        private NumericUpDown nudRooms;
        private Panel pnlFloorConfigurationHeader;
        private Panel pnlFloorConfigurationActionButtons;
        private Panel pnlFloorConfigurationContent;
    }
}