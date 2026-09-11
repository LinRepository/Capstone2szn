namespace Capstoneszn.Forms.UserControls.Settings
{
    partial class SalaryControl
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
            pnlSalaryHeader = new Panel();
            pnlSalaryContent = new Panel();
            pnlSalaryCenter = new Panel();
            pnlSalaryInput = new Panel();
            txtEmployeeSalary = new TextBox();
            pnlSalaryActionButtons = new Panel();
            btnSalaryCancel = new Button();
            btnSalarySave = new Button();
            pnlSalaryCenterHeader = new Panel();
            lblCurrentSalary = new Label();
            lblSalaryEmployees = new Label();
            btnBackSalary = new Button();
            lblSalaryTitle = new Label();
            pnlSalaryHeader.SuspendLayout();
            pnlSalaryContent.SuspendLayout();
            pnlSalaryCenter.SuspendLayout();
            pnlSalaryInput.SuspendLayout();
            pnlSalaryActionButtons.SuspendLayout();
            pnlSalaryCenterHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSalaryHeader
            // 
            pnlSalaryHeader.Controls.Add(lblSalaryTitle);
            pnlSalaryHeader.Controls.Add(btnBackSalary);
            pnlSalaryHeader.Dock = DockStyle.Top;
            pnlSalaryHeader.Location = new Point(0, 0);
            pnlSalaryHeader.Name = "pnlSalaryHeader";
            pnlSalaryHeader.Size = new Size(1300, 100);
            pnlSalaryHeader.TabIndex = 0;
            // 
            // pnlSalaryContent
            // 
            pnlSalaryContent.Controls.Add(pnlSalaryCenter);
            pnlSalaryContent.Dock = DockStyle.Fill;
            pnlSalaryContent.Location = new Point(0, 100);
            pnlSalaryContent.Name = "pnlSalaryContent";
            pnlSalaryContent.Size = new Size(1300, 650);
            pnlSalaryContent.TabIndex = 1;
            // 
            // pnlSalaryCenter
            // 
            pnlSalaryCenter.Anchor = AnchorStyles.None;
            pnlSalaryCenter.BorderStyle = BorderStyle.FixedSingle;
            pnlSalaryCenter.Controls.Add(pnlSalaryInput);
            pnlSalaryCenter.Controls.Add(pnlSalaryActionButtons);
            pnlSalaryCenter.Controls.Add(pnlSalaryCenterHeader);
            pnlSalaryCenter.Location = new Point(352, 145);
            pnlSalaryCenter.Name = "pnlSalaryCenter";
            pnlSalaryCenter.Size = new Size(600, 300);
            pnlSalaryCenter.TabIndex = 13;
            // 
            // pnlSalaryInput
            // 
            pnlSalaryInput.Controls.Add(txtEmployeeSalary);
            pnlSalaryInput.Dock = DockStyle.Fill;
            pnlSalaryInput.Location = new Point(0, 100);
            pnlSalaryInput.Name = "pnlSalaryInput";
            pnlSalaryInput.Size = new Size(598, 123);
            pnlSalaryInput.TabIndex = 2;
            // 
            // txtEmployeeSalary
            // 
            txtEmployeeSalary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtEmployeeSalary.Location = new Point(180, 45);
            txtEmployeeSalary.Multiline = true;
            txtEmployeeSalary.Name = "txtEmployeeSalary";
            txtEmployeeSalary.Size = new Size(250, 40);
            txtEmployeeSalary.TabIndex = 9;
            // 
            // pnlSalaryActionButtons
            // 
            pnlSalaryActionButtons.Controls.Add(btnSalaryCancel);
            pnlSalaryActionButtons.Controls.Add(btnSalarySave);
            pnlSalaryActionButtons.Dock = DockStyle.Bottom;
            pnlSalaryActionButtons.Location = new Point(0, 223);
            pnlSalaryActionButtons.Name = "pnlSalaryActionButtons";
            pnlSalaryActionButtons.Size = new Size(598, 75);
            pnlSalaryActionButtons.TabIndex = 1;
            // 
            // btnSalaryCancel
            // 
            btnSalaryCancel.Location = new Point(477, 19);
            btnSalaryCancel.Name = "btnSalaryCancel";
            btnSalaryCancel.Size = new Size(100, 40);
            btnSalaryCancel.TabIndex = 11;
            btnSalaryCancel.Text = "Cancel";
            btnSalaryCancel.UseVisualStyleBackColor = true;
            // 
            // btnSalarySave
            // 
            btnSalarySave.Location = new Point(359, 19);
            btnSalarySave.Name = "btnSalarySave";
            btnSalarySave.Size = new Size(100, 40);
            btnSalarySave.TabIndex = 10;
            btnSalarySave.Text = "Save";
            btnSalarySave.UseVisualStyleBackColor = true;
            // 
            // pnlSalaryCenterHeader
            // 
            pnlSalaryCenterHeader.Controls.Add(lblCurrentSalary);
            pnlSalaryCenterHeader.Controls.Add(lblSalaryEmployees);
            pnlSalaryCenterHeader.Dock = DockStyle.Top;
            pnlSalaryCenterHeader.Location = new Point(0, 0);
            pnlSalaryCenterHeader.Name = "pnlSalaryCenterHeader";
            pnlSalaryCenterHeader.Size = new Size(598, 100);
            pnlSalaryCenterHeader.TabIndex = 0;
            // 
            // lblCurrentSalary
            // 
            lblCurrentSalary.Dock = DockStyle.Fill;
            lblCurrentSalary.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentSalary.ForeColor = Color.White;
            lblCurrentSalary.ImageAlign = ContentAlignment.MiddleRight;
            lblCurrentSalary.Location = new Point(0, 53);
            lblCurrentSalary.Name = "lblCurrentSalary";
            lblCurrentSalary.Size = new Size(598, 47);
            lblCurrentSalary.TabIndex = 13;
            lblCurrentSalary.Text = "Current Salary:";
            lblCurrentSalary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSalaryEmployees
            // 
            lblSalaryEmployees.Dock = DockStyle.Top;
            lblSalaryEmployees.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSalaryEmployees.ForeColor = Color.White;
            lblSalaryEmployees.ImageAlign = ContentAlignment.MiddleRight;
            lblSalaryEmployees.Location = new Point(0, 0);
            lblSalaryEmployees.Name = "lblSalaryEmployees";
            lblSalaryEmployees.Size = new Size(598, 53);
            lblSalaryEmployees.TabIndex = 8;
            lblSalaryEmployees.Text = "Enter the salary of employess";
            lblSalaryEmployees.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackSalary
            // 
            btnBackSalary.Cursor = Cursors.Hand;
            btnBackSalary.Dock = DockStyle.Left;
            btnBackSalary.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackSalary.Location = new Point(0, 0);
            btnBackSalary.Margin = new Padding(0);
            btnBackSalary.Name = "btnBackSalary";
            btnBackSalary.Size = new Size(140, 100);
            btnBackSalary.TabIndex = 8;
            btnBackSalary.Text = "←";
            btnBackSalary.TextAlign = ContentAlignment.TopCenter;
            btnBackSalary.UseVisualStyleBackColor = true;
            // 
            // lblSalaryTitle
            // 
            lblSalaryTitle.Dock = DockStyle.Fill;
            lblSalaryTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSalaryTitle.ForeColor = Color.White;
            lblSalaryTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblSalaryTitle.Location = new Point(140, 0);
            lblSalaryTitle.Name = "lblSalaryTitle";
            lblSalaryTitle.Size = new Size(1160, 100);
            lblSalaryTitle.TabIndex = 9;
            lblSalaryTitle.Text = "Salary";
            lblSalaryTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SalaryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlSalaryContent);
            Controls.Add(pnlSalaryHeader);
            Name = "SalaryControl";
            Size = new Size(1300, 750);
            pnlSalaryHeader.ResumeLayout(false);
            pnlSalaryContent.ResumeLayout(false);
            pnlSalaryCenter.ResumeLayout(false);
            pnlSalaryInput.ResumeLayout(false);
            pnlSalaryInput.PerformLayout();
            pnlSalaryActionButtons.ResumeLayout(false);
            pnlSalaryCenterHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSalaryHeader;
        private Panel pnlSalaryContent;
        private Label lblSalaryEmployees;
        private Button btnSalaryCancel;
        private Button btnSalarySave;
        private TextBox txtEmployeeSalary;
        private Panel pnlSalaryCenter;
        private Panel pnlSalaryInput;
        private Panel pnlSalaryActionButtons;
        private Panel pnlSalaryCenterHeader;
        private Label lblCurrentSalary;
        private Label lblSalaryTitle;
        private Button btnBackSalary;
    }
}
