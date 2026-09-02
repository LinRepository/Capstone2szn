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
            pnlBillingContent = new Panel();
            lblBillingTitle = new Label();
            tblBillingOptions = new TableLayoutPanel();
            pnlRoomAccount = new Panel();
            pnlExpenses = new Panel();
            lblRoomAccount = new Label();
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
            pnlBillingHeader.Controls.Add(lblBillingTitle);
            pnlBillingHeader.Dock = DockStyle.Top;
            pnlBillingHeader.Location = new Point(0, 0);
            pnlBillingHeader.Name = "pnlBillingHeader";
            pnlBillingHeader.Size = new Size(1300, 100);
            pnlBillingHeader.TabIndex = 1;
            // 
            // pnlBillingContent
            // 
            pnlBillingContent.Controls.Add(tblBillingOptions);
            pnlBillingContent.Dock = DockStyle.Fill;
            pnlBillingContent.Location = new Point(0, 100);
            pnlBillingContent.Name = "pnlBillingContent";
            pnlBillingContent.Size = new Size(1300, 650);
            pnlBillingContent.TabIndex = 2;
            // 
            // lblBillingTitle
            // 
            lblBillingTitle.Dock = DockStyle.Fill;
            lblBillingTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillingTitle.ForeColor = Color.White;
            lblBillingTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblBillingTitle.Location = new Point(0, 0);
            lblBillingTitle.Name = "lblBillingTitle";
            lblBillingTitle.Size = new Size(1300, 100);
            lblBillingTitle.TabIndex = 4;
            lblBillingTitle.Text = "Billing Management";
            lblBillingTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblBillingOptions
            // 
            tblBillingOptions.AutoScroll = true;
            tblBillingOptions.ColumnCount = 1;
            tblBillingOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblBillingOptions.Controls.Add(pnlRoomAccount, 0, 0);
            tblBillingOptions.Controls.Add(pnlExpenses, 0, 1);
            tblBillingOptions.Dock = DockStyle.Fill;
            tblBillingOptions.Location = new Point(0, 0);
            tblBillingOptions.Name = "tblBillingOptions";
            tblBillingOptions.RowCount = 2;
            tblBillingOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBillingOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblBillingOptions.Size = new Size(1300, 650);
            tblBillingOptions.TabIndex = 0;
            // 
            // pnlRoomAccount
            // 
            pnlRoomAccount.Controls.Add(lblRoomAccount);
            pnlRoomAccount.Cursor = Cursors.Hand;
            pnlRoomAccount.Dock = DockStyle.Fill;
            pnlRoomAccount.Location = new Point(15, 15);
            pnlRoomAccount.Margin = new Padding(15);
            pnlRoomAccount.Name = "pnlRoomAccount";
            pnlRoomAccount.Size = new Size(1270, 295);
            pnlRoomAccount.TabIndex = 0;
            // 
            // pnlExpenses
            // 
            pnlExpenses.Controls.Add(lblExpenses);
            pnlExpenses.Cursor = Cursors.Hand;
            pnlExpenses.Dock = DockStyle.Fill;
            pnlExpenses.Location = new Point(15, 340);
            pnlExpenses.Margin = new Padding(15);
            pnlExpenses.Name = "pnlExpenses";
            pnlExpenses.Size = new Size(1270, 295);
            pnlExpenses.TabIndex = 1;
            // 
            // lblRoomAccount
            // 
            lblRoomAccount.Dock = DockStyle.Fill;
            lblRoomAccount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomAccount.ForeColor = Color.White;
            lblRoomAccount.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomAccount.Location = new Point(0, 0);
            lblRoomAccount.Name = "lblRoomAccount";
            lblRoomAccount.Size = new Size(1270, 295);
            lblRoomAccount.TabIndex = 5;
            lblRoomAccount.Text = "Room Account";
            lblRoomAccount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblExpenses
            // 
            lblExpenses.Dock = DockStyle.Fill;
            lblExpenses.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpenses.ForeColor = Color.White;
            lblExpenses.ImageAlign = ContentAlignment.MiddleRight;
            lblExpenses.Location = new Point(0, 0);
            lblExpenses.Name = "lblExpenses";
            lblExpenses.Size = new Size(1270, 295);
            lblExpenses.TabIndex = 6;
            lblExpenses.Text = "Expenses";
            lblExpenses.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BillingManagementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlBillingContent);
            Controls.Add(pnlBillingHeader);
            Name = "BillingManagementControl";
            Size = new Size(1300, 750);
            pnlBillingHeader.ResumeLayout(false);
            pnlBillingContent.ResumeLayout(false);
            tblBillingOptions.ResumeLayout(false);
            pnlRoomAccount.ResumeLayout(false);
            pnlExpenses.ResumeLayout(false);
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
    }
}
