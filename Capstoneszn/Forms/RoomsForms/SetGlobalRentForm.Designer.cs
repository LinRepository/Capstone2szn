namespace Capstoneszn.Forms
{
    partial class SetGlobalRentForm
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
            pnlGlobalRentHeader = new Panel();
            lblGlobalRentTitle = new Label();
            lblGlobalRentDescription = new Label();
            pnlGlobalRentActions = new Panel();
            btnApplyGlobalRent = new Button();
            btnCancelGlobalRent = new Button();
            pnlGlobalRentContent = new Panel();
            lblNewRent = new Label();
            lblCurrentRentValue = new Label();
            lblCurrentRent = new Label();
            lblRentInfoOne = new Label();
            nudNewRent = new NumericUpDown();
            lblRentInfoTwo = new Label();
            pnlGlobalRentHeader.SuspendLayout();
            pnlGlobalRentActions.SuspendLayout();
            pnlGlobalRentContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNewRent).BeginInit();
            SuspendLayout();
            // 
            // pnlGlobalRentHeader
            // 
            pnlGlobalRentHeader.Controls.Add(lblGlobalRentTitle);
            pnlGlobalRentHeader.Controls.Add(lblGlobalRentDescription);
            pnlGlobalRentHeader.Dock = DockStyle.Top;
            pnlGlobalRentHeader.Location = new Point(0, 0);
            pnlGlobalRentHeader.Name = "pnlGlobalRentHeader";
            pnlGlobalRentHeader.Size = new Size(382, 65);
            pnlGlobalRentHeader.TabIndex = 0;
            // 
            // lblGlobalRentTitle
            // 
            lblGlobalRentTitle.AutoSize = true;
            lblGlobalRentTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGlobalRentTitle.ForeColor = Color.White;
            lblGlobalRentTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblGlobalRentTitle.Location = new Point(119, 9);
            lblGlobalRentTitle.Name = "lblGlobalRentTitle";
            lblGlobalRentTitle.Size = new Size(147, 28);
            lblGlobalRentTitle.TabIndex = 25;
            lblGlobalRentTitle.Text = "Set Global Rent";
            lblGlobalRentTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblGlobalRentTitle.Visible = false;
            // 
            // lblGlobalRentDescription
            // 
            lblGlobalRentDescription.AutoSize = true;
            lblGlobalRentDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGlobalRentDescription.ForeColor = Color.White;
            lblGlobalRentDescription.ImageAlign = ContentAlignment.MiddleRight;
            lblGlobalRentDescription.Location = new Point(41, 37);
            lblGlobalRentDescription.Name = "lblGlobalRentDescription";
            lblGlobalRentDescription.Size = new Size(305, 20);
            lblGlobalRentDescription.TabIndex = 26;
            lblGlobalRentDescription.Text = "Update the standard monthly rent for rooms.";
            lblGlobalRentDescription.TextAlign = ContentAlignment.MiddleCenter;
            lblGlobalRentDescription.Visible = false;
            // 
            // pnlGlobalRentActions
            // 
            pnlGlobalRentActions.Controls.Add(btnApplyGlobalRent);
            pnlGlobalRentActions.Controls.Add(btnCancelGlobalRent);
            pnlGlobalRentActions.Dock = DockStyle.Bottom;
            pnlGlobalRentActions.Location = new Point(0, 303);
            pnlGlobalRentActions.Name = "pnlGlobalRentActions";
            pnlGlobalRentActions.Size = new Size(382, 50);
            pnlGlobalRentActions.TabIndex = 1;
            // 
            // btnApplyGlobalRent
            // 
            btnApplyGlobalRent.Location = new Point(273, 10);
            btnApplyGlobalRent.Name = "btnApplyGlobalRent";
            btnApplyGlobalRent.Size = new Size(94, 29);
            btnApplyGlobalRent.TabIndex = 1;
            btnApplyGlobalRent.Text = "Apply";
            btnApplyGlobalRent.UseVisualStyleBackColor = true;
            // 
            // btnCancelGlobalRent
            // 
            btnCancelGlobalRent.Location = new Point(162, 10);
            btnCancelGlobalRent.Name = "btnCancelGlobalRent";
            btnCancelGlobalRent.Size = new Size(94, 29);
            btnCancelGlobalRent.TabIndex = 0;
            btnCancelGlobalRent.Text = "Cancel";
            btnCancelGlobalRent.UseVisualStyleBackColor = true;
            // 
            // pnlGlobalRentContent
            // 
            pnlGlobalRentContent.Controls.Add(lblRentInfoTwo);
            pnlGlobalRentContent.Controls.Add(nudNewRent);
            pnlGlobalRentContent.Controls.Add(lblRentInfoOne);
            pnlGlobalRentContent.Controls.Add(lblNewRent);
            pnlGlobalRentContent.Controls.Add(lblCurrentRentValue);
            pnlGlobalRentContent.Controls.Add(lblCurrentRent);
            pnlGlobalRentContent.Dock = DockStyle.Fill;
            pnlGlobalRentContent.Location = new Point(0, 65);
            pnlGlobalRentContent.Name = "pnlGlobalRentContent";
            pnlGlobalRentContent.Size = new Size(382, 238);
            pnlGlobalRentContent.TabIndex = 2;
            // 
            // lblNewRent
            // 
            lblNewRent.AutoSize = true;
            lblNewRent.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewRent.ForeColor = Color.White;
            lblNewRent.ImageAlign = ContentAlignment.MiddleRight;
            lblNewRent.Location = new Point(39, 154);
            lblNewRent.Name = "lblNewRent";
            lblNewRent.Size = new Size(138, 23);
            lblNewRent.TabIndex = 29;
            lblNewRent.Text = "New Global Rent";
            lblNewRent.TextAlign = ContentAlignment.MiddleCenter;
            lblNewRent.Visible = false;
            // 
            // lblCurrentRentValue
            // 
            lblCurrentRentValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentRentValue.ForeColor = Color.White;
            lblCurrentRentValue.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentRentValue.Location = new Point(207, 93);
            lblCurrentRentValue.Name = "lblCurrentRentValue";
            lblCurrentRentValue.Size = new Size(70, 23);
            lblCurrentRentValue.TabIndex = 28;
            lblCurrentRentValue.Text = "₱0.00";
            lblCurrentRentValue.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentRentValue.Visible = false;
            // 
            // lblCurrentRent
            // 
            lblCurrentRent.AutoSize = true;
            lblCurrentRent.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentRent.ForeColor = Color.White;
            lblCurrentRent.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentRent.Location = new Point(39, 93);
            lblCurrentRent.Name = "lblCurrentRent";
            lblCurrentRent.Size = new Size(162, 23);
            lblCurrentRent.TabIndex = 27;
            lblCurrentRent.Text = "Current Global Rent";
            lblCurrentRent.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentRent.Visible = false;
            // 
            // lblRentInfoOne
            // 
            lblRentInfoOne.AutoSize = true;
            lblRentInfoOne.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRentInfoOne.ForeColor = Color.White;
            lblRentInfoOne.ImageAlign = ContentAlignment.MiddleRight;
            lblRentInfoOne.Location = new Point(41, 5);
            lblRentInfoOne.Name = "lblRentInfoOne";
            lblRentInfoOne.Size = new Size(287, 17);
            lblRentInfoOne.TabIndex = 30;
            lblRentInfoOne.Text = "Vacant rooms will use the new rent immediately.";
            lblRentInfoOne.TextAlign = ContentAlignment.MiddleCenter;
            lblRentInfoOne.Visible = false;
            // 
            // nudNewRent
            // 
            nudNewRent.DecimalPlaces = 2;
            nudNewRent.Location = new Point(41, 180);
            nudNewRent.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudNewRent.Name = "nudNewRent";
            nudNewRent.Size = new Size(199, 27);
            nudNewRent.TabIndex = 32;
            nudNewRent.ThousandsSeparator = true;
            // 
            // lblRentInfoTwo
            // 
            lblRentInfoTwo.AutoSize = true;
            lblRentInfoTwo.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRentInfoTwo.ForeColor = Color.White;
            lblRentInfoTwo.ImageAlign = ContentAlignment.MiddleRight;
            lblRentInfoTwo.Location = new Point(34, 29);
            lblRentInfoTwo.Name = "lblRentInfoTwo";
            lblRentInfoTwo.Size = new Size(305, 17);
            lblRentInfoTwo.TabIndex = 33;
            lblRentInfoTwo.Text = "Occupied rooms will use it on the next billing cycle.";
            lblRentInfoTwo.TextAlign = ContentAlignment.MiddleCenter;
            lblRentInfoTwo.Visible = false;
            // 
            // SetGlobalRentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(382, 353);
            Controls.Add(pnlGlobalRentContent);
            Controls.Add(pnlGlobalRentActions);
            Controls.Add(pnlGlobalRentHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetGlobalRentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set Global Rent";
            pnlGlobalRentHeader.ResumeLayout(false);
            pnlGlobalRentHeader.PerformLayout();
            pnlGlobalRentActions.ResumeLayout(false);
            pnlGlobalRentContent.ResumeLayout(false);
            pnlGlobalRentContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNewRent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlGlobalRentHeader;
        private Panel pnlGlobalRentActions;
        private Panel pnlGlobalRentContent;
        private Label lblGlobalRentTitle;
        private Button btnApplyGlobalRent;
        private Button btnCancelGlobalRent;
        private Label lblCurrentRent;
        private Label lblGlobalRentDescription;
        private Label lblNewRent;
        private Label lblCurrentRentValue;
        private Label lblRentInfoOne;
        private NumericUpDown nudNewRent;
        private Label lblRentInfoTwo;
    }
}