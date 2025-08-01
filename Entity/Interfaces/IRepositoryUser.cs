using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IRepositoryUser<T>
    {
        Task<T> Login(string username, string password);

        Task<T?> CreateUserAsync(string email, string password);

        Task EditAsync(T user);

        Task<T> GetByIdAsync(int id);
    }
}
