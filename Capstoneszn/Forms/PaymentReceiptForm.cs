using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms
{
    /// <summary>
    /// The receipt for one payment: who paid, how, and what each peso
    /// settled (bill period, maintenance issue, or advance credit).
    /// A voided payment shows a red VOIDED banner with the reason, on
    /// screen and on paper.
    ///
    /// Print / PDF opens a print preview; choosing the "Microsoft Print to
    /// PDF" printer there saves it as a PDF.
    /// </summary>
    /// 

    public partial class PaymentReceiptForm : Form
    {

        private readonly int _paymentId;
        private PaymentReceipt? _receipt;

        public PaymentReceiptForm(int paymentId)
        {
            InitializeComponent();
            _paymentId = paymentId;
            SetUpLinesGrid();
        }

        private void SetUpLinesGrid()
        {
            var g = dgvReceiptLines;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            g.ReadOnly = true;
            g.RowHeadersVisible = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.DefaultCellStyle.SelectionBackColor = Color.White;   // receipt look, no blue highlight
            g.DefaultCellStyle.SelectionForeColor = Color.Black;

            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLineTenant", HeaderText = "Tenant", FillWeight = 30 });
            g.Columns.Add(new DataGridViewTextBoxColumn { Name = "colLineFor", HeaderText = "Applied To", FillWeight = 50 });
            var amt = new DataGridViewTextBoxColumn { Name = "colLineAmount", HeaderText = "Amount", FillWeight = 20 };
            amt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            g.Columns.Add(amt);
        }


        private void PaymentReceiptForm_Load(object sender, EventArgs e)
        {
            try
            {
                _receipt = PaymentHistoryService.GetReceipt(_paymentId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the receipt.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (_receipt == null)
            {
                MessageBox.Show("This payment no longer exists.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            PaymentHistoryRow p = _receipt.Payment;

            Text = "Receipt " + p.ReceiptNo;
            lblReceiptTitle.Text = _receipt.BuildingName + "\r\nOFFICIAL RECEIPT";

            lblVoidBanner.Visible = p.IsVoided;
            if (p.IsVoided)
                lblVoidBanner.Text = "VOIDED" +
                    (p.VoidedAt.HasValue ? " on " + p.VoidedAt.Value.ToString("MMM dd, yyyy") : "") +
                    " - " + p.VoidReason;

            lblReceiptInfo.Text = InfoText(p);

            foreach (PaymentAllocationLine line in _receipt.Lines)
                dgvReceiptLines.Rows.Add(line.TenantName, line.AppliedTo, "₱" + line.Amount.ToString("N2"));

            lblReceiptTotal.Text = "TOTAL PAID:  ₱" + p.Amount.ToString("N2");
        }

        /// <summary>The header block, shared by the screen and the printout.</summary>
        private string InfoText(PaymentHistoryRow p)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Receipt No. : " + p.ReceiptNo);
            sb.AppendLine("Date        : " + p.PaymentDate.ToString("MMMM dd, yyyy") +
                          "   (recorded " + p.RecordedAt.ToString("hh:mm tt") + ")");
            sb.AppendLine("Received from: " + p.TenantName);
            sb.AppendLine("Room        : " + p.RoomNumber + (p.CoversRoom ? "  (Whole Room payment)" : ""));
            sb.AppendLine("Category    : " + p.Category);
            sb.AppendLine("Type        : " + p.PaymentType);
            sb.AppendLine("Method      : " + p.Method + (p.ReferenceNo.Length > 0 ? "  Ref: " + p.ReferenceNo : ""));
            if (_receipt != null && _receipt.RecordedBy.Length > 0)
                sb.AppendLine("Received by : " + _receipt.RecordedBy);
            return sb.ToString();
        }

        /* ------------------------------------------------------------------
           Print / PDF
           ------------------------------------------------------------------ */

        private void btnCloseReceipt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (_receipt == null) return;

            using (var doc = new PrintDocument())
            using (var preview = new PrintPreviewDialog())
            {
                doc.DocumentName = "Receipt " + _receipt.Payment.ReceiptNo;
                doc.PrintPage += Doc_PrintPage;

                preview.Document = doc;
                preview.Width = 900;
                preview.Height = 800;
                preview.StartPosition = FormStartPosition.CenterParent;
                preview.ShowDialog(this);
            }
        }

        /// <summary>Draws the receipt on one page.</summary>
        private void Doc_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (_receipt == null || e.Graphics == null) return;

            PaymentHistoryRow p = _receipt.Payment;
            Graphics g = e.Graphics;
            float left = e.MarginBounds.Left;
            float width = e.MarginBounds.Width;
            float y = e.MarginBounds.Top;

            using (var titleFont = new Font("Segoe UI", 16F, FontStyle.Bold))
            using (var boldFont = new Font("Segoe UI", 11F, FontStyle.Bold))
            using (var monoFont = new Font("Consolas", 10.5F))
            using (var bodyFont = new Font("Segoe UI", 10.5F))
            using (var center = new StringFormat { Alignment = StringAlignment.Center })
            using (var right = new StringFormat { Alignment = StringAlignment.Far })
            {
                // Title
                g.DrawString(_receipt.BuildingName, titleFont, Brushes.Black,
                             new RectangleF(left, y, width, 30), center);
                y += 32;
                g.DrawString("OFFICIAL RECEIPT", boldFont, Brushes.Black,
                             new RectangleF(left, y, width, 22), center);
                y += 34;

                // Voided stamp
                if (p.IsVoided)
                {
                    g.DrawString("*** VOIDED *** " + p.VoidReason, boldFont, Brushes.DarkRed,
                                 new RectangleF(left, y, width, 40), center);
                    y += 44;
                }

                // Header block
                foreach (string line in InfoText(p).Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    g.DrawString(line, monoFont, Brushes.Black, left, y);
                    y += 20;
                }
                y += 10;
                g.DrawLine(Pens.Black, left, y, left + width, y);
                y += 8;

                // Lines
                g.DrawString("Tenant", boldFont, Brushes.Black, left, y);
                g.DrawString("Applied To", boldFont, Brushes.Black, left + width * 0.30f, y);
                g.DrawString("Amount", boldFont, Brushes.Black, new RectangleF(left, y, width, 22), right);
                y += 26;

                foreach (PaymentAllocationLine line in _receipt.Lines)
                {
                    g.DrawString(line.TenantName, bodyFont, Brushes.Black,
                                 new RectangleF(left, y, width * 0.29f, 20));
                    g.DrawString(line.AppliedTo, bodyFont, Brushes.Black,
                                 new RectangleF(left + width * 0.30f, y, width * 0.50f, 20));
                    g.DrawString("₱" + line.Amount.ToString("N2"), bodyFont, Brushes.Black,
                                 new RectangleF(left, y, width, 20), right);
                    y += 22;
                }

                y += 6;
                g.DrawLine(Pens.Black, left, y, left + width, y);
                y += 10;
                g.DrawString("TOTAL PAID:  ₱" + p.Amount.ToString("N2"), titleFont, Brushes.Black,
                             new RectangleF(left, y, width, 30), right);
                y += 50;

                g.DrawString("Printed " + DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"),
                             bodyFont, Brushes.Gray, left, y);
            }

            e.HasMorePages = false;
        }

    }
}
