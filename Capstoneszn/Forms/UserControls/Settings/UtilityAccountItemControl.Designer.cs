namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class UtilityAccountItemControl
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
            pnlUtilityAccountActions = new Panel();
            pnlUtilityAccountInfo = new Panel();
            btnEditUtilityAccount = new Button();
            btnArchiveUtilityAccount = new Button();
            tblUtilityAccountInfo = new TableLayoutPanel();
            lblRoomTitle = new Label();
            lblRoomValue = new Label();
            lblAccountNumberTitle = new Label();
            lblAccountNumberValue = new Label();
            lblIncludeToTitle = new Label();
            lblIncludeToValue = new Label();
            pnlUtilityAccountActions.SuspendLayout();
            pnlUtilityAccountInfo.SuspendLayout();
            tblUtilityAccountInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlUtilityAccountActions
            // 
            pnlUtilityAccountActions.Controls.Add(btnArchiveUtilityAccount);
            pnlUtilityAccountActions.Controls.Add(btnEditUtilityAccount);
            pnlUtilityAccountActions.Dock = DockStyle.Bottom;
            pnlUtilityAccountActions.Location = new Point(0, 100);
            pnlUtilityAccountActions.Name = "pnlUtilityAccountActions";
            pnlUtilityAccountActions.Size = new Size(400, 50);
            pnlUtilityAccountActions.TabIndex = 0;
            // 
            // pnlUtilityAccountInfo
            // 
            pnlUtilityAccountInfo.Controls.Add(tblUtilityAccountInfo);
            pnlUtilityAccountInfo.Dock = DockStyle.Fill;
            pnlUtilityAccountInfo.Location = new Point(0, 0);
            pnlUtilityAccountInfo.Name = "pnlUtilityAccountInfo";
            pnlUtilityAccountInfo.Size = new Size(400, 100);
            pnlUtilityAccountInfo.TabIndex = 1;
            // 
            // btnEditUtilityAccount
            // 
            btnEditUtilityAccount.Location = new Point(183, 11);
            btnEditUtilityAccount.Name = "btnEditUtilityAccount";
            btnEditUtilityAccount.Size = new Size(94, 29);
            btnEditUtilityAccount.TabIndex = 0;
            btnEditUtilityAccount.Text = "Edit";
            btnEditUtilityAccount.UseVisualStyleBackColor = true;
            // 
            // btnArchiveUtilityAccount
            // 
            btnArchiveUtilityAccount.Location = new Point(290, 11);
            btnArchiveUtilityAccount.Name = "btnArchiveUtilityAccount";
            btnArchiveUtilityAccount.Size = new Size(94, 29);
            btnArchiveUtilityAccount.TabIndex = 1;
            btnArchiveUtilityAccount.Text = "Archive";
            btnArchiveUtilityAccount.UseVisualStyleBackColor = true;
            // 
            // tblUtilityAccountInfo
            // 
            tblUtilityAccountInfo.ColumnCount = 2;
            tblUtilityAccountInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblUtilityAccountInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblUtilityAccountInfo.Controls.Add(lblIncludeToValue, 1, 2);
            tblUtilityAccountInfo.Controls.Add(lblIncludeToTitle, 0, 2);
            tblUtilityAccountInfo.Controls.Add(lblAccountNumberValue, 1, 1);
            tblUtilityAccountInfo.Controls.Add(lblAccountNumberTitle, 0, 1);
            tblUtilityAccountInfo.Controls.Add(lblRoomValue, 1, 0);
            tblUtilityAccountInfo.Controls.Add(lblRoomTitle, 0, 0);
            tblUtilityAccountInfo.Dock = DockStyle.Fill;
            tblUtilityAccountInfo.Location = new Point(0, 0);
            tblUtilityAccountInfo.Name = "tblUtilityAccountInfo";
            tblUtilityAccountInfo.RowCount = 3;
            tblUtilityAccountInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblUtilityAccountInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblUtilityAccountInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tblUtilityAccountInfo.Size = new Size(400, 100);
            tblUtilityAccountInfo.TabIndex = 0;
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.Dock = DockStyle.Fill;
            lblRoomTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomTitle.ForeColor = Color.White;
            lblRoomTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomTitle.Location = new Point(3, 0);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new Size(194, 33);
            lblRoomTitle.TabIndex = 10;
            lblRoomTitle.Text = "Room";
            lblRoomTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRoomValue
            // 
            lblRoomValue.Dock = DockStyle.Fill;
            lblRoomValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomValue.ForeColor = Color.White;
            lblRoomValue.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomValue.Location = new Point(203, 0);
            lblRoomValue.Name = "lblRoomValue";
            lblRoomValue.Size = new Size(194, 33);
            lblRoomValue.TabIndex = 11;
            lblRoomValue.Text = "###";
            lblRoomValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAccountNumberTitle
            // 
            lblAccountNumberTitle.Dock = DockStyle.Fill;
            lblAccountNumberTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountNumberTitle.ForeColor = Color.White;
            lblAccountNumberTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAccountNumberTitle.Location = new Point(3, 33);
            lblAccountNumberTitle.Name = "lblAccountNumberTitle";
            lblAccountNumberTitle.Size = new Size(194, 33);
            lblAccountNumberTitle.TabIndex = 12;
            lblAccountNumberTitle.Text = "Account Number";
            lblAccountNumberTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAccountNumberValue
            // 
            lblAccountNumberValue.Dock = DockStyle.Fill;
            lblAccountNumberValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountNumberValue.ForeColor = Color.White;
            lblAccountNumberValue.ImageAlign = ContentAlignment.MiddleRight;
            lblAccountNumberValue.Location = new Point(203, 33);
            lblAccountNumberValue.Name = "lblAccountNumberValue";
            lblAccountNumberValue.Size = new Size(194, 33);
            lblAccountNumberValue.TabIndex = 13;
            lblAccountNumberValue.Text = "##########";
            lblAccountNumberValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIncludeToTitle
            // 
            lblIncludeToTitle.Dock = DockStyle.Fill;
            lblIncludeToTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIncludeToTitle.ForeColor = Color.White;
            lblIncludeToTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblIncludeToTitle.Location = new Point(3, 66);
            lblIncludeToTitle.Name = "lblIncludeToTitle";
            lblIncludeToTitle.Size = new Size(194, 34);
            lblIncludeToTitle.TabIndex = 14;
            lblIncludeToTitle.Text = "Include To";
            lblIncludeToTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIncludeToValue
            // 
            lblIncludeToValue.Dock = DockStyle.Fill;
            lblIncludeToValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIncludeToValue.ForeColor = Color.White;
            lblIncludeToValue.ImageAlign = ContentAlignment.MiddleRight;
            lblIncludeToValue.Location = new Point(203, 66);
            lblIncludeToValue.Name = "lblIncludeToValue";
            lblIncludeToValue.Size = new Size(194, 34);
            lblIncludeToValue.TabIndex = 15;
            lblIncludeToValue.Text = "None/Owner";
            lblIncludeToValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UtilityAccountItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlUtilityAccountInfo);
            Controls.Add(pnlUtilityAccountActions);
            Name = "UtilityAccountItemControl";
            Size = new Size(400, 150);
            pnlUtilityAccountActions.ResumeLayout(false);
            pnlUtilityAccountInfo.ResumeLayout(false);
            tblUtilityAccountInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlUtilityAccountActions;
        private Panel pnlUtilityAccountInfo;
        private Button btnArchiveUtilityAccount;
        private Button btnEditUtilityAccount;
        private TableLayoutPanel tblUtilityAccountInfo;
        private Label lblRoomTitle;
        private Label lblIncludeToValue;
        private Label lblIncludeToTitle;
        private Label lblAccountNumberValue;
        private Label lblAccountNumberTitle;
        private Label lblRoomValue;
    }
}
