using Capstoneszn.Forms.UserControls.Utilities;
using Capstoneszn.Forms.UtilityForms;
using Microsoft.Data.SqlClient;
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
    public partial class EditElectricityAccount : Form
    {
        private readonly int _buildingId;                    // NEW
        private ElectricityAdminAccountInfo? _current;       // NEW: null = not set up yet
        public EditElectricityAccount()
        {
            InitializeComponent();
        }
        // NEW: the constructor Settings uses
        public EditElectricityAccount(int buildingId) : this()
        {
            _buildingId = buildingId;
            btnCancel.Click += (s, e) => Close();
            txtNewNumber.KeyPress += WaterAccountHelper.AccountNumberKeyPress;
        }

        private void EditElectricityAccount_Load(object sender, EventArgs e)
        {
            if (_buildingId == 0) return;   // NEW: opened without a building (old constructor)

            // NEW
            try
            {
                _current = ElectricityAccountHelper.GetAdmin(_buildingId);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to load the electricity account.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                return;
            }

            txtNewName.MaxLength = ElectricityAccountHelper.NameMaxLength;
            txtNewNumber.MaxLength = ElectricityAccountHelper.NumberMaxLength;

            if (_current == null)
            {
                Text = "Set Up Electricity Account";
                lblCurrentName.Text = "Not set yet";
                lblCurrentNumber.Text = "Not set yet";
            }
            else
            {
                Text = "Edit Electricity Account";
                lblCurrentName.Text = _current.AccountName.Length == 0 ? "—" : _current.AccountName;
                lblCurrentNumber.Text = _current.AccountNumber.Length == 0 ? "—" : _current.AccountNumber;

                txtNewName.Text = _current.AccountName;
                txtNewNumber.Text = _current.AccountNumber;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtNewName.Text.Trim();
            string number = txtNewNumber.Text.Trim();

            if (!ElectricityAccountHelper.Validate(name, number, out string error))
            {
                Warn(error);
                (name.Length == 0 ? txtNewName : txtNewNumber).Focus();
                return;
            }

            if (_current != null && _current.AccountName == name && _current.AccountNumber == number)
            {
                MessageBox.Show("No changes were made.", "Electricity Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string question = _current == null
                ? "Set up this building's electricity account?\n\n" +
                  $"Account name:    {name}\n" +
                  $"Account number:  {number}"
                : "Change this building's electricity account?\n\n" +
                  $"From:  {_current.AccountName} ({_current.AccountNumber})\n" +
                  $"To:    {name} ({number})";

            if (MessageBox.Show(question, "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                ElectricityAccountHelper.Save(_buildingId, name, number);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to save the electricity account.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO (audit logs): record the change here once the AuditLogs format is confirmed

            MessageBox.Show("Electricity account saved.", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // NEW
        private static void Warn(string msg) =>
            MessageBox.Show(msg, "Electricity Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
