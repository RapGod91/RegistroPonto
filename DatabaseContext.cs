using System;
using System.Data.SQLite;

namespace RegistroPonto.Repositories
{
    // Classe que cuida da criação e gerenciamento do banco de dados SQLite
    public class DatabaseContext
    {
        //String de cone~xoa com o banco de dados
        private const string DbConnectionString = "Data Source=registroponto.db;Version=3;";

        //Método para criar uma conexão com o BD
        public SQLiteConnection CreateConnection()
        {
            var connection = new SQLiteConnection(DbConnectionString);
            connection.Open();
            return connection;
        }

        //Mpetodo que cri a tabela funcionários
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
        //Método que cria tabela de registros de ponto
        public void CreateRegistroPontoTable()
        {
            using (var connection = CreateConnection())
            {
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS RegistroPonto (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            FuncionarioID INTEGER,
                            DataHora DATETIME
                        )";
                    command.ExecuteNonQuery();
                }
            }
        }


        //Método que insere um registro de ponto no BD
        public void InserirRegistroPonto(int funcionarioID, DateTime dataHora)
        {
            using (var connection = CreateConnection())
            {
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO RegistroPonto (FuncionarioID, DataHora) VALUES (@FuncionarioID, @DataHora)";
                    command.Parameters.AddWithValue("@FuncionarioID", funcionarioID);
                    command.Parameters.AddWithValue("@DataHora", dataHora);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
