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
        private int _roomId;
        private int _currentCapacity;

        public SetCapacityForm(int roomId, int currentCapacity)
        {
            InitializeComponent();

            _roomId = roomId;
            _currentCapacity = currentCapacity;

            // Display current capacity on load in your lblCurrentCapacityValue
            lblCurrentCapacityValue.Text = _currentCapacity == 0 ? "Not Set" : _currentCapacity.ToString();

            // Set the NumericUpDown rules
            nudNewCapacity.Minimum = 1;
            nudNewCapacity.Maximum = 10;
            nudNewCapacity.Value = _currentCapacity > 0 ? _currentCapacity : 1;
        }

        private void SetCapacityForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveCapacity_Click(object sender, EventArgs e)
        {
            int newCapacity = (int)nudNewCapacity.Value;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Rooms SET Capacity = @capacity WHERE RoomId = @roomId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@capacity", newCapacity);
                        cmd.Parameters.AddWithValue("@roomId", _roomId);

                        cmd.ExecuteNonQuery();
                    }

                    // Tell the RoomInformationForm that the save was successful
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating capacity: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
