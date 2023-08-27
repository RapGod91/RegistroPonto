using System;

namespace RegistroPonto.Models
{
    // Classe que representa um registro de ponto
    public class RegistroPontoItem
    {
        //Propriedades que armazenam os dados do registro ponto
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataHora { get; set; }
        public bool Chegada { get; set; }
    }
}
