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

            // ADDED (System Clock STEP 4): the clock check runs FIRST, before Login.
            // Everything after this point (login lockout timer, BillGenerator at
            // login, audit log times, salary recording) depends on a correct clock.
            // If the user exits or closes the clock window, the app does not open.
            using (var clockForm = new SystemClockForm())
            {
                if (clockForm.ShowDialog() != DialogResult.OK)
                    return 0;
            }

            // ADDED (System Clock STEP 6): from here on, a clock or time zone change
            // made while the app is open reopens the clock check (any screen).
            ClockWatcher.Start();

            Application.Run(new Login());
            return 0;   // ADDED (System Clock STEP 4): Main now returns an exit code
        }
    }
}