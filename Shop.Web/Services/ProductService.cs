using Models.Dtos;
using Shop.Web.Services.Contracts;
using System.Net.Http.Json;

namespace Shop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetProductDtosAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
            return items;
        }

        public async Task<ProductDto> GetProductsByIdAsync(int id)
        {
            var item = await _httpClient.GetFromJsonAsync<ProductDto>($"api/Product/{id}");
            return item;
        } 
    }
}
