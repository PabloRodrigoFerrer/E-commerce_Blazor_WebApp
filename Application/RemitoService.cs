using Entity;
using Entity.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class RemitoService
    {   
        private readonly IRepositoryRemito<Remito> _repositoryRemito;
        private readonly IMapper<PedidoDetalle, RemitoDetalle> _mapper;
        public RemitoService(IRepositoryRemito<Remito> repository, IMapper<PedidoDetalle, RemitoDetalle> mapper) 
        {
            _repositoryRemito = repository;
            _mapper = mapper;
        }

        public async Task InsertRemito(List<PedidoDetalle> carrito, int idCliente, int idPedido)
        {
            List<RemitoDetalle> listaRemitoDetalle = new();

            foreach(var pedidoDetalle in carrito) 
            {
                listaRemitoDetalle.Add(await _mapper.Map(pedidoDetalle));
            }

            var nuevoRemito =
                new Remito
                {
                    FechaRemito = DateTime.Now,
                    IdCliente = idCliente,
                    IdPedido = idPedido,
                    TotalRemito = listaRemitoDetalle.Sum(p => p.SubTotal),
                    Detalles = listaRemitoDetalle
                };

            await _repositoryRemito.AddAsync(nuevoRemito);
        }
    }
}
