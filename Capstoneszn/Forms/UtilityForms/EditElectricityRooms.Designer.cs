namespace Capstoneszn.Forms.UtilityForms
{
    partial class EditElectricityRooms
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
            txtElectricityAmount = new TextBox();
            lblEditElectricityAmount = new Label();
            cbElecAccountNumber = new ComboBox();
            lblElecAccountNumber = new Label();
            label1 = new Label();
            txtRoomNumber = new TextBox();
            SuspendLayout();
            // 
            // txtElectricityAmount
            // 
            txtElectricityAmount.Location = new Point(133, 214);
            txtElectricityAmount.Multiline = true;
            txtElectricityAmount.Name = "txtElectricityAmount";
            txtElectricityAmount.Size = new Size(251, 34);
            txtElectricityAmount.TabIndex = 22;
            // 
            // lblEditElectricityAmount
            // 
            lblEditElectricityAmount.AutoSize = true;
            lblEditElectricityAmount.Font = new Font("Segoe UI", 13.2000008F);
            lblEditElectricityAmount.ForeColor = Color.White;
            lblEditElectricityAmount.ImageAlign = ContentAlignment.MiddleRight;
            lblEditElectricityAmount.Location = new Point(133, 180);
            lblEditElectricityAmount.Name = "lblEditElectricityAmount";
            lblEditElectricityAmount.Size = new Size(142, 31);
            lblEditElectricityAmount.TabIndex = 21;
            lblEditElectricityAmount.Text = "Edit Amount";
            lblEditElectricityAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbElecAccountNumber
            // 
            cbElecAccountNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            cbElecAccountNumber.FormattingEnabled = true;
            cbElecAccountNumber.Location = new Point(133, 54);
            cbElecAccountNumber.Name = "cbElecAccountNumber";
            cbElecAccountNumber.Size = new Size(251, 28);
            cbElecAccountNumber.TabIndex = 20;
            cbElecAccountNumber.SelectedIndexChanged += cbElecAccountNumber_SelectedIndexChanged;
            // 
            // lblElecAccountNumber
            // 
            lblElecAccountNumber.AutoSize = true;
            lblElecAccountNumber.Font = new Font("Segoe UI", 13.2000008F);
            lblElecAccountNumber.ForeColor = Color.White;
            lblElecAccountNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblElecAccountNumber.Location = new Point(133, 20);
            lblElecAccountNumber.Name = "lblElecAccountNumber";
            lblElecAccountNumber.Size = new Size(165, 31);
            lblElecAccountNumber.TabIndex = 19;
            lblElecAccountNumber.Text = "Select Account";
            lblElecAccountNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.2000008F);
            label1.ForeColor = Color.White;
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(133, 100);
            label1.Name = "label1";
            label1.Size = new Size(73, 31);
            label1.TabIndex = 19;
            label1.Text = "Room";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(133, 133);
            txtRoomNumber.Multiline = true;
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.ReadOnly = true;
            txtRoomNumber.Size = new Size(251, 34);
            txtRoomNumber.TabIndex = 22;
            // 
            // EditElectricityRooms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(txtRoomNumber);
            Controls.Add(txtElectricityAmount);
            Controls.Add(lblEditElectricityAmount);
            Controls.Add(cbElecAccountNumber);
            Controls.Add(label1);
            Controls.Add(lblElecAccountNumber);
            Name = "EditElectricityRooms";
            Size = new Size(517, 268);
            Load += EditElectricityRooms_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtElectricityAmount;
        private Label lblEditElectricityAmount;
        private ComboBox cbElecAccountNumber;
        private Label lblElecAccountNumber;
        private Label label1;
        private TextBox txtRoomNumber;
    }
}
