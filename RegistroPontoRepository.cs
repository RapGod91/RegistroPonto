using Dapper;
using RegistroPonto.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistroPonto.Repositories
{
    //Classe responsável pelos registros no BD
    public class RegistroPontoRepository
    {
        private readonly DatabaseContext _databaseContext;

        //Construtor recebendo instância de DAtabaseContext
        public RegistroPontoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        
        //Método para obter os registros de ponto do funcionario
        public List<RegistroPontoItem> ObterRegistrosPontoPorFuncionario(Funcionario funcionario)
        {
            using (var connection = _databaseContext.CreateConnection())
            {
                const string sql = "SELECT * FROM RegistroPonto WHERE FuncionarioId = @FuncionarioId";
                return connection.Query<RegistroPontoItem>(sql, new { FuncionarioId = funcionario.Id }).ToList();
            }
        }

        //Cria a tabela de registros de ponto
        public void CriarTabelaRegistroPonto()
        {
            _databaseContext.CreateRegistroPontoTable();
        }

        //Inserir registro de ponto no BD
        public void InserirRegistroPonto(int funcionarioID, DateTime dataHora)
        {
            _databaseContext.InserirRegistroPonto(funcionarioID, dataHora);
        }
    }
}
