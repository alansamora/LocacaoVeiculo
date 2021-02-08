using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Locacao.Aplicacao.Interfaces;
using Locacao.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Locacao.Api.Controllers
{
    [Route("api/locacao")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoAplicacao _locacaoAplicacao;

        public LocacaoController(ILocacaoAplicacao locacaoAplicacao)
        {
            _locacaoAplicacao = locacaoAplicacao;
        }

        // GET: Buscar todas as locacoes
        [HttpGet]
        public IActionResult Get()
        {
            var locacoes = _locacaoAplicacao.ListarLocacoes();
            return new OkObjectResult(locacoes);
        }

        // GET Buscar a locacao pelo id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var locacao = _locacaoAplicacao.ObterLocacaoPorId(id);
            return new OkObjectResult(locacao);
        }

        // GET Buscar veículos disponíveis para locacação em um período
        [HttpGet("{dataInicio}/{dataFim}")]
        public IActionResult Get(DateTime dataInicio, DateTime dataFim)
        {
            var veiculos = _locacaoAplicacao.ListarVeiculosDisponiveisParaLocacaoPorData(dataInicio, dataFim);
            return new OkObjectResult(veiculos);
        }

        // GET Buscar locações pelo cliente e data de referencia
        [HttpGet("{clienteId}/{dataLocacao}")]
        public IActionResult Get(int clienteId, DateTime dataLocacao)
        {
            var locacoes = _locacaoAplicacao.ListarLocacoesPorDataECliente(dataLocacao, clienteId);
            return new OkObjectResult(locacoes);
        }

        // GET Buscar valor total de diarias pelo veiculo, valor hora e total de horas
        [HttpGet("{veiculoId}/{valorHora}/{totalHoras}")]
        public IActionResult Get(int veiculoId, double valorHora, double totalHoras)
        {
            var valor = _locacaoAplicacao.ObterValorTotalDiarias(veiculoId, valorHora, totalHoras);
            return new OkObjectResult(valor);
        }

        // GET Buscar valor total da locacao calculando valores do checklist de devolução
        [HttpGet("{locacaoId}/{carroLimpo}/{tanqueCheio}/{amassado}/{arranhao}")]
        public IActionResult Get(int locacaoId, bool carroLimpo, bool tanqueCheio, bool amassado, bool arranhao)
        {
            var valor = _locacaoAplicacao.ObterValorTotalLocacao(locacaoId, carroLimpo, tanqueCheio, amassado, arranhao);
            return new OkObjectResult(valor);
        }

        // POST Inserir uma locação
        [HttpPost]
        public IActionResult Post([FromBody] Locacao.Dominio.Entidades.Locacao locacao)
        {
            using (var scope = new TransactionScope())
            {
                _locacaoAplicacao.InserirLocacao(locacao);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = locacao.Id }, locacao);
            }
        }
    }
}
