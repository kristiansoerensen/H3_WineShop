using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Areas.Manage.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IDataContext _context;
        public List<Category> Categories { get; set; } = default!;
        public IndexModel(IDataContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            this.Categories = this._context.Categories.GetAll().ToList();
        }
    }
}
