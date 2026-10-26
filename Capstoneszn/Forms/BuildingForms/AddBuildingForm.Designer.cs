namespace Capstoneszn
{
    partial class AddBuildingForm
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
            txtBuildingName = new TextBox();
            lblBuildingName = new Label();
            nudFloors = new NumericUpDown();
            btnCancel = new Button();
            btnNext = new Button();
            lblEnterFloors = new Label();
            pnlAddBuildingHeader = new Panel();
            lblTitle = new Label();
            pnlAddBuildingActionsButtons = new Panel();
            pnlAddBuildingContent = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label7 = new Label();
            txtElecAccountName = new TextBox();
            txtElecAccountNumber = new TextBox();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label4 = new Label();
            txtWaterAccountNumber = new TextBox();
            txtWaterAccountName = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label3 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudFloors).BeginInit();
            pnlAddBuildingHeader.SuspendLayout();
            pnlAddBuildingActionsButtons.SuspendLayout();
            pnlAddBuildingContent.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtBuildingName
            // 
            txtBuildingName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuildingName.Location = new Point(101, 58);
            txtBuildingName.Name = "txtBuildingName";
            txtBuildingName.PlaceholderText = "Enter Building Name";
            txtBuildingName.Size = new Size(400, 34);
            txtBuildingName.TabIndex = 1;
            txtBuildingName.TextAlign = HorizontalAlignment.Center;
            // 
            // lblBuildingName
            // 
            lblBuildingName.AutoSize = true;
            lblBuildingName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuildingName.ForeColor = Color.White;
            lblBuildingName.Location = new Point(101, 24);
            lblBuildingName.Name = "lblBuildingName";
            lblBuildingName.Size = new Size(166, 31);
            lblBuildingName.TabIndex = 2;
            lblBuildingName.Text = "Building Name";
            // 
            // nudFloors
            // 
            nudFloors.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudFloors.Location = new Point(241, 112);
            nudFloors.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudFloors.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFloors.Name = "nudFloors";
            nudFloors.Size = new Size(260, 34);
            nudFloors.TabIndex = 2;
            nudFloors.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(350, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 42);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnNext
            // 
            btnNext.Cursor = Cursors.Hand;
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(463, 8);
            btnNext.Margin = new Padding(5, 3, 3, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(106, 42);
            btnNext.TabIndex = 8;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblEnterFloors
            // 
            lblEnterFloors.AutoSize = true;
            lblEnterFloors.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnterFloors.ForeColor = Color.White;
            lblEnterFloors.Location = new Point(101, 115);
            lblEnterFloors.Name = "lblEnterFloors";
            lblEnterFloors.Size = new Size(134, 31);
            lblEnterFloors.TabIndex = 7;
            lblEnterFloors.Text = "Enter Floors";
            // 
            // pnlAddBuildingHeader
            // 
            pnlAddBuildingHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBuildingHeader.Controls.Add(lblTitle);
            pnlAddBuildingHeader.Dock = DockStyle.Top;
            pnlAddBuildingHeader.Location = new Point(0, 0);
            pnlAddBuildingHeader.Name = "pnlAddBuildingHeader";
            pnlAddBuildingHeader.Size = new Size(582, 70);
            pnlAddBuildingHeader.TabIndex = 8;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(580, 68);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Create Building";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAddBuildingActionsButtons
            // 
            pnlAddBuildingActionsButtons.Controls.Add(btnCancel);
            pnlAddBuildingActionsButtons.Controls.Add(btnNext);
            pnlAddBuildingActionsButtons.Dock = DockStyle.Bottom;
            pnlAddBuildingActionsButtons.Location = new Point(0, 608);
            pnlAddBuildingActionsButtons.Name = "pnlAddBuildingActionsButtons";
            pnlAddBuildingActionsButtons.Padding = new Padding(8);
            pnlAddBuildingActionsButtons.Size = new Size(582, 64);
            pnlAddBuildingActionsButtons.TabIndex = 9;
            // 
            // pnlAddBuildingContent
            // 
            pnlAddBuildingContent.Controls.Add(tableLayoutPanel2);
            pnlAddBuildingContent.Controls.Add(tableLayoutPanel1);
            pnlAddBuildingContent.Controls.Add(label6);
            pnlAddBuildingContent.Controls.Add(label3);
            pnlAddBuildingContent.Controls.Add(label1);
            pnlAddBuildingContent.Controls.Add(lblBuildingName);
            pnlAddBuildingContent.Controls.Add(nudFloors);
            pnlAddBuildingContent.Controls.Add(lblEnterFloors);
            pnlAddBuildingContent.Controls.Add(txtBuildingName);
            pnlAddBuildingContent.Dock = DockStyle.Fill;
            pnlAddBuildingContent.Location = new Point(0, 70);
            pnlAddBuildingContent.Name = "pnlAddBuildingContent";
            pnlAddBuildingContent.Size = new Size(582, 538);
            pnlAddBuildingContent.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label7, 0, 0);
            tableLayoutPanel2.Controls.Add(txtElecAccountName, 1, 0);
            tableLayoutPanel2.Controls.Add(txtElecAccountNumber, 1, 1);
            tableLayoutPanel2.Controls.Add(label2, 0, 1);
            tableLayoutPanel2.Location = new Point(28, 393);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(530, 84);
            tableLayoutPanel2.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(259, 42);
            label7.TabIndex = 2;
            label7.Text = "Electricity account name:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtElecAccountName
            // 
            txtElecAccountName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtElecAccountName.Location = new Point(268, 3);
            txtElecAccountName.Name = "txtElecAccountName";
            txtElecAccountName.Size = new Size(259, 34);
            txtElecAccountName.TabIndex = 5;
            txtElecAccountName.TextAlign = HorizontalAlignment.Center;
            // 
            // txtElecAccountNumber
            // 
            txtElecAccountNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtElecAccountNumber.Location = new Point(268, 45);
            txtElecAccountNumber.Name = "txtElecAccountNumber";
            txtElecAccountNumber.Size = new Size(259, 34);
            txtElecAccountNumber.TabIndex = 6;
            txtElecAccountNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 42);
            label2.Name = "label2";
            label2.Size = new Size(259, 42);
            label2.TabIndex = 2;
            label2.Text = "Electricity account number:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label4, 0, 0);
            tableLayoutPanel1.Controls.Add(txtWaterAccountNumber, 1, 1);
            tableLayoutPanel1.Controls.Add(txtWaterAccountName, 1, 0);
            tableLayoutPanel1.Controls.Add(label5, 0, 1);
            tableLayoutPanel1.Location = new Point(28, 242);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(530, 84);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(259, 42);
            label4.TabIndex = 2;
            label4.Text = "Water account name:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtWaterAccountNumber
            // 
            txtWaterAccountNumber.Dock = DockStyle.Fill;
            txtWaterAccountNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWaterAccountNumber.Location = new Point(268, 45);
            txtWaterAccountNumber.Name = "txtWaterAccountNumber";
            txtWaterAccountNumber.Size = new Size(259, 34);
            txtWaterAccountNumber.TabIndex = 4;
            txtWaterAccountNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // txtWaterAccountName
            // 
            txtWaterAccountName.Dock = DockStyle.Fill;
            txtWaterAccountName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWaterAccountName.Location = new Point(268, 3);
            txtWaterAccountName.Name = "txtWaterAccountName";
            txtWaterAccountName.Size = new Size(259, 34);
            txtWaterAccountName.TabIndex = 3;
            txtWaterAccountName.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 42);
            label5.Name = "label5";
            label5.Size = new Size(259, 42);
            label5.TabIndex = 2;
            label5.Text = "Water account number:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(28, 362);
            label6.Name = "label6";
            label6.Size = new Size(107, 28);
            label6.TabIndex = 2;
            label6.Text = "Electricity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(28, 211);
            label3.Name = "label3";
            label3.Size = new Size(69, 28);
            label3.TabIndex = 2;
            label3.Text = "Water";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(189, 176);
            label1.Name = "label1";
            label1.Size = new Size(204, 31);
            label1.TabIndex = 2;
            label1.Text = "Utilities Accounts";
            // 
            // AddBuildingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(582, 672);
            Controls.Add(pnlAddBuildingContent);
            Controls.Add(pnlAddBuildingActionsButtons);
            Controls.Add(pnlAddBuildingHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBuildingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Building";
            Load += AddBuildingForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudFloors).EndInit();
            pnlAddBuildingHeader.ResumeLayout(false);
            pnlAddBuildingActionsButtons.ResumeLayout(false);
            pnlAddBuildingContent.ResumeLayout(false);
            pnlAddBuildingContent.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtBuildingName;
        private Label lblBuildingName;
        private NumericUpDown nudFloors;
        private Button btnCancel;
        private Button btnNext;
        private Label lblEnterFloors;
        private Panel pnlAddBuildingHeader;
        private Label lblTitle;
        private Panel pnlAddBuildingActionsButtons;
        private Panel pnlAddBuildingContent;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private TextBox txtWaterAccountNumber;
        private TextBox txtWaterAccountName;
        private Label label5;
        private TextBox txtElecAccountNumber;
        private Label label3;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label7;
        private TextBox txtElecAccountName;
        private Label label6;
    }
}