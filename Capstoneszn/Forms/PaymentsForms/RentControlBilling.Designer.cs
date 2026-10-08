namespace Capstoneszn.Forms.PaymentsForms
{
    partial class RentControlBilling
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
            pnlButtons = new Panel();
            RadioBtnRoom = new RadioButton();
            RadioBtnIndividualTenant = new RadioButton();
            pnlTenantInformation = new Panel();
            lblBalanceValue = new Label();
            lblPeriodValue = new Label();
            lblTenantValue = new Label();
            lblRoomValue = new Label();
            lblBalance = new Label();
            lblPeriod = new Label();
            lblTenant = new Label();
            lblRoom = new Label();
            lblShare = new Label();
            lblShareValue = new Label();
            lblOutstanding = new Label();
            lblOutstandingValue = new Label();
            lblDescription1 = new Label();
            lblDescription2 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            pnlButtons.SuspendLayout();
            pnlTenantInformation.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(panel2);
            pnlButtons.Controls.Add(panel1);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new Point(0, 181);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(825, 169);
            pnlButtons.TabIndex = 1;
            // 
            // RadioBtnRoom
            // 
            RadioBtnRoom.Appearance = Appearance.Button;
            RadioBtnRoom.BackColor = Color.FromArgb(11, 20, 38);
            RadioBtnRoom.FlatStyle = FlatStyle.Flat;
            RadioBtnRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RadioBtnRoom.ForeColor = Color.White;
            RadioBtnRoom.Location = new Point(443, 10);
            RadioBtnRoom.Margin = new Padding(0);
            RadioBtnRoom.Name = "RadioBtnRoom";
            RadioBtnRoom.Size = new Size(324, 62);
            RadioBtnRoom.TabIndex = 7;
            RadioBtnRoom.TabStop = true;
            RadioBtnRoom.Text = "Whole Room";
            RadioBtnRoom.TextAlign = ContentAlignment.MiddleCenter;
            RadioBtnRoom.UseVisualStyleBackColor = false;
            // 
            // RadioBtnIndividualTenant
            // 
            RadioBtnIndividualTenant.Appearance = Appearance.Button;
            RadioBtnIndividualTenant.BackColor = Color.FromArgb(11, 20, 38);
            RadioBtnIndividualTenant.FlatStyle = FlatStyle.Flat;
            RadioBtnIndividualTenant.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RadioBtnIndividualTenant.ForeColor = Color.White;
            RadioBtnIndividualTenant.Location = new Point(52, 10);
            RadioBtnIndividualTenant.Margin = new Padding(0);
            RadioBtnIndividualTenant.Name = "RadioBtnIndividualTenant";
            RadioBtnIndividualTenant.Size = new Size(324, 62);
            RadioBtnIndividualTenant.TabIndex = 6;
            RadioBtnIndividualTenant.TabStop = true;
            RadioBtnIndividualTenant.Text = "Individual Tenant";
            RadioBtnIndividualTenant.TextAlign = ContentAlignment.MiddleCenter;
            RadioBtnIndividualTenant.UseVisualStyleBackColor = false;
            // 
            // pnlTenantInformation
            // 
            pnlTenantInformation.Controls.Add(lblOutstandingValue);
            pnlTenantInformation.Controls.Add(lblOutstanding);
            pnlTenantInformation.Controls.Add(lblShareValue);
            pnlTenantInformation.Controls.Add(lblShare);
            pnlTenantInformation.Controls.Add(lblBalanceValue);
            pnlTenantInformation.Controls.Add(lblPeriodValue);
            pnlTenantInformation.Controls.Add(lblTenantValue);
            pnlTenantInformation.Controls.Add(lblRoomValue);
            pnlTenantInformation.Controls.Add(lblBalance);
            pnlTenantInformation.Controls.Add(lblPeriod);
            pnlTenantInformation.Controls.Add(lblTenant);
            pnlTenantInformation.Controls.Add(lblRoom);
            pnlTenantInformation.Dock = DockStyle.Fill;
            pnlTenantInformation.Location = new Point(0, 0);
            pnlTenantInformation.Name = "pnlTenantInformation";
            pnlTenantInformation.Size = new Size(825, 181);
            pnlTenantInformation.TabIndex = 2;
            // 
            // lblBalanceValue
            // 
            lblBalanceValue.AutoSize = true;
            lblBalanceValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalanceValue.ForeColor = Color.White;
            lblBalanceValue.ImageAlign = ContentAlignment.MiddleRight;
            lblBalanceValue.Location = new Point(658, 83);
            lblBalanceValue.Margin = new Padding(0);
            lblBalanceValue.Name = "lblBalanceValue";
            lblBalanceValue.Size = new Size(70, 31);
            lblBalanceValue.TabIndex = 36;
            lblBalanceValue.Text = "####";
            lblBalanceValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPeriodValue
            // 
            lblPeriodValue.AutoSize = true;
            lblPeriodValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriodValue.ForeColor = Color.White;
            lblPeriodValue.ImageAlign = ContentAlignment.MiddleRight;
            lblPeriodValue.Location = new Point(645, 14);
            lblPeriodValue.Margin = new Padding(0);
            lblPeriodValue.Name = "lblPeriodValue";
            lblPeriodValue.Size = new Size(122, 31);
            lblPeriodValue.TabIndex = 35;
            lblPeriodValue.Text = "From to To";
            lblPeriodValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenantValue
            // 
            lblTenantValue.AutoSize = true;
            lblTenantValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantValue.ForeColor = Color.White;
            lblTenantValue.ImageAlign = ContentAlignment.MiddleRight;
            lblTenantValue.Location = new Point(146, 83);
            lblTenantValue.Margin = new Padding(0);
            lblTenantValue.Name = "lblTenantValue";
            lblTenantValue.Size = new Size(149, 31);
            lblTenantValue.TabIndex = 34;
            lblTenantValue.Text = "Tenant Name";
            lblTenantValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomValue
            // 
            lblRoomValue.AutoSize = true;
            lblRoomValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomValue.ForeColor = Color.White;
            lblRoomValue.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomValue.Location = new Point(167, 14);
            lblRoomValue.Margin = new Padding(0);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(56, 31);
            lblRoomValue.TabIndex = 33;
            lblRoomValue.Text = "###";
            lblRoomValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalance.ForeColor = Color.White;
            lblBalance.ImageAlign = ContentAlignment.MiddleRight;
            lblBalance.Location = new Point(477, 83);
            lblBalance.Margin = new Padding(0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(93, 31);
            lblBalance.TabIndex = 32;
            lblBalance.Text = "Balance";
            lblBalance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPeriod.ForeColor = Color.White;
            lblPeriod.ImageAlign = ContentAlignment.MiddleRight;
            lblPeriod.Location = new Point(477, 14);
            lblPeriod.Margin = new Padding(0);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(79, 31);
            lblPeriod.TabIndex = 31;
            lblPeriod.Text = "Period";
            lblPeriod.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenant
            // 
            lblTenant.AutoSize = true;
            lblTenant.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenant.ForeColor = Color.White;
            lblTenant.ImageAlign = ContentAlignment.MiddleRight;
            lblTenant.Location = new Point(15, 83);
            lblTenant.Margin = new Padding(0);
            lblTenant.Name = "lblTenant";
            lblTenant.Size = new Size(82, 31);
            lblTenant.TabIndex = 30;
            lblTenant.Text = "Tenant";
            lblTenant.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.ForeColor = Color.White;
            lblRoom.ImageAlign = ContentAlignment.MiddleRight;
            lblRoom.Location = new Point(15, 14);
            lblRoom.Margin = new Padding(0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(73, 31);
            lblRoom.TabIndex = 29;
            lblRoom.Text = "Room";
            lblRoom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblShare
            // 
            lblShare.AutoSize = true;
            lblShare.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShare.ForeColor = Color.White;
            lblShare.ImageAlign = ContentAlignment.MiddleRight;
            lblShare.Location = new Point(43, 147);
            lblShare.Margin = new Padding(0);
            lblShare.Name = "lblShare";
            lblShare.Size = new Size(71, 31);
            lblShare.TabIndex = 37;
            lblShare.Text = "Share";
            lblShare.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblShareValue
            // 
            lblShareValue.AutoSize = true;
            lblShareValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShareValue.ForeColor = Color.White;
            lblShareValue.ImageAlign = ContentAlignment.MiddleRight;
            lblShareValue.Location = new Point(183, 147);
            lblShareValue.Margin = new Padding(0);
            lblShareValue.Name = "lblShareValue";
            lblShareValue.Size = new Size(70, 31);
            lblShareValue.TabIndex = 38;
            lblShareValue.Text = "####";
            lblShareValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOutstanding
            // 
            lblOutstanding.AutoSize = true;
            lblOutstanding.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOutstanding.ForeColor = Color.White;
            lblOutstanding.ImageAlign = ContentAlignment.MiddleRight;
            lblOutstanding.Location = new Point(463, 147);
            lblOutstanding.Margin = new Padding(0);
            lblOutstanding.Name = "lblOutstanding";
            lblOutstanding.Size = new Size(142, 31);
            lblOutstanding.TabIndex = 39;
            lblOutstanding.Text = "Outstanding";
            lblOutstanding.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOutstandingValue
            // 
            lblOutstandingValue.AutoSize = true;
            lblOutstandingValue.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOutstandingValue.ForeColor = Color.White;
            lblOutstandingValue.ImageAlign = ContentAlignment.MiddleRight;
            lblOutstandingValue.Location = new Point(658, 147);
            lblOutstandingValue.Margin = new Padding(0);
            lblOutstandingValue.Name = "lblOutstandingValue";
            lblOutstandingValue.Size = new Size(70, 31);
            lblOutstandingValue.TabIndex = 40;
            lblOutstandingValue.Text = "####";
            lblOutstandingValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription1
            // 
            lblDescription1.AutoSize = true;
            lblDescription1.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription1.ForeColor = Color.White;
            lblDescription1.ImageAlign = ContentAlignment.MiddleRight;
            lblDescription1.Location = new Point(43, 0);
            lblDescription1.Margin = new Padding(0);
            lblDescription1.Name = "lblDescription1";
            lblDescription1.Size = new Size(143, 31);
            lblDescription1.TabIndex = 38;
            lblDescription1.Text = "Description1";
            lblDescription1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription2
            // 
            lblDescription2.AutoSize = true;
            lblDescription2.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription2.ForeColor = Color.White;
            lblDescription2.ImageAlign = ContentAlignment.MiddleRight;
            lblDescription2.Location = new Point(43, 45);
            lblDescription2.Margin = new Padding(0);
            lblDescription2.Name = "lblDescription2";
            lblDescription2.Size = new Size(143, 31);
            lblDescription2.TabIndex = 39;
            lblDescription2.Text = "Description2";
            lblDescription2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblDescription1);
            panel1.Controls.Add(lblDescription2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 89);
            panel1.Name = "panel1";
            panel1.Size = new Size(825, 80);
            panel1.TabIndex = 40;
            // 
            // panel2
            // 
            panel2.Controls.Add(RadioBtnIndividualTenant);
            panel2.Controls.Add(RadioBtnRoom);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 9);
            panel2.Name = "panel2";
            panel2.Size = new Size(825, 80);
            panel2.TabIndex = 41;
            // 
            // RentControlBilling
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlTenantInformation);
            Controls.Add(pnlButtons);
            Name = "RentControlBilling";
            Size = new Size(825, 350);
            pnlButtons.ResumeLayout(false);
            pnlTenantInformation.ResumeLayout(false);
            pnlTenantInformation.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlButtons;
        private Panel pnlTenantInformation;
        private RadioButton RadioBtnRoom;
        private RadioButton RadioBtnIndividualTenant;
        private Label lblRoom;
        private Label lblTenant;
        private Label lblPeriod;
        private Label lblBalance;
        private Label lblTenantValue;
        private Label lblRoomValue;
        private Label lblBalanceValue;
        private Label lblPeriodValue;
        private Label lblOutstandingValue;
        private Label lblOutstanding;
        private Label lblShareValue;
        private Label lblShare;
        private Label lblDescription2;
        private Label lblDescription1;
        private Panel panel1;
        private Panel panel2;
    }
}
