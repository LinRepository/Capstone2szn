namespace Capstoneszn.Forms.RoomsForms
{
    partial class TransferPaymentForm
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblDescription = new Label();
            lblTitle = new Label();
            pnlActions = new Panel();
            btnContinue = new Button();
            btnBack = new Button();
            pnlContent = new Panel();
            flpCards = new FlowLayoutPanel();
            lblCardsNote = new Label();
            pnlSummary = new Panel();
            lblStatus = new Label();
            lblPolicy = new Label();
            lblReceiptsLine = new Label();
            lblTotalDue = new Label();
            lblTotalCaption = new Label();
            lblSummaryBody = new Label();
            lblSummaryTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlActions.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlSummary.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lblDescription);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 80);
            pnlHeader.TabIndex = 0;
            //
            // lblDescription
            //
            lblDescription.Dock = DockStyle.Fill;
            lblDescription.Font = new Font("Segoe UI", 11F);
            lblDescription.ForeColor = Color.FromArgb(201, 212, 234);
            lblDescription.Location = new Point(0, 42);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(998, 36);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Room ### → Room ### · Rent difference · Today";
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            //
            // lblTitle
            //
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 15F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(998, 42);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Transfer Payment";
            lblTitle.TextAlign = ContentAlignment.BottomCenter;
            //
            // pnlActions
            //
            pnlActions.BorderStyle = BorderStyle.FixedSingle;
            pnlActions.Controls.Add(btnContinue);
            pnlActions.Controls.Add(btnBack);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 700);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(1000, 60);
            pnlActions.TabIndex = 2;
            //
            // btnContinue
            //
            btnContinue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnContinue.Location = new Point(838, 10);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(146, 38);
            btnContinue.TabIndex = 1;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            //
            // btnBack
            //
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 10.8F);
            btnBack.Location = new Point(14, 10);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(120, 38);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            //
            // pnlContent
            //
            pnlContent.Controls.Add(flpCards);
            pnlContent.Controls.Add(lblCardsNote);
            pnlContent.Controls.Add(pnlSummary);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(16, 14, 16, 14);
            pnlContent.Size = new Size(1000, 620);
            pnlContent.TabIndex = 1;
            //
            // flpCards
            //
            flpCards.AutoScroll = true;
            flpCards.Dock = DockStyle.Fill;
            flpCards.FlowDirection = FlowDirection.TopDown;
            flpCards.Location = new Point(16, 14);
            flpCards.Name = "flpCards";
            flpCards.Size = new Size(654, 552);
            flpCards.TabIndex = 0;
            flpCards.WrapContents = false;
            //
            // lblCardsNote
            //
            lblCardsNote.Dock = DockStyle.Bottom;
            lblCardsNote.Font = new Font("Segoe UI", 9.6F);
            lblCardsNote.ForeColor = Color.FromArgb(169, 182, 211);
            lblCardsNote.Location = new Point(16, 566);
            lblCardsNote.Name = "lblCardsNote";
            lblCardsNote.Size = new Size(654, 40);
            lblCardsNote.TabIndex = 1;
            lblCardsNote.Text = "One card per payer who owes a difference. Dependents and payers with no difference just move.";
            lblCardsNote.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlSummary
            //
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Controls.Add(lblStatus);
            pnlSummary.Controls.Add(lblPolicy);
            pnlSummary.Controls.Add(lblReceiptsLine);
            pnlSummary.Controls.Add(lblTotalDue);
            pnlSummary.Controls.Add(lblTotalCaption);
            pnlSummary.Controls.Add(lblSummaryBody);
            pnlSummary.Controls.Add(lblSummaryTitle);
            pnlSummary.Dock = DockStyle.Right;
            pnlSummary.Location = new Point(670, 14);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Padding = new Padding(14, 10, 14, 10);
            pnlSummary.Size = new Size(314, 592);
            pnlSummary.TabIndex = 2;
            //
            // lblStatus
            //
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Font = new Font("Segoe UI", 10.2F);
            lblStatus.ForeColor = Color.FromArgb(111, 224, 160);
            lblStatus.Location = new Point(14, 528);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(284, 52);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Ready to continue.";
            //
            // lblPolicy
            //
            lblPolicy.Dock = DockStyle.Bottom;
            lblPolicy.Font = new Font("Segoe UI", 9F);
            lblPolicy.ForeColor = Color.FromArgb(169, 182, 211);
            lblPolicy.Location = new Point(14, 478);
            lblPolicy.Name = "lblPolicy";
            lblPolicy.Size = new Size(284, 50);
            lblPolicy.TabIndex = 5;
            lblPolicy.Text = "Full difference, no proration - even with 1 day left. No refund on a cheaper room.";
            //
            // lblReceiptsLine
            //
            lblReceiptsLine.Dock = DockStyle.Top;
            lblReceiptsLine.Font = new Font("Segoe UI", 10.2F);
            lblReceiptsLine.ForeColor = Color.FromArgb(158, 197, 255);
            lblReceiptsLine.Location = new Point(14, 282);
            lblReceiptsLine.Name = "lblReceiptsLine";
            lblReceiptsLine.Size = new Size(284, 30);
            lblReceiptsLine.TabIndex = 4;
            lblReceiptsLine.Text = "1 payment · 1 receipt";
            //
            // lblTotalDue
            //
            lblTotalDue.Dock = DockStyle.Top;
            lblTotalDue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalDue.ForeColor = Color.White;
            lblTotalDue.Location = new Point(14, 232);
            lblTotalDue.Name = "lblTotalDue";
            lblTotalDue.Size = new Size(284, 50);
            lblTotalDue.TabIndex = 3;
            lblTotalDue.Text = "₱0.00";
            //
            // lblTotalCaption
            //
            lblTotalCaption.Dock = DockStyle.Top;
            lblTotalCaption.Font = new Font("Segoe UI", 10.2F);
            lblTotalCaption.ForeColor = Color.FromArgb(201, 212, 234);
            lblTotalCaption.Location = new Point(14, 202);
            lblTotalCaption.Name = "lblTotalCaption";
            lblTotalCaption.Size = new Size(284, 30);
            lblTotalCaption.TabIndex = 2;
            lblTotalCaption.Text = "Total due today";
            lblTotalCaption.TextAlign = ContentAlignment.BottomLeft;
            //
            // lblSummaryBody
            //
            lblSummaryBody.Dock = DockStyle.Top;
            lblSummaryBody.Font = new Font("Segoe UI", 10.2F);
            lblSummaryBody.ForeColor = Color.White;
            lblSummaryBody.Location = new Point(14, 40);
            lblSummaryBody.Name = "lblSummaryBody";
            lblSummaryBody.Size = new Size(284, 162);
            lblSummaryBody.TabIndex = 1;
            lblSummaryBody.Text = "From\nTo\nMoving\nNew price from";
            //
            // lblSummaryTitle
            //
            lblSummaryTitle.Dock = DockStyle.Top;
            lblSummaryTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblSummaryTitle.ForeColor = Color.FromArgb(201, 212, 234);
            lblSummaryTitle.Location = new Point(14, 10);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(284, 30);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "SUMMARY";
            //
            // TransferPaymentForm
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(1000, 760);
            Controls.Add(pnlContent);
            Controls.Add(pnlActions);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TransferPaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Transfer Payment";
            Load += TransferPaymentForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlSummary.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblDescription;
        private Panel pnlActions;
        private Button btnContinue;
        private Button btnBack;
        private Panel pnlContent;
        private FlowLayoutPanel flpCards;
        private Label lblCardsNote;
        private Panel pnlSummary;
        private Label lblSummaryTitle;
        private Label lblSummaryBody;
        private Label lblTotalCaption;
        private Label lblTotalDue;
        private Label lblReceiptsLine;
        private Label lblPolicy;
        private Label lblStatus;
    }
}