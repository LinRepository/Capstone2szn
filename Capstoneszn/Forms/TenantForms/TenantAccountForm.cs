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
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.TenantForms
{
    /// <summary>
    /// NEW (Nov 12, 2026): the redesigned "View Details" - one tenant's full
    /// account. Replaces TenantBillingForm (kept in the project, no longer opened).
    ///
    ///   Header    name (middle initial), room, occupied since, contact, status
    ///   Cards     the SAME figures as the Billing Summary panel:
    ///               Rent Available Balance (rent only), Water owed,
    ///               Maintenance owed, Electricity of the room (paid to AKELCO),
    ///               Advance credit (rent + water)
    ///   Bills     every share the tenant was charged (Rent / Water / Maintenance),
    ///             labelled by BillKind, with paid, balance and status
    ///   Payments  every receipt that paid something for this tenant, showing
    ///             only this tenant's part; voided receipts struck through
    ///
    /// Read-only. Money is recorded in Bill Management and corrected by voiding.
    /// Every money rule follows BillingHelper:
    ///   - a voided allocation, or any allocation under a voided payment, never counts
    ///   - only shares from the CURRENT stay are owing; older unpaid shares were
    ///     settled by write-off at a move-out, so they show "Written off"
    /// </summary>
    public partial class TenantAccountForm : Form
    {
        private readonly int _tenantId;

        private const string All = "All";
        private const string StatusPaid = "Paid";
        private const string StatusUnpaid = "Unpaid";
        private const string StatusPartial = "Partially Paid";
        private const string StatusOverdue = "Overdue";
        private const string StatusWrittenOff = "Written off";
        private const string StatusVoided = "Voided";
        private const string StatusValid = "Valid";

        private DataTable _bills = new DataTable();
        private DataTable _payments = new DataTable();

        private Font? _strikeFont;   // voided payment rows

        public TenantAccountForm(int tenantId)
        {
            InitializeComponent();
            _tenantId = tenantId;
        }

        private static string Str(object? o) => Convert.ToString(o)?.Trim() ?? "";
        private static string Peso(decimal v) => "₱ " + v.ToString("N2");

        /* =================================================================
           LOAD
           ================================================================= */

        private void TenantAccountForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();

            cboBillCategory.Items.AddRange(new object[] { All, "Rent", "Water", "Maintenance" });
            cboBillStatus.Items.AddRange(new object[] { All, "Unpaid (any)", StatusOverdue, StatusPaid, StatusWrittenOff });
            cboPayCategory.Items.AddRange(new object[] { All, "Rent", "Water", "Maintenance" });

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                LoadHeader(conn);
                LoadBills(conn);        // before the cards: the cards use the overdue counts
                LoadCards(conn);
                LoadPayments(conn);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Could not load the tenant's account: " + ex.Message,
                    "Tenant Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Selecting index 0 applies the filters (they guard on empty tables).
            cboBillCategory.SelectedIndex = 0;
            cboBillStatus.SelectedIndex = 0;
            cboPayCategory.SelectedIndex = 0;

            ShowTab(bills: true);
        }

        /* =================================================================
           HEADER
           ================================================================= */

        private void LoadHeader(SqlConnection conn)
        {
            using var cmd = new SqlCommand(@"
                SELECT t.FirstName, t.MiddleName, t.LastName, t.ContactNumber,
                       cur.RoomNumber, cur.MoveInDate
                FROM   Tenants t
                OUTER APPLY (SELECT TOP 1 r.RoomNumber, tn.MoveInDate
                             FROM   Tenancies tn
                             JOIN   Rooms r ON r.RoomId = tn.RoomId
                             WHERE  tn.TenantId = t.TenantId AND tn.Status = 'Active') cur
                WHERE  t.TenantId = @tid;", conn);
            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;

            using SqlDataReader rd = cmd.ExecuteReader();
            if (!rd.Read())
            {
                lblTenantName.Text = "Tenant not found";
                lblTenantSub.Text = "";
                return;
            }

            string middle = Str(rd["MiddleName"]);
            // Middle initial for clarity (Nov 9 display rule).
            lblTenantName.Text = Str(rd["LastName"]) + ", " + Str(rd["FirstName"]) +
                                 (middle.Length > 0 ? " " + middle[0] + "." : "");

            string contact = Str(rd["ContactNumber"]);
            bool active = rd["RoomNumber"] != DBNull.Value;

            if (active)
            {
                lblTenantSub.Text = $"Room {Str(rd["RoomNumber"])}  ·  Occupied since " +
                                    $"{Convert.ToDateTime(rd["MoveInDate"]):MMM d, yyyy}  ·  {contact}";
                lblBadge.Text = "Active";
                lblBadge.BackColor = Color.FromArgb(46, 125, 50);
            }
            else
            {
                lblTenantSub.Text = $"Not currently renting  ·  {contact}";
                lblBadge.Text = "Moved out";
                lblBadge.BackColor = Color.FromArgb(110, 110, 130);
            }
        }

        /* =================================================================
           SUMMARY CARDS - same figures as the Billing Summary panel
           ================================================================= */

        private void LoadCards(SqlConnection conn)
        {
            decimal rentOwed = BillingHelper.GetTotalOutstanding(conn, _tenantId, "Rent");
            decimal waterOwed = BillingHelper.GetTotalOutstanding(conn, _tenantId, "Water");
            decimal maintOwed = BillingHelper.GetTotalOutstanding(conn, _tenantId, "Maintenance");
            decimal rentCredit = BillingHelper.GetAvailableCredit(conn, _tenantId, "Rent");
            decimal waterCredit = BillingHelper.GetAvailableCredit(conn, _tenantId, "Water");

            decimal electricity;
            using (var cmd = new SqlCommand(@"
                SELECT ISNULL(SUM(ec.Amount), 0)
                FROM   Tenancies tn
                JOIN   ElectricityAccounts ea ON ea.RoomId = tn.RoomId AND ea.IsArchived = 0
                JOIN   ElectricityCharges ec  ON ec.ElectricityAccountId = ea.ElectricityAccountId
                WHERE  tn.TenantId = @tid AND tn.Status = 'Active'
                  AND  ec.Status = 'Unpaid' AND ec.Amount IS NOT NULL;", conn))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                electricity = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            // Rent Available Balance - rent only (+ = paid ahead, - = behind)
            decimal rentBalance = rentCredit - rentOwed;
            lblCardRentValue.Text = (rentBalance < 0m ? "-₱ " : "₱ ") + Math.Abs(rentBalance).ToString("N2");
            lblCardRentValue.ForeColor = rentBalance < 0m ? Color.Salmon
                                       : rentBalance > 0m ? Color.PaleGreen : Color.White;

            // NEW (Nov 13): short note instead of the Designer's fixed text (was cut off)
            lblCardRentNote.Text = rentBalance > 0m ? "paid ahead · rent only"
                                 : rentBalance < 0m ? "behind on rent"
                                 : "settled · rent only";

            SetOwedCard(lblCardWaterValue, lblCardWaterNote, waterOwed, "Water");
            SetOwedCard(lblCardMaintValue, lblCardMaintNote, maintOwed, "Maintenance");

            lblCardElecValue.Text = Peso(electricity);
            lblCardElecValue.ForeColor = electricity > 0m ? Color.Salmon : Color.White;
            lblCardElecNote.Text = electricity > 0m ? "unpaid · pay AKELCO directly" : "no unpaid bill";

            decimal credit = rentCredit + waterCredit;
            lblCardCreditValue.Text = Peso(credit);
            lblCardCreditValue.ForeColor = credit > 0m ? Color.PaleGreen : Color.White;
            lblCardCreditNote.Text = credit > 0m ? "applied to the next bills" : "rent + water credit";
        }

        private void SetOwedCard(Label value, Label note, decimal owed, string category)
        {
            value.Text = Peso(owed);
            value.ForeColor = owed > 0m ? Color.Salmon : Color.White;

            int overdue = _bills.AsEnumerable().Count(r =>
                r.Field<string>("Category") == category && r.Field<string>("Status") == StatusOverdue);

            note.Text = owed <= 0m ? "no unpaid bills"
                      : overdue > 0 ? $"{overdue} bill{(overdue == 1 ? "" : "s")} overdue"
                      : "not yet due";
        }

        /* =================================================================
           BILLS
           ================================================================= */

        private void LoadBills(SqlConnection conn)
        {
            var dt = new DataTable();
            dt.Columns.Add("Period", typeof(string));
            dt.Columns.Add("Room", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("DueDate", typeof(DateTime));
            dt.Columns.Add("Share", typeof(decimal));
            dt.Columns.Add("Paid", typeof(decimal));
            dt.Columns.Add("Balance", typeof(decimal));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Category", typeof(string));   // filter only, not shown

            // Start of the current stay. Unpaid shares from BEFORE it were written
            // off at an earlier move-out (BillingHelper does not count them).
            DateTime? stayStart = null;
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 MoveInDate FROM Tenancies
                WHERE  TenantId = @tid AND Status = 'Active';", conn))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                object? v = cmd.ExecuteScalar();
                if (v != null && v != DBNull.Value) stayStart = Convert.ToDateTime(v).Date;
            }

            using (var cmd = new SqlCommand(@"
                SELECT b.BillCategory, b.BillKind, b.BillingPeriodStart, b.BillingPeriodEnd,
                       b.DueDate, b.Amount, bt.Share, r.RoomNumber, mi.IssueTitle,
                       (SELECT COUNT(*) FROM BillTenants c WHERE c.BillId = b.BillId) AS Heads,
                       ISNULL((SELECT SUM(a.Amount)
                               FROM   PaymentAllocations a
                               JOIN   Payments p ON p.PaymentId = a.PaymentId
                               WHERE  a.BillId = bt.BillId AND a.TenantId = bt.TenantId
                                 AND  a.IsVoided = 0 AND p.IsVoided = 0), 0) AS Paid
                FROM   BillTenants bt
                JOIN   Bills b ON b.BillId = bt.BillId
                JOIN   Rooms r ON r.RoomId = b.RoomId
                LEFT JOIN MaintenanceIssues mi ON mi.IssueId = b.MaintenanceIssueId
                WHERE  bt.TenantId = @tid
                  AND  b.BillCategory IN ('Rent', 'Water', 'Maintenance')   -- electricity is not billed here
                ORDER BY b.DueDate DESC, b.BillId DESC;", conn))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                using SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string cat = Str(rd["BillCategory"]);
                    string kind = Str(rd["BillKind"]);
                    DateTime start = Convert.ToDateTime(rd["BillingPeriodStart"]).Date;
                    DateTime end = Convert.ToDateTime(rd["BillingPeriodEnd"]).Date;
                    DateTime due = Convert.ToDateTime(rd["DueDate"]).Date;
                    decimal share = Convert.ToDecimal(rd["Share"]);
                    decimal paid = Convert.ToDecimal(rd["Paid"]);
                    decimal balance = Math.Max(0m, share - paid);

                    // Stored end = the next period's first day; show the last covered day.
                    // A one-day bill (maintenance, joiner/gap bills) shows one date.
                    string period = end > start
                        ? $"{start:MMM d} – {end.AddDays(-1):MMM d, yyyy}"
                        : $"{start:MMM d, yyyy}";

                    string status;
                    bool writtenOff = balance > 0m &&
                        (kind == "Superseded" || !stayStart.HasValue || start < stayStart.Value);

                    if (balance <= 0m) status = StatusPaid;
                    else if (writtenOff) { status = StatusWrittenOff; balance = 0m; }
                    else if (DateTime.Today > due) status = StatusOverdue;   // overdue the day after the due date
                    else if (paid > 0m) status = StatusPartial;
                    else status = StatusUnpaid;

                    dt.Rows.Add(period, Str(rd["RoomNumber"]),
                        Describe(cat, kind, start, Convert.ToDecimal(rd["Amount"]),
                                 Convert.ToInt32(rd["Heads"]), Str(rd["IssueTitle"])),
                        due, share, paid, balance, status, cat);
                }
            }

            _bills = dt;
            dgvBills.DataSource = _bills.DefaultView;
            ApplyBillFilter();
        }

        /// <summary>What a bill is, in words a tenant understands (BillKind-aware).</summary>
        // OLD: private static string Describe(
        // NEW (Nov 12): internal so the tenant statement (TenantsControl) uses the same wording.
        internal static string Describe(string category, string kind, DateTime start,
                                       decimal roomTotal, int heads, string issueTitle)
        {
            if (category == "Water") return $"Water – {start:MMMM yyyy}";
            if (category == "Maintenance") return "Maintenance – " + (issueTitle.Length > 0 ? issueTitle : "repair");

            return kind switch
            {
                "TransferGap" => "Rent – vacated share (a roommate left)",
                "JoinerShare" => "Rent – joiner share",
                "PriceDifference" => "Rent – transfer price difference",
                "Superseded" => "Rent – issued before move-out",
                _ => heads > 1 ? $"Rent (₱{roomTotal:N2} ÷ {heads})" : "Rent"   // Regular / Closed
            };
        }

        private void BillFilter_Changed(object? sender, EventArgs e) => ApplyBillFilter();

        private void ApplyBillFilter()
        {
            if (_bills.Columns.Count == 0) return;

            var parts = new List<string>();

            string cat = cboBillCategory.SelectedItem as string ?? All;
            if (cat != All) parts.Add($"Category = '{cat}'");

            string st = cboBillStatus.SelectedItem as string ?? All;
            if (st == "Unpaid (any)") parts.Add("Balance > 0");
            else if (st != All) parts.Add($"Status = '{st}'");

            _bills.DefaultView.RowFilter = string.Join(" AND ", parts);

            var rows = _bills.DefaultView.Cast<DataRowView>().ToList();
            lblBillsCount.Text = $"{rows.Count} bill{(rows.Count == 1 ? "" : "s")}";
            lblBillsTotal.Text =
                $"Total   Your share {Peso(rows.Sum(r => (decimal)r["Share"]))}     " +
                $"Paid {Peso(rows.Sum(r => (decimal)r["Paid"]))}     " +
                $"Balance {Peso(rows.Sum(r => (decimal)r["Balance"]))}";
        }

        private void dgvBills_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvBills.Columns[e.ColumnIndex].Name;

            if (col == colBillStatus.Name && e.Value is string status)
            {
                e.CellStyle!.ForeColor = status switch
                {
                    StatusPaid => Color.PaleGreen,
                    StatusOverdue => Color.Salmon,
                    StatusPartial => Color.Orange,
                    StatusWrittenOff => Color.Gray,
                    _ => Color.White
                };
            }
        }

        /* =================================================================
           PAYMENTS
           ================================================================= */

        private void LoadPayments(SqlConnection conn)
        {
            var dt = new DataTable();
            dt.Columns.Add("PaymentDate", typeof(DateTime));
            dt.Columns.Add("ReceiptNo", typeof(string));
            dt.Columns.Add("Categories", typeof(string));
            dt.Columns.Add("Method", typeof(string));
            dt.Columns.Add("PaidBy", typeof(string));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("VoidReason", typeof(string));   // tooltip only

            // One row per receipt that paid anything for this tenant. Amount is
            // ONLY this tenant's part (a Whole Room receipt shows their share of it).
            // For a voided receipt, the part it had paid is shown, struck through.
            using (var cmd = new SqlCommand(@"
                SELECT p.PaymentId, p.PaymentDate, p.ReceiptNo, p.PaymentMethod, p.IsVoided,
                       p.VoidReason, p.CoversRoom, p.TenantId AS PayerId,
                       payer.FirstName + ' ' + payer.LastName AS PayerName,
                       SUM(CASE WHEN p.IsVoided = 1 OR a.IsVoided = 0 THEN a.Amount ELSE 0 END) AS TenantPart,
                       (SELECT STRING_AGG(c.Category, ', ')
                        FROM (SELECT DISTINCT a2.Category FROM PaymentAllocations a2
                              WHERE a2.PaymentId = p.PaymentId AND a2.TenantId = @tid) c) AS Categories
                FROM   PaymentAllocations a
                JOIN   Payments p     ON p.PaymentId    = a.PaymentId
                JOIN   Tenants  payer ON payer.TenantId = p.TenantId
                WHERE  a.TenantId = @tid
                GROUP BY p.PaymentId, p.PaymentDate, p.ReceiptNo, p.PaymentMethod, p.IsVoided,
                         p.VoidReason, p.CoversRoom, p.TenantId, payer.FirstName, payer.LastName
                ORDER BY p.PaymentDate DESC, p.PaymentId DESC;", conn))
            {
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                using SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    decimal part = Convert.ToDecimal(rd["TenantPart"]);
                    if (part <= 0m) continue;   // nothing of this tenant's left on it

                    bool voided = Convert.ToBoolean(rd["IsVoided"]);
                    bool wholeRoom = Convert.ToBoolean(rd["CoversRoom"]);
                    string payer = Str(rd["PayerName"]);

                    dt.Rows.Add(
                        Convert.ToDateTime(rd["PaymentDate"]),
                        Str(rd["ReceiptNo"]),
                        Str(rd["Categories"]),
                        Str(rd["PaymentMethod"]),
                        wholeRoom ? payer + " (Whole Room)" : payer,
                        part,
                        voided ? StatusVoided : StatusValid,
                        Str(rd["VoidReason"]));
                }
            }

            _payments = dt;
            dgvPayments.DataSource = _payments.DefaultView;
            ApplyPayFilter();
        }

        private void PayFilter_Changed(object? sender, EventArgs e) => ApplyPayFilter();

        private void ApplyPayFilter()
        {
            if (_payments.Columns.Count == 0) return;

            string cat = cboPayCategory.SelectedItem as string ?? All;
            _payments.DefaultView.RowFilter = cat == All ? "" : $"Categories LIKE '%{cat}%'";

            var rows = _payments.DefaultView.Cast<DataRowView>().ToList();
            int voided = rows.Count(r => (string)r["Status"] == StatusVoided);
            decimal valid = rows.Where(r => (string)r["Status"] == StatusValid).Sum(r => (decimal)r["Amount"]);

            lblPayCount.Text = $"{rows.Count} receipt{(rows.Count == 1 ? "" : "s")}" +
                               (voided > 0 ? $" · {voided} voided (not counted)" : "");
            lblPayTotal.Text = $"Total received (valid only)   {Peso(valid)}";
        }

        private void dgvPayments_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvPayments.Rows[e.RowIndex].DataBoundItem is not DataRowView row) return;

            bool voided = (string)row["Status"] == StatusVoided;
            string col = dgvPayments.Columns[e.ColumnIndex].Name;

            if (voided)
            {
                _strikeFont ??= new Font(dgvPayments.DefaultCellStyle.Font ?? Font, FontStyle.Strikeout);
                e.CellStyle!.Font = _strikeFont;
                e.CellStyle.ForeColor = Color.Gray;
                dgvPayments.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText =
                    "Voided: " + Str(row["VoidReason"]);
            }
            else if (col == colPayStatus.Name)
            {
                e.CellStyle!.ForeColor = Color.PaleGreen;
            }
        }

        /* =================================================================
           TABS, THEME, CLOSE
           ================================================================= */

        private void btnTabBills_Click(object sender, EventArgs e) => ShowTab(bills: true);
        private void btnTabPayments_Click(object sender, EventArgs e) => ShowTab(bills: false);

        private void ShowTab(bool bills)
        {
            pnlBills.Visible = bills;
            pnlPayments.Visible = !bills;

            StyleTab(btnTabBills, bills);
            StyleTab(btnTabPayments, !bills);
        }

        private static void StyleTab(Button tab, bool active)
        {
            tab.BackColor = active ? UiTheme.Card : UiTheme.Page;
            tab.ForeColor = active ? UiTheme.Accent : UiTheme.MutedText;
            tab.FlatAppearance.BorderColor = active ? UiTheme.ButtonBorder : UiTheme.Line;
        }

        private void ApplyTheme()
        {
            BackColor = UiTheme.Page;

            UiTheme.StyleGrid(dgvBills);
            UiTheme.StyleGrid(dgvPayments);
            dgvBills.BackgroundColor = UiTheme.Card;
            dgvPayments.BackgroundColor = UiTheme.Card;

            UiTheme.StyleButton(btnTabBills);
            UiTheme.StyleButton(btnTabPayments);
            UiTheme.StyleButton(btnClose);

            // Dates and money
            colBillDue.DefaultCellStyle.Format = "MMM d, yyyy";
            colPayDate.DefaultCellStyle.Format = "MMM d, yyyy";
            foreach (DataGridViewColumn c in new DataGridViewColumn[]
                     { colBillShare, colBillPaid, colBillBalance, colPayAmount })
            {
                c.DefaultCellStyle.Format = "₱#,##0.00";
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvBills.AutoGenerateColumns = false;
            dgvPayments.AutoGenerateColumns = false;

            

        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _strikeFont?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
