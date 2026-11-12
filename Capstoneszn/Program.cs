using System;
using System.Windows.Forms;
using Capstoneszn.Forms.BuildingForms;

namespace Capstoneszn
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        // was: static void Main()
        // CHANGED (System Clock STEP 4): returns an exit code and receives the
        // start-up arguments, so the clock helper copy (STEP 3) can report
        // success (0) or failure back to the main app.
        static int Main(string[] args)
        {
            // ADDED (System Clock STEP 4): clock helper copy.
            // When SystemClockForm asks to change the Windows clock, it starts a
            // second copy of this app as administrator with "--set-clock-offset".
            // That copy only sets the clock and exits here - no window opens.
            // A normal start skips this and continues below.
            if (WindowsClockHelper.TryRunSetClockMode(args, out int clockExitCode))
                return clockExitCode;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // CHANGED (System Clock, login-first flow - Nov 12, 2026):
            // the app now opens on Login. The clock check runs in LoginForm right after
            // the password is verified, before Building Selection.
            // Old startup check kept here commented out per team rule:
            //
            // // ADDED (System Clock STEP 4): the clock check runs FIRST, before Login.
            // using (var clockForm = new SystemClockForm())
            // {
            //     if (clockForm.ShowDialog() != DialogResult.OK)
            //         return 0;
            // }

            // Login is created first: creating a form sets up the UI thread context
            // that ClockWatcher needs to show its warning and the clock window.
            var loginForm = new Login();

            // ADDED (System Clock STEP 6), now started BEFORE Login is shown, so a clock
            // or time zone change made on the Login screen is also caught.
            ClockWatcher.Start();

            // was: Application.Run(new Login());
            Application.Run(loginForm);
            return 0;   // ADDED (System Clock STEP 4): Main now returns an exit code
        }
    }
}