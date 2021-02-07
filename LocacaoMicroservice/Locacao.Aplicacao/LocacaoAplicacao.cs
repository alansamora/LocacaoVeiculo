using Locacao.Aplicacao.Interfaces;
using Locacao.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Locacao.Aplicacao
{
    public class LocacaoAplicacao : ILocacaoAplication
    {
        public void InserirLocacao(Dominio.Entidades.Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Entidades.Locacao> ListarLocacoes()
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Entidades.Locacao> ListarLocacoesPorDataECliente(DateTime dataLocacao, int clienteId)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> ListarVeiculos()
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidades.Locacao ObterLocacaoPorId(int locacaoId)
        {
            throw new NotImplementedException();
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
