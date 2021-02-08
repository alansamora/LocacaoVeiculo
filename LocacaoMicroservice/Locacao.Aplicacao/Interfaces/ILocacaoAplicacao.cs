using Locacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Aplicacao.Interfaces
{
    public interface ILocacaoAplicacao
    {
        List<Veiculo> ListarVeiculos();
        void InserirLocacao(Locacao.Dominio.Entidades.Locacao locacao);
        Locacao.Dominio.Entidades.Locacao ObterLocacaoPorId(int locacaoId);
        List<Locacao.Dominio.Entidades.Locacao> ListarLocacoes();
        List<Locacao.Dominio.Entidades.Locacao> ListarLocacoesPorDataECliente(DateTime dataLocacao, int clienteId);
        double ObterValorTotalDiarias(int veiculoId, double valorHora, double totalHoras);
        Valor ObterValorTotalLocacao(int locacaoId, bool carroLimpo, bool tanqueCheio, bool amassado, bool arranhao);
    }
}
