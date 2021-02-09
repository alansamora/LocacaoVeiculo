using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Locacao.Aplicacao.Interfaces;
using Locacao.Dominio.Entidades;
using Locacao.Dominio.ModeloDB;
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
            if(locacao != null) return new OkObjectResult(locacao);
            return new NoContentResult();
        }

        // GET Buscar veículos disponíveis para locacação em um período e por categoria
        [HttpGet("{dataInicio}/{dataFim}/{categoria}/categoria")]
        public IActionResult Get(DateTime dataInicio, DateTime dataFim, int categoria)
        {
            var veiculos = _locacaoAplicacao.ListarVeiculosDisponiveisParaLocacaoPorDataECategoria(categoria, dataInicio, dataFim);
            return new OkObjectResult(veiculos);
        }

        // GET Buscar locações pelo cliente e data de referencia
        [HttpGet("{dataLocacaoInicio}/{dataLocacaoFim}/{clienteId}/cliente")]
        public IActionResult Get(int clienteId, DateTime dataLocacaoInicio, DateTime dataLocacaoFim)
        {
            var locacoes = _locacaoAplicacao.ListarLocacoesPorDataECliente(dataLocacaoInicio, dataLocacaoFim, clienteId);
            return new OkObjectResult(locacoes);
        }

        // GET Buscar valor total de diarias pelo veiculo, valor hora e total de horas
        [HttpGet("{totalHoras}/{veiculoId}/veiculo")]
        public IActionResult Get(int veiculoId, double totalHoras)
        {
            var valor = _locacaoAplicacao.ObterValorTotalDiarias(veiculoId, totalHoras);
            return new OkObjectResult(valor);
        }

        // GET Buscar valor total da locacao calculando valores do checklist de devolução
        [HttpGet("{locacaoId}/{carroLimpo}/{tanqueCheio}/{amassado}/{arranhao}")]
        public IActionResult Get(int locacaoId, bool carroLimpo, bool tanqueCheio, bool amassado, bool arranhao)
        {
            var valor = _locacaoAplicacao.ObterValorTotalLocacao(locacaoId, carroLimpo, tanqueCheio, amassado, arranhao);
            if(valor != null) return new OkObjectResult(valor);
            return new NoContentResult();
        }

        // POST Inserir uma locação
        [HttpPost]
        public IActionResult Post([FromBody] LocacaoDB locacao)
        {
            if (locacao.DataInicioLocacao > locacao.DataFimLocacao)
            {
                return new BadRequestObjectResult("Data inicial não pode ser superior à data final");
            }

            using (var scope = new TransactionScope())
            {
                _locacaoAplicacao.InserirLocacao(locacao);
                scope.Complete();
            }
            if (locacao.Id > 0)
            {
                var veiculo = _locacaoAplicacao.ObterVeiculoPorId(locacao.VeiculoId);
                if (veiculo != null)
                {
                    var locacaoRetorno = new Locacao.Dominio.Entidades.Locacao(locacao, veiculo);
                    return CreatedAtAction(nameof(Get), new { id = locacao.Id }, locacaoRetorno);
                }
            }
            return new NoContentResult();
        }
    }
}
