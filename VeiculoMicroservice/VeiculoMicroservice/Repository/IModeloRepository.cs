using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculoMicroservice.Model;

namespace VeiculoMicroservice.Repository
{
    public interface IModeloRepository
    {
        void InserirModelo(Modelo modelo);
        void DeletarModelo(int modeloId);
        void AtualizarModelo(Modelo modelo);
        Modelo ObterModeloPorId(int modeloId);
        List<Modelo> ListarModelos();
    }
}
