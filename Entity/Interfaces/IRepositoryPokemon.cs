using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IRepositoryPokemon<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> SearchByText(string text);

        Task<IEnumerable<T>> FilterByCatActive(int idCat);

        Task<IEnumerable<T>> GetAllActiveAsync();

        Task EditAsync(T product);

        Task AddAsync(T product);

        Task DeleteAsync(T product);

        Task<bool> IdCatExist(int idCat);
    }
}
