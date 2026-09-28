namespace Capstoneszn.Forms.UtilityForms
{
    partial class AddWaterBillForm
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
            lblAddWaterBillTitle = new Label();
            pnlAddBillActionButtons = new Panel();
            btnCancel = new Button();
            btnConfirm = new Button();
            pnlAddBillContent = new Panel();
            lblTotalBIll = new Label();
            txtTotalBill = new TextBox();
            pnlAddBillHeader.SuspendLayout();
            pnlAddBillActionButtons.SuspendLayout();
            pnlAddBillContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAddBillHeader
            // 
            pnlAddBillHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBillHeader.Controls.Add(lblAddWaterBillTitle);
            pnlAddBillHeader.Dock = DockStyle.Top;
            pnlAddBillHeader.Location = new Point(0, 0);
            pnlAddBillHeader.Name = "pnlAddBillHeader";
            pnlAddBillHeader.Size = new Size(382, 60);
            pnlAddBillHeader.TabIndex = 0;
            // 
            // lblAddWaterBillTitle
            // 
            lblAddWaterBillTitle.Dock = DockStyle.Fill;
            lblAddWaterBillTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddWaterBillTitle.ForeColor = Color.White;
            lblAddWaterBillTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddWaterBillTitle.Location = new Point(0, 0);
            lblAddWaterBillTitle.Name = "lblAddWaterBillTitle";
            lblAddWaterBillTitle.Size = new Size(380, 58);
            lblAddWaterBillTitle.TabIndex = 13;
            lblAddWaterBillTitle.Text = "Add Water Bill";
            lblAddWaterBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAddBillActionButtons
            // 
            pnlAddBillActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBillActionButtons.Controls.Add(btnCancel);
            pnlAddBillActionButtons.Controls.Add(btnConfirm);
            pnlAddBillActionButtons.Dock = DockStyle.Bottom;
            pnlAddBillActionButtons.Location = new Point(0, 303);
            pnlAddBillActionButtons.Name = "pnlAddBillActionButtons";
            pnlAddBillActionButtons.Size = new Size(382, 50);
            pnlAddBillActionButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(143, 11);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(261, 11);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // pnlAddBillContent
            // 
            pnlAddBillContent.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBillContent.Controls.Add(lblTotalBIll);
            pnlAddBillContent.Controls.Add(txtTotalBill);
            pnlAddBillContent.Dock = DockStyle.Fill;
            pnlAddBillContent.Location = new Point(0, 60);
            pnlAddBillContent.Name = "pnlAddBillContent";
            pnlAddBillContent.Size = new Size(382, 243);
            pnlAddBillContent.TabIndex = 2;
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
            // AddWaterBillForm
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
            Name = "AddWaterBillForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Water Bill";
            Load += AddWaterBillForm_Load;
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
        private Label lblAddWaterBillTitle;
        private Button btnCancel;
        private Button btnConfirm;
        private Label lblTotalBIll;
        private TextBox txtTotalBill;
    }
}