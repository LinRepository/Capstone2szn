using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// Audit Logs: read-only list of what each user (landlord or caretaker)
    /// did. Entries are never edited or deleted (a database trigger refuses
    /// it), so there is no archive - the date range keeps the list short.
    ///
    /// Filters: search (user, action, description), module, date range
    /// (default: the last 30 days). Changing the dates reloads from the
    /// database; search and module filter what is already loaded.
    /// </summary>
    /// 

    public partial class AuditLogsControl : UserControl
    {
        private const string AllModules = "All Modules";

        private List<AuditLogRow> _rows = new List<AuditLogRow>();
        private bool _loading;   // true while filters are being reset - avoids repeated reloads

        public AuditLogsControl()
        {
            InitializeComponent();

            cboAuditModule.Items.Clear();
            cboAuditModule.Items.AddRange(new object[]
            {
                AllModules,
                AuditLogger.ModuleLogin,
                AuditLogger.ModuleRooms,
                AuditLogger.ModuleTenants,
                AuditLogger.ModulePayments,
                AuditLogger.ModuleMaintenance,
                AuditLogger.ModuleEmployee,
                AuditLogger.ModuleSettings
            });

            SetUpGrid();
            ResetFilters();

            // Wired here only - do not double-click these in the designer.
            txtAuditSearch.TextChanged += (s, e) => FillGrid();
            cboAuditModule.SelectedIndexChanged += (s, e) => FillGrid();
            dtpAuditFrom.ValueChanged += (s, e) => { if (!_loading) LoadLogs(); };
            dtpAuditTo.ValueChanged += (s, e) => { if (!_loading) LoadLogs(); };
            btnAuditClear.Click += (s, e) => { ResetFilters(); LoadLogs(); };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            LoadLogs();
        }

        private void SetUpGrid()
        {
            var g = dgvAuditLogs;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.BackgroundColor = Color.FromArgb(11, 20, 38);
            g.BorderStyle = BorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            g.DefaultCellStyle.WrapMode = DataGridViewTriState.True;   // long descriptions wrap
            g.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            g.MultiSelect = false;
            g.ReadOnly = true;
            g.RowHeadersVisible = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            g.Columns.Clear();
            AddColumn("Date & Time", 14);
            AddColumn("User", 12);
            AddColumn("Role", 8);
            AddColumn("Module", 10);
            AddColumn("Action", 11);
            AddColumn("Description", 45);
        }

        private void AddColumn(string header, float weight)
        {
            dgvAuditLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                FillWeight = weight,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        /// <summary>Last 30 days, all modules, no search.</summary>
        private void ResetFilters()
        {
            _loading = true;
            DateTime today = DateTime.Today;
            dtpAuditFrom.Value = today.AddDays(-29);
            dtpAuditTo.Value = today;
            txtAuditSearch.Clear();
            cboAuditModule.SelectedIndex = 0;
            _loading = false;
        }

        private void LoadLogs()
        {
            DateTime from = dtpAuditFrom.Value.Date;
            DateTime to = dtpAuditTo.Value.Date;

            if (from > to)
            {
                lblAuditCount.Text = "Date From cannot be later than Date To.";
                dgvAuditLogs.Rows.Clear();
                return;
            }

            try
            {
                _rows = AuditLogService.GetLogs(Session.BuildingId, from, to.AddDays(1));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load audit logs.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _rows = new List<AuditLogRow>();
            }

            FillGrid();
        }

        private void FillGrid()
        {
            if (_loading) return;

            string q = txtAuditSearch.Text.Trim();
            string module = cboAuditModule.SelectedItem as string ?? AllModules;

            var shown = _rows.Where(r =>
                (module == AllModules || r.Module == module) &&
                (q.Length == 0 ||
                 r.UserName.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 r.Action.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 r.Description.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();

            dgvAuditLogs.SuspendLayout();
            dgvAuditLogs.Rows.Clear();
            foreach (AuditLogRow r in shown)
                dgvAuditLogs.Rows.Add(r.LoggedAt.ToString("MMM dd, yyyy  hh:mm tt"),
                                      r.UserName, r.Role, r.Module, r.Action, r.Description);
            dgvAuditLogs.ResumeLayout();

            lblAuditCount.Text = shown.Count + " entr" + (shown.Count == 1 ? "y" : "ies") +
                                 (shown.Count != _rows.Count ? "  (of " + _rows.Count + " in this date range)" : "");
        }


    }
}
