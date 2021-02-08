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
    [Route("api/modelo")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloController(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        // GET: Buscar todos os modelos
        [HttpGet]
        public IActionResult Get()
        {
            var modelos = _modeloRepository.ListarModelos();
            return new OkObjectResult(modelos);
        }

        // GET Buscar o modelo por id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var modelo = _modeloRepository.ObterModeloPorId(id);
            return new OkObjectResult(modelo);
        }

        // POST Inserir um modelo
        [HttpPost]
        public IActionResult Post([FromBody] Modelo modelo)
        {
            using (var scope = new TransactionScope())
            {
                _modeloRepository.InserirModelo(modelo);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = modelo.Id }, modelo);
            }
        }

        // PUT Atualizar um modelo
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Modelo modelo)
        {
            if (modelo != null)
            {
                using (var scope = new TransactionScope())
                {
                    _modeloRepository.AtualizarModelo(modelo);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE Deletar um modelo
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _modeloRepository.DeletarModelo(id);
            return new OkResult();
        }
    }
}
