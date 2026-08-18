namespace Capstoneszn.Forms
{
    partial class ConfirmPaymentForm
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
            pnlPaymentConfirmation = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            lbabl = new Label();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPaymentConfirmation
            // 
            pnlPaymentConfirmation.Dock = DockStyle.Fill;
            pnlPaymentConfirmation.Location = new Point(0, 65);
            pnlPaymentConfirmation.Name = "pnlPaymentConfirmation";
            pnlPaymentConfirmation.Size = new Size(482, 338);
            pnlPaymentConfirmation.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbabl);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 65);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 403);
            panel2.Name = "panel2";
            panel2.Size = new Size(482, 50);
            panel2.TabIndex = 2;
            // 
            // lbabl
            // 
            lbabl.AutoSize = true;
            lbabl.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbabl.ForeColor = Color.White;
            lbabl.ImageAlign = ContentAlignment.MiddleRight;
            lbabl.Location = new Point(177, 20);
            lbabl.Name = "lbabl";
            lbabl.Size = new Size(149, 25);
            lbabl.TabIndex = 4;
            lbabl.Text = "Confirm Payment";
            lbabl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(246, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(361, 12);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // ConfirmPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(482, 453);
            Controls.Add(pnlPaymentConfirmation);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfirmPaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Payment";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPaymentConfirmation;
        private Panel panel1;
        private Panel panel2;
        private Label lbabl;
        private Button button2;
        private Button button1;
    }
}