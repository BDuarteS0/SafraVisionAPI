using Microsoft.EntityFrameworkCore;
using SafraVisionAPI.Data;
using SafraVisionAPI.Models;
using SafraVisionAPI.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraVisionAPI.Repositorios
{
    public class VendaRepositorio : IVendaRepositorio
    {
        private readonly SafraVisionDBContext _dbContext;

        public VendaRepositorio(SafraVisionDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VendaModel>> BuscarTodasVendas()
        {
            return await _dbContext.Vendas.Include(v => v.Produto).ToListAsync();
        }

        public async Task<VendaModel> BuscarVendaPorId(int id)
        {
            return await _dbContext.Vendas.Include(v => v.Produto).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<VendaModel> InserirVenda(VendaModel venda)
        {
            await _dbContext.Vendas.AddAsync(venda);
            await _dbContext.SaveChangesAsync();
            return venda;
        }
    }
}