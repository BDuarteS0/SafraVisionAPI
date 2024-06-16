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


        public async Task<CompradorModel> BuscarCompradorPorId(int idComprador)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _dbContext.Comprador.FirstOrDefaultAsync(x => x.idComprador == idComprador);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public async Task<CompradorModel> AtualizarComprador(CompradorModel comprador, int idPessoa)
        {
            CompradorModel compradorPorId = await BuscarCompradorPorId(idPessoa);
            if(compradorPorId == null)
            {
                throw new Exception("Comprador não encontrado");
            }
            compradorPorId.nomeComprador = comprador.nomeComprador;
            compradorPorId.descricao = comprador.descricao;

            _dbContext.Comprador.Update(compradorPorId);
            _dbContext.SaveChanges();
            return compradorPorId;
        }
 


        public async Task<bool> DeletarComprador(int idPessoa)
        {
            CompradorModel compradorPorId = await BuscarCompradorPorId(idPessoa);
            if (compradorPorId == null)
            {
                throw new Exception("Comprador não encontrado");
            }
            _dbContext.Comprador.Remove(compradorPorId);
            _dbContext.SaveChanges();
            return true;
        }


    }
}
