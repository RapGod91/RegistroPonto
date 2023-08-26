using Dapper;
using RegistroPonto.Models;
using System;
using System.Data.SQLite;

namespace RegistroPonto.Repositories
{
    public class RegistroPontoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RegistroPontoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
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
