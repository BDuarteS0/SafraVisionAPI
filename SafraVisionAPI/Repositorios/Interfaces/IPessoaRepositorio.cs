using SafraVisionAPI.Models;

namespace SafraVisionAPI.Repositorios.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<List<PessoaModel>> BuscarTodasPessoas();
        Task<PessoaModel>BuscarPessoaPorId(int idPessoa);
        Task<PessoaModel> InserirPessoa(PessoaModel pessoa);
        Task<PessoaModel> AtualizarPessoa(PessoaModel pessoa, int id);
        Task<bool> DeletarPessoa(int id);
    }
}

