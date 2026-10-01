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

namespace Capstoneszn.Forms.SettingsForms
{
    public partial class SecurityQuestionsForm : Form
    {
        private readonly int _userId;
        public SecurityQuestionsForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void btnSaveSecurityQuestions_Click(object sender, EventArgs e)
        {
            string a1 = txtAnswer1.Text.Trim();
            string a2 = txtAnswer2.Text.Trim();
            string a3 = txtAnswer3.Text.Trim();

            if (a1 == "" || a2 == "" || a3 == "")
            {
                MessageBox.Show("Please answer all three questions.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string updateQuery = @"UPDATE Users
                           SET SecurityAnswer1 = @Answer1,
                               SecurityAnswer2 = @Answer2,
                               SecurityAnswer3 = @Answer3
                           WHERE user_id = @UserID";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Answer1", a1);
                    cmd.Parameters.AddWithValue("@Answer2", a2);
                    cmd.Parameters.AddWithValue("@Answer3", a3);
                    cmd.Parameters.AddWithValue("@UserID", _userId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Security answers updated successfully.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving answers: " + ex.Message, "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelSecurityQuestions_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SecurityQuestionsForm_Load(object sender, EventArgs e)
        {
            string query = @"SELECT SecurityQuestion1, SecurityQuestion2, SecurityQuestion3
                     FROM Users WHERE user_id = @UserID";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", _userId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("User not found.", "Security Questions",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }

                        lblQuestion1.Text = reader["SecurityQuestion1"].ToString();
                        lblQuestion2.Text = reader["SecurityQuestion2"].ToString();
                        lblQuestion3.Text = reader["SecurityQuestion3"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
