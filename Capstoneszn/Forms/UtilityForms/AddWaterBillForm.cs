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
    public partial class AddWaterBillForm : Form
    {
        private readonly DateTime _billingMonth;
        private List<PreviewRow> _previewRows = new();
        private int _activeTenantCount;
        private decimal _totalAmount;
        private decimal _adminAmount;
        private decimal _perTenantAmount;
        private bool _updating;   // stops code-driven text changes from re-triggering the preview
        public AddWaterBillForm(DateTime billingMonth)
        {
            InitializeComponent();

            _billingMonth = new DateTime(billingMonth.Year, billingMonth.Month, 1);

            txtTotalAmount.TextChanged += (s, e) => { if (!_updating) RecalculatePreview(); };
            txtAdminShare.TextChanged += (s, e) => { if (!_updating) RecalculatePreview(); };
            rdoDefaultShare.CheckedChanged += AdminMode_CheckedChanged;
            rdoCustomAmount.CheckedChanged += AdminMode_CheckedChanged;
            txtTotalAmount.KeyPress += WaterBillHelper.MoneyKeyPress;
            txtAdminShare.KeyPress += WaterBillHelper.MoneyKeyPress;
        }
        private void AddWaterBillForm_Load(object sender, EventArgs e)
        {
            dtpBillingMonth.Value = _billingMonth;   // month comes from the Utilities tab
            dtpBillingMonth.Enabled = false;
            dtpDueDate.MinDate = _billingMonth;
            dtpDueDate.Value = DateTime.Today;

            rdoDefaultShare.Checked = true;
            LoadActiveTenants();
            RecalculatePreview();
        }
        private void LoadActiveTenants()
        {
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                _previewRows = WaterBillHelper.LoadActiveTenants(conn, null, _billingMonth);
            }
            catch (SqlException ex)
            {
                _previewRows = new();
                MessageBox.Show("Unable to load tenants.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _activeTenantCount = _previewRows.Count;
            lblActiveTenantCount.Text = _activeTenantCount.ToString();
        }

        private void AdminMode_CheckedChanged(object? sender, EventArgs e)
        {
            if (_updating) return;
            if (sender is RadioButton rb && !rb.Checked) return;   // fires for both radios; react once

            bool custom = rdoCustomAmount.Checked;
            txtAdminShare.ReadOnly = !custom;

            if (custom)
            {
                _updating = true;
                txtAdminShare.Clear();
                _updating = false;
                txtAdminShare.Focus();
            }
            RecalculatePreview();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void RecalculatePreview()
        {
            decimal.TryParse(txtTotalAmount.Text.Trim(), out _totalAmount);

            decimal custom = 0m;
            if (rdoCustomAmount.Checked)
                decimal.TryParse(txtAdminShare.Text.Trim(), out custom);

            (_perTenantAmount, _adminAmount) = WaterBillHelper.Calculate(
                _totalAmount, _activeTenantCount, rdoDefaultShare.Checked, custom);

            foreach (var r in _previewRows) r.Amount = _perTenantAmount;

            if (rdoDefaultShare.Checked)   // default mode: the box just shows the computed share
            {
                _updating = true;
                txtAdminShare.Text = _adminAmount.ToString("0.00");
                _updating = false;
            }

            BindPreviewGrid();
        }
        private void BindPreviewGrid() =>
            WaterBillHelper.FillPreviewGrid(dgvWaterPreview, _previewRows, _adminAmount);

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            if (!TrySaveWaterBill()) return;
            DialogResult = DialogResult.OK;
            Close();
        }
        private bool TrySaveWaterBill()
        {
            RecalculatePreview();   // save exactly what the preview shows

            // ── Validation ──
            if (_totalAmount <= 0)
            {
                Warn("Enter a valid total bill amount.");
                txtTotalAmount.Focus();
                return false;
            }
            if (_activeTenantCount == 0)
            {
                Warn($"There are no active tenants for {_billingMonth:MMMM yyyy}, so there's no one to split the bill with.");
                return false;
            }
            if (rdoCustomAmount.Checked)
            {
                if (!decimal.TryParse(txtAdminShare.Text.Trim(), out decimal custom) || custom < 0)
                {
                    Warn("Enter a valid custom amount for the owner.");
                    txtAdminShare.Focus();
                    return false;
                }
                if (custom >= _totalAmount)
                {
                    Warn("The owner's custom amount must be less than the total bill.");
                    txtAdminShare.Focus();
                    return false;
                }
            }
            if (_perTenantAmount <= 0)
            {
                Warn("Each tenant's share comes out to ₱0.00. Check the total or lower the owner's amount.");
                return false;
            }

            var confirm = MessageBox.Show(
                $"Save the {_billingMonth:MMMM yyyy} water bill?\n\n" +
                $"Total: ₱{_totalAmount:#,##0.00}\n" +
                $"{_activeTenantCount} tenant(s) × ₱{_perTenantAmount:#,##0.00}\n" +
                $"Owner: ₱{_adminAmount:#,##0.00}",
                "Confirm bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return false;

            // ── Save: header + tenant bills in one transaction ──
            // Returning before Commit() rolls back automatically when 'tran' is disposed.
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using SqlTransaction tran = conn.BeginTransaction();

                using (var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.WaterBills WHERE BuildingId = @BuildingId AND BillingMonth = @Month;",
                    conn, tran))
                {
                    cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                    cmd.Parameters.Add("@Month", SqlDbType.Date).Value = _billingMonth;
                    if ((int)cmd.ExecuteScalar() > 0)
                    {
                        Warn($"{_billingMonth:MMMM yyyy} already has a water bill. Use Edit Bill instead.");
                        return false;
                    }
                }

                using (var cmd = new SqlCommand(@"
                    INSERT INTO dbo.WaterBills
                        (BuildingId, BillingMonth, DueDate, TotalAmount, AdminShareMode, AdminAmount, AdminStatus, RecordedBy)
                    VALUES
                        (@BuildingId, @Month, @Due, @Total, @Mode, @AdminAmount, 'Unpaid', @RecordedBy);", conn, tran))
                {
                    cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;
                    cmd.Parameters.Add("@Month", SqlDbType.Date).Value = _billingMonth;
                    cmd.Parameters.Add("@Due", SqlDbType.Date).Value = dtpDueDate.Value.Date;
                    cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 10).Value = rdoDefaultShare.Checked ? "Default" : "Custom";
                    cmd.Parameters.Add("@RecordedBy", SqlDbType.Int).Value = Session.UserId;
                    WaterBillHelper.AddMoney(cmd, "@Total", _totalAmount);
                    WaterBillHelper.AddMoney(cmd, "@AdminAmount", _adminAmount);
                    cmd.ExecuteNonQuery();
                }

                WaterBillHelper.InsertTenantBills(conn, tran, _billingMonth, dtpDueDate.Value.Date, _previewRows);

                tran.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error saving bill: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static void Warn(string msg) =>
            MessageBox.Show(msg, "Add Bill", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}