using Dapper;

namespace RegistroPonto.Repositories
{
    public class RegistroPontoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RegistroPontoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        
    }
}
