using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Infraestrutura.DBModels
{
    public class LocacaoDbModel
    {
        public int Id { get; set; }
        public double ValorHora { get; set; }
        public double TotalHora { get; set; }
        public DateTime DataInicioLocacao { get; set; }
        public DateTime DataFimLocacao { get; set; }
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
    }
}
