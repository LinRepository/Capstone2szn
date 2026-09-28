namespace Capstoneszn.Forms.UtilityForms
{
    partial class EditWaterBillForm
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
            pnlEditWaterBillContent = new Panel();
            lblTotalBIll = new Label();
            txtTotalBill = new TextBox();
            pnlEditWaterBillActionButtons = new Panel();
            btnCancel = new Button();
            btnConfirm = new Button();
            pnlEditWaterBillHeader = new Panel();
            lblEditWaterBillTitle = new Label();
            pnlEditWaterBillContent.SuspendLayout();
            pnlEditWaterBillActionButtons.SuspendLayout();
            pnlEditWaterBillHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEditWaterBillContent
            // 
            pnlEditWaterBillContent.BorderStyle = BorderStyle.FixedSingle;
            pnlEditWaterBillContent.Controls.Add(lblTotalBIll);
            pnlEditWaterBillContent.Controls.Add(txtTotalBill);
            pnlEditWaterBillContent.Dock = DockStyle.Fill;
            pnlEditWaterBillContent.Location = new Point(0, 60);
            pnlEditWaterBillContent.Name = "pnlEditWaterBillContent";
            pnlEditWaterBillContent.Size = new Size(382, 243);
            pnlEditWaterBillContent.TabIndex = 5;
            // 
            // lblTotalBIll
            // 
            lblTotalBIll.AutoSize = true;
            lblTotalBIll.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalBIll.ForeColor = Color.Transparent;
            lblTotalBIll.Location = new Point(86, 58);
            lblTotalBIll.Name = "lblTotalBIll";
            lblTotalBIll.Size = new Size(121, 25);
            lblTotalBIll.TabIndex = 1;
            lblTotalBIll.Text = "Enter Total Bill";
            // 
            // txtTotalBill
            // 
            txtTotalBill.Location = new Point(86, 86);
            txtTotalBill.Multiline = true;
            txtTotalBill.Name = "txtTotalBill";
            txtTotalBill.Size = new Size(200, 40);
            txtTotalBill.TabIndex = 0;
            // 
            // pnlEditWaterBillActionButtons
            // 
            pnlEditWaterBillActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlEditWaterBillActionButtons.Controls.Add(btnCancel);
            pnlEditWaterBillActionButtons.Controls.Add(btnConfirm);
            pnlEditWaterBillActionButtons.Dock = DockStyle.Bottom;
            pnlEditWaterBillActionButtons.Location = new Point(0, 303);
            pnlEditWaterBillActionButtons.Name = "pnlEditWaterBillActionButtons";
            pnlEditWaterBillActionButtons.Size = new Size(382, 50);
            pnlEditWaterBillActionButtons.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(136, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(261, 12);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // pnlEditWaterBillHeader
            // 
            pnlEditWaterBillHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlEditWaterBillHeader.Controls.Add(lblEditWaterBillTitle);
            pnlEditWaterBillHeader.Dock = DockStyle.Top;
            pnlEditWaterBillHeader.Location = new Point(0, 0);
            pnlEditWaterBillHeader.Name = "pnlEditWaterBillHeader";
            pnlEditWaterBillHeader.Size = new Size(382, 60);
            pnlEditWaterBillHeader.TabIndex = 3;
            // 
            // lblEditWaterBillTitle
            // 
            lblEditWaterBillTitle.Dock = DockStyle.Fill;
            lblEditWaterBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditWaterBillTitle.ForeColor = Color.White;
            lblEditWaterBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblEditWaterBillTitle.Location = new Point(0, 0);
            lblEditWaterBillTitle.Name = "lblEditWaterBillTitle";
            lblEditWaterBillTitle.Size = new Size(380, 58);
            lblEditWaterBillTitle.TabIndex = 13;
            lblEditWaterBillTitle.Text = "Edit Water Bill";
            lblEditWaterBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditWaterBillForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(382, 353);
            Controls.Add(pnlEditWaterBillContent);
            Controls.Add(pnlEditWaterBillActionButtons);
            Controls.Add(pnlEditWaterBillHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditWaterBillForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Water Bill";
            pnlEditWaterBillContent.ResumeLayout(false);
            pnlEditWaterBillContent.PerformLayout();
            pnlEditWaterBillActionButtons.ResumeLayout(false);
            pnlEditWaterBillHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEditWaterBillContent;
        private Label lblTotalBIll;
        private TextBox txtTotalBill;
        private Panel pnlEditWaterBillActionButtons;
        private Button btnCancel;
        private Button btnConfirm;
        private Panel pnlEditWaterBillHeader;
        private Label lblEditWaterBillTitle;
    }
}