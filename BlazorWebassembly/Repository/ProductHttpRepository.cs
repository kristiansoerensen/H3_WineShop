using System.Text.Json;
using BlazorWebassembly.Models;

namespace BlazorWebassembly.Repository
{
    public class ProductHttpRepository : IProductHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public ProductHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<PagedProducts> GetPagedProducts(string queryString = "")
        {
            var response = await _client.GetAsync("products?" + queryString);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var PagedProducts = JsonSerializer.Deserialize<PagedProducts>(content, _options);
            return PagedProducts != null ? PagedProducts : new PagedProducts();
        }
    }
}
