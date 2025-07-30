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
    public class ElementoRepository : IRepositoryElemento<Elemento>
    {
        private readonly AppContextDb _context;
        public ElementoRepository(AppContextDb context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Elemento>> GetAllAsync()
        {
            return await _context.Elementos
                .Select(e => 
                new Elemento
                {
                    Id = e.Id,
                    Descripcion= e.Descripcion,
                }).ToListAsync();
        }
    }
}
