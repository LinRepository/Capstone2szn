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
                    string query = "SELECT BuildingId, BuildingName FROM Buildings ORDER BY CreatedDate ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
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

                    // 3. Ensure the Add Building panel always stays at the very end of the flow layout
                    flpBuildings.Controls.SetChildIndex(pnlAddBuilding, flpBuildings.Controls.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading buildings: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblPlusBuilding_Click(object sender, EventArgs e)
        {
            
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
            BuildingCard clickedCard = sender as BuildingCard;

            if (clickedCard != null)
            {
                int selectedBuildingId = clickedCard.BuildingId;
                string selectedBuildingName = clickedCard.BuildingName;

                
                MainForm mainForm = new MainForm(selectedBuildingId, selectedBuildingName);
                mainForm.Show();
                this.Hide();
            }
        }

        private void flpBuildings_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
