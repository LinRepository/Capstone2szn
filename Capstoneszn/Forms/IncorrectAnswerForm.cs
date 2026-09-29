using Capstoneszn.Forms.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms
{
    public partial class IncorrectAnswerForm : Form
    {
        public IncorrectAnswerForm()
        {
            InitializeComponent();
        }

        private void IncorrectAnswerForm_Load(object sender, EventArgs e)
        {

        }
        public void AddWrongAnswer(int no, string question, string answer)
        {
            IncorrectAnswerItemControl card = new IncorrectAnswerItemControl();
            card.SetData(no, question, answer);
            flpIncorrectAnswers.Controls.Add(card);
        }

        private void btnWrongAnswerOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flpIncorrectAnswers_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
