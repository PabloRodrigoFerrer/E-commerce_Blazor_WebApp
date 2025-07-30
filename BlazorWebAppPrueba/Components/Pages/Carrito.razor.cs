using Application;
using Entity;
using Microsoft.AspNetCore.Components;

namespace BlazorWebAppPrueba.Components.Pages
{
    public partial class Carrito : ComponentBase
    {

        public void RefreshQuantity(CarritoItem item, string cantidad) 
        {
            //var CartItem = Cart.Items.FirstOrDefault(i => i.PokeId == item.PokeId);
            item.Cantidad = int.Parse(cantidad);
                 
        }
       
    }
}
