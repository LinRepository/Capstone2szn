using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstoneszn.Forms.BuildingForms
{

    /// <summary>
    /// STEP 5 - System Clock Confirmation (opens at startup, before Login).
    ///
    ///   Time zone wrong ............ blocked until fixed in Windows
    ///   ONLINE  + clock correct .... Confirm
    ///   ONLINE  + clock wrong ...... Fix Automatically (no manual set while online)
    ///   OFFLINE + clock OK ......... Confirm, or Set Manually
    ///   OFFLINE + earlier than the last recorded time ... Set Manually only (no backdating)
    ///
    /// Logic lives in ClockService (STEP 2) and WindowsClockHelper (STEP 3).
    /// The previous version of this form is kept, commented out, at the end of this file.
    /// </summary>
    /// 

    public partial class SystemClockForm : Form
    {
        /// <summary>
        /// True while this window is open. STEP 6 (app-wide watcher) uses it so a
        /// clock change made BY this form doesn't open a second clock window.
        /// </summary>
        public static bool IsShowing { get; private set; }

        private System.Windows.Forms.Timer? clockTimer;

        // Online result. null = offline. The stopwatch keeps the real time
        // correct while the window stays open: real now = onlineUtc + elapsed.
        private DateTime? onlineUtc;
        private readonly Stopwatch sinceOnline = new Stopwatch();

        // Latest time the system ever recorded anything (no-backdating rule)
        private DateTime? lastRecorded;

        // Detects a clock change made while this window is open:
        // expected PC time = PC time at the check + time elapsed since.
        private DateTime pcUtcAtCheck;
        private readonly Stopwatch sinceCheck = new Stopwatch();

        private bool canConfirm;
        private string? resultToLog;   // written when Confirm is clicked (null = already logged)
        private bool busy;             // ignores clicks while a check or clock change is running

        private static readonly Color MsgWhite = Color.White;
        private static readonly Color MsgGreen = Color.LightGreen;
        private static readonly Color MsgAmber = Color.Gold;
        private static readonly Color MsgRed = Color.FromArgb(255, 120, 120);

        private const string DisplayFormat = "MMMM dd, yyyy  hh:mm tt";

        public SystemClockForm()
        {
            InitializeComponent();
        }

        // ADDED (login-first flow, Nov 12, 2026): LoginForm opens the clock check
        // after the password is verified. There, closing it returns to the login
        // screen (the app stays open), so the button reads "Back to Login".
        // The ClockWatcher still uses the old constructor, where "Exit" closes the app.
        public SystemClockForm(bool afterLogin) : this()
        {
            if (afterLogin)
            {
                btnGoBack.Text = "Back to Login";
                btnGoBack.Width = 130;                                   // wider for the longer text
                btnGoBack.Left = btnConfirm.Left - btnGoBack.Width - 6;  // keep it beside Confirm
            }
        }

        // ───────────────────────── Start ─────────────────────────

        private async void SystemClockForm_Load(object sender, EventArgs e)
        {
            IsShowing = true;
            FormClosed += (s, a) =>
            {
                IsShowing = false;
                clockTimer?.Stop();

                // ADDED (Nov 12, 2026): a confirmed clock is the new correct time, so the
                // watcher must not treat a change made here (Fix Automatically /
                // Set Manually) as a "clock changed" alarm later.
                if (this.DialogResult == DialogResult.OK)
                    ClockWatcher.AcknowledgeCurrentTime();
            };

            // Wrap long messages instead of running off the form
            lblMessage.MaximumSize = new Size(this.ClientSize.Width - 2 * lblMessage.Left, 0);

            // Live PC clock in lblDateandTime
            clockTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
            ClockTimer_Tick(null, EventArgs.Empty);

            await RunCheckAsync();
        }

        private void ClockTimer_Tick(object? sender, EventArgs e)
        {
            // This is the PC's time (what the whole system will use)
            lblDateandTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy - hh:mm:ss tt");
        }

        // ───────────────────────── The check ─────────────────────────

        private async Task RunCheckAsync()
        {
            if (busy) return;
            busy = true;

            try
            {
                ShowButtons();
                HideManualPicker();
                canConfirm = false;
                resultToLog = null;
                onlineUtc = null;
                ShowMessage("Checking the date and time...", MsgWhite);

                // 1. Time zone must be UTC+08:00 (item 5)
                if (!ClockService.IsTimeZoneValid())
                {
                    string offset = ClockService.CurrentUtcOffsetText();
                    ClockService.LogCheck(ClockService.ResultRejected, details: "Wrong time zone: " + offset);

                    ShowMessage($"Your PC's time zone is {offset}. It must be (UTC+08:00) Philippines.\n" +
                                "Change it in Windows Settings > Time & language > Date & time, then click Check Again.",
                                MsgRed);
                    ShowButtons(checkAgain: true);
                    return;
                }

                // 2. Last recorded time (also proves the database is reachable).
                //    Runs in the background so the window doesn't freeze if SQL Server is slow.
                try
                {
                    lastRecorded = await Task.Run(() => ClockService.GetLastRecordedTime());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    if (IsDisposed) return;
                    ShowMessage("Cannot connect to the database. Make sure SQL Server is running, then click Check Again.",
                                MsgRed);
                    ShowButtons(checkAgain: true);
                    return;
                }

                // 3. Real time from the internet (waits at most about 4 seconds)
                onlineUtc = await ClockService.GetOnlineUtcAsync();
                if (IsDisposed) return;   // window closed while waiting

                MarkCheckedNow();

                if (onlineUtc != null)
                {
                    sinceOnline.Restart();
                    ShowOnlineResult();
                }
                else
                {
                    ShowOfflineResult();
                }
            }
            finally
            {
                busy = false;
            }
        }

        /// <summary>PATH 1 - online: the internet decides the time.</summary>
        private void ShowOnlineResult()
        {
            DateTime realUtc = CurrentOnlineUtc();
            DateTime realLocal = ClockService.ToPhilippineTime(realUtc);

            if (ClockService.IsWithinTolerance(realUtc))
            {
                canConfirm = true;
                resultToLog = ClockService.ResultVerified;
                ShowMessage("Date and time verified online. Click Confirm to continue.", MsgGreen);
                ShowButtons(confirm: true);
                return;
            }

            ClockService.LogCheck(ClockService.ResultRejected, onlineUtc: realUtc,
                details: $"PC clock wrong: PC {DateTime.Now:yyyy-MM-dd HH:mm}, real {realLocal:yyyy-MM-dd HH:mm}");

            // No Set Manually here - while online, the real time is known (item 3)
            ShowMessage("Your PC clock is wrong.\n" +
                        $"PC time:       {DateTime.Now.ToString(DisplayFormat)}\n" +
                        $"Correct time: {realLocal.ToString(DisplayFormat)}\n\n" +
                        "Click Fix Automatically to set the correct time.", MsgRed);
            ShowButtons(fix: true, checkAgain: true);
        }

        /// <summary>PATH 2 - offline: the user decides, but can't go back in time.</summary>
        private void ShowOfflineResult()
        {
            if (ClockService.IsEarlierThanLastRecorded(DateTime.Now, lastRecorded))
            {
                ClockService.LogCheck(ClockService.ResultRejected,
                    details: $"Offline: PC {DateTime.Now:yyyy-MM-dd HH:mm} is earlier than last recorded {lastRecorded:yyyy-MM-dd HH:mm}");

                ShowMessage("No internet connection, and your PC date is EARLIER than the last recorded activity " +
                            $"({lastRecorded?.ToString(DisplayFormat)}). Going back in time is not allowed.\n\n" +
                            "Click Set Manually to set the correct date and time, or connect to the internet and click Check Again.",
                            MsgRed);
                ShowButtons(manual: true, checkAgain: true);
                return;
            }

            canConfirm = true;
            resultToLog = ClockService.ResultOfflineConfirmed;
            ShowMessage("No internet connection, so the date and time could not be verified online.\n" +
                        "Is the date and time below correct? Click Confirm, or Set Manually to change it.", MsgAmber);
            ShowButtons(confirm: true, manual: true, checkAgain: true);
        }

        // ───────────────────────── Buttons ─────────────────────────

        private async void btnCheckAgain_Click(object sender, EventArgs e)
        {
            await RunCheckAsync();
        }

        /// <summary>Item 2 - online only: sets Windows to the real time.</summary>
        private async void btnFixAutomatically_Click(object sender, EventArgs e)
        {
            if (busy || onlineUtc == null) return;
            busy = true;

            try
            {
                ShowButtons();
                ShowMessage("Waiting for Windows permission to change the clock...", MsgWhite);

                DateTime oldTime = DateTime.Now;
                DateTime target = ClockService.ToPhilippineTime(CurrentOnlineUtc());

                SetClockResult result = await WindowsClockHelper.SetClockAsync(target);
                if (IsDisposed) return;

                if (result != SetClockResult.Success)
                {
                    HandleSetClockProblem(result);
                    return;
                }

                ClockService.LogCheck(ClockService.ResultAutoFixed, onlineUtc: CurrentOnlineUtc(),
                                      oldTime: oldTime, newTime: DateTime.Now);
            }
            finally
            {
                busy = false;
            }

            await RunCheckAsync();   // verify again - should now show "verified"
        }

        /// <summary>Item 1 - offline only: shows the date/time picker.</summary>
        private void btnSetManually_Click(object sender, EventArgs e)
        {
            if (busy || onlineUtc != null) return;   // manual set is offline only (item 3)

            // Start the picker at the PC time, or at the last recorded time if the PC is earlier
            DateTime start = DateTime.Now;
            if (lastRecorded.HasValue && start < lastRecorded.Value)
                start = lastRecorded.Value;

            dtpManualDateTime.Value = start;
            dtpManualDateTime.Visible = true;
            btnApplyTime.Visible = true;
            dtpManualDateTime.Focus();

            ShowMessage("Pick the correct date and time, then click Apply Time.\n" +
                        "(Windows will ask for administrator permission.)", MsgWhite);
        }

        /// <summary>Item 1 - applies the picked time to the Windows clock.</summary>
        private async void btnApplyTime_Click(object sender, EventArgs e)
        {
            if (busy || onlineUtc != null) return;

            DateTime v = dtpManualDateTime.Value;
            DateTime picked = new DateTime(v.Year, v.Month, v.Day, v.Hour, v.Minute, 0, DateTimeKind.Local);

            // Guardrail: no backdating
            if (ClockService.IsEarlierThanLastRecorded(picked, lastRecorded))
            {
                MessageBox.Show("The date and time can't be earlier than the last recorded activity:\n" +
                                lastRecorded?.ToString(DisplayFormat),
                                "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            busy = true;
            btnApplyTime.Enabled = false;

            try
            {
                ShowButtons();
                ShowMessage("Waiting for Windows permission to change the clock...", MsgWhite);

                DateTime oldTime = DateTime.Now;
                Stopwatch waited = Stopwatch.StartNew();   // time spent on the UAC prompt

                SetClockResult result = await WindowsClockHelper.SetClockAsync(picked);
                if (IsDisposed) return;

                if (result != SetClockResult.Success)
                {
                    HideManualPicker();
                    HandleSetClockProblem(result);
                    return;
                }

                // Make sure Windows really took the new time
                DateTime expectedNow = picked + waited.Elapsed;
                if (Math.Abs((DateTime.Now - expectedNow).TotalMinutes) > 1)
                {
                    HideManualPicker();
                    HandleSetClockProblem(SetClockResult.Failed);
                    return;
                }

                ClockService.LogCheck(ClockService.ResultManualSet, oldTime: oldTime, newTime: picked,
                                      details: "Set manually from SystemClockForm (offline)");

                HideManualPicker();
                MarkCheckedNow();
                canConfirm = true;
                resultToLog = null;   // already logged as ManualSet

                ShowMessage($"PC clock set to {picked.ToString(DisplayFormat)}. Click Confirm to continue.", MsgGreen);
                ShowButtons(confirm: true, manual: true, checkAgain: true);
            }
            finally
            {
                busy = false;
                btnApplyTime.Enabled = true;
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (busy || !canConfirm) return;

            // Someone changed the clock or time zone while the window was open
            if (!ClockService.IsTimeZoneValid() || ClockChangedSinceCheck())
            {
                MessageBox.Show("The date, time, or time zone was changed while this window was open.\n" +
                                "The clock will be checked again.",
                                "System Clock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                await RunCheckAsync();
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Proceed with this date and time?\n\n" + DateTime.Now.ToString("dddd, MMMM dd, yyyy - hh:mm tt"),
                "System Clock Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            if (resultToLog == ClockService.ResultVerified)
                ClockService.LogCheck(ClockService.ResultVerified, onlineUtc: CurrentOnlineUtc());
            else if (resultToLog == ClockService.ResultOfflineConfirmed)
                ClockService.LogCheck(ClockService.ResultOfflineConfirmed);

            clockTimer?.Stop();
            this.DialogResult = DialogResult.OK;   // tells Program.cs the clock was confirmed
            this.Close();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // Button text is now "Exit": the form opens before Login, so this closes the app
            clockTimer?.Stop();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ───────────────────────── Helpers ─────────────────────────

        private DateTime CurrentOnlineUtc()
        {
            return onlineUtc!.Value + sinceOnline.Elapsed;
        }

        private void MarkCheckedNow()
        {
            pcUtcAtCheck = DateTime.UtcNow;
            sinceCheck.Restart();
        }

        private bool ClockChangedSinceCheck()
        {
            DateTime expected = pcUtcAtCheck + sinceCheck.Elapsed;
            return Math.Abs((DateTime.UtcNow - expected).TotalMinutes) > 1;
        }

        /// <summary>UAC cancelled -> open Windows settings instead (fallback). Other failure -> message.</summary>
        private void HandleSetClockProblem(SetClockResult result)
        {
            if (result == SetClockResult.Cancelled)
            {
                bool opened = WindowsClockHelper.OpenWindowsDateTimeSettings();
                ShowMessage(opened
                    ? "Administrator permission was not given, so Windows Date & time settings were opened instead.\n" +
                      "Set the correct date and time there, then click Check Again."
                    : "Administrator permission was not given. Set the date and time in " +
                      "Windows Settings > Time & language > Date & time, then click Check Again.",
                    MsgAmber);
            }
            else
            {
                ShowMessage("The PC clock could not be changed. Set it in " +
                            "Windows Settings > Time & language > Date & time, then click Check Again.", MsgRed);
            }

            ShowButtons(checkAgain: true);
        }

        private void ShowButtons(bool confirm = false, bool fix = false, bool manual = false, bool checkAgain = false)
        {
            btnConfirm.Visible = confirm;
            btnFixAutomatically.Visible = fix;
            btnSetManually.Visible = manual;
            btnCheckAgain.Visible = checkAgain;
            btnGoBack.Enabled = true;   // Exit is always available
        }

        private void HideManualPicker()
        {
            dtpManualDateTime.Visible = false;
            btnApplyTime.Visible = false;
        }

        private void ShowMessage(string text, Color color)
        {
            lblMessage.Text = text;
            lblMessage.ForeColor = color;
        }
    }
}
