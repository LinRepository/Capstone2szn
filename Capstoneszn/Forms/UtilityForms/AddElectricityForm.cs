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
    public partial class AddElectricityForm : Form
    {
        private bool _noRoomsAvailable = false;
        public AddElectricityForm()
        {
            InitializeComponent();
        }
        private void LoadAvailableRooms()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RoomId", typeof(int));
            dt.Columns.Add("RoomNumber");

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // rooms in this building that don't already have an electricity account
                    string sql = @"SELECT r.RoomId, r.RoomNumber
                                   FROM dbo.Rooms  r
                                   JOIN dbo.Floors f ON f.FloorId = r.FloorId
                                   WHERE f.BuildingId = @BuildingId
                                     AND r.IsArchived = 0
                                     AND NOT EXISTS (SELECT 1
                                                     FROM dbo.UtilityAccounts ua
                                                     WHERE ua.RoomID      = r.RoomId
                                                       AND ua.UtilityType = 'Electricity')
                                   ORDER BY r.RoomNumber;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                                dt.Rows.Add(Convert.ToInt32(dr["RoomId"]),
                                            dr["RoomNumber"].ToString());
                        }
                    }

                    cbAssignedRooms.DisplayMember = "RoomNumber";
                    cbAssignedRooms.ValueMember = "RoomId";
                    cbAssignedRooms.DataSource = dt;
                    cbAssignedRooms.SelectedIndex = -1;

                    if (dt.Rows.Count == 0)
                        _noRoomsAvailable = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rooms: " + ex.Message);
                }
            }
        }
        private void AddElectricityForm_Load(object sender, EventArgs e)
        {
            LoadAvailableRooms();

            if (_noRoomsAvailable)
            {
                MessageBox.Show("Every room already has an electricity account.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = txtAccountName.Text.Trim();
            string number = txtAccountNumber.Text.Trim();

            if (name.Length == 0)
            {
                MessageBox.Show("Enter an account name.");
                txtAccountName.Focus();
                return;
            }

            if (number.Length == 0)
            {
                MessageBox.Show("Enter an account number.");
                txtAccountNumber.Focus();
                return;
            }

            if (cbAssignedRooms.SelectedIndex < 0)
            {
                MessageBox.Show("Select the room this account belongs to.");
                cbAssignedRooms.Focus();
                return;
            }

            int roomId = Convert.ToInt32(cbAssignedRooms.SelectedValue);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string sql = @"INSERT INTO dbo.UtilityAccounts
                                      (BuildingID, UtilityType, AccountName,
                                       AccountNumber, RoomID)
                                   VALUES
                                      (@BuildingId, 'Electricity', @Name,
                                       @Number, @RoomId);";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@BuildingId", Session.BuildingId);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Number", number);
                        cmd.Parameters.AddWithValue("@RoomId", roomId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Electricity account added.");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding account: " + ex.Message);
                }
            }
        }
    }
}
