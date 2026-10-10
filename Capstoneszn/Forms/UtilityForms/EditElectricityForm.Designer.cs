namespace Capstoneszn.Forms.UtilityForms
{
    partial class EditElectricityForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlEditElectrcityHeader = new Panel();
            lblEditElectricityBillTitle = new Label();
            pnlElectricityActionButton = new Panel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlElectricityContent = new Panel();
            RadioBtnRooms = new RadioButton();
            RadioBtnAdmin = new RadioButton();
            pnlEditElectrcityHeader.SuspendLayout();
            pnlElectricityActionButton.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEditElectrcityHeader
            // 
            pnlEditElectrcityHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlEditElectrcityHeader.Controls.Add(lblEditElectricityBillTitle);
            pnlEditElectrcityHeader.Dock = DockStyle.Top;
            pnlEditElectrcityHeader.Location = new Point(0, 0);
            pnlEditElectrcityHeader.Name = "pnlEditElectrcityHeader";
            pnlEditElectrcityHeader.Size = new Size(519, 60);
            pnlEditElectrcityHeader.TabIndex = 1;
            // 
            // lblEditElectricityBillTitle
            // 
            lblEditElectricityBillTitle.BackColor = Color.FromArgb(11, 20, 38);
            lblEditElectricityBillTitle.Dock = DockStyle.Fill;
            lblEditElectricityBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditElectricityBillTitle.ForeColor = Color.White;
            lblEditElectricityBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblEditElectricityBillTitle.Location = new Point(0, 0);
            lblEditElectricityBillTitle.Name = "lblEditElectricityBillTitle";
            lblEditElectricityBillTitle.Size = new Size(517, 58);
            lblEditElectricityBillTitle.TabIndex = 14;
            lblEditElectricityBillTitle.Text = "Edit Electricity Bill";
            lblEditElectricityBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlElectricityActionButton
            // 
            pnlElectricityActionButton.Controls.Add(btnConfirm);
            pnlElectricityActionButton.Controls.Add(btnCancel);
            pnlElectricityActionButton.Dock = DockStyle.Bottom;
            pnlElectricityActionButton.Location = new Point(0, 386);
            pnlElectricityActionButton.Name = "pnlElectricityActionButton";
            pnlElectricityActionButton.Size = new Size(519, 50);
            pnlElectricityActionButton.TabIndex = 2;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(252, 9);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(139, 9);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlElectricityContent
            // 
            pnlElectricityContent.BorderStyle = BorderStyle.FixedSingle;
            pnlElectricityContent.Location = new Point(1, 112);
            pnlElectricityContent.Name = "pnlElectricityContent";
            pnlElectricityContent.Size = new Size(517, 268);
            pnlElectricityContent.TabIndex = 3;
            // 
            // RadioBtnRooms
            // 
            RadioBtnRooms.Appearance = Appearance.Button;
            RadioBtnRooms.AutoSize = true;
            RadioBtnRooms.FlatStyle = FlatStyle.Flat;
            RadioBtnRooms.Font = new Font("Segoe UI", 12F);
            RadioBtnRooms.ForeColor = Color.White;
            RadioBtnRooms.Location = new Point(166, 66);
            RadioBtnRooms.Name = "RadioBtnRooms";
            RadioBtnRooms.Size = new Size(84, 40);
            RadioBtnRooms.TabIndex = 4;
            RadioBtnRooms.TabStop = true;
            RadioBtnRooms.Text = "Rooms";
            RadioBtnRooms.UseVisualStyleBackColor = true;
            // 
            // RadioBtnAdmin
            // 
            RadioBtnAdmin.Appearance = Appearance.Button;
            RadioBtnAdmin.AutoSize = true;
            RadioBtnAdmin.FlatStyle = FlatStyle.Flat;
            RadioBtnAdmin.Font = new Font("Segoe UI", 12F);
            RadioBtnAdmin.ForeColor = Color.White;
            RadioBtnAdmin.Location = new Point(256, 66);
            RadioBtnAdmin.Name = "RadioBtnAdmin";
            RadioBtnAdmin.Size = new Size(82, 40);
            RadioBtnAdmin.TabIndex = 4;
            RadioBtnAdmin.TabStop = true;
            RadioBtnAdmin.Text = "Admin";
            RadioBtnAdmin.UseVisualStyleBackColor = true;
            // 
            // EditElectricityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(519, 436);
            Controls.Add(RadioBtnAdmin);
            Controls.Add(RadioBtnRooms);
            Controls.Add(pnlElectricityContent);
            Controls.Add(pnlElectricityActionButton);
            Controls.Add(pnlEditElectrcityHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditElectricityForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "EditElectricityForm";
            Load += EditElectricityForm_Load;
            pnlEditElectrcityHeader.ResumeLayout(false);
            pnlElectricityActionButton.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEditElectrcityHeader;
        private Label lblEditElectricityBillTitle;
        private Panel pnlElectricityActionButton;
        private Button btnConfirm;
        private Button btnCancel;
        private Panel pnlElectricityContent;
        private RadioButton RadioBtnRooms;
        private RadioButton RadioBtnAdmin;
    }
}