using System.Text.Json;
using BlazorWebassembly.Models;
using BlazorWebassembly.DTOs;

namespace BlazorWebassembly.Repository
{
    public class BasketItemHttpRepository : IBasketItemHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public BasketItemHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        
        public async Task<BasketDTO> GetBasketItem(int id, string queryString = "")
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

        public async Task<List<BasketItemDTO>> GetBasketItems(string queryString = "")
        {
            var response = await _client.GetAsync("basketitems?" + queryString);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var items = JsonSerializer.Deserialize<List<BasketItemDTO>>(content, _options);
            return items != null ? items : new List<BasketItemDTO>();
        }
    }
}
