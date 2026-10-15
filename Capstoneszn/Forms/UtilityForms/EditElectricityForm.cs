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
    public partial class EditElectricityForm : Form
    {
        public EditElectricityForm()
        {
            InitializeComponent();

            RadioBtnRooms.CheckedChanged += Mode_CheckedChanged;
            RadioBtnAdmin.CheckedChanged += Mode_CheckedChanged;


        }

        private void EditElectricityForm_Load(object sender, EventArgs e)
        {
            RadioBtnRooms.Checked = true;
        }
        private void Mode_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not RadioButton rb || !rb.Checked) return;

            UserControl editor = rb == RadioBtnRooms
                ? new EditElectricityRooms()
                : new EditElectricityAdmin();

            pnlElectricityContent.Controls.Clear();
            editor.Dock = DockStyle.Fill;
            pnlElectricityContent.Controls.Add(editor);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (pnlElectricityContent.Controls.Count == 0) return;

            bool saved = pnlElectricityContent.Controls[0] switch
            {
                EditElectricityRooms rooms => rooms.Save(),
                EditElectricityAdmin admin => admin.Save(),
                _ => false
            };

            if (!saved) return;

            MessageBox.Show("Saved.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
