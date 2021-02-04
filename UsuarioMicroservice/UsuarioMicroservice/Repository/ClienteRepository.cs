using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioMicroservice.DBContexts;
using UsuarioMicroservice.Model;

namespace UsuarioMicroservice.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly UsuarioContext _dbContext;

        public ClienteRepository(UsuarioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            _dbContext.Entry(cliente).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeletarCliente(int clienteId)
        {
            _dbContext.Clientes.Remove(ObterClientePorId(clienteId));
            _dbContext.SaveChanges();
        }

        public void InserirCliente(Cliente cliente)
        {
            _dbContext.Add(cliente);
            _dbContext.SaveChanges();
        }

        public List<Cliente> ListarClientes()
        {
            return _dbContext.Clientes.ToList();
        }

        public Cliente ObterClientePorId(int clienteId)
        {
            return _dbContext.Clientes.Find(clienteId);
        }
    }
}
