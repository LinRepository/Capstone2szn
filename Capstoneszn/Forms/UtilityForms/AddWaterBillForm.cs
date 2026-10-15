using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UtilityForms
{
    public partial class AddWaterBillForm : Form
    {
        public AddWaterBillForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // --- validate ---
            if (!decimal.TryParse(txtTotalAmount.Text.Trim(), out decimal total) || total <= 0)
            {
                MessageBox.Show("Enter a valid total bill amount.");
                txtTotalAmount.Focus();
                return;
            }

            DateTime start = dtpBillingMonth.Value.Date;
            DateTime end = dtpDueDate.Value.Date;
            DateTime due = dtpDueDate.Value.Date;

            if (end < start)
            {
                MessageBox.Show("The billing period's end date cannot be before its start date.");
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // --- 1. active tenants in this building ---
                        var tenantIds = new System.Collections.Generic.List<int>();
                        var roomIds = new System.Collections.Generic.List<int>();

                        string tenantSql = @"SELECT t.TenantId, t.RoomId
                                             FROM dbo.Tenants t
                                             JOIN dbo.Rooms  r ON r.RoomId  = t.RoomId
                                             JOIN dbo.Floors f ON f.FloorId = r.FloorId
                                             WHERE f.BuildingId = @BuildingId
                                               AND t.Status     = 'Active'
                                               AND t.IsArchived = 0;";

                        using (SqlCommand cmd = new SqlCommand(tenantSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    tenantIds.Add(Convert.ToInt32(dr["TenantId"]));
                                    roomIds.Add(Convert.ToInt32(dr["RoomId"]));
                                }
                            }
                        }

                        if (tenantIds.Count == 0)
                        {
                            tran.Rollback();
                            MessageBox.Show("There are no active tenants to split this bill between.");
                            return;
                        }

                        int shares = tenantIds.Count + 1;                       // tenants + owner
                        decimal perShare = Math.Floor(total / shares * 100) / 100m;  // owner absorbs the remainder

                        // --- 2. the bill ---
                        int billId;

                        string billSql = @"INSERT INTO dbo.WaterBills
                                              (BuildingID, BillingPeriodStart, BillingPeriodEnd,
                                               DueDate, TotalAmount, TotalShares, RecordedBy)
                                           VALUES
                                              (@BuildingId, @Start, @End,
                                               @Due, @Total, @Shares, @RecordedBy);
                                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        using (SqlCommand cmd = new SqlCommand(billSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);
                            cmd.Parameters.AddWithValue("@Start", start);
                            cmd.Parameters.AddWithValue("@End", end);
                            cmd.Parameters.AddWithValue("@Due", due);
                            cmd.Parameters.AddWithValue("@Total", total);
                            cmd.Parameters.AddWithValue("@Shares", shares);
                            cmd.Parameters.AddWithValue("@RecordedBy", Session.UserId);

                            billId = (int)cmd.ExecuteScalar();
                        }

                        // --- 3. one charge per tenant ---
                        string chargeSql = @"INSERT INTO dbo.TenantWaterCharges
                                                (WaterBillID, TenantID, RoomID, Shares, Amount)
                                             VALUES
                                                (@BillId, @TenantId, @RoomId, 1, @Amount);";

                        for (int i = 0; i < tenantIds.Count; i++)
                        {
                            using (SqlCommand cmd = new SqlCommand(chargeSql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@BillId", billId);
                                cmd.Parameters.AddWithValue("@TenantId", tenantIds[i]);
                                cmd.Parameters.AddWithValue("@RoomId", roomIds[i]);
                                cmd.Parameters.AddWithValue("@Amount", perShare);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();

                        decimal ownerShare = total - (perShare * tenantIds.Count);
                        MessageBox.Show(
                            $"Bill saved.\n\n{tenantIds.Count} tenant(s) at {perShare:₱#,##0.00} each."
                            + $"\nOwner's share: {ownerShare:₱#,##0.00}");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error saving bill: " + ex.Message);
                    }
                }
            }
        }

        private void AddWaterBillForm_Load(object sender, EventArgs e)
        {

        }

    }
}
