using DataLayer.DTOs;

namespace WebAPI.Models
{
    public class PagedProducts
    {
        public string SearchTerm { get; set; } = string.Empty;
        public List<int> CategoryIds { get; set; } = new List<int>();
        public int PageSize { get; set; }
        public int OrderBy { get; set; }
        public int CurrentPage { get; set; }
        public int NumOfPages { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
