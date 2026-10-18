using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms;
using Microsoft.Data.SqlClient;
using Capstoneszn.Forms.RoomsForms;

namespace Capstoneszn.UserControls
{
    public partial class MoveInForm : Form
    {

        private int _roomId;

        public MoveInForm(int roomId)
        {
            InitializeComponent();

            _roomId = roomId;

            txtContactNumber.KeyPress += NumericOnly_KeyPress;
            txtContactNumber.MaxLength = 20;
            txtFName.MaxLength = 50;    // nvarchar(50)
            txtMName.MaxLength = 50;
            txtLName.MaxLength = 50;
            txtAddress.MaxLength = 255;   // nvarchar(255)
            dtpMoveInDate.Value = DateTime.Today;
            dtpMoveInDate.Enabled = false;
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnCancelMoveIn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MoveInForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmMoveIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
        string.IsNullOrWhiteSpace(txtLName.Text))
            {
                MessageBox.Show("First name and last name are required.",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string contact = txtContactNumber.Text.Trim();
            if (contact.Length < 11 || !contact.All(char.IsDigit))
            {
                MessageBox.Show("Contact number must be 11 digits or more.",
                    "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNumber.Focus();
                return;
            }

            if (!ConfirmIfDuplicateContact(contact)) return;

            var data = new MoveInData
            {
                RoomId = _roomId,
                FirstName = txtFName.Text.Trim(),
                MiddleName = txtMName.Text.Trim(),
                LastName = txtLName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactNumber = contact,
                DateOccupied = dtpMoveInDate.Value.Date
            };

            int activeTenants = GetActiveTenantCount();
            if (activeTenants < 0) return;   // query failed, message already shown

            if (activeTenants == 0)
            {
                // Vacant room: landlord policy requires the full room price up front
                using (PaymentForm pay = new PaymentForm(data))
                {
                    if (pay.ShowDialog(this) == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                // Room is already occupied: no payment at move-in.
                // This tenant's share is collected through Bill Management.
                string msg =
                    $"This room is already occupied, so no payment is collected now.\n\n" +
                    $"{data.FirstName} {data.LastName} will be added to the room, and " +
                    $"their rent is collected with the room's next bill.\n\nContinue?";

                if (MessageBox.Show(msg, "Add Tenant", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (AddTenantWithoutPayment(data))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        // Returns -1 if the query failed
        private int GetActiveTenantCount()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Occupancy lives in Tenancies now. Tenants holds only the
                    // person, so a room's headcount comes from its active stays.
                    string sql = @"
                SELECT COUNT(*) FROM Tenancies
                WHERE RoomId = @rid AND Status = 'Active';";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _roomId;
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                    MessageBox.Show("Could not check the room: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        private bool AddTenantWithoutPayment(MoveInData data)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Re-check capacity inside the transaction
                        string capSql = @"
                    SELECT r.Capacity,
                           (SELECT COUNT(*) FROM Tenancies tn
                            WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active')
                    FROM Rooms r WHERE r.RoomId = @rid;";

                        int capacity, occupied;
                        using (var cmd = new SqlCommand(capSql, conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = data.RoomId;
                            using (var rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                // An unconfigured room has no capacity yet, so nobody
                                // can move in until the landlord sets one.
                                capacity = rd.IsDBNull(0) ? 0 : rd.GetInt32(0);
                                occupied = rd.GetInt32(1);
                            }
                        }

                        if (capacity == 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room has no capacity set yet.",
                                "Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (occupied >= capacity)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room filled up while the form was open.",
                                "Room Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        // The room emptied while this form was open. A tenant moving into a
                        // vacant room must pay the full room price first, so send them back
                        // through the payment path instead of adding them for free.
                        // Checked BEFORE any insert, so nothing is written and undone.
                        if (occupied == 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room became vacant while the form was open.\n\n" +
                                            "Click Confirm again to take the first payment.",
                                "Room Is Now Vacant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }

                        // 2. Insert the PERSON
                        int tenantId;
                        string tenantSql = @"
                    INSERT INTO Tenants
                        (FirstName, MiddleName, LastName, Address, ContactNumber)
                    OUTPUT INSERTED.TenantId
                    VALUES (@fn, @mn, @ln, @addr, @contact);";

                        using (var cmd = new SqlCommand(tenantSql, conn, tx))
                        {
                            cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = data.FirstName;
                            cmd.Parameters.Add("@mn", SqlDbType.NVarChar, 50).Value =
                                string.IsNullOrWhiteSpace(data.MiddleName)
                                    ? (object)DBNull.Value : data.MiddleName;
                            cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = data.LastName;
                            cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 255).Value =
                                string.IsNullOrWhiteSpace(data.Address)
                                    ? (object)DBNull.Value : data.Address;
                            cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = data.ContactNumber;

                            tenantId = (int)cmd.ExecuteScalar();
                        }

                        // 3. Insert the STAY. Separating these two is what lets a
                        //    tenant move rooms or return later without losing the
                        //    earlier tenancy.
                        string tenancySql = @"
                    INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                    VALUES (@tid, @rid, @date, 'Active');";

                        using (var cmd = new SqlCommand(tenancySql, conn, tx))
                        {
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tenantId;
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = data.RoomId;
                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = data.DateOccupied;
                            cmd.ExecuteNonQuery();
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleTenants, "Move In",
    data.FirstName + " " + data.LastName + " joined Room " +
    AuditLogger.RoomNumber(conn, tx, data.RoomId) + " on " + data.DateOccupied.ToString("MMM dd, yyyy") + " (no payment)");

                        // No bill, share or payment here: a tenant joining an
                        // occupied room is billed from the room's next cycle.
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { System.Diagnostics.Debug.WriteLine(rollbackEx); }

                        System.Diagnostics.Debug.WriteLine(ex);
                        MessageBox.Show("Could not add the tenant: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Clear();
            txtMName.Clear();
            txtLName.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            dtpMoveInDate.Value = DateTime.Today;
        }

        /// <summary>
        /// Warns if the contact number already belongs to someone. Deliberately
        /// a warning, not a block: family members share numbers. It catches the
        /// accidental double entry without forbidding the legitimate one.
        /// Returns false if the landlord decides not to continue.
        /// </summary>
        private bool ConfirmIfDuplicateContact(string contactNumber)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT TOP 1 t.FirstName + ' ' + t.LastName AS FullName,
                   ISNULL(r.RoomNumber, '-') AS RoomNumber,
                   CASE WHEN tn.TenancyId IS NULL THEN 'Inactive' ELSE 'Active' END AS Standing
            FROM   Tenants t
            LEFT JOIN Tenancies tn ON tn.TenantId = t.TenantId AND tn.Status = 'Active'
            LEFT JOIN Rooms r      ON r.RoomId = tn.RoomId
            WHERE  t.ContactNumber = @contact
            ORDER BY tn.TenancyId DESC;", conn))
                {
                    cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = contactNumber;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return true;   // no match, carry on

                        string msg =
                            $"A tenant with this contact number already exists:\n\n" +
                            $"{r.GetString(0)} - Room {r.GetString(1)} ({r.GetString(2)})\n\n" +
                            $"Continue anyway?";

                        return MessageBox.Show(msg, "Possible Duplicate",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                    }
                }
            }
            catch (Exception ex)
            {
                // A failed check must not block a legitimate move-in.
                System.Diagnostics.Debug.WriteLine(ex);
                return true;
            }
        }
    }
}
