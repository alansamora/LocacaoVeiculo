using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Dominio.Entidades
{
    public class Locacao
    {
        public int Id { get; set; }
        public double ValorHora { get; set; }
        public double TotalHora { get; set; }
        public DateTime DataInicioLocacao { get; set; }
        public DateTime DataFimLocacao { get; set; }
        public int ClienteId { get; set; }
        public Veiculo Veiculo { get; set; }

        private double _valorTotal;
        public double ValorTotal
        {
            get => _valorTotal;
            set => _valorTotal = (ValorHora * TotalHora);
        }
    }
}
