namespace Capstoneszn.Forms.PaymentsForms
{
    partial class UtilitiesControlBilling
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
            panel2 = new Panel();
            lblRoom = new Label();
            lblTenant = new Label();
            lblRoomValue = new Label();
            lblTenantValue = new Label();
            lblPeriod = new Label();
            lblOutstanding = new Label();
            lblPeriodValue = new Label();
            lblOutstandingValue = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTenant);
            panel2.Controls.Add(lblTenantValue);
            panel2.Controls.Add(lblOutstandingValue);
            panel2.Controls.Add(lblPeriodValue);
            panel2.Controls.Add(lblRoomValue);
            panel2.Controls.Add(lblOutstanding);
            panel2.Controls.Add(lblPeriod);
            panel2.Controls.Add(lblRoom);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(825, 200);
            panel2.TabIndex = 1;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.ForeColor = Color.White;
            lblRoom.Location = new Point(36, 37);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(78, 31);
            lblRoom.TabIndex = 0;
            lblRoom.Text = "Room:";
            // 
            // lblTenant
            // 
            lblTenant.AutoSize = true;
            lblTenant.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenant.ForeColor = Color.White;
            lblTenant.Location = new Point(36, 105);
            lblTenant.Name = "lblTenant";
            lblTenant.Size = new Size(87, 31);
            lblTenant.TabIndex = 0;
            lblTenant.Text = "Tenant:";
            // 
            // lblRoomValue
            // 
            lblRoomValue.AutoSize = true;
            lblRoomValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomValue.ForeColor = Color.White;
            lblRoomValue.Location = new Point(147, 37);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(94, 31);
            lblRoomValue.TabIndex = 0;
            lblRoomValue.Text = "number";
            // 
            // lblTenantValue
            // 
            lblTenantValue.AutoSize = true;
            lblTenantValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantValue.ForeColor = Color.White;
            lblTenantValue.Location = new Point(147, 105);
            lblTenantValue.Name = "lblTenantValue";
            lblTenantValue.Size = new Size(71, 31);
            lblTenantValue.TabIndex = 0;
            lblTenantValue.Text = "name";
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriod.ForeColor = Color.White;
            lblPeriod.Location = new Point(415, 37);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(153, 31);
            lblPeriod.TabIndex = 0;
            lblPeriod.Text = "Water Month:";
            // 
            // lblOutstanding
            // 
            lblOutstanding.AutoSize = true;
            lblOutstanding.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOutstanding.ForeColor = Color.White;
            lblOutstanding.Location = new Point(415, 105);
            lblOutstanding.Name = "lblOutstanding";
            lblOutstanding.Size = new Size(134, 31);
            lblOutstanding.TabIndex = 0;
            lblOutstanding.Text = "Total Owed:";
            // 
            // lblPeriodValue
            // 
            lblPeriodValue.AutoSize = true;
            lblPeriodValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriodValue.ForeColor = Color.White;
            lblPeriodValue.Location = new Point(574, 37);
            lblPeriodValue.Name = "lblPeriodValue";
            lblPeriodValue.Size = new Size(60, 31);
            lblPeriodValue.TabIndex = 0;
            lblPeriodValue.Text = "date";
            // 
            // lblOutstandingValue
            // 
            lblOutstandingValue.AutoSize = true;
            lblOutstandingValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOutstandingValue.ForeColor = Color.White;
            lblOutstandingValue.Location = new Point(574, 105);
            lblOutstandingValue.Name = "lblOutstandingValue";
            lblOutstandingValue.Size = new Size(94, 31);
            lblOutstandingValue.TabIndex = 0;
            lblOutstandingValue.Text = "number";
            // 
            // UtilitiesControlBilling
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(panel2);
            Name = "UtilitiesControlBilling";
            Size = new Size(825, 200);
            Load += UtilitiesControlBilling_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label lblRoom;
        private Label lblTenant;
        private Label lblTenantValue;
        private Label lblOutstandingValue;
        private Label lblPeriodValue;
        private Label lblRoomValue;
        private Label lblOutstanding;
        private Label lblPeriod;
    }
}
