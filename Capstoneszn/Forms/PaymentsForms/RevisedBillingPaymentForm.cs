using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.PaymentsForms
{
    /// <summary>
    /// Billing v2 payment form: ONE payment (one receipt) that can cover
    /// Rent, Water and Maintenance together.
    ///
    ///   Individual - the payer pays their own balances.
    ///   Whole Room - the payer pays for everyone: Rent follows the existing
    ///                split rule; Water must be the room's full balance;
    ///                Maintenance is not allowed (each affected tenant pays).
    ///
    /// Type follows the amount (never picked by hand):
    ///   amount == owed -> Full,  amount < owed -> Partial,
    ///   amount >  owed -> Advance (Rent only; Water is capped).
    /// </summary>
    public partial class RevisedBillingPaymentForm : Form
    {
        private const string Rent = "Rent";
        private const string Water = "Water";
        private const string Maintenance = BillingHelper.MaintenanceCategory;
        private const decimal MaxAmount = 999999.99m;

        private readonly int _roomId;
        private readonly int _preselectedTenantId;

        // What is owed right now, for the current mode.
        private decimal _rentOwed, _waterOwed, _maintOwed;

        // True while the form fills itself, so change events don't run early.
        private bool _loading;

        /// <summary>Needed by the Visual Studio designer only.</summary>
        public RevisedBillingPaymentForm()
        {
            InitializeComponent();
        }
        public RevisedBillingPaymentForm(int roomId, int tenantId) : this()
        {
            _roomId = roomId;
            _preselectedTenantId = tenantId;

            // Wired here, NOT in the designer, so each fires once.
            // (rbWholeRoom_CheckedChanged and Load are already wired in the designer.)
            cboPayer.SelectedIndexChanged += (s, e) => ReloadOwed();
            txtRentPay.TextChanged += (s, e) => UpdateTotals();
            txtWaterPay.TextChanged += (s, e) => UpdateTotals();
            rbGcash.CheckedChanged += (s, e) =>
            {
                txtRefNo.Enabled = rbGcash.Checked;
                if (!rbGcash.Checked) txtRefNo.Clear();
            };
        }

        private void rbWholeRoom_CheckedChanged(object sender, EventArgs e)
        {
            // Fires when Whole Room is ticked AND unticked, so it covers both modes.
            ReloadOwed();
        }
        /// <summary>
        /// Individual: the payer's own balances.
        /// Whole Room: the total of every active tenant in the room.
        /// Resets the rows, because the old amounts no longer apply.
        /// </summary>
        private void ReloadOwed()
        {
            if (_loading || !(cboPayer.SelectedValue is int payerId)) return;

            bool wholeRoom = rbWholeRoom.Checked;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    if (wholeRoom)
                    {
                        _rentOwed = BillingHelper.GetRoomOwing(conn, _roomId, Rent).Sum(x => x.Value);
                        _waterOwed = BillingHelper.GetRoomOwing(conn, _roomId, Water).Sum(x => x.Value);
                        _maintOwed = 0m;   // never Whole Room
                    }
                    else
                    {
                        _rentOwed = BillingHelper.GetTotalOutstanding(conn, payerId, Rent);
                        _waterOwed = BillingHelper.GetTotalOutstanding(conn, payerId, Water);
                        _maintOwed = BillingHelper.GetTotalOutstanding(conn, payerId, Maintenance);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load the balances.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblRentBill.Text = _rentOwed.ToString("N2");
            lblWaterBill.Text = _waterOwed.ToString("N2");
            lblMaintenanceBill.Text = wholeRoom ? "Each pays own" : _maintOwed.ToString("N2");

            _loading = true;   // resetting rows must not trigger recalculation midway

            FillCreditTo(payerId, wholeRoom);   // NEW (credit choice)

            chkAll.Checked = false;

            chkRent.Checked = false;
            chkRent.Enabled = true;                  // always: rent can be paid in advance
            txtRentPay.Text = "";
            txtRentPay.Enabled = false;

            chkWater.Checked = false;
            chkWater.Enabled = _waterOwed > 0m;      // nothing owed -> nothing to pay (capped)
            txtWaterPay.Text = "";
            txtWaterPay.Enabled = false;

            chkMaintenance.Checked = false;
            chkMaintenance.Enabled = !wholeRoom && _maintOwed > 0m;
            lblMaintenancePay.Text = "-";

            _loading = false;
            UpdateTotals();
        }

        private void RevisedBillingPaymentForm_Load(object sender, EventArgs e)
        {
            _loading = true;

            // Payments are dated today only (decided) - shown, never edited.
            dtpPaymentDate.CustomFormat = "MMMM d, yyyy";
            dtpPaymentDate.Value = DateTime.Today;

            // Typed text must be visible on the dark background.
            txtRentPay.ForeColor = Color.White;
            txtWaterPay.ForeColor = Color.White;

            cboPayer.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadPayers();

            rbIndividual.Checked = true;
            rbCash.Checked = true;
            txtRefNo.Enabled = false;

            _loading = false;
            ReloadOwed();
        }
        /// <summary>The room's active paying tenants (dependents are not payers).</summary>
        private void LoadPayers()
        {
            const string sql = @"
                SELECT t.TenantId, t.FirstName + ' ' + t.LastName AS TenantName
                FROM   Tenancies tn
                JOIN   Tenants t ON t.TenantId = tn.TenantId
                WHERE  tn.RoomId = @rid
                  AND  tn.Status = 'Active'
                ORDER BY tn.MoveInDate ASC, t.LastName ASC, t.FirstName ASC;";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) da.Fill(dt);

                    cboPayer.DisplayMember = "TenantName";
                    cboPayer.ValueMember = "TenantId";
                    cboPayer.DataSource = dt;
                    cboPayer.SelectedValue = _preselectedTenantId;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load the tenants of this room.", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (!(cboPayer.SelectedValue is int payerId))
            {
                Warn("Choose who is paying.");
                return;
            }

            bool wholeRoom = rbWholeRoom.Checked;
            var lines = new List<PaymentLine>();

            // ---- 1. Build the lines, validating each ----------------------
            if (chkRent.Checked)
            {
                if (!TryAmount(txtRentPay, "Rent", out decimal amount)) return;
                lines.Add(new PaymentLine(Rent, amount, TypeFor(amount, _rentOwed)));
            }

            // ORIGINAL: if (chkWater.Checked)
            // ORIGINAL: {
            // ORIGINAL:     if (!TryAmount(txtWaterPay, "Water", out decimal amount)) return;
            // ORIGINAL:     if (amount > _waterOwed) { Warn(...); txtWaterPay.Focus(); return; }
            // ORIGINAL:     lines.Add(new PaymentLine(Water, amount, TypeFor(amount, _waterOwed)));
            // ORIGINAL: }

            // NEW: water is paid in full only - the exact amount owed, typed Full.
            if (chkWater.Checked)
                lines.Add(new PaymentLine(Water, _waterOwed, "Full"));

            if (chkMaintenance.Checked)
                lines.Add(new PaymentLine(Maintenance, _maintOwed, "Full"));

            if (lines.Count == 0)
            {
                Warn("Tick at least one category to pay.");
                return;
            }

            // ---- 2. Method --------------------------------------------------
            string method = rbGcash.Checked ? "GCash" : "Cash";
            string refNo = null;

            if (method == "GCash")
            {
                refNo = txtRefNo.Text.Trim();
                if (refNo.Length != 13 || !refNo.All(char.IsDigit))
                {
                    Warn("The GCash reference number must be exactly 13 digits.");
                    txtRefNo.Focus();
                    return;
                }
            }

            decimal total = lines.Sum(l => l.Amount);

            // NEW (credit choice): Whole Room rent above what the room owes = extra.
            // null = split equally (also when only one tenant lives here).
            decimal rentPaid = lines.Where(l => l.Category == Rent).Sum(l => l.Amount);
            decimal extra = wholeRoom ? rentPaid - _rentOwed : 0m;
            int? extraTo = null;
            string extraText = "";
            if (extra > 0m && cboCreditTo.Visible && cboCreditTo.SelectedItem is CreditChoice choice)
            {
                extraTo = choice.TenantId;
                extraText = $"Extra ₱{extra:N2} credited to: " + (choice.TenantId.HasValue ? choice.Text : "split equally");
            }

            // ---- 3. Confirm --------------------------------------------------
            var sb = new StringBuilder();
            sb.AppendLine("Payer: " + cboPayer.Text + (wholeRoom ? "  (Whole Room)" : ""));
            sb.AppendLine();
            foreach (PaymentLine l in lines)
                sb.AppendLine($"{l.Category}: ₱{l.Amount:N2}  ({l.PaymentType})");
            sb.AppendLine();
            sb.AppendLine($"Total: ₱{total:N2}    Method: {method}" + (refNo != null ? "  Ref: " + refNo : ""));
            if (extraText.Length > 0) sb.AppendLine(extraText);   // NEW (credit choice)
            sb.AppendLine();
            sb.AppendLine("This will update the tenant's account. Save this payment?");

            if (MessageBox.Show(sb.ToString(), "Confirm Payment",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // ---- 4. Save: header + lines in ONE transaction ----------------
            btnContinue.Enabled = false;   // no double-click double payment

            try
            {
                string receiptNo = "R" + DateTime.Now.ToString("yyyyMMddHHmmss");

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // ORIGINAL: BillingHelper.RecordReceipt(conn, tx, _roomId, payerId, wholeRoom,
                            // ORIGINAL:     lines, method, refNo, DateTime.Today, Session.UserId, receiptNo);
                            BillingHelper.RecordReceipt(conn, tx, _roomId, payerId, wholeRoom,
                                lines, method, refNo, DateTime.Today, Session.UserId, receiptNo,
                                extraTo);   // NEW (credit choice)
                            tx.Commit();
                        }
                        catch
                        {
                            try { tx.Rollback(); } catch { /* keep the original error */ }
                            throw;
                        }
                    }
                }

                MessageBox.Show("Payment saved.\nReceipt No. " + receiptNo, "Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;   // the room screen reloads
                Close();
            }
            catch (InvalidOperationException ex)
            {
                Warn(ex.Message);   // a billing rule said no
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                Warn("This GCash reference number has already been used. Please check it.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("The payment could not be saved. Nothing was recorded.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed) btnContinue.Enabled = true;
            }
        }

        /* =================================================================
           NEW (credit choice): Whole Room - who gets the EXTRA rent
           (money left after the whole room's rent is settled).
           Default = the payer, because it is their money.
           ================================================================= */

        /// <summary>One item of "Extra credit to". TenantId null = split equally.</summary>
        private sealed class CreditChoice
        {
            public int? TenantId;
            public string Text = "";
            public override string ToString() => Text;
        }

        /// <summary>"Split equally" + every tenant in the room; starts on the payer.</summary>
        private void FillCreditTo(int payerId, bool wholeRoom)
        {
            cboCreditTo.Items.Clear();
            cboCreditTo.Items.Add(new CreditChoice { TenantId = null, Text = "Split equally" });

            int tenants = 0;
            if (cboPayer.DataSource is DataTable dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var item = new CreditChoice
                    {
                        TenantId = Convert.ToInt32(row["TenantId"]),
                        Text = Convert.ToString(row["TenantName"]) ?? ""
                    };
                    cboCreditTo.Items.Add(item);
                    if (item.TenantId == payerId) cboCreditTo.SelectedItem = item;   // default: the payer
                    tenants++;
                }
            }
            if (cboCreditTo.SelectedIndex < 0) cboCreditTo.SelectedIndex = 0;

            // A choice only exists in Whole Room with 2+ tenants.
            bool show = wholeRoom && tenants > 1;
            lblCreditTo.Visible = show;
            cboCreditTo.Visible = show;
            cboCreditTo.Enabled = false;   // UpdateTotals enables it once there is extra money
        }

        /* =================================================================
           HELPERS
           ================================================================= */

        private bool TryAmount(TextBox box, string name, out decimal amount)
        {
            string text = box.Text.Trim();

            if (!decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out amount)
                || amount <= 0m)
            {
                Warn($"Enter a valid {name} amount greater than 0.");
                box.Focus();
                return false;
            }
            if (decimal.Round(amount, 2) != amount)
            {
                Warn($"{name} amount can have at most 2 decimal places.");
                box.Focus();
                return false;
            }
            if (amount > MaxAmount)
            {
                Warn($"{name} amount is too large.");
                box.Focus();
                return false;
            }
            return true;
        }

        private static decimal Parse(string text)
        {
            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal v) ? v : 0m;
        }

        /// <summary>Digits and one decimal point only.</summary>
        private static void MoneyKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && sender is TextBox tb && !tb.Text.Contains('.')) return;
            e.Handled = true;
        }

        private static void Warn(string message)
        {
            MessageBox.Show(message, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rbCash.Checked = true;
            txtRefNo.Clear();
            ReloadOwed();   // unticks every row and clears the amounts
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            // Only rows that can be paid are ticked.
            if (chkRent.Enabled) chkRent.Checked = chkAll.Checked;
            if (chkWater.Enabled) chkWater.Checked = chkAll.Checked;
            if (chkMaintenance.Enabled) chkMaintenance.Checked = chkAll.Checked;
        }

        private void chkRent_CheckedChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            txtRentPay.Enabled = chkRent.Checked;
            txtRentPay.Text = chkRent.Checked && _rentOwed > 0m ? _rentOwed.ToString("0.00") : "";
            if (chkRent.Checked) txtRentPay.Focus();
            UpdateTotals();
        }

        private void chkWater_CheckedChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            txtWaterPay.Enabled = chkWater.Checked;
            txtWaterPay.Text = chkWater.Checked ? _waterOwed.ToString("0.00") : "";
            // ORIGINAL: // Whole Room water must be the full room balance, so it cannot be edited.
            // ORIGINAL: txtWaterPay.ReadOnly = rbWholeRoom.Checked;
            // NEW: water is paid in full only (exact amount), in both Individual and Whole Room.
            txtWaterPay.ReadOnly = true;
            UpdateTotals();
        }

        private void chkMaintenance_CheckedChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            // Maintenance is Full only: the amount is fixed to what is owed.
            lblMaintenancePay.Text = chkMaintenance.Checked ? _maintOwed.ToString("N2") : "-";
            UpdateTotals();
        }
        /// <summary>Recomputes every row's Type and the Totals row.</summary>
        private void UpdateTotals()
        {
            if (_loading) return;

            decimal owed = 0m, pay = 0m;

            decimal rentAmount = Parse(txtRentPay.Text);
            // ORIGINAL: decimal waterAmount = Parse(txtWaterPay.Text);
            decimal waterAmount = _waterOwed;   // NEW: water is always the exact amount owed

            if (chkRent.Checked) { owed += _rentOwed; pay += rentAmount; }
            if (chkWater.Checked) { owed += _waterOwed; pay += waterAmount; }
            if (chkMaintenance.Checked) { owed += _maintOwed; pay += _maintOwed; }

            lblRentType.Text = chkRent.Checked ? TypeFor(rentAmount, _rentOwed) : "-";
            // ORIGINAL: lblWaterType.Text = !chkWater.Checked ? "-"
            // ORIGINAL:                   : waterAmount > _waterOwed ? "Too much"
            // ORIGINAL:                   : TypeFor(waterAmount, _waterOwed);
            lblWaterType.Text = chkWater.Checked ? "Full" : "-";   // NEW: full payment only
            lblMaintenanceType.Text = chkMaintenance.Checked ? "Full" : "-";

            lblWaterType.ForeColor = lblWaterType.Text == "Too much" ? Color.Tomato : Color.White;

            lblTotalOwed.Text = owed.ToString("N2");
            lblTotalAmountToPay.Text = pay.ToString("N2");

            // NEW (credit choice): only matters when Whole Room rent is MORE than the room owes.
            cboCreditTo.Enabled = rbWholeRoom.Checked && chkRent.Checked && rentAmount > _rentOwed;
        }
        /// <summary>Full / Partial / Advance, decided by the amount.</summary>
        private static string TypeFor(decimal amount, decimal owed)
        {
            if (amount <= 0m) return "-";
            if (owed <= 0m || amount > owed) return "Advance";
            return amount == owed ? "Full" : "Partial";
        }

    }
}
