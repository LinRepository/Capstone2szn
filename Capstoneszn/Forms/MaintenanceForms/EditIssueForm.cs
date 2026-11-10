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

        // NEW (Maintenance v2): true only while the Repair Done button is saving.
        // Replaces the old "Status: Complete" dropdown.
        private bool _repairDone;

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

            // NEW (Maintenance v2): Repair Done saves the edits AND marks the
            // repair done, through the same save code as Save Changes.
            // Wired here only - the designer has no handler on this button.
            btnRepairDone.Click += (s, e) =>
            {
                _repairDone = true;
                try { btnSaveIssueChanges_Click(s, e); }
                finally { _repairDone = false; }
            };

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
                    // ORIGINAL: _tenantChoices = MaintenanceService.GetTenantChoicesForIssue(_issueId, _issue.RoomId);
                    _tenantChoices = MaintenanceService.GetTenantChoicesForIssue(_issueId, _issue.RoomId, Session.BuildingId);   // NEW
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

            // ORIGINAL: lblRoomValue.Text = "Room " + _issue.RoomNumber;
            // ORIGINAL: lblIssueTypeValue.Text = "Room";
            // NEW (Maintenance v2): RoomId 0 = Building issue (type cannot be changed)
            bool buildingIssue = _issue.RoomId == 0;
            lblRoomValue.Text = buildingIssue ? "Whole building" : "Room " + _issue.RoomNumber;
            lblIssueTypeValue.Text = buildingIssue ? "Building" : "Room";
            if (buildingIssue)
                // ORIGINAL: lblTenantHint.Text = "Optional. Building tenants who will pay (billed to their own room).";
                lblTenantHint.Text = "Optional. Split equally; each billed in their own room.";   // NEW (Nov 10)

            UpdateMaterialsCount();
            txtIssue.Text = _issue.IssueTitle;
            txtDescription.Text = _issue.Description;

            dtpIssueDate.MaxDate = DateTime.Today;
            dtpIssueDate.Value = _issue.DateReported > DateTime.Today ? DateTime.Today : _issue.DateReported;

            cboIssueStatus.SelectedItem = MaintenanceService.StatusPending;
            // NEW (Maintenance v2): status is no longer picked by hand.
            // Repair Done replaces "Complete"; Complete is reached when tenants pay.
            pnlIssueStatus.Visible = false;

            LoadTenantSection();
            LoadResponsibleSection();

            // NEW (Nov 10): only the landlord decides whether the owner shares the cost.
            chkOwnerSharesCost.Checked = false;
            chkOwnerSharesCost.Visible = Session.IsLandlord;
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
                    // ORIGINAL: Warn("Check at least one affected tenant, or choose None.", clbAffectedTenants);
                    Warn("Check at least one tenant to charge, or choose None.", clbAffectedTenants);   // NEW (Nov 10)
                    return;
                }
            }
            else if (rdoTenantNone.Checked)
                tenants = new List<TenantChoice>();
            else
            {
                // ORIGINAL: Warn("Choose who is affected: All, Specify, or None.", rdoTenantAll);
                Warn("Choose who to charge: All, Specify, or None.", rdoTenantAll);   // NEW (Nov 10)
                return;
            }

            // Decision 4: someone who moved out cannot be charged.
            TenantChoice gone = tenants.FirstOrDefault(t => !t.IsCurrent);
            if (gone != null)
            {
                // ORIGINAL: Warn(gone.Name + " is no longer in the room. Uncheck them in Affected Tenants first.",
                Warn(gone.Name + " is no longer in the room. Uncheck them in Charged Tenants first.",   // NEW (Nov 10)
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
                    // ORIGINAL: Warn("Check at least one responsible person, or choose None.", clbResponsible);
                    Warn("Check at least one person to assign, or choose None.", clbResponsible);   // NEW (Nov 10)
                    return;
                }
            }
            else if (rdoResponsibleNone.Checked)
                responsible = new List<ResponsibleChoice>();
            else
            {
                // ORIGINAL: Warn("Choose who is responsible: All, Specify, or None.", rdoResponsibleAll);
                Warn("Choose who is assigned: All, Specify, or None.", rdoResponsibleAll);   // NEW (Nov 10)
                return;
            }

            if (dtpIssueDate.Value.Date > DateTime.Today)
            {
                Warn("The issue date cannot be in the future.", dtpIssueDate);
                return;
            }

            // ORIGINAL: bool markComplete = (cboIssueStatus.SelectedItem as string) == MaintenanceService.StatusComplete;
            bool markComplete = _repairDone;   // NEW (Maintenance v2): only the Repair Done button completes the repair

            // ---- Completing is final: show exactly what will happen -------
            // ORIGINAL: if (markComplete && !ConfirmComplete(tenants.Count))
            // ORIGINAL (Step 4): if (markComplete && !ConfirmComplete(tenants.Count, responsible.Count))
            // NEW (Nov 10): Assigned To never shares the cost; only the owner can, when ticked.
            bool ownerShares = Session.IsLandlord && chkOwnerSharesCost.Checked;
            if (markComplete && !ConfirmComplete(tenants.Count, ownerShares))
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
                    // ORIGINAL: Session.UserId);
                    Session.UserId,
                    markComplete && ownerShares);   // NEW (Nov 10)
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Issue Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // NEW (MNT-01): a missing expense category, in plain words.
            catch (Microsoft.Data.SqlClient.SqlException ex)
                when (ex.Number == 547 && ex.Message.Contains("FK_Expenses_Category"))
            {
                MessageBox.Show(
                    "This repair was not saved because its expense category is missing from the database.\n\n" +
                    "Nothing was changed, and the issue is still Pending. " +
                    "Ask the system administrator to run the expense category setup, then try again.",
                    "Setup Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The issue was not saved.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ORIGINAL: MessageBox.Show(SavedMessage(result), result.Completed ? "Issue Completed" : "Issue Saved",
            MessageBox.Show(SavedMessage(result), result.Completed ? "Repair Done" : "Issue Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Tells the landlord, before anything is saved, what Complete will
        /// create. Returns true only on Yes.
        /// </summary>
        ///  // ORIGINAL: private bool ConfirmComplete(int tenantCount)
        // ORIGINAL (Step 4): private bool ConfirmComplete(int tenantCount, int responsibleCount)
        private bool ConfirmComplete(int tenantCount, bool ownerShares)   // NEW (Nov 10)
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
            // ORIGINAL (Maintenance v2):
            // else if (tenantCount > 0)
            //     outcome = tenantCount + " tenant(s) will be billed a total of " + Peso(total)
            //             + " (about " + Peso(Math.Round(total / tenantCount, 2)) + " each), due "
            //             + DateTime.Today.AddDays(MaintenanceService.MaintenanceDueDays).ToString("MMM dd, yyyy")
            //             + ".\nThey pay it in Bill Management. The issue becomes Complete once all have paid.";
            else if (tenantCount > 0)
            {
                // NEW (Step 4): tenants + responsible people share equally, rounded down;
                // the responsible shares and any rounding are a building expense.
                // ORIGINAL (Step 4): int heads = tenantCount + responsibleCount;
                int heads = tenantCount + (ownerShares ? 1 : 0);   // NEW (Nov 10)
                decimal share = Math.Floor(total / heads * 100m) / 100m;
                decimal expense = total - share * tenantCount;

                if (share < 1m)
                {
                    MessageBox.Show("Each person's share would be " + Peso(share) + " (" + Peso(total) + " split among " +
                                    heads + "). A share must be at least ₱1.00.\n\n" +
                                    // ORIGINAL: "Charge fewer people, or choose None under Affected Tenants to record it as a building expense.",
                                    "Charge fewer tenants, or choose None under Charged Tenants to record it as a building expense.",   // NEW (Nov 10)
                        "Share Too Small", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                outcome = tenantCount + " tenant(s) will each be billed " + Peso(share) + ", due "
                        + DateTime.Today.AddDays(MaintenanceService.MaintenanceDueDays).ToString("MMM dd, yyyy")
                        + ", in the room each lives in now."
                        + (expense > 0m
                            ? "\n" + Peso(expense) + " is recorded as a building expense"
                              // ORIGINAL (Step 4): + (responsibleCount > 0 ? " (the " + responsibleCount + " responsible share(s))." : " (rounding).")
                              + (ownerShares ? " (the owner's share)." : " (rounding).")   // NEW (Nov 10)
                            : "")
                        + "\nThey pay it in Bill Management. The issue becomes Complete once all have paid.";
            }
            else
                outcome = Peso(total) + " will be recorded as a building expense.";

            // NEW (Nov 10): the owner share only applies when tenants are charged.
            if (ownerShares && tenantCount == 0 && total > 0m)
                outcome += "\n(\"Owner shares the cost\" has no effect: nobody is charged, so the owner pays it all.)";

            return MessageBox.Show(
                       // ORIGINAL: outcome + "\n\nOnce completed, this issue can no longer be edited or deleted. Continue?",
                       // ORIGINAL: "Complete Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                       outcome + "\n\nAfter Repair Done, this issue can no longer be edited or deleted. Continue?",
                       "Repair Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes;
        }

        private static string SavedMessage(IssueSaveResult r)
        {
            if (!r.Completed)
                return "Changes saved.";
            if (r.TenantsCharged > 0)
                // NEW (Maintenance v2)
                // ORIGINAL: return "Repair done. " + r.TenantsCharged + " tenant(s) billed "
                // ORIGINAL:      + Peso(r.MaterialsTotal) + " in total, due "
                // ORIGINAL:      + r.DueDate.Value.ToString("MMM dd, yyyy") + ".\nStatus: For Payment.";
                return "Repair done. " + r.TenantsCharged + " tenant(s) billed "        // NEW (Step 4)
                     + Peso(r.SharePerTenant) + " each, due "
                     + r.DueDate.Value.ToString("MMM dd, yyyy") + "."
                     + (r.ExpenseAmount > 0m ? "\n" + Peso(r.ExpenseAmount) + " recorded as a building expense." : "")
                     + "\nStatus: For Payment.";
            if (r.ExpenseRecorded)
                return "Issue completed. " + Peso(r.MaterialsTotal) + " recorded as a building expense.";
            return "Issue completed. No charge and no expense (no materials).";
        }

        private static string Peso(decimal amount) => "₱" + amount.ToString("N2");

        private void Warn(string message, Control focus)
        {
            MessageBox.Show(message, "Missing Information",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // focus.Focus();
            // Focusing a RadioButton checks it automatically (WinForms behaviour),
            // which picked "All" for the user. Only focus non-radio controls.
            if (!(focus is RadioButton)) focus.Focus();
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
