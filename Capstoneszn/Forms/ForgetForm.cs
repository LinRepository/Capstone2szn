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
        private int _userId;
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
                {
                    conn.Open();

                    // 1. Resolve the username to a UserId
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT UserId FROM Users WHERE Username = @Username", conn))
                    {
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = _username;
                        object? result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("User not found.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }

                        _userId = (int)result;
                    }

                    // 2. Load that user's three questions from the SecurityQuestions table
                    var questions = new Dictionary<int, string>();

                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT QuestionNumber, QuestionText
                          FROM SecurityQuestions
                          WHERE UserID = @UserId
                          ORDER BY QuestionNumber", conn))
                    {
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = _userId;

                        using (SqlDataReader r = cmd.ExecuteReader())
                            while (r.Read()) questions[r.GetInt32(0)] = r.GetString(1);
                    }

                    // An account with no questions seeded can't use this recovery path
                    if (questions.Count < 3)
                    {
                        MessageBox.Show(
                            "This account has no security questions set up, so the password cannot be reset here.",
                            "Not available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }

                    lblQuestionOne.Text = questions[1];
                    lblQuestionTwo.Text = questions[2];
                    lblQuestionThree.Text = questions[3];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connect to the database.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            // Trim only. Answers are CASE-SENSITIVE, matching how they were hashed.
            string a1 = SecurityHelper.NormalizeAnswer(txtQuestionOne.Text);
            string a2 = SecurityHelper.NormalizeAnswer(txtQuestionTwo.Text);
            string a3 = SecurityHelper.NormalizeAnswer(txtQuestionThree.Text);

            if (a1.Length == 0 || a2.Length == 0 || a3.Length == 0)
            {
                MessageBox.Show("Please answer all three questions.", "Missing answers",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var hashes = new Dictionary<int, string>();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT QuestionNumber, AnswerHash
                      FROM SecurityQuestions
                      WHERE UserID = @UserId", conn))
                {
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = _userId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) hashes[r.GetInt32(0)] = r.GetString(1);
                }

                if (hashes.Count < 3)
                {
                    MessageBox.Show("Security questions are incomplete for this account.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Each answer is verified against its own hash - the typed answer
                // is never sent to SQL Server.
                bool ok1 = SecurityHelper.Verify(a1, hashes[1]);
                bool ok2 = SecurityHelper.Verify(a2, hashes[2]);
                bool ok3 = SecurityHelper.Verify(a3, hashes[3]);

                if (ok1 && ok2 && ok3)
                {
                    MessageBox.Show("Verification successful! You can now reset your password.",
                        "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (var reset = new PasswordResetForm(_username))
                        reset.ShowDialog(this);

                    this.Close();   // Login re-shows itself via its FormClosed handler
                }
                else
                {
                    IncorrectAnswerForm wrongForm = new IncorrectAnswerForm();

                    if (!ok1) wrongForm.AddWrongAnswer(1, lblQuestionOne.Text, a1);
                    if (!ok2) wrongForm.AddWrongAnswer(2, lblQuestionTwo.Text, a2);
                    if (!ok3) wrongForm.AddWrongAnswer(3, lblQuestionThree.Text, a3);

                    wrongForm.ShowDialog(this);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connect to the database.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

            // Close the current Forget Form
            this.Close();
        }
    }
}
