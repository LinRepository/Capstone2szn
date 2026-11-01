using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.BuildingForms
{

    /// <summary>What happened when the app tried to change the Windows clock.</summary>
    public enum SetClockResult
    {
        Success,     // clock changed
        Cancelled,   // user clicked "No" on the Windows admin prompt (UAC)
        Failed       // something else went wrong
    }

    /// <summary>
    /// STEP 3 - Changes the Windows clock (items 1 and 2).
    /// New file: Capstoneszn/WindowsClockHelper.cs  (same folder as ClockService.cs)
    ///
    /// WHY IT WORKS THIS WAY
    ///   Only an administrator can change the Windows clock. The app itself does
    ///   NOT run as admin (that would show a UAC prompt at every startup).
    ///   So for this one action the app starts a SECOND COPY of itself as admin:
    ///
    ///     Main app (normal)                      Helper copy (admin)
    ///     ─────────────────                      ───────────────────
    ///     SetClockAsync(target)  ── starts ──►   Program.Main sees "--set-clock-offset"
    ///       Windows shows UAC prompt               TryRunSetClockMode() sets the clock
    ///       waits ...                ◄── exit ──   quits right away (no window)
    ///     reads the exit code: 0 = success
    ///
    ///   PART 2 below only runs once Program.cs calls it (STEP 4).
    ///   Do NOT call SetClockAsync before STEP 4 is done - without it the
    ///   helper copy would open a second full app instead of setting the clock.
    ///
    /// WHY IT SENDS A DIFFERENCE, NOT A TIME
    ///   The user may take several seconds to click "Yes" on the UAC prompt.
    ///   An exact time ("9:30:00") would be late by that delay. The difference
    ///   ("+2 days 3 hours") stays correct however long the user takes, because
    ///   the PC clock keeps ticking at normal speed - it is just set wrong.
    /// </summary>
    /// 

    public static class WindowsClockHelper
    {
        private const string SetClockArg = "--set-clock-offset";

        // Windows error code when the user clicks "No" on the UAC prompt
        private const int ErrorCancelled = 1223;

        // Exit codes of the helper copy
        private const int ExitOk = 0;
        private const int ExitBadArgument = 2;
        private const int ExitSetFailed = 3;

        // ───────────────────────── Windows API ─────────────────────────
        // SetSystemTime takes the time in UTC. It turns on the "change the
        // system time" permission by itself, as long as the process is admin.

        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            public ushort wYear, wMonth, wDayOfWeek, wDay,
                          wHour, wMinute, wSecond, wMilliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetSystemTime(ref SYSTEMTIME time);

        // ═════════════════════════════════════════════════════════════════
        // PART 1 - used by SystemClockForm (the normal, non-admin app)
        // ═════════════════════════════════════════════════════════════════

        /// <summary>
        /// Changes the Windows clock to targetLocalTime (Philippine time).
        ///   - Fix Automatically: target = ClockService.ToPhilippineTime(onlineUtc)
        ///   - Set Manually     : target = the date/time the user picked
        /// The caller must run the guardrails (time zone, no backdating) BEFORE calling this.
        /// </summary>
        public static async Task<SetClockResult> SetClockAsync(DateTime targetLocalTime)
        {
            // The difference between the wanted time and the PC's time right now
            TimeSpan offset = targetLocalTime - DateTime.Now;

            var startInfo = new ProcessStartInfo
            {
                FileName = Environment.ProcessPath ?? Application.ExecutablePath,
                Arguments = SetClockArg + " " + offset.Ticks.ToString(CultureInfo.InvariantCulture),
                UseShellExecute = true,   // required for "runas"
                Verb = "runas"            // = "Run as administrator" -> Windows shows the UAC prompt
            };

            try
            {
                using Process? helper = Process.Start(startInfo);
                if (helper == null) return SetClockResult.Failed;

                // Wait without freezing the form. The helper finishes in well under
                // a second once approved; 60 s covers a user slow to click "Yes".
                using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(60));
                await helper.WaitForExitAsync(timeout.Token);

                return helper.ExitCode == ExitOk ? SetClockResult.Success : SetClockResult.Failed;
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == ErrorCancelled)
            {
                return SetClockResult.Cancelled;   // user clicked "No"
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Set clock failed: " + ex);
                return SetClockResult.Failed;
            }
        }

        /// <summary>
        /// Fallback when the UAC prompt is cancelled: opens
        /// Windows Settings > Time &amp; language > Date &amp; time.
        /// Returns false if it could not be opened.
        /// </summary>
        public static bool OpenWindowsDateTimeSettings()
        {
            try
            {
                Process.Start(new ProcessStartInfo("ms-settings:dateandtime") { UseShellExecute = true });
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not open Date & time settings: " + ex);
                return false;
            }
        }

        // ═════════════════════════════════════════════════════════════════
        // PART 2 - runs inside the helper copy (admin), called from Program.Main
        // ═════════════════════════════════════════════════════════════════

        /// <summary>
        /// If the app was started as the clock helper, sets the clock and returns true
        /// (Program.Main must then exit with exitCode and show no form).
        /// Returns false for a normal start, so the app opens as usual.
        /// </summary>
        public static bool TryRunSetClockMode(string[] args, out int exitCode)
        {
            exitCode = ExitOk;

            if (args.Length == 0 || args[0] != SetClockArg)
                return false;                       // normal start - not the helper

            if (args.Length < 2 ||
                !long.TryParse(args[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out long ticks))
            {
                exitCode = ExitBadArgument;
                return true;
            }

            DateTime newUtc;
            try
            {
                newUtc = DateTime.UtcNow.AddTicks(ticks);
            }
            catch (ArgumentOutOfRangeException)
            {
                exitCode = ExitBadArgument;
                return true;
            }

            // Sanity limit - refuses nonsense years even if someone runs the helper by hand
            if (newUtc.Year < 2020 || newUtc.Year > 2099)
            {
                exitCode = ExitBadArgument;
                return true;
            }

            var time = new SYSTEMTIME
            {
                wYear = (ushort)newUtc.Year,
                wMonth = (ushort)newUtc.Month,
                wDay = (ushort)newUtc.Day,
                wHour = (ushort)newUtc.Hour,
                wMinute = (ushort)newUtc.Minute,
                wSecond = (ushort)newUtc.Second,
                wMilliseconds = (ushort)newUtc.Millisecond
                // wDayOfWeek is ignored by SetSystemTime
            };

            if (!SetSystemTime(ref time))
            {
                Debug.WriteLine("SetSystemTime error " + Marshal.GetLastWin32Error());
                exitCode = ExitSetFailed;
            }

            return true;
        }
    }


}
