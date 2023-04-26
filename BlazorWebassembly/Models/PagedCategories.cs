using BlazorWebassembly.DTOs;

namespace BlazorWebassembly.Models
{
    public class PagedCategories
    {
        public string SearchTerm { get; set; } = string.Empty;
        public List<int> CategoryIds { get; set; } = new List<int>();
        public int PageSize { get; set; } = 9;
        public int OrderBy { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
        public int NumOfPages { get; set; } = 1;
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
