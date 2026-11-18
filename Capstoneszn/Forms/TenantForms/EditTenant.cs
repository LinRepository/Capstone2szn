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

    ///
    /// NEW (Nov 12) validation rules:
    ///   - First / Last name required; Middle name optional
    ///   - Names: letters (ñ, accents), spaces, period, hyphen, apostrophe only
    ///   - Contact: required, 11 digits starting with 09, unique among tenants
    ///   - Input is trimmed and repeated spaces collapsed before saving
    ///   - No UPDATE runs when nothing changed
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

            // NEW: block numbers/symbols while typing in the name fields
            txtEditTenantFName.KeyPress += LettersOnly_KeyPress;
            txtEditTenantMName.KeyPress += LettersOnly_KeyPress;
            txtEditTenantLName.KeyPress += LettersOnly_KeyPress;

            // Enter confirms, Esc cancels.
            this.AcceptButton = btnEditConfirm;
            this.CancelButton = btnEditCancel;
            this.StartPosition = FormStartPosition.CenterParent;

            LoadTenant();
            // NEW (Nov 13): start in First Name when the form opens
            this.ActiveControl = txtEditTenantFName;
        }

        /* =================================================================
           NEW (Nov 18, Audit Logs coverage): Edit Tenant entry
           ================================================================= */

        /// <summary>
        /// Writes the Edit Tenant audit entry, e.g.
        /// "Juan Dela Cruz (Room 202): Contact 09171234567 → 09181234567; Address Bacolod → Iloilo".
        /// Called only after the UPDATE saved.
        /// </summary>
        private void LogEdit(SqlConnection conn, string fname, string mname, string lname,
                             string addr, string contact)
        {
            var changes = new List<string>();
            AddChange(changes, "First name", _originalFName, fname);
            AddChange(changes, "Middle name", _originalMName, mname);
            AddChange(changes, "Last name", _originalLName, lname);
            AddChange(changes, "Contact", _originalContact, contact);
            AddChange(changes, "Address", _originalAddress, addr);
            if (changes.Count == 0) return;   // the Save button already stops "no changes"

            // The tenant as they were known before the edit, plus their current room.
            string oldName = (_originalFName + " " +
                              (_originalMName.Length > 0 ? _originalMName + " " : "") +
                              _originalLName).Trim();

            // The room is only extra detail: if this lookup fails, log without it
            // instead of showing an error for a save that already worked.
            string room = "";
            try
            {
                using (var cmd = new SqlCommand(@"
                    SELECT TOP 1 r.RoomNumber
                    FROM   Tenancies tn
                    JOIN   Rooms r ON r.RoomId = tn.RoomId
                    WHERE  tn.TenantId = @tid AND tn.Status = 'Active';", conn))
                {
                    cmd.Parameters.Add("@tid", SqlDbType.Int).Value = _tenantId;
                    object? value = cmd.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                        room = " (Room " + value + ")";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            AuditLogger.Log(AuditLogger.ModuleTenants, "Edit Tenant",
                oldName + room + ": " + string.Join("; ", changes));
        }

        /// <summary>Adds "Label old → new" when the value changed; blanks show as (blank).</summary>
        private static void AddChange(List<string> changes, string label, string oldValue, string newValue)
        {
            oldValue = oldValue ?? "";
            newValue = newValue ?? "";
            if (string.Equals(oldValue, newValue, StringComparison.Ordinal)) return;

            changes.Add(label + " " + (oldValue.Length == 0 ? "(blank)" : oldValue) +
                        " → " + (newValue.Length == 0 ? "(blank)" : newValue));
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        // name fields accept letters, space, period, apostrophe and hyphen only
        private void LettersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsControl(c) || char.IsLetter(c) || c == ' ' || c == '.' ||
                c == '\'' || c == '’' || c == '‘' || c == '-')
                return;

            e.Handled = true;   // blocks digits and other symbols
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
                                _originalFName = Clean(txtEditTenantFName.Text);
                                _originalMName = Clean(txtEditTenantMName.Text);
                                _originalLName = Clean(txtEditTenantLName.Text);
                                _originalAddress = Clean(txtEditTenantAddress.Text);

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


                    if (contact != _originalContact && !ConfirmSharedContact(conn, contact))
                    {
                        txtEditTenantContactNumber.Focus();
                        return;
                    }

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

                    // NEW (Nov 18, Audit Logs coverage): the update saved (rows > 0).
                    // Only the changed fields, full old → new values. Logged after success
                    // (this save has no transaction); AuditLogger never throws here.
                    LogEdit(conn, fname, mname, lname, addr, contact);

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
                MessageBox.Show(label + " can only contain letters, spaces, periods (.), hyphens (-) and apostrophes (').",
                    "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// NEW (Nov 12): unique contact rule. Returns false and shows the name of the
        /// tenant who already uses this number, so the save is blocked (no override).
        /// Runs only when the contact number was actually changed.
        /// </summary>
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

                MessageBox.Show(contact + " is already used by " + other + ". Please enter a different number.",
                    "Contact Number in Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
