using Capstoneszn.Forms.UserControls.Utilities;
using Capstoneszn.Forms.UtilityForms;
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
    public partial class UtilitiesControl : UserControl
    {
        public UtilitiesControl()
        {
            InitializeComponent();


        }

        private void btnEditWaterBill_Click(object sender, EventArgs e)
        {
            EditWaterBillForm ewb = new EditWaterBillForm();
            ewb.ShowDialog(this);
        }

        private void btnEditElectricity_Click(object sender, EventArgs e)
        {
            using var frm = new EditElectricityForm();
            frm.ShowDialog(this);
        }

        private void UtilitiesControl_Load(object sender, EventArgs e)
        {
            var admin = new AdminElectricityAccount { Dock = DockStyle.Fill };
            pnlAdminAccount.Controls.Add(admin);
        }

        private void btnAddElectricity_Click(object sender, EventArgs e)
        {
            AddElectricityForm aef = new AddElectricityForm();
            aef.ShowDialog(this);
        }

        private void btnOtherAdd_Click(object sender, EventArgs e)
        {
            AddOtherForm aof = new AddOtherForm();
            aof.ShowDialog(this);
        }

        private void btnAddWaterBill_Click(object sender, EventArgs e)
        {
            AddWaterBillForm awf = new AddWaterBillForm();
            awf.ShowDialog(this);
        }
    }
}
