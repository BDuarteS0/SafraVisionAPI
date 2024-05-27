using SafraVisionAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraVisionAPI.Repositorios.Interfaces
{
	public interface IVendaRepositorio
	{
		Task<List<VendaModel>> BuscarTodasVendas();
		Task<VendaModel> BuscarVendaPorId(int id);
		Task<VendaModel> InserirVenda(VendaModel venda);
	}
}