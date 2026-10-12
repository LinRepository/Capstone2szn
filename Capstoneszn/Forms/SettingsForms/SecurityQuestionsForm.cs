using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.SettingsForms
{
    public partial class SecurityQuestionsForm : Form
    {
        private readonly int _userId;

        // True when the form is opened by the login check because the account
        // has no questions yet. In that mode the user cannot skip past it and
        // reach the dashboard - closing returns them to the login screen.
        private readonly bool _mandatorySetup;

        private bool _savedSuccessfully = false;

        // Set when Load fails and closes the form itself. Without this, a database
        // error in mandatory mode triggers the "setup not finished" warning, which
        // blames the user for something the database did.
        private bool _abortSetup = false;


        public SecurityQuestionsForm(int userId, bool mandatorySetup = false)
        {
            _userId = userId;
            _mandatorySetup = mandatorySetup;
            InitializeComponent();
        }

        private void btnSaveSecurityQuestions_Click(object sender, EventArgs e)
        {
            string q1 = txtQuestion1.Text.Trim();
            string q2 = txtQuestion2.Text.Trim();
            string q3 = txtQuestion3.Text.Trim();

            // Trim only. Answers are CASE-SENSITIVE, matching how they are verified.
            string a1 = SecurityHelper.NormalizeAnswer(txtAnswer1.Text);
            string a2 = SecurityHelper.NormalizeAnswer(txtAnswer2.Text);
            string a3 = SecurityHelper.NormalizeAnswer(txtAnswer3.Text);

            string currentPassword = txtCurrentPassword.Text;   // never trim a password

            if (q1.Length == 0 || q2.Length == 0 || q3.Length == 0)
            {
                MessageBox.Show("Please write all three questions.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (q1.Length < 8 || q2.Length < 8 || q3.Length < 8)
            {
                MessageBox.Show("Each question must be at least 8 characters long.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Compared without case, because the database's UNIQUE constraint ignores
            // case too. Catching it here gives a readable message instead of a
            // constraint violation from SQL Server.
            if (string.Equals(q1, q2, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(q1, q3, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(q2, q3, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Your three questions must be different from each other.",
                    "Security Questions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (a1.Length == 0 || a2.Length == 0 || a3.Length == 0)
            {
                MessageBox.Show("Please answer all three questions.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentPassword.Length == 0)
            {
                MessageBox.Show("Please enter your current password to confirm this change.",
                    "Security Questions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
                return;
            }

            if (MessageBox.Show(
                    "Your answers are case-sensitive and cannot be viewed again once saved. " +
                    "You will need them exactly as typed to recover a forgotten password.\n\n" +
                    "Save these questions and answers?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Changing these is credential-equivalent: anyone at an unlocked
                    // machine could otherwise swap in questions they know and take
                    // the account. Prove ownership before touching anything.
                    string storedHash;

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT Password FROM Users WHERE UserId = @UserId", conn))
                    {
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = _userId;
                        object? result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("This account no longer exists.", "Security Questions",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        storedHash = (string)result;
                    }

                    if (!SecurityHelper.Verify(currentPassword, storedHash))
                    {
                        MessageBox.Show("The current password is incorrect. Nothing was saved.",
                            "Security Questions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCurrentPassword.Clear();
                        txtCurrentPassword.Focus();
                        return;
                    }

                    // Delete-then-insert rather than update: it handles a first-time
                    // setup (no rows), a later change (three rows) and a broken
                    // partial state (one or two rows) in exactly the same way.
                    // The transaction makes it all-or-nothing, so the account can
                    // never be left with a mix of old and new questions.
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand del = new SqlCommand(
                                "DELETE FROM SecurityQuestions WHERE UserId = @UserId", conn, tx))
                            {
                                del.Parameters.Add("@UserId", SqlDbType.Int).Value = _userId;
                                del.ExecuteNonQuery();
                            }

                            string[] questions = { q1, q2, q3 };
                            string[] answers = { a1, a2, a3 };

                            for (int number = 1; number <= 3; number++)
                            {
                                using (SqlCommand ins = new SqlCommand(
                                    @"INSERT INTO SecurityQuestions
                                          (UserId, QuestionNumber, QuestionText, AnswerHash)
                                      VALUES (@UserId, @Number, @QuestionText, @AnswerHash)", conn, tx))
                                {
                                    ins.Parameters.Add("@UserId", SqlDbType.Int).Value = _userId;
                                    ins.Parameters.Add("@Number", SqlDbType.Int).Value = number;
                                    ins.Parameters.Add("@QuestionText", SqlDbType.NVarChar, 255).Value =
                                        questions[number - 1];
                                    ins.Parameters.Add("@AnswerHash", SqlDbType.NVarChar, 255).Value =
                                        SecurityHelper.Hash(answers[number - 1]);

                                    ins.ExecuteNonQuery();
                                }
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            // If the connection has already dropped, the rollback fails
                            // too - SQL Server rolls the transaction back on its own in
                            // that case, so the original error is what matters.
                            try { tx.Rollback(); }
                            catch (Exception rollbackEx) { Debug.WriteLine(rollbackEx); }

                            throw;
                        }
                    }
                }

                _savedSuccessfully = true;

                txtAnswer1.Clear();
                txtAnswer2.Clear();
                txtAnswer3.Clear();
                txtCurrentPassword.Clear();

                MessageBox.Show("Security questions saved successfully.", "Security Questions",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Unique constraint violation - the database backstop for duplicate
                // questions. The validation above should already have caught this.
                Debug.WriteLine(ex);
                MessageBox.Show("Your three questions must be different from each other. Nothing was saved.",
                    "Security Questions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(
                    "A database error occurred. Nothing was saved. Please make sure SQL Server is running and try again.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(
                    "Something went wrong while saving your security questions. Nothing was saved.",
                    "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelSecurityQuestions_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SecurityQuestionsForm_Load(object sender, EventArgs e)
        {
            if (_mandatorySetup)
            {
                this.Text = "Set Up Security Questions";
                lblSecurityQuestionsTitle.Text = "Set Up Security Questions";
                lblSecurityQuestionsHint.Text =
                    "Write three questions only you can answer. Answers are case-sensitive.";
                btnCancelSecurityQuestions.Text = "Back to Login";
            }

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

                // Existing questions are prefilled so they can be edited. A first-time
                // setup simply finds nothing and leaves the boxes empty - no error,
                // because "not set up yet" is a normal state for a new account.
                if (questions.ContainsKey(1)) txtQuestion1.Text = questions[1];
                if (questions.ContainsKey(2)) txtQuestion2.Text = questions[2];
                if (questions.ContainsKey(3)) txtQuestion3.Text = questions[3];

                // The answer boxes always start empty. Stored answers are hashed,
                // so they cannot be read back - all three are re-entered every time.
                txtQuestion1.Select();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(
                    "A database error occurred. Please make sure SQL Server is running and try again.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _abortSetup = true;
                this.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(
                    "Something went wrong while loading your security questions.",
                    "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _abortSetup = true;
                this.Close();
            }
        }

        private void SecurityQuestionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Only guard the forced first-login case. Opened from Settings, this
            // form closes freely like any other dialog.
            // was: if (!_mandatorySetup || _savedSuccessfully) return;
            if (!_mandatorySetup || _savedSuccessfully || _abortSetup) return;

            DialogResult answer = MessageBox.Show(
                "Your security questions are not set up yet. Without them you cannot " +
                "recover a forgotten password.\n\nReturn to the login screen?",
                "Setup not finished", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
            {
                e.Cancel = true;

                // Reset, otherwise the DialogResult left behind by Cancel/Esc would
                // close the form again the moment this handler returns.
                this.DialogResult = DialogResult.None;
            }

            // On Yes the form closes and ShowDialog returns Cancel, which tells
            // LoginForm to stay on the login screen instead of continuing.
        }
    }
}
