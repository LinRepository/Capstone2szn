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
            txtElectricityAmount = new TextBox();
            lblEditElectricityAmount = new Label();
            cboElectricityRoom = new ComboBox();
            lblElectricityRoom = new Label();
            pnlEditElectrcityHeader.SuspendLayout();
            pnlElectricityActionButton.SuspendLayout();
            pnlElectricityContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEditElectrcityHeader
            // 
            pnlEditElectrcityHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlEditElectrcityHeader.Controls.Add(lblEditElectricityBillTitle);
            pnlEditElectrcityHeader.Dock = DockStyle.Top;
            pnlEditElectrcityHeader.Location = new Point(0, 0);
            pnlEditElectrcityHeader.Name = "pnlEditElectrcityHeader";
            pnlEditElectrcityHeader.Size = new Size(382, 60);
            pnlEditElectrcityHeader.TabIndex = 1;
            // 
            // lblEditElectricityBillTitle
            // 
            lblEditElectricityBillTitle.Dock = DockStyle.Fill;
            lblEditElectricityBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditElectricityBillTitle.ForeColor = Color.White;
            lblEditElectricityBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblEditElectricityBillTitle.Location = new Point(0, 0);
            lblEditElectricityBillTitle.Name = "lblEditElectricityBillTitle";
            lblEditElectricityBillTitle.Size = new Size(380, 58);
            lblEditElectricityBillTitle.TabIndex = 14;
            lblEditElectricityBillTitle.Text = "Edit Electricity Bill";
            lblEditElectricityBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlElectricityActionButton
            // 
            pnlElectricityActionButton.Controls.Add(btnConfirm);
            pnlElectricityActionButton.Controls.Add(btnCancel);
            pnlElectricityActionButton.Dock = DockStyle.Bottom;
            pnlElectricityActionButton.Location = new Point(0, 303);
            pnlElectricityActionButton.Name = "pnlElectricityActionButton";
            pnlElectricityActionButton.Size = new Size(382, 50);
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
            pnlElectricityContent.Controls.Add(txtElectricityAmount);
            pnlElectricityContent.Controls.Add(lblEditElectricityAmount);
            pnlElectricityContent.Controls.Add(cboElectricityRoom);
            pnlElectricityContent.Controls.Add(lblElectricityRoom);
            pnlElectricityContent.Dock = DockStyle.Fill;
            pnlElectricityContent.Location = new Point(0, 60);
            pnlElectricityContent.Name = "pnlElectricityContent";
            pnlElectricityContent.Size = new Size(382, 243);
            pnlElectricityContent.TabIndex = 3;
            // 
            // txtElectricityAmount
            // 
            txtElectricityAmount.Location = new Point(65, 155);
            txtElectricityAmount.Multiline = true;
            txtElectricityAmount.Name = "txtElectricityAmount";
            txtElectricityAmount.Size = new Size(251, 34);
            txtElectricityAmount.TabIndex = 18;
            // 
            // lblEditElectricityAmount
            // 
            lblEditElectricityAmount.AutoSize = true;
            lblEditElectricityAmount.Font = new Font("Segoe UI", 13.2000008F);
            lblEditElectricityAmount.ForeColor = Color.White;
            lblEditElectricityAmount.ImageAlign = ContentAlignment.MiddleRight;
            lblEditElectricityAmount.Location = new Point(65, 121);
            lblEditElectricityAmount.Name = "lblEditElectricityAmount";
            lblEditElectricityAmount.Size = new Size(142, 31);
            lblEditElectricityAmount.TabIndex = 17;
            lblEditElectricityAmount.Text = "Edit Amount";
            lblEditElectricityAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboElectricityRoom
            // 
            cboElectricityRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboElectricityRoom.FormattingEnabled = true;
            cboElectricityRoom.Location = new Point(65, 61);
            cboElectricityRoom.Name = "cboElectricityRoom";
            cboElectricityRoom.Size = new Size(251, 28);
            cboElectricityRoom.TabIndex = 16;
            // 
            // lblElectricityRoom
            // 
            lblElectricityRoom.AutoSize = true;
            lblElectricityRoom.Font = new Font("Segoe UI", 13.2000008F);
            lblElectricityRoom.ForeColor = Color.White;
            lblElectricityRoom.ImageAlign = ContentAlignment.MiddleRight;
            lblElectricityRoom.Location = new Point(65, 27);
            lblElectricityRoom.Name = "lblElectricityRoom";
            lblElectricityRoom.Size = new Size(140, 31);
            lblElectricityRoom.TabIndex = 15;
            lblElectricityRoom.Text = "Select Room";
            lblElectricityRoom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditElectricityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(382, 353);
            Controls.Add(pnlElectricityContent);
            Controls.Add(pnlElectricityActionButton);
            Controls.Add(pnlEditElectrcityHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditElectricityForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditElectricityForm";
            pnlEditElectrcityHeader.ResumeLayout(false);
            pnlElectricityActionButton.ResumeLayout(false);
            pnlElectricityContent.ResumeLayout(false);
            pnlElectricityContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEditElectrcityHeader;
        private Label lblEditElectricityBillTitle;
        private Panel pnlElectricityActionButton;
        private Button btnConfirm;
        private Button btnCancel;
        private Panel pnlElectricityContent;
        private TextBox txtElectricityAmount;
        private Label lblEditElectricityAmount;
        private ComboBox cboElectricityRoom;
        private Label lblElectricityRoom;
    }
}