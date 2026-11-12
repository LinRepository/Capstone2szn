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
    public partial class MaintenanceControl : UserControl
    {
        private const string FilterAll = "All";
        // NEW (Nov 12): below this width a card is too cramped, so the list
        // shows one card per row instead of two.
        private const int MinCardWidth = 760;

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

            flpMaintenanceIssues.AutoScroll = true;

            // NEW (Nov 12): re-fit the cards whenever the list changes size
            // (maximize, restore, sidebar toggle).
            flpMaintenanceIssues.ClientSizeChanged += (s, e) => ResizeCards();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
                LoadIssues();
        }

        /// <summary>
        /// Rebuilds the card list for the selected building and filter.
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

                // NEW (Nov 12): fit the new cards to the list's width.
                ResizeCards();

            }
            finally
            {
                flpMaintenanceIssues.ResumeLayout();
            }
        }

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
            // Always reserve the vertical scrollbar's width, so the cards
            // don't jump (or loop) when the scrollbar appears or disappears.
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

        /* ------------------------------------------------------------------
           Card actions. Edit and Delete reload the list on OK.
           ------------------------------------------------------------------ */

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

    }
}
