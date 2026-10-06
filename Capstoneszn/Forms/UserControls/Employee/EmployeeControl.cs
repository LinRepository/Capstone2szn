using Capstoneszn.Forms.EmployeeForms;
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
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
                LoadEmployees();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            using (var form = new AddEmployeeForm(1))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadEmployees();
            }
        }

        private void EmployeeControl_Load(object sender, EventArgs e)
        {

        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void LoadEmployees()
        {
            const string sql = @"
        SELECT  e.EmployeeID,
                e.FullName,
                e.Address,
                e.DateHired,
                e.EmploymentStatus
        FROM    Employees e
        WHERE   e.ArchivedAt IS NULL
        ORDER BY e.FullName;";

            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.Fill(dt);
                }

                dgvEmployee.AutoGenerateColumns = false;
                dgvEmployee.DataSource = null;
                dgvEmployee.Rows.Clear();

                int active = 0;

                foreach (DataRow r in dt.Rows)
                {
                    bool isActive = r["EmploymentStatus"].ToString() == "Active";
                    if (isActive) active++;

                    dgvEmployee.Rows.Add(
                        r["EmployeeID"],
                        r["FullName"],
                        r["Address"],
                        Convert.ToDateTime(r["DateHired"]).ToString("MMM dd, yyyy"),
                        isActive,
                        "Edit",
                        "Archive");
                }

                lblRegisteredEmployeeValue.Text = dt.Rows.Count.ToString();
                lblActiveEmployeeValue.Text = active.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load employees.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
