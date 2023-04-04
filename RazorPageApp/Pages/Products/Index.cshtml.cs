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

        public IndexModel(IDataContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            this.Products = await _context.Products.GetAll().ToListAsync();
        }
    }
}
