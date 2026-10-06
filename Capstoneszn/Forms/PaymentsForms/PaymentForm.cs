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

            // Payment type: full only, per landlord policy
            cboPaymentType.Items.Clear();
            cboPaymentType.Items.AddRange(new object[] { "Full", "Partial", "Down" });
            cboPaymentType.SelectedIndex = 0;          // "Full"
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

            using (ConfirmPaymentForm confirm = new ConfirmPaymentForm(dtpPaymentDate.Value.Date, cboPaymentCategory.Text, cboPaymentType.Text, method, refNo, amount))
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
                        _roomPrice = (result == null || result == DBNull.Value) ? 0m : Convert.ToDecimal(result);
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
                        // 1. Re-check capacity — the form may have sat open a while
                        string capSql = @"
                            SELECT r.Capacity,
                                   (SELECT COUNT(*) FROM Tenants t
                                    WHERE t.RoomId = r.RoomId
                                      AND t.Status = 'Active' AND t.IsArchived = 0)
                            FROM Rooms r WHERE r.RoomId = @rid;";

                        int capacity, occupied;
                        using (var cmd = new SqlCommand(capSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", _data.RoomId);
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
                            return;
                        }

                        // 2. Insert tenant
                        string tenantSql = @"
                            INSERT INTO Tenants
                                (RoomId, FirstName, MiddleName, LastName, Address,
                                 ContactNumber, DateOccupied, Status)
                            VALUES (@rid, @fn, @mn, @ln, @addr, @contact, @date, 'Active');
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int newTenantId;
                        using (var cmd = new SqlCommand(tenantSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", _data.RoomId);
                            cmd.Parameters.AddWithValue("@fn", _data.FirstName);
                            cmd.Parameters.AddWithValue("@mn",
                                string.IsNullOrWhiteSpace(_data.MiddleName)
                                    ? (object)DBNull.Value : _data.MiddleName);
                            cmd.Parameters.AddWithValue("@ln", _data.LastName);
                            cmd.Parameters.AddWithValue("@addr",
                                string.IsNullOrWhiteSpace(_data.Address)
                                    ? (object)DBNull.Value : _data.Address);
                            cmd.Parameters.AddWithValue("@contact", _data.ContactNumber);
                            cmd.Parameters.AddWithValue("@date", _data.DateOccupied);
                            newTenantId = (int)cmd.ExecuteScalar();
                        }

                        // 2b. Anchor the billing cycle and create the first bill
                        DateTime start = _data.DateOccupied;

                        using (var cmd = new SqlCommand(
                            @"UPDATE Rooms SET BillingAnchorDate = @start
                              WHERE RoomId = @rid AND BillingAnchorDate IS NULL;", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", _data.RoomId);
                            cmd.Parameters.AddWithValue("@start", start);
                            cmd.ExecuteNonQuery();
                        }

                        int billId;
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO Bills (RoomId, BillingPeriodStart, BillingPeriodEnd, DueDate, Amount)
                              VALUES (@rid, @start,
                                      DATEADD(DAY, -1, DATEADD(MONTH, 1, @start)),
                                      @start, @amt);
                              SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", _data.RoomId);
                            cmd.Parameters.AddWithValue("@start", start);
                            cmd.Parameters.AddWithValue("@amt", amount);
                            billId = (int)cmd.ExecuteScalar();
                        }

                        // 3. Insert payment
                        string paySql = @" INSERT INTO Payments (TenantId, RoomId, BillId, ReceiptNo, PaymentCategory, PaymentType, Amount, PaymentMethod, ReferenceNo, PaymentDate) VALUES (@tid, @rid, @bill, @rcpt, @cat, @type, @amt, @method, @ref, @pdate);";

                        using (var cmd = new SqlCommand(paySql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@tid", newTenantId);
                            cmd.Parameters.AddWithValue("@rid", _data.RoomId);
                            cmd.Parameters.AddWithValue("@bill", billId);
                            cmd.Parameters.AddWithValue("@rcpt", receiptNo);
                            cmd.Parameters.AddWithValue("@cat", cboPaymentCategory.Text);
                            cmd.Parameters.AddWithValue("@type", cboPaymentType.Text);
                            cmd.Parameters.AddWithValue("@amt", amount);
                            cmd.Parameters.AddWithValue("@method", method);
                            cmd.Parameters.AddWithValue("@ref",
                                string.IsNullOrWhiteSpace(refNo)
                                    ? (object)DBNull.Value : refNo);
                            cmd.Parameters.AddWithValue("@pdate", dtpPaymentDate.Value.Date);
                            cmd.ExecuteNonQuery();
                        }

                        // 3b. Recompute the bill from its payments
                        using (var cmd = new SqlCommand(
                            @"UPDATE Bills
                              SET AmountPaid = ISNULL((SELECT SUM(p.Amount) FROM Payments p
                                                       WHERE p.BillId = Bills.BillId), 0),
                                  Status = CASE
                                      WHEN ISNULL((SELECT SUM(p.Amount) FROM Payments p
                                                   WHERE p.BillId = Bills.BillId), 0) >= Amount THEN 'Paid'
                                      WHEN ISNULL((SELECT SUM(p.Amount) FROM Payments p
                                                   WHERE p.BillId = Bills.BillId), 0) > 0 THEN 'Partially Paid'
                                      ELSE 'Unpaid' END
                              WHERE BillId = @bid;", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@bid", billId);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Recompute room status from the live tenant count
                        string statusSql = @" UPDATE Rooms SET Status = CASE WHEN (SELECT COUNT(*) FROM Tenants t WHERE t.RoomId = Rooms.RoomId AND t.Status = 'Active' AND t.IsArchived = 0) > 0 THEN 'Occupied' ELSE 'Available' END WHERE RoomId = @rid AND Status IN ('Available', 'Occupied');";

                        using (var cmd = new SqlCommand(statusSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", _data.RoomId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        saved = true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
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
    }
}
