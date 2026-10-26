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
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvAmountStyle = new DataGridViewCellStyle();
            pnlPaymentHeader = new Panel();
            lblPaymentSummary = new Label();
            lblConfirmationTitle = new Label();
            pnlPaymentDetails = new Panel();
            tblPaymentDetails = new TableLayoutPanel();
            lblConfirmDateTitle = new Label();
            lblConfirmDateValue = new Label();
            lblConfirmPaidAsTitle = new Label();
            lblConfirmPaidAsValue = new Label();
            lblConfirmRoomTitle = new Label();
            lblConfirmRoomValue = new Label();
            lblConfirmOccupantsTitle = new Label();
            lblConfirmOccupantsValue = new Label();
            lblConfirmCategoryTitle = new Label();
            lblConfirmCategoryValue = new Label();
            lblConfirmShareTitle = new Label();
            lblConfirmShareValue = new Label();
            pnlConfirmContent = new Panel();
            dgvConfirmPayments = new DataGridView();
            colPayer = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colMethod = new DataGridViewTextBoxColumn();
            colReference = new DataGridViewTextBoxColumn();
            colCovers = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            pnlTotal = new Panel();
            lblConfirmAmountValue = new Label();
            lblConfirmAmountTitle = new Label();
            lblCreditedTo = new Label();
            lblDependents = new Label();
            lblNotice = new Label();
            pnlLegacyConfirm = new Panel();
            lblConfirmPaymentTypeTitle = new Label();
            lblConfirmPaymentTypeValue = new Label();
            lblConfirmPaymentMethodTitle = new Label();
            lblConfirmPaymentMethodValue = new Label();
            lblConfirmReferenceTitle = new Label();
            lblConfirmReferenceValue = new Label();
            panel2 = new Panel();
            lblReceiptsLine = new Label();
            btnConfirmPayment = new Button();
            btnCancelPayment = new Button();
            pnlPaymentHeader.SuspendLayout();
            pnlPaymentDetails.SuspendLayout();
            tblPaymentDetails.SuspendLayout();
            pnlConfirmContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConfirmPayments).BeginInit();
            pnlTotal.SuspendLayout();
            pnlLegacyConfirm.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            //
            // pnlPaymentHeader
            //
            pnlPaymentHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentHeader.Controls.Add(lblPaymentSummary);
            pnlPaymentHeader.Controls.Add(lblConfirmationTitle);
            pnlPaymentHeader.Dock = DockStyle.Top;
            pnlPaymentHeader.Location = new Point(0, 0);
            pnlPaymentHeader.Name = "pnlPaymentHeader";
            pnlPaymentHeader.Size = new Size(820, 70);
            pnlPaymentHeader.TabIndex = 0;
            //
            // lblPaymentSummary
            //
            lblPaymentSummary.Dock = DockStyle.Fill;
            lblPaymentSummary.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentSummary.ForeColor = Color.FromArgb(201, 204, 242);
            lblPaymentSummary.Location = new Point(0, 36);
            lblPaymentSummary.Name = "lblPaymentSummary";
            lblPaymentSummary.Size = new Size(818, 32);
            lblPaymentSummary.TabIndex = 1;
            lblPaymentSummary.Text = "Please review the move-in and payment details before confirming.";
            lblPaymentSummary.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblConfirmationTitle
            //
            lblConfirmationTitle.Dock = DockStyle.Top;
            lblConfirmationTitle.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmationTitle.ForeColor = Color.White;
            lblConfirmationTitle.Location = new Point(0, 0);
            lblConfirmationTitle.Name = "lblConfirmationTitle";
            lblConfirmationTitle.Size = new Size(818, 36);
            lblConfirmationTitle.TabIndex = 0;
            lblConfirmationTitle.Text = "Confirm Payment";
            lblConfirmationTitle.TextAlign = ContentAlignment.BottomCenter;
            //
            // pnlPaymentDetails
            // Shared details, shown once (no longer one row per field).
            //
            pnlPaymentDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlPaymentDetails.Controls.Add(tblPaymentDetails);
            pnlPaymentDetails.Dock = DockStyle.Top;
            pnlPaymentDetails.Location = new Point(0, 70);
            pnlPaymentDetails.Name = "pnlPaymentDetails";
            pnlPaymentDetails.Padding = new Padding(16, 8, 16, 8);
            pnlPaymentDetails.Size = new Size(820, 118);
            pnlPaymentDetails.TabIndex = 1;
            //
            // tblPaymentDetails
            //
            tblPaymentDetails.ColumnCount = 4;
            tblPaymentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tblPaymentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tblPaymentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tblPaymentDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tblPaymentDetails.Controls.Add(lblConfirmDateTitle, 0, 0);
            tblPaymentDetails.Controls.Add(lblConfirmDateValue, 1, 0);
            tblPaymentDetails.Controls.Add(lblConfirmPaidAsTitle, 2, 0);
            tblPaymentDetails.Controls.Add(lblConfirmPaidAsValue, 3, 0);
            tblPaymentDetails.Controls.Add(lblConfirmRoomTitle, 0, 1);
            tblPaymentDetails.Controls.Add(lblConfirmRoomValue, 1, 1);
            tblPaymentDetails.Controls.Add(lblConfirmOccupantsTitle, 2, 1);
            tblPaymentDetails.Controls.Add(lblConfirmOccupantsValue, 3, 1);
            tblPaymentDetails.Controls.Add(lblConfirmCategoryTitle, 0, 2);
            tblPaymentDetails.Controls.Add(lblConfirmCategoryValue, 1, 2);
            tblPaymentDetails.Controls.Add(lblConfirmShareTitle, 2, 2);
            tblPaymentDetails.Controls.Add(lblConfirmShareValue, 3, 2);
            tblPaymentDetails.Dock = DockStyle.Fill;
            tblPaymentDetails.Location = new Point(16, 8);
            tblPaymentDetails.Name = "tblPaymentDetails";
            tblPaymentDetails.RowCount = 3;
            tblPaymentDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333F));
            tblPaymentDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333F));
            tblPaymentDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333F));
            tblPaymentDetails.Size = new Size(786, 100);
            tblPaymentDetails.TabIndex = 0;
            //
            // lblConfirmDateTitle
            //
            lblConfirmDateTitle.Dock = DockStyle.Fill;
            lblConfirmDateTitle.Font = new Font("Segoe UI", 10.8F);
            lblConfirmDateTitle.ForeColor = Color.FromArgb(201, 204, 242);
            lblConfirmDateTitle.Name = "lblConfirmDateTitle";
            lblConfirmDateTitle.TabIndex = 0;
            lblConfirmDateTitle.Text = "Date";
            lblConfirmDateTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmDateValue
            //
            lblConfirmDateValue.Dock = DockStyle.Fill;
            lblConfirmDateValue.Font = new Font("Segoe UI", 10.8F);
            lblConfirmDateValue.ForeColor = Color.White;
            lblConfirmDateValue.Name = "lblConfirmDateValue";
            lblConfirmDateValue.TabIndex = 1;
            lblConfirmDateValue.Text = "-";
            lblConfirmDateValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmPaidAsTitle
            //
            lblConfirmPaidAsTitle.Dock = DockStyle.Fill;
            lblConfirmPaidAsTitle.Font = new Font("Segoe UI", 10.8F);
            lblConfirmPaidAsTitle.ForeColor = Color.FromArgb(201, 204, 242);
            lblConfirmPaidAsTitle.Name = "lblConfirmPaidAsTitle";
            lblConfirmPaidAsTitle.TabIndex = 2;
            lblConfirmPaidAsTitle.Text = "Paid as";
            lblConfirmPaidAsTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmPaidAsValue
            //
            lblConfirmPaidAsValue.Dock = DockStyle.Fill;
            lblConfirmPaidAsValue.Font = new Font("Segoe UI", 10.8F);
            lblConfirmPaidAsValue.ForeColor = Color.White;
            lblConfirmPaidAsValue.Name = "lblConfirmPaidAsValue";
            lblConfirmPaidAsValue.TabIndex = 3;
            lblConfirmPaidAsValue.Text = "-";
            lblConfirmPaidAsValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmRoomTitle
            //
            lblConfirmRoomTitle.Dock = DockStyle.Fill;
            lblConfirmRoomTitle.Font = new Font("Segoe UI", 10.8F);
            lblConfirmRoomTitle.ForeColor = Color.FromArgb(201, 204, 242);
            lblConfirmRoomTitle.Name = "lblConfirmRoomTitle";
            lblConfirmRoomTitle.TabIndex = 4;
            lblConfirmRoomTitle.Text = "Room";
            lblConfirmRoomTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmRoomValue
            //
            lblConfirmRoomValue.Dock = DockStyle.Fill;
            lblConfirmRoomValue.Font = new Font("Segoe UI", 10.8F);
            lblConfirmRoomValue.ForeColor = Color.White;
            lblConfirmRoomValue.Name = "lblConfirmRoomValue";
            lblConfirmRoomValue.TabIndex = 5;
            lblConfirmRoomValue.Text = "-";
            lblConfirmRoomValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmOccupantsTitle
            //
            lblConfirmOccupantsTitle.Dock = DockStyle.Fill;
            lblConfirmOccupantsTitle.Font = new Font("Segoe UI", 10.8F);
            lblConfirmOccupantsTitle.ForeColor = Color.FromArgb(201, 204, 242);
            lblConfirmOccupantsTitle.Name = "lblConfirmOccupantsTitle";
            lblConfirmOccupantsTitle.TabIndex = 6;
            lblConfirmOccupantsTitle.Text = "Occupants";
            lblConfirmOccupantsTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmOccupantsValue
            //
            lblConfirmOccupantsValue.Dock = DockStyle.Fill;
            lblConfirmOccupantsValue.Font = new Font("Segoe UI", 10.8F);
            lblConfirmOccupantsValue.ForeColor = Color.White;
            lblConfirmOccupantsValue.Name = "lblConfirmOccupantsValue";
            lblConfirmOccupantsValue.TabIndex = 7;
            lblConfirmOccupantsValue.Text = "-";
            lblConfirmOccupantsValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmCategoryTitle
            //
            lblConfirmCategoryTitle.Dock = DockStyle.Fill;
            lblConfirmCategoryTitle.Font = new Font("Segoe UI", 10.8F);
            lblConfirmCategoryTitle.ForeColor = Color.FromArgb(201, 204, 242);
            lblConfirmCategoryTitle.Name = "lblConfirmCategoryTitle";
            lblConfirmCategoryTitle.TabIndex = 8;
            lblConfirmCategoryTitle.Text = "Category";
            lblConfirmCategoryTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmCategoryValue
            //
            lblConfirmCategoryValue.Dock = DockStyle.Fill;
            lblConfirmCategoryValue.Font = new Font("Segoe UI", 10.8F);
            lblConfirmCategoryValue.ForeColor = Color.White;
            lblConfirmCategoryValue.Name = "lblConfirmCategoryValue";
            lblConfirmCategoryValue.TabIndex = 9;
            lblConfirmCategoryValue.Text = "-";
            lblConfirmCategoryValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmShareTitle
            //
            lblConfirmShareTitle.Dock = DockStyle.Fill;
            lblConfirmShareTitle.Font = new Font("Segoe UI", 10.8F);
            lblConfirmShareTitle.ForeColor = Color.FromArgb(201, 204, 242);
            lblConfirmShareTitle.Name = "lblConfirmShareTitle";
            lblConfirmShareTitle.TabIndex = 10;
            lblConfirmShareTitle.Text = "Share each";
            lblConfirmShareTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblConfirmShareValue
            //
            lblConfirmShareValue.Dock = DockStyle.Fill;
            lblConfirmShareValue.Font = new Font("Segoe UI", 10.8F);
            lblConfirmShareValue.ForeColor = Color.White;
            lblConfirmShareValue.Name = "lblConfirmShareValue";
            lblConfirmShareValue.TabIndex = 11;
            lblConfirmShareValue.Text = "-";
            lblConfirmShareValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlConfirmContent
            //
            pnlConfirmContent.Controls.Add(dgvConfirmPayments);
            pnlConfirmContent.Controls.Add(pnlTotal);
            pnlConfirmContent.Controls.Add(lblCreditedTo);
            pnlConfirmContent.Controls.Add(lblDependents);
            pnlConfirmContent.Controls.Add(lblNotice);
            pnlConfirmContent.Dock = DockStyle.Fill;
            pnlConfirmContent.Location = new Point(0, 188);
            pnlConfirmContent.Name = "pnlConfirmContent";
            pnlConfirmContent.Padding = new Padding(16, 14, 16, 12);
            pnlConfirmContent.Size = new Size(820, 476);
            pnlConfirmContent.TabIndex = 2;
            //
            // dgvConfirmPayments
            // One row per payment that will be recorded.
            //
            dgvConfirmPayments.AllowUserToAddRows = false;
            dgvConfirmPayments.AllowUserToDeleteRows = false;
            dgvConfirmPayments.AllowUserToResizeRows = false;
            dgvConfirmPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConfirmPayments.BackgroundColor = Color.FromArgb(25, 25, 70);
            dgvConfirmPayments.BorderStyle = BorderStyle.FixedSingle;
            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(35, 37, 106);
            dgvHeaderStyle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.White;
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(35, 37, 106);
            dgvHeaderStyle.SelectionForeColor = Color.White;
            dgvHeaderStyle.WrapMode = DataGridViewTriState.False;
            dgvConfirmPayments.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvConfirmPayments.ColumnHeadersHeight = 36;
            dgvConfirmPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvConfirmPayments.Columns.AddRange(new DataGridViewColumn[] { colPayer, colType, colMethod, colReference, colCovers, colAmount });
            dgvCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle.BackColor = Color.FromArgb(25, 25, 70);
            dgvCellStyle.Font = new Font("Segoe UI", 10.2F);
            dgvCellStyle.ForeColor = Color.White;
            dgvCellStyle.SelectionBackColor = Color.FromArgb(25, 25, 70);
            dgvCellStyle.SelectionForeColor = Color.White;
            dgvCellStyle.WrapMode = DataGridViewTriState.False;
            dgvConfirmPayments.DefaultCellStyle = dgvCellStyle;
            dgvConfirmPayments.Dock = DockStyle.Fill;
            dgvConfirmPayments.EnableHeadersVisualStyles = false;
            dgvConfirmPayments.GridColor = Color.FromArgb(52, 56, 143);
            dgvConfirmPayments.Location = new Point(16, 14);
            dgvConfirmPayments.MultiSelect = false;
            dgvConfirmPayments.Name = "dgvConfirmPayments";
            dgvConfirmPayments.ReadOnly = true;
            dgvConfirmPayments.RowHeadersVisible = false;
            dgvConfirmPayments.RowHeadersWidth = 51;
            dgvConfirmPayments.RowTemplate.Height = 38;
            dgvConfirmPayments.ScrollBars = ScrollBars.Vertical;
            dgvConfirmPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConfirmPayments.Size = new Size(788, 202);
            dgvConfirmPayments.TabIndex = 0;
            dgvConfirmPayments.TabStop = false;
            //
            // colPayer
            //
            colPayer.FillWeight = 30F;
            colPayer.HeaderText = "Payer";
            colPayer.MinimumWidth = 6;
            colPayer.Name = "colPayer";
            colPayer.ReadOnly = true;
            //
            // colType
            //
            colType.FillWeight = 12F;
            colType.HeaderText = "Type";
            colType.MinimumWidth = 6;
            colType.Name = "colType";
            colType.ReadOnly = true;
            //
            // colMethod
            //
            colMethod.FillWeight = 11F;
            colMethod.HeaderText = "Method";
            colMethod.MinimumWidth = 6;
            colMethod.Name = "colMethod";
            colMethod.ReadOnly = true;
            //
            // colReference
            //
            colReference.FillWeight = 18F;
            colReference.HeaderText = "Reference No.";
            colReference.MinimumWidth = 6;
            colReference.Name = "colReference";
            colReference.ReadOnly = true;
            //
            // colCovers
            //
            colCovers.FillWeight = 17F;
            colCovers.HeaderText = "Covers Until";
            colCovers.MinimumWidth = 6;
            colCovers.Name = "colCovers";
            colCovers.ReadOnly = true;
            //
            // colAmount
            //
            dgvAmountStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvAmountStyle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            colAmount.DefaultCellStyle = dgvAmountStyle;
            colAmount.FillWeight = 14F;
            colAmount.HeaderText = "Amount";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;
            //
            // pnlTotal
            //
            pnlTotal.BackColor = Color.FromArgb(35, 37, 106);
            pnlTotal.Controls.Add(lblConfirmAmountValue);
            pnlTotal.Controls.Add(lblConfirmAmountTitle);
            pnlTotal.Dock = DockStyle.Bottom;
            pnlTotal.Location = new Point(16, 216);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Padding = new Padding(12, 0, 12, 0);
            pnlTotal.Size = new Size(788, 44);
            pnlTotal.TabIndex = 1;
            //
            // lblConfirmAmountValue
            //
            lblConfirmAmountValue.Dock = DockStyle.Right;
            lblConfirmAmountValue.Font = new Font("Segoe UI", 13.2F, FontStyle.Bold);
            lblConfirmAmountValue.ForeColor = Color.White;
            lblConfirmAmountValue.Location = new Point(546, 0);
            lblConfirmAmountValue.Name = "lblConfirmAmountValue";
            lblConfirmAmountValue.Size = new Size(230, 44);
            lblConfirmAmountValue.TabIndex = 1;
            lblConfirmAmountValue.Text = "₱0.00";
            lblConfirmAmountValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblConfirmAmountTitle
            //
            lblConfirmAmountTitle.Dock = DockStyle.Left;
            lblConfirmAmountTitle.Font = new Font("Segoe UI", 12F);
            lblConfirmAmountTitle.ForeColor = Color.White;
            lblConfirmAmountTitle.Location = new Point(12, 0);
            lblConfirmAmountTitle.Name = "lblConfirmAmountTitle";
            lblConfirmAmountTitle.Size = new Size(220, 44);
            lblConfirmAmountTitle.TabIndex = 0;
            lblConfirmAmountTitle.Text = "Total amount";
            lblConfirmAmountTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblCreditedTo
            // Whole Room only.
            //
            lblCreditedTo.BorderStyle = BorderStyle.FixedSingle;
            lblCreditedTo.Dock = DockStyle.Bottom;
            lblCreditedTo.Font = new Font("Segoe UI", 10.2F);
            lblCreditedTo.ForeColor = Color.White;
            lblCreditedTo.Location = new Point(16, 260);
            lblCreditedTo.Name = "lblCreditedTo";
            lblCreditedTo.Padding = new Padding(10, 6, 10, 6);
            lblCreditedTo.Size = new Size(788, 76);
            lblCreditedTo.TabIndex = 2;
            lblCreditedTo.Text = "Credited to:";
            lblCreditedTo.Visible = false;
            //
            // lblDependents
            //
            lblDependents.Dock = DockStyle.Bottom;
            lblDependents.Font = new Font("Segoe UI", 10.2F);
            lblDependents.ForeColor = Color.FromArgb(201, 204, 242);
            lblDependents.Location = new Point(16, 336);
            lblDependents.Name = "lblDependents";
            lblDependents.Size = new Size(788, 34);
            lblDependents.TabIndex = 3;
            lblDependents.Text = "Dependents (no billing): —";
            lblDependents.TextAlign = ContentAlignment.MiddleLeft;
            lblDependents.Visible = false;
            //
            // lblNotice
            //
            lblNotice.BackColor = Color.FromArgb(42, 42, 58);
            lblNotice.BorderStyle = BorderStyle.FixedSingle;
            lblNotice.Dock = DockStyle.Bottom;
            lblNotice.Font = new Font("Segoe UI", 10.2F);
            lblNotice.ForeColor = Color.FromArgb(253, 230, 138);
            lblNotice.Location = new Point(16, 370);
            lblNotice.Name = "lblNotice";
            lblNotice.Padding = new Padding(10, 6, 10, 6);
            lblNotice.Size = new Size(788, 94);
            lblNotice.TabIndex = 4;
            lblNotice.Text = "Confirming will move the listed occupants into the room and record the payments shown. Saved payments cannot be edited; a wrong payment must be voided.";
            lblNotice.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlLegacyConfirm
            // The old single-payment rows, kept (hidden) so the current
            // ConfirmPaymentForm.cs constructor still compiles. Type, method
            // and reference now show per payment in dgvConfirmPayments.
            //
            pnlLegacyConfirm.Controls.Add(lblConfirmPaymentTypeTitle);
            pnlLegacyConfirm.Controls.Add(lblConfirmPaymentTypeValue);
            pnlLegacyConfirm.Controls.Add(lblConfirmPaymentMethodTitle);
            pnlLegacyConfirm.Controls.Add(lblConfirmPaymentMethodValue);
            pnlLegacyConfirm.Controls.Add(lblConfirmReferenceTitle);
            pnlLegacyConfirm.Controls.Add(lblConfirmReferenceValue);
            pnlLegacyConfirm.Location = new Point(0, 188);
            pnlLegacyConfirm.Name = "pnlLegacyConfirm";
            pnlLegacyConfirm.Size = new Size(400, 100);
            pnlLegacyConfirm.TabIndex = 4;
            pnlLegacyConfirm.Visible = false;
            //
            // lblConfirmPaymentTypeTitle
            //
            lblConfirmPaymentTypeTitle.AutoSize = true;
            lblConfirmPaymentTypeTitle.ForeColor = Color.White;
            lblConfirmPaymentTypeTitle.Location = new Point(3, 0);
            lblConfirmPaymentTypeTitle.Name = "lblConfirmPaymentTypeTitle";
            lblConfirmPaymentTypeTitle.Size = new Size(100, 20);
            lblConfirmPaymentTypeTitle.TabIndex = 0;
            lblConfirmPaymentTypeTitle.Text = "Payment Type";
            //
            // lblConfirmPaymentTypeValue
            //
            lblConfirmPaymentTypeValue.AutoSize = true;
            lblConfirmPaymentTypeValue.ForeColor = Color.White;
            lblConfirmPaymentTypeValue.Location = new Point(200, 0);
            lblConfirmPaymentTypeValue.Name = "lblConfirmPaymentTypeValue";
            lblConfirmPaymentTypeValue.Size = new Size(15, 20);
            lblConfirmPaymentTypeValue.TabIndex = 1;
            lblConfirmPaymentTypeValue.Text = "-";
            //
            // lblConfirmPaymentMethodTitle
            //
            lblConfirmPaymentMethodTitle.AutoSize = true;
            lblConfirmPaymentMethodTitle.ForeColor = Color.White;
            lblConfirmPaymentMethodTitle.Location = new Point(3, 30);
            lblConfirmPaymentMethodTitle.Name = "lblConfirmPaymentMethodTitle";
            lblConfirmPaymentMethodTitle.Size = new Size(122, 20);
            lblConfirmPaymentMethodTitle.TabIndex = 2;
            lblConfirmPaymentMethodTitle.Text = "Payment Method";
            //
            // lblConfirmPaymentMethodValue
            //
            lblConfirmPaymentMethodValue.AutoSize = true;
            lblConfirmPaymentMethodValue.ForeColor = Color.White;
            lblConfirmPaymentMethodValue.Location = new Point(200, 30);
            lblConfirmPaymentMethodValue.Name = "lblConfirmPaymentMethodValue";
            lblConfirmPaymentMethodValue.Size = new Size(15, 20);
            lblConfirmPaymentMethodValue.TabIndex = 3;
            lblConfirmPaymentMethodValue.Text = "-";
            //
            // lblConfirmReferenceTitle
            //
            lblConfirmReferenceTitle.AutoSize = true;
            lblConfirmReferenceTitle.ForeColor = Color.White;
            lblConfirmReferenceTitle.Location = new Point(3, 60);
            lblConfirmReferenceTitle.Name = "lblConfirmReferenceTitle";
            lblConfirmReferenceTitle.Size = new Size(131, 20);
            lblConfirmReferenceTitle.TabIndex = 4;
            lblConfirmReferenceTitle.Text = "Reference Number";
            //
            // lblConfirmReferenceValue
            //
            lblConfirmReferenceValue.AutoSize = true;
            lblConfirmReferenceValue.ForeColor = Color.White;
            lblConfirmReferenceValue.Location = new Point(200, 60);
            lblConfirmReferenceValue.Name = "lblConfirmReferenceValue";
            lblConfirmReferenceValue.Size = new Size(15, 20);
            lblConfirmReferenceValue.TabIndex = 5;
            lblConfirmReferenceValue.Text = "-";
            //
            // panel2
            //
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblReceiptsLine);
            panel2.Controls.Add(btnConfirmPayment);
            panel2.Controls.Add(btnCancelPayment);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 664);
            panel2.Name = "panel2";
            panel2.Size = new Size(820, 56);
            panel2.TabIndex = 3;
            //
            // lblReceiptsLine
            //
            lblReceiptsLine.Font = new Font("Segoe UI", 10.2F);
            lblReceiptsLine.ForeColor = Color.FromArgb(201, 204, 242);
            lblReceiptsLine.Location = new Point(16, 9);
            lblReceiptsLine.Name = "lblReceiptsLine";
            lblReceiptsLine.Size = new Size(380, 36);
            lblReceiptsLine.TabIndex = 2;
            lblReceiptsLine.Text = "1 payment · 1 receipt";
            lblReceiptsLine.TextAlign = ContentAlignment.MiddleLeft;
            //
            // btnConfirmPayment
            //
            btnConfirmPayment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConfirmPayment.Cursor = Cursors.Hand;
            btnConfirmPayment.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnConfirmPayment.Location = new Point(666, 9);
            btnConfirmPayment.Name = "btnConfirmPayment";
            btnConfirmPayment.Size = new Size(140, 36);
            btnConfirmPayment.TabIndex = 1;
            btnConfirmPayment.Text = "Confirm";
            btnConfirmPayment.UseVisualStyleBackColor = true;
            btnConfirmPayment.Click += btnConfirmPayment_Click;
            //
            // btnCancelPayment
            //
            btnCancelPayment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelPayment.Cursor = Cursors.Hand;
            btnCancelPayment.Font = new Font("Segoe UI", 10.8F);
            btnCancelPayment.Location = new Point(530, 9);
            btnCancelPayment.Name = "btnCancelPayment";
            btnCancelPayment.Size = new Size(120, 36);
            btnCancelPayment.TabIndex = 0;
            btnCancelPayment.Text = "Cancel";
            btnCancelPayment.UseVisualStyleBackColor = true;
            btnCancelPayment.Click += btnCancelPayment_Click;
            //
            // ConfirmPaymentForm
            //
            AcceptButton = btnConfirmPayment;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            CancelButton = btnCancelPayment;
            ClientSize = new Size(820, 720);
            Controls.Add(pnlConfirmContent);
            Controls.Add(pnlLegacyConfirm);
            Controls.Add(panel2);
            Controls.Add(pnlPaymentDetails);
            Controls.Add(pnlPaymentHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfirmPaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Payment";
            Load += ConfirmPaymentForm_Load;
            pnlPaymentHeader.ResumeLayout(false);
            pnlPaymentDetails.ResumeLayout(false);
            tblPaymentDetails.ResumeLayout(false);
            pnlConfirmContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConfirmPayments).EndInit();
            pnlTotal.ResumeLayout(false);
            pnlLegacyConfirm.ResumeLayout(false);
            pnlLegacyConfirm.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // ---- Existing controls (names unchanged; ConfirmPaymentForm.cs uses them) ----
        private Panel pnlPaymentDetails;
        private Panel pnlPaymentHeader;
        private Panel panel2;
        private Label lblConfirmationTitle;
        private Button btnConfirmPayment;
        private Button btnCancelPayment;
        private Label lblPaymentSummary;
        private TableLayoutPanel tblPaymentDetails;
        private Label lblConfirmReferenceValue;
        private Label lblConfirmReferenceTitle;
        private Label lblConfirmAmountValue;
        private Label lblConfirmAmountTitle;
        private Label lblConfirmPaymentMethodValue;
        private Label lblConfirmPaymentMethodTitle;
        private Label lblConfirmCategoryValue;
        private Label lblConfirmCategoryTitle;
        private Label lblConfirmDateValue;
        private Label lblConfirmDateTitle;
        private Label lblConfirmPaymentTypeValue;
        private Label lblConfirmPaymentTypeTitle;

        // ---- New controls (C1 · Summary table) ----
        private Label lblConfirmPaidAsTitle;
        private Label lblConfirmPaidAsValue;
        private Label lblConfirmRoomTitle;
        private Label lblConfirmRoomValue;
        private Label lblConfirmOccupantsTitle;
        private Label lblConfirmOccupantsValue;
        private Label lblConfirmShareTitle;
        private Label lblConfirmShareValue;
        private Panel pnlConfirmContent;
        private DataGridView dgvConfirmPayments;
        private DataGridViewTextBoxColumn colPayer;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colMethod;
        private DataGridViewTextBoxColumn colReference;
        private DataGridViewTextBoxColumn colCovers;
        private DataGridViewTextBoxColumn colAmount;
        private Panel pnlTotal;
        private Label lblCreditedTo;
        private Label lblDependents;
        private Label lblNotice;
        private Panel pnlLegacyConfirm;
        private Label lblReceiptsLine;
    }
}