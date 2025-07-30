using Entity;
using Entity.Interfaces;

namespace Application
{
    public class MapToCarritoItem :IMapper<Pokemon, CarritoItem>
    {

        public CarritoItem Map(Pokemon pokemon)
        {
            return new CarritoItem
            {
                PokeId = pokemon.Id,
                PokeName = pokemon.Nombre,
                Cantidad = 1,
                PrecioUnitario = pokemon.Precio,
                CantidadMax = pokemon.Cantidad
            };  
         
        }
    }
}
