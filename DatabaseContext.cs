using System.Data.SQLite;

namespace RegistroPonto.Repositories
{
    public class DatabaseContext
    {
        private const string DbConnectionString = "Data Source=registroponto.db;Version=3;";

        public SQLiteConnection CreateConnection()
        {
            var connection = new SQLiteConnection(DbConnectionString);
            connection.Open();
            return connection;
        }
    }
}
