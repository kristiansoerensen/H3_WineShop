using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPageApp.Areas.Manage.Pages.Products
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

            Product? product = _context.Products.GetAll().Where(p => p.Id == id).Include(p => p.Images).Include(p => p.Brand).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            this.Product = product;
            return Page();
        }
    }
}
