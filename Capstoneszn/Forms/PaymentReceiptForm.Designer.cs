namespace Capstoneszn.Forms
{
    partial class PaymentReceiptForm
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
            pnlReceiptBody = new Panel();
            dgvReceiptLines = new DataGridView();
            lblReceiptTotal = new Label();
            lblReceiptInfo = new Label();
            lblVoidBanner = new Label();
            lblReceiptTitle = new Label();
            pnlReceiptActions = new Panel();
            btnPrintReceipt = new Button();
            btnCloseReceipt = new Button();
            pnlReceiptBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReceiptLines).BeginInit();
            pnlReceiptActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlReceiptBody
            // 
            pnlReceiptBody.BackColor = Color.White;
            pnlReceiptBody.Controls.Add(dgvReceiptLines);
            pnlReceiptBody.Controls.Add(lblReceiptTotal);
            pnlReceiptBody.Controls.Add(lblReceiptInfo);
            pnlReceiptBody.Controls.Add(lblVoidBanner);
            pnlReceiptBody.Controls.Add(lblReceiptTitle);
            pnlReceiptBody.Dock = DockStyle.Fill;
            pnlReceiptBody.Location = new Point(0, 0);
            pnlReceiptBody.Name = "pnlReceiptBody";
            pnlReceiptBody.Padding = new Padding(20, 10, 20, 10);
            pnlReceiptBody.Size = new Size(620, 585);
            pnlReceiptBody.TabIndex = 0;
            // 
            // dgvReceiptLines
            // 
            dgvReceiptLines.ColumnHeadersHeight = 29;
            dgvReceiptLines.Dock = DockStyle.Fill;
            dgvReceiptLines.Location = new Point(20, 335);
            dgvReceiptLines.Name = "dgvReceiptLines";
            dgvReceiptLines.RowHeadersWidth = 51;
            dgvReceiptLines.Size = new Size(580, 195);
            dgvReceiptLines.TabIndex = 3;
            // 
            // lblReceiptTotal
            // 
            lblReceiptTotal.Dock = DockStyle.Bottom;
            lblReceiptTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReceiptTotal.ForeColor = Color.Black;
            lblReceiptTotal.Location = new Point(20, 530);
            lblReceiptTotal.Name = "lblReceiptTotal";
            lblReceiptTotal.Size = new Size(580, 45);
            lblReceiptTotal.TabIndex = 4;
            lblReceiptTotal.Text = "TOTAL PAID";
            lblReceiptTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblReceiptInfo
            // 
            lblReceiptInfo.Dock = DockStyle.Top;
            lblReceiptInfo.Font = new Font("Consolas", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReceiptInfo.ForeColor = Color.Black;
            lblReceiptInfo.Location = new Point(20, 120);
            lblReceiptInfo.Name = "lblReceiptInfo";
            lblReceiptInfo.Padding = new Padding(0, 8, 0, 8);
            lblReceiptInfo.Size = new Size(580, 215);
            lblReceiptInfo.TabIndex = 2;
            lblReceiptInfo.Text = "Info";
            // 
            // lblVoidBanner
            // 
            lblVoidBanner.BackColor = Color.MistyRose;
            lblVoidBanner.Dock = DockStyle.Top;
            lblVoidBanner.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVoidBanner.ForeColor = Color.DarkRed;
            lblVoidBanner.Location = new Point(20, 70);
            lblVoidBanner.Name = "lblVoidBanner";
            lblVoidBanner.Size = new Size(580, 50);
            lblVoidBanner.TabIndex = 1;
            lblVoidBanner.Text = "VOIDED";
            lblVoidBanner.TextAlign = ContentAlignment.MiddleCenter;
            lblVoidBanner.Visible = false;
            // 
            // lblReceiptTitle
            // 
            lblReceiptTitle.Dock = DockStyle.Top;
            lblReceiptTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReceiptTitle.ForeColor = Color.Black;
            lblReceiptTitle.Location = new Point(20, 10);
            lblReceiptTitle.Name = "lblReceiptTitle";
            lblReceiptTitle.Size = new Size(580, 60);
            lblReceiptTitle.TabIndex = 0;
            lblReceiptTitle.Text = "Building Name\r\nOFFICIAL RECEIPT";
            lblReceiptTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlReceiptActions
            // 
            pnlReceiptActions.Controls.Add(btnPrintReceipt);
            pnlReceiptActions.Controls.Add(btnCloseReceipt);
            pnlReceiptActions.Dock = DockStyle.Bottom;
            pnlReceiptActions.Location = new Point(0, 585);
            pnlReceiptActions.Name = "pnlReceiptActions";
            pnlReceiptActions.Size = new Size(620, 55);
            pnlReceiptActions.TabIndex = 1;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrintReceipt.Location = new Point(355, 10);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(130, 35);
            btnPrintReceipt.TabIndex = 0;
            btnPrintReceipt.Text = "Print / PDF";
            btnPrintReceipt.UseVisualStyleBackColor = true;
            btnPrintReceipt.Click += btnPrintReceipt_Click;
            // 
            // btnCloseReceipt
            // 
            btnCloseReceipt.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCloseReceipt.Location = new Point(495, 10);
            btnCloseReceipt.Name = "btnCloseReceipt";
            btnCloseReceipt.Size = new Size(110, 35);
            btnCloseReceipt.TabIndex = 1;
            btnCloseReceipt.Text = "Close";
            btnCloseReceipt.UseVisualStyleBackColor = true;
            btnCloseReceipt.Click += btnCloseReceipt_Click;
            // 
            // PaymentReceiptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(620, 640);
            Controls.Add(pnlReceiptBody);
            Controls.Add(pnlReceiptActions);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentReceiptForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Receipt";
            Load += PaymentReceiptForm_Load;
            pnlReceiptBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReceiptLines).EndInit();
            pnlReceiptActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlReceiptBody;
        private Label lblReceiptTitle;
        private Label lblVoidBanner;
        private Label lblReceiptInfo;
        private DataGridView dgvReceiptLines;
        private Label lblReceiptTotal;
        private Panel pnlReceiptActions;
        private Button btnPrintReceipt;
        private Button btnCloseReceipt;
    }
}