namespace Capstoneszn.Forms.BuildingForms
{
    partial class BuildingCard
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
            lblBuildingNameCard = new Label();
            lblBuildingContent = new Label();
            SuspendLayout();
            // 
            // lblBuildingNameCard
            // 
            lblBuildingNameCard.Dock = DockStyle.Bottom;
            lblBuildingNameCard.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuildingNameCard.ForeColor = Color.White;
            lblBuildingNameCard.Location = new Point(0, 164);
            lblBuildingNameCard.Name = "lblBuildingNameCard";
            lblBuildingNameCard.Size = new Size(250, 36);
            lblBuildingNameCard.TabIndex = 2;
            lblBuildingNameCard.Text = "Building Name";
            lblBuildingNameCard.TextAlign = ContentAlignment.MiddleCenter;
            lblBuildingNameCard.Click += lblBuildingNameCard_Click;
            // 
            // lblBuildingContent
            // 
            lblBuildingContent.Dock = DockStyle.Fill;
            lblBuildingContent.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuildingContent.ForeColor = Color.White;
            lblBuildingContent.Location = new Point(0, 0);
            lblBuildingContent.Name = "lblBuildingContent";
            lblBuildingContent.Size = new Size(250, 164);
            lblBuildingContent.TabIndex = 4;
            lblBuildingContent.Text = "🏢";
            lblBuildingContent.TextAlign = ContentAlignment.MiddleCenter;
            lblBuildingContent.Click += lblBuildingContent_Click;
            // 
            // BuildingCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            Controls.Add(lblBuildingContent);
            Controls.Add(lblBuildingNameCard);
            Name = "BuildingCard";
            Size = new Size(250, 200);
            Load += BuildingCard_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblBuildingNameCard;
        private Label lblBuildingContent;
    }
}
