namespace Capstoneszn.Forms.BuildingForms
{
    partial class BuildingSelection
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
            pnlSamplesAddBuilding = new Panel();
            lblPlusSampleBuilding = new Label();
            lblSampleBuilding = new Label();
            flpBuildings = new FlowLayoutPanel();
            pnlAddBuilding = new Panel();
            lblPlusBuilding = new Label();
            lblAddBuilding = new Label();
            pnlBuildingHeader = new Panel();
            lblTitle = new Label();
            pnlSamplesAddBuilding.SuspendLayout();
            flpBuildings.SuspendLayout();
            pnlAddBuilding.SuspendLayout();
            pnlBuildingHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSamplesAddBuilding
            // 
            pnlSamplesAddBuilding.BackColor = Color.LightSlateGray;
            pnlSamplesAddBuilding.BorderStyle = BorderStyle.FixedSingle;
            pnlSamplesAddBuilding.Controls.Add(lblPlusSampleBuilding);
            pnlSamplesAddBuilding.Controls.Add(lblSampleBuilding);
            pnlSamplesAddBuilding.Cursor = Cursors.Hand;
            pnlSamplesAddBuilding.Location = new Point(13, 13);
            pnlSamplesAddBuilding.Name = "pnlSamplesAddBuilding";
            pnlSamplesAddBuilding.Size = new Size(250, 200);
            pnlSamplesAddBuilding.TabIndex = 1;
            // 
            // lblPlusSampleBuilding
            // 
            lblPlusSampleBuilding.Dock = DockStyle.Fill;
            lblPlusSampleBuilding.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlusSampleBuilding.ForeColor = Color.White;
            lblPlusSampleBuilding.Location = new Point(0, 0);
            lblPlusSampleBuilding.Name = "lblPlusSampleBuilding";
            lblPlusSampleBuilding.Size = new Size(248, 162);
            lblPlusSampleBuilding.TabIndex = 2;
            lblPlusSampleBuilding.Text = "+";
            lblPlusSampleBuilding.TextAlign = ContentAlignment.MiddleCenter;
            lblPlusSampleBuilding.Click += lblPlusSampleBuilding_Click;
            // 
            // lblSampleBuilding
            // 
            lblSampleBuilding.Dock = DockStyle.Bottom;
            lblSampleBuilding.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSampleBuilding.ForeColor = Color.White;
            lblSampleBuilding.Location = new Point(0, 162);
            lblSampleBuilding.Name = "lblSampleBuilding";
            lblSampleBuilding.Size = new Size(248, 36);
            lblSampleBuilding.TabIndex = 1;
            lblSampleBuilding.Text = "Sample Building";
            lblSampleBuilding.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpBuildings
            // 
            flpBuildings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpBuildings.AutoScroll = true;
            flpBuildings.BackColor = Color.Transparent;
            flpBuildings.BorderStyle = BorderStyle.FixedSingle;
            flpBuildings.Controls.Add(pnlSamplesAddBuilding);
            flpBuildings.Controls.Add(pnlAddBuilding);
            flpBuildings.Location = new Point(39, 91);
            flpBuildings.Name = "flpBuildings";
            flpBuildings.Padding = new Padding(10);
            flpBuildings.Size = new Size(1305, 556);
            flpBuildings.TabIndex = 4;
            flpBuildings.Paint += flpBuildings_Paint;
            // 
            // pnlAddBuilding
            // 
            pnlAddBuilding.BackColor = Color.LightSlateGray;
            pnlAddBuilding.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBuilding.Controls.Add(lblPlusBuilding);
            pnlAddBuilding.Controls.Add(lblAddBuilding);
            pnlAddBuilding.Cursor = Cursors.Hand;
            pnlAddBuilding.Location = new Point(269, 13);
            pnlAddBuilding.Name = "pnlAddBuilding";
            pnlAddBuilding.Size = new Size(250, 200);
            pnlAddBuilding.TabIndex = 2;
            // 
            // lblPlusBuilding
            // 
            lblPlusBuilding.Dock = DockStyle.Fill;
            lblPlusBuilding.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlusBuilding.ForeColor = Color.White;
            lblPlusBuilding.Location = new Point(0, 0);
            lblPlusBuilding.Name = "lblPlusBuilding";
            lblPlusBuilding.Size = new Size(248, 162);
            lblPlusBuilding.TabIndex = 2;
            lblPlusBuilding.Text = "+";
            lblPlusBuilding.TextAlign = ContentAlignment.MiddleCenter;
            lblPlusBuilding.Click += lblPlusBuilding_Click;
            // 
            // lblAddBuilding
            // 
            lblAddBuilding.Dock = DockStyle.Bottom;
            lblAddBuilding.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddBuilding.ForeColor = Color.White;
            lblAddBuilding.Location = new Point(0, 162);
            lblAddBuilding.Name = "lblAddBuilding";
            lblAddBuilding.Size = new Size(248, 36);
            lblAddBuilding.TabIndex = 1;
            lblAddBuilding.Text = "Add Building";
            lblAddBuilding.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBuildingHeader
            // 
            pnlBuildingHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlBuildingHeader.Controls.Add(lblTitle);
            pnlBuildingHeader.Dock = DockStyle.Top;
            pnlBuildingHeader.Location = new Point(0, 0);
            pnlBuildingHeader.Name = "pnlBuildingHeader";
            pnlBuildingHeader.Size = new Size(1382, 65);
            pnlBuildingHeader.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1380, 63);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Select a Building";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BuildingSelection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(1382, 698);
            Controls.Add(pnlBuildingHeader);
            Controls.Add(flpBuildings);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BuildingSelection";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Building";
            Load += BuildingSelection_Load;
            pnlSamplesAddBuilding.ResumeLayout(false);
            flpBuildings.ResumeLayout(false);
            pnlAddBuilding.ResumeLayout(false);
            pnlBuildingHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlSamplesAddBuilding;
        private Label lblPlusSampleBuilding;
        private Label lblSampleBuilding;
        private FlowLayoutPanel flpBuildings;
        private Panel pnlAddBuilding;
        private Label lblPlusBuilding;
        private Label lblAddBuilding;
        private Panel pnlBuildingHeader;
        private Label lblTitle;
    }
}