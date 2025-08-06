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

        public async Task AddAsync(Pedido nuevoPedido)
        {
            await _context.Pedidos.AddAsync(nuevoPedido);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos
                //.Include(p => p.Detalles)
                .Select(p => new Pedido
            {
                IdPedido = p.IdPedido,
                FechaPedido = p.FechaPedido,
                IdCliente = p.IdCliente,
                Cliente = p.Cliente ?? "No registrado",
                Estado = p.Estado ?? "Sin estado",
                TotalPedido = p.TotalPedido,
                DireccionEntrega = p.DireccionEntrega ?? string.Empty,
                TotalUnidades = p.TotalUnidades != 0 ? p.TotalUnidades : 0,
                // Detalles = p.Detalles.Select(d => new PedidoDetalle
                //{
                //     IdDetalle = d.IdDetalle,
                //     IdPedido = d.IdPedido,
                //     IdProducto = d.IdProducto,
                //     Cantidad = d.Cantidad,
                //     PrecioUnitario = d.PrecioUnitario,
                //     SubTotal = d.SubTotal,
                //     NombreProducto = d.NombreProducto,
                //     Color = d.Color,                     
                //}).ToList()
                }).ToListAsync();
        }
    }
}
