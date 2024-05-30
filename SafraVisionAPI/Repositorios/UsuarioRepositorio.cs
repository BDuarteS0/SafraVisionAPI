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
        //BUSCA E RETORNA UMA LISTA TODOS OS USUÁRIOS DO SISTEMA 
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        //BUSCA E RETORNA APENAS UM USUÁRIO ESPECÍFICO
        public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.idPessoa == id);
        }

        //ADICIONA UM NOVO USUÁRIO NO SISTEMA
        public async Task<UsuarioModel> InserirUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        //ATUALIZA OS DADOS DE UM USUÁRIO DO SISTEMA
        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorID = await BuscarUsuarioPorId(id);
            if(usuarioPorID == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            usuarioPorID.email = usuario.email;
            usuarioPorID.senha= usuario.senha;
            
            _dbContext.Usuario.Update(usuarioPorID);
            _dbContext.SaveChanges();
            return usuarioPorID;
        }

        //DELETA UM USUÁRIO ESPECÍFICO DO SISTEMA
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
