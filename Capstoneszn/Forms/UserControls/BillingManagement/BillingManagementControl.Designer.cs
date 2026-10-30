namespace Capstoneszn.UserControls
{
    partial class BillingManagementControl
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
            pnlBillingHeader = new Panel();
            lblBillingTitle = new Label();
            pnlBillingContent = new Panel();
            tblBillingOptions = new TableLayoutPanel();
            pnlRoomAccount = new Panel();
            label1 = new Label();
            lblRoomAccount = new Label();
            pnlExpenses = new Panel();
            label2 = new Label();
            lblExpenses = new Label();
            pnlBillingHeader.SuspendLayout();
            pnlBillingContent.SuspendLayout();
            tblBillingOptions.SuspendLayout();
            pnlRoomAccount.SuspendLayout();
            pnlExpenses.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBillingHeader
            // 
            pnlBillingHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlBillingHeader.Controls.Add(lblBillingTitle);
            pnlBillingHeader.Dock = DockStyle.Top;
            pnlBillingHeader.Location = new Point(10, 10);
            pnlBillingHeader.Name = "pnlBillingHeader";
            pnlBillingHeader.Size = new Size(1559, 85);
            pnlBillingHeader.TabIndex = 1;
            // 
            // lblBillingTitle
            // 
            lblBillingTitle.Dock = DockStyle.Fill;
            lblBillingTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillingTitle.ForeColor = Color.White;
            lblBillingTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblBillingTitle.Location = new Point(0, 0);
            lblBillingTitle.Name = "lblBillingTitle";
            lblBillingTitle.Size = new Size(1557, 83);
            lblBillingTitle.TabIndex = 4;
            lblBillingTitle.Text = "Billing Management";
            lblBillingTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBillingContent
            // 
            pnlBillingContent.BorderStyle = BorderStyle.FixedSingle;
            pnlBillingContent.Controls.Add(tblBillingOptions);
            pnlBillingContent.Dock = DockStyle.Fill;
            pnlBillingContent.Location = new Point(10, 95);
            pnlBillingContent.Name = "pnlBillingContent";
            pnlBillingContent.Padding = new Padding(10);
            pnlBillingContent.Size = new Size(1559, 790);
            pnlBillingContent.TabIndex = 2;
            // 
            // tblBillingOptions
            // 
            tblBillingOptions.AutoScroll = true;
            tblBillingOptions.ColumnCount = 1;
            tblBillingOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblBillingOptions.Controls.Add(pnlRoomAccount, 0, 0);
            tblBillingOptions.Controls.Add(pnlExpenses, 0, 1);
            tblBillingOptions.Dock = DockStyle.Fill;
            tblBillingOptions.Location = new Point(10, 10);
            tblBillingOptions.Name = "tblBillingOptions";
            tblBillingOptions.RowCount = 2;
            tblBillingOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBillingOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBillingOptions.Size = new Size(1537, 768);
            tblBillingOptions.TabIndex = 0;
            // 
            // pnlRoomAccount
            // 
            pnlRoomAccount.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomAccount.Controls.Add(label1);
            pnlRoomAccount.Controls.Add(lblRoomAccount);
            pnlRoomAccount.Cursor = Cursors.Hand;
            pnlRoomAccount.Dock = DockStyle.Fill;
            pnlRoomAccount.Location = new Point(15, 15);
            pnlRoomAccount.Margin = new Padding(15);
            pnlRoomAccount.Name = "pnlRoomAccount";
            pnlRoomAccount.Size = new Size(1507, 354);
            pnlRoomAccount.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(25, 25, 75);
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(551, 12);
            label1.Name = "label1";
            label1.Size = new Size(381, 28);
            label1.TabIndex = 6;
            label1.Text = "\"Bills, payments and statements per room\"";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomAccount
            // 
            lblRoomAccount.BackColor = Color.FromArgb(25, 25, 75);
            lblRoomAccount.Dock = DockStyle.Fill;
            lblRoomAccount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomAccount.ForeColor = Color.White;
            lblRoomAccount.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomAccount.Location = new Point(0, 0);
            lblRoomAccount.Name = "lblRoomAccount";
            lblRoomAccount.Size = new Size(1505, 352);
            lblRoomAccount.TabIndex = 5;
            lblRoomAccount.Text = "Room Account";
            lblRoomAccount.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomAccount.Click += lblRoomAccount_Click;
            // 
            // pnlExpenses
            // 
            pnlExpenses.BorderStyle = BorderStyle.FixedSingle;
            pnlExpenses.Controls.Add(label2);
            pnlExpenses.Controls.Add(lblExpenses);
            pnlExpenses.Cursor = Cursors.Hand;
            pnlExpenses.Dock = DockStyle.Fill;
            pnlExpenses.Location = new Point(15, 399);
            pnlExpenses.Margin = new Padding(15);
            pnlExpenses.Name = "pnlExpenses";
            pnlExpenses.Size = new Size(1507, 354);
            pnlExpenses.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(25, 25, 75);
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(529, 22);
            label2.Name = "label2";
            label2.Size = new Size(442, 28);
            label2.TabIndex = 6;
            label2.Text = "“Building expenses (maintenance, utilities, salary)”";
            // 
            // lblExpenses
            // 
            lblExpenses.BackColor = Color.FromArgb(25, 25, 75);
            lblExpenses.Dock = DockStyle.Fill;
            lblExpenses.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpenses.ForeColor = Color.White;
            lblExpenses.ImageAlign = ContentAlignment.MiddleRight;
            lblExpenses.Location = new Point(0, 0);
            lblExpenses.Name = "lblExpenses";
            lblExpenses.Size = new Size(1505, 352);
            lblExpenses.TabIndex = 6;
            lblExpenses.Text = "Expenses";
            lblExpenses.TextAlign = ContentAlignment.MiddleCenter;
            lblExpenses.Click += lblExpenses_Click;
            // 
            // BillingManagementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            Controls.Add(pnlBillingContent);
            Controls.Add(pnlBillingHeader);
            Name = "BillingManagementControl";
            Padding = new Padding(10);
            Size = new Size(1579, 895);
            pnlBillingHeader.ResumeLayout(false);
            pnlBillingContent.ResumeLayout(false);
            tblBillingOptions.ResumeLayout(false);
            pnlRoomAccount.ResumeLayout(false);
            pnlRoomAccount.PerformLayout();
            pnlExpenses.ResumeLayout(false);
            pnlExpenses.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBillingHeader;
        private Panel pnlBillingContent;
        private Label lblBillingTitle;
        private TableLayoutPanel tblBillingOptions;
        private Panel pnlRoomAccount;
        private Panel pnlExpenses;
        private Label lblRoomAccount;
        private Label lblExpenses;
        private Label label1;
        private Label label2;
    }
}
