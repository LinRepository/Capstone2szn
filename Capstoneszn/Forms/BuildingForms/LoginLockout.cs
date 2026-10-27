using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Capstoneszn.Forms.BuildingForms
{

    /// <summary>
    /// Login attempt limit - Option B, progressive cooldown (settled Oct 23, 2026).
    ///
    ///   3 failed attempts -> locked 1 min, then 5 min, then 15 min for every lockout after that.
    ///   A successful login or a completed password reset sets everything back to 0.
    ///
    /// The state lives in dbo.Users (FailedLoginCount, LockoutCount, LockoutUntilUtc), so
    /// closing and reopening the app does not reset it. Every time comparison is done by
    /// SQL Server with SYSUTCDATETIME() - never DateTime.Now - and stored in UTC, so a
    /// time-zone change on the PC cannot shorten a lock.
    ///
    /// Used by LoginForm, ChangePasswordForm and SecurityQuestionsForm (a wrong Current
    /// Password counts toward the same lockout) and PasswordResetForm (reset).
    /// </summary>
    public static class LoginLockout
    {
        public const int MaxFailedAttempts = 3;

        // The only place the lock lengths are defined; the SQL receives them as parameters.
        private const int FirstLockMinutes = 1;
        private const int SecondLockMinutes = 5;
        private const int MaxLockMinutes = 15;

        /// <summary>
        /// Seconds left on the account's current lock, rounded up; 0 when not locked.
        /// Call this BEFORE checking the password, so a correct password typed during a
        /// lock is still refused.
        /// </summary>
        public static int GetSecondsRemaining(SqlConnection conn, int userId)
        {
            const string sql = @"
                SELECT CASE WHEN LockoutUntilUtc > SYSUTCDATETIME()
                            THEN (DATEDIFF(MILLISECOND, SYSUTCDATETIME(), LockoutUntilUtc) + 999) / 1000
                            ELSE 0 END
                FROM dbo.Users
                WHERE UserId = @UserId;";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                object? result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
            }
        }

        /// <summary>
        /// Records one wrong password. Returns the length in minutes of the lock that this
        /// failure just started (1, 5 or 15), or 0 if the account is not locked yet.
        ///
        /// One atomic UPDATE: every right-hand side reads the values from BEFORE the update,
        /// so the 3rd failure becomes a lockout in the same statement. An account that is
        /// already locked is left untouched (the WHERE clause), so attempts during a lock
        /// cannot extend it.
        /// </summary>
        public static int RecordFailure(SqlConnection conn, int userId)
        {
            const string sql = @"
                UPDATE dbo.Users
                SET FailedLoginCount = CASE WHEN FailedLoginCount + 1 >= @Max THEN 0
                                            ELSE FailedLoginCount + 1 END,
                    LockoutCount     = CASE WHEN FailedLoginCount + 1 >= @Max THEN LockoutCount + 1
                                            ELSE LockoutCount END,
                    LockoutUntilUtc  = CASE WHEN FailedLoginCount + 1 >= @Max
                                            THEN DATEADD(MINUTE,
                                                     CASE LockoutCount WHEN 0 THEN @Lock1
                                                                       WHEN 1 THEN @Lock2
                                                                       ELSE @Lock3 END,
                                                     SYSUTCDATETIME())
                                            ELSE LockoutUntilUtc END
                OUTPUT CASE WHEN inserted.LockoutCount > deleted.LockoutCount
                            THEN CASE deleted.LockoutCount WHEN 0 THEN @Lock1
                                                           WHEN 1 THEN @Lock2
                                                           ELSE @Lock3 END
                            ELSE 0 END
                WHERE UserId = @UserId
                  AND (LockoutUntilUtc IS NULL OR LockoutUntilUtc <= SYSUTCDATETIME());";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cmd.Parameters.Add("@Max", SqlDbType.Int).Value = MaxFailedAttempts;
                cmd.Parameters.Add("@Lock1", SqlDbType.Int).Value = FirstLockMinutes;
                cmd.Parameters.Add("@Lock2", SqlDbType.Int).Value = SecondLockMinutes;
                cmd.Parameters.Add("@Lock3", SqlDbType.Int).Value = MaxLockMinutes;

                object? result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
            }
        }

        /// <summary>Clears the counters after a successful password check.</summary>
        public static void Reset(SqlConnection conn, int userId)
        {
            const string sql = @"
                UPDATE dbo.Users
                SET FailedLoginCount = 0, LockoutCount = 0, LockoutUntilUtc = NULL
                WHERE UserId = @UserId
                  AND (FailedLoginCount <> 0 OR LockoutCount <> 0 OR LockoutUntilUtc IS NOT NULL);";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>The message shown whenever an account is locked.</summary>
        public static string LockedMessage(int secondsRemaining)
        {
            return "Too many failed attempts. This account is locked for " +
                   FormatDuration(secondsRemaining) + ".\n\n" +
                   "Try again later, or use \"Forgot Password?\" on the login screen " +
                   "to reset your password with your security questions.";
        }

        private static string FormatDuration(int seconds)
        {
            if (seconds < 1) seconds = 1;
            if (seconds < 60) return seconds + " sec";

            int minutes = seconds / 60;
            int rest = seconds % 60;
            return rest == 0 ? minutes + " min" : minutes + " min " + rest + " sec";
        }
    }

}
