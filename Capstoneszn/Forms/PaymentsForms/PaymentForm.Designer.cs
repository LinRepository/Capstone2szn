namespace Capstoneszn.Forms
{
    partial class PaymentForm
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
            pnlPaymentHeader = new Panel();
            lblPaymentDescription = new Label();
            lblPaymentTitle = new Label();
            pnlPaymentActions = new Panel();
            btnClear = new Button();
            btnContinuePayment = new Button();
            btnCancelPayment = new Button();
            pnlPaymentContent = new Panel();
            pnlPayerArea = new Panel();
            flpPayerCards = new FlowLayoutPanel();
            lblCreditedTo = new Label();
            lblDependents = new Label();
            pnlPaidBy = new Panel();
            cboPaidBy = new ComboBox();
            lblPaidBy = new Label();
            pnlCreditTo = new Panel();          // NEW (credit choice)
            cboCreditTo = new ComboBox();       // NEW (credit choice)
            lblCreditTo = new Label();          // NEW (credit choice)
            pnlSummary = new Panel();
            lblStatus = new Label();
            lblReceiptsLine = new Label();
            lblTotalCollected = new Label();
            lblTotalCaption = new Label();
            tlpSummary = new TableLayoutPanel();
            lblRoomPriceCaption = new Label();
            lblRoomPrice = new Label();
            lblOccupantsCaption = new Label();
            lblOccupants = new Label();
            lblShareCaption = new Label();
            lblShare = new Label();
            lblCycleCaption = new Label();
            lblCycleStart = new Label();
            lblSummaryTitle = new Label();
            pnlLegacyFields = new Panel();
            pnlAmountReferenceNumber = new Panel();
            pnlPaymentAmount = new Panel();
            txtAmountValue = new TextBox();
            lblPaymentAmount = new Label();
            pnlReferenceNumber = new Panel();
            txtReferenceNumber = new TextBox();
            lblReferenceNumber = new Label();
            pnlCategoryPaymentType = new Panel();
            pnlPaymentCategory = new Panel();
            cboPaymentCategory = new ComboBox();
            lblPaymentCategory = new Label();
            pnlPaymentType = new Panel();
            lblPaymentType = new Label();
            cboPaymentType = new ComboBox();
            pnlDatePaymentMethod = new Panel();
            pnlPaymentMethod = new Panel();
            pnlPaymentMethodOptions = new Panel();
            RadioBtnGCash = new RadioButton();
            RadioBtnCash = new RadioButton();
            lblPaymentMethod = new Label();
            pnlPaymentDate = new Panel();
            lblPaymentDate = new Label();
            dtpPaymentDate = new DateTimePicker();
            pnlPaymentHeader.SuspendLayout();
            pnlPaymentActions.SuspendLayout();
            pnlPaymentContent.SuspendLayout();
            pnlPayerArea.SuspendLayout();
            pnlPaidBy.SuspendLayout();
            pnlCreditTo.SuspendLayout();        // NEW (credit choice)
            pnlSummary.SuspendLayout();
            tlpSummary.SuspendLayout();
            pnlLegacyFields.SuspendLayout();
            pnlAmountReferenceNumber.SuspendLayout();
            pnlPaymentAmount.SuspendLayout();
            pnlReferenceNumber.SuspendLayout();
            pnlCategoryPaymentType.SuspendLayout();
            pnlPaymentCategory.SuspendLayout();
            pnlPaymentType.SuspendLayout();
            pnlDatePaymentMethod.SuspendLayout();
            pnlPaymentMethod.SuspendLayout();
            pnlPaymentMethodOptions.SuspendLayout();
            pnlPaymentDate.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPaymentHeader
            // 
            pnlPaymentHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentHeader.Controls.Add(lblPaymentDescription);
            pnlPaymentHeader.Controls.Add(lblPaymentTitle);
            pnlPaymentHeader.Dock = DockStyle.Top;
            pnlPaymentHeader.Location = new Point(0, 0);
            pnlPaymentHeader.Margin = new Padding(0);
            pnlPaymentHeader.Name = "pnlPaymentHeader";
            pnlPaymentHeader.Size = new Size(1000, 72);
            pnlPaymentHeader.TabIndex = 0;
            // 
            // lblPaymentDescription
            // 
            lblPaymentDescription.Dock = DockStyle.Fill;
            lblPaymentDescription.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentDescription.ForeColor = Color.FromArgb(184, 198, 224);
            lblPaymentDescription.Location = new Point(0, 36);
            lblPaymentDescription.Name = "lblPaymentDescription";
            lblPaymentDescription.Size = new Size(998, 34);
            lblPaymentDescription.TabIndex = 1;
            lblPaymentDescription.Text = "Room ### · Rent · Today · Whole Room";
            lblPaymentDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPaymentTitle
            // 
            lblPaymentTitle.Dock = DockStyle.Top;
            lblPaymentTitle.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentTitle.ForeColor = Color.White;
            lblPaymentTitle.Location = new Point(0, 0);
            lblPaymentTitle.Name = "lblPaymentTitle";
            lblPaymentTitle.Size = new Size(998, 36);
            lblPaymentTitle.TabIndex = 0;
            lblPaymentTitle.Text = "Move-In Payment";
            lblPaymentTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlPaymentActions
            // 
            pnlPaymentActions.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentActions.Controls.Add(btnClear);
            pnlPaymentActions.Controls.Add(btnContinuePayment);
            pnlPaymentActions.Controls.Add(btnCancelPayment);
            pnlPaymentActions.Dock = DockStyle.Bottom;
            pnlPaymentActions.Location = new Point(0, 704);
            pnlPaymentActions.Margin = new Padding(0);
            pnlPaymentActions.Name = "pnlPaymentActions";
            pnlPaymentActions.Size = new Size(1000, 56);
            pnlPaymentActions.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.Font = new Font("Segoe UI", 10.8F);
            btnClear.Location = new Point(150, 9);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Visible = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnContinuePayment
            // 
            btnContinuePayment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnContinuePayment.Cursor = Cursors.Hand;
            btnContinuePayment.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnContinuePayment.Location = new Point(838, 9);
            btnContinuePayment.Name = "btnContinuePayment";
            btnContinuePayment.Size = new Size(148, 36);
            btnContinuePayment.TabIndex = 1;
            btnContinuePayment.Text = "Continue";
            btnContinuePayment.UseVisualStyleBackColor = true;
            btnContinuePayment.Click += btnContinuePayment_Click;
            // 
            // btnCancelPayment
            // 
            btnCancelPayment.Cursor = Cursors.Hand;
            btnCancelPayment.Font = new Font("Segoe UI", 10.8F);
            btnCancelPayment.Location = new Point(14, 9);
            btnCancelPayment.Name = "btnCancelPayment";
            btnCancelPayment.Size = new Size(120, 36);
            btnCancelPayment.TabIndex = 0;
            btnCancelPayment.Text = "← Back";
            btnCancelPayment.UseVisualStyleBackColor = true;
            btnCancelPayment.Click += btnCancelPayment_Click;
            // 
            // pnlPaymentContent
            // 
            pnlPaymentContent.Controls.Add(pnlPayerArea);
            pnlPaymentContent.Controls.Add(pnlSummary);
            pnlPaymentContent.Controls.Add(pnlLegacyFields);
            pnlPaymentContent.Dock = DockStyle.Fill;
            pnlPaymentContent.Location = new Point(0, 72);
            pnlPaymentContent.Margin = new Padding(0);
            pnlPaymentContent.Name = "pnlPaymentContent";
            pnlPaymentContent.Padding = new Padding(16, 14, 16, 14);
            pnlPaymentContent.Size = new Size(1000, 632);
            pnlPaymentContent.TabIndex = 1;
            // 
            // pnlPayerArea
            // 
            pnlPayerArea.Controls.Add(flpPayerCards);
            pnlPayerArea.Controls.Add(lblCreditedTo);
            pnlPayerArea.Controls.Add(lblDependents);
            pnlPayerArea.Controls.Add(pnlCreditTo);   // NEW (credit choice): docks under "Paid by"
            pnlPayerArea.Controls.Add(pnlPaidBy);
            pnlPayerArea.Dock = DockStyle.Fill;
            pnlPayerArea.Location = new Point(16, 14);
            pnlPayerArea.Name = "pnlPayerArea";
            pnlPayerArea.Padding = new Padding(0, 0, 14, 0);
            pnlPayerArea.Size = new Size(668, 604);
            pnlPayerArea.TabIndex = 0;
            // 
            // flpPayerCards
            // 
            flpPayerCards.AutoScroll = true;
            flpPayerCards.Dock = DockStyle.Fill;
            flpPayerCards.FlowDirection = FlowDirection.TopDown;
            flpPayerCards.Location = new Point(0, 52);
            flpPayerCards.Name = "flpPayerCards";
            flpPayerCards.Size = new Size(654, 444);
            flpPayerCards.TabIndex = 1;
            flpPayerCards.WrapContents = false;
            // 
            // lblCreditedTo
            // 
            lblCreditedTo.BorderStyle = BorderStyle.FixedSingle;
            lblCreditedTo.Dock = DockStyle.Bottom;
            lblCreditedTo.Font = new Font("Segoe UI", 10.2F);
            lblCreditedTo.ForeColor = Color.White;
            lblCreditedTo.Location = new Point(0, 496);
            lblCreditedTo.Name = "lblCreditedTo";
            lblCreditedTo.Padding = new Padding(10, 6, 10, 6);
            lblCreditedTo.Size = new Size(654, 72);
            lblCreditedTo.TabIndex = 2;
            lblCreditedTo.Text = "Credited to:";
            lblCreditedTo.Visible = false;
            // 
            // lblDependents
            // 
            lblDependents.Dock = DockStyle.Bottom;
            lblDependents.Font = new Font("Segoe UI", 10.2F);
            lblDependents.ForeColor = Color.FromArgb(184, 198, 224);
            lblDependents.Location = new Point(0, 568);
            lblDependents.Name = "lblDependents";
            lblDependents.Padding = new Padding(4, 0, 0, 0);
            lblDependents.Size = new Size(654, 36);
            lblDependents.TabIndex = 3;
            lblDependents.Text = "Dependents (no billing): —";
            lblDependents.TextAlign = ContentAlignment.MiddleLeft;
            lblDependents.Visible = false;
            // 
            // pnlCreditTo  (NEW - credit choice: Whole Room, who gets the extra)
            // 
            pnlCreditTo.Controls.Add(cboCreditTo);
            pnlCreditTo.Controls.Add(lblCreditTo);
            pnlCreditTo.Dock = DockStyle.Top;
            pnlCreditTo.Location = new Point(0, 52);
            pnlCreditTo.Name = "pnlCreditTo";
            pnlCreditTo.Padding = new Padding(0, 0, 0, 10);
            pnlCreditTo.Size = new Size(654, 46);
            pnlCreditTo.TabIndex = 1;
            pnlCreditTo.Visible = false;
            // 
            // cboCreditTo
            // 
            cboCreditTo.Cursor = Cursors.Hand;
            cboCreditTo.Dock = DockStyle.Left;
            cboCreditTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCreditTo.Font = new Font("Segoe UI", 12F);
            cboCreditTo.FormattingEnabled = true;
            cboCreditTo.Location = new Point(150, 0);
            cboCreditTo.Name = "cboCreditTo";
            cboCreditTo.Size = new Size(260, 36);
            cboCreditTo.TabIndex = 1;
            cboCreditTo.SelectedIndexChanged += cboCreditTo_SelectedIndexChanged;
            // 
            // lblCreditTo
            // 
            lblCreditTo.Dock = DockStyle.Left;
            lblCreditTo.Font = new Font("Segoe UI", 12F);
            lblCreditTo.ForeColor = Color.White;
            lblCreditTo.Location = new Point(0, 0);
            lblCreditTo.Name = "lblCreditTo";
            lblCreditTo.Size = new Size(150, 36);
            lblCreditTo.TabIndex = 0;
            lblCreditTo.Text = "Extra credit to";
            lblCreditTo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPaidBy
            // 
            pnlPaidBy.Controls.Add(cboPaidBy);
            pnlPaidBy.Controls.Add(lblPaidBy);
            pnlPaidBy.Dock = DockStyle.Top;
            pnlPaidBy.Location = new Point(0, 0);
            pnlPaidBy.Name = "pnlPaidBy";
            pnlPaidBy.Padding = new Padding(0, 6, 0, 10);
            pnlPaidBy.Size = new Size(654, 52);
            pnlPaidBy.TabIndex = 0;
            // 
            // cboPaidBy
            // 
            cboPaidBy.Cursor = Cursors.Hand;
            cboPaidBy.Dock = DockStyle.Left;
            cboPaidBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaidBy.Font = new Font("Segoe UI", 12F);
            cboPaidBy.FormattingEnabled = true;
            cboPaidBy.Location = new Point(90, 6);
            cboPaidBy.Name = "cboPaidBy";
            cboPaidBy.Size = new Size(320, 36);
            cboPaidBy.TabIndex = 1;
            cboPaidBy.SelectedIndexChanged += cboPaidBy_SelectedIndexChanged;
            // 
            // lblPaidBy
            // 
            lblPaidBy.Dock = DockStyle.Left;
            lblPaidBy.Font = new Font("Segoe UI", 12F);
            lblPaidBy.ForeColor = Color.White;
            lblPaidBy.Location = new Point(0, 6);
            lblPaidBy.Name = "lblPaidBy";
            lblPaidBy.Size = new Size(90, 36);
            lblPaidBy.TabIndex = 0;
            lblPaidBy.Text = "Paid by";
            lblPaidBy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlSummary
            // 
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Controls.Add(lblStatus);
            pnlSummary.Controls.Add(lblReceiptsLine);
            pnlSummary.Controls.Add(lblTotalCollected);
            pnlSummary.Controls.Add(lblTotalCaption);
            pnlSummary.Controls.Add(tlpSummary);
            pnlSummary.Controls.Add(lblSummaryTitle);
            pnlSummary.Dock = DockStyle.Right;
            pnlSummary.Location = new Point(684, 14);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Padding = new Padding(14, 10, 14, 10);
            pnlSummary.Size = new Size(300, 604);
            pnlSummary.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Font = new Font("Segoe UI", 10.2F);
            lblStatus.ForeColor = Color.FromArgb(134, 239, 172);
            lblStatus.Location = new Point(14, 530);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(270, 62);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Ready to continue.";
            lblStatus.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblReceiptsLine
            // 
            lblReceiptsLine.Dock = DockStyle.Top;
            lblReceiptsLine.Font = new Font("Segoe UI", 10.2F);
            lblReceiptsLine.ForeColor = Color.FromArgb(147, 197, 253);
            lblReceiptsLine.Location = new Point(14, 260);
            lblReceiptsLine.Name = "lblReceiptsLine";
            lblReceiptsLine.Size = new Size(270, 30);
            lblReceiptsLine.TabIndex = 4;
            lblReceiptsLine.Text = "1 payment · 1 receipt";
            // 
            // lblTotalCollected
            // 
            lblTotalCollected.Dock = DockStyle.Top;
            lblTotalCollected.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold);
            lblTotalCollected.ForeColor = Color.White;
            lblTotalCollected.Location = new Point(14, 210);
            lblTotalCollected.Name = "lblTotalCollected";
            lblTotalCollected.Size = new Size(270, 50);
            lblTotalCollected.TabIndex = 3;
            lblTotalCollected.Text = "₱0.00";
            lblTotalCollected.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalCaption
            // 
            lblTotalCaption.Dock = DockStyle.Top;
            lblTotalCaption.Font = new Font("Segoe UI", 9.6F);
            lblTotalCaption.ForeColor = Color.FromArgb(184, 198, 224);
            lblTotalCaption.Location = new Point(14, 180);
            lblTotalCaption.Name = "lblTotalCaption";
            lblTotalCaption.Padding = new Padding(0, 10, 0, 0);
            lblTotalCaption.Size = new Size(270, 30);
            lblTotalCaption.TabIndex = 2;
            lblTotalCaption.Text = "Total collected today";
            // 
            // tlpSummary
            // 
            tlpSummary.ColumnCount = 2;
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSummary.Controls.Add(lblRoomPriceCaption, 0, 0);
            tlpSummary.Controls.Add(lblRoomPrice, 1, 0);
            tlpSummary.Controls.Add(lblOccupantsCaption, 0, 1);
            tlpSummary.Controls.Add(lblOccupants, 1, 1);
            tlpSummary.Controls.Add(lblShareCaption, 0, 2);
            tlpSummary.Controls.Add(lblShare, 1, 2);
            tlpSummary.Controls.Add(lblCycleCaption, 0, 3);
            tlpSummary.Controls.Add(lblCycleStart, 1, 3);
            tlpSummary.Dock = DockStyle.Top;
            tlpSummary.Location = new Point(14, 40);
            tlpSummary.Name = "tlpSummary";
            tlpSummary.RowCount = 4;
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlpSummary.Size = new Size(270, 140);
            tlpSummary.TabIndex = 1;
            // 
            // lblRoomPriceCaption
            // 
            lblRoomPriceCaption.Dock = DockStyle.Fill;
            lblRoomPriceCaption.Font = new Font("Segoe UI", 10.2F);
            lblRoomPriceCaption.ForeColor = Color.FromArgb(184, 198, 224);
            lblRoomPriceCaption.Location = new Point(3, 0);
            lblRoomPriceCaption.Name = "lblRoomPriceCaption";
            lblRoomPriceCaption.Size = new Size(129, 35);
            lblRoomPriceCaption.TabIndex = 0;
            lblRoomPriceCaption.Text = "Room price";
            lblRoomPriceCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRoomPrice
            // 
            lblRoomPrice.Dock = DockStyle.Fill;
            lblRoomPrice.Font = new Font("Segoe UI", 10.2F);
            lblRoomPrice.ForeColor = Color.White;
            lblRoomPrice.Location = new Point(138, 0);
            lblRoomPrice.Name = "lblRoomPrice";
            lblRoomPrice.Size = new Size(129, 35);
            lblRoomPrice.TabIndex = 1;
            lblRoomPrice.Text = "₱0.00";
            lblRoomPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblOccupantsCaption
            // 
            lblOccupantsCaption.Dock = DockStyle.Fill;
            lblOccupantsCaption.Font = new Font("Segoe UI", 10.2F);
            lblOccupantsCaption.ForeColor = Color.FromArgb(184, 198, 224);
            lblOccupantsCaption.Location = new Point(3, 35);
            lblOccupantsCaption.Name = "lblOccupantsCaption";
            lblOccupantsCaption.Size = new Size(129, 35);
            lblOccupantsCaption.TabIndex = 2;
            lblOccupantsCaption.Text = "Occupants";
            lblOccupantsCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOccupants
            // 
            lblOccupants.Dock = DockStyle.Fill;
            lblOccupants.Font = new Font("Segoe UI", 10.2F);
            lblOccupants.ForeColor = Color.White;
            lblOccupants.Location = new Point(138, 35);
            lblOccupants.Name = "lblOccupants";
            lblOccupants.Size = new Size(129, 35);
            lblOccupants.TabIndex = 3;
            lblOccupants.Text = "0 (0 paying)";
            lblOccupants.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblShareCaption
            // 
            lblShareCaption.Dock = DockStyle.Fill;
            lblShareCaption.Font = new Font("Segoe UI", 10.2F);
            lblShareCaption.ForeColor = Color.FromArgb(184, 198, 224);
            lblShareCaption.Location = new Point(3, 70);
            lblShareCaption.Name = "lblShareCaption";
            lblShareCaption.Size = new Size(129, 35);
            lblShareCaption.TabIndex = 4;
            lblShareCaption.Text = "Share each";
            lblShareCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblShare
            // 
            lblShare.Dock = DockStyle.Fill;
            lblShare.Font = new Font("Segoe UI", 10.2F);
            lblShare.ForeColor = Color.White;
            lblShare.Location = new Point(138, 70);
            lblShare.Name = "lblShare";
            lblShare.Size = new Size(129, 35);
            lblShare.TabIndex = 5;
            lblShare.Text = "₱0.00";
            lblShare.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCycleCaption
            // 
            lblCycleCaption.Dock = DockStyle.Fill;
            lblCycleCaption.Font = new Font("Segoe UI", 10.2F);
            lblCycleCaption.ForeColor = Color.FromArgb(184, 198, 224);
            lblCycleCaption.Location = new Point(3, 105);
            lblCycleCaption.Name = "lblCycleCaption";
            lblCycleCaption.Size = new Size(129, 35);
            lblCycleCaption.TabIndex = 6;
            lblCycleCaption.Text = "Cycle starts";
            lblCycleCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCycleStart
            // 
            lblCycleStart.Dock = DockStyle.Fill;
            lblCycleStart.Font = new Font("Segoe UI", 10.2F);
            lblCycleStart.ForeColor = Color.White;
            lblCycleStart.Location = new Point(138, 105);
            lblCycleStart.Name = "lblCycleStart";
            lblCycleStart.Size = new Size(129, 35);
            lblCycleStart.TabIndex = 7;
            lblCycleStart.Text = "—";
            lblCycleStart.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.Dock = DockStyle.Top;
            lblSummaryTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSummaryTitle.ForeColor = Color.FromArgb(184, 198, 224);
            lblSummaryTitle.Location = new Point(14, 10);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(270, 30);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "SUMMARY";
            // 
            // pnlLegacyFields
            // 
            pnlLegacyFields.Controls.Add(pnlAmountReferenceNumber);
            pnlLegacyFields.Controls.Add(pnlCategoryPaymentType);
            pnlLegacyFields.Controls.Add(pnlDatePaymentMethod);
            pnlLegacyFields.Location = new Point(16, 14);
            pnlLegacyFields.Name = "pnlLegacyFields";
            pnlLegacyFields.Size = new Size(762, 282);
            pnlLegacyFields.TabIndex = 2;
            pnlLegacyFields.Visible = false;
            // 
            // pnlAmountReferenceNumber
            // 
            pnlAmountReferenceNumber.Controls.Add(pnlPaymentAmount);
            pnlAmountReferenceNumber.Controls.Add(pnlReferenceNumber);
            pnlAmountReferenceNumber.Dock = DockStyle.Fill;
            pnlAmountReferenceNumber.Location = new Point(0, 200);
            pnlAmountReferenceNumber.Name = "pnlAmountReferenceNumber";
            pnlAmountReferenceNumber.Size = new Size(762, 82);
            pnlAmountReferenceNumber.TabIndex = 3;
            // 
            // pnlPaymentAmount
            // 
            pnlPaymentAmount.Controls.Add(txtAmountValue);
            pnlPaymentAmount.Controls.Add(lblPaymentAmount);
            pnlPaymentAmount.Dock = DockStyle.Right;
            pnlPaymentAmount.Location = new Point(387, 0);
            pnlPaymentAmount.Name = "pnlPaymentAmount";
            pnlPaymentAmount.Size = new Size(375, 82);
            pnlPaymentAmount.TabIndex = 1;
            // 
            // txtAmountValue
            // 
            txtAmountValue.BorderStyle = BorderStyle.FixedSingle;
            txtAmountValue.Location = new Point(3, 28);
            txtAmountValue.Name = "txtAmountValue";
            txtAmountValue.Size = new Size(369, 27);
            txtAmountValue.TabIndex = 10;
            txtAmountValue.Text = "₱****";
            txtAmountValue.TextAlign = HorizontalAlignment.Center;
            // 
            // lblPaymentAmount
            // 
            lblPaymentAmount.AutoSize = true;
            lblPaymentAmount.Dock = DockStyle.Top;
            lblPaymentAmount.Font = new Font("Segoe UI", 13.8F);
            lblPaymentAmount.ForeColor = Color.White;
            lblPaymentAmount.Location = new Point(0, 0);
            lblPaymentAmount.Margin = new Padding(0);
            lblPaymentAmount.Name = "lblPaymentAmount";
            lblPaymentAmount.Size = new Size(96, 31);
            lblPaymentAmount.TabIndex = 8;
            lblPaymentAmount.Text = "Amount";
            // 
            // pnlReferenceNumber
            // 
            pnlReferenceNumber.Controls.Add(txtReferenceNumber);
            pnlReferenceNumber.Controls.Add(lblReferenceNumber);
            pnlReferenceNumber.Dock = DockStyle.Left;
            pnlReferenceNumber.Location = new Point(0, 0);
            pnlReferenceNumber.Name = "pnlReferenceNumber";
            pnlReferenceNumber.Size = new Size(375, 82);
            pnlReferenceNumber.TabIndex = 0;
            pnlReferenceNumber.Paint += pnlReferenceNumber_Paint;
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.BorderStyle = BorderStyle.FixedSingle;
            txtReferenceNumber.Location = new Point(3, 28);
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.Size = new Size(369, 27);
            txtReferenceNumber.TabIndex = 9;
            txtReferenceNumber.Visible = false;
            txtReferenceNumber.TextChanged += txtReferenceNumber_TextChanged;
            // 
            // lblReferenceNumber
            // 
            lblReferenceNumber.AutoSize = true;
            lblReferenceNumber.Dock = DockStyle.Top;
            lblReferenceNumber.Font = new Font("Segoe UI", 13.8F);
            lblReferenceNumber.ForeColor = Color.White;
            lblReferenceNumber.Location = new Point(0, 0);
            lblReferenceNumber.Margin = new Padding(0);
            lblReferenceNumber.Name = "lblReferenceNumber";
            lblReferenceNumber.Size = new Size(272, 31);
            lblReferenceNumber.TabIndex = 8;
            lblReferenceNumber.Text = "Reference Gcash Number";
            lblReferenceNumber.Visible = false;
            // 
            // pnlCategoryPaymentType
            // 
            pnlCategoryPaymentType.Controls.Add(pnlPaymentCategory);
            pnlCategoryPaymentType.Controls.Add(pnlPaymentType);
            pnlCategoryPaymentType.Dock = DockStyle.Top;
            pnlCategoryPaymentType.Location = new Point(0, 100);
            pnlCategoryPaymentType.Name = "pnlCategoryPaymentType";
            pnlCategoryPaymentType.Size = new Size(762, 100);
            pnlCategoryPaymentType.TabIndex = 2;
            // 
            // pnlPaymentCategory
            // 
            pnlPaymentCategory.Controls.Add(cboPaymentCategory);
            pnlPaymentCategory.Controls.Add(lblPaymentCategory);
            pnlPaymentCategory.Dock = DockStyle.Left;
            pnlPaymentCategory.Location = new Point(0, 0);
            pnlPaymentCategory.Name = "pnlPaymentCategory";
            pnlPaymentCategory.Size = new Size(375, 100);
            pnlPaymentCategory.TabIndex = 3;
            // 
            // cboPaymentCategory
            // 
            cboPaymentCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentCategory.FormattingEnabled = true;
            cboPaymentCategory.Location = new Point(3, 34);
            cboPaymentCategory.Name = "cboPaymentCategory";
            cboPaymentCategory.Size = new Size(369, 28);
            cboPaymentCategory.TabIndex = 0;
            // 
            // lblPaymentCategory
            // 
            lblPaymentCategory.AutoSize = true;
            lblPaymentCategory.Dock = DockStyle.Top;
            lblPaymentCategory.Font = new Font("Segoe UI", 13.8F);
            lblPaymentCategory.ForeColor = Color.White;
            lblPaymentCategory.Location = new Point(0, 0);
            lblPaymentCategory.Margin = new Padding(0);
            lblPaymentCategory.Name = "lblPaymentCategory";
            lblPaymentCategory.Size = new Size(106, 31);
            lblPaymentCategory.TabIndex = 6;
            lblPaymentCategory.Text = "Category";
            // 
            // pnlPaymentType
            // 
            pnlPaymentType.Controls.Add(lblPaymentType);
            pnlPaymentType.Controls.Add(cboPaymentType);
            pnlPaymentType.Dock = DockStyle.Right;
            pnlPaymentType.Location = new Point(387, 0);
            pnlPaymentType.Name = "pnlPaymentType";
            pnlPaymentType.Size = new Size(375, 100);
            pnlPaymentType.TabIndex = 0;
            // 
            // lblPaymentType
            // 
            lblPaymentType.AutoSize = true;
            lblPaymentType.Dock = DockStyle.Top;
            lblPaymentType.Font = new Font("Segoe UI", 13.8F);
            lblPaymentType.ForeColor = Color.White;
            lblPaymentType.Location = new Point(0, 0);
            lblPaymentType.Margin = new Padding(0);
            lblPaymentType.Name = "lblPaymentType";
            lblPaymentType.Size = new Size(156, 31);
            lblPaymentType.TabIndex = 8;
            lblPaymentType.Text = "Payment Type";
            // 
            // cboPaymentType
            // 
            cboPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentType.FormattingEnabled = true;
            cboPaymentType.Location = new Point(0, 34);
            cboPaymentType.Name = "cboPaymentType";
            cboPaymentType.Size = new Size(372, 28);
            cboPaymentType.TabIndex = 7;
            // 
            // pnlDatePaymentMethod
            // 
            pnlDatePaymentMethod.Controls.Add(pnlPaymentMethod);
            pnlDatePaymentMethod.Controls.Add(pnlPaymentDate);
            pnlDatePaymentMethod.Dock = DockStyle.Top;
            pnlDatePaymentMethod.Location = new Point(0, 0);
            pnlDatePaymentMethod.Name = "pnlDatePaymentMethod";
            pnlDatePaymentMethod.Size = new Size(762, 100);
            pnlDatePaymentMethod.TabIndex = 1;
            // 
            // pnlPaymentMethod
            // 
            pnlPaymentMethod.Controls.Add(pnlPaymentMethodOptions);
            pnlPaymentMethod.Controls.Add(lblPaymentMethod);
            pnlPaymentMethod.Dock = DockStyle.Right;
            pnlPaymentMethod.Location = new Point(387, 0);
            pnlPaymentMethod.Name = "pnlPaymentMethod";
            pnlPaymentMethod.Size = new Size(375, 100);
            pnlPaymentMethod.TabIndex = 1;
            // 
            // pnlPaymentMethodOptions
            // 
            pnlPaymentMethodOptions.Controls.Add(RadioBtnGCash);
            pnlPaymentMethodOptions.Controls.Add(RadioBtnCash);
            pnlPaymentMethodOptions.Location = new Point(58, 34);
            pnlPaymentMethodOptions.Name = "pnlPaymentMethodOptions";
            pnlPaymentMethodOptions.Size = new Size(250, 50);
            pnlPaymentMethodOptions.TabIndex = 5;
            // 
            // RadioBtnGCash
            // 
            RadioBtnGCash.AutoSize = true;
            RadioBtnGCash.ForeColor = Color.White;
            RadioBtnGCash.Location = new Point(150, 13);
            RadioBtnGCash.Name = "RadioBtnGCash";
            RadioBtnGCash.Size = new Size(69, 24);
            RadioBtnGCash.TabIndex = 1;
            RadioBtnGCash.TabStop = true;
            RadioBtnGCash.Text = "Gcash";
            RadioBtnGCash.UseVisualStyleBackColor = true;
            RadioBtnGCash.CheckedChanged += RadioBtnGCash_CheckedChanged;
            // 
            // RadioBtnCash
            // 
            RadioBtnCash.AutoSize = true;
            RadioBtnCash.ForeColor = Color.White;
            RadioBtnCash.Location = new Point(41, 13);
            RadioBtnCash.Name = "RadioBtnCash";
            RadioBtnCash.Size = new Size(61, 24);
            RadioBtnCash.TabIndex = 0;
            RadioBtnCash.TabStop = true;
            RadioBtnCash.Text = "Cash";
            RadioBtnCash.UseVisualStyleBackColor = true;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Dock = DockStyle.Top;
            lblPaymentMethod.Font = new Font("Segoe UI", 13.8F);
            lblPaymentMethod.ForeColor = Color.White;
            lblPaymentMethod.Location = new Point(0, 0);
            lblPaymentMethod.Margin = new Padding(0);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(189, 31);
            lblPaymentMethod.TabIndex = 4;
            lblPaymentMethod.Text = "Payment Method";
            // 
            // pnlPaymentDate
            // 
            pnlPaymentDate.Controls.Add(lblPaymentDate);
            pnlPaymentDate.Controls.Add(dtpPaymentDate);
            pnlPaymentDate.Dock = DockStyle.Left;
            pnlPaymentDate.Location = new Point(0, 0);
            pnlPaymentDate.Name = "pnlPaymentDate";
            pnlPaymentDate.Size = new Size(375, 100);
            pnlPaymentDate.TabIndex = 0;
            // 
            // lblPaymentDate
            // 
            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Dock = DockStyle.Top;
            lblPaymentDate.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentDate.ForeColor = Color.White;
            lblPaymentDate.Location = new Point(0, 0);
            lblPaymentDate.Margin = new Padding(0);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new Size(62, 31);
            lblPaymentDate.TabIndex = 3;
            lblPaymentDate.Text = "Date";
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Location = new Point(3, 34);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(369, 27);
            dtpPaymentDate.TabIndex = 0;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 20, 38);
            ClientSize = new Size(1000, 760);
            Controls.Add(pnlPaymentContent);
            Controls.Add(pnlPaymentActions);
            Controls.Add(pnlPaymentHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Move-In Payment";
            Load += PaymentForm_Load;
            pnlPaymentHeader.ResumeLayout(false);
            pnlPaymentActions.ResumeLayout(false);
            pnlPaymentContent.ResumeLayout(false);
            pnlPayerArea.ResumeLayout(false);
            pnlPaidBy.ResumeLayout(false);
            pnlCreditTo.ResumeLayout(false);   // NEW (credit choice)
            pnlSummary.ResumeLayout(false);
            tlpSummary.ResumeLayout(false);
            pnlLegacyFields.ResumeLayout(false);
            pnlAmountReferenceNumber.ResumeLayout(false);
            pnlPaymentAmount.ResumeLayout(false);
            pnlPaymentAmount.PerformLayout();
            pnlReferenceNumber.ResumeLayout(false);
            pnlReferenceNumber.PerformLayout();
            pnlCategoryPaymentType.ResumeLayout(false);
            pnlPaymentCategory.ResumeLayout(false);
            pnlPaymentCategory.PerformLayout();
            pnlPaymentType.ResumeLayout(false);
            pnlPaymentType.PerformLayout();
            pnlDatePaymentMethod.ResumeLayout(false);
            pnlPaymentMethod.ResumeLayout(false);
            pnlPaymentMethod.PerformLayout();
            pnlPaymentMethodOptions.ResumeLayout(false);
            pnlPaymentMethodOptions.PerformLayout();
            pnlPaymentDate.ResumeLayout(false);
            pnlPaymentDate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // ---- Existing controls (names unchanged; PaymentForm.cs uses them) ----
        private Panel pnlPaymentHeader;
        private Panel pnlPaymentActions;
        private Panel pnlPaymentContent;
        private Label lblPaymentDescription;
        private Label lblPaymentTitle;
        private Panel pnlDatePaymentMethod;
        private Panel pnlCategoryPaymentType;
        private Panel pnlPaymentMethod;
        private Panel pnlPaymentDate;
        private Panel pnlAmountReferenceNumber;
        private Panel pnlPaymentCategory;
        private Panel pnlPaymentType;
        private Button btnContinuePayment;
        private Button btnCancelPayment;
        private DateTimePicker dtpPaymentDate;
        private Panel pnlPaymentAmount;
        private Panel pnlReferenceNumber;
        private Label lblPaymentMethod;
        private Label lblPaymentDate;
        private Label lblPaymentType;
        private ComboBox cboPaymentType;
        private Label lblPaymentCategory;
        private ComboBox cboPaymentCategory;
        private Panel pnlPaymentMethodOptions;
        private RadioButton RadioBtnGCash;
        private RadioButton RadioBtnCash;
        private Label lblPaymentAmount;
        private TextBox txtReferenceNumber;
        private Label lblReferenceNumber;
        private TextBox txtAmountValue;
        private Button btnClear;

        // ---- New controls (Payer Cards design) ----
        private Panel pnlLegacyFields;
        private Panel pnlPayerArea;
        private Panel pnlPaidBy;
        private Label lblPaidBy;
        private ComboBox cboPaidBy;
        private Panel pnlCreditTo;      // NEW (credit choice)
        private ComboBox cboCreditTo;   // NEW (credit choice)
        private Label lblCreditTo;      // NEW (credit choice)
        private FlowLayoutPanel flpPayerCards;
        private Label lblCreditedTo;
        private Label lblDependents;
        private Panel pnlSummary;
        private Label lblSummaryTitle;
        private TableLayoutPanel tlpSummary;
        private Label lblRoomPriceCaption;
        private Label lblRoomPrice;
        private Label lblOccupantsCaption;
        private Label lblOccupants;
        private Label lblShareCaption;
        private Label lblShare;
        private Label lblCycleCaption;
        private Label lblCycleStart;
        private Label lblTotalCaption;
        private Label lblTotalCollected;
        private Label lblReceiptsLine;
        private Label lblStatus;
    }
}