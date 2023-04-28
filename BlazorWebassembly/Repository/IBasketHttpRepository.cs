using BlazorWebassembly.Models;
using BlazorWebassembly.DTOs;

namespace BlazorWebassembly.Repository
{
    public interface IBasketHttpRepository
    {
        Task<BasketDTO> GetBasket(int id, string queryString = "");
        Task<int?> CreateBasket(BasketDTO basket);
    }
}
