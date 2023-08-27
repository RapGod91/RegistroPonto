using Dapper;
using RegistroPonto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistroPonto.Repositories
{
    public class RegistroPontoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RegistroPontoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Método para obter registros de ponto por funcionário
        public List<RegistroPontoItem> ObterRegistrosPontoPorFuncionario(Funcionario funcionario)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                const string sql = "SELECT * FROM RegistroPonto WHERE FuncionarioId = @FuncionarioId";
                return connection.Query<RegistroPontoItem>(sql, new { FuncionarioId = funcionario.Id }).ToList();
            }
        }

        public void CriarTabelaRegistroPonto()
        {
            _databaseContext.CreateRegistroPontoTable();
        }

        public void InserirRegistroPonto(int funcionarioID, DateTime dataHora)
        {
            _databaseContext.InserirRegistroPonto(funcionarioID, dataHora);
        }
    }
}
