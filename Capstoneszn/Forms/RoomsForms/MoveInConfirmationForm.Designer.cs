namespace Capstoneszn.Forms.RoomsForms
{
    partial class MoveInConfirmationForm
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
            pnlMoveInConfirmationHeader = new Panel();
            lblMoveInConfirmationTitle = new Label();
            pnlMoveInConfirmationContent = new Panel();
            flpTenantInformation = new FlowLayoutPanel();
            pnlMoveInConfirmationBottom = new Panel();
            btnAddAnotherTenant = new Button();
            btnProceedPayment = new Button();
            pnlMoveInConfirmationHeader.SuspendLayout();
            pnlMoveInConfirmationContent.SuspendLayout();
            pnlMoveInConfirmationBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMoveInConfirmationHeader
            // 
            pnlMoveInConfirmationHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlMoveInConfirmationHeader.Controls.Add(lblMoveInConfirmationTitle);
            pnlMoveInConfirmationHeader.Dock = DockStyle.Top;
            pnlMoveInConfirmationHeader.Location = new Point(0, 0);
            pnlMoveInConfirmationHeader.Name = "pnlMoveInConfirmationHeader";
            pnlMoveInConfirmationHeader.Size = new Size(582, 70);
            pnlMoveInConfirmationHeader.TabIndex = 0;
            // 
            // lblMoveInConfirmationTitle
            // 
            lblMoveInConfirmationTitle.Dock = DockStyle.Fill;
            lblMoveInConfirmationTitle.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMoveInConfirmationTitle.ForeColor = Color.White;
            lblMoveInConfirmationTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblMoveInConfirmationTitle.Location = new Point(0, 0);
            lblMoveInConfirmationTitle.Margin = new Padding(0);
            lblMoveInConfirmationTitle.Name = "lblMoveInConfirmationTitle";
            lblMoveInConfirmationTitle.Size = new Size(580, 68);
            lblMoveInConfirmationTitle.TabIndex = 26;
            lblMoveInConfirmationTitle.Text = "Confirm Tenant";
            lblMoveInConfirmationTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMoveInConfirmationContent
            // 
            pnlMoveInConfirmationContent.Controls.Add(flpTenantInformation);
            pnlMoveInConfirmationContent.Dock = DockStyle.Fill;
            pnlMoveInConfirmationContent.Location = new Point(0, 70);
            pnlMoveInConfirmationContent.Name = "pnlMoveInConfirmationContent";
            pnlMoveInConfirmationContent.Size = new Size(582, 483);
            pnlMoveInConfirmationContent.TabIndex = 1;
            // 
            // flpTenantInformation
            // 
            flpTenantInformation.BorderStyle = BorderStyle.FixedSingle;
            flpTenantInformation.Dock = DockStyle.Fill;
            flpTenantInformation.Location = new Point(0, 0);
            flpTenantInformation.Name = "flpTenantInformation";
            flpTenantInformation.Size = new Size(582, 483);
            flpTenantInformation.TabIndex = 0;
            // 
            // pnlMoveInConfirmationBottom
            // 
            pnlMoveInConfirmationBottom.BorderStyle = BorderStyle.FixedSingle;
            pnlMoveInConfirmationBottom.Controls.Add(btnAddAnotherTenant);
            pnlMoveInConfirmationBottom.Controls.Add(btnProceedPayment);
            pnlMoveInConfirmationBottom.Dock = DockStyle.Bottom;
            pnlMoveInConfirmationBottom.Location = new Point(0, 493);
            pnlMoveInConfirmationBottom.Name = "pnlMoveInConfirmationBottom";
            pnlMoveInConfirmationBottom.Size = new Size(582, 60);
            pnlMoveInConfirmationBottom.TabIndex = 2;
            // 
            // btnAddAnotherTenant
            // 
            btnAddAnotherTenant.Location = new Point(212, 15);
            btnAddAnotherTenant.Name = "btnAddAnotherTenant";
            btnAddAnotherTenant.Size = new Size(165, 29);
            btnAddAnotherTenant.TabIndex = 0;
            btnAddAnotherTenant.Text = "Add Another Tenant";
            btnAddAnotherTenant.UseVisualStyleBackColor = true;
            // 
            // btnProceedPayment
            // 
            btnProceedPayment.Location = new Point(401, 15);
            btnProceedPayment.Name = "btnProceedPayment";
            btnProceedPayment.Size = new Size(165, 29);
            btnProceedPayment.TabIndex = 0;
            btnProceedPayment.Text = "Proceed to Payment";
            btnProceedPayment.UseVisualStyleBackColor = true;
            // 
            // MoveInConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(582, 553);
            Controls.Add(pnlMoveInConfirmationBottom);
            Controls.Add(pnlMoveInConfirmationContent);
            Controls.Add(pnlMoveInConfirmationHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveInConfirmationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MoveInConfirmationForm";
            pnlMoveInConfirmationHeader.ResumeLayout(false);
            pnlMoveInConfirmationContent.ResumeLayout(false);
            pnlMoveInConfirmationBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMoveInConfirmationHeader;
        private Panel pnlMoveInConfirmationContent;
        private Panel pnlMoveInConfirmationBottom;
        private FlowLayoutPanel flpTenantInformation;
        private Label lblMoveInConfirmationTitle;
        private Button btnAddAnotherTenant;
        private Button btnProceedPayment;
    }
}