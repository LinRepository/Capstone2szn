using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace Capstoneszn
{
    public static class DatabaseHelper
    {
        // Your specific connection string for SQL Server Express
        //private static readonly string connectionString = @"Server=LAPTOP-TRR0U4GS\SQLEXPRESS;Database=ApartmentDB;Integrated Security=True;TrustServerCertificate=True;";

        //private static readonly string connectionString = @"Server=LAPTOP-TRR0U4GS\SQLEXPRESS;Database=ApartmentDB;Integrated Security=True;TrustServerCertificate=True;";
        private static readonly string connectionString = @"Server=LAPTOP-TRR0U4GS\SQLEXPRESS;Database=ApartmentDB;Integrated Security=True;TrustServerCertificate=True;";

        // Method to get a new SQL connection whenever you need to query the database
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // A temporary method just to test if the connection actually works
        public static void TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Connection to SQL Server Express was successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
