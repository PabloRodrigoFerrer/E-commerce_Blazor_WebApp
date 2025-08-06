using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IRepositoryRemito<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T nuevoRemito);
    }
}
