namespace Capstoneszn.Forms.PaymentsForms
{
    partial class RevisedBillingPaymentForm
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
            label1 = new Label();
            rbIndividual = new RadioButton();
            rbWholeRoom = new RadioButton();
            label2 = new Label();
            cboPayer = new ComboBox();
            dtpPaymentDate = new DateTimePicker();
            label3 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            chkMaintenance = new CheckBox();
            chkWater = new CheckBox();
            chkRent = new CheckBox();
            chkAll = new CheckBox();
            label5 = new Label();
            lblMaintenanceType = new Label();
            lblWaterType = new Label();
            lblTotalAmountToPay = new Label();
            lblTotalOwed = new Label();
            label9 = new Label();
            lblRentType = new Label();
            lblMaintenancePay = new Label();
            lblMaintenanceBill = new Label();
            lblWaterBill = new Label();
            lblRentBill = new Label();
            label6 = new Label();
            label4 = new Label();
            txtRentPay = new TextBox();
            txtWaterPay = new TextBox();
            label7 = new Label();
            rbCash = new RadioButton();
            rbGcash = new RadioButton();
            panel1 = new Panel();
            btnContinue = new Button();
            btnCancel = new Button();
            btnClear = new Button();
            txtRefNo = new TextBox();
            label8 = new Label();
            panel2 = new Panel();
            lblCreditTo = new Label();
            cboCreditTo = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 11);
            label1.Name = "label1";
            label1.Size = new Size(76, 28);
            label1.TabIndex = 0;
            label1.Text = "Pay for:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rbIndividual
            // 
            rbIndividual.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbIndividual.ForeColor = Color.White;
            rbIndividual.Location = new Point(82, 2);
            rbIndividual.Name = "rbIndividual";
            rbIndividual.Size = new Size(125, 47);
            rbIndividual.TabIndex = 1;
            rbIndividual.TabStop = true;
            rbIndividual.Text = "Individual";
            rbIndividual.TextAlign = ContentAlignment.MiddleCenter;
            rbIndividual.UseVisualStyleBackColor = false;
            // 
            // rbWholeRoom
            // 
            rbWholeRoom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbWholeRoom.ForeColor = Color.White;
            rbWholeRoom.Location = new Point(204, 2);
            rbWholeRoom.Name = "rbWholeRoom";
            rbWholeRoom.Size = new Size(166, 47);
            rbWholeRoom.TabIndex = 1;
            rbWholeRoom.TabStop = true;
            rbWholeRoom.Text = "Whole Room";
            rbWholeRoom.TextAlign = ContentAlignment.MiddleCenter;
            rbWholeRoom.UseVisualStyleBackColor = false;
            rbWholeRoom.CheckedChanged += rbWholeRoom_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 90);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 0;
            label2.Text = "Payer:";
            // 
            // cboPayer
            // 
            cboPayer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboPayer.FormattingEnabled = true;
            cboPayer.Location = new Point(94, 87);
            cboPayer.Name = "cboPayer";
            cboPayer.Size = new Size(288, 36);
            cboPayer.TabIndex = 2;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Enabled = false;
            dtpPaymentDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpPaymentDate.Format = DateTimePickerFormat.Custom;
            dtpPaymentDate.Location = new Point(623, 20);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(232, 34);
            dtpPaymentDate.TabIndex = 3;
            dtpPaymentDate.Value = new DateTime(2026, 10, 27, 0, 0, 0, 0);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(560, 26);
            label3.Name = "label3";
            label3.Size = new Size(57, 28);
            label3.TabIndex = 0;
            label3.Text = "Date:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.52195F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.3855286F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.1138783F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.7838287F));
            tableLayoutPanel1.Controls.Add(chkMaintenance, 0, 3);
            tableLayoutPanel1.Controls.Add(chkWater, 0, 2);
            tableLayoutPanel1.Controls.Add(chkRent, 0, 1);
            tableLayoutPanel1.Controls.Add(chkAll, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 2, 0);
            tableLayoutPanel1.Controls.Add(lblMaintenanceType, 3, 3);
            tableLayoutPanel1.Controls.Add(lblWaterType, 3, 2);
            tableLayoutPanel1.Controls.Add(lblTotalAmountToPay, 2, 4);
            tableLayoutPanel1.Controls.Add(lblTotalOwed, 1, 4);
            tableLayoutPanel1.Controls.Add(label9, 0, 4);
            tableLayoutPanel1.Controls.Add(lblRentType, 3, 1);
            tableLayoutPanel1.Controls.Add(lblMaintenancePay, 2, 3);
            tableLayoutPanel1.Controls.Add(lblMaintenanceBill, 1, 3);
            tableLayoutPanel1.Controls.Add(lblWaterBill, 1, 2);
            tableLayoutPanel1.Controls.Add(lblRentBill, 1, 1);
            tableLayoutPanel1.Controls.Add(label6, 3, 0);
            tableLayoutPanel1.Controls.Add(label4, 1, 0);
            tableLayoutPanel1.Controls.Add(txtRentPay, 2, 1);
            tableLayoutPanel1.Controls.Add(txtWaterPay, 2, 2);
            tableLayoutPanel1.Location = new Point(12, 145);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.1627922F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 48.8372078F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.Size = new Size(843, 223);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // chkMaintenance
            // 
            chkMaintenance.AutoSize = true;
            chkMaintenance.Dock = DockStyle.Fill;
            chkMaintenance.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkMaintenance.ForeColor = Color.White;
            chkMaintenance.Location = new Point(4, 146);
            chkMaintenance.Name = "chkMaintenance";
            chkMaintenance.Size = new Size(166, 39);
            chkMaintenance.TabIndex = 0;
            chkMaintenance.Text = "Maintenance";
            chkMaintenance.UseVisualStyleBackColor = true;
            chkMaintenance.CheckedChanged += chkMaintenance_CheckedChanged;
            // 
            // chkWater
            // 
            chkWater.AutoSize = true;
            chkWater.Dock = DockStyle.Fill;
            chkWater.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkWater.ForeColor = Color.White;
            chkWater.Location = new Point(4, 103);
            chkWater.Name = "chkWater";
            chkWater.Size = new Size(166, 36);
            chkWater.TabIndex = 0;
            chkWater.Text = "Water";
            chkWater.UseVisualStyleBackColor = true;
            chkWater.CheckedChanged += chkWater_CheckedChanged;
            // 
            // chkRent
            // 
            chkRent.AutoSize = true;
            chkRent.Dock = DockStyle.Fill;
            chkRent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkRent.ForeColor = Color.White;
            chkRent.Location = new Point(4, 55);
            chkRent.Name = "chkRent";
            chkRent.Size = new Size(166, 41);
            chkRent.TabIndex = 0;
            chkRent.Text = "Rent";
            chkRent.UseVisualStyleBackColor = true;
            chkRent.CheckedChanged += chkRent_CheckedChanged;
            // 
            // chkAll
            // 
            chkAll.AutoSize = true;
            chkAll.Dock = DockStyle.Fill;
            chkAll.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            chkAll.ForeColor = Color.White;
            chkAll.Location = new Point(4, 4);
            chkAll.Name = "chkAll";
            chkAll.Size = new Size(166, 44);
            chkAll.TabIndex = 0;
            chkAll.Text = "Category";
            chkAll.UseVisualStyleBackColor = true;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(391, 1);
            label5.Name = "label5";
            label5.Size = new Size(230, 50);
            label5.TabIndex = 0;
            label5.Text = "Amount to pay";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaintenanceType
            // 
            lblMaintenanceType.AutoSize = true;
            lblMaintenanceType.Dock = DockStyle.Fill;
            lblMaintenanceType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceType.ForeColor = Color.White;
            lblMaintenanceType.Location = new Point(628, 143);
            lblMaintenanceType.Name = "lblMaintenanceType";
            lblMaintenanceType.Size = new Size(211, 45);
            lblMaintenanceType.TabIndex = 0;
            lblMaintenanceType.Text = "Partial";
            lblMaintenanceType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWaterType
            // 
            lblWaterType.AutoSize = true;
            lblWaterType.Dock = DockStyle.Fill;
            lblWaterType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWaterType.ForeColor = Color.White;
            lblWaterType.Location = new Point(628, 100);
            lblWaterType.Name = "lblWaterType";
            lblWaterType.Size = new Size(211, 42);
            lblWaterType.TabIndex = 0;
            lblWaterType.Text = "Full";
            lblWaterType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalAmountToPay
            // 
            lblTotalAmountToPay.AutoSize = true;
            lblTotalAmountToPay.Dock = DockStyle.Fill;
            lblTotalAmountToPay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalAmountToPay.ForeColor = Color.White;
            lblTotalAmountToPay.Location = new Point(391, 189);
            lblTotalAmountToPay.Name = "lblTotalAmountToPay";
            lblTotalAmountToPay.Size = new Size(230, 33);
            lblTotalAmountToPay.TabIndex = 0;
            lblTotalAmountToPay.Text = "lblTotalAmountToPay";
            lblTotalAmountToPay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalOwed
            // 
            lblTotalOwed.AutoSize = true;
            lblTotalOwed.Dock = DockStyle.Fill;
            lblTotalOwed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalOwed.ForeColor = Color.White;
            lblTotalOwed.Location = new Point(177, 189);
            lblTotalOwed.Name = "lblTotalOwed";
            lblTotalOwed.Size = new Size(207, 33);
            lblTotalOwed.TabIndex = 0;
            lblTotalOwed.Text = "lblTotalOwed";
            lblTotalOwed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(4, 189);
            label9.Name = "label9";
            label9.Size = new Size(166, 33);
            label9.TabIndex = 0;
            label9.Text = "Totals:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRentType
            // 
            lblRentType.AutoSize = true;
            lblRentType.Dock = DockStyle.Fill;
            lblRentType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRentType.ForeColor = Color.White;
            lblRentType.Location = new Point(628, 52);
            lblRentType.Name = "lblRentType";
            lblRentType.Size = new Size(211, 47);
            lblRentType.TabIndex = 0;
            lblRentType.Text = "Advance";
            lblRentType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaintenancePay
            // 
            lblMaintenancePay.AutoSize = true;
            lblMaintenancePay.Dock = DockStyle.Fill;
            lblMaintenancePay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenancePay.ForeColor = Color.White;
            lblMaintenancePay.Location = new Point(391, 143);
            lblMaintenancePay.Name = "lblMaintenancePay";
            lblMaintenancePay.Size = new Size(230, 45);
            lblMaintenancePay.TabIndex = 0;
            lblMaintenancePay.Text = "lblMaintenancePay";
            lblMaintenancePay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaintenanceBill
            // 
            lblMaintenanceBill.AutoSize = true;
            lblMaintenanceBill.Dock = DockStyle.Fill;
            lblMaintenanceBill.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaintenanceBill.ForeColor = Color.White;
            lblMaintenanceBill.Location = new Point(177, 143);
            lblMaintenanceBill.Name = "lblMaintenanceBill";
            lblMaintenanceBill.Size = new Size(207, 45);
            lblMaintenanceBill.TabIndex = 0;
            lblMaintenanceBill.Text = "lblMaintenanceBill";
            lblMaintenanceBill.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWaterBill
            // 
            lblWaterBill.AutoSize = true;
            lblWaterBill.Dock = DockStyle.Fill;
            lblWaterBill.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWaterBill.ForeColor = Color.White;
            lblWaterBill.Location = new Point(177, 100);
            lblWaterBill.Name = "lblWaterBill";
            lblWaterBill.Size = new Size(207, 42);
            lblWaterBill.TabIndex = 0;
            lblWaterBill.Text = "lblWaterBill";
            lblWaterBill.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRentBill
            // 
            lblRentBill.AutoSize = true;
            lblRentBill.Dock = DockStyle.Fill;
            lblRentBill.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRentBill.ForeColor = Color.White;
            lblRentBill.Location = new Point(177, 52);
            lblRentBill.Name = "lblRentBill";
            lblRentBill.Size = new Size(207, 47);
            lblRentBill.TabIndex = 0;
            lblRentBill.Text = "rentBill";
            lblRentBill.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(628, 1);
            label6.Name = "label6";
            label6.Size = new Size(211, 50);
            label6.TabIndex = 0;
            label6.Text = "Type";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(177, 1);
            label4.Name = "label4";
            label4.Size = new Size(207, 50);
            label4.TabIndex = 0;
            label4.Text = "Owed";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtRentPay
            // 
            txtRentPay.BackColor = Color.FromArgb(25, 25, 70);
            txtRentPay.BorderStyle = BorderStyle.None;
            txtRentPay.Dock = DockStyle.Fill;
            txtRentPay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRentPay.Location = new Point(391, 55);
            txtRentPay.Name = "txtRentPay";
            txtRentPay.PlaceholderText = "Enter amount";
            txtRentPay.Size = new Size(230, 27);
            txtRentPay.TabIndex = 1;
            txtRentPay.TextAlign = HorizontalAlignment.Center;
            // 
            // txtWaterPay
            // 
            txtWaterPay.BackColor = Color.FromArgb(25, 25, 70);
            txtWaterPay.BorderStyle = BorderStyle.None;
            txtWaterPay.Dock = DockStyle.Fill;
            txtWaterPay.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWaterPay.Location = new Point(391, 103);
            txtWaterPay.Name = "txtWaterPay";
            txtWaterPay.PlaceholderText = "Enter amount";
            txtWaterPay.Size = new Size(230, 27);
            txtWaterPay.TabIndex = 1;
            txtWaterPay.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(4, 20);
            label7.Name = "label7";
            label7.Size = new Size(165, 28);
            label7.TabIndex = 0;
            label7.Text = "Payment method:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rbCash
            // 
            rbCash.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbCash.ForeColor = Color.White;
            rbCash.Location = new Point(174, 11);
            rbCash.Name = "rbCash";
            rbCash.Size = new Size(118, 47);
            rbCash.TabIndex = 1;
            rbCash.TabStop = true;
            rbCash.Text = "Cash";
            rbCash.TextAlign = ContentAlignment.MiddleCenter;
            rbCash.UseVisualStyleBackColor = false;
            // 
            // rbGcash
            // 
            rbGcash.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbGcash.ForeColor = Color.White;
            rbGcash.Location = new Point(298, 11);
            rbGcash.Name = "rbGcash";
            rbGcash.Size = new Size(133, 47);
            rbGcash.TabIndex = 1;
            rbGcash.TabStop = true;
            rbGcash.Text = "Gcash";
            rbGcash.TextAlign = ContentAlignment.MiddleCenter;
            rbGcash.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnContinue);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(txtRefNo);
            panel1.Controls.Add(rbCash);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(rbGcash);
            panel1.Location = new Point(12, 387);
            panel1.Name = "panel1";
            panel1.Size = new Size(839, 153);
            panel1.TabIndex = 5;
            // 
            // btnContinue
            // 
            btnContinue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnContinue.Location = new Point(720, 107);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(114, 41);
            btnContinue.TabIndex = 3;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(605, 107);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 41);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(487, 107);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 41);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtRefNo
            // 
            txtRefNo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRefNo.Location = new Point(174, 64);
            txtRefNo.Name = "txtRefNo";
            txtRefNo.Size = new Size(257, 34);
            txtRefNo.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(4, 67);
            label8.Name = "label8";
            label8.Size = new Size(136, 28);
            label8.TabIndex = 0;
            label8.Text = "Reference No.:";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(rbWholeRoom);
            panel2.Controls.Add(rbIndividual);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(384, 52);
            panel2.TabIndex = 6;
            // 
            // lblCreditTo
            // 
            lblCreditTo.AutoSize = true;
            lblCreditTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreditTo.ForeColor = Color.White;
            lblCreditTo.Location = new Point(430, 90);
            lblCreditTo.Name = "lblCreditTo";
            lblCreditTo.Size = new Size(138, 28);
            lblCreditTo.TabIndex = 0;
            lblCreditTo.Text = "Extra credit to:";
            lblCreditTo.Visible = false;
            // 
            // cboCreditTo
            // 
            cboCreditTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCreditTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboCreditTo.FormattingEnabled = true;
            cboCreditTo.Location = new Point(583, 87);
            cboCreditTo.Name = "cboCreditTo";
            cboCreditTo.Size = new Size(272, 36);
            cboCreditTo.TabIndex = 3;
            cboCreditTo.Visible = false;
            // 
            // RevisedBillingPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 70);
            ClientSize = new Size(867, 552);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(dtpPaymentDate);
            Controls.Add(cboPayer);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(lblCreditTo);
            Controls.Add(cboCreditTo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RevisedBillingPaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Payment";
            Load += RevisedBillingPaymentForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton rbIndividual;
        private RadioButton rbWholeRoom;
        private Label label2;
        private ComboBox cboPayer;
        private DateTimePicker dtpPaymentDate;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox chkMaintenance;
        private CheckBox chkWater;
        private CheckBox chkRent;
        private CheckBox chkAll;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblMaintenanceType;
        private Label lblWaterType;
        private Label lblRentType;
        private Label lblMaintenancePay;
        private Label lblMaintenanceBill;
        private Label lblWaterBill;
        private Label lblRentBill;
        private TextBox txtRentPay;
        private TextBox txtWaterPay;
        private Label label7;
        private Label lblTotalAmountToPay;
        private Label lblTotalOwed;
        private Label label9;
        private RadioButton rbCash;
        private RadioButton rbGcash;
        private Panel panel1;
        private Button btnContinue;
        private Button btnCancel;
        private Button btnClear;
        private TextBox txtRefNo;
        private Label label8;
        private Panel panel2;
        private Label lblCreditTo;       // NEW (credit choice)
        private ComboBox cboCreditTo;    // NEW (credit choice)
    }
}