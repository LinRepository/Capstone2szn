namespace Capstoneszn
{
    partial class FloorConfigurationForm
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
            label1 = new Label();
            flpFloors = new FlowLayoutPanel();
            lblDescription = new Label();
            lblBuildingName = new Label();
            btnBack = new Button();
            btnCreate = new Button();
            pnlFloor = new Panel();
            lblFloor = new Label();
            lblRooms = new Label();
            nudRooms = new NumericUpDown();
            flpFloors.SuspendLayout();
            pnlFloor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRooms).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(251, 9);
            label1.Name = "label1";
            label1.Size = new Size(276, 38);
            label1.TabIndex = 0;
            label1.Text = "Configure The Floors";
            // 
            // flpFloors
            // 
            flpFloors.AutoScroll = true;
            flpFloors.BorderStyle = BorderStyle.FixedSingle;
            flpFloors.Controls.Add(pnlFloor);
            flpFloors.FlowDirection = FlowDirection.TopDown;
            flpFloors.Location = new Point(64, 141);
            flpFloors.Name = "flpFloors";
            flpFloors.Size = new Size(650, 450);
            flpFloors.TabIndex = 1;
            flpFloors.WrapContents = false;
            flpFloors.Paint += flpFloors_Paint;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(64, 82);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(354, 23);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Specify how many rooms each floor contains.";
            // 
            // lblBuildingName
            // 
            lblBuildingName.AutoSize = true;
            lblBuildingName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuildingName.ForeColor = Color.White;
            lblBuildingName.Location = new Point(64, 115);
            lblBuildingName.Name = "lblBuildingName";
            lblBuildingName.Size = new Size(123, 23);
            lblBuildingName.TabIndex = 3;
            lblBuildingName.Text = "Building Name";
            lblBuildingName.Click += lblBuildingName_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(278, 609);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(418, 609);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // pnlFloor
            // 
            pnlFloor.BackColor = Color.White;
            pnlFloor.Controls.Add(nudRooms);
            pnlFloor.Controls.Add(lblRooms);
            pnlFloor.Controls.Add(lblFloor);
            pnlFloor.Location = new Point(3, 3);
            pnlFloor.Name = "pnlFloor";
            pnlFloor.Size = new Size(642, 100);
            pnlFloor.TabIndex = 0;
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloor.Location = new Point(14, 11);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(68, 25);
            lblFloor.TabIndex = 0;
            lblFloor.Text = "Floor 1";
            // 
            // lblRooms
            // 
            lblRooms.AutoSize = true;
            lblRooms.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRooms.Location = new Point(14, 52);
            lblRooms.Name = "lblRooms";
            lblRooms.Size = new Size(72, 25);
            lblRooms.TabIndex = 1;
            lblRooms.Text = "Rooms:";
            // 
            // nudRooms
            // 
            nudRooms.Location = new Point(88, 54);
            nudRooms.Name = "nudRooms";
            nudRooms.Size = new Size(85, 27);
            nudRooms.TabIndex = 2;
            // 
            // FloorConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(782, 653);
            Controls.Add(btnCreate);
            Controls.Add(btnBack);
            Controls.Add(lblBuildingName);
            Controls.Add(lblDescription);
            Controls.Add(flpFloors);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FloorConfigurationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FloorConfigurationForm";
            flpFloors.ResumeLayout(false);
            pnlFloor.ResumeLayout(false);
            pnlFloor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRooms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flpFloors;
        private Label lblDescription;
        private Label lblBuildingName;
        private Button btnBack;
        private Button btnCreate;
        private Panel pnlFloor;
        private Label lblFloor;
        private Label lblRooms;
        private NumericUpDown nudRooms;
    }
}