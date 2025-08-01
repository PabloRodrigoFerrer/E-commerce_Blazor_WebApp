using Entity;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class PedidoDetalleService
    {
        private readonly IRepositoryPedidoDetalle<PedidoDetalle> _repositoryPedidoDetalle;

        public PedidoDetalleService(IRepositoryPedidoDetalle<PedidoDetalle> repository)
        {
            _repositoryPedidoDetalle = repository;
        }

        public async Task<IEnumerable<PedidoDetalle>> GetAllAsync()
        {
            var pedidos = await _repositoryPedidoDetalle.GetAllAsync();

            if (pedidos == null) return Enumerable.Empty<PedidoDetalle>();

            return pedidos;
        }

        public async Task<IEnumerable<PedidoDetalle>> GetDetallesById(int idPedido)
        {
            var detalles = await _repositoryPedidoDetalle.GetDetallesById(idPedido);

            if (detalles == null) return Enumerable.Empty<PedidoDetalle>();

            return detalles;
        }
    }
}
