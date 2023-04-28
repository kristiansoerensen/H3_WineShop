using BlazorWebassembly.Models;
using BlazorWebassembly.DTOs;

namespace BlazorWebassembly.Repository
{
    public interface IBasketItemHttpRepository
    {
        Task<BasketDTO> GetBasketItem(int id, string queryString = "");
        Task<List<BasketItemDTO>> GetBasketItems(string queryString = "");
    }
}
