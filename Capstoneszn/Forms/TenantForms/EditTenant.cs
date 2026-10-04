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

namespace Capstoneszn.Forms.TenantForms
{
    public partial class EditTenant : Form
    {

        private int _tenantId;

        public EditTenant(int tenantId)
        {
            InitializeComponent();

            _tenantId = tenantId;

            txtEditTenantContactNumber.KeyPress += NumericOnly_KeyPress;
            txtEditTenantContactNumber.MaxLength = 20;


            LoadTenant();
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void LoadTenant()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT FirstName, MiddleName, LastName, Address, ContactNumber
                        FROM Tenants WHERE TenantId = @tid;";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tid", _tenantId);
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                txtEditTenantFName.Text = rd.IsDBNull(0) ? "" : rd.GetString(0);
                                txtEditTenantMName.Text = rd.IsDBNull(1) ? "" : rd.GetString(1);
                                txtEditTenantLName.Text = rd.IsDBNull(2) ? "" : rd.GetString(2);
                                txtEditTenantAddress.Text = rd.IsDBNull(3) ? "" : rd.GetString(3);
                                txtEditTenantContactNumber.Text =
                                    rd.IsDBNull(4) ? "" : rd.GetString(4);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading tenant: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditConfirm_Click(object sender, EventArgs e)
        {
            string fname = txtEditTenantFName.Text.Trim();
            string lname = txtEditTenantLName.Text.Trim();
            string contact = txtEditTenantContactNumber.Text.Trim();

            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname))
            {
                MessageBox.Show("First name and last name are required.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contact.Length < 10)
            {
                MessageBox.Show("Please enter a valid contact number.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        UPDATE Tenants
                        SET FirstName     = @fn,
                            MiddleName    = @mn,
                            LastName      = @ln,
                            Address       = @addr,
                            ContactNumber = @contact
                        WHERE TenantId = @tid;";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        string mname = txtEditTenantMName.Text.Trim();
                        string addr = txtEditTenantAddress.Text.Trim();

                        cmd.Parameters.AddWithValue("@fn", fname);
                        cmd.Parameters.AddWithValue("@mn",
                            mname.Length == 0 ? (object)DBNull.Value : mname);
                        cmd.Parameters.AddWithValue("@ln", lname);
                        cmd.Parameters.AddWithValue("@addr",
                            addr.Length == 0 ? (object)DBNull.Value : addr);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@tid", _tenantId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tenant details updated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
