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

namespace Capstoneszn.Forms.BuildingForms
{
    public partial class BuildingSelection : Form
    {
        public BuildingSelection()
        {
            InitializeComponent();
        }

        private void BuildingSelection_Load(object sender, EventArgs e)
        {
            LoadBuildings();
        }

        private void LoadBuildings()
        {
            // 1. Clear existing cards EXCEPT the pnlAddBuilding
            for (int i = flpBuildings.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = flpBuildings.Controls[i];
                if (ctrl.Name != "pnlAddBuilding")
                {
                    flpBuildings.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }

            // 2. Fetch and populate BuildingCards
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    // OLD: every user saw every building
                    // string query = "SELECT BuildingId, BuildingName FROM Buildings ORDER BY CreatedDate ASC";

                    // ADDED (caretaker restrictions):
                    //   Landlord  -> all buildings (same as before)
                    //   Caretaker -> only the building they were added to (Employees.BuildingId)
                    string query = Session.IsLandlord
                        ? "SELECT BuildingId, BuildingName FROM Buildings ORDER BY CreatedDate ASC"
                        : @"SELECT b.BuildingId, b.BuildingName
                            FROM   Users u
                            JOIN   Employees e ON e.EmployeeId = u.EmployeeId
                            JOIN   Buildings b ON b.BuildingId = e.BuildingId
                            WHERE  u.UserId = @uid";

                    // OLD:
                    // using (SqlCommand cmd = new SqlCommand(query, conn))
                    // using (SqlDataReader reader = cmd.ExecuteReader())
                    // {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // ADDED: the caretaker query needs the user id (the landlord query ignores it)
                        cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Session.UserId;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BuildingCard card = new BuildingCard();
                                card.BuildingId = reader.GetInt32(0);
                                card.BuildingName = reader.GetString(1);


                                card.CardClicked += BuildingCard_Clicked;

                                flpBuildings.Controls.Add(card);
                            }
                        }
                    }

                    // 3. Ensure the Add Building panel always stays at the very end of the flow layout
                    flpBuildings.Controls.SetChildIndex(pnlAddBuilding, flpBuildings.Controls.Count);

                    // ADDED (caretaker restrictions): only the landlord can add a building
                    pnlAddBuilding.Visible = Session.IsLandlord;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading buildings: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblPlusBuilding_Click(object sender, EventArgs e)
        {

            if (!Session.IsLandlord) return;   // ADDED: landlord only (panel is also hidden)

            using (AddBuildingForm addForm = new AddBuildingForm())
            {

                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBuildings();
                }
            }

        }

        // This triggers when ANY dynamically created BuildingCard is clicked
        private void BuildingCard_Clicked(object sender, EventArgs e)
        {

            if (sender is not BuildingCard clickedCard) return;

            // ADDED (caretaker restrictions): a caretaker only ever gets their own
            // building's card, so this can't normally happen - checked anyway.
            if (!Session.IsLandlord && !IsCaretakerBuilding(clickedCard.BuildingId))
            {
                MessageBox.Show("You can only open the building you are assigned to.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Session.BuildingId = clickedCard.BuildingId;

            MainForm mainForm = new MainForm(clickedCard.BuildingId, clickedCard.BuildingName);
            mainForm.FormClosed += (s2, e2) => this.Close();
            mainForm.Show();
            this.Hide();

        }

        // ADDED (caretaker restrictions): is this the caretaker's assigned building?
        private static bool IsCaretakerBuilding(int buildingId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*)
                    FROM   Users u
                    JOIN   Employees e ON e.EmployeeId = u.EmployeeId
                    WHERE  u.UserId = @uid AND e.BuildingId = @bid;", conn))
                {
                    cmd.Parameters.Add("@uid", SqlDbType.Int).Value = Session.UserId;
                    cmd.Parameters.Add("@bid", SqlDbType.Int).Value = buildingId;
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch
            {
                return false;   // if in doubt, don't let them in
            }
        }

        private void flpBuildings_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
