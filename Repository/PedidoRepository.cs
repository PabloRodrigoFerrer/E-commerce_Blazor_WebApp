using Entity;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PedidoRepository : IRepositoryPedido<Pedido>
    {
        private readonly AppContextDb _context;

        public PedidoRepository(AppContextDb context) 
        {
            _context = context;
        }

        public Task<IEnumerable<Pedido>> AddAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos.Select(p => new Pedido
            {
                IdPedido = p.IdPedido,
                FechaPedido = p.FechaPedido,
                IdCliente = p.IdCliente,
                Cliente = p.Cliente ?? "No registrado",
                Estado = p.Estado,
                DireccionEntrega = p.DireccionEntrega ?? string.Empty,
                TotalPedido = p.TotalPedido,
                TotalUnidades = p.TotalUnidades != 0 ? p.TotalUnidades : 0
            }).ToListAsync();
        }
    }
}
