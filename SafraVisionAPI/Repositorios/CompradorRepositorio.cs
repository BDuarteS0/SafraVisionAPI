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


        public async Task<CompradorModel> BuscarCompradorPorId(int idPessoa)
        {
            return await _dbContext.Comprador.FirstOrDefaultAsync(x => x.idPessoa == idPessoa);
        }

        public async Task<CompradorModel> AtualizarComprador(CompradorModel comprador, int idPessoa)
        {
            CompradorModel compradorPorId = await BuscarCompradorPorId(idPessoa);
            if(compradorPorId == null)
            {
                throw new Exception("Comprador não encontrado");
            }
            comprador.descricao = compradorPorId.descricao;
            comprador.nomePessoa = comprador.nomePessoa;

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
