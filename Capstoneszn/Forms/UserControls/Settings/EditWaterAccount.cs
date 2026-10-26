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
    public partial class EditWaterAccount : Form
    {
        private readonly int _buildingId;          // NEW
        private WaterAccountInfo? _current;        // NEW: null = not set up yet
        public EditWaterAccount()
        {
            InitializeComponent();
        }
        // NEW: the constructor Settings uses
        public EditWaterAccount(int buildingId) : this()
        {
            _buildingId = buildingId;
            txtNewNumber.KeyPress += AccountNumberKeyPress;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditWaterAccount_Load(object sender, EventArgs e)
        {
            try
            {
                _current = WaterAccountHelper.GetActive(_buildingId);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to load the water account.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                return;
            }

            txtNewName.MaxLength = WaterAccountHelper.NameMaxLength;
            txtNewNumber.MaxLength = WaterAccountHelper.NumberMaxLength;

            if (_current == null)
            {
                Text = "Set Up Water Account";
                lblCurrentName.Text = "Not set yet";
                lblCurrentNumber.Text = "Not set yet";
            }
            else
            {
                Text = "Edit Water Account";
                lblCurrentName.Text = _current.AccountName;
                lblCurrentNumber.Text = _current.AccountNumber;

                // pre-fill so fixing a typo doesn't mean retyping everything
                txtNewName.Text = _current.AccountName;
                txtNewNumber.Text = _current.AccountNumber;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtNewName.Text.Trim();
            string number = txtNewNumber.Text.Trim();

            // Same rules as Add Building and the database
            if (!WaterAccountHelper.Validate(name, number, out string error))
            {
                Warn(error);
                (name.Length == 0 ? txtNewName : txtNewNumber).Focus();
                return;
            }

            if (_current != null && _current.AccountName == name && _current.AccountNumber == number)
            {
                MessageBox.Show("No changes were made.", "Water Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirm: first-time setup vs. change
            string question;
            if (_current == null)
            {
                question = "Set up this building's water account?\n\n" +
                           $"Account name:    {name}\n" +
                           $"Account number:  {number}";
            }
            else
            {
                bool hasBills;
                try
                {
                    hasBills = WaterAccountHelper.ActiveAccountHasBills(_buildingId);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Unable to check existing bills.\n\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                question = "Change this building's water account?\n\n" +
                           $"From:  {_current.AccountName} ({_current.AccountNumber})\n" +
                           $"To:    {name} ({number})" +
                           (hasBills ? "\n\nPast water bills will keep the previous account details." : "");
            }

            if (MessageBox.Show(question, "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            WaterAccountSaveResult result;
            try
            {
                result = WaterAccountHelper.Save(_buildingId, name, number);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unable to save the water account.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result == WaterAccountSaveResult.DuplicateNumber)
            {
                Warn($"Account number {number} is already used by another building's water account.");
                txtNewNumber.Focus();
                return;
            }

            // TODO (audit logs): record the change here once the AuditLogs format is confirmed

            MessageBox.Show("Water account saved.", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();

        }
        private static void AccountNumberKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '-')
                return;
            e.Handled = true;
        }

        // NEW
        private static void Warn(string msg) =>
            MessageBox.Show(msg, "Water Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
