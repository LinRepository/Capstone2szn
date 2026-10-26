using Capstoneszn.Forms;
using Capstoneszn.Forms.SettingsForms;
using Capstoneszn.Forms.UserControls.Utilities;
using Capstoneszn.Forms.UtilityForms;   // NEW: WaterAccountHelper
using Microsoft.Data.SqlClient;         // NEW
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls.Settings
{
    public partial class ElectricWaterAccountControl : UserControl
    {
        public ElectricWaterAccountControl()
        {
            InitializeComponent();
            Load += (s, e) => { LoadElectricityAccount(); LoadWaterAccount(); };   // NEW
        }
        // NEW: fills the Water card from the database
        private void LoadWaterAccount()
        {
            WaterAccountInfo? account = null;
            try
            {
                account = WaterAccountHelper.GetActive(Session.BuildingId);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to load the water account.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblWaterValueName.Text = account?.AccountName ?? "Not set yet";
            lblWaterValueNumber.Text = account?.AccountNumber ?? "Not set yet";
            btnEditWaterAccount.Text = account == null ? "Set Up" : "Edit";
        }
        // NEW: fills the Electricity card from the database
        private void LoadElectricityAccount()
        {
            ElectricityAdminAccountInfo? account = null;
            try
            {
                account = ElectricityAccountHelper.GetAdmin(Session.BuildingId);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to load the electricity account.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblElecValueName.Text = account == null ? "Not set yet"
                                  : account.AccountName.Length == 0 ? "—" : account.AccountName;
            lblElecValueNumber.Text = account == null ? "Not set yet"
                                    : account.AccountNumber.Length == 0 ? "—" : account.AccountNumber;
            btnEditElectAccount.Text = account == null ? "Set Up" : "Edit";
        }

        private void btnBackElectricWater_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }

        private void btnAddElectricityAccount_Click(object sender, EventArgs e)
        {
            AddUtilityAccountForm addutilaccountform = new AddUtilityAccountForm();
            addutilaccountform.ShowDialog();
        }

        private void btnAddWaterAccount_Click(object sender, EventArgs e)
        {
            AddUtilityAccountForm addutilaccountform = new AddUtilityAccountForm();
            addutilaccountform.ShowDialog();
        }

        private void flpElectricityAccounts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditElectAccount_Click(object sender, EventArgs e)
        {
            // NEW: pass the building, refresh the card only if something was saved
            using var editElectricityAccount = new EditElectricityAccount(Session.BuildingId);
            if (editElectricityAccount.ShowDialog(this) == DialogResult.OK)
                LoadElectricityAccount();
        }

        private void btnEditWaterAccount_Click(object sender, EventArgs e)
        {
            // NEW: pass the building, refresh the card only if something was saved
            using var editWaterAccount = new EditWaterAccount(Session.BuildingId);
            if (editWaterAccount.ShowDialog(this) == DialogResult.OK)
                LoadWaterAccount();
        }
    }
}
