using SafraVisionAPI.Models;

namespace SafraVisionAPI.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarUsuarioPorId(int id);
        Task<UsuarioModel> InserirUsuario(UsuarioModel usuario);
        Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id);
        Task<bool> DeletarUsuario(int id);
    }
}
