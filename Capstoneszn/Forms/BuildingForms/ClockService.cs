using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.BuildingForms
{

    /// <summary>
    /// STEP 2 - System Clock business logic (no UI in here).
    /// New file: Capstoneszn/ClockService.cs  (same folder as DatabaseHelper.cs)
    ///
    /// SystemClockForm uses these methods to decide:
    ///   - Online : is the PC clock within ±5 minutes of the real time?
    ///   - Offline: is the PC time earlier than the last recorded time? (no backdating)
    ///   - Always : is the time zone UTC+08:00?
    /// and to write every result to the SystemClockChecks table.
    /// </summary>
    public static class ClockService
    {
        // ───────────────────────── Settings ─────────────────────────

        /// <summary>Philippine Standard Time is UTC+8.</summary>
        public const double RequiredUtcOffsetHours = 8.0;

        /// <summary>
        /// Small drift that is allowed (item 8). Used in two places:
        ///  - online : PC clock vs real time
        ///  - offline: PC clock vs last recorded time (so a tiny Windows
        ///             correction of a few seconds is not called "backdating")
        /// </summary>
        public const double ToleranceMinutes = 5.0;

        /// <summary>Give up on the internet after this many seconds.</summary>
        private const int OnlineTimeoutSeconds = 4;

        // Results stored in SystemClockChecks.Result (match CK_SystemClockChecks_Result)
        public const string ResultVerified = "Verified";
        public const string ResultAutoFixed = "AutoFixed";
        public const string ResultOfflineConfirmed = "OfflineConfirmed";
        public const string ResultManualSet = "ManualSet";
        public const string ResultRejected = "Rejected";

        // Time sources. Moved here from SystemClockForm (same NTP servers),
        // plus two HTTPS sites in case the network blocks NTP (UDP port 123).
        private static readonly string[] NtpServers =
        {
            "time.windows.com",
            "time.google.com",
            "pool.ntp.org"
        };

        private static readonly string[] HttpsSites =
        {
            "https://www.google.com",
            "https://www.microsoft.com"
        };

        private static readonly HttpClient Http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(OnlineTimeoutSeconds)
        };

        // ───────────────────────── Online time ─────────────────────────

        /// <summary>
        /// Real current time (UTC) from the internet, or null when offline.
        ///
        /// How it works: it asks all 5 sources AT THE SAME TIME and takes the
        /// first one that answers. So when online it is fast, and when offline
        /// the user waits at most 4 seconds (not 3 seconds per server).
        /// </summary>
        public static async Task<DateTime?> GetOnlineUtcAsync()
        {
            var pending = new List<Task<DateTime>>();
            foreach (string server in NtpServers) pending.Add(GetNtpUtcAsync(server));
            foreach (string site in HttpsSites) pending.Add(GetHttpsUtcAsync(site));

            Task timeout = Task.Delay(TimeSpan.FromSeconds(OnlineTimeoutSeconds));

            while (pending.Count > 0)
            {
                Task finished = await Task.WhenAny(pending.Cast<Task>().Append(timeout));
                if (finished == timeout) return null;          // nobody answered in time

                var task = (Task<DateTime>)finished;
                pending.Remove(task);

                if (task.Status == TaskStatus.RanToCompletion)
                    return task.Result;                         // first good answer wins

                Debug.WriteLine("Time source failed: " + task.Exception?.GetBaseException().Message);
            }

            return null;                                        // every source failed
        }

        /// <summary>Asks an NTP server for the real time (UTC). Same code the old form used.</summary>
        private static async Task<DateTime> GetNtpUtcAsync(string server)
        {
            byte[] ntpData = new byte[48];
            ntpData[0] = 0x1B; // NTP version 3, client mode

            IPAddress[] addresses = await Dns.GetHostAddressesAsync(server);
            IPAddress ipv4 = addresses.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork)
                             ?? throw new Exception($"No IPv4 address found for {server}.");

            using UdpClient udp = new UdpClient();
            udp.Connect(new IPEndPoint(ipv4, 123));
            await udp.SendAsync(ntpData, ntpData.Length);

            Task<UdpReceiveResult> receiveTask = udp.ReceiveAsync();
            if (await Task.WhenAny(receiveTask, Task.Delay(OnlineTimeoutSeconds * 1000)) != receiveTask)
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

        /// <summary>
        /// Reads the "Date" header a website sends back (always UTC).
        /// Accurate to about 1 second - more than enough for a 5-minute tolerance.
        /// HTTPS, so the answer cannot be faked by someone on the network.
        /// </summary>
        private static async Task<DateTime> GetHttpsUtcAsync(string site)
        {
            using HttpResponseMessage response =
                await Http.GetAsync(site, HttpCompletionOption.ResponseHeadersRead);

            if (response.Headers.Date is DateTimeOffset date)
                return date.UtcDateTime;

            throw new Exception($"{site} sent no Date header.");
        }

        // ───────────────────────── Checks ─────────────────────────

        /// <summary>Item 5: the PC must be set to UTC+08:00.</summary>
        public static bool IsTimeZoneValid()
        {
            TimeZoneInfo.ClearCachedData();   // pick up a time zone change made while the app is open
            return TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalHours == RequiredUtcOffsetHours;
        }

        /// <summary>The PC's current UTC offset, for the error message (e.g. "UTC-07:00").</summary>
        public static string CurrentUtcOffsetText()
        {
            TimeSpan offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            return "UTC" + (offset < TimeSpan.Zero ? "-" : "+") + offset.ToString(@"hh\:mm");
        }

        /// <summary>Item 8: is the PC clock within ±5 minutes of the real time?</summary>
        public static bool IsWithinTolerance(DateTime onlineUtc)
        {
            return Math.Abs((DateTime.UtcNow - onlineUtc).TotalMinutes) <= ToleranceMinutes;
        }

        /// <summary>Converts the real UTC time to Philippine time for display / for setting the clock.</summary>
        public static DateTime ToPhilippineTime(DateTime utc)
        {
            return DateTime.SpecifyKind(utc.AddHours(RequiredUtcOffsetHours), DateTimeKind.Local);
        }

        /// <summary>
        /// The latest moment the system has ever recorded anything.
        /// Time can't legitimately go back before this (no-backdating rule).
        /// Returns null on a brand-new database with nothing recorded yet.
        ///
        /// Sources (all written with the PC's local clock):
        ///   - accepted clock checks (Rejected ones are skipped: their PC time was wrong)
        ///   - AuditLogs.LoggedAt  (logins, payments, move-ins, ...)
        ///   - Payments.RecordedAt
        ///   - Expenses.RecordedAt (includes automatic salary expenses)
        ///
        /// Throws if the database can't be reached - the form shows that as an error.
        /// </summary>
        public static DateTime? GetLastRecordedTime()
        {
            const string sql = @"
                SELECT MAX(t) FROM (
                    SELECT MAX(CheckedAt) FROM SystemClockChecks WHERE Result <> 'Rejected'
                    -- was: UNION ALL SELECT MAX(LoggedAt)   FROM AuditLogs
                    -- CHANGED (Nov 12, 2026): skip entries written BEFORE a clock check:
                    --   Login module (failed-login lockouts, Forgot Password lockouts/resets)
                    --   'Clock Changed' (written under the changed, unchecked time)
                    UNION ALL SELECT MAX(LoggedAt)   FROM AuditLogs
                              WHERE Module <> 'Login' AND Action <> 'Clock Changed'
                    UNION ALL SELECT MAX(RecordedAt) FROM Payments
                    UNION ALL SELECT MAX(RecordedAt) FROM Expenses
                ) AS x(t);";

            using SqlConnection conn = DatabaseHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();

            object result = cmd.ExecuteScalar();
            return result == null || result == DBNull.Value ? null : Convert.ToDateTime(result);
        }

        /// <summary>
        /// No-backdating rule: true when the given time is earlier than the last
        /// recorded time (minus the 5-minute tolerance for tiny Windows corrections).
        /// </summary>
        public static bool IsEarlierThanLastRecorded(DateTime localTime, DateTime? lastRecorded)
        {
            return lastRecorded.HasValue
                && localTime < lastRecorded.Value.AddMinutes(-ToleranceMinutes);
        }

        // ───────────────────────── Logging (item 7) ─────────────────────────

        /// <summary>
        /// Writes one row to SystemClockChecks. Never throws - like AuditLogger,
        /// a logging problem must not stop the user. (AuditLogger itself can't be
        /// used here: it needs a signed-in user, and this runs before Login.)
        /// </summary>
        public static void LogCheck(string result,
                                    DateTime? onlineUtc = null,
                                    DateTime? oldTime = null,
                                    DateTime? newTime = null,
                                    string? details = null)
        {
            const string sql = @"
                INSERT INTO SystemClockChecks (Result, OnlineTimeUtc, OldTime, NewTime, MachineName, Details)
                VALUES (@result, @online, @old, @new, @machine, @details);";

            try
            {
                using SqlConnection conn = DatabaseHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@result", SqlDbType.VarChar, 20).Value = result;
                cmd.Parameters.Add("@online", SqlDbType.DateTime2).Value = (object?)onlineUtc ?? DBNull.Value;
                cmd.Parameters.Add("@old", SqlDbType.DateTime2).Value = (object?)oldTime ?? DBNull.Value;
                cmd.Parameters.Add("@new", SqlDbType.DateTime2).Value = (object?)newTime ?? DBNull.Value;
                cmd.Parameters.Add("@machine", SqlDbType.NVarChar, 100).Value = Environment.MachineName;
                cmd.Parameters.Add("@details", SqlDbType.NVarChar, 300).Value =
                    string.IsNullOrWhiteSpace(details) ? DBNull.Value
                    : details.Length > 300 ? details.Substring(0, 300) : details;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Clock check log failed: " + ex);
            }
        }
    }

}
