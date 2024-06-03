using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;

namespace SafraVisionAPI.Repositorios
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly SafraVisionDBContext _dbContext;
        public PessoaRepositorio(SafraVisionDBContext safraVisionDBContext)
        {
            _dbContext = safraVisionDBContext;
        }
        //BUSCA E RETORNA UMA LISTA TODOS OS USUÁRIOS DO SISTEMA 
        public async Task<List<PessoaModel>> BuscarTodasPessoas()
        {
            return await _dbContext.Pessoa.ToListAsync();
        }

        //BUSCA E RETORNA APENAS UM USUÁRIO ESPECÍFICO
        public async Task<PessoaModel> BuscarPessoaPorId(int idPessoa)
        {
            return await _dbContext.Pessoa.FirstOrDefaultAsync(x => x.idPessoa == idPessoa);
        }

        //ADICIONA UM NOVO USUÁRIO NO SISTEMA
        public async Task<PessoaModel> InserirPessoa(PessoaModel pessoa)
        {
            await _dbContext.Pessoa.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
            return pessoa;
        }

        //ATUALIZA OS DADOS DE UM USUÁRIO DO SISTEMA
         public async Task<PessoaModel> AtualizarPessoa(PessoaModel pessoa, int idPessoa)
        {
            PessoaModel pessoaPorID = await BuscarPessoaPorId(idPessoa);
            if(pessoaPorID == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            pessoaPorID.nomePessoa = pessoa.nomePessoa;
          
            
            _dbContext.Pessoa.Update(pessoaPorID);
            _dbContext.SaveChanges();
            return pessoaPorID;
        }

        //DELETA UM USUÁRIO ESPECÍFICO DO SISTEMA
        public async Task<bool> DeletarPessoa(int idPessoa)
        {
            PessoaModel pessoaPorId = await BuscarPessoaPorId(idPessoa);
            if (pessoaPorId == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            _dbContext.Pessoa.Remove(pessoaPorId);
            _dbContext.SaveChanges();
            return true;
        }

   
    }
}
