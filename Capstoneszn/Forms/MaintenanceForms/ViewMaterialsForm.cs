using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms
{
    /// <summary>
    /// Lists one issue's materials and their total.
    /// While the issue is Pending: Add Material and Remove Material work.
    /// Once it is Complete: read-only, because the total already became
    /// a bill or an expense.
    /// </summary>
    /// 

    public partial class ViewMaterialsForm : Form
    {

        private readonly int _issueId;
        private bool _isPending;

        public ViewMaterialsForm(int issueId)
        {
            InitializeComponent();

            _issueId = issueId;

            CancelButton = btnClose;
        }

        private void ViewMaterialsForm_Load(object sender, EventArgs e)
        {
            MaintenanceIssueHeader header;
            try
            {
                header = MaintenanceService.GetIssueHeader(_issueId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load the issue.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (header == null)
            {
                MessageBox.Show("This issue no longer exists.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            _isPending = header.IsPending;
            lblMaterialsContext.Text = "Room " + header.RoomNumber + " - " + header.IssueTitle;

            btnAddMaterial.Enabled = _isPending;
            btnRemoveMaterial.Enabled = _isPending;

            LoadMaterials();
        }

        /// <summary>
        /// Refills the grid. Each row's Tag holds its MaterialId, so Remove
        /// knows exactly which row to delete without a hidden column.
        /// </summary>
        private void LoadMaterials()
        {
            List<MaintenanceMaterial> materials;
            try
            {
                materials = MaintenanceService.GetMaterials(_issueId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load materials.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvMaterials.Rows.Clear();
            foreach (MaintenanceMaterial m in materials)
            {
                int index = dgvMaterials.Rows.Add(
                    m.MaterialName,
                    m.Quantity,
                    Peso(m.UnitPrice),
                    Peso(m.TotalCost));
                dgvMaterials.Rows[index].Tag = m.MaterialId;
            }

            decimal total = materials.Sum(m => m.TotalCost);
            lblMaterialsTitle.Text = materials.Count == 0
                ? "Materials - none added yet"
                : "Materials - Total " + Peso(total);

            btnRemoveMaterial.Enabled = _isPending && materials.Count > 0;
        }




        private static string Peso(decimal amount) => "₱" + amount.ToString("N2");

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnClose.Click += (s, e) => Close();
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            using (var form = new AddMaterialForm(_issueId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadMaterials();
            }
        }

        private void btnRemoveMaterial_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.SelectedRows.Count == 0 || !(dgvMaterials.SelectedRows[0].Tag is int materialId))
            {
                MessageBox.Show("Select the material to remove.", "No Material Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = Convert.ToString(dgvMaterials.SelectedRows[0].Cells[colMaterialName.Index].Value);

            if (MessageBox.Show("Remove \"" + name + "\" from this issue?",
                    "Remove Material", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
                return;

            try
            {
                MaintenanceService.RemoveMaterial(materialId);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Removed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The material was not removed.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadMaterials();
        }
    }
}
