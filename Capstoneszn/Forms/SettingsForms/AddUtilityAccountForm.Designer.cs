namespace Capstoneszn.Forms.SettingsForms
{
    partial class AddUtilityAccountForm
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
            pnlUtilityAccountHeader = new Panel();
            pnlUtilityAccountActions = new Panel();
            pnlUtilityAccountContent = new Panel();
            lblUtilityAccountTitle = new Label();
            pnlRoom = new Panel();
            pnlIncludeTo = new Panel();
            pnlAccountNumber = new Panel();
            btnCancelUtilityAccount = new Button();
            btnAddUtilityAccount = new Button();
            lblRoom = new Label();
            cboRoom = new ComboBox();
            lblAccountNumber = new Label();
            lblIncludeTo = new Label();
            txtAccountNumber = new TextBox();
            cboIncludeTo = new ComboBox();
            pnlUtilityAccountHeader.SuspendLayout();
            pnlUtilityAccountActions.SuspendLayout();
            pnlUtilityAccountContent.SuspendLayout();
            pnlRoom.SuspendLayout();
            pnlIncludeTo.SuspendLayout();
            pnlAccountNumber.SuspendLayout();
            SuspendLayout();
            // 
            // pnlUtilityAccountHeader
            // 
            pnlUtilityAccountHeader.Controls.Add(lblUtilityAccountTitle);
            pnlUtilityAccountHeader.Dock = DockStyle.Top;
            pnlUtilityAccountHeader.Location = new Point(0, 0);
            pnlUtilityAccountHeader.Name = "pnlUtilityAccountHeader";
            pnlUtilityAccountHeader.Size = new Size(482, 75);
            pnlUtilityAccountHeader.TabIndex = 0;
            // 
            // pnlUtilityAccountActions
            // 
            pnlUtilityAccountActions.Controls.Add(btnAddUtilityAccount);
            pnlUtilityAccountActions.Controls.Add(btnCancelUtilityAccount);
            pnlUtilityAccountActions.Dock = DockStyle.Bottom;
            pnlUtilityAccountActions.Location = new Point(0, 328);
            pnlUtilityAccountActions.Name = "pnlUtilityAccountActions";
            pnlUtilityAccountActions.Size = new Size(482, 75);
            pnlUtilityAccountActions.TabIndex = 1;
            // 
            // pnlUtilityAccountContent
            // 
            pnlUtilityAccountContent.Controls.Add(pnlAccountNumber);
            pnlUtilityAccountContent.Controls.Add(pnlIncludeTo);
            pnlUtilityAccountContent.Controls.Add(pnlRoom);
            pnlUtilityAccountContent.Dock = DockStyle.Fill;
            pnlUtilityAccountContent.Location = new Point(0, 75);
            pnlUtilityAccountContent.Name = "pnlUtilityAccountContent";
            pnlUtilityAccountContent.Size = new Size(482, 253);
            pnlUtilityAccountContent.TabIndex = 2;
            // 
            // lblUtilityAccountTitle
            // 
            lblUtilityAccountTitle.Dock = DockStyle.Fill;
            lblUtilityAccountTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUtilityAccountTitle.ForeColor = Color.White;
            lblUtilityAccountTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblUtilityAccountTitle.Location = new Point(0, 0);
            lblUtilityAccountTitle.Name = "lblUtilityAccountTitle";
            lblUtilityAccountTitle.Size = new Size(482, 75);
            lblUtilityAccountTitle.TabIndex = 10;
            lblUtilityAccountTitle.Text = "Add Water/Electricity Bill Account";
            lblUtilityAccountTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoom
            // 
            pnlRoom.Controls.Add(cboRoom);
            pnlRoom.Controls.Add(lblRoom);
            pnlRoom.Dock = DockStyle.Top;
            pnlRoom.Location = new Point(0, 0);
            pnlRoom.Name = "pnlRoom";
            pnlRoom.Padding = new Padding(10);
            pnlRoom.Size = new Size(482, 80);
            pnlRoom.TabIndex = 0;
            // 
            // pnlIncludeTo
            // 
            pnlIncludeTo.Controls.Add(cboIncludeTo);
            pnlIncludeTo.Controls.Add(lblIncludeTo);
            pnlIncludeTo.Dock = DockStyle.Bottom;
            pnlIncludeTo.Location = new Point(0, 173);
            pnlIncludeTo.Name = "pnlIncludeTo";
            pnlIncludeTo.Padding = new Padding(10);
            pnlIncludeTo.Size = new Size(482, 80);
            pnlIncludeTo.TabIndex = 1;
            // 
            // pnlAccountNumber
            // 
            pnlAccountNumber.Controls.Add(txtAccountNumber);
            pnlAccountNumber.Controls.Add(lblAccountNumber);
            pnlAccountNumber.Dock = DockStyle.Fill;
            pnlAccountNumber.Location = new Point(0, 80);
            pnlAccountNumber.Name = "pnlAccountNumber";
            pnlAccountNumber.Padding = new Padding(10);
            pnlAccountNumber.Size = new Size(482, 93);
            pnlAccountNumber.TabIndex = 2;
            // 
            // btnCancelUtilityAccount
            // 
            btnCancelUtilityAccount.Cursor = Cursors.Hand;
            btnCancelUtilityAccount.Location = new Point(231, 30);
            btnCancelUtilityAccount.Name = "btnCancelUtilityAccount";
            btnCancelUtilityAccount.Size = new Size(94, 29);
            btnCancelUtilityAccount.TabIndex = 0;
            btnCancelUtilityAccount.Text = "Cancel";
            btnCancelUtilityAccount.UseVisualStyleBackColor = true;
            // 
            // btnAddUtilityAccount
            // 
            btnAddUtilityAccount.Cursor = Cursors.Hand;
            btnAddUtilityAccount.Location = new Point(360, 30);
            btnAddUtilityAccount.Name = "btnAddUtilityAccount";
            btnAddUtilityAccount.Size = new Size(94, 29);
            btnAddUtilityAccount.TabIndex = 1;
            btnAddUtilityAccount.Text = "Add";
            btnAddUtilityAccount.UseVisualStyleBackColor = true;
            // 
            // lblRoom
            // 
            lblRoom.Dock = DockStyle.Top;
            lblRoom.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoom.ForeColor = Color.White;
            lblRoom.ImageAlign = ContentAlignment.MiddleRight;
            lblRoom.Location = new Point(10, 10);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(462, 33);
            lblRoom.TabIndex = 11;
            lblRoom.Text = "Room";
            lblRoom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboRoom
            // 
            cboRoom.Dock = DockStyle.Top;
            cboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new Point(10, 43);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new Size(462, 28);
            cboRoom.TabIndex = 12;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.Dock = DockStyle.Top;
            lblAccountNumber.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountNumber.ForeColor = Color.White;
            lblAccountNumber.ImageAlign = ContentAlignment.MiddleRight;
            lblAccountNumber.Location = new Point(10, 10);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(462, 33);
            lblAccountNumber.TabIndex = 12;
            lblAccountNumber.Text = "Account Number";
            lblAccountNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIncludeTo
            // 
            lblIncludeTo.Dock = DockStyle.Top;
            lblIncludeTo.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIncludeTo.ForeColor = Color.White;
            lblIncludeTo.ImageAlign = ContentAlignment.MiddleRight;
            lblIncludeTo.Location = new Point(10, 10);
            lblIncludeTo.Name = "lblIncludeTo";
            lblIncludeTo.Size = new Size(462, 33);
            lblIncludeTo.TabIndex = 12;
            lblIncludeTo.Text = "Include To:";
            lblIncludeTo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.Dock = DockStyle.Top;
            txtAccountNumber.Location = new Point(10, 43);
            txtAccountNumber.Multiline = true;
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.Size = new Size(462, 34);
            txtAccountNumber.TabIndex = 13;
            // 
            // cboIncludeTo
            // 
            cboIncludeTo.Dock = DockStyle.Top;
            cboIncludeTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIncludeTo.FormattingEnabled = true;
            cboIncludeTo.Location = new Point(10, 43);
            cboIncludeTo.Name = "cboIncludeTo";
            cboIncludeTo.Size = new Size(462, 28);
            cboIncludeTo.TabIndex = 13;
            // 
            // AddUtilityAccountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 403);
            Controls.Add(pnlUtilityAccountContent);
            Controls.Add(pnlUtilityAccountActions);
            Controls.Add(pnlUtilityAccountHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddUtilityAccountForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Utility Account";
            pnlUtilityAccountHeader.ResumeLayout(false);
            pnlUtilityAccountActions.ResumeLayout(false);
            pnlUtilityAccountContent.ResumeLayout(false);
            pnlRoom.ResumeLayout(false);
            pnlIncludeTo.ResumeLayout(false);
            pnlAccountNumber.ResumeLayout(false);
            pnlAccountNumber.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlUtilityAccountHeader;
        private Panel pnlUtilityAccountActions;
        private Panel pnlUtilityAccountContent;
        private Label lblUtilityAccountTitle;
        private Panel pnlAccountNumber;
        private Panel pnlIncludeTo;
        private Panel pnlRoom;
        private Button btnAddUtilityAccount;
        private Button btnCancelUtilityAccount;
        private Label lblRoom;
        private ComboBox cboRoom;
        private Label lblAccountNumber;
        private Label lblIncludeTo;
        private TextBox txtAccountNumber;
        private ComboBox cboIncludeTo;
    }
}