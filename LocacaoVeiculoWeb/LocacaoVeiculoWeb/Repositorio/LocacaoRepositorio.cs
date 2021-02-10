﻿using LocacaoVeiculoWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LocacaoVeiculoWeb.Repositorio
{
    public class LocacaoRepositorio : ILocacaoRepositorio
    {
        static HttpClient _httpClient;

        public LocacaoRepositorio()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri("http://localhost:60729/api/");
            }
        }

        public List<Locacao> BuscarLocacoes(BuscarLocacao buscarLocacao)
        {
            var url = $"locacao/{buscarLocacao.DataLocacaoInicio.ToString("yyyy-MM-ddTHH:mm:ss")}/{buscarLocacao.DataLocacaoFim.ToString("yyyy-MM-ddTHH:mm:ss")}/{buscarLocacao.ClienteId}/cliente";
            var retorno = _httpClient.GetAsync(url).Result;
            var resultado = retorno.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Locacao>>(resultado);
        }

        public List<Veiculo> BuscarVeiculosDisponiveis(BuscarVeiculo buscarVeiculo)
        {
            var url = $"locacao/{buscarVeiculo.DataReservaInicio.ToString("yyyy-MM-ddTHH:mm:ss")}/{buscarVeiculo.DataReservaFim.ToString("yyyy-MM-ddTHH:mm:ss")}/{buscarVeiculo.Categoria}/categoria";
            var retorno = _httpClient.GetAsync(url).Result;
            var resultado = retorno.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Veiculo>>(resultado);
        }
    }
}
