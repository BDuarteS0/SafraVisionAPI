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
            ProdutoModel produtoPorId = await BuscarProdutoPorId(idProduto);
            if(produtoPorId == null)
            {
                throw new Exception("Produto não encontrado");
            }
            produtoPorId.nomeProduto = produto.nomeProduto;
            produtoPorId.descricao = produto.descricao;
            produtoPorId.preco = produto.preco;
            produtoPorId.qtdEstoque = produto.qtdEstoque;
    
            _dbContext.Produto.Update(produtoPorId);
            _dbContext.SaveChanges();
            return produtoPorId;
      
        }


        public async Task<bool> DeletarProduto(int idProduto)
        {
            ProdutoModel produtoPorId = await BuscarProdutoPorId(idProduto);
            if (produtoPorId == null)
            {
                throw new Exception("Produto não encontrado");
            }
            _dbContext.Produto.Remove(produtoPorId);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
