using Capstoneszn.Forms.UserControls.Utilities;
using Capstoneszn.Forms.UtilityForms;
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

namespace Capstoneszn.UserControls
{
    public partial class UtilitiesControl : UserControl
    {
        
        public UtilitiesControl()
        {
            InitializeComponent();
            
        }
        private void SetupWaterGrid()
        {
            dgvWaterBillData.AutoGenerateColumns = false;
            colWaterRoom.DataPropertyName = "Room";
            colWaterTenant.DataPropertyName = "Tenant";
            colWaterDueDate.DataPropertyName = "DueDate";
            colWaterAmount.DataPropertyName = "Amount";
            colWaterStatus.DataPropertyName = "Status";
        }
        public void LoadWaterTab()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Room");
            dt.Columns.Add("Tenant");
            dt.Columns.Add("DueDate");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Status");

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    int billId = 0;
                    decimal total = 0m;
                    int shares = 0;
                    DateTime due = DateTime.MinValue;

                    string billSql = @"SELECT TOP 1 WaterBillID, TotalAmount, TotalShares, DueDate
                   FROM dbo.WaterBills
                   WHERE BuildingID = @BuildingId
                     AND YEAR(BillingPeriodEnd)  = YEAR(@PickedDate)
                     AND MONTH(BillingPeriodEnd) = MONTH(@PickedDate)
                   ORDER BY BillingPeriodEnd DESC;";

                    using (SqlCommand cmd = new SqlCommand(billSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);
                        cmd.Parameters.AddWithValue("@PickedDate", dtpWaterDate.Value.Date);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                billId = Convert.ToInt32(dr["WaterBillID"]);
                                total = Convert.ToDecimal(dr["TotalAmount"]);
                                shares = Convert.ToInt32(dr["TotalShares"]);
                                due = Convert.ToDateTime(dr["DueDate"]);
                            }
                        }
                    }

                    if (billId == 0)
                    {
                        // 2a. No bill yet — show active tenants with blank charges
                        lblCurrentTotalBillValue.Text = "—";
                        lblTotalSharesValue.Text = "—";

                        string sql = @"SELECT r.RoomNumber, t.FirstName, t.LastName
                               FROM dbo.Tenants t
                               JOIN dbo.Rooms  r ON r.RoomId  = t.RoomId
                               JOIN dbo.Floors f ON f.FloorId = r.FloorId
                               WHERE f.BuildingId = @BuildingId
                                 AND t.Status     = 'Active'
                                 AND t.IsArchived = 0
                               ORDER BY r.RoomNumber, t.LastName;";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    dt.Rows.Add(
                                        dr["RoomNumber"].ToString(),
                                        dr["FirstName"].ToString() + " " + dr["LastName"].ToString(),
                                        "—",
                                        "—",
                                        "No bill");
                                }
                            }
                        }
                    }
                    else
                    {
                        // 2b. Bill exists — every active tenant, charged or not
                        lblCurrentTotalBillValue.Text = total.ToString("₱#,##0.00");
                        lblTotalSharesValue.Text = shares.ToString();

                        string sql = @"SELECT r.RoomNumber, t.FirstName, t.LastName, c.Amount, c.Status
                   FROM dbo.Tenants t
                   JOIN dbo.Rooms  r ON r.RoomId  = t.RoomId
                   JOIN dbo.Floors f ON f.FloorId = r.FloorId
                   LEFT JOIN dbo.TenantWaterCharges c
                          ON c.TenantID = t.TenantId
                         AND c.WaterBillID = @BillId
                   WHERE f.BuildingId = @BuildingId
                     AND t.Status     = 'Active'
                     AND t.IsArchived = 0
                   ORDER BY r.RoomNumber, t.LastName;";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@BillId", billId);
                            cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    bool onBill = dr["Amount"] != DBNull.Value;

                                    dt.Rows.Add(
                                        dr["RoomNumber"].ToString(),
                                        dr["FirstName"].ToString() + " " + dr["LastName"].ToString(),
                                        onBill ? due.ToString("MMM d, yyyy") : "—",
                                        onBill ? Convert.ToDecimal(dr["Amount"]).ToString("₱#,##0.00") : "—",
                                        onBill ? dr["Status"].ToString() : "Not on this bill");
                                }
                            }
                        }
                    }

                    dgvWaterBillData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading water tab: " + ex.Message);
                }
            }
        }
        private void SetupElectricityGrid()
        {
            dgvElectricityBillData.AutoGenerateColumns = false;
            colElectricityRoom.DataPropertyName = "Room";
            colElectricityAccountName.DataPropertyName = "AccountName";
            colElectricityAccountNumber.DataPropertyName = "AccountNumber";
            colElectricityAmount.DataPropertyName = "Amount";
            colElectricityStatus.DataPropertyName = "Status";
        }
        public void LoadElectricityTab()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Room");
            dt.Columns.Add("AccountName");
            dt.Columns.Add("AccountNumber");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Status");
            dt.Columns.Add("ChargeId", typeof(int));
            dt.Columns.Add("AmountValue", typeof(decimal));

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT ua.AccountID, ua.AccountName, ua.AccountNumber,
                        r.RoomNumber, c.Amount, c.Status, c.ChargeID
                        FROM dbo.UtilityAccounts ua
                        JOIN dbo.Rooms r ON r.RoomId = ua.RoomID
                        LEFT JOIN dbo.ElectricityCharges c
                        ON c.AccountID = ua.AccountID
                        AND c.BillMonth = @BillMonth
                        WHERE ua.BuildingID  = @BuildingId
                        AND ua.UtilityType = 'Electricity'
                        AND ua.RoomID IS NOT NULL
                        AND ua.IsActive    = 1
                        ORDER BY r.RoomNumber;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        DateTime picked = dtpElectricityDate.Value.Date;
                        DateTime billMonth = new DateTime(picked.Year, picked.Month, 1);

                        cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);
                        cmd.Parameters.AddWithValue("@BillMonth", billMonth);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                bool billed = dr["Amount"] != DBNull.Value;

                                dt.Rows.Add(
                                    dr["RoomNumber"].ToString(),
                                    dr["AccountName"].ToString(),
                                    dr["AccountNumber"].ToString(),
                                    billed ? Convert.ToDecimal(dr["Amount"]).ToString("₱#,##0.00") : "—",
                                    billed ? dr["Status"].ToString() : "No bill",
                                    billed ? Convert.ToInt32(dr["ChargeID"]) : 0,
                                    billed ? Convert.ToDecimal(dr["Amount"]) : 0m);
                            }
                        }
                    }

                    dgvElectricityBillData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading electricity tab: " + ex.Message);
                }
            }
        }
        private void btnEditWaterBill_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditElectricity_Click(object sender, EventArgs e)
        {
            
        }

        private void UtilitiesControl_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddElectricity_Click(object sender, EventArgs e)
        {
            
        }
        private void btnAddWaterBill_Click(object sender, EventArgs e)
        {
            
        }

        private void dtpWaterDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvElectricityBillData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtpElectricityDate_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvWaterBillData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}