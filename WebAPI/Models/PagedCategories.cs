using DataLayer.DTOs;

namespace WebAPI.Models
{
    public class PagedCategories
    {
        public string SearchTerm { get; set; } = string.Empty;
        public int PageSize { get; set; } = 9;
        public int OrderBy { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
        public int NumOfPages { get; set; } = 1;
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}
