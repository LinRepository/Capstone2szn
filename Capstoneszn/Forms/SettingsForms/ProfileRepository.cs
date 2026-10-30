using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstoneszn.Forms.SettingsForms
{

    public class UserProfile
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }          // 'Landlord' or 'Caretaker'
        public int? EmployeeId { get; set; }      // set only for Caretaker
    }

    public enum PasswordCheckResult
    {
        Ok,
        WrongPassword,   // wrong, but not locked yet
        LockedNow,       // this wrong attempt triggered a lockout
        AlreadyLocked    // account was already locked before this attempt
    }

    public static class ProfileRepository
    {
        private static string ConnStr => @"Server=LAPTOP-1LRDH7J7\SQLEXPRESS;Database=ApartmentDB;Integrated Security=True;TrustServerCertificate=True;";

        public static UserProfile GetProfile(int userId)
        {
            const string sql = @"SELECT UserId, Username, Name, Role, EmployeeId
                                 FROM Users WHERE UserId = @UserId";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    return new UserProfile
                    {
                        UserId = r.GetInt32(0),
                        Username = r.GetString(1),
                        Name = r.IsDBNull(2) ? "" : r.GetString(2),
                        Role = r.GetString(3),
                        EmployeeId = r.IsDBNull(4) ? (int?)null : r.GetInt32(4)
                    };
                }
            }
        }

        // True if ANOTHER user already has this username.
        public static bool IsUsernameTaken(string username, int userId)
        {
            const string sql = @"SELECT COUNT(1) FROM Users
                                 WHERE Username = @Username AND UserId <> @UserId";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Verifies the current password and applies the same lockout rule as login:
        // 3 wrong attempts -> lock; lock time escalates 1 min -> 5 min -> 15 min (cap).
        // NOTE: if your login code already has a "record failed attempt" method,
        // call that instead of the failed-attempt block below so the rule lives in one place.
        public static PasswordCheckResult VerifyPassword(int userId, string password)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    string hash;
                    int failed, lockouts;
                    bool isLocked;

                    const string readSql = @"
                        SELECT Password, FailedLoginCount, LockoutCount,
                               CASE WHEN LockoutUntilUtc > SYSUTCDATETIME() THEN 1 ELSE 0 END
                        FROM Users WITH (UPDLOCK) WHERE UserId = @UserId";

                    using (var cmd = new SqlCommand(readSql, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (!r.Read()) throw new InvalidOperationException("User not found.");
                            hash = r.GetString(0);
                            failed = r.GetInt32(1);
                            lockouts = r.GetInt32(2);
                            isLocked = r.GetInt32(3) == 1;
                        }
                    }

                    if (isLocked)
                    {
                        tx.Commit();
                        return PasswordCheckResult.AlreadyLocked;
                    }

                    if (BCrypt.Net.BCrypt.Verify(password, hash))
                    {
                        if (failed > 0)
                        {
                            using (var cmd = new SqlCommand(
                                "UPDATE Users SET FailedLoginCount = 0 WHERE UserId = @UserId", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                        return PasswordCheckResult.Ok;
                    }

                    // ----- wrong password: count the attempt -----
                    failed++;
                    PasswordCheckResult result;
                    string updateSql;

                    if (failed >= 3)
                    {
                        lockouts++;
                        int minutes = lockouts == 1 ? 1 : (lockouts == 2 ? 5 : 15);
                        updateSql = @"UPDATE Users
                                      SET FailedLoginCount = 0,
                                          LockoutCount = @Lockouts,
                                          LockoutUntilUtc = DATEADD(MINUTE, @Minutes, SYSUTCDATETIME())
                                      WHERE UserId = @UserId";
                        using (var cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Lockouts", lockouts);
                            cmd.Parameters.AddWithValue("@Minutes", minutes);
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.ExecuteNonQuery();
                        }
                        result = PasswordCheckResult.LockedNow;
                    }
                    else
                    {
                        updateSql = "UPDATE Users SET FailedLoginCount = @Failed WHERE UserId = @UserId";
                        using (var cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Failed", failed);
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.ExecuteNonQuery();
                        }
                        result = PasswordCheckResult.WrongPassword;
                    }

                    tx.Commit();
                    return result;
                }
            }
        }

        // Saves name + username. For a Caretaker, Employees.FullName is updated in the
        // same transaction so the two copies of the name never drift apart.
        // Returns false if the username was taken at the last second (unique index).
        public static bool UpdateProfile(UserProfile profile, string newName, string newUsername)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SqlCommand(
                            "UPDATE Users SET Name = @Name, Username = @Username WHERE UserId = @UserId",
                            conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@Name", newName);
                            cmd.Parameters.AddWithValue("@Username", newUsername);
                            cmd.Parameters.AddWithValue("@UserId", profile.UserId);
                            cmd.ExecuteNonQuery();
                        }

                        if (profile.Role == "Caretaker" && profile.EmployeeId.HasValue)
                        {
                            using (var cmd = new SqlCommand(
                                "UPDATE Employees SET FullName = @Name WHERE EmployeeId = @EmployeeId",
                                conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@Name", newName);
                                cmd.Parameters.AddWithValue("@EmployeeId", profile.EmployeeId.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                        return true;
                    }
                    catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                    {
                        tx.Rollback();
                        return false; // duplicate username
                    }
                }
            }
        }
    }


}
