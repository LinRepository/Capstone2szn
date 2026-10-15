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
    public partial class EditElectricityRooms : UserControl
    {
        private readonly DateTime _billMonth =
            new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        public EditElectricityRooms()
        {
            InitializeComponent();
            LoadAccounts();
        }
        private void LoadAccounts()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AccountId", typeof(int));
            dt.Columns.Add("Display");

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT ua.AccountID, ua.AccountName, ua.AccountNumber
                                   FROM dbo.UtilityAccounts ua
                                   WHERE ua.BuildingID  = @BuildingId
                                     AND ua.UtilityType = 'Electricity'
                                     AND ua.RoomID IS NOT NULL
                                     AND ua.IsActive    = 1
                                   ORDER BY ua.AccountName;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                                dt.Rows.Add(Convert.ToInt32(dr["AccountID"]),
                                            dr["AccountName"] + "  —  " + dr["AccountNumber"]);
                        }
                    }

                    cbElecAccountNumber.DisplayMember = "Display";
                    cbElecAccountNumber.ValueMember = "AccountId";
                    cbElecAccountNumber.DataSource = dt;
                    cbElecAccountNumber.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading accounts: " + ex.Message);
                }
            }
        }
        public bool Save()
        {
            if (cbElecAccountNumber.SelectedIndex < 0)
            {
                MessageBox.Show("Select an account first.");
                return false;
            }

            if (!decimal.TryParse(txtElectricityAmount.Text.Trim(), out decimal amount) || amount < 0)
            {
                MessageBox.Show("Enter a valid amount.");
                txtElectricityAmount.Focus();
                return false;
            }

            int accountId = Convert.ToInt32(cbElecAccountNumber.SelectedValue);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"IF EXISTS (SELECT 1 FROM dbo.ElectricityCharges
                          WHERE AccountID = @AccountId AND BillMonth = @BillMonth
                            AND Status = 'Paid')
                   SELECT -1;    -- locked: refuse
               ELSE IF EXISTS (SELECT 1 FROM dbo.ElectricityCharges
                               WHERE AccountID = @AccountId AND BillMonth = @BillMonth)
               BEGIN
                   UPDATE dbo.ElectricityCharges
                      SET Amount = @Amount
                    WHERE AccountID = @AccountId AND BillMonth = @BillMonth
                      AND Status = 'Unpaid';
                   SELECT 1;
               END
               ELSE
               BEGIN
                   INSERT INTO dbo.ElectricityCharges
                          (AccountID, BillMonth, Amount, Status)
                   VALUES (@AccountId, @BillMonth, @Amount, 'Unpaid');
                   SELECT 1;
               END";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AccountId", accountId);
                        cmd.Parameters.AddWithValue("@BillMonth", _billMonth);
                        cmd.Parameters.AddWithValue("@Amount", amount);

                        int result = Convert.ToInt32(cmd.ExecuteScalar());
                        if (result == -1)
                        {
                            MessageBox.Show("This bill is already paid and can't be edited.", "Bill locked",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving: " + ex.Message);
                    return false;
                }
            }
        }

        private void cbElecAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbElecAccountNumber.SelectedIndex < 0) return;

            int accountId = Convert.ToInt32(cbElecAccountNumber.SelectedValue);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT r.RoomNumber, c.Amount, c.Status
                           FROM dbo.UtilityAccounts ua
                           JOIN dbo.Rooms r ON r.RoomId = ua.RoomID
                           LEFT JOIN dbo.ElectricityCharges c
                                  ON c.AccountID = ua.AccountID
                                 AND c.BillMonth = @BillMonth
                           WHERE ua.AccountID = @AccountId;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AccountId", accountId);
                        cmd.Parameters.AddWithValue("@BillMonth", _billMonth);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtRoomNumber.Text = dr["RoomNumber"].ToString();

                                txtElectricityAmount.Text = dr["Amount"] == DBNull.Value
                                    ? ""
                                    : Convert.ToDecimal(dr["Amount"]).ToString("0.00");

                                // NEW: lock the amount if this month's bill is already paid
                                bool isPaid = dr["Status"] != DBNull.Value
                                              && dr["Status"].ToString() == "Paid";

                                txtElectricityAmount.Enabled = !isPaid;
                                lblEditElectricityAmount.Text = isPaid
                                    ? "Amount (Paid - locked)"
                                    : "Edit Amount";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading account: " + ex.Message);
                }
            }
        }

        private void EditElectricityRooms_Load(object sender, EventArgs e)
        {
            
        }
    }
}
