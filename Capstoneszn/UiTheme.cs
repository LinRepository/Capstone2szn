using System.Drawing;
using System.Windows.Forms;

namespace Capstoneszn
{
    /// <summary>
    /// NEW (UI improvement): the shared colours and styles of the system, so
    /// every module reads as one application. The grid colours are the same
    /// ones the redesigned Move In form already uses.
    ///
    /// Only appearance lives here. Nothing in this class touches data.
    /// </summary>
    public static class UiTheme
    {
        public static readonly Color Page = Color.FromArgb(25, 25, 70);
        public static readonly Color Card = Color.FromArgb(35, 35, 90);
        public static readonly Color CardAlternate = Color.FromArgb(30, 30, 80);
        public static readonly Color TitleBar = Color.FromArgb(45, 45, 110);
        public static readonly Color Selection = Color.FromArgb(60, 60, 140);
        public static readonly Color Line = Color.FromArgb(60, 60, 120);
        public static readonly Color ButtonBorder = Color.FromArgb(110, 110, 170);
        public static readonly Color Accent = Color.FromArgb(230, 192, 93);   // the gold of the KSU logo
        public static readonly Color MutedText = Color.FromArgb(201, 203, 232);

        /// <summary>Dark grid with left-aligned text. Columns and data are not touched.</summary>
        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Page;           // removes the grey block under the rows
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Line;

            // Without this line Windows ignores the header colours below.
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 40;
            grid.RowTemplate.Height = 38;

            DataGridViewCellStyle header = grid.ColumnHeadersDefaultCellStyle;
            header.Alignment = DataGridViewContentAlignment.MiddleLeft;
            header.BackColor = TitleBar;
            header.ForeColor = Color.White;
            header.Font = new Font("Segoe UI Semibold", 10F);
            header.Padding = new Padding(10, 0, 10, 0);
            header.SelectionBackColor = TitleBar;   // stops the first header turning blue
            header.SelectionForeColor = Color.White;
            header.WrapMode = DataGridViewTriState.False;

            DataGridViewCellStyle cell = grid.DefaultCellStyle;
            cell.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cell.BackColor = Card;
            cell.ForeColor = Color.White;
            cell.Font = new Font("Segoe UI", 10F);
            cell.Padding = new Padding(10, 0, 10, 0);
            cell.SelectionBackColor = Selection;
            cell.SelectionForeColor = Color.White;

            grid.AlternatingRowsDefaultCellStyle.BackColor = CardAlternate;
        }

        /// <summary>Flat button that matches the dark panels. Text and click events stay.</summary>
        public static void StyleButton(Button button)
        {
            button.UseVisualStyleBackColor = false;
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Selection;
            button.ForeColor = Color.White;
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = ButtonBorder;
            button.FlatAppearance.MouseOverBackColor = TitleBar;
            button.FlatAppearance.MouseDownBackColor = TitleBar;
        }
    }
}
