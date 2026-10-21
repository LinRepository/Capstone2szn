namespace Capstoneszn.Forms.RoomsForms
{
    partial class TransferForm
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
            pnlHeader = new Panel();
            lblSourceRoom = new Label();
            lblTitle = new Label();
            pnlDestination = new Panel();
            lblDestinationInfo = new Label();
            cboDestination = new ComboBox();
            lblDestinationCaption = new Label();
            pnlTenants = new Panel();
            clbTenants = new CheckedListBox();
            pnlTenantsHeader = new Panel();
            lblTenantsCaption = new Label();
            pnlWarnings = new Panel();
            lblWarnings = new Label();
            pnlActions = new Panel();
            btnTransfer = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            pnlDestination.SuspendLayout();
            pnlTenants.SuspendLayout();
            pnlTenantsHeader.SuspendLayout();
            pnlWarnings.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lblSourceRoom);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(720, 85);
            pnlHeader.TabIndex = 0;
            // 
            // lblSourceRoom
            // 
            lblSourceRoom.Dock = DockStyle.Fill;
            lblSourceRoom.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSourceRoom.ForeColor = Color.White;
            lblSourceRoom.Location = new Point(0, 45);
            lblSourceRoom.Name = "lblSourceRoom";
            lblSourceRoom.Size = new Size(718, 38);
            lblSourceRoom.TabIndex = 1;
            lblSourceRoom.Text = "-";
            lblSourceRoom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(718, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Transfer Tenants";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDestination
            // 
            pnlDestination.BorderStyle = BorderStyle.FixedSingle;
            pnlDestination.Controls.Add(lblDestinationInfo);
            pnlDestination.Controls.Add(cboDestination);
            pnlDestination.Controls.Add(lblDestinationCaption);
            pnlDestination.Dock = DockStyle.Top;
            pnlDestination.Location = new Point(0, 85);
            pnlDestination.Name = "pnlDestination";
            pnlDestination.Padding = new Padding(15, 10, 15, 10);
            pnlDestination.Size = new Size(720, 110);
            pnlDestination.TabIndex = 1;
            // 
            // lblDestinationInfo
            // 
            lblDestinationInfo.Dock = DockStyle.Bottom;
            lblDestinationInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDestinationInfo.ForeColor = Color.Gainsboro;
            lblDestinationInfo.Location = new Point(195, 68);
            lblDestinationInfo.Name = "lblDestinationInfo";
            lblDestinationInfo.Size = new Size(508, 30);
            lblDestinationInfo.TabIndex = 2;
            lblDestinationInfo.Text = "-";
            lblDestinationInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboDestination
            // 
            cboDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDestination.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboDestination.FormattingEnabled = true;
            cboDestination.Location = new Point(205, 18);
            cboDestination.Name = "cboDestination";
            cboDestination.Size = new Size(480, 33);
            cboDestination.TabIndex = 1;
            cboDestination.SelectedIndexChanged += cboDestination_SelectedIndexChanged;
            // 
            // lblDestinationCaption
            // 
            lblDestinationCaption.Dock = DockStyle.Left;
            lblDestinationCaption.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDestinationCaption.ForeColor = Color.White;
            lblDestinationCaption.Location = new Point(15, 10);
            lblDestinationCaption.Name = "lblDestinationCaption";
            lblDestinationCaption.Size = new Size(180, 88);
            lblDestinationCaption.TabIndex = 0;
            lblDestinationCaption.Text = "Transfer to room";
            lblDestinationCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTenants
            // 
            pnlTenants.Controls.Add(clbTenants);
            pnlTenants.Controls.Add(pnlTenantsHeader);
            pnlTenants.Dock = DockStyle.Fill;
            pnlTenants.Location = new Point(0, 195);
            pnlTenants.Name = "pnlTenants";
            pnlTenants.Padding = new Padding(15, 0, 15, 10);
            pnlTenants.Size = new Size(720, 215);
            pnlTenants.TabIndex = 2;
            // 
            // clbTenants
            // 
            clbTenants.CheckOnClick = true;
            clbTenants.Dock = DockStyle.Fill;
            clbTenants.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clbTenants.FormattingEnabled = true;
            clbTenants.IntegralHeight = false;
            clbTenants.Location = new Point(15, 40);
            clbTenants.Name = "clbTenants";
            clbTenants.Size = new Size(690, 165);
            clbTenants.TabIndex = 1;
            clbTenants.ItemCheck += clbTenants_ItemCheck;
            // 
            // pnlTenantsHeader
            // 
            pnlTenantsHeader.Controls.Add(lblTenantsCaption);
            pnlTenantsHeader.Dock = DockStyle.Top;
            pnlTenantsHeader.Location = new Point(15, 0);
            pnlTenantsHeader.Name = "pnlTenantsHeader";
            pnlTenantsHeader.Size = new Size(690, 40);
            pnlTenantsHeader.TabIndex = 0;
            // 
            // lblTenantsCaption
            // 
            lblTenantsCaption.Dock = DockStyle.Fill;
            lblTenantsCaption.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenantsCaption.ForeColor = Color.White;
            lblTenantsCaption.Location = new Point(0, 0);
            lblTenantsCaption.Name = "lblTenantsCaption";
            lblTenantsCaption.Size = new Size(690, 40);
            lblTenantsCaption.TabIndex = 0;
            lblTenantsCaption.Text = "Tenants to transfer";
            lblTenantsCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlWarnings
            // 
            pnlWarnings.BorderStyle = BorderStyle.FixedSingle;
            pnlWarnings.Controls.Add(lblWarnings);
            pnlWarnings.Dock = DockStyle.Bottom;
            pnlWarnings.Location = new Point(0, 410);
            pnlWarnings.Name = "pnlWarnings";
            pnlWarnings.Padding = new Padding(15, 8, 15, 8);
            pnlWarnings.Size = new Size(720, 130);
            pnlWarnings.TabIndex = 3;
            // 
            // lblWarnings
            // 
            lblWarnings.Dock = DockStyle.Fill;
            lblWarnings.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWarnings.ForeColor = Color.Gold;
            lblWarnings.Location = new Point(15, 8);
            lblWarnings.Name = "lblWarnings";
            lblWarnings.Size = new Size(688, 112);
            lblWarnings.TabIndex = 0;
            lblWarnings.Text = "-";
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnTransfer);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 540);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(15, 10, 15, 10);
            pnlActions.Size = new Size(720, 60);
            pnlActions.TabIndex = 4;
            // 
            // btnTransfer
            // 
            btnTransfer.Cursor = Cursors.Hand;
            btnTransfer.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTransfer.Location = new Point(555, 10);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(150, 40);
            btnTransfer.TabIndex = 1;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(395, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 40);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // TransferForm
            // 
            AcceptButton = btnTransfer;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            CancelButton = btnCancel;
            ClientSize = new Size(720, 600);
            Controls.Add(pnlTenants);
            Controls.Add(pnlWarnings);
            Controls.Add(pnlActions);
            Controls.Add(pnlDestination);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TransferForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Transfer Tenants";
            Load += TransferForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlDestination.ResumeLayout(false);
            pnlTenants.ResumeLayout(false);
            pnlTenantsHeader.ResumeLayout(false);
            pnlWarnings.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSourceRoom;
        private Panel pnlDestination;
        private Label lblDestinationCaption;
        private ComboBox cboDestination;
        private Label lblDestinationInfo;
        private Panel pnlTenants;
        private Panel pnlTenantsHeader;
        private Label lblTenantsCaption;
        private CheckedListBox clbTenants;
        private Panel pnlWarnings;
        private Label lblWarnings;
        private Panel pnlActions;
        private Button btnCancel;
        private Button btnTransfer;
    }
}