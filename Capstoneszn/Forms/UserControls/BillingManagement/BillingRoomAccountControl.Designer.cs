namespace Capstoneszn.Forms.UserControls.BillingManagement
{
    partial class BillingRoomAccountControl
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
            pnlRoomAccountHeader = new Panel();
            btnBackRoomAccount = new Button();
            lblRoomAccountTitle = new Label();
            pnlRoomAccountContent = new Panel();
            flpFloors = new FlowLayoutPanel();
            pnlFloorSection = new Panel();
            lblFloorTitle = new Label();
            flpFloorRooms = new FlowLayoutPanel();
            pnlRoomAccountHeader.SuspendLayout();
            pnlRoomAccountContent.SuspendLayout();
            flpFloors.SuspendLayout();
            pnlFloorSection.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomAccountHeader
            // 
            pnlRoomAccountHeader.Controls.Add(lblRoomAccountTitle);
            pnlRoomAccountHeader.Controls.Add(btnBackRoomAccount);
            pnlRoomAccountHeader.Dock = DockStyle.Top;
            pnlRoomAccountHeader.Location = new Point(0, 0);
            pnlRoomAccountHeader.Name = "pnlRoomAccountHeader";
            pnlRoomAccountHeader.Size = new Size(1300, 90);
            pnlRoomAccountHeader.TabIndex = 0;
            // 
            // btnBackRoomAccount
            // 
            btnBackRoomAccount.Dock = DockStyle.Left;
            btnBackRoomAccount.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackRoomAccount.Location = new Point(0, 0);
            btnBackRoomAccount.Margin = new Padding(0);
            btnBackRoomAccount.Name = "btnBackRoomAccount";
            btnBackRoomAccount.Size = new Size(140, 90);
            btnBackRoomAccount.TabIndex = 0;
            btnBackRoomAccount.Text = "←";
            btnBackRoomAccount.TextAlign = ContentAlignment.TopCenter;
            btnBackRoomAccount.UseVisualStyleBackColor = true;
            // 
            // lblRoomAccountTitle
            // 
            lblRoomAccountTitle.Dock = DockStyle.Fill;
            lblRoomAccountTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomAccountTitle.ForeColor = Color.White;
            lblRoomAccountTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomAccountTitle.Location = new Point(140, 0);
            lblRoomAccountTitle.Name = "lblRoomAccountTitle";
            lblRoomAccountTitle.Size = new Size(1160, 90);
            lblRoomAccountTitle.TabIndex = 5;
            lblRoomAccountTitle.Text = "Rooms";
            lblRoomAccountTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomAccountContent
            // 
            pnlRoomAccountContent.Controls.Add(flpFloors);
            pnlRoomAccountContent.Dock = DockStyle.Fill;
            pnlRoomAccountContent.Location = new Point(0, 90);
            pnlRoomAccountContent.Name = "pnlRoomAccountContent";
            pnlRoomAccountContent.Padding = new Padding(15);
            pnlRoomAccountContent.Size = new Size(1300, 660);
            pnlRoomAccountContent.TabIndex = 1;
            // 
            // flpFloors
            // 
            flpFloors.AutoScroll = true;
            flpFloors.Controls.Add(pnlFloorSection);
            flpFloors.Dock = DockStyle.Fill;
            flpFloors.Location = new Point(15, 15);
            flpFloors.Name = "flpFloors";
            flpFloors.Padding = new Padding(5);
            flpFloors.Size = new Size(1270, 630);
            flpFloors.TabIndex = 0;
            flpFloors.WrapContents = false;
            // 
            // pnlFloorSection
            // 
            pnlFloorSection.Controls.Add(flpFloorRooms);
            pnlFloorSection.Controls.Add(lblFloorTitle);
            pnlFloorSection.Location = new Point(8, 8);
            pnlFloorSection.Name = "pnlFloorSection";
            pnlFloorSection.Size = new Size(250, 600);
            pnlFloorSection.TabIndex = 0;
            // 
            // lblFloorTitle
            // 
            lblFloorTitle.Dock = DockStyle.Top;
            lblFloorTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloorTitle.ForeColor = Color.White;
            lblFloorTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblFloorTitle.Location = new Point(0, 0);
            lblFloorTitle.Margin = new Padding(0);
            lblFloorTitle.Name = "lblFloorTitle";
            lblFloorTitle.Size = new Size(250, 50);
            lblFloorTitle.TabIndex = 20;
            lblFloorTitle.Text = "FLOOR 1";
            lblFloorTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpFloorRooms
            // 
            flpFloorRooms.AutoScroll = true;
            flpFloorRooms.Dock = DockStyle.Fill;
            flpFloorRooms.FlowDirection = FlowDirection.TopDown;
            flpFloorRooms.Location = new Point(0, 50);
            flpFloorRooms.Name = "flpFloorRooms";
            flpFloorRooms.Padding = new Padding(10);
            flpFloorRooms.Size = new Size(250, 550);
            flpFloorRooms.TabIndex = 21;
            flpFloorRooms.WrapContents = false;
            // 
            // BillingRoomAccountControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            Controls.Add(pnlRoomAccountContent);
            Controls.Add(pnlRoomAccountHeader);
            Name = "BillingRoomAccountControl";
            Size = new Size(1300, 750);
            pnlRoomAccountHeader.ResumeLayout(false);
            pnlRoomAccountContent.ResumeLayout(false);
            flpFloors.ResumeLayout(false);
            pnlFloorSection.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoomAccountHeader;
        private Button btnBackRoomAccount;
        private Label lblRoomAccountTitle;
        private Panel pnlRoomAccountContent;
        private FlowLayoutPanel flpFloors;
        private Panel pnlFloorSection;
        private Label lblFloorTitle;
        private FlowLayoutPanel flpFloorRooms;
    }
}
