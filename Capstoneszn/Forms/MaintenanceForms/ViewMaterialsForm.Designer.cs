namespace Capstoneszn.Forms
{
    partial class ViewMaterialsForm
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
            pnlMaterialsHeader = new Panel();
            lblMaterialsContext = new Label();
            lblMaterialsTitle = new Label();
            pnlMaterialsActions = new Panel();
            btnRemoveMaterial = new Button();
            btnClose = new Button();
            btnAddMaterial = new Button();
            pnlMaterialsContent = new Panel();
            dgvMaterials = new DataGridView();
            colMaterialName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colTotalCost = new DataGridViewTextBoxColumn();
            pnlMaterialsHeader.SuspendLayout();
            pnlMaterialsActions.SuspendLayout();
            pnlMaterialsContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).BeginInit();
            SuspendLayout();
            // 
            // pnlMaterialsHeader
            // 
            pnlMaterialsHeader.Controls.Add(lblMaterialsContext);
            pnlMaterialsHeader.Controls.Add(lblMaterialsTitle);
            pnlMaterialsHeader.Dock = DockStyle.Top;
            pnlMaterialsHeader.Location = new Point(0, 0);
            pnlMaterialsHeader.Name = "pnlMaterialsHeader";
            pnlMaterialsHeader.Size = new Size(582, 50);
            pnlMaterialsHeader.TabIndex = 0;
            // 
            // lblMaterialsContext
            // 
            lblMaterialsContext.AutoSize = true;
            lblMaterialsContext.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialsContext.ForeColor = Color.White;
            lblMaterialsContext.ImageAlign = ContentAlignment.MiddleRight;
            lblMaterialsContext.Location = new Point(3, 26);
            lblMaterialsContext.Name = "lblMaterialsContext";
            lblMaterialsContext.Size = new Size(80, 20);
            lblMaterialsContext.TabIndex = 38;
            lblMaterialsContext.Text = "Room ###";
            lblMaterialsContext.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaterialsTitle
            // 
            lblMaterialsTitle.AutoSize = true;
            lblMaterialsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaterialsTitle.ForeColor = Color.White;
            lblMaterialsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMaterialsTitle.Location = new Point(3, 3);
            lblMaterialsTitle.Name = "lblMaterialsTitle";
            lblMaterialsTitle.Size = new Size(70, 20);
            lblMaterialsTitle.TabIndex = 37;
            lblMaterialsTitle.Text = "Materials";
            lblMaterialsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMaterialsActions
            // 
            pnlMaterialsActions.Controls.Add(btnRemoveMaterial);
            pnlMaterialsActions.Controls.Add(btnClose);
            pnlMaterialsActions.Controls.Add(btnAddMaterial);
            pnlMaterialsActions.Dock = DockStyle.Bottom;
            pnlMaterialsActions.Location = new Point(0, 303);
            pnlMaterialsActions.Name = "pnlMaterialsActions";
            pnlMaterialsActions.Size = new Size(582, 50);
            pnlMaterialsActions.TabIndex = 1;
            // 
            // btnRemoveMaterial
            // 
            btnRemoveMaterial.Cursor = Cursors.Hand;
            btnRemoveMaterial.Location = new Point(124, 9);
            btnRemoveMaterial.Name = "btnRemoveMaterial";
            btnRemoveMaterial.Size = new Size(140, 29);
            btnRemoveMaterial.TabIndex = 2;
            btnRemoveMaterial.Text = "Remove Material";
            btnRemoveMaterial.UseVisualStyleBackColor = true;
            btnRemoveMaterial.Click += btnRemoveMaterial_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(285, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 29);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnAddMaterial
            // 
            btnAddMaterial.Location = new Point(440, 9);
            btnAddMaterial.Name = "btnAddMaterial";
            btnAddMaterial.Size = new Size(130, 29);
            btnAddMaterial.TabIndex = 0;
            btnAddMaterial.Text = "Add Material";
            btnAddMaterial.UseVisualStyleBackColor = true;
            btnAddMaterial.Click += btnAddMaterial_Click;
            // 
            // pnlMaterialsContent
            // 
            pnlMaterialsContent.Controls.Add(dgvMaterials);
            pnlMaterialsContent.Dock = DockStyle.Fill;
            pnlMaterialsContent.Location = new Point(0, 50);
            pnlMaterialsContent.Name = "pnlMaterialsContent";
            pnlMaterialsContent.Size = new Size(582, 253);
            pnlMaterialsContent.TabIndex = 2;
            // 
            // dgvMaterials
            // 
            dgvMaterials.AllowUserToAddRows = false;
            dgvMaterials.AllowUserToDeleteRows = false;
            dgvMaterials.AllowUserToResizeRows = false;
            dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterials.Columns.AddRange(new DataGridViewColumn[] { colMaterialName, colQuantity, colUnitPrice, colTotalCost });
            dgvMaterials.Dock = DockStyle.Fill;
            dgvMaterials.Location = new Point(0, 0);
            dgvMaterials.MultiSelect = false;
            dgvMaterials.Name = "dgvMaterials";
            dgvMaterials.ReadOnly = true;
            dgvMaterials.RowHeadersVisible = false;
            dgvMaterials.RowHeadersWidth = 51;
            dgvMaterials.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterials.Size = new Size(582, 253);
            dgvMaterials.TabIndex = 0;
            // 
            // colMaterialName
            // 
            colMaterialName.HeaderText = "Material Name";
            colMaterialName.MinimumWidth = 6;
            colMaterialName.Name = "colMaterialName";
            colMaterialName.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 6;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            colUnitPrice.HeaderText = "Unit Price";
            colUnitPrice.MinimumWidth = 6;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            // 
            // colTotalCost
            // 
            colTotalCost.HeaderText = "Total Cost";
            colTotalCost.MinimumWidth = 6;
            colTotalCost.Name = "colTotalCost";
            colTotalCost.ReadOnly = true;
            // 
            // ViewMaterialsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(582, 353);
            Controls.Add(pnlMaterialsContent);
            Controls.Add(pnlMaterialsActions);
            Controls.Add(pnlMaterialsHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ViewMaterialsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View Materials";
            Load += ViewMaterialsForm_Load;
            pnlMaterialsHeader.ResumeLayout(false);
            pnlMaterialsHeader.PerformLayout();
            pnlMaterialsActions.ResumeLayout(false);
            pnlMaterialsContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMaterialsHeader;
        private Panel pnlMaterialsActions;
        private Panel pnlMaterialsContent;
        private Label lblMaterialsContext;
        private Label lblMaterialsTitle;
        private Button btnAddMaterial;
        private DataGridView dgvMaterials;
        private DataGridViewTextBoxColumn colMaterialName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colTotalCost;
        private Button btnClose;
        private Button btnRemoveMaterial;
    }
}