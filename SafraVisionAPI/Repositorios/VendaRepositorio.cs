﻿using Microsoft.EntityFrameworkCore;
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
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _dbContext.Venda.FirstOrDefaultAsync(x => x.idVenda == idVenda);
#pragma warning restore CS8603 // Possível retorno de referência nula.
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
            vendaPorId.clienteVenda = venda.clienteVenda;
            vendaPorId.produtoVenda = venda.produtoVenda;
            vendaPorId.descricaoVenda = venda.descricaoVenda;
            vendaPorId.qtdVendida = venda.qtdVendida;
            vendaPorId.dataVenda = venda.dataVenda;

          
            
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
        