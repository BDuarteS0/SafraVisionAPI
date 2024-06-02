using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;

namespace SafraVisionAPI.Repositorios
{
    public class CompradorRepositorio : ICompradorRepositorio
    {
        private readonly SafraVisionDBContext _dbContext;
        public CompradorRepositorio(SafraVisionDBContext safraVisionDBContext)
        {
            _dbContext = safraVisionDBContext;
        }
        public async Task<CompradorModel> InserirComprador(CompradorModel comprador)
        {
            await _dbContext.Comprador.AddAsync(comprador);
            await _dbContext.SaveChangesAsync();
            return comprador;
        }

        public async Task<List<CompradorModel>> BuscarTodosCompradores()
        {
            return await _dbContext.Comprador.ToListAsync();
        }


        public Task<CompradorModel> BuscarCompradorPorId(int idPessoa)
        {
            throw new NotImplementedException();
        }

        public Task<CompradorModel> AtualizarComprador(CompradorModel comprador, int idPessoa)
        {
            throw new NotImplementedException();
        }


        public Task<bool> DeletarComprador(int idPessoa)
        {
            throw new NotImplementedException();
        }


    }
}
