using Capstoneszn.Forms.UserControls.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls
{
    /// <summary>
    /// The Notification module: every room of the selected building that is
    /// Overdue or Due Soon (within 7 days), one card per room. The list is
    /// worked out live from the bills (NotificationService) - nothing is
    /// stored, so there is no Delete or Mark as read: a card disappears by
    /// itself once the room pays. Clicking a card opens that room's billing.
    /// </summary>
    public partial class NotificationControl : UserControl
    {
        // NEW (Notification): the full list, loaded once; search only filters it.
        private List<RoomNotification> _all = new List<RoomNotification>();
        public NotificationControl()
        {
            InitializeComponent();

            // Moved to NotificationControl_Load: in the constructor the flow
            // panel still has the designer's width, so the cards would be
            // sized wrong.

            // NEW (Notification): a vertical list that scrolls when it is long.
            // TopDown + WrapContents would start a second column instead.
            flpNotifications.AutoScroll = true;
            flpNotifications.WrapContents = false;
            flpNotifications.Resize += flpNotifications_Resize;

            // NEW (Notification): search as you type, plus the 🔍 button.
            // These events are NOT wired in the designer - if you ever
            // double-click them in the designer, remove these lines or each
            // fires twice.
            txtNotificationSearch.TextChanged += txtNotificationSearch_TextChanged;
            txtNotificationSearch.KeyDown += txtNotificationSearch_KeyDown;
        }

        private void LoadNotifications()
        {
            // ORIGINAL (placeholder cards, kept per team rule):
            // flpNotifications.BringToFront();
            // flpNotifications.Controls.Clear();
            //
            // for (int i = 0; i < 5; i++)
            // {
            //     NotificationItem item = new NotificationItem();
            //
            //     item.Width = flpNotifications.Size.Width;
            //     item.Height = 60;
            //     item.Margin = new Padding(10);
            //     item.BackColor = Color.Navy; // Bright color to guarantee visibility
            //
            //     flpNotifications.Controls.Add(item);
            // }

            // NEW (Notification): the real list for the selected building.
            try
            {
                _all = NotificationService.GetRoomNotifications(Session.BuildingId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                _all = new List<RoomNotification>();
                MessageBox.Show("Could not load the notifications.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ShowCards();
        }

        private void NotificationControl_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        /// <summary>
        /// Puts the cards on screen, filtered by the search box. All of
        /// them - no limit. Already sorted by NotificationService.
        /// </summary>
        private void ShowCards()
        {
            string search = CleanSearch(txtNotificationSearch.Text);

            List<RoomNotification> shown = search.Length == 0
                ? _all
                : _all.Where(n => n.RoomNumber.Contains(search)).ToList();

            flpNotifications.SuspendLayout();

            // Dispose rather than just Clear, or every search leaks the old cards.
            for (int i = flpNotifications.Controls.Count - 1; i >= 0; i--)
                flpNotifications.Controls[i].Dispose();
            flpNotifications.Controls.Clear();

            if (shown.Count == 0)
            {
                string message = _all.Count == 0
                    ? "No due or overdue bills. All rooms are settled."
                    : $"No notification for room \"{search}\".";

                flpNotifications.Controls.Add(new Label
                {
                    Text = message,
                    Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                    ForeColor = Color.Gainsboro,
                    AutoSize = true,
                    Margin = new Padding(10, 20, 10, 10)
                });
            }
            else
            {
                int cardWidth = CardWidth();

                foreach (RoomNotification n in shown)
                {
                    NotificationItem item = new NotificationItem
                    {
                        Width = cardWidth,
                        Margin = new Padding(0, 0, 0, 10)
                        // Height and colours come from the designer.
                    };

                    item.Bind(n);
                    item.CardClicked += NotificationItem_CardClicked;

                    flpNotifications.Controls.Add(item);
                }
            }

            flpNotifications.ResumeLayout();
        }

        /// <summary>
        /// Card width = the visible width of the list, leaving room for the
        /// vertical scrollbar so the cards never cause a sideways scroll.
        /// </summary>
        private int CardWidth()
        {
            return Math.Max(300,
                flpNotifications.ClientSize.Width
                - flpNotifications.Padding.Horizontal
                - SystemInformation.VerticalScrollBarWidth - 5);
        }


        private void flpNotifications_Resize(object? sender, EventArgs e)
        {
            int cardWidth = CardWidth();
            foreach (Control c in flpNotifications.Controls)
                if (c is NotificationItem) c.Width = cardWidth;
        }

        /* =================================================================
           CLICK - open that room's billing
           ================================================================= */

        private void NotificationItem_CardClicked(object? sender, EventArgs e)
        {
            if (sender is NotificationItem item && this.ParentForm is MainForm mainForm)
            {
                mainForm.OpenRoomBilling(item.RoomId);
            }
        }

        /* =================================================================
           SEARCH - room number only
           ================================================================= */

        private void txtNotificationSearch_TextChanged(object? sender, EventArgs e)
        {
            ShowCards();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            ShowCards();
        }

        /// <summary>The search box is Multiline in the designer - stop Enter from adding a new line.</summary>
        private void txtNotificationSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ShowCards();
            }
        }

        /// <summary>Trims spaces and any pasted line breaks.</summary>
        private static string CleanSearch(string text)
        {
            return (text ?? "").Replace("\r", "").Replace("\n", "").Trim();
        }
    }
}
