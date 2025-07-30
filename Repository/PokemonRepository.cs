using Entity;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository
{
    public class PokemonRepository : IRepositoryPokemon<Pokemon>
    {
        public readonly AppContextDb _context;

        public PokemonRepository(AppContextDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            return await _context.Pokemons.Select(p => new Pokemon
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                IdTipo = p.IdTipo,
                IdDebilidad = p.IdDebilidad,
                UrlImagen = p.UrlImagen,
                Cantidad = p.Cantidad,
                Precio = p.Precio,
                Activo = p.Activo,

            }).ToListAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            var poke = await _context.Pokemons.FindAsync(id);
            return poke;
        }

        public async Task<IEnumerable<Pokemon>> SearchByText(string text)
        {
            return await _context.Pokemons.Where(p => p.Nombre.ToLower()
                                          .Contains(text.ToLower()))
                                          .Select(p => new Pokemon
                                          {
                                              Id = p.Id,
                                              Nombre = p.Nombre,
                                              Descripcion = p.Descripcion,
                                              IdTipo = p.IdTipo,
                                              IdDebilidad = p.IdDebilidad,
                                              UrlImagen = p.UrlImagen,
                                              Precio = p.Precio,
                                              Cantidad = p.Cantidad,
                                              Activo = p.Activo,
                                          }).ToListAsync();
        }

        public async Task<IEnumerable<Pokemon>> FilterByCatActive(int idCat)
        {
            return await _context.Pokemons.Where(p => p.IdTipo == idCat && p.Activo == true)
                                          .Select(p => new Pokemon
                                          {
                                              Id = p.Id,
                                              Nombre = p.Nombre,
                                              Descripcion = p.Descripcion,
                                              IdTipo = p.IdTipo,
                                              IdDebilidad = p.IdDebilidad,
                                              UrlImagen = p.UrlImagen,
                                              Precio = p.Precio,
                                              Cantidad = p.Cantidad,
                                              Activo = p.Activo,
                                          }).ToListAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetAllActiveAsync()
        {
            return await _context.Pokemons.Where(p => p.Activo == true)
                                      .Select(p => new Pokemon
                                      {
                                          Id = p.Id,
                                          Nombre = p.Nombre,
                                          Descripcion = p.Descripcion,
                                          IdTipo = p.IdTipo,
                                          IdDebilidad = p.IdDebilidad,
                                          UrlImagen = p.UrlImagen,
                                          Precio = p.Precio,
                                          Cantidad = p.Cantidad,
                                          Activo = p.Activo
                                      }).ToListAsync();

        }

        public async Task EditAsync(Pokemon product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(Pokemon product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon product)
        {
             _context.Pokemons.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IdCatExist(int id)
        {
            return await _context.Pokemons.AnyAsync(p => p.IdTipo == id);
        }    
    }
}
