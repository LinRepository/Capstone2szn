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
using Capstoneszn.Forms.UserControls;

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// The Maintenance list.
    ///
    /// NEW (Nov 20): the card list (flpMaintenanceIssues + MaintenanceIssueControl)
    /// was replaced by a grid, dgvMaintenanceIssues. Cards cost ~290 px each, so
    /// 15 issues meant ~2,200 px of scrolling; the grid shows the same issues in
    /// aligned columns and matches dgvMaintenance on the dashboard and every other
    /// management table in the system.
    ///
    /// The card code below is COMMENTED OUT, not deleted (team rule), and
    /// MaintenanceIssueControl.cs is left in the project untouched.
    ///
    /// What did NOT change: the service call, the status filter, the Pending-only
    /// Edit/Delete rule, and Repair Done (still btnRepairDone inside EditIssueForm).
    ///
    /// NEW (Nov 21): the Assigned To column and the Description tooltip are gone -
    /// both fields were removed from the Maintenance module.
    /// </summary>
    public partial class MaintenanceControl : UserControl
    {
        private const string FilterAll = "All";
        // NEW (Nov 12): below this width a card is too cramped, so the list
        // shows one card per row instead of two.

        //private const int MinCardWidth = 760;

        /* ------------------------------------------------------------------
           NEW (Nov 20): column names.
           Handlers look columns up by name, never by index, so inserting a
           column later cannot silently point a click at the wrong cell.
           ------------------------------------------------------------------ */
        private const string ColIssueId = "colIssueId";
        private const string ColRoom = "colRoom";
        private const string ColIssue = "colIssue";
        private const string ColCharged = "colChargedTenants";
        // ORIGINAL (Nov 21): private const string ColAssigned = "colAssignedTo";
        private const string ColDate = "colDateReported";
        private const string ColStatus = "colStatus";
        private const string ColMaterials = "colViewMaterials";
        private const string ColEdit = "colEdit";
        private const string ColDelete = "colDelete";

        // What a locked (non-Pending) row shows in place of an Edit / Delete button.
        private const string NoAction = "-";
        // NEW (Nov 21): the empty-state label is built in code, so the
        // designer file needs no second edit.
        private Label lblNoIssues;

        public MaintenanceControl()
        {
            InitializeComponent();

            cboMaintenanceStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaintenanceStatus.Items.AddRange(new object[]
            {
                MaintenanceService.StatusPending,
                MaintenanceService.StatusForPayment,   // NEW (Maintenance v2)
                MaintenanceService.StatusComplete,
                FilterAll
            });

            // Set the default BEFORE subscribing, so the list loads once (in OnLoad),
            // not twice.
            cboMaintenanceStatus.SelectedIndex = 0;
            cboMaintenanceStatus.SelectedIndexChanged += (s, e) => LoadIssues();

            // ORIGINAL (card list):
            //flpMaintenanceIssues.AutoScroll = true;

            // NEW (Nov 12): re-fit the cards whenever the list changes size
            // (maximize, restore, sidebar toggle).
            //flpMaintenanceIssues.ClientSizeChanged += (s, e) => ResizeCards();

            // NEW (Nov 20): the grid replaces the card list.
            BuildGrid();

            // NEW (Nov 21): replaces the message the card list used to add to
            // the flow panel. BackColor is set so it covers the grid when shown.
            lblNoIssues = new Label
            {
                Name = "lblNoIssues",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(25, 25, 70),
                Text = "No maintenance issues to show.",
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            pnlMaintenanceContent.Controls.Add(lblNoIssues);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
                LoadIssues();
        }

        /* ==================================================================
           GRID SETUP
           Built once, in code, so the column order and the Pending-only rule
           live next to the handlers that depend on them.
           ================================================================== */

        /// <summary>
        /// NEW (Nov 20): defines the columns and the look of dgvMaintenanceIssues.
        /// Column order follows how the list is read:
        /// ORIGINAL (Nov 21): where -> what -> who pays -> who repairs -> when -> state -> act.
        /// NEW (Nov 21):      where -> what -> who pays -> when -> state -> act.
        /// </summary>
        private void BuildGrid()
        {
            DataGridView dgv = dgvMaintenanceIssues;

            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.ReadOnly = true;                 // button cells still raise clicks
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 46;
            dgv.RowTemplate.Height = 36;
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.BackgroundColor = Color.FromArgb(25, 25, 70);
            dgv.GridColor = Color.FromArgb(55, 55, 110);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(18, 18, 55);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(18, 18, 55);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            // NEW (Nov 21): headers never wrap. This is what cut "Date Reported"
            // in half - WrapMode defaults to True on column headers.
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 70);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 105);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;   // NEW (Nov 21)

            dgv.Columns.Clear();

            // 0 - row identity. Hidden: every handler reads the issue from here
            //     instead of matching on room + issue text.
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColIssueId,
                Visible = false
            });

            // 1 - Room. GetIssues already returns the text "Building" for a
            //     building-wide issue (RoomId is null), so nothing special here.
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColRoom,
                HeaderText = "Room",
                // ORIGINAL (Nov 20): Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,   // NEW (Nov 21)
                MinimumWidth = 80,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });

            // 2 - Issue. Long titles are cut with "..." and the built-in tooltip
            //     shows the full title on hover.
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColIssue,
                HeaderText = "Issue",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                // ORIGINAL (Nov 21): FillWeight = 26,
                FillWeight = 34,   // NEW: takes most of the Assigned To column's space
                SortMode = DataGridViewColumnSortMode.NotSortable
            });

            // 3 - Charged Tenants: who owes money on this issue. The card never
            //     showed this, which is why it is here.
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = ColCharged,
                HeaderText = "Charged Tenants",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                // ORIGINAL (Nov 21): FillWeight = 24,
                FillWeight = 30,   // NEW
                SortMode = DataGridViewColumnSortMode.NotSortable
            });

            // ORIGINAL (Nov 21): 4 - Assigned To - removed from the module.
            // dgv.Columns.Add(new DataGridViewTextBoxColumn
            // {
            //     Name = ColAssigned,
            //     HeaderText = "Assigned To",
            //     AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            //     FillWeight = 20,
            //     SortMode = DataGridViewColumnSortMode.NotSortable
            // });

            // 4 - Date Reported. Bound as a DateTime, formatted here, so it can
            //     never sort as text.
            var dateCol = new DataGridViewTextBoxColumn
            {
                Name = ColDate,
                HeaderText = "Date Reported",
                // Date Reported
                // ORIGINAL (Nov 20): Width = 140,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,   // NEW (Nov 21)
                MinimumWidth = 130,
                ValueType = typeof(DateTime),
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            dateCol.DefaultCellStyle.Format = "MMM dd, yyyy";
            dgv.Columns.Add(dateCol);

            // 5 - Status. Colour is applied in Grid_CellFormatting.
            var statusCol = new DataGridViewTextBoxColumn
            {
                Name = ColStatus,
                HeaderText = "Status",
                // ORIGINAL (Nov 20): Width = 125,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,   // NEW (Nov 21)
                MinimumWidth = 115,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            statusCol.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.Columns.Add(statusCol);

            // NEW (Nov 21): the action group gets a visible header. DataGridView
            // cannot merge header cells, so the label sits on the first button
            // column and the other two stay blank.
            var materialsCol = NewButtonColumn(ColMaterials, "View Materials", 150);
            materialsCol.HeaderText = "Actions";
            dgv.Columns.Add(materialsCol);
            dgv.Columns.Add(NewButtonColumn(ColEdit, "Update", 90));
            dgv.Columns.Add(NewButtonColumn(ColDelete, "Delete", 95));

            dgv.CellFormatting += Grid_CellFormatting;
            dgv.CellContentClick += Grid_CellContentClick;
            dgv.CellDoubleClick += Grid_CellDoubleClick;
        }

        /// <summary>
        /// NEW (Nov 20): one action column. The header is blank so the three
        /// buttons read as one action area rather than three data columns.
        /// </summary>
        private static DataGridViewButtonColumn NewButtonColumn(string name, string text, int width)
        {
            var col = new DataGridViewButtonColumn
            {
                Name = name,
                HeaderText = string.Empty,
                Text = text,
                UseColumnTextForButtonValue = true,
                Width = width,
                FlatStyle = FlatStyle.Standard,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            col.DefaultCellStyle.ForeColor = Color.Black;
            col.DefaultCellStyle.SelectionForeColor = Color.Black;
            col.DefaultCellStyle.Padding = new Padding(4, 4, 4, 4);
            return col;
        }

        /* ==================================================================
           LOADING
           ================================================================== */

        /// <summary>
        /// Rebuilds the list for the selected building and filter.
        /// Called on load, on filter change, and after any save.
        /// </summary>
        private void LoadIssues()
        {
            string filter = cboMaintenanceStatus.SelectedItem as string;
            string status = (filter == FilterAll) ? null : filter;

            List<MaintenanceIssueSummary> issues;
            try
            {
                issues = MaintenanceService.GetIssues(Session.BuildingId, status);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load maintenance issues.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // NEW (Nov 20): remember the selected issue, so a reload after Edit
            // does not throw the user back to the top of a 15-row list.
            int wasSelected = CurrentIssueId();

            dgvMaintenanceIssues.SuspendLayout();
            try
            {
                dgvMaintenanceIssues.Rows.Clear();

                foreach (MaintenanceIssueSummary issue in issues)
                    AddRow(issue);
            }
            finally
            {
                dgvMaintenanceIssues.ResumeLayout();
            }

            ShowEmptyState(issues.Count == 0);
            Reselect(wasSelected);

            /* ORIGINAL (card list):
            flpMaintenanceIssues.SuspendLayout();
            try
            {
                ClearCards();

                if (issues.Count == 0)
                {
                    flpMaintenanceIssues.Controls.Add(new Label
                    {
                        Text = "No maintenance issues to show.",
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 12F),
                        AutoSize = true,
                        Margin = new Padding(15)
                    });
                    return;
                }

                foreach (MaintenanceIssueSummary issue in issues)
                {
                    var card = new MaintenanceIssueControl();
                    card.Bind(issue);
                    card.Margin = new Padding(10);

                    card.DetailsRequested += Card_DetailsRequested;
                    card.ViewMaterialsRequested += Card_ViewMaterialsRequested;
                    card.EditRequested += Card_EditRequested;
                    card.DeleteRequested += Card_DeleteRequested;

                    flpMaintenanceIssues.Controls.Add(card);
                }

                ResizeCards();
            }
            finally
            {
                flpMaintenanceIssues.ResumeLayout();
            }
            */
        }

        /// <summary>
        /// NEW (Nov 20): fills one row.
        /// A non-Pending issue has its Edit and Delete BUTTON cells replaced by
        /// plain text cells. That is the whole lock: there is no button left to
        /// click, so no owner-drawing and no handler can reach a locked issue.
        /// Same rule MaintenanceIssueControl.Bind applied by hiding the buttons.
        /// </summary>
        private void AddRow(MaintenanceIssueSummary issue)
        {
            int index = dgvMaintenanceIssues.Rows.Add();
            DataGridViewRow row = dgvMaintenanceIssues.Rows[index];

            row.Cells[ColIssueId].Value = issue.IssueId;
            row.Cells[ColRoom].Value = issue.RoomNumber;       // "Building" when RoomId is null
            row.Cells[ColIssue].Value = issue.IssueTitle;
            row.Cells[ColCharged].Value = string.IsNullOrWhiteSpace(issue.ChargedTenants)
                ? "None (building expense)"
                : issue.ChargedTenants;
            // ORIGINAL (Nov 21): row.Cells[ColAssigned].Value = issue.Responsible;  // "Assigned To" since Nov 10
            row.Cells[ColDate].Value = issue.DateReported;
            row.Cells[ColStatus].Value = issue.Status;

            // ORIGINAL (Nov 21): Description was removed from the module.
            // row.Cells[ColIssue].ToolTipText = string.IsNullOrWhiteSpace(issue.Description)
            //     ? "No description."
            //     : issue.Description;

            if (!issue.IsPending)
            {
                row.Cells[ColEdit] = LockedCell();
                row.Cells[ColDelete] = LockedCell();
            }
        }

        private static DataGridViewTextBoxCell LockedCell()
        {
            var cell = new DataGridViewTextBoxCell { Value = NoAction };
            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cell.Style.ForeColor = Color.FromArgb(120, 130, 170);
            cell.Style.SelectionForeColor = Color.FromArgb(120, 130, 170);
            return cell;
        }

        /// <summary>
        /// NEW (Nov 20): replaces the "No maintenance issues to show." label the
        /// card list used to add to the flow panel.
        /// </summary>
        private void ShowEmptyState(bool empty)
        {
            lblNoIssues.Visible = empty;
            if (empty) lblNoIssues.BringToFront();
            else lblNoIssues.SendToBack();
        }

        /* ==================================================================
           ROW HELPERS
           ================================================================== */

        /// <summary>Issue id of the selected row, or 0 when nothing is selected.</summary>
        private int CurrentIssueId()
        {
            DataGridViewRow row = dgvMaintenanceIssues.CurrentRow;
            if (row == null || row.Index < 0) return 0;

            object value = row.Cells[ColIssueId].Value;
            return value == null ? 0 : Convert.ToInt32(value);
        }

        /// <summary>Puts the selection back on an issue after a reload, if it is still listed.</summary>
        private void Reselect(int issueId)
        {
            if (issueId == 0) return;

            foreach (DataGridViewRow row in dgvMaintenanceIssues.Rows)
            {
                if (Convert.ToInt32(row.Cells[ColIssueId].Value) != issueId) continue;

                row.Selected = true;
                dgvMaintenanceIssues.CurrentCell = row.Cells[ColIssue];
                return;
            }
        }

        /* ==================================================================
           GRID EVENTS
           ================================================================== */

        /// <summary>
        /// NEW (Nov 20): the card's status colours, unchanged.
        /// Pending = repair not done, For Payment = waiting for tenants,
        /// Complete = settled.
        /// </summary>
        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvMaintenanceIssues.Columns[e.ColumnIndex].Name != ColStatus) return;

            string status = Convert.ToString(e.Value);

            Color colour = status == MaintenanceService.StatusPending ? Color.Orange
                         : status == MaintenanceService.StatusForPayment ? Color.Gold
                         : Color.LightGreen;

            e.CellStyle.ForeColor = colour;
            e.CellStyle.SelectionForeColor = colour;
        }

        /// <summary>
        /// NEW (Nov 20): the three action buttons. A locked row's Edit / Delete
        /// cell is a text cell, not a button, so it falls out at the type check.
        /// </summary>
        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow row = dgvMaintenanceIssues.Rows[e.RowIndex];
            if (!(row.Cells[e.ColumnIndex] is DataGridViewButtonCell)) return;

            int issueId = Convert.ToInt32(row.Cells[ColIssueId].Value);
            string column = dgvMaintenanceIssues.Columns[e.ColumnIndex].Name;

            if (column == ColMaterials) OpenMaterials(issueId);
            else if (column == ColEdit) OpenEdit(issueId);
            else if (column == ColDelete) OpenDelete(issueId);
        }

        /// <summary>
        /// NEW (Nov 20): double-clicking a row opens Details, the way clicking
        /// anywhere on a card used to.
        /// </summary>
        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow row = dgvMaintenanceIssues.Rows[e.RowIndex];
            if (row.Cells[e.ColumnIndex] is DataGridViewButtonCell) return;   // the button already acted

            OpenDetails(Convert.ToInt32(row.Cells[ColIssueId].Value));
        }

        private void btnAddIssue_Click(object sender, EventArgs e)
        {
            using (var form = new AddIssueForm())
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                LoadIssues();

                // "Materials Needed? Yes" -> go straight to the materials list.
                if (form.MaterialsNeeded)
                {
                    using (var materials = new ViewMaterialsForm(form.NewIssueId))
                        materials.ShowDialog(this);
                }
            }
        }

        /* ==================================================================
           ACTIONS
           Unchanged behaviour - these are the old Card_* handlers, taking an
           issue id instead of reading it off a card. Repair Done is NOT here:
           it is btnRepairDone inside EditIssueForm, reached through Edit.
           ================================================================== */

        private void OpenDetails(int issueId)
        {
            using (var form = new MaintenanceIssueDetailsForm(issueId))
                form.ShowDialog(this);
        }

        private void OpenMaterials(int issueId)
        {
            using (var form = new ViewMaterialsForm(issueId))
                form.ShowDialog(this);
        }

        private void OpenEdit(int issueId)
        {
            using (var form = new EditIssueForm(issueId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadIssues();
            }
        }

        private void OpenDelete(int issueId)
        {
            using (var form = new DeleteIssueConfirmationForm(issueId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadIssues();
            }
        }

        /* ==================================================================
           ORIGINAL CARD CODE (Nov 12 and earlier)
           Kept, commented out, per the team rule. MaintenanceIssueControl.cs
           is still in the project and is no longer instantiated from here.
           ==================================================================

        /// <summary>
        /// Controls.Clear() does not dispose, so old cards would pile up in
        /// memory on every reload. Remove and dispose each one.
        /// </summary>
        private void ClearCards()
        {
            while (flpMaintenanceIssues.Controls.Count > 0)
            {
                Control c = flpMaintenanceIssues.Controls[0];
                flpMaintenanceIssues.Controls.RemoveAt(0);
                c.Dispose();
            }
        }

        /// <summary>
        /// NEW (Nov 12): two cards per row when there is room, otherwise one.
        /// Each card stretches so the row fills the list's width.
        /// </summary>
        private void ResizeCards()
        {
            int available = flpMaintenanceIssues.ClientSize.Width
                          - (flpMaintenanceIssues.VerticalScroll.Visible ? 0 : SystemInformation.VerticalScrollBarWidth)
                          - 2;
            if (available <= 0) return;

            const int margin = 20;   // card.Margin = 10 on each side
            int columns = available >= 2 * (MinCardWidth + margin) ? 2 : 1;
            int cardWidth = Math.Max(available / columns - margin, MinCardWidth);

            flpMaintenanceIssues.SuspendLayout();
            foreach (Control c in flpMaintenanceIssues.Controls)
                if (c is MaintenanceIssueControl)
                    c.Width = cardWidth;
            flpMaintenanceIssues.ResumeLayout();
        }

        private void Card_DetailsRequested(object sender, EventArgs e)
        {
            var card = (MaintenanceIssueControl)sender;
            using (var form = new MaintenanceIssueDetailsForm(card.IssueId))
                form.ShowDialog(this);
        }

        private void Card_ViewMaterialsRequested(object sender, EventArgs e)
        {
            var card = (MaintenanceIssueControl)sender;
            using (var form = new ViewMaterialsForm(card.IssueId))
                form.ShowDialog(this);
        }

        private void Card_EditRequested(object sender, EventArgs e)
        {
            var card = (MaintenanceIssueControl)sender;
            using (var form = new EditIssueForm(card.IssueId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadIssues();
            }
        }

        private void Card_DeleteRequested(object sender, EventArgs e)
        {
            var card = (MaintenanceIssueControl)sender;
            using (var form = new DeleteIssueConfirmationForm(card.IssueId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadIssues();
            }
        }

           ================================================================== */
    }
}
