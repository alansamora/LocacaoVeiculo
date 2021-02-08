using Locacao.Dominio.Repositorios;
using Locacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Locacao.Infraestrutura.DBContexts;
using System.Linq;

namespace Locacao.Infraestrutura.Repositorios
{
    public class LocacaoRepositorio : ILocacaoRepositorio
    {
        private readonly LocacaoContext _dbContext;

        public LocacaoRepositorio(LocacaoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InserirLocacao(Dominio.Entidades.Locacao locacao)
        {
            _dbContext.Add(locacao);
            _dbContext.SaveChanges();
        }

        public List<Dominio.Entidades.Locacao> ListarLocacoes()
        {
            return _dbContext.Locacoes.ToList();
        }

        public List<Dominio.Entidades.Locacao> ListarLocacoesPorDataECliente(DateTime dataLocacao, int clienteId)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> ListarVeiculosDisponiveisParaLocacaoPorData(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidades.Locacao ObterLocacaoPorId(int locacaoId)
        {
            return _dbContext.Locacoes.Find(locacaoId);
        }

        public double ObterValorTotalDiarias(int veiculoId, double valorHora, double totalHoras)
        {
            throw new NotImplementedException();
        }

        public Valor ObterValorTotalLocacao(int locacaoId, bool carroLimpo, bool tanqueCheio, bool amassado, bool arranhao)
        {
            throw new NotImplementedException();
        }
    }
}
