namespace Capstoneszn.UserControls
{
    partial class RoomCardControl
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
            lblRoomNumber = new Label();
            lblOccupancy = new Label();
            SuspendLayout();
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.BackColor = Color.Transparent;
            lblRoomNumber.BorderStyle = BorderStyle.FixedSingle;
            lblRoomNumber.Dock = DockStyle.Top;
            lblRoomNumber.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.Black;
            lblRoomNumber.Location = new Point(0, 0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(180, 75);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "101";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomNumber.Click += lblRoomNumber_Click;
            // 
            // lblOccupancy
            // 
            lblOccupancy.BackColor = Color.Transparent;
            lblOccupancy.BorderStyle = BorderStyle.FixedSingle;
            lblOccupancy.Dock = DockStyle.Fill;
            lblOccupancy.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOccupancy.ForeColor = Color.Black;
            lblOccupancy.Location = new Point(0, 75);
            lblOccupancy.Name = "lblOccupancy";
            lblOccupancy.Size = new Size(180, 75);
            lblOccupancy.TabIndex = 1;
            lblOccupancy.Text = "1/1";
            lblOccupancy.TextAlign = ContentAlignment.MiddleCenter;
            lblOccupancy.Click += lblOccupancy_Click;
            // 
            // RoomCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblOccupancy);
            Controls.Add(lblRoomNumber);
            Cursor = Cursors.Hand;
            Name = "RoomCardControl";
            Size = new Size(180, 150);
            Load += RoomCardControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblRoomNumber;
        private Label lblOccupancy;
    }
}
