using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeiculoMicroservice.Model
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public double ValorHora { get; set; }
        public TipoCombustivel Combustivel { get; set; }
        public int LimitePortaMalas { get; set; }
        public TipoCategoria Categoria { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
    }
}
