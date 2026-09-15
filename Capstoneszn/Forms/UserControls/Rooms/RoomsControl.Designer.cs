namespace Capstoneszn.UserControls
{
    partial class RoomsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlRoomsHeader = new Panel();
            lblRoomsTitle = new Label();
            pnlRoomsHeaderContent = new Panel();
            panel3 = new Panel();
            lblLegendMaintenance = new Label();
            pnlLegendMaintenance = new Panel();
            panel2 = new Panel();
            lblLegendOccupied = new Label();
            pnlLegendOccupied = new Panel();
            panel1 = new Panel();
            lblLegendAvailable = new Label();
            pnlLegendAvailable = new Panel();
            btnManageRooms = new Button();
            pnlRoomsContent = new Panel();
            flpRoomsOverview = new FlowLayoutPanel();
            pnlFloorSection = new Panel();
            flpFloorRooms = new FlowLayoutPanel();
            lblFloor = new Label();
            pnlRoomsHeader.SuspendLayout();
            pnlRoomsHeaderContent.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            pnlRoomsContent.SuspendLayout();
            flpRoomsOverview.SuspendLayout();
            pnlFloorSection.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomsHeader
            // 
            pnlRoomsHeader.Controls.Add(lblRoomsTitle);
            pnlRoomsHeader.Dock = DockStyle.Top;
            pnlRoomsHeader.Location = new Point(5, 5);
            pnlRoomsHeader.Margin = new Padding(0);
            pnlRoomsHeader.Name = "pnlRoomsHeader";
            pnlRoomsHeader.Size = new Size(1290, 85);
            pnlRoomsHeader.TabIndex = 0;
            // 
            // lblRoomsTitle
            // 
            lblRoomsTitle.BorderStyle = BorderStyle.FixedSingle;
            lblRoomsTitle.Dock = DockStyle.Fill;
            lblRoomsTitle.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomsTitle.ForeColor = Color.White;
            lblRoomsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomsTitle.Location = new Point(0, 0);
            lblRoomsTitle.Margin = new Padding(0);
            lblRoomsTitle.Name = "lblRoomsTitle";
            lblRoomsTitle.Size = new Size(1290, 85);
            lblRoomsTitle.TabIndex = 23;
            lblRoomsTitle.Text = "Rooms";
            lblRoomsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomsHeaderContent
            // 
            pnlRoomsHeaderContent.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomsHeaderContent.Controls.Add(panel3);
            pnlRoomsHeaderContent.Controls.Add(panel2);
            pnlRoomsHeaderContent.Controls.Add(panel1);
            pnlRoomsHeaderContent.Controls.Add(btnManageRooms);
            pnlRoomsHeaderContent.Dock = DockStyle.Top;
            pnlRoomsHeaderContent.Location = new Point(5, 90);
            pnlRoomsHeaderContent.Name = "pnlRoomsHeaderContent";
            pnlRoomsHeaderContent.Padding = new Padding(10, 5, 10, 5);
            pnlRoomsHeaderContent.Size = new Size(1290, 70);
            pnlRoomsHeaderContent.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblLegendMaintenance);
            panel3.Controls.Add(pnlLegendMaintenance);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(410, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 58);
            panel3.TabIndex = 32;
            // 
            // lblLegendMaintenance
            // 
            lblLegendMaintenance.AutoSize = true;
            lblLegendMaintenance.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLegendMaintenance.ForeColor = Color.White;
            lblLegendMaintenance.ImageAlign = ContentAlignment.MiddleRight;
            lblLegendMaintenance.Location = new Point(62, 17);
            lblLegendMaintenance.Margin = new Padding(0);
            lblLegendMaintenance.Name = "lblLegendMaintenance";
            lblLegendMaintenance.Size = new Size(112, 25);
            lblLegendMaintenance.TabIndex = 28;
            lblLegendMaintenance.Text = "Maintenance";
            lblLegendMaintenance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLegendMaintenance
            // 
            pnlLegendMaintenance.BackColor = Color.LightSlateGray;
            pnlLegendMaintenance.Location = new Point(35, 17);
            pnlLegendMaintenance.Name = "pnlLegendMaintenance";
            pnlLegendMaintenance.Size = new Size(25, 25);
            pnlLegendMaintenance.TabIndex = 25;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblLegendOccupied);
            panel2.Controls.Add(pnlLegendOccupied);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(210, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 58);
            panel2.TabIndex = 31;
            // 
            // lblLegendOccupied
            // 
            lblLegendOccupied.AutoSize = true;
            lblLegendOccupied.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLegendOccupied.ForeColor = Color.White;
            lblLegendOccupied.ImageAlign = ContentAlignment.MiddleRight;
            lblLegendOccupied.Location = new Point(70, 17);
            lblLegendOccupied.Margin = new Padding(0);
            lblLegendOccupied.Name = "lblLegendOccupied";
            lblLegendOccupied.Size = new Size(87, 25);
            lblLegendOccupied.TabIndex = 27;
            lblLegendOccupied.Text = "Occupied";
            lblLegendOccupied.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLegendOccupied
            // 
            pnlLegendOccupied.BackColor = Color.Crimson;
            pnlLegendOccupied.Location = new Point(42, 17);
            pnlLegendOccupied.Name = "pnlLegendOccupied";
            pnlLegendOccupied.Size = new Size(25, 25);
            pnlLegendOccupied.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblLegendAvailable);
            panel1.Controls.Add(pnlLegendAvailable);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(10, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 58);
            panel1.TabIndex = 30;
            // 
            // lblLegendAvailable
            // 
            lblLegendAvailable.AutoSize = true;
            lblLegendAvailable.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLegendAvailable.ForeColor = Color.White;
            lblLegendAvailable.ImageAlign = ContentAlignment.MiddleRight;
            lblLegendAvailable.Location = new Point(63, 17);
            lblLegendAvailable.Margin = new Padding(0);
            lblLegendAvailable.Name = "lblLegendAvailable";
            lblLegendAvailable.Size = new Size(83, 25);
            lblLegendAvailable.TabIndex = 26;
            lblLegendAvailable.Text = "Available";
            lblLegendAvailable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLegendAvailable
            // 
            pnlLegendAvailable.BackColor = Color.Chartreuse;
            pnlLegendAvailable.Location = new Point(35, 17);
            pnlLegendAvailable.Name = "pnlLegendAvailable";
            pnlLegendAvailable.Size = new Size(25, 25);
            pnlLegendAvailable.TabIndex = 23;
            // 
            // btnManageRooms
            // 
            btnManageRooms.Cursor = Cursors.Hand;
            btnManageRooms.Dock = DockStyle.Right;
            btnManageRooms.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnManageRooms.Location = new Point(1158, 5);
            btnManageRooms.Name = "btnManageRooms";
            btnManageRooms.Size = new Size(120, 58);
            btnManageRooms.TabIndex = 29;
            btnManageRooms.Text = "Manage Rooms";
            btnManageRooms.UseVisualStyleBackColor = true;
            // 
            // pnlRoomsContent
            // 
            pnlRoomsContent.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomsContent.Controls.Add(flpRoomsOverview);
            pnlRoomsContent.Dock = DockStyle.Fill;
            pnlRoomsContent.Location = new Point(5, 160);
            pnlRoomsContent.Name = "pnlRoomsContent";
            pnlRoomsContent.Size = new Size(1290, 585);
            pnlRoomsContent.TabIndex = 2;
            // 
            // flpRoomsOverview
            // 
            flpRoomsOverview.AutoScroll = true;
            flpRoomsOverview.Controls.Add(pnlFloorSection);
            flpRoomsOverview.Dock = DockStyle.Fill;
            flpRoomsOverview.FlowDirection = FlowDirection.TopDown;
            flpRoomsOverview.Location = new Point(0, 0);
            flpRoomsOverview.Name = "flpRoomsOverview";
            flpRoomsOverview.Size = new Size(1288, 583);
            flpRoomsOverview.TabIndex = 0;
            flpRoomsOverview.WrapContents = false;
            // 
            // pnlFloorSection
            // 
            pnlFloorSection.Controls.Add(flpFloorRooms);
            pnlFloorSection.Controls.Add(lblFloor);
            pnlFloorSection.Location = new Point(3, 3);
            pnlFloorSection.Name = "pnlFloorSection";
            pnlFloorSection.Size = new Size(514, 190);
            pnlFloorSection.TabIndex = 0;
            // 
            // flpFloorRooms
            // 
            flpFloorRooms.Dock = DockStyle.Fill;
            flpFloorRooms.Location = new Point(0, 25);
            flpFloorRooms.Margin = new Padding(0);
            flpFloorRooms.Name = "flpFloorRooms";
            flpFloorRooms.Size = new Size(514, 165);
            flpFloorRooms.TabIndex = 22;
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.Dock = DockStyle.Top;
            lblFloor.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloor.ForeColor = Color.White;
            lblFloor.ImageAlign = ContentAlignment.MiddleRight;
            lblFloor.Location = new Point(0, 0);
            lblFloor.Margin = new Padding(0);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(69, 25);
            lblFloor.TabIndex = 20;
            lblFloor.Text = "Floor #";
            lblFloor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RoomsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlRoomsContent);
            Controls.Add(pnlRoomsHeaderContent);
            Controls.Add(pnlRoomsHeader);
            Name = "RoomsControl";
            Padding = new Padding(5);
            Size = new Size(1300, 750);
            pnlRoomsHeader.ResumeLayout(false);
            pnlRoomsHeaderContent.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlRoomsContent.ResumeLayout(false);
            flpRoomsOverview.ResumeLayout(false);
            pnlFloorSection.ResumeLayout(false);
            pnlFloorSection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoomsHeader;
        private Panel pnlRoomsHeaderContent;
        private Label lblRoomsTitle;
        private Button btnManageRooms;
        private Label lblLegendMaintenance;
        private Label lblLegendOccupied;
        private Label lblLegendAvailable;
        private Panel pnlLegendMaintenance;
        private Panel pnlLegendOccupied;
        private Panel pnlLegendAvailable;
        private Panel pnlRoomsContent;
        private FlowLayoutPanel flpRoomsOverview;
        private Panel pnlFloorSection;
        private FlowLayoutPanel flpFloorRooms;
        private Label lblFloor;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
    }
}
