namespace Capstoneszn.UserControls
{
    partial class MaintenanceControl
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
            pnlMaintenanceHeader = new Panel();
            cboMaintenanceStatus = new ComboBox();
            btnAddIssue = new Button();
            pnlMaintenanceContent = new Panel();
            flpMaintenanceIssues = new FlowLayoutPanel();
            pnlMaintenanceHeader.SuspendLayout();
            pnlMaintenanceContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMaintenanceHeader
            // 
            pnlMaintenanceHeader.Controls.Add(cboMaintenanceStatus);
            pnlMaintenanceHeader.Controls.Add(btnAddIssue);
            pnlMaintenanceHeader.Dock = DockStyle.Top;
            pnlMaintenanceHeader.Location = new Point(0, 0);
            pnlMaintenanceHeader.Name = "pnlMaintenanceHeader";
            pnlMaintenanceHeader.Size = new Size(1300, 85);
            pnlMaintenanceHeader.TabIndex = 0;
            // 
            // cboMaintenanceStatus
            // 
            cboMaintenanceStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboMaintenanceStatus.FormattingEnabled = true;
            cboMaintenanceStatus.Location = new Point(1127, 27);
            cboMaintenanceStatus.Name = "cboMaintenanceStatus";
            cboMaintenanceStatus.Size = new Size(151, 28);
            cboMaintenanceStatus.TabIndex = 1;
            // 
            // btnAddIssue
            // 
            btnAddIssue.Location = new Point(26, 26);
            btnAddIssue.Name = "btnAddIssue";
            btnAddIssue.Size = new Size(94, 29);
            btnAddIssue.TabIndex = 0;
            btnAddIssue.Text = "Add Issue";
            btnAddIssue.UseVisualStyleBackColor = true;
            // 
            // pnlMaintenanceContent
            // 
            pnlMaintenanceContent.Controls.Add(flpMaintenanceIssues);
            pnlMaintenanceContent.Dock = DockStyle.Fill;
            pnlMaintenanceContent.Location = new Point(0, 85);
            pnlMaintenanceContent.Name = "pnlMaintenanceContent";
            pnlMaintenanceContent.Size = new Size(1300, 665);
            pnlMaintenanceContent.TabIndex = 1;
            // 
            // flpMaintenanceIssues
            // 
            flpMaintenanceIssues.Dock = DockStyle.Fill;
            flpMaintenanceIssues.FlowDirection = FlowDirection.TopDown;
            flpMaintenanceIssues.Location = new Point(0, 0);
            flpMaintenanceIssues.Name = "flpMaintenanceIssues";
            flpMaintenanceIssues.Size = new Size(1300, 665);
            flpMaintenanceIssues.TabIndex = 0;
            flpMaintenanceIssues.WrapContents = false;
            // 
            // MaintenanceControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlMaintenanceContent);
            Controls.Add(pnlMaintenanceHeader);
            Name = "MaintenanceControl";
            Size = new Size(1300, 750);
            pnlMaintenanceHeader.ResumeLayout(false);
            pnlMaintenanceContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMaintenanceHeader;
        private ComboBox cboMaintenanceStatus;
        private Button btnAddIssue;
        private Panel pnlMaintenanceContent;
        private FlowLayoutPanel flpMaintenanceIssues;
    }
}
