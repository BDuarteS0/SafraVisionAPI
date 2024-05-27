using SafraVisionAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraVisionAPI.Repositorios.Interfaces
{
	public interface IProdutoRepositorio
	{
		Task<List<ProdutoModel>> BuscarTodosProdutos();
		Task<ProdutoModel> BuscarProdutoPorId(int id);
		Task<ProdutoModel> InserirProduto(ProdutoModel produto);
		Task<ProdutoModel> AtualizarProduto(ProdutoModel produto, int id);
		Task<bool> DeletarProduto(int id);
	}
