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
    public partial class SystemClockForm : Form
    {
        private System.Windows.Forms.Timer? clockTimer;
        private bool isClockValid = false;

        // Philippine Standard Time is UTC+8
        private const double RequiredUtcOffsetHours = 8.0;

        // How far (in minutes) the PC clock may drift from the real time
        private const double AllowedDriftMinutes = 2.0;

        // Internet time servers, tried in order until one answers
        private static readonly string[] NtpServers =
        {
            "time.windows.com",
            "time.google.com",
            "pool.ntp.org"
        };

        // Real UTC time captured from the NTP server + a stopwatch started at that moment.
        // Lets us know the real time later even if the user changes the PC clock while the form is open.
        private DateTime verifiedNtpUtc;
        private readonly Stopwatch sinceVerified = new Stopwatch();
        public SystemClockForm()
        {
            InitializeComponent();
        }

        private async void SystemClockForm_Load(object sender, EventArgs e)
        {
            // Wrap long messages instead of running off the form
            lblMessage.MaximumSize = new Size(this.ClientSize.Width - 2 * lblMessage.Left, 0);

            // 1. Initialize the live ticking timer for lblDateandTime
            clockTimer = new System.Windows.Forms.Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += new EventHandler(ClockTimer_Tick);
            clockTimer.Start();
            ClockTimer_Tick(null, EventArgs.Empty);

            // 2. Validate the PC clock against the real time from the internet
            await ValidateSystemClockAsync();
        }
        private void ClockTimer_Tick(object? sender, EventArgs e)
        {
            // Continuously update the date and time label (this is the PC's time)
            lblDateandTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy - hh:mm:ss tt");
        }

        private async Task ValidateSystemClockAsync()
        {
            isClockValid = false;
            btnConfirm.Enabled = false;
            lblMessage.Text = "Checking your PC clock against the internet time server...";
            lblMessage.ForeColor = Color.White;

            DateTime? realUtc = null;
            string lastError = "";

            // Try each server until one responds
            foreach (string server in NtpServers)
            {
                try
                {
                    realUtc = await GetNetworkTimeUtcAsync(server);
                    break;
                }
                catch (Exception ex)
                {
                    lastError = ex.Message;
                }
            }

            // The form may have been closed while we were waiting
            if (IsDisposed) return;

            // VALIDATION 1: We must be able to reach a time server
            if (realUtc == null)
            {
                ShowError("Cannot verify the date and time: no internet connection or the time server " +
                          "could not be reached. Please connect to the internet and open this window again." +
                          (string.IsNullOrEmpty(lastError) ? "" : $"\n(Details: {lastError})"));
                return;
            }

            verifiedNtpUtc = realUtc.Value;
            sinceVerified.Restart();

            DateTime realLocal = verifiedNtpUtc.AddHours(RequiredUtcOffsetHours); // real Philippine time
            DateTime deviceLocal = DateTime.Now;
            double deviceOffsetHours = TimeZoneInfo.Local.GetUtcOffset(deviceLocal).TotalHours;

            // VALIDATION 2: The PC's time zone must be UTC+8
            if (deviceOffsetHours != RequiredUtcOffsetHours)
            {
                ShowError($"Cannot proceed: Your PC's time zone is wrong (UTC{deviceOffsetHours:+0.##;-0.##}). " +
                          $"It must be UTC+08:00 (Philippines). Please fix your Windows time zone settings.");
                return;
            }

            // VALIDATION 3: The PC's date must match the real date
            if (deviceLocal.Date != realLocal.Date)
            {
                ShowError($"Cannot proceed: Your PC's date is wrong! Your PC says {deviceLocal:MMMM dd, yyyy}, " +
                          $"but today is actually {realLocal:dddd, MMMM dd, yyyy}. Please fix your Windows clock.");
                return;
            }

            // VALIDATION 4: The PC's time must be close to the real time
            double driftMinutes = Math.Abs((DateTime.UtcNow - verifiedNtpUtc).TotalMinutes);
            if (driftMinutes > AllowedDriftMinutes)
            {
                ShowError($"Cannot proceed: Your PC's time is off by {driftMinutes:0} minute(s). Your PC says " +
                          $"{deviceLocal:hh:mm tt}, but the actual time is {realLocal:hh:mm tt}. Please fix your Windows clock.");
                return;
            }

            // All checks passed
            isClockValid = true;
            lblMessage.Text = "System clock and time zone verified. Please confirm the current time to proceed to the dashboard.";
            lblMessage.ForeColor = Color.LightGreen;
            btnConfirm.Enabled = true;
        }

        private void ShowError(string message)
        {
            isClockValid = false;
            lblMessage.Text = message;
            lblMessage.ForeColor = Color.Red;
            btnConfirm.Enabled = false; // STRICTLY BLOCKS PROCEEDING!
        }

        // Asks an NTP server for the real current time (UTC). Times out after 3 seconds.
        private static async Task<DateTime> GetNetworkTimeUtcAsync(string server)
        {
            byte[] ntpData = new byte[48];
            ntpData[0] = 0x1B; // NTP version 3, client mode

            IPAddress[] addresses = await Dns.GetHostAddressesAsync(server);
            IPAddress? ipv4 = addresses.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            if (ipv4 == null)
                throw new Exception($"No IPv4 address found for {server}.");

            using UdpClient udp = new UdpClient();
            udp.Connect(new IPEndPoint(ipv4, 123));
            await udp.SendAsync(ntpData, ntpData.Length);

            Task<UdpReceiveResult> receiveTask = udp.ReceiveAsync();
            if (await Task.WhenAny(receiveTask, Task.Delay(3000)) != receiveTask)
                throw new TimeoutException($"{server} did not respond.");

            byte[] response = receiveTask.Result.Buffer;
            if (response.Length < 48)
                throw new Exception($"Invalid response from {server}.");

            // Transmit timestamp starts at byte 40 (seconds + fraction since Jan 1, 1900)
            ulong seconds = BinaryPrimitives.ReadUInt32BigEndian(response.AsSpan(40, 4));
            ulong fraction = BinaryPrimitives.ReadUInt32BigEndian(response.AsSpan(44, 4));
            ulong milliseconds = (seconds * 1000) + ((fraction * 1000) / 0x100000000UL);

            return new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(milliseconds);
        }

        // Re-checks that nobody changed the PC clock after the form verified it
        private bool IsClockStillValid()
        {
            if (!isClockValid || !sinceVerified.IsRunning) return false;

            DateTime expectedUtc = verifiedNtpUtc.Add(sinceVerified.Elapsed);
            double driftMinutes = Math.Abs((DateTime.UtcNow - expectedUtc).TotalMinutes);
            double deviceOffsetHours = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalHours;

            return driftMinutes <= AllowedDriftMinutes && deviceOffsetHours == RequiredUtcOffsetHours;
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            TimeZoneInfo.ClearCachedData(); // pick up any time zone change made while the form was open

            if (!IsClockStillValid())
            {
                MessageBox.Show("Cannot proceed: Your PC's date, time, or time zone was changed and is now incorrect.",
                                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await ValidateSystemClockAsync(); // refresh lblMessage with the exact reason
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to proceed with the current system time:\n{lblDateandTime.Text}?",
                "System Clock Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                clockTimer?.Stop();
                this.DialogResult = DialogResult.OK; // tells MainForm the clock was confirmed
                this.Close();
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            clockTimer?.Stop();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
