using System.Drawing;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Notification
{
    /// <summary>
    /// NEW (UI improvement): the status colours of the notifications, shared
    /// by the cards, the screen's header counts and the Home dashboard list.
    /// The strip colours are the same ones the billing screen uses.
    /// </summary>
    public static class NotificationColors
    {
        // Solid colours: the card's edge strip and the header dots.
        public static readonly Color OverdueStrip = Color.Crimson;
        public static readonly Color DueSoonStrip = Color.DarkOrange;

        // Lighter versions for TEXT on the dark navy background
        // (Crimson text on navy is too dark to read).
        public static readonly Color OverdueText = Color.FromArgb(255, 138, 156);
        public static readonly Color DueSoonText = Color.FromArgb(255, 194, 122);
    }


    /// <summary>
    /// NEW (UI improvement): the look of one notification card.
    ///
    ///   | Room 202                                   ₱4,000.00    View billing › |
    ///   | Tenants owing: 2 of 3 · Due Oct 28, 2026   21 days overdue             |
    ///   ^ thin colour strip
    ///
    /// Appearance only - the click, the data and the designer stay the same.
    /// It is kept in its own file so NotificationItem.Designer.cs stays
    /// untouched; to go back to the old look, comment out ApplyItemTheme()
    /// in the constructor (and the three NEW lines in Bind).
    ///
    /// Because this runs at runtime, the Designer view in Visual Studio still
    /// shows the old look. The new look appears when the program runs.
    /// </summary>
    public partial class NotificationItem
    {
        public const int CardHeight = 72;

        // Created here, not in the designer: the amount on the right, and the
        // area that holds "View billing ›" at the far right.
        private readonly Label lblAmount = new Label { Name = "lblAmount" };
        private readonly Panel pnlView = new Panel { Name = "pnlView" };

        private void ApplyItemTheme()
        {
            // The card: theme colour, no white border. Every panel and label
            // inside has no colour of its own, so they all follow this one -
            // which is what makes the hover below work.
            BorderStyle = BorderStyle.None;
            BackColor = UiTheme.Card;
            Height = CardHeight;

            pnlColourStrip.Width = 5;   // was 57 - a thin edge is enough

            StyleRoomSide();
            StyleAmountSide();
            StyleViewLink();
            WireHover(this);
        }

        /* ---- left: room number, then tenants owing + due date ---- */

        private void StyleRoomSide()
        {
            panel3.Padding = new Padding(16, 11, 10, 8);

            StyleLine(lblTitle, new Font("Segoe UI Semibold", 13F), Color.White, 28, ContentAlignment.MiddleLeft);
            StyleLine(lblDescription, new Font("Segoe UI", 10F), UiTheme.MutedText, 22, ContentAlignment.MiddleLeft);

            // Dock Top stacks from the back: bringing the description to the
            // front puts it UNDER the title.
            lblDescription.BringToFront();
        }

        /* ---- right: amount, then "21 days overdue" ---- */

        private void StyleAmountSide()
        {
            panel2.Width = 190;
            panel2.Padding = new Padding(0, 11, 12, 8);

            panel2.Controls.Add(lblAmount);
            StyleLine(lblAmount, new Font("Segoe UI Semibold", 13F), Color.White, 28, ContentAlignment.MiddleRight);
            StyleLine(lblDays, new Font("Segoe UI", 10F), UiTheme.MutedText, 22, ContentAlignment.MiddleRight);

            lblDays.BringToFront();   // under the amount
        }

        /* ---- far right: "View billing ›" in the logo's gold ---- */

        private void StyleViewLink()
        {
            pnlView.Dock = DockStyle.Right;
            pnlView.Width = 130;

            // Added last, so it docks first = the outermost right edge.
            panel1.Controls.Add(pnlView);

            pnlView.Controls.Add(label1);   // moves it out of panel2
            label1.AutoSize = false;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = new Font("Segoe UI Semibold", 10F);
            label1.ForeColor = UiTheme.Accent;
            label1.Text = "View billing  ›";   // ›
        }

        /// <summary>One line of text, full width, fixed height.</summary>
        private static void StyleLine(Label label, Font font, Color color, int height, ContentAlignment align)
        {
            label.AutoSize = false;
            label.Dock = DockStyle.Top;
            label.Height = height;
            label.Font = font;
            label.ForeColor = color;
            label.TextAlign = align;
            label.AutoEllipsis = true;   // "…" instead of cutting a long line
        }

        /* ---- hover: the card lights up under the mouse ---- */

        private void WireHover(Control parent)
        {
            parent.MouseEnter += (s, e) => BackColor = UiTheme.Selection;
            parent.MouseLeave += (s, e) =>
            {
                // Moving from one label to another inside the card also fires
                // MouseLeave - only reset when the mouse really left the card.
                if (!ClientRectangle.Contains(PointToClient(Cursor.Position)))
                    BackColor = UiTheme.Card;
            };

            foreach (Control child in parent.Controls)
                WireHover(child);
        }
    }
}
