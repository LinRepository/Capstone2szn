namespace Capstoneszn.Forms.UtilityForms
{
    partial class AddBillForm
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
            pnlAddBillHeader = new Panel();
            pnlAddBillActionButtons = new Panel();
            pnlAddBillContent = new Panel();
            lblAddBillTitle = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            txtTotalBill = new TextBox();
            lblTotalBIll = new Label();
            pnlAddBillHeader.SuspendLayout();
            pnlAddBillActionButtons.SuspendLayout();
            pnlAddBillContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAddBillHeader
            // 
            pnlAddBillHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBillHeader.Controls.Add(lblAddBillTitle);
            pnlAddBillHeader.Dock = DockStyle.Top;
            pnlAddBillHeader.Location = new Point(0, 0);
            pnlAddBillHeader.Name = "pnlAddBillHeader";
            pnlAddBillHeader.Size = new Size(382, 70);
            pnlAddBillHeader.TabIndex = 0;
            // 
            // pnlAddBillActionButtons
            // 
            pnlAddBillActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBillActionButtons.Controls.Add(btnCancel);
            pnlAddBillActionButtons.Controls.Add(btnConfirm);
            pnlAddBillActionButtons.Dock = DockStyle.Bottom;
            pnlAddBillActionButtons.Location = new Point(0, 283);
            pnlAddBillActionButtons.Name = "pnlAddBillActionButtons";
            pnlAddBillActionButtons.Size = new Size(382, 70);
            pnlAddBillActionButtons.TabIndex = 1;
            // 
            // pnlAddBillContent
            // 
            pnlAddBillContent.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBillContent.Controls.Add(lblTotalBIll);
            pnlAddBillContent.Controls.Add(txtTotalBill);
            pnlAddBillContent.Dock = DockStyle.Fill;
            pnlAddBillContent.Location = new Point(0, 70);
            pnlAddBillContent.Name = "pnlAddBillContent";
            pnlAddBillContent.Size = new Size(382, 213);
            pnlAddBillContent.TabIndex = 2;
            // 
            // lblAddBillTitle
            // 
            lblAddBillTitle.Dock = DockStyle.Fill;
            lblAddBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddBillTitle.ForeColor = Color.White;
            lblAddBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddBillTitle.Location = new Point(0, 0);
            lblAddBillTitle.Name = "lblAddBillTitle";
            lblAddBillTitle.Size = new Size(380, 68);
            lblAddBillTitle.TabIndex = 13;
            lblAddBillTitle.Text = "Add Bill";
            lblAddBillTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            // btnCancel
            // 
            btnCancel.Location = new Point(134, 20);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtTotalBill
            // 
            txtTotalBill.Location = new Point(86, 86);
            txtTotalBill.Multiline = true;
            txtTotalBill.Name = "txtTotalBill";
            txtTotalBill.Size = new Size(200, 40);
            txtTotalBill.TabIndex = 0;
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
            // AddBillForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(382, 353);
            Controls.Add(pnlAddBillContent);
            Controls.Add(pnlAddBillActionButtons);
            Controls.Add(pnlAddBillHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBillForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Bill";
            pnlAddBillHeader.ResumeLayout(false);
            pnlAddBillActionButtons.ResumeLayout(false);
            pnlAddBillContent.ResumeLayout(false);
            pnlAddBillContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAddBillHeader;
        private Panel pnlAddBillActionButtons;
        private Panel pnlAddBillContent;
        private Label lblAddBillTitle;
        private Button btnCancel;
        private Button btnConfirm;
        private Label lblTotalBIll;
        private TextBox txtTotalBill;
    }
}