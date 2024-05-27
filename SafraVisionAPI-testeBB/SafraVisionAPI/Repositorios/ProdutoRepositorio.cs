using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraVisionAPI.Repositorios
{
	public class ProdutoRepositorio : IProdutoRepositorio
	{
		private readonly SafraVisionDBContext _dbContext;

		public ProdutoRepositorio(SafraVisionDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<ProdutoModel>> BuscarTodosProdutos()
		{
			return await _dbContext.Produtos.ToListAsync();
		}

		public async Task<ProdutoModel> BuscarProdutoPorId(int id)
		{
			return await _dbContext.Produtos.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<ProdutoModel> InserirProduto(ProdutoModel produto)
		{
			await _dbContext.Produtos.AddAsync(produto);
			await _dbContext.SaveChangesAsync();
			return produto;
		}

		public async Task<ProdutoModel> AtualizarProduto(ProdutoModel produto, int id)
		{
			ProdutoModel produtoPorId = await BuscarProdutoPorId(id);
			if (produtoPorId == null)
			{
				throw new Exception("Produto não encontrado");
			}
			produtoPorId.Nome = produto.Nome;
			produtoPorId.Preco = produto.Preco;

			_dbContext.Produtos.Update(produtoPorId);
			await _dbContext.SaveChangesAsync();
			return produtoPorId;
		}

		public async Task<bool> DeletarProduto(int id)
		{
			ProdutoModel produtoPorId = await BuscarProdutoPorId(id);
			if (produtoPorId == null)
			{
				throw new Exception("Produto não encontrado");
			}
			_dbContext.Produtos.Remove(produtoPorId);
			await _dbContext.SaveChangesAsync();
			return true;
		}
	}