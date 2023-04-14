using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPageApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IDataContext _context;
        public IList<Product> Products { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(IDataContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            this.Products = await _context.Products.GetAll().Include(p => p.Category).Include(p => p.Brand).ToListAsync();
        }
    }
}
