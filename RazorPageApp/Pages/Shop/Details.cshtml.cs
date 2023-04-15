using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPageApp.Pages.Shop
{
    public class DetailsModel : PageModel
    {
        private readonly IDataContext _context;
        public Product Product { get; set; } = default!;
        public IList<Product> RelatedProducts { get; set; } = default!;

        public DetailsModel(IDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            this.RelatedProducts = await _context.Products.GetAll().Include(p => p.Brand).Include(p => p.Images).Include(p => p.ProductCategories).Take(5).ToListAsync();
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            Product? product = await _context.Products.GetAll().Where(p => p.Id == id).Include(p => p.Brand).Include(p => p.Images).Include(p => p.ProductCategories).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }
            this.Product = product;
            return Page();
        }
    }
}
