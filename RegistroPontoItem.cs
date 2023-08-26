using System;

namespace RegistroPonto.Models
{
    public class RegistroPontoItem
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataHora { get; set; }
        public bool Chegada { get; set; }
    }
}
