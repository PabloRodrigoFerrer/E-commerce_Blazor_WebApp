using Entity;
using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ProductService
    {
        private readonly IRepositoryPokemon<Pokemon> _repositoryPoke;
        public ProductService(IRepositoryPokemon<Pokemon> repository)
        {
            _repositoryPoke = repository;
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
           => await _repositoryPoke.GetAllAsync();

        public async Task<IEnumerable<Pokemon>> GetAllAsyncActive() 
        {
            return await _repositoryPoke.GetAllActiveAsync();
        }

        public async Task<(bool Success, string Message)> GuardarAsync(Pokemon poke)
        {
            if (poke.Precio < 0)
                return (false, "El precio no puede ser negativo");

            if (string.IsNullOrEmpty(poke.Nombre))
                return (false, "El nombre es obligatorio");

            if (poke.Id == 0)
                await _repositoryPoke.AddAsync(poke);
            else
                await _repositoryPoke.EditAsync(poke);

            return (true, "Guardado correctamente");
        }

        public async Task EliminarAsync(Pokemon poke)
        {
            var product = await _repositoryPoke.GetByIdAsync(poke.Id);

            if (product == null) return;

            await _repositoryPoke.DeleteAsync(product);
        }

        public async Task<Pokemon> GetById(int id) 
        {
            var product = await _repositoryPoke.GetByIdAsync(id);

            if (product == null) return new Pokemon();

            return product;
        }

        public async Task<IEnumerable<Pokemon>> FilterByCatActive(int idElemento) 
        {
            if (idElemento == 0) return null;

            var exist = await _repositoryPoke.IdCatExist(idElemento);
            
            if(exist)
                return await _repositoryPoke.FilterByCatActive(idElemento);

            return Enumerable.Empty<Pokemon>();
        }

        public async Task<IEnumerable<Pokemon>> SearchByText(string text) 
        {
            if(text != null)
                return await _repositoryPoke.SearchByText(text);

            return Enumerable.Empty<Pokemon>(); ;
        }

    }
}
