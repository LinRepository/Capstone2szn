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

namespace Capstoneszn.Forms.UtilityForms
{
    public partial class EditWaterBillForm : Form
    {
        private int _billId = 0;
        public EditWaterBillForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_billId == 0) return;

            if (!decimal.TryParse(txtTotalBill.Text.Trim(), out decimal total) || total <= 0)
            {
                MessageBox.Show("Enter a valid total bill amount.");
                txtTotalBill.Focus();
                return;
            }

            DateTime start = dtpStartBillingPeriod.Value.Date;
            DateTime end = dtpEndBillingPeriod.Value.Date;
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
                        // how many charges, and how many already settled?
                        int chargeCount = 0, paidCount = 0;

                        string countSql = @"SELECT COUNT(*) AS Total,
                                           SUM(CASE WHEN Status = 'Paid' THEN 1 ELSE 0 END) AS Paid
                                    FROM dbo.TenantWaterCharges
                                    WHERE WaterBillID = @BillId;";

                        using (SqlCommand cmd = new SqlCommand(countSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@BillId", _billId);

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    chargeCount = Convert.ToInt32(dr["Total"]);
                                    paidCount = dr["Paid"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Paid"]);
                                }
                            }
                        }

                        if (chargeCount == 0)
                        {
                            tran.Rollback();
                            MessageBox.Show("This bill has no tenant charges to recalculate.");
                            return;
                        }

                        int shares = chargeCount + 1;                                 // tenants + owner
                        decimal perShare = Math.Floor(total / shares * 100) / 100m;

                        if (paidCount > 0)
                        {
                            string warn = $"{paidCount} charge(s) on this bill are already marked paid.\n\n"
                                        + $"Their amount will change to {perShare:₱#,##0.00}. Continue?";

                            if (MessageBox.Show(warn, "Already paid", MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning) != DialogResult.Yes)
                            {
                                tran.Rollback();
                                return;
                            }
                        }

                        string billSql = @"UPDATE dbo.WaterBills
                                      SET BillingPeriodStart = @Start,
                                          BillingPeriodEnd   = @End,
                                          DueDate            = @Due,
                                          TotalAmount        = @Total,
                                          TotalShares        = @Shares
                                    WHERE WaterBillID = @BillId;";

                        using (SqlCommand cmd = new SqlCommand(billSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Start", start);
                            cmd.Parameters.AddWithValue("@End", end);
                            cmd.Parameters.AddWithValue("@Due", due);
                            cmd.Parameters.AddWithValue("@Total", total);
                            cmd.Parameters.AddWithValue("@Shares", shares);
                            cmd.Parameters.AddWithValue("@BillId", _billId);
                            cmd.ExecuteNonQuery();
                        }

                        string chargeSql = @"UPDATE dbo.TenantWaterCharges
                                        SET Amount = @Amount
                                      WHERE WaterBillID = @BillId;";

                        using (SqlCommand cmd = new SqlCommand(chargeSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Amount", perShare);
                            cmd.Parameters.AddWithValue("@BillId", _billId);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();

                        decimal ownerShare = total - (perShare * chargeCount);
                        MessageBox.Show(
                            $"Bill updated.\n\n{chargeCount} tenant(s) at {perShare:₱#,##0.00} each."
                            + $"\nOwner's share: {ownerShare:₱#,##0.00}");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error updating bill: " + ex.Message);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditWaterBillForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT TOP 1 WaterBillID, BillingPeriodStart, BillingPeriodEnd,
                                  DueDate, TotalAmount
                           FROM dbo.WaterBills
                           WHERE BuildingID = @BuildingId
                           ORDER BY BillingPeriodEnd DESC;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                _billId = Convert.ToInt32(dr["WaterBillID"]);
                                dtpStartBillingPeriod.Value = Convert.ToDateTime(dr["BillingPeriodStart"]);
                                dtpEndBillingPeriod.Value = Convert.ToDateTime(dr["BillingPeriodEnd"]);
                                dtpDueDate.Value = Convert.ToDateTime(dr["DueDate"]);
                                txtTotalBill.Text = Convert.ToDecimal(dr["TotalAmount"]).ToString("0.00");
                            }
                        }
                    }

                    if (_billId == 0)
                    {
                        MessageBox.Show("There's no water bill to edit yet. Add one first.");
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bill: " + ex.Message);
                }
            }
        }
    }
}
