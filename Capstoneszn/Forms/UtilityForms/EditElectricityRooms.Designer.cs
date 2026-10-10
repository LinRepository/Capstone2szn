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
            cboElectricityRoom = new ComboBox();
            lblElectricityRoom = new Label();
            SuspendLayout();
            // 
            // txtElectricityAmount
            // 
            txtElectricityAmount.Location = new Point(133, 178);
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
            lblEditElectricityAmount.Location = new Point(133, 144);
            lblEditElectricityAmount.Name = "lblEditElectricityAmount";
            lblEditElectricityAmount.Size = new Size(142, 31);
            lblEditElectricityAmount.TabIndex = 21;
            lblEditElectricityAmount.Text = "Edit Amount";
            lblEditElectricityAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboElectricityRoom
            // 
            cboElectricityRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboElectricityRoom.FormattingEnabled = true;
            cboElectricityRoom.Location = new Point(133, 90);
            cboElectricityRoom.Name = "cboElectricityRoom";
            cboElectricityRoom.Size = new Size(251, 28);
            cboElectricityRoom.TabIndex = 20;
            // 
            // lblElectricityRoom
            // 
            lblElectricityRoom.AutoSize = true;
            lblElectricityRoom.Font = new Font("Segoe UI", 13.2000008F);
            lblElectricityRoom.ForeColor = Color.White;
            lblElectricityRoom.ImageAlign = ContentAlignment.MiddleRight;
            lblElectricityRoom.Location = new Point(133, 56);
            lblElectricityRoom.Name = "lblElectricityRoom";
            lblElectricityRoom.Size = new Size(140, 31);
            lblElectricityRoom.TabIndex = 19;
            lblElectricityRoom.Text = "Select Room";
            lblElectricityRoom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditElectricityRooms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(txtElectricityAmount);
            Controls.Add(lblEditElectricityAmount);
            Controls.Add(cboElectricityRoom);
            Controls.Add(lblElectricityRoom);
            Name = "EditElectricityRooms";
            Size = new Size(517, 268);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtElectricityAmount;
        private Label lblEditElectricityAmount;
        private ComboBox cboElectricityRoom;
        private Label lblElectricityRoom;
    }
}
