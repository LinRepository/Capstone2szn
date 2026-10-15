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
            lblRoomInfo = new Label();
            lblMoveOutTitle = new Label();
            pnlTenantSelection = new Panel();
            dgvTenantsToMoveOut = new DataGridView();
            pnlTenantSelectionCaption = new Panel();
            lblMoveOutDescription = new Label();
            pnlSettlement = new Panel();
            dgvSettlement = new DataGridView();
            pnlSettlementHeader = new Panel();
            lblSettlementTotal = new Label();
            lblSettlementCaption = new Label();
            pnlDetails = new Panel();
            txtWriteOffReason = new TextBox();
            lblReasonCaption = new Label();
            dtpMoveOutDate = new DateTimePicker();
            lblMoveOutDateCaption = new Label();
            pnlMoveOutActions = new Panel();
            btnMoveOut = new Button();
            btnCancelMoveOut = new Button();
            pnlTenantSelectionHeader.SuspendLayout();
            pnlTenantSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenantsToMoveOut).BeginInit();
            pnlTenantSelectionCaption.SuspendLayout();
            pnlSettlement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSettlement).BeginInit();
            pnlSettlementHeader.SuspendLayout();
            pnlDetails.SuspendLayout();
            pnlMoveOutActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTenantSelectionHeader
            // 
            pnlTenantSelectionHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlTenantSelectionHeader.Controls.Add(lblRoomInfo);
            pnlTenantSelectionHeader.Controls.Add(lblMoveOutTitle);
            pnlTenantSelectionHeader.Dock = DockStyle.Top;
            pnlTenantSelectionHeader.Location = new Point(0, 0);
            pnlTenantSelectionHeader.Name = "pnlTenantSelectionHeader";
            pnlTenantSelectionHeader.Size = new Size(720, 85);
            pnlTenantSelectionHeader.TabIndex = 0;
            // 
            // lblRoomInfo
            // 
            lblRoomInfo.Dock = DockStyle.Fill;
            lblRoomInfo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomInfo.ForeColor = Color.White;
            lblRoomInfo.Location = new Point(0, 45);
            lblRoomInfo.Margin = new Padding(0);
            lblRoomInfo.Name = "lblRoomInfo";
            lblRoomInfo.Size = new Size(718, 38);
            lblRoomInfo.TabIndex = 1;
            lblRoomInfo.Text = "-";
            lblRoomInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMoveOutTitle
            // 
            lblMoveOutTitle.Dock = DockStyle.Top;
            lblMoveOutTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveOutTitle.ForeColor = Color.White;
            lblMoveOutTitle.Location = new Point(0, 0);
            lblMoveOutTitle.Margin = new Padding(0);
            lblMoveOutTitle.Name = "lblMoveOutTitle";
            lblMoveOutTitle.Size = new Size(718, 45);
            lblMoveOutTitle.TabIndex = 0;
            lblMoveOutTitle.Text = "Move Out Tenant";
            lblMoveOutTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblMoveOutTitle.Click += lblMoveOutTitle_Click;
            // 
            // pnlTenantSelection
            // 
            pnlTenantSelection.Controls.Add(dgvTenantsToMoveOut);
            pnlTenantSelection.Controls.Add(pnlTenantSelectionCaption);
            pnlTenantSelection.Dock = DockStyle.Top;
            pnlTenantSelection.Location = new Point(0, 85);
            pnlTenantSelection.Name = "pnlTenantSelection";
            pnlTenantSelection.Padding = new Padding(12, 0, 12, 8);
            pnlTenantSelection.Size = new Size(720, 215);
            pnlTenantSelection.TabIndex = 1;
            // 
            // dgvTenantsToMoveOut
            // 
            dgvTenantsToMoveOut.AllowUserToAddRows = false;
            dgvTenantsToMoveOut.AllowUserToDeleteRows = false;
            dgvTenantsToMoveOut.AllowUserToResizeRows = false;
            dgvTenantsToMoveOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTenantsToMoveOut.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTenantsToMoveOut.Dock = DockStyle.Fill;
            dgvTenantsToMoveOut.Location = new Point(12, 38);
            dgvTenantsToMoveOut.MultiSelect = false;
            dgvTenantsToMoveOut.Name = "dgvTenantsToMoveOut";
            dgvTenantsToMoveOut.ReadOnly = true;
            dgvTenantsToMoveOut.RowHeadersVisible = false;
            dgvTenantsToMoveOut.RowHeadersWidth = 51;
            dgvTenantsToMoveOut.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenantsToMoveOut.Size = new Size(696, 169);
            dgvTenantsToMoveOut.TabIndex = 1;
            // 
            // pnlTenantSelectionCaption
            // 
            pnlTenantSelectionCaption.Controls.Add(lblMoveOutDescription);
            pnlTenantSelectionCaption.Dock = DockStyle.Top;
            pnlTenantSelectionCaption.Location = new Point(12, 0);
            pnlTenantSelectionCaption.Name = "pnlTenantSelectionCaption";
            pnlTenantSelectionCaption.Size = new Size(696, 38);
            pnlTenantSelectionCaption.TabIndex = 0;
            // 
            // lblMoveOutDescription
            // 
            lblMoveOutDescription.Dock = DockStyle.Fill;
            lblMoveOutDescription.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveOutDescription.ForeColor = Color.White;
            lblMoveOutDescription.Location = new Point(0, 0);
            lblMoveOutDescription.Margin = new Padding(0);
            lblMoveOutDescription.Name = "lblMoveOutDescription";
            lblMoveOutDescription.Size = new Size(696, 38);
            lblMoveOutDescription.TabIndex = 0;
            lblMoveOutDescription.Text = "Select the tenant you want to move out of this room.";
            lblMoveOutDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlSettlement
            // 
            pnlSettlement.Controls.Add(dgvSettlement);
            pnlSettlement.Controls.Add(pnlSettlementHeader);
            pnlSettlement.Dock = DockStyle.Fill;
            pnlSettlement.Location = new Point(0, 300);
            pnlSettlement.Name = "pnlSettlement";
            pnlSettlement.Padding = new Padding(12, 0, 12, 8);
            pnlSettlement.Size = new Size(720, 205);
            pnlSettlement.TabIndex = 2;
            // 
            // dgvSettlement
            // 
            dgvSettlement.AllowUserToAddRows = false;
            dgvSettlement.AllowUserToDeleteRows = false;
            dgvSettlement.AllowUserToResizeRows = false;
            dgvSettlement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSettlement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSettlement.Dock = DockStyle.Fill;
            dgvSettlement.Location = new Point(12, 38);
            dgvSettlement.MultiSelect = false;
            dgvSettlement.Name = "dgvSettlement";
            dgvSettlement.ReadOnly = true;
            dgvSettlement.RowHeadersVisible = false;
            dgvSettlement.RowHeadersWidth = 51;
            dgvSettlement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSettlement.Size = new Size(696, 159);
            dgvSettlement.TabIndex = 1;
            // 
            // pnlSettlementHeader
            // 
            pnlSettlementHeader.Controls.Add(lblSettlementTotal);
            pnlSettlementHeader.Controls.Add(lblSettlementCaption);
            pnlSettlementHeader.Dock = DockStyle.Top;
            pnlSettlementHeader.Location = new Point(12, 0);
            pnlSettlementHeader.Name = "pnlSettlementHeader";
            pnlSettlementHeader.Size = new Size(696, 38);
            pnlSettlementHeader.TabIndex = 0;
            // 
            // lblSettlementTotal
            // 
            lblSettlementTotal.Dock = DockStyle.Fill;
            lblSettlementTotal.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSettlementTotal.ForeColor = Color.Gainsboro;
            lblSettlementTotal.Location = new Point(290, 0);
            lblSettlementTotal.Margin = new Padding(0);
            lblSettlementTotal.Name = "lblSettlementTotal";
            lblSettlementTotal.Size = new Size(406, 38);
            lblSettlementTotal.TabIndex = 1;
            lblSettlementTotal.Text = "-";
            lblSettlementTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSettlementCaption
            // 
            lblSettlementCaption.Dock = DockStyle.Left;
            lblSettlementCaption.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSettlementCaption.ForeColor = Color.White;
            lblSettlementCaption.Location = new Point(0, 0);
            lblSettlementCaption.Margin = new Padding(0);
            lblSettlementCaption.Name = "lblSettlementCaption";
            lblSettlementCaption.Size = new Size(290, 38);
            lblSettlementCaption.TabIndex = 0;
            lblSettlementCaption.Text = "What will be settled";
            lblSettlementCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDetails
            // 
            pnlDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlDetails.Controls.Add(txtWriteOffReason);
            pnlDetails.Controls.Add(lblReasonCaption);
            pnlDetails.Controls.Add(dtpMoveOutDate);
            pnlDetails.Controls.Add(lblMoveOutDateCaption);
            pnlDetails.Dock = DockStyle.Bottom;
            pnlDetails.Location = new Point(0, 505);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(720, 135);
            pnlDetails.TabIndex = 3;
            // 
            // txtWriteOffReason
            // 
            txtWriteOffReason.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWriteOffReason.Location = new Point(185, 55);
            txtWriteOffReason.MaxLength = 255;
            txtWriteOffReason.Multiline = true;
            txtWriteOffReason.Name = "txtWriteOffReason";
            txtWriteOffReason.ScrollBars = ScrollBars.Vertical;
            txtWriteOffReason.Size = new Size(505, 62);
            txtWriteOffReason.TabIndex = 3;
            // 
            // lblReasonCaption
            // 
            lblReasonCaption.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReasonCaption.ForeColor = Color.Gray;
            lblReasonCaption.Location = new Point(18, 58);
            lblReasonCaption.Margin = new Padding(0);
            lblReasonCaption.Name = "lblReasonCaption";
            lblReasonCaption.Size = new Size(160, 28);
            lblReasonCaption.TabIndex = 2;
            lblReasonCaption.Text = "Write-off reason";
            lblReasonCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpMoveOutDate
            // 
            dtpMoveOutDate.CustomFormat = "MMM d, yyyy";
            dtpMoveOutDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpMoveOutDate.Format = DateTimePickerFormat.Custom;
            dtpMoveOutDate.Location = new Point(185, 12);
            dtpMoveOutDate.Name = "dtpMoveOutDate";
            dtpMoveOutDate.Size = new Size(220, 31);
            dtpMoveOutDate.TabIndex = 1;
            // 
            // lblMoveOutDateCaption
            // 
            lblMoveOutDateCaption.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveOutDateCaption.ForeColor = Color.White;
            lblMoveOutDateCaption.Location = new Point(18, 15);
            lblMoveOutDateCaption.Margin = new Padding(0);
            lblMoveOutDateCaption.Name = "lblMoveOutDateCaption";
            lblMoveOutDateCaption.Size = new Size(160, 28);
            lblMoveOutDateCaption.TabIndex = 0;
            lblMoveOutDateCaption.Text = "Move-out date";
            lblMoveOutDateCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlMoveOutActions
            // 
            pnlMoveOutActions.Controls.Add(btnMoveOut);
            pnlMoveOutActions.Controls.Add(btnCancelMoveOut);
            pnlMoveOutActions.Dock = DockStyle.Bottom;
            pnlMoveOutActions.Location = new Point(0, 640);
            pnlMoveOutActions.Name = "pnlMoveOutActions";
            pnlMoveOutActions.Size = new Size(720, 60);
            pnlMoveOutActions.TabIndex = 4;
            // 
            // btnMoveOut
            // 
            btnMoveOut.Cursor = Cursors.Hand;
            btnMoveOut.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMoveOut.Location = new Point(585, 12);
            btnMoveOut.Name = "btnMoveOut";
            btnMoveOut.Size = new Size(120, 36);
            btnMoveOut.TabIndex = 1;
            btnMoveOut.Text = "Move Out";
            btnMoveOut.UseVisualStyleBackColor = true;
            btnMoveOut.Click += btnCancelMoveOut_Click;
            // 
            // btnCancelMoveOut
            // 
            btnCancelMoveOut.Cursor = Cursors.Hand;
            btnCancelMoveOut.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelMoveOut.Location = new Point(455, 12);
            btnCancelMoveOut.Name = "btnCancelMoveOut";
            btnCancelMoveOut.Size = new Size(120, 36);
            btnCancelMoveOut.TabIndex = 0;
            btnCancelMoveOut.Text = "Cancel";
            btnCancelMoveOut.UseVisualStyleBackColor = true;
            btnCancelMoveOut.Click += btnCancelMoveOut_Click;
            // 
            // MoveOutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            CancelButton = btnCancelMoveOut;
            ClientSize = new Size(720, 700);
            Controls.Add(pnlSettlement);
            Controls.Add(pnlDetails);
            Controls.Add(pnlMoveOutActions);
            Controls.Add(pnlTenantSelection);
            Controls.Add(pnlTenantSelectionHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveOutForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Move Out Tenant";
            Load += MoveOutForm_Load;
            pnlTenantSelectionHeader.ResumeLayout(false);
            pnlTenantSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTenantsToMoveOut).EndInit();
            pnlTenantSelectionCaption.ResumeLayout(false);
            pnlSettlement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSettlement).EndInit();
            pnlSettlementHeader.ResumeLayout(false);
            pnlDetails.ResumeLayout(false);
            pnlDetails.PerformLayout();
            pnlMoveOutActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTenantSelectionHeader;
        private Label lblMoveOutTitle;
        private Label lblRoomInfo;
        private Panel pnlTenantSelection;
        private Panel pnlTenantSelectionCaption;
        private Label lblMoveOutDescription;
        private DataGridView dgvTenantsToMoveOut;
        private Panel pnlSettlement;
        private Panel pnlSettlementHeader;
        private Label lblSettlementCaption;
        private Label lblSettlementTotal;
        private DataGridView dgvSettlement;
        private Panel pnlDetails;
        private Label lblMoveOutDateCaption;
        private DateTimePicker dtpMoveOutDate;
        private Label lblReasonCaption;
        private TextBox txtWriteOffReason;
        private Panel pnlMoveOutActions;
        private Button btnMoveOut;
        private Button btnCancelMoveOut;
    }
}