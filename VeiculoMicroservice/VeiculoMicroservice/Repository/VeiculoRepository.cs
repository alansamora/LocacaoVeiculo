using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculoMicroservice.DBContexts;
using VeiculoMicroservice.Model;

namespace VeiculoMicroservice.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly VeiculoContext _dbContext;

        public VeiculoRepository(VeiculoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarVeiculo(Veiculo veiculo)
        {
            _dbContext.Entry(veiculo).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeletarVeiculo(int veiculoId)
        {
            _dbContext.Veiculos.Remove(ObterVeiculoPorId(veiculoId));
            _dbContext.SaveChanges();
        }

        public void InserirVeiculo(Veiculo veiculo)
        {
            _dbContext.Add(veiculo);
            _dbContext.SaveChanges();
        }

        public List<Veiculo> ListarVeiculos()
        {
            return _dbContext.Veiculos.ToList();
        }

        public Veiculo ObterVeiculoPorId(int veiculoId)
        {
            return _dbContext.Veiculos.Find(veiculoId);
        }
    }
}
