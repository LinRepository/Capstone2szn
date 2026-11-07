using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.PaymentsForms;
using Microsoft.Data.SqlClient;


namespace Capstoneszn.Forms.RoomsForms
{
    /// <summary>
    /// NEW (transfer price difference): collects the difference before a
    /// transfer is saved. Opened by TransferForm only when someone's share
    /// goes up and their advance credit does not cover it.
    ///
    ///   1. One Payer Card per payer with something due (the same card as
    ///      Move-In Payment): at least the amount due, Cash or GCash.
    ///   2. Continue -> GCash checks -> Confirm (C1 table)
    ///      -> TransferService.Save: transfer + difference bill + credit +
    ///         receipts, ONE transaction.
    ///   3. Transfer Complete (the Move-In Complete screen, retitled).
    ///
    /// DialogResult:  OK = saved,  Cancel = Back,  Abort = data changed,
    /// TransferForm reloads its lists.
    /// </summary>
    public partial class TransferPaymentForm : Form
    {
        private readonly TransferPlan _plan;
        private readonly List<PayerCardControl> _cards = new List<PayerCardControl>();
        private bool _building;

        /// <summary>Needed by the Visual Studio designer only.</summary>
        public TransferPaymentForm()
        {
            InitializeComponent();
        }

        public TransferPaymentForm(TransferPlan plan) : this()
        {
            _plan = plan ?? throw new ArgumentNullException(nameof(plan));
        }

        private void TransferPaymentForm_Load(object sender, EventArgs e)
        {
            if (_plan == null) return;   // designer

            lblDescription.Text = $"Room {_plan.SourceRoomNumber} → Room {_plan.DestRoomNumber} · Rent difference · {DateTime.Today:MMM d, yyyy}";

            int people = _plan.Movers.Count + _plan.DependentCount;
            lblSummaryBody.Text =
                $"From              Room {_plan.SourceRoomNumber}\n" +
                $"To                  Room {_plan.DestRoomNumber}\n" +
                $"Moving           {people} ({_plan.Movers.Count} paying)\n" +
                $"Difference      {Peso(_plan.TotalDifference)}\n" +
                $"Credit used     − {Peso(_plan.TotalCredit)}\n" +
                $"New price from {(_plan.FirstBill.HasValue ? _plan.FirstBill.Value.ToString("MMM d, yyyy") : "-")}";

            BuildCards();
        }

        /// <summary>One card per payer with an amount due (the rest just move).</summary>
        private void BuildCards()
        {
            _building = true;
            flpCards.SuspendLayout();

            foreach (TransferMover m in _plan.Movers.Where(x => x.Due > 0m))
            {
                var card = new PayerCardControl();
                int key = _plan.Movers.IndexOf(m);

                // Title carries the breakdown: "Usopp Test - difference ₱6,000.00, credit −₱1,000.00"
                string title = m.Name + " - difference " + Peso(m.Difference) +
                               (m.CreditUsed > 0m ? ", credit −" + Peso(m.CreditUsed) : "");
                card.SetPayer(key, title, "Amount due", m.Due);
                card.Width = flpCards.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 6;
                card.PaymentChanged += (s, e) => { if (!_building) Recalculate(); };

                flpCards.Controls.Add(card);
                _cards.Add(card);
            }

            flpCards.ResumeLayout();
            _building = false;

            Recalculate();
            if (_cards.Count > 0) _cards[0].FocusAmount();
        }

        private TransferMover MoverOf(PayerCardControl card) => _plan.Movers[card.PayerKey];

        /// <summary>Re-checks every card: below due = red, exact = Full, more = Advance (Rent credit).</summary>
        private bool Recalculate()
        {
            decimal total = 0m;
            string problem = null;

            foreach (PayerCardControl card in _cards)
            {
                decimal? paid = card.AmountPaid;
                decimal due = card.AmountDue;
                string periods = TransferService.Breakdown(MoverOf(card)).Replace("\n", "; ");

                if (paid == null || paid.Value <= 0m)
                {
                    card.ShowResult("Enter amount", Color.Firebrick, periods, "");
                    problem = problem ?? "Enter the amount paid by " + MoverOf(card).Name + ".";
                    continue;
                }

                total += paid.Value;

                if (paid.Value < due)
                {
                    card.ShowResult("Below due", Color.Firebrick, "Short by " + Peso(due - paid.Value), "");
                    problem = problem ?? MoverOf(card).Name + " must pay at least " + Peso(due) + ".";
                    continue;
                }

                bool full = paid.Value == due;
                card.ShowResult(full ? "Full" : "Advance",
                    full ? Color.SeaGreen : Color.RoyalBlue,
                    periods,
                    full ? "No credit" : "Credit " + Peso(paid.Value - due));
            }

            lblTotalDue.Text = Peso(_plan.TotalDue);
            int n = _cards.Count;
            lblReceiptsLine.Text = n == 1 ? "1 payment · 1 receipt" : n + " payments · " + n + " receipts";

            bool ok = problem == null;
            lblStatus.Text = problem ?? (total > _plan.TotalDue ? "Ready. The extra becomes advance credit." : "Ready to continue.");
            lblStatus.ForeColor = ok ? Color.FromArgb(111, 224, 160) : Color.Tomato;
            btnContinue.Enabled = ok;
            return ok;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (!Recalculate())
            {
                Warn(lblStatus.Text);
                _cards.FirstOrDefault(c => c.AmountPaid == null || c.AmountPaid < c.AmountDue)?.FocusAmount();
                return;
            }

            if (!CheckReferences()) return;

            // Put the cards into the plan - this is what TransferService saves.
            foreach (PayerCardControl card in _cards)
            {
                TransferMover m = MoverOf(card);
                m.AmountPaid = card.AmountPaid ?? 0m;
                m.Method = card.Method;
                m.ReferenceNo = card.Method == MoveInService.GCash ? card.ReferenceNo : "";
            }

            using (var confirm = new ConfirmPaymentForm(BuildConfirmInfo()))
            {
                if (confirm.ShowDialog(this) != DialogResult.OK) return;
            }

            TransferResult result;
            btnContinue.Enabled = false;   // one click = one save

            try
            {
                result = TransferService.Save(_plan);
            }
            catch (InvalidOperationException ex)
            {
                // A rule said no (a bill or payment changed, room full, reference used...). Nothing was saved.
                Warn(ex.Message + "\n\nNothing was changed.");
                this.DialogResult = DialogResult.Abort;   // TransferForm reloads
                this.Close();
                return;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show("The transfer failed and nothing was changed.\n\n" + ex.Message,
                    "Transfer Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Recalculate();
                return;
            }

            ShowComplete(this, _plan, result);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>The Move-In Complete screen, retitled for a transfer. Also used by TransferForm.</summary>
        internal static void ShowComplete(IWin32Window owner, TransferPlan plan, TransferResult result)
        {
            using (var done = new MoveInCompleteForm(plan.DestRoomNumber, result.PayingCount, result.DependentCount,
                                                     DateTime.Today, result.FirstBill ?? DateTime.Today, result.Receipts))
            {
                done.ShowAsTransfer(plan.SourceRoomNumber, plan.DestRoomNumber,
                                    result.PayingCount, result.DependentCount, result.FirstBill);
                done.ShowDialog(owner);
            }
        }

        /// <summary>13 digits, no two payers with the same one, not used before.</summary>
        private bool CheckReferences()
        {
            var references = new List<string>();

            foreach (PayerCardControl card in _cards.Where(c => c.Method == MoveInService.GCash))
            {
                string reference = card.ReferenceNo;

                if (!MoveInService.IsValidGCashReference(reference))
                {
                    Warn("GCash reference number for " + MoverOf(card).Name + " must be exactly 13 digits.");
                    card.FocusReference();
                    return false;
                }
                if (references.Contains(reference))
                {
                    Warn("Two payers have the same GCash reference number. Each GCash payment has its own.");
                    card.FocusReference();
                    return false;
                }
                references.Add(reference);

                try
                {
                    using (SqlConnection conn = DatabaseHelper.GetConnection())
                    // ORIGINAL: using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Payments WHERE ReferenceNo = @ref;", conn))
                    // NEW (PAY-01): a voided receipt no longer reserves its GCash reference
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Payments WHERE ReferenceNo = @ref AND IsVoided = 0;", conn))
                    {
                        cmd.Parameters.Add("@ref", SqlDbType.NVarChar, 100).Value = reference;
                        conn.Open();
                        if ((int)cmd.ExecuteScalar() > 0)
                        {
                            Warn("GCash reference " + reference + " was already recorded in an earlier payment.");
                            card.FocusReference();
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // A failed check must not block; the database still refuses a duplicate.
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }

            return true;
        }

        /// <summary>What the C1 confirm screen shows.</summary>
        private ConfirmMoveInInfo BuildConfirmInfo()
        {
            var info = new ConfirmMoveInInfo
            {
                Date = DateTime.Today,
                RoomNumber = _plan.SourceRoomNumber + " → " + _plan.DestRoomNumber,
                PaidAs = "Transfer difference",
                Occupants = (_plan.Movers.Count + _plan.DependentCount) + " moving (" + _plan.Movers.Count + " paying)",
                Share = Peso(_plan.TotalDifference) + (_plan.TotalCredit > 0m ? " (credit −" + Peso(_plan.TotalCredit) + ")" : ""),
                CreditedTo = "Full difference, no proration. New price from the " +
                             (_plan.FirstBill.HasValue ? _plan.FirstBill.Value.ToString("MMM d") : "next") + " bill.",
                Dependents = _plan.DependentCount > 0
                    ? "Moving with their head: " + string.Join(", ", _plan.Movers.SelectMany(m => m.Dependents))
                    : "",
                ReceiptsLine = lblReceiptsLine.Text
            };

            foreach (PayerCardControl card in _cards)
            {
                TransferMover m = MoverOf(card);
                decimal paid = card.AmountPaid ?? 0m;

                info.Rows.Add(new ConfirmMoveInRow
                {
                    Payer = m.Name,
                    Type = paid == m.Due ? "Full" : "Advance",
                    Method = card.Method,
                    Reference = card.Method == MoveInService.GCash ? card.ReferenceNo : "—",
                    Covers = _plan.FirstBill.HasValue ? "Until " + _plan.FirstBill.Value.ToString("MMM d, yyyy") : "-",
                    Amount = paid
                });
                info.Total += paid;
            }

            return info;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Warn(string message)
        {
            MessageBox.Show(message, "Transfer Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static string Peso(decimal v) => "₱" + v.ToString("N2");
    }
}
