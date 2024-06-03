using SafraVisionAPI.Models;

namespace SafraVisionAPI.Repositorios.Interfaces
{
    public interface ICompradorRepositorio
    {
        Task<List<CompradorModel>> BuscarTodosCompradores();
        Task<CompradorModel> BuscarCompradorPorId(int idPessoa);
        Task<CompradorModel>InserirComprador(CompradorModel comprador);
        Task<CompradorModel>AtualizarComprador(CompradorModel comprador, int idPessoa);
        Task<bool>DeletarComprador(int idPessoa);
    }
}
