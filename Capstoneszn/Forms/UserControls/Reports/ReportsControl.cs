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

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// Reports: money in and money out for a date range.
    ///
    /// Settled rules:
    ///   - One filter bar for all tabs (Date From / To, Room, Generate, Clear, Print).
    ///   - Summary: Rent, Utilities, Maintenance collected, Expenses, Net Income.
    ///   - Net Income = Rent collected - Expenses. Water / maintenance
    ///     collections are reimbursements and are NOT income.
    ///   - The Room filter applies to the Received tab (and the collected
    ///     boxes) only. Expenses are building-wide, so with one room chosen
    ///     Net Income is not shown - it would mix one room's rent with the
    ///     whole building's expenses.
    ///   - Voided payments are never counted.
    /// </summary>
    /// 

    public partial class ReportsControl : UserControl
    {

        private const string AllRooms = "All Rooms";

        private static readonly Color CardBack = Color.FromArgb(20, 32, 58);

        // Results of the last Generate, kept for printing.
        private List<ReportReceivedRow> _received = new List<ReportReceivedRow>();
        private List<ExpenseRow> _expenses = new List<ExpenseRow>();
        private DateTime _from, _to;
        private string _roomText = AllRooms;
        private decimal _rent, _utilities, _maintenance, _expenseTotal;
        private bool _netShown;

        // Summary value labels, created in code.
        private Label _lblRent = new Label(), _lblUtilities = new Label(), _lblMaintenance = new Label(),
                      _lblExpenses = new Label(), _lblNet = new Label();

        // Printing state (pages).
        private List<PrintLine> _printLines = new List<PrintLine>();
        private int _printIndex;

        public ReportsControl()
        {
            InitializeComponent();

            BuildSummaryCards();
            SetUpGrid(dgvReceived, new[] { ("Date", 12f), ("Receipt No.", 15f), ("Tenant", 22f),
                                           ("Room", 8f), ("Category", 12f), ("Method", 10f), ("Amount", 13f) });
            SetUpGrid(dgvExpenses, new[] { ("Date", 14f), ("Category", 16f), ("Description", 50f), ("Amount", 16f) });

            // Wired here only - do not double-click these in the designer.
            btnGenerateReport.Click += (s, e) => GenerateReport();
            btnClearReport.Click += (s, e) => { ResetFilters(); GenerateReport(); };
            btnPrintReport.Click += (s, e) => PrintReport();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;

            LoadRooms();
            ResetFilters();
            GenerateReport();
        }

        /* ==================================================================
           SET-UP
           ================================================================== */

        private void BuildSummaryCards()
        {
            tlpSummary.Controls.Clear();
            AddCard(0, "Rent Collected", _lblRent);
            AddCard(1, "Utilities Collected", _lblUtilities);
            AddCard(2, "Maintenance Collected", _lblMaintenance);
            AddCard(3, "Expenses", _lblExpenses);
            AddCard(4, "Net Income", _lblNet);
        }

        private void AddCard(int column, string title, Label value)
        {
            var card = new Panel { Dock = DockStyle.Fill, BackColor = CardBack, Margin = new Padding(4) };

            value.Dock = DockStyle.Fill;
            value.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            value.ForeColor = Color.White;
            value.TextAlign = ContentAlignment.MiddleCenter;
            value.Text = "₱0.00";

            var caption = new Label
            {
                Dock = DockStyle.Top,
                Height = 26,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Silver,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = title
            };

            card.Controls.Add(value);     // Fill first, then Top, so docking lays out correctly
            card.Controls.Add(caption);
            tlpSummary.Controls.Add(card, column, 0);
        }

        private static void SetUpGrid(DataGridView grid, (string Header, float Weight)[] columns)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.FromArgb(11, 20, 38);
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            grid.Columns.Clear();
            foreach (var c in columns)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = c.Header,
                    FillWeight = c.Weight,
                    ReadOnly = true,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                if (c.Header == "Amount")
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns.Add(col);
            }
        }

        private void LoadRooms()
        {
            cboReportRoom.Items.Clear();
            cboReportRoom.Items.Add(AllRooms);

            try
            {
                foreach (ReportRoom room in ReportService.GetRooms(Session.BuildingId))
                    cboReportRoom.Items.Add(room);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load rooms.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>This month, all rooms.</summary>
        private void ResetFilters()
        {
            DateTime today = DateTime.Today;
            dtpReportFrom.MaxDate = DateTimePicker.MaximumDateTime;   // avoid min/max clashes while setting
            dtpReportTo.MaxDate = DateTimePicker.MaximumDateTime;
            dtpReportFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpReportTo.Value = today;
            if (cboReportRoom.Items.Count > 0) cboReportRoom.SelectedIndex = 0;
        }

        /* ==================================================================
           GENERATE
           ================================================================== */

        private void GenerateReport()
        {
            DateTime from = dtpReportFrom.Value.Date;
            DateTime to = dtpReportTo.Value.Date;

            if (from > to)
            {
                MessageBox.Show("Date From cannot be later than Date To.", "Invalid Range",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpReportFrom.Focus();
                return;
            }

            ReportRoom? room = cboReportRoom.SelectedItem as ReportRoom;

            try
            {
                _received = ReportService.GetReceived(Session.BuildingId, from, to.AddDays(1),
                                                      room?.RoomId);
                _expenses = ExpenseService.GetExpenses(Session.BuildingId, from, to.AddDays(1))
                                          .OrderBy(x => x.ExpenseDate).ThenBy(x => x.ExpenseId).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to generate the report.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _from = from;
            _to = to;
            _roomText = room == null ? AllRooms : room.ToString();

            // ---- Summary --------------------------------------------------
            _rent = _received.Where(r => r.Category == "Rent").Sum(r => r.Amount);
            _maintenance = _received.Where(r => r.Category == "Maintenance").Sum(r => r.Amount);
            _utilities = _received.Where(r => r.Category == "Water" || r.Category == "Electricity"
                                           || r.Category == "Other").Sum(r => r.Amount);
            _expenseTotal = _expenses.Sum(x => x.Amount);
            _netShown = room == null;

            _lblRent.Text = Peso(_rent);
            _lblUtilities.Text = Peso(_utilities);
            _lblMaintenance.Text = Peso(_maintenance);
            _lblExpenses.Text = Peso(_expenseTotal);

            if (_netShown)
            {
                decimal net = _rent - _expenseTotal;
                _lblNet.Text = (net < 0 ? "-" : "") + Peso(Math.Abs(net));
                _lblNet.ForeColor = net < 0 ? Color.Salmon : Color.PaleGreen;
            }
            else
            {
                _lblNet.Text = "All rooms only";
                _lblNet.ForeColor = Color.Silver;
            }

            // ---- Grids ----------------------------------------------------
            dgvReceived.Rows.Clear();
            foreach (ReportReceivedRow r in _received)
                dgvReceived.Rows.Add(r.PaymentDate.ToString("MMM dd, yyyy"), r.ReceiptNo, r.TenantName,
                                     r.RoomNumber, r.Category, r.Method, Peso(r.Amount));

            dgvExpenses.Rows.Clear();
            foreach (ExpenseRow x in _expenses)
                dgvExpenses.Rows.Add(x.ExpenseDate.ToString("MMM dd, yyyy"), x.Category, x.Description, Peso(x.Amount));

            tabReceived.Text = "Received (" + _received.Count + ")";
            tabExpenses.Text = "Expenses (" + _expenses.Count + ")";
        }

        private static string Peso(decimal d) => "₱" + d.ToString("N2");

        /* ==================================================================
           PRINT / PDF
           ================================================================== */

        /// <summary>One printed line: plain text, or a row of cells.</summary>
        private class PrintLine
        {
            public string Text = "";
            public string[]? Cells;
            public float[]? Widths;     // fractions of the page width
            public bool Bold;
            public bool Big;
            public bool Rule;           // draw a line under it
            public float SpaceBefore;
        }

        private static readonly float[] ReceivedWidths = { 0.13f, 0.16f, 0.24f, 0.08f, 0.13f, 0.10f, 0.16f };
        private static readonly float[] ExpenseWidths = { 0.15f, 0.17f, 0.50f, 0.18f };

        private void PrintReport()
        {
            if (_from == default)
            {
                MessageBox.Show("Generate the report first.", "Print",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BuildPrintLines();
            _printIndex = 0;

            using (var doc = new PrintDocument())
            using (var preview = new PrintPreviewDialog())
            {
                doc.DocumentName = "Report " + _from.ToString("yyyy-MM-dd") + " to " + _to.ToString("yyyy-MM-dd");
                doc.BeginPrint += (s, e) => _printIndex = 0;   // preview renders, then printing starts over
                doc.PrintPage += Doc_PrintPage;

                preview.Document = doc;
                preview.Width = 1000;
                preview.Height = 800;
                preview.ShowDialog(FindForm());
            }
        }

        private void BuildPrintLines()
        {
            var L = new List<PrintLine>();
            string building = "";
            try { building = ReportService.GetBuildingName(Session.BuildingId); } catch { /* title only */ }

            L.Add(new PrintLine { Text = building, Big = true });
            L.Add(new PrintLine { Text = "Financial Report", Bold = true });
            L.Add(new PrintLine
            {
                Text = _from.ToString("MMMM dd, yyyy") + "  to  " + _to.ToString("MMMM dd, yyyy") +
                                         "     Room: " + _roomText,
                Rule = true
            });

            L.Add(new PrintLine { Text = "SUMMARY", Bold = true, SpaceBefore = 10 });
            L.Add(Row(new[] { "Rent Collected", Peso(_rent) }, new[] { 0.6f, 0.4f }));
            L.Add(Row(new[] { "Utilities Collected (reimbursement)", Peso(_utilities) }, new[] { 0.6f, 0.4f }));
            L.Add(Row(new[] { "Maintenance Collected (reimbursement)", Peso(_maintenance) }, new[] { 0.6f, 0.4f }));
            L.Add(Row(new[] { "Expenses", Peso(_expenseTotal) }, new[] { 0.6f, 0.4f }));
            if (_netShown)
            {
                decimal net = _rent - _expenseTotal;
                var netRow = Row(new[] { "NET INCOME (Rent - Expenses)", (net < 0 ? "-" : "") + Peso(Math.Abs(net)) },
                                 new[] { 0.6f, 0.4f });
                netRow.Bold = true;
                L.Add(netRow);
            }
            L[L.Count - 1].Rule = true;

            L.Add(new PrintLine { Text = "RECEIVED (" + _received.Count + ")", Bold = true, SpaceBefore = 12 });
            var head = Row(new[] { "Date", "Receipt No.", "Tenant", "Room", "Category", "Method", "Amount" }, ReceivedWidths);
            head.Bold = true; head.Rule = true;
            L.Add(head);
            foreach (ReportReceivedRow r in _received)
                L.Add(Row(new[] { r.PaymentDate.ToString("MMM dd, yyyy"), r.ReceiptNo, r.TenantName, r.RoomNumber,
                                  r.Category, r.Method, Peso(r.Amount) }, ReceivedWidths));
            if (_received.Count == 0) L.Add(new PrintLine { Text = "No payments in this period." });

            L.Add(new PrintLine { Text = "EXPENSES (" + _expenses.Count + ")", Bold = true, SpaceBefore = 12 });
            var head2 = Row(new[] { "Date", "Category", "Description", "Amount" }, ExpenseWidths);
            head2.Bold = true; head2.Rule = true;
            L.Add(head2);
            foreach (ExpenseRow x in _expenses)
                L.Add(Row(new[] { x.ExpenseDate.ToString("MMM dd, yyyy"), x.Category, x.Description, Peso(x.Amount) },
                          ExpenseWidths));
            if (_expenses.Count == 0) L.Add(new PrintLine { Text = "No expenses in this period." });

            L.Add(new PrintLine
            {
                Text = "Generated " + DateTime.Now.ToString("MMM dd, yyyy hh:mm tt") +
                                         " by " + Session.Name,
                SpaceBefore = 16
            });
            _printLines = L;
        }

        private static PrintLine Row(string[] cells, float[] widths) => new PrintLine { Cells = cells, Widths = widths };

        /// <summary>Draws lines until the page is full; continues on the next page.</summary>
        private void Doc_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null) return;
            Graphics g = e.Graphics;
            float left = e.MarginBounds.Left, width = e.MarginBounds.Width;
            float y = e.MarginBounds.Top, bottom = e.MarginBounds.Bottom;

            using (var normal = new Font("Segoe UI", 9.5F))
            using (var bold = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (var big = new Font("Segoe UI", 15F, FontStyle.Bold))
            using (var right = new StringFormat { Alignment = StringAlignment.Far, Trimming = StringTrimming.EllipsisCharacter })
            using (var plain = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
            {
                while (_printIndex < _printLines.Count)
                {
                    PrintLine line = _printLines[_printIndex];
                    Font font = line.Big ? big : line.Bold ? bold : normal;
                    float h = font.GetHeight(g) + 4;

                    if (y + line.SpaceBefore + h > bottom)
                    {
                        e.HasMorePages = true;   // the rest goes on the next page
                        return;
                    }

                    y += line.SpaceBefore;

                    if (line.Cells == null)
                    {
                        g.DrawString(line.Text, font, Brushes.Black, new RectangleF(left, y, width, h), plain);
                    }
                    else
                    {
                        float x = left;
                        for (int i = 0; i < line.Cells.Length; i++)
                        {
                            float w = width * line.Widths![i];
                            bool isLast = i == line.Cells.Length - 1;
                            g.DrawString(line.Cells[i], font, Brushes.Black,
                                         new RectangleF(x, y, w - 4, h), isLast ? right : plain);
                            x += w;
                        }
                    }

                    y += h;
                    if (line.Rule)
                    {
                        g.DrawLine(Pens.Black, left, y, left + width, y);
                        y += 3;
                    }

                    _printIndex++;
                }
            }

            e.HasMorePages = false;
        }

    }
}
