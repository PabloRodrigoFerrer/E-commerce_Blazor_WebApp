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
        private readonly CarritoService _carritoService;
        private readonly UserService _userService;
        public PedidoService(IRepositoryPedido<Pedido> repository, CarritoService carritoService, UserService userService)
        {
            _repositoryPedido = repository;
            _carritoService = carritoService;
            _userService = userService;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            var pedidos = await _repositoryPedido.GetAllAsync();

            if (pedidos == null) return Enumerable.Empty<Pedido>();

            return pedidos;
        }

        public async Task InsertAsync(IEnumerable<CarritoItem> carrito)
        {
         
            if (carrito == null || carrito.Count() <= 0) return;

            Pedido nuevoPedido = new();
            nuevoPedido.IdCliente = _userService.ActiveUser.Id;
            nuevoPedido.DireccionEntrega = _userService.ActiveUser.Direccion;
            nuevoPedido.FechaPedido = DateTime.Now;
            nuevoPedido.TotalUnidades = carrito.Sum(i => i.Cantidad);
            nuevoPedido.Cliente = _userService.ActiveUser.Nombre;
            
            foreach (var item in carrito)
            {
                var detalle = new PedidoDetalle
                {
                    IdProducto = item.PokeId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    NombreProducto = item.PokeName,
                    Color = item.PokeTipo.Descripcion,
                    SubTotal =  item.Subtotal
                };

                nuevoPedido.Detalles.Add(detalle);
            }
            nuevoPedido.TotalPedido = nuevoPedido.Detalles.Sum(i =>i.SubTotal);

            await _repositoryPedido.AddAsync(nuevoPedido);
        }
    }

  
}
