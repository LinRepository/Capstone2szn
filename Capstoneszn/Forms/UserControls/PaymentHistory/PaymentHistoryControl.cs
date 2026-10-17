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
    ///   - tabs All / Rent / Maintenance / Utilities (each tab has its own columns)
    ///   - search (tenant, room, receipt no.) and a period filter
    ///   - a total of the visible tab that leaves voided payments out
    ///   - [Receipt] on every row; [Void] for the landlord only
    ///
    /// Voided payments stay in the list, greyed and struck through, with the
    /// reason as a tooltip (settled rule: never deleted, never hidden).
    /// Columns are created in code (see the column specs below), so the
    /// designer only holds the empty grids.
    /// </summary>
    /// 

    public partial class PaymentHistoryControl : UserControl
    {

        private const string PeriodThisMonth = "This Month";
        private const string PeriodLastMonth = "Last Month";
        private const string PeriodThisYear = "This Year";
        private const string PeriodAllTime = "All Time";

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


        public PaymentHistoryControl()
        {
            InitializeComponent();

            cboPaymentPeriod.Items.Clear();
            cboPaymentPeriod.Items.AddRange(new object[]
                { PeriodThisMonth, PeriodLastMonth, PeriodThisYear, PeriodAllTime });
            cboPaymentPeriod.SelectedIndex = 0;   // before subscribing: loads once, in OnLoad

            cboPaymentPeriod.SelectedIndexChanged += (s, e) => LoadPayments();
            txtSearch.TextChanged += (s, e) => FillGrids();
            tabPaymentHistory.SelectedIndexChanged += (s, e) => UpdateTotal();

            SetUpGrids();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            LoadPayments();
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
            ColumnSpec amount = C("colAmount", "Amount", 9, r => Peso(r.Amount), right: true);
            ColumnSpec status = C("colStatus", "Status", 7, r => r.IsVoided ? "Voided" : "Valid");
            ColumnSpec type = C("colType", "Type", 7, r => r.PaymentType);

            _specs[dgvAll] = new List<ColumnSpec>
            {
                date, time, rcpt, tenant, room,
                C("colCategory", "Category", 9, r => r.Category),
                amount, method, status
            };

            _specs[dgvRent] = new List<ColumnSpec>
            {
                date, time, rcpt, tenant, room,
                C("colPaidAs", "Paid As", 9, r => r.CoversRoom ? "Whole Room" : "Individual"),
                type,
                C("colTag", "Tag", 7, r => r.Tag),
                method, amount, status
            };

            _specs[dgvMaintenance] = new List<ColumnSpec>
            {
                date, time, rcpt, tenant, room,
                C("colIssues", "Issue(s)", 18, r => r.Issues),
                method, amount, status
            };

            _specs[dgvUtilities] = new List<ColumnSpec>
            {
                date, time, rcpt, tenant, room,
                C("colUtility", "Utility", 8, r => r.Category),
                type, method, amount, status
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

            // Void: landlord only (settled rule). Checked again when saving.
            if (Session.IsLandlord)
            {
                grid.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = ColVoid,
                    HeaderText = "Void",
                    FillWeight = 7
                });
            }

            grid.CellContentClick += Grid_CellContentClick;
        }

        /* ==================================================================
           DATA
           ================================================================== */

        private void LoadPayments()
        {
            GetPeriod(out DateTime? from, out DateTime? to);

            try
            {
                _rows = PaymentHistoryService.GetPayments(Session.BuildingId, from, to);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load payment history.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _rows = new List<PaymentHistoryRow>();
            }

            FillGrids();
        }

        /// <summary>Rows that pass the search box (tenant, room, receipt no.).</summary>
        private IEnumerable<PaymentHistoryRow> Searched()
        {
            string q = txtSearch.Text.Trim();
            if (q.Length == 0) return _rows;

            return _rows.Where(r =>
                r.TenantName.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                r.RoomNumber.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                r.ReceiptNo.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        /// <summary>Which rows belong on which tab.</summary>
        private IEnumerable<PaymentHistoryRow> RowsFor(DataGridView grid, IEnumerable<PaymentHistoryRow> rows)
        {
            if (grid == dgvRent) return rows.Where(r => r.Category == "Rent");
            if (grid == dgvMaintenance) return rows.Where(r => r.Category == "Maintenance");
            if (grid == dgvUtilities) return rows.Where(r => r.IsUtility);
            return rows;   // All
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

                    if (r.IsVoided)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Strikeout);

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

            decimal total = shown.Where(r => !r.IsVoided).Sum(r => r.Amount);
            int voided = shown.Count(r => r.IsVoided);

            lblPaymentTotal.Text =
                "Total (" + tabPaymentHistory.SelectedTab?.Text + ", " + cboPaymentPeriod.Text + "): " +
                Peso(total) + "   •   " + shown.Count + " payment(s)" +
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

        private void GetPeriod(out DateTime? from, out DateTime? to)
        {
            DateTime today = DateTime.Today;
            DateTime monthStart = new DateTime(today.Year, today.Month, 1);

            switch (cboPaymentPeriod.SelectedItem as string)
            {
                case PeriodThisMonth: from = monthStart; to = monthStart.AddMonths(1); break;
                case PeriodLastMonth: from = monthStart.AddMonths(-1); to = monthStart; break;
                case PeriodThisYear: from = new DateTime(today.Year, 1, 1); to = new DateTime(today.Year + 1, 1, 1); break;
                default: from = null; to = null; break;   // All Time
            }
        }

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
