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
    }
}
