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

namespace Capstoneszn.Forms
{
    public partial class ConfirmPaymentForm : Form
    {

        private int _roomId;
        private string _tenantName;
        private string _contactNumber;
        private DateTime _moveInDate;

        private DateTime _paymentDate;
        private string _category;
        private string _paymentType;
        private string _method;
        private decimal _amount;
        private string _refNumber;
        private string _remarks;
        public ConfirmPaymentForm(int roomId, string tenantName, string contactNumber, DateTime moveInDate,
            DateTime paymentDate, string category, string paymentType, string method,
            decimal amount, string refNumber, string remarks)
        {
            InitializeComponent();

            // Store data
            _roomId = roomId; _tenantName = tenantName; _contactNumber = contactNumber; _moveInDate = moveInDate;
            _paymentDate = paymentDate; _category = category; _paymentType = paymentType;
            _method = method; _amount = amount; _refNumber = refNumber; _remarks = remarks;

            // Populate your confirmation labels
            lblConfirmDateValue.Text = _paymentDate.ToString("MMM dd, yyyy");
            lblConfirmCategoryValue.Text = _category;
            lblConfirmPaymentMethodValue.Text = _method;
            lblConfirmAmountValue.Text = $"₱{_amount:0.00}";
            lblConfirmPaymentTypeValue.Text = _paymentType;
            lblConfirmReferenceValue.Text = string.IsNullOrEmpty(_refNumber) ? "N/A" : _refNumber;
            lblConfirmRemarksValue.Text = string.IsNullOrEmpty(_remarks) ? "None" : _remarks;
        }

        private void ConfirmPaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelPayment_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Step 1: Insert the Tenant 
                    string insertTenantQuery = @"
                INSERT INTO Tenants (RoomId, TenantName, ContactNumber, DateOccupied) 
                OUTPUT INSERTED.TenantId
                VALUES (@roomId, @name, @contact, @date)";

                    int newTenantId = 0;
                    using (SqlCommand cmdTenant = new SqlCommand(insertTenantQuery, conn))
                    {
                        cmdTenant.Parameters.AddWithValue("@roomId", _roomId);
                        cmdTenant.Parameters.AddWithValue("@name", _tenantName);
                        cmdTenant.Parameters.AddWithValue("@contact", _contactNumber);
                        cmdTenant.Parameters.AddWithValue("@date", _moveInDate);

                        // ExecuteScalar gets the generated TenantId
                        newTenantId = (int)cmdTenant.ExecuteScalar();
                    }

                    // Step 2: Insert the Payment Record (Removed RoomId to match your database schema)
                    string insertPaymentQuery = @"
                INSERT INTO Payments (TenantId, Amount, PaymentDate, PaymentMethod, Category, PaymentType, ReferenceNumber, Remarks)
                VALUES (@tId, @amount, @pDate, @method, @cat, @pType, @ref, @remarks)";

                    using (SqlCommand cmdPayment = new SqlCommand(insertPaymentQuery, conn))
                    {
                        cmdPayment.Parameters.AddWithValue("@tId", newTenantId);
                        cmdPayment.Parameters.AddWithValue("@amount", _amount);
                        cmdPayment.Parameters.AddWithValue("@pDate", _paymentDate);
                        cmdPayment.Parameters.AddWithValue("@method", _method);
                        cmdPayment.Parameters.AddWithValue("@cat", _category);
                        cmdPayment.Parameters.AddWithValue("@pType", _paymentType);
                        cmdPayment.Parameters.AddWithValue("@ref", _refNumber);
                        cmdPayment.Parameters.AddWithValue("@remarks", _remarks);
                        cmdPayment.ExecuteNonQuery();
                    }

                    // Step 3: Update the Room's status to Occupied
                    string updateRoomQuery = "UPDATE Rooms SET Status = 'Occupied' WHERE RoomId = @roomId";
                    using (SqlCommand cmdUpdate = new SqlCommand(updateRoomQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@roomId", _roomId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Payment verified! {_tenantName} has successfully moved in.", "Move-In Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing move-in: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
