using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.UtilityForms
{
    public partial class AddOtherForm : Form
    {
        private const int MaxNameLength = 100;              // NVARCHAR(100)
        private const decimal MaxAmount = 99_999_999.99m;   // DECIMAL(10,2)
        private sealed class ChargeLine
        {
            public int? TenantId;
            public string? OutsiderName;
            public string DisplayName = "";
            public decimal Amount;
        }
        private readonly List<ChargeLine> lines = new();
        public AddOtherForm()
        {
            InitializeComponent();

            rbTenant.CheckedChanged += ChargeTo_CheckedChanged;
            rbOutsider.CheckedChanged += ChargeTo_CheckedChanged;
            txtAmount.KeyPress += txtAmount_KeyPress;

        }
        private void AddOtherForm_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = MaxNameLength;
            txtOutsiderName.MaxLength = MaxNameLength;
            cbTenant.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpChargeDate.MaxDate = DateTime.Today.AddDays(1).AddSeconds(-1);
            dtpChargeDate.Value = DateTime.Today;

            LoadTenants();
            LoadChargeNameSuggestions();
            UpdateTotal();
        }
        private void LoadTenants()
        {
            const string sql = @"
                SELECT  t.TenantId,
                        t.FirstName + ' ' + t.LastName AS FullName,
                        t.FirstName + ' ' + t.LastName + ' - Room ' + r.RoomNumber AS DisplayName
                FROM Tenants t
                INNER JOIN Rooms  r ON r.RoomId  = t.RoomId
                INNER JOIN Floors f ON f.FloorId = r.FloorId
                WHERE t.Status = 'Active'
                  AND t.IsArchived = 0
                  AND f.BuildingId = @bId
                ORDER BY t.FirstName, t.LastName;";

            var dt = new DataTable();
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@bId", SqlDbType.Int).Value = Session.BuildingId;
                using var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load tenants.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cbTenant.DisplayMember = "DisplayName";
            cbTenant.ValueMember = "TenantId";
            cbTenant.DataSource = dt;
            cbTenant.SelectedIndex = -1;

            if (dt.Rows.Count == 0)
            {
                rbTenant.Enabled = false;
                rbOutsider.Checked = true;
            }
            else
            {
                rbTenant.Checked = true;
            }
            ChargeTo_CheckedChanged(null, EventArgs.Empty);
        }
        private void LoadChargeNameSuggestions()
        {
            var names = new AutoCompleteStringCollection();
            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();
                using var cmd = new SqlCommand(
                    "SELECT DISTINCT ChargeName FROM OtherCharges WHERE BuildingId = @bId;", conn);
                cmd.Parameters.Add("@bId", SqlDbType.Int).Value = Session.BuildingId;
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) names.Add(reader.GetString(0));
            }
            catch (Exception)
            {
                // Suggestions are optional; the form still works without them.
            }

            textBox1.AutoCompleteCustomSource = names;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void ChargeTo_CheckedChanged(object? sender, EventArgs e)
        {
            bool isTenant = rbTenant.Checked;
            label4.Visible = isTenant;
            cbTenant.Visible = isTenant;
            label8.Visible = !isTenant;
            txtOutsiderName.Visible = !isTenant;
        }

        private void txtAmount_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && !txtAmount.Text.Contains('.')) return;
            e.Handled = true;
        }
        private void btnAddtoList_Click(object sender, EventArgs e)
        {
            if (!rbTenant.Checked && !rbOutsider.Checked)
            {
                Warn("Choose whether this is for a tenant or an outsider.");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
            {
                Warn("Enter an amount greater than zero.");
                txtAmount.Focus();
                return;
            }
            if (amount != Math.Round(amount, 2))
            {
                Warn("The amount can have at most 2 decimal places.");
                txtAmount.Focus();
                return;
            }
            if (amount > MaxAmount)
            {
                Warn("That amount is too large.");
                txtAmount.Focus();
                return;
            }

            ChargeLine line;

            if (rbTenant.Checked)
            {
                if (cbTenant.SelectedItem is not DataRowView row)
                {
                    Warn("Choose a tenant.");
                    cbTenant.Focus();
                    return;
                }
                int tenantId = (int)row["TenantId"];
                if (lines.Any(l => l.TenantId == tenantId))
                {
                    Warn("That tenant is already in the list.");
                    return;
                }
                line = new ChargeLine
                {
                    TenantId = tenantId,
                    DisplayName = (string)row["FullName"],
                    Amount = amount
                };
            }
            else
            {
                string name = txtOutsiderName.Text.Trim();
                if (name.Length == 0)
                {
                    Warn("Enter the outsider's name.");
                    txtOutsiderName.Focus();
                    return;
                }
                if (lines.Any(l => string.Equals(l.OutsiderName, name,
                        StringComparison.OrdinalIgnoreCase)))
                {
                    Warn("That name is already in the list.");
                    return;
                }
                line = new ChargeLine
                {
                    OutsiderName = name,
                    DisplayName = name,
                    Amount = amount
                };
            }

            lines.Add(line);
            int rowIndex = dgvCharges.Rows.Add(
                line.TenantId.HasValue ? "Tenant" : "Outsider",
                line.DisplayName,
                line.Amount);
            dgvCharges.Rows[rowIndex].Tag = line;
            dgvCharges.ClearSelection();

            txtAmount.Clear();
            txtOutsiderName.Clear();
            cbTenant.SelectedIndex = -1;
            UpdateTotal();
        }
        private void dgvCharges_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colRemove.Index) return;

            var row = dgvCharges.Rows[e.RowIndex];
            if (row.Tag is ChargeLine line) lines.Remove(line);
            dgvCharges.Rows.RemoveAt(e.RowIndex);
            UpdateTotal();
        }
        private void UpdateTotal()
        {
            lblTotalAmount.Text = lines.Sum(l => l.Amount).ToString("#,##0.00");
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string chargeName = textBox1.Text.Trim();
            if (chargeName.Length == 0)
            {
                Warn("Enter the utility name.");
                textBox1.Focus();
                return;
            }
            if (lines.Count == 0)
            {
                Warn("Add at least one person to the list.");
                return;
            }
            if (txtAmount.Text.Trim().Length > 0 &&
                MessageBox.Show("There's an amount that wasn't added to the list. Save without it?",
                    "Unadded entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            const string sql = @"
                INSERT INTO OtherCharges (BuildingId, ChargeName, ChargeDate, TenantID, OutsiderName, Amount)
                VALUES (@bId, @ChargeName, @ChargeDate, @TenantID, @OutsiderName, @Amount);";

            using SqlConnection conn = DatabaseHelper.GetConnection();
            try
            {
                conn.Open();
                using var tx = conn.BeginTransaction();
                try
                {
                    foreach (var line in lines)
                    {
                        using var cmd = new SqlCommand(sql, conn, tx);
                        cmd.Parameters.Add("@bId", SqlDbType.Int).Value = Session.BuildingId;
                        cmd.Parameters.Add("@ChargeName", SqlDbType.NVarChar, MaxNameLength).Value = chargeName;
                        cmd.Parameters.Add("@ChargeDate", SqlDbType.Date).Value = dtpChargeDate.Value.Date;
                        cmd.Parameters.Add("@TenantID", SqlDbType.Int).Value =
                            (object?)line.TenantId ?? DBNull.Value;
                        cmd.Parameters.Add("@OutsiderName", SqlDbType.NVarChar, MaxNameLength).Value =
                            (object?)line.OutsiderName ?? DBNull.Value;
                        var p = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                        p.Precision = 10; p.Scale = 2; p.Value = line.Amount;
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save the charges.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Charges saved.", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lines.Count > 0 &&
                MessageBox.Show("Discard the charges in the list?", "Cancel",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private static void Warn(string message)
        {
            MessageBox.Show(message, "Check the form",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
    