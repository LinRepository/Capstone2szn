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
using Capstoneszn.Forms.PaymentsForms;

namespace Capstoneszn.Forms.UserControls.BillingManagement
{
    public partial class BillingRoomDetailsControl : UserControl
    {

        private int _roomId;
        private int _currentBillId = -1;


        public BillingRoomDetailsControl(int roomId)
        {
            InitializeComponent();

            _roomId = roomId;

            dgvTenantPayments.AutoGenerateColumns = false;
            colTenantName.DataPropertyName = "TenantName";
            colShare.DataPropertyName = "Share";
            colPaid.DataPropertyName = "Paid";
            colBalance.DataPropertyName = "Balance";

            colShare.DefaultCellStyle.Format = "N2";
            colPaid.DefaultCellStyle.Format = "N2";
            colBalance.DefaultCellStyle.Format = "N2";
            colShare.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPaid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colBalance.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTenantPayments.CellContentClick += dgvTenantPayments_CellContentClick;
            dgvTenantPayments.CellFormatting += dgvTenantPayments_CellFormatting;

            // btnBackRoomBilling.Click is wired by the designer - do NOT add it
            // here as well, or Back fires twice and the second pass crashes.

            LoadBilling();

        }

        public void LoadBilling()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(
                        "SELECT RoomNumber FROM Rooms WHERE RoomId = @rid", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _roomId);
                        object rn = cmd.ExecuteScalar();
                        lblRoomNumber.Text = "Room " +
                            ((rn == null || rn == DBNull.Value) ? "-" : rn.ToString());
                    }

                    // Current period = the most recent rent bill for this room
                    decimal amount = 0m;
                    _currentBillId = -1;

                    using (var cmd = new SqlCommand(@"
                        SELECT TOP 1 BillId, BillingPeriodStart, BillingPeriodEnd,
                               DueDate, Amount, Status
                        FROM Bills
                        WHERE RoomId = @rid AND BillCategory = 'Rent'
                        ORDER BY BillingPeriodStart DESC;", conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", _roomId);
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                _currentBillId = rd.GetInt32(0);
                                DateTime start = rd.GetDateTime(1);
                                DateTime end = rd.GetDateTime(2);
                                DateTime due = rd.GetDateTime(3);
                                amount = rd.GetDecimal(4);

                                lblPeriodValue.Text =
                                    start.ToString("MMM d") + " - " + end.ToString("MMM d, yyyy");
                                lblBillStatusValue.Text = rd.GetString(5);
                            }
                            else
                            {
                                lblPeriodValue.Text = "No bill yet";
                                lblBillStatusValue.Text = "-";
                            }
                        }
                    }

                    decimal paid = 0m;
                    if (_currentBillId > 0)
                    {
                        using (var cmd = new SqlCommand(
                            @"SELECT ISNULL(SUM(Amount), 0) FROM PaymentAllocations
                              WHERE BillId = @bid;", conn))
                        {
                            cmd.Parameters.AddWithValue("@bid", _currentBillId);
                            paid = Convert.ToDecimal(cmd.ExecuteScalar());
                        }
                    }

                    lblTotalBillValue.Text = amount.ToString("N2");
                    lblTotalPaidValue.Text = paid.ToString("N2");
                    lblCurrentDueValue.Text = (amount - paid).ToString("N2");

                    LoadTenantGrid(conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading room billing: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadTenantGrid(SqlConnection conn)
        {
            // Share and Paid are this period. Balance is the tenant's running
            // position: credit held, minus everything still unpaid.
            string sql = @"
                SELECT t.TenantId,
                       ISNULL(t.FirstName,'') + ' ' + ISNULL(t.LastName,'') AS TenantName,
                       ISNULL(bt.Share, 0) AS Share,
                       ISNULL((SELECT SUM(a.Amount) FROM PaymentAllocations a
                               WHERE a.BillId = @bid AND a.TenantId = t.TenantId), 0) AS Paid,
                       ISNULL((SELECT SUM(c.Amount) FROM PaymentAllocations c
                               WHERE c.TenantId = t.TenantId AND c.BillId IS NULL), 0)
                       - (
                           ISNULL((SELECT SUM(bt2.Share) FROM BillTenants bt2
                                   JOIN Bills b2 ON b2.BillId = bt2.BillId
                                   WHERE bt2.TenantId = t.TenantId
                                     AND b2.BillCategory = 'Rent'), 0)
                         - ISNULL((SELECT SUM(a3.Amount) FROM PaymentAllocations a3
                                   JOIN Bills b3 ON b3.BillId = a3.BillId
                                   WHERE a3.TenantId = t.TenantId
                                     AND b3.BillCategory = 'Rent'), 0)
                         ) AS Balance
                FROM Tenants t
                LEFT JOIN BillTenants bt
                       ON bt.BillId = @bid AND bt.TenantId = t.TenantId
                WHERE t.RoomId = @rid AND t.Status = 'Active' AND t.IsArchived = 0
                ORDER BY t.LastName, t.FirstName;";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@rid", _roomId);
                cmd.Parameters.AddWithValue("@bid", _currentBillId);

                DataTable dt = new DataTable();
                using (var da = new SqlDataAdapter(cmd)) da.Fill(dt);
                dgvTenantPayments.DataSource = dt;
            }
        }

        // Per-row button caption and balance color
        private void dgvTenantPayments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView row = dgvTenantPayments.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            if (e.ColumnIndex == colPayment.Index)
            {
                decimal share = Convert.ToDecimal(row["Share"]);
                decimal pd = Convert.ToDecimal(row["Paid"]);

                if (share <= 0) e.Value = "Not billed";
                else if (share - pd > 0) e.Value = "Make Payment";
                else e.Value = "Paid";
            }
            else if (e.ColumnIndex == colBalance.Index)
            {
                decimal bal = Convert.ToDecimal(row["Balance"]);
                e.CellStyle.ForeColor = bal < 0 ? Color.Crimson
                                      : bal > 0 ? Color.SeaGreen
                                      : Color.Black;
            }
        }

        private void dgvTenantPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colPayment.Index) return;

            if (_currentBillId <= 0)
            {
                MessageBox.Show("This room has no bill yet.", "No Bill",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRowView row = dgvTenantPayments.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (row == null) return;

            decimal share = Convert.ToDecimal(row["Share"]);
            decimal pd = Convert.ToDecimal(row["Paid"]);

            if (share <= 0)
            {
                MessageBox.Show("This tenant joined after the bill was generated, so they have no share for this period. They will be billed from the next period.",
                    "Not Billed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (share - pd <= 0)
            {
                MessageBox.Show("This tenant's share is already settled for the period.",
                    "Nothing Due", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int tenantId = Convert.ToInt32(row["TenantId"]);

            using (var pay = new BillingPaymentForm(_roomId, tenantId))
            {
                if (pay.ShowDialog(this) == DialogResult.OK)
                    LoadBilling();   // refresh totals, grid and button captions
            }
        }


        private void btnBackRoomBilling_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            if (parent == null) return;

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is BillingRoomAccountControl)
                {
                    ctrl.Show();
                    ctrl.BringToFront();
                    break;
                }
            }

            parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
