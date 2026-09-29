using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.UserControls
{
    public partial class IncorrectAnswerItemControl : UserControl
    {
        public IncorrectAnswerItemControl()
        {
            InitializeComponent();
        }

        private void lblQuestionNo_Click(object sender, EventArgs e)
        {

        }

        private void IncorrectAnswerItemControl_Load(object sender, EventArgs e)
        {

        }
        public void SetData(int questionNo, string question, string answer)
        {
            lblQuestionNo.Text = "Question " + questionNo;
            lblQuestion.Text = question;
            lblQuestionAnswer.Text = "Your answer: " + answer;
        }
    }
}
