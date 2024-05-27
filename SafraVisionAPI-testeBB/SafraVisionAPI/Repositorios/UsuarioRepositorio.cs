using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;

namespace SafraVisionAPI.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SafraVisionDBContext _dbContext;
        public UsuarioRepositorio(SafraVisionDBContext safraVisionDBContext)
        {
            _dbContext = safraVisionDBContext;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuario.ToListAsync();
        }


        public Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            return _dbContext.Usuario.FirstOrDefaultAsync(x => x.id == id);
        }


        public async Task<UsuarioModel> InserirUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            _dbContext.SaveChangesAsync();
            return usuario;
        }
        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorID = await BuscarUsuarioPorId(id);
            if(usuarioPorID == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            usuarioPorID.senha= usuario.senha;
            
            _dbContext.Usuario.Update(usuarioPorID);
            _dbContext.SaveChanges();
            return usuarioPorID;
        }

        public async Task<bool> DeletarUsuario(int id)
        {
            UsuarioModel usuarioPorID = await BuscarUsuarioPorId(id);
            if (usuarioPorID == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            _dbContext.Usuario.Remove(usuarioPorID);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
