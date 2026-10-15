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
using Capstoneszn.Forms.TenantForms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// The current tenants of the selected building, with each one's
    /// details and billing position.
    ///
    /// "Current" means an Active tenancy. A tenant who moved out has no
    /// active tenancy, so they leave this list on their own - that IS the
    /// archive. No flag on Tenants is needed for it, and none is read here.
    /// </summary>
    /// 

    public partial class TenantsControl : UserControl
    {
        /// <summary>
        /// Every category the ledger knows. All are summed into Available
        /// Balance even where the panel has no row of its own, so money
        /// recorded under any of them is never left out of the total.
        /// </summary>
        /// 

        private static readonly string[] Categories =
            { "Rent", "Maintenance", "Water", "Electricity", "Other" };

        private DataTable _tenants = new DataTable();
        private int _selectedTenantId = -1;

        public TenantsControl()
        {
            InitializeComponent();

            // Map grid columns to the SQL result
            dgvTenants.AutoGenerateColumns = false;
            colRoom.DataPropertyName = "RoomNumber";
            colFname.DataPropertyName = "FirstName";
            colMname.DataPropertyName = "MiddleName";
            colLname.DataPropertyName = "LastName";
            colAddress.DataPropertyName = "Address";
            colContactNumber.DataPropertyName = "ContactNumber";
            colDateOccupied.DataPropertyName = "MoveInDate";
            colDateOccupied.DefaultCellStyle.Format = "MMM d, yyyy";

            dgvTenants.ReadOnly = true;
            dgvTenants.AllowUserToAddRows = false;
            dgvTenants.RowHeadersVisible = false;
            dgvTenants.MultiSelect = false;
            dgvTenants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Wire events
            dgvTenants.SelectionChanged += dgvTenants_SelectionChanged;

            pnlTenantDetails.Visible = false;   // nothing selected yet
            LoadTenants();
        }

        public void LoadTenants()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // No t.IsArchived check: an Active tenancy already means
                    // "currently renting", and whether Tenants still has that
                    // column at all is unsettled. Relying on the tenancy keeps
                    // this list correct either way.
                    string sql = @"
                        SELECT t.TenantId, r.RoomNumber, t.FirstName, t.MiddleName,
                               t.LastName, t.Address, t.ContactNumber, tn.MoveInDate
                        FROM   Tenants t
                        INNER JOIN Tenancies tn ON tn.TenantId = t.TenantId
                        INNER JOIN Rooms r      ON r.RoomId    = tn.RoomId
                        WHERE  r.BuildingId = @BuildingId
                          AND  tn.Status    = 'Active'
                        ORDER BY t.LastName, t.FirstName;";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@BuildingId", SqlDbType.Int).Value = Session.BuildingId;

                        _tenants = new DataTable();
                        using (var da = new SqlDataAdapter(cmd))
                            da.Fill(_tenants);
                    }

                    dgvTenants.DataSource = _tenants;
                    dgvTenants.ClearSelection();
                }
                catch (Exception ex)
                {
                    // Keep the reason visible while the system is being
                    // tested - "Unable to load" alone gives nothing to fix.
                    Debug.WriteLine(ex);
                    MessageBox.Show("Unable to load tenants: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void TenantsControl_Load(object sender, EventArgs e)
        {

        }

        private void btnEditTenant_Click(object sender, EventArgs e)
        {
            if (_selectedTenantId <= 0)
            {
                MessageBox.Show("Please select a tenant first.", "No Tenant Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (EditTenant edit = new EditTenant(_selectedTenantId))
            {
                if (edit.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    int keepId = _selectedTenantId;
                    LoadTenants();
                    Reselect(keepId);
                }
            }
        }

        private void btnCloseTenantDetails_Click(object sender, EventArgs e)
        {
            pnlTenantDetails.Visible = false;
            _selectedTenantId = -1;
            dgvTenants.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_tenants == null) return;

            string term = EscapeFilter(txtSearch.Text.Trim());

            _tenants.DefaultView.RowFilter = term.Length == 0
                ? ""
                : $"FirstName LIKE '%{term}%' OR LastName LIKE '%{term}%' " +
                  $"OR MiddleName LIKE '%{term}%' OR RoomNumber LIKE '%{term}%' " +
                  $"OR ContactNumber LIKE '%{term}%'";

            pnlTenantDetails.Visible = false;   // old selection no longer valid
            _selectedTenantId = -1;
        }

        // RowFilter treats [ ] * % as pattern characters. Without escaping,
        // typing a single "[" throws a SyntaxErrorException.
        private static string EscapeFilter(string s)
        {
            return (s ?? string.Empty)
                .Replace("[", "[[]")   // must come first
                .Replace("%", "[%]")
                .Replace("*", "[*]")
                .Replace("'", "''");
        }

        private void dgvTenants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTenants_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTenants.CurrentRow == null || dgvTenants.CurrentRow.Index < 0)
            {
                pnlTenantDetails.Visible = false;
                _selectedTenantId = -1;
                return;
            }

            DataRowView row = dgvTenants.CurrentRow.DataBoundItem as DataRowView;
            if (row == null) return;

            _selectedTenantId = Convert.ToInt32(row["TenantId"]);
            ShowDetails(row);
        }

        private void ShowDetails(DataRowView row)
        {
            lblRoomValue.Text = Val(row["RoomNumber"]);
            lblFirstNameValue.Text = Val(row["FirstName"]);
            lblMiddleNameValue.Text = Val(row["MiddleName"]);
            lblLastNameValue.Text = Val(row["LastName"]);
            lblAddressValue.Text = Val(row["Address"]);
            lblContactNumberValue.Text = Val(row["ContactNumber"]);

            lblDateOccupiedValue.Text = row["MoveInDate"] == DBNull.Value
                ? "-"
                : Convert.ToDateTime(row["MoveInDate"]).ToString("MMMM d, yyyy");

            LoadTenantBillingSummary(_selectedTenantId);

            pnlTenantDetails.Visible = true;
        }

        private static string Val(object o)
        {
            if (o == null || o == DBNull.Value) return "-";
            string s = o.ToString().Trim();
            return s.Length == 0 ? "-" : s;
        }

        private void Reselect(int tenantId)
        {
            foreach (DataGridViewRow gridRow in dgvTenants.Rows)
            {
                DataRowView row = gridRow.DataBoundItem as DataRowView;
                if (row != null && Convert.ToInt32(row["TenantId"]) == tenantId)
                {
                    gridRow.Selected = true;
                    dgvTenants.CurrentCell = gridRow.Cells[0];
                    return;
                }
            }
        }

        /* =================================================================
           BILLING SUMMARY

           Each category row shows what the tenant still OWES in it -
           ₱ 0.00 means nothing owed, not "no data". Available Balance is
           the net position: credit paid ahead minus everything owed,
           across all categories. Positive = paid ahead, negative = owing.

           Every figure comes from BillingHelper - the same queries the
           payment engine allocates against - so this panel, the payment
           form and Bill Management can never disagree.
           ================================================================= */

        private void LoadTenantBillingSummary(int tenantId)
        {

            var owed = new Dictionary<string, decimal>();
            decimal net = 0m;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    foreach (string cat in Categories)
                    {
                        decimal outstanding = BillingHelper.GetTotalOutstanding(conn, tenantId, cat);
                        decimal credit = BillingHelper.GetAvailableCredit(conn, tenantId, cat);

                        owed[cat] = outstanding;
                        net += credit - outstanding;
                    }
                }
            }
            catch (Exception ex)
            {
                // Never show 0.00 when the real figure is unknown - that
                // would read as "owes nothing".
                Debug.WriteLine(ex);
                foreach (Label l in new[] { lblRentBillValue, lblMaintenanceBillValue,
                                            lblWaterBillValue, lblElectricityBillValue,
                                            lblUtilitiesBillValue, lblAvailableBalanceValue })
                {
                    l.Text = "-";
                    l.ForeColor = Color.White;
                }
                return;
            }

            ShowOwed(lblRentBillValue, owed["Rent"]);
            ShowOwed(lblMaintenanceBillValue, owed["Maintenance"]);
            ShowOwed(lblWaterBillValue, owed["Water"]);
            ShowOwed(lblElectricityBillValue, owed["Electricity"]);

            // The Utilities row is Water + Electricity together.
            ShowOwed(lblUtilitiesBillValue, owed["Water"] + owed["Electricity"]);

            lblAvailableBalanceValue.Text =
                (net < 0m ? "-₱ " : "₱ ") + Math.Abs(net).ToString("N2");
            lblAvailableBalanceValue.ForeColor = net < 0m ? Color.Salmon
                                               : net > 0m ? Color.PaleGreen
                                               : Color.White;

        }

        private static void ShowOwed(Label label, decimal amount)
        {
            label.Text = "₱ " + amount.ToString("N2");
            label.ForeColor = amount > 0m ? Color.Salmon : Color.White;
        }


        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (_selectedTenantId <= 0) return;

            using (var billing = new TenantBillingForm(_selectedTenantId))
                billing.ShowDialog(this.FindForm());
        }
    }
}
