using SafraVisionAPI.Models;

namespace SafraVisionAPI.Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarClientePorId(int idPessoa);
        Task<ClienteModel>InserirCliente(ClienteModel cliente);
        Task<ClienteModel>AtualizarCliente(ClienteModel cliente, int idPessoa);
        Task<bool>DeletarCliente(int idPessoa);
    } 
}
