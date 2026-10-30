using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls
{
    /// <summary>
    /// One maintenance issue card. It only displays data and raises events;
    /// MaintenanceControl decides what each action opens. That keeps the card
    /// free of database code and lets the list refresh after any change.
    /// </summary>
    /// 

    public partial class MaintenanceIssueControl : UserControl
    {
        public int IssueId { get; private set; }
        public bool IsPending { get; private set; }

        public event EventHandler DetailsRequested;
        public event EventHandler ViewMaterialsRequested;
        public event EventHandler EditRequested;
        public event EventHandler DeleteRequested;


        public MaintenanceIssueControl()
        {
            InitializeComponent();

            // Wired here only. Do NOT also double-click these buttons in the
            // designer, or each click will fire twice.
            btnViewMaterials.Click += (s, e) => ViewMaterialsRequested?.Invoke(this, EventArgs.Empty);
            btnEditIssue.Click += (s, e) => EditRequested?.Invoke(this, EventArgs.Empty);
            btnDeleteIssue.Click += (s, e) => DeleteRequested?.Invoke(this, EventArgs.Empty);

            // Clicking the card - or any label/panel on it - opens Details.
            // The buttons (and the strip that holds them) are excluded.
            Click += RaiseDetails;
            WireDetailsClick(this);
        }

        private void WireDetailsClick(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is Button || child == pnlIssueActions)
                    continue;

                child.Click += RaiseDetails;
                WireDetailsClick(child);
            }
        }

        private void RaiseDetails(object sender, EventArgs e)
        {
            DetailsRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Fills the card. Edit and Delete are hidden on a Complete issue:
        /// by then a bill or expense may exist, and changing the issue would
        /// silently change what tenants owe.
        /// </summary>
        public void Bind(MaintenanceIssueSummary issue)
        {
            IssueId = issue.IssueId;
            IsPending = issue.IsPending;

            // ORIGINAL: lblUnitValue.Text = issue.RoomNumber;
            // NEW (Maintenance v2): "Building | <building name>" for a Building issue
            lblUnitTitle.Text = issue.IsBuildingIssue ? "Building" : "Room";
            lblUnitValue.Text = issue.IsBuildingIssue ? issue.BuildingName : issue.RoomNumber;
            lblStatusValue.Text = issue.Status;
            // ORIGINAL: lblStatusValue.ForeColor = issue.IsPending ? Color.Orange : Color.LightGreen;
            // NEW (Maintenance v2): Pending = repair not done; For Payment = waiting for tenants; Complete = settled
            lblStatusValue.ForeColor = issue.IsPending ? Color.Orange
                                     : issue.Status == MaintenanceService.StatusForPayment ? Color.Gold
                                     : Color.LightGreen;
            lblIssueValue.Text = issue.IssueTitle;
            lblDescriptionValue.Text = string.IsNullOrWhiteSpace(issue.Description)
                ? "-" : issue.Description;
            lblResponsibleValue.Text = issue.Responsible;
            lblDateValue.Text = issue.DateReported.ToString("MMM dd, yyyy");

            btnEditIssue.Visible = issue.IsPending;
            btnDeleteIssue.Visible = issue.IsPending;
        }

        private void btnEditIssue_Click(object sender, EventArgs e)
        {

        }
    }
}
