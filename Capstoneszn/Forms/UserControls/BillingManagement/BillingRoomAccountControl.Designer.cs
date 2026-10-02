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
            lblRoomAccountTitle = new Label();
            btnBackRoomAccount = new Button();
            pnlRoomAccountContent = new Panel();
            flpFloors = new FlowLayoutPanel();
            pnlFloorSection1 = new Panel();
            flpFloorRooms1 = new FlowLayoutPanel();
            lblFloorTitle1 = new Label();
            pnlFloorSection2 = new Panel();
            flpFloorRooms2 = new FlowLayoutPanel();
            lblFloorTitle2 = new Label();
            pnlRoomAccountHeader.SuspendLayout();
            pnlRoomAccountContent.SuspendLayout();
            flpFloors.SuspendLayout();
            pnlFloorSection1.SuspendLayout();
            pnlFloorSection2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRoomAccountHeader
            // 
            pnlRoomAccountHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlRoomAccountHeader.Controls.Add(lblRoomAccountTitle);
            pnlRoomAccountHeader.Controls.Add(btnBackRoomAccount);
            pnlRoomAccountHeader.Dock = DockStyle.Top;
            pnlRoomAccountHeader.Location = new Point(0, 0);
            pnlRoomAccountHeader.Name = "pnlRoomAccountHeader";
            pnlRoomAccountHeader.Size = new Size(1300, 90);
            pnlRoomAccountHeader.TabIndex = 0;
            // 
            // lblRoomAccountTitle
            // 
            lblRoomAccountTitle.Dock = DockStyle.Fill;
            lblRoomAccountTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRoomAccountTitle.ForeColor = Color.White;
            lblRoomAccountTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblRoomAccountTitle.Location = new Point(140, 0);
            lblRoomAccountTitle.Name = "lblRoomAccountTitle";
            lblRoomAccountTitle.Size = new Size(1158, 88);
            lblRoomAccountTitle.TabIndex = 5;
            lblRoomAccountTitle.Text = "Rooms";
            lblRoomAccountTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackRoomAccount
            // 
            btnBackRoomAccount.Dock = DockStyle.Left;
            btnBackRoomAccount.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackRoomAccount.Location = new Point(0, 0);
            btnBackRoomAccount.Margin = new Padding(0);
            btnBackRoomAccount.Name = "btnBackRoomAccount";
            btnBackRoomAccount.Size = new Size(140, 88);
            btnBackRoomAccount.TabIndex = 0;
            btnBackRoomAccount.Text = "←";
            btnBackRoomAccount.TextAlign = ContentAlignment.TopCenter;
            btnBackRoomAccount.UseVisualStyleBackColor = true;
            btnBackRoomAccount.Click += btnBackRoomAccount_Click;
            // 
            // pnlRoomAccountContent
            // 
            pnlRoomAccountContent.BorderStyle = BorderStyle.FixedSingle;
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
            flpFloors.BorderStyle = BorderStyle.FixedSingle;
            flpFloors.Controls.Add(pnlFloorSection1);
            flpFloors.Controls.Add(pnlFloorSection2);
            flpFloors.Dock = DockStyle.Fill;
            flpFloors.FlowDirection = FlowDirection.TopDown;
            flpFloors.Location = new Point(15, 15);
            flpFloors.Name = "flpFloors";
            flpFloors.Padding = new Padding(5);
            flpFloors.Size = new Size(1268, 628);
            flpFloors.TabIndex = 0;
            flpFloors.WrapContents = false;
            // 
            // pnlFloorSection1
            // 
            pnlFloorSection1.BorderStyle = BorderStyle.FixedSingle;
            pnlFloorSection1.Controls.Add(flpFloorRooms1);
            pnlFloorSection1.Controls.Add(lblFloorTitle1);
            pnlFloorSection1.Location = new Point(8, 8);
            pnlFloorSection1.Name = "pnlFloorSection1";
            pnlFloorSection1.Padding = new Padding(5);
            pnlFloorSection1.Size = new Size(1250, 200);
            pnlFloorSection1.TabIndex = 0;
            // 
            // flpFloorRooms1
            // 
            flpFloorRooms1.AutoScroll = true;
            flpFloorRooms1.BorderStyle = BorderStyle.FixedSingle;
            flpFloorRooms1.Dock = DockStyle.Fill;
            flpFloorRooms1.FlowDirection = FlowDirection.TopDown;
            flpFloorRooms1.Location = new Point(5, 55);
            flpFloorRooms1.Name = "flpFloorRooms1";
            flpFloorRooms1.Padding = new Padding(10);
            flpFloorRooms1.Size = new Size(1238, 138);
            flpFloorRooms1.TabIndex = 21;
            flpFloorRooms1.WrapContents = false;
            // 
            // lblFloorTitle1
            // 
            lblFloorTitle1.Dock = DockStyle.Top;
            lblFloorTitle1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloorTitle1.ForeColor = Color.White;
            lblFloorTitle1.ImageAlign = ContentAlignment.MiddleRight;
            lblFloorTitle1.Location = new Point(5, 5);
            lblFloorTitle1.Margin = new Padding(0);
            lblFloorTitle1.Name = "lblFloorTitle1";
            lblFloorTitle1.Size = new Size(1238, 50);
            lblFloorTitle1.TabIndex = 20;
            lblFloorTitle1.Text = "FLOOR 1";
            lblFloorTitle1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFloorSection2
            // 
            pnlFloorSection2.BorderStyle = BorderStyle.FixedSingle;
            pnlFloorSection2.Controls.Add(flpFloorRooms2);
            pnlFloorSection2.Controls.Add(lblFloorTitle2);
            pnlFloorSection2.Location = new Point(8, 214);
            pnlFloorSection2.Name = "pnlFloorSection2";
            pnlFloorSection2.Padding = new Padding(5);
            pnlFloorSection2.Size = new Size(1250, 200);
            pnlFloorSection2.TabIndex = 1;
            // 
            // flpFloorRooms2
            // 
            flpFloorRooms2.AutoScroll = true;
            flpFloorRooms2.BorderStyle = BorderStyle.FixedSingle;
            flpFloorRooms2.Dock = DockStyle.Fill;
            flpFloorRooms2.FlowDirection = FlowDirection.TopDown;
            flpFloorRooms2.Location = new Point(5, 55);
            flpFloorRooms2.Name = "flpFloorRooms2";
            flpFloorRooms2.Padding = new Padding(10);
            flpFloorRooms2.Size = new Size(1238, 138);
            flpFloorRooms2.TabIndex = 21;
            flpFloorRooms2.WrapContents = false;
            // 
            // lblFloorTitle2
            // 
            lblFloorTitle2.Dock = DockStyle.Top;
            lblFloorTitle2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFloorTitle2.ForeColor = Color.White;
            lblFloorTitle2.ImageAlign = ContentAlignment.MiddleRight;
            lblFloorTitle2.Location = new Point(5, 5);
            lblFloorTitle2.Margin = new Padding(0);
            lblFloorTitle2.Name = "lblFloorTitle2";
            lblFloorTitle2.Size = new Size(1238, 50);
            lblFloorTitle2.TabIndex = 20;
            lblFloorTitle2.Text = "FLOOR 2";
            lblFloorTitle2.TextAlign = ContentAlignment.MiddleCenter;
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
            pnlFloorSection1.ResumeLayout(false);
            pnlFloorSection2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoomAccountHeader;
        private Button btnBackRoomAccount;
        private Label lblRoomAccountTitle;
        private Panel pnlRoomAccountContent;
        private FlowLayoutPanel flpFloors;
        private Panel pnlFloorSection1;
        private Label lblFloorTitle1;
        private FlowLayoutPanel flpFloorRooms1;
        private Panel pnlFloorSection2;
        private FlowLayoutPanel flpFloorRooms2;
        private Label lblFloorTitle2;
    }
}
