using Dapper;
using RegistroPonto.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegistroPonto.Repositories
{
    // Classe que realiza operações de acesso a dados relacionadas a funcionários
    public class FuncionarioRepository
    {
        private readonly DatabaseContext _databaseContext;

        //Construtor que recebe contexto do BD
        public FuncionarioRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        private List<Funcionario> _funcionarios;

        

        // Método para buscar funcionário por nome
        public Funcionario BuscarFuncionarioPorNome(string nome)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                const string sql = "SELECT * FROM Funcionarios WHERE Nome = @Nome";
                return connection.QueryFirstOrDefault<Funcionario>(sql, new { Nome = nome });
            }
        }

        //Métodos do CRUD, porém sem o atualizar implementado.
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

        //Métodos para buscar funcionario
        public Funcionario BuscarFuncionarioPorId(int id)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                const string sql = "SELECT * FROM Funcionarios WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Funcionario>(sql, new { Id = id });
            }
        }
        public List<Funcionario> ObterTodosFuncionarios()
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                const string sql = "SELECT * FROM Funcionarios";
                return connection.Query<Funcionario>(sql).ToList();
            }
        }
        



    }
}
