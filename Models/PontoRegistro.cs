using System;

namespace RegistroPonto.Models
{
    public class PontoRegistro
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataHoraRegistro { get; set; }
    }
}
