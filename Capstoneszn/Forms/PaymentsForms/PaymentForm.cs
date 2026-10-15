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
using Capstoneszn.Forms.RoomsForms;

namespace Capstoneszn.Forms
{
    public partial class PaymentForm : Form
    {
        private MoveInData _data;
        private decimal _roomPrice;
        public PaymentForm(MoveInData data)
        {
            InitializeComponent();

            _data = data;

            // Date is fixed - it anchors the billing cycle
            dtpPaymentDate.Value = DateTime.Today;
            dtpPaymentDate.Enabled = false;

            // Category: Rent, locked
            cboPaymentCategory.Items.Clear();
            cboPaymentCategory.Items.Add("Rent");
            cboPaymentCategory.SelectedIndex = 0;
            cboPaymentCategory.Enabled = false;

            // Payment type: always Full. The amount is locked to the room price,
            // which is exactly the first bill - paid equals owed.
            cboPaymentType.Items.Clear();
            cboPaymentType.Items.Add("Full Payment");
            cboPaymentType.SelectedIndex = 0;
            cboPaymentType.Enabled = false;

            // Amount is always visible
            lblPaymentAmount.Visible = true;
            txtAmountValue.Visible = true;

            RadioBtnCash.Checked = true;
            RadioBtnCash.CheckedChanged += PaymentMethod_Changed;
            RadioBtnGCash.CheckedChanged += PaymentMethod_Changed;
            PaymentMethod_Changed(null, EventArgs.Empty);

        }

        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && txtAmountValue.Text.Contains("."))
                e.Handled = true;
        }

        private void PaymentMethod_Changed(object sender, EventArgs e)
        {
            bool isGCash = RadioBtnGCash.Checked;

            lblReferenceNumber.Visible = isGCash;
            txtReferenceNumber.Visible = isGCash;

            if (!isGCash) txtReferenceNumber.Clear();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LoadRoomPrice();
        }

        private void btnCancelPayment_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnContinuePayment_Click(object sender, EventArgs e)
        {

            if (_roomPrice <= 0)
            {
                MessageBox.Show("This room has no price set. Configure the room before moving a tenant in.",
                    "No Room Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal amount = _roomPrice;

            string method = RadioBtnGCash.Checked ? "GCash" : "Cash";
            string refNo = txtReferenceNumber.Text.Trim();

            if (method == "GCash" && string.IsNullOrWhiteSpace(refNo))
            {
                MessageBox.Show("Please enter the GCash reference number.",
                    "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (ConfirmPaymentForm confirm = new ConfirmPaymentForm(
                dtpPaymentDate.Value.Date, cboPaymentCategory.Text,
                cboPaymentType.Text, method, refNo, amount))
            {
                if (confirm.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            SaveMoveIn(amount, method, refNo);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReferenceNumber.Clear();
            RadioBtnCash.Checked = true;
            // Amount, Category, Payment Type and Date are fixed - don't clear them
        }

        private void LoadRoomPrice()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT RoomPrice FROM Rooms WHERE RoomId = @rid";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _data.RoomId);
                        object result = cmd.ExecuteScalar();
                        _roomPrice = (result == null || result == DBNull.Value)
                            ? 0m : Convert.ToDecimal(result);
                    }

                    txtAmountValue.Text = _roomPrice.ToString("N2");
                    txtAmountValue.ReadOnly = true;
                    txtAmountValue.BackColor = Color.Gainsboro;
                    txtAmountValue.ForeColor = Color.Black;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not load the room price: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveMoveIn(decimal amount, string method, string refNo)
        {
            string receiptNo = "R" + DateTime.Now.ToString("yyyyMMddHHmmss");
            bool saved = false;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Re-check capacity - the form may have sat open a while.
                        //    Occupancy comes from Tenancies now; Tenants holds only
                        //    the person.
                        string capSql = @"
                    SELECT r.Capacity,
                           (SELECT COUNT(*) FROM Tenancies tn
                            WHERE tn.RoomId = r.RoomId AND tn.Status = 'Active')
                    FROM Rooms r WHERE r.RoomId = @rid;";

                        int capacity, occupied;
                        using (var cmd = new SqlCommand(capSql, conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            using (var rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                capacity = rd.IsDBNull(0) ? 0 : rd.GetInt32(0);
                                occupied = rd.GetInt32(1);
                            }
                        }

                        if (capacity == 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room has no capacity set yet.",
                                "Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (occupied >= capacity)
                        {
                            tx.Rollback();
                            MessageBox.Show("This room filled up while the form was open.",
                                "Room Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // 2. Insert the PERSON
                        int newTenantId;
                        string tenantSql = @"
                    INSERT INTO Tenants
                        (FirstName, MiddleName, LastName, Address, ContactNumber)
                    OUTPUT INSERTED.TenantId
                    VALUES (@fn, @mn, @ln, @addr, @contact);";

                        using (var cmd = new SqlCommand(tenantSql, conn, tx))
                        {
                            cmd.Parameters.Add("@fn", SqlDbType.NVarChar, 50).Value = _data.FirstName;
                            cmd.Parameters.Add("@mn", SqlDbType.NVarChar, 50).Value =
                                string.IsNullOrWhiteSpace(_data.MiddleName)
                                    ? (object)DBNull.Value : _data.MiddleName;
                            cmd.Parameters.Add("@ln", SqlDbType.NVarChar, 50).Value = _data.LastName;
                            cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 255).Value =
                                string.IsNullOrWhiteSpace(_data.Address)
                                    ? (object)DBNull.Value : _data.Address;
                            cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 20).Value = _data.ContactNumber;

                            newTenantId = (int)cmd.ExecuteScalar();
                        }

                        // 2a. Insert the STAY
                        using (var cmd = new SqlCommand(@"
                    INSERT INTO Tenancies (TenantId, RoomId, MoveInDate, Status)
                    VALUES (@tid, @rid, @date, 'Active');", conn, tx))
                        {
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = _data.DateOccupied;
                            cmd.ExecuteNonQuery();
                        }

                        // 2b. Anchor the billing cycle. If this tenant is alone in the room,
                        //     the cycle starts on their move-in day. If others already live
                        //     here, the room keeps its existing anchor.
                        DateTime start = _data.DateOccupied;

                        using (var cmd = new SqlCommand(
                            @"UPDATE Rooms SET BillingAnchorDate = @start
                          WHERE RoomId = @rid
                            AND NOT EXISTS (SELECT 1 FROM Tenancies tn
                            WHERE tn.RoomId = @rid AND tn.Status = 'Active'
                            AND tn.TenantId <> @tid);", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            cmd.Parameters.Add("@start", SqlDbType.Date).Value = start;
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.ExecuteNonQuery();
                        }

                        // 2c. The first bill. Period runs anchor to anchor, matching
                        //     what the generator will produce for every later period.
                        int billId;
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO Bills
                          (RoomId, BillCategory, BillingPeriodStart,
                           BillingPeriodEnd, DueDate, Amount)
                      OUTPUT INSERTED.BillId
                      VALUES (@rid, 'Rent', @start,
                              DATEADD(MONTH, 1, @start), @start, @amt);", conn, tx))
                        {
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            cmd.Parameters.Add("@start", SqlDbType.Date).Value = start;
                            cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                            cmd.Parameters["@amt"].Precision = 18;
                            cmd.Parameters["@amt"].Scale = 2;
                            billId = (int)cmd.ExecuteScalar();
                        }

                        // 2d. This tenant's share. They are alone in the room, so the
                        //     share is the whole bill. Frozen here, never recomputed.
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO BillTenants (BillId, TenantId, Share)
                      VALUES (@bid, @tid, @share);", conn, tx))
                        {
                            cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.Parameters.Add("@share", SqlDbType.Decimal).Value = amount;
                            cmd.Parameters["@share"].Precision = 18;
                            cmd.Parameters["@share"].Scale = 2;
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Record the money received. Payments no longer carries a
                        //    BillId - PaymentAllocations says which share it settled.
                        int paymentId;
                        string paySql = @"
                    INSERT INTO Payments
                        (TenantId, RoomId, ReceiptNo, PaymentCategory,
                         PaymentType, Amount, PaymentMethod, ReferenceNo,
                         PaymentDate, CoversRoom, RecordedBy)
                    OUTPUT INSERTED.PaymentId
                    VALUES (@tid, @rid, @rcpt, @cat,
                            @type, @amt, @method, @ref,
                            @pdate, 0, @by);";

                        using (var cmd = new SqlCommand(paySql, conn, tx))
                        {
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = _data.RoomId;
                            cmd.Parameters.Add("@rcpt", SqlDbType.NVarChar, 50).Value = receiptNo;
                            cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 20).Value = cboPaymentCategory.Text;
                            cmd.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = "Full";
                            cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                            cmd.Parameters["@amt"].Precision = 18;
                            cmd.Parameters["@amt"].Scale = 2;
                            cmd.Parameters.Add("@method", SqlDbType.NVarChar, 20).Value = method;
                            cmd.Parameters.Add("@ref", SqlDbType.NVarChar, 100).Value =
                                string.IsNullOrWhiteSpace(refNo) ? (object)DBNull.Value : refNo;
                            cmd.Parameters.Add("@pdate", SqlDbType.Date).Value = dtpPaymentDate.Value.Date;
                            cmd.Parameters.Add("@by", SqlDbType.Int).Value = Session.UserId;

                            paymentId = (int)cmd.ExecuteScalar();
                        }

                        // 3a. Allocate that money to the share it settles. Nothing
                        //     stores "amount paid" - it is summed from here, so it
                        //     cannot drift away from the payments behind it.
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO PaymentAllocations
                          (PaymentId, BillId, TenantId, Amount)
                      VALUES (@pid, @bid, @tid, @amt);", conn, tx))
                        {
                            cmd.Parameters.Add("@pid", SqlDbType.Int).Value = paymentId;
                            cmd.Parameters.Add("@bid", SqlDbType.Int).Value = billId;
                            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = newTenantId;
                            cmd.Parameters.Add("@amt", SqlDbType.Decimal).Value = amount;
                            cmd.Parameters["@amt"].Precision = 18;
                            cmd.Parameters["@amt"].Scale = 2;
                            cmd.ExecuteNonQuery();
                        }

                        // No bill recompute and no room status update: both are
                        // derived now, from allocations and from vwRoomStatus.

                        tx.Commit();
                        saved = true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); }
                        catch (Exception rollbackEx) { System.Diagnostics.Debug.WriteLine(rollbackEx); }

                        System.Diagnostics.Debug.WriteLine(ex);
                        MessageBox.Show("Move-in failed, nothing was saved: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (!saved) return;

            using (PaymentSuccessForm success = new PaymentSuccessForm(
                receiptNo, dtpPaymentDate.Value.Date, cboPaymentCategory.Text))
            {
                success.ShowDialog(this);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtReferenceNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlReferenceNumber_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RadioBtnGCash_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
