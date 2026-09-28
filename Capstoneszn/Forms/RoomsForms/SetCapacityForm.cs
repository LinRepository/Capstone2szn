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

namespace Capstoneszn.Forms
{
    public partial class SetCapacityForm : Form
    {


        public SetCapacityForm()
        {
            InitializeComponent();

        }

        private void SetCapacityForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveCapacity_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelCapacity_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nudNewCapacity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
