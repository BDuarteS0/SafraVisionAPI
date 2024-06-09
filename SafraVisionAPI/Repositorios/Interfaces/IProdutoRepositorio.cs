using SafraVisionAPI.Models;

namespace SafraVisionAPI.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosProdutos();
        Task<ProdutoModel> BuscarProdutoPorId(int idProduto);
        Task<ProdutoModel> InserirProduto(ProdutoModel produto);
        Task<ProdutoModel> AtualizarProduto(ProdutoModel produto, int id);
        Task<bool> DeletarProduto(int id);
    }
}
