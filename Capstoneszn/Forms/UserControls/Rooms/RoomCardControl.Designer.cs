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
            lblRoomNumber.Dock = DockStyle.Top;
            lblRoomNumber.Location = new Point(0, 0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(110, 40);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "###";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOccupancy
            // 
            lblOccupancy.Dock = DockStyle.Fill;
            lblOccupancy.Location = new Point(0, 40);
            lblOccupancy.Name = "lblOccupancy";
            lblOccupancy.Size = new Size(110, 40);
            lblOccupancy.TabIndex = 1;
            lblOccupancy.Text = "# / #";
            lblOccupancy.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RoomCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblOccupancy);
            Controls.Add(lblRoomNumber);
            Cursor = Cursors.Hand;
            Name = "RoomCardControl";
            Size = new Size(110, 80);
            ResumeLayout(false);
        }

        #endregion

        private Label lblRoomNumber;
        private Label lblOccupancy;
    }
}
