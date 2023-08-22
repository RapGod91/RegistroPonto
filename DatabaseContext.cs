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

        public void CreateFuncionarioTable()
        {
            using (var connection = CreateConnection())
            {
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Funcionarios (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nome TEXT,
                            Cargo TEXT,
                            FotoPath TEXT
                        )";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
