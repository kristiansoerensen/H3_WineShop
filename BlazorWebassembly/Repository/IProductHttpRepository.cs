using BlazorWebassembly.Models;
using BlazorWebassembly.DTOs;

namespace BlazorWebassembly.Repository
{
    public interface IProductHttpRepository
    {
        Task<PagedProducts> GetPagedProducts(string queryString = "");
        Task<ProductDTO> GetProduct(int id, string queryString = "");
    }
}
