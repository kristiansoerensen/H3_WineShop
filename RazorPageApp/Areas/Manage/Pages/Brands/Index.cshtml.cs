using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Areas.Manage.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly IDataContext _context;
        public List<Brand> Brands { get; set; } = default!;
        public IndexModel(IDataContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            this.Brands = this._context.Brands.GetAll().ToList();
        }
    }
}
