using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.MaintenanceForms;

namespace Capstoneszn.Forms
{
    /// <summary>
    /// Edits a Pending issue, and is where an issue gets Completed.
    ///
    /// Completing is final: the materials total becomes a Maintenance bill
    /// for the affected tenants (due Complete + 7 days), or a building
    /// expense when nobody is charged, or nothing when there are no
    /// materials. After that the issue is locked.
    ///
    /// Closes with DialogResult.OK after a save so MaintenanceControl
    /// reloads the list.
    /// </summary>
    /// 
    public partial class EditIssueForm : Form
    {

        private readonly int _issueId;
        private MaintenanceIssueEdit _issue;
        private List<TenantChoice> _tenantChoices = new List<TenantChoice>();
        private List<ResponsibleChoice> _responsibleChoices = new List<ResponsibleChoice>();

        public EditIssueForm(int issueId)
        {
            InitializeComponent();

            _issueId = issueId;

            // Each radio sits in its own panel, so WinForms doesn't group them.
            RadioGroupHelper.Link(rdoTenantAll, rdoTenantSpecify, rdoTenantNone);
            RadioGroupHelper.Link(rdoResponsibleAll, rdoResponsibleSpecify, rdoResponsibleNone);

            rdoTenantAll.CheckedChanged += (s, e) => clbAffectedTenants.Visible = rdoTenantSpecify.Checked;
            rdoTenantSpecify.CheckedChanged += (s, e) => clbAffectedTenants.Visible = rdoTenantSpecify.Checked;
            rdoTenantNone.CheckedChanged += (s, e) => clbAffectedTenants.Visible = rdoTenantSpecify.Checked;

            rdoResponsibleAll.CheckedChanged += (s, e) => clbResponsible.Visible = rdoResponsibleSpecify.Checked;
            rdoResponsibleSpecify.CheckedChanged += (s, e) => clbResponsible.Visible = rdoResponsibleSpecify.Checked;
            rdoResponsibleNone.CheckedChanged += (s, e) => clbResponsible.Visible = rdoResponsibleSpecify.Checked;

        }

        /* ------------------------------------------------------------------
           Load
           ------------------------------------------------------------------ */

        private void EditIssueForm_Load(object sender, EventArgs e)
        {
            try
            {
                _issue = MaintenanceService.GetIssueForEdit(_issueId);
                if (_issue != null)
                {
                    _tenantChoices = MaintenanceService.GetTenantChoicesForIssue(_issueId, _issue.RoomId);
                    _responsibleChoices = MaintenanceService.GetResponsibleChoicesForIssue(_issueId, Session.BuildingId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the issue.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (_issue == null)
            {
                MessageBox.Show("This issue no longer exists.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            if (!_issue.IsPending)
            {
                MessageBox.Show("This issue is already complete and can no longer be edited.",
                    "Issue Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            lblRoomValue.Text = "Room " + _issue.RoomNumber;

            // Every issue is a Room issue until the Building migration is done.
            lblIssueTypeValue.Text = "Room";
            UpdateMaterialsCount();
            txtIssue.Text = _issue.IssueTitle;
            txtDescription.Text = _issue.Description;

            dtpIssueDate.MaxDate = DateTime.Today;
            dtpIssueDate.Value = _issue.DateReported > DateTime.Today ? DateTime.Today : _issue.DateReported;

            cboIssueStatus.SelectedItem = MaintenanceService.StatusPending;

            LoadTenantSection();
            LoadResponsibleSection();
        }

        /// <summary>
        /// Fills the tenant checklist and picks the radio that matches what
        /// is saved: nobody -> None; every current tenant (and no one who
        /// moved out) -> All; anything else -> Specify.
        /// </summary>
        private void LoadTenantSection()
        {
            clbAffectedTenants.Items.Clear();
            foreach (TenantChoice t in _tenantChoices)
                clbAffectedTenants.Items.Add(t, t.IsAffected);

            bool hasCurrent = _tenantChoices.Any(t => t.IsCurrent);
            var affected = _tenantChoices.Where(t => t.IsAffected).ToList();

            rdoTenantAll.Enabled = hasCurrent;
            rdoTenantSpecify.Enabled = _tenantChoices.Count > 0;
            rdoTenantNone.Enabled = true;

            if (affected.Count == 0)
                rdoTenantNone.Checked = true;
            else if (affected.All(t => t.IsCurrent)
                     && _tenantChoices.Where(t => t.IsCurrent).All(t => t.IsAffected))
                rdoTenantAll.Checked = true;
            else
                rdoTenantSpecify.Checked = true;

            clbAffectedTenants.Visible = rdoTenantSpecify.Checked;
        }

        /// <summary>
        /// Same idea for Responsible: nobody -> None; owner plus every active
        /// caretaker (and no inactive one) -> All; anything else -> Specify.
        /// </summary>
        private void LoadResponsibleSection()
        {
            clbResponsible.Items.Clear();
            foreach (ResponsibleChoice r in _responsibleChoices)
                clbResponsible.Items.Add(r, r.IsSelected);

            var selected = _responsibleChoices.Where(r => r.IsSelected).ToList();

            if (selected.Count == 0)
                rdoResponsibleNone.Checked = true;
            else if (selected.All(r => r.IsActive)
                     && _responsibleChoices.Where(r => r.IsActive).All(r => r.IsSelected))
                rdoResponsibleAll.Checked = true;
            else
                rdoResponsibleSpecify.Checked = true;

            clbResponsible.Visible = rdoResponsibleSpecify.Checked;
        }

        /* ------------------------------------------------------------------
           Save
           ------------------------------------------------------------------ */

        private void btnSaveIssueChanges_Click(object sender, EventArgs e)
        {
            string title = txtIssue.Text.Trim();
            if (title.Length == 0)
            {
                Warn("Please enter the issue.", txtIssue);
                return;
            }

            // ---- Affected tenants ------------------------------------------
            List<TenantChoice> tenants;
            if (rdoTenantAll.Checked)
                tenants = _tenantChoices.Where(t => t.IsCurrent).ToList();
            else if (rdoTenantSpecify.Checked)
            {
                tenants = clbAffectedTenants.CheckedItems.Cast<TenantChoice>().ToList();
                if (tenants.Count == 0)
                {
                    Warn("Check at least one affected tenant, or choose None.", clbAffectedTenants);
                    return;
                }
            }
            else if (rdoTenantNone.Checked)
                tenants = new List<TenantChoice>();
            else
            {
                Warn("Choose who is affected: All, Specify, or None.", rdoTenantAll);
                return;
            }

            // Decision 4: someone who moved out cannot be charged.
            TenantChoice gone = tenants.FirstOrDefault(t => !t.IsCurrent);
            if (gone != null)
            {
                Warn(gone.Name + " is no longer in the room. Uncheck them in Affected Tenants first.",
                     clbAffectedTenants);
                return;
            }

            // ---- Responsible -----------------------------------------------
            List<ResponsibleChoice> responsible;
            if (rdoResponsibleAll.Checked)
                responsible = _responsibleChoices.Where(r => r.IsActive).ToList();
            else if (rdoResponsibleSpecify.Checked)
            {
                responsible = clbResponsible.CheckedItems.Cast<ResponsibleChoice>().ToList();
                if (responsible.Count == 0)
                {
                    Warn("Check at least one responsible person, or choose None.", clbResponsible);
                    return;
                }
            }
            else if (rdoResponsibleNone.Checked)
                responsible = new List<ResponsibleChoice>();
            else
            {
                Warn("Choose who is responsible: All, Specify, or None.", rdoResponsibleAll);
                return;
            }

            if (dtpIssueDate.Value.Date > DateTime.Today)
            {
                Warn("The issue date cannot be in the future.", dtpIssueDate);
                return;
            }

            bool markComplete = (cboIssueStatus.SelectedItem as string) == MaintenanceService.StatusComplete;

            // ---- Completing is final: show exactly what will happen -------
            if (markComplete && !ConfirmComplete(tenants.Count))
                return;

            IssueSaveResult result;
            try
            {
                result = MaintenanceService.SaveIssueEdit(
                    _issueId,
                    title,
                    txtDescription.Text.Trim(),
                    dtpIssueDate.Value.Date,
                    tenants.Select(t => t.TenantId).ToList(),
                    responsible.Any(r => r.IsOwner),
                    responsible.Where(r => !r.IsOwner && r.EmployeeId.HasValue)
                               .Select(r => r.EmployeeId.Value).ToList(),
                    markComplete,
                    Session.UserId);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Issue Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The issue was not saved.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(SavedMessage(result), result.Completed ? "Issue Completed" : "Issue Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Tells the landlord, before anything is saved, what Complete will
        /// create. Returns true only on Yes.
        /// </summary>
        private bool ConfirmComplete(int tenantCount)
        {
            decimal total;
            try
            {
                total = MaintenanceService.GetMaterials(_issueId).Sum(m => m.TotalCost);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to read the materials.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string outcome;
            if (total <= 0m)
                outcome = "No materials were recorded, so nobody will be charged and no expense will be recorded.";
            else if (tenantCount > 0)
                outcome = tenantCount + " tenant(s) will be charged a total of " + Peso(total)
                        + " (about " + Peso(Math.Round(total / tenantCount, 2)) + " each), due "
                        + DateTime.Today.AddDays(MaintenanceService.MaintenanceDueDays).ToString("MMM dd, yyyy") + ".";
            else
                outcome = Peso(total) + " will be recorded as a building expense.";

            return MessageBox.Show(
                       outcome + "\n\nOnce completed, this issue can no longer be edited or deleted. Continue?",
                       "Complete Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes;
        }

        private static string SavedMessage(IssueSaveResult r)
        {
            if (!r.Completed)
                return "Changes saved.";
            if (r.TenantsCharged > 0)
                return "Issue completed. " + r.TenantsCharged + " tenant(s) charged "
                     + Peso(r.MaterialsTotal) + " in total, due "
                     + r.DueDate.Value.ToString("MMM dd, yyyy") + ".";
            if (r.ExpenseRecorded)
                return "Issue completed. " + Peso(r.MaterialsTotal) + " recorded as a building expense.";
            return "Issue completed. No charge and no expense (no materials).";
        }

        private static string Peso(decimal amount) => "₱" + amount.ToString("N2");

        private void Warn(string message, Control focus)
        {
            MessageBox.Show(message, "Missing Information",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus.Focus();
        }

        private void btnCancelEditIssue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /* ------------------------------------------------------------------
           Materials - replaces the "Materials Needed? Yes/No" of the Add
           form. Opens the existing ViewMaterialsForm, where materials can
           be added or removed while the issue is Pending.
           ------------------------------------------------------------------ */

        private void btnViewMaterials_Click(object sender, EventArgs e)
        {
            using (var form = new ViewMaterialsForm(_issueId))
                form.ShowDialog(this);

            // Materials may have been added or removed.
            UpdateMaterialsCount();
        }

        private void UpdateMaterialsCount()
        {
            try
            {
                int count = MaintenanceService.GetMaterials(_issueId).Count;
                lblMaterialsCount.Text = count == 0 ? "No materials yet"
                                       : count == 1 ? "1 item listed"
                                       : count + " items listed";
            }
            catch (Exception)
            {
                lblMaterialsCount.Text = "";
            }
        }
    }
}
