using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IRepositoryPedido<T>
    {
        Task<IEnumerable<T>> GetAllAsync();


        Task AddAsync(Pedido nuevoPedido);
    }
}
