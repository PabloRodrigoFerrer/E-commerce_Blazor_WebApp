using Entity;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class MapPedidoDetalleToRemitoDetalle : IMapper<PedidoDetalle, RemitoDetalle>
    {
        public Task<RemitoDetalle> Map(PedidoDetalle input)
        {
            var result =  new RemitoDetalle
            {
                ProductoId = input.IdProducto,
                Cantidad = input.Cantidad,
                NombreProducto = input.NombreProducto,
                Color = input.Color,
                PrecioUnitario = input.PrecioUnitario,
                SubTotal = input.SubTotal,
            };

            return Task.FromResult(result);
        }
    }
}
