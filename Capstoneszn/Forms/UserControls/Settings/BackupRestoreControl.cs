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
    public partial class BackupRestoreControl : UserControl
    {
        public BackupRestoreControl()
        {
            InitializeComponent();
        }

        private void btnBackBackupRestore_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
