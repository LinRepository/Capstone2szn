using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.TenantForms
{
    /// <summary>
    /// Edits a current tenant's personal details.
    ///
    /// Settled rule: a moved-out tenant cannot be edited. That rule is
    /// enforced inside the UPDATE itself, not only by hiding the button,
    /// so no other screen that opens this form can get around it.
    /// </summary>
    /// 

    public partial class EditTenant : Form
    {

        private int _tenantId;

        /// <summary>The contact number as loaded, so the duplicate check
        /// only runs when it is actually changed.</summary>
        private string _originalContact = "";
        // NEW: original values, so "nothing changed" can be detected
        private string _originalFName = "", _originalMName = "", _originalLName = "", _originalAddress = "";

        // NEW: letters (incl. ñ/accents), single spaces, hyphen, apostrophe, period - e.g. "Dela Cruz", "O'Neil", "Jr."
        private static readonly Regex NamePattern = new Regex(@"^[\p{L}][\p{L} .'’‘\-–—]*$");

        // NEW: PH mobile number - 11 digits starting with 09
        private static readonly Regex ContactPattern = new Regex(@"^09\d{9}$");

        // NEW: trims and collapses repeated spaces ("Carl   Aldrin" -> "Carl Aldrin")
        private static string Clean(string s)
        {
            string t = (s ?? "")
                .Replace('’', '\'').Replace('‘', '\'')
                .Replace('–', '-').Replace('—', '-');
            return Regex.Replace(t, @"\s+", " ").Trim();
        }

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
            txtEditTenantContactNumber.MaxLength = 11;

            txtEditTenantContactNumber.KeyPress += NumericOnly_KeyPress;

            // Enter confirms, Esc cancels.
            this.AcceptButton = btnEditConfirm;
            this.CancelButton = btnEditCancel;
            this.StartPosition = FormStartPosition.CenterParent;

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
                        SELECT t.FirstName, t.MiddleName, t.LastName, t.Address, t.ContactNumber,
                               CASE WHEN EXISTS (SELECT 1 FROM Tenancies tn
                                                 WHERE tn.TenantId = t.TenantId
                                                   AND tn.Status   = 'Active')
                                    THEN 1 ELSE 0 END AS IsCurrent
                        FROM   Tenants t
                        WHERE  t.TenantId = @tid;";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;

                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                txtEditTenantFName.Text = rd.IsDBNull(0) ? "" : rd.GetString(0);
                                txtEditTenantMName.Text = rd.IsDBNull(1) ? "" : rd.GetString(1);
                                txtEditTenantLName.Text = rd.IsDBNull(2) ? "" : rd.GetString(2);
                                txtEditTenantAddress.Text = rd.IsDBNull(3) ? "" : rd.GetString(3);
                                txtEditTenantContactNumber.Text = rd.IsDBNull(4) ? "" : rd.GetString(4);

                                _originalContact = txtEditTenantContactNumber.Text.Trim();
                                _originalFName = txtEditTenantFName.Text.Trim();
                                _originalMName = txtEditTenantMName.Text.Trim();
                                _originalLName = txtEditTenantLName.Text.Trim();
                                _originalAddress = txtEditTenantAddress.Text.Trim();

                                if (rd.GetInt32(5) == 0)
                                    MakeReadOnly();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    MessageBox.Show("Unable to load tenant details: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>A moved-out tenant's record stays readable but not editable.</summary>
        /// 
        private void MakeReadOnly()
        {
            lblEditTenantDescription.Text = "This tenant has moved out. Their details are read-only.";

            foreach (TextBox box in new[] { txtEditTenantFName, txtEditTenantMName,
                                            txtEditTenantLName, txtEditTenantAddress,
                                            txtEditTenantContactNumber })
                box.ReadOnly = true;

            btnEditConfirm.Enabled = false;
        }

        private void btnEditConfirm_Click(object sender, EventArgs e)
        {
            // NEW: clean the input, then validate each field in screen order,
            //      focusing the field that actually failed
            string fname = Clean(txtEditTenantFName.Text);
            string mname = Clean(txtEditTenantMName.Text);
            string lname = Clean(txtEditTenantLName.Text);
            string addr = Clean(txtEditTenantAddress.Text);
            string contact = txtEditTenantContactNumber.Text.Trim();

            if (!ValidateName(fname, "First name", required: true, txtEditTenantFName)) return;
            if (!ValidateName(mname, "Middle name", required: false, txtEditTenantMName)) return;
            if (!ValidateName(lname, "Last name", required: true, txtEditTenantLName)) return;

            if (addr.Length == 0)
            {
                MessageBox.Show("Address is required.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditTenantAddress.Focus();
                return;
            }

            // Also catches pasted values that KeyPress could not block.
            if (!ContactPattern.IsMatch(contact))
            {
                MessageBox.Show("Contact number must be 11 digits and start with 09 (e.g. 09171234567).",
                    "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditTenantContactNumber.Focus();
                return;
            }

            // NEW: nothing changed - don't run an UPDATE or claim a save
            if (fname == _originalFName && mname == _originalMName && lname == _originalLName &&
                addr == _originalAddress && contact == _originalContact)
            {
                MessageBox.Show("No changes were made.", "Edit Tenant",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Same rule as Move In: a shared number is allowed (family
                    // members, a company phone) but the landlord is told.
                    if (contact != _originalContact && !ConfirmSharedContact(conn, contact))
                        return;

                    // The EXISTS clause is the moved-out rule. Even if this
                    // form is somehow opened for a former tenant, the row
                    // will not change.
                    string sql = @"
                        UPDATE Tenants
                        SET FirstName     = @fn,
                            MiddleName    = @mn,
                            LastName      = @ln,
                            Address       = @addr,
                            ContactNumber = @contact
                        WHERE TenantId = @tid
                          AND EXISTS (SELECT 1 FROM Tenancies tn
                                      WHERE tn.TenantId = Tenants.TenantId
                                        AND tn.Status   = 'Active');";

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
                            MessageBox.Show(
                                "This tenant has moved out or no longer exists, so their " +
                                "details cannot be edited. Nothing was saved.",
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
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    MessageBox.Show("Unable to save changes: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // NEW: letters-only names (panel requirement)
        private static bool ValidateName(string value, string label, bool required, TextBox box)
        {
            if (value.Length == 0)
            {
                if (!required) return true;
                MessageBox.Show(label + " is required.", "Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            if (!NamePattern.IsMatch(value))
            {
                MessageBox.Show(label + " can only contain letters, spaces, hyphens (-), and apostrophes (').",
                    "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true to go ahead. Warns, never blocks, when another tenant
        /// already has this number.
        /// </summary>
        /// 
        private bool ConfirmSharedContact(SqlConnection conn, string contact)
        {
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 FirstName + ' ' + LastName
                FROM   Tenants
                WHERE  ContactNumber = @contact
                  AND  TenantId <> @tid;", conn))
            {
                cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = contact;
                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;

                object other = cmd.ExecuteScalar();
                if (other == null || other == DBNull.Value) return true;

                return MessageBox.Show(
                    contact + " is already recorded for " + other + ".\n\nSave it anyway?",
                    "Contact Number in Use", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes;
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
