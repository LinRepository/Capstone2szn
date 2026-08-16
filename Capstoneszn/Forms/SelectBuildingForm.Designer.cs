namespace Capstoneszn
{
    partial class SelectBuildingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlAddBuilding = new Panel();
            lblPlus = new Label();
            lblAddBuilding = new Label();
            flpBuildings = new FlowLayoutPanel();
            pnlAddBuilding.SuspendLayout();
            flpBuildings.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTitle.Location = new Point(670, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(236, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Select a Building";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAddBuilding
            // 
            pnlAddBuilding.BackColor = Color.LightSlateGray;
            pnlAddBuilding.BorderStyle = BorderStyle.FixedSingle;
            pnlAddBuilding.Controls.Add(lblPlus);
            pnlAddBuilding.Controls.Add(lblAddBuilding);
            pnlAddBuilding.Cursor = Cursors.Hand;
            pnlAddBuilding.Location = new Point(3, 3);
            pnlAddBuilding.Name = "pnlAddBuilding";
            pnlAddBuilding.Size = new Size(250, 200);
            pnlAddBuilding.TabIndex = 1;
            pnlAddBuilding.Paint += PanelAddBuilding_Paint;
            // 
            // lblPlus
            // 
            lblPlus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPlus.AutoSize = true;
            lblPlus.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlus.ForeColor = Color.White;
            lblPlus.Location = new Point(56, -1);
            lblPlus.Name = "lblPlus";
            lblPlus.Size = new Size(149, 159);
            lblPlus.TabIndex = 2;
            lblPlus.Text = "+";
            lblPlus.TextAlign = ContentAlignment.MiddleCenter;
            lblPlus.Click += lblPlus_Click;
            // 
            // lblAddBuilding
            // 
            lblAddBuilding.AutoSize = true;
            lblAddBuilding.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddBuilding.ForeColor = Color.White;
            lblAddBuilding.Location = new Point(56, 159);
            lblAddBuilding.Name = "lblAddBuilding";
            lblAddBuilding.Size = new Size(126, 28);
            lblAddBuilding.TabIndex = 1;
            lblAddBuilding.Text = "Add Building";
            lblAddBuilding.Click += lblAddBuilding_Click;
            // 
            // flpBuildings
            // 
            flpBuildings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpBuildings.AutoScroll = true;
            flpBuildings.BackColor = Color.Transparent;
            flpBuildings.Controls.Add(pnlAddBuilding);
            flpBuildings.Location = new Point(210, 132);
            flpBuildings.Name = "flpBuildings";
            flpBuildings.Size = new Size(1200, 600);
            flpBuildings.TabIndex = 2;
            flpBuildings.Paint += flpBuildings_Paint;
            // 
            // SelectBuildingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(1582, 853);
            Controls.Add(flpBuildings);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectBuildingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Building";
            Load += SelectBuildingForm_Load;
            pnlAddBuilding.ResumeLayout(false);
            pnlAddBuilding.PerformLayout();
            flpBuildings.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlAddBuilding;
        private Label lblAddBuilding;
        private Label lblPlus;
        private FlowLayoutPanel flpBuildings;
    }
}
