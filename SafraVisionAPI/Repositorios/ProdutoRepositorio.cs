using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;
namespace SafraVisionAPI.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SafraVisionDBContext _dbContext;
        public ProdutoRepositorio(SafraVisionDBContext safraVisionDBContext)
        {
            _dbContext = safraVisionDBContext;
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produto.ToListAsync();
        }


        public async Task<ProdutoModel> BuscarProdutoPorId(int idProduto)
        {
           return await _dbContext.Produto.FirstOrDefaultAsync(x => x.idProduto == idProduto);
        }


        public async Task<ProdutoModel> InserirProduto(ProdutoModel produto)
        {
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }


        public async Task<ProdutoModel> AtualizarProduto(ProdutoModel produto, int idProduto)
        {
            throw new NotImplementedException();
        }


        public Task<bool> DeletarProduto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
