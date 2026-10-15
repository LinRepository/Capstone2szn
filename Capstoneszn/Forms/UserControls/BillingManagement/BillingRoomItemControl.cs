using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Rooms
{
    /// <summary>
    /// A room's payment state, as Billing Management sees it. Deliberately
    /// separate from the occupancy status the Rooms module uses - the same
    /// room can be "Occupied" there and "Overdue" here.
    /// </summary>
    public enum BillingRoomState
    {
        Vacant,     // nobody to bill
        Settled,    // occupied, nothing owing
        Unpaid,     // owing, not yet past due
        Overdue     // at least one share is past its due date
    }

    /// <summary>
    /// One room on the Billing Management grid.
    ///
    /// Display only. The caller works out the state from the ledger and
    /// hands it over through Bind(); this control just shows it and reports
    /// clicks. That keeps the billing rule next to the query that feeds it,
    /// not buried in a UI widget.
    /// </summary>
    /// 
    public partial class BillingRoomItemControl : UserControl
    {

        private static readonly Color NormalBack = Color.FromArgb(11, 20, 38);
        private static readonly Color HoverBack = Color.FromArgb(26, 40, 68);

        /// <summary>
        /// Raised wherever on the card the user clicks. The sender is always
        /// the card itself, never the label underneath the mouse.
        /// </summary>
        public event EventHandler CardClicked;

        public int RoomId { get; private set; }
        public string RoomNumber { get; private set; } = "";
        public BillingRoomState State { get; private set; } = BillingRoomState.Vacant;


        public BillingRoomItemControl()
        {
            InitializeComponent();

            // A click on a Label raises the Label's Click, not the
            // UserControl's. Without forwarding every child, the card only
            // responds when you hit its 1-pixel border.
            HookPart(this);
            HookChildren(this);
        }

        /// <param name="occupancy">Already formatted by the caller, e.g. "2/3 tenants".</param>
        /// <param name="outstanding">Everything still owed by current occupants.</param>
        /// <param name="overdue">The part of <paramref name="outstanding"/> that is past due.</param>
        /// 

        public void Bind(int roomId, string roomNumber, string occupancy,
                         BillingRoomState state, decimal outstanding, decimal overdue)
        {
            RoomId = roomId;
            RoomNumber = roomNumber;
            State = state;

            lblRoomNumber.Text = "ROOM " + roomNumber;
            lblOccupancy.Text = occupancy;

            switch (state)
            {
                case BillingRoomState.Overdue:
                    // The urgent figure. The full breakdown is one click away.
                    lblMoneyState.Text = $"{overdue:N2} overdue";
                    break;
                case BillingRoomState.Unpaid:
                    lblMoneyState.Text = $"{outstanding:N2} due";
                    break;
                case BillingRoomState.Settled:
                    lblMoneyState.Text = "Settled";
                    break;
                default:
                    lblMoneyState.Text = "Vacant";
                    break;
            }

            pnlStatusStrip.BackColor = StripColor(state);
            lblMoneyState.ForeColor = TextColor(state);
        }


        /* =================================================================
           COLOURS

           The strip uses the same family as the Rooms module so the app
           reads as one system. The text uses lighter variants where the
           strip colour would be hard to read on the navy background -
           Crimson text on navy is too dark to read at a glance.
           ================================================================= */

        private static Color StripColor(BillingRoomState state)
        {
            switch (state)
            {
                case BillingRoomState.Overdue: return Color.Crimson;
                case BillingRoomState.Unpaid: return Color.Gold;
                case BillingRoomState.Settled: return Color.Chartreuse;
                default: return Color.LightSlateGray;
            }
        }

        private static Color TextColor(BillingRoomState state)
        {
            switch (state)
            {
                case BillingRoomState.Overdue: return Color.Tomato;
                case BillingRoomState.Unpaid: return Color.Gold;
                case BillingRoomState.Settled: return Color.Chartreuse;
                default: return Color.LightSlateGray;
            }
        }


        /* =================================================================
           CLICK AND HOVER PLUMBING
           ================================================================= */

        private void HookChildren(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                HookPart(child);
                if (child.HasChildren) HookChildren(child);
            }
        }

        private void HookPart(Control part)
        {
            part.Click += AnyPart_Click;
            part.MouseEnter += AnyPart_MouseEnter;
            part.MouseLeave += AnyPart_MouseLeave;
        }

        private void AnyPart_Click(object sender, EventArgs e)
        {
            CardClicked?.Invoke(this, EventArgs.Empty);
        }

        private void AnyPart_MouseEnter(object sender, EventArgs e)
        {
            SetHover(true);
        }

        /// <summary>
        /// Moving from the card onto one of its own labels raises MouseLeave
        /// on the card. Only drop the highlight when the pointer has really
        /// left the card's rectangle, or it flickers as you move across it.
        /// </summary>
        private void AnyPart_MouseLeave(object sender, EventArgs e)
        {
            if (!ClientRectangle.Contains(PointToClient(Cursor.Position)))
                SetHover(false);
        }

        private void SetHover(bool on)
        {
            // Labels and the body panel have no BackColor of their own, so
            // they inherit this. The status strip keeps its colour.
            BackColor = on ? HoverBack : NormalBack;
        }


        private void pnlStatusStrip_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
