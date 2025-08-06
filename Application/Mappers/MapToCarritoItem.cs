using Entity;
using Entity.Interfaces;

namespace Application
{
    public class MapToCarritoItem :IMapper<Pokemon, CarritoItem>
    {
        private readonly IRepositoryElemento<Elemento> _repositoryElemento;

        public MapToCarritoItem(IRepositoryElemento<Elemento> repositoryElemento)
        {
            _repositoryElemento = repositoryElemento;
        }

        public async Task<CarritoItem> Map(Pokemon pokemon)
        {
            var elemento = await _repositoryElemento.GetElementById(pokemon.IdTipo);

            return new CarritoItem
            {
                PokeId = pokemon.Id,
                PokeName = pokemon.Nombre,
                PokeTipo = elemento,
                Cantidad = 1,
                PrecioUnitario = pokemon.Precio,
                CantidadMax = pokemon.Cantidad
            };  
         
        }
    }
}
