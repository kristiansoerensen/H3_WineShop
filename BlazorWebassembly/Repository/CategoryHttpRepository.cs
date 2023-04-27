using System.Text.Json;
using BlazorWebassembly.Models;

namespace BlazorWebassembly.Repository
{
    public class CategoryHttpRepository : ICategoryHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public CategoryHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<PagedCategories> GetPagedCategories(string queryString = "")
        {
            var response = await _client.GetAsync("categories?" + queryString);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var PagedCategories = JsonSerializer.Deserialize<PagedCategories>(content, _options);
            return PagedCategories != null ? PagedCategories : new PagedCategories();
        }
    }
}
