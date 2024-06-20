using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;

namespace SafraVisionAPI.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly SafraVisionDBContext _dbContext;
        public ClienteRepositorio(SafraVisionDBContext safraVisionDBContext)
        {
            _dbContext = safraVisionDBContext;
        }
        public async Task<ClienteModel> InserirCliente(ClienteModel cliente)
        {
            await _dbContext.Cliente.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<List<ClienteModel>> BuscarTodosClientees()
        {
            return await _dbContext.Cliente.ToListAsync();
        }


        public async Task<ClienteModel> BuscarClientePorId(int idCliente)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _dbContext.Cliente.FirstOrDefaultAsync(x => x.idCliente == idCliente);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public async Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int idPessoa)
        {
            ClienteModel clientePorId = await BuscarClientePorId(idPessoa);
            if(clientePorId == null)
            {
                throw new Exception("Cliente não encontrado");
            }
            clientePorId.nomeCliente = cliente.nomeCliente;
            clientePorId.descricao = cliente.descricao;
            clientePorId.numeroTelefone = cliente.numeroTelefone;

            _dbContext.Cliente.Update(clientePorId);
            _dbContext.SaveChanges();
            return clientePorId;
        }
 


        public async Task<bool> DeletarCliente(int idPessoa)
        {
            ClienteModel clientePorId = await BuscarClientePorId(idPessoa);
            if (clientePorId == null)
            {
                throw new Exception("Cliente não encontrado");
            }
            _dbContext.Cliente.Remove(clientePorId);
            _dbContext.SaveChanges();
            return true;
        }


    }
}
