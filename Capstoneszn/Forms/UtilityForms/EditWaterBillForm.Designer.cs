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
            dtpDueDate = new DateTimePicker();
            dtpEndBillingPeriod = new DateTimePicker();
            dtpStartBillingPeriod = new DateTimePicker();
            label1 = new Label();
            lvlDueDate = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
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
            pnlEditWaterBillContent.Controls.Add(dtpDueDate);
            pnlEditWaterBillContent.Controls.Add(dtpEndBillingPeriod);
            pnlEditWaterBillContent.Controls.Add(dtpStartBillingPeriod);
            pnlEditWaterBillContent.Controls.Add(label1);
            pnlEditWaterBillContent.Controls.Add(lvlDueDate);
            pnlEditWaterBillContent.Controls.Add(label4);
            pnlEditWaterBillContent.Controls.Add(label3);
            pnlEditWaterBillContent.Controls.Add(label2);
            pnlEditWaterBillContent.Controls.Add(lblTotalBIll);
            pnlEditWaterBillContent.Controls.Add(txtTotalBill);
            pnlEditWaterBillContent.Dock = DockStyle.Fill;
            pnlEditWaterBillContent.Location = new Point(0, 60);
            pnlEditWaterBillContent.Name = "pnlEditWaterBillContent";
            pnlEditWaterBillContent.Size = new Size(598, 336);
            pnlEditWaterBillContent.TabIndex = 5;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(69, 139);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(237, 31);
            dtpDueDate.TabIndex = 7;
            // 
            // dtpEndBillingPeriod
            // 
            dtpEndBillingPeriod.Format = DateTimePickerFormat.Short;
            dtpEndBillingPeriod.Location = new Point(336, 64);
            dtpEndBillingPeriod.Name = "dtpEndBillingPeriod";
            dtpEndBillingPeriod.Size = new Size(195, 27);
            dtpEndBillingPeriod.TabIndex = 7;
            // 
            // dtpStartBillingPeriod
            // 
            dtpStartBillingPeriod.Format = DateTimePickerFormat.Short;
            dtpStartBillingPeriod.Location = new Point(69, 64);
            dtpStartBillingPeriod.Name = "dtpStartBillingPeriod";
            dtpStartBillingPeriod.Size = new Size(195, 27);
            dtpStartBillingPeriod.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(143, 251);
            label1.Name = "label1";
            label1.Size = new Size(44, 50);
            label1.TabIndex = 6;
            label1.Text = "₱";
            // 
            // lvlDueDate
            // 
            lvlDueDate.AutoSize = true;
            lvlDueDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lvlDueDate.ForeColor = Color.Transparent;
            lvlDueDate.Location = new Point(69, 111);
            lvlDueDate.Name = "lvlDueDate";
            lvlDueDate.Size = new Size(84, 25);
            lvlDueDate.TabIndex = 1;
            lvlDueDate.Text = "Due date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(336, 36);
            label4.Name = "label4";
            label4.Size = new Size(42, 25);
            label4.TabIndex = 1;
            label4.Text = "End";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(221, 2);
            label3.Name = "label3";
            label3.Size = new Size(116, 25);
            label3.TabIndex = 1;
            label3.Text = "Billing period";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(69, 36);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 1;
            label2.Text = "Start";
            // 
            // lblTotalBIll
            // 
            lblTotalBIll.AutoSize = true;
            lblTotalBIll.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalBIll.ForeColor = Color.Transparent;
            lblTotalBIll.Location = new Point(143, 222);
            lblTotalBIll.Name = "lblTotalBIll";
            lblTotalBIll.Size = new Size(121, 25);
            lblTotalBIll.TabIndex = 1;
            lblTotalBIll.Text = "Enter Total Bill";
            // 
            // txtTotalBill
            // 
            txtTotalBill.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalBill.Location = new Point(143, 250);
            txtTotalBill.Name = "txtTotalBill";
            txtTotalBill.Size = new Size(291, 51);
            txtTotalBill.TabIndex = 0;
            txtTotalBill.TextAlign = HorizontalAlignment.Right;
            // 
            // pnlEditWaterBillActionButtons
            // 
            pnlEditWaterBillActionButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlEditWaterBillActionButtons.Controls.Add(btnCancel);
            pnlEditWaterBillActionButtons.Controls.Add(btnConfirm);
            pnlEditWaterBillActionButtons.Dock = DockStyle.Bottom;
            pnlEditWaterBillActionButtons.Location = new Point(0, 396);
            pnlEditWaterBillActionButtons.Name = "pnlEditWaterBillActionButtons";
            pnlEditWaterBillActionButtons.Size = new Size(598, 50);
            pnlEditWaterBillActionButtons.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(197, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 35);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSize = true;
            btnConfirm.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(312, 3);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 35);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // pnlEditWaterBillHeader
            // 
            pnlEditWaterBillHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlEditWaterBillHeader.Controls.Add(lblEditWaterBillTitle);
            pnlEditWaterBillHeader.Dock = DockStyle.Top;
            pnlEditWaterBillHeader.Location = new Point(0, 0);
            pnlEditWaterBillHeader.Name = "pnlEditWaterBillHeader";
            pnlEditWaterBillHeader.Size = new Size(598, 60);
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
            lblEditWaterBillTitle.Size = new Size(596, 58);
            lblEditWaterBillTitle.TabIndex = 13;
            lblEditWaterBillTitle.Text = "Edit Water Bill";
            lblEditWaterBillTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditWaterBillForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(598, 446);
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
            Load += EditWaterBillForm_Load;
            pnlEditWaterBillContent.ResumeLayout(false);
            pnlEditWaterBillContent.PerformLayout();
            pnlEditWaterBillActionButtons.ResumeLayout(false);
            pnlEditWaterBillActionButtons.PerformLayout();
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
        private Label label1;
        private DateTimePicker dtpStartBillingPeriod;
        private DateTimePicker dtpDueDate;
        private DateTimePicker dtpEndBillingPeriod;
        private Label label2;
        private Label lvlDueDate;
        private Label label4;
        private Label label3;
    }
}