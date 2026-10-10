using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.TenantForms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.UserControls
{
    public partial class TenantsControl : UserControl
    {

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
            colDateOccupied.DataPropertyName = "DateOccupied";

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
                    string sql = @"
                SELECT t.TenantId, r.RoomNumber, t.FirstName, t.MiddleName,
                       t.LastName, t.Address, t.ContactNumber, t.DateOccupied
                FROM Tenants t
                INNER JOIN Rooms  r ON r.RoomId  = t.RoomId
                INNER JOIN Floors f ON f.FloorId = r.FloorId
                WHERE f.BuildingId = @BuildingId
                  AND t.Status = 'Active'
                  AND t.IsArchived = 0
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
                catch (Exception)
                {
                    MessageBox.Show("Unable to load tenants.", "Database Error",
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
                if (edit.ShowDialog() == DialogResult.OK)
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

            lblDateOccupiedValue.Text = row["DateOccupied"] == DBNull.Value
                ? "-"
                : Convert.ToDateTime(row["DateOccupied"]).ToString("MMMM d, yyyy");

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



    }
}
