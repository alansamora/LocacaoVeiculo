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
    [Route("api/marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        // GET: Buscar todas as marcas
        [HttpGet]
        public IActionResult Get()
        {
            var marcas = _marcaRepository.ListarMarcas();
            return new OkObjectResult(marcas);
        }

        // GET Buscar a marca pelo id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var marca = _marcaRepository.ObterMarcaPorId(id);
            return new OkObjectResult(marca);
        }

        // POST Inserir uma marca
        [HttpPost]
        public IActionResult Post([FromBody] Marca marca)
        {
            using (var scope = new TransactionScope())
            {
                _marcaRepository.InserirMarca(marca);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = marca.Id }, marca);
            }
        }

        // PUT Atualizar uma marca
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Marca marca)
        {
            if (marca != null)
            {
                using (var scope = new TransactionScope())
                {
                    _marcaRepository.AtualizarMarca(marca);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE Deletar uma marca
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _marcaRepository.DeletarMarca(id);
            return new OkResult();
        }
    }
}
