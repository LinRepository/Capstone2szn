namespace Capstoneszn.Forms.UtilityForms
{
    partial class EditBillForm
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
            pnlEditBillContent = new Panel();
            lblTotalBIll = new Label();
            txtTotalBill = new TextBox();
            pnlEditBillActionButtons = new Panel();
            btnCancel = new Button();
            btnConfirm = new Button();
            pnlEditBillHeader = new Panel();
            lblEditBillTitle = new Label();
            pnlEditBillContent.SuspendLayout();
            pnlEditBillActionButtons.SuspendLayout();
            pnlEditBillHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEditBillContent
            // 
            pnlEditBillContent.BorderStyle = BorderStyle.FixedSingle;
            pnlEditBillContent.Controls.Add(lblTotalBIll);
            pnlEditBillContent.Controls.Add(txtTotalBill);
            pnlEditBillContent.Dock = DockStyle.Fill;
            pnlEditBillContent.Location = new Point(0, 70);
            pnlEditBillContent.Name = "pnlEditBillContent";
            pnlEditBillContent.Size = new Size(382, 213);
            pnlEditBillContent.TabIndex = 5;
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
            // pnlEditBillActionButtons
            // 
            pnlEditBillActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlEditBillActionButtons.Controls.Add(btnCancel);
            pnlEditBillActionButtons.Controls.Add(btnConfirm);
            pnlEditBillActionButtons.Dock = DockStyle.Bottom;
            pnlEditBillActionButtons.Location = new Point(0, 283);
            pnlEditBillActionButtons.Name = "pnlEditBillActionButtons";
            pnlEditBillActionButtons.Size = new Size(382, 70);
            pnlEditBillActionButtons.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(134, 20);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(261, 20);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // pnlEditBillHeader
            // 
            pnlEditBillHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlEditBillHeader.Controls.Add(lblEditBillTitle);
            pnlEditBillHeader.Dock = DockStyle.Top;
            pnlEditBillHeader.Location = new Point(0, 0);
            pnlEditBillHeader.Name = "pnlEditBillHeader";
            pnlEditBillHeader.Size = new Size(382, 70);
            pnlEditBillHeader.TabIndex = 3;
            // 
            // lblEditBillTitle
            // 
            lblEditBillTitle.Dock = DockStyle.Fill;
            lblEditBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEditBillTitle.ForeColor = Color.White;
            lblEditBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblEditBillTitle.Location = new Point(0, 0);
            lblEditBillTitle.Name = "lblEditBillTitle";
            lblEditBillTitle.Size = new Size(380, 68);
            lblEditBillTitle.TabIndex = 13;
            lblEditBillTitle.Text = "Edit Bill";
            lblEditBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditBillForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(382, 353);
            Controls.Add(pnlEditBillContent);
            Controls.Add(pnlEditBillActionButtons);
            Controls.Add(pnlEditBillHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditBillForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Bill";
            pnlEditBillContent.ResumeLayout(false);
            pnlEditBillContent.PerformLayout();
            pnlEditBillActionButtons.ResumeLayout(false);
            pnlEditBillHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEditBillContent;
        private Label lblTotalBIll;
        private TextBox txtTotalBill;
        private Panel pnlEditBillActionButtons;
        private Button btnCancel;
        private Button btnConfirm;
        private Panel pnlEditBillHeader;
        private Label lblEditBillTitle;
    }
}