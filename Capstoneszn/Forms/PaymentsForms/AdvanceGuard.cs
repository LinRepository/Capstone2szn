using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.PaymentsForms
{
    /// <summary>
    /// NEW (Step 6): the 3-month advance warning, shared by the three payment
    /// screens (Move-In Payment, Make Payment, Transfer Payment).
    ///
    /// Only the ADVANCE counts: the money paid beyond what is owed today.
    /// If it is more than 3 months of the payer's rent, the screen asks once
    /// "Is this amount correct?". Yes saves, No goes back to the amount.
    ///
    ///   share 2,000, owes 2,000, pays  8,000 -> advance 6,000 = 3 months -> no warning
    ///   share 2,000, owes 2,000, pays 10,000 -> advance 8,000 = 4 months -> warning
    ///
    /// It never blocks a payment: an honest advance is allowed, the warning
    /// only catches a typo (an extra zero).
    /// </summary>
    public static class AdvanceGuard
    {
        /// <summary>More advance than this many months of rent gets the warning.</summary>
        public const int MaxMonths = 3;

        /// <summary>
        /// True = go on (no warning needed, or the user answered Yes).
        /// False = the user answered No; the screen should go back to the amount.
        /// </summary>
        /// <param name="advance">Money paid beyond what is owed today.</param>
        /// <param name="monthly">The payer's rent for one month (0 = unknown, no warning).</param>
        public static bool Confirm(IWin32Window owner, string payerName, decimal advance, decimal monthly)
        {
            if (advance <= 0m || monthly <= 0m) return true;
            if (advance <= monthly * MaxMonths) return true;

            decimal months = Math.Round(advance / monthly, 1);   // decimal: no overflow on a huge typo

            string message =
                payerName + " is paying ₱" + advance.ToString("N2") + " in advance, about " +
                months.ToString("0.#") + " months of rent." + Environment.NewLine + Environment.NewLine +
                "Is this amount correct?";

            return MessageBox.Show(owner, message, "Check Amount",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                       MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
    }
}
