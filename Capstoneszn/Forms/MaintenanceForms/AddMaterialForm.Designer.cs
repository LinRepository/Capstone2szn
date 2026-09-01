namespace Capstoneszn.Forms
{
    partial class AddMaterialForm
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
            pnlAddMaterialHeader = new Panel();
            lblAddMaterialTitle = new Label();
            pnlAddMaterialActions = new Panel();
            btnAddMaterial = new Button();
            btnCancelMaterial = new Button();
            pnlAddMaterialContent = new Panel();
            nudUnitPrice = new NumericUpDown();
            nudQuantity = new NumericUpDown();
            txtMaterialName = new TextBox();
            lblQuantity = new Label();
            lblUnitPrice = new Label();
            lblAddMaterialDescription = new Label();
            lblMaterialName = new Label();
            pnlAddMaterialHeader.SuspendLayout();
            pnlAddMaterialActions.SuspendLayout();
            pnlAddMaterialContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();
            // 
            // pnlAddMaterialHeader
            // 
            pnlAddMaterialHeader.Controls.Add(lblAddMaterialTitle);
            pnlAddMaterialHeader.Dock = DockStyle.Top;
            pnlAddMaterialHeader.Location = new Point(0, 0);
            pnlAddMaterialHeader.Name = "pnlAddMaterialHeader";
            pnlAddMaterialHeader.Size = new Size(432, 50);
            pnlAddMaterialHeader.TabIndex = 0;
            // 
            // lblAddMaterialTitle
            // 
            lblAddMaterialTitle.AutoSize = true;
            lblAddMaterialTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddMaterialTitle.ForeColor = Color.White;
            lblAddMaterialTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddMaterialTitle.Location = new Point(181, 15);
            lblAddMaterialTitle.Name = "lblAddMaterialTitle";
            lblAddMaterialTitle.Size = new Size(96, 20);
            lblAddMaterialTitle.TabIndex = 38;
            lblAddMaterialTitle.Text = "Add Material";
            lblAddMaterialTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblAddMaterialTitle.Visible = false;
            // 
            // pnlAddMaterialActions
            // 
            pnlAddMaterialActions.Controls.Add(btnAddMaterial);
            pnlAddMaterialActions.Controls.Add(btnCancelMaterial);
            pnlAddMaterialActions.Dock = DockStyle.Bottom;
            pnlAddMaterialActions.Location = new Point(0, 298);
            pnlAddMaterialActions.Name = "pnlAddMaterialActions";
            pnlAddMaterialActions.Size = new Size(432, 55);
            pnlAddMaterialActions.TabIndex = 1;
            // 
            // btnAddMaterial
            // 
            btnAddMaterial.Location = new Point(300, 14);
            btnAddMaterial.Name = "btnAddMaterial";
            btnAddMaterial.Size = new Size(120, 29);
            btnAddMaterial.TabIndex = 1;
            btnAddMaterial.Text = "Add Material";
            btnAddMaterial.UseVisualStyleBackColor = true;
            // 
            // btnCancelMaterial
            // 
            btnCancelMaterial.Location = new Point(190, 14);
            btnCancelMaterial.Name = "btnCancelMaterial";
            btnCancelMaterial.Size = new Size(94, 29);
            btnCancelMaterial.TabIndex = 0;
            btnCancelMaterial.Text = "Cancel";
            btnCancelMaterial.UseVisualStyleBackColor = true;
            // 
            // pnlAddMaterialContent
            // 
            pnlAddMaterialContent.Controls.Add(nudUnitPrice);
            pnlAddMaterialContent.Controls.Add(nudQuantity);
            pnlAddMaterialContent.Controls.Add(txtMaterialName);
            pnlAddMaterialContent.Controls.Add(lblQuantity);
            pnlAddMaterialContent.Controls.Add(lblUnitPrice);
            pnlAddMaterialContent.Controls.Add(lblAddMaterialDescription);
            pnlAddMaterialContent.Controls.Add(lblMaterialName);
            pnlAddMaterialContent.Dock = DockStyle.Fill;
            pnlAddMaterialContent.Location = new Point(0, 50);
            pnlAddMaterialContent.Name = "pnlAddMaterialContent";
            pnlAddMaterialContent.Size = new Size(432, 248);
            pnlAddMaterialContent.TabIndex = 2;
            // 
            // nudUnitPrice
            // 
            nudUnitPrice.DecimalPlaces = 2;
            nudUnitPrice.Location = new Point(124, 203);
            nudUnitPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudUnitPrice.Name = "nudUnitPrice";
            nudUnitPrice.Size = new Size(199, 27);
            nudUnitPrice.TabIndex = 44;
            nudUnitPrice.ThousandsSeparator = true;
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(124, 136);
            nudQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(199, 27);
            nudQuantity.TabIndex = 43;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtMaterialName
            // 
            txtMaterialName.Location = new Point(124, 58);
            txtMaterialName.Multiline = true;
            txtMaterialName.Name = "txtMaterialName";
            txtMaterialName.Size = new Size(199, 34);
            txtMaterialName.TabIndex = 42;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.ForeColor = Color.White;
            lblQuantity.ImageAlign = ContentAlignment.MiddleRight;
            lblQuantity.Location = new Point(124, 105);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(88, 28);
            lblQuantity.TabIndex = 41;
            lblQuantity.Text = "Quantity";
            lblQuantity.TextAlign = ContentAlignment.MiddleCenter;
            lblQuantity.Visible = false;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitPrice.ForeColor = Color.White;
            lblUnitPrice.ImageAlign = ContentAlignment.MiddleRight;
            lblUnitPrice.Location = new Point(124, 172);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(96, 28);
            lblUnitPrice.TabIndex = 40;
            lblUnitPrice.Text = "Unit Price";
            lblUnitPrice.TextAlign = ContentAlignment.MiddleCenter;
            lblUnitPrice.Visible = false;
            // 
            // lblAddMaterialDescription
            // 
            lblAddMaterialDescription.AutoSize = true;
            lblAddMaterialDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddMaterialDescription.ForeColor = Color.White;
            lblAddMaterialDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblAddMaterialDescription.Location = new Point(120, 0);
            lblAddMaterialDescription.Name = "lblAddMaterialDescription";
            lblAddMaterialDescription.Size = new Size(197, 20);
            lblAddMaterialDescription.TabIndex = 39;
            lblAddMaterialDescription.Text = "Enter Material Details Below";
            lblAddMaterialDescription.TextAlign = ContentAlignment.MiddleCenter;
            lblAddMaterialDescription.Visible = false;
            // 
            // lblMaterialName
            // 
            lblMaterialName.AutoSize = true;
            lblMaterialName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialName.ForeColor = Color.White;
            lblMaterialName.ImageAlign = ContentAlignment.MiddleRight;
            lblMaterialName.Location = new Point(124, 27);
            lblMaterialName.Name = "lblMaterialName";
            lblMaterialName.Size = new Size(141, 28);
            lblMaterialName.TabIndex = 38;
            lblMaterialName.Text = "Material Name";
            lblMaterialName.TextAlign = ContentAlignment.MiddleCenter;
            lblMaterialName.Visible = false;
            // 
            // AddMaterialForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(432, 353);
            Controls.Add(pnlAddMaterialContent);
            Controls.Add(pnlAddMaterialActions);
            Controls.Add(pnlAddMaterialHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddMaterialForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Material";
            pnlAddMaterialHeader.ResumeLayout(false);
            pnlAddMaterialHeader.PerformLayout();
            pnlAddMaterialActions.ResumeLayout(false);
            pnlAddMaterialContent.ResumeLayout(false);
            pnlAddMaterialContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAddMaterialHeader;
        private Panel pnlAddMaterialActions;
        private Panel pnlAddMaterialContent;
        private Label lblAddMaterialTitle;
        private Button btnAddMaterial;
        private Button btnCancelMaterial;
        private Label lblQuantity;
        private Label lblUnitPrice;
        private Label lblAddMaterialDescription;
        private Label lblMaterialName;
        private TextBox txtMaterialName;
        private NumericUpDown nudUnitPrice;
        private NumericUpDown nudQuantity;
    }
}