using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Capstoneszn.Forms.EmployeeForms
{
    /// <summary>One employee, for EditEmployeeForm.</summary>
    public class EmployeeInfo
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = "";
        public string Address { get; set; } = "";
    }

    /// <summary>
    /// Database work for the Employee module (Employees + their Users login).
    /// The forms validate input and show messages; the SQL lives here.
    ///
    /// RULES (settled Oct 28, 2026)
    ///   - max 3 employees per building (archived ones don't count)
    ///   - a salary must be set before adding an employee
    ///   - a new employee is ACTIVE and can log in right away
    ///   - Status unchecked = on leave: cannot log in, still paid
    ///   - Archive stops the salary; Restore = re-hire (Date Hired = restore date)
    /// </summary>
    public static class EmployeeHelper
    {
        public const int MaxEmployeesPerBuilding = 3;

        // =====================================================================
        // PART 1 — Counts / list
        // =====================================================================

        /// <summary>Non-archived employees of a building (Active + Inactive).</summary>
        public static int CountEmployees(int buildingId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return CountEmployees(conn, null, buildingId);
            }
        }

        private static int CountEmployees(SqlConnection conn, SqlTransaction? tx, int buildingId)
        {
            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Employees WHERE BuildingId = @b AND ArchivedAt IS NULL;", conn, tx))
            {
                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>The building's non-archived employees with their username (for dgvEmployee).</summary>
        public static DataTable GetEmployees(int buildingId)
        {
            const string sql = @"
                SELECT  e.EmployeeId,
                        e.FullName,
                        u.Username,
                        e.Address,
                        e.DateHired,
                        e.EmploymentStatus
                FROM    Employees e
                LEFT JOIN Users u ON u.EmployeeId = e.EmployeeId
                WHERE   e.BuildingId = @b
                  AND   e.ArchivedAt IS NULL
                ORDER BY e.FullName;";

            var dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                da.Fill(dt);
            }
            return dt;
        }

        // =====================================================================
        // PART 2 — Add employee + login (STEP 3), all or nothing
        //   - status 'Active' -> can log in right away, salary counts from today
        //   - role 'Caretaker' (CK_Users_Role allows only Landlord / Caretaker)
        //   - password saved as a BCrypt hash, never plain text
        // =====================================================================
        public static int AddEmployee(int buildingId, string fullName, string address,
                                      DateTime dateHired, string username, string plainPassword)
        {
            // Hash first: BCrypt is slow on purpose; don't hold the transaction open for it.
            string passwordHash = SecurityHelper.Hash(plainPassword);

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 2a. 3-employee rule (checked again here in case two windows were open)
                        if (CountEmployees(conn, tx, buildingId) >= MaxEmployeesPerBuilding)
                            throw new InvalidOperationException(
                                $"This building already has {MaxEmployeesPerBuilding} employees. " +
                                "Archive one before adding another.");

                        // 2b. A salary must apply to this month - pay starts today.
                        RequireSalaryThisMonth(conn, tx, buildingId);

                        // 2c. Username must be free
                        using (var chk = new SqlCommand(
                            "SELECT COUNT(*) FROM Users WHERE Username = @u;", conn, tx))
                        {
                            chk.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = username;
                            if ((int)chk.ExecuteScalar() > 0)
                                throw new DuplicateNameException();
                        }

                        // 2d. Employees row (Active)
                        int employeeId;
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO Employees (BuildingId, FullName, Address, DateHired, EmploymentStatus)
                            VALUES (@b, @name, @addr, @hired, 'Active');
                            SELECT CAST(SCOPE_IDENTITY() AS int);", conn, tx))
                        {
                            cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = fullName;
                            cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 255).Value = address;
                            cmd.Parameters.Add("@hired", SqlDbType.Date).Value = dateHired.Date;
                            employeeId = (int)cmd.ExecuteScalar();
                        }

                        // 2e. Users row (the login) linked to that employee
                        using (var cmd = new SqlCommand(@"
                            INSERT INTO Users (Username, Password, Role, Name, EmployeeId)
                            VALUES (@u, @p, 'Caretaker', @name, @id);", conn, tx))
                        {
                            cmd.Parameters.Add("@u", SqlDbType.NVarChar, 50).Value = username;
                            cmd.Parameters.Add("@p", SqlDbType.NVarChar, 255).Value = passwordHash;
                            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = fullName;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                            cmd.ExecuteNonQuery();
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Add Employee",
                            $"Added {fullName} (username {username})");

                        tx.Commit();
                        return employeeId;
                    }
                    catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                    {
                        tx.Rollback();
                        throw new DuplicateNameException();   // username taken (unique index)
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        private static void RequireSalaryThisMonth(SqlConnection conn, SqlTransaction tx, int buildingId)
        {
            using (var cmd = new SqlCommand(@"
                SELECT COUNT(*) FROM SalaryRates
                WHERE  BuildingId = @b AND EffectiveMonth <= @m;", conn, tx))
            {
                cmd.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                cmd.Parameters.Add("@m", SqlDbType.Date).Value = SalaryHelper.FirstOfMonth(DateTime.Today);
                if ((int)cmd.ExecuteScalar() == 0)
                    throw new InvalidOperationException("Set the salary first (Salary button).");
            }
        }

        // =====================================================================
        // PART 3 — Status checkbox (STEP 4)
        //   Active   -> can log in
        //   Inactive -> on leave: cannot log in, STILL PAID (salary not touched)
        // =====================================================================
        public static void SetStatus(int employeeId, bool active)
        {
            string newStatus = active ? "Active" : "Inactive";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string name;
                        using (var cmd = new SqlCommand(@"
                            UPDATE Employees
                            SET    EmploymentStatus = @s
                            OUTPUT inserted.FullName
                            WHERE  EmployeeId = @id
                              AND  ArchivedAt IS NULL
                              AND  EmploymentStatus <> @s;", conn, tx))
                        {
                            cmd.Parameters.Add("@s", SqlDbType.NVarChar, 20).Value = newStatus;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                            object? v = cmd.ExecuteScalar();
                            if (v == null)
                                throw new InvalidOperationException(
                                    "This employee's status was already changed or they were archived. Refresh the list.");
                            name = (string)v;
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee,
                            active ? "Set Active" : "Set Inactive",
                            $"{name} set to {newStatus}" + (active ? "" : " (on leave)"));

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // =====================================================================
        // PART 4 — Edit name and address (STEP 5)
        // The login's display name (Users.Name) is updated too, so the header
        // shows the new name when that caretaker logs in.
        // =====================================================================
        public static EmployeeInfo? GetEmployee(int employeeId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT EmployeeId, FullName, Address
                FROM   Employees
                WHERE  EmployeeId = @id AND ArchivedAt IS NULL;", conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    return new EmployeeInfo
                    {
                        EmployeeId = r.GetInt32(0),
                        FullName = r.GetString(1),
                        Address = r.IsDBNull(2) ? "" : r.GetString(2)
                    };
                }
            }
        }

        public static void UpdateEmployee(int employeeId, string fullName, string address)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Old values, for the audit log
                        string oldName, oldAddress;
                        using (var cmd = new SqlCommand(@"
                            SELECT FullName, Address FROM Employees
                            WHERE  EmployeeId = @id AND ArchivedAt IS NULL;", conn, tx))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                            using (var r = cmd.ExecuteReader())
                            {
                                if (!r.Read())
                                    throw new InvalidOperationException(
                                        "This employee was archived. Refresh the list.");
                                oldName = r.GetString(0);
                                oldAddress = r.IsDBNull(1) ? "" : r.GetString(1);
                            }
                        }

                        using (var cmd = new SqlCommand(@"
                            UPDATE Employees SET FullName = @name, Address = @addr WHERE EmployeeId = @id;
                            UPDATE Users     SET Name = @name                     WHERE EmployeeId = @id;", conn, tx))
                        {
                            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = fullName;
                            cmd.Parameters.Add("@addr", SqlDbType.NVarChar, 255).Value = address;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                            cmd.ExecuteNonQuery();
                        }

                        string change = "";
                        if (oldName != fullName) change += $"Name: {oldName} -> {fullName}. ";
                        if (oldAddress != address) change += $"Address: {oldAddress} -> {address}.";
                        AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Edit Employee", change.Trim());

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // =====================================================================
        // PART 5 — Archive (STEP 6)
        //   - warns (does not block) about Pending maintenance issues
        //   - the employee can no longer log in (LoginForm checks ArchivedAt)
        //   - the salary stops: the final days of this month are recorded now
        // =====================================================================

        /// <summary>Pending (repair not done), non-deleted issues this employee is Responsible for.</summary>
        public static int CountPendingIssues(int employeeId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT COUNT(DISTINCT mi.IssueId)
                FROM   MaintenanceResponsible mr
                JOIN   MaintenanceIssues mi ON mi.IssueId = mr.IssueId
                WHERE  mr.EmployeeId = @id
                  AND  mi.Status = 'Pending'
                  AND  mi.IsDeleted = 0;", conn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>Archives the employee. Returns the final salary amount recorded.</summary>
        public static decimal Archive(int employeeId, int userId)
        {
            // Catch up any finished month first (e.g. the app stayed open past midnight
            // into a new month), so no month is skipped.
            SalaryHelper.RecordMonthEndSalaries(userId);

            DateTime now = DateTime.Now;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string name;
                        int buildingId;
                        DateTime dateHired;
                        using (var cmd = new SqlCommand(@"
                            SELECT FullName, BuildingId, DateHired
                            FROM   Employees
                            WHERE  EmployeeId = @id AND ArchivedAt IS NULL;", conn, tx))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                            using (var r = cmd.ExecuteReader())
                            {
                                if (!r.Read())
                                    throw new InvalidOperationException(
                                        "This employee is already archived. Refresh the list.");
                                name = r.GetString(0);
                                buildingId = r.GetInt32(1);
                                dateHired = r.GetDateTime(2);
                            }
                        }

                        using (var cmd = new SqlCommand(@"
                            UPDATE Employees SET ArchivedAt = @now
                            WHERE  EmployeeId = @id AND ArchivedAt IS NULL;", conn, tx))
                        {
                            cmd.Parameters.Add("@now", SqlDbType.DateTime2).Value = now;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                            cmd.ExecuteNonQuery();
                        }

                        decimal finalPay = SalaryHelper.RecordFinalSalary(conn, tx, employeeId, buildingId,
                            name, dateHired, now.Date, userId);

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Archive Employee",
                            $"Archived {name}; final salary {finalPay:N2}");

                        tx.Commit();
                        return finalPay;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // =====================================================================
        // PART 6 — Restore = re-hire (STEP 9, Settings > Archive > Employee)
        //   - blocked if the building already has 3 employees
        //   - comes back Active, Date Hired = today -> salary counts from today
        //   - the original hire date is kept in the audit log
        // =====================================================================
        public static DataTable GetArchivedEmployees(int buildingId)
        {
            const string sql = @"
                SELECT EmployeeId, ArchivedAt, FullName, Address, DateHired
                FROM   Employees
                WHERE  BuildingId = @b AND ArchivedAt IS NOT NULL
                ORDER BY ArchivedAt DESC;";

            var dt = new DataTable();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.Add("@b", SqlDbType.Int).Value = buildingId;
                da.Fill(dt);
            }
            return dt;
        }

        public static void Restore(int employeeId)
        {
            DateTime today = DateTime.Today;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string name;
                        int buildingId;
                        DateTime oldHired, archivedAt;
                        using (var cmd = new SqlCommand(@"
                            SELECT FullName, BuildingId, DateHired, ArchivedAt
                            FROM   Employees
                            WHERE  EmployeeId = @id AND ArchivedAt IS NOT NULL;", conn, tx))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                            using (var r = cmd.ExecuteReader())
                            {
                                if (!r.Read())
                                    throw new InvalidOperationException(
                                        "This employee is no longer archived. Refresh the list.");
                                name = r.GetString(0);
                                buildingId = r.GetInt32(1);
                                oldHired = r.GetDateTime(2);
                                archivedAt = r.GetDateTime(3);
                            }
                        }

                        if (archivedAt.Date > today)
                            throw new InvalidOperationException(
                                "The PC date is earlier than the archive date. Check the system clock.");

                        if (CountEmployees(conn, tx, buildingId) >= MaxEmployeesPerBuilding)
                            throw new InvalidOperationException(
                                $"This building already has {MaxEmployeesPerBuilding} employees. " +
                                "Archive one before restoring another.");

                        RequireSalaryThisMonth(conn, tx, buildingId);

                        using (var cmd = new SqlCommand(@"
                            UPDATE Employees
                            SET    ArchivedAt = NULL,
                                   EmploymentStatus = 'Active',
                                   DateHired = @today
                            WHERE  EmployeeId = @id AND ArchivedAt IS NOT NULL;", conn, tx))
                        {
                            cmd.Parameters.Add("@today", SqlDbType.Date).Value = today;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
                            cmd.ExecuteNonQuery();
                        }

                        AuditLogger.Log(conn, tx, AuditLogger.ModuleEmployee, "Restore Employee",
                            $"Re-hired {name} on {today:MMM dd, yyyy} (first hired {oldHired:MMM dd, yyyy})");

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}