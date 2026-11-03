using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Notification
{
    /// <summary>
    /// One notification card = one room that is Overdue or Due Soon.
    /// The card only displays what it is given (Bind); the rules live in
    /// NotificationService. Clicking anywhere on the card raises CardClicked.
    /// </summary>
    public partial class NotificationItem : UserControl
    {
        // Same colours the billing screen uses for Overdue / Unpaid.
        private static readonly Color OverdueColor = Color.Crimson;
        private static readonly Color DueSoonColor = Color.DarkOrange;

        /// <summary>The room this card is about - read by the click handler.</summary>
        public int RoomId { get; private set; }

        /// <summary>Raised when the user clicks anywhere on the card.</summary>
        public event EventHandler? CardClicked;
        public NotificationItem()
        {
            InitializeComponent();

            // NEW (Notification): the labels and panels cover the whole card,
            // so a click on any of them must count as a click on the card.
            // Cursor is already Hand in the designer; child controls inherit it.
            WireClick(this);
        }
        /// <summary>Fills the card from one notification.</summary>
        public void Bind(RoomNotification n)
        {
            RoomId = n.RoomId;

            Color statusColor = n.IsOverdue ? OverdueColor : DueSoonColor;

            pnlColourStrip.BackColor = statusColor;
            lblTitle.Text = n.Title;              // OVERDUE · Room 202
            lblDescription.Text = n.Description;  // ₱4,000.00 unpaid · Tenants owing: 2 of 3 · Due Oct 28, 2026
            lblDays.Text = n.DaysText;            // 5 days overdue / Due in 3 days / Due today
            lblDays.ForeColor = statusColor;
            // label1 keeps its designer text "View billing >"
        }
        /// <summary>Hooks Click on the control and every child inside it.</summary>
        private void WireClick(Control parent)
        {
            parent.Click += AnyPart_Click;
            foreach (Control child in parent.Controls)
                WireClick(child);
        }
        private void AnyPart_Click(object? sender, EventArgs e)
        {
            CardClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
