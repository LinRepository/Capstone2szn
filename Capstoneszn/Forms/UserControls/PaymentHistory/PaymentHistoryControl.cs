using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms;
using Capstoneszn.Forms.PaymentsForms;
using Capstoneszn.Forms.UserControls.Utilities;

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// Payment History. Read-only list of the building's payments, with:
    ///   - ORIGINAL: tabs All / Rent / Maintenance / Utilities (each tab has its own columns)
    ///     NEW (Nov 11): tabs All / Rent / Maintenance / Water. One receipt can pay
    ///     several categories; it shows on every tab it paid, and each tab shows
    ///     only its own part of the money (All shows the whole receipt).
    ///     The open tab is blue with a gold underline (same look as Utilities).
    ///   - ORIGINAL: search (tenant, room, receipt no.) and a period filter
    ///     NEW (Nov 11): search (tenant, room, receipt no., GCash ref no.) and a
    ///     Date From / Date To range with a Clear button
    ///   - a total of the visible tab that leaves voided payments out
    ///   - [Receipt] on every row
    ///   - ORIGINAL: [Void] for the landlord only
    ///     NEW (Nov 11): [Void] on every row for the landlord; a caretaker sees it
    ///     only on receipts they recorded themselves today (rule B)
    ///
    /// Voided payments stay in the list, greyed and struck through, with the
    /// reason as a tooltip (settled rule: never deleted, never hidden).
    /// Columns are created in code (see the column specs below), so the
    /// designer only holds the empty grids.
    /// </summary>
    ///

    public partial class PaymentHistoryControl : UserControl
    {

        // ORIGINAL (period combo box, removed Nov 11 - replaced by Date From / Date To):
        // private const string PeriodThisMonth = "This Month";
        // private const string PeriodLastMonth = "Last Month";
        // private const string PeriodThisYear = "This Year";
        // private const string PeriodAllTime = "All Time";

        private const string ColReceipt = "colReceipt";
        private const string ColVoid = "colVoid";

        /// <summary>One column of a grid: name, header, width weight, value.</summary>
        private class ColumnSpec
        {
            public string Name = "";
            public string Header = "";
            public float Weight = 10;
            public bool AlignRight;
            public Func<PaymentHistoryRow, object> Value = r => "";
        }

        private List<PaymentHistoryRow> _rows = new List<PaymentHistoryRow>();
        private readonly Dictionary<DataGridView, List<ColumnSpec>> _specs =
            new Dictionary<DataGridView, List<ColumnSpec>>();

        // NEW (Nov 11): one font for every voided row (it used to create a new
        // Font per row and never free it).
        private static readonly Font VoidedRowFont = new Font("Segoe UI", 9.5F, FontStyle.Strikeout);

        // NEW (Nov 11): tab indicator colours - the same as the Utilities tabs
        private static readonly Color TabSelectedBack = Color.FromArgb(39, 111, 227);
        private static readonly Color TabNormalBack = Color.FromArgb(35, 35, 90);
        private static readonly Color TabNormalText = Color.FromArgb(180, 185, 210);
        private static readonly Color TabUnderline = Color.FromArgb(250, 204, 21);
        private Font? _tabFont;
        private Font? _tabFontBold;

        // NEW (Nov 11): true while the date pickers are being set in code,
        // so they don't reload the list twice.
        private bool _settingDates;


        public PaymentHistoryControl()
        {
            InitializeComponent();

            // ORIGINAL: cboPaymentPeriod.Items.Clear();
            // ORIGINAL: cboPaymentPeriod.Items.AddRange(new object[]
            // ORIGINAL:     { PeriodThisMonth, PeriodLastMonth, PeriodThisYear, PeriodAllTime });
            // ORIGINAL: cboPaymentPeriod.SelectedIndex = 0;   // before subscribing: loads once, in OnLoad
            // ORIGINAL: cboPaymentPeriod.SelectedIndexChanged += (s, e) => LoadPayments();

            // NEW (Nov 11): Date From / Date To + Clear.
            // Wired here only - do not double-click these in the designer.
            ResetDates();   // before subscribing: the list loads once, in OnLoad
            dtpPaymentFrom.ValueChanged += (s, e) => { if (!_settingDates) LoadPayments(); };
            dtpPaymentTo.ValueChanged += (s, e) => { if (!_settingDates) LoadPayments(); };
            btnPaymentClear.Click += (s, e) => ClearFilters();

            txtSearch.TextChanged += (s, e) => FillGrids();
            tabPaymentHistory.SelectedIndexChanged += (s, e) => UpdateTotal();

            SetUpTabIndicator();   // NEW (Nov 11)
            SetUpGrids();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            LoadPayments();
        }

        /* ==================================================================
           FILTERS (NEW, Nov 11)
           ================================================================== */

        /// <summary>Default range: the 1st of this month up to today.</summary>
        private void ResetDates()
        {
            _settingDates = true;
            DateTime today = DateTime.Today;
            dtpPaymentFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpPaymentTo.Value = today;
            _settingDates = false;
        }

        /// <summary>Clear: empty search, default dates, reload once.</summary>
        private void ClearFilters()
        {
            txtSearch.Clear();   // refills the grids from the rows already loaded (no database call)
            ResetDates();        // does not reload by itself (_settingDates)
            LoadPayments();      // one fresh load for the default dates
        }

        /* ==================================================================
           TAB INDICATOR (NEW, Nov 11)
           ================================================================== */

        /// <summary>
        /// The tabs are drawn by hand so the open tab is obvious: blue fill,
        /// bold white text and a gold underline. Same look as the Utilities tabs.
        /// </summary>
        private void SetUpTabIndicator()
        {
            tabPaymentHistory.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabPaymentHistory.SizeMode = TabSizeMode.Fixed;
            tabPaymentHistory.ItemSize = new Size(180, 40);
            tabPaymentHistory.DrawItem += TabPaymentHistory_DrawItem;

            _tabFont = new Font(tabPaymentHistory.Font, FontStyle.Regular);
            _tabFontBold = new Font(tabPaymentHistory.Font, FontStyle.Bold);
        }

        private void TabPaymentHistory_DrawItem(object? sender, DrawItemEventArgs e)
        {
            bool selected = e.Index == tabPaymentHistory.SelectedIndex;
            Rectangle r = tabPaymentHistory.GetTabRect(e.Index);

            using (var back = new SolidBrush(selected ? TabSelectedBack : TabNormalBack))
                e.Graphics.FillRectangle(back, r);

            if (selected)   // gold underline on the open tab
                using (var line = new SolidBrush(TabUnderline))
                    e.Graphics.FillRectangle(line, r.X, r.Bottom - 4, r.Width, 4);

            TextRenderer.DrawText(e.Graphics, tabPaymentHistory.TabPages[e.Index].Text,
                selected ? _tabFontBold : _tabFont, r,
                selected ? Color.White : TabNormalText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        /* ==================================================================
           COLUMNS
           ================================================================== */

        private static ColumnSpec C(string name, string header, float weight,
                                    Func<PaymentHistoryRow, object> value, bool right = false)
            => new ColumnSpec { Name = name, Header = header, Weight = weight, Value = value, AlignRight = right };

        private static string Peso(decimal d) => "₱" + d.ToString("N2");

        private void SetUpGrids()
        {
            // Shared columns
            ColumnSpec date = C("colDate", "Date", 9, r => r.PaymentDate.ToString("MMM dd, yyyy"));
            ColumnSpec time = C("colTime", "Time", 7, r => r.RecordedAt.ToString("hh:mm tt"));
            ColumnSpec rcpt = C("colReceiptNo", "Receipt No.", 11, r => r.ReceiptNo);
            ColumnSpec tenant = C("colTenant", "Tenant", 13, r => r.TenantName);
            ColumnSpec room = C("colRoom", "Room", 6, r => r.RoomNumber);
            ColumnSpec method = C("colMethod", "Method", 7, r => r.Method);
            // ORIGINAL: ColumnSpec amount = C("colAmount", "Amount", 9, r => Peso(r.Amount), right: true);
            ColumnSpec status = C("colStatus", "Status", 7, r => r.IsVoided ? "Voided" : "Valid");
            // ORIGINAL: ColumnSpec type = C("colType", "Type", 7, r => r.PaymentType);

            // NEW (Nov 11): each tab shows only its own part of the receipt.
            // Example: one receipt of ₱2,300 = ₱2,000 rent + ₱300 water
            //   All tab ₱2,300   Rent tab ₱2,000   Water tab ₱300
            ColumnSpec amountAll = C("colAmount", "Amount", 9, r => Peso(r.Amount), right: true);
            ColumnSpec amountRent = C("colAmount", "Rent Paid", 9, r => Peso(r.RentAmount), right: true);
            ColumnSpec amountMaint = C("colAmount", "Maintenance Paid", 10, r => Peso(r.MaintenanceAmount), right: true);
            ColumnSpec amountWater = C("colAmount", "Water Paid", 9, r => Peso(r.WaterAmount), right: true);

            _specs[dgvAll] = new List<ColumnSpec>
            {
                date, time, rcpt, tenant, room,
                C("colCategory", "Category", 11, r => r.Category),
                // ORIGINAL: amount, method, status
                amountAll, method, status
            };

            _specs[dgvRent] = new List<ColumnSpec>
            {
                date, time, rcpt, tenant, room,
                C("colPaidAs", "Paid As", 9, r => r.CoversRoom ? "Whole Room" : "Individual"),
                // ORIGINAL: type,
                C("colType", "Type", 7, r => r.RentType),      // NEW: type of the rent part only
                C("colTag", "Tag", 7, r => r.Tag),             // NEW: saved at payment time (Payments.RentTag)
                // ORIGINAL: method, amount, status
                method, amountRent, status
            };

            _specs[dgvMaintenance] = new List<ColumnSpec>
            {
                date, time, rcpt, tenant, room,
                C("colIssues", "Issue(s)", 18, r => r.Issues),
                // ORIGINAL: method, amount, status
                method, amountMaint, status
            };

            // ORIGINAL (Utilities tab):
            // _specs[dgvUtilities] = new List<ColumnSpec>
            // {
            //     date, time, rcpt, tenant, room,
            //     C("colUtility", "Utility", 8, r => r.Category),
            //     type, method, amount, status
            // };

            // NEW (Nov 11): the tab is now "Water" - only water money goes through
            // Payments (electricity is paid to AKELCO directly). No Type column:
            // water is always paid in full.
            _specs[dgvUtilities] = new List<ColumnSpec>
            {
                date, time, rcpt, tenant, room,
                method, amountWater, status
            };

            foreach (var pair in _specs)
                BuildGrid(pair.Key, pair.Value);
        }

        private void BuildGrid(DataGridView grid, List<ColumnSpec> specs)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.FromArgb(11, 20, 38);
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 35;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.EnableHeadersVisualStyles = false;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowTemplate.Height = 35;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ShowCellToolTips = true;

            grid.Columns.Clear();
            foreach (ColumnSpec s in specs)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = s.Name,
                    HeaderText = s.Header,
                    FillWeight = s.Weight,
                    ReadOnly = true,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                if (s.AlignRight)
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns.Add(col);
            }

            grid.Columns.Add(new DataGridViewButtonColumn
            {
                Name = ColReceipt,
                HeaderText = "Receipt",
                FillWeight = 7,
                Text = "View",
                UseColumnTextForButtonValue = true
            });

            // ORIGINAL: // Void: landlord only (settled rule). Checked again when saving.
            // ORIGINAL: if (Session.IsLandlord)
            // ORIGINAL: {
            // ORIGINAL:     grid.Columns.Add(new DataGridViewButtonColumn { Name = ColVoid, HeaderText = "Void", FillWeight = 7 });
            // ORIGINAL: }

            // NEW (Step 6, rule B): Void for both roles. A caretaker may void only a
            // receipt they recorded today - checked when the void screen opens and
            // again when saving (PaymentHistoryService.VoidNotAllowedReason).
            grid.Columns.Add(new DataGridViewButtonColumn
            {
                Name = ColVoid,
                HeaderText = "Void",
                FillWeight = 7
            });

            grid.CellContentClick += Grid_CellContentClick;
        }

        /* ==================================================================
           DATA
           ================================================================== */

        private void LoadPayments()
        {
            // ORIGINAL: GetPeriod(out DateTime? from, out DateTime? to);

            // NEW (Nov 11): Date From / Date To, both days included
            DateTime from = dtpPaymentFrom.Value.Date;
            DateTime to = dtpPaymentTo.Value.Date;

            if (from > to)
            {
                _rows = new List<PaymentHistoryRow>();
                FillGrids();
                lblPaymentCount.Text = "Date From cannot be later than Date To.";
                return;
            }

            try
            {
                // ORIGINAL: _rows = PaymentHistoryService.GetPayments(Session.BuildingId, from, to);
                // NEW: the query's "to" is exclusive, so pass the day after Date To
                _rows = PaymentHistoryService.GetPayments(Session.BuildingId, from, to.AddDays(1));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load payment history.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _rows = new List<PaymentHistoryRow>();
            }

            FillGrids();
        }

        /// <summary>Rows that pass the search box (tenant, room, receipt no., GCash ref no.).</summary>
        private IEnumerable<PaymentHistoryRow> Searched()
        {
            string q = txtSearch.Text.Trim();
            if (q.Length == 0) return _rows;

            return _rows.Where(r =>
                r.TenantName.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                r.RoomNumber.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                // ORIGINAL: r.ReceiptNo.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);
                r.ReceiptNo.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                r.ReferenceNo.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);   // NEW (Nov 11): GCash ref no.
        }

        /// <summary>Which rows belong on which tab.</summary>
        private IEnumerable<PaymentHistoryRow> RowsFor(DataGridView grid, IEnumerable<PaymentHistoryRow> rows)
        {
            // ORIGINAL: if (grid == dgvRent) return rows.Where(r => r.Category == "Rent");
            // ORIGINAL: if (grid == dgvMaintenance) return rows.Where(r => r.Category == "Maintenance");
            // ORIGINAL: if (grid == dgvUtilities) return rows.Where(r => r.IsUtility);

            // NEW (Nov 11): a receipt belongs on every tab it paid something on.
            // ("Rent, Water" never matched == "Rent", so mixed receipts were missing.)
            if (grid == dgvRent) return rows.Where(r => r.RentAmount > 0m);
            if (grid == dgvMaintenance) return rows.Where(r => r.MaintenanceAmount > 0m);
            if (grid == dgvUtilities) return rows.Where(r => r.WaterAmount > 0m);
            return rows;   // All
        }

        /// <summary>NEW (Nov 11): the part of a receipt that counts on this tab.</summary>
        private decimal AmountOn(DataGridView grid, PaymentHistoryRow r)
        {
            if (grid == dgvRent) return r.RentAmount;
            if (grid == dgvMaintenance) return r.MaintenanceAmount;
            if (grid == dgvUtilities) return r.WaterAmount;
            return r.Amount;   // All = the whole receipt
        }

        /// <summary>
        /// NEW (Nov 11, rule B): may the logged-in user void this receipt?
        ///   Landlord  -> any receipt
        ///   Caretaker -> only one they recorded themselves, today
        /// This only decides whether the button is shown. The real check is
        /// done again in the database when the void is saved.
        /// </summary>
        private static bool CanVoid(PaymentHistoryRow r)
        {
            if (Session.IsLandlord) return true;
            return r.RecordedById == Session.UserId && r.PaymentDate.Date == DateTime.Today;
        }

        private void FillGrids()
        {
            var searched = Searched().ToList();

            foreach (var pair in _specs)
            {
                DataGridView grid = pair.Key;
                grid.SuspendLayout();
                grid.Rows.Clear();

                foreach (PaymentHistoryRow r in RowsFor(grid, searched))
                {
                    var values = pair.Value.Select(s => s.Value(r)).ToList();
                    if (grid.Columns.Contains(ColVoid))
                    {
                        values.Add(null);   // receipt button uses its column text
                        values.Add(r.IsVoided ? "Voided" : "Void");
                    }

                    int i = grid.Rows.Add(values.ToArray());
                    DataGridViewRow row = grid.Rows[i];
                    row.Tag = r;

                    // NEW (Nov 11): no [Void] button where this user can't void.
                    // A plain cell replaces the button (voided rows still say "Voided").
                    if (!CanVoid(r))
                        row.Cells[ColVoid] = new DataGridViewTextBoxCell { Value = r.IsVoided ? "Voided" : "" };

                    if (r.IsVoided)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                        // ORIGINAL: row.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Strikeout);
                        row.DefaultCellStyle.Font = VoidedRowFont;   // NEW: one shared font

                        string tip = "VOIDED" +
                            (r.VoidedAt.HasValue ? " on " + r.VoidedAt.Value.ToString("MMM dd, yyyy hh:mm tt") : "") +
                            (r.VoidedBy.Length > 0 ? " by " + r.VoidedBy : "") +
                            "\nReason: " + r.VoidReason;
                        foreach (DataGridViewCell cell in row.Cells)
                            cell.ToolTipText = tip;
                    }
                }

                grid.ResumeLayout();
            }

            UpdateTotal();
        }

        /// <summary>Total of the selected tab, voided payments left out.</summary>
        private void UpdateTotal()
        {
            DataGridView grid = SelectedGrid();
            var shown = RowsFor(grid, Searched()).ToList();

            // ORIGINAL: decimal total = shown.Where(r => !r.IsVoided).Sum(r => r.Amount);
            decimal total = shown.Where(r => !r.IsVoided).Sum(r => AmountOn(grid, r));   // NEW: this tab's part only
            int voided = shown.Count(r => r.IsVoided);

            // ORIGINAL:
            // lblPaymentTotal.Text =
            //     "Total (" + tabPaymentHistory.SelectedTab?.Text + ", " + cboPaymentPeriod.Text + "): " +
            //     Peso(total) + "   •   " + shown.Count + " payment(s)" +
            //     (voided > 0 ? ", " + voided + " voided (not counted)" : "");

            // NEW (Nov 11): three labels
            //   [Rent total:] [₱25,500.00]
            //   [8 payment(s), 1 voided (not counted)]
            lblPaymentTotalCaption.Text = (tabPaymentHistory.SelectedTab?.Text ?? "All") + " total:";
            lblPaymentTotalAmount.Text = Peso(total);
            // "Maintenance total:" is wider than "All total:", so the amount
            // moves to sit right after the caption instead of overlapping it.
            lblPaymentTotalAmount.Left = lblPaymentTotalCaption.Right + 6;

            lblPaymentCount.Text = shown.Count + " payment(s)" +
                (voided > 0 ? ", " + voided + " voided (not counted)" : "");
        }

        private DataGridView SelectedGrid()
        {
            TabPage? page = tabPaymentHistory.SelectedTab;
            if (page == tabRent) return dgvRent;
            if (page == tabMaintenance) return dgvMaintenance;
            if (page == tabUtilities) return dgvUtilities;
            return dgvAll;
        }

        // ORIGINAL (replaced by Date From / Date To on Nov 11):
        // private void GetPeriod(out DateTime? from, out DateTime? to)
        // {
        //     DateTime today = DateTime.Today;
        //     DateTime monthStart = new DateTime(today.Year, today.Month, 1);
        //
        //     switch (cboPaymentPeriod.SelectedItem as string)
        //     {
        //         case PeriodThisMonth: from = monthStart; to = monthStart.AddMonths(1); break;
        //         case PeriodLastMonth: from = monthStart.AddMonths(-1); to = monthStart; break;
        //         case PeriodThisYear: from = new DateTime(today.Year, 1, 1); to = new DateTime(today.Year + 1, 1, 1); break;
        //         default: from = null; to = null; break;   // All Time
        //     }
        // }

        /* ==================================================================
           ROW BUTTONS
           ================================================================== */

        private void Grid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is not DataGridView grid || e.RowIndex < 0) return;
            if (grid.Rows[e.RowIndex].Tag is not PaymentHistoryRow row) return;

            string colName = grid.Columns[e.ColumnIndex].Name;

            if (colName == ColReceipt)
            {
                using (var form = new PaymentReceiptForm(row.PaymentId))
                    form.ShowDialog(FindForm());
            }
            else if (colName == ColVoid)
            {
                // NEW (Nov 11): rows where this user can't void have no button - ignore clicks there
                if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex] is not DataGridViewButtonCell) return;

                if (row.IsVoided)
                {
                    MessageBox.Show("This payment is already voided.\n\nReason: " + row.VoidReason,
                        "Already Voided", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var form = new VoidPaymentForm(row.PaymentId))
                {
                    if (form.ShowDialog(FindForm()) == DialogResult.OK)
                        LoadPayments();
                }
            }
        }

    }
}
