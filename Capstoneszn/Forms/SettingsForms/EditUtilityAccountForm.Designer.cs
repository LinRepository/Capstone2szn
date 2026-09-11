namespace Capstoneszn.Forms.SettingsForms
{
    partial class EditUtilityAccountForm
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
            pnlUtilityAccountContent = new Panel();
            pnlAccountNumber = new Panel();
            txtAccountNumber = new TextBox();
            lblAccountNumber = new Label();
            pnlIncludeTo = new Panel();
            cboIncludeTo = new ComboBox();
            lblIncludeTo = new Label();
            pnlRoom = new Panel();
            cboRoom = new ComboBox();
            lblRoom = new Label();
            pnlUtilityAccountActions = new Panel();
            btnSaveUtilityAccount = new Button();
            btnCancelEditUtilityAccount = new Button();
            pnlUtilityAccountHeader = new Panel();
            lblUtilityAccountTitle = new Label();
            pnlUtilityAccountContent.SuspendLayout();
            pnlAccountNumber.SuspendLayout();
            pnlIncludeTo.SuspendLayout();
            pnlRoom.SuspendLayout();
            pnlUtilityAccountActions.SuspendLayout();
            pnlUtilityAccountHeader.SuspendLayout();
            SuspendLayout();
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
            pnlUtilityAccountContent.TabIndex = 5;
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
            // txtAccountNumber
            // 
            txtAccountNumber.Dock = DockStyle.Top;
            txtAccountNumber.Location = new Point(10, 43);
            txtAccountNumber.Multiline = true;
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.Size = new Size(462, 34);
            txtAccountNumber.TabIndex = 13;
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
            // pnlUtilityAccountActions
            // 
            pnlUtilityAccountActions.Controls.Add(btnSaveUtilityAccount);
            pnlUtilityAccountActions.Controls.Add(btnCancelEditUtilityAccount);
            pnlUtilityAccountActions.Dock = DockStyle.Bottom;
            pnlUtilityAccountActions.Location = new Point(0, 328);
            pnlUtilityAccountActions.Name = "pnlUtilityAccountActions";
            pnlUtilityAccountActions.Size = new Size(482, 75);
            pnlUtilityAccountActions.TabIndex = 4;
            // 
            // btnSaveUtilityAccount
            // 
            btnSaveUtilityAccount.Cursor = Cursors.Hand;
            btnSaveUtilityAccount.Location = new Point(360, 30);
            btnSaveUtilityAccount.Name = "btnSaveUtilityAccount";
            btnSaveUtilityAccount.Size = new Size(94, 29);
            btnSaveUtilityAccount.TabIndex = 1;
            btnSaveUtilityAccount.Text = "Save";
            btnSaveUtilityAccount.UseVisualStyleBackColor = true;
            // 
            // btnCancelEditUtilityAccount
            // 
            btnCancelEditUtilityAccount.Cursor = Cursors.Hand;
            btnCancelEditUtilityAccount.Location = new Point(231, 30);
            btnCancelEditUtilityAccount.Name = "btnCancelEditUtilityAccount";
            btnCancelEditUtilityAccount.Size = new Size(94, 29);
            btnCancelEditUtilityAccount.TabIndex = 0;
            btnCancelEditUtilityAccount.Text = "Cancel";
            btnCancelEditUtilityAccount.UseVisualStyleBackColor = true;
            // 
            // pnlUtilityAccountHeader
            // 
            pnlUtilityAccountHeader.Controls.Add(lblUtilityAccountTitle);
            pnlUtilityAccountHeader.Dock = DockStyle.Top;
            pnlUtilityAccountHeader.Location = new Point(0, 0);
            pnlUtilityAccountHeader.Name = "pnlUtilityAccountHeader";
            pnlUtilityAccountHeader.Size = new Size(482, 75);
            pnlUtilityAccountHeader.TabIndex = 3;
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
            lblUtilityAccountTitle.Text = "Edit Water/Electricity Bill Account";
            lblUtilityAccountTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditUtilityAccountForm
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
            Name = "EditUtilityAccountForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Utility Account";
            pnlUtilityAccountContent.ResumeLayout(false);
            pnlAccountNumber.ResumeLayout(false);
            pnlAccountNumber.PerformLayout();
            pnlIncludeTo.ResumeLayout(false);
            pnlRoom.ResumeLayout(false);
            pnlUtilityAccountActions.ResumeLayout(false);
            pnlUtilityAccountHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlUtilityAccountContent;
        private Panel pnlAccountNumber;
        private TextBox txtAccountNumber;
        private Label lblAccountNumber;
        private Panel pnlIncludeTo;
        private ComboBox cboIncludeTo;
        private Label lblIncludeTo;
        private Panel pnlRoom;
        private ComboBox cboRoom;
        private Label lblRoom;
        private Panel pnlUtilityAccountActions;
        private Button btnSaveUtilityAccount;
        private Button btnCancelEditUtilityAccount;
        private Panel pnlUtilityAccountHeader;
        private Label lblUtilityAccountTitle;
    }
}