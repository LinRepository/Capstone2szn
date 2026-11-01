using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// NEW FILE: RestoreConfirmForm.cs  (put it in Forms/SettingsForms, next to EditProfileForm)
// Built fully in code — no Designer file needed.
// Shows which backup will be restored and its date, and asks for the password.


namespace Capstoneszn.Forms.SettingsForms
{
    public partial class RestoreConfirmForm : Form
    {
        // Read by BackupRestoreControl after DialogResult.OK
        public string Password => txtRestorePassword.Text;

        public RestoreConfirmForm(string fileName, DateTime backupDate)
        {
            InitializeComponent();

            lblRestoreWarning.Text =
                "You are about to restore:\n" + fileName + "\n\n" +
                "This backup was made on " + backupDate.ToString("MMMM d, yyyy h:mm tt") + ".\n" +
                "Everything recorded after that (payments, move-ins, etc.) will be LOST.\n\n" +
                "A safety backup of the current data is made first, and you will be " +
                "logged out after the restore.";
        }
    }
}
