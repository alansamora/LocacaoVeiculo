using Locacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Dominio.Repositorios
{
    public interface ILocacaoRepositorio
    {
        void InserirLocacao(Locacao.Dominio.Entidades.Locacao locacao);
        Locacao.Dominio.Entidades.Locacao ObterLocacaoPorId(int locacaoId);
        List<Locacao.Dominio.Entidades.Locacao> ListarLocacoes();
        List<Locacao.Dominio.Entidades.Locacao> ListarLocacoesPorDataECliente(DateTime dataLocacao, int clienteId);
        List<Veiculo> ListarVeiculosDisponiveisParaLocacaoPorData(DateTime dataInicio, DateTime dataFim);
        double ObterValorTotalDiarias(int veiculoId, double valorHora, double totalHoras);
        Valor ObterValorTotalLocacao(int locacaoId, bool carroLimpo, bool tanqueCheio, bool amassado, bool arranhao);
    }
}
