using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculoMicroservice.Model;

namespace VeiculoMicroservice.Repository
{
    public interface IVeiculoRepository
    {
        void InserirVeiculo(Veiculo veiculo);
        void DeletarVeiculo(int veiculoId);
        void AtualizarVeiculo(Veiculo veiculo);
        Veiculo ObterVeiculoPorId(int veiculoId);
        List<Veiculo> ListarVeiculos();
    }
}
