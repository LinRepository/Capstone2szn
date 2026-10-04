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

            if (txtContactNumber.Text.Trim().Length < 10)
            {
                MessageBox.Show("Please enter a valid contact number.",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var data = new MoveInData
            {
                RoomId = _roomId,
                FirstName = txtFName.Text.Trim(),
                MiddleName = txtMName.Text.Trim(),
                LastName = txtLName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                ContactNumber = txtContactNumber.Text.Trim(),
                DateOccupied = dtpMoveInDate.Value.Date
            };

            int activeTenants = GetActiveTenantCount();
            if (activeTenants < 0) return;   // query failed, message already shown

            if (activeTenants == 0)
            {
                // Vacant room: landlord policy requires the full room price up front
                using (PaymentForm pay = new PaymentForm(data))
                {
                    if (pay.ShowDialog() == DialogResult.OK)
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
                    string sql = @"
                SELECT COUNT(*) FROM Tenants
                WHERE RoomId = @rid AND Status = 'Active' AND IsArchived = 0;";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _roomId);
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
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
                           (SELECT COUNT(*) FROM Tenants t
                            WHERE t.RoomId = r.RoomId
                              AND t.Status = 'Active' AND t.IsArchived = 0)
                    FROM Rooms r WHERE r.RoomId = @rid;";

                        int capacity, occupied;
                        using (var cmd = new SqlCommand(capSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", data.RoomId);
                            using (var rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                capacity = rd.GetInt32(0);
                                occupied = rd.GetInt32(1);
                            }
                        }

                        if (occupied >= capacity)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room filled up while the form was open.",
                                "Room Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        // 2. Insert the tenant
                        string tenantSql = @"
                    INSERT INTO Tenants
                        (RoomId, FirstName, MiddleName, LastName, Address,
                         ContactNumber, DateOccupied, Status)
                    VALUES (@rid, @fn, @mn, @ln, @addr, @contact, @date, 'Active');";

                        using (var cmd = new SqlCommand(tenantSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", data.RoomId);
                            cmd.Parameters.AddWithValue("@fn", data.FirstName);
                            cmd.Parameters.AddWithValue("@mn",
                                string.IsNullOrWhiteSpace(data.MiddleName)
                                    ? (object)DBNull.Value : data.MiddleName);
                            cmd.Parameters.AddWithValue("@ln", data.LastName);
                            cmd.Parameters.AddWithValue("@addr",
                                string.IsNullOrWhiteSpace(data.Address)
                                    ? (object)DBNull.Value : data.Address);
                            cmd.Parameters.AddWithValue("@contact", data.ContactNumber);
                            cmd.Parameters.AddWithValue("@date", data.DateOccupied);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Keep room status in step with the live tenant count
                        string statusSql = @"
                    UPDATE Rooms
                    SET Status = CASE
                            WHEN (SELECT COUNT(*) FROM Tenants t
                                  WHERE t.RoomId = Rooms.RoomId
                                    AND t.Status = 'Active' AND t.IsArchived = 0) > 0
                            THEN 'Occupied' ELSE 'Available' END
                    WHERE RoomId = @rid AND Status IN ('Available', 'Occupied');";

                        using (var cmd = new SqlCommand(statusSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", data.RoomId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
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
    }
}
