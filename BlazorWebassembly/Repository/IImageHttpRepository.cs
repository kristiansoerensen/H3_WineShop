using BlazorWebassembly.Models;
using BlazorWebassembly.DTOs;

namespace BlazorWebassembly.Repository
{
    public interface IImageHttpRepository
    {
        Task<ImageDTO> GetImage(int id, string queryString = "");
        Task<List<ImageDTO>> GetImages(List<int> imageIds);
    }
}
