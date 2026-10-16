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
