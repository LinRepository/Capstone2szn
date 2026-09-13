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
            lblMaintenanceTitle = new Label();
            pnlMaintenanceHeaderContent = new Panel();
            cboMaintenanceStatus = new ComboBox();
            btnAddIssue = new Button();
            pnlMaintenanceContent = new Panel();
            flpMaintenanceIssues = new FlowLayoutPanel();
            pnlMaintenanceHeader.SuspendLayout();
            pnlMaintenanceHeaderContent.SuspendLayout();
            pnlMaintenanceContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMaintenanceHeader
            // 
            pnlMaintenanceHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlMaintenanceHeader.Controls.Add(lblMaintenanceTitle);
            pnlMaintenanceHeader.Dock = DockStyle.Top;
            pnlMaintenanceHeader.Location = new Point(10, 10);
            pnlMaintenanceHeader.Name = "pnlMaintenanceHeader";
            pnlMaintenanceHeader.Size = new Size(1280, 85);
            pnlMaintenanceHeader.TabIndex = 0;
            // 
            // lblMaintenanceTitle
            // 
            lblMaintenanceTitle.BorderStyle = BorderStyle.FixedSingle;
            lblMaintenanceTitle.Dock = DockStyle.Fill;
            lblMaintenanceTitle.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceTitle.ForeColor = Color.White;
            lblMaintenanceTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMaintenanceTitle.Location = new Point(0, 0);
            lblMaintenanceTitle.Name = "lblMaintenanceTitle";
            lblMaintenanceTitle.Size = new Size(1278, 83);
            lblMaintenanceTitle.TabIndex = 6;
            lblMaintenanceTitle.Text = "Maintenance";
            lblMaintenanceTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMaintenanceHeaderContent
            // 
            pnlMaintenanceHeaderContent.BorderStyle = BorderStyle.FixedSingle;
            pnlMaintenanceHeaderContent.Controls.Add(cboMaintenanceStatus);
            pnlMaintenanceHeaderContent.Controls.Add(btnAddIssue);
            pnlMaintenanceHeaderContent.Dock = DockStyle.Top;
            pnlMaintenanceHeaderContent.Location = new Point(10, 95);
            pnlMaintenanceHeaderContent.Name = "pnlMaintenanceHeaderContent";
            pnlMaintenanceHeaderContent.Padding = new Padding(10);
            pnlMaintenanceHeaderContent.Size = new Size(1280, 50);
            pnlMaintenanceHeaderContent.TabIndex = 1;
            // 
            // cboMaintenanceStatus
            // 
            cboMaintenanceStatus.Dock = DockStyle.Right;
            cboMaintenanceStatus.FormattingEnabled = true;
            cboMaintenanceStatus.Location = new Point(1117, 10);
            cboMaintenanceStatus.Name = "cboMaintenanceStatus";
            cboMaintenanceStatus.Size = new Size(151, 28);
            cboMaintenanceStatus.TabIndex = 2;
            // 
            // btnAddIssue
            // 
            btnAddIssue.Cursor = Cursors.Hand;
            btnAddIssue.Dock = DockStyle.Left;
            btnAddIssue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddIssue.Location = new Point(10, 10);
            btnAddIssue.Name = "btnAddIssue";
            btnAddIssue.Size = new Size(125, 28);
            btnAddIssue.TabIndex = 1;
            btnAddIssue.Text = "Add Issue";
            btnAddIssue.UseVisualStyleBackColor = true;
            // 
            // pnlMaintenanceContent
            // 
            pnlMaintenanceContent.BorderStyle = BorderStyle.FixedSingle;
            pnlMaintenanceContent.Controls.Add(flpMaintenanceIssues);
            pnlMaintenanceContent.Dock = DockStyle.Fill;
            pnlMaintenanceContent.Location = new Point(10, 145);
            pnlMaintenanceContent.Name = "pnlMaintenanceContent";
            pnlMaintenanceContent.Size = new Size(1280, 595);
            pnlMaintenanceContent.TabIndex = 2;
            // 
            // flpMaintenanceIssues
            // 
            flpMaintenanceIssues.Dock = DockStyle.Fill;
            flpMaintenanceIssues.FlowDirection = FlowDirection.TopDown;
            flpMaintenanceIssues.Location = new Point(0, 0);
            flpMaintenanceIssues.Name = "flpMaintenanceIssues";
            flpMaintenanceIssues.Size = new Size(1278, 593);
            flpMaintenanceIssues.TabIndex = 0;
            flpMaintenanceIssues.WrapContents = false;
            // 
            // MaintenanceControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 50);
            Controls.Add(pnlMaintenanceContent);
            Controls.Add(pnlMaintenanceHeaderContent);
            Controls.Add(pnlMaintenanceHeader);
            Name = "MaintenanceControl";
            Padding = new Padding(10);
            Size = new Size(1300, 750);
            pnlMaintenanceHeader.ResumeLayout(false);
            pnlMaintenanceHeaderContent.ResumeLayout(false);
            pnlMaintenanceContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMaintenanceHeader;
        private Panel pnlMaintenanceHeaderContent;
        private Panel pnlMaintenanceContent;
        private FlowLayoutPanel flpMaintenanceIssues;
        private ComboBox cboMaintenanceStatus;
        private Button btnAddIssue;
        private Label lblMaintenanceTitle;
    }
}
