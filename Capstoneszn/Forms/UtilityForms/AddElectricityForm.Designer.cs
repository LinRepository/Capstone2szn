namespace Capstoneszn.Forms.UtilityForms
{
    partial class AddElectricityForm
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
            pnlElectrcityHeader = new Panel();
            lblAddElectricityBillTitle = new Label();
            pnlElectricityActionButton = new Panel();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlElectricityContent = new Panel();
            txtElectricityAmount = new TextBox();
            lblElectricityAmount = new Label();
            cboElectricityRoom = new ComboBox();
            lblElectricityRoom = new Label();
            pnlElectrcityHeader.SuspendLayout();
            pnlElectricityActionButton.SuspendLayout();
            pnlElectricityContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlElectrcityHeader
            // 
            pnlElectrcityHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlElectrcityHeader.Controls.Add(lblAddElectricityBillTitle);
            pnlElectrcityHeader.Dock = DockStyle.Top;
            pnlElectrcityHeader.Location = new Point(0, 0);
            pnlElectrcityHeader.Name = "pnlElectrcityHeader";
            pnlElectrcityHeader.Size = new Size(382, 60);
            pnlElectrcityHeader.TabIndex = 0;
            // 
            // lblAddElectricityBillTitle
            // 
            lblAddElectricityBillTitle.Dock = DockStyle.Fill;
            lblAddElectricityBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddElectricityBillTitle.ForeColor = Color.White;
            lblAddElectricityBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddElectricityBillTitle.Location = new Point(0, 0);
            lblAddElectricityBillTitle.Name = "lblAddElectricityBillTitle";
            lblAddElectricityBillTitle.Size = new Size(380, 58);
            lblAddElectricityBillTitle.TabIndex = 14;
            lblAddElectricityBillTitle.Text = "Add Electricity Bill";
            lblAddElectricityBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlElectricityActionButton
            // 
            pnlElectricityActionButton.Controls.Add(btnConfirm);
            pnlElectricityActionButton.Controls.Add(btnCancel);
            pnlElectricityActionButton.Dock = DockStyle.Bottom;
            pnlElectricityActionButton.Location = new Point(0, 303);
            pnlElectricityActionButton.Name = "pnlElectricityActionButton";
            pnlElectricityActionButton.Size = new Size(382, 50);
            pnlElectricityActionButton.TabIndex = 1;
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
            pnlElectricityContent.Controls.Add(lblElectricityAmount);
            pnlElectricityContent.Controls.Add(cboElectricityRoom);
            pnlElectricityContent.Controls.Add(lblElectricityRoom);
            pnlElectricityContent.Dock = DockStyle.Fill;
            pnlElectricityContent.Location = new Point(0, 60);
            pnlElectricityContent.Name = "pnlElectricityContent";
            pnlElectricityContent.Size = new Size(382, 243);
            pnlElectricityContent.TabIndex = 2;
            // 
            // txtElectricityAmount
            // 
            txtElectricityAmount.Location = new Point(65, 155);
            txtElectricityAmount.Multiline = true;
            txtElectricityAmount.Name = "txtElectricityAmount";
            txtElectricityAmount.Size = new Size(251, 34);
            txtElectricityAmount.TabIndex = 18;
            // 
            // lblElectricityAmount
            // 
            lblElectricityAmount.AutoSize = true;
            lblElectricityAmount.Font = new Font("Segoe UI", 13.2000008F);
            lblElectricityAmount.ForeColor = Color.White;
            lblElectricityAmount.ImageAlign = ContentAlignment.MiddleRight;
            lblElectricityAmount.Location = new Point(65, 121);
            lblElectricityAmount.Name = "lblElectricityAmount";
            lblElectricityAmount.Size = new Size(155, 31);
            lblElectricityAmount.TabIndex = 17;
            lblElectricityAmount.Text = "Enter Amount";
            lblElectricityAmount.TextAlign = ContentAlignment.MiddleCenter;
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
            // AddElectricityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(382, 353);
            Controls.Add(pnlElectricityContent);
            Controls.Add(pnlElectricityActionButton);
            Controls.Add(pnlElectrcityHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddElectricityForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddElectricityForm";
            pnlElectrcityHeader.ResumeLayout(false);
            pnlElectricityActionButton.ResumeLayout(false);
            pnlElectricityContent.ResumeLayout(false);
            pnlElectricityContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlElectrcityHeader;
        private Panel pnlElectricityActionButton;
        private Panel pnlElectricityContent;
        private Label lblAddElectricityBillTitle;
        private Button btnConfirm;
        private Button btnCancel;
        private Label lblElectricityRoom;
        private Label lblElectricityAmount;
        private ComboBox cboElectricityRoom;
        private TextBox txtElectricityAmount;
    }
}