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

namespace Capstoneszn
{
    public partial class AddBuildingForm : Form
    {
        public AddBuildingForm()
        {
            InitializeComponent();
        }

        private void AddBuildingForm_Load(object sender, EventArgs e)
        {
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string buildingName = txtBuildingName.Text.Trim();
            int numberOfFloors = (int)nudFloors.Value;

            // 1. Validation
            if (string.IsNullOrEmpty(buildingName) || numberOfFloors <= 0)
            {
                MessageBox.Show("Please enter a valid building name and at least 1 floor.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Database Transaction
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Step A: Insert Building
                    // FloorCount is stored on the building as well as expanded into Floors
                    // rows. Floors cannot be added after creation, so this number is the
                    // permanent record of how tall the building is.
                    string insertBuildingQuery =
                        "INSERT INTO Buildings (BuildingName, FloorCount) " +
                        "OUTPUT INSERTED.BuildingId VALUES (@bName, @fCount);";
                    int newBuildingId;

                    using (SqlCommand cmd = new SqlCommand(insertBuildingQuery, conn, transaction))
                    {
                        cmd.Parameters.Add("@bName", SqlDbType.NVarChar, 100).Value = buildingName;
                        cmd.Parameters.Add("@fCount", SqlDbType.Int).Value = numberOfFloors;
                        newBuildingId = (int)cmd.ExecuteScalar();
                    }

                    // Step B: Loop to insert Floors
                    string insertFloorQuery = "INSERT INTO Floors (BuildingId, FloorNumber) VALUES (@bId, @fNum);";
                    using (SqlCommand cmd = new SqlCommand(insertFloorQuery, conn, transaction))
                    {
                        cmd.Parameters.Add("@bId", SqlDbType.Int);
                        cmd.Parameters.Add("@fNum", SqlDbType.Int);

                        for (int i = 1; i <= numberOfFloors; i++)
                        {
                            cmd.Parameters["@bId"].Value = newBuildingId;
                            cmd.Parameters["@fNum"].Value = i;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    // 3. Signal Success and Close
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error saving building: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
