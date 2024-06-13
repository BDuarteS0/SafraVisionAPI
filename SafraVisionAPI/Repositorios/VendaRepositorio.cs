using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;

namespace SafraVisionAPI.Repositorios
{
    public class VendaRepositorio : IVendaRepositorio   
    {
        private readonly SafraVisionDBContext _dbContext;
        public VendaRepositorio(SafraVisionDBContext safraVisionDBContext)
        {
            _dbContext = safraVisionDBContext;
        }
        //BUSCA E RETORNA UMA LISTA TODOS OS USUÁRIOS DO SISTEMA 
        public async Task<List<VendaModel>> BuscarTodasVendas()
        {
            return await _dbContext.Venda.ToListAsync();
        }

        //BUSCA E RETORNA APENAS UM USUÁRIO ESPECÍFICO
        public async Task<VendaModel> BuscarVendaPorId(int idVenda)
        {
            return await _dbContext.Venda.FirstOrDefaultAsync(x => x.idVenda == idVenda);
        }

        //ADICIONA UM NOVO USUÁRIO NO SISTEMA
        public async Task<VendaModel> InserirVenda(VendaModel venda)
        {
            await _dbContext.Venda.AddAsync(venda);
            await _dbContext.SaveChangesAsync();
            return venda;
        }

        //ATUALIZA OS DADOS DE UM USUÁRIO DO SISTEMA
         public async Task<VendaModel> AtualizarVenda(VendaModel venda, int idVenda)
        {
            VendaModel vendaPorId = await BuscarVendaPorId(idVenda);
            if(vendaPorId == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            vendaPorId.qtdVendida = venda.qtdVendida;
            vendaPorId.idComprador = venda.idComprador;
          
            
            _dbContext.Venda.Update(vendaPorId);
            _dbContext.SaveChanges();
            return vendaPorId;
        }

        //DELETA UM USUÁRIO ESPECÍFICO DO SISTEMA
        public async Task<bool> DeletarVenda(int idVenda)
        {
            VendaModel vendaPorId = await BuscarVendaPorId(idVenda);
            if (vendaPorId == null)
            {
                throw new Exception("Venda não encontrado");
            }
            _dbContext.Venda.Remove(vendaPorId);
            _dbContext.SaveChanges();
            return true;
        }


    }
}
        