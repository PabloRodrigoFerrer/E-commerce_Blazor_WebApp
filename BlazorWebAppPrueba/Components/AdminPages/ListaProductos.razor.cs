using Application;
using Entity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorWebAppPrueba.Components.AdminPages
{
    public partial class ListaProductos : ComponentBase
    {
        [Inject]
        private ProductService _productService { get; set; }
        private List<Pokemon> _listaPokemons { get; set; } = new();

        private PaginationState _paginationState = new PaginationState { ItemsPerPage = 5 };

        private string? _txtFiltro { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _listaPokemons = (List<Pokemon>)await _productService.GetAllAsync();
        }

        private void OnPaginationSizeChanged(ChangeEventArgs e)
        {
            if (e.Value is not null)
                _paginationState.ItemsPerPage = int.Parse((string)e.Value);
        }

        private async Task HandleKeyDown(KeyboardEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtFiltro))
                _listaPokemons = (List<Pokemon>)await _productService.GetAllAsync();

            if (e.Key == "Enter" && _txtFiltro != "")
                _listaPokemons = _listaPokemons.FindAll(p => p.Nombre.ToLower().Contains(_txtFiltro.ToLower()));
        }

        private void NavToAltaProducto(int Id) => NavManager.NavigateTo("/altaProducto/" + Id);

    }
}
