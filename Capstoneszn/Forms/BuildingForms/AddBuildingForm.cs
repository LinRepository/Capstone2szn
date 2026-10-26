using Capstoneszn.Forms.UserControls.Utilities;
using Capstoneszn.Forms.UtilityForms;   // NEW: WaterAccountHelper, ElectricityAccountHelper
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
            // NEW: same limits and key filter as Settings → Utilities Accounts
            txtWaterAccountName.MaxLength = WaterAccountHelper.NameMaxLength;
            txtWaterAccountNumber.MaxLength = WaterAccountHelper.NumberMaxLength;
            txtElecAccountName.MaxLength = ElectricityAccountHelper.NameMaxLength;
            txtElecAccountNumber.MaxLength = ElectricityAccountHelper.NumberMaxLength;
            txtWaterAccountNumber.KeyPress += WaterAccountHelper.AccountNumberKeyPress;
            txtElecAccountNumber.KeyPress += WaterAccountHelper.AccountNumberKeyPress;
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

            //Utilities
            // NEW ── 1b. Utility accounts (optional now; can be set up later in Settings) ──
            string waterName = txtWaterAccountName.Text.Trim();
            string waterNumber = txtWaterAccountNumber.Text.Trim();
            string elecName = txtElecAccountName.Text.Trim();
            string elecNumber = txtElecAccountNumber.Text.Trim();

            bool waterGiven = waterName.Length > 0 || waterNumber.Length > 0;
            bool elecGiven = elecName.Length > 0 || elecNumber.Length > 0;

            // Started filling one in → it must be complete and valid (same rules as Settings)
            if (waterGiven && !WaterAccountHelper.Validate(waterName, waterNumber, out string waterError))
            {
                MessageBox.Show("Water account: " + waterError, "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                (waterName.Length == 0 ? txtWaterAccountName : txtWaterAccountNumber).Focus();
                return;
            }
            if (elecGiven && !ElectricityAccountHelper.Validate(elecName, elecNumber, out string elecError))
            {
                MessageBox.Show("Electricity account: " + elecError, "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                (elecName.Length == 0 ? txtElecAccountName : txtElecAccountNumber).Focus();
                return;
            }

            // Water account numbers can't be shared between buildings
            if (waterGiven)
            {
                bool inUse;
                try
                {
                    inUse = WaterAccountHelper.IsActiveNumberInUse(waterNumber);
                }
                catch (SqlException checkEx)
                {
                    MessageBox.Show("Unable to check the water account number.\n\n" + checkEx.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (inUse)
                {
                    MessageBox.Show($"Water account number {waterNumber} is already used by another building.", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWaterAccountNumber.Focus();
                    return;
                }
            }

            // Skipped one or both → confirm "set up later"
            if (!waterGiven || !elecGiven)
            {
                string skipped = !waterGiven && !elecGiven ? "water and electricity accounts"
                               : !waterGiven ? "water account"
                                             : "electricity account";

                if (MessageBox.Show(
                        $"The {skipped} will not be set up now.\n\n" +
                        "You can set it up later in Settings → Utilities Accounts. " +
                        "Water bills can't be added until the water account is set up.\n\n" +
                        "Continue creating the building?",
                        "Set up later", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }
            // END of Utilities validation

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

                    // NEW Step C: utility accounts, saved with the building (all or nothing)
                    if (waterGiven)
                        WaterAccountHelper.Save(conn, transaction, newBuildingId, waterName, waterNumber);
                    if (elecGiven)
                        ElectricityAccountHelper.Save(conn, transaction, newBuildingId, elecName, elecNumber);

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
