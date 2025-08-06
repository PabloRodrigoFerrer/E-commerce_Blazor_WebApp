using Entity;
using Entity.Interfaces;


namespace Application
{
    public class CarritoService
    {
        
        private readonly IMapper<Pokemon,CarritoItem> _mapToCarritoItem;

        private readonly List<CarritoItem> _items = new();

        public IEnumerable<CarritoItem> Items => _items;

        public CarritoService(IMapper<Pokemon,CarritoItem> mapper) 
        {
            _mapToCarritoItem = mapper;
        }


        public async Task AgregarCarrito(Pokemon poke)
        {
            var item = await _mapToCarritoItem.Map(poke);
            var existente =_items.FirstOrDefault(c => c.PokeId == item.PokeId);

            if (existente != null && existente.Cantidad < existente.CantidadMax)
                existente.Cantidad++;
            
            if(existente == null)
                _items.Add(item);
        } 
        
        public void EliminarDeCarrito(CarritoItem item) => _items.Remove(item);

        public void LimpiarCarrito() => _items.Clear();      

        public bool IsInCart(int id) 
        {
            var item = _items.FirstOrDefault(i => i.PokeId == id);

            if (item != null)
                return true;

            return false;
        }
    }
}
