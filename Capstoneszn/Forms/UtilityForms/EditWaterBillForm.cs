using Capstoneszn.Forms.UserControls.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UtilityForms
{
    public partial class EditWaterBillForm : Form
    {
        private readonly DateTime _monthStart;
        private int _waterBillId;
        private List<PreviewRow> _tenants = new List<PreviewRow>();
        private decimal _perTenant;
        private decimal _adminAmount;
        private bool _updating;

        public EditWaterBillForm() : this(DateTime.Today) { }
        public EditWaterBillForm(DateTime BillingMonth)
        {
            _monthStart = new DateTime(BillingMonth.Year, BillingMonth.Month, 1);
            InitializeComponent();

            dtpStartBillingPeriod.Value = _monthStart;   // locked month (disabled in designer)
            dtpDueDate.MinDate = _monthStart;

            txtTotalBill.KeyPress += WaterBillHelper.MoneyKeyPress;
            txtAdminShare.KeyPress += WaterBillHelper.MoneyKeyPress;

            txtTotalBill.TextChanged += (s, e) => Recalculate();
            txtAdminShare.TextChanged += (s, e) => Recalculate();
            rdoDefaultShare.CheckedChanged += (s, e) => Recalculate();
            rdoCustomAmount.CheckedChanged += (s, e) => Recalculate();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // ── Validation ──
            if (!decimal.TryParse(txtTotalBill.Text.Trim(), out decimal total) || total <= 0)
            {
                Warn("Enter a valid total bill amount.");
                txtTotalBill.Focus();
                return;
            }
            if (total != Math.Round(total, 2))
            {
                Warn("Enter the total to at most two decimal places (centavos).");
                txtTotalBill.Focus();
                return;
            }
            if (_tenants.Count == 0)
            {
                Warn($"There are no active tenants for {_monthStart:MMMM yyyy} to split the bill with.");
                return;
            }

            bool isDefault = rdoDefaultShare.Checked;
            if (!isDefault)
            {
                if (!decimal.TryParse(txtAdminShare.Text.Trim(), out decimal custom) || custom < 0)
                {
                    Warn("Enter a valid amount for the owner's share.");
                    txtAdminShare.Focus();
                    return;
                }
                if (custom >= total)
                {
                    Warn("The owner's share must be less than the total bill.");
                    txtAdminShare.Focus();
                    return;
                }
            }
            if (_perTenant <= 0)
            {
                Warn("Each tenant's share would be ₱0.00. Lower the owner's share or raise the total.");
                return;
            }
            if (dtpDueDate.Value.Date < _monthStart)
            {
                Warn("The due date can't be before the billing month.");
                return;
            }

            if (MessageBox.Show(
                    $"Update the {_monthStart:MMMM yyyy} water bill?\n\n" +
                    $"Total:       {total:₱#,##0.00}\n" +
                    $"Per tenant:  {_perTenant:₱#,##0.00} × {_tenants.Count}\n" +
                    $"Owner:       {_adminAmount:₱#,##0.00}\n" +
                    $"Due:         {dtpDueDate.Value:MMM d, yyyy}\n\n" +
                    "The tenants' shares will be replaced with these amounts.",
                    "Confirm update", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            // ── Save ──
            // Returning before Commit() rolls back automatically when 'tran' is disposed.
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using SqlTransaction tran = conn.BeginTransaction();

                // Re-check the locks inside the transaction
                string status;
                using (var cmd = new SqlCommand(@"
                    SELECT AdminStatus FROM dbo.WaterBills WITH (UPDLOCK, HOLDLOCK)
                    WHERE  WaterBillId = @Id;", conn, tran))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _waterBillId;
                    status = cmd.ExecuteScalar() as string ?? "";
                }
                if (status != "Unpaid" || WaterBillHelper.HasTenantPayments(conn, tran, _monthStart))
                {
                    Warn("This bill was paid while you were editing, so it's now locked. Nothing was changed.");
                    DialogResult = DialogResult.Cancel;
                    return;
                }

                // The tenant list must still match the preview
                var current = WaterBillHelper.LoadActiveTenants(conn, tran, _monthStart);
                if (current.Count != _tenants.Count)
                {
                    Warn("The tenant list changed while you were editing. Close this window and try again.");
                    return;
                }
                foreach (var t in current) t.Amount = _perTenant;

                // Replace the tenant shares
                WaterBillHelper.DeleteTenantBills(conn, tran, _monthStart);
                WaterBillHelper.InsertTenantBills(conn, tran, _monthStart, dtpDueDate.Value.Date, current);

                // NEW: same update. The bill keeps the account it was recorded under;
                // a legacy bill with no account is linked to the building's current one.
                WaterAccountInfo? activeAccount =
                    WaterAccountHelper.GetActive(conn, tran, Session.BuildingId, lockRow: false);

                using (var cmd = new SqlCommand(@"
                    UPDATE dbo.WaterBills
                       SET DueDate        = @Due,
                           TotalAmount    = @Total,
                           AdminShareMode = @Mode,
                           AdminAmount    = @Admin,
                           WaterAccountId = COALESCE(WaterAccountId, @ActiveAccountId)
                     WHERE WaterBillId = @Id;", conn, tran))
                {
                    cmd.Parameters.Add("@Due", SqlDbType.Date).Value = dtpDueDate.Value.Date;
                    WaterBillHelper.AddMoney(cmd, "@Total", total);
                    cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 10).Value = isDefault ? "Default" : "Custom";
                    WaterBillHelper.AddMoney(cmd, "@Admin", _adminAmount);
                    cmd.Parameters.Add("@ActiveAccountId", SqlDbType.Int).Value =
                        (object?)activeAccount?.WaterAccountId ?? DBNull.Value;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _waterBillId;
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();

                MessageBox.Show("Water bill updated.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error updating bill: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditWaterBillForm_Load(object sender, EventArgs e)
        {
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                // The month's header row
                string mode = "Default";
                decimal total = 0m, savedAdmin = 0m;
                string adminStatus = "Unpaid";

                using (var cmd = new SqlCommand(@"
                    SELECT WaterBillId, DueDate, TotalAmount, AdminShareMode, AdminAmount, AdminStatus
                    FROM   dbo.WaterBills
                    WHERE  BuildingId = @BuildingId AND BillingMonth = @MonthStart;", conn))
                {
                    cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                    cmd.Parameters.Add("@MonthStart", SqlDbType.Date).Value = _monthStart;

                    using SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        MessageBox.Show($"There's no water bill for {_monthStart:MMMM yyyy}. Add one first.",
                            "Edit Bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.Cancel;
                        return;
                    }

                    _waterBillId = dr.GetInt32(0);
                    DateTime due = dr.GetDateTime(1);
                    total = dr.GetDecimal(2);
                    mode = dr.GetString(3);
                    savedAdmin = dr.GetDecimal(4);
                    adminStatus = dr.GetString(5);

                    dtpDueDate.Value = due < _monthStart ? _monthStart : due;
                }

                // Locks: owner already paid, or any tenant money (payment or applied credit) on the bill
                if (adminStatus == "Paid")
                {
                    ShowLocked("the owner's share has already been recorded as paid");
                    return;
                }
                if (WaterBillHelper.HasTenantPayments(conn, null, _monthStart))
                {
                    ShowLocked("a tenant has already paid toward it");
                    return;
                }

                _tenants = WaterBillHelper.LoadActiveTenants(conn, null, _monthStart);
                lblActiveTenantCount.Text = _tenants.Count.ToString();

                // Fill the form with what's saved
                _updating = true;
                txtTotalBill.Text = total.ToString("0.00");
                if (mode == "Custom")
                {
                    rdoCustomAmount.Checked = true;
                    txtAdminShare.Text = savedAdmin.ToString("0.00");
                }
                else
                {
                    rdoDefaultShare.Checked = true;
                }
                _updating = false;

                Recalculate();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading bill: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void ShowLocked(string reason)
        {
            MessageBox.Show(
                $"The {_monthStart:MMMM yyyy} water bill can't be edited because {reason}.\n\n" +
                "Bills with payments are locked so the records stay correct.",
                "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.Cancel;
        }
        private void Recalculate()
        {
            if (_updating) return;
            _updating = true;
            try
            {
                decimal.TryParse(txtTotalBill.Text.Trim(), out decimal total);
                bool isDefault = rdoDefaultShare.Checked;

                txtAdminShare.ReadOnly = isDefault;

                decimal custom = 0m;
                if (!isDefault) decimal.TryParse(txtAdminShare.Text.Trim(), out custom);

                (_perTenant, _adminAmount) =
                    WaterBillHelper.Calculate(total, _tenants.Count, isDefault, custom);

                foreach (var t in _tenants) t.Amount = _perTenant;

                if (isDefault)
                    txtAdminShare.Text = total > 0 ? _adminAmount.ToString("0.00") : "";

                WaterBillHelper.FillPreviewGrid(dgvWaterPreview, _tenants, _adminAmount);
            }
            finally
            {
                _updating = false;
            }
        }
        private static void Warn(string msg) =>
            MessageBox.Show(msg, "Edit Bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
