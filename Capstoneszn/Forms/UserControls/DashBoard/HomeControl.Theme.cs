using System.Drawing;
using System.Windows.Forms;

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// NEW (UI improvement): the Home dashboard's Notification list in the
    /// dark theme, matching the Notification module.
    ///
    /// Appearance only. It is kept in its own file so HomeControl.Designer.cs
    /// stays untouched; to go back to the old grey list, comment out
    /// StyleNotificationList() in the constructor.
    ///
    /// StyleDarkList works on any ListView, so the Recent Activities list can
    /// get the same look later with one line: StyleDarkList(lvRecentActivities);
    /// </summary>
    public partial class HomeControl
    {
        private static readonly Font ListHeaderFont = new Font("Segoe UI Semibold", 10F);

        private void StyleNotificationList()
        {
            StyleDarkList(lvNotification);
        }

        private static void StyleDarkList(ListView lv)
        {
            lv.BackColor = UiTheme.Card;
            lv.ForeColor = Color.White;
            lv.BorderStyle = BorderStyle.None;
            lv.Font = new Font("Segoe UI", 10F);

            // Windows always paints ListView column headers light grey. The
            // only way to colour them is to draw them ourselves; the rows are
            // still drawn by Windows (DrawDefault).
            lv.OwnerDraw = true;
            lv.DrawColumnHeader += DarkList_DrawColumnHeader;
            lv.DrawItem += (s, e) => e.DrawDefault = true;
            lv.DrawSubItem += (s, e) => e.DrawDefault = true;
        }

        private static void DarkList_DrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var back = new SolidBrush(UiTheme.TitleBar))
                e.Graphics.FillRectangle(back, e.Bounds);

            Rectangle text = new Rectangle(e.Bounds.X + 6, e.Bounds.Y, e.Bounds.Width - 8, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, e.Header?.Text ?? "", ListHeaderFont, text, Color.White,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }
    }
}
