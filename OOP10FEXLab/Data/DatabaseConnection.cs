using MySql.Data.MySqlClient;

namespace OOP10FEXLab.Data
{
    /// <summary>
    /// Connection settings for the instructor's MySQL database (based on the provided DBconnection.cs).
    /// Written without C# 9 shortcuts (target-typed "new") so it compiles on .NET Framework 4.7.2 (C# 7.3).
    /// </summary>
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Default settings for this app. Change user / password here.
        /// Connect Timeout=3: if the instructor's PC cannot be reached (for example at home),
        /// give up after 3 seconds instead of 15, and the app uses the .txt files instead.
        /// </summary>
        public static DatabaseConnection CreateDefault()
        {
            return new DatabaseConnection("Server=172.16.24.11;Port=3306;Database=fastfoodDB;Uid=root;Pwd=;Connect Timeout=3;");
        }

        /// <summary>Returns a NEW, not-yet-opened connection. Callers open and dispose it.</summary>
        public MySqlConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
