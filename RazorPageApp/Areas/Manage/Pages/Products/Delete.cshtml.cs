using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPageApp.Areas.Manage.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IDataContext _context;

        public DeleteModel(IDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            Product? product = _context.Products.GetAll().Where(p => p.Id == id).Include(p => p.Images).Include(p => p.Brand).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                this.Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            Product? product = _context.Products.GetAll().Where(p => p.Id == id).Include(p => p.Images).Include(p => p.Brand).FirstOrDefault();

            if (product != null)
            {
                this.Product = product;
                _context.Products.Delete(product);
                await _context.CommitAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
