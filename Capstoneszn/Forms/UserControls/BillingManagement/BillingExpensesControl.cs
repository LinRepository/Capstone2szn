using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.UserControls;

namespace Capstoneszn.Forms.UserControls.BillingManagement
{
    /// <summary>
    /// Bill Management > Expenses. Read-only list of the building's expenses.
    ///
    /// Tabs: "All" (from the designer) plus one tab per ACTIVE row in
    /// ExpenseCategories, built at load. Adding a category is an INSERT into
    /// that table - no designer or code change.
    ///
    /// The period filter (This Month / Last Month / This Year / All Time)
    /// limits every tab; the total shows the selected tab's sum.
    /// </summary>
    /// 
    public partial class BillingExpensesControl : UserControl
    {

        private const string PeriodThisMonth = "This Month";
        private const string PeriodLastMonth = "Last Month";
        private const string PeriodThisYear = "This Year";
        private const string PeriodAllTime = "All Time";

        /// <summary>Category name -> its grid, for the generated tabs.</summary>
        private readonly Dictionary<string, DataGridView> _categoryGrids =
            new Dictionary<string, DataGridView>(StringComparer.OrdinalIgnoreCase);

        private List<ExpenseRow> _rows = new List<ExpenseRow>();

        public BillingExpensesControl()
        {
            InitializeComponent();

            // ---- Period filter -------------------------------------------
            cboExpensePeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboExpensePeriod.Items.Clear();
            cboExpensePeriod.Items.AddRange(new object[]
                { PeriodThisMonth, PeriodLastMonth, PeriodThisYear, PeriodAllTime });
            cboExpensePeriod.SelectedIndex = 0;   // set before subscribing: loads once, in OnLoad

            cboExpensePeriod.SelectedIndexChanged += (s, e) => LoadExpenses();
            tabExpenses.SelectedIndexChanged += (s, e) => UpdateTotal();

            // ---- All tab: add a Category column after Date ----------------
            var colAllCategory = new DataGridViewTextBoxColumn
            {
                Name = "colAllCategory",
                HeaderText = "Category",
                ReadOnly = true,
                MinimumWidth = 6
            };
            dgvAll.Columns.Insert(1, colAllCategory);
            StyleColumns(dgvAll);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;

            BuildCategoryTabs();
            LoadExpenses();
        }

        /* ------------------------------------------------------------------
           Tabs
           ------------------------------------------------------------------ */

        /// <summary>
        /// One tab per active category, after "All". Any tab other than All
        /// (e.g. left over in the designer) is removed first.
        /// </summary>
        private void BuildCategoryTabs()
        {
            List<string> categories;
            try
            {
                categories = ExpenseService.GetActiveCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load expense categories.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (TabPage page in tabExpenses.TabPages.Cast<TabPage>().ToList())
            {
                if (page == tabAll) continue;
                tabExpenses.TabPages.Remove(page);
                page.Dispose();
            }
            _categoryGrids.Clear();

            foreach (string category in categories)
            {
                var grid = NewGrid();
                var page = new TabPage(category) { Padding = new Padding(3) };
                page.UseVisualStyleBackColor = true;
                page.Controls.Add(grid);
                tabExpenses.TabPages.Add(page);

                _categoryGrids[category] = grid;
            }
        }

        /// <summary>A grid set up like dgvAll, with Date / Description / Amount.</summary>
        private DataGridView NewGrid()
        {
            var grid = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Dock = DockStyle.Fill,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                ScrollBars = ScrollBars.Vertical,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Date", ReadOnly = true });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDescription", HeaderText = "Description", ReadOnly = true });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAmount", HeaderText = "Amount", ReadOnly = true });

            StyleColumns(grid);
            return grid;
        }

        /// <summary>Date narrow, Description wide, Amount right-aligned peso.</summary>
        private static void StyleColumns(DataGridView grid)
        {
            foreach (DataGridViewColumn col in grid.Columns)
            {
                string header = col.HeaderText;
                if (header == "Date") col.FillWeight = 20;
                else if (header == "Category") col.FillWeight = 20;
                else if (header == "Description") col.FillWeight = 60;
                else if (header == "Amount")
                {
                    col.FillWeight = 20;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.DefaultCellStyle.Format = "₱#,##0.00";
                }
            }
        }

        /* ------------------------------------------------------------------
           Data
           ------------------------------------------------------------------ */

        private void LoadExpenses()
        {
            GetPeriod(out DateTime? from, out DateTime? to);

            try
            {
                _rows = ExpenseService.GetExpenses(Session.BuildingId, from, to);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load expenses.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _rows = new List<ExpenseRow>();
            }

            // All tab
            dgvAll.Rows.Clear();
            foreach (ExpenseRow r in _rows)
                dgvAll.Rows.Add(r.ExpenseDate.ToString("MMM dd, yyyy"), r.Category, r.Description, r.Amount);

            // One tab per category
            foreach (var pair in _categoryGrids)
            {
                DataGridView grid = pair.Value;
                grid.Rows.Clear();
                foreach (ExpenseRow r in _rows.Where(x =>
                             string.Equals(x.Category, pair.Key, StringComparison.OrdinalIgnoreCase)))
                {
                    grid.Rows.Add(r.ExpenseDate.ToString("MMM dd, yyyy"), r.Description, r.Amount);
                }
            }

            UpdateTotal();
        }

        /// <summary>Total of the selected tab, for the selected period.</summary>
        private void UpdateTotal()
        {
            TabPage page = tabExpenses.SelectedTab;
            IEnumerable<ExpenseRow> shown = _rows;
            string label = "All";

            if (page != null && page != tabAll)
            {
                label = page.Text;
                shown = _rows.Where(x => string.Equals(x.Category, page.Text, StringComparison.OrdinalIgnoreCase));
            }

            decimal total = shown.Sum(x => x.Amount);
            lblExpensesTotal.Text = "Total (" + label + ", " + cboExpensePeriod.Text + "): ₱" + total.ToString("N2");
        }

        /// <summary>The selected period as [from, to). Nulls = All Time.</summary>
        private void GetPeriod(out DateTime? from, out DateTime? to)
        {
            DateTime today = DateTime.Today;
            DateTime monthStart = new DateTime(today.Year, today.Month, 1);

            switch (cboExpensePeriod.SelectedItem as string)
            {
                case PeriodThisMonth:
                    from = monthStart;
                    to = monthStart.AddMonths(1);
                    break;
                case PeriodLastMonth:
                    from = monthStart.AddMonths(-1);
                    to = monthStart;
                    break;
                case PeriodThisYear:
                    from = new DateTime(today.Year, 1, 1);
                    to = new DateTime(today.Year + 1, 1, 1);
                    break;
                default:   // All Time
                    from = null;
                    to = null;
                    break;
            }
        }


        /* ------------------------------------------------------------------
           Navigation (unchanged)
           ------------------------------------------------------------------ */


        private void btnBackExpenses_Click(object sender, EventArgs e)
        {
            // Loop through the controls in the parent panel to find the Billing Management Control
            foreach (Control ctrl in this.Parent.Controls)
            {
                if (ctrl is BillingManagementControl)
                {
                    // Show it and bring it to the front
                    ctrl.Show();
                    ctrl.BringToFront();
                    break;
                }
            }

            // Remove THIS Expenses control from the parent panel and dispose of it
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
