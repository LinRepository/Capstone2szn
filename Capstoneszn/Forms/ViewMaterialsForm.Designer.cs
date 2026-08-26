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
            btnAddMaterial = new Button();
            pnlMaterialsContent = new Panel();
            btnCloseMaterials = new Button();
            dgvMaterials = new DataGridView();
            colMaterialName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colTotalCost = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            pnlMaterialsHeader.SuspendLayout();
            pnlMaterialsActions.SuspendLayout();
            pnlMaterialsContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).BeginInit();
            SuspendLayout();
            // 
            // pnlMaterialsHeader
            // 
            pnlMaterialsHeader.Controls.Add(btnCloseMaterials);
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
            lblMaterialsContext.Visible = false;
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
            lblMaterialsTitle.Visible = false;
            // 
            // pnlMaterialsActions
            // 
            pnlMaterialsActions.Controls.Add(btnClose);
            pnlMaterialsActions.Controls.Add(btnAddMaterial);
            pnlMaterialsActions.Dock = DockStyle.Bottom;
            pnlMaterialsActions.Location = new Point(0, 303);
            pnlMaterialsActions.Name = "pnlMaterialsActions";
            pnlMaterialsActions.Size = new Size(582, 50);
            pnlMaterialsActions.TabIndex = 1;
            // 
            // btnAddMaterial
            // 
            btnAddMaterial.Location = new Point(440, 9);
            btnAddMaterial.Name = "btnAddMaterial";
            btnAddMaterial.Size = new Size(130, 29);
            btnAddMaterial.TabIndex = 0;
            btnAddMaterial.Text = "Add Materials";
            btnAddMaterial.UseVisualStyleBackColor = true;
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
            // btnCloseMaterials
            // 
            btnCloseMaterials.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseMaterials.FlatStyle = FlatStyle.Flat;
            btnCloseMaterials.ForeColor = Color.White;
            btnCloseMaterials.Location = new Point(540, 12);
            btnCloseMaterials.Name = "btnCloseMaterials";
            btnCloseMaterials.Size = new Size(30, 30);
            btnCloseMaterials.TabIndex = 39;
            btnCloseMaterials.TabStop = false;
            btnCloseMaterials.Text = "X";
            btnCloseMaterials.UseVisualStyleBackColor = true;
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
            // btnClose
            // 
            btnClose.Location = new Point(285, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 29);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // ViewMaterialsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
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
        private Button btnCloseMaterials;
        private DataGridView dgvMaterials;
        private DataGridViewTextBoxColumn colMaterialName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colTotalCost;
        private Button btnClose;
    }
}