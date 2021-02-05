using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using UsuarioMicroservice.Model;
using UsuarioMicroservice.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsuarioMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: Buscar todos os clientes
        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _clienteRepository.ListarClientes();
            return new OkObjectResult(clientes);
        }

        // GET Buscar o cliente por id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var clientes = _clienteRepository.ObterClientePorId(id);
            return new OkObjectResult(clientes);
        }

        // POST Inserir um cliente
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            using (var scope = new TransactionScope())
            {
                _clienteRepository.InserirCliente(cliente);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
            }
        }

        // PUT Atualizar um cliente
        [HttpPut("{cliente}")]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente != null)
            {
                using (var scope = new TransactionScope())
                {
                    _clienteRepository.AtualizarCliente(cliente);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE Deletar um cliente
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clienteRepository.DeletarCliente(id);
            return new OkResult();
        }
    }
}
