namespace Capstoneszn.Forms.UserControls
{
    partial class MaintenanceIssueControl
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
            pnlIssueRow = new Panel();
            tblIssueInfo = new TableLayoutPanel();
            pnlIssueActions = new Panel();
            btnDeleteIssue = new Button();
            btnEditIssue = new Button();
            btnViewMaterials = new Button();
            pnlIssueRow.SuspendLayout();
            pnlIssueActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlIssueRow
            // 
            pnlIssueRow.Controls.Add(tblIssueInfo);
            pnlIssueRow.Controls.Add(pnlIssueActions);
            pnlIssueRow.Dock = DockStyle.Fill;
            pnlIssueRow.Location = new Point(0, 0);
            pnlIssueRow.Name = "pnlIssueRow";
            pnlIssueRow.Size = new Size(857, 213);
            pnlIssueRow.TabIndex = 0;
            // 
            // tblIssueInfo
            // 
            tblIssueInfo.ColumnCount = 6;
            tblIssueInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tblIssueInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tblIssueInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tblIssueInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
            tblIssueInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            tblIssueInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tblIssueInfo.Dock = DockStyle.Fill;
            tblIssueInfo.Location = new Point(0, 0);
            tblIssueInfo.Name = "tblIssueInfo";
            tblIssueInfo.RowCount = 2;
            tblIssueInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblIssueInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblIssueInfo.Size = new Size(704, 213);
            tblIssueInfo.TabIndex = 2;
            // 
            // pnlIssueActions
            // 
            pnlIssueActions.Controls.Add(btnDeleteIssue);
            pnlIssueActions.Controls.Add(btnEditIssue);
            pnlIssueActions.Controls.Add(btnViewMaterials);
            pnlIssueActions.Dock = DockStyle.Right;
            pnlIssueActions.Location = new Point(704, 0);
            pnlIssueActions.Name = "pnlIssueActions";
            pnlIssueActions.Size = new Size(153, 213);
            pnlIssueActions.TabIndex = 1;
            // 
            // btnDeleteIssue
            // 
            btnDeleteIssue.Location = new Point(35, 121);
            btnDeleteIssue.Name = "btnDeleteIssue";
            btnDeleteIssue.Size = new Size(94, 29);
            btnDeleteIssue.TabIndex = 2;
            btnDeleteIssue.Text = "Delete";
            btnDeleteIssue.UseVisualStyleBackColor = true;
            // 
            // btnEditIssue
            // 
            btnEditIssue.Location = new Point(35, 68);
            btnEditIssue.Name = "btnEditIssue";
            btnEditIssue.Size = new Size(94, 29);
            btnEditIssue.TabIndex = 1;
            btnEditIssue.Text = "Edit";
            btnEditIssue.UseVisualStyleBackColor = true;
            // 
            // btnViewMaterials
            // 
            btnViewMaterials.Location = new Point(35, 15);
            btnViewMaterials.Name = "btnViewMaterials";
            btnViewMaterials.Size = new Size(94, 29);
            btnViewMaterials.TabIndex = 0;
            btnViewMaterials.Text = "View Materials";
            btnViewMaterials.UseVisualStyleBackColor = true;
            // 
            // MaintenanceIssueControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlIssueRow);
            Cursor = Cursors.Hand;
            Name = "MaintenanceIssueControl";
            Size = new Size(857, 213);
            pnlIssueRow.ResumeLayout(false);
            pnlIssueActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlIssueRow;
        private Panel pnlIssueActions;
        private Button btnDeleteIssue;
        private Button btnEditIssue;
        private Button btnViewMaterials;
        private TableLayoutPanel tblIssueInfo;
    }
}
