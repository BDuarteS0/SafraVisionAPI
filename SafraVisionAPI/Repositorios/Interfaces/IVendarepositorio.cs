using SafraVisionAPI.Models;

namespace SafraVisionAPI.Repositorios.Interfaces
{
    public interface IVendaRepositorio
    {
        Task<List<VendaModel>> BuscarTodasVendas();
        Task<VendaModel> BuscarVendaPorId(int idVenda);
        Task<VendaModel> InserirVenda(VendaModel venda);
        Task<VendaModel> AtualizarVenda(VendaModel venda, int id);
        Task<bool> DeletarVenda(int id);
    }
}


