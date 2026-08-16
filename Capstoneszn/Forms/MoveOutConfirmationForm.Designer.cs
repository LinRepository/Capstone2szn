namespace Capstoneszn.UserControls
{
    partial class MoveOutConfirmationForm
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
            pnlConfirmation = new Panel();
            lblConfirmation = new Label();
            btnCancelConfirmation = new Button();
            btnConfirmMoveOut = new Button();
            pnlConfirmation.SuspendLayout();
            SuspendLayout();
            // 
            // pnlConfirmation
            // 
            pnlConfirmation.Controls.Add(btnConfirmMoveOut);
            pnlConfirmation.Controls.Add(btnCancelConfirmation);
            pnlConfirmation.Controls.Add(lblConfirmation);
            pnlConfirmation.Dock = DockStyle.Fill;
            pnlConfirmation.Location = new Point(0, 0);
            pnlConfirmation.Name = "pnlConfirmation";
            pnlConfirmation.Size = new Size(432, 253);
            pnlConfirmation.TabIndex = 0;
            // 
            // lblConfirmation
            // 
            lblConfirmation.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmation.ForeColor = Color.White;
            lblConfirmation.ImageAlign = ContentAlignment.MiddleRight;
            lblConfirmation.Location = new Point(127, 73);
            lblConfirmation.Margin = new Padding(0);
            lblConfirmation.Name = "lblConfirmation";
            lblConfirmation.Size = new Size(169, 25);
            lblConfirmation.TabIndex = 27;
            lblConfirmation.Text = "Confirm Move Out?";
            lblConfirmation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancelConfirmation
            // 
            btnCancelConfirmation.Location = new Point(100, 172);
            btnCancelConfirmation.Name = "btnCancelConfirmation";
            btnCancelConfirmation.Size = new Size(94, 29);
            btnCancelConfirmation.TabIndex = 28;
            btnCancelConfirmation.Text = "Cancel";
            btnCancelConfirmation.UseVisualStyleBackColor = true;
            // 
            // btnConfirmMoveOut
            // 
            btnConfirmMoveOut.Location = new Point(235, 172);
            btnConfirmMoveOut.Name = "btnConfirmMoveOut";
            btnConfirmMoveOut.Size = new Size(94, 29);
            btnConfirmMoveOut.TabIndex = 29;
            btnConfirmMoveOut.Text = "Confirm";
            btnConfirmMoveOut.UseVisualStyleBackColor = true;
            // 
            // MoveOutConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(432, 253);
            Controls.Add(pnlConfirmation);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveOutConfirmationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Move Out";
            pnlConfirmation.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlConfirmation;
        private Button btnConfirmMoveOut;
        private Button btnCancelConfirmation;
        private Label lblConfirmation;
    }
}