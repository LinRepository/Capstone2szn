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
            lblTitle = new Label();
            txtBuildingName = new TextBox();
            lblBuildingName = new Label();
            nudFloors = new NumericUpDown();
            btnCancel = new Button();
            btnNext = new Button();
            lblEnterFloors = new Label();
            ((System.ComponentModel.ISupportInitialize)nudFloors).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(308, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(272, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Building";
            // 
            // txtBuildingName
            // 
            txtBuildingName.Location = new Point(276, 168);
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
            lblBuildingName.Location = new Point(276, 127);
            lblBuildingName.Name = "lblBuildingName";
            lblBuildingName.Size = new Size(166, 31);
            lblBuildingName.TabIndex = 2;
            lblBuildingName.Text = "Building Name";
            // 
            // nudFloors
            // 
            nudFloors.Location = new Point(414, 251);
            nudFloors.Name = "nudFloors";
            nudFloors.Size = new Size(100, 27);
            nudFloors.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(338, 345);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(486, 345);
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
            lblEnterFloors.Location = new Point(274, 247);
            lblEnterFloors.Name = "lblEnterFloors";
            lblEnterFloors.Size = new Size(134, 31);
            lblEnterFloors.TabIndex = 7;
            lblEnterFloors.Text = "Enter Floors";
            // 
            // AddBuildingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(882, 453);
            Controls.Add(lblEnterFloors);
            Controls.Add(btnNext);
            Controls.Add(btnCancel);
            Controls.Add(nudFloors);
            Controls.Add(lblBuildingName);
            Controls.Add(txtBuildingName);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBuildingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddBuildingForm";
            Load += AddBuildingForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudFloors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtBuildingName;
        private Label lblBuildingName;
        private NumericUpDown nudFloors;
        private Button btnCancel;
        private Button btnNext;
        private Label lblEnterFloors;
    }
}