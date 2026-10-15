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
            pnlStatusStrip = new Panel();
            lblRoomArrow = new Label();
            pnlBody = new Panel();
            lblMoneyState = new Label();
            lblOccupancy = new Label();
            lblRoomNumber = new Label();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // pnlStatusStrip
            // 
            pnlStatusStrip.BackColor = Color.LightSlateGray;
            pnlStatusStrip.Dock = DockStyle.Left;
            pnlStatusStrip.Location = new Point(0, 0);
            pnlStatusStrip.Margin = new Padding(0);
            pnlStatusStrip.Name = "pnlStatusStrip";
            pnlStatusStrip.Size = new Size(8, 100);
            pnlStatusStrip.TabIndex = 0;
            pnlStatusStrip.Paint += pnlStatusStrip_Paint;
            // 
            // lblRoomArrow
            // 
            lblRoomArrow.Dock = DockStyle.Right;
            lblRoomArrow.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomArrow.ForeColor = Color.White;
            lblRoomArrow.Location = new Point(200, 0);
            lblRoomArrow.Margin = new Padding(0);
            lblRoomArrow.Name = "lblRoomArrow";
            lblRoomArrow.Size = new Size(40, 100);
            lblRoomArrow.TabIndex = 2;
            lblRoomArrow.Text = ">";
            lblRoomArrow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(lblMoneyState);
            pnlBody.Controls.Add(lblOccupancy);
            pnlBody.Controls.Add(lblRoomNumber);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(8, 0);
            pnlBody.Margin = new Padding(0);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(10, 6, 0, 6);
            pnlBody.Size = new Size(192, 100);
            pnlBody.TabIndex = 1;
            // 
            // lblMoneyState
            // 
            lblMoneyState.Dock = DockStyle.Fill;
            lblMoneyState.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMoneyState.ForeColor = Color.LightSlateGray;
            lblMoneyState.Location = new Point(10, 64);
            lblMoneyState.Margin = new Padding(0);
            lblMoneyState.Name = "lblMoneyState";
            lblMoneyState.Size = new Size(182, 30);
            lblMoneyState.TabIndex = 2;
            lblMoneyState.Text = "Vacant";
            lblMoneyState.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOccupancy
            // 
            lblOccupancy.Dock = DockStyle.Top;
            lblOccupancy.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOccupancy.ForeColor = Color.Gainsboro;
            lblOccupancy.Location = new Point(10, 40);
            lblOccupancy.Margin = new Padding(0);
            lblOccupancy.Name = "lblOccupancy";
            lblOccupancy.Size = new Size(182, 24);
            lblOccupancy.TabIndex = 1;
            lblOccupancy.Text = "0/0 tenants";
            lblOccupancy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.Dock = DockStyle.Top;
            lblRoomNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.Location = new Point(10, 6);
            lblRoomNumber.Margin = new Padding(0);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(182, 34);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "ROOM ###";
            lblRoomNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BillingRoomItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnlBody);
            Controls.Add(lblRoomArrow);
            Controls.Add(pnlStatusStrip);
            Cursor = Cursors.Hand;
            Margin = new Padding(6);
            Name = "BillingRoomItemControl";
            Size = new Size(240, 100);
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlStatusStrip;
        private Label lblRoomArrow;
        private Panel pnlBody;
        private Label lblRoomNumber;
        private Label lblOccupancy;
        private Label lblMoneyState;
    }
}
