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
            ((System.ComponentModel.ISupportInitialize)nudFloors).BeginInit();
            pnlAddBuildingHeader.SuspendLayout();
            pnlAddBuildingActionsButtons.SuspendLayout();
            pnlAddBuildingContent.SuspendLayout();
            SuspendLayout();
            // 
            // txtBuildingName
            // 
            txtBuildingName.Location = new Point(101, 58);
            txtBuildingName.Multiline = true;
            txtBuildingName.Name = "txtBuildingName";
            txtBuildingName.Size = new Size(400, 50);
            txtBuildingName.TabIndex = 1;
            txtBuildingName.Text = "Enter Building Name";
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
            nudFloors.Location = new Point(241, 134);
            nudFloors.Name = "nudFloors";
            nudFloors.Size = new Size(125, 27);
            nudFloors.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Location = new Point(362, 19);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnNext
            // 
            btnNext.Cursor = Cursors.Hand;
            btnNext.Location = new Point(473, 19);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 6;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblEnterFloors
            // 
            lblEnterFloors.AutoSize = true;
            lblEnterFloors.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnterFloors.ForeColor = Color.White;
            lblEnterFloors.Location = new Point(101, 130);
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
            pnlAddBuildingActionsButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBuildingActionsButtons.Controls.Add(btnNext);
            pnlAddBuildingActionsButtons.Controls.Add(btnCancel);
            pnlAddBuildingActionsButtons.Dock = DockStyle.Bottom;
            pnlAddBuildingActionsButtons.Location = new Point(0, 293);
            pnlAddBuildingActionsButtons.Name = "pnlAddBuildingActionsButtons";
            pnlAddBuildingActionsButtons.Size = new Size(582, 60);
            pnlAddBuildingActionsButtons.TabIndex = 9;
            // 
            // pnlAddBuildingContent
            // 
            pnlAddBuildingContent.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBuildingContent.Controls.Add(lblBuildingName);
            pnlAddBuildingContent.Controls.Add(nudFloors);
            pnlAddBuildingContent.Controls.Add(lblEnterFloors);
            pnlAddBuildingContent.Controls.Add(txtBuildingName);
            pnlAddBuildingContent.Dock = DockStyle.Fill;
            pnlAddBuildingContent.Location = new Point(0, 70);
            pnlAddBuildingContent.Name = "pnlAddBuildingContent";
            pnlAddBuildingContent.Size = new Size(582, 223);
            pnlAddBuildingContent.TabIndex = 10;
            // 
            // AddBuildingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(582, 353);
            Controls.Add(pnlAddBuildingContent);
            Controls.Add(pnlAddBuildingActionsButtons);
            Controls.Add(pnlAddBuildingHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBuildingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddBuildingForm";
            Load += AddBuildingForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudFloors).EndInit();
            pnlAddBuildingHeader.ResumeLayout(false);
            pnlAddBuildingActionsButtons.ResumeLayout(false);
            pnlAddBuildingContent.ResumeLayout(false);
            pnlAddBuildingContent.PerformLayout();
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
    }
}