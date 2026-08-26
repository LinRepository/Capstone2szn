namespace Capstoneszn.Forms
{
    partial class SetCapacityForm
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
            pnlCapacityHeader = new Panel();
            pnlCapacityActions = new Panel();
            pnlCapacityContent = new Panel();
            lblCapacityTitle = new Label();
            lblCurrentCapacity = new Label();
            lblNewCapacity = new Label();
            btnCancelCapacity = new Button();
            btnSaveCapacity = new Button();
            lblCurrentCapacityValue = new Label();
            nudNewCapacity = new NumericUpDown();
            pnlCapacityHeader.SuspendLayout();
            pnlCapacityActions.SuspendLayout();
            pnlCapacityContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNewCapacity).BeginInit();
            SuspendLayout();
            // 
            // pnlCapacityHeader
            // 
            pnlCapacityHeader.Controls.Add(lblCapacityTitle);
            pnlCapacityHeader.Dock = DockStyle.Top;
            pnlCapacityHeader.Location = new Point(0, 0);
            pnlCapacityHeader.Name = "pnlCapacityHeader";
            pnlCapacityHeader.Size = new Size(282, 40);
            pnlCapacityHeader.TabIndex = 0;
            // 
            // pnlCapacityActions
            // 
            pnlCapacityActions.Controls.Add(btnSaveCapacity);
            pnlCapacityActions.Controls.Add(btnCancelCapacity);
            pnlCapacityActions.Dock = DockStyle.Bottom;
            pnlCapacityActions.Location = new Point(0, 213);
            pnlCapacityActions.Name = "pnlCapacityActions";
            pnlCapacityActions.Size = new Size(282, 40);
            pnlCapacityActions.TabIndex = 1;
            // 
            // pnlCapacityContent
            // 
            pnlCapacityContent.Controls.Add(nudNewCapacity);
            pnlCapacityContent.Controls.Add(lblCurrentCapacityValue);
            pnlCapacityContent.Controls.Add(lblNewCapacity);
            pnlCapacityContent.Controls.Add(lblCurrentCapacity);
            pnlCapacityContent.Dock = DockStyle.Fill;
            pnlCapacityContent.Location = new Point(0, 40);
            pnlCapacityContent.Name = "pnlCapacityContent";
            pnlCapacityContent.Size = new Size(282, 173);
            pnlCapacityContent.TabIndex = 2;
            // 
            // lblCapacityTitle
            // 
            lblCapacityTitle.AutoSize = true;
            lblCapacityTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapacityTitle.ForeColor = Color.White;
            lblCapacityTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblCapacityTitle.Location = new Point(65, 9);
            lblCapacityTitle.Name = "lblCapacityTitle";
            lblCapacityTitle.Size = new Size(162, 25);
            lblCapacityTitle.TabIndex = 34;
            lblCapacityTitle.Text = "Set Room Capacity";
            lblCapacityTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblCapacityTitle.Visible = false;
            // 
            // lblCurrentCapacity
            // 
            lblCurrentCapacity.AutoSize = true;
            lblCurrentCapacity.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentCapacity.ForeColor = Color.White;
            lblCurrentCapacity.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentCapacity.Location = new Point(67, 15);
            lblCurrentCapacity.Name = "lblCurrentCapacity";
            lblCurrentCapacity.Size = new Size(138, 23);
            lblCurrentCapacity.TabIndex = 35;
            lblCurrentCapacity.Text = "Current Capacity";
            lblCurrentCapacity.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentCapacity.Visible = false;
            // 
            // lblNewCapacity
            // 
            lblNewCapacity.AutoSize = true;
            lblNewCapacity.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewCapacity.ForeColor = Color.White;
            lblNewCapacity.ImageAlign = ContentAlignment.MiddleRight;
            lblNewCapacity.Location = new Point(83, 81);
            lblNewCapacity.Name = "lblNewCapacity";
            lblNewCapacity.Size = new Size(114, 23);
            lblNewCapacity.TabIndex = 36;
            lblNewCapacity.Text = "New Capacity";
            lblNewCapacity.TextAlign = ContentAlignment.MiddleCenter;
            lblNewCapacity.Visible = false;
            // 
            // btnCancelCapacity
            // 
            btnCancelCapacity.Location = new Point(46, 8);
            btnCancelCapacity.Name = "btnCancelCapacity";
            btnCancelCapacity.Size = new Size(94, 29);
            btnCancelCapacity.TabIndex = 0;
            btnCancelCapacity.Text = "Cancel";
            btnCancelCapacity.UseVisualStyleBackColor = true;
            // 
            // btnSaveCapacity
            // 
            btnSaveCapacity.Location = new Point(148, 8);
            btnSaveCapacity.Name = "btnSaveCapacity";
            btnSaveCapacity.Size = new Size(125, 29);
            btnSaveCapacity.TabIndex = 1;
            btnSaveCapacity.Text = "Save Capacity";
            btnSaveCapacity.UseVisualStyleBackColor = true;
            // 
            // lblCurrentCapacityValue
            // 
            lblCurrentCapacityValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentCapacityValue.ForeColor = Color.White;
            lblCurrentCapacityValue.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentCapacityValue.Location = new Point(67, 43);
            lblCurrentCapacityValue.Name = "lblCurrentCapacityValue";
            lblCurrentCapacityValue.Size = new Size(138, 23);
            lblCurrentCapacityValue.TabIndex = 37;
            lblCurrentCapacityValue.Text = "-";
            lblCurrentCapacityValue.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentCapacityValue.Visible = false;
            // 
            // nudNewCapacity
            // 
            nudNewCapacity.Location = new Point(66, 108);
            nudNewCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNewCapacity.Name = "nudNewCapacity";
            nudNewCapacity.Size = new Size(150, 27);
            nudNewCapacity.TabIndex = 38;
            nudNewCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SetCapacityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(282, 253);
            Controls.Add(pnlCapacityContent);
            Controls.Add(pnlCapacityActions);
            Controls.Add(pnlCapacityHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetCapacityForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set Capacity";
            pnlCapacityHeader.ResumeLayout(false);
            pnlCapacityHeader.PerformLayout();
            pnlCapacityActions.ResumeLayout(false);
            pnlCapacityContent.ResumeLayout(false);
            pnlCapacityContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNewCapacity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCapacityHeader;
        private Panel pnlCapacityActions;
        private Panel pnlCapacityContent;
        private Label lblCapacityTitle;
        private Label lblCurrentCapacity;
        private Button btnSaveCapacity;
        private Button btnCancelCapacity;
        private NumericUpDown nudNewCapacity;
        private Label lblCurrentCapacityValue;
        private Label lblNewCapacity;
    }
}