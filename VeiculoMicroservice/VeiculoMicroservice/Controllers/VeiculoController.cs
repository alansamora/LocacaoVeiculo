﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using VeiculoMicroservice.Model;
using VeiculoMicroservice.ModelDB;
using VeiculoMicroservice.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VeiculoMicroservice.Controllers
{
    [Route("api/veiculo")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IModeloRepository _modeloRepository;
        private readonly IMarcaRepository _marcaRepository;

        public VeiculoController(IVeiculoRepository veiculoRepository, IModeloRepository modeloRepository, IMarcaRepository marcaRepository)
        {
            _veiculoRepository = veiculoRepository;
            _modeloRepository = modeloRepository;
            _marcaRepository = marcaRepository;
        }

        // GET: Buscar todos os veiculos
        [HttpGet]
        public IActionResult Get()
        {
            var veiculos = _veiculoRepository.ListarVeiculos();
            var veiculosRetorno = new List<Veiculo>();
            if (veiculos.Count > 0)
            {
                foreach (VeiculoDB veiculoDB in veiculos)
                {
                    var modelo = _modeloRepository.ObterModeloPorId(veiculoDB.ModeloId);
                    var modeloRetorno = new Modelo(modelo.Id, modelo.Nome, _marcaRepository.ObterMarcaPorId(modelo.MarcaId));
                    var marca = _marcaRepository.ObterMarcaPorId(veiculoDB.MarcaId);
                    var veiculo = new Veiculo(veiculoDB, marca.Nome, modeloRetorno.Nome);
                    veiculosRetorno.Add(veiculo);
                }
            }
            return new OkObjectResult(veiculosRetorno);
        }

        // GET Buscar todos os veiculos por categoria
        [HttpGet("{categoria}/categoria")]
        public IActionResult Get(TipoCategoria categoria)
        {
            var veiculos = _veiculoRepository.ListarVeiculosPorCategoria((int)categoria);
            var veiculosRetorno = new List<Veiculo>();
            if (veiculos.Count > 0)
            {
                foreach (VeiculoDB veiculoDB in veiculos)
                {
                    var modelo = _modeloRepository.ObterModeloPorId(veiculoDB.ModeloId);
                    var modeloRetorno = new Modelo(modelo.Id, modelo.Nome, _marcaRepository.ObterMarcaPorId(modelo.MarcaId));
                    var marca = _marcaRepository.ObterMarcaPorId(veiculoDB.MarcaId);
                    var veiculo = new Veiculo(veiculoDB, marca.Nome, modeloRetorno.Nome);
                    veiculosRetorno.Add(veiculo);
                }
            }
            return new OkObjectResult(veiculosRetorno);
        }

        // GET Buscar o veiculo pelo id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var veiculo = _veiculoRepository.ObterVeiculoPorId(id);
            if (veiculo != null)
            {
                var modelo = _modeloRepository.ObterModeloPorId(veiculo.ModeloId);
                var modeloRetorno = new Modelo(modelo.Id, modelo.Nome, _marcaRepository.ObterMarcaPorId(modelo.MarcaId));
                var marca = _marcaRepository.ObterMarcaPorId(veiculo.MarcaId);
                var veiculoRetorno = new Veiculo(veiculo, marca.Nome, modeloRetorno.Nome);
                return new OkObjectResult(veiculoRetorno);
            }
            return new NoContentResult();
        }

        // POST Inserir um veiculo
        [HttpPost]
        public IActionResult Post([FromBody] VeiculoDB veiculo)
        {
            using (var scope = new TransactionScope())
            {
                _veiculoRepository.InserirVeiculo(veiculo);
                scope.Complete();
            }
            if (veiculo.Id > 0)
            {
                var modelo = _modeloRepository.ObterModeloPorId(veiculo.ModeloId);
                var modeloRetorno = new Modelo(modelo.Id, modelo.Nome, _marcaRepository.ObterMarcaPorId(modelo.MarcaId));
                var marca = _marcaRepository.ObterMarcaPorId(veiculo.MarcaId);
                var veiculoRetorno = new Veiculo(veiculo, marca.Nome, modeloRetorno.Nome);
                return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculoRetorno);
            }
            return new NoContentResult();
        }

        // PUT Atualizar um veiculo
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] VeiculoDB veiculo)
        {
            if (veiculo != null)
            {
                using (var scope = new TransactionScope())
                {
                    _veiculoRepository.AtualizarVeiculo(veiculo);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE Deletar um veiculo
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _veiculoRepository.DeletarVeiculo(id);
            return new OkResult();
        }
    }
}
