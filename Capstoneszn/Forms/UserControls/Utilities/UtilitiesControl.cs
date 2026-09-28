using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.UtilityForms;

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
        }
    }
}
