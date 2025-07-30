using Application;
using Entity;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

namespace BlazorWebAppPrueba.Helpers
{
    public class SearchService
    {
        private readonly ProductService _productService;
        public SearchService(ProductService productService) 
        {
            _productService = productService;
        }

        public string SearchText { get; set; } = string.Empty;

        public event Action? OnChange;

        public void SetSearchText(string text) 
        {
            SearchText = text;
            OnChange?.Invoke();
        }

        public async Task<IEnumerable<Pokemon>> FilterNavbar()
        {
            if (string.IsNullOrEmpty(SearchText))
                return await _productService.GetAllAsyncActive();
            
            return await _productService.SearchByText(SearchText);
        }
    }
}
