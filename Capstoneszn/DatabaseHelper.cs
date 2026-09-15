using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Capstoneszn
{
    public static class DatabaseHelper
    {
        // Sets the database path to the same folder where your .exe runs
        public static string GetConnectionString()
        {
            string dbPath = Path.Combine(Application.StartupPath, "KSU_Apartment.db");
            return $"Data Source={dbPath};";
        }

        public static void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(GetConnectionString()))
            {
                connection.Open();

                // Step 1: Turn on Foreign Keys (Crucial for SQLite)
                var pragmaCmd = connection.CreateCommand();
                pragmaCmd.CommandText = "PRAGMA foreign_keys = ON;";
                pragmaCmd.ExecuteNonQuery();

                // Step 2: Create the initial tables if they don't exist

                // THIS TWO LINES OF CREATING TABLES
                // var command = connection.CreateCommand();
                // command.CommandText = @"  ";
                // command.ExecuteNonQuery();

                /*
                 * EXAMPLE OF CREATING A TABLE
                 * 
                 * -- TENANTS TABLE
                    CREATE TABLE IF NOT EXISTS Tenants (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        ContactNumber TEXT NOT NULL,
                        DateOccupied TEXT NOT NULL,
                        RoomId INTEGER,
                        IsArchived INTEGER DEFAULT 0,
                        -- Link the tenant directly to the RoomId
                        FOREIGN KEY(RoomId) REFERENCES Rooms(Id) ON DELETE RESTRICT
                    );
                 * 
                 */


            }
        }
    }
}
