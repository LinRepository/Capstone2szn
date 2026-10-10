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

            // Match the database column widths exactly, so the user is stopped
            // at the textbox instead of by a truncation error at save time.
            txtEditTenantFName.MaxLength = 50;    // nvarchar(50)
            txtEditTenantMName.MaxLength = 50;    // nvarchar(50)
            txtEditTenantLName.MaxLength = 50;    // nvarchar(50)
            txtEditTenantAddress.MaxLength = 255;   // nvarchar(255)
            txtEditTenantContactNumber.MaxLength = 20;

            txtEditTenantContactNumber.KeyPress += NumericOnly_KeyPress;

            // Enter confirms, Esc cancels.
            this.AcceptButton = btnEditConfirm;
            this.CancelButton = btnEditCancel;

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
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;

                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                txtEditTenantFName.Text         = rd.IsDBNull(0) ? "" : rd.GetString(0);
                                txtEditTenantMName.Text         = rd.IsDBNull(1) ? "" : rd.GetString(1);
                                txtEditTenantLName.Text         = rd.IsDBNull(2) ? "" : rd.GetString(2);
                                txtEditTenantAddress.Text       = rd.IsDBNull(3) ? "" : rd.GetString(3);
                                txtEditTenantContactNumber.Text = rd.IsDBNull(4) ? "" : rd.GetString(4);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to load tenant details.", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditConfirm_Click(object sender, EventArgs e)
        {
            string fname = txtEditTenantFName.Text.Trim();
            string mname = txtEditTenantMName.Text.Trim();
            string lname = txtEditTenantLName.Text.Trim();
            string addr = txtEditTenantAddress.Text.Trim();
            string contact = txtEditTenantContactNumber.Text.Trim();

            if (fname.Length == 0 || lname.Length == 0)
            {
                MessageBox.Show("First name and last name are required.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditTenantFName.Focus();
                return;
            }

            // KeyPress blocks typed letters, but not a pasted value — so re-check here.
            if (contact.Length == 0 || !contact.All(char.IsDigit))
            {
                MessageBox.Show("Contact number must be 11 digits or more.",
                    "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditTenantContactNumber.Focus();
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
                        cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = fname;
                        cmd.Parameters.Add("@mn", SqlDbType.NVarChar, 50).Value =
                            mname.Length == 0 ? (object)DBNull.Value : mname;
                        cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = lname;
                        cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 255).Value =
                            addr.Length == 0 ? (object)DBNull.Value : addr;
                        cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = contact;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show("This tenant no longer exists. Nothing was saved.",
                                "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.DialogResult = DialogResult.Cancel;
                            this.Close();
                            return;
                        }
                    }

                    MessageBox.Show("Tenant details updated.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to save changes. Please try again.",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditTenant_Load(object sender, EventArgs e)
        {

        }
    }
}
