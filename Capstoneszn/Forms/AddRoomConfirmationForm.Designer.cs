namespace Capstoneszn.Forms
{
    partial class AddRoomConfirmationForm
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
            pnlAddRoomHeader = new Panel();
            pnlAddRoomActions = new Panel();
            btnCancelAddRoom = new Button();
            btnConfirmAddRoom = new Button();
            pnlAddRoomContent = new Panel();
            lblAddRoomTitle = new Label();
            lblAddRoomNotice = new Label();
            lblAddRoomQuestion = new Label();
            pnlAddRoomHeader.SuspendLayout();
            pnlAddRoomActions.SuspendLayout();
            pnlAddRoomContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAddRoomHeader
            // 
            pnlAddRoomHeader.Controls.Add(lblAddRoomTitle);
            pnlAddRoomHeader.Dock = DockStyle.Top;
            pnlAddRoomHeader.Location = new Point(0, 0);
            pnlAddRoomHeader.Name = "pnlAddRoomHeader";
            pnlAddRoomHeader.Size = new Size(332, 45);
            pnlAddRoomHeader.TabIndex = 0;
            // 
            // pnlAddRoomActions
            // 
            pnlAddRoomActions.Controls.Add(btnConfirmAddRoom);
            pnlAddRoomActions.Controls.Add(btnCancelAddRoom);
            pnlAddRoomActions.Dock = DockStyle.Bottom;
            pnlAddRoomActions.Location = new Point(0, 208);
            pnlAddRoomActions.Name = "pnlAddRoomActions";
            pnlAddRoomActions.Size = new Size(332, 45);
            pnlAddRoomActions.TabIndex = 1;
            // 
            // btnCancelAddRoom
            // 
            btnCancelAddRoom.Location = new Point(108, 8);
            btnCancelAddRoom.Name = "btnCancelAddRoom";
            btnCancelAddRoom.Size = new Size(94, 29);
            btnCancelAddRoom.TabIndex = 0;
            btnCancelAddRoom.Text = "Cancel";
            btnCancelAddRoom.UseVisualStyleBackColor = true;
            // 
            // btnConfirmAddRoom
            // 
            btnConfirmAddRoom.Location = new Point(221, 8);
            btnConfirmAddRoom.Name = "btnConfirmAddRoom";
            btnConfirmAddRoom.Size = new Size(100, 29);
            btnConfirmAddRoom.TabIndex = 1;
            btnConfirmAddRoom.Text = "Add Room";
            btnConfirmAddRoom.UseVisualStyleBackColor = true;
            // 
            // pnlAddRoomContent
            // 
            pnlAddRoomContent.Controls.Add(lblAddRoomQuestion);
            pnlAddRoomContent.Controls.Add(lblAddRoomNotice);
            pnlAddRoomContent.Dock = DockStyle.Fill;
            pnlAddRoomContent.Location = new Point(0, 45);
            pnlAddRoomContent.Name = "pnlAddRoomContent";
            pnlAddRoomContent.Size = new Size(332, 163);
            pnlAddRoomContent.TabIndex = 2;
            // 
            // lblAddRoomTitle
            // 
            lblAddRoomTitle.AutoSize = true;
            lblAddRoomTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddRoomTitle.ForeColor = Color.White;
            lblAddRoomTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblAddRoomTitle.Location = new Point(78, 9);
            lblAddRoomTitle.Name = "lblAddRoomTitle";
            lblAddRoomTitle.Size = new Size(181, 28);
            lblAddRoomTitle.TabIndex = 32;
            lblAddRoomTitle.Text = "Confirm Add Room";
            lblAddRoomTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblAddRoomTitle.Visible = false;
            // 
            // lblAddRoomNotice
            // 
            lblAddRoomNotice.Dock = DockStyle.Bottom;
            lblAddRoomNotice.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddRoomNotice.ForeColor = Color.White;
            lblAddRoomNotice.ImageAlign = ContentAlignment.MiddleRight;
            lblAddRoomNotice.Location = new Point(0, 93);
            lblAddRoomNotice.Name = "lblAddRoomNotice";
            lblAddRoomNotice.Size = new Size(332, 70);
            lblAddRoomNotice.TabIndex = 34;
            lblAddRoomNotice.Text = "The room will be added to Floor #.";
            lblAddRoomNotice.TextAlign = ContentAlignment.MiddleCenter;
            lblAddRoomNotice.Visible = false;
            // 
            // lblAddRoomQuestion
            // 
            lblAddRoomQuestion.Dock = DockStyle.Fill;
            lblAddRoomQuestion.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddRoomQuestion.ForeColor = Color.White;
            lblAddRoomQuestion.ImageAlign = ContentAlignment.MiddleRight;
            lblAddRoomQuestion.Location = new Point(0, 0);
            lblAddRoomQuestion.Name = "lblAddRoomQuestion";
            lblAddRoomQuestion.Size = new Size(332, 93);
            lblAddRoomQuestion.TabIndex = 35;
            lblAddRoomQuestion.Text = "Are you sure you want\r\nto add this room?";
            lblAddRoomQuestion.TextAlign = ContentAlignment.MiddleCenter;
            lblAddRoomQuestion.Visible = false;
            // 
            // AddRoomConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(332, 253);
            Controls.Add(pnlAddRoomContent);
            Controls.Add(pnlAddRoomActions);
            Controls.Add(pnlAddRoomHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddRoomConfirmationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Add Room";
            pnlAddRoomHeader.ResumeLayout(false);
            pnlAddRoomHeader.PerformLayout();
            pnlAddRoomActions.ResumeLayout(false);
            pnlAddRoomContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAddRoomHeader;
        private Panel pnlAddRoomActions;
        private Button btnConfirmAddRoom;
        private Button btnCancelAddRoom;
        private Panel pnlAddRoomContent;
        private Label lblAddRoomTitle;
        private Label lblAddRoomQuestion;
        private Label lblAddRoomNotice;
    }
}