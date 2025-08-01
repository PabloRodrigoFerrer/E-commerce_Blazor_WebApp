using Entity;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class PedidoService
    {
        private readonly IRepositoryPedido<Pedido> _repositoryPedido;
        public PedidoService(IRepositoryPedido<Pedido> repository) 
        {
            _repositoryPedido = repository;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync() 
        {
            var pedidos = await _repositoryPedido.GetAllAsync();

            if(pedidos == null) return Enumerable.Empty<Pedido>();

            return pedidos;
        }



    }
}
