using DataLayer.Data;
using DataLayer.ExtensionMethods;
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
        public string SearchTerm { get; set; } = string.Empty;

        public IndexModel(IDataContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            //this.Products = await _context.Products.GetAll().Include(p => p.Category).Include(p => p.Brand).Include(p => p.Images).Page(1, 9).ToListAsync();
            this.Products = await _context.Products.GetAll().Include(p => p.Brand).Include(p => p.Images).Page(1, 9).ToListAsync();
        }
    }
}
