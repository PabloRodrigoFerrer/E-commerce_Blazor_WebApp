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
    public class UsuarioRepository : IRepositoryUser<User>
    {
        private readonly AppContextDb _context;

        public UsuarioRepository(AppContextDb context)
        {
            _context = context;
        }

        public async Task EditAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<User> Login(string username, string password)
        {
            username = username.Trim().ToLower();
            var user = await _context.Usuarios.Where(u =>
                                                    (u.Usuario == username && u.Pass == password) ||
                                                    (u.Email == username && u.Pass == password))
                                                    .FirstOrDefaultAsync();

            if (user == null) return new User();

            return user;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User?> CreateUserAsync(string email, string password)
        {   
            email = email.Trim().ToLower();
            var correo = await _context.Usuarios.Where(u => u.Email == email).FirstOrDefaultAsync();

            if (correo != null) return null;

            var nuevoUsuario = new User
            {
                Email = email.ToLower(),
                Pass = password
            };

            await _context.Usuarios.AddAsync(nuevoUsuario);
            await _context.SaveChangesAsync();
            return nuevoUsuario;
        }
    }
}
