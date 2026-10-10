using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstoneszn.Forms.UserControls.Utilities;

namespace Capstoneszn.Forms.UserControls.Utilities
{
    public partial class AdminElectricityAccount : UserControl
    {
        public AdminElectricityAccount()
        {
            InitializeComponent();
        }

        private void AdminElectricityAccount_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnRecordExpenses_Click(object sender, EventArgs e)
        {
            RecordExpensesForm refForm = new RecordExpensesForm();
            refForm.ShowDialog();
        }
    }
}
