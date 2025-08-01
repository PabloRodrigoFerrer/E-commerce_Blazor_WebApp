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
    public class PedidoDetalleRepository : IRepositoryPedidoDetalle<PedidoDetalle>
    {
        private readonly AppContextDb _context;

        public PedidoDetalleRepository(AppContextDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PedidoDetalle>> GetAllAsync()
        {
            return await _context.PedidoDetalles.Select(p => new PedidoDetalle
            {
                IdDetalle = p.IdDetalle,
                IdPedido = p.IdPedido,
                IdProducto = p.IdProducto,
                Cantidad = p.Cantidad,
                PrecioUnitario = p.PrecioUnitario,
                NombreProducto = p.NombreProducto,
                Color = p.Color
            }).ToListAsync();
        }

        public async Task<IEnumerable<PedidoDetalle>> GetDetallesById(int idPedido)
        {
            return await _context.PedidoDetalles
                 .Where(p => p.IdPedido == idPedido)
                 .Select(d => new PedidoDetalle
                 {
                     IdDetalle = d.IdDetalle,
                     IdPedido = d.IdPedido,
                     IdProducto = d.IdProducto,
                     Cantidad = d.Cantidad,
                     PrecioUnitario = d.PrecioUnitario,
                     NombreProducto = d.NombreProducto,
                     Color = d.Color
                 }).ToListAsync();
        }
    }
}
