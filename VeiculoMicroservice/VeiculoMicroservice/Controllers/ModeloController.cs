using System;
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
    [Route("api/modelo")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMarcaRepository _marcaRepository;

        public ModeloController(IModeloRepository modeloRepository, IMarcaRepository marcaRepository)
        {
            _modeloRepository = modeloRepository;
            _marcaRepository = marcaRepository;
        }

        // GET: Buscar todos os modelos
        [HttpGet]
        public IActionResult Get()
        {
            var modelos = _modeloRepository.ListarModelos();
            var modelosRetorno = new List<Modelo>();
            if (modelos != null)
            {
                foreach (ModeloDB modelDB in modelos)
                {
                    var modelo = new Modelo(modelDB.Id, modelDB.Nome, _marcaRepository.ObterMarcaPorId(modelDB.MarcaId));
                    modelosRetorno.Add(modelo);
                }
            }
            return new OkObjectResult(modelosRetorno);
        }

        // GET Buscar o modelo por id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var modelo = _modeloRepository.ObterModeloPorId(id);
            if(modelo != null)
            {
                var modeloRetorno = new Modelo(modelo.Id, modelo.Nome, _marcaRepository.ObterMarcaPorId(modelo.MarcaId));
                return new OkObjectResult(modeloRetorno);
            }
            return new NoContentResult();
        }

        // POST Inserir um modelo
        [HttpPost]
        public IActionResult Post([FromBody] ModeloDB modelo)
        {
            using (var scope = new TransactionScope())
            {
                _modeloRepository.InserirModelo(modelo);
                scope.Complete();
            }
            if(modelo.Id > 0) return CreatedAtAction(nameof(Get), new { id = modelo.Id }, new Modelo(modelo.Id, modelo.Nome, _marcaRepository.ObterMarcaPorId(modelo.MarcaId)));
            return new NoContentResult();
        }

        // PUT Atualizar um modelo
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ModeloDB modelo)
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
