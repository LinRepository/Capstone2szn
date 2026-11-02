using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Utilities
{
    /// <summary>
    /// One place for the Utilities status colors (Paid / Unpaid / Overdue / No bill),
    /// used by the Water and Electricity grids and both admin cards.
    /// Display only: the database still stores 'Paid' / 'Unpaid'; "Overdue" is computed on screen.
    /// </summary>
    internal static class UtilityStatusStyle
    {
        public static readonly Color PaidFore = Color.FromArgb(30, 123, 52);      // #1E7B34
        public static readonly Color PaidBack = Color.FromArgb(230, 244, 234);    // #E6F4EA
        public static readonly Color UnpaidFore = Color.FromArgb(178, 106, 0);    // #B26A00
        public static readonly Color UnpaidBack = Color.FromArgb(255, 244, 224);  // #FFF4E0
        public static readonly Color OverdueFore = Color.FromArgb(198, 40, 40);   // #C62828
        public static readonly Color OverdueBack = Color.FromArgb(253, 231, 233); // #FDE7E9
        public static readonly Color NeutralFore = Color.FromArgb(107, 114, 128); // #6B7280

        private enum Kind { Paid, Unpaid, Overdue, Neutral }

        private static Kind KindOf(string? status)
        {
            string s = (status ?? "").Trim();
            if (s.StartsWith("Paid", StringComparison.OrdinalIgnoreCase)) return Kind.Paid;   // also "Paid (Nov 1, 2026)"
            if (s.Equals("Overdue", StringComparison.OrdinalIgnoreCase)) return Kind.Overdue;
            if (s.Equals("Unpaid", StringComparison.OrdinalIgnoreCase)) return Kind.Unpaid;
            return Kind.Neutral;                                                              // "No bill", "—", "No share"
        }

        /// <summary>Colors a grid cell (call from CellFormatting).</summary>
        public static void ApplyToCell(DataGridViewCellStyle style, string? status, Font baseFont)
        {
            switch (KindOf(status))
            {
                case Kind.Paid:
                    Set(style, PaidFore, PaidBack, baseFont, bold: false);
                    break;
                case Kind.Unpaid:
                    Set(style, UnpaidFore, UnpaidBack, baseFont, bold: false);
                    break;
                case Kind.Overdue:
                    Set(style, OverdueFore, OverdueBack, baseFont, bold: true);
                    break;
                default:
                    style.ForeColor = NeutralFore;
                    style.SelectionForeColor = NeutralFore;
                    break;
            }
        }

        /// <summary>Colors an admin-card status label (text color + bold for Overdue).</summary>
        public static void ApplyToLabel(Label label)
        {
            Kind kind = KindOf(label.Text);
            label.ForeColor = kind switch
            {
                Kind.Paid => PaidFore,
                Kind.Unpaid => UnpaidFore,
                Kind.Overdue => OverdueFore,
                _ => NeutralFore
            };
            label.Font = new Font(label.Font, kind == Kind.Overdue ? FontStyle.Bold : FontStyle.Regular);
        }

        private static void Set(DataGridViewCellStyle style, Color fore, Color back, Font baseFont, bool bold)
        {
            style.ForeColor = fore;
            style.BackColor = back;
            // keep the color visible even when the row is selected
            style.SelectionForeColor = fore;
            style.SelectionBackColor = back;
            if (bold) style.Font = new Font(baseFont, FontStyle.Bold);
        }
    }
}
