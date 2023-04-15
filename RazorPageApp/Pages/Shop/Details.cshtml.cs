using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Pages.Shop
{
    public class DetailsModel : PageModel
    {
        private readonly IDataContext _context;
        public Product Product { get; set; } = default!;

        public DetailsModel(IDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            Product? product = await _context.Products.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            this.Product = product;
            return Page();
        }
    }
}
