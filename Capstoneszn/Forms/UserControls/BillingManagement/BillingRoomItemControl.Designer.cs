namespace Capstoneszn.Forms.UserControls.Rooms
{
    partial class BillingRoomItemControl
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
            lblRoomArrow = new Label();
            lblRoomNumber = new Label();
            SuspendLayout();
            // 
            // lblRoomArrow
            // 
            lblRoomArrow.Dock = DockStyle.Right;
            lblRoomArrow.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomArrow.ForeColor = Color.White;
            lblRoomArrow.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomArrow.Location = new Point(148, 0);
            lblRoomArrow.Margin = new Padding(0);
            lblRoomArrow.Name = "lblRoomArrow";
            lblRoomArrow.Size = new Size(50, 73);
            lblRoomArrow.TabIndex = 21;
            lblRoomArrow.Text = ">";
            lblRoomArrow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.Dock = DockStyle.Fill;
            lblRoomNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomNumber.Location = new Point(0, 0);
            lblRoomNumber.Margin = new Padding(0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(148, 73);
            lblRoomNumber.TabIndex = 22;
            lblRoomNumber.Text = "ROOM ###";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BillingRoomItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblRoomNumber);
            Controls.Add(lblRoomArrow);
            Cursor = Cursors.Hand;
            Name = "BillingRoomItemControl";
            Size = new Size(198, 73);
            ResumeLayout(false);
        }

        #endregion

        private Label lblRoomArrow;
        private Label lblRoomNumber;
    }
}
