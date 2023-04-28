using System.Text.Json;
using BlazorWebassembly.Models;
using BlazorWebassembly.DTOs;

namespace BlazorWebassembly.Repository
{
    public class BasketHttpRepository : IBasketHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public BasketHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        
        public async Task<BasketDTO> GetBasket(int id, string queryString = "")
        {
            var response = await _client.GetAsync("basket/" + id + "?" + queryString);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var item = JsonSerializer.Deserialize<BasketDTO>(content, _options);
            return item != null ? item : new BasketDTO();
        }

        public async Task<int?> CreateBasket(BasketDTO basket)
        {
            var response = await _client.PostAsync("basket", new StringContent(JsonSerializer.Serialize<BasketDTO>(basket)));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<int>(content, _options);
        }
    }
}
