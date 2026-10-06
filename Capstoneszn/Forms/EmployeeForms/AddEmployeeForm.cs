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

namespace Capstoneszn.Forms.EmployeeForms
{
    public partial class AddEmployeeForm : Form
    {
        private readonly int _buildingId;
        public AddEmployeeForm(int buildingId)
        {
            InitializeComponent();
            _buildingId = buildingId;

            txtAddPassword.UseSystemPasswordChar = true;
            txtAddUsername.PlaceholderText = "@Employee1";
            dtpDate.MaxDate = DateTime.Today;
            dtpDate.Value = DateTime.Today;
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fullName = txtAddFullName.Text.Trim();
            string address = txtAddAddress.Text.Trim();
            string username = txtAddUsername.Text.Trim();
            string password = txtAddPassword.Text;
            DateTime dateHired = dtpDate.Value.Date;

            if (!ValidateInput(fullName, address, username, password)) return;

            btnAdd.Enabled = false;
            try
            {
                InsertEmployee(fullName, address, dateHired, username, password);

                MessageBox.Show($"Employee \"{fullName}\" added successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DuplicateNameException)
            {
                MessageBox.Show("That username is already taken. Please choose another.",
                    "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddUsername.Focus();
                txtAddUsername.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add the employee.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAdd.Enabled = true;
            }
        }

        private bool ValidateInput(string fullName, string address, string username, string password)
        {
            if (fullName.Length == 0)
            {
                MessageBox.Show("Full name is required.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddFullName.Focus();
                return false;
            }
            if (address.Length == 0)
            {
                MessageBox.Show("Address is required.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddAddress.Focus();
                return false;
            }
            if (username.Length < 4 || username.Contains(" "))
            {
                MessageBox.Show("Username must be at least 4 characters and contain no spaces.",
                    "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddUsername.Focus();
                return false;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Weak Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddPassword.Focus();
                return false;
            }
            return true;
        }

        private void InsertEmployee(string fullName, string address, DateTime dateHired,
                                    string username, string password)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. username must be free
                        using (SqlCommand chk = new SqlCommand(
                            "SELECT COUNT(*) FROM Users WHERE Username = @Username", conn, tx))
                        {
                            chk.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                            if ((int)chk.ExecuteScalar() > 0)
                                throw new DuplicateNameException();
                        }

                        // 2. Employees row — grab the new identity
                        int employeeId;
                        const string insertEmp = @"
                            INSERT INTO Employees
                                (BuildingID, FullName, Address, DateHired, EmploymentStatus, SalaryPerPeriod)
                            VALUES
                                (@BuildingID, @FullName, @Address, @DateHired, 'Active', 0);
                            SELECT CAST(SCOPE_IDENTITY() AS int);";

                        using (SqlCommand cmd = new SqlCommand(insertEmp, conn, tx))
                        {
                            cmd.Parameters.Add("@BuildingID", SqlDbType.Int).Value = _buildingId;
                            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = fullName;
                            cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = address;
                            cmd.Parameters.Add("@DateHired", SqlDbType.Date).Value = dateHired;
                            employeeId = (int)cmd.ExecuteScalar();
                        }

                        // 3. Users row linked to that employee
                        const string insertUser = @"
                            INSERT INTO Users (Username, Password, Role, Name, EmployeeID)
                            VALUES (@Username, @Password, 'Employee', @Name, @EmployeeID);";

                        using (SqlCommand cmd = new SqlCommand(insertUser, conn, tx))
                        {
                            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
                            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = fullName;
                            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employeeId;
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
