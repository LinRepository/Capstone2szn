namespace Capstoneszn.UserControls
{
    partial class MoveOutForm
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
            pnlTenantSelectionHeader = new Panel();
            lblMoveOutTitle = new Label();
            lblMoveOutDescription = new Label();
            pnlMoveOutActions = new Panel();
            pnlTenantSelection = new Panel();
            dgvTenantsToMoveOut = new DataGridView();
            btnCancelMoveOut = new Button();
            btnMoveOut = new Button();
            pnlTenantSelectionHeader.SuspendLayout();
            pnlMoveOutActions.SuspendLayout();
            pnlTenantSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenantsToMoveOut).BeginInit();
            SuspendLayout();
            // 
            // pnlTenantSelectionHeader
            // 
            pnlTenantSelectionHeader.Controls.Add(lblMoveOutDescription);
            pnlTenantSelectionHeader.Controls.Add(lblMoveOutTitle);
            pnlTenantSelectionHeader.Dock = DockStyle.Top;
            pnlTenantSelectionHeader.Location = new Point(0, 0);
            pnlTenantSelectionHeader.Name = "pnlTenantSelectionHeader";
            pnlTenantSelectionHeader.Size = new Size(782, 70);
            pnlTenantSelectionHeader.TabIndex = 0;
            // 
            // lblMoveOutTitle
            // 
            lblMoveOutTitle.AutoSize = true;
            lblMoveOutTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveOutTitle.ForeColor = Color.White;
            lblMoveOutTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveOutTitle.Location = new Point(295, 6);
            lblMoveOutTitle.Margin = new Padding(0);
            lblMoveOutTitle.Name = "lblMoveOutTitle";
            lblMoveOutTitle.Size = new Size(189, 31);
            lblMoveOutTitle.TabIndex = 25;
            lblMoveOutTitle.Text = "Move Out Tenant";
            lblMoveOutTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMoveOutDescription
            // 
            lblMoveOutDescription.AutoSize = true;
            lblMoveOutDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveOutDescription.ForeColor = Color.White;
            lblMoveOutDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveOutDescription.Location = new Point(183, 39);
            lblMoveOutDescription.Margin = new Padding(0);
            lblMoveOutDescription.Name = "lblMoveOutDescription";
            lblMoveOutDescription.Size = new Size(433, 25);
            lblMoveOutDescription.TabIndex = 26;
            lblMoveOutDescription.Text = "Select the tenant you want to move out of this room.";
            lblMoveOutDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMoveOutActions
            // 
            pnlMoveOutActions.Controls.Add(btnMoveOut);
            pnlMoveOutActions.Controls.Add(btnCancelMoveOut);
            pnlMoveOutActions.Dock = DockStyle.Bottom;
            pnlMoveOutActions.Location = new Point(0, 398);
            pnlMoveOutActions.Name = "pnlMoveOutActions";
            pnlMoveOutActions.Size = new Size(782, 55);
            pnlMoveOutActions.TabIndex = 1;
            // 
            // pnlTenantSelection
            // 
            pnlTenantSelection.Controls.Add(dgvTenantsToMoveOut);
            pnlTenantSelection.Dock = DockStyle.Fill;
            pnlTenantSelection.Location = new Point(0, 70);
            pnlTenantSelection.Name = "pnlTenantSelection";
            pnlTenantSelection.Size = new Size(782, 328);
            pnlTenantSelection.TabIndex = 2;
            // 
            // dgvTenantsToMoveOut
            // 
            dgvTenantsToMoveOut.AllowUserToAddRows = false;
            dgvTenantsToMoveOut.AllowUserToDeleteRows = false;
            dgvTenantsToMoveOut.AllowUserToResizeRows = false;
            dgvTenantsToMoveOut.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTenantsToMoveOut.Dock = DockStyle.Fill;
            dgvTenantsToMoveOut.Location = new Point(0, 0);
            dgvTenantsToMoveOut.MultiSelect = false;
            dgvTenantsToMoveOut.Name = "dgvTenantsToMoveOut";
            dgvTenantsToMoveOut.ReadOnly = true;
            dgvTenantsToMoveOut.RowHeadersVisible = false;
            dgvTenantsToMoveOut.RowHeadersWidth = 51;
            dgvTenantsToMoveOut.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenantsToMoveOut.Size = new Size(782, 328);
            dgvTenantsToMoveOut.TabIndex = 0;
            // 
            // btnCancelMoveOut
            // 
            btnCancelMoveOut.Location = new Point(564, 14);
            btnCancelMoveOut.Name = "btnCancelMoveOut";
            btnCancelMoveOut.Size = new Size(94, 29);
            btnCancelMoveOut.TabIndex = 0;
            btnCancelMoveOut.Text = "Cancel";
            btnCancelMoveOut.UseVisualStyleBackColor = true;
            // 
            // btnMoveOut
            // 
            btnMoveOut.Location = new Point(676, 14);
            btnMoveOut.Name = "btnMoveOut";
            btnMoveOut.Size = new Size(94, 29);
            btnMoveOut.TabIndex = 1;
            btnMoveOut.Text = "Move Out";
            btnMoveOut.UseVisualStyleBackColor = true;
            // 
            // MoveOutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(782, 453);
            Controls.Add(pnlTenantSelection);
            Controls.Add(pnlMoveOutActions);
            Controls.Add(pnlTenantSelectionHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveOutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Move Out Tenant";
            pnlTenantSelectionHeader.ResumeLayout(false);
            pnlTenantSelectionHeader.PerformLayout();
            pnlMoveOutActions.ResumeLayout(false);
            pnlTenantSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTenantsToMoveOut).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTenantSelectionHeader;
        private Label lblMoveOutTitle;
        private Label lblMoveOutDescription;
        private Panel pnlMoveOutActions;
        private Button btnMoveOut;
        private Button btnCancelMoveOut;
        private Panel pnlTenantSelection;
        private DataGridView dgvTenantsToMoveOut;
    }
}