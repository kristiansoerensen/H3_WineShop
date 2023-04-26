using BlazorWebassembly.Models;

namespace BlazorWebassembly.Repository
{
    public interface ICategoryHttpRepository
    {
        Task<PagedCategories> GetPagedCategories(string queryString = "");
    }
}
