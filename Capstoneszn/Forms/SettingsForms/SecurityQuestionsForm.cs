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
            // Trim only. Answers are CASE-SENSITIVE, matching how they are verified.
            string a1 = SecurityHelper.NormalizeAnswer(txtAnswer1.Text);
            string a2 = SecurityHelper.NormalizeAnswer(txtAnswer2.Text);
            string a3 = SecurityHelper.NormalizeAnswer(txtAnswer3.Text);

            if (a1.Length == 0 || a2.Length == 0 || a3.Length == 0)
            {
                MessageBox.Show("Please answer all three questions.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Your answers are case-sensitive and cannot be viewed again once saved. " +
                    "You will need them exactly as typed to recover a forgotten password.\n\nSave these answers?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // All three save together or none do, so the account can never be
                    // left with a mix of old and new answers.
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        int rows = 0;
                        string[] answers = { a1, a2, a3 };

                        for (int number = 1; number <= 3; number++)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                @"UPDATE SecurityQuestions
                                  SET AnswerHash = @AnswerHash
                                  WHERE UserId = @UserId AND QuestionNumber = @Number", conn, tx))
                            {
                                cmd.Parameters.Add("@AnswerHash", SqlDbType.NVarChar, 255).Value =
                                    SecurityHelper.Hash(answers[number - 1]);
                                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = _userId;
                                cmd.Parameters.Add("@Number", SqlDbType.Int).Value = number;

                                rows += cmd.ExecuteNonQuery();
                            }
                        }

                        if (rows != 3)
                        {
                            tx.Rollback();
                            MessageBox.Show("Security questions are incomplete for this account. Nothing was saved.",
                                "Security Questions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        tx.Commit();
                    }
                }

                txtAnswer1.Clear();
                txtAnswer2.Clear();
                txtAnswer3.Clear();

                MessageBox.Show("Security answers updated successfully.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save the security answers.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelSecurityQuestions_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SecurityQuestionsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var questions = new Dictionary<int, string>();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT QuestionNumber, QuestionText
                      FROM SecurityQuestions
                      WHERE UserId = @UserId
                      ORDER BY QuestionNumber", conn))
                {
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = _userId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) questions[r.GetInt32(0)] = r.GetString(1);
                }

                if (questions.Count < 3)
                {
                    MessageBox.Show("Security questions are not set up for this account.",
                        "Security Questions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblQuestion1.Text = questions[1];
                lblQuestion2.Text = questions[2];
                lblQuestion3.Text = questions[3];

                // The answer boxes stay empty on purpose. Stored answers are hashed,
                // so they cannot be read back and displayed - all three are re-entered.
                txtAnswer1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load the security questions.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
