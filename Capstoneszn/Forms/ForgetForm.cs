using Capstoneszn.Forms;
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
using Capstoneszn.Forms.UserControls;

namespace Capstoneszn
{
    public partial class ForgetForm : Form
    {
        private readonly string _username;
        public ForgetForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void ForgetForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT SecurityQuestion1, SecurityQuestion2, SecurityQuestion3 FROM Users WHERE Username = @Username", conn))
                {
                    cmd.Parameters.AddWithValue("@Username", _username);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("User not found.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }

                        lblQuestionOne.Text = reader["SecurityQuestion1"].ToString();
                        lblQuestionTwo.Text = reader["SecurityQuestion2"].ToString();
                        lblQuestionThree.Text = reader["SecurityQuestion3"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string a1 = txtQuestionOne.Text.Trim().ToLower();
            string a2 = txtQuestionTwo.Text.Trim().ToLower();
            string a3 = txtQuestionThree.Text.Trim().ToLower();

            //Warning if may empty answer
            if (a1 == "" || a2 == "" || a3 == "")
            {
                MessageBox.Show("Please answer all three questions.", "Missing answers",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT SecurityAnswer1, SecurityAnswer2, SecurityAnswer3
                             FROM Users WHERE Username = @Username";

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", _username);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("User not found.");
                            return;
                        }

                        // Step 1: check each answer
                        bool ok1 = Matches(reader["SecurityAnswer1"], a1);
                        bool ok2 = Matches(reader["SecurityAnswer2"], a2);
                        bool ok3 = Matches(reader["SecurityAnswer3"], a3);

                        // Step 2: all correct
                        if (ok1 && ok2 && ok3)
                        {
                            MessageBox.Show("Verification successful! You can now reset your password.");
                            new PasswordResetForm(_username).Show();
                            this.Hide();
                        }
                        // Step 3: show the wrong ones
                        else
                        {
                            IncorrectAnswerForm wrongForm = new IncorrectAnswerForm();

                            if (!ok1) wrongForm.AddWrongAnswer(1, lblQuestionOne.Text, a1);
                            if (!ok2) wrongForm.AddWrongAnswer(2, lblQuestionTwo.Text, a2);
                            if (!ok3) wrongForm.AddWrongAnswer(3, lblQuestionThree.Text, a3);

                            wrongForm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Case-insensitive, so "Carl" matches "carl"
        private static bool Matches(object dbValue, string input) =>
            dbValue != DBNull.Value &&
            string.Equals(dbValue.ToString()?.Trim(), input, StringComparison.OrdinalIgnoreCase);

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Find the original hidden Login Form
            var login = Application.OpenForms.OfType<Login>().FirstOrDefault();

            if (login != null)
            {
                login.Show();
            }
            else
            {
                // Fallback just in case it doesn't exist
                new Login().Show();
            }

            // Close the current Forget Form
            this.Close();
        }
    }
}
