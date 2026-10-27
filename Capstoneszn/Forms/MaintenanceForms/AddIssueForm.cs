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
    /// Affected Tenants = who will be CHARGED when the issue is completed.
    /// Responsible      = who handles the work (owner and/or caretakers).
    ///
    /// After a successful save the form closes with DialogResult.OK and
    /// exposes NewIssueId and MaterialsNeeded, so MaintenanceControl can
    /// refresh the list and, when "Yes" was picked, open the materials form.
    /// </summary>
    /// 

    public partial class AddIssueForm : Form
    {
        public int NewIssueId { get; private set; }
        public bool MaterialsNeeded { get; private set; }

        private List<ResponsibleOption> _responsibleOptions = new List<ResponsibleOption>();

        public AddIssueForm()
        {
            InitializeComponent();

            // Each radio sits in its own panel, so WinForms doesn't group them.
            // Link each set so only one in the group can be selected.
            RadioGroupHelper.Link(rdoTenantAll, rdoTenantSpecify, rdoTenantNone);
            RadioGroupHelper.Link(rdoResponsibleAll, rdoResponsibleSpecify, rdoResponsibleNone);
            RadioGroupHelper.Link(rdoMaterialsYes, rdoMaterialsNo);
            // Wired here only - the designer has no handlers on these.
            cboRoom.SelectedIndexChanged += cboRoom_SelectedIndexChanged;

            rdoTenantAll.CheckedChanged += TenantOption_CheckedChanged;
            rdoTenantSpecify.CheckedChanged += TenantOption_CheckedChanged;
            rdoTenantNone.CheckedChanged += TenantOption_CheckedChanged;

            rdoResponsibleAll.CheckedChanged += ResponsibleOption_CheckedChanged;
            rdoResponsibleSpecify.CheckedChanged += ResponsibleOption_CheckedChanged;
            rdoResponsibleNone.CheckedChanged += ResponsibleOption_CheckedChanged;

            CancelButton = btnCancelIssue;
        }

        private void AddIssueForm_Load(object sender, EventArgs e)
        {
            // Lists start hidden; they only appear when "Specify" is picked.
            clbAffectedTenants.Visible = false;
            clbResponsible.Visible = false;

            // An issue cannot be reported for a future date.
            dtpIssueDate.MaxDate = DateTime.Today;
            dtpIssueDate.Value = DateTime.Today;

            // Not stored - only decides whether the materials form opens next.
            rdoMaterialsNo.Checked = true;

            // Room is the default type. Building issues need the database
            // change first (RoomId nullable + BuildingId), so the Building
            // option stays disabled until that step is done.
            rdoIssueTypeRoom.Checked = true;
            rdoIssueTypeBuilding.Enabled = false;

            // No tenant group choice until a room is picked.
            SetTenantOptionsEnabled(false);

            try
            {
                cboRoom.DataSource = MaintenanceService.GetRoomsForIssue(Session.BuildingId);
                cboRoom.SelectedIndex = -1;   // force the user to choose a room

                _responsibleOptions = MaintenanceService.GetResponsibleOptions(Session.BuildingId);
                clbResponsible.Items.Clear();
                foreach (ResponsibleOption option in _responsibleOptions)
                    clbResponsible.Items.Add(option);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load rooms or staff.\n\n" + ex.Message,
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
            }
        }

        private void SetTenantOptionsEnabled(bool enabled)
        {
            rdoTenantAll.Enabled = enabled;
            rdoTenantSpecify.Enabled = enabled;
            rdoTenantNone.Enabled = enabled;
        }

        /* ------------------------------------------------------------------
           Radio groups -> show the checked list only for "Specify"
           ------------------------------------------------------------------ */

        private void TenantOption_CheckedChanged(object sender, EventArgs e)
        {
            clbAffectedTenants.Visible = rdoTenantSpecify.Checked;
        }

        private void ResponsibleOption_CheckedChanged(object sender, EventArgs e)
        {
            clbResponsible.Visible = rdoResponsibleSpecify.Checked;
        }


        private void btnCancelIssue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAddIssue_Click(object sender, EventArgs e)
        {
            if (!(cboRoom.SelectedItem is LookupItem room))
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

            // ---- Affected tenants ------------------------------------------
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
                    Warn("Check at least one affected tenant, or choose None.", clbAffectedTenants);
                    return;
                }
            }
            else if (rdoTenantNone.Checked)
            {
                tenantIds = new List<int>();
            }
            else
            {
                Warn("Choose who is affected: All, Specify, or None.", rdoTenantAll);
                return;
            }

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
                    Warn("Check at least one responsible person, or choose None.", clbResponsible);
                    return;
                }
            }
            else if (rdoResponsibleNone.Checked)
            {
                responsible = new List<ResponsibleOption>();
            }
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

            bool ownerResponsible = responsible.Any(r => r.IsOwner);
            List<int> employeeIds = responsible
                .Where(r => !r.IsOwner && r.EmployeeId.HasValue)
                .Select(r => r.EmployeeId.Value)
                .ToList();

            try
            {
                NewIssueId = MaintenanceService.AddIssue(
                    room.Id,
                    title,
                    txtDescription.Text.Trim(),
                    dtpIssueDate.Value.Date,
                    tenantIds,
                    ownerResponsible,
                    employeeIds,
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

            MessageBox.Show("Maintenance issue added. The room is now under maintenance.",
                "Issue Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Warn(string message, Control focus)
        {
            MessageBox.Show(message, "Missing Information",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus.Focus();
        }

    }
}
