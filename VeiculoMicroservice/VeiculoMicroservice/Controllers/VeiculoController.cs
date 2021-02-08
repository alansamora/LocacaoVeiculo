using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using VeiculoMicroservice.Model;
using VeiculoMicroservice.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VeiculoMicroservice.Controllers
{
    [Route("api/veiculo")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        // GET: Buscar todos os veiculos
        [HttpGet]
        public IActionResult Get()
        {
            var veiculos = _veiculoRepository.ListarVeiculos();
            return new OkObjectResult(veiculos);
        }

        // GET Buscar o veiculo pelo id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var veiculo = _veiculoRepository.ObterVeiculoPorId(id);
            return new OkObjectResult(veiculo);
        }

        // POST Inserir um veiculo
        [HttpPost]
        public IActionResult Post([FromBody] Veiculo veiculo)
        {
            using (var scope = new TransactionScope())
            {
                _veiculoRepository.InserirVeiculo(veiculo);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
            }
        }

        // PUT Atualizar um veiculo
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Veiculo veiculo)
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
