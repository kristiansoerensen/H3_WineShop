using System.Text.Json;
using BlazorWebassembly.Models;
using BlazorWebassembly.DTOs;

namespace BlazorWebassembly.Repository
{
    public class ImageHttpRepository : IImageHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public ImageHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        
        public async Task<ImageDTO> GetImage(int id, string queryString = "")
        {
            var response = await _client.GetAsync("image/" + id + "?" + queryString);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var item = JsonSerializer.Deserialize<ImageDTO>(content, _options);
            return item != null ? item : new ImageDTO();
        }

        public async Task<List<ImageDTO>> GetImages(List<int> imageIds)
        {
            List<ImageDTO> images = new List<ImageDTO>();
            foreach (var imageId in imageIds)
            {
                var response = await _client.GetAsync("image/" + imageId);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
                var image = JsonSerializer.Deserialize<ImageDTO>(content, _options);
                if (image != null)
                {
                    images.Add(image);
                }
            }
            return images;
        }
    }
}
