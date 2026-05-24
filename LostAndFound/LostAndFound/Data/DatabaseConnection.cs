using System.Configuration;
using System.Data.SqlClient;

namespace LostAndFound
{
    internal static class DatabaseConnection
    {
        private const string ConnectionStringName = "DbConn";

        public static string ConnectionString
        {
            get
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[ConnectionStringName];

                if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                {
                    throw new ConfigurationErrorsException("Connection string 'DbConn' is missing from App.config.");
                }

                return settings.ConnectionString;
            }
        }

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
