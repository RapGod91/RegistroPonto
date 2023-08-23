using Dapper;
using RegistroPonto.Models;


namespace RegistroPonto.Repositories
{
    public class FuncionarioRepository
    {
        private readonly DatabaseContext _databaseContext;

        public FuncionarioRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                const string sql = "INSERT INTO Funcionarios (Nome, Cargo, FotoPath) VALUES (@Nome, @Cargo, @FotoPath)";
                connection.Execute(sql, funcionario);
            }
        }
        public void AtualizarFuncionario(Funcionario funcionario)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                const string sql = "UPDATE Funcionarios SET Nome = @Nome, Cargo = @Cargo, FotoPath = @FotoPath WHERE Id = @Id";
                connection.Execute(sql, funcionario);
            }
        }

        public void ExcluirFuncionario(Funcionario funcionario)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                const string sql = "DELETE FROM Funcionarios WHERE Id = @Id";
                connection.Execute(sql, funcionario);
            }
        }

        public Funcionario BuscarFuncionarioPorId(int id)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                const string sql = "SELECT * FROM Funcionarios WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Funcionario>(sql, new { Id = id });
            }
        }

    }
}
