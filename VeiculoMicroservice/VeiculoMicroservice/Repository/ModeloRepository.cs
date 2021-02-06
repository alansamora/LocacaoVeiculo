using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeiculoMicroservice.DBContexts;
using VeiculoMicroservice.Model;

namespace VeiculoMicroservice.Repository
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly VeiculoContext _dbContext;

        public ModeloRepository(VeiculoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarModelo(Modelo modelo)
        {
            _dbContext.Entry(modelo).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeletarModelo(int modeloId)
        {
            _dbContext.Modelos.Remove(ObterModeloPorId(modeloId));
            _dbContext.SaveChanges();
        }

        public void InserirModelo(Modelo modelo)
        {
            _dbContext.Add(modelo);
            _dbContext.SaveChanges();
        }

        public List<Modelo> ListarModelos()
        {
            return _dbContext.Modelos.ToList();
        }

        public Modelo ObterModeloPorId(int modeloId)
        {
            return _dbContext.Modelos.Find(modeloId);
        }
    }
}
