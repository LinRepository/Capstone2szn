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
    public partial class EditElectricityAdmin : UserControl
    {
        private readonly DateTime _billMonth =
            new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        private int _accountId;
        private bool _isLocked;
        public EditElectricityAdmin()
        {
            InitializeComponent();

            LoadAccount();
        }
        private void LoadAccount()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"SELECT ua.AccountID, ua.AccountName, ua.AccountNumber,
                                          c.Amount, c.Status
                                   FROM dbo.UtilityAccounts ua
                                   LEFT JOIN dbo.ElectricityCharges c
                                          ON c.AccountID = ua.AccountID
                                         AND c.BillMonth = @BillMonth
                                   WHERE ua.BuildingID  = @BuildingId
                                     AND ua.UtilityType = 'Electricity'
                                     AND ua.RoomID IS NULL
                                     AND ua.IsActive    = 1;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);
                        cmd.Parameters.AddWithValue("@BillMonth", _billMonth);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                _accountId = Convert.ToInt32(dr["AccountID"]);
                                txtAdminAccountName.Text = dr["AccountName"].ToString();
                                txtAdminAccountNumber.Text = dr["AccountNumber"].ToString();

                                txtAdminAmount.Text = dr["Amount"] == DBNull.Value
                                    ? ""
                                    : Convert.ToDecimal(dr["Amount"]).ToString("0.00");

                                _isLocked = dr["Status"] != DBNull.Value
                                            && dr["Status"].ToString() == "Paid";

                                txtAdminAmount.Enabled = !_isLocked;
                                label3.Text = _isLocked ? "Amount (Paid - locked)" : "Amount";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading owner account: " + ex.Message);
                }
            }
        }
        public bool Save()
        {
            // 4a. Validate
            if (_accountId == 0)
            {
                MessageBox.Show("No owner electricity account found.");
                return false;
            }

            string name = txtAdminAccountName.Text.Trim();
            string number = txtAdminAccountNumber.Text.Trim();

            if (name.Length == 0 || number.Length == 0)
            {
                MessageBox.Show("Account name and number are both required.");
                return false;
            }

            decimal amount = 0;
            if (!_isLocked &&
                (!decimal.TryParse(txtAdminAmount.Text.Trim(), out amount) || amount < 0))
            {
                MessageBox.Show("Enter a valid amount.");
                txtAdminAmount.Focus();
                return false;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 4b. Name and number — always editable
                        string acctSql = @"UPDATE dbo.UtilityAccounts
                                              SET AccountName = @Name, AccountNumber = @Number
                                            WHERE AccountID = @AccountId;";

                        using (SqlCommand cmd = new SqlCommand(acctSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Number", number);
                            cmd.Parameters.AddWithValue("@AccountId", _accountId);
                            cmd.ExecuteNonQuery();
                        }

                        // 4c. This month's amount — skipped when locked
                        if (!_isLocked)
                        {
                            string chargeSql = @"IF EXISTS (SELECT 1 FROM dbo.ElectricityCharges
                                                            WHERE AccountID = @AccountId AND BillMonth = @BillMonth
                                                              AND Status = 'Paid')
                                                     SELECT -1;
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

                            using (SqlCommand cmd = new SqlCommand(chargeSql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@AccountId", _accountId);
                                cmd.Parameters.AddWithValue("@BillMonth", _billMonth);
                                cmd.Parameters.AddWithValue("@Amount", amount);

                                if (Convert.ToInt32(cmd.ExecuteScalar()) == -1)
                                {
                                    tran.Rollback();
                                    MessageBox.Show("The owner's bill is already paid and can't be edited.",
                                        "Bill locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                        }

                        // 4d. Save both together
                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error saving: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
