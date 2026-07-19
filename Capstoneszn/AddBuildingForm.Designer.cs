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
            lblTitleBuilding = new Label();
            InputBuilding = new TextBox();
            lblBuildingName = new Label();
            InputFloors = new NumericUpDown();
            btnCancel = new Button();
            btnNext = new Button();
            lblFloors = new Label();
            ((System.ComponentModel.ISupportInitialize)InputFloors).BeginInit();
            SuspendLayout();
            // 
            // lblTitleBuilding
            // 
            lblTitleBuilding.AutoSize = true;
            lblTitleBuilding.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleBuilding.ForeColor = Color.White;
            lblTitleBuilding.Location = new Point(308, 48);
            lblTitleBuilding.Name = "lblTitleBuilding";
            lblTitleBuilding.Size = new Size(272, 50);
            lblTitleBuilding.TabIndex = 0;
            lblTitleBuilding.Text = "Create Building";
            // 
            // InputBuilding
            // 
            InputBuilding.Location = new Point(276, 168);
            InputBuilding.Multiline = true;
            InputBuilding.Name = "InputBuilding";
            InputBuilding.Size = new Size(400, 50);
            InputBuilding.TabIndex = 1;
            InputBuilding.Text = "Enter Building Name";
            InputBuilding.TextAlign = HorizontalAlignment.Center;
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
            // InputFloors
            // 
            InputFloors.Location = new Point(414, 251);
            InputFloors.Name = "InputFloors";
            InputFloors.Size = new Size(100, 27);
            InputFloors.TabIndex = 3;
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
            // lblFloors
            // 
            lblFloors.AutoSize = true;
            lblFloors.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloors.ForeColor = Color.White;
            lblFloors.Location = new Point(274, 247);
            lblFloors.Name = "lblFloors";
            lblFloors.Size = new Size(134, 31);
            lblFloors.TabIndex = 7;
            lblFloors.Text = "Enter Floors";
            // 
            // AddBuildingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(882, 453);
            Controls.Add(lblFloors);
            Controls.Add(btnNext);
            Controls.Add(btnCancel);
            Controls.Add(InputFloors);
            Controls.Add(lblBuildingName);
            Controls.Add(InputBuilding);
            Controls.Add(lblTitleBuilding);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBuildingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddBuildingForm";
            Load += AddBuildingForm_Load;
            ((System.ComponentModel.ISupportInitialize)InputFloors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitleBuilding;
        private TextBox InputBuilding;
        private Label lblBuildingName;
        private NumericUpDown InputFloors;
        private Button btnCancel;
        private Button btnNext;
        private Label lblFloors;
    }
}