using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculoMicroservice.ModelDB;

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

        public Veiculo(VeiculoDB veiculoDB, Marca marca, Modelo modelo)
        {
            Id = veiculoDB.Id;
            Placa = veiculoDB.Placa;
            Ano = veiculoDB.Ano;
            ValorHora = veiculoDB.ValorHora;
            Combustivel = veiculoDB.Combustivel;
            LimitePortaMalas = veiculoDB.LimitePortaMalas;
            Categoria = veiculoDB.Categoria;
            Marca = marca;
            Modelo = modelo;
        }
    }
}
