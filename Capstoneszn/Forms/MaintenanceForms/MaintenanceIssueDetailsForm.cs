using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms
{
    /// <summary>
    /// Read-only view of one maintenance issue, opened by clicking a card.
    /// Shows no money (decision G) - costs live in View Materials.
    /// </summary>
    /// 

    public partial class MaintenanceIssueDetailsForm : Form
    {
        private readonly int _issueId;

        public MaintenanceIssueDetailsForm(int issueId)
        {
            InitializeComponent();

            _issueId = issueId;

            // The redesigned layout (two columns) docks every label in the
            // designer, so the runtime re-arrangement is no longer needed.
            // ArrangeLayout();

            CancelButton = btnCloseDetails;
        }

        /// <summary>
        /// The designer places each title/value pair at fixed positions with
        /// AutoSize on, so a long tenant list or description runs off the form.
        /// Docking the title to the top and the value to fill each panel keeps
        /// every value inside its box, whatever its length.
        /// </summary>
        private void ArrangeLayout()
        {
            Arrange(lblUnitTitle, lblUnitValue, ContentAlignment.MiddleCenter);
            Arrange(lblDateTitle, lblDateValue, ContentAlignment.MiddleCenter);
            // lblAffectedTenantsValue was replaced by dgvAffectedTenants.
            // Arrange(lblAffectedTenantsTitle, lblAffectedTenantsValue, ContentAlignment.MiddleCenter);
            Arrange(lblResponsibleTitle, lblResponsibleValue, ContentAlignment.MiddleCenter);
            Arrange(lblIssueTitle, lblIssueValue, ContentAlignment.MiddleCenter);
            Arrange(lblStatusTitle, lblStatusValue, ContentAlignment.MiddleCenter);
            Arrange(lblDescriptionTitle, lblDescriptionValue, ContentAlignment.TopLeft);

            lblDescriptionValue.Padding = new Padding(15, 5, 15, 5);
        }

        private static void Arrange(Label title, Label value, ContentAlignment valueAlign)
        {
            title.AutoSize = false;
            title.Dock = DockStyle.Top;
            title.Height = 30;
            title.TextAlign = ContentAlignment.MiddleCenter;

            value.AutoSize = false;
            value.Dock = DockStyle.Fill;
            value.TextAlign = valueAlign;
            value.AutoEllipsis = true;
            value.BringToFront();   // the Fill control must dock last
        }

        private void MaintenanceIssueDetailsForm_Load(object sender, EventArgs e)
        {
            MaintenanceIssueDetails d;
            try
            {
                d = MaintenanceService.GetIssueDetails(_issueId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the issue.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (d == null)
            {
                MessageBox.Show("This issue no longer exists.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            lblUnitValue.Text = "Room " + d.RoomNumber;
            lblDateValue.Text = d.DateReported.ToString("MMM dd, yyyy");

            // Affected tenants are now a grid (Tenant | Room) instead of one label.
            // lblAffectedTenantsValue.Text = string.IsNullOrWhiteSpace(d.AffectedTenants)
            //     ? "None (building expense)"
            //     : d.AffectedTenants;

            lblResponsibleValue.Text = d.Responsible;
            lblIssueValue.Text = d.IssueTitle;

            // The completed date now has its own label, so Status shows the status only.
            // lblStatusValue.Text = d.IsPending || !d.CompletedAt.HasValue
            //     ? d.Status
            //     : d.Status + " (" + d.CompletedAt.Value.ToString("MMM dd, yyyy") + ")";
            lblStatusValue.Text = d.Status;
            lblStatusValue.ForeColor = d.IsPending ? Color.Orange : Color.LightGreen;

            lblCompletedValue.Text = d.CompletedAt.HasValue
                ? d.CompletedAt.Value.ToString("MMM dd, yyyy")
                : "-";

            lblDescriptionValue.Text = string.IsNullOrWhiteSpace(d.Description)
                ? "-" : d.Description;

            LoadGrids();
        }

        /// <summary>
        /// Fills the Affected Tenants and Materials grids. Materials show the
        /// name and quantity only - no money on this form (decision G).
        /// </summary>
        private void LoadGrids()
        {
            List<AffectedTenantRow> tenants;
            List<MaintenanceMaterial> materials;
            try
            {
                tenants = MaintenanceService.GetAffectedTenantsForDetails(_issueId);
                materials = MaintenanceService.GetMaterials(_issueId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the tenants or materials.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Only the columns defined in the designer; TotalCost/UnitPrice stay hidden.
            dgvAffectedTenants.AutoGenerateColumns = false;
            dgvAffectedTenants.DataSource = tenants;
            lblAffectedTenantsTitle.Text = tenants.Count == 0
                ? "Affected Tenants - none (building expense)"
                : "Affected Tenants";

            dgvMaterials.AutoGenerateColumns = false;
            dgvMaterials.DataSource = materials;
            lblMaterialsTitle.Text = materials.Count == 0
                ? "Materials - none recorded"
                : "Materials";
        }

        private void btnCloseDetails_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
