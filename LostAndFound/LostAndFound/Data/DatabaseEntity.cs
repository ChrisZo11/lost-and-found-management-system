using System;
using System.Data.SqlClient;

namespace LostAndFound
{
    public abstract class DatabaseEntity
    {
        private readonly string connectionString;

        protected DatabaseEntity()
            : this(DatabaseConnection.ConnectionString)
        {
        }

        protected DatabaseEntity(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Connection string cannot be empty.", nameof(connectionString));
            }

            this.connectionString = connectionString;
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
