using BlazorWebassembly.Models;

namespace BlazorWebassembly.Repository
{
    public interface IProductHttpRepository
    {
        Task<PagedProducts> GetPagedProducts(string queryString = "");
    }
}
