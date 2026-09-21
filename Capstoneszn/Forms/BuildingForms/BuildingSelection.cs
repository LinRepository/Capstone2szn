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
            LoadBuildings(); // Load immediately on form launch
        }

        private void BuildingSelection_Load(object sender, EventArgs e)
        {

        }

        private void flpBuildings_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void lblPlusBuilding_Click(object sender, EventArgs e)
        {
            AddBuildingForm addForm = new AddBuildingForm();
            addForm.Show();

            // Hide
            this.Hide();
        }


        public void LoadBuildings()
        {
            // 1. Remove any previously loaded database cards
            for (int i = flpBuildings.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = flpBuildings.Controls[i];
                // Don't delete your static design-time panels
                if (ctrl.Name != "pnlSamplesAddBuilding" && ctrl.Name != "pnlAddBuilding")
                {
                    flpBuildings.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }

            // 2. Fetch buildings from SQL Server
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT BuildingId, BuildingName FROM Buildings ORDER BY BuildingId ASC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int insertionIndex = 0; // Tracks where to insert so they stay in order

                            while (reader.Read())
                            {
                                // 3. Instantiate your custom UserControl
                                BuildingCard card = new BuildingCard();
                                card.BuildingId = Convert.ToInt32(reader["BuildingId"]);
                                card.BuildingName = reader["BuildingName"].ToString();
                                card.Cursor = Cursors.Hand;

                                // Subscribe to the unified click event we created in the UserControl
                                card.CardClicked += BuildingCard_Click;

                                // 4. Inject into FlowLayoutPanel at the correct position
                                flpBuildings.Controls.Add(card);
                                flpBuildings.Controls.SetChildIndex(card, insertionIndex);
                                insertionIndex++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load buildings: " + ex.Message);
                }
            }
        }

        // 5. The click event for when a user selects a generated BuildingCard
        private void BuildingCard_Click(object sender, EventArgs e)
        {
            // Cast the sender specifically to your BuildingCard class
            BuildingCard clickedCard = sender as BuildingCard;
            if (clickedCard != null)
            {
                int buildingId = clickedCard.BuildingId;

                // Instantiate MainForm and pass the selected building's ID into it
                MainForm mainForm = new MainForm(buildingId);
                mainForm.Show();

                // Hide the building selection screen
                this.Hide();
            }
        }

    }
}
