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
using Capstoneszn.UserControls;

namespace Capstoneszn.Forms
{
    /// <summary>
    /// Creates a maintenance issue. The new issue is always Pending.
    ///
    /// Charged Tenants = who will be CHARGED when the repair is done.
    ///
    /// After a successful save the form closes with DialogResult.OK and
    /// exposes NewIssueId and MaterialsNeeded, so MaintenanceControl can
    /// refresh the list and, when "Yes" was picked, open the materials form.
    ///
    /// NEW (Nov 21):
    ///   - Description removed from the form and from both service calls.
    ///   - Charged Tenants now defaults to None, so a landlord issue
    ///     (building expense) saves without a validation error first.
    ///   - Because None is the default, saving with nobody charged now asks
    ///     for confirmation, so the building never quietly pays by accident.
    ///
    /// NEW (Nov 21, Assigned To removed):
    ///   - The Assigned To group (rdoResponsible*, clbResponsible) is gone from
    ///     the designer. Every line that used it below is commented out, and
    ///     MaintenanceService.AddIssue / AddBuildingIssue no longer take the
    ///     ownerResponsible / responsibleEmployeeIds arguments.
    ///   - Assigned To never affected the cost split (since Nov 10), so no
    ///     billing rule changes. "Owner shares the cost" lives in EditIssueForm
    ///     and is NOT part of Assigned To.
    /// </summary>
    public partial class AddIssueForm : Form
    {
        public int NewIssueId { get; private set; }
        public bool MaterialsNeeded { get; private set; }

        // ORIGINAL (Nov 21): private List<ResponsibleOption> _responsibleOptions = new List<ResponsibleOption>();

        public AddIssueForm()
        {
            InitializeComponent();

            // Each radio sits in its own panel, so WinForms doesn't group them.
            // Link each set so only one in the group can be selected.
            RadioGroupHelper.Link(rdoTenantAll, rdoTenantSpecify, rdoTenantNone);
            // ORIGINAL (Nov 21): RadioGroupHelper.Link(rdoResponsibleAll, rdoResponsibleSpecify, rdoResponsibleNone);
            RadioGroupHelper.Link(rdoMaterialsYes, rdoMaterialsNo);
            // Wired here only - the designer has no handlers on these.
            cboRoom.SelectedIndexChanged += cboRoom_SelectedIndexChanged;
            // NEW (Maintenance v2): Room <-> Building switches the form.
            // Both radios sit in pnlIssueType, so WinForms already groups them.
            rdoIssueTypeBuilding.CheckedChanged += IssueType_CheckedChanged;

            rdoTenantAll.CheckedChanged += TenantOption_CheckedChanged;
            rdoTenantSpecify.CheckedChanged += TenantOption_CheckedChanged;
            rdoTenantNone.CheckedChanged += TenantOption_CheckedChanged;

            // ORIGINAL (Nov 21): rdoResponsibleAll.CheckedChanged += ResponsibleOption_CheckedChanged;
            // ORIGINAL (Nov 21): rdoResponsibleSpecify.CheckedChanged += ResponsibleOption_CheckedChanged;
            // ORIGINAL (Nov 21): rdoResponsibleNone.CheckedChanged += ResponsibleOption_CheckedChanged;

            CancelButton = btnCancelIssue;
        }

        private void AddIssueForm_Load(object sender, EventArgs e)
        {
            // List starts hidden; it only appears when "Specify" is picked.
            clbAffectedTenants.Visible = false;
            // ORIGINAL (Nov 21): clbResponsible.Visible = false;

            // NEW (Nov 21): Room is checked in the designer, so IssueType_CheckedChanged
            // never runs on open and the designer's old hint stayed. Same text as
            // the Room branch of IssueType_CheckedChanged.
            lblTenantHint.Text = "They pay; split equally. None = the building pays it.";

            // An issue cannot be reported for a future date.
            dtpIssueDate.MaxDate = DateTime.Today;
            dtpIssueDate.Value = DateTime.Today;

            // Not stored - only decides whether the materials form opens next.
            rdoMaterialsNo.Checked = true;

            // Room is the default type. Building issues need the database
            // change first (RoomId nullable + BuildingId), so the Building
            // option stays disabled until that step is done.
            rdoIssueTypeRoom.Checked = true;
            // ORIGINAL: rdoIssueTypeBuilding.Enabled = false;
            rdoIssueTypeBuilding.Enabled = true;   // NEW (Maintenance v2): database is ready for Building issues

            // No tenant group choice until a room is picked.
            SetTenantOptionsEnabled(false);

            // ORIGINAL (Nov 21): Assigned To defaulted to None here.
            // rdoResponsibleNone.Checked = true;

            try
            {
                cboRoom.DataSource = MaintenanceService.GetRoomsForIssue(Session.BuildingId);
                cboRoom.SelectedIndex = -1;   // force the user to choose a room

                // ORIGINAL (Nov 21): Assigned To options are no longer loaded.
                // _responsibleOptions = MaintenanceService.GetResponsibleOptions(Session.BuildingId);
                // clbResponsible.Items.Clear();
                // foreach (ResponsibleOption option in _responsibleOptions)
                //     clbResponsible.Items.Add(option);
            }
            catch (Exception ex)
            {
                // ORIGINAL (Nov 21): MessageBox.Show("Unable to load rooms or staff.\n\n" + ex.Message,
                MessageBox.Show("Unable to load rooms.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddIssue.Enabled = false;
                return;
            }

            if (cboRoom.Items.Count == 0)
            {
                MessageBox.Show("This building has no rooms yet. Add a room first.",
                    "No Rooms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAddIssue.Enabled = false;
            }
        }

        private void cboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbAffectedTenants.Items.Clear();
            rdoTenantAll.Checked = false;
            rdoTenantSpecify.Checked = false;
            rdoTenantNone.Checked = false;

            if (!(cboRoom.SelectedItem is LookupItem room))
            {
                SetTenantOptionsEnabled(false);
                return;
            }

            List<LookupItem> tenants;
            try
            {
                tenants = MaintenanceService.GetActiveTenantsInRoom(room.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the room's tenants.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetTenantOptionsEnabled(false);
                return;
            }

            foreach (LookupItem tenant in tenants)
                clbAffectedTenants.Items.Add(tenant);

            if (tenants.Count == 0)
            {
                // Nobody to charge: the cost will be a building expense.
                SetTenantOptionsEnabled(false);
                rdoTenantNone.Enabled = true;
                rdoTenantNone.Checked = true;
            }
            else
            {
                SetTenantOptionsEnabled(true);
                // NEW (Nov 21): default to None. The three radios were cleared
                // above, so this has to be set after the list is rebuilt.
                rdoTenantNone.Checked = true;
            }
        }

        private void SetTenantOptionsEnabled(bool enabled)
        {
            rdoTenantAll.Enabled = enabled;
            rdoTenantSpecify.Enabled = enabled;
            rdoTenantNone.Enabled = enabled;
        }

        /// <summary>
        /// NEW (Maintenance v2). Building issue: no room field; affected tenants
        /// come from the whole building. Room issue: back to the room's tenants.
        /// </summary>
        private void IssueType_CheckedChanged(object sender, EventArgs e)
        {
            bool building = rdoIssueTypeBuilding.Checked;

            pnlRoomSelection.Visible = !building;
            // ORIGINAL: lblTenantHint.Text = building
            // ORIGINAL:     ? "Optional. Building tenants who will pay (billed to their own room)."
            // ORIGINAL:     : "Optional. Tenants of the selected room who will pay.";
            // ORIGINAL (Nov 10): "Optional. Split equally; each billed in their own room."
            // ORIGINAL (Nov 10): "Optional. They pay; the cost is split equally."
            lblTenantHint.Text = building   // NEW (Nov 21): None is now the default, so the hint says what None means
                ? "Split equally, each billed in their own room."
                : "They pay; split equally. None = the building pays it.";

            if (building)
                LoadBuildingTenants();
            else
                cboRoom_SelectedIndexChanged(cboRoom, EventArgs.Empty);   // reload the chosen room's tenants
        }

        /// <summary>NEW (Maintenance v2): fills the tenant list with every payer in the building.</summary>
        private void LoadBuildingTenants()
        {
            clbAffectedTenants.Items.Clear();
            rdoTenantAll.Checked = false;
            rdoTenantSpecify.Checked = false;
            rdoTenantNone.Checked = false;

            List<LookupItem> tenants;
            try
            {
                tenants = MaintenanceService.GetActiveTenantsInBuilding(Session.BuildingId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the building's tenants.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetTenantOptionsEnabled(false);
                return;
            }

            foreach (LookupItem tenant in tenants)
                clbAffectedTenants.Items.Add(tenant);

            if (tenants.Count == 0)
            {
                // Nobody to charge: the cost will be a building expense.
                SetTenantOptionsEnabled(false);
                rdoTenantNone.Enabled = true;
                rdoTenantNone.Checked = true;
            }
            else
            {
                SetTenantOptionsEnabled(true);
                rdoTenantNone.Checked = true;   // NEW (Nov 21): same default as a Room issue
            }
        }

        /* ------------------------------------------------------------------
           Radio groups -> show the checked list only for "Specify"
           ------------------------------------------------------------------ */

        private void TenantOption_CheckedChanged(object sender, EventArgs e)
        {
            clbAffectedTenants.Visible = rdoTenantSpecify.Checked;
        }

        // ORIGINAL (Nov 21): Assigned To removed.
        // private void ResponsibleOption_CheckedChanged(object sender, EventArgs e)
        // {
        //     clbResponsible.Visible = rdoResponsibleSpecify.Checked;
        // }


        private void btnCancelIssue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAddIssue_Click(object sender, EventArgs e)
        {
            // ORIGINAL: if (!(cboRoom.SelectedItem is LookupItem room)) { Warn("Please select a room.", cboRoom); return; }
            // NEW (Maintenance v2): a Building issue has no room.
            bool buildingIssue = rdoIssueTypeBuilding.Checked;
            LookupItem room = cboRoom.SelectedItem as LookupItem;
            if (!buildingIssue && room == null)
            {
                Warn("Please select a room.", cboRoom);
                return;
            }

            string title = txtIssue.Text.Trim();
            if (title.Length == 0)
            {
                Warn("Please enter the issue.", txtIssue);
                return;
            }

            // ---- Charged tenants -------------------------------------------
            List<int> tenantIds;
            if (rdoTenantAll.Checked)
            {
                tenantIds = clbAffectedTenants.Items.Cast<LookupItem>().Select(t => t.Id).ToList();
            }
            else if (rdoTenantSpecify.Checked)
            {
                tenantIds = clbAffectedTenants.CheckedItems.Cast<LookupItem>().Select(t => t.Id).ToList();
                if (tenantIds.Count == 0)
                {
                    // ORIGINAL: Warn("Check at least one affected tenant, or choose None.", clbAffectedTenants);
                    Warn("Check at least one tenant to charge, or choose None.", clbAffectedTenants);   // NEW (Nov 10)
                    return;
                }
            }
            else if (rdoTenantNone.Checked)
            {
                tenantIds = new List<int>();
            }
            else
            {
                // ORIGINAL: Warn("Choose who is affected: All, Specify, or None.", rdoTenantAll);
                Warn("Choose who to charge: All, Specify, or None.", rdoTenantAll);   // NEW (Nov 10)
                return;
            }

            /* ORIGINAL (Nov 21): Assigned To removed.
            // ---- Responsible -----------------------------------------------
            List<ResponsibleOption> responsible;
            if (rdoResponsibleAll.Checked)
            {
                responsible = _responsibleOptions;
            }
            else if (rdoResponsibleSpecify.Checked)
            {
                responsible = clbResponsible.CheckedItems.Cast<ResponsibleOption>().ToList();
                if (responsible.Count == 0)
                {
                    // ORIGINAL: Warn("Check at least one responsible person, or choose None.", clbResponsible);
                    Warn("Check at least one person to assign, or choose None.", clbResponsible);   // NEW (Nov 10)
                    return;
                }
            }
            else if (rdoResponsibleNone.Checked)
            {
                responsible = new List<ResponsibleOption>();
            }
            else
            {
                // ORIGINAL: Warn("Choose who is responsible: All, Specify, or None.", rdoResponsibleAll);
                Warn("Choose who is assigned: All, Specify, or None.", rdoResponsibleAll);   // NEW (Nov 10)
                return;
            }
            */

            if (dtpIssueDate.Value.Date > DateTime.Today)
            {
                Warn("The issue date cannot be in the future.", dtpIssueDate);
                return;
            }

            // NEW (Nov 21): Charged Tenants now defaults to None, so a hurried
            // save would quietly make the building pay. Confirm it once.
            // Delete this block if the prompt becomes noise.
            if (tenantIds.Count == 0)
            {
                DialogResult choice = MessageBox.Show(
                    "No tenant will be charged for this issue.\n\n" +
                    "When the repair is done, the materials cost is recorded as a " +
                    "building expense. Continue?",
                    "No Tenant Charged", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (choice != DialogResult.Yes)
                    return;
            }

            // ORIGINAL (Nov 21): Assigned To removed.
            // bool ownerResponsible = responsible.Any(r => r.IsOwner);
            // List<int> employeeIds = responsible
            //     .Where(r => !r.IsOwner && r.EmployeeId.HasValue)
            //     .Select(r => r.EmployeeId.Value)
            //     .ToList();

            try
            {
                // NEW (Maintenance v2): Building issue -> AddBuildingIssue; Room issue -> AddIssue (unchanged)
                // NEW (Nov 21): the description and Assigned To arguments are gone from both.
                if (buildingIssue)
                    NewIssueId = MaintenanceService.AddBuildingIssue(
                        Session.BuildingId,
                        title,
                        // ORIGINAL: txtDescription.Text.Trim(),
                        dtpIssueDate.Value.Date,
                        tenantIds,
                        // ORIGINAL (Nov 21): ownerResponsible,
                        // ORIGINAL (Nov 21): employeeIds,
                        Session.UserId);
                else
                    NewIssueId = MaintenanceService.AddIssue(
                        room.Id,
                        title,
                        // ORIGINAL: txtDescription.Text.Trim(),
                        dtpIssueDate.Value.Date,
                        tenantIds,
                        // ORIGINAL (Nov 21): ownerResponsible,
                        // ORIGINAL (Nov 21): employeeIds,
                        Session.UserId);
            }
            catch (InvalidOperationException ex)
            {
                // Expected rule violation (e.g. a tenant moved out meanwhile).
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

            MaterialsNeeded = rdoMaterialsYes.Checked;

            // ORIGINAL: MessageBox.Show("Maintenance issue added. The room is now under maintenance.",
            MessageBox.Show(buildingIssue
                    ? "Building maintenance issue added."
                    : "Maintenance issue added. The room is now under maintenance.",
                "Issue Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Warn(string message, Control focus)
        {
            MessageBox.Show(message, "Missing Information",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // focus.Focus();
            // Focusing a RadioButton checks it automatically (WinForms behaviour),
            // which picked "All" for the user. Only focus non-radio controls.
            if (!(focus is RadioButton)) focus.Focus();
        }

    }
}
