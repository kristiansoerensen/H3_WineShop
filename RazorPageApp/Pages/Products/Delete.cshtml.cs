using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Pages.Products
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
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            Product? product = await _context.Products.GetById(id);

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
            Product? product = await _context.Products.GetById(id);

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
