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
    /// Adds one material to a Pending issue. Closes with DialogResult.OK
    /// after a successful save so ViewMaterialsForm reloads its grid.
    /// </summary>
    /// 

    public partial class AddMaterialForm : Form
    {
        private readonly int _issueId;

        public AddMaterialForm(int issueId)
        {
            InitializeComponent();
            _issueId = issueId;


            AcceptButton = btnAddMaterial;
            CancelButton = btnCancelMaterial;

        }

        private void AddMaterialForm_Load(object sender, EventArgs e)
        {

        }



        private void Warn(string message, Control focus)
        {
            MessageBox.Show(message, "Missing Information",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus.Focus();
        }

        private void btnCancelMaterial_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            string name = txtMaterialName.Text.Trim();
            if (name.Length == 0)
            {
                Warn("Please enter the material name.", txtMaterialName);
                return;
            }

            int quantity = (int)nudQuantity.Value;
            if (quantity < 1)
            {
                Warn("Quantity must be at least 1.", nudQuantity);
                return;
            }

            decimal unitPrice = nudUnitPrice.Value;
            if (unitPrice <= 0m)
            {
                Warn("Unit price must be greater than zero.", nudUnitPrice);
                return;
            }

            try
            {
                MaintenanceService.AddMaterial(_issueId, name, quantity, unitPrice);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Material Not Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The material was not added.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
