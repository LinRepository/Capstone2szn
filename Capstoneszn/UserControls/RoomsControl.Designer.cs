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
            lblLegendMaintenance = new Label();
            lblLegendOccupied = new Label();
            lblLegendAvailable = new Label();
            pnlLegendMaintenance = new Panel();
            pnlLegendOccupied = new Panel();
            pnlLegendAvailable = new Panel();
            btnManageRooms = new Button();
            pnlRoomsContent = new Panel();
            flpRoomsOverview = new FlowLayoutPanel();
            pnlRoomsHeader.SuspendLayout();
            pnlRoomsContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomsHeader
            // 
            pnlRoomsHeader.Controls.Add(btnManageRooms);
            pnlRoomsHeader.Controls.Add(lblLegendMaintenance);
            pnlRoomsHeader.Controls.Add(lblLegendOccupied);
            pnlRoomsHeader.Controls.Add(lblLegendAvailable);
            pnlRoomsHeader.Controls.Add(pnlLegendMaintenance);
            pnlRoomsHeader.Controls.Add(pnlLegendOccupied);
            pnlRoomsHeader.Controls.Add(pnlLegendAvailable);
            pnlRoomsHeader.Dock = DockStyle.Top;
            pnlRoomsHeader.Location = new Point(15, 15);
            pnlRoomsHeader.Margin = new Padding(0);
            pnlRoomsHeader.Name = "pnlRoomsHeader";
            pnlRoomsHeader.Size = new Size(1270, 125);
            pnlRoomsHeader.TabIndex = 0;
            // 
            // lblLegendMaintenance
            // 
            lblLegendMaintenance.AutoSize = true;
            lblLegendMaintenance.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLegendMaintenance.ForeColor = Color.White;
            lblLegendMaintenance.ImageAlign = ContentAlignment.MiddleRight;
            lblLegendMaintenance.Location = new Point(771, 50);
            lblLegendMaintenance.Margin = new Padding(0);
            lblLegendMaintenance.Name = "lblLegendMaintenance";
            lblLegendMaintenance.Size = new Size(112, 25);
            lblLegendMaintenance.TabIndex = 21;
            lblLegendMaintenance.Text = "Maintenance";
            lblLegendMaintenance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLegendOccupied
            // 
            lblLegendOccupied.AutoSize = true;
            lblLegendOccupied.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLegendOccupied.ForeColor = Color.White;
            lblLegendOccupied.ImageAlign = ContentAlignment.MiddleRight;
            lblLegendOccupied.Location = new Point(601, 50);
            lblLegendOccupied.Margin = new Padding(0);
            lblLegendOccupied.Name = "lblLegendOccupied";
            lblLegendOccupied.Size = new Size(87, 25);
            lblLegendOccupied.TabIndex = 20;
            lblLegendOccupied.Text = "Occupied";
            lblLegendOccupied.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLegendAvailable
            // 
            lblLegendAvailable.AutoSize = true;
            lblLegendAvailable.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLegendAvailable.ForeColor = Color.White;
            lblLegendAvailable.ImageAlign = ContentAlignment.MiddleRight;
            lblLegendAvailable.Location = new Point(415, 50);
            lblLegendAvailable.Margin = new Padding(0);
            lblLegendAvailable.Name = "lblLegendAvailable";
            lblLegendAvailable.Size = new Size(83, 25);
            lblLegendAvailable.TabIndex = 19;
            lblLegendAvailable.Text = "Available";
            lblLegendAvailable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLegendMaintenance
            // 
            pnlLegendMaintenance.Location = new Point(743, 50);
            pnlLegendMaintenance.Name = "pnlLegendMaintenance";
            pnlLegendMaintenance.Size = new Size(25, 25);
            pnlLegendMaintenance.TabIndex = 18;
            // 
            // pnlLegendOccupied
            // 
            pnlLegendOccupied.Location = new Point(573, 50);
            pnlLegendOccupied.Name = "pnlLegendOccupied";
            pnlLegendOccupied.Size = new Size(25, 25);
            pnlLegendOccupied.TabIndex = 17;
            // 
            // pnlLegendAvailable
            // 
            pnlLegendAvailable.Location = new Point(387, 50);
            pnlLegendAvailable.Name = "pnlLegendAvailable";
            pnlLegendAvailable.Size = new Size(25, 25);
            pnlLegendAvailable.TabIndex = 16;
            // 
            // btnManageRooms
            // 
            btnManageRooms.Location = new Point(1121, 36);
            btnManageRooms.Name = "btnManageRooms";
            btnManageRooms.Size = new Size(94, 56);
            btnManageRooms.TabIndex = 22;
            btnManageRooms.Text = "Manage Rooms";
            btnManageRooms.UseVisualStyleBackColor = true;
            // 
            // pnlRoomsContent
            // 
            pnlRoomsContent.Controls.Add(flpRoomsOverview);
            pnlRoomsContent.Dock = DockStyle.Fill;
            pnlRoomsContent.Location = new Point(15, 140);
            pnlRoomsContent.Name = "pnlRoomsContent";
            pnlRoomsContent.Size = new Size(1270, 595);
            pnlRoomsContent.TabIndex = 1;
            // 
            // flpRoomsOverview
            // 
            flpRoomsOverview.AutoScroll = true;
            flpRoomsOverview.Dock = DockStyle.Fill;
            flpRoomsOverview.FlowDirection = FlowDirection.TopDown;
            flpRoomsOverview.Location = new Point(0, 0);
            flpRoomsOverview.Name = "flpRoomsOverview";
            flpRoomsOverview.Size = new Size(1270, 595);
            flpRoomsOverview.TabIndex = 0;
            flpRoomsOverview.WrapContents = false;
            // 
            // RoomsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlRoomsContent);
            Controls.Add(pnlRoomsHeader);
            Name = "RoomsControl";
            Padding = new Padding(15);
            Size = new Size(1300, 750);
            pnlRoomsHeader.ResumeLayout(false);
            pnlRoomsHeader.PerformLayout();
            pnlRoomsContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoomsHeader;
        private Button btnManageRooms;
        private Label lblLegendMaintenance;
        private Label lblLegendOccupied;
        private Label lblLegendAvailable;
        private Panel pnlLegendMaintenance;
        private Panel pnlLegendOccupied;
        private Panel pnlLegendAvailable;
        private Panel pnlRoomsContent;
        private FlowLayoutPanel flpRoomsOverview;
    }
}
