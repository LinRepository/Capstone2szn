namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class ElectricWaterAccountControl
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
            pnlElectricWaterAccountHeader = new Panel();
            pnlTitle = new Panel();
            lblTitle = new Label();
            pnlBackbtn = new Panel();
            btnBackElectricWater = new Button();
            pnlElectricWaterAccountContent = new Panel();
            pnlWater = new Panel();
            pnlWaterContent = new Panel();
            pnlWaterFooter = new Panel();
            btnEditWaterAccount = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            lblWaterAccountName = new Label();
            lblWaterValueName = new Label();
            lblWaterValueNumber = new Label();
            pnlElectricityHeader = new Panel();
            lblWaterAccount = new Label();
            pnlElec = new Panel();
            pnlElecContent = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblElecAccountName = new Label();
            lblElecAccountNumber = new Label();
            lblElecValueNumber = new Label();
            lblElecValueName = new Label();
            pnlElecFooter = new Panel();
            btnEditElectAccount = new Button();
            pnlWaterHeader = new Panel();
            lblElectricAccount = new Label();
            pnlUtilitiesAccounts = new Panel();
            pnlElectricWaterAccountHeader.SuspendLayout();
            pnlTitle.SuspendLayout();
            pnlBackbtn.SuspendLayout();
            pnlElectricWaterAccountContent.SuspendLayout();
            pnlWater.SuspendLayout();
            pnlWaterContent.SuspendLayout();
            pnlWaterFooter.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pnlElectricityHeader.SuspendLayout();
            pnlElec.SuspendLayout();
            pnlElecContent.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlElecFooter.SuspendLayout();
            pnlWaterHeader.SuspendLayout();
            pnlUtilitiesAccounts.SuspendLayout();
            SuspendLayout();
            // 
            // pnlElectricWaterAccountHeader
            // 
            pnlElectricWaterAccountHeader.Controls.Add(pnlTitle);
            pnlElectricWaterAccountHeader.Controls.Add(pnlBackbtn);
            pnlElectricWaterAccountHeader.Dock = DockStyle.Top;
            pnlElectricWaterAccountHeader.Location = new Point(0, 0);
            pnlElectricWaterAccountHeader.Name = "pnlElectricWaterAccountHeader";
            pnlElectricWaterAccountHeader.Size = new Size(1571, 94);
            pnlElectricWaterAccountHeader.TabIndex = 0;
            // 
            // pnlTitle
            // 
            pnlTitle.Controls.Add(lblTitle);
            pnlTitle.Dock = DockStyle.Fill;
            pnlTitle.Location = new Point(144, 0);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(1427, 94);
            pnlTitle.TabIndex = 14;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(519, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(278, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Utilities Accounts";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBackbtn
            // 
            pnlBackbtn.Controls.Add(btnBackElectricWater);
            pnlBackbtn.Dock = DockStyle.Left;
            pnlBackbtn.Location = new Point(0, 0);
            pnlBackbtn.Name = "pnlBackbtn";
            pnlBackbtn.Padding = new Padding(0, 10, 10, 10);
            pnlBackbtn.Size = new Size(144, 94);
            pnlBackbtn.TabIndex = 12;
            // 
            // btnBackElectricWater
            // 
            btnBackElectricWater.Cursor = Cursors.Hand;
            btnBackElectricWater.Dock = DockStyle.Fill;
            btnBackElectricWater.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackElectricWater.Location = new Point(0, 10);
            btnBackElectricWater.Margin = new Padding(0);
            btnBackElectricWater.Name = "btnBackElectricWater";
            btnBackElectricWater.Size = new Size(134, 74);
            btnBackElectricWater.TabIndex = 10;
            btnBackElectricWater.Text = "←";
            btnBackElectricWater.UseVisualStyleBackColor = true;
            btnBackElectricWater.Click += btnBackElectricWater_Click;
            // 
            // pnlElectricWaterAccountContent
            // 
            pnlElectricWaterAccountContent.Controls.Add(pnlWater);
            pnlElectricWaterAccountContent.Controls.Add(pnlElec);
            pnlElectricWaterAccountContent.Dock = DockStyle.Fill;
            pnlElectricWaterAccountContent.Location = new Point(0, 94);
            pnlElectricWaterAccountContent.Name = "pnlElectricWaterAccountContent";
            pnlElectricWaterAccountContent.Size = new Size(1571, 732);
            pnlElectricWaterAccountContent.TabIndex = 1;
            // 
            // pnlWater
            // 
            pnlWater.BackColor = Color.FromArgb(25, 25, 80);
            pnlWater.Controls.Add(pnlWaterContent);
            pnlWater.Controls.Add(pnlElectricityHeader);
            pnlWater.Dock = DockStyle.Fill;
            pnlWater.Location = new Point(787, 0);
            pnlWater.Name = "pnlWater";
            pnlWater.Padding = new Padding(5);
            pnlWater.Size = new Size(784, 732);
            pnlWater.TabIndex = 4;
            // 
            // pnlWaterContent
            // 
            pnlWaterContent.BorderStyle = BorderStyle.FixedSingle;
            pnlWaterContent.Controls.Add(pnlWaterFooter);
            pnlWaterContent.Controls.Add(tableLayoutPanel2);
            pnlWaterContent.Dock = DockStyle.Fill;
            pnlWaterContent.Location = new Point(5, 79);
            pnlWaterContent.Name = "pnlWaterContent";
            pnlWaterContent.Size = new Size(774, 648);
            pnlWaterContent.TabIndex = 1;
            // 
            // pnlWaterFooter
            // 
            pnlWaterFooter.Controls.Add(btnEditWaterAccount);
            pnlWaterFooter.Dock = DockStyle.Bottom;
            pnlWaterFooter.Location = new Point(0, 572);
            pnlWaterFooter.Name = "pnlWaterFooter";
            pnlWaterFooter.Padding = new Padding(10);
            pnlWaterFooter.Size = new Size(772, 74);
            pnlWaterFooter.TabIndex = 3;
            // 
            // btnEditWaterAccount
            // 
            btnEditWaterAccount.Dock = DockStyle.Left;
            btnEditWaterAccount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditWaterAccount.Location = new Point(10, 10);
            btnEditWaterAccount.Name = "btnEditWaterAccount";
            btnEditWaterAccount.Size = new Size(120, 54);
            btnEditWaterAccount.TabIndex = 1;
            btnEditWaterAccount.Text = "Edit";
            btnEditWaterAccount.UseVisualStyleBackColor = true;
            btnEditWaterAccount.Click += btnEditWaterAccount_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.7799F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.2201042F));
            tableLayoutPanel2.Controls.Add(label1, 0, 1);
            tableLayoutPanel2.Controls.Add(lblWaterAccountName, 0, 0);
            tableLayoutPanel2.Controls.Add(lblWaterValueName, 1, 0);
            tableLayoutPanel2.Controls.Add(lblWaterValueNumber, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(5);
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
            tableLayoutPanel2.Size = new Size(772, 165);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(8, 82);
            label1.Name = "label1";
            label1.Size = new Size(229, 78);
            label1.TabIndex = 0;
            label1.Text = "Account number:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWaterAccountName
            // 
            lblWaterAccountName.AutoSize = true;
            lblWaterAccountName.Dock = DockStyle.Left;
            lblWaterAccountName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWaterAccountName.ForeColor = Color.White;
            lblWaterAccountName.Location = new Point(8, 10);
            lblWaterAccountName.Margin = new Padding(3, 5, 3, 5);
            lblWaterAccountName.Name = "lblWaterAccountName";
            lblWaterAccountName.Padding = new Padding(5);
            lblWaterAccountName.Size = new Size(211, 67);
            lblWaterAccountName.TabIndex = 0;
            lblWaterAccountName.Text = "Account name:";
            lblWaterAccountName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWaterValueName
            // 
            lblWaterValueName.AutoSize = true;
            lblWaterValueName.Dock = DockStyle.Right;
            lblWaterValueName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWaterValueName.ForeColor = Color.White;
            lblWaterValueName.Location = new Point(611, 10);
            lblWaterValueName.Margin = new Padding(3, 5, 3, 5);
            lblWaterValueName.Name = "lblWaterValueName";
            lblWaterValueName.Size = new Size(153, 67);
            lblWaterValueName.TabIndex = 0;
            lblWaterValueName.Text = "Not set yet";
            lblWaterValueName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWaterValueNumber
            // 
            lblWaterValueNumber.AutoSize = true;
            lblWaterValueNumber.Dock = DockStyle.Right;
            lblWaterValueNumber.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWaterValueNumber.ForeColor = Color.White;
            lblWaterValueNumber.Location = new Point(611, 87);
            lblWaterValueNumber.Margin = new Padding(3, 5, 3, 5);
            lblWaterValueNumber.Name = "lblWaterValueNumber";
            lblWaterValueNumber.Size = new Size(153, 68);
            lblWaterValueNumber.TabIndex = 0;
            lblWaterValueNumber.Text = "Not set yet";
            lblWaterValueNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlElectricityHeader
            // 
            pnlElectricityHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlElectricityHeader.Controls.Add(lblWaterAccount);
            pnlElectricityHeader.Dock = DockStyle.Top;
            pnlElectricityHeader.Location = new Point(5, 5);
            pnlElectricityHeader.Name = "pnlElectricityHeader";
            pnlElectricityHeader.Size = new Size(774, 74);
            pnlElectricityHeader.TabIndex = 0;
            // 
            // lblWaterAccount
            // 
            lblWaterAccount.AutoSize = true;
            lblWaterAccount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWaterAccount.ForeColor = Color.White;
            lblWaterAccount.Location = new Point(259, 12);
            lblWaterAccount.Name = "lblWaterAccount";
            lblWaterAccount.Size = new Size(243, 46);
            lblWaterAccount.TabIndex = 0;
            lblWaterAccount.Text = "Water Account";
            lblWaterAccount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlElec
            // 
            pnlElec.BackColor = Color.FromArgb(25, 25, 80);
            pnlElec.Controls.Add(pnlElecContent);
            pnlElec.Controls.Add(pnlWaterHeader);
            pnlElec.Dock = DockStyle.Left;
            pnlElec.Location = new Point(0, 0);
            pnlElec.Name = "pnlElec";
            pnlElec.Padding = new Padding(5);
            pnlElec.Size = new Size(787, 732);
            pnlElec.TabIndex = 5;
            // 
            // pnlElecContent
            // 
            pnlElecContent.BorderStyle = BorderStyle.FixedSingle;
            pnlElecContent.Controls.Add(tableLayoutPanel1);
            pnlElecContent.Controls.Add(pnlElecFooter);
            pnlElecContent.Dock = DockStyle.Fill;
            pnlElecContent.Location = new Point(5, 79);
            pnlElecContent.Name = "pnlElecContent";
            pnlElecContent.Size = new Size(777, 648);
            pnlElecContent.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblElecAccountName, 0, 0);
            tableLayoutPanel1.Controls.Add(lblElecAccountNumber, 0, 1);
            tableLayoutPanel1.Controls.Add(lblElecValueNumber, 1, 1);
            tableLayoutPanel1.Controls.Add(lblElecValueName, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(5);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(775, 165);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // lblElecAccountName
            // 
            lblElecAccountName.AutoSize = true;
            lblElecAccountName.Dock = DockStyle.Left;
            lblElecAccountName.Font = new Font("Segoe UI", 16.2F);
            lblElecAccountName.ForeColor = Color.White;
            lblElecAccountName.Location = new Point(8, 10);
            lblElecAccountName.Margin = new Padding(3, 5, 3, 5);
            lblElecAccountName.Name = "lblElecAccountName";
            lblElecAccountName.Size = new Size(201, 67);
            lblElecAccountName.TabIndex = 0;
            lblElecAccountName.Text = "Account name:";
            lblElecAccountName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblElecAccountNumber
            // 
            lblElecAccountNumber.AutoSize = true;
            lblElecAccountNumber.Dock = DockStyle.Left;
            lblElecAccountNumber.Font = new Font("Segoe UI", 16.2F);
            lblElecAccountNumber.ForeColor = Color.White;
            lblElecAccountNumber.Location = new Point(8, 87);
            lblElecAccountNumber.Margin = new Padding(3, 5, 3, 5);
            lblElecAccountNumber.Name = "lblElecAccountNumber";
            lblElecAccountNumber.Size = new Size(229, 68);
            lblElecAccountNumber.TabIndex = 0;
            lblElecAccountNumber.Text = "Account number:";
            lblElecAccountNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblElecValueNumber
            // 
            lblElecValueNumber.AutoSize = true;
            lblElecValueNumber.Dock = DockStyle.Right;
            lblElecValueNumber.Font = new Font("Segoe UI", 16.2F);
            lblElecValueNumber.ForeColor = Color.White;
            lblElecValueNumber.Location = new Point(614, 87);
            lblElecValueNumber.Margin = new Padding(3, 5, 3, 5);
            lblElecValueNumber.Name = "lblElecValueNumber";
            lblElecValueNumber.Size = new Size(153, 68);
            lblElecValueNumber.TabIndex = 0;
            lblElecValueNumber.Text = "Not set yet";
            lblElecValueNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblElecValueName
            // 
            lblElecValueName.AutoSize = true;
            lblElecValueName.Dock = DockStyle.Right;
            lblElecValueName.Font = new Font("Segoe UI", 16.2F);
            lblElecValueName.ForeColor = Color.White;
            lblElecValueName.Location = new Point(614, 10);
            lblElecValueName.Margin = new Padding(3, 5, 3, 5);
            lblElecValueName.Name = "lblElecValueName";
            lblElecValueName.Size = new Size(153, 67);
            lblElecValueName.TabIndex = 0;
            lblElecValueName.Text = "Not set yet";
            lblElecValueName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlElecFooter
            // 
            pnlElecFooter.Controls.Add(btnEditElectAccount);
            pnlElecFooter.Dock = DockStyle.Bottom;
            pnlElecFooter.Location = new Point(0, 572);
            pnlElecFooter.Name = "pnlElecFooter";
            pnlElecFooter.Padding = new Padding(10);
            pnlElecFooter.Size = new Size(775, 74);
            pnlElecFooter.TabIndex = 2;
            // 
            // btnEditElectAccount
            // 
            btnEditElectAccount.Dock = DockStyle.Left;
            btnEditElectAccount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditElectAccount.Location = new Point(10, 10);
            btnEditElectAccount.Name = "btnEditElectAccount";
            btnEditElectAccount.Size = new Size(120, 54);
            btnEditElectAccount.TabIndex = 1;
            btnEditElectAccount.Text = "Edit";
            btnEditElectAccount.UseVisualStyleBackColor = true;
            btnEditElectAccount.Click += btnEditElectAccount_Click;
            // 
            // pnlWaterHeader
            // 
            pnlWaterHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlWaterHeader.Controls.Add(lblElectricAccount);
            pnlWaterHeader.Dock = DockStyle.Top;
            pnlWaterHeader.Location = new Point(5, 5);
            pnlWaterHeader.Name = "pnlWaterHeader";
            pnlWaterHeader.Size = new Size(777, 74);
            pnlWaterHeader.TabIndex = 0;
            // 
            // lblElectricAccount
            // 
            lblElectricAccount.AutoSize = true;
            lblElectricAccount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblElectricAccount.ForeColor = Color.White;
            lblElectricAccount.Location = new Point(222, 12);
            lblElectricAccount.Name = "lblElectricAccount";
            lblElectricAccount.Size = new Size(296, 46);
            lblElectricAccount.TabIndex = 0;
            lblElectricAccount.Text = "Electricity Account";
            lblElectricAccount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlUtilitiesAccounts
            // 
            pnlUtilitiesAccounts.Controls.Add(pnlElectricWaterAccountContent);
            pnlUtilitiesAccounts.Controls.Add(pnlElectricWaterAccountHeader);
            pnlUtilitiesAccounts.Dock = DockStyle.Fill;
            pnlUtilitiesAccounts.Location = new Point(0, 0);
            pnlUtilitiesAccounts.Name = "pnlUtilitiesAccounts";
            pnlUtilitiesAccounts.Size = new Size(1571, 826);
            pnlUtilitiesAccounts.TabIndex = 1;
            // 
            // ElectricWaterAccountControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            Controls.Add(pnlUtilitiesAccounts);
            Name = "ElectricWaterAccountControl";
            Size = new Size(1571, 826);
            pnlElectricWaterAccountHeader.ResumeLayout(false);
            pnlTitle.ResumeLayout(false);
            pnlTitle.PerformLayout();
            pnlBackbtn.ResumeLayout(false);
            pnlElectricWaterAccountContent.ResumeLayout(false);
            pnlWater.ResumeLayout(false);
            pnlWaterContent.ResumeLayout(false);
            pnlWaterFooter.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            pnlElectricityHeader.ResumeLayout(false);
            pnlElectricityHeader.PerformLayout();
            pnlElec.ResumeLayout(false);
            pnlElecContent.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlElecFooter.ResumeLayout(false);
            pnlWaterHeader.ResumeLayout(false);
            pnlWaterHeader.PerformLayout();
            pnlUtilitiesAccounts.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlElectricWaterAccountHeader;
        private Panel pnlElectricWaterAccountContent;
        private Button btnBackElectricWater;
        private Panel pnlBackbtn;
        private Panel pnlTitle;
        private Label lblTitle;
        private Panel pnlUtilitiesAccounts;
        private Panel pnlWater;
        private Panel pnlWaterContent;
        private Label lblWaterValueName;
        private Label lblWaterAccountName;
        private Panel pnlElectricityHeader;
        private Label lblWaterAccount;
        private Panel pnlElec;
        private Panel pnlElecContent;
        private Label lblElecValueName;
        private Label lblElecAccountName;
        private Label lblElecValueNumber;
        private Label lblElecAccountNumber;
        private Panel pnlWaterHeader;
        private Label lblElectricAccount;
        private Button btnEditWaterAccount;
        private Button btnEditElectAccount;
        private Panel pnlElecFooter;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel pnlWaterFooter;
        private Label label1;
        private Label lblWaterValueNumber;
    }
}
