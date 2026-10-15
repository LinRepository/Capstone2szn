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
            pnlConfirmationHeader = new Panel();
            lblConfirmationTitle = new Label();
            pnlConfirmation = new Panel();
            lblConfirmation = new Label();
            pnlWarning = new Panel();
            lblIrreversible = new Label();
            pnlConfirmationActions = new Panel();
            btnConfirmMoveOut = new Button();
            btnCancelConfirmation = new Button();
            pnlConfirmationHeader.SuspendLayout();
            pnlConfirmation.SuspendLayout();
            pnlWarning.SuspendLayout();
            pnlConfirmationActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlConfirmationHeader
            // 
            pnlConfirmationHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlConfirmationHeader.Controls.Add(lblConfirmationTitle);
            pnlConfirmationHeader.Dock = DockStyle.Top;
            pnlConfirmationHeader.Location = new Point(0, 0);
            pnlConfirmationHeader.Name = "pnlConfirmationHeader";
            pnlConfirmationHeader.Size = new Size(560, 60);
            pnlConfirmationHeader.TabIndex = 0;
            // 
            // lblConfirmationTitle
            // 
            lblConfirmationTitle.Dock = DockStyle.Fill;
            lblConfirmationTitle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmationTitle.ForeColor = Color.White;
            lblConfirmationTitle.Location = new Point(0, 0);
            lblConfirmationTitle.Margin = new Padding(0);
            lblConfirmationTitle.Name = "lblConfirmationTitle";
            lblConfirmationTitle.Size = new Size(558, 58);
            lblConfirmationTitle.TabIndex = 0;
            lblConfirmationTitle.Text = "Confirm Move Out";
            lblConfirmationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlConfirmation
            // 
            pnlConfirmation.Controls.Add(lblConfirmation);
            pnlConfirmation.Dock = DockStyle.Fill;
            pnlConfirmation.Location = new Point(0, 60);
            pnlConfirmation.Name = "pnlConfirmation";
            pnlConfirmation.Padding = new Padding(22, 18, 22, 10);
            pnlConfirmation.Size = new Size(560, 240);
            pnlConfirmation.TabIndex = 1;
            // 
            // lblConfirmation
            // 
            lblConfirmation.Dock = DockStyle.Fill;
            lblConfirmation.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmation.ForeColor = Color.White;
            lblConfirmation.Location = new Point(22, 18);
            lblConfirmation.Margin = new Padding(0);
            lblConfirmation.Name = "lblConfirmation";
            lblConfirmation.Size = new Size(516, 212);
            lblConfirmation.TabIndex = 0;
            lblConfirmation.Text = "-";
            // 
            // pnlWarning
            // 
            pnlWarning.Controls.Add(lblIrreversible);
            pnlWarning.Dock = DockStyle.Bottom;
            pnlWarning.Location = new Point(0, 300);
            pnlWarning.Name = "pnlWarning";
            pnlWarning.Padding = new Padding(22, 0, 22, 0);
            pnlWarning.Size = new Size(560, 55);
            pnlWarning.TabIndex = 2;
            // 
            // lblIrreversible
            // 
            lblIrreversible.Dock = DockStyle.Fill;
            lblIrreversible.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIrreversible.ForeColor = Color.Gold;
            lblIrreversible.Location = new Point(22, 0);
            lblIrreversible.Margin = new Padding(0);
            lblIrreversible.Name = "lblIrreversible";
            lblIrreversible.Size = new Size(516, 55);
            lblIrreversible.TabIndex = 0;
            lblIrreversible.Text = "-";
            lblIrreversible.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlConfirmationActions
            // 
            pnlConfirmationActions.Controls.Add(btnConfirmMoveOut);
            pnlConfirmationActions.Controls.Add(btnCancelConfirmation);
            pnlConfirmationActions.Dock = DockStyle.Bottom;
            pnlConfirmationActions.Location = new Point(0, 355);
            pnlConfirmationActions.Name = "pnlConfirmationActions";
            pnlConfirmationActions.Size = new Size(560, 65);
            pnlConfirmationActions.TabIndex = 3;
            // 
            // btnConfirmMoveOut
            // 
            btnConfirmMoveOut.Cursor = Cursors.Hand;
            btnConfirmMoveOut.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirmMoveOut.Location = new Point(420, 14);
            btnConfirmMoveOut.Name = "btnConfirmMoveOut";
            btnConfirmMoveOut.Size = new Size(120, 36);
            btnConfirmMoveOut.TabIndex = 1;
            btnConfirmMoveOut.Text = "Confirm";
            btnConfirmMoveOut.UseVisualStyleBackColor = true;
            btnConfirmMoveOut.Click += btnConfirmMoveOut_Click;
            // 
            // btnCancelConfirmation
            // 
            btnCancelConfirmation.Cursor = Cursors.Hand;
            btnCancelConfirmation.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelConfirmation.Location = new Point(290, 14);
            btnCancelConfirmation.Name = "btnCancelConfirmation";
            btnCancelConfirmation.Size = new Size(120, 36);
            btnCancelConfirmation.TabIndex = 0;
            btnCancelConfirmation.Text = "Cancel";
            btnCancelConfirmation.UseVisualStyleBackColor = true;
            btnCancelConfirmation.Click += btnCancelConfirmation_Click;
            // 
            // MoveOutConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            CancelButton = btnCancelConfirmation;
            ClientSize = new Size(560, 420);
            Controls.Add(pnlConfirmation);
            Controls.Add(pnlWarning);
            Controls.Add(pnlConfirmationActions);
            Controls.Add(pnlConfirmationHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveOutConfirmationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Move Out";
            pnlConfirmationHeader.ResumeLayout(false);
            pnlConfirmation.ResumeLayout(false);
            pnlWarning.ResumeLayout(false);
            pnlConfirmationActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlConfirmationHeader;
        private Label lblConfirmationTitle;
        private Panel pnlConfirmation;
        private Label lblConfirmation;
        private Panel pnlWarning;
        private Label lblIrreversible;
        private Panel pnlConfirmationActions;
        private Button btnConfirmMoveOut;
        private Button btnCancelConfirmation;
    }
}