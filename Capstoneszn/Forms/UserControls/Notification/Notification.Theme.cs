using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Capstoneszn.Forms.UserControls.Notification;

namespace Capstoneszn.Forms.UserControls
{
    /// <summary>
    /// NEW (UI improvement): the look of the Notification module.
    ///
    ///   Notification            ● 3 overdue   ● 4 due soon   [ Search room number ]
    ///   OVERDUE · 3
    ///   [card]
    ///   DUE SOON · 4
    ///   [card]
    ///
    /// Appearance only - the list, search and click stay the same. It is kept
    /// in its own file so Notification.Designer.cs stays untouched; to go back
    /// to the old look, comment out ApplyNotificationTheme() in the constructor.
    ///
    /// Because this runs at runtime, the Designer view in Visual Studio still
    /// shows the old look. The new look appears when the program runs.
    /// </summary>
    public partial class NotificationControl
    {
        // Created here, not in the designer: holds the two counts in the header.
        private readonly FlowLayoutPanel flpCounts = new FlowLayoutPanel { Name = "flpCounts" };

        private void ApplyNotificationTheme()
        {
            BorderStyle = BorderStyle.None;
            BackColor = UiTheme.Page;

            StyleHeader();

            pnlNotificationContent.Padding = new Padding(10, 0, 10, 10);
            flpNotifications.BackColor = UiTheme.Page;
        }

        /* =================================================================
           HEADER - title, counts and search on ONE row
           (the designer's second row is hidden; its controls move up)
           ================================================================= */

        private void StyleHeader()
        {
            pnlNotificationHeader.BorderStyle = BorderStyle.None;
            pnlNotificationHeader.Height = 66;
            pnlNotificationHeader.Padding = new Padding(10, 13, 10, 13);

            lblNotificationTitle.Font = new Font("Segoe UI Semibold", 20F);
            lblNotificationTitle.TextAlign = ContentAlignment.MiddleLeft;

            // Right side, from the edge inwards: search box, then the counts.
            // Dock Right places the LAST added control outermost, so the
            // search container is added after the counts.
            StyleCounts();
            pnlNotificationHeader.Controls.Add(flpCounts);
            StyleSearch();
            pnlNotificationHeader.Controls.Add(pnlNotificationSearchContainer);

            lblNotificationTitle.BringToFront();   // Fill must dock last

            // The old second row (bordered search + legend) is now empty.
            pnlNotificationHeaderContent.Visible = false;
        }

        /// <summary>
        /// The designer's legend (two big squares + "Near Due" / "Overdue")
        /// becomes two live counts with small dots: "● 3 overdue  ● 4 due soon".
        /// The texts are filled by UpdateCounts().
        /// </summary>
        private void StyleCounts()
        {
            flpCounts.Dock = DockStyle.Right;
            flpCounts.Width = 290;
            flpCounts.WrapContents = false;
            flpCounts.FlowDirection = FlowDirection.LeftToRight;
            flpCounts.Padding = new Padding(0, 0, 10, 0);

            // Overdue first, like the list. Adding moves them out of panel3.
            flpCounts.Controls.Add(panel1);   // crimson dot
            flpCounts.Controls.Add(label1);   // "3 overdue"
            flpCounts.Controls.Add(panel2);   // orange dot
            flpCounts.Controls.Add(label2);   // "4 due soon"

            foreach (Panel dot in new[] { panel1, panel2 })
            {
                dot.Size = new Size(12, 12);
                dot.Margin = new Padding(0, 15, 7, 0);
            }

            StyleCount(label1, NotificationColors.OverdueText);
            StyleCount(label2, NotificationColors.DueSoonText);
        }

        private static void StyleCount(Label label, Color color)
        {
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 11F);
            label.ForeColor = color;
            label.Margin = new Padding(0, 8, 20, 0);
        }

        /// <summary>White search box without the old border - same as the Tenants screen.</summary>
        private void StyleSearch()
        {
            pnlNotificationSearchContainer.Dock = DockStyle.Right;
            pnlNotificationSearchContainer.Width = 300;
            pnlNotificationSearchContainer.BackColor = Color.White;
            pnlNotificationSearchContainer.Padding = new Padding(10, 8, 10, 4);

            txtNotificationSearch.BorderStyle = BorderStyle.None;
            txtNotificationSearch.Font = new Font("Segoe UI", 12F);
            txtNotificationSearch.TextAlign = HorizontalAlignment.Left;
            txtNotificationSearch.Dock = DockStyle.Fill;
        }

        /* =================================================================
           LIST PARTS - used by ShowCards() in Notification.cs
           ================================================================= */

        /// <summary>Header counts - always the FULL list, not the search result.</summary>
        private void UpdateCounts()
        {
            int overdue = _all.Count(n => n.IsOverdue);
            int dueSoon = _all.Count - overdue;

            label1.Text = $"{overdue} overdue";
            label2.Text = $"{dueSoon} due soon";
        }

        /// <summary>Small heading above each group: "OVERDUE · 3" / "DUE SOON · 4".</summary>
        private static Label MakeSectionLabel(bool overdue, int count)
        {
            return new Label
            {
                Text = (overdue ? "OVERDUE" : "DUE SOON") + " · " + count,
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 9.5F),
                ForeColor = UiTheme.MutedText,
                Margin = new Padding(2, 12, 0, 6)
            };
        }
    }
}
