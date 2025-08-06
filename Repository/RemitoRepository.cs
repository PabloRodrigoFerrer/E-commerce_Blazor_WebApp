using Entity;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RemitoRepository : IRepositoryRemito<Remito>
    {
        private readonly AppContextDb _context;
        public RemitoRepository(AppContextDb contexto) 
        {
            _context = contexto;
        }

        public async Task<IEnumerable<Remito>> GetAllAsync()
        {
            return await _context.Remitos.ToListAsync();
        }
        public async Task AddAsync(Remito nuevoRemito)
        {
            await _context.Remitos.AddAsync(nuevoRemito);
            await _context.SaveChangesAsync();
        }
    }
}
