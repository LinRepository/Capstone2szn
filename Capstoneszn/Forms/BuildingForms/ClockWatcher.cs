using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Capstoneszn.Forms.BuildingForms;

namespace Capstoneszn.Forms.BuildingForms
{

    /// <summary>
    /// STEP 6 - App-wide clock watcher (item 6).
    /// New file: Capstoneszn/ClockWatcher.cs  (same folder as ClockService.cs)
    ///
    /// The startup check runs once. This watcher covers the rest of the session:
    /// if someone changes the Windows clock or time zone while the app is open
    /// (on Login, Building Selection or MainForm), the SystemClockForm opens again.
    ///
    ///   Small change (within ±5 min, e.g. Windows correcting itself) -> ignored
    ///   Bigger change or wrong time zone -> warning + audit log + SystemClockForm
    ///       Confirm -> continue working
    ///       Exit    -> the app closes
    ///
    /// Started once from Program.cs, right after the startup clock check passes.
    /// </summary>
    public static class ClockWatcher
    {
        private static SynchronizationContext? uiContext;
        private static bool started;
        private static bool handling;

        // What the time SHOULD be now = baseline + time elapsed since (the stopwatch
        // keeps counting correctly even when someone changes the Windows clock).
        private static DateTime baselineUtc;
        private static readonly Stopwatch sinceBaseline = new Stopwatch();

        public static void Start()
        {
            if (started) return;
            started = true;

            // Windows raises TimeChanged on a background thread; forms must be shown
            // on the UI thread, so remember it and send the work there.
            uiContext = SynchronizationContext.Current ?? new WindowsFormsSynchronizationContext();

            ResetBaseline();
            SystemEvents.TimeChanged += OnTimeChanged;
            Application.ApplicationExit += (s, e) => SystemEvents.TimeChanged -= OnTimeChanged;
        }

        private static void ResetBaseline()
        {
            baselineUtc = DateTime.UtcNow;
            sinceBaseline.Restart();
        }

        /// <summary>
        /// ADDED (Nov 12, 2026): called when a SystemClockForm is confirmed (for example
        /// the clock check at login). Accepts the current PC time as correct, so a clock
        /// change made inside that form doesn't trigger a false alarm later.
        /// </summary>
        public static void AcknowledgeCurrentTime()
        {
            if (started) ResetBaseline();
        }

        private static void OnTimeChanged(object? sender, EventArgs e)
        {
            uiContext?.Post(_ => HandleTimeChanged(), null);
        }

        private static void HandleTimeChanged()
        {
            // Already handling, or the clock form is open (it changed the clock itself
            // with Fix Automatically / Set Manually) - nothing to do here.
            if (handling || SystemClockForm.IsShowing) return;

            DateTime expectedUtc = baselineUtc + sinceBaseline.Elapsed;
            double driftMinutes = Math.Abs((DateTime.UtcNow - expectedUtc).TotalMinutes);
            bool timeZoneOk = ClockService.IsTimeZoneValid();

            if (driftMinutes <= ClockService.ToleranceMinutes && timeZoneOk)
            {
                ResetBaseline();   // tiny automatic correction - ignore
                return;
            }

            handling = true;
            try
            {
                // Logged under the signed-in user (AuditLogger skips this when nobody is signed in,
                // e.g. on the Login screen - SystemClockChecks still records the re-check result).
                AuditLogger.Log(AuditLogger.ModuleSettings, "Clock Changed",
                    $"PC date/time or time zone changed while the system was open " +
                    $"(expected {expectedUtc.ToLocalTime():MMM dd, yyyy hh:mm tt}, " +
                    $"now {DateTime.Now:MMM dd, yyyy hh:mm tt}); clock check reopened");

                // The user is probably in Windows Settings, so the app may not be the
                // active window - fall back to the last visible form as the owner.
                Form? owner = Form.ActiveForm
                              ?? Application.OpenForms.Cast<Form>().LastOrDefault(f => f.Visible);

                MessageBox.Show(owner,
                    "The PC date, time, or time zone was changed while the system was open.\n" +
                    "The clock must be checked again before you continue.",
                    "System Clock", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                using var clockForm = new SystemClockForm();
                DialogResult result = owner != null ? clockForm.ShowDialog(owner) : clockForm.ShowDialog();

                if (result != DialogResult.OK)
                {
                    Application.Exit();   // Exit / closed the window -> close the app
                    return;
                }

                ResetBaseline();          // confirmed - this is the new correct time
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Clock watcher failed: " + ex);
            }
            finally
            {
                handling = false;
            }
        }
    }

}
